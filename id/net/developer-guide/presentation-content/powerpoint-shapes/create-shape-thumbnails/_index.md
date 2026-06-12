---
title: Buat Thumbnail Bentuk Presentasi di .NET
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/net/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk .NET – dengan mudah buat dan ekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for .NET digunakan untuk membuat file presentasi di mana setiap halaman adalah slide. Slide tersebut dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides for .NET membantu Anda menghasilkan gambar mini (thumbnail) dari bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.
Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas penampilan bentuk.

## **Menghasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides for .NET:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Ambil gambar thumbnail bentuk dari slide yang direferensikan dengan skala default.
1. Simpan gambar thumbnail ke format gambar yang diinginkan.

Contoh di bawah ini menghasilkan thumbnail bentuk.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Menghasilkan Thumbnail dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides for .NET:

1. Buat instance dari kelas `Presentation`.
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Ambil gambar thumbnail dari slide yang direferensikan dengan batas bentuk.
1. Simpan gambar thumbnail ke format gambar yang diinginkan.

Contoh di bawah ini menghasilkan thumbnail dengan faktor skala yang ditentukan pengguna.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Skala pada sumbu X dan Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Membuat Thumbnail Penampilan Bentuk Berbasis Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas penampilan bentuk. Metode ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail dari bentuk slide apa pun dalam batas penampilannya, gunakan kode contoh berikut:

1. Buat instance dari kelas `Presentation`.
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Ambil gambar thumbnail dari slide yang direferensikan dengan batas bentuk sebagai penampilan.
1. Simpan gambar thumbnail ke format gambar yang diinginkan.

Contoh di bawah ini membuat thumbnail dengan faktor skala yang ditentukan pengguna.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Skala pada sumbu X dan Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/net/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [dieksport sebagai SVG vektor](https://reference.aspose.com/slides/id/net/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/net/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai thumbnail?**

Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slide tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Setiap objek yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/net/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/net/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/net/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perubahan tata letak teks.