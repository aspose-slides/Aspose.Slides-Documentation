---
title: Buat Efek 3D dalam Presentasi Menggunakan Python
linktitle: Presentasi 3D
type: docs
weight: 232
url: /id/python-net/3d-presentation/
keywords:
- PowerPoint 3D
- presentasi 3D
- rotasi 3D
- kedalaman 3D
- ekstrusi 3D
- gradien 3D
- teks 3D
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint dalam Python dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET dapat membuat, mengedit, mempertahankan, dan merender pemformatan 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini membahas efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="primary" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau menyunting file model 3D terpisah. Ketika Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan properti [Shape.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/three_d_format/) untuk menerapkan pemformatan 3D pada sebuah bentuk. Properti tersebut mengekspos [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan properti [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/three_d_format/). Ini menerapkan pemformatan 3D pada bingkai teks, bukan pada tubuh bentuk.

Properti yang paling penting adalah:

| Properti | Apa yang dikontrol | Kapan digunakan |
|---|---|---|
| [camera](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/camera/) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/light_rig/) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [material](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/material/) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama terlihat lebih datar, lebih lembut, mengkilap, atau metalik. |
| [extrusion_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_height/) | Seberapa jauh bentuk memperpanjang ke belakang dari permukaan depannya. | Mengubah bentuk datar menjadi objek 3D yang tampak tebal. |
| [extrusion_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_color/) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau menyelaraskan warna sisi dengan isian depan. |
| [depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/depth/) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersama dengan pengaturan bevel dan material. |
| [bevel_top](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/bevel_top/) dan [bevel_bottom](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/bevel_bottom/) | Tepi yang terangkat atau melengkung pada permukaan depan dan belakang. | Menambahkan tepi yang lembut atau terbentuk alih-alih permukaan datar yang tajam. |
| [contour_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/contour_color/) dan [contour_width](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/contour_width/) | Garis luar di sekitar objek 3D. | Menekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan sebelum terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat permukaan dan sisi dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar membutuhkan ketebalan.

Contoh berikut membuat sebuah persegi panjang, menambahkan teks pada permukaan depannya, menerapkan pemformatan 3D, menyimpan presentasi sebagai PPTX, dan merender slide menjadi gambar PNG.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)
    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Gambar slide yang dirender menunjukkan persegi panjang sebagai blok 3D yang tebal:

![Persegi panjang 3D biru yang dirender dengan teks 3D putih pada permukaan depan](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel 3-D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel PowerPoint 3-D Rotation dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, atur tipe kamera dan rotasi melalui [ThreeDFormat.camera](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/camera/):

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah titik pandang 3D yang digunakan oleh PowerPoint dan Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk terlihat tebal dengan memperpanjangnya di belakang permukaan depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat ini, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint yang dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_height/) untuk ketebalan dan [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_color/) untuk warna sisi:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Gunakan [ThreeDFormat.depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/depth/) ketika Anda perlu bekerja langsung dengan nilai kedalaman PowerPoint atau menggabungkan kedalaman dengan bevel, material, dan efek teks. Dalam banyak skenario bentuk, [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_height/) adalah pengaturan yang lebih jelas karena langsung menyatakan ekstrusi yang terlihat.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar pada permukaan depan dan tetap menggunakan pengaturan kamera, cahaya, material, dan ekstrusi yang sama.

Contoh ini menerapkan isian gradien pada bentuk dan warna ekstrusi yang lebih gelap pada sisi:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

Output yang dirender mempertahankan gradien pada permukaan depan dan merender ekstrusi secara terpisah:

![Persegi panjang 3D yang dirender dengan isian gradien biru ke oranye dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Gambar dirender pada permukaan depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Persegi panjang 3D yang dirender dengan isian foto pada permukaan depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi tubuh bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf itu sendiri membutuhkan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan isian pola, menerapkan transformasi WordArt, dan mengkonfigurasi pengaturan 3D pada [TextFrameFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/):

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

Teks dirender sebagai huruf 3D melengkung dan diekstrusi:

![Teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke output sebagai hasil 2D. Ini berlaku ketika Anda merender slide ke [PNG](/slides/id/python-net/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/python-net/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/python-net/convert-powerpoint-to-video/).

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah ekspor.
- Penampilan akhir tergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [effective shape properties](/slides/id/python-net/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih-alih dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML yang diekspor menjadi adegan 3D interaktif yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukung.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, atur rotasi kamera dan salah satu dari ekstrusi atau kedalaman. Dalam praktiknya, juga atur rig cahaya dan material agar permukaan yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/three_d_format/) untuk tubuh bentuk dan [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/three_d_format/) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/python-net/shape-effective-properties/) untuk membaca kamera akhir, rig cahaya, bevel, dan nilai 3D terkait.