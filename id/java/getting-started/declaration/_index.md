---
title: Persyaratan Security Manager
type: docs
weight: 190
url: /id/java/declaration/
keywords:
- Manajer Keamanan
- kebijakan keamanan
- AllPermission
- izin
- sandbox
- JDK 24
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Izin Security Manager apa yang dibutuhkan Aspose.Slides untuk Java dan kode yang memanggilnya pada Java 23 dan sebelumnya, serta mengapa tidak ada yang perlu dikonfigurasi pada Java 24 dan setelahnya."
---
## **Gambaran Umum**

Java Security Manager membatasi apa yang dapat dilakukan kode menurut kebijakan keamanan. Java 17 menandainya sebagai usang untuk dihapus ([JEP 411](https://openjdk.org/jeps/411)), dan Java 24 menonaktifkannya secara permanen ([JEP 486](https://openjdk.org/jeps/486)). Artikel ini menjelaskan apa yang dibutuhkan Aspose.Slides for Java ketika sebuah aplikasi masih berjalan dengan Security Manager. Jika aplikasi Anda tidak mengaktifkannya, yang merupakan default, tidak ada yang perlu dikonfigurasi.

## **Java 23 dan Sebelumnya**

Saat Security Manager diaktifkan, kebijakan keamanan harus memberikan izin berikut kepada file JAR Aspose.Slides dan kepada kode aplikasi yang memanggilnya:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides membaca properti sistem.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides membaca file font dan file lainnya.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides memulai program sistem operasi, misalnya `reg` pada Windows dan `fc-match` pada Linux.
- `java.io.FilePermission` dengan aksi `write` untuk folder tempat aplikasi Anda menyimpan file.

Memberikan izin ke file JAR saja tidak cukup: kode yang memanggil Aspose.Slides juga memerlukan izin tersebut. Memberikan `java.security.AllPermission` ke keduanya juga berfungsi.

Tanpa izin membaca properti sistem atau memulai program, Aspose.Slides gagal pada penggunaan pertama: membuat objek [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) melempar `ExceptionInInitializerError`. Tanpa akses membaca ke file font, menyimpan presentasi sebagai PDF gagal dengan error "Cannot find any fonts installed on the system".

## **Java 24 dan Selanjutnya**

Security Manager tidak dapat diaktifkan pada Java 24 dan versi berikutnya, sehingga tidak ada izin yang perlu diberikan. Aspose.Slides berjalan dengan izin akun yang menjalankan aplikasi Anda. Untuk membatasi apa yang dapat diakses aplikasi, proyek OpenJDK merekomendasikan teknologi di luar JDK, seperti kontainer, hypervisor, dan fitur sandboxing sistem operasi. Lihat [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Apakah saya dapat menggunakan Aspose.Slides di lingkungan yang menjalankan aplikasi dengan kebijakan Security Manager yang restriktif?**

Hanya jika kebijakan tersebut memberikan izin yang tercantum di atas baik kepada Aspose.Slides maupun ke kode yang memanggilnya. Izin tersebut mencakup membaca semua file dan memulai program apa pun.