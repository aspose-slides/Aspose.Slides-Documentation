---
title: Menambahkan Elips ke Presentasi di .NET
linktitle: Elips
type: docs
weight: 30
url: /id/net/ellipse/
keywords:
- elips
- bentuk
- menambahkan elips
- membuat elips
- menggambar elips
- elips terformat
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides untuk .NET dalam presentasi PPT dan PPTX—termasuk contoh kode C#."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint menggunakan Aspose.Slides. Ini mencakup pembuatan elips sederhana, pembuatan elips yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX. Juga menyentuh pertanyaan terkait seperti bekerja dengan posisi dan ukuran elips, mengontrol urutan tumpukan, dan menerapkan efek animasi.

## **Buat Elips**
Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

1. Buat instance dari [Presentasi ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class
1. Dapatkan referensi slide dengan menggunakan Index‑nya
1. Tambahkan AutoShape bertipe Ellipse menggunakan metode AddAutoShape yang disediakan oleh objek IShapes
1. Tulis presentasi yang dimodifikasi sebagai file PPTX

Dalam contoh di bawah ini, kami telah menambahkan elips ke slide pertama.

```c#
// Instansiasi kelas Presentation yang mewakili PPTX
using (Presentation pres = new Presentation())
{

    // Dapatkan slide pertama
    ISlide sld = pres.Slides[0];

    // Tambahkan autoshape tipe elips
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Tulis file PPTX ke disk
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Buat Elips yang Diformat**
Untuk menambahkan elips yang diformat dengan lebih baik ke slide, ikuti langkah‑langkah berikut:

1. Buat instance dari [Presentasi ](https://reference.aspose.com/slides/id/net/aspose.slides/presentation)class.
1. Dapatkan referensi slide dengan menggunakan Index‑nya.
1. Tambahkan AutoShape bertipe Ellipse menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Atur Fill Type elips menjadi Solid.
1. Atur Warna elips menggunakan properti SolidFillColor.Color yang diakses melalui objek FillFormat yang terkait dengan objek IShape.
1. Atur Warna garis elips.
1. Atur Lebar garis elips.
1. Tulis presentasi yang dimodifikasi sebagai file PPTX.

Dalam contoh di bawah ini, kami telah menambahkan elips yang diformat ke slide pertama presentasi.

```c#
    // Instansiasi kelas Presentation yang mewakili PPTX
    using (Presentation pres = new Presentation())
    {

        // Dapatkan slide pertama
        ISlide sld = pres.Slides[0];

        // Tambahkan autoshape tipe elips
        IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

        // Terapkan beberapa pemformatan pada bentuk elips
        shp.FillFormat.FillType = FillType.Solid;
        shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

        // Terapkan beberapa pemformatan pada garis Elips
        shp.LineFormat.FillFormat.FillType = FillType.Solid;
        shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
        shp.LineFormat.Width = 5;

        //Write file PPTX ke disk
        pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
    }
```

## **FAQ**

**Bagaimana cara mengatur posisi dan ukuran tepat elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, dasar perhitungan Anda pada ukuran slide dan konversi milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilai.

**Bagaimana saya dapat menempatkan elips di atas atau di bawah objek lain (mengontrol urutan tumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Ini memungkinkan elips menumpuk objek lain atau mengungkapkan yang berada di bawahnya.

**Bagaimana cara saya memberi animasi pada penampilan atau penekanan elips?**

[Apply](/slides/id/net/shape-animation/) efek masuk, penekanan, atau keluar ke bentuk, dan konfigurasikan pemicu serta waktu untuk mengatur kapan dan bagaimana animasi diputar.