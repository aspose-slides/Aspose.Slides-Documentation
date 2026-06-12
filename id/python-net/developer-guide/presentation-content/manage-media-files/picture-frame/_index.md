---
title: Tambahkan Bingkai Gambar ke Presentasi dengan Python
linktitle: Bingkai Gambar
type: docs
weight: 10
url: /id/python-net/picture-frame/
keywords:
- bingkai gambar
- tambahkan bingkai gambar
- buat bingkai gambar
- tambahkan gambar
- buat gambar
- ekstrak gambar
- gambar raster
- gambar vektor
- pangkas gambar
- area terpangkas
- properti StretchOff
- pemformatan bingkai gambar
- properti bingkai gambar
- skala relatif
- efek gambar
- rasio aspek
- transparansi gambar
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tambahkan bingkai gambar ke presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET. Permudah alur kerja Anda dan tingkatkan desain slide."
---
## **Pendahuluan**

Bingkai gambar di Aspose.Slides untuk Python memungkinkan Anda menempatkan dan mengelola gambar raster dan vektor sebagai bentuk slide asli. Anda dapat menyisipkan gambar dari file atau stream, memposisikan dan mengubah ukurannya dengan koordinat yang tepat, menerapkan rotasi, mengatur transparansi, dan mengontrol urutan z bersama bentuk lainnya. API juga mendukung pemotongan, mempertahankan rasio aspek, mengatur border dan efek, serta mengganti gambar dasar tanpa membangun ulang tata letak. Karena bingkai gambar berperilaku seperti bentuk biasa, Anda dapat menambahkan animasi, tautan hiperteks, dan teks alternatif, sehingga mudah membangun presentasi yang kaya visual dan aksesibel.

## **Buat Bingkai Gambar**

Bagian ini menunjukkan cara menyisipkan gambar ke dalam slide dengan membuat sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) menggunakan Aspose.Slides untuk Python. Anda akan belajar cara memuat gambar, menempatkannya secara tepat pada slide, dan mengontrol ukuran serta pemformatannya.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan slide berdasarkan indeksnya.
3. Buat sebuah [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke [ImageCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/) presentasi. Gambar ini akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi bingkai.
5. Buat sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) dengan ukuran tersebut menggunakan metode [add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Simpan presentasi sebagai file PPTX.

```py
import aspose.slides as slides

# Instansiasi kelas Presentation untuk merepresentasikan file PPTX.
with slides.Presentation() as presentation:
    # Ambil slide pertama.
    slide = presentation.slides[0]

    # Tambahkan gambar ke presentasi.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Tambahkan bingkai gambar dengan ukuran sesuai gambar.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Simpan presentasi sebagai PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Bingkai gambar memungkinkan Anda dengan cepat membuat slide presentasi dari gambar. Ketika Anda menggabungkan bingkai gambar dengan opsi penyimpanan Aspose.Slides, Anda dapat mengontrol operasi I/O untuk mengonversi gambar dari satu format ke format lain. Anda mungkin ingin melihat halaman-halaman berikut: konversi [image to JPG](https://products.aspose.com/slides/id/python-net/conversion/image-to-jpg/); konversi [JPG to image](https://products.aspose.com/slides/id/python-net/conversion/jpg-to-image/); konversi [JPG to PNG](https://products.aspose.com/slides/id/python-net/conversion/jpg-to-png/); konversi [PNG to JPG](https://products.aspose.com/slides/id/python-net/conversion/png-to-jpg/); konversi [PNG to SVG](https://products.aspose.com/slides/id/python-net/conversion/png-to-svg/); konversi [SVG to PNG](https://products.aspose.com/slides/id/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Buat Bingkai Gambar dengan Skala Relatif**

Bagian ini mendemonstrasikan penempatan gambar dengan ukuran tetap, kemudian menerapkan skala berbasis persentase secara terpisah pada lebar dan tinggi. Karena persentasenya dapat berbeda, rasio aspek dapat berubah. Skala dilakukan relatif terhadap dimensi asli gambar.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan slide berdasarkan indeksnya.
3. Buat sebuah [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke [ImageCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/).
4. Tambahkan sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) ke slide.
5. Atur lebar dan tinggi relatif bingkai gambar.
6. Simpan presentasi sebagai file PPTX.

Kode Python berikut menunjukkan cara membuat bingkai gambar dengan skala relatif:

```py
import aspose.slides as slides

# Instansiasi kelas Presentation untuk merepresentasikan file PPTX.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan gambar ke koleksi gambar presentasi.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Tambahkan bingkai gambar ke slide.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Atur lebar dan tinggi skala relatif.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Simpan presentasi.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Ekstrak Gambar Raster dari Bingkai Gambar**

Anda dapat mengekstrak gambar raster dari objek [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) dan menyimpannya dalam format PNG, JPG, dan format lainnya. Contoh kode di bawah ini mendemonstrasikan cara mengekstrak gambar dari dokumen "sample.pptx" dan menyimpannya dalam format PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Ekstrak Gambar SVG dari Bingkai Gambar**

Ketika sebuah presentasi berisi grafik SVG yang ditempatkan di dalam bentuk [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/), Aspose.Slides untuk Python via .NET memungkinkan Anda mengambil gambar vektor asli dengan fidelitas penuh. Dengan menelusuri koleksi bentuk slide, Anda dapat mengidentifikasi setiap [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/), memeriksa apakah [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) yang mendasarinya berisi konten SVG, dan kemudian menyimpan gambar tersebut ke disk atau stream dalam format SVG aslinya.

Contoh kode berikut mendemonstrasikan cara mengekstrak gambar SVG dari sebuah bingkai gambar:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Dapatkan Transparansi Gambar**

Aspose.Slides memungkinkan Anda mengambil efek transparansi yang diterapkan pada sebuah gambar. Kode Python berikut mendemonstrasikan operasi ini:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
Semua efek yang diterapkan pada gambar dapat ditemukan di [aspose.slides.effects](https://reference.aspose.com/slides/id/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Pemformatan Bingkai Gambar**

Aspose.Slides menyediakan banyak opsi pemformatan yang dapat Anda terapkan pada sebuah bingkai gambar. Dengan opsi-opsi ini, Anda dapat menyesuaikan bingkai gambar agar memenuhi kebutuhan khusus.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan slide berdasarkan indeksnya.
3. Buat sebuah [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) dengan menambahkan gambar ke [ImageCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/). Gambar ini akan digunakan untuk mengisi bentuk.
4. Tentukan lebar dan tinggi bingkai.
5. Buat sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) dengan ukuran tersebut menggunakan metode [add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/) pada slide.
6. Atur warna garis bingkai gambar.
7. Atur lebar garis bingkai gambar.
8. Putar bingkai gambar dengan memberikan nilai positif (searah jarum jam) atau negatif (berlawanan arah jarum jam).
9. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan proses pemformatan bingkai gambar:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiasikan kelas Presentation untuk merepresentasikan file PPTX.
with slides.Presentation() as presentation:
    # Ambil slide pertama.
    slide = presentation.slides[0]

    # Tambahkan gambar ke koleksi gambar presentasi.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Tambahkan bingkai gambar dengan ukuran sesuai gambar.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Terapkan pemformatan pada bingkai gambar.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Simpan presentasi sebagai PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose telah mengembangkan [Collage Maker](https://products.aspose.app/slides/id/collage) gratis. Jika Anda perlu [menggabungkan JPG/JPEG](https://products.aspose.app/slides/id/collage/jpg) atau gambar PNG, atau [membuat grid foto](https://products.aspose.app/slides/id/collage/photo-grid), Anda dapat menggunakan layanan ini.
{{% /alert %}}

## **Tambahkan Gambar sebagai Tautan**

Untuk menjaga ukuran file presentasi tetap kecil, Anda dapat menambahkan gambar atau video melalui tautan alih-alih menyematkan file secara langsung dalam presentasi. Kode Python berikut menunjukkan cara menyisipkan gambar dan video ke dalam placeholder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Pangkas Gambar**

Di bagian ini, Anda akan belajar cara memangkas area tampilan gambar dalam bingkai gambar tanpa mengubah file sumber. Anda juga akan mempelajari metode dasar untuk menerapkan margin pemotongan guna menciptakan komposisi yang bersih dan fokus langsung pada slide.

Kode Python berikut menunjukkan cara memangkas gambar pada slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Tambahkan gambar ke koleksi gambar presentasi.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Tambahkan bingkai gambar ke slide.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Potong gambar (nilai persentase).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Simpan hasil.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Hapus Area Gambar yang Dipangkas**

Jika Anda ingin menghapus area yang dipangkas dari gambar dalam sebuah bingkai, gunakan metode [delete_picture_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Metode ini mengembalikan gambar yang telah dipangkas, atau gambar asli jika tidak ada pemotongan yang diperlukan.

Kode Python berikut mendemonstrasikan operasi tersebut:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Dapatkan PictureFrame dari slide pertama.
    picture_frame = slides.shape[0]

    # Dapatkan PictureFrame dari slide pertama.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Simpan hasil.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metode [delete_picture_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) menambahkan gambar yang dipangkas ke koleksi gambar presentasi. Jika gambar tersebut hanya digunakan dalam [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) yang diproses, hal ini dapat mengurangi ukuran presentasi; sebaliknya, jumlah gambar dalam presentasi yang dihasilkan dapat meningkat.

Selama pemotongan, metode ini mengonversi file metafile WMF/EMF menjadi gambar PNG raster.
{{% /alert %}}

## **Kompres Gambar**

Anda dapat mengompres gambar dalam presentasi menggunakan metode [PictureFillFormat.compress_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/compress_image/). Metode ini mengompres gambar dengan mengurangi ukurannya berdasarkan ukuran bentuk dan resolusi yang ditentukan, dengan opsi untuk menghapus area yang dipangkas.

Metode ini menyesuaikan ukuran dan resolusi gambar mirip dengan fitur **Picture Format -> Compress Pictures -> Resolution** di PowerPoint.

Contoh Python berikut mendemonstrasikan cara mengompres gambar dalam presentasi dengan menentukan resolusi target dan secara opsional menghapus area yang dipangkas:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Kompres gambar dengan resolusi target 150 DPI (resolusi Web) dan hapus area yang dipangkas.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Periksa hasil kompresi.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Atau dengan menggunakan nilai DPI khusus secara langsung:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Kompres gambar ke 150 DPI (resolusi web), menghapus area yang dipangkas.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Metode ini mengonversi gambar ke resolusi lebih rendah berdasarkan ukuran bentuk dan DPI yang diberikan. Daerah yang dipangkas juga dapat dihapus untuk mengoptimalkan ukuran file. Jika gambar adalah metafile (WMF/EMF) atau SVG, kompresi tidak akan diterapkan. Selain itu, kualitas JPEG dipertahankan atau sedikit dikurangi berdasarkan resolusi, mirip dengan cara PowerPoint menangani JPEG beresolusi tinggi.
{{% /alert %}}

## **Kunci Rasio Aspek**

Jika Anda menginginkan sebuah bentuk yang berisi gambar tetap mempertahankan rasio aspeknya setelah Anda mengubah dimensi gambar, atur properti [aspect_ratio_locked](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) menjadi `True`.

Kode Python berikut menunjukkan cara mengunci rasio aspek sebuah bentuk:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Kunci rasio aspek saat mengubah ukuran.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Pengaturan *Lock Aspect Ratio* ini hanya mempertahankan rasio aspek bentuk, bukan rasio aspek gambar di dalamnya.
{{% /alert %}}

## **Gunakan Properti Stretch Offset**

Dengan menggunakan properti `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right`, dan `stretch_offset_bottom` dari kelas [PictureFillFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/), Anda dapat mendefinisikan persegi panjang pengisian.

Saat peregangan ditentukan untuk sebuah gambar, persegi panjang sumber diskalakan agar sesuai dengan persegi panjang pengisian. Setiap tepi persegi panjang pengisian didefinisikan oleh offset persentase dari tepi yang bersesuaian pada kotak pembatas bentuk. Persentase positif menunjukkan inset, sementara persentase negatif menunjukkan outset.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Dapatkan referensi ke slide berdasarkan indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang.
4. Atur tipe isi bentuk.
5. Atur mode isi gambar bentuk.
6. Muat sebuah gambar.
7. Tetapkan gambar untuk mengisi bentuk.
8. Tentukan offset gambar dari tepi yang bersesuaian pada kotak pembatas bentuk.
9. Simpan presentasi sebagai file PPTX.

Kode Python berikut mendemonstrasikan cara menggunakan properti Stretch Offset:

```py
import aspose.slides as slides

# Instansiasikan kelas Presentation yang mewakili file PPTX.
with slides.Presentation() as presentation:
    # Dapatkan slide pertama.
    slide = presentation.slides[0]

    # Tambahkan AutoShape persegi panjang.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Atur tipe isi bentuk.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Atur mode isi gambar bentuk.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Muat gambar dan tambahkan ke presentasi.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Tetapkan gambar untuk mengisi bentuk.
    shape.fill_format.picture_fill_format.picture.image = image

    # Tentukan offset gambar dari tepi yang bersesuaian pada kotak pembatas bentuk.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Simpan file PPTX ke disk.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose menyediakan konverter gratis—[JPEG to PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG to PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan Anda dengan cepat membuat presentasi dari gambar.
{{% /alert %}}

## **FAQ**

**Bagaimana saya dapat mengetahui format gambar apa yang didukung untuk PictureFrame?**

Aspose.Slides mendukung baik gambar raster (PNG, JPEG, BMP, GIF, dll.) maupun gambar vektor (misalnya SVG) melalui objek gambar yang ditetapkan ke sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/). Daftar format yang didukung umumnya tumpang tindih dengan kemampuan mesin konversi slide dan gambar.

**Bagaimana penambahan puluhan gambar besar memengaruhi ukuran dan kinerja PPTX?**

Menyematkan gambar besar meningkatkan ukuran file dan penggunaan memori; menautkan gambar membantu menjaga ukuran presentasi tetap kecil namun mengharuskan file eksternal tetap dapat diakses. Aspose.Slides menyediakan kemampuan menambahkan gambar melalui tautan untuk mengurangi ukuran file.

**Bagaimana saya dapat mengunci objek gambar agar tidak secara tidak sengaja dipindahkan/diresize?**

Gunakan [shape locks](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/picture_frame_lock/) untuk sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) (misalnya, menonaktifkan pemindahan atau perubahan ukuran). Mekanisme penguncian dijelaskan untuk bentuk dalam artikel [protection article](/slides/id/python-net/applying-protection-to-presentation/) terpisah dan didukung untuk berbagai tipe bentuk, termasuk [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/).

**Apakah fidelitas vektor SVG dipertahankan saat mengekspor presentasi ke PDF/gambar?**

Aspose.Slides memungkinkan mengekstrak SVG dari sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/pictureframe/) sebagai vektor asli. Saat [mengeksport ke PDF](/slides/id/python-net/convert-powerpoint-to-pdf/) atau ke [format raster](/slides/id/python-net/convert-powerpoint-to-png/), hasilnya mungkin dirasterisasi tergantung pada pengaturan ekspor; fakta bahwa SVG asli disimpan sebagai vektor dikonfirmasi oleh perilaku ekstraksi.