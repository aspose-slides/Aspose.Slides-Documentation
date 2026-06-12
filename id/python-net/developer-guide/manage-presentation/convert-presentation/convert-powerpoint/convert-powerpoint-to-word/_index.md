---
title: Konversi Presentasi PowerPoint ke Dokumen Word dengan Python
linktitle: PowerPoint ke Word
type: docs
weight: 110
url: /id/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint ke DOCX
- OpenDocument ke DOCX
- presentasi ke DOCX
- slide ke DOCX
- PPT ke DOCX
- PPTX ke DOCX
- ODP ke DOCX
- PowerPoint ke DOC
- OpenDocument ke DOC
- presentasi ke DOC
- slide ke DOC
- PPT ke DOC
- PPTX ke DOC
- ODP ke DOC
- PowerPoint ke Word
- OpenDocument ke Word
- presentasi ke Word
- slide ke Word
- PPT ke Word
- PPTX ke Word
- ODP ke Word
- konversi PowerPoint
- konversi OpenDocument
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- konversi ODP
- Python
- Aspose.Slides
description: "Pelajari cara dengan mudah mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word menggunakan Aspose.Slides for Python via .NET. Panduan langkah demi langkah kami dengan contoh kode Python menyediakan solusi bagi pengembang yang ingin menyederhanakan alur kerja dokumen mereka."
---
## **Gambaran Umum**

Artikel ini menyediakan solusi bagi pengembang untuk mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word menggunakan Aspose.Slides for Python via .NET dan Aspose.Words for Python via .NET. Panduan langkah demi langkah ini akan mengarahkan Anda melalui setiap tahap proses konversi.

## **Mengonversi Presentasi ke Dokumen Word**

Ikuti instruksi di bawah ini untuk mengonversi presentasi PowerPoint atau OpenDocument ke dokumen Word:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan muat file presentasi.  
2. Buat instance kelas [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) dan [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) untuk menghasilkan dokumen Word.  
3. Atur ukuran halaman dokumen Word agar cocok dengan presentasi menggunakan properti [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
4. Atur margin pada dokumen Word menggunakan properti [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).  
5. Iterasi seluruh slide presentasi menggunakan properti [Presentation.slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/).  
    - Hasilkan gambar slide dengan menggunakan metode `get_image` dari kelas [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/) dan simpan ke aliran memori.  
    - Tambahkan gambar slide ke dokumen Word menggunakan metode `insert_image` dari kelas [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/).  
6. Simpan dokumen Word ke file.

Misalkan kita memiliki presentasi "sample.pptx" yang terlihat seperti ini:

![Presentasi PowerPoint](PowerPoint.png)

Contoh kode Python berikut menunjukkan cara mengonversi presentasi PowerPoint ke dokumen Word:

```py
import aspose.slides as slides
import aspose.words as words

# Muat file presentasi.
with slides.Presentation("sample.pptx") as presentation:

    # Buat objek Document dan DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Atur ukuran halaman di dokumen Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Atur margin di dokumen Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Lakukan iterasi semua slide presentasi.
    for slide in presentation.slides:

        # Hasilkan gambar slide dan simpan ke aliran memori.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Tambahkan gambar slide ke dokumen Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Simpan dokumen Word ke file.
    document.save("output.docx")
```

Hasilnya:

![Dokumen Word](Word.png)

{{% alert color="primary" %}} 
Coba [**Online PPT to Word Converter**](https://products.aspose.app/slides/id/conversion/ppt-to-word) kami untuk melihat manfaat yang Anda dapatkan dari mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word. 
{{% /alert %}}

## **FAQ**

**Komponen apa yang perlu diinstal untuk mengonversi presentasi PowerPoint dan OpenDocument ke dokumen Word?**

Anda hanya perlu menambahkan paket yang bersangkutan untuk [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) dan [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) ke proyek Python Anda. Kedua paket berfungsi sebagai API mandiri, dan tidak diperlukan pemasangan Microsoft Office.

**Apakah semua format presentasi PowerPoint dan OpenDocument didukung?**

Aspose.Slides for Python .NET [mendukung semua format presentasi](/slides/id/python-net/supported-file-formats/), termasuk PPT, PPTX, ODP, dan jenis file umum lainnya. Ini memastikan Anda dapat bekerja dengan presentasi yang dibuat dalam berbagai versi Microsoft PowerPoint.