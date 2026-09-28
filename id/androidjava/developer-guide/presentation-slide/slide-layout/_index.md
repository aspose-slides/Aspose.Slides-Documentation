---
title: Terapkan atau Ubah Layout Slide di Android
linktitle: Layout Slide
type: docs
weight: 60
url: /id/androidjava/slide-layout/
keywords:
- layout slide
- layout konten
- placeholder
- desain presentasi
- desain slide
- layout tidak terpakai
- visibilitas footer
- slide judul
- judul dan konten
- header bagian
- dua konten
- perbandingan
- hanya judul
- layout kosong
- konten dengan keterangan
- gambar dengan keterangan
- judul dan teks vertikal
- judul vertikal dan teks
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi layout slide dalam Aspose.Slides untuk Android via Java, tambahkan placeholder, hapus layout yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Layout slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan layout memberikan slide struktur yang konsisten sambil memungkinkan setiap slide berisi konten masing‑-masing.

Layout paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subjudul.
- **Title and Content**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Layout**

Sebuah presentasi memiliki tiga tingkatan yang terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/) termasuk dalam master dan mendefinisikan susunan placeholder tertentu.
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/) menggunakan satu layout dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari layoutnya, dan layout mewarisi dari masternya. Nilai yang diatur langsung pada normal slide menggantikan nilai yang diwarisi pada tingkat itu. Ketika sebuah normal slide dibuat, shape placeholder‑nya dihasilkan dari layout yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke sebuah layout sebelum membuat slide darinya. Menambahkan placeholder lain ke layout kemudian tidak secara otomatis menambah shape placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada layout dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit layout yang sudah dipakai, inspeksi slide‑slide yang bergantung dan tinjau hasil presentasi.
- Sebuah layout yang masih digunakan oleh slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung ke layout lain terlebih dahulu, atau hapus hanya layout yang tidak digunakan.

Untuk informasi lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/androidjava/slide-master/).

Untuk menyembunyikan logo yang diwarisi atau shape master dekoratif pada satu slide atau melalui layout bersama, lihat [Control the Visibility of Master Graphics](/slides/id/androidjava/slide-master/). Contoh membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Layout Slide**

Gunakan tipe layout ketika presentasi mengikuti definisi layout PowerPoint standar. Nama layout dapat diedit oleh pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang dapat diandalkan kecuali Anda mengendalikan templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika layout itu tidak tersedia, secara sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya layout khusus. Layout yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [ISlide.setLayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mengubah layout slide tidak menghapus shape biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan korespondensi antara placeholder yang ada dengan layout baru dapat berubah, sehingga inspeksi output diperlukan ketika beralih antar layout yang sangat berbeda.

## **Tambah Layout Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih layout yang sudah ada; tidak membuat yang baru. Untuk membuat layout, panggil metode [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) pada koleksi layout master target.

Contoh berikut selalu menambahkan layout **Title and Content** baru bernama `Report Title and Content`, lalu menambahkan slide normal berdasarinya. Nama layout harus unik dalam koleksi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Tambahkan layout hanya ketika templat memang membutuhkan struktur dapat digunakan kembali lain. Jika layout yang cocok sudah ada, pilih dan gunakan kembali alih‑alih membuat duplikat.

## **Tambah Placeholder ke Layout Slide**

Metode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) menyediakan sebuah [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) untuk menambahkan shape placeholder ke sebuah layout.

| Placeholder PowerPoint              | Metode `ILayoutPlaceholderManager` |
| ----------------------------------- | ---------------------------------- |
| ![Konten](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Konten (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Teks](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Teks (Vertikal)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Gambar](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabel](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Gambar Online](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Contoh berikut memverifikasi bahwa layout **Blank** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang memakai layout yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan shape placeholder yang sesuai pada slide tersebut.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Placeholder pada layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder layout yang ada dapat memengaruhi slide‑slide yang bergantung. Placeholder layout yang baru ditambahkan tidak otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan layout pada salinan presentasi dan inspeksi setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Layout Slide yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) untuk menghapus layout yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan layout yang masih digunakan tetap utuh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Untuk menghapus satu layout tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) atau [getDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) pada layout tersebut. Alihkan slide‑slide yang bergantung sebelum memanggil [ILayoutSlide.remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#remove--). Mencoba menghapus layout yang sedang dipakai akan memunculkan [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Layout Slide**

Sebuah layout memiliki footer, nomor slide, dan placeholder tanggal‑waktu sendiri. Gunakan metode [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) untuk mengontrol placeholder tersebut pada satu layout. Ini berguna ketika, misalnya, layout konten harus menampilkan footer tetapi layout judul tidak.

Contoh berikut memilih layout secara aman dan membuat elemen footernya terlihat:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrol Visibilitas Footer pada Master dan Layout Anak‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Metode propagasi dari [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) beroperasi pada master serta layout slide dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Apa Perbedaan antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema presentasi dan pemformatan bersama. Layout slide termasuk dalam master dan mendefinisikan satu susunan placeholder yang dapat digunakan kembali. Slide normal memakai layout‑layout tersebut dan menyimpan konten khusus slide.

**Apakah Saya Bisa Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Saat menyalin antar presentasi, juga periksa font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi ketika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) untuk menghapus hanya layout yang tidak direferensikan.