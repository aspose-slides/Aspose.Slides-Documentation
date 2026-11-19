---
title: Buat Efek 3D dalam Presentasi Menggunakan Python
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/python-java/3d-presentation/
keywords:
- 3D PowerPoint
- presentasi 3D
- rotasi 3D
- kedalaman 3D
- ekstrusi 3D
- gradien 3D
- teks 3D
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint dalam Python melalui Java dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D gaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau mengedit file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke dalam output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan metode [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Metode tersebut mengembalikan [ThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/) yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan metode [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Ini menerapkan pemformatan 3D ke kerangka teks alih-alih badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikendalikan | Kapan menggunakannya |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau sesuaikan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getLightRig) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getMaterial) dan [setMaterial](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setMaterial) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama tampak lebih rata, lebih lembut, mengkilap, atau metalik. |
| [getExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionHeight) dan [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Seberapa jauh bentuk menjorok ke belakang dari wajah depannya. | Mengubah bentuk datar menjadi objek 3D yang tampak tebal. |
| [getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyelaraskan warna sisi dengan isian depan. |
| [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getDepth) dan [setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelTop) dan [getBevelBottom](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getBevelBottom) | Tepi terangkat atau melengkung pada wajah depan dan belakang. | Menambahkan tepi yang lebih lembut atau dibentuk alih-alih wajah datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourColor) dan [getContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getContourWidth) dan [setContourWidth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setContourWidth) | Garis tepi di sekitar objek 3D. | Menekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya membutuhkan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat dilihat.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar memerlukan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks ke wajah depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi adalah 100 poin. Contoh ini merender slide menjadi gambar PNG dengan ukuran dua kali dimensi default dan menyimpan presentasi sebagai PPTX.

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

Gambar slide yang dirender menunjukkan persegi panjang sebagai blok 3D yang tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada wajah depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3-D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel PowerPoint 3-D Rotation dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [ThreeDFormat.getCamera](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getCamera). Contoh ini membuat sebuah persegi panjang, memilih tampilan depan ortografis, dan mengatur rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing-masing. Contoh ini mengkonfigurasi bentuk dalam memori tanpa menyimpan file:

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

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah sudut pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

### **Salin Orientasi Kamera dari Bentuk Template**

Untuk mencocokkan orientasi bentuk template, baca preset kamera-nya dengan [Camera.getCameraType](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getCameraType) dan sudut rotasinya dengan [Camera.getRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#getRotation). Contoh ini membuka `template.pptx` dan menyalin orientasi kamera dari bentuk pertama pada slide pertama ke bentuk kedua. Kedua bentuk sudah memiliki pencahayaan 3D, dan bentuk kedua tidak memiliki rotasi kamera eksplisit.

Sudutnya dalam derajat. Indeks `0` adalah lintang, indeks `1` adalah bujur, dan indeks `2` adalah revolusi. Kirimkan ke [Camera.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/camera/#setRotation) dalam urutan tersebut. Jika sumber mengembalikan `None`, maka tidak ada rotasi eksplisit, sehingga biarkan sudut bentuk kedua tidak diatur. Rotasi eksplisit `(0, 0, 0)` mengembalikan tiga nol dan harus disalin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("template.pptx")
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    source_camera = shapes.get_Item(0).getThreeDFormat().getCamera()
    destination_camera = shapes.get_Item(1).getThreeDFormat().getCamera()

    destination_camera.setCameraType(source_camera.getCameraType())
    angles = source_camera.getRotation()
    if angles is not None:
        destination_camera.setRotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Saat Anda membuka kembali `camera-copy.pptx` di PowerPoint, panah di kanan memiliki preset kamera dan rotasi yang sama dengan persegi panjang di kiri. Kedua bentuk menggunakan pencahayaan dan kedalaman ekstrusi yang sama.

![Sebuah persegi panjang 3D biru dan panah kanan dengan orientasi kamera yang cocok, dilihat dari atas dan kanan](camera-orientation.png)

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang wajah depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat ini, dan kontrol warna mengatur warna sisi wajah.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Gunakan [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) untuk mengatur ketebalan dan [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#getExtrusionColor) untuk mengakses warna sisi. Contoh ini memberikan persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Contoh ini mengkonfigurasi bentuk dalam memori tanpa menyimpan file:

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

Metode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setDepth) mengatur kedalaman sebuah bentuk 3D. Metode [setExtrusionHeight](https://reference.aspose.com/slides/python-java/aspose.slides/threedformat/#setExtrusionHeight) mengontrol tinggi efek ekstrusi, seperti yang ditunjukkan dalam contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar ke wajah depan dan tetap menggunakan kamera, cahaya, material, dan pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru-ke-oren pada wajah depan dan warna oranye gelap pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender menjadi gambar PNG dengan ukuran dua kali dimensi default:

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

Output yang dirender mempertahankan gradien pada wajah depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradien biru-ke-oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar sebagai gantinya, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan file yang ada bernama "image.jpg" di direktori kerja. Gambar tersebut diregangkan untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Contoh ini mengkonfigurasi bentuk dalam memori tanpa menyimpan atau merender file:

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

Gambar dirender pada wajah depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada wajah depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D ke Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi kerangka teks. Ini berguna untuk efek mirip WordArt di mana huruf-huruf itu sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye-dan-putih, menerapkan lengkungan ke atas, dan mengkonfigurasi pengaturan 3D melalui [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat). Tinggi dan kedalaman ekstrusi dalam poin, dan rotasi cahaya dalam derajat. Isian dan garis tepi bentuk disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

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

Teks dirender sebagai huruf 3D melengkung dan diekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap dapat dibaca sambil mempertahankan tampilan 3D bentuk, panggil [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setKeepTextFlat) melalui [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getTextFrameFormat). Ketika nilai tersebut `True`, teks tetap berada di luar adegan 3D. Ketika `False`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D-nya.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusinya tetap dikonfigurasi melalui [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat). Ini juga berbeda dari rotasi biasa. [Shape.setRotation](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setRotation) memutar bentuk dalam bidang slide, sementara [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset salah satu sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di sebelah asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `False` di kiri dan `True` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh ini menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi default.

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

Di kiri, teks mengikuti orientasi 3D. Di kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi dan orientasi 3D yang sama.

![Dua persegi panjang 3D berdampingan: teks mengikuti orientasi 3D di kiri dan tetap datar di kanan](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D di rasterisasi atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/python-java/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/python-java/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/python-java/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/python-java/convert-powerpoint-to-video/).

Ingat poin-poin berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [properti bentuk efektif](/slides/id/python-java/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih-alih dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML yang diekspor menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila format tersebut mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Minimal, atur rotasi kamera dan salah satu antara ekstrusi atau kedalaman. Pada praktiknya, juga atur rig cahaya dan material agar wajah yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getThreeDFormat) untuk badan bentuk dan [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getThreeDFormat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Properti Bentuk Efektif](/slides/id/python-java/shape-effective-properties/) untuk membaca kamera akhir, rig cahaya, bevel, dan nilai 3D terkait.