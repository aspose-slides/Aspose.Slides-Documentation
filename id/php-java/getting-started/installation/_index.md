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
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Instal Aspose.Slides untuk PHP via Java di Linux dan Windows: siapkan PHP, Java, Apache Tomcat, dan PHP/Java Bridge, tambahkan paket dengan Composer, dan verifikasi konfigurasi dengan skrip singkat."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java dijalankan dalam dua proses. Skrip PHP Anda menggunakan kelas PHP yang meneruskan setiap panggilan melalui PHP/Java Bridge ke Aspose.Slides, yang berjalan di Java dalam Apache Tomcat. Artikel ini menjelaskan cara menyiapkan kedua sisi, menginstal paket dengan Composer, dan menjalankan skrip singkat untuk memverifikasi instalasi.

## **Prasyarat**

- **PHP 7.0 hingga 8.3**, dengan `allow_url_include = On` di `php.ini`. Skrip Anda memuat pustaka klien bridge, `Java.inc`, dari Tomcat melalui HTTP. Pada PHP 8.4 dan yang lebih baru, `Java.inc` berhenti dengan error "end() expects exactly 1 argument" setiap kali ekstensi `xml` PHP dimuat, dan build Windows PHP selalu memuatnya.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 atau lebih baru.** JRE sudah cukup.
- **Apache Tomcat 9.** PHP/Java Bridge dibangun di atas API `javax.servlet`, yang tidak lagi disediakan oleh Tomcat 10 dan yang lebih baru, sehingga bridge tidak dapat dijalankan di sana.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, rilis terbarunya. Aplikasi webnya, `JavaBridge.war`, dijalankan di Tomcat.

Artikel ini menjalankan Tomcat dan skrip PHP Anda di komputer yang sama. Aspose.Slides membuka dan menyimpan file di dalam Tomcat, sehingga setiap path yang Anda berikan ke dalamnya harus valid di sana.

## **Instalasi di Linux**

Perintah berikut menginstal semua hal di folder home Anda pada Ubuntu 24.04. Pada distribusi lain, instal paket yang sama dengan manajer paket distribusi.

1. Instal PHP, Composer, Java, dan alat pengunduh, lalu aktifkan `allow_url_include` untuk baris perintah PHP:
   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Unduh Apache Tomcat 9 dan PHP/Java Bridge, letakkan `JavaBridge.war` bridge ke dalam folder `webapps` Tomcat, dan mulai Tomcat. Tomcat mengekstrak file WAR ke `webapps/JavaBridge` saat memulai:
   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Buat folder proyek dan instal Aspose.Slides for PHP via Java dari [Packagist](https://packagist.org/packages/aspose/slides):
   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Hentikan Tomcat, salin file JAR Aspose.Slides dari paket ke folder `WEB-INF/lib` bridge, gantikan `Java.inc` bridge dengan versi PHP 8 dari paket, dan mulai kembali Tomcat:
   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/id/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/id/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Pada PHP 7, lewati penggantian `Java.inc`. Tomcat membutuhkan beberapa detik untuk memulai, dan harus berjalan setiap kali skrip Anda menggunakan Aspose.Slides.

## **Instalasi di Windows**

1. Instal [PHP 8.3 untuk Windows](https://www.php.net/downloads.php?os=windows) dan tambahkan foldernya ke variabel lingkungan `PATH`. Salin `php.ini-production` menjadi `php.ini` di folder yang sama. Di `php.ini`, atur `allow_url_include = On` dan hapus komentar pada baris `extension_dir = "ext"`, `extension=openssl`, dan `extension=zip`. Composer membutuhkan `openssl` untuk mengunduh paket, dan `zip` untuk mengekstraknya kecuali 7‑Zip sudah terpasang atau perintah `unzip` ada di `PATH`.
2. Instal [Composer](https://getcomposer.org/download/).
3. Instal Java dan setel variabel lingkungan `JAVA_HOME` ke foldernya. Tomcat tidak dapat dimulai tanpa variabel ini.
4. Di Command Prompt, unduh Apache Tomcat 9 dan PHP/Java Bridge, letakkan `JavaBridge.war` bridge ke dalam folder `webapps` Tomcat, dan mulai Tomcat. Skrip Tomcat menemukan Tomcat melalui variabel `CATALINA_HOME`, jadi tetap gunakan jendela Command Prompt yang sama untuk langkah selanjutnya. Tomcat mengekstrak file WAR ke `webapps\JavaBridge` saat memulai:
   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Buat folder proyek dan instal Aspose.Slides for PHP via Java dari [Packagist](https://packagist.org/packages/aspose/slides):
   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Hentikan Tomcat, salin file JAR Aspose.Slides dari paket ke folder `WEB-INF\lib` bridge, gantikan `Java.inc` bridge dengan versi PHP 8 dari paket, dan mulai kembali Tomcat:
   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Pada PHP 7, lewati penggantian `Java.inc`. Tomcat membutuhkan beberapa detik untuk memulai, dan harus berjalan setiap kali skrip Anda menggunakan Aspose.Slides.

## **Verifikasi Instalasi**

Simpan skrip ini sebagai *hello.php* di folder proyek. Skrip ini membuat presentasi dengan satu kotak teks dan menyimpannya di samping skrip:
```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/id/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jalankan dari folder proyek:
```bash
php hello.php
```

Skrip menulis *hello.pptx*, dengan satu slide yang berisi kotak teks. Tanpa lisensi, slide juga menampilkan watermark evaluasi; lihat [Licensing](/slides/id/php-java/licensing/).

Skrip menyertakan `aspose.slides.php` secara langsung: autoloader Composer tidak dapat memuat kelas‑kelas ini, karena semuanya didefinisikan dalam satu file tersebut. Skrip juga memberikan path absolut ke `save`, karena Aspose.Slides berjalan di dalam Tomcat dan menyelesaikan path relatif terhadap folder kerja Tomcat, bukan folder skrip Anda.

## **FAQ**

**Bagaimana saya dapat memverifikasi bahwa Aspose.Slides terintegrasi dengan benar?**

Jalankan skrip di [Verifikasi Instalasi](#verify-the-installation). Jika skrip menulis *hello.pptx* tanpa error, PHP, PHP/Java Bridge, dan Aspose.Slides berfungsi bersama.

**Mengapa skrip saya berhenti dengan "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP tidak dapat memuat `Java.inc` dari Tomcat. Jika pesan sebelumnya menyatakan bahwa pembungkus `http://` dinonaktifkan, atur `allow_url_include = On` di file `php.ini` yang dimuat oleh baris perintah PHP Anda; `php --ini` akan menampilkan file tersebut. Jika pesan menunjukkan "Connection refused", Tomcat belum berjalan: mulai Tomcat, atau tunggu beberapa detik hingga selesai memulai.

**Bagaimana saya dapat membatasi konsumsi memori saat memproses presentasi besar?**

Tingkatkan batas memori JVM hanya sebesar yang diperlukan, dan tutup setiap instance [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dalam blok `finally` untuk segera melepaskan cache. Hal ini mencegah error out‑of‑memory dan menjaga penggunaan memori secara keseluruhan tetap dapat diprediksi selama operasi batch.

**Apakah saya dapat mengecualikan format ekspor yang tidak diinginkan untuk memperkecil ukuran JAR akhir?**

Rilis Aspose.Slides saat ini didistribusikan sebagai satu library monolitik, sehingga Anda tidak dapat menonaktifkan exporter tertentu seperti PDF atau SVG pada waktu build.