---
title: Menambahkan Bentuk Garis ke Presentasi di .NET
linktitle: Garis
type: docs
weight: 50
url: /id/net/Line/
keywords:
- garis
- membuat garis
- menambahkan garis
- garis polos
- mengonfigurasi garis
- menyesuaikan garis
- gaya dash
- kepala panah
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memanipulasi pemformatan garis dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET. Temukan properti, metode, dan contoh."
---
## **Ringkasan**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga tampil sebagai panah.

Anda akan mempelajari cara menambahkan bentuk garis ke sebuah slide, menyesuaikan tampilan visualnya, dan menyimpan presentasi yang telah diperbarui. Contoh-contoh berfokus pada pengaturan pemformatan garis praktis seperti gaya, lebar, pola dash, opsi ujung panah, dan warna isi.

## **Buat Garis Biasa**
Untuk menambahkan garis polos sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

- Buat instance dari [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) kelas.
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Line menggunakan metode [AddAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/methods/addautoshape/index) yang disediakan oleh objek Shapes.
- Simpan presentasi yang dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```c#
// Instansiasi kelas PresentationEx yang mewakili file PPTX
using (Presentation pres = new Presentation())
{
    // Dapatkan slide pertama
    ISlide sld = pres.Slides[0];

    // Tambahkan autoshape tipe garis
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Tulis PPTX ke Disk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Buat Garis Berbentuk Panah**
Aspose.Slides for .NET juga memungkinkan pengembang mengonfigurasi beberapa properti garis agar tampak lebih menarik. Mari kita coba mengonfigurasi beberapa properti garis agar tampak seperti panah. Ikuti langkah-langkah berikut untuk melakukannya:

- Buat instance dari [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/id/aspose.slides/)[](http://www.aspose.com/api/net/slides/id/aspose.slides/).
- Dapatkan referensi slide dengan menggunakan Index-nya.
- Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes.
- Atur Line Style ke salah satu gaya yang disediakan oleh Aspose.Slides for .NET.
- Atur Width garis.
- Atur [Dash Style](https://reference.aspose.com/slides/id/net/aspose.slides/linedashstyle) garis ke salah satu gaya yang disediakan oleh Aspose.Slides for .NET.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/net/aspose.slides/linearrowheadstyle) dan Length titik start garis.
- Atur Arrow Head Style dan Length titik akhir garis.
- Simpan presentasi yang dimodifikasi sebagai file PPTX.

```c#
// Instansiasi kelas PresentationEx yang mewakili file PPTX
using (Presentation pres = new Presentation())
{

    // Dapatkan slide pertama
    ISlide sld = pres.Slides[0];

    // Tambahkan autoshape tipe garis
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Terapkan beberapa pemformatan pada garis
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Tulis PPTX ke Disk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Bisakah saya mengonversi garis biasa menjadi konektor sehingga ia "menempel" pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) tipe [Line](https://reference.aspose.com/slides/id/net/aspose.slides/shapetype/)) tidak otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/net/aspose.slides/connector/) khusus dan [corresponding APIs](/slides/id/net/connector/) untuk koneksi.

**Apa yang harus saya lakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhirnya?**

[Baca properti efektif](/slides/id/net/shape-effective-properties/) melalui antarmuka [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ilinefillformateffectivedata/) — antarmuka ini sudah memperhitungkan pewarisan dan gaya tema.

**Bisakah saya mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukurannya)?**

Ya. Shapes menyediakan [objek kunci](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/autoshapelock/) yang memungkinkan Anda [menolak operasi pengeditan](/slides/id/net/applying-protection-to-presentation/).