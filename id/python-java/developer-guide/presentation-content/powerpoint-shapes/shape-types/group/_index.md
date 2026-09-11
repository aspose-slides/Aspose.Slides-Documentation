---
title: Bentuk Grup Presentasi dalam Python via Java
linktitle: Grup Bentuk
type: docs
weight: 40
url: /id/python-java/group/
keywords:
- bentuk grup
- grup bentuk
- tambahkan grup
- teks alternatif
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelompokkan dan memisahkan bentuk dalam dek PowerPoint menggunakan Aspose.Slides untuk Python via Java - panduan langkah demi langkah dengan kode Python gratis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan bentuk grup di Aspose.Slides. Artikel ini menunjukkan cara menambahkan bentuk grup ke slide, menempatkan bentuk di dalamnya, dan menyimpan presentasi yang telah diperbarui. Artikel ini juga mendemonstrasikan cara mengakses bentuk yang disimpan di dalam grup dan membaca teks alternatifnya menggunakan [getAlternativeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText). Selain itu, artikel ini secara singkat membahas kemampuan bentuk grup terkait seperti grup bersarang, urutan‑z, dan opsi penguncian.

## **Tambah Bentuk Grup**

Aspose.Slides mendukung bekerja dengan bentuk grup pada slide. Fitur ini membantu pengembang membuat presentasi yang lebih kaya. Aspose.Slides for Python via Java mendukung penambahan dan pengaksesan bentuk grup. Anda dapat mengisi sebuah bentuk grup dengan bentuk‑bentuk atau mengakses propertinya. Untuk menambahkan bentuk grup ke slide menggunakan Aspose.Slides for Python via Java:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan bentuk grup ke slide.
4. Tambahkan bentuk ke dalam bentuk grup.
5. Simpan presentasi yang dimodifikasi sebagai file PPTX.

Contoh di bawah menambahkan sebuah bentuk grup ke slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Instansiasi kelas Presentation.
presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Akses koleksi bentuk slide.
    slide_shapes = slide.getShapes()

    # Tambahkan bentuk grup ke slide.
    group_shape = slide_shapes.addGroupShape()

    # Tambahkan bentuk di dalam grup bentuk.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Atur bingkai grup bentuk.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Tulis file PPTX ke disk.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Akses Teks Alternatif**

Bagian ini menunjukkan cara mengakses teks alternatif dari bentuk‑bentuk di dalam grup pada slide. Untuk mengakses teks ini menggunakan Aspose.Slides for Python via Java:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang mewakili file PPTX.
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Akses koleksi bentuk slide.
4. Akses bentuk grup.
5. Baca teks alternatif bentuk‑bentuknya menggunakan [getAlternativeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getAlternativeText).

Contoh di bawah mengakses teks alternatif dari bentuk‑bentuk di dalam grup:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Instansiasi kelas Presentation yang mewakili file PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Akses sebuah bentuk dalam koleksi bentuk slide.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Akses bentuk-bentuk di dalam grup.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Baca teks alternatif.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah pengelompokan bersarang (sebuah grup di dalam grup) didukung?**

Ya. [GroupShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/) memiliki metode [getParentGroup](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getParentGroup) yang menunjukkan dukungan hierarki: sebuah grup dapat menjadi anak dari grup lain.

**Bagaimana cara mengontrol urutan‑z grup relatif terhadap objek lain pada slide?**

Gunakan metode [getZOrderPosition](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getZOrderPosition) pada objek [GroupShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/) untuk memeriksa posisinya dalam tumpukan tampilan.

**Bisakah saya mencegah pemindahan, penyuntingan, atau pembongkaran grup?**

Ya. Kunci grup dapat diakses melalui [getGroupShapeLock](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/#getGroupShapeLock), yang memungkinkan Anda membatasi operasi pada objek tersebut.