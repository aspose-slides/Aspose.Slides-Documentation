---
title: Klon Slide PowerPoint di Python
linktitle: Klon Slide
type: docs
weight: 40
url: /id/python-net/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Dengan cepat mengklon atau menggandakan slide PowerPoint menggunakan Aspose.Slides untuk Python via .NET. Ikuti contoh kode dan tips kami yang jelas untuk mengotomatiskan pembuatan PPT dalam hitungan detik, meningkatkan produktivitas, dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Kloning adalah proses membuat salinan persis atau replika dari sesuatu. Aspose.Slides juga memungkinkan Anda menyalin (mengklon) slide apa pun dan kemudian menyisipkan slide yang diklon ke dalam presentasi saat ini atau presentasi terbuka lainnya. Kloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa memengaruhi slide asli. Ada beberapa cara untuk mengklon slide:

- Mengklon di akhir sebuah presentasi.
- Mengklon di posisi lain dalam sebuah presentasi.
- Mengklon di akhir presentasi lain.
- Mengklon di posisi lain dalam presentasi lain.
- Mengklon di posisi tertentu dalam presentasi lain.

Dalam Aspose.Slides untuk Python via .NET, [koleksi slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) yang disediakan oleh objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) menawarkan metode `add_clone` dan `insert_clone` untuk melakukan jenis kloning slide ini.

## **Instalasi**

```bash
pip install aspose.slides
```

## **Mengklon di Akhir dalam Presentasi yang Sama**

Jika Anda ingin mengklon slide dalam presentasi yang sama dan menambahkannya ke akhir slide yang ada, gunakan metode `add_clone`. Ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan koleksi slide dari objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Panggil metode `add_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/), dengan menyertakan slide yang akan diklon.
1. Simpan presentasi yang telah dimodifikasi.

Pada contoh di bawah, slide pertama (indeks 0) diklon dan ditambahkan ke akhir presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama.
    presentation.slides.add_clone(presentation.slides[0])
    # Simpan presentasi yang telah dimodifikasi ke disk.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengklon ke Posisi Tertentu dalam Presentasi yang Sama**

Jika Anda ingin mengklon slide dalam presentasi yang sama dan menempatkannya pada posisi berbeda, gunakan metode `insert_clone`:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan koleksi slide dari objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Panggil metode `insert_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/), dengan menyertakan slide yang akan diklon serta indeks target untuk posisi barunya.
1. Simpan presentasi yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 1 (posisi 2) diklon ke indeks 2 (posisi 3) dalam presentasi yang sama.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Mengklon slide yang diinginkan ke posisi (indeks) tertentu dalam presentasi yang sama.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Simpan presentasi yang telah dimodifikasi ke disk.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengklon di Akhir Presentasi Lain**

Jika Anda perlu mengklon slide dari satu presentasi dan menambahkannya ke akhir presentasi lain:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi sumber (yang berisi slide yang akan diklon).
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi tujuan (tempat slide akan ditambahkan).
1. Dapatkan koleksi slide dari presentasi tujuan.
1. Panggil `add_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) tujuan, dengan menyertakan slide dari presentasi sumber.
1. Simpan presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 0 di presentasi sumber diklon ke akhir presentasi tujuan.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi sumber.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon).
    with slides.Presentation() as target_presentation:
        # Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide di presentasi tujuan.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Simpan presentasi tujuan ke disk.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengklon ke Posisi Tertentu dalam Presentasi Lain**

Jika Anda perlu mengklon slide dari satu presentasi dan menyisipkannya ke presentasi lain pada posisi tertentu:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi sumber (yang berisi slide yang akan diklon).
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi tujuan (tempat slide akan ditambahkan).
1. Dapatkan koleksi slide dari presentasi tujuan.
1. Panggil metode `insert_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) tujuan, dengan menyertakan slide dari presentasi sumber serta indeks target yang diinginkan.
1. Simpan presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 0 di presentasi sumber diklon ke indeks 2 (posisi 3) di presentasi tujuan.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi sumber.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan diklon).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Menyisipkan klon slide pertama dari sumber pada indeks 2 di presentasi tujuan.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Simpan presentasi tujuan ke disk.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengklon Slide beserta Slide Master ke Presentasi Lain**

Jika Anda perlu mengklon slide **beserta masternya** dari satu presentasi dan menggunakannya di presentasi lain, pertama klon master slide yang diperlukan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan master tujuan tersebut saat mengklon slide. Metode `add_clone(Slide, MasterSlide)` mengharapkan **slide master dari presentasi tujuan**, bukan dari sumber.

Untuk mengklon slide beserta masternya, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi sumber (yang berisi slide yang akan diklon).
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi tujuan.
1. Akses slide sumber yang akan diklon dan master slide‑nya.
1. Dapatkan [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) dari koleksi master presentasi tujuan.
1. Panggil `add_clone` pada [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) tujuan, dengan menyertakan master sumber untuk mengklonnya ke tujuan.
1. Dapatkan [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) dari koleksi slide presentasi tujuan.
1. Panggil `add_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) tujuan, dengan menyertakan slide sumber dan master tujuan yang telah diklon.
1. Simpan presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 0 di presentasi sumber diklon ke akhir presentasi tujuan menggunakan master yang diklon dari sumber.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi sumber.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Membuat instance kelas Presentation untuk presentasi tujuan dimana slide akan diklon.
    with slides.Presentation() as target_presentation:
        # Ambil slide pertama dari presentasi sumber.
        source_slide = source_presentation.slides[0]
        # Ambil master slide yang digunakan oleh slide pertama.
        source_master = source_slide.layout_slide.master_slide
        # Klon master slide ke dalam koleksi master presentasi tujuan.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Klon slide dari presentasi sumber ke akhir presentasi tujuan menggunakan master yang diklon.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Simpan presentasi tujuan ke disk.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengklon di Akhir pada Seksi yang Ditentukan**

Dengan Aspose.Slides untuk Python via .NET, Anda dapat mengklon slide dari satu seksi presentasi dan menyisipkannya ke seksi lain dalam presentasi yang sama. Untuk melakukannya, gunakan metode `add_clone(Slide, Section)` pada kelas [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/).

Contoh Python berikut menunjukkan cara mengklon slide dan menyisipkan klonnya ke seksi yang ditentukan:

```py
import aspose.slides as slides

# Buat presentasi kosong baru.
with slides.Presentation() as presentation:
    # Tambahkan slide kosong berdasarkan tata letak slide pertama.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Tambahkan bentuk elips ke slide baru; slide ini akan diklon nanti.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Tambahkan slide kosong lain berdasarkan tata letak slide pertama.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Buat seksi bernama "Section2" yang dimulai pada slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Klon slide yang sebelumnya dibuat ke dalam seksi "Section2".
    presentation.slides.add_clone(slide, section)
    # Simpan presentasi sebagai file PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Pastikan Ukuran Slide Sesuai**

Saat mengklon slide ke presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi asli dipertahankan, yang dapat menyebabkan konten terlihat tidak rata atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar cocok dengan sumber sebelum mengklon master dan slide:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Lakukan ini sebelum mengklon master dan slide.

## **FAQ**

**Apakah catatan pembicara dan komentar peninjau ikut diklon?**

Ya. Halaman catatan dan komentar peninjau termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/python-net/presentation-notes/) setelah penyisipan.

**Bagaimana chart dan sumber data mereka ditangani?**

Objek chart, format, dan data tersemat disalin. Jika chart terhubung ke sumber eksternal (misalnya buku kerja yang di‑embed OLE), tautan tersebut dipertahankan sebagai [objek OLE](/slides/id/python-net/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

**Bisakah saya mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke [seksi](/slides/id/python-net/slide-section/) pilihan. Jika seksi target belum ada, buat dulu kemudian pindahkan slide ke dalamnya.