---
title: Mengelola Transisi Slide dalam Presentasi dengan Python via Java
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
- tipe transisi
- efek transisi
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Terapkan transisi slide, konfigurasikan kemajuan slide otomatis, dan sesuaikan Morph serta efek transisi lainnya dengan Aspose.Slides untuk Python via Java."
---
## **Gambaran Umum**

Transisi slide mengontrol bagaimana slide muncul selama pertunjukan slide. Dengan Aspose.Slides untuk Python via Java, Anda dapat memilih efek transisi untuk setiap slide, mengkonfigurasi kemajuan dengan klik mouse atau timer, dan menyesuaikan opsi khusus untuk sebuah efek. Artikel ini menggunakan contoh Python untuk menerapkan transisi, menetapkan durasi transisi yang tepat, mengelola waktu slide, dan membuat transisi Morph antara dua slide. Contoh‑contoh juga menunjukkan cara menyimpan pengaturan ke file PPTX.

## **Menambahkan Transisi Slide**

Untuk menerapkan transisi, muat sebuah presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan akses pengaturan transisi slide melalui [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition). Gunakan [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) dengan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), kemudian simpan presentasi.

Contoh berikut menerapkan transisi Circle pada slide pertama dan transisi Comb pada slide kedua. Gunakan file `input.pptx` dengan setidaknya dua slide.

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

## **Transisi Roda**

Gunakan [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) untuk memilih Wheel dari [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/). Kemudian panggil [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) untuk mengakses pengaturan [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/). Metode [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) mengontrol berapa banyak sektor radial yang mengungkap slide tujuan.

Contoh ini membuat dua pasang slide yang identik. Setiap pasangan dimulai dengan slide hitam dan diakhiri dengan persegi panjang emas yang menutupi seluruh slide. Kedua slide tujuan menggunakan kecepatan lambat yang sama yang diatur dengan [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) dan durasi eksplisit yang sama yaitu 8,000 milidetik yang diatur dengan [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration). Hanya jumlah spoke yang berubah.

Buka `wheel-transitions.pptx` di PowerPoint dan mulai pertunjukan slide. Lanjutkan dari slide 1 ke slide 2 untuk melihat satu sapuan searah jarum jam mengungkap persegi panjang emas. Kemudian lanjutkan dari slide 3 ke slide 4 untuk melihat delapan sektor radial mengungkap persegi panjang yang sama secara simultan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Menambahkan Transisi Slide Lanjutan**

Anda dapat mengkonfigurasi berapa lama sebuah slide tetap di layar dan apakah klik mouse melanjutkan pertunjukan slide. Metode‑metode berikut mengontrol perilaku ini:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) memungkinkan pemirsa melanjutkan dengan mengklik mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) mengaktifkan kemajuan otomatis.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) menentukan jeda sebelum kemajuan otomatis, dalam milidetik.

Aktifkan keduanya, klik dan kemajuan berbasis waktu, agar pemirsa dapat melanjutkan dengan klik atau menunggu timer. Untuk menggunakan hanya timer, berikan `False` ke [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Jeda mengontrol kapan pertunjukan slide maju; ini tidak mengatur durasi efek transisi visual.

Contoh ini menetapkan efek yang berbeda ke tiga slide pertama dan mengaktifkan kemajuan otomatis setelah 3, 5, dan 7 detik, masing‑masing. Klik mouse juga dapat melanjutkan slide‑slide ini. Gunakan file `input.pptx` dengan setidaknya tiga slide.

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

Untuk memeriksa apakah kemajuan berbasis waktu diaktifkan, panggil [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Penundaan yang disimpan saja tidak menunjukkan bahwa timer aktif.

Contoh berikut membuka file yang disimpan di atas, melaporkan setiap timer yang diaktifkan, dan menonaktifkan kemajuan otomatis untuk slide dengan penundaan lebih dari dua detik. Ia mengaktifkan klik mouse untuk slide tersebut dan menyimpan pengaturan yang diperbarui.

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

Gunakan [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) untuk menentukan panjang tepat efek transisi dalam milidetik. Metode [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) pada slide mengekspos pengaturan ini melalui [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| Metode | Tujuan |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | Menetapkan durasi efek transisi itu sendiri, dalam milidetik. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Menetapkan jeda sebelum slide melaju secara otomatis, dalam milidetik. Berikan `True` ke [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) untuk mengaktifkan timer ini. |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | Memilih kategori kecepatan yang telah ditentukan sebelumnya dari [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium, atau Fast. Ini digunakan ketika durasi tepat tidak ditentukan. |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) mengontrol hanya efek transisi; ia tidak menentukan berapa lama slide tetap terlihat. Konfigurasikan jeda kemajuan otomatis secara terpisah. Ketika tidak ada durasi eksplisit yang ditetapkan, Aspose.Slides menentukan durasi efek dari jenis transisi dan nilai [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Bar terpisah mengidentifikasi durasi transisi 750‑ms dan pengaturan kemajuan otomatis 5,000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Contoh bersama memberi setiap slide transisi Fade 750‑ms dan secara terpisah mengaktifkan kemajuan otomatis pada 5.000 ms. Durasi transisi mengontrol efek; kemajuan mengontrol kapan meninggalkan slide. Bar ini merupakan pengaturan skematis, bukan timeline gabungan yang diukur.*
<!-- visual-explanation:slide-transition:end -->

### **Menerapkan Durasi yang Sama pada Setiap Slide**

Untuk kecepatan yang konsisten, terapkan efek yang sama dan durasi tepat pada setiap slide. Contoh ini memuat `input.pptx`, memilih Fade dari [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/), dan memberi setiap transisi durasi 750 milidetik. Ia secara terpisah mengaktifkan kemajuan otomatis setelah 5.000 milidetik dan menonaktifkan kemajuan dengan klik mouse, kemudian menyimpan hasilnya sebagai PPTX.

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

        # Konfigurasikan kemajuan otomatis secara terpisah dari durasi efek.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Menetapkan Durasi Berbeda untuk Slide Individu**

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

### **Mengkoordinasikan Transisi dengan Output Animasi**

Saat menyiapkan [animated GIF](/slides/id/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/id/python-java/export-to-html5/), atau [video](/slides/id/python-java/convert-powerpoint-to-video/), tetapkan durasi transisi yang tepat sebelum diekspor untuk mencocokkan kecepatan yang diinginkan. Misalnya, gunakan fade 600‑milidetik antara adegan, dan sesuaikan penundaan kemajuan setiap slide secara terpisah untuk memberikan waktu bagi narasi atau kontennya.

Untuk GIF dan video, koordinasikan frame rate output dengan durasi efek: 600 milidetik setara dengan 18 frame pada 30 frame per detik. Pada HTML5, aktifkan transisi animasi di pengaturan ekspor. Periksa efek dan opsi timing yang didukung oleh format ekspor yang dipilih, dan pratinjau output untuk memastikan sinkronisasi.

### **Membaca Durasi Transisi yang Ada**

Panggil [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) sebelum memodifikasi transisi untuk menentukan apakah nilai eksplisit disimpan. Nilai `-1` berarti tidak ada durasi eksplisit yang ditetapkan; nilai nonnegatif menentukan durasi yang disimpan dalam milidetik. Nilai yang tidak diatur bukan durasi pemutaran yang dihitung: Aspose.Slides menggunakan jenis transisi dan nilai [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) untuk menentukan durasi tersebut. Menetapkan jenis transisi dapat menginisialisasi durasi, jadi periksa pengaturan asli terlebih dahulu.

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

Transisi Morph menganimasikan perubahan antara objek pada slide berurutan. Untuk membuat efek Morph sederhana, kloning sebuah slide, pindahkan atau ubah ukuran sebuah objek pada klon, dan terapkan transisi Morph pada slide kedua. Ini memberikan objek yang bersesuaian untuk dianimasikan antara keadaan asli dan yang dimodifikasi.

Contoh berikut membuat slide dengan persegi panjang teks, mengkloning slide tersebut, dan mengubah posisi serta ukuran persegi panjang pada klon. Kemudian memilih Morph dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) untuk slide kedua. Buka file yang disimpan di penampil presentasi yang mendukung Morph untuk melihat efek selama pertunjukan slide.

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

## **Tipe Transisi Morph**

Enumerasi [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) mengatur bagaimana Morph mencocokkan dan menganimasikan konten:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) memperlakukan setiap bentuk sebagai satu objek utuh.
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) menganimasikan teks dengan mencocokkan kata bila memungkinkan.
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) menganimasikan teks dengan mencocokkan karakter bila memungkinkan.

Gunakan [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) untuk memilih Morph sebelum mengakses [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue). Nilai tersebut kemudian menjadi instance dari kelas [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/), yang metode [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType)‑nya memilih mode pencocokan.

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

## **Mengatur Efek Transisi**

Beberapa transisi menyediakan opsi tambahan, seperti arah atau apakah efek dimulai dari layar hitam. Opsi yang tersedia bergantung pada transisi yang dipilih dengan [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType). Tetapkan tipe terlebih dahulu, kemudian gunakan kelas yang sesuai dari [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue).

Contoh berikut menerapkan transisi Cut pada slide pertama `input.pptx`. Ia memanggil [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) melalui [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) sehingga transisi dimulai dari layar hitam.

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

Ya. Pilih [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) ketika Anda memerlukan durasi efek yang tepat dalam milidetik. Gunakan [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) ketika kategori [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) yang telah ditentukan—Slow, Medium, atau Fast—cukup dan tidak ada durasi eksplisit yang ditetapkan. Pengaturan ini mengontrol efek transisi secara independen dari jeda kemajuan otomatis.

**Bisakah saya melampirkan audio ke transisi dan membuatnya berulang?**

Ya. Tetapkan audio tersemat dengan [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound), berikan StartSound dari enumerasi [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) ke [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode), dan aktifkan [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) dengan `True`. Audio akan berulang hingga peristiwa suara berikutnya dalam pertunjukan slide.

**Apa cara tercepat untuk menerapkan transisi yang sama pada setiap slide?**

Iterasi melalui koleksi [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) pada presentasi dan panggil [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) dengan nilai yang sama untuk transisi setiap slide. Tetapkan semua opsi waktu dan efek dalam loop yang sama untuk menjaga perilaku konsisten di seluruh slide.

**Bagaimana saya dapat memeriksa transisi mana yang saat ini ditetapkan pada slide?**

Panggil [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) pada hasil [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) slide. Itu mengembalikan nilai dari enumerasi [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/); None_ berarti tidak ada efek transisi yang diterapkan.