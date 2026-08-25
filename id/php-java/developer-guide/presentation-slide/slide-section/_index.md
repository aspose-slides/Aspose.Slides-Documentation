---
title: Kelola Bagian Slide dalam Presentasi dengan PHP
linktitle: Bagian Slide
type: docs
weight: 90
url: /id/php-java/slide-section/
keywords:
- buat bagian
- tambahkan bagian
- edit bagian
- ubah bagian
- nama bagian
- ambil slide bagian
- proses slide bagian
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Kelola bagian slide dengan Aspose.Slides untuk PHP via Java: buat, ganti nama, ubah urutan, ambil, dan proses slide bagian dalam presentasi PPTX."
---
## **Pendahuluan**

Bagian mengatur slide berurutan menjadi grup bernama tanpa mengubah konten slide. Dengan Aspose.Slides untuk PHP via Java, Anda dapat membuat, mengubah urutan, mengganti nama, memeriksa, dan menghapus bagian melalui metode [Presentation::getSections](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSections).

Bagian sangat berguna ketika:

- presentasi besar perlu dibagi menjadi topik atau bab logis;
- kelompok slide yang berbeda ditugaskan ke kolaborator yang berbeda;
- slide perlu diproses, dipindahkan, atau digabungkan sebagai grup.

Pilih nama bagian yang singkat dan menggambarkan tujuan slide yang dikelompokkan. Karena bagian merupakan bagian dari struktur presentasi, gunakan API bagian untuk menentukan keanggotaan alih-alih menurunkannya dari posisi slide.

## **Buat dan Kelola Bagian**

Gunakan [SectionCollection::addSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/#addSection) untuk membuat sebuah bagian dengan menentukan namanya dan slide awal. Aspose.Slides menentukan slide mana yang termasuk dalam bagian dari struktur bagian presentasi saat ini.

[SectionCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/) yang sama juga memungkinkan Anda:

- memindahkan sebuah bagian bersama slide-nya dengan menggunakan [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides);
- menghapus hanya definisi bagian dengan [SectionCollection::removeSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/#removeSection), yang mempertahankan slide-nya;
- menghapus sebuah bagian beserta slide-nya dengan [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides);
- menambahkan bagian kosong di akhir dengan [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/#appendEmptySection).

Contoh berikut membuat dua bagian, memindahkan salah satunya, menghapusnya bersama slide-nya, dan menambahkan bagian kosong:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

Setelah operasi ini, presentasi berisi bagian `Introduction` dengan slide-nya dan bagian `Appendix` kosong. Bagian `Results` dan slide-nya telah dihapus.

## **Ganti Nama Bagian**

Untuk mengganti nama sebuah bagian, panggil metode [Section::setName](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#setName). Slide dan posisi bagian tetap tidak berubah.

Contoh berikut membuat sebuah bagian dan mengubah namanya:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **Dapatkan Slide dari Bagian**

Metode [Presentation::getSections](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSections) mengembalikan sebuah [SectionCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/) yang dapat Anda proses berdasarkan indeks. Untuk setiap [Section](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/), panggil [Section::getSlidesListOfSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getSlidesListOfSection) untuk memperoleh slide yang saat ini termasuk di dalamnya. Metode ini mengembalikan sebuah [SectionSlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionSlideCollection/), yang menyediakan jumlah dan akses berdasarkan indeks.

Contoh berikut membuat dua bagian terisi dan satu bagian kosong, kemudian mencetak setiap [nama](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getName), [identifier](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getSectionId), [slide awal](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getStartedFromSlide), jumlah slide, dan nomor slide untuk setiap bagian. Ia menggunakan [SectionCollection::get_Item](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionCollection/#get_Item) dan [SectionSlideCollection::get_Item](https://reference.aspose.com/slides/id/php-java/aspose.slides/SectionSlideCollection/#get_Item) untuk akses berindeks. Untuk bagian kosong, koleksi yang dikembalikan berukuran nol dan `get_Item` tidak dipanggil.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Keanggotaan bagian ditentukan oleh struktur bagian presentasi. Jangan menghitung rentang bagian secara manual dari [Section::getStartedFromSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getStartedFromSlide), indeks slide, dan slide awal bagian berikutnya.

Suntingan struktural dapat mengubah baik slide yang dikembalikan untuk sebuah bagian maupun nomor slide mereka. Ini termasuk mengubah urutan slide, mengkloning slide ke dalam sebuah bagian, memindahkan sebuah bagian bersama slide-nya, menghapus slide, dan menghapus bagian. Contoh berikut memanggil [Section::getSlidesListOfSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getSlidesListOfSection) setelah setiap perubahan tersebut alih-alih mempertahankan asumsi tentang batas sebelumnya.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

Panggil kembali [Section::getSlidesListOfSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getSlidesListOfSection) setiap kali slide atau bagian diubah urutannya, dikloning, dipindahkan, atau dihapus. Ini menjaga pemrosesan selanjutnya selaras dengan struktur presentasi saat ini.

Format PPT (PowerPoint 97–2003) tidak mempertahankan metadata bagian. Gunakan alur kerja ini dengan format yang mendukung bagian, seperti PPTX; mengonversi ke PPT menghapus struktur bagian yang diperlukan untuk iterasi selanjutnya.

## **FAQ**

**Apakah bagian dipertahankan saat menyimpan ke format PPT (PowerPoint 97–2003)?**

Tidak. Format PPT tidak mendukung metadata bagian, sehingga pengelompokan bagian hilang saat disimpan ke .ppt.

**Apakah seluruh bagian dapat "disembunyikan"?**

Tidak. Sebuah bagian tidak memiliki status visibilitas. Untuk menyembunyikan isinya, panggil [Slide::setHidden](https://reference.aspose.com/slides/id/php-java/aspose.slides/Slide/#setHidden) untuk setiap slide dalam bagian tersebut.

**Bagaimana saya dapat menemukan bagian yang berisi sebuah slide?**

Loop melalui koleksi yang dikembalikan oleh [Presentation::getSections](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation/#getSections), panggil [Section::getSlidesListOfSection](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getSlidesListOfSection) untuk setiap bagian, dan bandingkan slide yang dikembalikan dengan slide target. Untuk bagian yang tidak kosong, [Section::getStartedFromSlide](https://reference.aspose.com/slides/id/php-java/aspose.slides/Section/#getStartedFromSlide) mengembalikan slide pertamanya; untuk bagian kosong, ia mengembalikan `null`.