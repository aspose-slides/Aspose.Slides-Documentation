---
title: Ubah Ukuran dan Orientasi Halaman Catatan di .NET
linktitle: Ukuran Halaman Catatan
type: docs
weight: 10
url: /id/net/notes-size/
keywords:
- ukuran halaman catatan
- orientasi catatan
- catatan lanskap
- catatan potret
- ukuran handout
- PowerPoint
- presentasi
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Baca dan ubah dimensi halaman catatan di Aspose.Slides untuk .NET, ubah orientasi, verifikasi ukuran yang disimpan, dan ekspor catatan atau handout ke PDF dan gambar."
---
## **Ikhtisar**

Gunakan [Presentation.NotesSize](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/notessize/) untuk mengakses pengaturan halaman catatan presentasi. Metode ini mengembalikan objek [INotesSize](https://reference.aspose.com/slides/id/net/aspose.slides/inotessize/) yang properti [Size](https://reference.aspose.com/slides/id/net/aspose.slides/inotessize/size/) dapat ditulisi. Meskipun objek pengaturan bersifat read‑only, Anda dapat menetapkan dimensi baru ke properti ukuran tersebut.

Lebar dan tinggi ditentukan dalam **point**, dengan 72 point per inci. Misalnya, 900 × 600 point adalah 12,5 × 8⅓ inci. Pengaturan ini berlaku untuk seluruh presentasi, bukan untuk catatan slide individu.

| Pengaturan | Tujuan |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/notessize/) | Mengontrol dimensi halaman catatan dan dimensi halaman yang digunakan untuk ekspor handout. |
| [Presentation.SlideSize](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/slidesize/) | Mengontrol dimensi slide presentasi biasa melalui [ISlideSize](https://reference.aspose.com/slides/id/net/aspose.slides/islidesize/). |

Mengubah salah satu pengaturan tidak secara otomatis mengubah yang lain. Mengubah orientasi halaman catatan juga tidak memutar slide reguler. Lihat [Slide Size](/slides/id/net/slide-size/) untuk mengubah ukuran slide reguler.

Contoh di bawah menggunakan file `sample.pptx` yang sudah ada. Untuk contoh ekspor, gunakan presentasi yang memiliki setidaknya satu slide dengan catatan pembicara. Setiap contoh dapat dijalankan secara terpisah.

## **Baca Ukuran dan Orientasi Halaman Catatan**

Baca lebar dan tinggi serta bandingkan untuk menentukan orientasi: halaman yang lebih lebar merupakan lanskap, yang lebih tinggi merupakan potret, dan dimensi yang sama menggambarkan halaman persegi. Contoh ini mencetak dimensi sebenarnya dalam point, tanpa mengasumsikan ukuran kertas standar.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **Beralih ke Lanskap Tanpa Mengubah Ukuran Kertas**

Untuk mengubah hanya orientasi, tukar lebar dan tinggi yang ada. Ini mempertahankan panjang kedua sisi, termasuk ukuran kertas khusus. Kondisi di bawah mencegah halaman yang sudah dalam orientasi lanskap beralih kembali ke potret dan membiarkan halaman persegi tidak berubah.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

Untuk orientasi potret, gunakan penetapan yang sama ketika `size.Width > size.Height`. Jangan mengganti dimensi A4 atau Letter kecuali Anda juga ingin mengubah ukuran kertas.

## **Atur dan Verifikasi Ukuran Halaman Catatan Kustom**

Tetapkan kedua dimensi sekaligus, kemudian gunakan [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) untuk menulis presentasi. Contoh ini menetapkan halaman lanskap 900 × 600 point, menyimpannya sebagai PPTX, dan membuka kembali file yang disimpan untuk memeriksa nilai yang dipertahankan. Perbandingan memperbolehkan toleransi 0,01 point untuk nilai floating‑point; ini bukan jaminan presisi untuk setiap format file.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

Hasil yang diharapkan adalah `900 x 600 points` dan `Size preserved: True`. Memeriksa presentasi yang baru dibuka memverifikasi file yang disimpan, bukan hanya pengaturan dalam memori.

## **Ekspor Catatan dan Handout**

Dimensi halaman mendefinisikan area yang tersedia untuk tata letak catatan atau handout. Mereka tidak mengaktifkan tata letak tersebut sendiri: konfigurasi opsi ekspor juga diperlukan. Ekspor slide reguler tetap menggunakan dimensi slide.

### **Ekspor Catatan ke PDF dan PNG**

Tetapkan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/notescommentslayoutingoptions/) ke [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) untuk menyertakan catatan dalam PDF. Contoh ini juga merender slide pertama dengan catatan ke PNG menggunakan [Slide.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/slide/getimage/) dan [RenderingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/).

Mode [BottomTruncated](https://reference.aspose.com/slides/id/net/aspose.slides.export/notespositions/) menjaga catatan tetap pada satu halaman; catatan yang tidak muat dapat dipotong. PDF menggunakan halaman 900 × 600 point. Pada skala gambar 1 × 1 yang digunakan di bawah, PNG berukuran 900 × 600 piksel. Point menggambarkan geometri halaman; piksel menggambarkan output raster, yang dimensinya juga bergantung pada skala rendering.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

Untuk ekspor PDF dengan catatan panjang, [BottomFull](https://reference.aspose.com/slides/id/net/aspose.slides.export/notespositions/) memungkinkan penambahan halaman sesuai kebutuhan. Jangan gunakan mode itu dengan pemanggilan gambar satu‑slide di atas, yang tidak mendukungnya. Setelah mengubah ukuran, periksa output untuk catatan yang terpotong dan penempatan objek notes‑master yang ada; mengubah dimensi halaman saja tidak menjamin semua konten akan muat. Lihat [Convert PowerPoint to PDF with Notes](/slides/id/net/convert-powerpoint-to-pdf-with-notes/) untuk informasi lebih lanjut tentang ekspor catatan.

### **Ekspor Handout ke PDF**

Gunakan [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/handoutlayoutingoptions/) untuk menampilkan beberapa thumbnail slide pada satu halaman. Contoh berikut menetapkan halaman 900 × 600 point dan menggunakan [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/id/net/aspose.slides.export/handouttype/) untuk menata hingga empat slide per halaman. Preset horizontal mengontrol urutan slide; orientasi halaman berasal dari lebar dan tingginya.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

Mengubah ukuran halaman mengubah area yang tersedia untuk grid handout tanpa mengubah dimensi slide sumber. Untuk gambar handout, gunakan [Presentation.GetImages](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/getimages/) dengan tata letak handout, bukan metode gambar slide individu. Di Aspose.Slides, rendering handout tingkat presentasi menggunakan dimensi halaman catatan, sementara pemanggilan gambar slide individu tidak menghasilkan halaman handout. Lihat [Handout Mode](/slides/id/net/convert-powerpoint-in-handout-mode/) untuk opsi tata letak.

## **Ukuran Halaman di Penampil, Ekspor, dan Pencetakan**

Pertahankan ukuran presentasi yang disimpan, ukuran halaman yang diekspor, dan ukuran kertas yang dicetak secara terpisah:

- **Penampil presentasi:** Penampil dapat menampilkan atau mencetak catatan menggunakan aturan tata letak miliknya. Jika aplikasi lain menyimpan file, buka kembali dan periksa dimensi lagi; konversi format aplikasi tersebut mungkin menormalkannya.
- **Format ekspor:** Contoh PDF catatan dan handout di atas menggunakan dimensi halaman yang telah dikonfigurasi. Gambar raster menggunakan dimensi piksel bulat dan skala rendering, sehingga nilai point pecahan dapat dibulatkan dalam output gambar. Mengekspor slide reguler tidak menerapkan ukuran halaman catatan.
- **Driver printer:** Pemilihan kertas, rotasi otomatis, dan pengaturan fit‑to‑page dapat mengubah output fisik tanpa mengubah dimensi yang disimpan dalam presentasi atau PDF. Untuk ukuran kertas tertentu, cocokkan pengaturan printer dan periksa pratinjau cetak.

## **FAQ**

**Apakah saya dapat mengatur ukuran catatan untuk hanya satu slide?**

Ukuran halaman catatan adalah pengaturan tingkat presentasi. Slide individual dapat memiliki konten catatan yang berbeda, tetapi properti ini tidak menyediakan ukuran halaman terpisah untuk setiap slide.

**Mengapa mengubah orientasi catatan tidak mengubah slide saya?**

Halaman catatan dan slide reguler memiliki dimensi yang independen. Gunakan pengaturan ukuran slide reguler ketika Anda ingin mengubah ukuran slide itu sendiri.

**Mengapa hasil yang saya simpan atau cetak memiliki ukuran yang berbeda?**

Pertama, buka kembali presentasi yang disimpan dan bandingkan dimensi catatannya. Jika berubah, periksa apakah proses penyimpanan atau konversi file di aplikasi lain mengubah pengaturan halaman. Jika tidak, periksa tata letak ekspor, skala gambar, pengaturan penampil, dan pilihan kertas printer.