---
title: Otomatisasi Lokalisasi Presentasi dalam PHP
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/php-java/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- menekan pemeriksaan ejaan
- bahasa pemeriksaan
- id bahasa
- teks multibahasa
- PowerPoint
- presentasi
- PHP
- Aspose.Slides
description: "Atur bahasa pemeriksaan untuk teks presentasi PowerPoint dan OpenDocument dalam PHP dengan Aspose.Slides, termasuk nilai default dan paragraf multibahasa."
---
## **Gambaran Umum**

Aspose.Slides for PHP via Java memungkinkan Anda mengonfigurasi metadata pemeriksaan ejaan untuk bagian teks individu. Gunakan [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) untuk mengidentifikasi bahasa pemeriksaan ejaan, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setSpellCheck) untuk mengizinkan atau menekan pemeriksaan ejaan, dan [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setProofDisabled) untuk mengontrol keadaan tidak‑pemeriksaan yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi banyak bahasa dan aturan pemeriksaan ejaan yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa untuk teks tertentu, mengatur bahasa default untuk teks baru dengan [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), membangun paragraf multibahasa, memilih antara `SpellCheck` dan `ProofDisabled`, serta mempertahankan pengaturan yang dimaksud ketika menggunakan [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Menetapkan Bahasa Pemeriksaan Ejaan untuk Teks**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [Portion::getPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getPortionFormat), dan tetapkan pengidentifikasi bahasanya. Contoh berikut membuat sebuah shape, mengatur bahasa Inggris Britania sebagai bahasa pemeriksaan ejaan, dan menyimpan hasilnya dengan [Presentation::save](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengatur Bahasa Default untuk Teks Baru**

Gunakan [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) untuk menentukan bahasa pemeriksaan ejaan yang akan ditetapkan Aspose.Slides pada teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau seluruh teks baru dalam presentasi menggunakan bahasa yang sama. Pengaturan ini tidak mengubah metadata bahasa pada teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi dimana teks baru menggunakan aturan ejaan Jerman:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Menggunakan Beberapa Bahasa dalam Satu Paragraf**

Sebuah [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/) berisi koleksi bagian teks. Buat [Portion](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/) terpisah untuk setiap bahasa dan tetapkan `LanguageId`-nya secara independen.

Contoh ini membuat satu paragraf dengan bagian bahasa Inggris dan Prancis:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Mengaktifkan atau Menekan Pemeriksaan Ejaan untuk Bagian Individual**

[PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/) mewarisi properti teks umum yang didefinisikan oleh [BasePortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/). Akses format bagian melalui [Portion::getPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portion/#getPortionFormat) dan gunakan [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setSpellCheck) untuk mengontrol apakah aplikasi presentasi boleh memeriksa ejaan untuk bagian tersebut. Nilai default adalah `false`: `true` mengizinkan pemeriksaan ejaan, sedangkan `false` menekannya.

Pengaturan ini berlaku untuk bagian teks individual. Bagian yang berbeda dalam paragraf yang sama dapat menggunakan nilai yang berbeda. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) dan `setSpellCheck` melayani tujuan yang saling melengkapi: `setLanguageId` mengidentifikasi bahasa pemeriksaan, sementara `setSpellCheck` menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setProofDisabled) juga mengontrol pemeriksaan ejaan, tetapi mewakili keadaan “tidak periksa” yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/php-java/aspose.slides/nullablebool/). Gunakan `setSpellCheck` ketika Anda membutuhkan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan `setProofDisabled` ketika Anda perlu mempertahankan atau secara eksplisit mengontrol metadata tidak‑pemeriksaan presentasi, termasuk keadaan `NotDefined`‑nya. Jika Anda mengatur kedua properti, jaga konsistensi nilainya; jangan menggabungkan `setSpellCheck(true)` dengan `setProofDisabled(NullableBool::True)`.

Properti ini mengonfigurasi metadata pemeriksaan ejaan yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan mereka untuk menjalankan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat presentasi masuk, memuatnya, menetapkan pengaturan pemeriksaan ejaan dan bahasa pemeriksaan yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membukanya kembali, dan memverifikasi nilai yang disimpan:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) menggabungkan bagian yang bersebelahan yang memiliki format sama. Perbedaan pada `SpellCheck` saja tidak akan mempertahankan bagian tersebut terpisah; setelah digabung, bagian yang dihasilkan mempertahankan nilai `SpellCheck` dari bagian pertama. Jika bagian memerlukan pengaturan pemeriksaan ejaan yang berbeda, panggil `joinPortionsWithSameFormatting` sebelum menetapkan pengaturan tersebut, atau inspeksi batas bagian yang dihasilkan dan terapkan kembali pengaturan setelahnya. Bagian dengan nilai `LanguageId` yang berbeda tetap terpisah karena format bahasa pemeriksaan mereka berbeda.

## **FAQ**

**Apakah ID bahasa menerjemahkan teks?**

Tidak. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) menyimpan metadata pemeriksaan ejaan untuk ejaan dan tata bahasa; ia tidak mengubah konten teks. Terjemahkan teks secara terpisah, lalu tetapkan pengidentifikasi bahasa yang tepat untuk setiap bagian yang telah diterjemahkan.

**Apakah bahasa pemeriksaan mengendalikan font, hyphenation, atau pembungkusan baris?**

Tidak. Pengidentifikasi bahasa hanya untuk pemeriksaan ejaan. Rendering teks dan tata letak terutama bergantung pada [font](/slides/id/php-java/powerpoint-fonts/) yang tersedia, sistem penulisan, dan pengaturan frame teks. Untuk rendering yang dapat diandalkan, sediakan font yang diperlukan, konfigurasikan [font substitution](/slides/id/php-java/font-substitution/), atau [embed fonts](/slides/id/php-java/embedded-font/) dalam presentasi.

**Dapatkah satu paragraf menggunakan beberapa bahasa pemeriksaan?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan dalam contoh paragraf multibahasa.

**Haruskah saya menggunakan `setDefaultTextLanguage` atau `setLanguageId`?**

Gunakan [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) ketika Anda menginginkan nilai default untuk teks yang baru dibuat. Gunakan [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId) ketika sebuah bagian khusus memerlukan bahasa pemeriksaan eksplisit atau ketika sebuah paragraf berisi beberapa bahasa.