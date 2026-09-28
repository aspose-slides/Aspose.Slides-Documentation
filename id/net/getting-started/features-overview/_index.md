---
title: Ikhtisar Fitur
type: docs
weight: 94
url: /id/net/features-overview/
keywords:
- fitur
- platform yang didukung
- format file
- konversi
- rendering
- konten presentasi
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tinjau apa saja yang dicakup oleh Aspose.Slides untuk .NET sebelum Anda mengevaluasinya: platform yang didukung, format file, rendering slide, dan konten yang dapat Anda buat serta edit."
---
## **Gambaran Umum**

Aspose.Slides for .NET adalah pustaka kelas untuk membuat, membaca, mengedit, mengonversi, dan merender presentasi PowerPoint dan OpenDocument. Ia tidak memiliki antarmuka pengguna sendiri dan tidak memerlukan Microsoft PowerPoint atau Office, sehingga Anda dapat menggunakannya dalam aplikasi konsol, aplikasi desktop seperti Windows Forms, aplikasi web, dan layanan web. Artikel ini merangkum apa yang dicakup oleh pustaka ini dan menautkan ke artikel yang menjelaskan setiap area.

## **Platform yang Didukung**

Aspose.Slides for .NET didistribusikan sebagai dua paket NuGet dengan API yang sama:

|**Paket**|**Komponen dalam paket**|**Sistem operasi**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0, dan .NET 6. Gunakan dengan .NET Framework 4.6.2 atau yang lebih baru, atau dengan .NET 6 atau yang lebih baru.|Windows. Linux dan macOS dengan pustaka `libgdiplus` dan saklar `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Gunakan dengan .NET 6 atau yang lebih baru.|Windows (x86, x64), Linux (x64 dengan glibc 2.23 atau yang lebih baru, ARM64 dengan glibc 2.39 atau yang lebih baru), dan macOS (x64, ARM64).|

[Instalasi](/slides/id/net/installation/) menjelaskan paket mana yang harus dipilih dan apa yang diperlukan masing‑masing pada Linux. [Persyaratan Sistem](/slides/id/net/system-requirements/) mencantumkan platform yang didukung secara rinci.

## **Format File dan Konversi**

Aspose.Slides membuka dan menyimpan presentasi PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP, serta presentasi XML PowerPoint. Ia mengimpor konten PDF dan HTML ke dalam slide, dan menyimpan presentasi sebagai PDF, XPS, HTML, HTML5, TIFF, GIF animasi, SWF, Markdown, dan XAML. [Format File yang Didukung](/slides/id/net/supported-file-formats/) mencantumkan setiap format beserta API yang membacanya atau menulisnya.

|**Fitur**|**Deskripsi**|
| :- | :- |
|[PPT dan PPTX](/slides/id/net/ppt-vs-pptx/)|Membaca dan menulis baik format binari PowerPoint 97-2003 maupun format Office Open XML.|
|[Konversi PPT ke PPTX](/slides/id/net/convert-ppt-to-pptx/)|Mengonversi presentasi PPT lama ke PPTX.|
|[Format Dokumen Portabel (PDF)](/slides/id/net/convert-powerpoint-to-pdf/)|Mengekspor presentasi ke PDF, termasuk dokumen PDF/A dan PDF/UA.|
|[Spesifikasi Kertas XML (XPS)](/slides/id/net/convert-powerpoint-to-xps/)|Mengekspor presentasi ke dokumen XPS.|
|[Format File Gambar Berlabel (TIFF)](/slides/id/net/convert-powerpoint-to-tiff/)|Mengekspor presentasi ke gambar TIFF.|
|[HTML](/slides/id/net/convert-powerpoint-to-html/)|Mengekspor presentasi ke HTML dan HTML5.|
|[Impor PDF dan HTML](/slides/id/net/import-presentation/)|Membuat slide dari halaman PDF dan konten HTML.|

## **Rendering Presentasi**

Aspose.Slides merender slide dan bentuk individual sebagai gambar PNG, JPEG, BMP, GIF, TIFF, dan SVG, serta slide sebagai file metafile EMF. Lihat [Konversi Slide Presentasi ke Gambar](/slides/id/net/convert-slide/), [Render Slide sebagai Gambar SVG](/slides/id/net/render-a-slide-as-an-svg-image/), dan [Buat Thumbnail Bentuk](/slides/id/net/create-shape-thumbnails/).

## **Fitur Konten**

Aspose.Slides memungkinkan Anda membuat, membaca, dan memodifikasi hampir semua konten presentasi:

|**Area**|**Apa yang dapat Anda lakukan**|
| :- | :- |
|[Slide](/slides/id/net/presentation-slide/)|Menambah, menggandakan, mengubah urutan, dan menghapus slide; menerapkan tata letak dan master; mengatur slide ke dalam bagian; mengubah ukuran slide.|
|[Desain](/slides/id/net/presentation-design/)|Mengatur latar belakang, warna tema, header dan footer, serta font.|
|[Teks](/slides/id/net/manage-text/)|Membuat dan menyunting bingkai teks, paragraf, dan potongan; mengatur font, warna, bullet, dan perataan; menemukan dan mengganti teks.|
|[Bentuk](/slides/id/net/powerpoint-shapes/)|Membuat AutoShape, garis, penghubung, grup bentuk, dan bingkai gambar; mengatur posisi, ukuran, garis, serta isian padat, gradasi, atau pola; menemukan bentuk berdasarkan teks alternatifnya.|
|[Tabel](/slides/id/net/powerpoint-table/), [grafik](/slides/id/net/powerpoint-charts/), dan [SmartArt](/slides/id/net/powerpoint-smartart/)|Membuat dan menyunting tabel, grafik Microsoft Office, serta diagram SmartArt.|
|[Media](/slides/id/net/manage-media-files/), [objek OLE](/slides/id/net/manage-ole/), dan [kontrol ActiveX](/slides/id/net/activex/)|Menambahkan bingkai audio atau video yang tertanam atau ditautkan, menyematkan objek OLE, serta menambah, mengubah, atau menghapus kontrol ActiveX.|
|[Catatan](/slides/id/net/presentation-notes/) dan [komentar](/slides/id/net/presentation-comments/)|Menambah, membaca, dan menyunting catatan pembicara serta komentar ulasan.|
|[Animasi](/slides/id/net/powerpoint-animation/) dan [transisi](/slides/id/net/slide-transition/)|Menerapkan efek animasi pada bentuk, mengatur transisi slide, dan mengkonfigurasi pengaturan tayang slide.|
|[Keamanan](/slides/id/net/presentation-security/)|Mengenkripsi presentasi dengan kata sandi, mengatur perlindungan penulisan, dan bekerja dengan tanda tangan digital.|
|[Makro VBA](/slides/id/net/presentation-via-vba/)|Menambah, mengekstrak, dan menghapus modul VBA pada presentasi yang mendukung makro.|
|[Properti](/slides/id/net/presentation-properties/)|Membaca dan menyunting properti dokumen.|

## **FAQ**

**Apakah saya perlu menginstal Microsoft PowerPoint di server atau PC agar pustaka ini berfungsi?**

Tidak. PowerPoint tidak diperlukan; Aspose.Slides adalah mesin mandiri untuk membuat, menyunting, mengonversi, dan merender presentasi.

**Bagaimana multithreading bekerja? Dapatkah pemrosesan diparalelisasi?**

Aman memproses dokumen yang berbeda dalam thread yang berbeda; objek **Presentation** yang sama tidak boleh digunakan oleh **multiple threads** pada waktu yang bersamaan.

**Apakah kata sandi file dan enkripsi didukung?**

Ya. **Anda dapat**[/slides/id/net/password-protected-presentation/] membuka presentasi terenkripsi, mengatur atau menghapus kata sandi buka dan tulis, serta memeriksa status perlindungan.

**Apakah saya perlu memperhatikan font di kontainer Linux?**

Ya. Font yang digunakan dalam presentasi Anda, atau pengganti yang cocok, harus diinstal pada sistem agar teks dapat dirender dengan benar. Anda juga dapat **menentukan direktori font**[/slides/id/net/custom-font/] dalam aplikasi Anda. **Instalasi**[/slides/id/net/installation/] mencantumkan prasyarat Linux untuk masing‑masing paket.

**Apakah ada batasan pada versi evaluasi?**

Ya. Tanpa **lisensi**[/slides/id/net/licensing/], Aspose.Slides menambahkan watermark evaluasi pada setiap slide yang disimpan dan memotong teks yang dibaca dari presentasi. **Lisensi sementara 30 hari**[https://purchase.aspose.com/temporary-license/] tersedia untuk pengujian dengan semua fitur.

**Apakah mengimpor format eksternal ke dalam presentasi (PDF atau HTML ke PPTX) didukung?**

Ya. Anda dapat menambah **halaman PDF dan konten HTML**[/slides/id/net/import-presentation/] ke sebuah presentasi, menjadikannya slide.