CREATE TABLE tab_users (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    email VARCHAR(255) NOT NULL,
    first_name VARCHAR(125) NOT NULL,
    last_name VARCHAR(125) NOT NULL,
    middle_name VARCHAR(125)
);

CREATE TABLE tab_news (
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL,
    content TEXT NOT NULL,
    date_of_creation DATETIME NOT NULL,
    author INT NOT NULL,
    FOREIGN KEY (author) REFERENCES tab_users(id) 
        ON UPDATE NO ACTION 
        ON DELETE NO ACTION 
);