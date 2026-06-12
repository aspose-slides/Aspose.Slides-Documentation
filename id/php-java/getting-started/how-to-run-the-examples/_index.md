---
title: Cara Menjalankan Contoh
type: docs
weight: 140
url: /id/php-java/how-to-run-the-examples/
keywords:
- contoh
- persyaratan perangkat lunak
- GitHub
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Jalankan contoh Aspose.Slides untuk PHP via Java dengan cepat: klon repositori, pulihkan paket, kemudian bangun dan uji fitur untuk PPT, PPTX, dan ODP."
---
## **Unduh dari GitHub**
Semua contoh Aspose.Slides untuk PHP via Java dihosting di [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Anda dapat mengkloning repositori menggunakan klien Github pilihan Anda atau mengunduh file ZIP dari [sini](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Ekstrak isi file ZIP ke folder mana saja di komputer Anda. Semua contoh berada di folder **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Impor Contoh ke IDE**
Proyek ini menggunakan sistem build Maven. IDE modern mana pun dapat dengan mudah membuka atau mengimpor proyek serta dependensinya. Berikut kami tunjukkan cara menggunakan IDE populer untuk membangun dan menjalankan contoh.

### **IntelliJ IDEA**
Klik menu **File** dan pilih **Open**. Telusuri ke folder proyek dan pilih file **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Proyek akan terbuka dan mengunduh dependensi secara otomatis. Dari tab Project, telusuri contoh di folder **src/main/java**. Untuk menjalankan contoh, cukup klik kanan pada file dan pilih “Run ..”, contoh akan dijalankan dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klik menu **File** dan pilih **Import**. Pilih **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Telusuri ke folder yang Anda klon atau unduh dari GitHub dan pilih file **pom.xml**. Proyek akan terbuka dan mengunduh dependensi secara otomatis. Dari tab Package Explorer, telusuri contoh di folder **src/main/java**. Untuk menjalankan contoh, cukup klik kanan pada file dan pilih **Run As** - **Java Application**, contoh akan dijalankan dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klik menu **File** dan pilih **Open Project**. Telusuri ke folder yang Anda klon atau unduh dari GitHub. Ikon folder **Examples** akan menunjukkan bahwa itu adalah proyek Maven. Pilih Examples dan buka.

![todo:image_alt_text](netbeans_openproject.png)

Proyek akan terbuka dan mengunduh dependensi secara otomatis. Dari tab Projects, telusuri contoh di **source packages**. Untuk menjalankan contoh, cukup klik kanan pada file dan pilih **Run File**, contoh akan dijalankan dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](netbeans_run_example.png)

## **Tambahkan Pustaka Aspose.Slides ke Repository Lokal Maven**
Ketika Anda mengimpor proyek **Aspose.Slides Examples** ke IDE, Maven secara otomatis mengunduh file JAR aspose.slides dari [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Jika Anda tidak memiliki akses internet, Anda dapat menambahkan JAR secara manual ke repository lokal Anda.

### **mvn install**
Unduh [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), ekstrak, dan salin aspose.slides-version.jar ke tempat lain, misalnya ke drive C. Jalankan perintah berikut:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Sekarang, jar **aspose.slides** telah disalin ke repository lokal Maven Anda.

### **pom.xml**
Setelah diinstal, cukup deklarasikan koordinat **aspose.slides** di pom.xml. Tambahkan repository berikut pada tab repositories dan dependensi pada tab dependencies.

``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php


### **Selesai**
Bangun proyek, sekarang jar **aspose.slides** dapat diambil dari repository lokal Maven Anda.

## **Berkontribusi**
Jika Anda ingin menambahkan atau meningkatkan sebuah contoh, kami mendorong Anda untuk berkontribusi pada proyek. Semua contoh dan proyek showcase di repositori ini bersifat open source dan dapat digunakan secara bebas dalam aplikasi Anda.

Untuk berkontribusi, Anda dapat fork repositori, mengedit kode sumber, dan mengirimkan Pull Request. Kami akan meninjau perubahan tersebut dan memasukkannya ke repositori jika dianggap bermanfaat.