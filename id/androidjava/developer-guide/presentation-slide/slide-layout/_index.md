---
title: Terapkan atau Ubah Tata Letak Slide pada Android
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/androidjava/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak yang tidak terpakai
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
- Android
- Java
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi tata letak slide di Aspose.Slides untuk Android via Java, tambahkan placeholder, hapus tata letak yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sekaligus memungkinkan setiap slide berisi kontennya sendiri.

Tata letak yang paling umum meliputi:

- **Slide Judul**: Memiliki placeholder judul dan subjudul.
- **Judul dan Konten**: Memiliki placeholder judul dan placeholder konten serbaguna.
- **Kosong**: Tidak memiliki placeholder konten dan berguna ketika setiap bentuk akan ditempatkan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkatan terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
1. Sebuah [layout slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/) merupakan bagian dari master dan menentukan susunan placeholder tertentu.
1. Sebuah [normal slide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan langsung pada normal slide menimpa nilai yang diwarisi pada tingkat tersebut. Ketika sebuah normal slide dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambah bentuk placeholder yang bersesuaian pada slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah digunakan, periksa slide yang bergantung dan tinjau hasil presentasi.
- Tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan slide yang bergantung ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak terpakai.

Untuk informasi lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/androidjava/slide-master/).

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan jenis tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama tata letak dapat diedit oleh pengguna dan dapat dilokalisasi, sehingga pemilihan berbasis nama kurang dapat diandalkan kecuali Anda mengendalikan templat sumber.

Contoh berikut mencari **Judul dan Konten** pada master pertama. Jika tata letak itu tidak tersedia, secara sengaja beralih ke **Kosong**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [ISlide.setLayoutSlide](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) .

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

Mengubah tata letak sebuah slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan korespondensi antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa output saat beralih antara tata letak yang sangat berbeda.

## **Tambahkan Tata Letak Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Judul dan Konten** baru bernama `Report Title and Content`, kemudian menambahkan slide normal yang berdasar padanya. Nama tata letak harus unik dalam koleksi.

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

Tambahkan tata letak hanya ketika templat memang membutuhkan struktur dapat pakai kembali lain. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali alih-alih membuat duplikat.

## **Tambahkan Placeholder ke Tata Letak Slide**

Metode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) menyediakan sebuah [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) untuk menambah bentuk placeholder ke tata letak.

| Placeholder PowerPoint             | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Konten](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Konten (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Teks](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Teks (Vertikal)](textV.png)      | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Gambar](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabel](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Gambar Online](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Contoh berikut memverifikasi bahwa tata letak **Kosong** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang menggunakan tata letak yang telah dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang bersesuaian pada slide tersebut.

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

![Placeholder pada tata letak slide](add_placeholders.png)

{{% alert color="warning" title="Peringatan" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder tata letak yang ada dapat memengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Tata Letak Slide yang Tidak Terpakai**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) untuk menghapus tata letak yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih dipakai tetap utuh.

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

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) atau [getDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) miliknya. Alihkan slide yang bergantung sebelum memanggil [ILayoutSlide.remove](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#remove--). Mencoba menghapus tata letak yang masih dipakai akan memunculkan [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Tata Letak Slide**

Sebuah tata letak memiliki footer, nomor slide, dan placeholder tanggal‑waktu masing‑masing. Gunakan metode [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) untuk mengatur placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak secara aman dan membuat elemen footernya terlihat:

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

## **Kontrol Visibilitas Footer pada Master dan Tata Letak Turunannya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) . Metode propagasi pada [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) beroperasi pada master serta slide tata letak dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

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

## **Tanya Jawab**

**Apa Perbedaan antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema dan pemformatan bersama presentasi. Layout slide merupakan bagian dari master dan menentukan satu susunan placeholder yang dapat dipakai kembali. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Saat menyalin antar presentasi, periksa juga font, tema, gambar, dan sumber daya lain yang digunakan oleh tata letak sumber.

**Apa yang Terjadi ketika Saya Memodifikasi Tata Letak yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan tata letak kecuali mereka menimpa pemformatan atau objek yang bersangkutan secara lokal. Geometri placeholder dan gaya yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit tata letak.

**Apa yang Terjadi Jika Saya Menghapus Tata Letak yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) untuk menghapus hanya tata letak yang tidak direferensikan.