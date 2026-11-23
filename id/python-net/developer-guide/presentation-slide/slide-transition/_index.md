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
- transisi Morph
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk Python melalui .NET."
---
## **Overview**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk Python melalui .NET, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi khusus untuk sebuah efek. Artikel ini menggunakan contoh Python untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Add Slide Transition**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan akses properti [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/). Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ke nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), lalu simpan presentasi.

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

## **Wheel Transition**

Properti [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) dari [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) mengontrol jumlah sektor radial yang menampilkan slide tujuan. Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) slide menjadi WHEEL dari [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) sebelum mengakses [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) sebagai [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Contoh ini membuat dua pasang slide identik: satu slide hitam diikuti slide dengan persegi panjang emas. Slide tujuan menggunakan jumlah spoke 1 dan 8, dengan [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) yang sama serta [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) eksplisit 8.000 milidetik untuk memudahkan observasi perbedaan.

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

Buka presentasi output di PowerPoint dan jalankan pertunjukan slide. Lanjutkan dari slide 1 ke slide 2, lalu dari slide 3 ke slide 4. Pada pemutaran PowerPoint, jumlah spoke yang terverifikasi 1 menampilkan slide dengan satu sapuan searah jarum jam; jumlah 8 menampilkan slide melalui delapan sektor radial secara bersamaan. Konten tujuan dan timing transisi identik, sehingga perbedaannya hanya pada jumlah sektor reveal.

## **Fade Through Black with the Reveal Transition**

Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi slide tujuan menjadi Reveal, lalu atur [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) pada objek [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/). Contoh ini membuat slide sumber berwarna teal dan slide tujuan berwarna coral, lalu menggandakan pasangan tersebut. Kedua pasangan menggunakan transisi Reveal dua detik yang sama. Hanya pasangan kedua yang memudar melalui hitam.

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Buka `reveal-transitions.pptx` di PowerPoint dan mulai pertunjukan slide. Lanjutkan dari slide 1 ke slide 2 untuk melihat teal memudar langsung ke coral. Kemudian lanjutkan dari slide 3 ke slide 4. Layar singkat menjadi hampir hitam sebelum slide coral muncul. Kedua slide mempertahankan warna latar belakang aslinya.

Baris di bawah ini menampilkan frame dari PowerPoint dengan interval setengah detik. Bandingkan frame tengah di tiap baris untuk melihat efek pengaturan.

![Bar terpisah mengidentifikasi durasi transisi 750‑ms dan pengaturan kemajuan otomatis 5.000‑ms.](reveal-through-black.png)

## **Add Advanced Slide Transition**

Anda dapat mengonfigurasi berapa lama slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Properti berikut mengontrol perilaku ini:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) mengaktifkan kemajuan otomatis.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) menentukan penundaan sebelum kemajuan otomatis, dalam milidetik.

Aktifkan keduanya, klik dan timer, sehingga penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, atur [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ke `False`. Penundaan mengontrol kapan pertunjukan slide maju; itu tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek berbeda pada tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat melanjutkan slide tersebut. Gunakan file `input.pptx` dengan setidaknya tiga slide.

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

Untuk memeriksa apakah kemajuan berbasis waktu diaktifkan, baca [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Penundaan yang tersimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan tiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide tersebut dan menyimpan pengaturan yang diperbarui.

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

## **Control Transition Timing Precisely**

Gunakan [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) untuk menentukan panjang pasti efek transisi dalam milidetik. Properti [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slide menampilkan pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Menetapkan penundaan sebelum slide maju secara otomatis, dalam milidetik. Aktifkan [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) untuk mengaktifkan timer ini. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Memilih kategori kecepatan yang telah ditentukan sebelumnya dari [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM, atau FAST. Digunakan bila durasi eksak tidak ditentukan. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Atur penundaan kemajuan otomatis secara terpisah. Bila tidak ada durasi eksplisit yang disetel, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Bar terpisah mengidentifikasi durasi transisi 750‑ms dan pengaturan kemajuan otomatis 5.000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Contoh bersama memberikan setiap slide transisi Fade 750‑ms dan secara terpisah mengaktifkan kemajuan otomatis pada 5.000 ms. Durasi transisi mengontrol efek; kemajuan mengontrol kapan meninggalkan slide. Bar ini bersifat skematis, bukan timeline gabungan yang terukur.*
<!-- visual-explanation:slide-transition:end -->

### **Apply the Same Duration to Every Slide**

Untuk konsistensi kecepatan, terapkan efek dan durasi yang sama pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan melalui klik mouse, kemudian menyimpan hasilnya sebagai PPTX.

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

### **Set Different Durations for Individual Slides**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini mengatur 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

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

### **Coordinate Transitions with Animated Output**

Saat menyiapkan [animated GIF](/slides/id/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/python-net/export-to-html5/), atau [video](/slides/id/python-net/convert-powerpoint-to-video/), tetapkan durasi transisi yang tepat sebelum mengekspor agar sesuai dengan irama yang diinginkan. Contohnya, gunakan fade 600 milidetik antar adegan, dan sesuaikan penundaan kemajuan tiap slide secara terpisah untuk memberikan waktu pada narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik bersamaan dengan 18 frame pada 30 fps. Pada HTML5, aktifkan transisi animasi di pengaturan ekspor. Periksa efek dan opsi timing yang didukung format ekspor yang dipilih, serta pratinjau output untuk memastikan sinkronisasi.

### **Read an Existing Transition Duration**

Baca [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) sebelum memodifikasi transisi untuk menentukan apakah nilai eksplisit tersimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang diatur; nilai non‑negatif menentukan durasi tersimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) untuk menentukan durasi tersebut. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi inspeksi pengaturan asli terlebih dahulu.

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

## **Morph Transition**

Transisi Morph menganimasikan perubahan antar objek pada slide berurutan. Untuk membuat efek Morph sederhana, gandakan sebuah slide, pindahkan atau ubah ukuran objek pada salinan, dan terapkan transisi Morph pada slide kedua. Ini memberikan objek yang bersesuaian untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, menggandakan slide, dan mengubah posisi serta ukuran persegi panjang pada salinan. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) untuk slide kedua. Buka file yang disimpan pada penampil presentasi yang mendukung Morph untuk melihat efek selama pertunjukan slide.

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

## **Morph Transition Types**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) mengontrol cara Morph mencocokkan dan menganimasikan konten:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) memperlakukan setiap bentuk sebagai satu objek utuh.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) menganimasikan teks dengan mencocokkan kata bila memungkinkan.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi menjadi Morph sebelum mengakses [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). Nilai tersebut kemudian menyediakan objek [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), yang properti [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) memilih mode pencocokan.

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

## **Set Transition Effects**

Beberapa transisi menawarkan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi yang dipilih. Atur tipe terlebih dahulu, kemudian gunakan objek transisi yang tepat dari [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia mengatur [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

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

Ya. Pilih [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) bila Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) bila kategori [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) yang telah ditentukan—SLOW, MEDIUM, atau FAST—cukup dan tidak ada durasi eksplisit yang disetel. Pengaturan ini mengontrol efek transisi secara independen dari penundaan kemajuan otomatis.

**Dapatkah saya menambahkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat ke [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), setel [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) ke START_SOUND dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/), dan aktifkan [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). Audio akan berulang hingga kejadian suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama ke setiap slide?**

Iterasikan koleksi [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) presentasi dan atur [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) transisi setiap slide ke nilai yang sama. Atur semua timing dan opsi efek dalam loop yang sama untuk menjaga perilaku konsisten di semua slide.

**Bagaimana cara memeriksa transisi mana yang sedang diterapkan pada sebuah slide?**

Baca properti [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) dari [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) slide. Ia mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE berarti tidak ada efek transisi yang diterapkan.