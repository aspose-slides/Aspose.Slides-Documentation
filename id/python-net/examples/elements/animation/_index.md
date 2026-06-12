---
title: Animasi
type: docs
weight: 100
url: /id/python-net/examples/elements/animation/
keywords:
- animasi
- menambahkan animasi
- mengakses animasi
- menghapus animasi
- urutan animasi
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kuasi animasi slide di Python dengan Aspose.Slides: menambahkan, mengedit, dan menghapus efek, pengaturan waktu, serta pemicu untuk membuat presentasi dinamis dalam format PPT, PPTX, dan ODP."
---
Menampilkan cara membuat animasi sederhana dan mengelola urutannya menggunakan **Aspose.Slides for Python via .NET**.

## **Menambahkan Animasi**

Buat bentuk persegi panjang dan terapkan efek memudar yang dipicu saat diklik.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Tambahkan efek memudar.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengakses Animasi**

Ambil efek animasi pertama dari timeline slide.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Akses efek animasi pertama.
        effect = slide.timeline.main_sequence[0]
```

## **Menghapus Animasi**

Hapus efek animasi dari urutan.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Asumsikan urutan utama berisi setidaknya satu efek.
        effect = slide.timeline.main_sequence[0]

        # Hapus efek tersebut.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyusun Urutan Animasi**

Tambahkan beberapa efek dan tunjukkan urutan terjadinya animasi.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```