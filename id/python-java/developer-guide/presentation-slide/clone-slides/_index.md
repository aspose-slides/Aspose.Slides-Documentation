---
title: Klon Slide Presentasi di Python
linktitle: Klon Slide
type: docs
weight: 35
url: /id/python-java/clone-slides/
keywords:
- klon slide
- salin slide
- simpan slide
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Duplikat slide PowerPoint dengan cepat menggunakan Aspose.Slides untuk Python via Java. Ikuti contoh kode kami yang jelas untuk mengotomatisasi pembuatan PPT dalam hitungan detik dan menghilangkan kerja manual."
---
## **Pendahuluan**

Cloning adalah proses membuat salinan atau replika persis dari sesuatu. Aspose.Slides for Python via Java juga memungkinkan untuk membuat salinan atau klon dari slide apa pun dan kemudian menyisipkan slide yang diklon tersebut ke dalam presentasi saat ini atau presentasi lain yang terbuka. Proses kloning slide menciptakan slide baru yang dapat dimodifikasi oleh pengembang tanpa mengubah slide asli. Ada beberapa cara untuk mengklon slide:

- Mengklon di akhir dalam satu presentasi.
- Mengklon di posisi lain dalam satu presentasi.
- Mengklon di akhir dalam presentasi lain.
- Mengklon di posisi lain dalam presentasi lain.
- Mengklon bersama master slide ke presentasi lain.

Di Aspose.Slides for Python via Java, koleksi slide (sebuah koleksi objek [Slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/)) yang disediakan oleh objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) menyediakan metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) dan [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertClone) untuk melakukan jenis kloning slide di atas.

## **Klon Slide di Akhir Presentasi**

Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama di akhir slide yang ada, gunakan metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) menurut langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dengan merujuk koleksi Slides yang disediakan oleh objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) yang disediakan oleh objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dan berikan slide yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone).
1. Simpan file presentasi yang telah dimodifikasi.

Pada contoh di bawah ini, kami mengklon slide (yang berada pada posisi pertama – indeks nol – dalam presentasi) ke akhir presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat instance kelas Presentation yang mewakili file presentasi
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Mengklon slide yang diinginkan ke akhir koleksi slide dalam presentasi yang sama
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Menulis presentasi yang telah dimodifikasi ke disk
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klon Slide ke Posisi Lain dalam Presentasi**

Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi di posisi yang berbeda, gunakan metode [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertClone):

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi ke koleksi slide yang dikembalikan oleh [getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) pada objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertClone) yang disediakan oleh objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dan berikan slide yang akan diklon bersama indeks untuk posisi baru sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertClone).
1. Simpan presentasi yang telah dimodifikasi sebagai file PPTX.

Pada contoh di bawah ini, kami mengklon slide (yang berada pada indeks 1 – posisi 2 – dalam presentasi) ke indeks 2 – posisi 3 – dalam presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat instance kelas Presentation yang mewakili file presentasi
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Mendapatkan koleksi slide dalam presentasi
    slides = presentation.getSlides()

    # Mengklon slide yang diinginkan ke indeks yang ditentukan dalam presentasi yang sama
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Menulis presentasi yang telah dimodifikasi ke disk
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klon Slide di Akhir Presentasi Lain**

Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, di akhir slide yang ada:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi presentasi sumber slide akan diklon.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dengan merujuk koleksi slide yang dikembalikan oleh [getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) pada objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) yang disediakan oleh objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dan berikan slide dari presentasi sumber sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone).
1. Simpan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami mengklon slide (dari indeks 0 presentasi sumber) ke akhir presentasi tujuan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat instance kelas Presentation untuk memuat file presentasi sumber
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Membuat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    destination_presentation = Presentation()
    try:
        # Mengklon slide yang diinginkan dari presentasi sumber ke akhir koleksi slide dalam presentasi tujuan
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Menulis presentasi tujuan ke disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klon Slide ke Posisi Lain dalam Presentasi Lain**

Jika Anda perlu mengklon slide dari satu presentasi dan menggunakannya dalam file presentasi lain, pada posisi tertentu:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi presentasi sumber slide akan diklon.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi presentasi tujuan tempat slide akan ditambahkan.
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dengan merujuk koleksi Slides yang disediakan oleh objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertClone) yang disediakan oleh objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dan berikan slide dari presentasi sumber bersama posisi yang diinginkan sebagai parameter ke metode [insertClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#insertClone).
1. Simpan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami mengklon slide (dari indeks nol presentasi sumber) ke indeks 1 (posisi 2) presentasi tujuan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat instance kelas Presentation untuk memuat file presentasi sumber
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Membuat instance kelas Presentation untuk PPTX tujuan (di mana slide akan diklon)
    destination_presentation = Presentation()
    try:
        # Mengklon slide yang diinginkan dari presentasi sumber ke indeks yang ditentukan dalam presentasi tujuan
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Menulis presentasi tujuan ke disk
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klon Slide dengan Master Slide ke Presentasi Lain**

Jika Anda perlu mengklon slide beserta master slide dari satu presentasi dan menggunakannya dalam presentasi lain, pertama‑tama Anda harus mengklon master slide yang diinginkan dari presentasi sumber ke presentasi tujuan. Kemudian gunakan master slide yang telah diklon tersebut saat mengklon slide. Metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) mengharapkan master slide dari presentasi tujuan, bukan dari presentasi sumber. Untuk mengklon slide dengan master, ikuti langkah‑langkah berikut:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi presentasi sumber slide akan diklon.
1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) yang berisi presentasi tujuan slide akan diklon ke sana.
1. Akses slide yang akan diklon beserta master slide‑nya.
1. Dapatkan objek [MasterSlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/) dengan merujuk koleksi Masters yang disediakan oleh objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/#addClone) yang disediakan oleh objek [MasterSlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/) dan berikan master dari PPTX sumber yang akan diklon sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslidecollection/#addClone).
1. Dapatkan objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dengan merujuk koleksi Slides yang disediakan oleh objek [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) dari presentasi tujuan.
1. Panggil metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) yang disediakan oleh objek [SlideCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/) dan berikan slide dari presentasi sumber yang akan diklon serta master slide sebagai parameter ke metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone).
1. Simpan file presentasi tujuan yang telah dimodifikasi.

Pada contoh di bawah ini, kami mengklon slide dengan master (yang berada pada indeks nol presentasi sumber) ke akhir presentasi tujuan menggunakan master slide sumber.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Membuat instance kelas Presentation untuk memuat file presentasi sumber
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Membuat instance kelas Presentation untuk presentasi tujuan (di mana slide akan diklon)
    destination_presentation = Presentation()
    try:
        # Membuat instance Slide dari koleksi slide dalam presentasi sumber bersama
        # Slide master
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Mengklon master slide yang diinginkan dari presentasi sumber ke koleksi master dalam
        # presentasi tujuan
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Mengklon slide yang diinginkan dari presentasi sumber dengan master yang diinginkan ke akhir
        # koleksi slide dalam presentasi tujuan
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Simpan presentasi tujuan ke disk
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klon Slide di Akhir Seksi yang Ditentukan**

Jika Anda ingin mengklon slide dan kemudian menggunakannya dalam file presentasi yang sama tetapi di seksi yang berbeda, gunakan metode [**addClone**](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/#addClone) yang disediakan oleh kelas [**SlideCollection**](https://reference.aspose.com/slides/id/python-java/aspose.slides/slidecollection/). Aspose.Slides for Python via Java memungkinkan mengklon slide dari seksi pertama dan kemudian menyisipkan slide yang diklon ke seksi kedua dalam presentasi yang sama.

Potongan kode berikut menunjukkan cara mengklon slide dan menyisipkan slide yang diklon ke seksi yang ditentukan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Simpan presentasi tujuan ke disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pastikan Ukuran Slide Cocok**

Saat mengklon slide ke presentasi lain, pastikan presentasi tujuan memiliki ukuran slide yang sama dengan sumber. Jika ukuran slide berbeda, Aspose.Slides tidak secara otomatis mengubah skala bentuk yang diklon—koordinat dan dimensi asli tetap dipertahankan, yang dapat menyebabkan konten terlihat tidak selaras atau melampaui batas slide.

Anda dapat mengatur ukuran slide presentasi tujuan agar cocok dengan sumber sebelum mengklon master dan slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Lakukan ini sebelum mengklon master dan slide.

## **FAQ**

**Apakah catatan pembicara dan komentar peninjau juga diklon?**

Ya. Halaman catatan dan komentar peninjau disertakan dalam klon. Jika Anda tidak menginginkannya, [hapus mereka](/slides/id/python-java/presentation-notes/) setelah penyisipan.

**Bagaimana diagram dan sumber data mereka ditangani?**

Objek diagram, pemformatan, dan data tersemat disalin. Jika diagram terhubung ke sumber eksternal (misalnya buku kerja yang disisipkan OLE), kaitan tersebut dipertahankan sebagai [objek OLE](/slides/id/python-java/manage-ole/). Setelah dipindahkan antar file, periksa ketersediaan data dan perilaku penyegaran.

**Bisakah saya mengontrol posisi penyisipan dan seksi untuk klon?**

Ya. Anda dapat menyisipkan klon pada indeks slide tertentu dan menempatkannya ke dalam [seksi](/slides/id/python-java/slide-section/) yang dipilih. Jika seksi target belum ada, buat terlebih dahulu kemudian pindahkan slide ke dalamnya.