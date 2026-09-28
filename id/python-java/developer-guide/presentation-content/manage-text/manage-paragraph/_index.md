---
title: Kelola Paragraf Teks PowerPoint di Python via Java
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
- tambah teks
- tambah paragraf
- kelola teks
- kelola paragraf
- kelola bullet
- indentasi paragraf
- indentasi menggantung
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
- Java
- Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, bagian, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Aspose.Slides for Python via Java merepresentasikan teks sebagai hierarki dari text frame, paragraph, dan portion:

* [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) mewakili kontainer teks dalam sebuah shape dan menyediakan akses ke koleksi paragrafnya.
* [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) mewakili satu paragraf dalam sebuah text frame dan menyediakan akses ke portion serta format level paragraf.
* [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) mewakili satu run teks di dalam paragraf. Setiap portion dapat memiliki teks dan format level karakter sendiri.

Dengan demikian, sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan format lainnya yang berbeda‑beda menggunakan beberapa portion.

## **Membuat dan Memformat Paragraf**

### **Membuat Paragraf dengan Beberapa Portion**

Langkah‑langkah berikut membuat sebuah text frame dengan tiga paragraf, masing‑masing berisi tiga portion:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) berukuran persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) shape tersebut.
5. Gunakan paragraf default dan tambahkan dua objek [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) lagi ke text frame.
6. Tambahkan cukup objek [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) untuk setiap paragraf agar berisi tiga portion. Paragraf default sudah berisi satu portion kosong.
7. Atur teks setiap portion.
8. Terapkan format level karakter melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getPortionFormat).
9. Simpan presentasi yang telah dimodifikasi.

Contoh Python yang mengimplementasikan langkah‑langkah tersebut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150)
    text_frame = shape.getTextFrame()
    first_paragraph = text_frame.getParagraphs().get_Item(0)
    first_paragraph.getPortions().add(Portion())
    first_paragraph.getPortions().add(Portion())
    second_paragraph = Paragraph()
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    second_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    third_paragraph.getPortions().add(Portion())
    text_frame.getParagraphs().add(third_paragraph)
    paragraph_count = text_frame.getParagraphs().getCount()
    for paragraph_index in range(paragraph_count):
        paragraph = text_frame.getParagraphs().get_Item(paragraph_index)
        portion_count = paragraph.getPortions().getCount()
        for portion_index in range(portion_count):
            portion = paragraph.getPortions().get_Item(portion_index)
            portion.setText(f"Portion {paragraph_index + 1}.{portion_index + 1}")
            if portion_index == 0:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
                portion.getPortionFormat().setFontBold(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(15)
            elif portion_index == 1:
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
                portion.getPortionFormat().setFontItalic(NullableBool.True_)
                portion.getPortionFormat().setFontHeight(18)
    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Membuat Daftar Bullet dan Numbered**

### **Membuat Daftar Bullet atau Numbered**

Bullet dan penomoran memudahkan pemindaian item yang berhubungan. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [BulletFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/).

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) shape tersebut.
5. Hapus paragraf default dari text frame.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) untuk bullet simbol.
7. Atur [BulletFormat.setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/#setType) menjadi [BulletType.Symbol](https://reference.aspose.com/slides/id/python-java/aspose.slides/bullettype/#Symbol) dan tentukan karakter bullet.
8. Atur teks paragraf, indent, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke text frame.
10. Buat paragraf kedua dan atur [BulletFormat.setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/#setType) menjadi [BulletType.Numbered](https://reference.aspose.com/slides/id/python-java/aspose.slides/bullettype/#Numbered).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke text frame.
12. Simpan presentasi.

Contoh Python yang membuat bullet simbol dan bullet bernomor:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ColorType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    symbol_paragraph = Paragraph()
    symbol_paragraph.setText("Welcome to Aspose.Slides")
    symbol_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    symbol_paragraph.getParagraphFormat().getBullet().setChar("•")
    symbol_paragraph.getParagraphFormat().setIndent(25)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    symbol_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    symbol_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    symbol_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(symbol_paragraph)
    numbered_paragraph = Paragraph()
    numbered_paragraph.setText("This is a numbered item")
    numbered_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    numbered_paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain)
    numbered_paragraph.getParagraphFormat().setIndent(25)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB)
    numbered_paragraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK)
    numbered_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    numbered_paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(numbered_paragraph)
    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menggunakan Picture Bullets**

Picture bullets memungkinkan Anda menggunakan gambar khusus alih‑alih simbol atau nomor.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) dan akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/)‑nya.
4. Hapus paragraf default dari text frame.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/).
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) dan atur teksnya.
7. Atur [BulletFormat.setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/#setType) menjadi [BulletType.Picture](https://reference.aspose.com/slides/id/python-java/aspose.slides/bullettype/#Picture).
8. Tetapkan gambar melalui [BulletFormat.getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/#getPicture) dan atur tinggi bullet.
9. Tambahkan paragraf ke text frame.
10. Simpan presentasi yang telah dimodifikasi.

Contoh Python yang membuat picture bullet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    bullet_image = Images.fromFile("bullets.png")
    try:
        presentation_image = presentation.getImages().addImage(bullet_image)
    finally:
        bullet_image.dispose()
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    paragraph = Paragraph()
    paragraph.setText("Welcome to Aspose.Slides")
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentation_image)
    paragraph.getParagraphFormat().getBullet().setHeight(100)
    text_frame.getParagraphs().add(paragraph)
    presentation.save("picture_bullet.pptx", SaveFormat.Pptx)
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

### **Membuat Daftar Multilevel**

Atur [ParagraphFormat.setDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setDepth) untuk menempatkan paragraf pada level daftar yang berbeda. Level teratas memiliki depth `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) serta bersihkan paragraf default dari text frame‑nya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Atur nilai [ParagraphFormat.setDepth](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setDepth) masing‑masing menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf‑paragraf ke text frame dan simpan presentasi.

Contoh Python yang membuat daftar bullet empat level:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Content")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar("•")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setDepth(0)
    second_paragraph = Paragraph()
    second_paragraph.setText("Second level")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('-')
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setDepth(1)
    third_paragraph = Paragraph()
    third_paragraph.setText("Third level")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    third_paragraph.getParagraphFormat().getBullet().setChar("•")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setDepth(2)
    fourth_paragraph = Paragraph()
    fourth_paragraph.setText("Fourth level")
    fourth_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    fourth_paragraph.getParagraphFormat().getBullet().setChar('-')
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    fourth_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    fourth_paragraph.getParagraphFormat().setDepth(3)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    text_frame.getParagraphs().add(fourth_paragraph)
    presentation.save("multilevel_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Memulai Nomor List pada Nilai Kustom**

Gunakan [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) untuk mengatur nomor awal yang ditampilkan pada paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) ke slide.
2. Bersihkan paragraf default dari text frame shape.
3. Buat tiga paragraf bernomor.
4. Atur [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/id/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) menjadi `2`, `3`, dan `7` untuk paragraf yang bersangkutan.
5. Tambahkan paragraf‑paragraf ke text frame dan simpan presentasi.

Contoh Python yang menetapkan nomor mulai kustom untuk setiap paragraf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("Start at 2")
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(2)
    text_frame.getParagraphs().add(first_paragraph)
    second_paragraph = Paragraph()
    second_paragraph.setText("Start at 3")
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(3)
    text_frame.getParagraphs().add(second_paragraph)
    third_paragraph = Paragraph()
    third_paragraph.setText("Start at 7")
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(7)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengontrol Tata Letak Paragraf dan Properti Akhir**

### **Mengatur Indent Baris Pertama**

Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent) untuk mengontrol indent baris pertama suatu paragraf. Metode ini hanya menggeser baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sedangkan baris‑baris berikutnya tetap sejajar dengan badan paragraf.

Gunakan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setMarginLeft) bila Anda ingin menggeser seluruh paragraf. Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent) bila hanya baris pertama yang perlu digeser.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent) yang berbeda untuk menunjukkan pengaruh indent baris pertama terhadap tata letak paragraf.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) shape dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf‑paragraf ke text frame.
7. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur indent paragraf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(20.0)
    first_paragraph.getParagraphFormat().setIndent(0.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().setFillType(FillType.Solid)
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    third_paragraph.getParagraphFormat().setMarginLeft(20.0)
    third_paragraph.getParagraphFormat().setIndent(40.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    text_frame.getParagraphs().add(third_paragraph)
    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Indent baris pertama paragraf](first_line_indent.png)

### **Mengatur Hanging Indent**

Hanging indent adalah tata letak paragraf di mana baris pertama dimulai lebih ke kiri dibandingkan baris‑baris berikutnya. Di Aspose.Slides, efek ini dibuat dengan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent). Berikan nilai negatif untuk menggeser baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktik, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setMarginLeft) menentukan posisi kiri badan paragraf, dan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat hanging indent, berikan nilai positif ke [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setMarginLeft) dan nilai negatif ke [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent).

Formatting ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris yang dibungkus harus sejajar di bawah badan paragraf, bukan di bawah karakter pertama baris pertama.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) shape dan hapus paragraf default.
5. Buat paragraf‑paragraf dan berikan nilai positif ke [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setMarginLeft) untuk masing‑masing.
6. Berikan nilai negatif ke [ParagraphFormat.setIndent](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setIndent) untuk menciptakan efek hanging indent.
7. Tambahkan paragraf‑paragraf ke text frame.
8. Simpan presentasi yang telah dimodifikasi.

Kode ini menunjukkan cara mengatur hanging indent untuk sebuah paragraf:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Presentation, SaveFormat, ShapeType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape)
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_paragraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.")
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    first_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    first_paragraph.getParagraphFormat().setMarginLeft(40.0)
    first_paragraph.getParagraphFormat().setIndent(-20.0)
    second_paragraph = Paragraph()
    second_paragraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(60.0)
    second_paragraph.getParagraphFormat().setIndent(-30.0)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("hanging_indent.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Hanging indent paragraf](hanging_indent.png)

### **Mengatur Properti End Paragraph Run**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) mengontrol format tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin pada tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) serta bersihkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan portion teks ke masing‑masing.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Atur [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setFontHeight) dan [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLatinFont).
6. Tetapkan format tersebut dengan [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) dan simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Paragraph, Portion, PortionFormat, Presentation, SaveFormat, ShapeType

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()
    first_paragraph = Paragraph()
    first_portion = Portion("Sample text")
    first_paragraph.getPortions().add(first_portion)
    second_paragraph = Paragraph()
    second_portion = Portion("Sample text 2")
    second_paragraph.getPortions().add(second_portion)
    end_paragraph_format = PortionFormat()
    end_paragraph_format.setFontHeight(48)
    latin_font = FontData("Times New Roman")
    end_paragraph_format.setLatinFont(latin_font)
    second_paragraph.setEndParagraphPortionFormat(end_paragraph_format)
    text_frame.getParagraphs().add(first_paragraph)
    text_frame.getParagraphs().add(second_paragraph)
    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menghitung Baris yang Dirender**

Untuk aturan paragraf yang memengaruhi pembungkusan otomatis dan tanda baca pada akhir baris, lihat [Control Line Breaking](/slides/id/python-java/text-formatting/#control-line-breaking) dan [Control Hanging Punctuation](/slides/id/python-java/text-formatting/#control-hanging-punctuation).

Gunakan [Paragraph.getLinesCount](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/#getLinesCount) untuk menghitung jumlah baris yang ditempati oleh sebuah paragraf setelah penataan teks, termasuk pembungkusan otomatis. Ini berguna saat memeriksa panjang teks dan tata letak dalam templat presentasi.

Sebuah paragraf merupakan satu item dalam [TextFrame.getParagraphs](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/#getParagraphs), dan dapat menempati beberapa baris yang dirender. Break baris eksplisit di dalam paragraf memaksa baris baru tanpa membuat paragraf baru. Pembungkusan otomatis membuat baris berdasarkan lebar yang tersedia tanpa menyisipkan break baris eksplisit ke dalam teks. Karena itu, menghitung paragraf atau karakter break baris tidak memberikan jumlah baris yang dirender.

Contoh berikut membuat sebuah shape teks, menghitung barisnya, mempersempit shape, lalu mengganti teks dengan string yang lebih pendek. Pembungkusan diaktifkan dan autofit dinonaktifkan sehingga lebar shape mengontrol pembungkusan tanpa secara otomatis memperkecil teks atau mengubah ukuran shape. Dimensi shape dinyatakan dalam poin. Akhirnya, contoh menambahkan paragraf lain dan menjumlahkan jumlah baris di seluruh text frame.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Paragraph, Presentation, ShapeType, TextAutofitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200)
    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.")
    print("Original width:", paragraph.getLinesCount())

    shape.setWidth(150)
    print("Narrower shape:", paragraph.getLinesCount())

    paragraph.setText("Short text.")
    print("Shorter text:", paragraph.getLinesCount())

    second_paragraph = Paragraph()
    second_paragraph.setText("Another paragraph.")
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20)
    text_frame.getParagraphs().add(second_paragraph)

    total_line_count = 0
    for current_paragraph in text_frame.getParagraphs():
        total_line_count += current_paragraph.getLinesCount()
    print("Total lines in the text frame:", total_line_count)
finally:
    presentation.dispose()
```

Dengan teks dan dimensi ini, mempersempit shape meningkatkan jumlah baris, sementara mengganti teks dengan string pendek menguranginya. Hitungan yang tepat dapat bervariasi tergantung pada ketersediaan font dan substitusi, ukuran font, margin, indentasi, pembungkusan, dan pengaturan autofit. Gunakan font dan pengaturan tata letak yang ditujukan untuk lingkungan target ketika memeriksa sebuah templat.

Jumlah baris saja tidak menentukan apakah teks melampaui kontainernya. Tinggi yang tersedia, tinggi baris, spasi paragraf dan baris, serta perilaku autofit juga penting; bahkan satu baris dapat melampaui lebar yang tersedia ketika pembungkusan dinonaktifkan.

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke Dalam Paragraf**

Gunakan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphcollection/#addFromHtml) untuk mengonversi markup HTML menjadi paragraf dan portion dalam sebuah text frame.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Akses sebuah slide dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
3. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) shape dan bersihkan paragraf defaultnya.
4. Baca file HTML sumber.
5. Berikan string HTML ke [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphcollection/#addFromHtml).
6. Simpan presentasi yang telah dimodifikasi.

Contoh Python yang mengimpor HTML ke dalam sebuah text frame:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape_width = presentation.getSlideSize().getSize().getWidth() - 20
    shape_height = presentation.getSlideSize().getSize().getHeight() - 20
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shape_width, shape_height)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()
    try:
        html = Path("file.html").read_text(encoding="utf-8")
        shape.getTextFrame().getParagraphs().addFromHtml(html)
        presentation.save("html_text.pptx", SaveFormat.Pptx)
    except OSError as exception:
        print("The HTML file could not be read: " + str(exception))
finally:
    presentation.dispose()
```

### **Ekspor Teks Paragraf ke HTML**

Gunakan [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphcollection/#exportToHtml) untuk mengekspor rentang paragraf yang dipilih sebagai HTML.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) yang berisi teks.
3. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) shape.
4. Panggil [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphcollection/#exportToHtml) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

Contoh Python yang mengekspor semua paragraf dari text shape pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation
from pathlib import Path

presentation = Presentation("ExportingHTMLText.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None:
            paragraphs = text_frame.getParagraphs()
            html = paragraphs.exportToHtml(0, paragraphs.getCount(), None)
            try:
                Path("paragraphs.html").write_text(str(html), encoding="utf-8")
            except OSError as exception:
                print("The HTML file could not be written: " + str(exception))
        else:
            print("The first shape does not contain a text frame.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

### **Render Paragraf sebagai Gambar**

[Paragraph.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) merender sebuah paragraf secara langsung dan mengembalikan objek gambar. Simpan hasilnya ke file atau stream dengan metode `save`. Anda tidak perlu merender shape yang memuatnya atau memotong bitmap secara manual.

[Paragraph.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) dapat mengembalikan `None` jika paragraf tidak ditemukan dalam koleksi induknya, tidak memiliki batas render yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpan dan buang gambar yang dikembalikan setelah selesai digunakan.

#### **Render Paragraf dengan Skala Default**

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah sebuah textbox yang berisi tiga paragraf.

![Textbox dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam sebuah shape teks biasa pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Blok `finally` memastikan gambar dibuang dengan benar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, AutoShape):
        text_shape = shape
        text_frame = text_shape.getTextFrame()
        if text_frame is not None and text_frame.getParagraphs().getCount() > 1:
            paragraph = text_frame.getParagraphs().get_Item(1)
            paragraph_image = paragraph.getImage()
            if paragraph_image is not None:
                try:
                    paragraph_image.save("paragraph.png", ImageFormat.Png)
                finally:
                    paragraph_image.dispose()
            else:
                print("The paragraph could not be rendered.")
        else:
            print("The expected paragraph was not found.")
    else:
        print("The first shape is not a text shape.")
finally:
    presentation.dispose()
```

Hasilnya:

![Gambar paragraf](paragraph_to_image_output.png)

#### **Render Paragraf dalam Sel Tabel dengan Skalasi**

Gunakan overload [Paragraph.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) yang menerima parameter `scale_x` dan `scale_y` untuk mengatur faktor skala horizontal dan vertikal. Contoh berikut membuat sebuah tabel, merender paragraf di sel pertama dengan lebar dan tinggi dua kali lipat skala default, dan menyimpan hasilnya sebagai gambar PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

scale_x = 2.0
scale_y = 2.0
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(50, 50, [300.0], [80.0])
    paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0)
    paragraph.setText("Text in a table cell")
    paragraph_image = paragraph.getImage(scale_x, scale_y)
    if paragraph_image is not None:
        try:
            paragraph_image.save("table_paragraph.png", ImageFormat.Png)
        finally:
            paragraph_image.dispose()
    else:
        print("The paragraph could not be rendered.")
finally:
    presentation.dispose()
```

Faktor skala `1` mempertahankan ukuran piksel default pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar dengan lebar dan tinggi kira‑kira dua kali dimensi default, sehingga menghasilkan empat kali lebih banyak piksel. Faktor yang lebih besar umumnya menghasilkan teks yang lebih tajam untuk zoom atau output beresolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran berkas. Faktor di bawah `1` menghasilkan gambar yang lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara independen.

Merender seluruh shape dengan [Shape.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) tetap berguna ketika output harus menyertakan isi, border, atau konteks visual lain dari shape. Untuk gambar yang hanya berisi paragraf, gunakan [Paragraph.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/).

## **FAQ**

**Apakah saya dapat menonaktifkan pembungkusan baris sepenuhnya di dalam sebuah text frame?**

Ya. Atur [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframeformat/#setWrapText) untuk menonaktifkan pembungkusan sehingga baris tidak terputus pada tepi text frame.

**Bagaimana cara mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Gunakan [Paragraph.getRect](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/#getRect) untuk memperoleh persegi panjang pembatas paragraf. [Portion.getRect](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getRect) memberikan batas sebuah portion individu.

**Di mana pengaturan alignment paragraf (kiri, kanan, tengah, atau justify) dikontrol?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraphformat/#setAlignment) merupakan pengaturan level paragraf dan diterapkan ke seluruh paragraf terlepas dari format portion individual.

**Apakah saya dapat mengatur bahasa proofing untuk bagian tertentu dari sebuah paragraf?**

Ya. Atur [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseportionformat/#setLanguageId) untuk portion individual, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.