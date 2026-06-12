---
title: Kelola Daftar Berpoin dan Bernomor dalam Presentasi dengan Python
linktitle: Kelola Daftar
type: docs
weight: 70
url: /id/python-net/manage-lists/
keywords:
- bullet
- daftar berpoin
- daftar bernomor
- bullet simbol
- bullet gambar
- bullet khusus
- daftar bertingkat
- buat bullet
- tambahkan bullet
- tambahkan daftar
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara membuat dan memformat daftar berpoin, bullet gambar, daftar bertingkat, dan daftar bernomor dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET."
---
## **Ikhtisar**

Aspose.Slides for Python via .NET memungkinkan Anda membuat dan memformat daftar berpoin dan bernomor dalam presentasi PowerPoint dan OpenDocument. Item daftar adalah paragraf yang pengaturan bullet‑nya dikendalikan melalui format paragrafnya.

Gunakan properti [Paragraph.paragraph_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/paragraph_format/) untuk mengakses pengaturan daftar tingkat paragraf. Titik masuk utama adalah [ParagraphFormat.bullet](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/bullet/), yang mengembalikan objek [BulletFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/). Dengan objek ini, Anda dapat mengatur tipe bullet, simbol, gambar, warna, ukuran, gaya penomoran, dan angka awal.

Artikel ini menunjukkan cara:

- membuat daftar berpoin dengan simbol khusus
- membuat bullet gambar
- membuat daftar bertingkat dengan mengatur kedalaman paragraf
- membuat daftar bernomor
- memeriksa dan mengubah pemformatan daftar dalam presentasi yang sudah ada

## **Buat Daftar Berpoin**

Untuk membuat daftar berpoin, tambahkan objek [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) ke dalam [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) dan setel [BulletFormat.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/type/) ke [BulletType.SYMBOL](https://reference.aspose.com/slides/id/python-net/aspose.slides/bullettype/). Selanjutnya Anda dapat menyetel [BulletFormat.char](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/color/), dan [BulletFormat.height](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/height/) untuk mengontrol tampilan bullet.

Kode Python berikut mendemonstrasikan cara membuat daftar berpoin dalam sebuah slide:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bullet simbol](symbol_bullets.png)

## **Buat Daftar Bernomor**

Gunakan daftar bernomor ketika urutan item penting. Setel [BulletFormat.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/type/) ke [BulletType.NUMBERED](https://reference.aspose.com/slides/id/python-net/aspose.slides/bullettype/). Anda juga dapat memilih format penomoran dengan [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/numbered_bullet_style/) atau menyetel [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) ketika daftar harus dimulai dari nilai selain 1.

Kode Python berikut menunjukkan cara membuat daftar bernomor dalam sebuah slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bullet bernomor](numbered_bullets.png)

## **Buat Bullet Gambar**

Aspose.Slides memungkinkan Anda mengganti simbol bullet standar dengan gambar. Bullet gambar paling cocok untuk gambar sederhana yang tetap dapat dibaca pada ukuran kecil, seperti ikon atau file PNG transparan kecil.

{{% alert color="primary" %}}
Idealnya, jika Anda berencana mengganti simbol bullet standar dengan gambar, sebaiknya pilih grafik sederhana dengan latar belakang transparan. Gambar semacam itu bekerja dengan baik sebagai simbol bullet khusus.
{{% /alert %}}

Untuk membuat bullet gambar, tambahkan gambar ke [Presentation.images](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/images/) dan tetapkan objek gambar yang dikembalikan ke [BulletFormat.picture](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/picture/). Setel [BulletFormat.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/type/) ke [BulletType.PICTURE](https://reference.aspose.com/slides/id/python-net/aspose.slides/bullettype/) sebelum menetapkan gambar.

Misalnya kita memiliki "image.png":

![Gambar untuk bullet](picture_for_bullets.png)

Kode Python berikut menunjukkan cara membuat bullet gambar dalam sebuah slide:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Bullet gambar](picture_bullets.png)

## **Buat Daftar Bertingkat**

Gunakan [ParagraphFormat.depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/depth/) untuk menempatkan item daftar pada level yang berbeda. Level 0 adalah level teratas, level 1 berada di bawahnya, dan seterusnya.

Kode Python berikut menunjukkan cara membuat daftar berpoin bertingkat:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Daftar bertingkat](multilevel_list.png)

## **Ubah Daftar yang Ada**

Untuk mengubah pemformatan daftar dalam presentasi yang sudah ada, akses paragraf target dan perbarui pengaturan [ParagraphFormat.bullet](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/bullet/)‑nya. Properti yang sama yang digunakan untuk membuat daftar dapat dipakai untuk memeriksa atau memodifikasi daftar yang dimuat dari file PPT, PPTX, atau ODP.

Kode Python berikut mengubah paragraf pertama dalam sebuah text frame agar menggunakan gaya daftar bernomor:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah daftar berpoin dan bernomor dapat diekspor ke PDF atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan daftar ketika format target mendukung tata letak teks dan fitur bullet yang bersangkutan.

**Apakah saya dapat mengedit daftar dalam presentasi yang sudah ada?**

Ya. Muat presentasi, akses paragraf target, periksa atau perbarui pengaturan [ParagraphFormat.bullet](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/bullet/), dan simpan presentasi.

**Apakah daftar dapat berisi teks non‑Latin?**

Ya. Teks item daftar dapat berisi karakter Unicode, sehingga Anda dapat membuat daftar dalam presentasi multibahasa. Pastikan font yang digunakan dalam presentasi mendukung karakter yang Anda perlukan.