create table tab_exhibits
(
    id int not null auto_increment primary key ,
    exhibit_name varchar(50) not null check(exhibit_name != ' '),
    id_author int not null,
    creation_date varchar(10),
    art_direction varchar(50),
    art_form varchar(50) not null check(art_form IN('картина', 'скульптура', 'утварь', 'мебель', 'посуда', 'ювелирные украшения', 'прочее')),
    materials varchar(100)
);

create table tab_author
(
    id int not null auto_increment primary key,
    author_name varchar(100) check (author_name!=' '),
    birth_date date,
    death_date date,
    birth_country varchar(50)
);

create table tab_storage
(
    id int not null auto_increment primary key,
    storage_name varchar(50) not null
);

create table tab_space_storage
(
    id int not null auto_increment primary key,
    id_exhibits int not null,
    id_storage int not null,
    special_conditions bool not null
);

INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (1, 'Джоконда', 1, '15050', '', 'картина', 'холст масло');
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (2, 'Лошадь и всадник', 1, null, null, 'скульптура', 'бронза');
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (3, 'Бульвар Монмартр в Париже', 2, '1897', 'импрессионизм', 'картина', null);
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (4, 'Въезд в деревню Вуазен', 2, '1872', 'импрессионизм', 'картина', null);
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (5, 'Мыслитель', 3, '1888', 'импрессионизм', 'скульптура', 'бронза');
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (6, 'Поцелуй', 3, '1889', 'импрессионизм', 'скульптура', 'мрамор');
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (9, 'Брошь Ирис', 4, null, null, 'ювелирные украшения', 'резной камень бриллианты');
INSERT INTO host1323541_shambala1.tab_exhibits (id, exhibit_name, id_author, creation_date, art_direction, art_form, materials) VALUES (10, 'Портсигар', 4, null, null, 'прочее', 'серебро эмаль');

INSERT INTO host1323541_shambala1.tab_storage (id, storage_name) VALUES (1, 'зал 1');
INSERT INTO host1323541_shambala1.tab_storage (id, storage_name) VALUES (2, 'зал 2');
INSERT INTO host1323541_shambala1.tab_storage (id, storage_name) VALUES (3, 'хранилище 1');
INSERT INTO host1323541_shambala1.tab_storage (id, storage_name) VALUES (4, 'хранилище 2');

INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (1, 1, 1, 1);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (2, 2, 1, 0);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (3, 3, 2, 0);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (4, 4, 2, 0);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (5, 5, 2, 0);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (6, 6, 3, 0);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (7, 9, 2, 1);
INSERT INTO host1323541_shambala1.tab_space_storage (id, id_exhibits, id_storage, special_conditions) VALUES (8, 10, 4, 1);

