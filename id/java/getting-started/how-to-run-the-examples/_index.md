---
title: Cara Menjalankan Contoh
type: docs
weight: 140
url: /id/java/how-to-run-the-examples/
keywords:
- contoh
- persyaratan perangkat lunak
- GitHub
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Jalankan contoh Aspose.Slides untuk Java dengan cepat: kloning repo, memulihkan paket, lalu membangun dan menguji fitur untuk PPT, PPTX, dan ODP."
---
## **Unduh Aspose.Slides dari GitHub**
Semua contoh Aspose.Slides untuk Java dihosting di [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Anda dapat mengkloning repositori menggunakan klien Github favorit Anda atau mengunduh file ZIP dari [sini](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Ekstrak isi file ZIP ke folder mana saja di komputer Anda. Semua contoh berada di folder **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Impor Contoh ke IDE**
Proyek ini menggunakan sistem build Maven. Setiap IDE modern dapat dengan mudah membuka atau mengimpor proyek beserta dependensinya. Di bawah ini kami menunjukkan cara menggunakan IDE populer untuk membangun dan menjalankan contoh.

### **IntelliJ IDEA**
Klik menu **File** dan pilih **Open**. Telusuri ke folder proyek dan pilih file **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Proyek akan dibuka dan dependensi akan diunduh secara otomatis. Dari tab Project, telusuri contoh di folder **src/main/java**. Untuk menjalankan contoh, cukup klik kanan pada file dan pilih "Run ..", contoh akan dieksekusi dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klik menu **File** dan pilih **Import**. Pilih **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Telusuri ke folder yang Anda kloning atau unduh dari GitHub dan pilih file **pom.xml**. Proyek akan dibuka dan dependensi akan diunduh secara otomatis. Dari tab Package Explorer, telusuri contoh di folder **src/main/java**. Untuk menjalankan contoh, cukup klik kanan pada file dan pilih **Run As** - **Java Application**, contoh akan dieksekusi dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klik menu **File** dan pilih **Open Project**. Telusuri ke folder yang Anda kloning atau unduh dari GitHub. Ikon folder **Examples** akan menunjukkan bahwa itu adalah proyek Maven. Pilih **Examples** dan buka.

![todo:image_alt_text](netbeans_openproject.png)

Proyek akan dibuka dan dependensi akan diunduh secara otomatis. Dari tab Projects, telusuri contoh di **source packages**. Untuk menjalankan contoh, cukup klik kanan pada file dan pilih **Run File**, contoh akan dieksekusi dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](netbeans_run_example.png)

## **Tambahkan Pustaka Aspose.Slides ke Repository Lokal Maven**
Saat Anda mengimpor proyek **Aspose.Slides Examples** ke IDE, Maven secara otomatis mengunduh file JAR aspose.slides dari [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Jika Anda tidak memiliki akses internet, Anda dapat menambahkan JAR secara manual ke repository lokal Anda.

### **mvn install**
Unduh [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), ekstrak, dan salin file aspose.slides-version.jar ke lokasi lain, misalnya drive C. Jalankan perintah berikut:

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```

Sekarang, jar **aspose.slides** telah disalin ke repository lokal Maven Anda.

### **pom.xml**
Setelah dipasang, cukup deklarasikan koordinat **aspose.slides** di pom.xml. Tambahkan repository berikut di tab repositories dan dependency di tab dependencies.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>25.12</version>
    <classifier>jdk16</classifier>
</dependency>
```

### **Selesai**
Bangun proyek, kini jar **aspose.slides** dapat diambil dari repository lokal Maven Anda.

## **Berkontribusi**
Jika Anda ingin menambah atau memperbaiki contoh, kami mendorong Anda untuk berkontribusi pada proyek. Semua contoh dan proyek showcase di repository ini bersifat open source dan dapat digunakan secara bebas dalam aplikasi Anda.

Untuk berkontribusi, Anda dapat fork repository, mengedit kode sumber, dan mengirim Pull Request. Kami akan meninjau perubahan dan memasukkannya ke repository jika dianggap membantu.