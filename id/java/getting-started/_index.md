---
title: Memulai
type: docs
weight: 10
url: /id/java/getting-started/
keywords:
- memulai
- persyaratan sistem
- instalasi
- presentasi pertama
- Maven
- pemrosesan PPT
- pemrosesan PPTX
- pemrosesan ODP
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Jalur dari proyek Java baru hingga presentasi pertama yang disimpan dengan Aspose.Slides: periksa persyaratan, tambahkan pustaka dari repositori Maven Aspose, jalankan program pertama, dan lanjutkan dengan tugas-tugas umum."
---
## **Overview**

Kerjakan empat langkah di bawah ini secara berurutan. Setiap langkah menyebutkan apa yang harus dilakukan dan menautkan artikel dengan detailnya. Evaluasi, lisensi, dan dukungan dibahas setelah langkah‑langkah tersebut.

## **Step 1: Check the System Requirements**

Aspose.Slides for Java adalah satu file JAR tunggal tanpa kode native, sehingga dapat dijalankan pada sistem operasi apa pun yang memiliki runtime Java yang didukung. [System Requirements](/slides/id/java/system-requirements/) mencantumkan sistem operasi dan versi Java yang didukung. Proyek dan perintah pada langkah berikutnya memerlukan JDK 11 atau lebih baru dan, untuk jalur Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Step 2: Add the Library to Your Project**

Aspose.Slides for Java dipublikasikan di repositori Maven milik Aspose sendiri, bukan di Maven Central. Pilih salah satu jalur berikut:

- Dengan Maven: deklarasikan repositori `https://releases.aspose.com/java/repo/` di *pom.xml* Anda dan tambahkan dependensi `com.aspose:aspose-slides` dengan classifier `jdk16`.
- Tanpa Maven: unduh file JAR yang berakhiran *-jdk16.jar* dari repositori dan letakkan di class path.

Di Linux, instal juga pustaka fontconfig dan setidaknya satu font. Tanpa keduanya, penyimpanan presentasi akan gagal dengan error “Fontconfig head is null, check your fonts or fonts configuration”.

[Installation](/slides/id/java/installation/) memberikan entri *pom.xml*, unduhan JAR, dan perintah Linux.

## **Step 3: Create Your First Presentation**

[quick start on the Aspose.Slides for Java home page](/slides/id/java/#your-first-presentation) adalah proyek Maven lengkap: file *pom.xml* dan program yang menambahkan bentuk awan dengan teks ke slide dan menyimpan presentasi sebagai file PPTX. Anda menjalankannya dengan `mvn compile exec:java`. [Create Presentations](/slides/id/java/create-presentation/) menjelaskan program yang sama langkah demi langkah. Untuk membuka presentasi yang ada dan menyimpannya dalam format lain, lihat [Open Presentations](/slides/id/java/open-presentation/) dan [Save Presentations](/slides/id/java/save-presentation/).

## **Step 4: Continue with Common Tasks**

- [Open a presentation](/slides/id/java/open-presentation/)
- [Save a presentation](/slides/id/java/save-presentation/)
- [Convert a presentation to PDF](/slides/id/java/convert-powerpoint-to-pdf/)
- [Render slides as images](/slides/id/java/convert-slide/)
- [Edit presentation text](/slides/id/java/manage-text/)
- [Examples by slide element](/slides/id/java/examples/)

## **Evaluate and License**

Tanpa lisensi, Aspose.Slides berjalan dalam mode evaluasi: menambahkan watermark pada setiap slide yang disimpan dan memotong teks yang dibaca kode Anda dari presentasi.

- [Evaluate Aspose.Slides](/slides/id/java/evaluate-aspose-slides/) menjelaskan batasan evaluasi dan cara meminta lisensi sementara.
- [Licensing](/slides/id/java/licensing/) menunjukkan cara menerapkan lisensi dari file atau stream.
- [Metered Licensing](/slides/id/java/metered-licensing/) membahas lisensi yang ditagih berdasarkan penggunaan.
- [Supported File Formats](/slides/id/java/supported-file-formats/) mencantumkan format yang dapat dimuat dan disimpan oleh Aspose.Slides.

## **Get Help**

[Technical Support](/slides/id/java/technical-support/) menjelaskan cara mengajukan pertanyaan di [free support forum](https://forum.aspose.com/c/slides/id/11) dan apa yang harus disertakan saat melaporkan masalah.

## **FAQ**

**Do I need Microsoft PowerPoint installed?**

Tidak. Aspose.Slides membaca dan menulis file presentasi secara mandiri dan tidak menggunakan PowerPoint, sehingga dapat dijalankan di server dan di Linux.

**Why does Maven not find Aspose.Slides for Java?**

Pustaka tidak berada di Maven Central. Deklarasikan repositori Aspose di *pom.xml* Anda, seperti yang ditunjukkan dalam [Installation](/slides/id/java/installation/), dan Maven akan mengunduh pustaka dari sana.

**Does the `jdk16` classifier mean that the library needs Java 16?**

Tidak. Classifier memilih build Java SE dari pustaka; build lain untuk Android. Build yang sama berjalan pada JDK saat ini, seperti JDK 21.