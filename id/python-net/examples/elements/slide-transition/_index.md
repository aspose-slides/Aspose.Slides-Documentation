---
title: Transisi Slide
type: docs
weight: 110
url: /id/python-net/examples/elements/slide-transition/
keywords:
- transisi slide
- menambah transisi slide
- akses transisi slide
- hapus transisi slide
- durasi transisi
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kontrol transisi slide dalam Python dengan Aspose.Slides: pilih tipe, kecepatan, suara, dan penjadwalan untuk menyempurnakan presentasi dalam format PPT, PPTX, dan ODP."
---
Menunjukkan cara menerapkan efek transisi slide dan penjadwalan dengan **Aspose.Slides for Python via .NET**.

## **Tambahkan Transisi Slide**

Terapkan efek transisi memudar pada slide pertama.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Terapkan transisi memudar.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Transisi Slide**

Baca jenis transisi yang saat ini ditetapkan pada slide.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses jenis transisi.
        transition_type = slide.slide_show_transition.type
```

## **Hapus Transisi Slide**

Hapus semua efek transisi dengan menyetel jenisnya ke `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Hapus transisi dengan menyetel none.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Atur Durasi Transisi**

Tentukan berapa lama slide ditampilkan sebelum berpindah otomatis.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # dalam milidetik.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```