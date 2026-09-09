---
title: Kelola Pertunjukan Slide dengan Python via Java
linktitle: Pertunjukan Slide
type: docs
weight: 90
url: /id/python-java/manage-slide-show/
keywords:
- jenis pertunjukan
- dipresentasikan oleh pembicara
- dilihat oleh individu
- dilihat di kiosk
- opsi pertunjukan
- putar terus-menerus
- pertunjukan tanpa narasi
- pertunjukan tanpa animasi
- warna pena
- tampilkan slide
- pertunjukan kustom
- majukan slide
- secara manual
- menggunakan waktu
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengelola pertunjukan slide di Aspose.Slides untuk Python via Java. Kendalikan transisi slide, waktu tampilan, dan lainnya pada format PPT, PPTX, dan ODP dengan mudah."
---
## **Pendahuluan**

Opsi **Set Up Show** Microsoft PowerPoint memungkinkan Anda memilih jenis pertunjukan, mengaktifkan pengulangan, memilih slide, dan mengontrol cara slide bergerak maju. Dengan Aspose.Slides untuk Python via Java, Anda dapat mengonfigurasi opsi ini secara programatis dan menyimpannya dalam file presentasi.

Metode [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlideShowSettings) mengembalikan objek [SlideShowSettings](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/) yang mengontrol opsi-opsi ini. Contoh di bawah ini memerlukan Aspose.Slides untuk Python via Java dan runtime Java yang kompatibel. Setiap contoh memulai JVM jika diperlukan dan melepaskan presentasi setelah selesai.

## **Pilih Jenis Pertunjukan**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setSlideShowType) mendefinisikan jenis slide show, yang dapat berupa instance dari kelas berikut: [PresentedBySpeaker](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/id/python-java/aspose.slides/browsedbyindividual/), atau [BrowsedAtKiosk](https://reference.aspose.com/slides/id/python-java/aspose.slides/browsedatkiosk/). Menggunakan metode ini memungkinkan Anda menyesuaikan presentasi untuk berbagai skenario penggunaan, seperti kios otomatis atau presentasi manual.

Contoh kode di bawah ini membuat presentasi baru dan mengatur jenis pertunjukan menjadi “Browsed by an individual” tanpa menampilkan scrollbar.

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

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setLoop) menentukan apakah slide show harus berulang dalam loop hingga dihentikan secara manual. Ini berguna untuk presentasi otomatis yang perlu berjalan terus-menerus. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setShowNarration) menentukan apakah narasi suara harus diputar selama slide show. Ini berguna untuk presentasi otomatis yang berisi panduan suara untuk audiens. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setShowAnimation) menentukan apakah animasi yang ditambahkan ke objek slide harus diputar. Ini berguna untuk memberikan efek visual lengkap dari presentasi.

Contoh kode berikut membuat presentasi baru dan mengulang slide show.

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

## **Pilih Slide yang Ditampilkan**

Metode [SlideShowSettings.setSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setSlides) memungkinkan Anda memilih rentang slide yang akan ditampilkan selama presentasi. Ini berguna ketika Anda hanya perlu menampilkan sebagian presentasi, bukan semua slide. Contoh kode berikut membuat presentasi dengan sembilan slide dan memilih slide 2 hingga 9. Rentang tersebut menggunakan nomor slide berbasis satu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # Buat sembilan slide sehingga rentang yang dipilih ada.
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

## **Kendalikan Pergerakan Slide**

Metode [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setUseTimings) memungkinkan Anda mengaktifkan atau menonaktifkan penggunaan waktu bawaan untuk setiap slide. Ini berguna untuk menampilkan slide secara otomatis dengan durasi tampilan yang telah ditentukan sebelumnya. Contoh kode di bawah ini membuat presentasi baru dan menonaktifkan penggunaan waktu.

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

Metode [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) menentukan apakah kontrol media (seperti putar, jeda, dan berhenti) harus ditampilkan selama slide show ketika konten multimedia (misalnya video atau audio) diputar. Ini berguna ketika Anda ingin memberi presenter kontrol atas pemutaran media selama presentasi.

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

**Apakah saya dapat menyimpan presentasi sehingga langsung terbuka dalam mode slide show?**

Ya. Simpan file sebagai PPSX atau PPSM; format ini langsung diluncurkan dalam mode slide show ketika dibuka di PowerPoint. Di Aspose.Slides, pilih format penyimpanan yang sesuai [saat mengekspor](/slides/id/python-java/save-presentation/).

**Apakah saya dapat mengecualikan slide individual dari pertunjukan tanpa menghapusnya dari file?**

Ya. Tandai slide sebagai [tersembunyi](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#setHidden). Slide tersembunyi tetap ada dalam presentasi namun tidak ditampilkan selama slide show.

**Apakah Aspose.Slides dapat memutar slide show atau mengontrol presentasi langsung di layar?**

Tidak. Aspose.Slides mengedit, menganalisis, dan mengonversi file presentasi; pemutaran sebenarnya ditangani oleh aplikasi penampil seperti PowerPoint.