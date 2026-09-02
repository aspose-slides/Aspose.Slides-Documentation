---
title: Kelola Paragraf Teks PowerPoint dengan Python
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
- kelola teks
- kelola paragraf
- kelola bullet
- inden paragraf
- inden gantung
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
description: "Pelajari cara membuat dan memformat paragraf, bagian, bullet, daftar bernomor, inden, konten HTML, serta gambar paragraf dengan Aspose.Slides untuk Python via .NET."
---
## **Ikhtisar**

Aspose.Slides for Python via .NET merepresentasikan teks sebagai hierarki bingkai teks, paragraf, dan bagian:

* [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) mewakili kontainer teks dalam sebuah bentuk dan menyediakan akses ke koleksi paragrafnya.
* [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) mewakili satu paragraf dalam sebuah bingkai teks dan menyediakan akses ke bagian-bagiannya serta pemformatan tingkat paragraf.
* [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) mewakili satu rangkaian teks dalam sebuah paragraf. Setiap bagian dapat memiliki teks dan pemformatan tingkat karakter yang berbeda.

Sebuah paragraf therefore dapat berisi teks dengan font, warna, ukuran, dan pemformatan lain yang berbeda dengan menggunakan beberapa bagian.

## **Membuat dan Memformat Paragraf**

### **Membuat Paragraf dengan Beberapa Bagian**

Langkah-langkah berikut membuat bingkai teks dengan tiga paragraf, masing-masing berisi tiga bagian:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) berbentuk persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) bentuk tersebut.
5. Gunakan paragraf bawaan dan tambahkan dua objek [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) lagi ke bingkai teks.
6. Tambahkan cukup objek [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) untuk setiap paragraf agar berisi tiga bagian. Paragraf bawaan sudah berisi satu bagian kosong.
7. Atur teks untuk setiap bagian.
8. Terapkan pemformatan tingkat karakter melalui [Portion.portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/portion_format/).
9. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut mengimplementasikan langkah-langkah tersebut:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)
    text_frame = shape.text_frame

    first_paragraph = text_frame.paragraphs[0]
    first_paragraph.portions.add(slides.Portion())
    first_paragraph.portions.add(slides.Portion())

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    second_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    third_paragraph.portions.add(slides.Portion())
    text_frame.paragraphs.add(third_paragraph)

    for paragraph_index in range(text_frame.paragraphs.count):
        paragraph = text_frame.paragraphs[paragraph_index]
        for portion_index in range(paragraph.portions.count):
            portion = paragraph.portions[portion_index]
            portion.text = f"Portion {paragraph_index + 1}.{portion_index + 1}"

            if portion_index == 0:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.red
                portion.portion_format.font_bold = slides.NullableBool.TRUE
                portion.portion_format.font_height = 15
            elif portion_index == 1:
                portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
                portion.portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                portion.portion_format.font_italic = slides.NullableBool.TRUE
                portion.portion_format.font_height = 18

    presentation.save("paragraphs_with_portions.pptx", slides.export.SaveFormat.PPTX)
```

## **Membuat Daftar Berbentuk Bullet dan Bernomor**

### **Membuat Daftar Bullet atau Bernomor**

Bullet dan penomoran membuat item terkait lebih mudah dipindai. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [BulletFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/).

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) bentuk tersebut.
5. Hapus paragraf bawaan dari bingkai teks.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) untuk bullet simbol.
7. Atur [BulletFormat.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/type/) menjadi [BulletType.SYMBOL](https://reference.aspose.com/slides/id/python-net/aspose.slides/bullettype/) dan tentukan karakter bullet.
8. Atur teks paragraf, indent, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke bingkai teks.
10. Buat paragraf kedua dan atur [BulletFormat.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/type/) menjadi [BulletType.NUMBERED](https://reference.aspose.com/slides/id/python-net/aspose.slides/bullettype/).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke bingkai teks.
12. Simpan presentasi.

Contoh Python berikut membuat bullet simbol dan bullet bernomor:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    symbol_paragraph = slides.Paragraph()
    symbol_paragraph.text = "Welcome to Aspose.Slides"
    symbol_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    symbol_paragraph.paragraph_format.bullet.char = chr(0x2022)
    symbol_paragraph.paragraph_format.indent = 25
    symbol_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    symbol_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    symbol_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    symbol_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(symbol_paragraph)

    numbered_paragraph = slides.Paragraph()
    numbered_paragraph.text = "This is a numbered item"
    numbered_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    numbered_paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN
    numbered_paragraph.paragraph_format.indent = 25
    numbered_paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    numbered_paragraph.paragraph_format.bullet.color.color = draw.Color.black
    numbered_paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    numbered_paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(numbered_paragraph)

    presentation.save("bulleted_and_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Gunakan Bullet Gambar**

Bullet gambar memungkinkan Anda menggunakan gambar khusus alih-alih simbol atau nomor.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dan akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/)‑nya.
4. Hapus paragraf bawaan dari bingkai teks.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/).
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dan atur teksnya.
7. Atur [BulletFormat.type](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/type/) menjadi [BulletType.PICTURE](https://reference.aspose.com/slides/id/python-net/aspose.slides/bullettype/).
8. Tetapkan gambar melalui [BulletFormat.picture](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/picture/) dan atur tinggi bullet.
9. Tambahkan paragraf ke bingkai teks.
10. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut membuat bullet gambar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("bullets.png") as bullet_image:
        presentation_image = presentation.images.add_image(bullet_image)

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = presentation_image
    paragraph.paragraph_format.bullet.height = 100
    text_frame.paragraphs.add(paragraph)

    presentation.save("picture_bullet.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("picture_bullet.ppt", slides.export.SaveFormat.PPT)
```

### **Buat Daftar Bertingkat**

Atur [ParagraphFormat.depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/depth/) untuk menempatkan paragraf pada level yang berbeda dalam sebuah daftar. Level teratas memiliki depth `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dan bersihkan paragraf bawaan dari bingkai teksnya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Atur nilai [ParagraphFormat.depth](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/depth/) mereka menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf ke bingkai teks dan simpan presentasi.

Contoh Python berikut membuat daftar bullet empat level:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Content"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    first_paragraph.paragraph_format.bullet.char = chr(0x2022)
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.depth = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Second level"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    second_paragraph.paragraph_format.bullet.char = "-"
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.depth = 1

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Third level"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    third_paragraph.paragraph_format.bullet.char = chr(0x2022)
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.depth = 2

    fourth_paragraph = slides.Paragraph()
    fourth_paragraph.text = "Fourth level"
    fourth_paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    fourth_paragraph.paragraph_format.bullet.char = "-"
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    fourth_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    fourth_paragraph.paragraph_format.depth = 3

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)
    text_frame.paragraphs.add(fourth_paragraph)

    presentation.save("multilevel_list.pptx", slides.export.SaveFormat.PPTX)
```

### **Mulai Item Daftar Bernomor dengan Nilai Kustom**

Gunakan [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) untuk mengatur nomor awal yang ditampilkan untuk paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) ke sebuah slide.
2. Bersihkan paragraf bawaan dari bingkai teks bentuk tersebut.
3. Buat tiga paragraf bernomor.
4. Atur [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/id/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) menjadi `2`, `3`, dan `7` untuk paragraf masing‑masing.
5. Tambahkan paragraf ke bingkai teks dan simpan presentasi.

Contoh Python berikut menetapkan nomor mulai kustom untuk setiap paragraf:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "Start at 2"
    first_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    first_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 2
    text_frame.paragraphs.add(first_paragraph)

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Start at 3"
    second_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    second_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 3
    text_frame.paragraphs.add(second_paragraph)

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "Start at 7"
    third_paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    third_paragraph.paragraph_format.bullet.numbered_bullet_start_with = 7
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("custom_numbered_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrol Tata Letak Paragraf dan Properti Akhir**

### **Atur Inden Baris Pertama**

Gunakan properti [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) untuk mengontrol inden baris pertama pada sebuah paragraf. Properti ini hanya memindahkan baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris lainnya tetap rata dengan badan paragraf.

Gunakan [ParagraphFormat.margin_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/margin_left/) bila Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) yang berbeda untuk menunjukkan bagaimana inden baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) bentuk tersebut dan hapus paragraf bawaan.
5. Buat beberapa paragraf dan atur nilai [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf ke bingkai teks.
7. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur inden paragraf:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 20
    first_paragraph.paragraph_format.indent = 0

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 20
    second_paragraph.paragraph_format.indent = 20

    third_paragraph = slides.Paragraph()
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.paragraph_format.margin_left = 20
    third_paragraph.paragraph_format.indent = 40

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Indent baris pertama dari paragraf](first_line_indent.png)

### **Atur Inden Gantung**

Inden gantung adalah tata letak paragraf di mana baris pertama dimulai di sebelah kiri baris‑baris berikutnya. Di Aspose.Slides, Anda menciptakan efek ini dengan properti [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/). Atur `indent` ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktik, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/margin_left/) menentukan posisi kiri badan paragraf, dan [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk menciptakan inden gantung, atur nilai `margin_left` positif dan `indent` negatif.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris‑baris yang dibungkus harus rata di bawah badan paragraf bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) bentuk tersebut dan hapus paragraf bawaan.
5. Buat paragraf dan atur nilai [ParagraphFormat.margin_left](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/margin_left/) yang positif untuk masing‑masing paragraf.
6. Atur nilai [ParagraphFormat.indent](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/indent/) yang negatif untuk menciptakan efek inden gantung.
7. Tambahkan paragraf ke bingkai teks.
8. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur inden gantung untuk sebuah paragraf:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = shape.text_frame
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.paragraph_format.margin_left = 40
    first_paragraph.paragraph_format.indent = -20

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.paragraph_format.margin_left = 60
    second_paragraph.paragraph_format.indent = -30

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Indent gantung dari paragraf](hanging_indent.png)

### **Atur Properti Jalankan Akhir Paragraf**

Properti [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) mengontrol pemformatan tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin ke tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) dan bersihkan paragraf bawaannya.
3. Buat dua paragraf dan tambahkan bagian‑bagian teks ke dalamnya.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Atur [PortionFormat.font_height](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/font_height/) dan [PortionFormat.latin_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/latin_font/).
6. Tetapkan format ke [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) dan simpan presentasi.

```python
import aspose.slides as slides

with slides.Presentation("Test.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)
    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    first_paragraph = slides.Paragraph()
    first_paragraph.portions.add(slides.Portion("Sample text"))

    second_paragraph = slides.Paragraph()
    second_paragraph.portions.add(slides.Portion("Sample text 2"))

    end_paragraph_format = slides.PortionFormat()
    end_paragraph_format.font_height = 48
    end_paragraph_format.latin_font = slides.FontData("Times New Roman")
    second_paragraph.end_paragraph_portion_format = end_paragraph_format

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("end_paragraph_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke dalam Paragraf**

Gunakan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphcollection/add_from_html/) untuk mengonversi markup HTML menjadi paragraf dan bagian dalam sebuah bingkai teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
2. Akses sebuah slide dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/).
3. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) bentuk tersebut dan bersihkan paragraf bawaannya.
4. Baca file HTML sumber.
5. Kirim string HTML ke [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphcollection/add_from_html/).
6. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut mengimpor HTML ke dalam bingkai teks:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape_width = presentation.slide_size.size.width - 20
    shape_height = presentation.slide_size.size.height - 20
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, shape_width, shape_height)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    with open("file.html", "r", encoding="utf-8") as html_stream:
        html = html_stream.read()

    shape.text_frame.paragraphs.add_from_html(html)
    presentation.save("html_text.pptx", slides.export.SaveFormat.PPTX)
```

### **Ekspor Teks Paragraf ke HTML**

Gunakan [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphcollection/export_to_html/) untuk mengekspor rentang paragraf tertentu sebagai HTML.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) yang berisi teks.
3. Akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) bentuk tersebut.
4. Panggil [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphcollection/export_to_html/) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

Contoh Python berikut mengekspor semua paragraf dari bentuk teks pertama:

```python
import aspose.slides as slides

with slides.Presentation("ExportingHTMLText.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None:
        paragraphs = shape.text_frame.paragraphs
        html = paragraphs.export_to_html(0, paragraphs.count, None)
        with open("paragraphs.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
    else:
        print("The first shape is not a text shape.")
```

### **Render Paragraf sebagai Gambar**

[Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) menyediakan metode `get_image` untuk merender paragraf individu secara langsung. Metode ini mengembalikan sebuah [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) yang dapat Anda simpan ke file atau aliran dengan [IImage.save](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/save/). Anda tidak perlu merender bentuk yang berisi atau memotong bitmap secara manual.

Metode `get_image` dapat mengembalikan `None` jika paragraf tidak ditemukan di koleksi induknya, tidak memiliki batas render yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpannya dan gunakan gambar yang dikembalikan sebagai context manager untuk melepaskan sumber dayanya.

#### **Render Paragraf pada Skala Default**

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana bentuk pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam bentuk teks biasa pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    if isinstance(shape, slides.AutoShape) and shape.text_frame is not None and shape.text_frame.paragraphs.count > 1:
        paragraph = shape.text_frame.paragraphs[1]
        paragraph_image = paragraph.get_image()

        if paragraph_image is not None:
            with paragraph_image:
                paragraph_image.save("paragraph.png", slides.ImageFormat.PNG)
        else:
            print("The paragraph could not be rendered.")
    else:
        print("The expected text shape or paragraph was not found.")
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

#### **Render Paragraf dalam Sel Tabel dengan Skala**

Berikan faktor skala horizontal dan vertikal ke `get_image` untuk mengontrol ukuran paragraf yang dirender. Contoh berikut membuat sebuah tabel, merender paragraf di sel pertamanya dengan lebar dan tinggi dua kali lipat skala default, dan menyimpan hasilnya sebagai gambar PNG:

```python
import aspose.slides as slides

scale_x = 2
scale_y = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(50, 50, [300], [80])
    paragraph = table.rows[0][0].text_frame.paragraphs[0]
    paragraph.text = "Text in a table cell"

    paragraph_image = paragraph.get_image(scale_x, scale_y)
    if paragraph_image is not None:
        with paragraph_image:
            paragraph_image.save("table_paragraph.png", slides.ImageFormat.PNG)
    else:
        print("The paragraph could not be rendered.")
```

Faktor skala `1` mempertahankan ukuran piksel default pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar dengan lebar dan tinggi kira‑kira dua kali dimensi default, menghasilkan empat kali lebih banyak piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output resolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran file. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara terpisah.

Merender seluruh bentuk dengan [Shape.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/) tetap berguna ketika output harus mencakup isi, border, atau konteks visual lain dari bentuk. Untuk gambar hanya paragraf, gunakan `Paragraph.get_image`.

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkusan baris di dalam sebuah TextFrame?**

Ya. Atur [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/wrap_text/) untuk menonaktifkan pembungkusan sehingga baris tidak terputus di tepi TextFrame.

**Bagaimana saya bisa mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Gunakan [Paragraph.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/get_rect/) untuk mengambil persegi panjang pembatas paragraf. [Portion.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/get_rect/) menyediakan batas untuk bagian individu.

**Di mana pengaturan perataan paragraf (kiri, kanan, tengah, atau justify) dikendalikan?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraphformat/alignment/) adalah pengaturan tingkat paragraf dan berlaku untuk seluruh paragraf terlepas dari pemformatan bagian individu.

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan untuk sebagian paragraf?**

Ya. Atur [PortionFormat.language_id](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/language_id/) untuk bagian individu, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.