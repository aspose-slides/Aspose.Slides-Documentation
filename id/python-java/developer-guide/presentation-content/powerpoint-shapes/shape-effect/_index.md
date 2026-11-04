---
title: Menerapkan Efek Bentuk dalam Presentasi Menggunakan Python via Java
linktitle: Efek Bentuk
type: docs
weight: 30
url: /id/python-java/shape-effect/
keywords:
- efek bentuk
- efek bayangan
- efek refleksi
- efek cahaya
- efek tepi lembut
- format efek
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk Python via Java—ciptakan slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, mereka berbeda dari [isi](/slides/id/python-java/shape-formatting/#gradient-fill) atau garis tepi. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek Bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint menyediakan pilihan di bawah **Preset**. Opsi Preset adalah kombinasi dari dua atau lebih efek yang diketahui terlihat bagus. Dengan cara ini, dengan memilih sebuah preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Menerapkan Efek Bayangan**

Aspose.Slides untuk Python via Java mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur mereka agar sesuai dengan desain presentasi Anda.

### **Menerapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol di atas latar belakang slide. Bayangan tersebut meluas di luar tepi bentuk, menciptakan kesan bahwa bentuk tersebut terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur‑nya agar cocok dengan pencahayaan dan gaya templat Anda.

Kode Python berikut menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) pada sebuah persegi panjang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efek Bayangan](shadow_effect.png)

### **Menerapkan Bayangan Dalam**

Saat meniru gaya visual sebuah templat, gunakan bayangan dalam untuk memberikan kartu atau panel tampilan teronggok. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sementara bayangan dalam memberikan bayangan pada bagian dalam tepinya.

Panggil [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), lalu konfigurasikan bayangan yang dikembalikan oleh [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih halus.

Contoh Python berikut membuat kartu biru muda dengan bayangan dalam abu‑abu gelap dan menyimpannya sebagai file PPTX. Arah bayangan adalah 225 derajat, jaraknya 7 poin, dan radius blur‑nya 6 poin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Persegi panjang biru muda dengan bayangan dalam](inner_shadow_effect.png)

Untuk menghapus bayangan dalam, panggil [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) pada format efek bentuk.

## **Menerapkan Efek Refleksi**

Untuk menerapkan efek refleksi di Aspose.Slides untuk Python via Java, Anda dapat menambahkan refleksi mirip cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberikan bentuk tampilan yang lebih halus dan canggih. Ini mudah diimplementasikan dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode Python berikut menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) pada sebuah bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efek Refleksi](reflection_effect.png)

## **Menerapkan Efek Cahaya**

Untuk menerapkan efek cahaya pada sebuah bentuk di Aspose.Slides untuk Python via Java, Anda dapat menambahkan aura lembut dan bercahaya di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu membuat bentuk menonjol dan menambah elemen visual yang menarik dan mencolok pada presentasi Anda. Ini mudah diimplementasikan dengan kode minimal, meningkatkan tampilan keseluruhan slide Anda.

Kode Python berikut menunjukkan cara menerapkan [efek cahaya](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) pada sebuah bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efek Cahaya](glow_effect.png)

## **Menerapkan Efek Tepi Halus**

Untuk menerapkan efek tepi halus di Aspose.Slides untuk Python via Java, Anda dapat membuat transisi halus dan kabur di sekitar tepi sebuah bentuk. Efek ini menambahkan tampilan yang lebih halus dan halus, sempurna untuk desain yang membutuhkan penampilan lembut dan lebih lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi Anda.

Kode Python berikut menunjukkan cara menerapkan [efek tepi lembut](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) pada sebuah bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Efek Tepi Lembut](soft_edges_effect.png)

## **Menerapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isi dan garis tepi bentuk sekaligus tetap dapat diedit. Panggil [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai nonnegatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah penampilan.

Pengaturan [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) mengontrol batas tampak dari efek. Dengan `False`, blur dipotong pada batas asli yang digambar, termasuk garis tepi. Dengan `True`, blur dapat melampaui batas tersebut. Kedua pengaturan tidak mengubah posisi atau dimensi bentuk.

Perbandingan di bawah menggunakan isi, garis tepi, dan dimensi bentuk yang sama sepanjang. Baris atas menggunakan `grow = False`; baris bawah menggunakan `grow = True`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh Python berikut membuat persegi panjang oranye dengan garis tepi biru tua, menerapkan blur 5 poin, lalu memperbaruinya menjadi blur 15 poin dengan memanggil [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) lagi. Ia menyimpan kedua kondisi blur, kemudian memanggil [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) dan menyimpan bentuk tanpa blur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Blur bentuk memengaruhi isi dan garis tepi sekaligus. Efek tepi halus memudarkan tepi bentuk, sementara blur bayangan melunakkan hanya bayangan. Efek transformasi gambar beroperasi pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan cahaya, pada satu bentuk untuk menciptakan penampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, diagram, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.