---
title: Kelola Header dan Footer Presentasi di Python melalui Java
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/python-java/presentation-header-and-footer/
keywords:
- header
- teks header
- footer
- teks footer
- atur header
- atur footer
- handout
- catatan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk Python melalui Java."
---
## **Gambaran Umum**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides untuk Python melalui Java memungkinkan Anda mengontrol teks dan visibilitas placeholder tersebut melalui kelas manajer header/footer.

Placeholder yang tersedia tergantung pada lingkup:

| Lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Slide reguler | Tidak | Ya | Ya | Ya |
| Notes master | Ya | Ya | Ya | Ya |
| Notes slide | Ya | Ya | Ya | Ya |
| Handout master | Ya | Ya | Ya | Ya |

Sebuah slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan handout. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Lingkup perubahan tergantung pada manajer yang Anda gunakan. Kelas [SlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideheaderfootermanager/) mengontrol satu slide reguler. Kelas [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/notesslideheaderfootermanager/) mengontrol satu slide catatan. Manajer master dan layout juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara kelas [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) mengontrol handout master.

## **Mengatur Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manajer header/footer setiap slide, mengatur teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, sehingga Anda hanya perlu mengontrol visibilitasnya.

Gunakan [setFooterText](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) dan [setDateTimeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) untuk mengatur teks, serta gunakan [setFooterVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), dan [setSlideNumberVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) untuk menampilkan placeholder yang sesuai.

Contoh end-to-end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama pada semua slide reguler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jika Anda perlu memperbarui hanya satu slide, akses slide tersebut langsung melalui metode [getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides) alih-alih mengulang seluruh koleksi.

## **Mengatur Header dan Footer pada Notes Master**

Notes master mendefinisikan format umum dan perilaku placeholder untuk halaman catatan. Gunakan kelas [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya notes master itu sendiri.

Contoh berikut mengatur teks header, footer, dan tanggal/waktu pada notes master dan membuat semua placeholder yang didukung terlihat pada master tersebut:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metode `getMasterNotesSlide` mengembalikan `None` ketika presentasi tidak berisi notes master.

## **Menerapkan Pengaturan Notes Master ke Catatan Slide Anak**

Notes master dapat menerapkan pengaturan header dan footer ke dirinya sendiri dan ke semua catatan slide yang bergantung. Gunakan metode propagasi khusus pada [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki catatan.

Sebagai contoh, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) dan [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) memperbarui header notes master dan semua header anak. Metode setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metode propagasi yang digunakan di atas adalah [setFooterAndChildFootersText](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), dan [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Mengatur Header dan Footer pada Slide Catatan Individual**

Sebuah catatan slide milik slide reguler tertentu. Gunakan kelas [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/notesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [addNotesSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/notesslidemanager/#addNotesSlide) mengembalikan catatan slide untuk slide saat ini dan membuatnya jika belum ada. Contoh berikut mengonfigurasi halaman catatan yang terkait dengan slide presentasi pertama:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jika Anda pertama-tama menyebarkan pengaturan dari notes master dan kemudian mengubah catatan slide individual, pengaturan per-slide selanjutnya memungkinkan Anda menyesuaikan halaman catatan tersebut secara independen.

## **Mengatur Header dan Footer pada Handout Master**

Halaman handout menggunakan handout master untuk placeholder header, footer, tanggal/waktu, dan nomor halaman mereka. Berbeda dengan halaman catatan, pengaturan handout dikelola melalui handout master bukan melalui slide handout individual.

Gunakan metode `getMasterHandoutSlide` untuk mengakses handout master. Jika tidak ada, panggil `setDefaultMasterHandoutSlide` untuk membuat handout master default.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Memahami Lingkup dan Pewarisan**

Pilih manajer header/footer yang sesuai dengan lingkup yang ingin Anda ubah:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/slideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslideheaderfootermanager/) mengontrol sebuah slide layout dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masternotesslideheaderfootermanager/) mengontrol notes master dan dapat menyebarkan pengaturan ke semua catatan slide yang bergantung.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/notesslideheaderfootermanager/) mengubah satu catatan slide dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) mengubah handout master dan mendukung keempat tipe placeholder.

Gunakan propagasi dari master atau layout ketika pengaturan yang sama harus berlaku sepanjang hierarki tersebut. Gunakan manajer slide individual atau notes-slide ketika Anda memerlukan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header pada slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan handout.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manajer header/footer yang bersangkutan untuk memeriksa visibilitasnya dan mengaktifkannya bila diperlukan. Sebagai contoh, [isFooterVisible](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) melaporkan apakah placeholder footer hadir, dan [setFooterVisibility](https://reference.aspose.com/slides/id/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Panggil metode [setFirstSlideNumber](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#setFirstSlideNumber) pada presentasi. Placeholder nomor slide kemudian akan menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama konten presentasi lainnya dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.