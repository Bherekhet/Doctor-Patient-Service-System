-- --------------------------------------------------------
-- Host:                         csdatabase.eku.edu
-- Server version:               10.2.6-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for csc340_db
CREATE DATABASE IF NOT EXISTS `csc340_db` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `csc340_db`;

-- Dumping structure for table csc340_db.wzb_appointment
CREATE TABLE IF NOT EXISTS `wzb_appointment` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Date` date DEFAULT NULL,
  `Time` varchar(15) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `Doctor_ID` int(11) DEFAULT NULL,
  `Patient_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Doctor_ID` (`Doctor_ID`),
  KEY `Patient_ID` (`Patient_ID`),
  CONSTRAINT `appointment_ibfk_1` FOREIGN KEY (`Doctor_ID`) REFERENCES `doctor` (`ID`),
  CONSTRAINT `appointment_ibfk_2` FOREIGN KEY (`Patient_ID`) REFERENCES `patient` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_appointment: ~54 rows (approximately)
/*!40000 ALTER TABLE `wzb_appointment` DISABLE KEYS */;
INSERT INTO `wzb_appointment` (`ID`, `Date`, `Time`, `Description`, `Doctor_ID`, `Patient_ID`) VALUES
	(7, '2018-12-07', '1:00:00 PM', 'dbdbdbdb', 1, 1),
	(13, '2018-12-25', '1:00:00 PM', 'erwffqfqwefqweffqwf', 1, 4),
	(14, '2019-01-05', '1:00:00 PM', 'tyjtejejet', 1, 4),
	(15, '2018-12-25', '3:00:00 PM', '', 1, 1),
	(16, '2018-12-07', '3:00:00 PM', 'erterwtetqer', 1, 1),
	(17, '2019-03-28', '8:00:00 AM', '', 1, 5),
	(18, '2018-12-25', '10:00:00 AM', '', 1, 5),
	(19, '2019-02-22', '10:00:00 AM', '', 1, 1),
	(20, '2018-12-18', '3:00:00 PM', 'adsad', 1, 16),
	(21, '2018-12-07', '8:00:00 AM', 'eggwgeg', 4, 1),
	(22, '2018-12-07', '10:00:00 AM', 'dfad', 1, 3),
	(23, '2018-12-20', '10:00:00 AM', 'adjkasd', 4, 2),
	(24, '2018-12-21', '1:00:00 PM', 'jkj', 1, 3),
	(25, '2018-12-19', '1:00:00 PM', 'Need to talk.', 2, 3),
	(26, '2019-02-22', '1:00:00 PM', 'ergehherh', 1, 15),
	(27, '2019-03-15', '1:00:00 PM', 'yoyoyo', 3, 1),
	(28, '2019-05-30', '10:00:00 AM', 'Bad Cough', 1, 1),
	(29, '2018-12-28', '3:00:00 PM', 'Foot pain.', 1, 22),
	(30, '2019-05-08', '1:00:00 PM', '', 1, 1),
	(31, '2019-01-24', '10:00:00 AM', '', 4, 1),
	(32, '2019-01-25', '1:00:00 PM', 'Flu', 4, 1),
	(33, '2019-01-29', '10:00:00 AM', 'Test', 4, 5),
	(35, '2019-01-29', '1:00:00 PM', 'Test', 3, 5),
	(36, '2019-01-21', '8:00:00 AM', 'Test', 3, 5),
	(37, '2019-02-12', '1:00:00 PM', 'To discuss surgery ', 4, 1),
	(38, '2019-02-12', '3:00:00 PM', 'Just cause', 4, 12),
	(39, '2019-02-08', '1:00:00 PM', 'To discuss illness', 4, 1),
	(40, '2019-02-24', '1:00:00 PM', 'asdfghj', 4, 5),
	(41, '2019-02-26', '8:00:00 AM', 'asdfghj', 1, 5),
	(42, '2019-02-24', '10:00:00 AM', 'asdfghj', 4, 5),
	(43, '2019-02-25', '10:00:00 AM', 'asdfghj', 1, 5),
	(44, '2019-01-31', '10:00:00 AM', 'asdf', 3, 5),
	(45, '2019-03-14', '10:00:00 AM', 'asdf', 3, 28),
	(46, '2019-03-15', '10:00:00 AM', 'asdf', 1, 28),
	(47, '2019-02-06', '8:00:00 AM', 'Sick', 3, 2),
	(48, '2019-02-06', '8:00:00 AM', 'Sick', NULL, NULL),
	(49, '2019-02-06', '10:00:00 AM', '', 4, 1),
	(50, '2019-01-31', '1:00:00 PM', '', 4, 1),
	(51, '2019-01-31', '3:00:00 PM', '', 4, 1),
	(52, '2019-02-09', '3:00:00 PM', '', 4, 28),
	(53, '2019-02-05', '3:00:00 PM', 'njlkjkljlklkj;xkjlczjklxx', 4, 27),
	(54, '2019-03-02', '8:00:00 AM', 'I need my flu shots', 3, 5),
	(55, '2019-02-01', '10:00:00 AM', 'ddd', 4, 6),
	(56, '2019-02-01', '1:00:00 PM', '-=[[[[[[[[[[[[[[[[[[[[[[=-', 4, 5),
	(57, '2019-02-01', '8:00:00 AM', '', 4, 4),
	(58, '2019-02-01', '3:00:00 PM', '1234', 4, 5),
	(59, '2019-02-02', '3:00:00 PM', '', 4, 5),
	(60, '2019-02-06', '3:00:00 PM', 'I\'m feeling sick', 3, 5),
	(61, '2019-02-04', '3:00:00 PM', 'I\'m feeling sick', 3, 5),
	(62, '2019-02-04', '8:00:00 AM', 'I\'m feeling sick', 3, 5),
	(63, '2019-02-06', '1:00:00 PM', 'I\'m feeling sick', 4, 5),
	(64, '2019-02-04', '1:00:00 PM', 'I\'m feeling sick', 4, 5),
	(65, '2019-02-07', '8:00:00 AM', 'Cough', 4, 2),
	(66, '2019-02-07', '10:00:00 AM', 'i don\'t know', 4, 2),
	(67, '2019-02-28', '3:00:00 PM', 'Cold', 4, 38),
	(68, '2019-02-28', '8:00:00 AM', '; LIKE %ag%', 4, 38),
	(69, '2019-02-28', '1:00:00 PM', 'Help.', 3, 3),
	(70, '2019-03-08', '3:00:00 PM', 'Need to ', 3, 3),
	(71, '2019-02-28', '10:00:00 AM', '1', 3, 2);
/*!40000 ALTER TABLE `wzb_appointment` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_doctor
CREATE TABLE IF NOT EXISTS `wzb_doctor` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(60) DEFAULT NULL,
  `Phone` varchar(18) DEFAULT NULL,
  `Email` varchar(60) DEFAULT NULL,
  `Street_1` varchar(30) DEFAULT NULL,
  `Street_2` varchar(30) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `State` char(2) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  `Speciality` varchar(20) DEFAULT NULL,
  `Hospital` varchar(50) DEFAULT NULL,
  `User_name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_doctor: ~4 rows (approximately)
/*!40000 ALTER TABLE `wzb_doctor` DISABLE KEYS */;
INSERT INTO `wzb_doctor` (`ID`, `Name`, `Phone`, `Email`, `Street_1`, `Street_2`, `City`, `State`, `Country`, `Speciality`, `Hospital`, `User_name`) VALUES
	(1, 'William Abernathy', '8592007708', 'matthew.abernathy@hotmail.com', '123 Yellow Brick Rd', ' ', 'Irvine', 'KY', 'United States', 'Gout', 'Mercy Health', 'WAbernathy'),
	(2, 'Zachary Bray', '8591234567', 'zachary_bray@hotmail.com', '456 Drive From Lex', ' ', 'Lexington', 'KY', 'United States', 'Children', 'Pattie A Clay Wound Center', 'ZBray'),
	(3, 'Bereket Degefa', '8597654321', 'bereket.demisie@hotmail.com', '789 Across the Ocean', ' ', 'Nairobi', 'KE', 'Kenya', 'Burns, Surgery', 'Burn-Unit', 'BDegefa'),
	(4, 'Kuang-Nan Chang', '8596221935', 'kuangnan.Chang@eku.edu', '409 Wallace Building', ' ', 'Richmond', 'KY', 'United States', 'Migraines', 'Eastern Kentucky University', 'KChang');
/*!40000 ALTER TABLE `wzb_doctor` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_doctor_patient
CREATE TABLE IF NOT EXISTS `wzb_doctor_patient` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Family_doctor` tinyint(1) DEFAULT NULL,
  `Doctor_ID` int(11) DEFAULT NULL,
  `Patient_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `Doctor_ID` (`Doctor_ID`),
  KEY `Patient_ID` (`Patient_ID`),
  CONSTRAINT `doctor_patient_ibfk_1` FOREIGN KEY (`Doctor_ID`) REFERENCES `doctor` (`ID`),
  CONSTRAINT `doctor_patient_ibfk_2` FOREIGN KEY (`Patient_ID`) REFERENCES `patient` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_doctor_patient: ~16 rows (approximately)
/*!40000 ALTER TABLE `wzb_doctor_patient` DISABLE KEYS */;
INSERT INTO `wzb_doctor_patient` (`Id`, `Family_doctor`, `Doctor_ID`, `Patient_ID`) VALUES
	(1, 1, 4, 1),
	(2, 0, 4, 2),
	(3, 1, 4, 3),
	(4, 0, 4, 4),
	(5, 1, 1, 1),
	(6, 1, 1, 2),
	(7, 1, 1, 3),
	(8, 1, 1, 4),
	(9, 1, 2, 1),
	(10, 0, 2, 2),
	(11, 1, 2, 3),
	(12, 1, 2, 4),
	(13, 1, 3, 1),
	(14, 1, 3, 2),
	(15, 0, 3, 3),
	(16, 1, 3, 4);
/*!40000 ALTER TABLE `wzb_doctor_patient` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_logininfo
CREATE TABLE IF NOT EXISTS `wzb_logininfo` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_name` varchar(20) DEFAULT NULL,
  `Password` varchar(20) DEFAULT NULL,
  `Name` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_logininfo: ~8 rows (approximately)
/*!40000 ALTER TABLE `wzb_logininfo` DISABLE KEYS */;
INSERT INTO `wzb_logininfo` (`ID`, `User_name`, `Password`, `Name`) VALUES
	(1, 'WAbernathy', 'D123', 'Will(Doctor)'),
	(2, 'ZBray', 'D456', 'Zach(Doctor)'),
	(3, 'BDegefa', 'D789', 'Bereket(Doctor)'),
	(4, 'WAbernathy', 'P123', 'Will(Patient)'),
	(5, 'ZBray', 'P456', 'Zach(Patient)'),
	(6, 'BDegefa', 'P789', 'Bereket(Patient)'),
	(7, 'KChang', 'D913578461', 'Chang(Doctor)'),
	(8, 'KChang', 'P913578461', 'Chang(Patient)');
/*!40000 ALTER TABLE `wzb_logininfo` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_notice
CREATE TABLE IF NOT EXISTS `wzb_notice` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Type_is` varchar(2) DEFAULT NULL,
  `Response` varchar(2) DEFAULT NULL,
  `Send_to` int(11) DEFAULT NULL,
  `Received_from` int(11) DEFAULT NULL,
  `Message` varchar(8000) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=247 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_notice: ~211 rows (approximately)
/*!40000 ALTER TABLE `wzb_notice` DISABLE KEYS */;
INSERT INTO `wzb_notice` (`ID`, `Type_is`, `Response`, `Send_to`, `Received_from`, `Message`) VALUES
	(1, 'RD', NULL, 4, 1, 'Need benadryl for allergies!'),
	(2, 'RD', '0', 4, 3, 'Foot pain, wanting tylenol please.'),
	(3, 'AD', '0', 4, 3, 'Requesting Appointment.'),
	(4, 'PD', NULL, 4, 2, '8592311234 Questions about therapy.'),
	(5, 'PD', NULL, 4, 1, '8592007708 Curious about this medication.'),
	(6, 'RD', NULL, 1, 1, 'Need benadryl for allergies!'),
	(7, 'RD', NULL, 1, 3, 'Foot pain, wanting tylenol please.'),
	(8, 'AD', NULL, 1, 3, 'Requesting Appointment.'),
	(9, 'PD', NULL, 1, 2, '8592311234 Questions about therapy.'),
	(10, 'PD', NULL, 1, 1, '8592007708 Curious about this medication.'),
	(11, 'MP', '1', 1, 3, 'Wanted to double check allergies'),
	(12, 'MP', NULL, 2, 4, 'Foot pain, wanting tylenol please.'),
	(13, 'ER', NULL, 1, 3, 'Requesting a refill for Tylenol'),
	(14, 'NR', NULL, 1, 2, 'Need new opioid prescription'),
	(15, 'WP', NULL, 1, 1, 'Your prescription is ready!'),
	(16, 'DD', '1', 1, 2, 'I wanted to discuss a recent opioid prescription.'),
	(45, 'MP', '-1', 4, 1, 'Requesting Access to medical Records! '),
	(46, 'RP', '1', 5, 1, 'GRANTED! '),
	(47, 'RP', '0', 1, 1, 'REJECTED! '),
	(48, 'AD', '1', 1, 1, 'William Abernathy | 1:00:00 PM | 2018-12-07 | dbdbdbdb'),
	(49, 'RD', '-1', 1, 1, 'William Abernathy | addy | get crunk'),
	(50, 'PD', '-1', 3, 1, 'William Abernathy | 1234567890 | gtbwbb'),
	(51, 'AP', '1', 4, 1, 'New Appointment! erwffqfqwefqweffqwf | Date: 2018/12/25 At: 1:00:00 PM'),
	(52, 'AP', '1', 4, 1, 'New Appointment! tyjtejejet | Date: 2019/1/5 At: 1:00:00 PM'),
	(53, 'MP', '0', 3, 2, 'Requesting Access to medical Records! rtbtrwbwr'),
	(54, 'AP', '1', 1, 1, 'New Appointment!  | Date: 2018/12/25 At: 3:00:00 PM'),
	(55, 'RP', '1', 5, 1, 'GRANTED! '),
	(56, 'RP', '0', 1, 1, 'REJECTED! '),
	(57, 'MP', '1', 1, 1, 'Requesting Access to medical Records! '),
	(58, 'AD', '1', 1, 1, 'William Abernathy | 3:00:00 PM | 2018-12-07 | erterwtetqer'),
	(59, 'RD', '-1', 3, 1, 'William Abernathy | qert rervregrtq | qertqetqertqe'),
	(60, 'PD', '-1', 1, 1, 'William Abernathy | 345535134531 | egewgewgegwg'),
	(61, 'AP', '1', 5, 1, 'New Appointment!  | Date: 2019/3/28 At: 8:00:00 AM'),
	(62, 'RD', '-1', 1, 14, 'Bereket Degefa | dfdf | adasd'),
	(63, 'MP', '0', 3, 1, 'Requesting Access to medical Records! '),
	(64, 'MP', '-1', 1, 2, 'Requesting Access to medical Records! '),
	(65, 'AP', '1', 5, 1, 'New Appointment!  | Date: 2018/12/25 At: 10:00:00 AM'),
	(66, 'AP', '1', 1, 1, 'New Appointment!  | Date: 2019/2/22 At: 10:00:00 AM'),
	(67, 'MP', '0', 2, 1, 'Requesting Access to medical Records! '),
	(68, 'RP', '1', 4, 1, 'GRANTED! '),
	(69, 'RP', '0', 14, 1, 'REJECTED! '),
	(70, 'RD', '-1', 1, 16, 'Bereket Degefa | asdasd | asdads'),
	(71, 'AD', '1', 1, 16, 'Bereket Degefa | 3:00:00 PM | 2018-12-18 | adsad'),
	(72, 'PD', '-1', 4, 16, 'Bereket Degefa | asdad | sadad'),
	(73, 'AD', '1', 4, 1, 'William Abernathy | 8:00:00 AM | 2018-12-07 | eggwgeg'),
	(74, 'RD', '-1', 1, 1, 'William Abernathy | egegewg | 3t3ggrg3g'),
	(75, 'PD', '-1', 3, 1, 'William Abernathy | 34356635654 | rgbhthhwhhwrh'),
	(76, 'AP', '1', 3, 1, 'New Appointment! dfad | Date: 2018/12/7 At: 10:00:00 AM'),
	(77, 'MP', '0', 3, 1, 'Requesting Access to medical Records! '),
	(78, 'RP', '1', 14, 1, 'GRANTED! '),
	(79, 'MP', '0', 3, 1, 'Requesting Access to medical Records! '),
	(80, 'PD', '-1', 1, 17, 'Bereket Degefa | sdad | adad'),
	(81, 'MP', '0', 3, 1, 'Requesting Access to medical Records! '),
	(82, 'RD', '-1', 1, 3, 'Bereket Degefa | sdasdad | asdad'),
	(83, 'RD', '-1', 4, 2, 'Zachary Bray | adsd | dadsa'),
	(84, 'RD', '-1', 1, 2, 'Zachary Bray | 1231 | asdasd'),
	(85, 'RD', '-1', 1, 2, 'Zachary Bray | sadsd | asdad'),
	(86, 'AD', '1', 4, 2, 'Zachary Bray | 10:00:00 AM | 2018-12-20 | adjkasd'),
	(87, 'MP', '1', 1, 3, 'Requesting Access to medical Records! '),
	(88, 'MP', '1', 2, 3, 'Requesting Access to medical Records! '),
	(89, 'AD', '1', 1, 3, 'Bereket Degefa | 1:00:00 PM | 2018-12-21 | jkj'),
	(90, 'RD', '-1', 4, 3, 'Bereket Degefa | bhbh | jkj'),
	(91, 'PD', '-1', 4, 3, 'Bereket Degefa | hjgh | jkhh'),
	(92, 'RP', '0', 3, 2, 'REJECTED! '),
	(93, 'MP', '0', 3, 2, 'Requesting Access to medical Records! '),
	(94, 'MP', '1', 3, 4, 'Requesting Access to medical Records! '),
	(95, 'RP', '1', 3, 4, 'GRANTED! '),
	(96, 'RD', '-1', 3, 1, 'William Abernathy | Medicine1 | I ran out.'),
	(97, 'RP', '1', 1, 3, 'GRANTED! '),
	(98, 'RD', '-1', 2, 3, 'Bereket Degefa | Medicine2 | Need more.'),
	(99, 'RP', '1', 3, 3, 'GRANTED! '),
	(100, 'PD', '-1', 1, 3, 'Bereket Degefa | 999999999 | Call me.'),
	(101, 'RP', '0', 3, 1, 'REJECTED! '),
	(102, 'RD', '-1', 2, 3, 'Bereket Degefa | Medicine4 | Need arefill.'),
	(103, 'RP', '1', 2, 3, 'GRANTED! '),
	(104, 'MP', '0', 3, 2, 'Requesting Access to medical Records! '),
	(105, 'PD', '-1', 2, 3, 'Bereket Degefa | 1111111111 | Need to talk.'),
	(106, 'RD', '-1', 2, 3, 'Bereket Degefa | Test Med | Ran out.'),
	(107, 'RP', '1', 2, 3, 'GRANTED! '),
	(108, 'MP', '1', 2, 3, 'Requesting Access to medical Records! I need to review document.'),
	(109, 'AD', '1', 2, 3, 'Bereket Degefa | 1:00:00 PM | 2018-12-19 | Need to talk.'),
	(110, 'RD', '-1', 2, 3, 'Bereket Degefa | Med 1 | a'),
	(111, 'MP', '1', 2, 3, 'Requesting Access to medical Records! '),
	(112, 'PD', '-1', 1, 3, 'Bereket Degefa | 000000000 | 12'),
	(113, 'AP', '1', 15, 1, 'New Appointment! ergehherh | Date: 2019/2/22 At: 1:00:00 PM'),
	(114, 'MP', '0', 1, 4, 'Requesting Access to medical Records! '),
	(115, 'RP', '1', 1, 5, 'GRANTED! '),
	(116, 'RP', '0', 18, 1, 'REJECTED! '),
	(117, 'AD', '1', 3, 1, 'William Abernathy | 1:00:00 PM | 2019-03-15 | yoyoyo'),
	(118, 'RD', '-1', 1, 1, 'William Abernathy | fsfsdfsd | fgdsgsdg'),
	(119, 'PD', '-1', 1, 1, 'William Abernathy | dfgdgdg | dgdfg'),
	(120, 'AP', '1', 1, 1, 'New Appointment! Bad Cough | Date: 2019/5/30 At: 10:00:00 AM'),
	(121, 'MP', '-1', 1, 5, 'Requesting Access to medical Records! You\'ve had one too many.'),
	(122, 'RP', '1', 1, 3, 'GRANTED! Call me upon receiving this notice. '),
	(123, 'RP', '0', 3, 1, 'REJECTED! Call me upon receiving this notice.'),
	(124, 'AD', '1', 1, 22, 'William Abernathy | 3:00:00 PM | 2018-12-28 | Foot pain.'),
	(125, 'RD', '-1', 3, 22, 'William Abernathy | Adderal | Finals coming up.'),
	(126, 'PD', '-1', 4, 22, 'William Abernathy | 8592007708 | Can\'t get out of bed.'),
	(127, 'MP', '-1', 1, 1, 'Requesting Access to medical Records! '),
	(128, 'MP', '-1', 1, 2, 'Requesting Access to medical Records! '),
	(129, 'MP', '-1', 1, 3, 'Requesting Access to medical Records! '),
	(130, 'MP', '-1', 1, 5, 'Requesting Access to medical Records! '),
	(131, 'MP', '-1', 1, 1, 'Requesting Access to medical Records! '),
	(132, 'MP', '-1', 1, 2, 'Requesting Access to medical Records! '),
	(133, 'MP', '-1', 1, 3, 'Requesting Access to medical Records! '),
	(134, 'MP', '-1', 1, 4, 'Requesting Access to medical Records! '),
	(135, 'MP', '-1', 1, 5, 'Requesting Access to medical Records! '),
	(136, 'RP', '1', 1, 1, 'GRANTED! '),
	(137, 'RP', '0', 1, 1, 'REJECTED! '),
	(138, 'AP', '1', 1, 1, 'New Appointment!  | Date: 2019/5/8 At: 1:00:00 PM'),
	(139, 'MP', '0', 2, 1, 'Requesting Access to medical Records! '),
	(140, 'ER', NULL, 1, 4, 'Requesting New Refill for Tylenol!'),
	(141, 'ER', NULL, 1, 4, 'Requesting New Refill for Tylenol!'),
	(142, 'NR', NULL, 1, 1, 'New Adderall prescription!'),
	(143, 'DR', NULL, 1, 3, 'How are you today?'),
	(144, 'WP', '0', 1, 2, 'Prescription is Ready!'),
	(145, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(146, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(147, 'DD', '1', 1, 3, 'I\'m good, you?'),
	(148, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(149, 'DD', '1', 1, 3, 'Not so good today.'),
	(150, 'DD', '0', 1, 4, 'Need help.'),
	(151, 'DD', '1', 2, 3, 'Wanted to talk about patient name by ____'),
	(152, 'DD', '0', 3, 1, 'Need to talk asap.'),
	(153, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(154, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(155, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(156, 'DD', '1', 3, 3, 'asdad'),
	(157, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(158, 'WP', '0', 1, 1, 'Prescription is Ready!'),
	(159, 'WP', '0', 1, 1, 'Prescription is Ready!'),
	(160, 'WP', '0', 2, 1, 'Prescription is Ready!'),
	(161, 'DD', '1', 1, 3, 'hello'),
	(162, 'DD', '1', 1, 3, 'hi'),
	(163, 'DD', '1', 3, 3, 'I need to talk to you about expired refill of patient Zach.'),
	(164, 'DD', '0', 2, 1, 'A request to discuss a case has been made Call 800-846-1532'),
	(165, 'DD', '0', 2, 1, 'A request to discuss a case has been made Call 800-846-1532'),
	(166, 'DD', '0', 2, 1, 'A request to discuss a case has been made Call 800-846-1532'),
	(167, 'DD', '0', 2, 1, 'A request to discuss a case has been made Call 800-846-1532'),
	(168, 'DD', '0', 2, 1, 'A request to discuss a case has been made Call 800-846-1532'),
	(169, 'DD', '0', 3, 1, 'A request to discuss a case has been made Call 800-846-1532'),
	(170, 'AP', '1', 1, 4, 'New Appointment!  | Date: 2019/1/24 At: 10:00:00 AM'),
	(171, 'AP', '1', 1, 4, 'New Appointment! Flu | Date: 2019/1/25 At: 1:00:00 PM'),
	(172, 'MP', '-1', 4, 1, 'Requesting Access to medical Records! '),
	(173, 'AP', '1', 5, 4, 'New Appointment! Test | Date: 2019/1/29 At: 10:00:00 AM'),
	(174, 'AP', '1', 5, 4, 'New Appointment!  | Date: 2019/1/29 At: 3:00:00 PM'),
	(175, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 1:00:00 PM | 2019-01-29 | Test'),
	(176, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 8:00:00 AM | 2019-01-21 | Test'),
	(177, 'AP', '1', 1, 4, 'New Appointment! To discuss surgery  | Date: 2019/2/12 At: 1:00:00 PM'),
	(178, 'AP', '1', 12, 4, 'New Appointment! Just cause | Date: 2019/2/12 At: 3:00:00 PM'),
	(179, 'AP', '1', 1, 4, 'New Appointment! To discuss illness | Date: 2019/2/8 At: 1:00:00 PM'),
	(180, 'AD', '1', 4, 5, 'Kuang-Nan Chang | 1:00:00 PM | 2019-02-24 | asdfghj'),
	(181, 'AD', '1', 1, 5, 'Kuang-Nan Chang | 8:00:00 AM | 2019-02-26 | asdfghj'),
	(182, 'AD', '1', 4, 5, 'Kuang-Nan Chang | 10:00:00 AM | 2019-02-24 | asdfghj'),
	(183, 'AD', '1', 1, 5, 'Kuang-Nan Chang | 10:00:00 AM | 2019-02-25 | asdfghj'),
	(184, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 10:00:00 AM | 2019-01-31 | asdf'),
	(185, 'AD', '1', 3, 28, 'William Abernathy | 10:00:00 AM | 2019-03-14 | asdf'),
	(186, 'AD', '1', 1, 28, 'William Abernathy | 10:00:00 AM | 2019-03-15 | asdf'),
	(187, 'AD', '1', 3, 2, 'Zachary Bray | 8:00:00 AM | 2019-02-06 | Sick'),
	(188, 'PD', '-1', 3, 28, 'William Abernathy | 859-555-5782 | Cold'),
	(189, 'PD', '-1', 3, 28, 'William Abernathy | 22 | Cold'),
	(190, 'PD', '-1', 3, 28, 'William Abernathy | 01234567890123456789 | Cold'),
	(191, 'PD', '-1', 3, 28, 'William Abernathy | ???§ | Cold'),
	(192, 'AD', '1', NULL, NULL, ' | 8:00:00 AM | 2019-02-06 | Sick'),
	(193, 'RP', '1', 3, 5, 'GRANTED! '),
	(194, 'MP', '-1', 3, 15, 'Requesting Access to medical Records! '),
	(195, 'PD', '-1', 4, 28, 'William Abernathy | (_)_)::::::::::::::::::::D~~~~ | Rocketship!\n(_)_)::::::::::::::::::::D~~~~\n(_)_)::::::::::::::::::::D~~~~'),
	(196, 'AP', '1', 1, 4, 'New Appointment!  | Date: 2019/2/6 At: 10:00:00 AM'),
	(197, 'AP', '1', 1, 4, 'New Appointment!  | Date: 2019/1/31 At: 1:00:00 PM'),
	(198, 'RD', '-1', 3, 28, 'William Abernathy | Advil | Headache'),
	(199, 'RD', '-1', 1, 28, 'William Abernathy | Never | .'),
	(200, 'RD', '-1', 1, 28, 'William Abernathy | Gonna | .'),
	(201, 'RD', '-1', 1, 28, 'William Abernathy | Give | .'),
	(202, 'RD', '-1', 1, 28, 'William Abernathy | You | .'),
	(203, 'RD', '-1', 1, 28, 'William Abernathy | Up | .'),
	(204, 'AP', '1', 1, 4, 'New Appointment!  | Date: 2019/1/31 At: 3:00:00 PM'),
	(205, 'AP', '1', 28, 4, 'New Appointment!  | Date: 2019/2/9 At: 3:00:00 PM'),
	(206, 'AP', '1', 27, 4, 'New Appointment! njlkjkljlklkj;xkjlczjklxx | Date: 2019/2/5 At: 3:00:00 PM'),
	(207, 'PD', '-1', 4, 2, 'Zachary Bray | asdf | asdf'),
	(208, 'PD', '-1', 4, 2, 'Zachary Bray | asdf | asdf'),
	(209, 'PD', '-1', 4, 2, 'Zachary Bray | 502-555-5555 | Sidk'),
	(210, 'RD', '-1', 4, 5, 'Kuang-Nan Chang | Water | Dehydrated'),
	(211, 'RP', '1', 4, 5, 'GRANTED! '),
	(212, 'MP', '-1', 4, 5, 'Requesting Access to medical Records! '),
	(213, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 8:00:00 AM | 2019-03-02 | I need my flu shots'),
	(214, 'AP', '1', 6, 4, 'New Appointment! ddd | Date: 2019/2/1 At: 10:00:00 AM'),
	(215, 'MP', '-1', 4, 1, 'Requesting Access to medical Records! '),
	(216, 'RP', '1', 4, 1, 'GRANTED! '),
	(217, 'AP', '1', 5, 4, 'New Appointment! -=[[[[[[[[[[[[[[[[[[[[[[=- | Date: 2019/2/1 At: 1:00:00 PM'),
	(218, 'AP', '1', 4, 4, 'New Appointment!  | Date: 2019/2/1 At: 8:00:00 AM'),
	(219, 'AD', '1', 4, 5, 'Kuang-Nan Chang | 3:00:00 PM | 2019-02-01 | 1234'),
	(220, 'AP', '1', 5, 4, 'New Appointment!  | Date: 2019/2/2 At: 3:00:00 PM'),
	(221, 'PD', '-1', 4, 5, 'Kuang-Nan Chang | s2551 | sss'),
	(222, 'MP', '-1', 4, 5, 'Requesting Access to medical Records! '),
	(223, 'RD', '-1', 3, 5, 'Kuang-Nan Chang | ddd | dddd'),
	(224, 'RP', '1', 4, 5, 'GRANTED! '),
	(225, 'MP', '-1', 1, 27, 'Requesting Access to medical Records! '),
	(226, 'MP', '-1', 1, 1, 'Requesting Access to medical Records! Testing testing testing'),
	(227, 'RP', '0', 5, 4, 'REJECTED! '),
	(228, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 3:00:00 PM | 2019-02-06 | I\'m feeling sick'),
	(229, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 3:00:00 PM | 2019-02-04 | I\'m feeling sick'),
	(230, 'AD', '1', 3, 5, 'Kuang-Nan Chang | 8:00:00 AM | 2019-02-04 | I\'m feeling sick'),
	(231, 'AD', '1', 4, 5, 'Kuang-Nan Chang | 1:00:00 PM | 2019-02-06 | I\'m feeling sick'),
	(232, 'AD', '1', 4, 5, 'Kuang-Nan Chang | 1:00:00 PM | 2019-02-04 | I\'m feeling sick'),
	(233, 'AP', '1', 2, 4, 'New Appointment! Cough | Date: 2019/2/7 At: 8:00:00 AM'),
	(234, 'AP', '1', 2, 4, 'New Appointment! i don\'t know | Date: 2019/2/7 At: 10:00:00 AM'),
	(235, 'PD', '-1', 3, 5, 'Kuang-Nan Chang | 606 | I don\'t know'),
	(236, 'PD', '-1', 3, 5, 'Kuang-Nan Chang | 6068025028 | ...'),
	(237, 'AD', '1', 4, 38, 'William Abernathy | 3:00:00 PM | 2019-02-28 | Cold'),
	(238, 'AD', '1', 4, 38, 'William Abernathy | 8:00:00 AM | 2019-02-28 | ; LIKE %ag%'),
	(239, 'AD', '1', 3, 3, 'Bereket Degefa | 1:00:00 PM | 2019-02-28 | Help.'),
	(240, 'RD', '-1', 1, 3, 'Bereket Degefa | sad | asda'),
	(241, 'AP', '1', 3, 3, 'New Appointment! Need to  | Date: 2019/3/8 At: 3:00:00 PM'),
	(242, 'RD', '-1', 2, 3, 'Bereket Degefa | Unknow | 1234'),
	(243, 'RD', '-1', 4, 2, 'Zachary Bray | 1 | 2'),
	(244, 'RD', '-1', 3, 2, 'Zachary Bray | 1 | 2'),
	(245, 'RP', '1', 3, 2, 'GRANTED! '),
	(246, 'AD', '1', 3, 2, 'Zachary Bray | 10:00:00 AM | 2019-02-28 | 1');
/*!40000 ALTER TABLE `wzb_notice` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_patient
CREATE TABLE IF NOT EXISTS `wzb_patient` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(60) DEFAULT NULL,
  `Gender` char(1) DEFAULT NULL,
  `DOB` date DEFAULT NULL,
  `Age` tinyint(4) DEFAULT NULL,
  `Phone` varchar(18) DEFAULT NULL,
  `Street_1` varchar(30) DEFAULT NULL,
  `Street_2` varchar(30) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `State` varchar(20) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  `Accepted_Date` date DEFAULT NULL,
  `Sickness` varchar(1000) DEFAULT NULL,
  `Prescriptions` int(11) DEFAULT NULL,
  `Allergies` varchar(8000) DEFAULT NULL,
  `Special_or_Other` varchar(8000) DEFAULT NULL,
  `User_name` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_patient: ~29 rows (approximately)
/*!40000 ALTER TABLE `wzb_patient` DISABLE KEYS */;
INSERT INTO `wzb_patient` (`ID`, `Name`, `Gender`, `DOB`, `Age`, `Phone`, `Street_1`, `Street_2`, `City`, `State`, `Country`, `Accepted_Date`, `Sickness`, `Prescriptions`, `Allergies`, `Special_or_Other`, `User_name`) VALUES
	(1, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'United States', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(2, 'Zachary Bray', 'M', '1993-02-25', 76, '8591234567', '456 Drive From Lex', ' ', 'Lexington', 'KY', 'United States', '1986-02-02', 'Cramps', 42, 'Shellfish, Nuts', '', 'ZBray'),
	(3, 'Bereket Degefa', 'M', '2002-11-05', 16, '8599876543', '789 Across the Ocean', ' ', 'Nairobi', 'KE', 'Kenya', '2006-12-25', 'Chest Pains', 0, 'Wheat, Soy', '', 'BDegefa'),
	(4, 'Bob Saget', 'M', '1956-05-17', 62, '8592001234', '123 Hollywood', ' ', 'Hollywood', 'CA', 'United States', '1985-08-29', 'Comedy, Networks, Gout', 9, 'Toxins', 'Erratic', 'BSaget'),
	(5, 'Kuang-Nan Chang', 'M', '1988-07-26', 30, '8592001234', '409 Wallace Building', ' ', 'Richmond', 'KY', 'United States', '1999-08-04', 'Migraines', 4, 'League of Legends', 'Pyschological Instabilities', 'KChang'),
	(6, 'Bob Saget', 'M', '1956-05-17', 62, '8592001234', '123 Hollywood', ' ', 'Hollywood', 'CA', 'Afghanistan', '1985-08-29', 'Comedy, Networks, Gout, egegewg', 353, 'Toxins, ergegweegewgg', 'Erratic, egewgegerg', 'BSaget'),
	(12, 'JimJam', 'M', '1946-07-22', 72, '1234567890', '84297 UPUPUP', 'Apt Down', 'Yellow', 'Lint', 'Rover', '2001-02-21', 'His name', 8, 'Pollen', 'Name is WACK', 'JJam'),
	(13, 'patient6', 'M', '1942-07-14', 76, '8591234567', '456 Drive From Lex', ' ', 'Lexingto', 'KY', 'Afghanistan', '1986-02-02', 'Cramps, rehethh', 47, 'Shellfish, Nuts, rhrt', 'rehrh', '5'),
	(14, 'patient4', 'M', '2002-11-05', 16, '8599876543', 'rth', 'ehrethh', 'Nairobi', 'KE', 'Afghanistan', '2006-12-25', 'reher', 5, 'rthrh', 'rthrhrher', '4'),
	(15, 'patient5', 'M', '1942-07-14', 76, '34343', 'erge', ' ', 'Lexington', 'KY', 'Afghanistan', '1986-02-02', 'Cramps, eregrer', 34376, 'Shellfish, Nuts, gqerg', 'eqrgqegqeg', '3'),
	(16, 'patient2', 'M', '2002-11-05', 16, '8599876543', '789 Across the Ocean', ' ', 'Nairobi', 'KE', 'Afghanistan', '2006-12-25', 'Chest Pains', 0, 'Wheat, Soy', '', '1'),
	(17, 'patient3', 'M', '2002-11-05', 16, '8599876543', '789 Across the Ocean', ' ', 'Nairobi', 'KE', 'Afghanistan', '2006-12-25', 'Chest Pains', 0, 'Wheat, Soy', '', '2'),
	(18, 'TestPatient', 'F', '2018-12-03', 0, '1111111111', '...098', '.907', 'Richmond', 'KY', 'United Kingdom', '2018-12-07', 'None so far', 0, 'None', 'N/A', 'TestPatient'),
	(19, 'Test Patient', 'M', '2018-02-20', 0, '111111111', 'asdasd', 'sdada', 'asdas', 'KY', 'United States', '2018-12-07', 'None', 0, 'n/a', 'n/a', 'TPatient'),
	(20, 'Bobby Tarter', 'F', '1969-06-09', 49, '1234569876', '5643 Holler Road', '', 'Richmond', 'Kentucky', 'United States', '2018-11-26', 'Hair Loss', 9, 'Pollen', 'N/A', 'BTarter'),
	(21, 'Bob Saget', 'M', '1956-05-17', 62, '124567894', '123 Hollywood', ' ', 'Hollywood', 'CA', 'Afghanistan', '1985-08-29', 'Comedy, Networks, Gout, Death', 24, 'Toxins, Tylenol', 'Erratic, Psycho', 'BSaget'),
	(22, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'United States', '2001-06-12', 'Death', 6, 'Penicilin', '', 'WAbernathy'),
	(23, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', 'Fake Street', ' ', 'Richmond', 'KY', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(24, 'William Abernathy', 'M', '1993-02-25', 25, '555555555', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(25, 'William Abernathy', 'M', '1993-02-25', 25, '555555555', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(26, 'William Abernathy', 'M', '1993-02-25', 25, '1234567891', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(27, 'William Abernathy', 'M', '1993-02-25', 25, '1234567890', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(28, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', '123 Yellow Brick Rd', ' ', 'Kansas City', '987987', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(29, '45', 'F', '2019-01-31', 0, '564356', '546', '546', '546', 'ccccc', 'Afghanistan', '2019-01-31', '654', 563, '46', '6', '45'),
	(30, '456', 'F', '2019-01-31', 0, '5', '5', '5', '5', '56', 'Afghanistan', '2005-01-31', '5', 69, '5', '', '456'),
	(31, 'Ryan', 'M', '2005-01-31', 14, '5', '5', '5', '5', '5', 'Afghanistan', '2005-01-31', '4', 5, '56', '5', 'Ryan'),
	(32, 'James', 'M', '2005-01-31', 14, '502', '545', '', '5', 'cs', 'Afghanistan', '2005-01-31', 'Dead', 5, 'dog', '', 'James'),
	(33, 'Ryan Smith', 'M', '2005-01-31', 14, '502', '123 Street St.', '', 'Richmond', 'Ky', 'Bulgaria', '2005-01-31', 'Fever', 2, 'Dog', 'Asthmatic', 'RSmith'),
	(34, 'James', 'M', '2019-01-31', 0, '502', '1236', '', 'Richmoind', 'Ky', 'Afghanistan', '2019-01-31', '', 5, 'jo;jop;op', 'nljlijjlo', 'James'),
	(35, 'James', 'M', '2019-01-31', 0, '5025', '123', '', 'Lex', 'Ky', 'Afghanistan', '2019-01-31', 'Heart Attack', 0, 'none', '', 'James'),
	(36, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(37, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', 'Allergies, Asthma, Arthritis', 3, 'Penicilin', '', 'WAbernathy'),
	(38, 'William Abernathy', 'M', '1993-02-25', 25, '8592007708', '123 Yellow Brick Rd', ' ', 'Kansas City', 'KS', 'Afghanistan', '2001-06-12', '22222222222222222', 3, '33333333333333333', '', 'WAbernathy');
/*!40000 ALTER TABLE `wzb_patient` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_pharmacy
CREATE TABLE IF NOT EXISTS `wzb_pharmacy` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(60) DEFAULT NULL,
  `Phone` varchar(18) DEFAULT NULL,
  `Street_1` varchar(30) DEFAULT NULL,
  `Street_2` varchar(30) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `State` varchar(50) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_pharmacy: ~2 rows (approximately)
/*!40000 ALTER TABLE `wzb_pharmacy` DISABLE KEYS */;
INSERT INTO `wzb_pharmacy` (`ID`, `Name`, `Phone`, `Street_1`, `Street_2`, `City`, `State`, `Country`) VALUES
	(1, 'Get Some', '8002589631', '951 Off the Side', '', 'Richmond', 'KY', 'United States'),
	(2, 'Healing and Support Only', '8008461532', '9818 Corner Road', 'Building 7', 'Richmond', 'KY', 'United States');
/*!40000 ALTER TABLE `wzb_pharmacy` ENABLE KEYS */;

-- Dumping structure for table csc340_db.wzb_prescription
CREATE TABLE IF NOT EXISTS `wzb_prescription` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Medication` varchar(30) DEFAULT NULL,
  `Patient_ID` int(11) DEFAULT NULL,
  `Doctor_ID` int(11) DEFAULT NULL,
  `Pharmacy_ID` int(11) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  `Type` char(2) DEFAULT NULL,
  `Dosage` char(6) DEFAULT NULL,
  `Refill_total` int(11) DEFAULT NULL,
  `Start_date` date DEFAULT NULL,
  `End_date` date DEFAULT NULL,
  `Last_refill_date` date DEFAULT NULL,
  `Refill_Count` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Patient_ID` (`Patient_ID`),
  KEY `Doctor_ID` (`Doctor_ID`),
  KEY `Pharmacy_ID` (`Pharmacy_ID`),
  CONSTRAINT `prescription_ibfk_1` FOREIGN KEY (`Patient_ID`) REFERENCES `patient` (`ID`),
  CONSTRAINT `prescription_ibfk_2` FOREIGN KEY (`Doctor_ID`) REFERENCES `doctor` (`ID`),
  CONSTRAINT `prescription_ibfk_3` FOREIGN KEY (`Pharmacy_ID`) REFERENCES `pharmacy` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

-- Dumping data for table csc340_db.wzb_prescription: ~12 rows (approximately)
/*!40000 ALTER TABLE `wzb_prescription` DISABLE KEYS */;
INSERT INTO `wzb_prescription` (`ID`, `Medication`, `Patient_ID`, `Doctor_ID`, `Pharmacy_ID`, `Status`, `Type`, `Dosage`, `Refill_total`, `Start_date`, `End_date`, `Last_refill_date`, `Refill_Count`) VALUES
	(1, 'Tylenol', 1, 4, 1, 'Ready', 'NP', '100mg', 2, '2018-12-01', '2018-12-15', '2018-06-04', 1),
	(2, 'Nexium', 2, 3, 1, 'Ready', 'RE', '100ml', 1, '2018-12-01', '2018-12-15', '2016-01-14', NULL),
	(3, 'Tylenol', 1, 4, 2, 'Ready', 'RE', '50mg', 4, '2018-12-14', '2018-12-29', '2012-11-27', NULL),
	(5, 'Med1', 2, 3, 1, 'Received', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL),
	(6, 'Med2', 2, 3, 1, 'Ready', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL),
	(7, 'Med3', 2, 2, 1, 'Ready', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL),
	(8, 'Med3', 2, 2, 1, 'New', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL),
	(9, 'Med5', 2, 2, 1, 'Ready', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL),
	(10, 'Med6', 2, 2, 1, 'Ready', 'RE', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', 0),
	(11, 'Med56', 2, 2, 1, 'Ready', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL),
	(12, 'Med51', 2, 2, 1, 'Ready', 'RE', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', 2),
	(13, 'Med52', 2, 2, 1, 'Received', 'NP', '100mg', 3, '2018-12-12', '2018-06-04', '2018-04-05', NULL);
/*!40000 ALTER TABLE `wzb_prescription` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
