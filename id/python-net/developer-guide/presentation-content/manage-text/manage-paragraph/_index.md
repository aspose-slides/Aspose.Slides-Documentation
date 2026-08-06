---
title: Kelola Paragraf Teks PowerPoint dalam Python
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- menambah teks
- menambah paragraf
- mengelola teks
- mengelola paragraf
- mengelola bullet
- indentasi paragraf
- indentasi gantung
- bullet paragraf
- daftar bernomor
- daftar bullet
- properti paragraf
- impor HTML
- teks ke HTML
- paragraf ke HTML
- paragraf ke gambar
- teks ke gambar
- ekspor paragraf
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kuasi pemformatan paragraf dengan Aspose.Slides untuk Python via .NET—optimalkan perataan, spasi & gaya dalam presentasi PowerPowerPoint dan OpenDocument di Python untuk menarik perhatian pemirsa."
---
## **Pendahuluan**

Aspose.Slides menyediakan kelas-kelas yang Anda butuhkan untuk bekerja dengan teks PowerPoint di Python.

* Aspose.Slides menyediakan kelas [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) untuk membuat objek kotak teks. Sebuah objek `TextFrame` dapat berisi satu atau beberapa paragraf (setiap paragraf dipisahkan oleh karakter kembali ke baris).
* Aspose.Slides menyediakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) untuk membuat objek paragraf. Sebuah objek `Paragraph` dapat berisi satu atau beberapa bagian teks.
* Aspose.Slides menyediakan kelas [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) untuk membuat objek bagian teks dan menentukan properti formatnya.

Objek `Paragraph` dapat menangani teks dengan properti format yang berbeda melalui objek `Portion` yang mendasarinya.

## **Instalasi**

```bash
pip install aspose.slides
```

## **Menambahkan Beberapa Paragraf yang Berisi Beberapa Bagian**

Langkah-langkah ini menunjukkan cara menambahkan kotak teks yang berisi tiga paragraf, masing-masing dengan tiga bagian:

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide target berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang ke slide.
1. Dapatkan [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).
1. Buat dua objek [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan tambahkan ke koleksi paragraf dari [TextFrame] (bersama dengan paragraf default, menghasilkan tiga paragraf).
1. Untuk setiap paragraf, buat tiga objek [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) dan tambahkan ke koleksi bagian paragraf tersebut.
1. Setel teks untuk setiap bagian.
1. Terapkan format yang diinginkan pada setiap bagian teks menggunakan properti yang disediakan oleh [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/).
1. Simpan presentasi yang telah dimodifikasi.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Membuat instance kelas Presentation untuk membuat file PPTX baru.
with slides.Presentation() as presentation:

    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tambahkan AutoShape berbentuk persegi panjang.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Akses TextFrame AutoShape.
    text_frame = shape.text_frame

    # Buat paragraf dan bagian; pemformatan diterapkan di bawah.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # Simpan PPTX ke disk.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengelola Bullet Paragraf**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Paragraf ber-bullet seringkali lebih mudah dibaca dan dipahami.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide target berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape tersebut.
1. Hapus paragraf default dari [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Buat paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/).
1. Setel tipe bullet paragraf menjadi `SYMBOL` dan tentukan karakter bullet.
1. Setel teks paragraf.
1. Setel indent bullet untuk paragraf.
1. Setel warna bullet.
1. Setel ukuran bullet (tinggi).
1. Tambahkan paragraf ke koleksi paragraf [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Tambahkan paragraf kedua dan ulangi langkah 7–12.
1. Simpan presentasi.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Buat sebuah instance presentasi.
with slides.Presentation() as presentation:

    # Akses slide pertama.
    slide = presentation.slides[0]

    # Tambahkan dan akses sebuah AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Akses text frame dari AutoShape yang dibuat.
    text_frame = shape.text_frame

    # Hapus paragraf default.
    text_frame.paragraphs.remove_at(0)

    # Buat sebuah paragraf.
    paragraph = slides.Paragraph()

    # Setel gaya bullet paragraf dan simbolnya.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # Setel teks paragraf.
    paragraph.text = "Welcome to Aspose.Slides"

    # Setel indent bullet.
    paragraph.paragraph_format.indent = 25

    # Setel warna bullet.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Setel tinggi bullet.
    paragraph.paragraph_format.bullet.height = 100

    # Tambahkan paragraf ke text frame.
    text_frame.paragraphs.add(paragraph)

    # Buat paragraf kedua.
    paragraph2 = slides.Paragraph()

    # Setel tipe dan gaya bullet paragraf.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # Setel teks paragraf.
    paragraph2.text = "This is numbered bullet"

    # Setel indent bullet.
    paragraph2.paragraph_format.indent = 25

    # Setel warna bullet.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # Setel tinggi bullet.
    paragraph2.paragraph_format.bullet.height = 100

    # Tambahkan paragraf ke text frame.
    text_frame.paragraphs.add(paragraph2)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengelola Bullet Gambar**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet gambar mudah dibaca dan dipahami.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide target berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape tersebut.
1. Hapus paragraf default dari [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Buat sebuah paragraf menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan setel teksnya.
1. Muat gambar dan tambahkan ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/).
1. Setel tipe bullet menjadi `PICTURE` dan tetapkan [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/) ke bullet.
1. Setel tinggi bullet.
1. Tambahkan paragraf baru ke koleksi paragraf [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Simpan presentasi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Akses slide pertama.
    slide = presentation.slides[0]

    # Muat gambar bullet.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # Tambahkan dan akses sebuah AutoShape.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Akses TextFrame dari AutoShape yang dibuat.
    text_frame = auto_shape.text_frame

    # Hapus paragraf default.
    text_frame.paragraphs.remove_at(0)

    # Buat paragraf baru.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # Setel tipe bullet paragraf menjadi Picture dan tetapkan gambar.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # Setel tinggi bullet.
    paragraph.paragraph_format.bullet.height = 100

    # Tambahkan paragraf ke text frame.
    text_frame.paragraphs.add(paragraph)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # Simpan presentasi sebagai file PPT.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Mengelola Bullet Bertingkat**

Daftar bullet membantu Anda mengatur dan menyajikan informasi dengan cepat dan efisien. Bullet bertingkat mudah dibaca dan dipahami.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide target berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) dari [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).
1. Hapus paragraf default dari [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Buat paragraf pertama menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan setel kedalamannya ke 0.
1. Buat paragraf kedua menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan setel kedalamannya ke 1.
1. Buat paragraf ketiga menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan setel kedalamannya ke 2.
1. Buat paragraf keempat menggunakan kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan setel kedalamannya ke 3.
1. Tambahkan paragraf baru ke koleksi paragraf [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Simpan presentasi.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Buat sebuah instance presentasi.
with slides.Presentation() as presentation:

    # Akses slide pertama.
    slide = presentation.slides[0]
    
    # Tambahkan sebuah AutoShape.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Akses TextFrame dari AutoShape yang dibuat.
    text_frame = shape.text_frame
    
    # Hapus paragraf default.
    text_frame.paragraphs.clear()

    # Tambahkan paragraf pertama.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setel level bullet.
    paragraph1.paragraph_format.depth = 0

    # Tambahkan paragraf kedua.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setel level bullet.
    paragraph2.paragraph_format.depth = 1

    # Tambahkan paragraf ketiga.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setel level bullet.
    paragraph3.paragraph_format.depth = 2

    # Tambahkan paragraf keempat.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # Setel level bullet.
    paragraph4.paragraph_format.depth = 3

    # Tambahkan paragraf ke koleksi.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # Simpan presentasi sebagai file PPTX.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengelola Paragraf dengan Daftar Nomor Kustom**

Kelas [BulletFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/) menyediakan properti `numbered_bullet_start_with` (dan lainnya) untuk mengontrol penomoran dan format kustom pada paragraf.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide yang akan berisi paragraf-paragraf tersebut.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape tersebut.
1. Hapus paragraf default dari [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Buat [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) pertama dan setel `numbered_bullet_start_with` ke 2.
1. Buat [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) kedua dan setel `numbered_bullet_start_with` ke 3.
1. Buat [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) ketiga dan setel `numbered_bullet_start_with` ke 7.
1. Tambahkan paragraf-paragraf ke koleksi [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Simpan presentasi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Tambahkan dan akses sebuah AutoShape.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # Akses TextFrame dari AutoShape yang dibuat.
    text_frame = shape.text_frame

    # Hapus paragraf default yang ada.
    text_frame.paragraphs.remove_at(0)

    # Buat item bernomor pertama (mulai dari 2, tingkat kedalaman 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # Buat item bernomor kedua (mulai dari 3, tingkat kedalaman 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # Buat item bernomor ketiga (mulai dari 7, tingkat kedalaman 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Inden Baris Pertama untuk Paragraf**

Gunakan properti [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) untuk mengontrol inden baris pertama suatu paragraf. Properti ini memindahkan hanya baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris lainnya tetap rata dengan badan paragraf.

Gunakan [ParagraphFormat.margin_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/margin_left/) saat Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) saat Anda hanya ingin memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai `indent` yang berbeda untuk menunjukkan bagaimana inden baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat beberapa paragraf dan setel nilai [indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) yang berbeda untuk masing-masing.
6. Tambahkan paragraf ke kotak teks.
7. Simpan presentasi yang telah dimodifikasi.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Indent baris pertama dari paragraf](first_line_indent.png)

## **Mengatur Inden Gantung untuk Paragraf**

Inden gantung adalah tata letak paragraf di mana baris pertama dimulai lebih ke kiri daripada baris-baris berikutnya. Di Aspose.Slides, Anda membuat efek ini dengan properti [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/). Setel `indent` ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktik, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/margin_left/) menentukan posisi kiri badan paragraf, dan [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat inden gantung, setel nilai `margin_left` positif dan nilai `indent` negatif.

Format ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus sejajar di bawah badan paragraf, bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang ke slide.
4. Tambahkan sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) kosong ke shape dan hapus paragraf default.
5. Buat paragraf dan setel nilai [margin_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/margin_left/) positif untuk setiap paragraf.
6. Setel nilai [indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) negatif untuk menciptakan efek inden gantung.
7. Tambahkan paragraf ke kotak teks.
8. Simpan presentasi yang telah dimodifikasi.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Hasil:

![Inden gantung dari paragraf](hanging_indent.png)

## **Mengelola Format Bagian Akhir Paragraf**

Saat Anda perlu mengontrol gaya “akhir” sebuah paragraf (format yang diterapkan setelah bagian teks terakhir), gunakan properti `end_paragraph_portion_format`. Contoh di bawah ini menerapkan font Times New Roman berukuran lebih besar pada akhir paragraf kedua.

1. Buat atau buka file [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan slide target berdasarkan indeks.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang ke slide.
1. Gunakan [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape dan buat dua paragraf.
1. Buat [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/) dengan ukuran 48 pt Times New Roman dan terapkan sebagai format bagian akhir paragraf.
1. Tetapkan ke `end_paragraph_portion_format` paragraf (berlaku pada akhir paragraf kedua).
1. Tulis presentasi yang telah dimodifikasi sebagai file PPTX.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# Hapus paragraf default.
	shape.text_frame.paragraphs.clear()

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengimpor Teks HTML ke dalam Paragraf**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengimpor teks HTML ke dalam paragraf.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Akses slide target berdasarkan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide.
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) dari [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).
1. Hapus paragraf default dari [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Baca file HTML sumber.
1. Tambahkan konten HTML ke koleksi paragraf [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/).
1. Simpan presentasi yang telah dimodifikasi.

```python
import aspose.slides as slides

# Buat sebuah instance Presentation kosong.
with slides.Presentation() as presentation:

    # Akses slide pertama dari presentasi.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # Tambahkan AutoShape untuk menampung konten HTML.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Hapus semua paragraf di text frame yang ditambahkan.
    shape.text_frame.paragraphs.clear()

    # Muat file HTML.
    with open("file.html", "rt") as html_stream:
        # Tambahkan teks dari file HTML ke text frame.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # Simpan presentasi.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengekspor Teks Paragraf ke HTML**

Aspose.Slides menyediakan dukungan yang ditingkatkan untuk mengekspor teks ke HTML.

1. Buat sebuah instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi target.
1. Akses slide yang diinginkan berdasarkan indeksnya.
1. Pilih shape yang berisi teks yang akan diekspor.
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) shape tersebut.
1. Buka aliran file untuk menulis output HTML.
1. Tentukan indeks mulai dan ekspor paragraf yang diperlukan.

```python
import aspose.slides as slides

# Muat file presentasi.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Akses slide pertama dari presentasi.
    slide = presentation.slides[0]

    # Indeks shape target.
    index = 0

    # Akses shape berdasarkan indeks.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Tulis data paragraf ke HTML dengan memberikan indeks paragraf mulai dan total jumlah paragraf yang akan diekspor.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Menyimpan Paragraf sebagai Gambar**

Pada bagian ini, kami akan menelusuri dua contoh yang menunjukkan cara menyimpan sebuah paragraf teks, yang direpresentasikan oleh kelas [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/), sebagai gambar. Kedua contoh mencakup memperoleh gambar shape yang berisi paragraf menggunakan metode `get_image` dari kelas [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/), menghitung batas paragraf di dalam shape, dan mengekspornya sebagai gambar bitmap. Pendekatan ini memungkinkan Anda mengekstrak bagian teks tertentu dari presentasi PowerPoint dan menyimpannya sebagai gambar terpisah, yang dapat berguna untuk penggunaan lebih lanjut dalam berbagai skenario.

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

**Contoh 1**

Pada contoh ini, kami memperoleh paragraf kedua sebagai gambar. Untuk melakukannya, kami mengekstrak gambar shape dari slide pertama presentasi, kemudian menghitung batas paragraf kedua dalam kotak teks shape. Paragraf kemudian digambar ulang ke gambar bitmap baru, yang disimpan dalam format PNG. Metode ini sangat berguna ketika Anda perlu menyimpan paragraf tertentu sebagai gambar terpisah sambil mempertahankan dimensi dan format teks yang tepat.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Simpan shape di memori sebagai bitmap.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Buat bitmap shape dari memori.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Hitung batas paragraf kedua.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Potong bitmap shape untuk mendapatkan bitmap paragraf saja.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Hasil:

![Gambar paragraf](paragraph_to_image_output.png)

**Contoh 2**

Pada contoh ini, kami memperluas pendekatan sebelumnya dengan menambahkan faktor skala ke gambar paragraf. Shape diekstrak dari presentasi dan disimpan sebagai gambar dengan faktor skala `2`. Hal ini memungkinkan output resolusi lebih tinggi saat mengekspor paragraf. Batas paragraf kemudian dihitung memperhitungkan skala. Skala dapat sangat berguna ketika diperlukan gambar yang lebih detail, misalnya untuk penggunaan dalam materi cetak kualitas tinggi.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Simpan shape di memori sebagai bitmap.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Buat bitmap shape dari memori.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Hitung batas paragraf kedua.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Hitung koordinat dan ukuran untuk gambar output (ukuran minimum - 1x1 piksel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Potong bitmap shape untuk mendapatkan bitmap paragraf saja.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **FAQ**

### Apakah saya dapat sepenuhnya menonaktifkan pembungkus baris di dalam kotak teks?

Ya. Gunakan pengaturan pembungkus kotak teks ([wrap_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/wrap_text/)) untuk mematikan pembungkus sehingga baris tidak akan terpotong di tepi kotak.

### Bagaimana saya dapat mendapatkan batas tepat pada slide dari paragraf tertentu?

Anda dapat mengambil persegi panjang pembatas paragraf (dan bahkan satu bagian) untuk mengetahui posisi dan ukuran tepatnya pada slide.

### Di mana kontrol perataan paragraf (kiri/kanan/tengah/justify) diatur?

[Alignment](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/alignment/) adalah pengaturan tingkat paragraf di [ParagraphFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/); ia berlaku untuk seluruh paragraf terlepas dari format bagian individu.

### Apakah saya dapat menetapkan bahasa pemeriksaan ejaan untuk hanya bagian dari paragraf (misalnya, satu kata)?

Ya. Bahasa diatur pada tingkat bagian ([PortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/language_id/)), sehingga beberapa bahasa dapat hidup berdampingan dalam satu paragraf.