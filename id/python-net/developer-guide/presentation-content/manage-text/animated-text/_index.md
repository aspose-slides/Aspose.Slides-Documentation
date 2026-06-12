---
title: Animasi Teks PowerPoint di Python
linktitle: Teks Animasi
type: docs
weight: 60
url: /id/python-net/animated-text/
keywords:
- teks animasi
- animasi teks
- paragraf animasi
- animasi paragraf
- efek animasi
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Buat teks animasi dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Python via .NET, dengan contoh kode yang mudah diikuti dan dioptimalkan."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara menggerakkan teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk Python. Anda akan belajar menambahkan efek ke paragraf individu, mengatur pemicu, dan membaca kembali urutan animasi yang ada. Pada akhirnya, Anda akan dapat membuat alur kerja animasi teks yang dapat digunakan kembali, mengekspor ke PPTX standar, dan diputar dengan benar di PowerPoint.

## **Menambahkan Efek Animasi Paragraf**

Metode [add_effect](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/add_effect/) dari kelas [Sequence](https://reference.aspose.com/slides/id/python-net/aspose.slides.animation/sequence/) memungkinkan Anda menerapkan efek animasi pada satu paragraf. Kode contoh di bawah ini menunjukkan cara melakukannya:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    # Pilih paragraf untuk menambahkan efek.
    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Tambahkan efek animasi Fly ke paragraf yang dipilih.
    effect = slide.timeline.main_sequence.add_effect(paragraph,
                                                     slides.animation.EffectType.FLY,
                                                     slides.animation.EffectSubtype.LEFT,
                                                     slides.animation.EffectTriggerType.ON_CLICK)
    presentation.save("ParagraphAnimationEffect.pptx", slides.export.SaveFormat.PPTX)
```

## **Mendapatkan Efek Animasi Paragraf**

Anda mungkin ingin menentukan efek animasi apa yang diterapkan pada sebuah paragraf—misalnya, jika Anda berencana menyalin efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk Python memungkinkan Anda mengambil semua efek animasi yang diterapkan pada paragraf dalam sebuah bingkai teks (shape). Kode contoh di bawah ini memperlihatkan cara mendapatkan efek animasi sebuah paragraf:

```py
import aspose.slides as slides

with slides.Presentation("ParagraphAnimationEffect.pptx") as presentation:
    slide = presentation.slides[0]
    sequence = slide.timeline.main_sequence
    auto_shape = slide.shapes[0]

    for paragraph in auto_shape.text_frame.paragraphs:
        effects = sequence.get_effects_by_paragraph(paragraph)
        if len(effects) > 0:
            print(f"Paragraph \"{paragraph.text}\" has the first animation effect of type {str(effects[0].type)}.")
```

## **FAQ**

**Bagaimana animasi teks berbeda dari transisi slide, dan apakah keduanya dapat digabungkan?**

Animasi teks mengontrol perilaku objek seiring waktu pada sebuah slide, sementara [transitions](/slides/id/python-net/slide-transition/) mengontrol cara slide beralih. Kedua hal ini bersifat independen dan dapat digunakan bersama; urutan pemutaran diatur oleh garis waktu animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda hanya akan melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan gerakan, gunakan ekspor [video](/slides/id/python-net/convert-powerpoint-to-video/) atau [HTML](/slides/id/python-net/export-to-html5/).

**Apakah animasi teks berfungsi di tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, tetapi timing dan interaksinya dengan animasi pada tingkat slide tergantung pada urutan akhir di slide.