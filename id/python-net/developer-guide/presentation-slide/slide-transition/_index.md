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
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan transisi Morph serta efek transisi lainnya dengan Aspose.Slides untuk Python via .NET."
---
## **Gambaran Umum**

Transisi slide mengendalikan bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides for Python via .NET, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi yang spesifik untuk suatu efek. Artikel ini menggunakan contoh Python untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola timing slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Tambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan akses properti [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slide. Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ke nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), lalu simpan presentasi.

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

## **Transisi Wheel**

Properti [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) dari [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) mengontrol jumlah sektor radial yang mengungkap slide tujuan. Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi slide menjadi WHEEL dari [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) sebelum mengakses [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) sebagai [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Contoh ini membuat dua pasang slide yang identik: slide hitam diikuti oleh slide dengan persegi panjang emas. Slide tujuan menggunakan jumlah spoke 1 dan 8, dengan [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) yang sama dan [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) eksplisit sebesar 8.000 milidetik agar perbedaan mudah diamati.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Buka presentasi keluaran di PowerPoint dan jalankan pertunjukan slide. Maju dari slide 1 ke slide 2, kemudian dari slide 3 ke slide 4. Dalam pemutaran PowerPoint, jumlah spoke terverifikasi 1 mengungkap slide dengan satu sapuan searah jarum jam; jumlah terverifikasi 8 mengungkapnya melalui delapan sektor radial secara bersamaan. Konten tujuan dan timing transisi identik, jadi perbedaannya terletak pada jumlah sektor pengungkapan.

## **Tambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse memajukan pertunjukan slide. Properti-properti berikut mengontrol perilaku ini:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) mengaktifkan kemajuan otomatis.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan kedua kemajuan klik dan timer untuk membiarkan penonton melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, atur [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ke `False`. Penundaan mengontrol kapan pertunjukan slide maju; tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek berbeda ke tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik, masing‑masing. Klik mouse juga dapat memajukan slide‑slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

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

Untuk memeriksa apakah kemajuan berbasis timer diaktifkan, baca [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Penundaan yang tersimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Itu mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

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

## **Kontrol Waktu Transisi dengan Tepat**

Gunakan [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) untuk menentukan panjang tepat efek transisi dalam milidetik. Properti [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slide menampilkan pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Properti | Tujuan |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Mengatur durasi efek transisi itu sendiri, dalam milidetik. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Mengatur penundaan sebelum slide maju secara otomatis, dalam milidetik. Aktifkan [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) untuk mengaktifkan timer ini. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Memilih kategori kecepatan yang telah ditentukan dari [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM, atau FAST. Digunakan ketika durasi eksak tidak ditentukan. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) mengontrol hanya efek transisi; tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan penundaan kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Bilah terpisah mengidentifikasi durasi transisi 750 ms dan pengaturan kemajuan otomatis 5.000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Contoh bersama ini memberi setiap slide transisi Fade 750 ms dan secara terpisah mengaktifkan kemajuan otomatis pada 5.000 ms. Durasi transisi mengontrol efek; kemajuan mengontrol kapan meninggalkan slide. Bilah‑bilah ini adalah pengaturan skematik, bukan garis waktu gabungan yang diukur.*
<!-- visual-explanation:slide-transition:end -->

### **Terapkan Durasi yang Sama ke Setiap Slide**

Untuk ritme yang konsisten, terapkan efek yang sama dan durasi yang tepat ke setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Itu secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan dengan klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Konfigurasi kemajuan otomatis secara terpisah dari durasi efek.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Atur Durasi Berbeda untuk Slide Individu**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengenalan bagian. Contoh ini mengatur 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

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

Saat menyiapkan [animated GIF](/slides/id/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/python-net/export-to-html5/), atau [video](/slides/id/python-net/convert-powerpoint-to-video/), atur durasi transisi yang tepat sebelum mengekspor agar sesuai dengan irama yang diinginkan. Misalnya, gunakan fade 600 milidetik di antara adegan, dan sesuaikan penundaan kemajuan setiap slide secara terpisah untuk memberi waktu pada narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik bersamaan dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi timing yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Baca [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) sebelum memodifikasi transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang ditetapkan; nilai non‑negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) untuk menentukan durasi tersebut. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi inspeksi pengaturan asli terlebih dahulu.

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

Transisi Morph menganimasi perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, klon slide, pindahkan atau ubah ukuran sebuah objek pada klon, dan terapkan transisi Morph ke slide kedua. Ini memberi transisi objek‑objek yang bersesuaian untuk beranimasi antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, mengkloning slide, dan mengubah posisi serta ukuran persegi panjang pada klon. Kemudian memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

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

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) mengontrol bagaimana Morph mencocokkan dan menganimasi konten:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) memperlakukan setiap bentuk sebagai satu objek utuh.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) menganimasi teks dengan mencocokkan kata‑kata bila memungkinkan.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) menganimasi teks dengan mencocokkan karakter bila memungkinkan.

Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi ke Morph sebelum mengakses [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Nilai tersebut kemudian menyediakan objek [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), yang properti [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) memilih mode pencocokan.

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

## **Atur Efek Transisi**

Beberapa transisi menampilkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia tergantung pada [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi yang dipilih. Atur jenisnya terlebih dahulu, kemudian gunakan objek transisi yang tepat dari [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Contoh berikut menerapkan transisi Cut ke slide pertama `input.pptx`. Itu mengatur [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

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

**Bisakah saya mengontrol kecepatan pemutaran transisi slide?**

Ya. Pilih [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) yang telah ditentukan—SLOW, MEDIUM, atau FAST—cukup dan tidak ada durasi eksplisit yang diatur. Pengaturan ini mengontrol efek transisi secara independen dari penundaan kemajuan otomatis.

**Bisakah saya menambahkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat ke [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), atur [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) ke START_SOUND dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/), dan aktifkan [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Audio akan berulang sampai ada peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama ke setiap slide?**

Iterasi melalui koleksi [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) presentasi dan atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi setiap slide ke nilai yang sama. Tetapkan opsi timing dan efek apa pun dalam loop yang sama untuk menjaga perilaku konsisten di semua slide.

**Bagaimana saya dapat memeriksa transisi mana yang saat ini diatur pada slide?**

Baca properti [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) dari [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slide. Properti ini mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE berarti tidak ada efek transisi yang diterapkan.