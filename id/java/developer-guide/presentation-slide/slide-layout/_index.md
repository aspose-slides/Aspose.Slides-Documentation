---
title: Terapkan atau Ubah Tata Letak Slide di Java
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/java/slide-layout/
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
- Java
- Aspose.Slides
description: "Terapkan, buat, dan modifikasi tata letak slide dalam Aspose.Slides untuk Java, tambahkan placeholder, hapus tata letak yang tidak terpakai, serta kontrol visibilitas footer."
---
## **Ikhtisar**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sekaligus memungkinkan setiap slide memiliki kontennya sendiri.

Tata letak yang paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subjudul.
- **Title and Content**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak memiliki placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Pahami Pewarisan Tata Letak**

Presentasi memiliki tiga tingkat terkait:

1. A [master slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/) menentukan tema, pemformatan bersama, latar belakang, dan objek umum.
1. A [layout slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/) merupakan bagian dari master dan menentukan susunan placeholder tertentu.
1. A [normal slide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Sebuah normal slide mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan langsung pada normal slide akan menggantikan nilai yang diwarisi pada tingkat tersebut. Ketika normal slide dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik normal slide.

Tambahkan placeholder yang diperlukan ke tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambahkan bentuk placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum menyunting tata letak yang sudah digunakan, periksa slide‑slide yang bergantung padanya dan tinjau presentasi hasilnya.
- Tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan slide‑slide yang bergantung padanya ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak digunakan.

Untuk informasi lebih lanjut tentang tingkat atas hierarki ini, lihat [Slide Master](/slides/id/java/slide-master/).

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama‑nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasar nama kurang dapat diandalkan kecuali Anda mengendalikan templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika tata letak itu tidak tersedia, secara sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [ISlide.setLayoutSlide](https://reference.aspose.com/slides/id/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-).

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

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan kesesuaian antara placeholder yang ada dengan tata letak baru dapat berubah, jadi periksa output saat beralih antara tata letak yang berbeda secara signifikan.

## **Tambahkan Slide Tata Letak**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Title and Content** baru bernama `Report Title and Content`, kemudian menambahkan slide normal yang menggunakannya. Nama tata letak harus unik dalam koleksi.

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

Tambahkan tata letak hanya bila templat memang membutuhkan struktur dapat pakai ulang lain. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali daripada membuat duplikat.

## **Tambahkan Placeholder ke Slide Tata Letak**

Metode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) menyediakan [ILayoutPlaceholderManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah tata letak.

| Placeholder PowerPoint | Metode `ILayoutPlaceholderManager` |
| ---------------------- | ----------------------------------- |
| ![Konten](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Konten (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Teks](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Teks (Vertikal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Gambar](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Tabel](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Gambar Online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

Contoh berikut memverifikasi bahwa tata letak **Blank** ada, menambahkan empat placeholder ke dalamnya, lalu membuat slide normal yang menggunakan tata letak yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

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

![Placeholder pada slide tata letak](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder tata letak yang ada dapat mempengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Slide Tata Letak yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) untuk menghapus tata letak yang tidak dirujuk oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih digunakan tetap utuh.

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

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) atau [getDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) miliknya. Alihkan semua slide yang bergantung sebelum memanggil [ILayoutSlide.remove](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#remove--). Mencoba menghapus tata letak yang masih digunakan akan memunculkan [PptxEditException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Slide Tata Letak**

Sebuah tata letak memiliki footer, nomor slide, dan placeholder tanggal‑waktu sendiri. Gunakan metode [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) untuk mengontrol placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

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

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--). Metode propagasi dari [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/java/com.aspose.slides/imasterslideheaderfootermanager/) beroperasi pada master serta slide tata letak dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

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

**Apa Perbedaan Antara Master Slide dan Layout Slide?**

Sebuah master slide menentukan tema presentasi dan pemformatan bersama. Sebuah layout slide merupakan bagian dari master dan menentukan satu susunan placeholder yang dapat dipakai ulang. Slide normal menggunakan tata letak tersebut dan menyimpan konten spesifik slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan menggunakan metode [addClone](https://reference.aspose.com/slides/id/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-). Saat menyalin antar presentasi, juga verifikasi font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Jika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menggantikan pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) untuk mengidentifikasi slide yang terpengaruh sebelum menyunting layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides melemparkan [PptxEditException](https://reference.aspose.com/slides/id/java/com.aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) untuk menghapus hanya layout yang tidak dirujuk.