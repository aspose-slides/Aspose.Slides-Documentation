---
title: "Mengonversi Slide Presentasi menjadi Gambar dalam Python"
linktitle: "Slide ke Gambar"
type: docs
weight: 41
url: /id/python-net/convert-slide/
keywords:
- konversi slide
- ekspor slide
- slide ke gambar
- simpan slide sebagai gambar
- slide ke EMF
- slide ke PNG
- slide ke JPEG
- slide ke bitmap
- slide ke TIFF
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Mengonversi slide dari presentasi PPT, PPTX, dan ODP ke PNG, JPEG, GIF, TIFF, EMF, dan format gambar lainnya dalam Python dengan Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET dapat merender slide individual dari presentasi PowerPoint dan OpenDocument sebagai PNG, JPEG, GIF, TIFF, dan format gambar lainnya.

Untuk mengonversi slide menjadi gambar, ikuti langkah-langkah berikut:

1. Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Pilih slide yang ingin Anda render.
3. Jika diperlukan, konfigurasikan rendering dengan kelas [RenderingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/) atau [TiffOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/).
4. Panggil metode [Slide.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/). Metode ini mengembalikan objek [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/).
5. Panggil metode [IImage.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/save/) dan tentukan format output dengan nilai [ImageFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/imageformat/).

## **Mengonversi Slide ke Gambar PNG**

Konversi paling sederhana menggunakan pengaturan rendering default. Objek [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) yang dihasilkan dapat diproses dalam memori atau disimpan ke file.

Contoh Python berikut merender slide pertama dan menyimpannya sebagai gambar PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Mengonversi Slide ke Gambar dengan Ukuran Kustom**

Gunakan overload [Slide.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) yang menerima nilai [Size](https://reference.aspose.com/slides/id/python-net/aspose.pydrawing/size/) untuk merender slide dengan dimensi piksel yang tepat.

Contoh berikut membuat gambar JPEG 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Mengonversi Slide dengan Catatan dan Komentar menjadi Gambar**

Secara default, gambar slide tidak menyertakan catatan atau komentar. Tetapkan objek [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/) ke properti [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) untuk mengontrol di mana catatan dan komentar muncul.

Contoh berikut menempatkan catatan yang dipotong di bawah slide dan komentar di sebelah kanannya:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Untuk konversi slide ke gambar, jangan set properti [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) ke [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notespositions/). Catatan dapat berisi lebih banyak teks daripada ukuran gambar tetap yang dapat menampungnya. Gunakan [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/notespositions/) sebagai gantinya.
{{% /alert %}}

## **Mengonversi Slide ke Gambar Menggunakan Opsi TIFF**

Kelas [TiffOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/) memungkinkan Anda mengontrol ukuran, resolusi, dan properti lainnya dari gambar TIFF yang dirender.

Contoh berikut merender slide pertama sebagai gambar TIFF 2160 × 2880 pada 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Mengonversi Semua Slide ke Gambar**

Iterasi melalui koleksi slide untuk mengonversi seluruh presentasi menjadi serangkaian gambar. Slide tersembunyi disertakan kecuali Anda secara eksplisit melewatinya.

Contoh berikut merender setiap slide sebagai gambar JPEG dengan faktor skala horizontal dan vertikal sebesar 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Membuat Output Metafile Ditingkatkan**

Enhanced Metafile (EMF) berguna ketika grafik berbasis vektor harus dipertukarkan dengan Microsoft Office atau aplikasi Windows lainnya yang mendukung metafile Windows. Tidak seperti gambar berbasis piksel, EMF dapat mempertahankan operasi gambar vektor yang dapat diskalakan tanpa kehilangan ketajaman yang sama. Namun, EMF terutama merupakan format kompatibilitas untuk aplikasi dengan dukungan metafile Windows, bukan format pertukaran universal. Selain itu, konten slide yang kompleks, seperti gambar bitmap dan beberapa efek, dapat disimpan sebagai elemen raster di dalam kontainer metafile vektor.

### **Ekspor Slide ke EMF**

Metode [Slide.write_as_emf](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/write_as_emf/) menulis Slide ke aliran target dalam format EMF. Contoh berikut memuat presentasi, memilih slide pertama, dan menulisnya ke aliran file EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Pemanggil memiliki aliran yang diberikan ke [Slide.write_as_emf](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/write_as_emf/) dan harus menutupnya. Aspose.Slides menulis pada posisi aliran saat ini dan membiarkan aliran tetap terbuka.

### **Mengonversi Gambar SVG ke EMF dan Menambahkannya ke Presentasi**

Gunakan [SvgImage.write_as_emf](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/write_as_emf/) untuk mengonversi konten SVG ke EMF. Byte yang dihasilkan dapat ditambahkan ke presentasi melalui [ImageCollection.add_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/add_image/) dan ditempatkan pada slide dengan [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/).

Contoh berikut membuat [SvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/) dari markup SVG, mengonversinya menjadi EMF dalam memori, menyisipkan metafile pada slide pertama, dan menyimpan presentasi:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/write_as_emf/) tidak mengambil kepemilikan aliran tujuan. Setelah menulis, posisi aliran berada di akhir data yang dihasilkan. Panggil `getvalue` untuk mendapatkan buffer lengkap terlepas dari posisi aliran saat ini, seperti ditunjukkan di atas. Jaga aliran tetap terbuka sampai data dibaca, dan tutup setelahnya.

Pembuatan EMF tersedia pada sistem operasi yang didukung oleh Aspose.Slides for Python via .NET, tetapi rendering dapat berbeda antar platform ketika font atau dependensi grafis native tidak tersedia. Instal font yang digunakan oleh konten sumber atau konfigurasikan substitusi yang sesuai, ikuti [platform requirements](/slides/id/python-net/system-requirements/) untuk Aspose.Slides, dan validasi hasilnya di aplikasi target yang mengonsumsi EMF. Aplikasi Linux dan macOS sering memiliki dukungan terbatas atau tidak konsisten untuk menampilkan dan mengedit metafile Windows.

## **Rendering Emoji Berwarna**

{{% alert title="Note" color="info" %}}
Untuk merender emoji berwarna dengan benar saat mengonversi slide presentasi menjadi gambar, font emoji yang digunakan dalam presentasi harus diinstal dan tersedia pada sistem yang melakukan konversi. Misalnya, jika presentasi menggunakan **Segoe UI Emoji** dan font ini tidak ada, emoji dapat muncul dalam monokrom pada gambar output.
{{% /alert %}}

## **FAQ**

**Apakah Aspose.Slides mendukung rendering slide dengan animasi?**

Tidak. Metode [Slide.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/) merender gambar statis dari slide dan tidak mengekspor animasi.

**Apakah slide tersembunyi dapat diekspor sebagai gambar?**

Ya. Slide tersembunyi dapat dirender seperti slide biasa. Sertakan mereka dalam loop pemrosesan, seperti yang ditunjukkan pada contoh di atas.

**Apakah bayangan dan efek lain dipertahankan dalam gambar slide?**

Ya. Aspose.Slides merender bayangan, transparansi, dan efek grafis lain yang didukung dalam gambar slide.