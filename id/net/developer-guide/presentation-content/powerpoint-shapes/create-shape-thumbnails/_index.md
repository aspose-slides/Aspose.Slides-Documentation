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
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk .NET - dengan mudah membuat dan mengekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for .NET digunakan untuk membuat file presentasi dimana setiap halaman adalah slide. Slide tersebut dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun terkadang, pengembang mungkin perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus seperti itu, Aspose.Slides for .NET membantu Anda menghasilkan gambar mini (thumbnail) bentuk slide. Cara menggunakan fitur ini dijelaskan dalam artikel ini.
Artikel ini menjelaskan cara menghasilkan thumbnail slide dengan berbagai cara:

- Menghasilkan thumbnail bentuk di dalam slide.
- Menghasilkan thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Menghasilkan thumbnail bentuk dalam batas tampilan bentuk.

## **Menghasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides for .NET:

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan gambar thumbnail bentuk dari slide yang direferensikan dengan skala default.
1. Simpan gambar thumbnail ke format gambar yang diinginkan.

Contoh di bawah menghasilkan thumbnail bentuk.

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
Untuk menghasilkan thumbnail bentuk dari bentuk slide mana pun menggunakan Aspose.Slides for .NET:

1. Buat instance kelas `Presentation`.
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan batas bentuk.
1. Simpan gambar thumbnail dalam format gambar yang diinginkan.

Contoh di bawah menghasilkan thumbnail dengan faktor skala yang ditentukan pengguna.

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

## **Membuat Thumbnail Penampilan Bentuk Berdasarkan Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas penampilan bentuk. Metode ini memperhitungkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide apa pun dalam batas penampilannya, gunakan kode contoh berikut:

1. Buat instance kelas `Presentation`.
1. Dapatkan referensi slide mana pun menggunakan ID atau indeksnya.
1. Dapatkan gambar thumbnail slide yang direferensikan dengan batas bentuk sebagai penampilan.
1. Simpan gambar thumbnail dalam format gambar yang diinginkan.

Contoh di bawah membuat thumbnail dengan menghasilkan thumbnail dengan faktor skala yang ditentukan pengguna.

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

## **Mendapatkan Batas Visual Aktual Sebuah Bentuk**

Properti bingkai dari [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/)—properti `X`, `Y`, `Width`, dan `Height`—menjelaskan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui bingkai tersebut atau menempati persegi panjang berorientasi sumbu yang berbeda. Rotasi, outline, kepala panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, dan efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [GetVisualBounds](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getvisualbounds/) untuk menghitung area yang ditempati tanpa membuat gambar. Metode ini mengembalikan sebuah [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong ke slide, sehingga koordinatnya dapat negatif ketika konten melampaui asal slide.

[GetVisualBounds](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getvisualbounds/) saat ini tidak dideklarasikan oleh antarmuka [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/). Oleh karena itu, pertahankan bentuk yang diambil dari koleksi bentuk slide sebagai nilai antarmuka dan lakukan cast hanya saat memanggil metode tersebut.

Contoh berikut mengambil dan membandingkan bingkai serta batas visual:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

[RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) yang sama dapat digunakan untuk menyelaraskan bentuk-bentuk terdekat ke tepi `Left`, `Right`, `Top`, atau `Bottom`‑nya; menyediakan ruang yang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan grup bentuk, dimana bingkai yang disimpan mungkin tidak menggambarkan hasil rendering penuh.

Gunakan [GetVisualBounds](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getvisualbounds/) ketika Anda membutuhkan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [IShape.GetImage](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/getimage/) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` menyesuaikan ukuran gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds.Appearance` menyesuaikan dari penampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, [GetVisualBounds](https://reference.aspose.com/slides/id/net/aspose.slides/shape/getvisualbounds/) hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/net/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/net/aspose.slides/shape/writeassvg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/net/shape-effect/) (bayangan, cahaya, dll.).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah tetap dapat dirender sebagai thumbnail?**

Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; bendera tersembunyi memengaruhi tampilan slide show tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah grup bentuk, bagan, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/net/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/net/aspose.slides.charts/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/net/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/net/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perataan ulang teks.