---
title: Dapatkan Batas Bagian Teks dari Presentasi dalam Python via Java
linktitle: Batas Bagian
type: docs
weight: 47
url: /id/python-java/portion-bounds/
keywords:
- batas bagian teks
- bagian teks
- potongan teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil batas sebuah fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [Portion.getRect](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getRect). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [Portion.getCoordinates](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getCoordinates). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami cara pemformatan diselesaikan melalui warisan bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Bagian Teks**

Gunakan [Portion.getRect](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getRect) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            rectangle = portion.getRect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
finally:
    presentation.dispose()
```

## **Dapatkan Koordinat Bagian Teks**

Gunakan [Portion.getCoordinates](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/#getCoordinates) untuk mengambil koordinat awal sebuah bagian teks:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    for paragraph in shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            point = portion.getCoordinates()
            print(f"X = {point.x}; Y = {point.y}")
finally:
    presentation.dispose()
```

## **Tanya Jawab**

**Apakah saya dapat menerapkan hyperlink hanya pada bagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/python-java/manage-hyperlinks/) ke sebuah bagian individu; hanya fragmen tersebut yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti pada tingkat Bagian memiliki prioritas tertinggi. Jika sebuah properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/), Aspose.Slides mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/python-java/aspose.slides/paragraph/). Jika tidak diatur di sana juga, Aspose.Slides menggunakan gaya [TextFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/textframe/) atau [theme](https://reference.aspose.com/slides/id/python-java/aspose.slides/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak ada di mesin atau server target?**

[Aturan substitusi font](/slides/id/python-java/font-selection-sequence/) diterapkan. Teks dapat mengalir kembali: metrik, hyphenasi, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi isi teks atau gradien khusus untuk bagian secara terpisah dari sisa paragraf?**

Ya, warna teks, isi, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/python-java/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.