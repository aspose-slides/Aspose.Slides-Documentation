---
title: Kelola Transisi Slide dalam Presentasi Menggunakan Python
linktitle: Transisi Slide
type: docs
weight: 90
url: /id/python-net/slide-transition/
keywords:
- transisi slide
- menambahkan transisi slide
- menerapkan transisi slide
- transisi slide lanjutan
- transisi morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Transisi slide mengontrol cara slide muncul selama pertunjukan slide. Dengan Aspose.Slides for Python via .NET, Anda dapat memilih efek transisi untuk setiap slide, mengatur kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi spesifik untuk sebuah efek. Artikel ini menggunakan contoh Python untuk menerapkan transisi, menetapkan durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/) dan akses properti [slide_show_transition](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/slide_show_transition/) slide. Atur [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/type/) menjadi nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitiontype/), lalu simpan presentasinya.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse mempercepat pertunjukan slide. Properti-properti berikut mengontrol perilaku ini:

- [advance_on_click](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [advance_after](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) mengaktifkan kemajuan otomatis.
- [advance_after_time](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) menentukan jeda sebelum kemajuan otomatis, dalam milidetik.

Aktifkan kedua kemajuan klik dan berwaktu agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, atur [advance_on_click](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) menjadi `False`. Jeda mengontrol kapan pertunjukan slide maju; tidak mengatur durasi efek transisi visual.

Contoh ini memberi efek berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat mempercepat slide-slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Untuk memeriksa apakah kemajuan berwaktu diaktifkan, baca [advance_after](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Jeda yang disimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan jeda lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/duration/) untuk menentukan panjang tepat efek transisi dalam milidetik. Properti [slide_show_transition](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/slide_show_transition/) slide menampilkan pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/):

| Properti | Tujuan |
| --- | --- |
| [duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [advance_after_time](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Menetapkan jeda sebelum slide maju secara otomatis, dalam milidetik. Aktifkan [advance_after](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) untuk mengaktifkan timer ini. |
| [speed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Memilih kategori kecepatan bawaan dari [TransitionSpeed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM, atau FAST. Digunakan ketika durasi tepat tidak ditentukan. |

[duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/duration/) hanya mengontrol efek transisi; tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan jeda kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari tipe transisi dan nilai [speed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

### **Terapkan Durasi yang Sama pada Setiap Slide**

Untuk tempo yang konsisten, terapkan efek yang sama dan durasi tepat pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan dengan klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Konfigurasikan kemajuan otomatis secara terpisah dari durasi efek.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Tetapkan Durasi Berbeda untuk Slide Individu**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/python-net/convert-powerpoint-to-animated-gif/), [presentasi HTML5](/slides/id/python-net/export-to-html5/), atau [video](/slides/id/python-net/convert-powerpoint-to-video/), tetapkan durasi transisi yang tepat sebelum ekspor untuk mencocokkan tempo yang diinginkan. Misalnya, gunakan fade selama 600 milidetik antara adegan, dan sesuaikan jeda kemajuan masing‑masing slide secara terpisah agar ada waktu untuk narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik setara dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Baca [duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/duration/) sebelum mengubah transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang diatur; nilai non‑negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak diset bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan tipe transisi dan [speed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/speed/) untuk menentukan durasi tersebut. Menetapkan tipe transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Transisi Morph**

Transisi Morph menganimasi perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, klon slide, pindahkan atau ubah ukuran objek pada klon, dan terapkan transisi Morph pada slide kedua. Ini memberi objek yang bersesuaian untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, mengkloning slide, dan mengubah posisi serta ukuran persegi panjang pada klon. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasi konten:

- [BY_OBJECT](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionmorphtype/) memperlakukan setiap shape sebagai satu objek utuh.
- [BY_WORD](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionmorphtype/) menganimasi teks dengan mencocokkan kata bila memungkinkan.
- [BY_CHAR](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionmorphtype/) menganimasi teks dengan mencocokkan karakter bila memungkinkan.

Setel [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi menjadi Morph sebelum mengakses [value](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/value/). Nilai kemudian menyediakan objek [MorphTransition](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/morphtransition/), properti [morph_type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/morphtransition/morph_type/)‑nya memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Menetapkan Efek Transisi**

Beberapa transisi menampilkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi yang dipilih. Atur tipe terlebih dahulu, lalu gunakan objek transisi yang sesuai dari [value](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia menyetel [from_black](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Apakah saya dapat mengontrol kecepatan pemutaran transisi slide?**

Ya. Utamakan [duration](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [speed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/speed/) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionspeed/) bawaan—SLOW, MEDIUM, atau FAST—cukup dan tidak ada durasi eksplisit yang diatur. Pengaturan ini mengontrol efek transisi secara independen dari jeda kemajuan otomatis.

**Apakah saya dapat melampirkan audio ke transisi dan menjadikannya berulang?**

Ya. Tetapkan audio tersemat ke [sound](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound/), setel [sound_mode](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) ke START_SOUND dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitionsoundmode/), dan aktifkan [sound_loop](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Audio akan berulang hingga terjadi peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat menerapkan transisi yang sama pada setiap slide?**

Lakukan loop melalui koleksi [slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/) presentasi dan setel setiap [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi slide ke nilai yang sama. Tetapkan opsi waktu dan efek apa pun dalam loop yang sama agar perilaku tetap konsisten di semua slide.

**Bagaimana saya dapat memeriksa transisi apa yang saat ini diterapkan pada sebuah slide?**

Baca properti [type](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/slideshowtransition/type/) dari [slide_show_transition](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/slide_show_transition/) slide. Nilai yang dikembalikan berasal dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/python-net/aspose.slides.slideshow/transitiontype/); NONE berarti tidak ada efek transisi yang diterapkan.