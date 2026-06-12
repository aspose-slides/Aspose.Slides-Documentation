---
title: Menambahkan Slide ke Presentasi dengan Python
linktitle: Tambah Slide
type: docs
weight: 10
url: /id/python-net/add-slide-to-presentation/
keywords:
- menambah slide
- membuat slide
- slide kosong
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Tambahkan slide dengan mudah ke presentasi PowerPoint dan OpenDocument Anda menggunakan Aspose.Slides untuk Python via .NET—penyisipan slide yang mulus dan efisien dalam hitungan detik."
---
## **Gambaran Umum**

Sebelum menambahkan slide ke presentasi, ada baiknya memahami bagaimana PowerPoint mengatur slide tersebut. Setiap presentasi berisi slide master, slide tata letak opsional, dan satu atau beberapa slide normal. Setiap slide memiliki ID unik, dan slide normal diurutkan berdasarkan indeks mulai dari nol. Artikel ini menunjukkan cara menggunakan Aspose.Slides untuk Python dalam membuat slide dan memilih tata letak yang tepat.

## **Menambahkan Slide ke Presentasi**

Aspose.Slides memungkinkan Anda menambahkan slide baru berdasarkan slide tata letak yang ada. Contoh di bawah ini mengiterasi setiap tata letak dalam presentasi, menambahkan slide yang menggunakan tata letak tersebut, dan kemudian menyimpan berkas.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) .
1. Akses [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) .
1. Untuk setiap item dalam `presentation.layout_slides`, panggil `add_empty_slide` untuk menambahkan slide yang menggunakan tata letak tersebut.
1. Opsional, modifikasi slide yang baru ditambahkan.
1. Simpan presentasi sebagai berkas PPTX.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation.
with slides.Presentation() as presentation:
    # Mengakses koleksi slide.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Menambahkan slide kosong ke koleksi slide.
        slides.add_empty_slide(layout_slide)

    # Lakukan beberapa pekerjaan pada slide yang baru ditambahkan.

    # Menyimpan presentasi ke disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bisakah saya menyisipkan slide baru pada posisi tertentu, bukan hanya di akhir?**

Ya. Perpustakaan mendukung koleksi slide serta operasi [insert](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/insert_clone/) , sehingga Anda dapat menambahkan slide pada indeks yang diperlukan, bukan hanya di akhir.

**Apakah tema/gaya tetap dipertahankan saat menambahkan slide berdasarkan tata letak?**

Ya. Sebuah tata letak mewarisi pemformatan dari master‑nya, dan slide baru mewarisi dari tata letak yang dipilih beserta master terkait.

**Slide apa yang ada dalam presentasi "kosong" baru sebelum menambahkan slide?**

Presentasi yang baru dibuat sudah berisi satu slide kosong dengan indeks nol. Hal ini penting dipertimbangkan saat menghitung indeks penyisipan.

**Bagaimana saya memilih tata letak yang "tepat" untuk slide baru jika master memiliki banyak opsi?**

Umumnya pilih [LayoutSlide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/) yang sesuai dengan struktur yang dibutuhkan ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidelayouttype/)). Jika tata letak tersebut tidak ada, Anda dapat [add it to the master](/slides/id/python-net/slide-layout/) dan kemudian menggunakannya.