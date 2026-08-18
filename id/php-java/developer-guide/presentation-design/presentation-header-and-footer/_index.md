---
title: Kelola Header dan Footer Presentasi dalam PHP
linktitle: Header dan Footer
type: docs
weight: 140
url: /id/php-java/presentation-header-and-footer/
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
- PHP
- Aspose.Slides
description: "Pelajari cara mengelola placeholder footer, tanggal-waktu, nomor slide, dan header pada slide, halaman catatan, dan handout dengan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

PowerPoint menggunakan placeholder header dan footer yang berbeda tergantung pada jenis halaman. Aspose.Slides untuk PHP via Java memungkinkan Anda mengontrol teks dan visibilitas placeholder ini melalui kelas pengelola header/footer.

Placeholder yang tersedia bergantung pada ruang lingkup:

| Ruang lingkup | Header | Footer | Tanggal/waktu | Nomor slide/halaman |
|---|---|---|---|---|
| Slide reguler | Tidak | Ya | Ya | Ya |
| Master catatan | Ya | Ya | Ya | Ya |
| Slide catatan | Ya | Ya | Ya | Ya |
| Master lembar kerja | Ya | Ya | Ya | Ya |

Sebuah slide presentasi reguler tidak memiliki placeholder header. Header tersedia pada halaman catatan dan lembar kerja. Untuk slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide sebagai gantinya.

Ruang lingkup perubahan tergantung pada pengelola yang Anda gunakan. Kelas [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideheaderfootermanager/) mengontrol satu slide reguler. Kelas [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/notesslideheaderfootermanager/) mengontrol satu slide catatan. Pengelola master dan tata letak juga dapat menyebarkan pengaturan ke slide yang bergantung, sementara kelas [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) mengontrol master lembar kerja.

## **Menetapkan Footer, Tanggal/Waktu, dan Nomor Slide pada Slide Reguler**

Untuk slide reguler, alur kerja dasar adalah mengakses pengelola header/footer masing‑masing slide, menetapkan teks footer dan tanggal/waktu, mengaktifkan placeholder yang diperlukan, dan menyimpan presentasi. Nomor slide dihasilkan oleh presentasi, jadi Anda hanya perlu mengontrol visibilitasnya.

Gunakan [`setFooterText`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/setfootertext/) dan [`setDateTimeText`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) untuk menetapkan teks, serta [`setFooterVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`setDateTimeVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/), dan [`setSlideNumberVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) untuk menampilkan placeholder yang sesuai.

Contoh end‑to‑end berikut menerapkan footer, teks tanggal/waktu, dan visibilitas nomor slide yang sama pada semua slide reguler:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getSlides() as $slide) {
        $headerFooterManager = $slide->getHeaderFooterManager();

        $headerFooterManager->setFooterText("Company Confidential");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_slide_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika Anda hanya perlu memperbarui satu slide, akses slide tersebut secara langsung melalui metode [`getSlides`](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/getslides/) alih‑alih mengiterasi seluruh koleksi.

## **Menetapkan Header dan Footer pada Master Catatan**

Master catatan menentukan pemformatan umum dan perilaku placeholder untuk halaman catatan. Gunakan kelas [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/) ketika Anda ingin mengubah hanya master catatan itu sendiri.

Contoh berikut menetapkan header, footer, dan teks tanggal/waktu pada master catatan serta membuat semua placeholder yang didukung terlihat pada master tersebut:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Notes header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Notes footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metode [`getMasterNotesSlide`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslidemanager/getmasternotesslide/) mengembalikan `null` ketika presentasi tidak berisi master catatan.

## **Menerapkan Pengaturan Master Catatan ke Slide Catatan Anak**

Master catatan dapat menerapkan pengaturan header dan footer pada dirinya sendiri dan semua slide catatan yang bergantung. Gunakan metode propagasi khusus pada [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/) ketika pengaturan yang sama harus diterapkan di seluruh hierarki catatan.

Sebagai contoh, [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) dan [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) memperbarui header master catatan dan semua header anak. Metode setara tersedia untuk footer, tanggal/waktu, dan nomor slide.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterNotesSlide = $presentation->getMasterNotesSlideManager()->getMasterNotesSlide();

    if (!java_is_null($masterNotesSlide)) {
        $headerFooterManager = $masterNotesSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderAndChildHeadersText("Notes header");
        $headerFooterManager->setHeaderAndChildHeadersVisibility(true);

        $headerFooterManager->setFooterAndChildFootersText("Notes footer");
        $headerFooterManager->setFooterAndChildFootersVisibility(true);

        $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");
        $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

        $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    $presentation->save("presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Metode propagasi yang digunakan di atas meliputi [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), dan [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Menetapkan Header dan Footer pada Slide Catatan Individual**

Sebuah slide catatan terkait dengan slide reguler tertentu. Gunakan kelas [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/notesslideheaderfootermanager/) ketika Anda ingin menyesuaikan hanya halaman catatan tersebut.

Metode [`addNotesSlide`](https://reference.aspose.com/slides/id/php-java/aspose.slides/notesslidemanager/addnotesslide/) mengembalikan slide catatan untuk slide saat ini dan membuatnya jika belum ada. Contoh berikut mengonfigurasi halaman catatan yang terkait dengan slide presentasi pertama:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
    $headerFooterManager = $notesSlide->getHeaderFooterManager();

    $headerFooterManager->setHeaderText("Header for the first notes page");
    $headerFooterManager->setHeaderVisibility(true);

    $headerFooterManager->setFooterText("Footer for the first notes page");
    $headerFooterManager->setFooterVisibility(true);

    $headerFooterManager->setDateTimeText("Date and time text");
    $headerFooterManager->setDateTimeVisibility(true);

    $headerFooterManager->setSlideNumberVisibility(true);

    $presentation->save("presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jika Anda pertama‑tama menyebarkan pengaturan dari master catatan kemudian mengubah slide catatan individual, pengaturan per‑slide selanjutnya memungkinkan Anda menyesuaikan halaman catatan tersebut secara independen.

## **Menetapkan Header dan Footer pada Master Lembar Kerja**

Halaman lembar kerja menggunakan master lembar kerja untuk placeholder header, footer, tanggal/waktu, dan nomor halaman. Berbeda dengan halaman catatan, pengaturan lembar kerja dikelola melalui master lembar kerja, bukan melalui slide lembar kerja individu.

Gunakan metode [`getMasterHandoutSlide`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterhandoutslidemanager/getmasterhandoutslide/) untuk mengakses master lembar kerja. Jika tidak ada, panggil [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterhandoutslidemanager/setdefaultmasterhandoutslide/) untuk membuat master lembar kerja default.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide();

    if (java_is_null($masterHandoutSlide)) {
        $masterHandoutSlide = $presentation->getMasterHandoutSlideManager()->setDefaultMasterHandoutSlide();
    }

    if (!java_is_null($masterHandoutSlide)) {
        $headerFooterManager = $masterHandoutSlide->getHeaderFooterManager();

        $headerFooterManager->setHeaderText("Handout header");
        $headerFooterManager->setHeaderVisibility(true);

        $headerFooterManager->setFooterText("Handout footer");
        $headerFooterManager->setFooterVisibility(true);

        $headerFooterManager->setDateTimeText("Date and time text");
        $headerFooterManager->setDateTimeVisibility(true);

        $headerFooterManager->setSlideNumberVisibility(true);
    }

    $presentation->save("presentation_with_handout_footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Memahami Ruang Lingkup dan Pewarisan**

Pilih pengelola header/footer yang sesuai dengan ruang lingkup yang ingin Anda ubah:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideheaderfootermanager/) mengubah pengaturan footer, tanggal/waktu, dan nomor slide untuk satu slide reguler.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslideheaderfootermanager/) mengontrol slide tata letak dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterslideheaderfootermanager/) mengontrol master slide reguler dan dapat menyebarkan pengaturan yang didukung ke slide yang bergantung.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masternotesslideheaderfootermanager/) mengontrol master catatan dan dapat menyebarkan pengaturan ke semua slide catatan yang bergantung.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/notesslideheaderfootermanager/) mengubah satu slide catatan dan mendukung placeholder header selain footer, tanggal/waktu, dan nomor slide.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterhandoutslideheaderfootermanager/) mengubah master lembar kerja dan mendukung keempat jenis placeholder.

Gunakan propagasi dari master atau tata letak ketika pengaturan yang sama harus berlaku di seluruh hierarki. Gunakan pengelola slide individual atau slide‑catatan ketika Anda memerlukan pengaturan lokal untuk satu halaman.

## **FAQ**

**Apakah saya dapat menambahkan header pada slide reguler?**

Tidak. PowerPoint tidak mendefinisikan placeholder header untuk slide reguler. Pada slide reguler, gunakan placeholder footer, tanggal/waktu, dan nomor slide. Placeholder header tersedia pada halaman catatan dan lembar kerja.

**Bagaimana jika placeholder footer, tanggal/waktu, atau nomor slide tidak terlihat?**

Gunakan pengelola header/footer yang bersangkutan untuk memeriksa visibilitasnya dan aktifkan bila diperlukan. Misalnya, [`isFooterVisible`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/isfootervisible/) melaporkan apakah placeholder footer ada, dan [`setFooterVisibility`](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) mengubah visibilitasnya.

**Bagaimana cara memulai penomoran slide dari nilai selain 1?**

Panggil metode [`setFirstSlideNumber`](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/setfirstslidenumber/) pada presentasi. Placeholder nomor slide kemudian menggunakan urutan penomoran yang diperbarui.

**Apa yang terjadi pada header dan footer saat mengekspor ke PDF, gambar, atau HTML?**

Elemen header dan footer yang terlihat dirender bersama konten presentasi lain dalam format output. Penampilannya tergantung pada jenis halaman yang diekspor dan pengaturan visibilitas placeholder yang bersangkutan.