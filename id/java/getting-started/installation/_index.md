---
title: Instalas i
type: docs
weight: 70
url: /id/java/installation/
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
- Java
- Aspose.Slides
description: "Instal Aspose.Slides untuk Java dari repository Maven Aspose atau sebagai file JAR, siapkan prasyarat Linux, dan periksa instalasi dengan program pertama."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menambahkan Aspose.Slides for Java ke sebuah proyek. Aspose.Slides for Java dipublikasikan di repositori Maven milik Aspose sendiri, bukan di Maven Central, sehingga proyek Maven harus menyatakan repositori tersebut. Anda juga dapat mengunduh file JAR dan menambahkannya ke class path secara manual. Kedua jalur berakhir dengan program singkat yang mengonfirmasi bahwa perpustakaan berfungsi.

Aspose.Slides for Java tidak memerlukan Microsoft PowerPoint. Ia secara program menghasilkan file presentasi yang diperlukan. Namun, untuk melihat presentasi yang dihasilkan, Anda mungkin memerlukan Microsoft PowerPoint atau penampil presentasi lainnya.

## **Prasyarat**

- Sebuah Java Development Kit (JDK). Proyek dan perintah dalam artikel ini memerlukan JDK 11 atau lebih baru. Pada JDK 11, program yang memeriksa instalasi mencetak peringatan yang dimulai dengan "WARNING: An illegal reflective access operation has occurred"; peringatan ini tidak memengaruhi hasil dan dapat diabaikan.
- [Apache Maven](https://maven.apache.org/install.html), jika Anda menggunakan jalur Maven.
- Pada Linux, pustaka fontconfig dan setidaknya satu font yang terpasang. Lihat [Linux](#linux).

## **Instal dari Repository Maven**

Aspose menyimpan pustaka Java-nya di [repository Maven](https://releases.aspose.com/java/repo/com/aspose/) miliknya sendiri. Untuk menggunakan [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) dalam proyek Maven, tambahkan dua entri ke *pom.xml* Anda.

1. **Deklarasikan repository Maven Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Tambahkan dependensi Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

Classifier `jdk8` diperlukan: ia memilih build Java SE dari perpustakaan. Ganti `26.10` dengan versi terbaru yang terdaftar di [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Repository menerbitkan file checksum SHA-1 di samping setiap JAR, yang diperiksa Maven saat mengunduh perpustakaan.

### **Periksa Instalasi**

Untuk memeriksa pengaturan dengan proyek baru:

1. Buat folder untuk proyek dan simpan *pom.xml* ini di dalamnya:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Selain repository dan dependensi, *pom.xml* ini mengatur rilis Java yang akan dikompilasi, memberi nama kelas yang dijalankan oleh `mvn exec:java`, dan mengunci plugin compiler, karena plugin lama yang digunakan secara default pada beberapa instalasi Maven mengabaikan pengaturan `maven.compiler.release`.

2. Simpan contoh pertama di [Create Presentations](/slides/id/java/create-presentation/) sebagai *src/main/java/HelloSlides.java*.

3. Di folder proyek, jalankan:

   ```bash
   mvn compile exec:java
   ```

Maven mengunduh Aspose.Slides for Java, mengompilasi program, dan menjalankannya. Program menyimpan *new_presentation.pptx* di folder proyek.

## **Gunakan File JAR tanpa Maven**

1. Unduh *aspose-slides-26.10-jdk8.jar* dari [folder versi](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) di repository. Untuk versi lain, buka foldernya di [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) dan unduh file yang diakhiri dengan *-jdk8.jar*.

2. Simpan contoh pertama di [Create Presentations](/slides/id/java/create-presentation/) sebagai *HelloSlides.java* di folder yang sama dengan file JAR.

3. Di folder tersebut, jalankan:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK mengompilasi dan menjalankan berkas sumber tunggal, dan program menyimpan *new_presentation.pptx* di folder. Dalam aplikasi Anda sendiri, tambahkan file JAR ke class path dalam alat build atau IDE Anda.

## **Linux**

Aspose.Slides for Java menggunakan dukungan font Java, yang pada Linux memerlukan pustaka fontconfig dan setidaknya satu font yang terpasang. Tanpa keduanya, penyimpanan presentasi gagal dengan error "Fontconfig head is null, check your fonts or fonts configuration". Gambar server dan kontainer minimal dapat kekurangan kedua hal tersebut; misalnya, gambar kontainer Ubuntu resmi tidak memiliki keduanya.

Pada Debian dan Ubuntu, perintah ini menginstal JDK, Maven, fontconfig, dan font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Font yang digunakan dalam presentasi Anda, atau substitusi yang cocok, juga harus diinstal agar teks dapat dirender dengan benar.

## **FAQ**

### Bagaimana saya dapat memverifikasi bahwa Aspose.Slides terintegrasi dengan benar?

Bangun proyek Anda, instantiate sebuah [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) kosong dan simpan dengan nama baru. Jika file dibuat tanpa melempar pengecualian, perpustakaan telah berhasil diintegrasikan.

### Bagaimana saya dapat membatasi konsumsi memori saat memproses presentasi besar?

Tingkatkan batas memori JVM hanya sebesar yang diperlukan, dan panggil [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) pada setiap instance [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) dalam blok `finally` untuk segera melepaskan cache. Ini mencegah error out‑of‑memory dan menjaga penggunaan memori secara keseluruhan tetap dapat diprediksi selama operasi batch.

### Bisakah saya mengecualikan format ekspor yang tidak diinginkan untuk memperkecil ukuran JAR akhir?

Rilis Aspose.Slides saat ini didistribusikan sebagai satu perpustakaan monolitik, sehingga Anda tidak dapat menonaktifkan exporter spesifik seperti PDF atau SVG pada waktu build.