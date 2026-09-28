---
title: Terapkan atau Ubah Tata Letak Slide di PHP
linktitle: Tata Letak Slide
type: docs
weight: 60
url: /id/php-java/slide-layout/
keywords:
- tata letak slide
- tata letak konten
- placeholder
- desain presentasi
- desain slide
- tata letak yang tidak digunakan
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
description: "Terapkan, buat, dan modifikasi tata letak slide di Aspose.Slides untuk PHP via Java, tambahkan placeholder, hapus tata letak yang tidak digunakan, dan kontrol visibilitas footer."
---
## **Ringkasan**

Tata letak slide menentukan posisi dan pemformatan placeholder seperti judul, teks, gambar, diagram, dan tabel. Menerapkan tata letak memberikan slide struktur yang konsisten sekaligus memungkinkan setiap slide berisi kontennya sendiri.

Tata letak yang paling umum meliputi:

- **Title Slide**: Berisi placeholder judul dan subtitel.
- **Title and Content**: Berisi placeholder judul dan placeholder konten serbaguna.
- **Blank**: Tidak berisi placeholder konten dan berguna ketika setiap bentuk akan diposisikan secara manual.

## **Memahami Pewarisan Tata Letak**

Sebuah presentasi memiliki tiga tingkatan yang terkait:

1. Sebuah [master slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/) mendefinisikan tema, pemformatan bersama, latar belakang, dan objek umum.
2. Sebuah [layout slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/) berada dalam master dan menentukan susunan placeholder tertentu.
3. Sebuah [normal slide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/) menggunakan satu tata letak dan menyimpan konten yang dimasukkan untuk slide tersebut.

Slide normal mewarisi tema dan pemformatan dari layoutnya, dan layout mewarisi dari masternya. Nilai yang ditetapkan langsung pada slide normal akan menggantikan nilai yang diwarisi pada tingkat tersebut. Saat slide normal dibuat, bentuk placeholdernya dihasilkan dari layout yang dipilih, sementara konten yang dimasukkan ke placeholder tersebut menjadi milik slide normal.

Tambahkan placeholder yang diperlukan ke layout sebelum membuat slide darinya. Menambahkan placeholder lain ke layout kemudian tidak secara otomatis menambah bentuk placeholder yang sesuai ke slide normal yang sudah ada.

Hubungan ini memiliki dua konsekuensi penting:

- Mengubah pemformatan yang diwarisi atau geometri placeholder yang ada pada layout dapat memperbarui semua slide yang bergantung padanya. Sebelum mengedit layout yang sudah digunakan, inspeksi slide yang bergantung padanya dan tinjau presentasi yang dihasilkan.
- Layout yang masih digunakan oleh slide tidak dapat dihapus. Alihkan slide yang bergantung ke layout lain terlebih dahulu, atau hapus hanya layout yang tidak digunakan.

Untuk informasi lebih lanjut tentang tingkat teratas hierarki ini, lihat [Slide Master](/slides/id/php-java/slide-master/).

Untuk menyembunyikan logo yang diwarisi atau bentuk master dekoratif pada satu slide atau melalui layout bersama, lihat [Control the Visibility of Master Graphics](/slides/id/php-java/slide-master/). Contoh ini membandingkan dua slide yang menggunakan master yang sama.

## **Pilih dan Terapkan Tata Letak Slide**

Gunakan tipe layout ketika presentasi mengikuti definisi tata letak PowerPoint standar. Nama layout dapat diedit pengguna dan dapat dilokalisasi, sehingga pemilihan berdasarkan nama kurang dapat diandalkan kecuali Anda mengontrol templat sumber.

Contoh berikut mencari **Title and Content** pada master pertama. Jika layout itu tidak tersedia, secara sengaja beralih ke **Blank**. Pemeriksaan null kedua diperlukan karena sebuah presentasi dapat berisi hanya layout khusus. Layout yang dipilih kemudian diterapkan ke slide normal pertama melalui metode [Slide.setLayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/slide/#setLayoutSlide).

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

Mengubah tata letak slide tidak menghapus bentuk biasa yang ditambahkan langsung ke slide. Namun, posisi placeholder, pemformatan yang diwarisi, dan korespondensi antara placeholder yang ada dengan tata letak baru dapat berubah, sehingga periksa output saat beralih antara layout yang sangat berbeda.

## **Tambahkan Layout Slide**

Pemilihan dan pembuatan adalah operasi terpisah. Contoh sebelumnya memilih layout yang ada; tidak membuat yang baru. Untuk membuat layout, panggil metode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterlayoutslidecollection/#add) pada koleksi layout master target.

Berikut contoh selalu menambahkan layout **Title and Content** baru dengan nama `Report Title and Content`, lalu menambahkan slide normal berdasarkan layout tersebut. Nama layout harus unik dalam koleksi.

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

Tambahkan layout hanya ketika templat memang membutuhkan struktur yang dapat digunakan kembali. Jika layout yang sesuai sudah ada, pilih dan gunakan kembali alih-alih membuat duplikat.

## **Tambah Placeholder ke Layout Slide**

Metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getPlaceholderManager) menyediakan sebuah [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/) untuk menambahkan bentuk placeholder ke sebuah layout.

| Placeholder PowerPoint | Metode `LayoutPlaceholderManager` |
| ----------------------- | --------------------------------- |
| ![Konten](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Konten (Vertikal)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Teks](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Teks (Vertikal)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Gambar](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Diagram](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabel](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Gambar Online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

Contoh berikut memverifikasi bahwa layout **Blank** ada, menambahkan empat placeholder ke dalamnya, dan kemudian membuat slide normal yang menggunakan layout yang dimodifikasi. Urutannya disengaja: placeholder ditambahkan sebelum slide normal dibuat, sehingga Aspose.Slides dapat menghasilkan bentuk placeholder yang sesuai pada slide tersebut.

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

Hasilnya:

![Placeholder pada layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Mengubah pemformatan yang diwarisi atau geometri placeholder layout yang ada dapat memengaruhi slide yang bergantung. Placeholder layout yang baru ditambahkan tidak secara otomatis ditambahkan ke slide normal yang sudah ada. Uji perubahan layout pada salinan presentasi dan inspeksi setiap slide yang bergantung.
{{% /alert %}}

## **Hapus Layout Slide yang Tidak Digunakan**

Gunakan metode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus layout yang tidak direferensikan oleh slide normal mana pun. Metode ini membiarkan layout yang masih digunakan tetap utuh.

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

Untuk menghapus satu layout tertentu, pertama gunakan metode [hasDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#hasDependingSlides) atau [getDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getDependingSlides) miliknya. Alihkan semua slide yang bergantung sebelum memanggil [LayoutSlide.remove](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#remove). Mencoba menghapus layout yang sedang digunakan akan menyebabkan [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/).

## **Kontrol Visibilitas Footer pada Layout Slide**

Layout memiliki footer, nomor slide, dan placeholder tanggal-waktu sendiri. Gunakan metode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) untuk mengontrol placeholder tersebut pada satu layout. Ini berguna ketika, misalnya, layout konten harus menampilkan footer tetapi layout judul tidak.

Contoh berikut memilih layout dengan aman dan membuat elemen footernya terlihat:

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

## **Kontrol Visibilitas Footer pada Master dan Layout Anak‑nya**

Untuk menerapkan pengaturan footer yang konsisten di seluruh hierarki master, gunakan metode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslide/#getHeaderFooterManager). Metode propagasi dari [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslideheaderfootermanager/) beroperasi pada master serta layout slide dan slide normal yang bergantung; mereka tidak menargetkan hanya satu slide normal.

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

**Apa Perbedaan antara Master Slide dan Layout Slide?**

Master slide mendefinisikan tema presentasi dan pemformatan yang dibagikan. Layout slide berada dalam master dan menentukan satu susunan placeholder yang dapat digunakan kembali. Slide normal menggunakan layout tersebut dan menyimpan konten khusus slide.

**Bisakah Saya Menyalin Layout Slide dari Satu Presentasi ke Presentasi Lain?**

Ya. Tambahkan salinan ke koleksi tujuan dengan metode [addClone](https://reference.aspose.com/slides/id/php-java/aspose.slides/globallayoutslidecollection/#addClone). Saat menyalin antar presentasi, juga pastikan font, tema, gambar, dan sumber daya lain yang digunakan oleh layout sumber.

**Apa yang Terjadi Ketika Saya Memodifikasi Layout yang Sudah Digunakan?**

Slide yang bergantung mewarisi perubahan layout kecuali mereka menggantikan pemformatan atau objek yang terpengaruh secara lokal. Geometri placeholder dan gaya yang diwarisi dapat berubah pada banyak slide sekaligus. Gunakan [getDependingSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getDependingSlides) untuk mengidentifikasi slide yang terpengaruh sebelum mengedit layout.

**Apa yang Terjadi Jika Saya Menghapus Layout yang Masih Digunakan?**

Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/). Alihkan slide yang bergantung terlebih dahulu, atau gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) untuk menghapus hanya layout yang tidak direferensikan.