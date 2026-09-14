---
title: Kelola Font dalam Presentasi Menggunakan Python via Java
linktitle: Kelola Font
type: docs
weight: 10
url: /id/python-java/manage-fonts/
keywords:
- kelola font
- properti font
- paragraf
- pemformatan teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kontrol font dalam Python via Java dengan Aspose.Slides: sematkan, gantikan, dan muat font khusus untuk menjaga presentasi PPT, PPTX, dan ODP tetap jelas, aman merek, dan konsisten."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda mengelola properti font dalam teks presentasi langsung dari kode Anda. Anda dapat mengakses teks dalam slide melalui shape, text frame, paragraf, dan portion, lalu menerapkan pemformatan pada teks yang dipilih.

Artikel ini menjelaskan cara mengonfigurasi properti terkait font untuk teks yang ada dalam presentasi, termasuk keluarga font, gaya tebal dan miring, perataan paragraf, serta warna font. Artikel ini juga menunjukkan cara membuat kotak teks, menambahkan teks ke dalamnya, dan mengatur properti font seperti keluarga font, tebal, miring, garis bawah, ukuran font, dan warna sebelum menyimpan hasilnya sebagai file PPTX.

## **Kelola Properti Terkait Font**
{{% alert color="info" title="Note" %}} 

Presentasi biasanya berisi teks dan gambar. Teks dapat diformat dengan berbagai cara, baik untuk menyoroti bagian dan kata tertentu maupun untuk menyesuaikan dengan gaya korporat. Pemformatan teks membantu pengguna mengubah tampilan dan nuansa konten presentasi. Artikel ini menunjukkan cara menggunakan Aspose.Slides for Python via Java untuk mengonfigurasi properti font dari paragraf teks pada slide.

{{% /alert %}} 

Untuk mengelola properti font dari sebuah paragraf menggunakan Aspose.Slides for Python via Java:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses shape [Placeholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/placeholder/) pada slide sebagai [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
1. Dapatkan [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/) dari [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) yang diekspose oleh [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
1. Ratakan paragraf.
1. Akses [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) teks dari sebuah [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/).
1. Tentukan font menggunakan [FontData](https://reference.aspose.com/slides/id/python-java/aspose.slides/fontdata/) dan atur **Font** dari teks [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) sesuai.
   1. Atur font menjadi tebal.
   1. Atur font menjadi miring.
1. Atur warna font menggunakan [FillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/fillformat/) yang diekspose oleh objek [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/).
1. Simpan presentasi yang telah dimodifikasi ke file PPTX.

Implementasi langkah-langkah di atas diberikan di bawah ini. Ini mengambil presentasi yang belum diberi format dan memformat font pada salah satu slide. Screenshot berikut menunjukkan file input dan bagaimana potongan kode mengubahnya. Kode mengubah font, warna, dan gaya font.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: Teks dalam file input**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: Teks yang sama dengan pemformatan yang diperbarui**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Muat presentasi.
presentation = Presentation("FontProperties.pptx")
try:
    # Akses slide pertama dan bingkai teks dari dua placeholder pertamanya.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Akses paragraf pertama di setiap bingkai teks.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Akses bagian pertama di setiap paragraf.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Tentukan dan tetapkan font baru.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Atur font menjadi tebal dan miring.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Atur warna font.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Simpan presentasi.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Atur Properti Font Teks**
{{% alert color="info" title="Note" %}} 

Seperti yang disebutkan dalam **Kelola Properti Terkait Font**, sebuah [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) digunakan untuk menampung teks dengan gaya pemformatan serupa dalam sebuah paragraf. Artikel ini menunjukkan cara menggunakan Aspose.Slides for Python via Java untuk membuat kotak teks dengan beberapa teks dan kemudian menentukan font tertentu serta berbagai properti font lainnya.

{{% /alert %}} 

Untuk membuat kotak teks dan mengatur properti font dari teks di dalamnya:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) dengan tipe **Rectangle** ke slide.
1. Hapus gaya isi yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
1. Akses [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) milik [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/).
1. Tambahkan beberapa teks ke [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/).
1. Akses objek [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) yang terkait dengan [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/).
1. Tentukan font yang akan digunakan untuk [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/).
1. Atur properti font lainnya seperti tebal, miring, garis bawah, warna, dan tinggi menggunakan properti yang relevan yang diekspose oleh objek [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/).
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

Implementasi langkah-langkah di atas diberikan di bawah ini.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Teks dengan beberapa properti font yang diatur oleh Aspose.Slides untuk Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Dapatkan slide pertama dan tambahkan persegi panjang.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Hapus isi shape.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Tambahkan teks ke bingkai teks shape.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Atur keluarga font.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Atur tebal, miring, garis bawah, dan ukuran font.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Atur warna font.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Simpan presentasi.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```