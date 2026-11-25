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
- efek pinggiran lembut
- format efek
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Ubah file PPT dan PPTX Anda dengan efek bentuk lanjutan menggunakan Aspose.Slides untuk Python via Java—buat slide yang menarik dan profesional dalam hitungan detik."
---
## **Pendahuluan**

Sementara efek di PowerPoint dapat digunakan untuk menonjolkan sebuah bentuk, mereka berbeda dari [isi](/slides/id/python-java/shape-formatting/#gradient-fill) atau garis tepi. Dengan menggunakan efek PowerPoint, Anda dapat membuat refleksi yang meyakinkan pada sebuah bentuk, menyebarkan cahaya pada bentuk, dll.

![Efek bentuk](shape-effect.png)

PowerPoint menyediakan enam efek yang dapat diterapkan pada bentuk. Anda dapat menerapkan satu atau lebih efek pada sebuah bentuk.

Beberapa kombinasi efek terlihat lebih baik daripada yang lain. Karena itu, PowerPoint menyediakan opsi di bawah **Preset**. Opsi Preset adalah kombinasi dua atau lebih efek yang diketahui terlihat bagus. Dengan cara ini, dengan memilih preset, Anda tidak perlu membuang waktu menguji atau menggabungkan efek yang berbeda untuk menemukan kombinasi yang bagus.

Aspose.Slides menyediakan properti dan metode di bawah kelas [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) yang memungkinkan Anda menerapkan efek yang sama pada bentuk dalam presentasi PowerPoint.

## **Terapkan Efek Bayangan**

Aspose.Slides untuk Python via Java mendukung bayangan luar dan dalam untuk bentuk. Anda dapat menyesuaikan warna, arah, jarak, dan radius blur mereka agar sesuai dengan desain presentasi Anda.

### **Terapkan Bayangan Luar**

Gunakan bayangan luar untuk membuat kartu atau panel menonjol dari latar belakang slide. Bayangan tersebut meluas melewati tepi bentuk, menciptakan kesan bentuk terangkat di atas slide. Sesuaikan warna, arah, jarak, dan radius blur agar sesuai dengan pencahayaan dan gaya template Anda.

Kode Python ini menunjukkan cara menerapkan [efek bayangan luar](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) pada sebuah persegi panjang:

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

![Efek bayangan](shadow_effect.png)

### **Terapkan Bayangan Dalam**

Saat mereproduksi gaya visual template, gunakan bayangan dalam untuk memberi kartu atau panel tampilan terukir. Bayangan luar meluas di luar bentuk dan membuatnya tampak terangkat, sementara bayangan dalam memberi bayangan pada bagian dalam tepinya.

Panggil [enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect), lalu konfigurasikan bayangan yang dikembalikan oleh [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect). Nilai radius blur yang lebih besar menghasilkan tepi yang lebih lembut.

Contoh Python ini membuat kartu biru muda dengan bayangan dalam abu‑abu gelap dan menyimpannya sebagai file PPTX. Arah bayangan 225 derajat, jaraknya 7 poin, dan radius blur‑nya 6 poin:

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

### **Terapkan, Ubah, dan Hapus Bayangan Preset**

Panggil [enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect), lalu gunakan [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) untuk memilih sebuah [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/). Untuk beralih gaya, ubah preset pada bentuk yang sama. Panggil [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) untuk menghapus bayangan sambil mempertahankan isi dan garis tepinya.

Contoh ini menggandakan persegi panjang pada setiap tahap sehingga Anda dapat membandingkan keempat keadaan berdampingan pada satu slide. Kedua bayangan dioffset sebesar 10 poin. Arah 225° menempatkan bayangan pertama di atas dan ke kiri persegi panjang. Arah 45° menempatkan bayangan kedua di bawah dan ke kanan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Asli | Preset pertama | Preset kedua | Setelah dihapus |
| :---: | :---: | :---: | :---: |
| ![Tanpa bayangan](preset_shadow_original.png) | ![Bayangan Drop Kiri Atas](preset_shadow_top_left.png) | ![Bayangan Drop Kanan Bawah](preset_shadow_bottom_right.png) | ![Tidak ada bayangan setelah dihapus](preset_shadow_removed.png) |

## **Terapkan Efek Refleksi**

Untuk menerapkan efek refleksi dalam Aspose.Slides untuk Python via Java, Anda dapat menambahkan refleksi seperti cermin pada bentuk, menyesuaikan parameter seperti jarak, transparansi, dan ukuran. Efek ini meningkatkan estetika presentasi Anda dengan memberi bentuk tampilan yang lebih halus dan elegan. Implementasinya mudah dengan kode sederhana, memungkinkan penerapan cepat pada banyak elemen untuk desain yang konsisten.

Kode Python ini menunjukkan cara menerapkan [efek refleksi](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) pada sebuah bentuk:

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

![Efek refleksi](reflection_effect.png)

## **Terapkan Efek Glow**

Untuk menerapkan efek glow pada sebuah bentuk dalam Aspose.Slides untuk Python via Java, Anda dapat menambahkan aura lembut yang bersinar di sekitar bentuk, menyesuaikan properti seperti warna dan ukuran. Efek ini membantu bentuk menonjol dan menambah elemen visual yang menarik pada presentasi Anda. Implementasinya mudah dengan kode minimal, meningkatkan tampilan keseluruhan slide.

Kode Python ini menunjukkan cara menerapkan [efek glow](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) pada sebuah bentuk:

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

![Efek glow](glow_effect.png)

## **Terapkan Efek Pinggiran Lembut**

Untuk menerapkan efek pinggiran lembut dalam Aspose.Slides untuk Python via Java, Anda dapat menciptakan transisi halus dan kabur di sekitar tepi bentuk. Efek ini menambah tampilan yang lebih subtil dan halus, cocok untuk desain yang memerlukan kesan lembut. Anda dapat dengan mudah menyesuaikan parameter seperti radius untuk mencapai efek yang diinginkan pada berbagai bentuk dalam presentasi.

Kode Python ini menunjukkan cara menerapkan [efek pinggiran lembut](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) pada sebuah bentuk:

```python
import jpime
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

![Efek pinggiran lembut](soft_edges_effect.png)

## **Terapkan Efek Blur**

Gunakan blur bentuk untuk melunakkan isi dan garis tepi bentuk sambil menjaga bentuk tetap dapat diedit. Panggil [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) pada format efek bentuk. Radius diukur dalam poin (1/72 inci): gunakan nilai non‑negatif, dengan nilai yang lebih besar menghasilkan blur yang lebih kuat. Radius nol tidak mengubah tampilan.

Pengaturan [getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) mengendalikan batas tampak efek. Dengan `False`, blur dipotong pada batas yang sudah dilukis, termasuk garis tepi. Dengan `True`, blur dapat melampaui batas tersebut. Tidak ada pengaturan yang mengubah posisi atau dimensi bentuk.

Perbandingan berikut menggunakan isi, garis tepi, dan dimensi bentuk yang sama sepanjang contoh. Baris atas menggunakan `grow = False`; baris bawah menggunakan `grow = True`.

![Persegi panjang asli dibandingkan dengan radius blur 5 dan 15 poin, dengan grow dinonaktifkan dan diaktifkan](shape_blur_comparison.png)

Contoh Python ini membuat persegi panjang oranye dengan garis tepi biru tua, menerapkan blur 5 poin, lalu memperbaruinya menjadi blur 15 poin dengan memanggil [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) lagi. Ia menyimpan kedua keadaan blur, kemudian memanggil [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) dan menyimpan bentuk tanpa blur.

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

Blur bentuk memengaruhi isi dan garis tepi secara bersamaan. Efek pinggiran lembut memudarkan tepi bentuk, sementara blur bayangan melunakkan hanya bayangan. Efek transformasi gambar beroperasi pada konten gambar; contoh ini menerapkan blur langsung pada format efek bentuk tanpa mengonversi bentuk menjadi gambar.

## **FAQ**

**Apakah saya dapat menerapkan beberapa efek pada bentuk yang sama?**

Ya, Anda dapat menggabungkan berbagai efek, seperti bayangan, refleksi, dan glow, pada satu bentuk untuk menciptakan penampilan yang lebih dinamis.

**Bentuk apa yang dapat saya terapkan efek?**

Anda dapat menerapkan efek pada berbagai bentuk, termasuk autoshape, bagan, tabel, gambar, objek SmartArt, objek OLE, dan lainnya.

**Apakah saya dapat menerapkan efek pada bentuk yang dikelompokkan?**

Ya, Anda dapat menerapkan efek pada bentuk yang dikelompokkan. Efek tersebut akan diterapkan pada seluruh grup.