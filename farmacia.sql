-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-06-2024 a las 14:55:47
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `farmacia`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `id_producto` int(10) NOT NULL,
  `codigo_producto` varchar(20) NOT NULL,
  `nombre` varchar(80) NOT NULL,
  `precio` varchar(10) NOT NULL,
  `cantidad` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`id_producto`, `codigo_producto`, `nombre`, `precio`, `cantidad`) VALUES
(1, '123', 'acetaminofen', '10$', '20'),
(2, '456', 'prospan', '5$', '10'),
(3, '789', 'ibuprofeno', '4$', '40'),
(4, '111', 'rifamacina', '10$', '20'),
(5, '222', 'amoxicilina', '6$', '50'),
(6, '333', 'atorvastatina', '7$', '30'),
(7, '444', 'diclofenac', '3$', '20'),
(8, '666', 'pantoprasol', '5$', '30'),
(9, '777', 'ketorolac', '7$', '50'),
(10, '555', 'erythromycin', '10$', '40');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `user_id` int(11) NOT NULL,
  `username` varchar(80) NOT NULL,
  `password` varchar(20) NOT NULL,
  `contrasena` varchar(20) NOT NULL,
  `fullname` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`user_id`, `username`, `password`, `contrasena`, `fullname`) VALUES
(1, 'karina', 'karina', 'karina', 'karina huang'),
(2, 'visita', 'visita', 'visita', 'visitante'),
(3, 'ana', 'ana', 'ana', 'ana diaz'),
(4, 'admin', 'admin', 'admin', 'administrador'),
(5, 'diana', 'diana', 'diana', 'diana diaz'),
(6, 'jesus', 'jesus', 'jesus', 'jesus perez'),
(7, 'andres', 'andres', 'andres', 'andres hernandez'),
(8, 'luis', 'luis', 'luis', 'luis silva'),
(9, 'maria', 'maria', 'maria', 'maria rodriguez'),
(10, 'andrea', 'andrea', 'andrea', 'andrea mata');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`id_producto`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`user_id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `id_producto` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
