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
description: "Dengan cepat mengkloning atau menduplikasi slide PowerPoint menggunakan Aspose.Slides untuk Python via .NET. Ikuti contoh kode yang jelas dan tips kami untuk mengotomatiskan pembuatan PPT dalam hitungan detik, meningkatkan produktivitas, dan menghilangkan pekerjaan manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan persis atau replika sesuatu. Aspose.Slides juga memungkinkan Anda menyalin (mengkloning) slide apa pun dan kemudian menyisipkan slide yang telah dikloning ke dalam presentasi saat ini atau presentasi terbuka lainnya. Kloning slide membuat slide baru yang dapat dimodifikasi oleh pengembang tanpa memengaruhi slide asli. Ada beberapa cara untuk mengkloning slide:

- Mengkloning di akhir presentasi.
- Mengkloning di posisi lain dalam presentasi.
- Mengkloning di akhir presentasi lain.
- Mengkloning di posisi lain dalam presentasi lain.
- Mengkloning pada posisi tertentu dalam presentasi lain.

Dalam Aspose.Slides for Python via .NET, [slide collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) yang diekspos oleh objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) menyediakan metode `add_clone` dan `insert_clone` untuk melakukan jenis kloning slide ini.

## **Instalasi**

```bash
pip install aspose.slides
```

## **Kloning di Akhir dalam Presentasi yang Sama**

Jika Anda ingin mengkloning slide dalam presentasi yang sama dan menambahkannya ke akhir slide yang ada, gunakan metode `add_clone`. Ikuti langkah-langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan koleksi slide dari objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Panggil metode `add_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/), dengan memberikan slide yang akan dikloning.
1. Simpan presentasi yang telah dimodifikasi.

Pada contoh di bawah, slide pertama (indeks 0) dikloning dan ditambahkan ke akhir presentasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama.
    presentation.slides.add_clone(presentation.slides[0])
    # Menyimpan presentasi yang telah dimodifikasi ke disk.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloning ke Posisi Tertentu dalam Presentasi yang Sama**

Jika Anda ingin mengkloning slide dalam presentasi yang sama dan menempatkannya pada posisi yang berbeda, gunakan metode `insert_clone`:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan koleksi slide dari objek [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Panggil metode `insert_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/), dengan memberikan slide yang akan dikloning dan indeks target untuk posisinya yang baru.
1. Simpan presentasi yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 1 (posisi 2) dikloning ke indeks 2 (posisi 3) dalam presentasi yang sama.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Mengklon slide yang diinginkan ke posisi (indeks) yang ditentukan dalam presentasi yang sama.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Menyimpan presentasi yang telah dimodifikasi ke disk.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloning di Akhir Presentasi Lain**

Jika Anda perlu mengkloning slide dari satu presentasi dan menambahkannya ke akhir presentasi lain:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi sumber (yang berisi slide yang akan dikloning).
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi tujuan (di mana slide akan ditambahkan).
1. Dapatkan koleksi slide dari presentasi tujuan.
1. Panggil `add_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) tujuan, dengan memberikan slide dari presentasi sumber.
1. Simpan presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 0 di presentasi sumber dikloning ke akhir presentasi tujuan.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi sumber.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan dikloning).
    with slides.Presentation() as target_presentation:
        # Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Menyimpan presentasi tujuan ke disk.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloning ke Posisi Tertentu dalam Presentasi Lain**

Jika Anda perlu mengkloning slide dari satu presentasi dan menyisipkannya ke presentasi lain pada posisi tertentu:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi sumber (yang berisi slide yang akan dikloning).
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi tujuan.
1. Dapatkan koleksi slide dari presentasi tujuan.
1. Panggil metode `insert_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) tujuan, dengan memberikan slide dari presentasi sumber dan indeks target yang diinginkan.
1. Simpan presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 0 di presentasi sumber dikloning ke indeks 2 (posisi 3) dalam presentasi tujuan.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi sumber.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Membuat instance kelas Presentation untuk PPTX tujuan (tempat slide akan dikloning).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Menyisipkan klon slide pertama dari sumber pada indeks 2 di presentasi tujuan.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Menyimpan presentasi tujuan ke disk.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloning Slide dengan Slide Masternya ke Presentasi Lain**

Jika Anda perlu mengkloning slide **dengan master-nya** dari satu presentasi dan menggunakannya di presentasi lain, pertama kloning slide master yang diperlukan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan master tujuan tersebut saat mengkloning slide. Metode `add_clone(Slide, MasterSlide)` mengharapkan **slide master dari presentasi tujuan**, bukan dari sumber.

Untuk mengkloning slide dengan master, ikuti langkah-langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi sumber (yang berisi slide yang akan dikloning).
1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) untuk presentasi tujuan.
1. Akses slide sumber yang akan dikloning dan slide master-nya.
1. Dapatkan [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) dari koleksi master presentasi tujuan.
1. Panggil `add_clone` pada [MasterSlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslidecollection/) tujuan, dengan memberikan master sumber untuk mengkloningnya ke tujuan.
1. Dapatkan [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) dari koleksi slide presentasi tujuan.
1. Panggil `add_clone` pada [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/) tujuan, dengan memberikan slide sumber dan master tujuan yang telah dikloning.
1. Simpan presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah, slide pada indeks 0 di presentasi sumber dikloning ke akhir presentasi tujuan menggunakan master yang dikloning dari sumber.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk merepresentasikan file presentasi sumber.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Membuat instance kelas Presentation untuk presentasi tujuan di mana slide akan dikloning.
    with slides.Presentation() as target_presentation:
        # Mendapatkan slide pertama dari presentasi sumber.
        source_slide = source_presentation.slides[0]
        # Mendapatkan slide master yang digunakan oleh slide pertama.
        source_master = source_slide.layout_slide.master_slide
        # Mengklon slide master ke dalam koleksi master presentasi tujuan.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Mengklon slide dari presentasi sumber ke akhir presentasi tujuan menggunakan master yang dikloning.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Menyimpan presentasi tujuan ke disk.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kloning di Akhir pada Seksi yang Ditetapkan**

Dengan Aspose.Slides for Python via .NET, Anda dapat mengkloning slide dari satu seksi presentasi dan menyisipkannya ke seksi lain dalam presentasi yang sama. Untuk melakukannya, gunakan metode `add_clone(Slide, Section)` dari kelas [SlideCollection](https://reference.aspose.com/slides/id/python-net/aspose.slides/slidecollection/).

Contoh Python berikut menunjukkan cara mengkloning slide dan menyisipkan klon ke dalam seksi yang ditentukan:

```py
import aspose.slides as slides

# Membuat presentasi kosong baru.
with slides.Presentation() as presentation:
    # Menambahkan slide kosong berdasarkan tata letak slide pertama.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Menambahkan bentuk elips ke slide baru; slide ini akan dikloning nanti.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Menambahkan slide kosong lain berdasarkan tata letak slide pertama.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Membuat seksi bernama "Section2" yang dimulai pada slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Mengklon slide yang sebelumnya dibuat ke dalam seksi "Section2".
    presentation.slides.add_clone(slide, section)
    # Menyimpan presentasi sebagai file PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**
### Apakah catatan pembicara dan komentar reviewer dikloning?

Ya. Halaman catatan dan komentar tinjauan termasuk dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/python-net/presentation-notes/) setelah penyisipan.

### Bagaimana chart dan sumber data mereka ditangani?

Objek chart, pemformatan, dan data tersemat disalin. Jika chart terhubung ke sumber eksternal (mis., workbook yang disisipkan OLE), tautan tersebut dipertahankan sebagai [OLE object](/slides/id/python-net/manage-ole/). Setelah dipindahkan antar file, verifikasi ketersediaan data dan perilaku penyegaran.

### Bisakah saya mengontrol posisi penyisipan dan seksi untuk klon?

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke dalam [section](/slides/id/python-net/slide-section/) yang dipilih. Jika seksi target tidak ada, buat dulu dan kemudian pindahkan slide ke dalamnya.