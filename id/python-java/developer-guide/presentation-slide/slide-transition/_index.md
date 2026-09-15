---
title: Kelola Transisi Slide dalam Presentasi Menggunakan Python via Java
linktitle: Transisi Slide
type: docs
weight: 80
url: /id/python-java/slide-transition/
keywords:
- transisi slide
- tambahkan transisi slide
- terapkan transisi slide
- transisi slide lanjutan
- transisi morph
- jenis transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan perpindahan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk Python via Java, Anda dapat memilih efek transisi untuk setiap slide, mengonfigurasi perpindahan dengan klik mouse atau timer, dan menyesuaikan opsi khusus untuk sebuah efek. Artikel ini menggunakan contoh Python untuk menerapkan transisi, mengatur durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh-contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getSlideShowTransition). Gunakan [setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setType) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitiontype/), lalu simpan presentasi.

Contoh berikut menerapkan transisi Circle ke slide pertama dan transisi Comb ke slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengonfigurasi berapa lama sebuah slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode berikut mengontrol perilaku ini:

- [setAdvanceOnClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) memungkinkan penonton melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) mengaktifkan perpindahan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) menentukan penundaan sebelum perpindahan otomatis, dalam milidetik.

Aktifkan kedua perpindahan klik dan berwaktu agar penonton dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, berikan `False` ke [setAdvanceOnClick](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Penundaan mengontrol kapan pertunjukan slide melanjutkan; itu tidak menentukan durasi efek transisi visual.

Contoh ini menetapkan efek yang berbeda ke tiga slide pertama dan mengaktifkan perpindahan otomatis setelah 3, 5, dan 7 detik masing‑masing. Klik mouse juga dapat melanjutkan slide‑slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

Untuk memeriksa apakah perpindahan berwaktu diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Penundaan yang disimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan perpindahan otomatis untuk slide dengan penundaan lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide‑slide tersebut dan menyimpan pengaturan yang diperbarui.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Mengontrol Waktu Transisi Secara Tepat**

Gunakan [setDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setDuration) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getSlideShowTransition) pada slide mengekspos pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setDuration) | Mengatur durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Menentukan penundaan sebelum slide melanjutkan secara otomatis, dalam milidetik. Berikan `True` ke [setAdvanceAfter](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setSpeed) | Memilih kategori kecepatan yang telah ditentukan dari [TransitionSpeed](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Digunakan ketika durasi tepat tidak ditentukan. |

[setDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setDuration) mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Atur penundaan perpindahan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang diberikan, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [getSpeed](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getSpeed).

### **Terapkan Durasi yang Sama ke Setiap Slide**

Untuk ritme yang konsisten, terapkan efek yang sama dan durasi tepat ke setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan perpindahan otomatis setelah 5.000 milidetik dan menonaktifkan perpindahan dengan klik mouse, lalu menyimpan hasilnya sebagai PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # Konfigurasikan perpindahan otomatis secara terpisah dari durasi efek.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tetapkan Durasi Berbeda untuk Slide Individu**

Slide yang berbeda dapat menggunakan durasi efek yang berbeda. Misalnya, gunakan transisi singkat untuk slide judul dan transisi lebih lama untuk pengantar bagian. Contoh ini menetapkan 500 milidetik untuk slide pertama dan 1.200 milidetik untuk slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **Koordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/python-java/export-to-html5/), atau [video](/slides/id/python-java/convert-powerpoint-to-video/), atur durasi transisi yang tepat sebelum mengekspor untuk menyamakan ritme yang diinginkan. Misalnya, gunakan fade 600 milidetik antara adegan, dan sesuaikan penundaan perpindahan tiap slide secara terpisah agar ada waktu untuk narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik setara dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi dalam pengaturan ekspor. Periksa efek dan opsi waktu yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Baca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getDuration) sebelum mengubah transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang diatur; nilai non‑negatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan nilai [getSpeed](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getSpeed) untuk menentukan durasi itu. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **Transisi Morph**

Transisi Morph menganimasikan perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, duplikat slide, pindahkan atau ubah ukuran objek pada duplikat, dan terapkan transisi Morph ke slide kedua. Ini memberi objek‑objek yang bersesuaian animasi antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, menduplikasi slide, dan mengubah posisi serta ukuran persegi pada duplikat. Kemudian ia memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan dalam penampil presentasi yang mendukung Morph untuk melihat efeknya selama pertunjukan slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Jenis Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionmorphtype/) mengontrol bagaimana Morph mencocokkan dan menganimasikan konten:

- [ByObject](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionmorphtype/#ByObject) memperlakukan setiap bentuk sebagai satu objek keseluruhan.
- [ByWord](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionmorphtype/#ByWord) menganimasikan teks dengan mencocokkan kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionmorphtype/#ByChar) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setType) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getValue). Nilainya kemudian menjadi instance dari kelas [MorphTransition](https://reference.aspose.com/slides/id/python-java/aspose.slides/morphtransition/), yang memiliki metode [setMorphType](https://reference.aspose.com/slides/id/python-java/aspose.slides/morphtransition/#setMorphType) untuk memilih mode pencocokan.

Contoh ini membuka presentasi yang dibuat pada bagian sebelumnya dan mengonfigurasi slide kedua untuk menggunakan animasi Morph berbasis kata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **Atur Efek Transisi**

Beberapa transisi mengekspos opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setType). Tetapkan jenisnya terlebih dahulu, lalu gunakan kelas yang tepat dari [getValue](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getValue).

Contoh berikut menerapkan transisi Cut ke slide pertama dari `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/id/python-java/aspose.slides/optionalblacktransition/#setFromBlack) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/id/python-java/aspose.slides/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **FAQ**

**Bisakah saya mengontrol kecepatan pemutaran transisi slide?**

Ya. Pilih [setDuration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setDuration) ketika Anda membutuhkan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setSpeed) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionspeed/) yang telah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang ditetapkan. Pengaturan ini mengontrol efek transisi secara terpisah dari penundaan perpindahan otomatis.

**Bisakah saya melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [setSound](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setSound), berikan `StartSound` dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setSoundMode), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setSoundLoop) dengan `True`. Audio akan berulang hingga ada peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama ke setiap slide?**

Lakukan perulangan pada koleksi [getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) presentasi dan panggil [setType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#setType) dengan nilai yang sama untuk transisi setiap slide. Tetapkan opsi waktu dan efek apa pun dalam loop yang sama agar perilaku tetap konsisten di semua slide.

**Bagaimana saya dapat memeriksa transisi mana yang saat ini diatur pada sebuah slide?**

Panggil [getType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowtransition/#getType) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslide/#getSlideShowTransition) slide. Itu mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/id/python-java/aspose.slides/transitiontype/); `None_` berarti tidak ada efek transisi yang diterapkan.