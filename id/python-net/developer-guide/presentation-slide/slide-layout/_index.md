---
title: Terapkan atau Ubah Tata Letak Slide dalam Python
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/python-net/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- tajuk bagian
- dua konten
- perbandingan
- hanya judul
- tata letak kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi tata letak slide dalam Aspose.Slides untuk Python via .NET, tambahkan placeholder, hapus tata letak yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan sebuah tata letak memberikan slide struktur yang konsisten sambil memungkinkan setiap slide berisi kontennya sendiri.

Tata letak yang paling umum meliputi:

- **Title Slide**: Mengandung placeholder judul dan subjudul.
- **Title and Content**: Mengandung placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak mengandung placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkatan terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/) menentukan tema, pemformatan bersama, latar belakang, dan objek umum.
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/) merupakan bagian dari master dan menentukan susunan khusus placeholder.
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan secara langsung pada sebuah normal slide akan menggantikan nilai yang diwarisi pada tingkat tersebut. Ketika sebuah normal slide dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke sebuah tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambah bentuk placeholder yang sesuai pada slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada sebuah tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah dipakai, periksa slide‑slide yang bergantung padanya dan tinjau presentasi yang dihasilkan.
- Tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung padanya ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak dipakai.

Untuk informasi lebih lanjut tentang tingkat teratas hierarki ini, lihat [Slide Master](/slides/id/python-net/slide-master/).

Untuk menyembunyikan logo yang diwarisi atau bentuk master dekoratif pada satu slide atau melalui tata letak bersama, lihat [Control the Visibility of Master Graphics](/slides/id/python-net/slide-master/). Contoh ini membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika tata letak tersebut tidak tersedia, ia sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan pada slide normal pertama melalui properti [Slide.layout_slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan keterkaitan antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa hasilnya saat beralih antara tata letak yang sangat berbeda.

## **Tambah Tata Letak Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterlayoutslidecollection/add/) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Title and Content** baru dengan nama `Report Title and Content`, kemudian menambahkan slide normal yang didasarkan padanya. Nama tata letak harus unik dalam koleksi.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Tambahkan tata letak hanya ketika templat memang membutuhkan struktur dapat pakai ulang lain. Jika tata letak yang cocok sudah ada, pilih dan pakai kembali alih‑alih membuat duplikat.

## **Tambah Placeholder ke Tata Letak Slide**

Properti [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/placeholder_manager/) menyediakan sebuah [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah tata letak.

| Placeholder PowerPoint              | Metode `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------- |
| ![Konten](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Konten (Vertikal)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Teks](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Teks (Vertikal)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Gambar](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Diagram](chart.png)               | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabel](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Gambar Online](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Contoh berikut memverifikasi bahwa tata letak **Blank** ada, menambahkan empat placeholder ke dalamnya, kemudian membuat slide normal yang menggunakan tata letak yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Hasilnya:

![Placeholder pada tata letak slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder tata letak yang ada dapat memengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis diisi pada slide normal yang ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Tata Letak Slide yang Tidak Digunakan**

Gunakan metode [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) untuk menghapus tata letak yang tidak diacu oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih dipakai tetap utuh.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Untuk menghapus satu tata letak tertentu, pertama gunakan properti [has_depending_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/has_depending_slides/) atau metode [get_depending_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/get_depending_slides/) miliknya. Alihkan slide‑slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/remove/). Mencoba menghapus tata letak yang masih dipakai akan menimbulkan [PptxEditException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxeditexception/).

## **Kendalikan Visibilitas Footer pada Tata Letak Slide**

Sebuah tata letak memiliki placeholder footer, nomor slide, dan tanggal‑waktu sendiri. Gunakan properti [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/header_footer_manager/) untuk mengendalikan placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak dengan aman dan membuat elemen footernya terlihat:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Kendalikan Visibilitas Footer pada Master dan Tata Letak Anak‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan properti [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslide/header_footer_manager/). Metode propagasi dari [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/masterslideheaderfootermanager/) beroperasi pada master serta tata letak slide dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Apa Perbedaan Antara Master Slide dan Layout Slide?**

Sebuah master slide menentukan tema presentasi dan pemformatan bersama. Sebuah layout slide merupakan bagian dari master dan menentukan satu susunan placeholder yang dapat dipakai ulang. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [add_clone](https://reference.aspose.com/slides/id/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Saat menyalin antara presentasi, pastikan juga font, tema, gambar, dan sumber daya lain yang digunakan oleh tata letak sumber.

**Apa yang Terjadi Ketika Saya Memodifikasi Tata Letak yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan tata letak kecuali mereka mengganti pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [get_depending_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides/layoutslide/get_depending_slides/) untuk mengidentifikasi slide yang terpengaruh sebelum menyunting tata letak.

**Apa yang Terjadi Jika Saya Menghapus Tata Letak yang Masih Digunakan?**

Aspose.Slides menimbulkan [PptxEditException](https://reference.aspose.com/slides/id/python-net/aspose.slides/pptxeditexception/). Alihkan slide‑slide yang bergantung terlebih dahulu, atau gunakan [remove_unused_layout_slides](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) untuk menghapus hanya tata letak yang tidak dirujuk.