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
- isian gradasi
- isian pola
- isian gambar
- isian tekstur
- isian warna solid
- transparansi bentuk
- render bentuk hitam-putih
- render bentuk skala abu-abu
- putar bentuk
- efek bevel 3D
- efek rotasi 3D
- reset pemformatan
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara memformat bentuk PowerPoint dalam Python menggunakan Aspose.Slides—atur gaya isian, garis, dan efek untuk file PPT, PPTX, dan ODP dengan presisi dan kontrol penuh."
---
## **Pendahuluan**

Di PowerPoint, Anda dapat menambahkan bentuk ke slide. Karena bentuk terdiri dari garis, Anda dapat memformatnya dengan memodifikasi atau menerapkan efek pada kontur mereka. Selain itu, Anda dapat memformat bentuk dengan menentukan pengaturan yang mengontrol bagaimana bagian dalamnya diisi.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides untuk Python menyediakan kelas dan properti yang memungkinkan Anda memformat bentuk menggunakan opsi yang sama dengan yang tersedia di PowerPoint.

## **Format Garis**

Menggunakan Aspose.Slides, Anda dapat menentukan gaya garis khusus untuk sebuah bentuk. Langkah‑langkah berikut menjelaskan prosedurnya:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur [gaya garis](https://reference.aspose.com/slides/python-net/aspose.slides/linestyle/) pada bentuk.
5. Tetapkan lebar garis.
6. Atur [gaya dash](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/) pada bentuk.
7. Tentukan warna garis untuk bentuk.
8. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan cara memformat sebuah `AutoShape` persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 75)

    # Hapus isian dari shape persegi panjang agar hanya garisnya yang terlihat.
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

Hasilnya:

![The formatted lines in the presentation](formatted-lines.png)

## **Terapkan Efek Sketsa pada Garis Bentuk**

Efek sketsa membuat garis bentuk terlihat seperti digambar tangan. Gunakan [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/) untuk mengakses pengaturan garis, [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/) untuk mengakses pengaturan sketsa, dan [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) untuk memilih nilai dari enumerasi [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/).

Kode Python berikut menunjukkan cara menerapkan efek [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/), membaca nilai yang ditetapkan secara eksplisit, dan menghapus efek dengan [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    # Akses format garis shape dan format sketsanya.
    sketch_format = shape.line_format.sketch_format

    # Terapkan efek sketsa.
    sketch_format.sketch_type = slides.LineSketchType.CURVED

    # Baca efek sketsa yang ditetapkan langsung pada shape.
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")

    # Hapus efek sketsa.
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

Nilai yang dikembalikan oleh `SketchFormat.sketch_type` mewakili pengaturan yang ditetapkan langsung pada bentuk. Jika pemformatan garis dapat diwarisi dari tema, master slide, atau layout slide, gunakan [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/), akses properti `sketch_format` dari objek yang dikembalikan, dan baca properti `sketch_type`‑nya. Nilai efektif mencerminkan pemformatan yang sebenarnya diterapkan setelah pewarisan diselesaikan:

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

## **Format Gaya Sambungan**

Berikut tiga opsi tipe sambungan:

* Round
* Miter
* Bevel

Secara default, ketika PowerPoint menggabungkan dua garis pada sudut (misalnya pada sudut bentuk), ia menggunakan pengaturan **Round**. Namun, jika Anda menggambar bentuk dengan sudut tajam, Anda mungkin lebih suka opsi **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

Kode Python berikut mendemonstrasikan cara tiga persegi panjang (seperti pada gambar di atas) dibuat menggunakan pengaturan tipe sambungan Miter, Bevel, dan Round:

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

	# Atur warna isian untuk setiap shape persegi panjang.
	shape1.fill_format.fill_type = slides.FillType.SOLID
	shape1.fill_format.solid_fill_color.color = draw.Color.black
	shape2.fill_format.fill_type = slides.FillType.SOLID
	shape2.fill_format.solid_fill_color.color = draw.Color.black
	shape3.fill_format.fill_type = slides.FillType.SOLID
	shape3.fill_format.solid_fill_color.color = draw.Color.black

	# Atur lebar garis.
	shape1.line_format.width = 15
	shape2.line_format.width = 15
	shape3.line_format.width = 15

	# Atur warna untuk setiap garis persegi panjang.
	shape1.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape1.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape2.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape2.line_format.fill_format.solid_fill_color.color = draw.Color.blue
	shape3.line_format.fill_format.fill_type = slides.FillType.SOLID
	shape3.line_format.fill_format.solid_fill_color.color = draw.Color.blue

	# Atur gaya sambungan.
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

## **Isian Gradasi**

Di PowerPoint, Isian Gradasi adalah opsi pemformatan yang memungkinkan Anda menerapkan perpaduan warna berkelanjutan pada sebuah bentuk. Misalnya, Anda dapat menerapkan dua atau lebih warna sehingga satu warna secara perlahan memudar menjadi warna lain.

Berikut cara menerapkan isian gradasi pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) bentuk menjadi `GRADIENT`.
5. Tambahkan dua warna pilihan Anda dengan posisi yang ditentukan menggunakan metode `add` pada koleksi `gradient_stops` yang disediakan oleh kelas [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/).
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan cara menerapkan efek isian gradasi pada sebuah elips:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Ellipse.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)

    # Terapkan pemformatan gradasi pada elips.
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR

    # Atur arah gradasi.
    shape.fill_format.gradient_format.gradient_direction = slides.GradientDirection.FROM_CORNER2

    # Tambahkan dua titik gradasi.
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0, slides.PresetColor.RED)

    # Simpan file PPTX ke disk.
    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The ellipse with gradient fill](gradient-fill.png)

Jika gradasi terlihat berbeda pada gambar yang diekspor dibandingkan di PowerPoint, lihat [Choose a Gradient Rendering Style](/slides/id/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Anda dapat memilih gaya rendering tanpa mengubah isian gradasi yang disimpan dalam presentasi.

## **Isian Pola**

Di PowerPoint, Isian Pola adalah opsi pemformatan yang memungkinkan Anda menerapkan desain dua warna—seperti titik, garis, garis silang, atau kotak—pada sebuah bentuk. Anda dapat memilih warna khusus untuk latar depan dan latar belakang pola.

Aspose.Slides menyediakan lebih dari 45 gaya pola bawaan yang dapat Anda terapkan pada bentuk untuk meningkatkan daya tarik visual presentasi Anda. Bahkan setelah memilih pola bawaan, Anda masih dapat menentukan warna tepat yang harus digunakan.

Berikut cara menerapkan isian pola pada bentuk menggunakan Aspose.Slides:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) bentuk menjadi `PATTERN`.
5. Pilih gaya pola dari opsi bawaan.
6. Atur [back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) pola.
7. Atur [fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) pola.
8. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan cara menerapkan isian pola pada sebuah persegi panjang:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Atur jenis isian menjadi Pattern.
    shape.fill_format.fill_type = slides.FillType.PATTERN

    # Atur gaya pola.
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS

    # Atur warna latar belakang dan latar depan pola.
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    # Simpan file PPTX ke disk.
    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The rectangle with pattern fill](pattern-fill.png)

## **Isian Gambar**

Di PowerPoint, Isian Gambar adalah opsi pemformatan yang memungkinkan Anda menyisipkan gambar di dalam sebuah bentuk—secara efektif menggunakan gambar sebagai latar belakang bentuk.

Berikut cara menggunakan Aspose.Slides untuk menerapkan isian gambar pada bentuk:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) bentuk menjadi `PICTURE`.
5. Atur mode isian gambar menjadi `TILE` (atau mode lain yang diinginkan).
6. Buat objek [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) dari gambar yang ingin Anda gunakan.
7. Tetapkan gambar ini ke properti `picture.image` pada `picture_fill_format` bentuk.
8. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Misalkan kita memiliki file "lotus.png" dengan gambar berikut:

![The lotus picture](lotus.png)

Kode Python berikut mendemonstrasikan cara mengisi sebuah bentuk dengan gambar:

```python
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 192, 95)

    # Atur jenis isian menjadi Picture.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Atur mode isian gambar.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    # Muat gambar dan tambahkan ke sumber daya presentasi.
    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)

    # Atur gambar.
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    # Simpan file PPTX ke disk.
    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape with picture fill](picture-fill.png)

### **Gambar Ubin sebagai Tekstur**

Jika Anda ingin menetapkan gambar ubin sebagai tekstur dan menyesuaikan perilaku ubin, Anda dapat menggunakan properti berikut dari kelas [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/):

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): Menetapkan mode isian gambar—baik `TILE` atau `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): Menentukan perataan ubin di dalam bentuk.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): Mengontrol apakah ubin dibalik secara horizontal, vertikal, atau keduanya.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): Menetapkan offset horizontal ubin (dalam point) dari asal bentuk.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): Menetapkan offset vertikal ubin (dalam point) dari asal bentuk.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): Mendefinisikan skala horizontal ubin dalam persentase.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): Mendefinisikan skala vertikal ubin dalam persentase.

Contoh kode berikut menunjukkan cara menambahkan bentuk persegi panjang dengan isian gambar ubin dan mengonfigurasi opsi ubin:

```py
import aspose.slides as slides

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    first_slide = presentation.slides[0]

    # Tambahkan auto shape persegi panjang.
    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)

    # Atur jenis isian shape menjadi Picture.
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

Hasilnya:

![The tile options](tile-options.png)

## **Isian Warna Solid**

Di PowerPoint, Isian Warna Solid adalah opsi pemformatan yang mengisi sebuah bentuk dengan satu warna seragam. Latar belakang berwarna polos ini diterapkan tanpa gradasi, tekstur, atau pola apa pun.

Untuk menerapkan isian warna solid pada bentuk menggunakan Aspose.Slides, ikuti langkah‑langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) bentuk menjadi `SOLID`.
5. Tetapkan warna isian pilihan Anda ke bentuk.
6. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan cara menerapkan isian warna solid pada sebuah persegi panjang di slide PowerPoint:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation yang mewakili file presentasi.
with slides.Presentation() as presentation:

    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan auto shape tipe Rectangle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    # Atur jenis isian menjadi Solid.
    shape.fill_format.fill_type = slides.FillType.SOLID

    # Atur warna isian.
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    # Simpan file PPTX ke disk.
    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![The shape with solid color fill](solid-color-fill.png)

## **Atur Transparansi**

Di PowerPoint, ketika Anda menerapkan isian warna solid, gradasi, gambar, atau tekstur pada bentuk, Anda juga dapat mengatur tingkat transparansi untuk mengontrol opasitas isian. Nilai transparansi yang lebih tinggi membuat bentuk menjadi lebih tembus, memungkinkan latar belakang atau objek di bawahnya terlihat sebagian.

Aspose.Slides memungkinkan Anda mengatur tingkat transparansi dengan menyesuaikan nilai alfa pada warna yang digunakan untuk isian. Berikut caranya:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur tipe isian menjadi `SOLID`.
5. Gunakan `Color.from_argb` untuk mendefinisikan warna dengan transparansi (komponen `alpha` mengontrol transparansi).
6. Simpan presentasi.

Kode Python berikut mendemonstrasikan cara menerapkan warna isian transparan pada sebuah persegi panjang:

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

## **Putar Bentuk**

Aspose.Slides memungkinkan Anda memutar bentuk dalam presentasi PowerPoint. Ini dapat berguna saat menempatkan elemen visual dengan kebutuhan penyelarasan atau desain tertentu.

Untuk memutar sebuah bentuk pada slide, ikuti langkah‑langkah berikut:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur properti `rotation` bentuk ke sudut yang diinginkan.
5. Simpan presentasi.

Kode Python berikut mendemonstrasikan cara memutar sebuah bentuk sebesar 5 derajat:

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

## **Tambahkan Efek Bevel 3D**

Aspose.Slides memungkinkan Anda menerapkan efek bevel 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) mereka.

Untuk menambahkan efek bevel 3D pada bentuk, ikuti langkah‑langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Konfigurasikan [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) bentuk untuk menentukan pengaturan bevel.
5. Simpan presentasi.

Kode Python berikut menunjukkan cara menerapkan efek bevel 3D pada sebuah bentuk:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance dari kelas Presentation.
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Tambahkan sebuah shape ke slide.
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

## **Tambahkan Efek Rotasi 3D**

Aspose.Slides memungkinkan Anda menerapkan efek rotasi 3D pada bentuk dengan mengonfigurasi properti [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) mereka.

Untuk menerapkan rotasi 3D pada sebuah bentuk:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) ke slide.
4. Atur [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) dan [light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/) bentuk untuk mendefinisikan rotasi 3D.
5. Simpan presentasi.

Kode Python berikut mendemonstrasikan cara menerapkan efek rotasi 3D pada sebuah bentuk:

```python
import aspose.slides as slides

# Membuat instance dari kelas Presentation.
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

## **Kontrol Rendering Hitam‑Putih untuk Bentuk**

Properti [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) menentukan bagaimana sebuah bentuk individu dirender ketika presentasi dilihat atau diproses dalam mode hitam‑putih. Properti ini tidak mengaktifkan tampilan hitam‑putih secara otomatis, dan tidak mengubah isian, garis, atau pemformatan lain bentuk dalam mode warna normal.

Gunakan nilai dari enumerasi [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) untuk memilih perilaku yang diinginkan. Misalnya, `AUTOMATIC` membiarkan aplikasi rendering memilih konversi, `GRAY` dan `LIGHT_GRAY` menggunakan warna abu‑abu, `BLACK_WHITE` hanya menggunakan hitam dan putih, `BLACK` dan `WHITE` memaksa satu warna, `COLOR` mempertahankan warna normal, dan `HIDDEN` menghilangkan bentuk dalam mode hitam‑putih. `NOT_DEFINED` berarti tidak ada mode pada tingkat bentuk yang ditetapkan.

Kode Python berikut membuat sebuah bentuk berwarna dan membuatnya tampak abu‑abu dalam mode tampilan hitam‑putih:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange

    # Pertahankan isian oranye dalam mode berwarna, tetapi render shape dengan warna abu-abu dalam mode hitam-putih.
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Dalam mode warna normal, persegi panjang tetap berisi warna oranye. Dalam alur kerja tampilan hitam‑putih, ia menggunakan warna abu‑abu karena mode‑nya disetel ke `GRAY`. Ini memungkinkan Anda mempertahankan slide berwarna penuh sambil mendefinisikan tampilan khusus untuk pencetakan, pratinjau, atau alur kerja lain yang menghormati pengaturan tampilan hitam‑putih presentasi.

## **Setel Ulang Pemformatan**

Kode Python berikut menunjukkan cara menyetel ulang pemformatan slide dan mengembalikan posisi, ukuran, serta pemformatan semua bentuk dengan placeholder pada [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) ke pengaturan default mereka:

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

Hanya sangat sedikit. Gambar dan media yang disematkan menempati sebagian besar ruang file, sedangkan parameter bentuk seperti warna, efek, dan gradasi disimpan sebagai metadata dan hampir tidak menambah ukuran.

**Bagaimana cara mendeteksi bentuk pada slide yang memiliki pemformatan identik sehingga saya dapat mengelompokkannya?**

Bandingkan setiap properti pemformatan utama bentuk—pengaturan isian, garis, dan efek. Jika semua nilai yang bersesuaian cocok, perlakukan gaya mereka sebagai identik dan kelompokkan bentuk‑bentuk tersebut secara logis, yang menyederhanakan pengelolaan gaya di kemudian hari.

**Bisakah saya menyimpan sekumpulan gaya bentuk khusus ke file terpisah untuk digunakan kembali di presentasi lain?**

Ya. Simpan contoh bentuk dengan gaya yang diinginkan dalam deck slide templat atau file .POTX. Saat membuat presentasi baru, buka templat tersebut, kloning bentuk ber‑gaya yang Anda perlukan, dan terapkan kembali pemformatannya di mana diperlukan.