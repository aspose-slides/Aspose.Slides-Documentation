---
title: Dapatkan Batas Paragraf dari Presentasi di Python
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/python-net/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- bingkai teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk Python melalui .NET guna mengoptimalkan penempatan teks dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf di Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) dengan menggunakan [Paragraph.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/get_rect/), cara mendapatkan koordinat paragraf di dalam bingkai teks sel tabel, serta menyoroti detail penting seperti satuan pengukuran, pengaruh pembungkus teks terhadap batas, konversi piksel, dan nilai format paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang Paragraf**

Gunakan [Paragraph.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/get_rect/) untuk mendapatkan persegi panjang pembatas sebuah paragraf.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Dapatkan Ukuran Paragraf di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dalam text frame sel tabel, gunakan [Paragraph.get_rect](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/get_rect/). Persegi panjang yang dikembalikan relatif terhadap text frame sel tabel, sehingga tambahkan posisi tabel dan offset sel bila Anda memerlukan koordinat pada tingkat slide.

Contoh berikut mendapatkan batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Dalam satuan apa koordinat paragraf diukur?**

Koordinat diukur dalam poin, di mana 1 inci sama dengan 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/wrap_text/) diaktifkan untuk [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversi poin ke piksel menggunakan rumus berikut: pixels = points x (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk render atau ekspor.

**Bagaimana cara saya mendapatkan parameter format paragraf "effective", dengan memperhitungkan warisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/python-net/shape-effective-properties/); ini mengembalikan nilai akhir yang dikonsolidasikan untuk indentasi, spasi, pembungkus, RTL, dan lainnya.