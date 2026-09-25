---
title: Buat dan Terapkan Efek WordArt di Python via Java
linktitle: WordArt
type: docs
weight: 110
url: /id/python-java/wordart/
keywords:
- WordArt
- buat WordArt
- template WordArt
- efek WordArt
- efek bayangan
- efek refleksi
- efek cahaya bersinar
- transformasi WordArt
- efek 3D
- efek bayangan luar
- efek bayangan dalam
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat dan sesuaikan efek WordArt di Aspose.Slides untuk Python via Java. Panduan langkah demi langkah ini membantu pengembang meningkatkan presentasi dengan teks profesional di Python via Java."
---
## **Ikhtisar**

Efek WordArt memungkinkan Anda memberi gaya pada teks dengan isian, garis tepi, bayangan, refleksi, cahaya bersinar, transformasi, dan pemformatan 3D. Artikel ini menjelaskan cara membuat dan menyesuaikan efek-efek tersebut dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java, tanpa Microsoft Office terpasang.

## **Buat Template WordArt Sederhana dan Terapkan ke Teks**

Contoh‑contoh berikut membangun gaya WordArt sederhana dengan mengatur teks, font, pola isian, dan garis tepi.

Setiap contoh membuat presentasi baru dan menambahkan persegi panjang ke slide pertamanya; tidak diperlukan file input. Contoh pertama mengatur teks menjadi "Aspose.Slides". Posisi dan dimensi bentuk diukur dalam poin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()

    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
finally:
    presentation.dispose()
```

Atur font ke Arial Black dengan ukuran 36 poin agar pemformatan lebih terlihat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)
finally:
    presentation.dispose()
```

Terapkan pola [SmallGrid](https://reference.aspose.com/slides/id/python-java/aspose.slides/patternstyle/#SmallGrid) dengan latar depan oranye tua dan latar belakang putih, lalu tambahkan garis tepi teks hitam dengan lebar 1 poin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, PatternStyle, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    dark_orange = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(dark_orange)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid)

    portion.getPortionFormat().getLineFormat().setWidth(1)
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
finally:
    presentation.dispose()
```

Teks yang dihasilkan:

![Template WordArt sederhana](WordArt_template.png)

## **Terapkan Efek WordArt Lainnya**

Contoh‑contoh berikut menunjukkan cara menerapkan bayangan, refleksi, cahaya bersinar, transformasi, dan efek 3D ke teks.

### **Terapkan Efek Bayangan Luar**

Bayangan luar menambah kedalaman dengan menempatkan bayangan di belakang teks. Anda dapat menyesuaikan warna, arah, jarak, radius blur, skala, dan kemiringan.

Contoh ini memanggil [enableOuterShadowEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/effectformat/#enableOuterShadowEffect) dan mengatur bayangan hitam dengan radius blur 4 poin, arah 230 derajat, serta jarak 30 poin. Nilai skala 100 mempertahankan ukuran bayangan, sementara kemiringan horizontal memiringkannya 20 derajat. Transformasi alfa mengatur opasitas menjadi 32%:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect()
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0)
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32)
finally:
    presentation.dispose()
```

Teks yang dihasilkan:

![Efek Bayangan Luar](outer_shadow_effect.png)

{{% alert color="info" title="Catatan" %}}
- Ketika bayangan luar dan bayangan preset digunakan bersama, hanya bayangan luar yang diterapkan.
- Jika bayangan luar dan dalam digunakan secara bersamaan, efek yang dihasilkan tergantung pada versi PowerPoint. Misalnya, di PowerPoint 2013 efeknya menjadi ganda, sementara di PowerPoint 2007 hanya bayangan luar yang diterapkan.
{{% /alert %}}

### **Terapkan Efek Refleksi**

Refleksi menciptakan salinan teks yang dipantulkan. Sesuaikan posisi, skala, blur, dan opasitas untuk mengontrol tampilannya.

Contoh ini memanggil [enableReflectionEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/effectformat/#enableReflectionEffect) dan membalikkan refleksi secara vertikal dengan skala -100%. Ia menggunakan radius blur 0,5 poin dan jarak 4,72 poin. Opasitas menurun dari 60% menjadi 0,9% antara posisi 0% hingga 60% sepanjang refleksi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, RectangleAlignment, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect()
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9)
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft)
finally:
    presentation.dispose()
```

Teks yang dihasilkan:

![Efek Refleksi](reflection_effect.png)

### **Terapkan Efek Cahaya Bersinar**

Cahaya bersinar menambahkan garis tepi berwarna lembut di sekitar teks. Sesuaikan warna, opasitas, dan radius untuk mengontrol efeknya.

Contoh ini memanggil [enableGlowEffect](https://reference.aspose.com/slides/id/python-java/aspose.slides/effectformat/#enableGlowEffect) dan menerapkan cahaya bersinar merah dengan opasitas 54% serta radius 7 poin:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FontData, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.setText("Aspose.Slides")
    font = FontData("Arial Black")
    portion.getPortionFormat().setLatinFont(font)
    portion.getPortionFormat().setFontHeight(36)

    portion.getPortionFormat().getEffectFormat().enableGlowEffect()
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54)
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7)
finally:
    presentation.dispose()
```

Teks yang dihasilkan:

![Efek Cahaya Bersinar](glow_effect.png)

### **Terapkan Transformasi WordArt**

Transformasi WordArt melengkungkan, meregangkan, atau memutar blok teks.

Setel [setTransform](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setTransform) ke [ArchUpPour](https://reference.aspose.com/slides/id/python-java/aspose.slides/textshapetype/#ArchUpPour) untuk melengkungkan seluruh bingkai teks ke atas:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, TextShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)

    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")
    text_frame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour)
finally:
    presentation.dispose()
```

Teks yang dihasilkan:

![Transformasi WordArt](transform_effect.png)

{{% alert color="info" title="Catatan" %}}
Aspose.Slides untuk Python via Java menyediakan satu set [tipe transformasi](https://reference.aspose.com/slides/id/python-java/aspose.slides/textshapetype/) yang telah ditentukan.
{{% /alert %}}

### **Terapkan Efek 3D ke Bentuk dan Teks**

Anda dapat menerapkan efek 3D ke bentuk atau ke teksnya. Bevel, ekstrusi, pencahayaan, dan pengaturan kamera mengontrol tampilan akhir.

Contoh berikut menggunakan [ThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/) untuk menambahkan bevel melingkar, ekstrusi oranye, dan kontur merah gelap ke persegi panjang. Dimensi bevel, tinggi ekstrusi, lebar kontur, dan kedalaman diukur dalam poin. Material plastik, pencahayaan seimbang yang diputar 40 derajat di sekitar sumbu Z, serta kamera perspektif menentukan tampilannya:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    auto_shape.getTextFrame().setText("Aspose.Slides")

    auto_shape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelBottom().setHeight(10.5)
    auto_shape.getThreeDFormat().getBevelBottom().setWidth(10.5)

    auto_shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    auto_shape.getThreeDFormat().getBevelTop().setHeight(12.5)
    auto_shape.getThreeDFormat().getBevelTop().setWidth(11)

    orange = Color(255, 165, 0)
    auto_shape.getThreeDFormat().getExtrusionColor().setColor(orange)
    auto_shape.getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    auto_shape.getThreeDFormat().getContourColor().setColor(dark_red)
    auto_shape.getThreeDFormat().setContourWidth(1.5)

    auto_shape.getThreeDFormat().setDepth(3)

    auto_shape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    auto_shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    auto_shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    auto_shape.getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    auto_shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Bentuk yang dihasilkan:

![Efek 3D pada bentuk](shape_3D_effect.png)

Contoh ini menerapkan pemformatan 3D serupa ke teks melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getThreeDFormat). Bevel yang lebih kecil membentuk tepi huruf, sementara ekstrusi dan pencahayaan memberi kedalaman pada teks:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BevelPresetType, CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200)
    text_frame = auto_shape.getTextFrame()
    text_frame.setText("Aspose.Slides")

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5)

    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4)
    text_frame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4)

    orange = Color(255, 165, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange)
    text_frame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6)

    dark_red = Color(139, 0, 0)
    text_frame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(dark_red)
    text_frame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5)

    text_frame.getTextFrameFormat().getThreeDFormat().setDepth(3)

    text_frame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic)

    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40)

    text_frame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)
finally:
    presentation.dispose()
```

Teks yang dihasilkan:

![Efek 3D pada teks](text_3D_effect.png)

{{% alert color="info" title="Catatan" %}}
Penerapan efek 3D ke teks atau bentuknya—dan interaksi antar efek tersebut—diatur oleh aturan khusus. Pertimbangkan sebuah adegan yang melibatkan baik teks maupun bentuk yang menampungnya. Efek 3D mencakup representasi 3D objek dan adegan tempat objek ditempatkan.

- Jika adegan ditetapkan untuk baik bentuk maupun teks, adegan bentuk memiliki prioritas dan adegan teks diabaikan.
- Jika bentuk tidak memiliki adegan sendiri tetapi memiliki representasi 3D, adegan teks yang digunakan.
- Jika bentuk tidak memiliki efek 3D sama sekali, ia diperlakukan sebagai datar, dan efek 3D hanya diterapkan pada teks.

Perilaku ini terkait dengan metode [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getLightRig) dan [ThreeDFormat.getCamera](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Untuk menjaga teks tetap datar dan dapat dibaca sambil mempertahankan pemformatan 3D bentuknya, lihat [Keep Text Flat on a 3D Shape](/slides/id/python-java/3d-presentation/) untuk perbandingan keduanya serta contoh Python lengkap.

## **FAQ**

**Apakah saya dapat menggunakan efek WordArt dengan font atau skrip yang berbeda (misalnya Arab, Cina)?**

Ya, Aspose.Slides untuk Python via Java mendukung Unicode dan bekerja dengan semua font serta skrip utama. Efek WordArt seperti bayangan, isian, dan garis tepi dapat diterapkan terlepas dari bahasa, meskipun ketersediaan font dan rendering dapat bergantung pada font sistem.

**Apakah saya dapat menerapkan efek WordArt ke elemen master slide?**

Ya, Anda dapat menerapkan efek WordArt ke bentuk pada slide master, termasuk placeholder judul, footer, atau teks latar belakang. Perubahan pada tata letak master akan tercermin pada semua slide terkait.

**Apakah efek WordArt memengaruhi ukuran file presentasi?**

Sedikit. Efek WordArt seperti bayangan, cahaya bersinar, dan isian gradien dapat menambah ukuran file sedikit karena metadata pemformatan tambahan, namun perbedaannya biasanya dapat diabaikan.

**Apakah saya dapat melihat pratinjau hasil efek WordArt tanpa menyimpan presentasi?**

Ya, Anda dapat merender slide yang berisi WordArt menjadi gambar (misalnya PNG, JPEG) menggunakan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage), atau merender bentuk individual menggunakan [Shape.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage). Dengan cara ini Anda dapat meninjau hasil di memori atau layar sebelum menyimpan atau mengekspor presentasi lengkap.