---
title: Menerapkan atau Mengubah Tata Letak Slide dalam Python via Java
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
description: "Menerapkan, membuat, dan memodifikasi tata letak slide dalam Aspose.Slides untuk Python via Java, menambahkan placeholder, menghapus tata letak yang tidak terpakai, dan mengontrol visibilitas footer."
---
## **Ikhtisar**

Tata letak slide mendefinisikan posisi dan format placeholder seperti judul, teks, gambar, bagan, dan tabel. Menerapkan tata letak memberi slide struktur yang konsisten sekaligus memungkinkan setiap slide berisi konten masing‑masing.

Tata letak yang paling umum meliputi:

- **Slide Judul**: Memuat placeholder judul dan subjudul.  
- **Judul dan Konten**: Memuat placeholder judul dan placeholder konten umum.  
- **Kosong**: Tidak memuat placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Presentasi memiliki tiga level terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/) mendefinisikan tema, format bersama, latar belakang, dan objek umum.  
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/) milik master dan mendefinisikan susunan placeholder tertentu.  
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan format dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan langsung pada normal slide akan menggantikan nilai yang diwariskan pada level itu. Ketika sebuah normal slide dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak nanti tidak secara otomatis menambah bentuk placeholder yang bersesuaian ke normal slide yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah format yang diwariskan atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum menyunting tata letak yang sudah dipakai, periksa slide‑slide yang bergantung dan tinjau hasil presentasinya.  
- Tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan dulu slide‑slide yang bergantung ke tata letak lain, atau hapus hanya tata letak yang tidak terpakai.

Untuk informasi lebih lanjut tentang level teratas hierarki ini, lihat [Slide Master](/slides/id/python-java/slide-master/).

Untuk menyembunyikan logo atau bentuk master dekoratif yang diwariskan pada satu slide atau melalui tata letak bersama, lihat [Control the Visibility of Master Graphics](/slides/id/python-java/slide-master/). Contoh ini membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit oleh pengguna dan dapat dilokalisasi, sehingga pemilihan berbasis nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Judul dan Konten** pada master pertama. Jika tata letak itu tidak tersedia, secara sengaja beralih ke **Kosong**. Pemeriksaan kedua untuk `None` diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [Slide.setLayoutSlide](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#setLayoutSlide).

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

Mengubah tata letak sebuah slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, format yang diwariskan, dan korespondensi antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa hasilnya saat beralih antara tata letak yang secara substansial berbeda.

## **Tambahkan Layout Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang sudah ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterlayoutslidecollection/#add) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Judul dan Konten** baru bernama `Report Title and Content`, lalu menambahkan slide normal berdasarkan tata letak tersebut. Nama tata letak harus unik dalam koleksi.

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

Tambahkan tata letak hanya ketika templat memang memerlukan struktur dapat pakai lain. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali alih‑alih membuat duplikat.

## **Tambahkan Placeholder ke Layout Slide**

Metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getPlaceholderManager) menyediakan sebuah [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke tata letak.

| Placeholder PowerPoint               | Metode [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/) |
| ------------------------------------ | ---------------------------------------- |
| ![Content](content.png)              | [addContentPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png)  | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                    | [addTextPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)        | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)              | [addPicturePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                  | [addChartPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                  | [addTablePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)            | [addSmartArtPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                  | [addMediaPlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)     | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Contoh berikut memverifikasi bahwa tata letak **Kosong** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang menggunakan tata letak yang telah diubah. Urutan ini disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang bersesuaian pada slide tersebut.

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

![Placeholder pada layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah format yang diwariskan atau geometri placeholder tata letak yang ada dapat memengaruhi slide‑slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Layout Slide yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus tata letak yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih dipakai tetap utuh.

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

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#hasDependingSlides) atau [getDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getDependingSlides). Alihkan dulu slide‑slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#remove). Mencoba menghapus tata letak yang sedang dipakai akan menyebabkan [PptxEditException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Layout Slide**

Sebuah tata letak memiliki placeholder footer, nomor slide, dan tanggal‑waktu sendiri. Gunakan metode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) untuk mengontrol placeholder‑placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

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

## **Kontrol Visibilitas Footer pada Master dan Layout‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Metode propagasi pada [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/python-java/aspose.slides/masterslideheaderfootermanager/) bekerja pada master serta tata letak dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

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

**Apa Perbedaan Antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema presentasi dan format bersama. Layout slide milik master dan mendefinisikan satu susunan placeholder yang dapat dipakai ulang. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/python-java/aspose.slides/globallayoutslidecollection/#addClone). Saat menyalin antar presentasi, pastikan juga font, tema, gambar, dan sumber daya lain yang dipakai oleh layout sumber.

**Apa yang Terjadi Jika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menimpa format atau objek yang terpengaruh secara lokal. Geometri placeholder dan styling yang diwariskan dapat berubah pada banyak slide secara bersamaan. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/layoutslide/#getDependingSlides) untuk mengidentifikasi slide yang terpengaruh sebelum menyunting layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/python-java/aspose.slides/pptxeditexception/). Alihkan dulu slide yang bergantung, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus hanya layout yang tidak direferensikan.