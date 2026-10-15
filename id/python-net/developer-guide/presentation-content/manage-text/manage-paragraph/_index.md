---
title: Kelola Paragraf Teks PowerPoint di Python
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
- daftar bertanda
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
description: "Pelajari cara membuat dan memformat paragraf, bagian, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Aspose.Slides for Python via .NET merepresentasikan teks sebagai hierarki bingkai teks, paragraf, dan bagian:

* [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) merepresentasikan wadah teks dalam sebuah bentuk dan menyediakan akses ke koleksi paragrafnya.
* [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) merepresentasikan satu paragraf dalam bingkai teks dan menyediakan akses ke bagian‑bagian serta pemformatan tingkat paragraf.
* [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) merepresentasikan satu run teks dalam paragraf. Setiap bagian dapat memiliki teks dan pemformatan tingkat karakter masing‑masing.

Dengan demikian, sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan pemformatan lain yang berbeda dengan menggunakan beberapa bagian.

## **Buat dan Format Paragraf**

Buat paragraf dalam bingkai teks sebuah bentuk dan gunakan bagian untuk memformat run teks individual. Bagian ini menunjukkan cara menggabungkan beberapa bagian dalam setiap paragraf dan menerapkan warna, ukuran font, serta gaya yang berbeda.

### **Buat Paragraf dengan Beberapa Bagian**

Contoh Python berikut membuat tiga paragraf, masing‑masing berisi tiga run teks dalam koleksi [Paragraph.portions](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/portions/). Contoh ini menggunakan kembali paragraf default dan bagian kosongnya, kemudian menambahkan paragraf serta bagian yang tersisa. Pemformatan diterapkan melalui [Portion.portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/portion/portion_format/): bagian pertama dalam setiap paragraf berwarna merah, tebal, dan 15 poin; bagian kedua berwarna biru, miring, dan 18 poin. Bagian ketiga mempertahankan pemformatan defaultnya:

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

## **Buat Daftar Bertanda dan Bernomor**

Atur teks paragraf menjadi daftar dengan simbol, angka, atau gambar khusus. Contoh‑contoh dalam bagian ini mencakup pemformatan bullet, daftar berjenjang, dan nomor mulai khusus.

### **Buat Daftar Bertanda atau Bernomor**

Bullet dan penomoran memudahkan pemindaian item terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/).

Contoh Python ini menambahkan bullet simbol dan item bernomor ke bingkai teks yang sama. [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) memilih jenis bullet, sedangkan [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) menyediakan simbol dan [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) memilih gaya penomoran. Kedua item menggunakan bullet hitam dengan tinggi 100 % dan indentasi paragraf 25 poin:

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

Bullet gambar memungkinkan Anda menggunakan gambar khusus alih‑alih simbol atau angka.

Contoh ini memerlukan `bullets.png` di direktori kerja. Contoh Python ini menambahkan gambar ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) dan menggunakannya sebagai bullet paragraf. Ia menetapkan [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) untuk menggunakan bullet gambar dan mengaitkan gambar melalui [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/). [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) diatur ke 100 % untuk menyesuaikan ukuran bullet relatif terhadap teks paragraf:

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

### **Buat Daftar Berjenjang**

Setel [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) untuk menempatkan paragraf pada tingkat daftar yang berbeda. Tingkat atas memiliki kedalaman `0`.

Contoh Python ini menetapkan nilai [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) dari 0 hingga 3 untuk empat paragraf, menghasilkan hierarki dalam satu bingkai teks. Setiap paragraf menggunakan bullet simbol, dengan [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/) berganti‑ganti antara bullet bulat dan tanda hubung untuk membedakan tingkat yang berdekatan:

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

### **Mulai Item Daftar Bernomor dengan Nilai Khusus**

Gunakan [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) untuk mengatur nomor awal yang ditampilkan pada paragraf bernomor.

Contoh Python ini menetapkan [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) untuk menggunakan penomoran pada tiga paragraf dan menetapkan nilai [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) masing‑masing 2, 3, dan 7. Nilai awal dikonfigurasi secara terpisah untuk setiap paragraf, sehingga nomor yang ditampilkan dapat melompati nilai:

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

## **Kendalikan Tata Letak Paragraf dan Properti Akhir**

Sesuaikan margin dan indentasi paragraf untuk mengontrol posisi baris pertama dan baris yang dibungkus. Anda juga dapat memformat tanda akhir paragraf secara terpisah dari bagian‑bagian teks yang terlihat.

### **Setel Indentasi Baris Pertama**

Gunakan properti [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) untuk mengontrol indentasi baris pertama paragraf. Properti ini memindahkan hanya baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sementara baris‑baris berikutnya tetap sejajar dengan badan paragraf.

Gunakan [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) bila Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) bila Anda hanya ingin memindahkan baris pertama.

Contoh berikut memberi tiga paragraf margin kiri [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) yang sama sebesar 20 poin dan nilai [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) masing‑masing 0, 20, dan 40 poin. Baris pertama mulai pada offset yang semakin besar, sementara baris yang dibungkus mempertahankan margin kiri yang sama:

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

![Indentasi baris pertama dari paragraf](first_line_indent.png)

### **Setel Indentasi Gantung**

Indentasi gantung adalah tata letak paragraf di mana baris pertama mulai di kiri baris‑baris berikutnya. Di Aspose.Slides, Anda membuat efek ini dengan properti [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/). Tetapkan `indent` ke nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktik, [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) menentukan posisi kiri badan paragraf, dan [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indentasi gantung, tetapkan nilai `margin_left` positif dan nilai `indent` negatif.

Pemformatan ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus sejajar di bawah badan paragraf, bukan di bawah karakter pertama baris pertama.

Contoh Python berikut memadukan nilai [ParagraphFormat.margin_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_left/) sebesar 40 dan 60 poin dengan nilai [ParagraphFormat.indent](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/indent/) masing‑masing -20 dan -30 poin. Pada setiap paragraf, baris pertama mulai di kiri baris yang dibungkus; paragraf kedua memiliki indentasi gantung yang lebih dalam:

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

![Indentasi gantung dari paragraf](hanging_indent.png)

### **Setel Properti Run Akhir Paragraf**

Properti [Paragraph.end_paragraph_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/end_paragraph_portion_format/) mengontrol pemformatan tanda akhir paragraf. Contoh memuat `Test.pptx`, yang harus berisi setidaknya satu slide, dan membuat [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) dengan [PortionFormat.font_height](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/font_height/) 48 poin serta [PortionFormat.latin_font](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/latin_font/) Times New Roman. Format ini diterapkan pada tanda akhir paragraf kedua, sementara bagian‑bagian teks yang terlihat tetap tidak berubah:

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

## **Hitung Garis yang Dirender**

Untuk aturan paragraf yang memengaruhi pembungkusan otomatis dan tanda baca di akhir baris, lihat [Control Line Breaking](/slides/id/python-net/text-formatting/#control-line-breaking) dan [Control Hanging Punctuation](/slides/id/python-net/text-formatting/#control-hanging-punctuation).

Gunakan [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/) untuk menghitung jumlah baris yang ditempati oleh sebuah paragraf setelah tata letak teks, termasuk pembungkusan otomatis. Hal ini berguna saat memeriksa panjang teks dan tata letak dalam templat presentasi.

Sebuah paragraf adalah satu item dalam [TextFrame.paragraphs](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/paragraphs/), dan dapat menempati beberapa baris yang dirender. Break baris eksplisit dalam paragraf memaksa baris baru tanpa membuat paragraf tambahan. Pembungkusan otomatis membuat baris berdasarkan lebar yang tersedia tanpa menyisipkan break baris eksplisit ke dalam teks. Karena itu menghitung paragraf atau karakter break baris tidak memberikan jumlah baris yang dirender.

Contoh berikut membuat sebuah bentuk teks, menghitung barisnya, mempersempit bentuk, lalu mengganti teks dengan string yang lebih pendek. Contoh mengaktifkan [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) dan menonaktifkan [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) sehingga lebar bentuk mengontrol pembungkusan tanpa secara otomatis memperkecil teks atau mengubah ukuran bentuk. Setiap pengukuran menggunakan [Paragraph.get_lines_count](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_lines_count/). Dimensi bentuk dalam poin. Akhirnya, contoh menambahkan paragraf lain dan menjumlahkan jumlah baris di seluruh bingkai teks.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 400, 200)
    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE

    paragraph = text_frame.paragraphs[0]
    paragraph.paragraph_format.default_portion_format.font_height = 20
    paragraph.text = "This text demonstrates how automatic wrapping changes the number of rendered lines."
    print(f"Original width: {paragraph.get_lines_count()}")

    shape.width = 150
    print(f"Narrower shape: {paragraph.get_lines_count()}")

    paragraph.text = "Short text."
    print(f"Shorter text: {paragraph.get_lines_count()}")

    second_paragraph = slides.Paragraph()
    second_paragraph.text = "Another paragraph."
    second_paragraph.paragraph_format.default_portion_format.font_height = 20
    text_frame.paragraphs.add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.paragraphs:
        total_line_count += current_paragraph.get_lines_count()
    print(f"Total lines in the text frame: {total_line_count}")
```

Dengan teks dan dimensi ini, mempersempit bentuk meningkatkan jumlah baris, sementara mengganti teks dengan string pendek menguranginya. Jumlah yang tepat dapat bervariasi tergantung pada ketersediaan dan substitusi font, ukuran font, margin, indentasi, pembungkusan, dan pengaturan autofit. Gunakan font dan pengaturan tata letak yang ditujukan untuk lingkungan target saat memeriksa templat.

Jumlah baris saja tidak menentukan apakah teks meluap dari kontainernya. Tinggi yang tersedia, tinggi baris, spasi paragraf dan baris, serta perilaku autofit juga penting; bahkan satu baris dapat melebihi lebar yang tersedia bila pembungkusan dinonaktifkan.

## **Impor dan Ekspor Konten Paragraf**

Gunakan HTML untuk memasukkan teks ke dalam presentasi atau mengekspor paragraf yang ada untuk digunakan di luar presentasi. Bagian ini juga menunjukkan cara merender paragraf individu sebagai gambar, termasuk paragraf dalam sel tabel.

### **Impor Teks HTML ke Paragraf**

Gunakan [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/) untuk mengonversi markup HTML menjadi paragraf dan bagian dalam bingkai teks.

Contoh Python ini membaca HTML dari `file.html` di direktori kerja dan meneruskan markup ke [ParagraphCollection.add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/add_from_html/). Ia mengosongkan paragraf default bingkai teks sehingga bingkai berisi hanya konten yang diimpor. Bentuk persegi panjang meninggalkan margin 10 poin di setiap sisi slide:

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

Gunakan [ParagraphCollection.export_to_html](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphcollection/export_to_html/) untuk mengekspor rentang paragraf yang dipilih sebagai HTML. Saat menggunakan kembali teks presentasi di situs web, Anda mungkin ingin mempertahankan penekanan lokal tanpa membawa gaya font, ukuran, atau kotak teks presentasi. Tetapkan [TextToHtmlConversionOptions.text_inheritance_limit](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/text_inheritance_limit/) untuk mengontrol sejauh mana eksportir mengikuti pewarisan pemformatan.

Unduh [presentasi contoh](text-inheritance.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi satu bentuk teks dengan teks "Inherited text; explicit red 18pt". Input sengaja menggunakan beberapa tingkat pemformatan:

- Gaya teks default presentasi menyediakan Calibri dengan ukuran 28 pt.
- Gaya teks tingkat pertama bingkai teks menyediakan teks biru dan miring.
- Paragraf secara eksplisit mengatur teks tebal.
- Bagian kedua, "explicit red 18pt", secara eksplisit mengatur teks merah dan ukuran 18 pt.

Contoh lengkap berikut mengekspor paragraf yang sama tiga kali. Ia meneruskan [TextToHtmlConversionOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/texttohtmlconversionoptions/) ke metode ekspor dan menulis masing‑masing hasil ke file HTML UTF‑8 terpisah:

```python
import aspose.slides as slides

with slides.Presentation("text-inheritance.pptx") as presentation:
    text_shape = presentation.slides[0].shapes[0]
    paragraphs = text_shape.text_frame.paragraphs
    
    modes = {
        "All": slides.export.TextInheritanceLimit.ALL,
        "TextBox": slides.export.TextInheritanceLimit.TEXT_BOX,
        "ParagraphOnly": slides.export.TextInheritanceLimit.PARAGRAPH_ONLY,
    }

    for name, mode in modes.items():
        options = slides.export.TextToHtmlConversionOptions()
        options.text_inheritance_limit = mode

        html = paragraphs.export_to_html(0, paragraphs.count, options)
        with open(f"{name}.html", "w", encoding="utf-8") as html_stream:
            html_stream.write(html)
```

HTML yang dihasilkan berisi CSS berikut untuk bagian pertama, "Inherited text; ". Tabel mencantumkan deklarasi yang relevan; properti lain yang dihasilkan dihilangkan demi kejelasan.

| Output | CSS yang Relevan untuk bagian pertama | Penampilan |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Teks biru, tebal, miring dengan ukuran 28 pt dalam Calibri, bila font tersebut tersedia. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Teks biru, tebal, miring; halaman atau peramban menyediakan keluarga font dan ukuran. |
| `ParagraphOnly.html` | `font-weight:bold` | Teks tebal; halaman atau peramban menyediakan keluarga font, ukuran, warna, dan gaya miring. |

Bagian kedua mempertahankan `color:#ff0000`, `font-size:18pt`, dan `font-weight:bold` dalam ketiga output. Ia juga mempertahankan miring pada `ALL` dan `TEXT_BOX`, tetapi tidak pada `PARAGRAPH_ONLY`. Membatasi pewarisan dengan demikian tidak menghapus pemformatan yang secara eksplisit ditetapkan pada paragraf atau bagian.

Buka file‑file tersebut di peramban yang sama untuk membandingkannya. Pada dua mode terbatas, properti CSS yang dihilangkan diselesaikan oleh gaya halaman tujuan atau default peramban, sehingga tampilan akhir tergantung pada tempat HTML tersebut digunakan.

### **Render Paragraf sebagai Gambar**

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) merender paragraf individual secara langsung dan mengembalikan sebuah [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/). Simpan hasilnya ke file atau aliran dengan [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Anda tidak perlu merender bentuk yang memuatnya atau memotong bitmap secara manual.

[Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) dapat mengembalikan `None` bila paragraf tidak ditemukan dalam koleksi induknya, tidak memiliki batas render yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpannya dan buang gambar yang dikembalikan setelah selesai digunakan.

#### **Render Paragraf dengan Skala Bawaan**

Contoh menggunakan `sample.pptx`, sebuah presentasi dengan satu slide yang bentuk pertama merupakan kotak teks berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut memilih paragraf kedua pada indeks 1 dan memanggil [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) tanpa parameter skala. Ia memeriksa bahwa bentuk berisi paragraf yang diperlukan dan bahwa render menghasilkan gambar sebelum memanggil [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) untuk menyimpannya dalam format PNG. Manajer konteks melepaskan sumber daya gambar setelah selesai.

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

Gunakan overload [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/) yang menerima parameter `scale_x` dan `scale_y` untuk mengatur faktor skala horizontal dan vertikal. Contoh berikut membuat tabel, merender paragraf dalam sel pertamanya dengan lebar dan tinggi dua kali lipat ukuran bawaan, dan menyimpan hasilnya sebagai gambar PNG.

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

Faktor skala `1` mempertahankan ukuran piksel standar pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar dengan lebar dan tinggi kira‑kira dua kali dimensi default, menghasilkan empat kali jumlah piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output resolusi tinggi, namun juga meningkatkan penggunaan memori dan ukuran berkas. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara independen.

Merender seluruh bentuk dengan [Shape.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/) tetap berguna ketika output harus menyertakan isi, batas, atau konteks visual lain dari bentuk. Untuk gambar hanya paragraf, gunakan [Paragraph.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_image/).

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkusan baris di dalam bingkai teks?**

Ya. Tetapkan [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) untuk menonaktifkan pembungkusan sehingga baris tidak berpotongan pada tepi bingkai teks.

**Bagaimana cara mendapatkan batas on‑slide yang tepat untuk paragraf tertentu?**

Gunakan [Paragraph.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/get_rect/) untuk mengambil persegi batas paragraf. [Portion.get_rect](https://reference.aspose.com/slides/python-net/aspose.slides/portion/get_rect/) menyediakan batas untuk bagian individual.

**Di mana pengaturan perataan paragraf (kiri, kanan, tengah, atau rata kiri‑kanan) dikendalikan?**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) adalah pengaturan tingkat paragraf dan diterapkan pada seluruh paragraf terlepas dari pemformatan bagian individual.

Untuk meratakan bagian dengan ukuran font berbeda secara vertikal dalam setiap baris, lihat [Align Fonts Within a Line](/slides/id/python-net/text-formatting/#align-fonts-within-a-line).

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan untuk bagian tertentu dari paragraf?**

Ya. Tetapkan [PortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/language_id/) untuk bagian individual, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.