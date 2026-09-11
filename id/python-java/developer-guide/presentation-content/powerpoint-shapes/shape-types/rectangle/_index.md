---
title: Menambahkan Persegi Panjang ke Presentasi di Python via Java
linktitle: Persegi Panjang
type: docs
weight: 80
url: /id/python-java/rectangle/
keywords:
- menambahkan persegi panjang
- membuat persegi panjang
- bentuk persegi panjang
- persegi panjang sederhana
- persegi panjang terformat
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Tingkatkan presentasi PowerPoint Anda dengan menambahkan persegi panjang menggunakan Aspose.Slides untuk Python via Java—desain dan modifikasi bentuk secara programatis dengan mudah."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk persegi panjang ke slide PowerPoint dengan menggunakan Aspose.Slides. Artikel ini mencakup pembuatan persegi panjang sederhana, pembuatan persegi panjang yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX.

Anda juga akan melihat cara menerapkan pemformatan dasar persegi panjang, seperti warna isi padat, warna garis, dan lebar garis. Selain itu, FAQ artikel ini mengarahkan ke tugas‑tugas terkait persegi panjang, termasuk sudut melengkung, isi gambar, efek visual, tautan hiper, penguncian bentuk, opsi ekspor, dan properti efektif.

## **Menambahkan Persegi Panjang ke Slide**

Untuk menambahkan persegi panjang sederhana ke slide yang dipilih dalam presentasi, ikuti langkah‑langkah di bawah ini:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) tipe persegi panjang menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) yang tersedia pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) .
- Tulis presentasi yang dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami telah menambahkan persegi panjang sederhana ke slide pertama presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Membuat instance kelas Presentation yang mewakili file PPTX.
presentation = Presentation()
try:
    # Ambil slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk persegi panjang.
    slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Tuliskan file PPTX ke disk.
    presentation.save("RecShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Persegi Panjang yang Diformat ke Slide**

Untuk menambahkan persegi panjang yang diformat ke slide, ikuti langkah‑langkah di bawah ini:

- Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) tipe persegi panjang menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) yang tersedia pada objek [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/) .
- Atur [fill type](https://reference.aspose.com/slides/id/python-java/aspose.slides/filltype/) persegi panjang menjadi solid.
- Atur warna persegi panjang menggunakan metode [setColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/colorformat/#setColor) pada warna isian solid dari objek [FillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/fillformat/) yang terkait dengan objek [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) .
- Atur warna garis tepi persegi panjang.
- Atur lebar garis tepi persegi panjang.
- Tulis presentasi yang dimodifikasi sebagai file PPTX.

Langkah‑langkah di atas diimplementasikan dalam contoh di bawah ini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

# Membuat instance kelas Presentation yang mewakili file PPTX.
presentation = Presentation()
try:
    # Ambil slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk persegi panjang.
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50)

    # Format isian persegi panjang.
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color.GRAY)

    # Format garis tepi persegi panjang.
    rectangle.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    rectangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    rectangle.getLineFormat().setWidth(5)

    # Tuliskan file PPTX ke disk.
    presentation.save("RecShp2.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Bagaimana cara menambahkan persegi panjang dengan sudut melengkung?**

Gunakan [shape type](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapetype/) yang memiliki sudut melengkung dan sesuaikan radius sudut pada properti bentuk; pembulatan juga dapat diterapkan per sudut melalui penyesuaian geometri.

**Bagaimana cara mengisi persegi panjang dengan gambar (tekstur)?**

Pilih [fill type](https://reference.aspose.com/slides/id/python-java/aspose.slides/filltype/) gambar, sediakan sumber gambar, dan konfigurasikan [stretching/tiling modes](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillmode/) .

**Apakah persegi panjang dapat memiliki bayangan dan cahaya kilau?**

Ya. [Outer/inner shadow, glow, and soft edges](/slides/id/python-java/shape-effect/) tersedia dengan parameter yang dapat disesuaikan.

**Bisakah saya mengubah persegi panjang menjadi tombol dengan tautan hiper?**

Ya. [Assign a hyperlink](/slides/id/python-java/manage-hyperlinks/) ke klik bentuk (melompat ke slide, file, alamat web, atau email).

**Bagaimana saya dapat melindungi persegi panjang dari pergerakan dan perubahan?**

[Use shape locks](/slides/id/python-java/applying-protection-to-presentation/): Anda dapat melarang pergerakan, pengubahan ukuran, pemilihan, atau penyuntingan teks untuk mempertahankan tata letak.

**Bisakah saya mengonversi persegi panjang menjadi gambar raster atau SVG?**

Ya. Anda dapat [render the shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) menjadi gambar dengan ukuran/skalanya yang ditentukan atau [export it as SVG](/slides/id/python-java/create-shape-thumbnails/) untuk penggunaan vektor.

**Bagaimana cara cepat mendapatkan properti aktual (efektif) dari persegi panjang dengan mempertimbangkan tema dan pewarisan?**

[Use the shape’s effective properties](/slides/id/python-java/shape-effective-properties/): API mengembalikan nilai yang dihitung yang mempertimbangkan gaya tema, tata letak, dan pengaturan lokal, mempermudah analisis pemformatan.