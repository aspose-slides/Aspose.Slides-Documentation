---
title: "Hyperlink"
type: docs
weight: 130
url: /id/python-net/examples/elements/hyperlink/
keywords:
- "tautan hiper"
- "menambahkan tautan hiper"
- "mengakses tautan hiper"
- "menghapus tautan hiper"
- "memperbarui tautan hiper"
- "contoh kode"
- "PowerPoint"
- "OpenDocument"
- "presentasi"
- "Python"
- "Aspose.Slides"
description: "Tambahkan, edit, dan hapus hyperlink dalam Python dengan Aspose.Slides: teks tautan, bentuk, slide, URL, dan email; atur target serta aksi untuk PPT, PPTX, dan ODP."
---
Menunjukkan cara menambahkan, mengakses, menghapus, dan memperbarui hyperlink pada bentuk menggunakan **Aspose.Slides for Python via .NET**.

## **Tambah Hyperlink**

Buat bentuk persegi panjang dengan hyperlink yang mengarah ke situs web eksternal.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Hyperlink**

Baca informasi hyperlink dari bagian teks sebuah bentuk.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Hapus Hyperlink**

Hapus hyperlink dari teks sebuah bentuk.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Perbarui Hyperlink**

Ubah target hyperlink yang ada. Gunakan `HyperlinkManager` untuk memodifikasi teks yang sudah berisi hyperlink, yang meniru cara PowerPoint memperbarui hyperlink secara aman.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Mengubah hyperlink dalam teks yang ada sebaiknya dilakukan melalui
        # HyperlinkManager daripada mengatur properti secara langsung.
        # Ini meniru cara PowerPoint memperbarui hyperlink dengan aman.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```