---
title: "Mengonversi Slide PowerPoint ke PNG di .NET"
linktitle: "PowerPoint ke PNG"
type: docs
weight: 30
url: /id/net/convert-powerpoint-to-png/
keywords:
- mengonversi PowerPoint
- mengonversi presentasi
- mengonversi slide
- mengonversi PPT
- mengonversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- .NET
- C#
- Aspose.Slides
description: "Konversi presentasi PowerPoint menjadi gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk .NET, memastikan hasil yang tepat dan otomatis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk .NET. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender setiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah ini menunjukkan cara merender thumbnail, mengatur faktor skala, menentukan dimensi output dalam piksel, dan memilih gaya rendering gradien.

## **Konversi PowerPoint ke PNG**

Muat sebuah presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) dan akses slidennya melalui koleksi [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). Contoh ini merender setiap slide dengan [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) tanpa parameter untuk membuat thumbnail. Kemudian memanggil [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) dengan [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) untuk menyimpan setiap slide yang dirender sebagai gambar PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Overload [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) tanpa parameter merender pada skala 0,2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail 144 × 108 piksel. Untuk mengendalikan dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit yang ditunjukkan di bawah.
{{% /alert %}}

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) untuk mengendalikan dimensi yang dirender. Pada contoh ini, kedua faktor adalah 2, sehingga slide berukuran 720 × 540 poin menghasilkan gambar 1440 × 1080 piksel. Faktor skala yang sama mempertahankan rasio aspek slide. Setiap gambar disimpan dalam format PNG dengan [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) alih-alih faktor skala. Contoh ini merender setiap slide pada 960 × 720 piksel dan menyimpan hasilnya dengan [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Pilih dimensi yang cocok dengan rasio aspek slide untuk menghindari pemanjangan gambar.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Pilih Gaya Rendering Gradien**

Misalkan sebuah slide berisi isian gradien, tetapi transisi pada PNG yang diekspor tampak lebih terang atau berbeda dari apa yang Anda lihat di PowerPoint. Anda dapat menggunakan properti [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) dari [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi dua gradien linear: cyan ke orange di bagian atas dan biru ke kuning di bagian bawah. Setiap gradien memiliki dua stop, pada 0% dan 100%.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Gradien cyan-ke-oren dan biru-ke-kuning dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Dalam contoh ini, `Default` menghasilkan warna menengah yang lebih terang, sementara `PowerPointUI` menghasilkan warna menengah yang lebih gelap. Perbedaan tergantung pada warna dan stop dalam gradien.

Pilih `Default` ketika output standar Aspose.Slides sudah memenuhi kebutuhan Anda. Coba `PowerPointUI` ketika prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang Anda inginkan; tidak ada mode yang secara universal lebih baik.

## **FAQ**

**Bagaimana saya dapat mengekspor bentuk tertentu, seperti diagram atau gambar, alih-alih seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individual](/slides/id/net/create-shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya. Gunakan instance presentasi terpisah untuk setiap thread atau proses; [jangan berbagi satu instance di seluruh thread](/slides/id/net/multithreading/).

**Apa batasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lain](/slides/id/net/licensing/) sampai lisensi diterapkan.