-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.36 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.6.0.6765
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for reading_recommendation_db
CREATE DATABASE IF NOT EXISTS `reading_recommendation_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `reading_recommendation_db`;

-- Dumping structure for table reading_recommendation_db.book
CREATE TABLE IF NOT EXISTS `book` (
  `book_id` int NOT NULL AUTO_INCREMENT,
  `book_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`book_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table reading_recommendation_db.book: ~3 rows (approximately)
INSERT INTO `book` (`book_id`, `book_name`) VALUES
	(1, 'Harry Potter'),
	(2, 'The Kite Runner'),
	(3, 'The Great Gatsby');
	
	-- Dumping structure for table reading_recommendation_db.user
CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table reading_recommendation_db.user: ~0 rows (approximately)
INSERT INTO `user` (`user_id`) VALUES
	(1),
	(2),
	(3);
	

-- Dumping structure for table reading_recommendation_db.reading_interval
CREATE TABLE IF NOT EXISTS `reading_interval` (
  `reading_id` int NOT NULL AUTO_INCREMENT,
  `user_id` int DEFAULT NULL,
  `book_id` int DEFAULT NULL,
  `start_page` int DEFAULT NULL,
  `end_page` int DEFAULT NULL,
  `timestamp` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`reading_id`),
  KEY `user_id` (`user_id`),
  KEY `book_id` (`book_id`),
  CONSTRAINT `reading_interval_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `user` (`user_id`),
  CONSTRAINT `reading_interval_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `book` (`book_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table reading_recommendation_db.reading_interval: ~5 rows (approximately)
INSERT INTO `reading_interval` (`reading_id`, `user_id`, `book_id`, `start_page`, `end_page`, `timestamp`) VALUES
	(2, 1, 1, 10, 30, '2024-04-08 14:52:10'),
	(3, 1, 1, 2, 25, '2024-04-08 14:53:26'),
	(4, 1, 2, 40, 50, '2024-04-08 16:49:56'),
	(5, 3, 2, 1, 10, '2024-04-08 16:51:14'),
	(6, 3, 3, 1, 10, '2024-04-08 17:10:21'),
	(7, 3, 3, 40, 60, '2024-04-08 17:14:29');



/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
