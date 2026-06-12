---
title: Menambahkan Elips ke Presentasi dalam Python
linktitle: Elips
type: docs
weight: 30
url: /id/python-net/ellipse/
keywords:
- elips
- bentuk
- menambahkan elips
- buat elips
- gambar elips
- elips terformat
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides for Python via .NET pada presentasi PPT, PPTX, dan ODP—contoh kode disertakan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint dengan menggunakan Aspose.Slides. Ini mencakup pembuatan elips sederhana, pembuatan elips dengan format, dan menyimpan presentasi yang telah diperbarui sebagai file PPTX. Juga menyentuh pertanyaan terkait seperti mengelola posisi dan ukuran elips, mengontrol urutan tumpukan, dan menerapkan efek animasi.

## **Buat Elips**
Dalam topik ini, kami akan memperkenalkan kepada pengembang cara menambahkan bentuk elips ke slide mereka menggunakan Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET menyediakan sekumpulan API yang lebih mudah untuk menggambar berbagai jenis bentuk dengan hanya beberapa baris kode. Untuk menambahkan elips sederhana ke slide yang dipilih dalam presentasi, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/)
1. Dapatkan referensi slide dengan menggunakan Index-nya
1. Tambahkan AutoShape tipe Ellipse menggunakan metode AddAutoShape yang disediakan oleh objek IShapes
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX

Dalam contoh di bawah ini, kami telah menambahkan elips ke slide pertama.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili PPTX
with slides.Presentation() as pres:
    # Dapatkan slide pertama
    sld = pres.slides[0]

    # Tambahkan autoshape tipe elips
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Tulis file PPTX ke disk
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Buat Elips Terformat**
Untuk menambahkan elips yang lebih terformat ke slide, ikuti langkah-langkah di bawah ini:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/)
1. Dapatkan referensi slide dengan menggunakan Index-nya
1. Tambahkan AutoShape tipe Ellipse menggunakan metode AddAutoShape yang disediakan oleh objek IShapes
1. Atur Fill Type elips menjadi Solid
1. Atur Color elips menggunakan properti SolidFillColor.Color yang disediakan oleh objek FillFormat yang terkait dengan objek IShape
1. Atur Color garis elips
1. Atur Width garis elips
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX

Dalam contoh di bawah ini, kami telah menambahkan elips terformat ke slide pertama presentasi.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili PPTX
with slides.Presentation() as pres:
    # Dapatkan slide pertama
    sld = pres.slides[0]

    # Tambahkan autoshape tipe elips
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Terapkan beberapa format pada bentuk elips
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Terapkan beberapa format pada garis Elips
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Tulis file PPTX ke disk
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bagaimana cara menetapkan posisi dan ukuran tepat elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, dasar perhitungan Anda pada ukuran slide dan konversikan milimeter atau inci yang diperlukan ke poin sebelum menetapkan nilai.

**Bagaimana cara menempatkan elips di atas atau di bawah objek lain (mengontrol urutan tumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Ini memungkinkan elips menutupi objek lain atau memperlihatkan yang berada di bawahnya.

**Bagaimana cara saya menganimasi tampilan atau penekanan elips?**

[Apply](/slides/id/python-net/shape-animation/) efek masuk, penekanan, atau keluar pada bentuk, dan konfigurasikan pemicu serta pengatur waktu untuk mengatur kapan dan bagaimana animasi diputar.