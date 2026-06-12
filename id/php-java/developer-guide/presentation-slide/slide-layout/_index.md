---
title: Menerapkan atau Mengubah Tata Letak Slide di PHP
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
description: "Kelola dan sesuaikan tata letak slide di Aspose.Slides untuk PHP via Java. Jelajahi tipe tata letak, kontrol placeholder, dan visibilitas footer melalui contoh kode."
---
## **Pendahuluan**

Tata letak slide menentukan susunan kotak placeholder dan pemformatan untuk konten pada sebuah slide. Tata letak mengontrol placeholder apa saja yang tersedia dan di mana mereka muncul. Tata letak slide membantu Anda merancang presentasi dengan cepat dan konsisten—baik ketika Anda membuat sesuatu yang sederhana maupun yang lebih kompleks. Beberapa tata letak slide yang paling umum di PowerPoint meliputi:

**Tata letak Slide Judul** – Menyertakan dua placeholder teks: satu untuk judul dan satu untuk subjudul.

**Tata letak Judul dan Konten** – Menampilkan placeholder judul yang lebih kecil di bagian atas dan placeholder yang lebih besar di bawahnya untuk konten utama (seperti teks, poin-poin, diagram, gambar, dan lain‑lain).

**Tata letak Kosong** – Tidak berisi placeholder, memberikan Anda kontrol penuh untuk merancang slide dari nol.

Tata letak slide merupakan bagian dari master slide, yaitu slide tingkat atas yang mendefinisikan gaya tata letak untuk seluruh presentasi. Anda dapat mengakses dan memodifikasi slide tata letak melalui master slide—baik berdasarkan tipe, nama, atau ID uniknya. Atau, Anda dapat menyunting tata letak slide tertentu secara langsung dalam presentasi.

Untuk bekerja dengan tata letak slide di Aspose.Slides untuk PHP, Anda dapat menggunakan:

- Metode seperti [getLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getLayoutSlides) dan [getMasters](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getMasters) pada kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/)
- Tipe seperti [LayoutSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/), dan [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Untuk mempelajari lebih lanjut tentang penggunaan master slide, lihat artikel [Slide Master](/slides/id/php-java/slide-master/).

{{% /alert %}}

## **Menambahkan Tata Letak Slide ke Presentasi**

Untuk menyesuaikan tampilan dan struktur slide Anda, mungkin Anda perlu menambahkan slide tata letak baru ke sebuah presentasi. Aspose.Slides untuk PHP memungkinkan Anda memeriksa apakah sebuah tata letak tertentu sudah ada, menambahkannya jika diperlukan, dan menggunakannya untuk menyisipkan slide berdasarkan tata letak tersebut.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Akses [MasterLayoutSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/masterlayoutslidecollection/).
1. Periksa apakah slide tata letak yang diinginkan sudah ada dalam koleksi. Jika belum, tambahkan slide tata letak yang diperlukan.
1. Tambahkan slide kosong berdasarkan tata letak baru.
1. Simpan presentasi.

Kode PHP berikut menunjukkan cara menambahkan tata letak slide ke presentasi PowerPoint:

```php
// Instansiasi kelas Presentation yang mewakili file PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Lalui tipe slide tata letak untuk memilih slide tata letak.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Situasi di mana presentasi tidak berisi semua tipe tata letak.
        // File presentasi hanya berisi tipe tata letak Blank dan Custom.
        // Namun, slide tata letak dengan tipe kustom mungkin memiliki nama yang dapat dikenali,
        // seperti "Title", "Title and Content", dll., yang dapat digunakan untuk pemilihan slide tata letak.
        // Anda juga dapat mengandalkan sekumpulan tipe bentuk placeholder.
        // Sebagai contoh, slide Judul seharusnya hanya memiliki tipe placeholder Title, dan seterusnya.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Tambahkan slide kosong menggunakan slide tata letak yang telah ditambahkan.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Simpan presentasi ke disk.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menghapus Slide Tata Letak yang Tidak Digunakan**

Aspose.Slides menyediakan metode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) dari kelas [Compress](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/) untuk memungkinkan Anda menghapus slide tata letak yang tidak diinginkan dan tidak terpakai.

Kode PHP berikut memperlihatkan cara menghapus slide tata letak dari presentasi PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menambahkan Placeholder ke Tata Letak Slide**

Aspose.Slides menyediakan metode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutslide/#getPlaceholderManager) yang memungkinkan Anda menambahkan placeholder baru ke sebuah slide tata letak.

Manajer ini berisi metode untuk tipe placeholder berikut:

| Placeholder PowerPoint              | Metode [LayoutPlaceholderManager](https://reference.aspose.com/slides/id/php-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | addContentPlaceholder(float x,float y,float width,float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x,float y,float width,float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x,float y,float width,float height) |
| ![Text (Vertical)](textV.png)       | addVerticalTextPlaceholder(float x,float y,float width,float height) |
| ![Picture](picture.png)             | addPicturePlaceholder(float x,float y,float width,float height) |
| ![Chart](chart.png)                 | addChartPlaceholder(float x,float y,float width,float height) |
| ![Table](table.png)                 | addTablePlaceholder(float x,float y,float width,float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x,float y,float width,float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x,float y,float width,float height) |
| ![Online Image](onlineimage.png)    | addOnlineImagePlaceholder(float x,float y,float width,float height) |

Kode PHP berikut menunjukkan cara menambahkan bentuk placeholder baru ke slide tata letak Blank:

```php
$presentation = new Presentation();
try {
    // Dapatkan slide tata letak Blank.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Dapatkan manajer placeholder dari slide tata letak.
    $placeholderManager = $layout->getPlaceholderManager();

    // Tambahkan berbagai placeholder ke slide tata letak Blank.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Tambahkan slide baru dengan tata letak Blank.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![The placeholders on the layout slide](add_placeholders.png)

## **Mengatur Visibilitas Footer untuk Slide Tata Letak**

Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat ditampilkan atau disembunyikan tergantung pada tata letak slide. Aspose.Slides untuk PHP memungkinkan Anda mengontrol visibilitas placeholder footer ini. Hal ini berguna ketika Anda ingin beberapa tata letak menampilkan informasi footer sementara yang lain tetap bersih dan minimal.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi slide tata letak berdasarkan indeksnya.
1. Atur placeholder footer slide agar terlihat.
1. Atur placeholder nomor slide agar terlihat.
1. Atur placeholder tanggal‑waktu agar terlihat.
1. Simpan presentasi.

Kode PHP berikut memperlihatkan cara mengatur visibilitas footer slide dan melakukan tugas terkait:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Mengatur Visibilitas Footer Anak untuk Slide**

​Dalam presentasi PowerPoint, elemen footer seperti tanggal, nomor slide, dan teks khusus dapat dikontrol pada tingkat master slide untuk memastikan konsistensi di semua slide tata letak. Aspose.Slides untuk PHP memungkinkan Anda mengatur visibilitas dan isi placeholder footer pada master slide dan menyebarkan pengaturan ini ke semua slide tata letak anak. Pendekatan ini memastikan informasi footer yang seragam di seluruh presentasi.​

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).
1. Dapatkan referensi ke master slide berdasarkan indeksnya.
1. Atur semua placeholder footer master dan anak agar terlihat.
1. Atur semua placeholder nomor slide master dan anak agar terlihat.
1. Atur semua placeholder tanggal‑waktu master dan anak agar terlihat.
1. Simpan presentasi.

Kode PHP berikut mendemonstrasikan operasi tersebut:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Apa perbedaan antara master slide dan layout slide?**

Master slide mendefinisikan tema keseluruhan dan pemformatan default, sementara layout slide menentukan susunan placeholder spesifik untuk berbagai jenis konten.

**Apakah saya dapat menyalin layout slide dari satu presentasi ke presentasi lain?**

Ya, Anda dapat mengkloning layout slide dari koleksi layout slide sebuah presentasi, yang dapat diakses melalui metode [getLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getLayoutSlides), dan menyisipkannya ke presentasi lain dengan metode `addClone`.

**Apa yang terjadi jika saya menghapus layout slide yang masih digunakan oleh sebuah slide?**

Jika Anda mencoba menghapus layout slide yang masih direferensikan oleh setidaknya satu slide dalam presentasi, Aspose.Slides akan melempar [PptxEditException](https://reference.aspose.com/slides/id/php-java/aspose.slides/pptxeditexception/). Untuk menghindarinya, gunakan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) yang secara aman menghapus hanya tata letak slide yang tidak sedang dipakai.