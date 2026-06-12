---
title: Menambahkan Persegi Panjang ke Presentasi di .NET
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/net/rectangle/
keywords:
- tambahkan persegi panjang
- buat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang terformat
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk .NET—dengan mudah merancang dan memodifikasi bentuk secara programatik."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang dengan format, dan penyimpanan presentasi yang diperbarui sebagai file PPTX.

Anda juga akan melihat cara menerapkan format dasar persegi panjang, seperti warna isi padat, warna garis, dan lebar garis. Selain itu, bagian FAQ artikel ini mengarahkan ke tugas-tugas terkait persegi panjang, termasuk sudut melengkung, isi gambar, efek visual, tautan hiperteks, penguncian bentuk, opsi ekspor, dan properti efektif.

## **Buat Persegi Panjang Sederhana**
Seperti topik sebelumnya, ini juga tentang menambahkan bentuk dan kali ini bentuk yang akan dibahas adalah Persegi Panjang. Dalam topik ini, kami menjelaskan bagaimana pengembang dapat menambahkan persegi panjang sederhana atau terformat ke slide mereka menggunakan Aspose.Slides untuk .NET. Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Tambahkan IAutoShape bertipe Rectangle menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami menambahkan persegi panjang sederhana ke slide pertama presentasi.

```c#
// Instansiasi kelas Presentation yang mewakili file PPTX
using (Presentation pres = new Presentation())
{

    // Dapatkan slide pertama
    ISlide sld = pres.Slides[0];

    // Tambahkan autoshape tipe persegi panjang
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Tuliskan file PPTX ke disk
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Buat Persegi Panjang Terformat**
Untuk menambahkan persegi panjang terformat ke slide, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentasi](https://reference.aspose.com/slides/id/net/aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan Indeksnya.
1. Tambahkan IAutoShape bertipe Rectangle menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Atur Fill Type persegi panjang menjadi Solid.
1. Atur Warna persegi panjang menggunakan properti SolidFillColor.Color yang disediakan oleh objek FillFormat yang terkait dengan objek IShape.
1. Atur Warna garis persegi panjang.
1. Atur Lebar garis persegi panjang.
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.
   Langkah‑langkah di atas diimplementasikan dalam contoh berikut.

```c#
 // Instansiasi kelas Presentation yang mewakili file PPTX
 using (Presentation pres = new Presentation())
 {

     // Dapatkan slide pertama
     ISlide sld = pres.Slides[0];

     // Tambahkan autoshape tipe persegi panjang
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

     // Terapkan beberapa format pada bentuk persegi panjang
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

     // Terapkan beberapa format pada garis persegi panjang
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;

     //Tuliskan file PPTX ke disk
     pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [tipe bentuk](https://reference.aspose.com/slides/id/net/aspose.slides/shapetype/) dengan sudut melengkung dan sesuaikan jari‑jari sudut pada properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [tipe isi gambar](https://reference.aspose.com/slides/id/net/aspose.slides/filltype/), sediakan sumber gambar, dan konfigurasikan [mode peregangan/pengulangan](https://reference.aspose.com/slides/id/net/aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan cahaya?**

Ya. [Bayangan luar/dalam, cahaya, dan tepi lembut](/slides/id/net/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Apakah saya dapat mengubah persegi panjang menjadi tombol dengan tautan?**

Ya. [Tetapkan tautan hiperteks](/slides/id/net/manage-hyperlinks/) pada klik bentuk (melompat ke slide, file, alamat web, atau email).

**Bagaimana cara melindungi persegi panjang agar tidak dipindahkan atau diubah?**

[Gunakan penguncian bentuk](/slides/id/net/applying-protection-to-presentation/): Anda dapat melarang pemindahan, pengubahan ukuran, pemilihan, atau penyuntingan teks untuk menjaga tata letak.

**Apakah saya dapat mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [menghasilkan gambar bentuk](http://reference.aspose.com/slides/id/net/aspose.slides/shape/getimage/) dengan ukuran/skalanya yang ditentukan atau [mengekspornya sebagai SVG](https://reference.aspose.com/slides/id/net/aspose.slides/shape/writeassvg/) untuk penggunaan vektor.

**Bagaimana cara cepat memperoleh properti aktual (efektif) persegi panjang dengan mempertimbangkan tema dan pewarisan?**

[Gunakan properti efektif bentuk](/slides/id/net/shape-effective-properties/): API mengembalikan nilai yang dihitung yang memperhitungkan gaya tema, tata letak, dan pengaturan lokal, mempermudah analisis format.