---
title: Kelola Pertunjukan Slide di Python via Java
linktitle: Pertunjukan Slide
type: docs
weight: 90
url: /id/python-java/manage-slide-show/
keywords:
- tipe pertunjukan
- ditampilkan oleh pembicara
- ditelusuri oleh individu
- ditelusuri di kiosk
- opsi pertunjukan
- ulangi terus-menerus
- pertunjukan tanpa narasi
- pertunjukan tanpa animasi
- warna pena
- tampilkan slide
- pertunjukan kustom
- maju slide
- secara manual
- menggunakan timing
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengelola pertunjukan slide di Aspose.Slides untuk Python via Java. Kendalikan transisi slide, timing, dan lainnya pada format PPT, PPTX, dan ODP dengan mudah."
---
## **Pengenalan**

Opsi **Set Up Show** Microsoft PowerPoint memungkinkan Anda memilih jenis pertunjukan, mengaktifkan perulangan, memilih slide, dan mengontrol cara slide beralih. Dengan Aspose.Slides untuk Python via Java, Anda dapat mengkonfigurasi opsi ini secara programatis dan menyimpannya dalam file presentasi.

[Presentation.getSlideShowSettings](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlideShowSettings) mengembalikan objek [SlideShowSettings](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/) yang mengontrol opsi-opsi tersebut. Contoh di bawah ini memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Setiap contoh memulai JVM jika diperlukan dan melepaskan presentasi setelah selesai.

## **Pilih Tipe Pertunjukan**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setSlideShowType) mendefinisikan jenis pertunjukan slide, yang dapat berupa instansi dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/python-java/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/python-java/aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk skenario penggunaan yang berbeda, seperti kiosk otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur tipe pertunjukan menjadi "Browsed by an individual" tanpa menampilkan scrollbar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aktifkan Opsi Pertunjukan**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setLoop) menentukan apakah pertunjukan slide harus diulang dalam loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus‑menerus. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setShowNarration) menentukan apakah narasi suara harus diputar selama pertunjukan slide. Ini berguna untuk presentasi otomatis yang berisi panduan suara bagi audiens. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setShowAnimation) menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual lengkap pada presentasi.

Contoh kode berikut membuat presentasi baru dan melakukan loop pada pertunjukan slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pilih Slide Untuk Ditampilkan**

[SlideShowSettings.setSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setSlides) memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian dari presentasi, bukan semua slide. Contoh kode berikut membuat presentasi dengan sembilan slide dan memilih slide 2 sampai 9. Rentang tersebut menggunakan nomor slide berbasis satu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Buat sembilan slide sehingga rentang yang dipilih tersedia.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrol Pergerakan Slide**

[SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setUseTimings) memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan timing pra‑set untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang sudah ditentukan. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan timing.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tampilkan Kontrol Media**

[SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama pertunjukan slide ketika konten multimedia (misalnya video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kontrol atas pemutaran media selama presentasi.

Contoh kode berikut membuat presentasi baru dan mengaktifkan tampilan kontrol media.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode pertunjukan slide?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam mode pertunjukan slide ketika dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [during export](/slides/id/python-java/save-presentation/).

**Apakah saya dapat mengecualikan slide tertentu dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [hidden](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#setHidden). Slide yang disembunyikan tetap berada dalam presentasi tetapi tidak ditampilkan selama pertunjukan slide.

**Apakah Aspose.Slides dapat memutar pertunjukan slide atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran aktual ditangani oleh aplikasi penampil seperti PowerPoint.