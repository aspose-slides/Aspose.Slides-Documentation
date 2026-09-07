---
title: Buat Efek 3D dalam Presentasi Menggunakan Python
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/python-java/3d-presentation/
keywords:
- PowerPoint 3D
- Presentasi 3D
- Rotasi 3D
- Kedalaman 3D
- Ekstrusi 3D
- Gradien 3D
- Teks 3D
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint dalam Python via Java dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ikhtisar**

Aspose.Slides for Python via Java dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D gaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isi gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Artikel ini tidak membahas penyisipan atau pengeditan file model 3D yang berdiri sendiri. Ketika Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke dalam output 2D yang diekspor.
{{% /alert %}}

Instal paket seperti dijelaskan pada [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides`, memulai JVM bila diperlukan, dan kemudian mengimpor API. Contoh isian gambar memerlukan file `image.jpg` di direktori kerja.

## **Konsep Pemformatan 3D**

Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getThreeDFormat) untuk menerapkan pemformatan 3D pada sebuah bentuk. Objek format yang dikembalikan mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getThreeDFormat). Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada badan bentuk.

Anggota API yang paling penting adalah:

| Anggota API | Apa yang dikontrol | Kapan harus digunakan |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getCamera) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getLightRig) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [getMaterial](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getMaterial) dan [setMaterial](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setMaterial) | Material permukaan, seperti datar, matte, plastik, atau logam. | Buat geometri yang sama tampak lebih datar, lebih lembut, mengkilap, atau logam. |
| [getExtrusionHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getExtrusionHeight) dan [setExtrusionHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setExtrusionHeight) | Seberapa jauh bentuk mengekstensi ke belakang dari muka depannya. | Ubah bentuk datar menjadi objek 3D yang tampak tebal. |
| [getExtrusionColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getExtrusionColor) | Warna sisi yang diekstrusi. | Buat kedalaman terlihat atau koordinasikan warna sisi dengan isian depan. |
| [getDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getDepth) dan [setDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setDepth) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama pengaturan bevel dan material. |
| [getBevelTop](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getBevelTop) dan [getBevelBottom](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getBevelBottom) | Tepi terangkat atau melengkung pada muka depan dan belakang. | Tambahkan tepi yang lebih lembut atau dibentuk alih-alih muka datar yang tajam. |
| [getContourColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getContourWidth), dan [setContourWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#setContourWidth) | Garis luar di sekitar objek 3D. | Tekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default mungkin menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar membutuhkan ketebalan.

Contoh berikut membuat persegi panjang, menambahkan teks ke muka depannya, menerapkan pemformatan 3D, menyimpan presentasi sebagai PPTX, dan merender slide ke gambar PNG.

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
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

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

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada muka depannya](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel Rotasi 3-D. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel Rotasi 3-D PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, atur tipe kamera dan rotasi melalui format 3D yang dikembalikan oleh [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getThreeDFormat):

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

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah titik pandang 3D yang digunakan oleh PowerPoint dan oleh Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperpanjangnya di belakang muka depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur tinggi ekstrusi untuk ketebalan dan warna ekstrusi untuk warna sisi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200)

    extrusion_color = Color(128, 0, 128)

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40)
    shape.getThreeDFormat().setExtrusionHeight(100)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Gunakan pengaturan kedalaman ketika Anda perlu bekerja langsung dengan nilai kedalaman PowerPoint atau menggabungkan kedalaman dengan bevel, material, dan efek teks. Dalam banyak skenario bentuk, tinggi ekstrusi lebih jelas karena langsung mengekspresikan ekstrusi yang terlihat.

## **Gunakan Isi Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isi bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isi gambar ke muka depan dan masih menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan isi gradien ke bentuk dan warna ekstrusi yang lebih gelap ke sisi:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE)

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

Output yang dirender mempertahankan gradien pada muka depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isi gradien biru-ke-oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isi gambar sebagai gantinya, tambahkan gambar ke presentasi dan tetapkan ke isi bentuk:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, PictureFillMode, Presentation, ShapeType
from java.awt import Color
from pathlib import Path
from java.nio.file import Files, Paths

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250)

    file_path = str(Path("image.jpg").resolve())
    image_path = Paths.get(file_path)
    image_data = Files.readAllBytes(image_path)
    image = presentation.getImages().addImage(image_data)

    shape.getFillFormat().setFillType(FillType.Picture)
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    extrusion_color = Color(255, 140, 0)
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30)
    shape.getThreeDFormat().setExtrusionHeight(150)
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusion_color)
finally:
    presentation.dispose()
```

Gambar tersebut dirender pada muka depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isi foto pada muka depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D ke Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑huruf itu sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan isi pola, menerapkan transformasi WordArt, dan mengonfigurasi pengaturan 3D pada [TextFrameFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/):

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

Teks dirender sebagai huruf 3D yang melengkung dan diekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isi pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke dalam output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke PNG, mengekspor ke PDF, mengekspor ke HTML, atau menghasilkan frame untuk konversi video.

Perhatikan hal‑hal berikut:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir bergantung pada kombinasi kamera, light rig, material, ekstrusi, isi, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, gunakan API pemformatan efektif.
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender daripada disimpan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan ekstrusi atau kedalaman. Praktiknya, juga atur light rig dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Apakah saya dapat menerapkan efek 3D ke bentuk dan teks sekaligus?**

Ya. Gunakan [Shape.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getThreeDFormat) untuk badan bentuk dan [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#getThreeDFormat) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan tema diterapkan?**

Ya. Gunakan [ThreeDFormat.getEffective](https://reference.aspose.com/slides/id/python-java/aspose.slides/threedformat/#getEffective) untuk membaca kamera, light rig, bevel, dan nilai 3D terkait yang akhir.