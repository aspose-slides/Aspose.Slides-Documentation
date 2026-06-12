---
title: Instalasi
type: docs
weight: 70
url: /id/php-java/installation/
keywords:
- instal Aspose.Slides
- unduh Aspose.Slides
- gunakan Aspose.Slides
- Instalasi Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Instal Aspose.Slides untuk PHP via Java dengan cepat. Panduan langkah demi langkah, persyaratan sistem, dan contoh kode — mulailah bekerja dengan presentasi PowerPoint hari ini!"
---
## **Ringkasan**

Artikel ini menjelaskan cara menginstal dan mengonfigurasi Aspose.Slides untuk PHP via Java. Ini mencakup penyiapan lingkungan yang diperlukan, mengunduh pustaka melalui Packagist, mengonfigurasi Apache Tomcat dengan PHP/Java Bridge, dan menjalankan contoh untuk memverifikasi instalasi.

## **Konfigurasi Lingkungan**

1. Instal PHP 7, tambahkan jalur PHP ke variabel sistem `PATH` dan atur `allow_url_include` ke `On` di file `php.ini`.
1. Instal JRE 8. Atur variabel lingkungan `JAVA_HOME` ke jalur JRE yang telah diinstal.
1. Instal Apache Tomcat 8.0.

## **Unduh Aspose.Slides untuk PHP via Java** 

`packagist` adalah cara termudah untuk mengunduh [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

Untuk menginstal Aspose.Slides menggunakan Packagist, jalankan perintah ini: 
   ```bash
   composer require aspose/slides
   ```

## **Konfigurasi Apache Tomcat**

1. Unduh PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) dari http://php-java-bridge.sourceforge.net/pjb/download.php dan ekstrak file `JavaBridge.war` ke folder `webapps` tomcat.
1. Mulai layanan Apache Tomcat.
1. Unduh “Aspose.Slides for PHP via Java” dari https://downloads.aspose.com/slides/id/php-java dan ekstrak ke folder `aspose.slides`. Salin file `jar/aspose-slides-x.x-php.jar` ke folder `webapps\JavaBridge\WEB-INF\lib`. Jika Anda menggunakan **PHP 8**, gantikan `Java.inc` asli dari PHP-Java Bridge dengan `Java.inc` dari `Java.inc.php8.zip`.
1. Mulai ulang layanan Apache Tomcat.
1. Jalankan `example.php` di folder `aspose.slides` untuk menjalankan contoh dengan perintah ini:
   ```bash
   php example.php
   ```

## **FAQ**

**Bagaimana saya dapat memverifikasi bahwa Aspose.Slides terintegrasi dengan benar?**

Bangun proyek Anda, buat instance dari [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) kosong dan simpan dengan nama baru. Jika file berhasil dibuat tanpa melemparkan pengecualian, maka pustaka telah terintegrasi dengan sukses.

**Bagaimana saya dapat membatasi konsumsi memori saat memproses presentasi besar?**

Tingkatkan batas memori JVM hanya sebesar yang diperlukan, dan tutup setiap instance [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) dalam blok `finally` untuk segera melepaskan cache. Hal ini mencegah kesalahan kehabisan memori dan menjaga penggunaan memori secara keseluruhan tetap dapat diprediksi selama operasi batch.

**Apakah saya dapat mengecualikan format ekspor yang tidak diinginkan untuk memperkecil ukuran JAR akhir?**

Rilis Aspose.Slides saat ini didistribusikan sebagai satu pustaka monolitik, sehingga Anda tidak dapat menonaktifkan pengekspor tertentu seperti PDF atau SVG pada saat build.