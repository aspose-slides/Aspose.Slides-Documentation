---
title: Slide
type: docs
weight: 10
url: /id/python-net/examples/elements/slide/
keywords:
- slide
- tambah slide
- akses slide
- indeks slide
- gandakan slide
- susun ulang slide
- hapus slide
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola slide dalam Python dengan Aspose.Slides: buat, gandakan, susun ulang, sembunyikan, atur latar belakang dan ukuran, terapkan transisi, serta ekspor untuk PowerPoint dan OpenDocument."
---
Artikel ini menyediakan serangkaian contoh yang menunjukkan cara bekerja dengan slide menggunakan **Aspose.Slides for Python via .NET**. Anda akan belajar cara menambahkan, mengakses, menggandakan, menyusun ulang, dan menghapus slide menggunakan kelas `Presentation`.

Setiap contoh di bawah ini mencakup penjelasan singkat diikuti dengan potongan kode dalam Python.

## **Menambahkan Slide**

Untuk menambahkan slide baru, Anda harus terlebih dahulu memilih tata letak. Pada contoh ini, kami menggunakan tata letak `Blank` dan menambahkan slide kosong ke presentasi.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Setiap slide didasarkan pada tata letak, yang sendiri didasarkan pada master slide.
        # Gunakan tata letak Blank untuk membuat slide baru.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Add a new empty slide using the selected layout.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip:** Setiap tata letak slide berasal dari master slide, yang menentukan desain keseluruhan dan struktur placeholder. Gambar di bawah ini menggambarkan bagaimana master slide dan tata letak terkait diatur dalam PowerPoint.

![Hubungan Master dan Tata Letak](master-layout-slide.png)

## **Mengakses Slide menurut Indeks**

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Akses slide dengan indeks.
        first_slide = presentation.slides[0]
```

## **Menggandakan Slide**

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Gandakan slide; akan ditambahkan di akhir presentasi.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Menyusun Ulang Slide**

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Pindahkan slide ke posisi pertama (slide lain bergeser ke bawah).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Menghapus Slide**

Untuk menghapus slide, cukup referensikan slide tersebut dan panggil `remove`. Contoh ini menghapus slide pertama.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Hapus slide.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```