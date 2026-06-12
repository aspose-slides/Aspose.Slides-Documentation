---
title: "HeaderFooter"
type: docs
weight: 220
url: /id/python-net/examples/elements/header-footer/
keywords:
- "header footer"
- "menambahkan header footer"
- "memperbarui header footer"
- "mengatur tanggal dan waktu"
- "contoh kode"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Python"
- "Aspose.Slides"
description: "Kontrol header dan footer di Python dengan Aspose.Slides: tambahkan atau edit tanggal/waktu, nomor slide, dan teks footer, tampilkan atau sembunyikan placeholder di seluruh PPT, PPTX, dan ODP."
---
Menampilkan cara menambahkan footer dan memperbarui placeholder tanggal serta waktu menggunakan **Aspose.Slides for Python via .NET**.

## **Menambahkan Footer**

Tambahkan teks ke area footer slide dan buat terlihat.

```py
def add_footer():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_footer_text("My footer")
        slide.header_footer_manager.set_footer_visibility(True)

        presentation.save("footer.pptx", slides.export.SaveFormat.PPTX)
```

## **Perbarui Tanggal dan Waktu**

Ubah placeholder tanggal dan waktu pada slide.

```py
def add_date_time():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        slide.header_footer_manager.set_date_time_text("01/01/2024")
        slide.header_footer_manager.set_date_time_visibility(True)

        presentation.save("date_time.pptx", slides.export.SaveFormat.PPTX)
```