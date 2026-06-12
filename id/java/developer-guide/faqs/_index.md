---
title: FAQ
type: docs
weight: 340
url: /id/java/faqs/
keywords:
- FAQ
- format presentasi
- error kehabisan memori
- ukuran slide
- ekstrak teks
- ambil teks
- ukuran paragraf
- memformat tabel
- font
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Dapatkan jawaban atas FAQ tentang Aspose.Slides untuk Java, mencakup dukungan PowerPoint dan OpenDocument, panduan instalasi, lisensi, serta pemecahan masalah."
---
## **Gambaran Umum**

FAQ ini memberikan jawaban atas pertanyaan umum tentang Aspose.Slides. Ini mencakup format file yang didukung, penanganan pengecualian saat bekerja dengan presentasi besar, mengubah ukuran slide, melihat pratinjau slide, mengambil teks dari presentasi, memformat batas tabel, menempatkan gambar, dan menyelesaikan masalah terkait font saat mengonversi presentasi ke PDF atau gambar.

## **Format File yang Didukung**

**Q:** Format file apa yang didukung oleh Aspose.Slides for Java?

**A:** Aspose.Slides for Java mendukung format file yang dijelaskan di [Supported File Formats](/slides/id/java/supported-file-formats/).

## **Pengecualian**

**Q:** Saya mendapatkan pengecualian out of memory saat memuat file PPT besar dengan gambar. Apakah ada batasan di Aspose.Slides terkait ukuran file?

**A:** Tidak ada rumus khusus untuk menghitung ukuran presentasi yang didukung oleh Aspose.Slides. Harus ada cukup ruang untuk menampung seluruh struktur presentasi dan gambar dalam memori. Biasanya, gambar dalam memori memakan lebih banyak ruang daripada di hard disk, terutama ketika gambar memiliki efek tambahan.

Secara umum, Aspose.Slides for Java dapat dengan mudah menangani file presentasi berukuran sekitar 300 MB pada server dengan RAM 4 GB.

## **Bekerja dengan Slide**

**Q:** Bisakah saya mengubah ukuran slide dalam sebuah presentasi?

**A:** Anda dapat menggunakan metode `getSlideSize` yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) untuk menentukan ukuran slide dalam sebuah presentasi.

**Q:** Apakah ada cara untuk menentukan slide dengan ukuran berbeda dalam satu presentasi?

**A:** Karena ukuran slide didefinisikan pada tingkat presentasi dalam dokumen Microsoft PowerPoint, tidak ada cara untuk melakukannya.

**Q:** Apakah Aspose.Slides for Java mendukung pratinjau slide sebelum menyimpan?

**A:** Anda dapat merender slide presentasi menjadi gambar dan menggunakan gambar tersebut untuk pratinjau slide.

## **Bekerja dengan Teks**

**Q:** Apakah memungkinkan untuk mengambil semua teks dari sebuah presentasi?

**A:** Aspose.Slides for Java menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/java/com.aspose.slides/slideutil/) yang menawarkan berbagai metode untuk mengambil seluruh teks dari presentasi.

**Q:** Mengapa ukuran paragraf berbeda pada sistem operasi Windows dan Linux?

**A:** Perhitungan ukuran paragraf didasarkan pada perhitungan ukuran teks yang mewakili paragraf tersebut. Perhitungan ukuran teks didasarkan pada metrik font yang ditentukan dalam presentasi PowerPoint. Jika font yang ditentukan tidak ada, maka akan digantikan dengan font yang paling mirip, tetapi font tersebut memiliki metrik yang berbeda dari yang asli. Akibatnya, perhitungan ukuran paragraf di sistem yang berbeda akan menghasilkan hasil yang berbeda tergantung pada kumpulan font yang terpasang. Untuk mencapai hasil yang sama pada sistem operasi yang berbeda, Anda perlu memasang font yang sama pada sistem atau memuatnya pada waktu menjalankan sebagai [external fonts](/slides/id/java/custom-font/).

## **Pemformatan dan Gambar**

**Q:** Bagaimana saya dapat mengatur warna batas tabel?

**A:** Anda dapat mengubah warna semua batas tabel atau hanya batas di sekitar seluruh tabel. Untuk mengubah semua batas, silakan gunakan metode `getCellFormat` dari antarmuka [ICell](https://reference.aspose.com/slides/id/java/com.aspose.slides/icell/). Untuk batas seluruh tabel, Anda harus mengiterasi sel dan mengubah warna batas luar.

**Q:** Ukuran satuan apa yang digunakan Aspose.Slides for Java untuk menempatkan gambar?

**A:** Koordinat dan ukuran semua bentuk pada slide diukur dalam poin (72 dpi).

## **Bekerja dengan Font**

**Q:** Saat mengonversi PPT ke PDF atau gambar, mengapa font berbeda dalam dokumen output?

**A:** Masalah ini mungkin menunjukkan bahwa font yang digunakan dalam presentasi tidak ada di sistem operasi tempat kode dijalankan. Anda harus memasang font pada sistem operasi atau memuatnya sebagai font eksternal menggunakan kelas [FontsLoader](https://reference.aspose.com/slides/id/java/com.aspose.slides/fontsloader/) seperti ditunjukkan di bawah:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```