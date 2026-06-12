---
title: Ekstraksi Teks Lanjutan dari Presentasi di Python
linktitle: Ekstrak Teks
type: docs
weight: 90
url: /id/python-net/extract-text-from-presentation/
keywords:
- ekstrak teks
- ekstrak teks dari slide
- ekstrak teks dari presentasi
- ekstrak teks dari PowerPoint
- ekstrak teks dari OpenDocument
- ekstrak teks dari PPT
- ekstrak teks dari PPTX
- ekstrak teks dari ODP
- mengambil teks
- mengambil teks dari slide
- mengambil teks dari presentasi
- mengambil teks dari PowerPoint
- mengambil teks dari OpenDocument
- mengambil teks dari PPT
- mengambil teks dari PPTX
- mengambil teks dari ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Ekstrak teks dengan cepat dari presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET. Ikuti panduan sederhana langkah demi langkah kami untuk menghemat waktu."
---
## **Gambaran Umum**

Mengekstrak teks dari presentasi adalah tugas yang umum namun penting bagi pengembang yang bekerja dengan konten slide. Baik Anda menangani file Microsoft PowerPoint dalam format PPT atau PPTX, maupun presentasi OpenDocument (ODP), mengakses dan mengambil data teks dapat menjadi kritis untuk analisis, otomasi, pengindeksan, atau tujuan migrasi konten.

Artikel ini memberikan panduan komprehensif tentang cara mengekstrak teks secara efisien dari berbagai format presentasi, termasuk PPT, PPTX, dan ODP, menggunakan Aspose.Slides for Python via .NET. Anda akan belajar cara mengiterasi elemen presentasi secara sistematis untuk mengambil konten teks yang Anda butuhkan dengan tepat.

## **Ekstrak Teks dari Slide**

Aspose.Slides for Python via .NET menyediakan namespace [aspose.slides.util](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/) yang mencakup kelas [SlideUtil](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/). Kelas ini menyediakan beberapa metode statis yang di‑overload untuk mengekstrak semua teks dari presentasi atau slide. Untuk mengekstrak teks dari sebuah slide dalam presentasi, gunakan metode [get_all_text_boxes](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/get_all_text_boxes/). Metode ini menerima objek bertipe [BaseSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslide/) sebagai parameter. Saat dijalankan, metode ini memindai seluruh slide untuk teks dan mengembalikan array objek bertipe [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), mempertahankan semua format teks.

Potongan kode berikut mengekstrak semua teks dari slide pertama presentasi:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Ekstrak Teks dari Presentasi**

Untuk memindai teks dari seluruh presentasi, gunakan metode statis [get_all_text_frames](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/get_all_text_frames/) yang disediakan oleh kelas [SlideUtil](https://reference.aspose.com/slides/id/python-net/aspose.slides.util/slideutil/). Metode ini menerima dua parameter:

1. Pertama, objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) yang mewakili presentasi PowerPoint atau OpenDocument dari mana teks akan diekstrak.
2. Kedua, nilai `Boolean` yang menunjukkan apakah slide master harus disertakan saat memindai teks dari presentasi.

Metode ini mengembalikan array objek bertipe [TextFrame](https://reference.aspose.com/slides/id/python-net/aspose.slides/textframe/), termasuk informasi pemformatan teks. Kode di bawah ini memindai teks dan detail pemformatan dari sebuah presentasi, termasuk slide master.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Ekstraksi Teks Terstruktur dan Cepat**

Kelas [PresentationFactory](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationfactory/) juga menyediakan metode untuk mengekstrak semua teks dari presentasi:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

Argumen enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/id/python-net/aspose.slides/textextractionarrangingmode/) menunjukkan mode pengorganisasian hasil ekstraksi teks dan dapat disetel ke nilai berikut:
- `UNARRANGED` - Teks mentah tanpa memperhatikan posisi pada slide.
- `ARRANGED` - Teks diatur dalam urutan yang sama seperti pada slide.

Mode `UNARRANGED` dapat digunakan ketika kecepatan menjadi faktor kritis; mode ini lebih cepat daripada mode `ARRANGED`.

[PresentationText](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentationtext/) mewakili teks mentah yang diekstrak dari presentasi. Properti `slides_text`‑nya mengembalikan array objek teks slide. Setiap objek mewakili teks pada slide yang bersangkutan dan memiliki properti berikut:

- `text` - Teks dalam bentuk‑bentuk pada slide.
- `master_text` - Teks dalam bentuk‑bentuk slide master yang terkait dengan slide ini.
- `layout_text` - Teks dalam bentuk‑bentuk slide tata letak yang terkait dengan slide ini.
- `notes_text` - Teks dalam bentuk‑bentuk slide catatan yang terkait dengan slide ini.
- `comments_text` - Teks dalam komentar yang terkait dengan slide ini.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **FAQ**

**Seberapa cepat Aspose.Slides memproses presentasi besar saat mengekstrak teks?**

Aspose.Slides dioptimalkan untuk kinerja tinggi dan dapat memproses bahkan [presentasi besar](/slides/id/python-net/open-presentation/), sehingga cocok untuk skenario pemrosesan real‑time atau bulk.

**Apakah Aspose.Slides dapat mengekstrak teks dari tabel dan diagram dalam presentasi?**

Ya. Aspose.Slides dapat mengekstrak teks dari banyak elemen slide, termasuk tabel dan objek terkait diagram, sehingga Anda dapat mengakses dan menganalisis konten teks dalam struktur presentasi yang umum.

**Apakah saya memerlukan lisensi khusus Aspose.Slides untuk mengekstrak teks dari presentasi?**

Anda dapat mengekstrak teks menggunakan versi percobaan gratis Aspose.Slides, meskipun akan ada [pembatasan tertentu](/slides/id/python-net/licensing/), seperti pemrosesan hanya sejumlah slide terbatas. Untuk penggunaan tanpa batas dan menangani presentasi yang lebih besar, disarankan membeli lisensi penuh.