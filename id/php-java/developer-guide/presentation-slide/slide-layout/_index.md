---
title: "Terapkan atau Ubah Tata Letak Slide di PHP"
linktitle: "Tata Letak Slide"
type: docs
weight: 60
url: /id/php-java/slide-layout/
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
- PHP
- Aspose.Slides
description: "Terapkan, buat, dan ubah tata letak slide di Aspose.Slides untuk PHP melalui Java, tambahkan placeholder, hapus tata letak yang tidak terpakai, dan kontrol visibilitas footer."
---
## **Gambaran Umum**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberi slide struktur yang konsisten sekaligus memungkinkan setiap slide memiliki kontennya sendiri.

Tata letak yang paling umum meliputi:

- **Slide Judul**: Berisi placeholder judul dan subjudul.
- **Judul dan Konten**: Berisi placeholder judul dan placeholder konten umum.
- **Kosong**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan ditempatkan secara manual.

## **Pahami Pewarisan Tata Letak**

Presentasi memiliki tiga tingkatan terkait:

1. Sebuah [slide master](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
2. Sebuah [slide tata letak](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/) termasuk dalam master dan mendefinisikan susunan khusus placeholder.
3. Sebuah [slide normal](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Slide normal mewarisi tema dan pemformatan dari tata letaknya, dan tata letak mewarisi dari masternya. Nilai yang ditetapkan secara langsung pada slide normal akan menggantikan nilai yang diwariskan pada tingkat tersebut. Ketika slide normal dibuat, bentuk placeholder‑nya dihasilkan dari tata letak yang dipilih, sementara konten yang dimasukkan ke dalam placeholder tersebut menjadi milik slide normal.

Tambahkan placeholder yang diperlukan ke sebuah tata letak sebelum membuat slide darinya. Menambahkan placeholder lain ke tata letak kemudian tidak secara otomatis menambahkan bentuk placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwariskan atau geometri placeholder yang ada pada tata letak dapat memperbarui setiap slide yang bergantung padanya. Sebelum mengedit tata letak yang sudah digunakan, periksa slide yang bergantung padanya dan tinjau presentasi yang dihasilkan.
- Tata letak yang masih digunakan oleh sebuah slide tidak dapat dihapus. Alihkan slide yang bergantung padanya ke tata letak lain terlebih dahulu, atau hapus hanya tata letak yang tidak terpakai.

Untuk informasi lebih lanjut tentang tingkat teratas hierarki ini, lihat [Slide Master](/slides/id/php-java/slide-master/).

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe tata letak ketika presentasi mengikuti definisi tata letak standar PowerPoint. Nama tata letak dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang dapat diandalkan kecuali Anda mengendalikan templat sumber.

Contoh berikut mencari **Judul dan Konten** pada master pertama. Jika tata letak tersebut tidak tersedia, secara sengaja beralih ke **Kosong**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya tata letak khusus. Tata letak yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [Slide.setLayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#setLayoutSlide) .

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwariskan, dan kesesuaian antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa hasilnya saat beralih antara tata letak yang secara signifikan berbeda.

## **Tambahkan Slide Tata Letak**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih tata letak yang sudah ada; tidak membuat yang baru. Untuk membuat tata letak, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterlayoutslidecollection/#add) pada koleksi tata letak master target.

Contoh berikut selalu menambahkan tata letak **Judul dan Konten** baru dengan nama `Report Title and Content`, lalu menambahkan slide normal yang berdasarkan tata letak itu. Nama tata letak harus unik dalam koleksi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tambahkan tata letak hanya ketika templat memang membutuhkan struktur dapat pakai ulang lain. Jika tata letak yang cocok sudah ada, pilih dan gunakan kembali daripada membuat duplikat.

## **Tambahkan Placeholder ke Slide Tata Letak**

Metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getPlaceholderManager) menyediakan sebuah [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah tata letak.

| Placeholder PowerPoint              | Metode `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------- |
| ![Konten](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Konten (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Teks](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Teks (Vertikal)](textV.png)      | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Gambar](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png)               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Gambar Online](onlineImage.png)  | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Contoh berikut memverifikasi bahwa tata letak **Kosong** ada, menambahkan empat placeholder ke dalamnya, dan kemudian membuat slide normal yang menggunakan tata letak yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasil:

![Placeholder pada slide tata letak](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwariskan atau geometri placeholder tata letak yang ada dapat memengaruhi slide yang bergantung. Placeholder tata letak yang baru ditambahkan tidak secara otomatis dimasukkan ke slide normal yang sudah ada. Uji perubahan tata letak pada salinan presentasi dan periksa setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Slide Tata Letak yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus tata letak yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan tata letak yang masih digunakan tetap tidak berubah.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Untuk menghapus satu tata letak tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#hasDependingSlides) atau [getDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getDependingSlides) miliknya. Alihkan slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#remove). Mencoba menghapus tata letak yang masih digunakan akan menghasilkan [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Slide Tata Letak**

Sebuah tata letak memiliki footer, placeholder nomor slide, dan tanggal‑waktu sendiri. Gunakan metode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) untuk mengontrol placeholder tersebut pada satu tata letak. Ini berguna ketika, misalnya, tata letak konten harus menampilkan footer tetapi tata letak judul tidak.

Contoh berikut memilih tata letak dengan aman dan membuat elemen footernya terlihat:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kontrol Visibilitas Footer pada Master dan Tata Letak Anaknya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Metode propagasi dari [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslideheaderfootermanager/) beroperasi pada master serta slide tata letak dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apa Perbedaan antara Slide Master dan Slide Tata Letak?**

Slide master mendefinisikan tema dan pemformatan bersama presentasi. Slide tata letak termasuk dalam master dan mendefinisikan satu susunan placeholder yang dapat dipakai ulang. Slide normal menggunakan tata letak tersebut dan menyimpan konten khusus slide.

**Bisakah Saya Menyalin Slide Tata Letak dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/globallayoutslidecollection/#addClone). Saat menyalin antar presentasi, periksa juga font, tema, gambar, dan sumber daya lain yang digunakan oleh tata letak sumber.

**Apa yang Terjadi Ketika Saya Memodifikasi Tata Letak yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan tata letak kecuali mereka menimpa pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwariskan dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getDependingSlides) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit tata letak.

**Apa yang Terjadi Jika Saya Menghapus Tata Letak yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus hanya tata letak yang tidak direferensikan.