---
title: Buat Bentuk Garis dalam Presentasi dengan Python
linktitle: Garis
type: docs
weight: 50
url: /id/python-net/line/
keywords:
- garis
- buat garis
- tambahkan garis
- garis polos
- konfigurasi garis
- kustomisasi garis
- gaya putus-putus
- kepala panah
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Temukan properti, metode, dan contoh."
---
## **Gambaran Umum**

Aspose.Slides untuk Python via .NET mendukung penambahan berbagai jenis bentuk ke slide. Dalam topik ini, kita akan mulai bekerja dengan bentuk dengan menambahkan garis ke slide. Menggunakan Aspose.Slides, pengembang tidak hanya dapat membuat garis sederhana, tetapi beberapa garis bergaya juga dapat digambar di slide.

## **Buat Garis Polos**

Gunakan Aspose.Slides untuk menambahkan garis polos ke slide sebagai pemisah sederhana atau penghubung. Untuk menambahkan garis polos ke slide yang dipilih dalam presentasi, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi ke slide berdasarkan indeks.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan tipe `LINE` menggunakan metode `add_auto_shape` pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) .
4. Simpan presentasi sebagai file PPTX.

Pada contoh di bawah ini, sebuah garis ditambahkan ke slide pertama presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape dengan tipe LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Buat Garis Berbentuk Panah**

Aspose.Slides memungkinkan Anda mengonfigurasi properti garis agar tampak lebih menarik secara visual. Di bawah ini, kami mengonfigurasi beberapa properti sebuah garis agar terlihat seperti panah. Ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
2. Dapatkan referensi ke sebuah slide berdasarkan indeks.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan tipe `LINE` menggunakan metode `add_auto_shape` pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/) .
4. Atur [gaya garis](https://reference.aspose.com/slides/id/python-net/aspose.slides/linestyle/) .
5. Atur lebar garis.
6. Atur [gaya putus-putus](https://reference.aspose.com/slides/id/python-net/aspose.slides/linedashstyle/) garis.
7. Atur [gaya kepala panah](https://reference.aspose.com/slides/id/python-net/aspose.slides/linearrowheadstyle/) dan panjang untuk titik awal garis.
8. Atur gaya kepala panah dan panjang untuk titik akhir garis.
9. Simpan presentasi sebagai file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file PPTX.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape dengan tipe LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Terapkan pemformatan pada garis.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Simpan presentasi sebagai file PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat mengubah garis biasa menjadi konektor sehingga ia "menempel" pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dengan tipe [LINE](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapetype/)) tidak otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/python-net/aspose.slides/connector/) khusus dan [API terkait](/slides/id/python-net/connector/) untuk sambungan.

**Apa yang harus saya lakukan jika properti garis diwarisi dari tema dan sulit menentukan nilai akhir?**

[Baca properti efektif](/slides/id/python-net/shape-effective-properties/) melalui kelas [ILineFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/id/python-net/aspose.slides/ilinefillformateffectivedata/) , yang sudah memperhitungkan pewarisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat disunting (dipindahkan, diubah ukurannya)?**

Ya. Bentuk menyediakan [objek kunci](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/auto_shape_lock/) yang memungkinkan Anda [menolak operasi penyuntingan](/slides/id/python-net/applying-protection-to-presentation/).