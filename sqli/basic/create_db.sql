CREATE TABLE users (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    username VARCHAR(100) NOT NULL,
    password VARCHAR(255) NOT NULL,
    is_admin BOOLEAN NOT NULL
);

INSERT INTO users (id, username, password, is_admin)
VALUES
    (1, 'admin', '827ccb0eea8a706c4c34a16891f84e7b', true),
    (2, 'developer', '5e8edd851d2fdfbd7415232c67367cc3', false),
    (3, 'hacker', 'd6a6bc0db10694a2d90e3a69648f3a03', false);
