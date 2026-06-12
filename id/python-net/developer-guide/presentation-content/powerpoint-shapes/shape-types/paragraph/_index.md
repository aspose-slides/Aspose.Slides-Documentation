---
title: Dapatkan Batas Paragraf dari Presentasi di Python
linktitle: Paragraf
type: docs
weight: 60
url: /id/python-net/paragraph/
keywords:
- batas paragraf
- batas bagian teks
- koordinat paragraf
- koordinat bagian
- ukuran paragraf
- ukuran bagian teks
- frame teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf dan bagian teks di Aspose.Slides untuk Python via .NET untuk mengoptimalkan penempatan teks dalam presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf serta bagian teks dalam Aspose.Slides. Menunjukkan cara mengambil persegi panjang paragraf dalam `TextFrame` dengan menggunakan `get_rect()`, cara mendapatkan koordinat paragraf dan bagian di dalam teks frame sel tabel, serta menyoroti detail penting seperti satuan pengukuran, efek pembungkus teks pada batas, konversi piksel, dan nilai format paragraf efektif.

## **Dapatkan Koordinat Paragraf dan Bagian dalam TextFrame**
Dengan menggunakan Aspose.Slides untuk Python via .NET, pengembang kini dapat mendapatkan koordinat persegi panjang untuk Paragraph di dalam koleksi paragraf TextFrame. Ini juga memungkinkan Anda mendapatkan koordinat bagian di dalam koleksi bagian dari sebuah paragraf. Dalam topik ini, kami akan mendemonstrasikan dengan contoh cara mendapatkan koordinat persegi panjang untuk paragraf beserta posisi bagian di dalam paragraf.

## **Dapatkan Koordinat Persegi Panjang Paragraf**
Metode baru **GetRect()** telah ditambahkan. Metode ini memungkinkan untuk mendapatkan persegi panjang batas paragraf.

```py
import aspose.slides as slides

# Buat objek Presentation yang mewakili berkas presentasi
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Dapatkan ukuran paragraf dan bagian di dalam teks frame sel tabel** ##

Untuk mendapatkan ukuran dan koordinat [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) atau [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/) dalam teks frame sel tabel, Anda dapat menggunakan metode [IPortion.GetRect](https://reference.aspose.com/slides/id/python-net/aspose.slides/iportion/) dan [IParagraph.GetRect](https://reference.aspose.com/slides/id/python-net/aspose.slides/iparagraph/).

Kode contoh ini mendemonstrasikan operasi yang dijelaskan:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**Dalam satuan apa koordinat yang dikembalikan untuk paragraf dan bagian teks diukur?**

Dalam poin, di mana 1 inci = 72 poin. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [wrapping](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframeformat/wrap_text/) diaktifkan di [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), teks akan terputus untuk menyesuaikan lebar area, yang mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversi poin ke piksel dengan: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering/ekspor.

**Bagaimana cara mendapatkan parameter pemformatan paragraf "efektif", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/python-net/shape-effective-properties/); itu mengembalikan nilai akhir yang terkonsolidasi untuk indentasi, spasi, pembungkus, RTL, dan lainnya.