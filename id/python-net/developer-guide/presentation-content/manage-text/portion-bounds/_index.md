---
title: Dapatkan Batas Bagian Teks dari Presentasi dengan Python
linktitle: Batas Bagian
type: docs
weight: 47
url: /id/python-net/portion-bounds/
keywords:
- batas bagian teks
- bagian teks
- potongan teks
- koordinat teks
- posisi teks
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen teks tertentu di dalam paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil batas fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih detail.

Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [Portion.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/get_rect/). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [Portion.get_coordinates](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/get_coordinates/). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami bagaimana pemformatan diselesaikan melalui bagian, paragraf, bingkai teks, dan pewarisan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Bagian Teks**

Gunakan [Portion.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/get_rect/) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            rectangle = portion.get_rect()
            print(f"X = {rectangle.x}; Y = {rectangle.y}; Width = {rectangle.width}; Height = {rectangle.height}")
```

## **Dapatkan Koordinat Bagian Teks**

Gunakan [Portion.get_coordinates](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/get_coordinates/) untuk mengambil koordinat awal sebuah bagian teks:

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    for paragraph in shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print(f"X = {point.x}; Y = {point.y}")
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada bagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/python-net/manage-hyperlinks/) ke sebuah bagian individual; hanya fragmen itu yang akan dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang di-override oleh bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti pada tingkat Bagian memiliki prioritas tertinggi. Jika suatu properti tidak diatur pada [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/), Aspose.Slides mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/). Jika tidak diatur di sana juga, Aspose.Slides menggunakan gaya [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) atau [theme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/theme/) .

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak ada di mesin atau server target?**

[Aturan substitusi font](/slides/id/python-net/font-selection-sequence/) berlaku. Teks dapat mengalami reflow: metrik, hyphenasi, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi atau gradien isian teks khusus bagian secara terpisah dari sisa paragraf?**

Ya, warna teks, isian, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.