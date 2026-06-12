---
title: FAQ
type: docs
weight: 340
url: /id/androidjava/faqs/
keywords:
- FAQ
- format presentasi
- error kehabisan memori
- ukuran slide
- ekstrak teks
- mengambil teks
- ukuran paragraf
- memformat tabel
- font
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Dapatkan jawaban atas FAQ tentang Aspose.Slides untuk Android via Java, mencakup dukungan PowerPoint dan OpenDocument, panduan instalasi, lisensi, pemecahan masalah."
---
## **Gambaran Umum**

FAQ ini menyediakan jawaban atas pertanyaan umum tentang Aspose.Slides. Dokumen ini mencakup format file yang didukung, penanganan pengecualian saat bekerja dengan presentasi besar, mengubah ukuran slide, pratinjau slide, mengambil teks dari presentasi, memformat batas tabel, menempatkan gambar, dan menyelesaikan masalah terkait font ketika mengonversi presentasi ke PDF atau gambar.

## **Format File yang Didukung**

**Q: Format file apa yang didukung oleh Aspose.Slides untuk Android via Java?**

**A**: Aspose.Slides untuk Android via Java mendukung format file yang dijelaskan di [Supported File Formats](/slides/id/androidjava/supported-file-formats/).

## **Pengecualian**

**Q: Saya mendapatkan pengecualian out of memory saat memuat file PPT besar dengan gambar. Apakah ada batasan ukuran file di Aspose.Slides?**

**A**: Tidak ada rumus khusus untuk menghitung ukuran presentasi yang didukung oleh Aspose.Slides. Harus ada cukup ruang untuk menampung seluruh struktur presentasi dan gambar di memori. Biasanya, gambar dalam memori memakan ruang lebih banyak daripada di hard disk, terutama ketika gambar memiliki efek tambahan.

Secara umum, Aspose.Slides untuk Android via Java dapat dengan mudah menangani file presentasi sekitar 300 MB pada server dengan RAM 4 GB.

## **Bekerja dengan Slide**

**Q: Apakah saya dapat mengubah ukuran slide dalam sebuah presentasi?**

**A**: Anda dapat menggunakan metode `getSlideSize` yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/) untuk menentukan ukuran slide dalam presentasi.

**Q: Apakah ada cara untuk mendefinisikan slide dengan ukuran berbeda dalam satu presentasi?**

**A**: Karena ukuran slide didefinisikan pada tingkat presentasi dalam dokumen Microsoft PowerPoint, tidak ada cara untuk melakukan hal ini.

**Q: Apakah Aspose.Slides untuk Android via Java mendukung pratinjau slide sebelum disimpan?**

**A**: Anda dapat merender slide presentasi menjadi gambar dan menggunakan gambar tersebut untuk pratinjau slide.

## **Bekerja dengan Teks**

**Q: Apakah memungkinkan untuk mengambil semua teks dari sebuah presentasi?**

**A**: Aspose.Slides untuk Android via Java menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/) yang menawarkan berbagai metode untuk mengambil seluruh teks dari presentasi.

**Q: Mengapa ukuran paragraf berbeda di PC dan Android?**

**A**: Perhitungan ukuran paragraf didasarkan pada perhitungan ukuran teks yang mewakili paragraf tersebut. Perhitungan ukuran teks didasarkan pada metrik font yang ditentukan dalam presentasi PowerPoint. Jika font yang ditentukan tidak tersedia, ia diganti dengan font yang paling mirip, tetapi font tersebut memiliki metrik yang berbeda dari yang asli. Akibatnya, perhitungan ukuran paragraf pada sistem yang berbeda akan menghasilkan hasil yang berbeda tergantung pada kumpulan font yang terpasang. Untuk mendapatkan hasil yang sama pada sistem operasi yang berbeda, Anda perlu memasang font yang sama pada sistem atau memuatnya pada runtime sebagai [external fonts](/slides/id/androidjava/custom-font/).

## **Pemformatan dan Gambar**

**Q: Bagaimana cara mengatur warna batas tabel?**

**A**: Anda dapat mengubah warna semua batas tabel atau hanya batas di sekitar seluruh tabel. Untuk mengubah semua batas, gunakan metode `getCellFormat` dari antarmuka [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/). Untuk batas seluruh tabel, Anda harus iterasi sel dan mengubah warna batas luar.

**Q: Pengukuran apa yang digunakan Aspose.Slides untuk Android via Java dalam menempatkan gambar?**

**A**: Koordinat dan ukuran semua bentuk pada slide diukur dalam poin (72 dpi).

## **Bekerja dengan Font**

**Q: Saat mengonversi PPT ke PDF atau gambar, mengapa font berbeda pada dokumen output?**

**A**: Masalah ini mungkin menunjukkan bahwa font yang digunakan dalam presentasi tidak ada di sistem operasi tempat kode dijalankan. Anda harus memasang font tersebut pada sistem operasi atau memuatnya sebagai font eksternal menggunakan kelas [FontsLoader](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontsloader/) seperti ditunjukkan di bawah ini:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```