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
- presentasi
- Python
- Aspose.Slides
description: "Gunakan Aspose.Slides for Python via .NET untuk menambahkan dan menyesuaikan header serta footer dalam presentasi PowerPoint dan OpenDocument agar terlihat profesional."
---
## **Ikhtisar**

Aspose.Slides for Python memungkinkan Anda mengontrol placeholder header dan footer di seluruh presentasi dengan ruang lingkup yang tepat. Teks footer, tanggal/waktu, dan nomor slide pada slide dikelola dari level master dan dapat diterapkan secara global atau disesuaikan per slide. Header didukung pada catatan dan handout, di mana Anda dapat mengaktifkan visibilitas dan mengatur teks untuk header, footer, tanggal/waktu, dan nomor halaman melalui pengelola header & footer khusus pada slide catatan master atau slide catatan individu. Artikel ini menjelaskan pola utama untuk memperbarui placeholder ini dan menyebarkan perubahan secara konsisten di seluruh dek Anda.

## **Kelola Teks Header dan Footer**

Di bagian ini, Anda akan mempelajari cara mengelola konten header dan footer dalam presentasi—mengaktifkan atau memodifikasi footer, tanggal dan waktu, serta nomor slide. Kami akan memberi gambaran singkat tentang ruang lingkup penerapan pengaturan ini (seluruh presentasi, slide individu, dan tampilan catatan/handout) serta menunjukkan cara menggunakan API Aspose.Slides untuk memperbaruinya dengan cepat dan konsisten.

Contoh kode di bawah ini membuka sebuah presentasi, mengaktifkan dan mengatur teks footer, memperbarui teks header pada slide catatan master, dan menyimpan file.

```py
import aspose.slides as slides

# Fungsi untuk mengatur teks header.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Muat presentasi.
with slides.Presentation("sample.pptx") as presentation:
    # Atur footer.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Akses dan perbarui header.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Simpan presentasi.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Kelola Header dan Footer pada Slide Catatan**

Di bagian ini, Anda akan mempelajari cara mengelola header dan footer khusus untuk slide catatan di Aspose.Slides. Kami akan membahas cara mengaktifkan placeholder yang relevan, mengatur teks untuk footer, tanggal/waktu, dan nomor halaman, serta menerapkan perubahan ini secara konsisten di seluruh master catatan dan halaman catatan individu.

Ikuti langkah‑langkah di bawah ini:

1. Muat file presentasi.
1. Dapatkan slide catatan master dan [header & footer manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. Pada slide catatan master, aktifkan visibilitas Header, Footer, Slide number, dan Date-time untuk master dan semua slide catatan anak.
1. Pada slide catatan master, atur teks untuk Header, Footer, dan Date-time untuk master dan semua slide catatan anak.
1. Dapatkan slide catatan untuk slide presentasi pertama dan [header & footer manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/notesslideheaderfootermanager/).
1. Untuk slide catatan pertama ini saja, pastikan Header, Footer, Slide number, dan Date-time terlihat (nyalakan yang mati).
1. Untuk slide catatan pertama ini saja, atur teks untuk Header, Footer, dan Date-time.
1. Simpan presentasi dalam format PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Buat slide catatan master dan semua placeholder header, footer, nomor slide, dan tanggal/waktu pada anak menjadi terlihat.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Atur teks pada slide catatan master dan semua placeholder header, footer, serta tanggal/waktu pada anak.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Ubah pengaturan header, footer, nomor slide, dan tanggal/waktu hanya untuk slide catatan pertama.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Pastikan placeholder header, footer, nomor slide, dan tanggal/waktu terlihat.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Atur teks pada placeholder header, footer, dan tanggal/waktu slide catatan.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Simpan presentasi.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bisakah saya menambahkan "header" ke slide reguler?**

Di PowerPoint, "Header" hanya ada untuk catatan dan handout; pada slide reguler, elemen yang didukung adalah footer, tanggal/waktu, dan nomor slide. Di Aspose.Slides hal ini sama: header hanya untuk Notes/Handout, dan pada slide—Footer/DateTime/SlideNumber.

**Bagaimana jika tata letak tidak memiliki area footer—apakah saya dapat "menyalakan" visibilitasnya?**

Ya. Periksa visibilitas melalui pengelola header/footer dan aktifkan bila diperlukan. Indikator dan metode API ini dirancang untuk kasus ketika placeholder tidak ada atau tersembunyi.

**Bagaimana cara membuat nomor slide dimulai dari nilai selain 1?**

Atur [first slide number](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/first_slide_number/) pada presentasi; setelah itu, semua penomoran akan dihitung ulang. Misalnya, Anda dapat memulai dari 0 atau 10, dan menyembunyikan nomor pada slide judul.

**Apa yang terjadi pada header/footer saat mengekspor ke PDF/gambar/HTML?**

Mereka dirender sebagai elemen teks biasa dalam presentasi. Artinya, jika elemen tersebut terlihat pada slide/halaman catatan, mereka juga akan muncul dalam format output bersama konten lainnya.