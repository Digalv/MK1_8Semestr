ТЕСТОВЫЕ ДАННЫЕ, ВСТАВИТЬ В SQL


CREATE DATABASE db_mk1sem8;

\c db_mk1sem8;

CREATE TABLE brands (
    id UUID PRIMARY KEY,
    title VARCHAR(255) NOT NULL
);

CREATE TABLE categories (
    id UUID PRIMARY KEY,
    title VARCHAR(255) NOT NULL
);

CREATE TABLE products (
    id UUID PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    amount INT NOT NULL,
    brand_id UUID,
    FOREIGN KEY (brand_id) REFERENCES brands(id)
);

CREATE TABLE product_categories (
    product_id UUID REFERENCES products(id) ON DELETE CASCADE,
    category_id UUID REFERENCES categories(id) ON DELETE CASCADE,
    PRIMARY KEY (product_id, category_id)
);

INSERT INTO categories (id, title) VALUES
    (gen_random_uuid(), 'Электроника'),
    (gen_random_uuid(), 'Одежда'),
    (gen_random_uuid(), 'Игрушки'),
    (gen_random_uuid(), 'Книги'),
    (gen_random_uuid(), 'Спорттовары');

INSERT INTO brands (id, title) VALUES
    (gen_random_uuid(), 'Brand A'),
    (gen_random_uuid(), 'Brand B'),
    (gen_random_uuid(), 'Brand C'),
    (gen_random_uuid(), 'Brand D'),
    (gen_random_uuid(), 'Brand E'),
    (gen_random_uuid(), 'Brand F'),
    (gen_random_uuid(), 'Brand G'),
    (gen_random_uuid(), 'Brand H'),
    (gen_random_uuid(), 'Brand I'),
    (gen_random_uuid(), 'Brand J');

INSERT INTO products (id, title, amount, brand_id) VALUES
    (gen_random_uuid(), 'Product 1', 10, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 2', 5, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 3', 8, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 4', 15, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 5', 12, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 6', 7, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 7', 20, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 8', 14, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 9', 6, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 10', 9, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 11', 11, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 12', 13, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 13', 16, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 14', 4, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1)),
    (gen_random_uuid(), 'Product 15', 3, (SELECT id FROM brands ORDER BY RANDOM() LIMIT 1));

INSERT INTO product_categories (product_id, category_id)
SELECT p.id, c.id
FROM products p
CROSS JOIN LATERAL (
    SELECT id FROM categories ORDER BY RANDOM() LIMIT 2
) c;
