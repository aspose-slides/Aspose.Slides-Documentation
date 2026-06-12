---
title: "Pertanyaan yang Sering Diajukan"
type: docs
weight: 340
url: /id/net/faqs/
keywords:
- FAQ
- PowerPoint
- format presentasi
- error memori tidak cukup
- ukuran slide
- ekstrak teks
- ambil teks
- ukuran paragraf
- memformat tabel
- font
- .NET
- C#
- Aspose.Slides
description: "Dapatkan jawaban atas FAQ pada Aspose.Slides untuk .NET, mencakup dukungan PowerPoint dan OpenDocument, panduan instalasi, lisensi, pemecahan masalah."
---
## **Gambaran Umum**

FAQ ini memberikan jawaban atas pertanyaan umum tentang Aspose.Slides. Ini mencakup format file yang didukung, penanganan pengecualian saat bekerja dengan presentasi besar, mengubah ukuran slide, menampilkan pratinjau slide, mengambil teks dari presentasi, memformat batas tabel, menempatkan gambar, dan menyelesaikan masalah terkait font saat mengonversi presentasi ke PDF atau gambar.

## **Format File yang Didukung**

**Q: Format file apa yang didukung oleh Aspose.Slides untuk .NET?**

**A**: Aspose.Slides untuk .NET mendukung format file yang dijelaskan dalam [Supported File Formats](/slides/id/net/supported-file-formats/).

## **Pengecualian**

**Q: Saya mendapatkan OutOfMemoryException saat memuat file PPT besar dengan gambar. Apakah ada batasan ukuran file di Aspose.Slides?**

**A**: Tidak ada formula khusus untuk menghitung ukuran presentasi yang didukung oleh Aspose.Slides. Harus ada cukup ruang untuk menampung seluruh struktur presentasi dan gambar dalam memori. Biasanya, gambar dalam memori memakan lebih banyak ruang dibandingkan dengan di hard disk, terutama ketika gambar memiliki efek tambahan.

Secara umum, Aspose.Slides untuk .NET dapat dengan mudah menangani file presentasi berukuran sekitar 300 MB pada server dengan RAM 4 GB.

## **Bekerja dengan Slide**

**Q: Bisakah saya mengubah ukuran slide dalam sebuah presentasi?**

**A**: Anda dapat menggunakan properti `SlideSize` yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk menentukan ukuran slide dalam sebuah presentasi.

**Q: Apakah ada cara untuk mendefinisikan slide dengan ukuran berbeda dalam sebuah presentasi?**

**A**: Karena ukuran slide didefinisikan pada tingkat presentasi dalam dokumen Microsoft PowerPoint, tidak ada cara untuk melakukannya.

**Q: Apakah Aspose.Slides untuk .NET mendukung pratinjau slide sebelum disimpan?**

**A**: Anda dapat merender slide presentasi menjadi gambar dan menggunakan gambar tersebut untuk pratinjau slide.

## **Bekerja dengan Teks**

**Q: Apakah memungkinkan untuk mengambil semua teks dari sebuah presentasi?**

**A**: Aspose.Slides untuk .NET menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/) di dalam namespace `Aspose.Slides.Util` yang menyediakan berbagai metode untuk mengambil seluruh teks dari presentasi.

**Q: Mengapa ukuran paragraf berbeda pada sistem operasi Windows dan Linux?**

**A**: Perhitungan ukuran paragraf didasarkan pada perhitungan ukuran teks yang merepresentasikan paragraf tersebut. Perhitungan ukuran teks menggunakan metrik font yang ditentukan dalam presentasi PowerPoint. Jika font yang ditentukan tidak ada, maka akan diganti dengan font yang paling mirip, namun font tersebut memiliki metrik yang berbeda dari yang asli. Akibatnya, perhitungan ukuran paragraf pada sistem yang berbeda akan menghasilkan hasil yang berbeda tergantung pada kumpulan font yang terpasang. Untuk mendapatkan hasil yang sama pada sistem operasi yang berbeda, Anda perlu menginstal font yang sama pada sistem atau memuatnya saat runtime sebagai [external fonts](/slides/id/net/custom-font/).

## **Pemformatan dan Gambar**

**Q: Bagaimana cara mengatur warna batas tabel?**

**A**: Anda dapat mengubah warna semua batas tabel atau hanya batas di sekitar seluruh tabel. Untuk mengubah semua batas, silakan gunakan properti `CellFormat` dari antarmuka [ICell](https://reference.aspose.com/slides/id/net/aspose.slides/icell/). Untuk batas seluruh tabel, Anda harus mengiterasi sel dan mengubah warna batas luar.

**Q: Ukuran apa yang digunakan Aspose.Slides untuk .NET saat menempatkan gambar?**

**A**: Koordinat dan ukuran semua bentuk pada slide diukur dalam poin (72 dpi).

## **Bekerja dengan Font**

**Q: Saat mengonversi PPT ke PDF atau gambar, mengapa font berbeda pada dokumen output?**

**A**: Masalah ini mungkin menunjukkan bahwa font yang digunakan dalam presentasi tidak ada di sistem operasi tempat kode dijalankan. Anda harus menginstal font pada sistem operasi atau memuatnya sebagai font eksternal menggunakan kelas [FontsLoader](https://reference.aspose.com/slides/id/net/aspose.slides/fontsloader/) seperti ditunjukkan di bawah ini:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```