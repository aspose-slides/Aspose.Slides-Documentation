---
title: Slide Tata Letak
type: docs
weight: 20
url: /id/python-net/examples/elements/layout-slide/
keywords:
- slide tata letak
- tambahkan slide tata letak
- akses slide tata letak
- hapus slide tata letak
- slide tata letak yang tidak terpakai
- gandakan slide tata letak
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Gunakan Python untuk mengelola slide tata letak dengan Aspose.Slides: membuat, menerapkan, menggandakan, mengganti nama, dan menyesuaikan placeholder serta tema dalam presentasi untuk PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara bekerja dengan **Layout Slides** dalam Aspose.Slides untuk Python via .NET. Slide tata letak mendefinisikan desain dan pemformatan yang diwarisi oleh slide normal. Anda dapat menambah, mengakses, menggandakan, dan menghapus slide tata letak, serta membersihkan yang tidak terpakai untuk mengurangi ukuran presentasi.

## **Add a Layout Slide**

Anda dapat membuat slide tata letak khusus untuk mendefinisikan pemformatan yang dapat digunakan kembali.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Buat slide tata letak dengan tipe dan nama yang ditentukan.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Slide tata letak berfungsi sebagai templat untuk slide individu. Anda dapat mendefinisikan elemen umum sekali dan menggunakannya kembali di banyak slide.

> 💡 **Tip 2:** Ketika Anda menambahkan bentuk atau teks ke slide tata letak, semua slide yang berbasis pada tata letak tersebut akan menampilkan konten bersama ini secara otomatis.  
> Screenshot di bawah menunjukkan dua slide, masing‑masing mewarisi kotak teks dari slide tata letak yang sama.

![Slide yang Mewarisi Konten Tata Letak](layout-slide-result.png)


## **Access a Layout Slide**

Slide tata letak dapat diakses berdasarkan indeks atau jenis tata letak (misalnya `Blank`, `Title`, `SectionHeader`, dll.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Akses berdasarkan indeks.
        first_layout_slide = presentation.layout_slides[0]

        # Akses berdasarkan tipe tata letak.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Remove a Layout Slide**

Anda dapat menghapus slide tata letak tertentu jika tidak lagi diperlukan.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Dapatkan slide tata letak berdasarkan tipe dan hapus.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Unused Layout Slides**

Untuk mengurangi ukuran presentasi, Anda mungkin ingin menghapus slide tata letak yang tidak digunakan oleh slide normal mana pun.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Secara otomatis menghapus semua slide tata letak yang tidak direferensikan oleh slide mana pun.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Clone a Layout Slide**

Anda dapat menduplikasi slide tata letak menggunakan metode `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Dapatkan slide tata letak yang ada berdasarkan tipe.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Gandakan slide tata letak ke akhir koleksi slide tata letak.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Summary:** Layout slides adalah alat yang kuat untuk mengelola pemformatan konsisten di seluruh slide. Aspose.Slides memungkinkan kontrol penuh atas pembuatan, pengelolaan, dan pengoptimalan slide tata letak.