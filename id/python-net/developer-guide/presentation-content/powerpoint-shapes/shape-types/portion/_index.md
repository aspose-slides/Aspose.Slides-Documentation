---
title: Kelola Bagian Teks dalam Presentasi dengan Python
linktitle: Bagian Teks
type: docs
weight: 70
url: /id/python-net/portion/
keywords:
- potongan teks
- bagian teks
- koordinat teks
- posisi teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara mengelola bagian teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET, meningkatkan kinerja dan penyesuaian."
---
## **Pengantar**

Sebuah bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten sekitarnya. Di Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil posisi sebuah fragmen teks, menerapkan format hanya pada bagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih detail.

## **Dapatkan Koordinat Bagian Teks**

Metode [get_coordinates](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/get_coordinates/) telah ditambahkan ke kelas [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) yang memungkinkan pengambilan koordinat bagian teks:

```py
import aspose.slides as slides

with slides.Presentation("HelloWorld.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame = shape.text_frame

    for paragraph in text_frame.paragraphs:
        for portion in paragraph.portions:
            point = portion.get_coordinates()
            print("Corrdinates X =" + str(point.x) + " Corrdinates Y =" + str(point.y))
```

## **FAQ**

**Bisakah saya menerapkan hyperlink hanya pada bagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/python-net/manage-hyperlinks/) pada bagian individu; hanya fragmen itu yang dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang ditimpa oleh Portion, dan apa yang diambil dari Paragraph/TextFrame?**

Properti tingkat Portion memiliki prioritas tertinggi. Jika properti tidak disetel pada [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/), mesin mengambilnya dari [Paragraph](https://reference.aspose.com/slides/id/python-net/aspose.slides/paragraph/); jika tidak disetel di sana juga, dari [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/) atau gaya [theme](https://reference.aspose.com/slides/id/python-net/aspose.slides.theme/theme/).

**Apa yang terjadi jika font yang ditentukan untuk sebuah Portion tidak ada di mesin/server target?**

[aturan substitusi font](/slides/id/python-net/font-selection-sequence/) diterapkan. Teks dapat berubah alurnya: metrik, hyphenation, dan lebar dapat berubah, yang memengaruhi penempatan yang tepat.

**Bisakah saya mengatur transparansi atau gradien isi teks khusus Portion terlepas dari paragraf lainnya?**

Ya, warna teks, isi, dan transparansi pada tingkat [Portion](https://reference.aspose.com/slides/id/python-net/aspose.slides/portion/) dapat berbeda dari fragmen tetangga.