---
title: Tinta
type: docs
weight: 180
url: /id/python-net/examples/elements/ink/
keywords:
- tinta
- mengakses tinta
- menghapus tinta
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tangani tinta digital pada slide di Python dengan Aspose.Slides: tambahkan goresan pena, edit jalur, atur warna dan lebar, serta ekspor hasil untuk PowerPoint dan OpenDocument."
---
Menyediakan contoh cara mengakses bentuk tinta yang ada dan menghapusnya menggunakan **Aspose.Slides for Python via .NET**.

> ❗ **Catatan:** Bentuk tinta mewakili masukan pengguna dari perangkat khusus. Aspose.Slides tidak dapat membuat goresan tinta baru secara programatis, tetapi Anda dapat membaca dan memodifikasi tinta yang sudah ada.

## **Akses Tinta**

Dapatkan bentuk tinta pertama dari slide.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Hapus Tinta**

Hapus sebuah bentuk tinta dari slide.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Mengasumsikan shape pertama adalah objek Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```