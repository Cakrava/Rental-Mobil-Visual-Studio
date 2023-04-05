/*
SQLyog Ultimate v12.5.1 (32 bit)
MySQL - 5.7.24 : Database - ta2020022cs
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`ta2020022cs` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `ta2020022cs`;

/*Table structure for table `detail_kembali` */

DROP TABLE IF EXISTS `detail_kembali`;

CREATE TABLE `detail_kembali` (
  `id_detail` int(12) NOT NULL,
  `id_pinjam` char(16) DEFAULT NULL,
  `id_mobil` char(20) DEFAULT NULL,
  `lama` int(12) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  PRIMARY KEY (`id_detail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `detail_kembali` */

insert  into `detail_kembali`(`id_detail`,`id_pinjam`,`id_mobil`,`lama`,`harga`) values 
(5,'MHV0001','KND0013',5,130000),
(8,'MHV0583','KND0016',5,180000),
(9,'MHV0062','KND0016',4,180000),
(10,'MHV0062','KND0015',3,140000),
(11,'MHV0062','KND0012',3,120000),
(12,'MHV0062','KND0023',3,105000),
(78,'MHV0001','KND002',2,80000);

/*Table structure for table `detail_pinjam` */

DROP TABLE IF EXISTS `detail_pinjam`;

CREATE TABLE `detail_pinjam` (
  `id_detail` int(12) NOT NULL AUTO_INCREMENT,
  `id_pinjam` char(16) DEFAULT NULL,
  `id_mobil` char(20) DEFAULT NULL,
  `lama` int(12) DEFAULT NULL,
  `harga` double DEFAULT NULL,
  PRIMARY KEY (`id_detail`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

/*Data for the table `detail_pinjam` */

insert  into `detail_pinjam`(`id_detail`,`id_pinjam`,`id_mobil`,`lama`,`harga`) values 
(6,'MHV0635','KND0014',4,150000),
(7,'MHV0635','KND0016',2,180000);

/*Table structure for table `dikembalikan` */

DROP TABLE IF EXISTS `dikembalikan`;

CREATE TABLE `dikembalikan` (
  `id` int(23) NOT NULL AUTO_INCREMENT,
  `id_pinjam` char(23) NOT NULL,
  `tgl` date DEFAULT NULL,
  `username` varchar(50) NOT NULL,
  `total` int(11) NOT NULL,
  `id_penyewa` char(20) NOT NULL,
  `id_acak` int(12) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_penyewa` (`username`),
  KEY `id_mobil` (`id_penyewa`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

/*Data for the table `dikembalikan` */

insert  into `dikembalikan`(`id`,`id_pinjam`,`tgl`,`username`,`total`,`id_penyewa`,`id_acak`) values 
(11,'MHV0001','2023-02-16','',160000,'17030100240003',NULL),
(12,'MHV0001','2023-02-17','user2',650000,'172831',14),
(13,'MHV0062','2023-02-17','moko',1815000,'172831',215),
(14,'MHV0583','2023-02-18','moko',900000,'002',647);

/*Table structure for table `kembali` */

DROP TABLE IF EXISTS `kembali`;

CREATE TABLE `kembali` (
  `id_kembali` int(11) NOT NULL AUTO_INCREMENT,
  `id_pinjam` varchar(20) DEFAULT NULL,
  `tgl_dikembalikan` date DEFAULT NULL,
  `id_acak` int(12) DEFAULT NULL,
  PRIMARY KEY (`id_kembali`)
) ENGINE=MyISAM AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

/*Data for the table `kembali` */

insert  into `kembali`(`id_kembali`,`id_pinjam`,`tgl_dikembalikan`,`id_acak`) values 
(18,'MHV0001','2023-02-16',981),
(20,'MHV0062','2023-02-17',215),
(19,'MHV0001','2023-02-17',14),
(21,'MHV0583','2023-02-18',647);

/*Table structure for table `mobil` */

DROP TABLE IF EXISTS `mobil`;

CREATE TABLE `mobil` (
  `id_mobil` varchar(10) NOT NULL,
  `merk` varchar(50) NOT NULL,
  `no_plat` varchar(20) NOT NULL,
  `harga_perhari` int(11) NOT NULL,
  `mesin` varchar(20) NOT NULL,
  `jumlah` int(11) NOT NULL,
  PRIMARY KEY (`id_mobil`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `mobil` */

insert  into `mobil`(`id_mobil`,`merk`,`no_plat`,`harga_perhari`,`mesin`,`jumlah`) values 
('KND0016','Innova','B 7890 XXX',180000,'Toyota',1),
('KND0015','Livina','B 6789 XXX',140000,'Nissan',3),
('KND0014','Ertiga','B 5678 XXX',150000,'Suzuki',1),
('KND0013','Avanza','B 4567 XXX',130000,'Daihatsu',1),
('KND0012','Xenia','B 3456 XXX',120000,'Toyota',2),
('KND0011','Terios','B 2345 XXX',125000,'Toyota',3),
('KND0017','Expander','B 8901 XXX',135000,'Mitsubishi',1),
('KND0018','Alphard','B 9012 XXX',300000,'Toyota',1),
('KND0019','Fortuner','B 0123 XXX',250000,'Toyota',1),
('KND0020','Pajero','B 1234 XXX',200000,'Mitsubishi',3),
('KND0021','Xpander','B 2345 YYY',125000,'Mitsubishi',3),
('KND0022','Jazz','B 3456 YYY',110000,'Honda',2),
('KND0023','Brio','B 4567 YYY',105000,'Honda',1),
('KND0024','Yaris','B 5678 YYY',140000,'Toyota',2),
('KND0025','Grand Livina','B 6789 YYY',150000,'Nissan',1),
('KND0026','BR-V','B 7890 YYY',160000,'Honda',2),
('KND0027','Rush','B 8901 YYY',135000,'Toyota',3),
('KND0028','CR-V','B 9012 YYY',220000,'Honda',1),
('KND0029','Kijang','B 0123 YYY',180000,'Toyota',1),
('KND0030','Camry','B 1234 YYY',280000,'Toyota',2),
('989','53','4',4000,'554',4),
('002','bagus','0232',50000,'Honda',4);

/*Table structure for table `penyewa` */

DROP TABLE IF EXISTS `penyewa`;

CREATE TABLE `penyewa` (
  `id_penyewa` varchar(20) NOT NULL,
  `nama_penyewa` varchar(50) NOT NULL,
  `nohp` varchar(20) NOT NULL,
  PRIMARY KEY (`id_penyewa`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `penyewa` */

insert  into `penyewa`(`id_penyewa`,`nama_penyewa`,`nohp`) values 
('002','Bagus Maulana','032093'),
('172830','Irsyad Farid','081234567890'),
('172831','Dewi Setiawati','082345678901'),
('172832','Hendra Gunawan','083456789012'),
('172833','Aisyah Azzahra','084567890123'),
('172834','Bambang Wibowo','085678901234'),
('172835','Reni Ayu Lestari','086789012345'),
('172836','Ahmad Rizal','087890123456'),
('172837','Desi Susanti','088901234567'),
('172838','Budi Hartanto','089012345678'),
('172839','Indah Permata Sari','090123456789'),
('172840','Fajar Rizky Pratama','091234567890'),
('172841','Ratih Ayu Safitri','092345678901'),
('172842','Irfan Ahmad','093456789012'),
('172843','Sri Widayanti','094567890123'),
('172844','Taufiq Hidayat','095678901234'),
('172845','Nina Kurnia Sari','096789012345'),
('172846','Ali Akbar','097890123456'),
('172847','Sinta Nurul Fitri','098901234567'),
('172848','Adi Kurniawan','099012345678'),
('172849','Lina Novitasari','100123456789');

/*Table structure for table `pinjam` */

DROP TABLE IF EXISTS `pinjam`;

CREATE TABLE `pinjam` (
  `id_pinjam` char(23) NOT NULL,
  `tgl` date DEFAULT NULL,
  `username` varchar(50) NOT NULL,
  `total` int(11) NOT NULL,
  `id_penyewa` char(20) NOT NULL,
  `id_acak` int(12) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`id_pinjam`,`id_acak`),
  KEY `id_penyewa` (`username`),
  KEY `id_mobil` (`id_penyewa`),
  KEY `id` (`id_acak`)
) ENGINE=InnoDB AUTO_INCREMENT=681 DEFAULT CHARSET=latin1;

/*Data for the table `pinjam` */

insert  into `pinjam`(`id_pinjam`,`tgl`,`username`,`total`,`id_penyewa`,`id_acak`) values 
('MHV0635','2023-02-17','moko',960000,'172846',680);

/*Table structure for table `temp` */

DROP TABLE IF EXISTS `temp`;

CREATE TABLE `temp` (
  `id_mobil` char(30) DEFAULT NULL,
  `lama` int(20) DEFAULT NULL,
  `harga` char(40) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `temp` */

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `username` varchar(50) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `lastLogin` time DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Data for the table `user` */

insert  into `user`(`username`,`nama`,`password`,`email`,`lastLogin`) values 
('moko','Joyo Kilat Moko','moko','user1@example.com','21:48:57'),
('vra','Vra Widia Putri','vra','vrawidiaputri@gmail.com',NULL);

/* Trigger structure for table `detail_kembali` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `tambah` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `tambah` AFTER INSERT ON `detail_kembali` FOR EACH ROW 
BEGIN
    UPDATE mobil SET jumlah = jumlah + 1 WHERE id_mobil = NEW.id_mobil;
END */$$


DELIMITER ;

/* Trigger structure for table `detail_pinjam` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `kurang` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `kurang` AFTER INSERT ON `detail_pinjam` FOR EACH ROW 
BEGIN
    UPDATE mobil SET jumlah = jumlah - 1 WHERE id_mobil = NEW.id_mobil;
END */$$


DELIMITER ;

/* Trigger structure for table `kembali` */

DELIMITER $$

/*!50003 DROP TRIGGER*//*!50032 IF EXISTS */ /*!50003 `tr_insert_kembali` */$$

/*!50003 CREATE */ /*!50017 DEFINER = 'root'@'localhost' */ /*!50003 TRIGGER `tr_insert_kembali` AFTER INSERT ON `kembali` FOR EACH ROW 
BEGIN
    -- pindahkan data dari tabel Pinjam ke tabel Dikembalikan
    INSERT INTO dikembalikan (id_pinjam,tgl,username,total,id_penyewa,id_acak)
    SELECT id_pinjam,tgl,username,total,id_penyewa,id_acak FROM pinjam WHERE id_pinjam = NEW.id_pinjam;
    
    -- pindahkan data dari tabel Detail_pinjam ke tabel Detail_kembali
    INSERT INTO detail_kembali (id_detail, id_pinjam,id_mobil,lama,harga)
    SELECT id_detail, id_pinjam,id_mobil,lama,harga FROM detail_pinjam WHERE id_pinjam = NEW.id_pinjam;
    
    -- hapus data dari tabel Detail_pinjam
    DELETE FROM detail_pinjam WHERE id_pinjam = NEW.id_pinjam;
    
    -- hapus data dari tabel Pinjam
    DELETE FROM pinjam WHERE id_pinjam = NEW.id_pinjam;
END */$$


DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
