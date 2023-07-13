-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               8.0.31 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.2.0.6576
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for employee_management_system
CREATE DATABASE IF NOT EXISTS `employee_management_system` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `employee_management_system`;

-- Dumping structure for table employee_management_system.departments
CREATE TABLE IF NOT EXISTS `departments` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.departments: ~0 rows (approximately)
INSERT INTO `departments` (`id`, `name`) VALUES
	(1, 'IT Department');

-- Dumping structure for table employee_management_system.designations
CREATE TABLE IF NOT EXISTS `designations` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.designations: ~0 rows (approximately)
INSERT INTO `designations` (`id`, `name`) VALUES
	(1, 'Chief Marketing Officer');

-- Dumping structure for table employee_management_system.employees
CREATE TABLE IF NOT EXISTS `employees` (
  `id` int NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) NOT NULL,
  `date_of_birth` varchar(50) NOT NULL DEFAULT '',
  `address` varchar(100) NOT NULL,
  `email` varchar(45) NOT NULL,
  `mobile_number` varchar(10) NOT NULL,
  `home_number` varchar(10) NOT NULL,
  `gender_id` int NOT NULL,
  `department_id` int NOT NULL,
  `designation_id` int NOT NULL,
  `emp_type_id` int NOT NULL,
  `is_removed` tinyint NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `fk_empoyees_genders_idx` (`gender_id`),
  KEY `fk_empoyees_departments1_idx` (`department_id`),
  KEY `fk_empoyees_designations1_idx` (`designation_id`),
  KEY `fk_empoyees_emp_types1_idx` (`emp_type_id`),
  CONSTRAINT `fk_empoyees_departments1` FOREIGN KEY (`department_id`) REFERENCES `departments` (`id`),
  CONSTRAINT `fk_empoyees_designations1` FOREIGN KEY (`designation_id`) REFERENCES `designations` (`id`),
  CONSTRAINT `fk_empoyees_emp_types1` FOREIGN KEY (`emp_type_id`) REFERENCES `emp_types` (`id`),
  CONSTRAINT `fk_empoyees_genders` FOREIGN KEY (`gender_id`) REFERENCES `genders` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.employees: ~2 rows (approximately)
INSERT INTO `employees` (`id`, `first_name`, `last_name`, `date_of_birth`, `address`, `email`, `mobile_number`, `home_number`, `gender_id`, `department_id`, `designation_id`, `emp_type_id`, `is_removed`) VALUES
	(1, 'Tharindu', 'Nimesh', '2023-12-12', 'tharindunimesh.abc@gmail.com', '693/3, Gonawala, Kelaniya.', '0701189971', '0112401967', 1, 1, 1, 1, 0),
	(2, 'Dilini', 'Tharaka', '2001-05-17', 'dilinitharaka@gmail.com', '693/3, Gonawala, Kelaniyaa.', '0701189971', '0112401967', 1, 1, 1, 1, 1);

-- Dumping structure for table employee_management_system.emp_types
CREATE TABLE IF NOT EXISTS `emp_types` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.emp_types: ~0 rows (approximately)
INSERT INTO `emp_types` (`id`, `type`) VALUES
	(1, 'Part Time Employee');

-- Dumping structure for table employee_management_system.genders
CREATE TABLE IF NOT EXISTS `genders` (
  `id` int NOT NULL AUTO_INCREMENT,
  `type` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.genders: ~2 rows (approximately)
INSERT INTO `genders` (`id`, `type`) VALUES
	(1, 'Male'),
	(2, 'Female');

-- Dumping structure for table employee_management_system.secure_key
CREATE TABLE IF NOT EXISTS `secure_key` (
  `key` varchar(50) NOT NULL DEFAULT '',
  PRIMARY KEY (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.secure_key: ~0 rows (approximately)
INSERT INTO `secure_key` (`key`) VALUES
	('112233');

-- Dumping structure for table employee_management_system.users
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3;

-- Dumping data for table employee_management_system.users: ~0 rows (approximately)
INSERT INTO `users` (`id`, `name`, `username`, `password`, `email`) VALUES
	(1, 'Tharindu', 'tharindu01', '112233', 'tharindunimesh.abc@gmail.com'),
	(2, 'Tharindu Nimesh', 'tharindunimesh', '112233', 'tharindunimesh@gmail.com');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
