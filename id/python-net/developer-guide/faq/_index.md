---
title: FAQ
type: docs
weight: 340
url: /id/python-net/faq/
keywords:
- FAQ
- format presentasi
- kesalahan memori tidak cukup
- ukuran slide
- ekstrak teks
- ambil teks
- ukuran paragraf
- pemformatan tabel
- font
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Dapatkan jawaban atas FAQ tentang Aspose.Slides untuk Python via .NET, mencakup dukungan PowerPoint dan OpenDocument, panduan instalasi, lisensi, serta pemecahan masalah."
---
## **Ikhtisar**

FAQ ini menyediakan jawaban untuk pertanyaan umum tentang Aspose.Slides. Ini mencakup format file yang didukung, penanganan pengecualian saat bekerja dengan presentasi besar, mengubah ukuran slide, menampilkan pratinjau slide, mengambil teks dari presentasi, memformat batas tabel, menempatkan gambar, dan menyelesaikan masalah terkait font saat mengonversi presentasi ke PDF atau gambar.

## **Format File yang Didukung**

**Q: Format file apa yang didukung Aspose.Slides untuk Python via .NET?**

**A**: Aspose.Slides untuk Python via .NET mendukung format file yang dijelaskan dalam [Supported File Formats](/slides/id/python-net/supported-file-formats/).

## **Pengecualian**

**Q: Saya mendapatkan pengecualian out of memory saat memuat file PPT besar dengan gambar. Apakah ada batasan dalam Aspose.Slides terkait ukuran file?**

**A**: Tidak ada formula khusus untuk menghitung ukuran presentasi yang didukung oleh Aspose.Slides. Harus ada cukup ruang untuk menampung seluruh struktur presentasi dan gambar di memori. Biasanya, gambar dalam memori menempati lebih banyak ruang daripada di hard disk, terutama ketika gambar memiliki efek tambahan.

Secara umum, Aspose.Slides untuk Python via .NET dapat menangani file presentasi sekitar 300 MB dengan mudah pada server yang memiliki 4 GB RAM.

## **Bekerja dengan Slide**

**Q: Bisakah saya mengubah ukuran slide dalam sebuah presentasi?**

**A**: Anda dapat menggunakan properti `slide_size` yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk menentukan ukuran slide dalam sebuah presentasi.

**Q: Apakah ada cara untuk menentukan slide dengan ukuran berbeda dalam satu presentasi?**

**A**: Karena ukuran slide didefinisikan pada tingkat presentasi dalam dokumen Microsoft PowerPoint, tidak ada cara untuk melakukannya.

**Q: Apakah Aspose.Slides untuk Python via .NET mendukung pratinjau slide sebelum disimpan?**

**A**: Anda dapat merender slide presentasi ke gambar dan menggunakan gambar‑gambar tersebut untuk pratinjau slide.

## **Bekerja dengan Teks**

**Q: Apakah memungkinkan untuk mengambil semua teks dari sebuah presentasi?**

**A**: Aspose.Slides untuk Python via .NET menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/) di dalam namespace `aspose.slides.util` yang menawarkan berbagai metode untuk mengambil seluruh teks dari presentasi.

**Q: Mengapa ukuran paragraf berbeda pada sistem operasi Windows dan Linux?**

**A**: Perhitungan ukuran paragraf didasarkan pada perhitungan ukuran teks yang mewakili paragraf tersebut. Perhitungan ukuran teks menggunakan metrik font yang ditentukan dalam presentasi PowerPoint. Jika font yang ditentukan tidak ada, maka akan diganti dengan font yang paling mirip, tetapi font pengganti memiliki metrik yang berbeda dari font asli. Akibatnya, perhitungan ukuran paragraf pada sistem yang berbeda akan menghasilkan hasil yang berbeda tergantung pada kumpulan font yang terpasang. Untuk memperoleh hasil yang sama pada berbagai sistem operasi, Anda perlu menginstal font yang sama pada sistem tersebut atau memuatnya pada waktu berjalan sebagai [external fonts](/slides/id/python-net/custom-font/).

## **Pemformatan dan Gambar**

**Q: Bagaimana cara mengatur warna batas tabel?**

**A**: Anda dapat mengubah warna semua batas tabel atau hanya batas di sekitar seluruh tabel. Untuk mengubah semua batas, gunakan properti `cell_format` dari kelas [Cell](https://reference.aspose.com/slides/id/python-net/aspose.slides/cell/). Untuk batas seluruh tabel, Anda harus mengiterasi sel‑sel dan mengubah warna batas luar.

**Q: Ukuran apa yang digunakan Aspose.Slides untuk Python via .NET dalam menempatkan gambar?**

**A**: Koordinat dan ukuran semua shape pada slide diukur dalam poin (72 dpi).

## **Bekerja dengan Font**

**Q: Saat mengonversi PPT ke PDF atau gambar, mengapa font berbeda pada dokumen output?**

**A**: Masalah ini mungkin menunjukkan bahwa font yang digunakan dalam presentasi tidak ada di sistem operasi tempat kode dijalankan. Anda harus menginstal font tersebut pada sistem operasi atau memuatnya sebagai font eksternal menggunakan kelas [FontsLoader](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsloader/) seperti yang ditunjukkan di bawah ini:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```