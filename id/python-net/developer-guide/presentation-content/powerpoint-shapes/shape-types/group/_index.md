---
title: Bentuk Presentasi Grup dengan Python
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/python-net/group/
keywords:
- bentuk grup
- grup bentuk
- tambahkan grup
- teks alternatif
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan bentuk di deck PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python—panduan cepat langkah demi langkah dengan kode gratis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Artikel ini menunjukkan cara menambahkan bentuk grup ke sebuah slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang diperbarui. Artikel ini juga mendemonstrasikan cara mengakses bentuk yang disimpan di dalam grup dan membaca nilai `alternative_text`‑nya. Selain itu, artikel ini secara singkat membahas kemampuan terkait bentuk grup seperti grup bersarang, z-order, dan opsi penguncian.

## **Menambahkan Bentuk Grup**

Aspose.Slides mendukung kerja dengan bentuk grup pada slide. Fitur ini memungkinkan Anda membuat presentasi yang lebih kaya dengan memperlakukan beberapa bentuk sebagai satu objek. Anda dapat menambahkan bentuk grup baru, mengakses yang sudah ada, mengisinya dengan bentuk anak, dan membaca atau memodifikasi properti apa pun. Untuk menambahkan bentuk grup ke slide:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeks.
3. Tambahkan [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/) ke slide.
4. Tambahkan bentuk ke grup shape baru.
5. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Contoh di bawah ini menunjukkan cara menambahkan bentuk grup ke slide.

```py
import aspose.slides as slides

# Buat instance kelas Presentation.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan grup shape ke slide.
    group_shape = slide.shapes.add_group_shape()

    # Tambahkan bentuk di dalam grup shape.
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 300, 100, 100)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 300, 100, 100)

    # Simpan file PPTX ke disk.
    presentation.save("group_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Properti Alt Text**

Bagian ini menjelaskan cara membaca Alt Text dari bentuk yang terdapat dalam sebuah grup shape pada slide menggunakan Aspose.Slides. Untuk mengakses Alt Text dari bentuk-bentuk tersebut:

1. Instansiasikan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk merepresentasikan file PPTX.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses koleksi bentuk slide.
4. Akses [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/).
5. Baca properti Alt Text.

Contoh di bawah ini mengambil Alt Text dari bentuk yang terdapat dalam grup shape.

```py
import aspose.slides as slides

# Buat instance kelas Presentation untuk membuka file PPTX.
with slides.Presentation("group_shape.pptx") as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.GroupShape):
            # Akses grup shape.
            for child_shape in shape.shapes:
                # Akses properti Alt Text.
                print(child_shape.alternative_text)
```

## **FAQ**

**Apakah pengelompokan bersarang (sebuah grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/) memiliki properti [parent_group](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/parent_group/), yang secara langsung menunjukkan dukungan hierarki (sebuah grup dapat menjadi anak dari grup lain).

**Bagaimana cara mengontrol z-order grup relatif terhadap objek lain pada slide?**

Gunakan properti [z_order_position](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/z_order_position/) milik [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Apakah saya dapat mencegah pemindahan/pengeditan/pembongkaran?**

Ya. Bagian kunci grup dapat diakses melalui [group_shape_lock](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/group_shape_lock/), yang memungkinkan Anda membatasi operasi pada objek tersebut.