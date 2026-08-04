---
title: Format Bentuk PowerPoint dalam Python
linktitle: Pemformatan Bentuk
type: docs
weight: 20
url: /id/python-net/shape-formatting/
keywords:
- format bentuk
- format garis
- efek sketsa
- garis bentuk sketsa
- format gaya sambungan
- isi gradien
- isi pola
- isi gambar
- isi tekstur
- isi warna solid
- transparansi bentuk
- rotasi bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam Python menggunakan Aspose.Slides—atur gaya isi, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol cara isi interiornya.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides untuk Python menyediakan kelas dan properti yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama tersedia di PowerPoint.

## **Memformat Garis**

Menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [line style](https://reference.aspose.com/slides/id/python-net/aspose.slides/linestyle/) bentuk.
1. Atur lebar garis.
1. Atur [dash style](https://reference.aspose.com/slides/id/python-net/aspose.slides/linedashstyle/) bentuk.
1. Atur warna garis untuk bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara memformat sebuah `AutoShape` persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Mengambil slide pertama.
    slide = presentation.slides[0]

    # Menambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Menetapkan warna isi untuk shape persegi panjang.
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    # Menerapkan pemformatan pada garis persegi panjang.
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH

    # Menetapkan warna untuk garis persegi panjang.
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    # Menyimpan file PPTX ke disk.
    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The formatted lines in the presentation](formatted-lines.png)

## **Menerapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat digambar tangan. Gunakan [Shape.line_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/line_format/) untuk mengakses pengaturan garis, [LineFormat.sketch_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/lineformat/sketch_format/) untuk mengakses pengaturan sketsa, dan [SketchFormat.sketch_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/sketchformat/sketch_type/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/id/python-net/aspose.slides/linesketchtype/).

Kode Python berikut menunjukkan cara menerapkan efek [LineSketchType.CURVED](https://reference.aspose.com/slides/id/python-net/aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.NONE](https://reference.aspose.com/slides/id/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Akses format garis shape dan format sketsnya.
    sketch_format = shape.line_format.sketch_format

    # Terapkan efek sketsa.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Baca efek sketsa yang ditetapkan langsung pada shape.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Hapus efek sketsa.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Nilai yang dikembalikan oleh `SketchFormat.sketch_type` mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat.get_effective](https://reference.aspose.com/slides/id/python-net/aspose.slides/lineformat/get_effective/), akses properti `sketch_format` pada objek yang dikembalikan, dan baca properti `sketch_type`‑nya. Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    line_format = shape.line_format

    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Memformat Gaya Sambungan**

Berikut tiga opsi jenis sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (misalnya pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih menyukai opsi **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Kode Python berikut mendemonstrasikan cara tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan jenis sambungan Miter, Bevel, dan Round:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

	# Dapatkan slide pertama.
	slide = presentation.slides[0]

	# Tambahkan tiga auto shape tipe Rectangle.
	shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
	shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
	shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

	# Tetapkan warna isi untuk setiap shape persegi panjang.
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

	# Tetapkan warna untuk setiap garis persegi panjang.
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

## **Gradient Fill**

Di PowerPoint, Gradient Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna berkelanjutan pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu secara perlahan memudar menjadi warna lainnya.

Berikut cara menerapkan gradient fill pada bentuk menggunakan Aspose.Slides:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `GRADIENT`.
1. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` pada koleksi `gradient_stops` yang diekspos oleh kelas [GradientFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/gradientformat/).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menerapkan efek gradient fill pada sebuah elips:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Terapkan pemformatan gradient pada elips.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Tetapkan arah gradient.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Tambahkan dua gradient stop.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The ellipse with gradient fill](gradient-fill.png)

## **Pattern Fill**

Di PowerPoint, Pattern Fill adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, crosshatch, atau kotak—pada sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola pra‑definisi yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola pra‑definisi, Anda tetap dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan pattern fill pada bentuk menggunakan Aspose.Slides:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `PATTERN`.
1. Pilih gaya pola dari opsi pra‑definisi.
1. Atur [back_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/patternformat/back_color/) pola.
1. Atur [fore_color](https://reference.aspose.com/slides/id/python-net/aspose.slides/patternformat/fore_color/) pola.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menerapkan pattern fill pada sebuah persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Tetapkan tipe isi menjadi Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Tetapkan gaya pola.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Tetapkan warna latar belakang dan latar depan pola.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Simpan file PPTX ke disk.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The rectangle with pattern fill](pattern-fill.png)

## **Picture Fill**

Di PowerPoint, Picture Fill adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar tersebut sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan picture fill pada bentuk:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `PICTURE`.
1. Atur mode picture fill menjadi `TILE` (atau mode lain yang Anda suka).
1. Buat objek [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dari gambar yang ingin Anda gunakan.
1. Tetapkan gambar ini ke properti `picture.image` pada `picture_fill_format` bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![The lotus picture](lotus.png)

Kode Python berikut menunjukkan cara mengisi bentuk dengan gambar:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Tetapkan tipe isi menjadi Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Tetapkan mode picture fill.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Muat gambar dan tambahkan ke sumber daya presentasi.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Tetapkan gambar.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Simpan file PPTX ke disk.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

Jika Anda ingin menetapkan gambar berulang sebagai tekstur dan menyesuaikan perilaku penataan ubin, Anda dapat menggunakan properti berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Menetapkan mode picture fill—baik `TILE` maupun `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_alignment/): Menentukan perataan ubin dalam bentuk.
- [tile_flip](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_flip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [tile_offset_x](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_offset_x/): Menetapkan offset horizontal ubin (dalam poin) dari asal bentuk.
- [tile_offset_y](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_offset_y/): Menetapkan offset vertikal ubin (dalam poin) dari asal bentuk.
- [tile_scale_x](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_scale_x/): Mendefinisikan skala horizontal ubin dalam persentase.
- [tile_scale_y](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/tile_scale_y/): Mendefinisikan skala vertikal ubin dalam persentase.

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan picture fill berulang dan mengonfigurasi opsi ubin:

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    first_slide = presentation.slides[0]

    # Tambahkan auto shape persegi panjang.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Tetapkan tipe isi shape menjadi Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Muat gambar dan tambahkan ke sumber daya presentasi.
    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    # Tetapkan gambar ke shape.
    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image

    # Konfigurasikan mode picture fill dan properti penataan ubin.
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

Hasilnya:

![The tile options](tile-options.png)

## **Solid Color Fill**

Di PowerPoint, Solid Color Fill adalah opsi pemformatan yang mengisi bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradient, tekstur, atau pola apa pun.

Untuk menerapkan solid color fill pada bentuk menggunakan Aspose.Slides, ikuti langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [FillType](https://reference.aspose.com/slides/id/python-net/aspose.slides/filltype/) bentuk menjadi `SOLID`.
1. Tetapkan warna isi pilihan Anda ke bentuk.
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut menunjukkan cara menerapkan solid color fill pada sebuah persegi panjang di slide PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Tetapkan tipe isi menjadi Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Tetapkan warna isi.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape with solid color fill](solid-color-fill.png)

## **Set Transparency**

Di PowerPoint, ketika Anda menerapkan solid color, gradient, picture, atau texture fill pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isi. Nilai transparansi yang lebih tinggi membuat bentuk lebih tembus, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isi. Cara melakukannya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur tipe isi menjadi `SOLID`.
1. Gunakan `Color.from_argb` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan warna isi transparan pada sebuah persegi panjang:

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

Hasilnya:

![The transparent shape](shape-transparency.png)

## **Rotate Shapes**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Hal ini berguna saat menempatkan elemen visual dengan kebutuhan alignment atau desain tertentu.

Untuk memutar bentuk pada slide, ikuti langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur properti `rotation` bentuk ke sudut yang diinginkan.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara memutar bentuk sebesar 5 derajat:

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

Hasilnya:

![The shape rotation](shape-rotation.png)

## **Add 3D Bevel Effects**

Aspose.Slides memungkinkan Anda menerapkan efek 3D bevel pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) mereka.

Untuk menambahkan efek 3D bevel pada bentuk, ikuti langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) bentuk untuk menentukan pengaturan bevel.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan efek 3D bevel pada bentuk:

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

Hasilnya:

![The 3D bevel effect](3D-bevel-effect.png)

## **Add 3D Rotation Effects**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada bentuk:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Atur [camera_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/camera/camera_type/) dan [light_type](https://reference.aspose.com/slides/id/python-net/aspose.slides/lightrig/light_type/) bentuk untuk mendefinisikan rotasi 3D.
1. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan efek rotasi 3D pada bentuk:

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

Hasilnya:

![The 3D rotation effect](3D-rotation-effect.png)

## **Reset Formatting**

Kode Python berikut menunjukkan cara mengatur ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/) ke pengaturan default mereka:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:

    for slide in presentation.slides:
        # Reset setiap shape pada slide yang memiliki placeholder pada layout.
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah pemformatan bentuk memengaruhi ukuran file presentasi akhir?**

Hanya sedikit. Gambar dan media yang disematkan menyumbang sebagian besar ruang file, sementara parameter bentuk seperti warna, efek, dan gradient disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana saya bisa mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan properti kunci pemformatan setiap bentuk—pengaturan fill, line, dan effect. Jika semua nilai yang bersesuaian cocok, anggap gaya mereka identik dan kelompokan bentuk‑bentuk tersebut secara logis, yang mempermudah manajemen gaya di kemudian hari.

**Apakah saya dapat menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam deck slide templat atau file .POTX templat. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk bergaya yang dibutuhkan, dan terapkan kembali pemformatannya bila diperlukan.