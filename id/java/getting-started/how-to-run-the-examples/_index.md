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
description: "Jalankan contoh Aspose.Slides untuk Java dengan cepat: klon repositori, pulihkan paket, lalu bangun dan uji fitur untuk PPT, PPTX, dan ODP."
---
## **Unduh Aspose.Slides dari GitHub**
Semua contoh Aspose.Slides untuk Java dihosting di [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Anda dapat mengkloning repositori menggunakan klien Github favorit Anda atau mengunduh berkas ZIP dari [di sini](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Ekstrak isi berkas ZIP ke folder mana saja di komputer Anda. Semua contoh berada di folder **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Impor Contoh ke IDE**
Proyek ini menggunakan sistem build Maven. IDE modern apa pun dapat dengan mudah membuka atau mengimpor proyek dan dependensinya. Di bawah ini kami menunjukkan cara menggunakan IDE populer untuk membangun dan menjalankan contoh.

### **IntelliJ IDEA**
Klik menu **File** dan pilih **Open**. Telusuri ke folder proyek dan pilih berkas **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

Proyek akan terbuka dan mengunduh dependensi secara otomatis. Dari tab Project, telusuri contoh di folder **src/main/java**. Untuk menjalankan contoh, cukup klik kanan pada berkas dan pilih "Run ..", contoh akan dieksekusi dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Klik menu **File** dan pilih **Import**. Pilih **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Telusuri ke folder yang Anda klon atau unduh dari GitHub dan pilih berkas **pom.xml**. Proyek akan terbuka dan mengunduh dependensi secara otomatis. Dari tab Package Explorer, telusuri contoh di folder **src/main/java**. Untuk menjalankan contoh, cukup klik kanan pada berkas dan pilih **Run As** - **Java Application**, contoh akan dieksekusi dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Klik menu **File** dan pilih **Open Project**. Telusuri ke folder yang Anda klon atau unduh dari GitHub. Ikon folder **Examples** akan menunjukkan bahwa itu proyek Maven. Pilih Examples dan buka.

![todo:image_alt_text](netbeans_openproject.png)

Proyek akan terbuka dan mengunduh dependensi secara otomatis. Dari tab Projects, telusuri contoh di **source packages**. Untuk menjalankan contoh, cukup klik kanan pada berkas dan pilih **Run File**, contoh akan dieksekusi dan output akan ditampilkan di jendela konsol bawaan.

![todo:image_alt_text](netbeans_run_example.png)

## **Tambah Pustaka Aspose.Slides ke Repository Lokal Maven**
Saat Anda mengimpor proyek **Aspose.Slides Examples** ke IDE, Maven secara otomatis mengunduh berkas JAR aspose.slides dari [Aspose Maven Repository](https://releases.aspose.com/java/repo/com/aspose/). Jika Anda tidak memiliki akses internet, Anda dapat menambahkan JAR secara manual ke repository lokal Anda.

### **mvn install**
Unduh [aspose.slides](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/), ekstrak, dan salin aspose.slides-version.jar ke lokasi lain, misalnya drive C. Jalankan perintah berikut:

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
Setelah dipasang, cukup deklarasikan koordinat **aspose.slides** di pom.xml. Tambahkan repository berikut di tab repositories dan dependensi di tab dependencies.

``` xml
<repository>
    <id>AsposeJavaAPI</id>
    <name>Aspose Java API</name>
    <url>https://releases.aspose.com/java/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>26.10</version>
    <classifier>jdk8</classifier>
</dependency>
```

### **Selesai**
Bangun proyeknya, sekarang jar **aspose.slides** dapat diambil dari repository lokal Maven Anda.

## **Berkontribusi**
Jika Anda ingin menambahkan atau memperbaiki sebuah contoh, kami mendorong Anda untuk berkontribusi pada proyek. Semua contoh dan proyek showcase di repositori ini bersifat sumber terbuka dan dapat bebas digunakan dalam aplikasi Anda.

Untuk berkontribusi, Anda dapat melakukan fork repositori, mengedit kode sumber, dan mengirimkan Pull Request. Kami akan meninjau perubahan tersebut dan memasukkannya ke repositori bila dianggap bermanfaat.