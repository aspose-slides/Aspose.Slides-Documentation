---
title: Tambahkan Bentuk Garis ke Presentasi dalam Python via Java
linktitle: Garis
type: docs
weight: 50
url: /id/python-java/line/
keywords:
- garis
- buat garis
- tambahkan garis
- garis sederhana
- konfigurasi garis
- sesuaikan garis
- gaya dash
- kepala panah
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memanipulasi format garis dalam presentasi PowerPoint dengan Aspose.Slides untuk Python via Java. Temukan properti, metode, dan contoh."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menambahkan bentuk garis ke slide PowerPoint secara programatis. Artikel ini menunjukkan cara membuat garis sederhana dan cara menyesuaikan garis sehingga muncul sebagai panah.

Anda akan belajar cara menambahkan bentuk garis ke slide, menyesuaikan tampilan visualnya, dan menyimpan presentasi yang telah diperbarui. Contoh berfokus pada pengaturan format garis praktis seperti gaya, lebar, pola dash, opsi kepala panah, dan warna isi.

## **Buat Garis Sederhana**

Untuk menambahkan garis sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah berikut:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Tambahkan bentuk garis menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) dari objek [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/).
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

Contoh berikut menambahkan garis ke slide pertama presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Instansiasi kelas Presentation yang mewakili file PPTX.
presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk garis.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Tuliskan file PPTX ke disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Buat Garis Berbentuk Panah**

Aspose.Slides untuk Python via Java juga memungkinkan pengembang mengonfigurasi properti garis agar tampak lebih menarik. Untuk mengonfigurasi garis agar terlihat seperti panah, ikuti langkah‑langkah berikut:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Tambahkan bentuk garis menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) dari objek [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/).
- Atur [line style](https://reference.aspose.com/slides/id/python-java/aspose.slides/linestyle/) ke salah satu gaya yang ditawarkan oleh Aspose.Slides untuk Python via Java.
- Atur lebar garis.
- Atur [dash style](https://reference.aspose.com/slides/id/python-java/aspose.slides/linedashstyle/) ke salah satu gaya yang ditawarkan oleh Aspose.Slides untuk Python via Java.
- Atur [arrowhead style](https://reference.aspose.com/slides/id/python-java/aspose.slides/linearrowheadstyle/) dan [length](https://reference.aspose.com/slides/id/python-java/aspose.slides/linearrowheadlength/) di awal garis.
- Atur [arrowhead style](https://reference.aspose.com/slides/id/python-java/aspose.slides/linearrowheadstyle/) dan [length](https://reference.aspose.com/slides/id/python-java/aspose.slides/linearrowheadlength/) di akhir garis.
- Tuliskan presentasi yang dimodifikasi sebagai file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Instansiasi kelas Presentation yang mewakili file PPTX.
presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk garis.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Terapkan pemformatan pada garis.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Tulis file PPTX ke disk.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tanya Jawab**

**Apakah saya dapat mengonversi garis biasa menjadi konektor sehingga ia “menempel” pada bentuk?**

Tidak. Garis biasa (sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) berjenis [Line](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/)) tidak otomatis menjadi konektor. Untuk membuatnya menempel pada bentuk, gunakan tipe [Connector](https://reference.aspose.com/slides/id/python-java/aspose.slides/connector/) khusus dan [corresponding APIs](/slides/id/python-java/connector/) untuk sambungan.

**Apa yang harus saya lakukan jika properti garis diwariskan dari tema dan sulit menentukan nilai akhir?**

Baca [Read the effective properties](/slides/id/python-java/shape-effective-properties/) garis dan isinya—ini sudah mempertimbangkan pewarisan dan gaya tema.

**Apakah saya dapat mengunci garis agar tidak dapat diedit (dipindahkan, diubah ukuran)?**

Ya. Bentuk menyediakan [lock objects] yang memungkinkan Anda [disallow editing operations](/slides/id/python-java/applying-protection-to-presentation/).