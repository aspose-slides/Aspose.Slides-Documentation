---
title: Kelola Superskrip dan Subskrip di Python
linktitle: Superskrip dan Subskrip
type: docs
weight: 80
url: /id/python-net/superscript-and-subscript/
keywords:
- superskrip
- subskrip
- tambahkan superskrip
- tambahkan subskrip
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kuasi superskrip dan subskrip di Aspose.Slides untuk Python via .NET dan tingkatkan presentasi Anda dengan pemformatan teks profesional untuk dampak maksimal."
---
## **Overview**

Aspose.Slides menyediakan fitur untuk mengintegrasikan teks superskrip dan subskrip ke dalam presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) Anda. Baik Anda perlu menyoroti rumus kimia, persamaan matematika, atau memberi anotasi pada konten dengan catatan kaki, opsi pemformatan khusus ini membantu menjaga kejelasan dan ketelitian. Dalam artikel ini, Anda akan mempelajari cara menerapkan gaya superskrip dan subskrip secara mulus serta memastikan hasil yang profesional di setiap slide.

## **Add Superscript and Subscript Text**

Anda dapat menambahkan teks superskrip dan subskrip ke bagian manapun dalam paragraf. Di Aspose.Slides, gunakan properti `escapement` dari kelas [PortionFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/portionformat/) untuk mengendalikan ini.

`escapement` adalah persentase dari **-100% hingga 100%**:

- **> 0** → superskrip (mis., 25% = kenaikan sedikit; 100% = superskrip penuh)
- **0** → garis dasar (tanpa super/subskrip)
- **< 0** → subskrip (mis., -25% = penurunan sedikit; -100% = subskrip penuh)

Langkah:

1. Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan dapatkan sebuah slide.
1. Tambahkan sebuah [AutoShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/autoshape/) persegi panjang dan akses [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) miliknya.
1. Bersihkan paragraf yang ada.
1. Untuk superskrip: buat sebuah paragraf dan sebuah bagian, atur `portion.portion_format.escapement` ke nilai antara **0 dan 100**, atur teks, dan tambahkan bagian tersebut.
1. Untuk subskrip: buat paragraf dan bagian lain, atur `escapement` ke nilai antara **-100 dan 0**, atur teks, dan tambahkan bagian tersebut.
1. Simpan presentasi sebagai PPTX.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    # Dapatkan slide.
    slide = presentation.slides[0]

    # Buat kotak teks.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 200, 100)
    shape.text_frame.paragraphs.clear()

    # Buat paragraf untuk teks superskrip.
    superscript_paragraph = slides.Paragraph()

    # Buat bagian teks dengan teks biasa.
    portion1 = slides.Portion()
    portion1.text = "SlideTitle"
    superscript_paragraph.portions.add(portion1)

    # Buat bagian teks dengan teks superskrip.
    superscript_portion = slides.Portion()
    superscript_portion.portion_format.escapement = 30
    superscript_portion.text = "TM"
    superscript_paragraph.portions.add(superscript_portion)

    # Buat paragraf untuk teks subskrip.
    subscript_paragraph = slides.Paragraph()

    # Buat bagian teks dengan teks biasa.
    portion2 = slides.Portion()
    portion2.text = "a"
    subscript_paragraph.portions.add(portion2)

    # Buat bagian teks dengan teks subskrip.
    subscript_portion = slides.Portion()
    subscript_portion.portion_format.escapement = -25
    subscript_portion.text = "i"
    subscript_paragraph.portions.add(subscript_portion)

    # Tambahkan paragraf ke kotak teks.
    shape.text_frame.paragraphs.add(superscript_paragraph)
    shape.text_frame.paragraphs.add(subscript_paragraph)

    presentation.save("TestOut.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat menerapkan superskrip/subskrip dalam tabel dan kontainer lain, tidak hanya kotak teks biasa?**

Ya. Anda dapat memformat teks sebagai superskrip atau subskrip di dalam objek apa pun yang menampilkan sebuah [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) (termasuk sel tabel). Pemformatan ini berlaku pada bagian teks di dalam frame tersebut.

**Apakah superskrip/subskrip akan dipertahankan saat mengekspor ke PDF, HTML, atau gambar?**

Ya. Aspose.Slides mempertahankan pemformatan superskrip/subskrip selama ekspor ke format umum seperti [PDF](/slides/id/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/id/python-net/convert-powerpoint-to-html/), dan [raster images](/slides/id/python-net/convert-powerpoint-to-png/) karena pipeline rendering menghormati pemformatan teks pada tingkat bagian.

**Apakah saya dapat menggabungkan superskrip/subskrip dengan hyperlink dalam fragmen teks yang sama?**

Ya. [Hyperlinks](/slides/id/python-net/manage-hyperlinks/) ditetapkan pada tingkat bagian (fragmen), sehingga sebuah bagian dapat sekaligus memiliki hyperlink dan diformat sebagai superskrip atau subskrip.