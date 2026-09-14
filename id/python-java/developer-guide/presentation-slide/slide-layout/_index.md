---
title: Menerapkan atau Mengubah Tata Letak Slide di Python melalui Java
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/python-java/slide-layout/
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
- header bagian
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
- Java
- Aspose.Slides
description: "Menerapkan, membuat, dan memodifikasi tata letak slide di Aspose.Slides untuk Python melalui Java, menambahkan placeholder, menghapus tata letak yang tidak terpakai, dan mengontrol visibilitas footer."
---
## **Gambaran Umum**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sambil memungkinkan setiap slide berisi kontennya masing‑masing.

Tata letak yang paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subjudul.
- **Title and Content**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkatan terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/) mendefinisikan tema, format bersama, latar belakang, dan objek umum.
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/) milik master dan mendefinisikan susunan placeholder tertentu.
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari tata letaknya, dan tata letak tersebut mewarisi dari masternya. Nilai yang ditetapkan langsung pada normal slide akan menggantikan nilai yang diwariskan pada tingkat itu. Ketika sebuah normal slide dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke sebuah tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambahkan bentuk placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah format yang diwariskan atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah digunakan, periksa slide yang bergantung padanya dan tinjau presentasi yang dihasilkan.
- Tata letak yang masih digunakan oleh slide tidak dapat dihapus. Alihkan slide yang bergantung ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak terpakai.

Untuk informasi lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/python-java/slide-master/).

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika tata letak tersebut tidak tersedia, secara sengaja akan kembali ke **Blank**. Pemeriksaan kedua untuk `None` diperlukan karena presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [Slide.setLayoutSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, format yang diwariskan, dan kesesuaian antara placeholder yang ada dengan tata letak baru dapat berubah, jadi periksa output ketika beralih antara tata letak yang secara substansial berbeda.

## **Tambahkan Tata Letak Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; ia tidak membuat yang baru. Untuk membuat tata letak, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterlayoutslidecollection/#add) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Title and Content** baru bernama `Report Title and Content`, lalu menambahkan slide normal berdasarkan tata letak tersebut. Nama tata letak harus unik dalam koleksi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tambahkan tata letak hanya ketika templat benar‑benar membutuhkan struktur dapat digunakan kembali lainnya. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali daripada membuat duplikat.

## **Tambahkan Placeholder ke Tata Letak Slide**

Metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getPlaceholderManager) menyediakan sebuah [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah tata letak.

| PowerPoint Placeholder | [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/) Metode |
| ---------------------- | ---------------------------------------- |
| ![Content](content.png) | [addContentPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png) | [addTextPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png) | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png) | [addPicturePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png) | [addChartPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png) | [addTablePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [addSmartArtPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [addMediaPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png) | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Contoh berikut memverifikasi bahwa tata letak **Blank** ada, menambahkan empat placeholder ke dalamnya, kemudian membuat slide normal yang menggunakan tata letak yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Hasilnya:

![Placeholder pada tata letak slide](add_placeholders.png)

{{% alert color="warning" title="Peringatan" %}}
Mengubah format yang diwariskan atau geometri placeholder tata letak yang ada dapat memengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak otomatis ditambahkan ke slide normal yang ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Tata Letak Slide yang Tidak Terpakai**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus tata letak yang tidak dirujuk oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih digunakan tetap utuh.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#hasDependingSlides) atau [getDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getDependingSlides). Alihkan slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#remove). Mencoba menghapus tata letak yang masih digunakan akan memicu [PptxEditException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Tata Letak Slide**

Sebuah tata letak memiliki footer, nomor slide, dan placeholder tanggal‑waktu masing‑masing. Gunakan metode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) untuk mengontrol placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak secara aman dan membuat elemen footernya terlihat:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrol Visibilitas Footer pada Master dan Tata Letak Turunannya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Metode propagasi dari [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslideheaderfootermanager/) beroperasi pada master serta tata letak dan slide normal yang bergantung; mereka tidak menargetkan satu slide normal saja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Apa Perbedaan antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema presentasi dan format bersama. Layout slide milik master dan mendefinisikan satu susunan placeholder yang dapat digunakan kembali. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/globallayoutslidecollection/#addClone). Saat menyalin antar presentasi, juga verifikasi font, tema, gambar, dan sumber daya lain yang digunakan oleh tata letak sumber.

**Apa yang Terjadi Ketika Saya Memodifikasi Tata Letak yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan tata letak kecuali mereka menimpa format atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwariskan dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getDependingSlides) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit tata letak.

**Apa yang Terjadi Jika Saya Menghapus Tata Letak yang Masih Digunakan?**

Aspose.Slides memicu [PptxEditException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus hanya tata letak yang tidak dirujuk.