---
title: Kelola Header dan Footer Presentasi dengan Python
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/python-net/presentation-header-and-footer/
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
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk Python melalui .NET."
---
## **Gambaran Umum**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada tipe halaman. Aspose.Slides untuk Python via .NET memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui kelas manajer header/footer.

Placeholder yang tersedia bergantung pada ruang lingkup:

| Lingkup | Header | Footer | Tanggal/Waktu | Nomor Slide/Halaman |
|---|---|---|---|---|
| Slide reguler | Tidak | Ya | Ya | Ya |
| Master catatan | Ya | Ya | Ya | Ya |
| Slide catatan | Ya | Ya | Ya | Ya |
| Master handout | Ya | Ya | Ya | Ya |

Slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan handout. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Ruang lingkup perubahan tergantung pada manajer yang Anda gunakan. Kelas [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/slideheaderfootermanager/) mengontrol satu slide reguler. Kelas [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslideheaderfootermanager/) mengontrol satu slide catatan. Manajer master dan layout juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara kelas [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) mengontrol master handout.

## **Menetapkan Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses manajer header/footer masing‑masing slide, menetapkan teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, sehingga Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`set_footer_text`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) dan [`set_date_time_text`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) untuk menetapkan teks, serta [`set_footer_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), dan [`set_slide_number_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) untuk menampilkan placeholder yang bersangkutan.

Contoh end‑to‑end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama pada semua slide reguler:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda hanya perlu memperbarui satu slide, akses slide tersebut langsung melalui koleksi [`slides`](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/slides/id/) alih‑alih mengiterasi seluruh koleksi.

## **Menetapkan Header dan Footer pada Master Catatan**

Master catatan mendefinisikan format umum dan perilaku placeholder untuk halaman catatan. Gunakan kelas [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya master catatan itu sendiri.

Contoh berikut menetapkan header, footer, dan teks tanggal/waktu pada master catatan serta membuat semua placeholder yang didukung terlihat pada master tersebut:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Sebuah presentasi mungkin tidak berisi master catatan, jadi periksa nilai yang dikembalikan apakah `None` sebelum mengubahnya.

## **Menerapkan Pengaturan Master Catatan ke Slide Catatan Anak**

Master catatan dapat menerapkan pengaturan header dan footer pada dirinya sendiri serta semua slide catatan yang bergantung. Gunakan metode propagasi khusus pada [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki catatan.

Misalnya, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) dan [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) memperbarui header master catatan dan semua header anak. Metode setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Metode propagasi yang digunakan di atas meliputi [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), dan [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Menetapkan Header dan Footer pada Slide Catatan Individual**

Sebuah slide catatan terkait dengan slide reguler tertentu. Gunakan kelas [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [`add_notes_slide`](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslidemanager/add_notes_slide/) mengembalikan slide catatan untuk slide saat ini dan membuatnya jika belum ada. Contoh berikut mengonfigurasi halaman catatan yang terkait dengan slide presentasi pertama:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Jika Anda pertama‑tama menyebarkan pengaturan dari master catatan dan kemudian mengubah slide catatan individual, pengaturan per‑slide yang terakhir memungkinkan Anda menyesuaikan halaman catatan tersebut secara terpisah.

## **Menetapkan Header dan Footer pada Master Handout**

Halaman handout menggunakan master handout untuk placeholder header, footer, tanggal/waktu, dan nomor halaman. Tidak seperti halaman catatan, pengaturan handout dikelola melalui master handout, bukan melalui slide handout individual.

Gunakan properti [`master_handout_slide`](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) untuk mengakses master handout. Jika tidak ada, panggil [`set_default_master_handout_slide`](https://reference.aspose.com/slides/id/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) untuk membuat master handout default.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Memahami Ruang Lingkup dan Pewarisan**

Pilih manajer header/footer yang sesuai dengan ruang lingkup yang ingin Anda ubah:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/slideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslideheaderfootermanager/) mengontrol slide layout dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/) mengontrol master catatan dan dapat menyebarkan pengaturan ke semua slide catatan yang bergantung.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslideheaderfootermanager/) mengubah satu slide catatan dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) mengubah master handout dan mendukung keempat tipe placeholder.

Gunakan propagasi dari master atau layout ketika pengaturan yang sama harus diterapkan di seluruh hierarki terkait. Gunakan manajer slide individual atau notes‑slide ketika Anda memerlukan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header pada slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan handout.

**Bagaimana bila placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan manajer header/footer yang bersangkutan untuk memeriksa visibilitasnya dan mengaktifkannya bila diperlukan. Misalnya, [`is_footer_visible`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) melaporkan apakah placeholder footer ada, dan [`set_footer_visibility`](https://reference.aspose.com/slides/id/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Tetapkan properti [`first_slide_number`](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/first_slide_number/) pada presentasi. Placeholder nomor slide kemudian akan menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama konten presentasi lainnya dalam format output. Penampilannya bergantung pada tipe halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.