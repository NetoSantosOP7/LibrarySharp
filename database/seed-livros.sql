-- ============================================================
-- SEED — popula a tabela Livros com 19 registros de exemplo
-- Rodar tanto no banco local (SSMS) quanto no Azure SQL,
-- depois de garantir que a tabela Livros já existe.
-- As imagens referenciadas em CaminhoImagem precisam estar
-- fisicamente em wwwroot/imagens/ ANTES de publicar o projeto,
-- pra serem versionadas junto no Git e sobreviverem a um republish.
-- ============================================================

INSERT INTO Livros (Titulo, Autor, AnoPublicacao, Disponivel, CaminhoImagem) VALUES
('Confissões de Santo Agostinho (Ed. 1620 anos)', 'Santo Agostinho', 400, 1, 'confissoes-agostinho.jpg'),
('Padre Pio: Vida, Carisma e Legado', 'Rogério Melo', 2022, 1, 'padre-pio.jpg'),
('Percy Jackson e os Olimpianos: O Ladrão de Raios', 'Rick Riordan', 2005, 1, 'percy-jackson-1.jpg'),
('Batman #78 — City of Bane', 'Tom King', 2019, 1, 'batman-78.jpg'),
('Batman by Tom King Omnibus Vol. 1', 'Tom King', 2021, 1, 'batman-tomking-omnibus.jpg'),
('The Amazing Spider-Man #345', 'David Michelinie', 1991, 1, 'asm-345.jpg'),
('Amazing Spider-Man: Brand New Day', 'Dan Slott', 2008, 1, 'asm-brandnewday.jpg'),
('Naruto Vol. 43', 'Masashi Kishimoto', 2009, 1, 'naruto-43.jpg'),
('Naruto Vol. 67', 'Masashi Kishimoto', 2014, 1, 'naruto-67.jpg'),
('Naruto Vol. 53', 'Masashi Kishimoto', 2011, 1, 'naruto-53.jpg'),
('One Piece Vol. 97', 'Eiichiro Oda', 2021, 1, 'one-piece-97.jpg'),
('Dragon Ball Vol. 1', 'Akira Toriyama', 1985, 1, 'dragon-ball-1.jpg'),
('Dragon Ball Super Vol. 12', 'Akira Toriyama / Toyotarou', 2019, 1, 'dragon-ball-super-12.jpg'),
('V Jump — Boruto: Two Blue Vortex (ed. 8)', 'Masashi Kishimoto', 2025, 0, 'vjump-boruto-8.jpg'),
('Boruto: Two Blue Vortex Vol. 2', 'Masashi Kishimoto / Mikio Ikemoto', 2024, 1, 'boruto-tbv-2.jpg'),
('V Jump — Boruto: Two Blue Vortex (ed. 10)', 'Masashi Kishimoto', 2025, 0, 'vjump-boruto-10.jpg'),
('V Jump — Boruto: Two Blue Vortex (ed. 6, 10º aniversário)', 'Masashi Kishimoto', 2025, 0, 'vjump-boruto-6.jpg'),
('Boruto: Two Blue Vortex Vol. 2 (capa alt.)', 'Masashi Kishimoto / Mikio Ikemoto', 2024, 1, 'boruto-tbv-2-alt.jpg'),
('Devocionário São Bento', 'Candeia Nova', 2020, 1, 'devocionario-sao-bento.jpg');

-- Define a ordem inicial do grid (a mesma ordem de inserção)
UPDATE Livros SET Ordem = Id WHERE Ordem IS NULL;
