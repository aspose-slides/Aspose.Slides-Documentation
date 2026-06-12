---
title: Slide Master
type: docs
weight: 30
url: /id/python-net/examples/elements/master-slide/
keywords:
- slide master
- tambahkan slide master
- akses slide master
- hapus slide master
- slide master tidak terpakai
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Kelola slide master di Python dengan Aspose.Slides: buat, edit, kloning, dan format tema, latar belakang, placeholder untuk menyatukan slide di PowerPoint dan OpenDocument."
---
Master slides membentuk level teratas dari hierarki pewarisan slide di PowerPoint. Sebuah **master slide** mendefinisikan elemen desain umum seperti latar belakang, logo, dan pemformatan teks. **Layout slides** mewarisi dari master slides, dan **normal slides** mewarisi dari layout slides.

Artikel ini menunjukkan cara membuat, memodifikasi, dan mengelola master slides menggunakan Aspose.Slides untuk Python via .NET.

## **Tambahkan Master Slide**

Contoh ini menunjukkan cara membuat master slide baru dengan menggandakan master slide default.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Gandakan master slide default.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Master slides menyediakan cara untuk menerapkan branding yang konsisten atau elemen desain bersama di semua slide. Setiap perubahan yang dilakukan pada master akan secara otomatis tercermin pada layout dan normal slides yang bergantung.

> 💡 **Tip 2:** Setiap bentuk atau pemformatan yang ditambahkan ke master slide akan diwarisi oleh layout slides dan, pada gilirannya, semua normal slides yang menggunakan layout tersebut.  
> Gambar di bawah ini menggambarkan bagaimana kotak teks yang ditambahkan pada master slide secara otomatis ditampilkan pada slide akhir.

![Contoh Pewarisan Master](master-slide-banner.png)

## **Akses Master Slide**

Anda dapat mengakses master slides menggunakan koleksi `Presentation.masters`. Berikut cara mengambil dan bekerja dengan mereka:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Akses slide master pertama.
        first_master_slide = presentation.masters[0]
```

## **Hapus Master Slide**

Master slides dapat dihapus baik berdasarkan indeks maupun referensi.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Hapus berdasarkan indeks.
        presentation.masters.remove_at(0)

        # Atau hapus berdasarkan referensi.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Hapus Master Slides yang Tidak Digunakan**

Beberapa presentasi berisi master slides yang tidak digunakan. Menghapus slide tersebut dapat membantu mengurangi ukuran file.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Hapus semua master slide yang tidak terpakai (bahkan yang ditandai sebagai Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** Gunakan `remove_unused(True)` untuk membersihkan master slides yang tidak digunakan dan meminimalkan ukuran presentasi.