---
title: Bagian
type: docs
weight: 90
url: /id/python-net/examples/elements/section/
keywords:
- bagian
- bagian slide
- tambahkan bagian
- akses bagian
- hapus bagian
- ganti nama bagian
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola bagian slide dalam Python dengan Aspose.Slides: buat, ganti nama, urutkan ulang dengan mudah, pindahkan slide antar bagian, dan kontrol visibilitas untuk PPT, PPTX, dan ODP."
---
Contoh mengelola bagian presentasi—menambah, mengakses, menghapus, dan mengganti nama secara programatis menggunakan **Aspose.Slides for Python via .NET**.

## **Tambah Bagian**

Buat bagian yang dimulai pada slide tertentu.

```py
def add_section():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Tambahkan bagian baru dan tentukan slide yang menandai awal bagian tersebut.
        presentation.sections.add_section("New Section", slide)

        presentation.save("section.pptx", slides.export.SaveFormat.PPTX)
```

## **Akses Bagian**

Dapatkan bagian dari sebuah presentasi.

```py
def access_section():
    with slides.Presentation("section.pptx") as presentation:

        # Akses sebuah bagian berdasarkan indeks.
        section = presentation.sections[0]
```

## **Hapus Bagian**

Hapus bagian yang sebelumnya ditambahkan.

```py
def remove_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Hapus bagian tersebut.
        presentation.sections.remove_section(section)

        presentation.save("section_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ganti Nama Bagian**

Ubah nama bagian yang ada.

```py
def rename_section():
    with slides.Presentation("section.pptx") as presentation:
        section = presentation.sections[0]

        # Ganti nama bagian.
        section.name = "New Name"

        presentation.save("section_renamed.pptx", slides.export.SaveFormat.PPTX)
```