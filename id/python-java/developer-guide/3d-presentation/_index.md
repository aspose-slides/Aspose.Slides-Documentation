---
title: Buat Efek 3D dalam Presentasi Menggunakan Python
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- presentasi 3D
- rotasi 3D
- kedalaman 3D
- ekstrusi 3D
- gradasi 3D
- teks 3D
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint dalam Python via Java dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ikhtisar**

Aspose.Slides untuk Python via Java dapat membuat, mengedit, mempertahankan, dan merender format 3D gaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradasi atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini tidak membahas penyisipan atau penyuntingan file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getThreeDFormat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode ini mengembalikan [ThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getThreeDFormat). Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan digunakan |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getCamera) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau sesuaikan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getLightRig) | Preset cahaya, arah, dan rotasi cahaya. | Ubah bagaimana sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getMaterial) dan [setMaterial](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setMaterial) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama terlihat lebih datar, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getExtrusionHeight) dan [setExtrusionHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Seberapa jauh bentuk menonjol ke belakang dari permukaan depannya. | Mengubah bentuk datar menjadi objek 3D yang jelas tebalnya. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getExtrusionColor) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyelaraskan warna sisi dengan isian depan. |
| [getDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getDepth) dan [setDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setDepth) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getBevelTop) dan [getBevelBottom](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getBevelBottom) | Tepi yang terangkat atau membulat pada permukaan depan dan belakang. | Menambahkan tepi yang lebih lunak atau dibentuk alih-alih permukaan datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getContourColor) dan [getContourWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getContourWidth) dan [setContourWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setContourWidth) | Garis luar di sekitar objek 3D. | Menekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.  
- Pengaturan cahaya, karena pencahayaan membuat permukaan dan sisi dapat terlihat.  
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.  
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.  

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke permukaan depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi adalah 100 poin. Contoh ini merender slide ke gambar PNG dengan ukuran dua kali dimensi default dan menyimpan presentasi sebagai PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)
    shape.getTextFrame().setText("3D")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("shape_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("shape_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gambar slide yang dirender menunjukkan persegi panjang sebagai balok 3D tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada permukaan depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3‑D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel PowerPoint 3‑D Rotation dengan nilai rotasi X, Y, dan Z yang disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [ThreeDFormat.getCamera](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getCamera). Contoh ini membuat persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing‑masing. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
finally:
    presentation.dispose()
```

Gunakan kamera ketika Anda perlu mengubah cara pemirsa melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah sudut pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk terlihat tebal dengan memperpanjangnya ke belakang permukaan depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setExtrusionHeight) untuk mengatur ketebalan dan [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getExtrusionColor) untuk mengakses warna sisi. Contoh ini memberi persegi panjang ekstrusi 100 poin dengan sisi berwarna ungu dan memutar kamera untuk memperlihatkan ketebalannya. Ia mengkonfigurasi bentuk di memori tanpa menyimpan file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Metode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setDepth) mengatur kedalaman sebuah bentuk 3D. Metode [setExtrusionHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setExtrusionHeight) mengontrol tinggi efek ekstrusi, seperti ditunjukkan pada contoh ini.

## **Gunakan Isian Gradasi atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradasi, pola, atau isian gambar pada permukaan depan dan tetap menggunakan pengaturan kamera, cahaya, material, serta ekstrusi yang sama.

Contoh ini menerapkan gradasi biru‑ke‑oranye pada permukaan depan dan warna oranye gelap pada ekstrusi 150 poin. Titik henti gradasi pada 0 dan 100 menandai awal dan akhir gradasi. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali dimensi default:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, ShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getTextFrame().setText("3D Gradient")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64)

    shape.getFillFormat().setFillType(FillType.Gradient)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE)
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color(255, 165, 0))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("gradient_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()
finally:
    presentation.dispose()
```

Output yang dirender mempertahankan gradasi pada permukaan depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradasi biru‑ke‑oranye dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang sudah ada bernama "image.jpg" di direktori kerja. Gambar akan diregangkan mengisi persegi panjang, diberikan ekstrusi 150 poin, dan kamera diputar dalam derajat. Ia mengkonfigurasi bentuk di memori tanpa menyimpan atau merender file:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, LightRigPresetType, LightingDirection, MaterialPresetType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    image_data = Path("image.jpg").read_bytes()
    java_image_data = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(java_image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Gambar dirender pada permukaan depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada permukaan depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D bentuk memengaruhi badan bentuk. Pemformatan 3D teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑hurufnya sendiri membutuhkan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye‑dan‑putih, menerapkan lengkungan ke atas, dan mengonfigurasi pengaturan 3D melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getThreeDFormat). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis luar disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, PatternStyle, Presentation, SaveFormat, ShapeType, TextShapeType
from java.awt import Color

image_scale = 2.0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().setText("3D Text")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern)
    pattern_color = Color(255, 140, 0)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(pattern_color)
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE)
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid)

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128)

    text_frame_format = shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setTransform(TextShapeType.ArchUp)
    text_frame_format.getThreeDFormat().setExtrusionHeight(3.5)
    text_frame_format.getThreeDFormat().setDepth(3)
    text_frame_format.getThreeDFormat().setMaterial(MaterialPresetType.Plastic)
    text_frame_format.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    text_frame_format.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced)
    text_frame_format.getThreeDFormat().getLightRig().setRotation(0, 0, 40)
    text_frame_format.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing)

    thumbnail = slide.getImage(image_scale, image_scale)
    try:
        thumbnail.save("text_3d.png", ImageFormat.Png)
    finally:
        thumbnail.dispose()

    presentation.save("text_3d.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Teks dirender sebagai huruf 3D melengkung dan ter-ekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap terbaca sambil mempertahankan tampilan 3D bentuk, panggil [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setKeepTextFlat) melalui [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getTextFrameFormat). Ketika nilai `True`, teks tetap berada di luar adegan 3D. Ketika `False`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusi tetap dikonfigurasi melalui [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getThreeDFormat). Ini juga berbeda dari rotasi biasa. [Shape.setRotation](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#setRotation) memutar bentuk pada bidang slide, sementara [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setRotationAngle) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak menyetel ulang salah satu sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di samping aslinya. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `False` di kiri dan `True` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi default.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CameraPresetType, FillType, ImageFormat, LightRigPresetType, LightingDirection, MaterialPresetType, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140)

    shape.getTextFrame().setText("Readable text")
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center)
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(100, 149, 237))

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront)
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0)
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat)
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top)
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat)
    shape.getThreeDFormat().setExtrusionHeight(40)
    shape.getThreeDFormat().getExtrusionColor().setColor(Color(65, 105, 225))
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(False)

    flat_text_shape = slide.getShapes().addClone(shape, 400, 160)
    flat_text_shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(True)

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx)
    image = slide.getImage(2, 2)
    try:
        image.save("keep_text_flat.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Di kiri, teks mengikuti orientasi 3D. Di kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi dan orientasi 3D yang terlihat.

![Persegi panjang 3D berdampingan: teks mengikuti orientasi 3D di kiri dan tetap datar di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format berlayout tetap, adegan 3D dirasterisasi atau digambar ke output sebagai hasil 2D. Hal ini berlaku ketika Anda merender slide ke [PNG](/slides/id/python-java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/python-java/convert-powerpoint-to-html/), atau membuat frame untuk [konversi video](/slides/id/python-java/convert-powerpoint-to-video/).

Perhatikan hal‑hal berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh pemirsa setelah diekspor.  
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.  
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [effective shape properties](/slides/id/python-java/shape-effective-properties/).  
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih‑alih disimpan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak menjadikan gambar, PDF, atau halaman HTML yang diekspor menjadi adegan 3D interaktif yang dapat diputar oleh pemirsa. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila format mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Praktiknya, juga atur rig cahaya dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks sekaligus?**

Ya. Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getThreeDFormat) untuk badan bentuk dan [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getThreeDFormat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/python-java/shape-effective-properties/) untuk membaca nilai akhir kamera, rig cahaya, bevel, dan nilai 3D terkait lainnya.