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
description: "Terapkan dan render efek 3D untuk bentuk dan teks PowerPoint di Python dengan Aspose.Slides. Konfigurasikan kamera, pencahayaan, material, ekstrusi, isian, dan teks 3D."
---
## **Ikhtisar**

Aspose.Slides for Python via .NET dapat membuat, menyunting, mempertahankan, dan merender pemformatan 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Ini bukan tentang menyisipkan atau menyunting file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan properti [Shape.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/three_d_format/) untuk menerapkan pemformatan 3D pada sebuah bentuk. Properti tersebut mengekspos [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/), yang mengontrol adegan 3D untuk bentuk itu.

Untuk teks, gunakan properti [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/three_d_format/). Ini menerapkan pemformatan 3D pada bingkai teks alih-alih badan bentuk.

Properti paling penting adalah:

| Properti | Apa yang dikendalikan | Kapan menggunakannya |
|---|---|---|
| [camera](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/camera/) | Sudut pandang, tipe kamera bawaan, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/light_rig/) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [material](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/material/) | Material permukaan, seperti rata, matte, plastik, atau logam. | Buat geometri yang sama terlihat lebih rata, lembut, mengkilap, atau metalik. |
| [extrusion_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_height/) | Seberapa jauh bentuk menjorok ke belakang dari permukaan depannya. | Ubah bentuk datar menjadi objek 3D tebal yang terlihat. |
| [extrusion_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_color/) | Warna sisi yang diekstrusi. | Buat kedalaman terlihat atau koordinasikan warna sisi dengan isian depan. |
| [depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/depth/) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Sesuaikan kedalaman untuk bentuk atau teks, terutama bersama pengaturan bevel dan material. |
| [bevel_top](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/bevel_top/) dan [bevel_bottom](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/bevel_bottom/) | Tepi yang terangkat atau melengkung pada permukaan depan dan belakang. | Tambahkan tepi yang lunak atau dibentuk alih-alih permukaan datar yang tajam. |
| [contour_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/contour_color/) dan [contour_width](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/contour_width/) | Garis tepi di sekitar objek 3D. | Tekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya memerlukan empat jenis pengaturan agar terlihat meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default mungkin menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat permukaan dan sisinya dapat dibaca.
- Pengaturan material, karena permukaan memengaruhi cara cahaya dirender.
- Pengaturan ekstrusi atau kedalaman, karena bentuk datar membutuhkan ketebalan.

Contoh berikut membuat persegi panjang, menambahkan teks ke permukaan depannya, dan menerapkan pemformatan 3D. Nilai rotasi kamera dalam derajat, dan tinggi ekstrusi 100 poin. Contoh ini merender slide ke gambar PNG dengan ukuran dua kali dimensi default dan menyimpan presentasi sebagai PPTX.

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

Gambar slide yang dirender menampilkan persegi panjang biru 3D dengan teks 3D putih di permukaan depannya:

![Gambar slide yang dirender menampilkan persegi panjang biru 3D dengan teks 3D putih di permukaan depannya](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi melalui panel 3‑D Rotation. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![Panel Rotasi 3‑D PowerPoint dengan nilai rotasi X, Y, dan Z disorot](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [ThreeDFormat.camera](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/camera/). Contoh ini membuat persegi panjang, memilih tampilan depan ortografik, dan mengatur rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing‑masing. Ia mengonfigurasi bentuk di memori tanpa menyimpan berkas:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Ini tidak mengubah geometri bentuk 2D pada slide. Ini mengubah sudut pandang 3D yang digunakan PowerPoint dan Aspose.Slides saat merender.

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk terlihat tebal dengan memperpanjangnya ke belakang permukaan depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![Kontrol kedalaman PowerPoint dipetakan ke properti warna ekstrusi dan tinggi ekstrusi](img_02_02.png)

Atur [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_height/) untuk ketebalan dan [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_color/) untuk warna sisi. Contoh ini memberikan persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Ia mengonfigurasi bentuk di memori tanpa menyimpan berkas:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

Properti [ThreeDFormat.depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/depth/) mengatur kedalaman bentuk 3D. Properti [extrusion_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/extrusion_height/) mengontrol tinggi efek ekstrusi, sebagaimana ditunjukkan dalam contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D bersifat independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar pada permukaan depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru‑ke‑oren pada permukaan depan dan warna oranye gelap pada ekstrusi 150 poin. Titik henti gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali dimensi default:

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

Gambar persegi panjang 3D dengan isian gradien biru‑ke‑oren dan ekstrusi oranye:

![Gambar persegi panjang 3D dengan isian gradien biru‑ke‑oren dan ekstrusi oranye](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan berkas yang sudah ada bernama "image.jpg" di direktori kerja. Ia memperluas gambar untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan mengatur rotasi kamera dalam derajat. Ia mengonfigurasi bentuk di memori tanpa menyimpan atau merender berkas:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Gambar persegi panjang 3D dengan isian foto pada permukaan depan dan ekstrusi oranye:

![Gambar persegi panjang 3D dengan isian foto pada permukaan depan dan ekstrusi oranye](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi bingkai teks. Ini berguna untuk efek mirip WordArt di mana huruf‑huruf itu sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola grid oranye‑putih, menerapkan lengkungan ke atas, dan mengonfigurasi pengaturan 3D melalui [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/three_d_format/). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis tepi disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

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

Gambar teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap:

![Gambar teks 3D yang dirender dengan transformasi WordArt melengkung, isian pola oranye, dan ekstrusi gelap](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap dapat dibaca sambil mempertahankan tampilan 3D bentuk, atur [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/keep_text_flat/) melalui [TextFrame.text_frame_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/text_frame_format/). Ketika nilai `True`, teks berada di luar adegan 3D. Ketika nilai `False`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusi tetap dikonfigurasi melalui [Shape.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/three_d_format/). Ini juga berbeda dari rotasi biasa. [Shape.rotation](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/rotation/) memutar bentuk dalam bidang slide, sementara [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/rotation_angle/) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset kedua sudut tersebut.

Contoh mandiri berikut membuat persegi panjang biru dengan teks dan menggandakannya di sebelah aslinya. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `False` di kiri dan `True` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh ini menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi default.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

Di kiri, teks mengikuti orientasi 3D. Di kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi dan orientasi 3D yang sama terlihat.

![Dua persegi panjang 3D berdampingan: keep_text_flat False di kiri dan True di kanan](keep_text_flat.png)

## **Ekspor dan Perilaku Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D dirasterisasi atau digambar ke output sebagai hasil 2D. Hal ini berlaku ketika Anda merender slide ke [PNG](/slides/id/python-net/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/python-net/convert-powerpoint-to-html/), atau menghasilkan frame untuk [konversi video](/slides/id/python-net/convert-powerpoint-to-video/).

Perlu diingat:

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir bergantung pada kombinasi kamera, rig cahaya, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwarisi atau berbasis tema, baca [effective shape properties](/slides/id/python-net/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat diedit. Pada format tersebut, hasil visual dirender alih‑alih dipertahankan sebagai pengaturan 3D yang dapat diedit.

## **FAQ**

**Apakah Aspose.Slides dapat membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML yang interaktif sebagai adegan 3D yang dapat diputar penonton. Pada PPTX, pemformatan 3D tetap dapat diedit di PowerPoint bila formatnya mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Minimal, atur rotasi kamera dan ekstrusi atau kedalaman. Praktiknya, juga atur rig cahaya dan material agar wajah yang dirender memiliki sorotan dan bayangan yang jelas.

**Dapatkah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/three_d_format/) untuk badan bentuk dan [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/three_d_format/) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D ketika menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat diedit.

**Dapatkah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/python-net/shape-effective-properties/) untuk membaca kamera, rig cahaya, bevel, dan nilai 3D terkait lainnya yang final.