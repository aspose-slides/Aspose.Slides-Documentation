---
title: Kelola Transisi Slide dalam Presentasi Menggunakan Python
linktitle: Transisi Slide
type: docs
weight: 90
url: /id/python-net/slide-transition/
keywords:
- transisi slide
- tambahkan transisi slide
- terapkan transisi slide
- transisi slide lanjutan
- transisi morph
- jenis transisi
- efek transisi
- Python
- Aspose.Slides
description: "Temukan cara menyesuaikan transisi slide di Aspose.Slides untuk Python melalui .NET, dengan panduan langkah demi langkah untuk presentasi PowerPoint dan OpenDocument."
---
## **Gambaran Umum**

Aspose.Slides for Python menyediakan kontrol penuh atas transisi slide, mulai dari memilih jenis transisi hingga mengonfigurasi waktu dan pemicu sebagai bagian dari alur kerja presentasi otomatis. Anda dapat mengatur slide untuk maju saat diklik dan/atau setelah penundaan tertentu serta menyempurnakan perilaku visual dengan efek seperti potongan dari hitam atau masuk dari arah tertentu. Perpustakaan ini juga mendukung transisi Morph yang diperkenalkan di PowerPoint 2019, termasuk mode yang mem morph berdasarkan objek, kata, atau karakter untuk menciptakan gerakan yang halus dan kohesif antar slide.

## **Menambahkan Transisi Slide**

Agar lebih mudah dipahami, contoh ini menunjukkan cara menggunakan Aspose.Slides for Python untuk mengelola transisi slide sederhana. Pengembang dapat menerapkan berbagai efek transisi slide ke slide dan menyesuaikan perilakunya. Untuk membuat transisi slide sederhana, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Terapkan transisi slide menggunakan salah satu efek dari enum [TransitionType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitiontype/).
1. Simpan berkas presentasi yang telah dimodifikasi.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk memuat file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    # Terapkan transisi lingkaran pada slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Terapkan transisi sisir pada slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Menambahkan Transisi Slide Lanjutan**

Pada bagian ini, kami menerapkan efek transisi sederhana pada sebuah slide. Untuk membuat efek tersebut lebih terkontrol dan halus, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Terapkan transisi slide menggunakan salah satu efek dari enum [TransitionType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitiontype/).
1. Konfigurasikan transisi untuk Advance On Click, setelah periode waktu tertentu, atau keduanya.
1. Simpan berkas presentasi yang telah dimodifikasi.

Jika **Advance On Click** diaktifkan, slide akan maju hanya ketika pengguna mengklik. Jika properti **Advance After Time** diatur, slide akan maju secara otomatis setelah interval yang ditentukan.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Terapkan transisi lingkaran pada slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aktifkan maju saat diklik dan atur auto-maju 3 detik.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Terapkan transisi sisir pada slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Aktifkan maju saat diklik dan atur auto-maju 5 detik.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Terapkan transisi zoom pada slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Aktifkan maju saat diklik dan atur auto-maju 7 detik.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Transisi Morph**

Aspose.Slides for Python mendukung [Morph transition](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/morphtransition/), yang menganimasikan pergerakan halus dari satu slide ke slide berikutnya. Bagian ini menjelaskan cara menggunakan transisi Morph. Untuk menggunakannya secara efektif, Anda memerlukan dua slide dengan setidaknya satu objek yang sama. Pendekatan termudah adalah menggandakan slide dan kemudian memindahkan objek ke posisi yang berbeda pada slide kedua.

Potongan kode berikut menunjukkan cara menggandakan slide yang berisi teks dan menerapkan transisi Morph pada slide kedua.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Klon slide pertama untuk membuat slide kedua dengan bentuk yang sama agar kontinuitas Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Pilih persegi panjang yang sama pada slide kedua dan ubah posisinya serta ukurannya.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Aktifkan transisi Morph pada slide kedua untuk menganimasikan perubahan bentuk secara halus.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Jenis Transisi Morph**

Enum [TransitionMorphType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionmorphtype/) mewakili berbagai jenis transisi slide Morph.

Potongan kode berikut menunjukkan cara menerapkan transisi Morph pada sebuah slide dan mengubah jenis morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengatur Efek Transisi**

Aspose.Slides for Python memungkinkan Anda mengatur efek transisi seperti **From Black**, **From Left**, **From Right**, dll. Untuk mengonfigurasi efek transisi, ikuti langkah‑langkah berikut:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide.
1. Atur efek transisi yang diinginkan.
1. Simpan presentasi sebagai berkas PPTX.

Pada contoh di bawah, kami mengatur beberapa efek transisi.

```py
import aspose.slides as slides

# Buat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Terapkan transisi Cut dan aktifkan From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Simpan presentasi ke disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Atur [speed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/speed/) transisi menggunakan pengaturan [TransitionSpeed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionspeed/) (misalnya, slow/medium/fast).

**Apakah saya dapat melampirkan audio pada transisi dan membuatnya berulang?**

Ya. Anda dapat menyematkan suara untuk transisi dan mengontrol perilakunya melalui pengaturan seperti mode suara dan looping (misalnya, [sound](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), serta metadata seperti [sound_is_built_in](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) dan [sound_name](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Konfigurasikan jenis transisi yang diinginkan pada pengaturan transisi masing‑masing slide; transisi disimpan per slide, sehingga menerapkan jenis yang sama pada semua slide memberikan hasil yang konsisten.

**Bagaimana saya dapat memeriksa transisi mana yang saat ini diterapkan pada sebuah slide?**

Periksa [transition settings](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/slide_show_transition/) slide dan baca [transition type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/type/); nilai tersebut memberi tahu Anda secara tepat efek apa yang diterapkan.