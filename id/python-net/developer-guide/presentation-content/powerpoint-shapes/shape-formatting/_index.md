---
title: Format Bentuk PowerPoint dalam Python
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/python-net/shape-formatting/
keywords:
- format bentuk
- format garis
- format gaya sambungan
- isi gradien
- isi pola
- isi gambar
- isi tekstur
- isi warna solid
- transparansi bentuk
- putar bentuk
- efek bevel 3d
- efek rotasi 3d
- reset pemformatan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam Python menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana interior mereka diisi.

![Format bentuk PowerPoint](format-shape-powerpoint.png)

Aspose.Slides untuk Python menyediakan kelas dan properti yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Format Garis**

Dengan menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah-langkah berikut menjelaskan prosedurnya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/python-net/aspose.slides/linestyle/) dari bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/python-net/aspose.slides/linedashstyle/) dari bentuk.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara memformat sebuah `AutoShape` persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Tetapkan warna isian untuk shape persegi panjang.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Terapkan pemformatan pada garis persegi panjang.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Tetapkan warna untuk garis persegi panjang.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Simpan file PPTX ke disk.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Garis yang diformat dalam presentasi](formatted-lines.png)

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (seperti pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih memilih opsi **Miter**.

![Gaya sambungan dalam presentasi](join-style-powerpoint.png)

Kode Python berikut menunjukkan bagaimana tiga persegi panjang (seperti yang ditunjukkan pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Buat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

	# Dapatkan slide pertama.
	slide = presentation.slides[0]

	# Tambahkan tiga auto shape tipe Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Tetapkan warna isian untuk setiap shape persegi panjang.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Tetapkan lebar garis.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Tetapkan warna untuk garis setiap persegi panjang.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Tetapkan gaya sambungan.
	shape1.line_format.join_style = slides.LineJoinStyle.MITER
	shape2.line_format.join_style = slides.LineJoinStyle.BEVEL
	shape3.line_format.join_style = slides.LineJoinStyle.ROUND

	# Tambahkan teks ke setiap persegi panjang.
	shape1.text_frame.text = "Miter Join style"
	shape2.text_frame.text = "Bevel Join style"
	shape3.text_frame.text = "Round Join style"

	# Simpan file PPTX ke disk.
	presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

## **Isian Gradien**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan campuran warna yang berkelanjutan pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara bertahap beralih ke warna lainnya.

Berikut cara menerapkan isian gradien pada sebuah bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `GRADIENT`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` pada koleksi `gradient_stops` yang disediakan oleh kelas [GradientFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/gradientformat/) .
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menerapkan efek isian gradien pada sebuah elips:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Terapkan pemformatan gradien pada elips.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Tetapkan arah gradien.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Tambahkan dua gradient stop.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Elips dengan isian gradien](gradient-fill.png)

## **Isian Pola**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, crosshatch, atau kotak—ke sebuah bentuk. Anda dapat memilih warna kustom untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola bawaan yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola bawaan, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isian pola pada sebuah bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `PATTERN`.
1. Pilih gaya pola dari opsi yang telah ditentukan.
1. Atur [back_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/patternformat/back_color/) pola.
1. Atur [fore_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/patternformat/fore_color/) pola.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menerapkan isian pola pada sebuah persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Tetapkan tipe isian menjadi Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Tetapkan gaya pola.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Tetapkan warna latar belakang dan latar depan pola.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Simpan file PPTX ke disk.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Persegi panjang dengan isian pola](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar pada sebuah bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `PICTURE`.
1. Atur mode isian gambar menjadi `TILE` (atau mode lain yang diinginkan).
1. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dari gambar yang ingin Anda gunakan.
1. Tetapkan gambar ini ke properti `picture.image` dari `picture_fill_format` bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![Gambar lotus](lotus.png)

Kode Python berikut menunjukkan cara mengisi sebuah bentuk dengan gambar:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Tetapkan tipe isian menjadi Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Tetapkan mode isian gambar.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Muat gambar dan tambahkan ke sumber daya presentasi.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Tetapkan gambar.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Simpan file PPTX ke disk.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bentuk dengan isian gambar](picture-fill.png)

### **Utile Gambar Sebagai Tekstur**

Jika Anda ingin mengatur gambar berulang sebagai tekstur dan menyesuaikan perilaku pengulangan, Anda dapat menggunakan properti berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/) :

- [picture_fill_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/picture_fill_mode/) : Mengatur mode isian gambar—baik `TILE` atau `STRETCH` .
- [tile_alignment](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_alignment/) : Menentukan perataan ubin dalam bentuk .
- [tile_flip](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_flip/) : Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya .
- [tile_offset_x](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_offset_x/) : Mengatur offset horizontal ubin (dalam poin) dari asal bentuk .
- [tile_offset_y](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_offset_y/) : Mengatur offset vertikal ubin (dalam poin) dari asal bentuk .
- [tile_scale_x](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_scale_x/) : Mendefinisikan skala horizontal ubin sebagai persentase .
- [tile_scale_y](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_scale_y/) : Mendefinisikan skala vertikal ubin sebagai persentase .

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan isian gambar berulang dan mengonfigurasi opsi ubin:

```py
import aspose.slides as slides

# Buat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    first_slide = presentation.slides[0]

    # Tambahkan auto shape persegi panjang.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Tetapkan tipe isian shape menjadi Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Muat gambar dan tambahkan ke sumber daya presentasi.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Tetapkan gambar ke shape.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurasikan mode isian gambar dan properti ubin.
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Simpan file PPTX ke disk.
    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Opsi ubin](tile-options.png)

## **Isian Warna Solid**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Warna latar belakang polos ini diterapkan tanpa gradien, tekstur, atau pola.

Untuk menerapkan isian warna solid pada sebuah bentuk menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `SOLID`.
1. Tetapkan warna isian pilihan Anda ke bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menerapkan isian warna solid pada sebuah persegi panjang dalam slide PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Tetapkan tipe isian menjadi Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Tetapkan warna isian.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bentuk dengan isian warna solid](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradien, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengendalikan keopakan isian. Nilai transparansi yang lebih tinggi membuat bentuk lebih tembus, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut cara melakukannya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur tipe isian menjadi `SOLID`.
1. Gunakan `Color.from_argb` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan warna isian transparan pada sebuah persegi panjang:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # Membuat instance kelas Presentation yang mewakili file presentasi.
    with slides.Presentation() as presentation:

        # Dapatkan slide pertama.
        slide = presentation.slides[0]
        
        # Tambahkan auto shape persegi panjang solid.
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

        # Tambahkan auto shape persegi panjang transparan di atas shape solid.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.fill_format.solid_fill_color.color = draw.Color.from_argb(128, 204, 102, 0)
        
        presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bentuk transparan](shape-transparency.png)

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur properti `rotation` bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara memutar sebuah bentuk sebesar 5 derajat:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Putar shape sebesar 5 derajat.
    shape.rotation = 5

    # Simpan file PPTX ke disk.
    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Rotasi bentuk](shape-rotation.png)

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) .

Untuk menambahkan efek bevel 3D pada sebuah bentuk, ikuti langkah-langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) bentuk untuk mendefinisikan pengaturan bevel.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan efek bevel 3D pada sebuah bentuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Buat instance kelas Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Tambahkan shape ke slide.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0

    # Atur properti ThreeDFormat shape.
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    # Simpan presentasi sebagai file PPTX.
    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Efek bevel 3D](3D-bevel-effect.png)

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) .

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [camera_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/camera/camera_type/) dan [light_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/lightrig/light_type/) bentuk untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan efek rotasi 3D pada sebuah bentuk:

```python
import aspose.slides as slides

# Buat instance kelas Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"

    auto_shape.three_d_format.depth = 6
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    # Simpan presentasi sebagai file PPTX.      
    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Efek rotasi 3D](3D-rotation-effect.png)

## **Setel Ulang Pemformatan**

Kode Python berikut menunjukkan cara menyetel ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/) ke pengaturan default mereka:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset setiap shape pada slide yang memiliki placeholder pada layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran akhir file presentasi?**

Hanya sedikit. Gambar dan media yang disematkan menempati sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradien disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya dapat mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan kunci bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokkan bentuk-bentuk tersebut secara logis, yang mempermudah manajemen gaya di kemudian hari.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk kustom ke file terpisah untuk digunakan kembali dalam presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam sebuah deck slide templat atau file templat .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk ber‑gaya yang Anda perlukan, dan terapkan kembali pemformatannya di mana pun diperlukan.