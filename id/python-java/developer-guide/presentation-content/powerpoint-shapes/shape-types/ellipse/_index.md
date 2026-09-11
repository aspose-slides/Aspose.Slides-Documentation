---
title: Menambahkan Elips ke Presentasi dalam Python via Java
linktitle: Elips
type: docs
weight: 30
url: /id/python-java/ellipse/
keywords:
- elips
- bentuk
- tambahkan elips
- buat elips
- gambar elips
- elips terformat
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat, memformat, dan memanipulasi bentuk elips di Aspose.Slides untuk Python via Java pada presentasi PPT dan PPTX—termasuk contoh kode Python."
---
## **Ikhtisar**

Artikel ini menunjukkan cara menambahkan bentuk elips ke slide PowerPoint dengan menggunakan Aspose.Slides. Itu mencakup pembuatan elips sederhana, pembuatan elips yang diformat, dan menyimpan presentasi yang diperbarui sebagai file PPTX. Juga menyentuh pertanyaan terkait seperti bekerja dengan posisi dan ukuran elips, mengontrol urutan tumpukan, dan menerapkan efek animasi.

## **Buat Ellipse**

Untuk menambahkan elips sederhana ke slide yang dipilih dari presentasi, ikuti langkah-langkah berikut:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Tambahkan elips menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) dari objek [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/).
- Tulis presentasi yang dimodifikasi sebagai file PPTX.

Contoh berikut menambahkan elips ke slide pertama:

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

    # Tambahkan bentuk elips.
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Tulis file PPTX ke disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Buat Ellipse yang Diformat**

Untuk menambahkan elips yang diformat ke slide, ikuti langkah-langkah berikut:

- Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
- Dapatkan referensi ke slide berdasarkan indeksnya.
- Tambahkan elips menggunakan metode [addAutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/#addAutoShape) dari objek [ShapeCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapecollection/).
- Atur jenis isi elips menjadi solid.
- Atur warna isi elips melalui [getSolidFillColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/fillformat/#getSolidFillColor) pada objek [FillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/fillformat/) yang terkait dengan objek [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/).
- Atur warna garis tepi elips.
- Atur lebar garis tepi elips.
- Tulis presentasi yang dimodifikasi sebagai file PPTX.

Contoh berikut menambahkan elips yang diformat ke slide pertama presentasi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetColor, SaveFormat, ShapeType
from java.awt import Color

# Instansiasi kelas Presentation yang mewakili file PPTX.
presentation = Presentation()
try:
    # Dapatkan slide pertama.
    slide = presentation.getSlides().get_Item(0)

    # Tambahkan bentuk elips.
    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50)

    # Format isi elips.
    ellipse.getFillFormat().setFillType(FillType.Solid)
    ellipse.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Chocolate)

    # Format garis tepi elips.
    ellipse.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    ellipse.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    ellipse.getLineFormat().setWidth(5)

    # Tulis file PPTX ke disk.
    presentation.save("EllipseShp1.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Bagaimana cara mengatur posisi dan ukuran tepat elips relatif terhadap satuan slide?**

Koordinat dan ukuran biasanya ditentukan **dalam poin**. Untuk hasil yang dapat diprediksi, dasar perhitungan Anda pada ukuran slide dan ubah milimeter atau inci yang diperlukan menjadi poin sebelum menetapkan nilai.

**Bagaimana saya dapat menempatkan elips di atas atau di bawah objek lain (mengontrol urutan tumpukan)?**

Sesuaikan urutan gambar objek dengan membawanya ke depan atau mengirimnya ke belakang. Ini memungkinkan elips menutupi objek lain atau menampilkan yang berada di bawahnya.

**Bagaimana cara menganimasikan munculnya atau penekanan elips?**

[Terapkan](/slides/id/python-java/shape-animation/) efek masuk, penekanan, atau keluar pada bentuk, dan konfigurasikan pemicu serta waktu untuk mengatur kapan dan bagaimana animasi diputar.