---
title: Cari dan Ganti Teks dalam Presentasi PowerPoint di PHP
linktitle: Cari dan Ganti Teks
type: docs
weight: 55
url: /id/php-java/search-and-replace-text/
keywords:
- cari teks
- sorot teks
- ganti teks
- ekspresi reguler
- callback hasil
- bingkai teks
- laporan audit
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Cari, sorot, dan ganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk PHP via Java."
---
## **Ikhtisar**

Aspose.Slides for PHP via Java dapat mencari, menyorot, dan mengganti teks dalam sebuah bingkai teks individu atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Ini memungkinkan untuk memperbarui presentasi dan secara bersamaan membangun jejak audit yang berisi teks yang cocok, konteksnya, posisi, bingkai teks, dan nomor slide.

Kemampuan ini berguna untuk peninjauan, penyensoran, pemeriksaan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Pada contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Sample text](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) untuk membatasi operasi pada satu bingkai teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk memproses semua teks yang relevan dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [TextFrame::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightText) |
| Sorot kecocokan ekspresi reguler | [TextFrame::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightRegex) |
| Ganti teks literal | [TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceText) |
| Ganti kecocokan ekspresi reguler | [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceRegex) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) membatasi pencocokan hanya pada kata lengkap.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) mengontrol apakah huruf kapital harus cocok.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) menyertakan catatan slide dalam pencarian, penggantian, dan penyorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan `Pattern` Java, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi dan flag-nya.

## **Identifikasi Pemilik Bingkai Teks**

Alur kerja pemrosesan teks umum sering menerima sebuah [TextFrame] saat mencari, mengganti, memvalidasi, atau mengekspor teks. Gunakan [TextFrame::getParentShape] dan [TextFrame::getParentCell] untuk menentukan objek presentasi mana yang memiliki bingkai teks.

Nilai yang diharapkan tergantung pada pemilik:

| Pemilik bingkai teks | `getParentShape` | `getParentCell` |
|---|---|---|
| Sebuah AutoShape atau bentuk lain yang berisi teks | Bentuk [Shape](https://reference.aspose.com/slides/id/php-java/aspose.slides/shape/) yang memilikinya | `null` |
| Sebuah sel tabel | `null` | Sel [Cell](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/) yang memilikinya |

Kedua metode menyediakan navigasi read-only. Memanggilnya tidak memindahkan bingkai teks atau mengubah pemiliknya. Kode generik harus memeriksa kedua nilai dengan `java_is_null` dan menangani kemungkinan bahwa tidak ada pemilik yang tersedia.

Contoh berikut menggunakan [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/id/php-java/aspose.slides/slideutil/#getAllTextFrames) untuk mengiterasi bingkai teks dalam sebuah presentasi. Untuk bentuk, ia melaporkan nama bentuk, tipe runtime Java, dan slide yang berisi. Untuk sel tabel, ia melaporkan koordinat kolom dan baris berbasis nol serta slide yang berisi.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Untuk konten SmartArt, iterasi bentuk dalam [SmartArtNode::getShapes](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartnode/#getShapes) dan akses setiap [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/smartartshape/#getTextFrame). Bingkai teks dapat ditelusuri ke bentuk terkait melalui [TextFrame::getParentShape](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentShape), sementara [TextFrame::getParentCell](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#getParentCell) mengembalikan `null`. Oleh karena itu, cabang bentuk dalam contoh juga menangani teks dari node SmartArt.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Berikan callback proxy Java ke metode penyorotan atau penggantian untuk menerima notifikasi setiap kecocokan. Metode callback menerima bingkai teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah ini menurunkannya dari slide induk dan juga menangani teks yang ditemukan dalam catatan slide. Array hasil menggunakan `null` ketika teks terkait dengan tipe slide lain.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Buat proxy untuk objek PHP ini sebelum memberikannya ke operasi:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Untuk operasi penggantian, `foundText` berisi teks asli yang cocok, sehingga callback dapat mencatat secara tepat istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [TextFrame::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightText) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/) untuk mengontrol pencarian.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian hanya menyorot kata lengkap **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Sorot setiap kemunculan "try" dalam bingkai teks.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Sorot hanya kata lengkap "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Hasilnya:

![The highlighted text](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightRegex) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang mengandung tujuh karakter atau lebih:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Hasil:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [Presentation::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightText) dan [Presentation::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightRegex) untuk mencari semua bingkai teks yang relevan dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Ganti Teks dalam Bingkai Teks**

Gunakan [TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText) untuk teks literal dan [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) untuk penggantian berbasis pola. Metode ini memperbarui teks yang cocok di dalam bingkai teks yang ada, mempertahankan format bagian sekitarnya alih-alih membangun ulang bingkai teks dari string biasa.

Contoh berikut menstandarkan varian ejaan dan kemudian mengganti label versi:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Jika satu kecocokan mencakup bagian dengan format berbeda, tinjau output untuk memastikan format mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [Presentation::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceText) dan [Presentation::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceRegex) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan penyensoran.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Kelompokkan Kecocokan untuk Pelaporan**

Karena setiap hasil menyimpan nomor slide dan bingkai teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja peninjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama berdasarkan slide lalu berdasarkan bingkai teks:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **FAQ**

**Bagaimana saya dapat mencari hanya satu kotak teks saja, bukan seluruh presentasi?**

Dapatkan bingkai teks bentuk dan panggil [TextFrame::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText), atau [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) pada bingkai teks tersebut. Metode tingkat presentasi memproses semua bingkai teks yang relevan sebagai gantinya.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Setel [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) dan [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ke `true`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `Pattern` Java itu sendiri.

**Apakah pencarian dan penggantian dapat menyertakan teks dalam catatan slide?**

Ya. Setel [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) ke `true` saat menggunakan operasi teks literal tingkat presentasi.

**Bagaimana saya dapat membuat laporan tanpa memindai presentasi sekali lagi?**

Berikan callback proxy Java ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan saat operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, bingkai teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah mengganti teks mempertahankan formatnya?**

[TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText) dan [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) memodifikasi teks yang cocok di dalam bingkai teks yang ada dan mempertahankan format bagian sekitarnya. Jika sebuah kecocokan mencakup bagian dengan format berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.