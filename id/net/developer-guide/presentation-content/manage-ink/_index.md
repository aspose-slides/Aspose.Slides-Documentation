---
title: Kelola Objek Tinta Presentasi di .NET
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/net/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- ekspor tinta
- render tinta
- sembunyikan tinta
- IInkOptions
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kendalikan penampilan tinta selama ekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk .NET."
---
## **Pendahuluan**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menunjukkan koneksi dan proses, serta menarik perhatian ke item tertentu pada slide.

Namespace [Aspose.Slides.Ink](https://reference.aspose.com/slides/id/net/aspose.slides.ink/) berisi kelas dan antarmuka yang diperlukan untuk bekerja dengan objek tinta. Misalnya, antarmuka [IInk](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iink/) mewakili objek tinta pada sebuah slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Dalam bentuk paling sederhana, shape adalah wadah yang menentukan area objek itu sendiri (bingkainya) beserta properti seperti ukuran wadah, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/net/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti bingkai objek (wadah) kecuali ukurannya. Ukuran area wadah ditentukan oleh properti standar [IShape.Width](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/width/) dan [IShape.Height](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik‑titik jejak tinta. Kuas memiliki warna dan ukuran sendiri, yang diwakili oleh properti [IInkBrush.Color](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iinkbrush/color/) dan [IInkBrush.Size](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iinkbrush/size/).

### **Atur Warna Kuas Tinta**

Contoh kode C# berikut menunjukkan cara mengatur warna kuas tinta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Atur Ukuran Kuas Tinta**

Contoh kode C# berikut menunjukkan cara mengatur ukuran kuas tinta:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Secara umum, lebar dan tinggi kuas tidak sama, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data yang bersangkutan berwarna abu‑abu). Ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari perbesar tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Wadah (bingkai) tidak memperhitungkan ukuran kuas—selalu mengasumsikan ketebalan garis nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas jejaknya harus dipertimbangkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran wadah (bingkai). Ketika ukuran wadah berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrol Penampilan Tinta Selama Ekspor dan Rendering**

Aspose.Slides menyediakan antarmuka [IInkOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/) untuk mengontrol cara objek tinta muncul dalam output yang diekspor atau dirender. Anda dapat menggunakan propertinya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi masker kuas tinta diinterpretasikan.

Opsi tinta tersedia melalui opsi ekspor atau rendering untuk beberapa jenis output:

| Output | Properti opsi tinta |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/id/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/id/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/id/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/inkoptions/) |

Dua pengaturan yang sama tersedia melalui properti ini:

- [`HideInk`](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/hideink/) menentukan apakah objek tinta termasuk dalam output. Nilai bakunya adalah `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) menentukan apakah operasi masker diinterpretasikan sebagai opasitas saat merender kuas tinta. Nilai bakunya adalah `true`; ubah menjadi `false` untuk menggunakan operasi ROP sebagai gantinya.

### **Sembunyikan Objek Tinta dalam Output PDF**

Secara default, objek tinta tetap terlihat selama ekspor. Atur [IInkOptions.HideInk](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/hideink/) ke `true` ketika Anda memerlukan output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya.

Contoh C# berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Sembunyikan Objek Tinta Saat Merender Slide sebagai Gambar**

Untuk menyembunyikan objek tinta saat merender slide sebagai gambar bitmap, konfigurasikan [RenderingOptions.InkOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/renderingoptions/inkoptions/) dan berikan opsi rendering ke metode [ISlide.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/islide/getimage/).

Contoh C# berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Kontrol Rendering Masker Tinta**

Properti [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) mengendalikan cara operasi masker diinterpretasikan saat merender kuas tinta. Nilai bakinya adalah `true`, yang menggunakan opasitas. Atur properti ke `false` untuk menggunakan operasi ROP sebagai gantinya.

Contoh C# berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi masker tinta:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions.InkOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/tiffoptions/inkoptions/) saat mengekspor presentasi atau merender slide ke TIFF.

### **Pilih Apakah Akan Menyembunyikan atau Menjaga Tinta**

Gunakan [IInkOptions.HideInk](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/hideink/) yang diatur ke `true` ketika file yang diekspor harus menjadi versi bersih dari presentasi beranotasi, misalnya salinan akhir yang ditujukan untuk distribusi tanpa tanda ulasan.

Biarkan [IInkOptions.HideInk](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/hideink/) pada nilai bakunya `false` ketika anotasi tinta merupakan bagian dari konten yang diinginkan, seperti komentar ulasan, catatan tulisan tangan, sorotan, atau gambar yang harus tetap terlihat dalam hasil ekspor. Hal ini memungkinkan aplikasi menghasilkan keluaran ulasan dan akhir yang terpisah dari presentasi yang sama tanpa mengubah objek tinta sumber.

## **FAQ**

**Apakah saya dapat mengubah warna atau ukuran goresan tinta yang ada?**

Ya. Dapatkan jejak dari [IInk.Traces](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iink/traces/), lalu ubah [IInkTrace.Brush](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iinktrace/brush/). Anda dapat mengatur properti [IInkBrush.Color](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iinkbrush/color/) dan [IInkBrush.Size](https://reference.aspose.com/slides/id/net/aspose.slides.ink/iinkbrush/size/).

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. [IInkOptions.HideInk](https://reference.aspose.com/slides/id/net/aspose.slides.export/iinkoptions/hideink/) memengaruhi hanya hasil yang dirender atau diekspor; ia tidak menghapus atau memodifikasi objek tinta dalam presentasi sumber.

**Format ekspor mana yang mendukung opsi tinta?**

Anda dapat mengonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang bersangkutan seperti yang ditunjukkan di atas.

**Bacaan Lebih Lanjut**

* Untuk mempelajari shape secara umum, lihat bagian [Shape PowerPoint](https://docs.aspose.com/slides/id/net/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Properti Efektif Shape](https://docs.aspose.com/slides/id/net/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail tentang ekspor PDF, lihat [Konversi PPT dan PPTX ke PDF](https://docs.aspose.com/slides/id/net/convert-powerpoint-to-pdf/).
* Untuk detail tentang ekspor HTML, lihat [Konversi Presentasi PowerPoint ke HTML](https://docs.aspose.com/slides/id/net/convert-powerpoint-to-html/).
* Untuk detail tentang ekspor SVG, lihat [Render Slide Presentasi sebagai Gambar SVG](https://docs.aspose.com/slides/id/net/render-a-slide-as-an-svg-image/).
* Untuk detail tentang ekspor TIFF, lihat [Konversi Presentasi PowerPoint ke TIFF](https://docs.aspose.com/slides/id/net/convert-powerpoint-to-tiff/).
* Untuk detail tentang render slide ke gambar, lihat [Konversi Slide Presentasi ke Gambar](https://docs.aspose.com/slides/id/net/convert-slide/).