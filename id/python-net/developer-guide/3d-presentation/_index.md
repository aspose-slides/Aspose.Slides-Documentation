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
## **Gambaran Umum**

Aspose.Slides untuk Python melalui .NET dapat membuat, mengedit, mempertahankan, dan merender format 3D bergaya PowerPoint untuk bentuk dan teks. Artikel ini mencakup efek 3D seperti rotasi, ekstrusi, bevel, pencahayaan, material, isian gradien atau gambar, dan teks 3D.

{{% alert color="info" title="Note" %}}
Artikel ini membahas efek pemformatan 3D pada bentuk dan teks PowerPoint. Artikel ini tidak membahas penyisipan atau penyuntingan file model 3D terpisah. Saat Anda mengekspor slide ke gambar, PDF, atau HTML, Aspose.Slides merender efek 3D tersebut ke output 2D yang diekspor.
{{% /alert %}}

## **Konsep Pemformatan 3D**

Gunakan properti [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) untuk menerapkan pemformatan 3D pada sebuah bentuk. Properti tersebut mengekspos [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/), yang mengontrol adegan 3D untuk bentuk tersebut.

Untuk teks, gunakan properti [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) . Ini menerapkan pemformatan 3D ke frame teks alih-alih badan bentuk.

Properti paling penting adalah:

| Properti | Apa yang dikontrol | Kapan digunakan |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Titik pandang, tipe kamera preset, rotasi, zoom, dan perspektif. | Putar objek dalam ruang 3D atau cocokkan dengan preset rotasi 3D PowerPoint. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Preset cahaya, arah, dan rotasi cahaya. | Ubah cara sorotan dan bayangan muncul pada permukaan 3D. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Material permukaan, seperti datar, matte, plastik, atau logam. | Membuat geometri yang sama tampak lebih datar, lembut, mengkilap, atau logam. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Seberapa jauh bentuk memperluas ke belakang dari permukaan depannya. | Mengubah bentuk datar menjadi objek 3D yang terlihat tebal. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Warna sisi yang diekstrusi. | Membuat kedalaman terlihat atau mengkoordinasikan warna sisi dengan isi depan. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | Kedalaman 3D tambahan yang digunakan oleh pemformatan 3D PowerPoint. | Menyetel kedalaman secara halus untuk bentuk atau teks, terutama bersamaan dengan pengaturan bevel dan material. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) dan [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Tepi yang terangkat atau melengkung pada permukaan depan dan belakang. | Tambahkan tepi yang lembut atau dibentuk alih-alih permukaan datar tajam. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) dan [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | Garis tepi di sekitar objek 3D. | Tekankan batas objek dalam output yang dirender. |

## **Buat Bentuk 3D**

Sebuah bentuk biasanya membutuhkan empat jenis pengaturan sebelum tampak meyakinkan sebagai 3D:

- Pengaturan kamera, karena tampilan depan default dapat menyembunyikan ekstrusi.
- Pengaturan cahaya, karena pencahayaan membuat wajah dan sisi dapat dibaca.
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

Gambar slide yang dirender menunjukkan persegi panjang sebagai blok 3D tebal:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **Putar Bentuk dengan Kamera**

Di PowerPoint, rotasi 3D dikonfigurasi dari panel Rotasi 3-D. Nilai rotasi X, Y, dan Z sesuai dengan rotasi yang Anda atur melalui API kamera.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Di Aspose.Slides, akses kamera melalui [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/). Contoh ini membuat persegi panjang, memilih tampilan depan ortografik, dan menetapkan rotasi X, Y, dan Z menjadi 20, 30, dan 40 derajat masing‑masing. Ini mengonfigurasi bentuk di memori tanpa menyimpan file:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Gunakan kamera ketika Anda perlu mengubah cara penonton melihat objek. Kamera tidak mengubah geometri bentuk 2D pada slide. Kamera mengubah titik pandang 3D yang digunakan PowerPoint dan Aspose.Slides saat merender.

### **Salin Orientasi Kamera dari Bentuk Template**

Untuk mencocokkan orientasi bentuk template, salin preset [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) dan baca rotasinya dengan [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/). Contoh membuka `template.pptx` dan menyalin orientasi kamera dari bentuk pertama pada slide pertama ke bentuk kedua. Kedua bentuk sudah memiliki pencahayaan 3D, dan bentuk kedua tidak memiliki rotasi kamera eksplisit.

Sudutnya dalam derajat. Indeks `0`, `1`, dan `2` masing‑masing menyimpan lintang, bujur, dan revolusi. Kirimkan ke [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) dalam urutan itu. Jika sumber tidak memiliki rotasi eksplisit, `get_rotation` mengembalikan `None`, jadi biarkan sudut tujuan tidak diatur. Jika sumber secara eksplisit menetapkan ketiga sudut ke nol, salin nol tersebut.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

Ketika Anda membuka kembali `camera-copy.pptx` di PowerPoint, kedua bentuk memiliki preset kamera dan rotasi yang sama. Panah di kanan menggunakan orientasi yang disalin dari persegi panjang di kiri. Kedua bentuk menggunakan pencahayaan dan kedalaman ekstrusi yang sama.

![A blue 3D rectangle and a right arrow with matching camera orientation, viewed from above and to the right](camera-orientation.png)

## **Tambahkan Ekstrusi dan Kedalaman**

Ekstrusi membuat bentuk tampak tebal dengan memperluasnya di belakang permukaan depan. Di PowerPoint, kontrol kedalaman mengatur ketebalan yang terlihat, dan kontrol warna mengatur warna sisi.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

Setel [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) untuk ketebalan dan [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) untuk warna sisi. Contoh ini memberi persegi panjang ekstrusi 100 poin dengan sisi ungu dan memutar kamera untuk memperlihatkan ketebalannya. Ini mengonfigurasi bentuk di memori tanpa menyimpan file:

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

Properti [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) mengatur kedalaman bentuk 3D. Properti [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) mengontrol tinggi efek ekstrusi, seperti pada contoh ini.

## **Gunakan Isian Gradien atau Gambar dengan Efek 3D**

Pemformatan 3D independen dari isian bentuk. Anda dapat menerapkan warna solid, gradien, pola, atau isian gambar ke permukaan depan dan tetap menggunakan kamera, cahaya, material, serta pengaturan ekstrusi yang sama.

Contoh ini menerapkan gradien biru‑ke‑oren pada permukaan depan dan warna oranye gelap pada ekstrusi 150 poin. Hentian gradien pada 0 dan 100 menandai awal dan akhir gradien. Nilai rotasi kamera dalam derajat. Slide dirender ke gambar PNG dengan ukuran dua kali dimensi default:

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

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

Untuk menggunakan isian gambar, tambahkan gambar ke presentasi dan tetapkan ke isian bentuk. Contoh ini memerlukan berkas yang ada bernama "image.jpg" di direktori kerja. Gambar diperluas untuk mengisi persegi panjang, menerapkan ekstrusi 150 poin, dan menetapkan rotasi kamera dalam derajat. Ini mengonfigurasi bentuk di memori tanpa menyimpan atau merender file:

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

Gambar dirender pada permukaan depan, sementara ekstrusi dirender sebagai permukaan sisi 3D:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **Terapkan Pemformatan 3D pada Teks**

Pemformatan 3D pada bentuk memengaruhi badan bentuk. Pemformatan 3D pada teks memengaruhi frame teks. Ini berguna untuk efek mirip WordArt di mana huruf‑huruf itu sendiri memerlukan ekstrusi, material, pencahayaan, dan pengaturan kamera.

Contoh berikut membuat teks dengan pola kisi oranye‑dan‑putih, menerapkan lengkungan ke atas, dan mengonfigurasi pengaturan 3D melalui [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/). Tinggi ekstrusi dan kedalaman dalam poin, dan rotasi cahaya dalam derajat. Isian bentuk dan garis tepi disembunyikan sehingga hanya teks yang terlihat. Contoh ini merender gambar PNG dengan ukuran dua kali dimensi slide default dan menyimpan presentasi sebagai PPTX:

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

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **Jaga Teks Tetap Datar pada Bentuk 3D**

Untuk menjaga teks tetap dapat dibaca sambil mempertahankan tampilan 3D bentuk, setel [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) melalui [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/). Ketika nilai `True`, teks tetap berada di luar adegan 3D. Ketika `False`, teks berpartisipasi dalam adegan dan mengikuti orientasi 3D.

Pengaturan ini tidak menghapus pemformatan 3D bentuk: kamera, pencahayaan, material, dan ekstrusi tetap dikonfigurasi melalui [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/). Ini juga berbeda dari rotasi biasa. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) memutar bentuk pada bidang slide, sementara [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) mengontrol rotasi khusus teks dalam kotak pembatasnya. Menjaga teks di luar adegan 3D tidak mereset kedua sudut tersebut.

Contoh berikut membuat persegi panjang biru dengan teks dan menggandakannya di samping yang asli. Kedua bentuk memiliki pemformatan 3D yang sama; hanya pengaturan teks yang berbeda: `False` di kiri dan `True` di kanan. Sudut kamera dalam derajat, dan tinggi ekstrusi 40 poin. Contoh menyimpan presentasi sebagai PPTX dan merender slide perbandingan ke PNG dengan ukuran dua kali dimensi default.

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

Di kiri, teks mengikuti orientasi 3D. Di kanan, teks tetap datar dan lebih mudah dibaca. Kedua persegi panjang mempertahankan ekstrusi terlihat dan orientasi 3D yang sama.

![Side-by-side 3D rectangles: keep_text_flat is False on the left and True on the right](keep_text_flat.png)

## **Perilaku Ekspor dan Rendering**

Aspose.Slides mempertahankan pemformatan 3D saat menyimpan ke format PowerPoint seperti PPTX. Saat merender atau mengekspor ke format tata letak tetap, adegan 3D di‑rasterisasi atau digambar ke output sebagai hasil 2D. Hal ini berlaku ketika Anda merender slide ke [PNG](/slides/id/python-net/convert-powerpoint-to-png/), mengekspor ke [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), mengekspor ke [HTML](/slides/id/python-net/convert-powerpoint-to-html/), atau menghasilkan frame untuk [video conversion](/slides/id/python-net/convert-powerpoint-to-video/).

- Gambar dan PDF yang diekspor tidak interaktif. Objek tidak dapat diputar oleh penonton setelah diekspor.
- Penampilan akhir bergantung pada kombinasi kamera, light rig, material, ekstrusi, isian, dan skala slide.
- Jika Anda perlu memeriksa nilai pemformatan yang diwariskan atau berbasis tema, baca [effective shape properties](/slides/id/python-net/shape-effective-properties/).
- Beberapa format output tidak dapat menyimpan pemformatan 3D PowerPoint yang dapat disunting. Pada format tersebut, hasil visual dirender bukan dipertahankan sebagai pengaturan 3D yang dapat disunting.

## **FAQ**

**Bisakah Aspose.Slides membuat presentasi 3D interaktif?**

Aspose.Slides membuat dan merender efek 3D PowerPoint untuk bentuk dan teks. Ia tidak membuat gambar, PDF, atau halaman HTML yang interaktif sebagai adegan 3D yang dapat diputar oleh penonton. Pada PPTX, pemformatan 3D tetap dapat disunting di PowerPoint bila format mendukungnya.

**Apa perbedaan antara model 3D dan efek 3D?**

Model 3D adalah objek 3D terpisah yang disisipkan ke dalam presentasi. Efek 3D adalah pemformatan yang diterapkan pada bentuk atau teks PowerPoint biasa, seperti rotasi, ekstrusi, bevel, pencahayaan, dan material. Artikel ini membahas efek 3D.

**Pengaturan apa yang diperlukan untuk bentuk 3D yang terlihat?**

Setidaknya, tetapkan rotasi kamera dan ekstrusi atau kedalaman. Pada praktiknya, juga tetapkan light rig dan material agar wajah yang dirender memiliki sorotan dan bayangan yang jelas.

**Bisakah saya menerapkan efek 3D pada bentuk dan teks?**

Ya. Gunakan [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) untuk badan bentuk dan [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) untuk teks.

**Apakah efek 3D akan muncul saat mengekspor ke gambar, PDF, HTML, atau frame video?**

Ya. Aspose.Slides merender efek 3D saat menghasilkan gambar slide, output PDF, output HTML, dan frame yang digunakan untuk konversi video. Output yang diekspor berisi tampilan yang dirender, bukan objek 3D yang dapat disunting.

**Bisakah saya membaca nilai 3D akhir setelah pewarisan dan pengaturan tema diterapkan?**

Ya. Gunakan API pemformatan efektif yang dijelaskan dalam [Shape Effective Properties](/slides/id/python-net/shape-effective-properties/) untuk membaca kamera, light rig, bevel, dan nilai 3D terkait lainnya yang akhir.