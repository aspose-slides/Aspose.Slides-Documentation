---
title: Tambah Bentuk Garis ke Presentasi di .NET
linktitle: Garis
type: docs
weight: 50
url: /id/net/line/
keywords:
- garis
- buat garis
- tambahkan garis
- garis biasa
- konfigurasi garis
- sesuaikan garis
- gaya putus-putus
- kepala panah
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara memanipulasi pemformatan garis pada presentasi PowerPoint dengan Aspose.Slides untuk .NET. Temukan properti, metode, dan contoh."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga muncul sebagai panah.

Anda akan belajar cara menambahkan bentuk garis ke slide, menyesuaikan tampilan visualnya, dan menyimpan presentasi yang telah diperbarui. Contoh-contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola putus‑putus, opsi kepala panah, dan warna isi.

## **Buat Garis Biasa**
Untuk menambahkan garis biasa sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class.
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Line menggunakan metode [AddAutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishapecollection/methods/addautoshape/index) yang disediakan oleh objek Shapes.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan garis ke slide pertama presentasi.

```c#
    // Membuat instance kelas PresentationEx yang mewakili file PPTX
    using (Presentation pres = new Presentation())
    {
        // Dapatkan slide pertama
        ISlide sld = pres.Slides[0];

        // Tambahkan autoshape tipe line
        sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Tulis PPTX ke Disk
        pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
    }
```

## **Buat Garis Berbentuk Panah**
Aspose.Slides untuk .NET juga memungkinkan pengembang mengonfigurasi beberapa properti garis agar terlihat lebih menarik. Mari coba mengonfigurasi beberapa properti garis agar tampak seperti panah. Ikuti langkah‑langkah berikut:

- Buat instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/id/aspose.slides/)[](http://www.aspose.com/api/net/slides/id/aspose.slides/).
- Dapatkan referensi slide dengan menggunakan Index‑nya.
- Tambahkan AutoShape tipe Line menggunakan metode AddAutoShape yang disediakan oleh objek Shapes.
- Atur Line Style ke salah satu gaya yang disediakan oleh Aspose.Slides untuk .NET.
- Atur Width garis.
- Atur [Dash Style](https://reference.aspose.com/slides/id/net/aspose.slides/linedashstyle) garis ke salah satu gaya yang disediakan oleh Aspose.Slides untuk .NET.
- Atur [Arrow Head Style](https://reference.aspose.com/slides/id/net/aspose.slides/linearrowheadstyle) dan Length titik awal garis.
- Atur Arrow Head Style dan Length titik akhir garis.
- Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

```c#
    // Buat instance kelas PresentationEx yang mewakili file PPTX
    using (Presentation pres = new Presentation())
    {

        // Dapatkan slide pertama
        ISlide sld = pres.Slides[0];

        // Tambahkan autoshape tipe line
        IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Terapkan beberapa format pada garis
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

**Apakah saya dapat mengonversi garis biasa menjadi konektor sehingga dapat "menempel" pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/) tipe [Line](https://reference.aspose.com/slides/id/net/aspose.slides/shapetype/)) tidak secara otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/net/aspose.slides/connector/) khusus dan [API yang sesuai](/slides/id/net/connector/) untuk koneksi.

**Apa yang harus saya lakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhir?**

[Baca properti efektif](/slides/id/net/shape-effective-properties/) melalui antarmuka [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/net/aspose.slides/ilinefillformateffectivedata/) — antarmuka ini sudah memperhitungkan pewarisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukurannya)?**

Ya. Shapes menyediakan [lock objects](https://reference.aspose.com/slides/id/net/aspose.slides/autoshape/autoshapelock/) yang memungkinkan Anda [melarang operasi pengeditan](/slides/id/net/applying-protection-to-presentation/).