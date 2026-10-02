---
title: Kelola Paragraf Teks PowerPoint dengan Python via Java
linktitle: Kelola Paragraf
type: docs
weight: 40
url: /id/python-java/manage-paragraph/
aliases:
  - /python-java/paragraph/
  - /python-java/portion/
keywords:
  - tambahkan teks
  - tambahkan paragraf
  - kelola teks
  - kelola paragraf
  - kelola bullet
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
  - Java
  - Aspose.Slides
description: "Pelajari cara membuat dan memformat paragraf, portion, bullet, daftar bernomor, indentasi, konten HTML, dan gambar paragraf dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Aspose.Slides untuk Python via Java merepresentasikan teks sebagai hierarki frame teks, paragraf, dan portion:

* [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) mewakili wadah teks dalam sebuah shape dan menyediakan akses ke koleksi paragrafnya.
* [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) mewakili satu paragraf dalam sebuah frame teks dan menyediakan akses ke portion serta format tingkat paragraf.
* [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) mewakili satu rangkaian teks dalam paragraf. Setiap portion dapat memiliki teks dan format tingkat karakter tersendiri.

Dengan demikian sebuah paragraf dapat berisi teks dengan font, warna, ukuran, dan format lain yang berbeda-beda dengan menggunakan beberapa portion.

## **Buat dan Format Paragraf**

### **Buat Paragraf dengan Beberapa Portion**

Langkah‑langkah berikut membuat sebuah frame teks dengan tiga paragraf, masing‑masing berisi tiga portion:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) shape.
5. Gunakan paragraf default dan tambahkan dua objek [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) lagi ke frame teks.
6. Tambahkan cukup objek [Portion](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) untuk setiap paragraf agar masing‑masing memiliki tiga portion. Paragraf default sudah berisi satu portion kosong.
7. Atur teks setiap portion.
8. Terapkan format tingkat karakter melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getPortionFormat).
9. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut mengimplementasikan langkah‑langkah tersebut:

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

## **Buat Daftar Bullet dan Bernomor**

### **Buat Daftar Bullet atau Bernomor**

Bullet dan penomoran memudahkan pemindaian item yang terkait. Di Aspose.Slides, pengaturan daftar didefinisikan melalui [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/).

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ke slide yang dipilih.
4. Akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) shape.
5. Hapus paragraf default dari frame teks.
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) untuk bullet simbol.
7. Atur [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) ke [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol) dan tentukan karakter bullet.
8. Atur teks paragraf, indentasi, warna bullet, dan tinggi bullet.
9. Tambahkan paragraf ke frame teks.
10. Buat paragraf kedua dan atur [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) ke [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered).
11. Konfigurasikan gaya bullet bernomor dan tambahkan paragraf ke frame teks.
12. Simpan presentasi.

Contoh Python berikut membuat bullet simbol dan bullet bernomor:

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

### **Gunakan Bullet Gambar**

Bullet gambar memungkinkan Anda menggunakan gambar khusus alih‑alih simbol atau angka.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Akses slide yang relevan melalui indeksnya.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) dan akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)‑nya.
4. Hapus paragraf default dari frame teks.
5. Muat gambar bullet dan tambahkan ke koleksi gambar presentasi sebagai [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) .
6. Buat sebuah [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) dan atur teksnya.
7. Atur [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) ke [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) .
8. Tetapkan gambar melalui [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture) dan atur tinggi bullet.
9. Tambahkan paragraf ke frame teks.
10. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut membuat bullet gambar:

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

### **Buat Daftar Multilevel**

Atur [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) untuk menempatkan paragraf pada level yang berbeda dalam sebuah daftar. Level teratas memiliki depth `0`.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) dan bersihkan paragraf default dari frame teksnya.
3. Buat empat paragraf dan konfigurasikan simbol bullet masing‑masing.
4. Atur nilai [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth) mereka menjadi `0`, `1`, `2`, dan `3`.
5. Tambahkan paragraf ke frame teks dan simpan presentasi.

Contoh Python berikut membuat daftar bullet dengan empat level:

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

### **Mulai Item Daftar Bernomor dengan Nilai Kustom**

Gunakan [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) untuk menentukan angka awal yang ditampilkan pada paragraf bernomor.

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) ke sebuah slide.
2. Bersihkan paragraf default dari frame teks shape.
3. Buat tiga paragraf bernomor.
4. Atur [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) menjadi `2`, `3`, dan `7` untuk paragraf masing‑masing.
5. Tambahkan paragraf ke frame teks dan simpan presentasi.

Contoh Python berikut menetapkan angka awal kustom untuk setiap paragraf:

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

## **Kontrol Tata Letak Paragraf dan Properti Akhir**

### **Atur Inden Baris Pertama**

Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) untuk mengontrol inden baris pertama sebuah paragraf. Metode ini memindahkan hanya baris pertama relatif terhadap margin kiri paragraf. Nilai positif menggeser baris pertama ke kanan, sedangkan baris‑baris berikutnya tetap sejajar dengan badan paragraf.

Gunakan [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) bila Anda perlu memindahkan seluruh paragraf. Gunakan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) bila Anda hanya perlu memindahkan baris pertama.

Contoh di bawah ini membuat beberapa paragraf dan menerapkan nilai [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) yang berbeda untuk menunjukkan bagaimana inden baris pertama memengaruhi tata letak paragraf.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) shape dan hapus paragraf default.
5. Buat beberapa paragraf dan atur nilai [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) yang berbeda untuk masing‑masing.
6. Tambahkan paragraf ke frame teks.
7. Simpan presentasi yang telah dimodifikasi.

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
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    second_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    second_paragraph.getParagraphFormat().setMarginLeft(20.0)
    second_paragraph.getParagraphFormat().setIndent(20.0)
    third_paragraph = Paragraph()
    third_paragraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.")
    third_paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
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

![Indentasi baris pertama dari paragraf](first_line_indent.png)

### **Atur Inden Gantung**

Indentasi gantung adalah tata letak paragraf di mana baris pertama dimulai di kiri baris‑baris berikutnya. Di Aspose.Slides, Anda membuat efek ini dengan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent). Berikan nilai negatif untuk memindahkan baris pertama ke kiri relatif terhadap badan paragraf.

Secara praktis, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) menentukan posisi kiri badan paragraf, dan [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) menentukan posisi baris pertama relatif terhadap margin tersebut. Untuk membuat indentasi gantung, berikan nilai positif ke [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) dan nilai negatif ke [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent).

Format ini berguna untuk bibliografi, referensi, entri glosarium, dan paragraf lain di mana baris‑baris yang dibungkus harus rata di bawah badan paragraf bukan di bawah karakter pertama baris pertama.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Akses slide target.
3. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) persegi panjang ke slide.
4. Akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) shape dan hapus paragraf default.
5. Buat paragraf dan berikan nilai positif ke [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginLeft) untuk masing‑masing paragraf.
6. Berikan nilai negatif ke [ParagraphFormat.setIndent](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setIndent) untuk menciptakan efek indentasi gantung.
7. Tambahkan paragraf ke frame teks.
8. Simpan presentasi yang telah dimodifikasi.

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

![Indentasi gantung dari paragraf](hanging_indent.png)

### **Atur Properti Jalankan Akhir Paragraf**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) mengontrol format tanda akhir paragraf. Contoh berikut menetapkan ukuran font dan font Latin ke tanda akhir paragraf kedua:

1. Muat sebuah [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan akses sebuah slide.
2. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) dan bersihkan paragraf defaultnya.
3. Buat dua paragraf dan tambahkan portion teks ke masing‑masing.
4. Buat sebuah [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) untuk tanda akhir paragraf kedua.
5. Atur [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) dan [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLatinFont) .
6. Tetapkan format dengan [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#setEndParagraphPortionFormat) dan simpan presentasi.

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

## **Hitung Baris yang Dirender**

Untuk aturan paragraf yang memengaruhi pembungkusan otomatis dan tanda baca di akhir baris, lihat [Kontrol Pemutusan Garis](/slides/id/python-java/text-formatting/#control-line-breaking) dan [Kontrol Tanda Baca Gantung](/slides/id/python-java/text-formatting/#control-hanging-punctuation).

Gunakan [Paragraph.getLinesCount](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getLinesCount) untuk menghitung baris yang ditempati oleh sebuah paragraf setelah tata letak teks, termasuk pembungkusan otomatis. Ini berguna saat memeriksa panjang teks dan tata letak dalam templat presentasi.

Sebuah paragraf adalah satu item dalam [TextFrame.getParagraphs](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getParagraphs), dan dapat menempati beberapa baris yang dirender. Pemutusan baris eksplisit di dalam paragraf memaksa baris baru tanpa membuat paragraf lain. Pembungkusan otomatis membuat baris berdasarkan lebar yang tersedia tanpa menyisipkan pemutusan baris eksplisit ke dalam teks. Karena itu menghitung paragraf atau karakter pemutusan baris tidak memberikan jumlah baris yang dirender.

Contoh berikut membuat sebuah shape teks, menghitung barisnya, mempersempit shape, dan kemudian mengganti teks dengan string yang lebih pendek. Pembungkusan diaktifkan dan autofit dinonaktifkan sehingga lebar shape mengontrol pembungkusan tanpa secara otomatis memperkecil teks atau mengubah ukuran shape. Dimensi shape dalam poin. Akhirnya, contoh menambahkan paragraf lain dan menjumlahkan jumlah baris di seluruh frame teks.

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

Dengan teks dan dimensi ini, mempersempit shape meningkatkan jumlah baris, sementara mengganti teks dengan string pendek menguranginya. Jumlah pasti dapat bervariasi tergantung pada ketersediaan dan substitusi font, ukuran font, margin, indentasi, pembungkusan, dan pengaturan autofit. Gunakan font dan pengaturan tata letak yang ditujukan untuk lingkungan target saat memeriksa templat.

Jumlah baris saja tidak menentukan apakah teks melampaui kontainernya. Tinggi yang tersedia, tinggi baris, spasi paragraf dan baris, serta perilaku autofit juga penting; bahkan satu baris dapat melampaui lebar yang tersedia bila pembungkusan dinonaktifkan.

## **Impor dan Ekspor Konten Paragraf**

### **Impor Teks HTML ke dalam Paragraf**

Gunakan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) untuk mengonversi markup HTML menjadi paragraf dan portion dalam sebuah frame teks.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Akses sebuah slide dan tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) .
3. Akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) shape dan bersihkan paragraf defaultnya.
4. Baca file HTML sumber.
5. Berikan string HTML ke [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#addFromHtml) .
6. Simpan presentasi yang telah dimodifikasi.

Contoh Python berikut mengimpor HTML ke dalam sebuah frame teks:

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

Gunakan [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) untuk mengekspor rentang paragraf yang dipilih sebagai HTML.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan muat presentasi yang diinginkan.
2. Akses slide dan temukan [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) yang berisi teks.
3. Akses [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) shape.
4. Panggil [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphcollection/#exportToHtml) dengan indeks paragraf awal dan jumlah paragraf yang akan diekspor.
5. Tulis string HTML yang dikembalikan ke sebuah file.

Contoh Python berikut mengekspor semua paragraf dari shape teks pertama:

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

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) merender sebuah paragraf individual secara langsung dan mengembalikan objek gambar. Simpan hasilnya ke file atau stream dengan metode `save`. Anda tidak perlu merender shape yang menampungnya atau memotong bitmap secara manual.

[Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) dapat mengembalikan `None` bila paragraf tidak ditemukan dalam koleksi induknya, tidak memiliki batas rendering yang valid, atau tidak dapat dirender. Periksa hasilnya sebelum menyimpannya dan dispose gambar yang dikembalikan setelah selesai digunakan.

#### **Render Paragraf pada Skala Default**

Misalkan kita memiliki file presentasi bernama sample.pptx dengan satu slide, di mana shape pertama adalah kotak teks yang berisi tiga paragraf.

![Kotak teks dengan tiga paragraf](paragraph_to_image_input.png)

Contoh berikut merender paragraf kedua dalam shape teks standar pada skala default dan menyimpan gambar yang dikembalikan dalam format PNG. Blok `finally` memastikan gambar dibebaskan dengan benar.

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

#### **Render Paragraf dalam Sel Tabel dengan Skala**

Gunakan overload [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) yang menerima parameter `scale_x` dan `scale_y` untuk mengatur faktor skala horizontal dan vertikal. Contoh berikut membuat sebuah tabel, merender paragraf di sel pertama dengan lebar dan tinggi dua kali lipat dari nilai default, dan menyimpan hasilnya sebagai gambar PNG.

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

Faktor skala `1` mempertahankan ukuran piksel default pada sumbu tersebut. Misalnya, `2` untuk kedua faktor menghasilkan gambar yang lebar dan tingginya kira‑kira dua kali dimensi default, sehingga menghasilkan empat kali lebih banyak piksel. Faktor yang lebih besar umumnya menghasilkan teks lebih tajam untuk zoom atau keluaran resolusi tinggi, tetapi juga meningkatkan penggunaan memori dan ukuran file. Faktor di bawah `1` menghasilkan gambar lebih kecil dengan detail lebih sedikit. Gunakan faktor yang sama untuk mempertahankan rasio aspek paragraf; faktor horizontal dan vertikal yang berbeda akan meregangkan output secara terpisah.

Merender seluruh shape dengan [Shape.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) tetap berguna ketika output harus mencakup isi, batas, atau konteks visual lainnya dari shape. Untuk gambar hanya paragraf, gunakan [Paragraph.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) .

## **FAQ**

**Apakah saya dapat sepenuhnya menonaktifkan pembungkus baris di dalam sebuah text frame?**

Ya. Atur [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) untuk menonaktifkan pembungkusan sehingga baris tidak terputus di tepi text frame.

**Bagaimana cara mendapatkan batas tepat pada slide untuk paragraf tertentu?**

Gunakan [Paragraph.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getRect) untuk mengambil persegi pembatas paragraf. [Portion.getRect](https://reference.aspose.com/slides/python-java/aspose.slides/portion/#getRect) menyediakan batas untuk setiap portion individual.

**Di mana pengaturan perataan paragraf (kiri, kanan, tengah, atau justify) dikendalikan?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) adalah pengaturan tingkat paragraf dan diterapkan pada seluruh paragraf terlepas dari format portion individual.

Untuk menyelaraskan portion dengan ukuran font berbeda secara vertikal dalam setiap baris, lihat [Align Fonts Within a Line](/slides/id/python-java/text-formatting/#align-fonts-within-a-line).

**Apakah saya dapat mengatur bahasa pemeriksaan ejaan untuk sebagian paragraf?**

Ya. Atur [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) untuk portion individual, sehingga satu paragraf dapat berisi teks dalam beberapa bahasa.