---
title: Menambahkan Persegi Panjang ke Presentasi di Python
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/python-net/rectangle/
keywords:
- menambahkan persegi panjang
- membuat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang berformat
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint & OpenDocument Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk Python via .NET—desain dan modifikasi bentuk secara programatis dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang berformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX.

Anda juga akan melihat cara menerapkan pemformatan persegi panjang dasar, seperti warna isi padat, warna garis, dan lebar garis. Selain itu, bagian FAQ artikel mengarahkan ke tugas-tugas terkait persegi panjang, termasuk sudut melengkung, isian gambar, efek visual, tautan hiper, penguncian bentuk, opsi ekspor, dan properti efektif.

## **Buat Persegi Panjang Sederhana**
Seperti topik sebelumnya, yang ini juga tentang menambahkan bentuk dan kali ini bentuk yang akan kami bahas adalah Rectangle. Pada topik ini, kami menjelaskan bagaimana pengembang dapat menambahkan persegi panjang sederhana atau berformat ke slide mereka menggunakan Aspose.Slides untuk Python via .NET. Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan IAutoShape tipe Rectangle menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan persegi panjang sederhana ke slide pertama presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili PPTX
with slides.Presentation() as pres:
    # Ambil slide pertama
    sld = pres.slides[0]

    # Tambahkan autoshape tipe persegi panjang
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Tulis file PPTX ke disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Buat Persegi Panjang Berformat**
Untuk menambahkan persegi panjang berformat ke slide, ikuti langkah-langkah di bawah ini:

1. Buat instance dari kelas [Presentation ](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan Index-nya.
1. Tambahkan IAutoShape tipe Rectangle menggunakan metode AddAutoShape yang disediakan oleh objek IShapes.
1. Atur Fill Type persegi panjang menjadi Solid.
1. Atur warna persegi panjang menggunakan properti SolidFillColor.Color yang tersedia melalui objek FillFormat yang terkait dengan objek IShape.
1. Atur warna garis persegi panjang.
1. Atur lebar garis persegi panjang.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.
   Langkah-langkah di atas diimplementasikan dalam contoh di bawah ini.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili PPTX
with slides.Presentation() as pres:
    # Ambil slide pertama
    sld = pres.slides[0]

    # Tambahkan autoshape tipe persegi panjang
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Terapkan beberapa format ke bentuk persegi panjang
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Terapkan beberapa format ke garis persegi panjang
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    # Tulis file PPTX ke disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [shape type](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapetype/) dengan sudut melengkung dan sesuaikan radius sudut di properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [fill type](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/), sediakan sumber gambar, dan konfigurasikan [stretching/tiling modes](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillmode/).

**Apakah persegi panjang dapat memiliki bayangan dan cahaya?**

Ya. [Outer/inner shadow, glow, and soft edges](/slides/id/python-net/shape-effect/) tersedia dengan parameter yang dapat diatur.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan hyperlink?**

Ya. [Assign a hyperlink](/slides/id/python-net/manage-hyperlinks/) pada klik bentuk (lompat ke slide, file, alamat web, atau email).

**Bagaimana cara melindungi persegi panjang dari pergerakan dan perubahan?**

[Use shape locks](/slides/id/python-net/applying-protection-to-presentation/): Anda dapat melarang pergerakan, mengubah ukuran, pemilihan, atau penyuntingan teks untuk menjaga tata letak.

**Bisakah saya mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [render the shape](http://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/) ke gambar dengan ukuran/skalanya yang ditentukan atau [export it as SVG](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti sebenarnya (effective) dari persegi panjang dengan mempertimbangkan tema dan pewarisan?**

[Use the shape’s effective properties](/slides/id/python-net/shape-effective-properties/): API mengembalikan nilai yang dihitung yang memperhitungkan gaya tema, tata letak, dan pengaturan lokal, mempermudah analisis pemformatan.