---
title: FAQ
type: docs
weight: 340
url: /id/cpp/faqs/
keywords:
- FAQ
- format presentasi
- kesalahan kehabisan memori
- ukuran slide
- ekstrak teks
- ambil teks
- ukuran paragraf
- memformat tabel
- font
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Dapatkan jawaban atas FAQ tentang Aspose.Slides untuk C++, mencakup dukungan PowerPoint dan OpenDocument, panduan instalasi, lisensi, serta pemecahan masalah."
---
## **Gambaran Umum**

FAQ ini memberikan jawaban atas pertanyaan umum tentang Aspose.Slides. FAQ ini mencakup format file yang didukung, penanganan pengecualian saat bekerja dengan presentasi besar, mengubah ukuran slide, menampilkan pratinjau slide, mengambil teks dari presentasi, memformat batas tabel, menempatkan gambar, serta menyelesaikan masalah terkait font saat mengonversi presentasi ke PDF atau gambar.

## **Format File yang Didukung**

**Q: Format file apa yang didukung oleh Aspose.Slides untuk C++?**

**A**: Aspose.Slides untuk C++ mendukung format file yang dijelaskan dalam [Supported File Formats](/slides/id/cpp/supported-file-formats/).

## **Pengecualian**

**Q: Saya mendapatkan pengecualian out of memory saat memuat file PPT besar dengan gambar. Apakah ada batasan ukuran file di Aspose.Slides?**

**A**: Tidak ada rumus khusus untuk menghitung ukuran presentasi yang didukung oleh Aspose.Slides. Harus ada cukup ruang untuk menampung seluruh struktur presentasi dan gambar di memori. Biasanya, gambar di memori memakan ruang lebih banyak daripada di hard disk, terutama ketika gambar memiliki efek tambahan.

Secara umum, Aspose.Slides untuk C++ dapat dengan mudah menangani file presentasi berukuran sekitar 300 MB pada server dengan RAM 4 GB.

## **Bekerja dengan Slide**

**Q: Apakah saya dapat mengubah ukuran slide dalam sebuah presentasi?**

**A**: Anda dapat menggunakan metode `get_SlideSize` yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) untuk menentukan ukuran slide dalam sebuah presentasi.

**Q: Apakah ada cara untuk menentukan slide dengan ukuran berbeda dalam satu presentasi?**

**A**: Karena ukuran slide ditentukan pada tingkat presentasi dalam dokumen Microsoft PowerPoint, tidak ada cara untuk melakukan hal ini.

**Q: Apakah Aspose.Slides untuk C++ mendukung pratinjau slide sebelum disimpan?**

**A**: Anda dapat merender slide presentasi ke gambar dan menggunakan gambar tersebut untuk menampilkan pratinjau slide.

## **Bekerja dengan Teks**

**Q: Apakah memungkinkan untuk mengambil semua teks dari sebuah presentasi?**

**A**: Aspose.Slides untuk C++ menyediakan kelas [SlideUtil](https://reference.aspose.com/slides/id/cpp/aspose.slides.util/slideutil/) di dalam namespace `Aspose::Slides::Util` yang menyediakan berbagai metode untuk mengambil seluruh teks dari presentasi.

**Q: Mengapa ukuran paragraf berbeda pada sistem operasi Windows dan Linux?**

**A**: Perhitungan ukuran paragraf didasarkan pada perhitungan ukuran teks yang mewakili paragraf tersebut. Perhitungan ukuran teks menggunakan metrik font yang ditentukan dalam presentasi PowerPoint. Jika font yang ditentukan tidak tersedia, font tersebut diganti dengan font yang paling mirip, tetapi font pengganti memiliki metrik yang berbeda dari font asli. Akibatnya, perhitungan ukuran paragraf pada sistem yang berbeda menghasilkan hasil yang berbeda tergantung pada kumpulan font yang terpasang. Untuk memperoleh hasil yang sama pada sistem operasi yang berbeda, Anda perlu memasang font yang sama pada semua sistem atau memuatnya pada waktu berjalan sebagai [external fonts](/slides/id/cpp/custom-font/).

## **Pemformatan dan Gambar**

**Q: Bagaimana cara mengatur warna batas tabel?**

**A**: Anda dapat mengubah warna semua batas tabel atau hanya batas di sekitar seluruh tabel. Untuk mengubah semua batas, gunakan metode `get_CellFormat` dari antarmuka [ICell](https://reference.aspose.com/slides/id/cpp/aspose.slides/icell/). Untuk batas seluruh tabel, iterasikan sel-selnya dan ubah warna batas luar.

**Q: Ukuran apa yang digunakan Aspose.Slides untuk C++ saat menempatkan gambar?**

**A**: Koordinat dan ukuran semua bentuk pada slide diukur dalam poin (72 dpi).

## **Bekerja dengan Font**

**Q: Saat mengonversi PPT ke PDF atau gambar, mengapa font di dokumen output berbeda?**

**A**: Masalah ini mungkin menunjukkan bahwa font yang digunakan dalam presentasi tidak ada pada sistem operasi tempat kode dijalankan. Anda harus memasang font pada sistem operasi atau memuatnya sebagai font eksternal menggunakan kelas [FontsLoader](https://reference.aspose.com/slides/id/cpp/aspose.slides/fontsloader/) seperti ditunjukkan di bawah ini:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```