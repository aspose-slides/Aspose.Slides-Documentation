---
title: Pencarian dan Penggantian Teks dalam Presentasi PowerPoint di PHP
linktitle: Pencarian dan Penggantian Teks
type: docs
weight: 55
url: /id/php-java/search-and-replace-text/
keywords:
- pencarian teks
- menyorot teks
- mengganti teks
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
## **Gambaran Umum**

Aspose.Slides for PHP via Java dapat mencari, menyorot, dan mengganti teks dalam satu bingkai teks atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Hal ini memungkinkan memperbarui presentasi dan sekaligus membangun jejak audit yang berisi teks yang cocok, konteksnya, posisi, bingkai teks, dan nomor slide.

Kemampuan ini berguna untuk tinjauan, penyensoran, pemeriksaan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Dalam contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/) untuk membatasi operasi pada satu bingkai teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/) untuk memproses semua teks yang berlaku dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [TextFrame::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightText) |
| Sorot kecocokan ekspresi reguler | [TextFrame::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightRegex) |
| Ganti teks literal | [TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceText) |
| Ganti kecocokan ekspresi reguler | [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#replaceRegex) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) membatasi kecocokan hanya pada kata lengkap.  
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) mengontrol apakah huruf harus cocok dalam hal kapitalisasi.  
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) menyertakan catatan slide dalam operasi pencarian, penggantian, dan penyorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan `Pattern` Java, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata ditentukan oleh ekspresi dan flag-nya.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Berikan callback proxy Java ke metode penyorotan atau penggantian untuk menerima notifikasi untuk setiap kecocokan. Metode callback menerima bingkai teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah ini menurunkannya dari slide induk dan juga menangani teks yang ditemukan di catatan slide. Array hasil menggunakan `null` ketika teks terkait dengan jenis slide lain.

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
        $parentSlide = $textFrame->getSlide();
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

Untuk operasi penggantian, `foundText` berisi teks yang cocok asli, sehingga callback dapat mencatat dengan tepat istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [TextFrame::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightText) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/) untuk mengontrol pencarian.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian hanya menyorot kata lengkap **"to"**.

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

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightRegex) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang berisi tujuh huruf atau lebih:

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

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [Presentation::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightText) dan [Presentation::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#highlightRegex) untuk mencari semua bingkai teks yang berlaku dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email:

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

## **Ganti Teks di Bingkai Teks**

Gunakan [TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText) untuk teks literal dan [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) untuk penggantian berbasis pola. Metode ini memperbarui teks yang cocok di dalam bingkai teks yang ada, yang mempertahankan pemformatan bagian sekitarnya alih-alih membangun ulang bingkai teks dari string biasa.

Contoh berikut menstandarisasi varian ejaan dan kemudian mengganti label versi:

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

Jika satu kecocokan melintasi bagian dengan pemformatan berbeda, tinjau output untuk memastikan pemformatan mana yang harus diterapkan pada teks pengganti.

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

Karena setiap hasil menyimpan nomor slide dan bingkai teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja tinjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama berdasarkan slide lalu berdasarkan bingkai teks:

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

**Bagaimana saya dapat mencari hanya satu kotak teks bukan seluruh presentasi?**

Dapatkan bingkai teks dari bentuk tersebut dan panggil [TextFrame::highlightText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText), atau [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) pada bingkai teks itu. Metode tingkat presentasi memproses semua bingkai teks yang berlaku sebagai gantinya.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Setel [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) dan [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) ke `true`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `Pattern` Java itu sendiri.

**Apakah pencarian dan penggantian dapat mencakup teks dalam catatan slide?**

Ya. Setel [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/id/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) ke `true` saat menggunakan operasi teks literal tingkat presentasi.

**Bagaimana saya dapat membuat laporan tanpa memindai presentasi untuk kedua kalinya?**

Berikan callback proxy Java ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan saat operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, bingkai teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah mengganti teks mempertahankan pemformatannya?**

[TextFrame::replaceText](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceText) dan [TextFrame::replaceRegex](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/#replaceRegex) memodifikasi teks yang cocok di dalam bingkai teks yang ada dan mempertahankan pemformatan bagian sekitarnya. Jika satu kecocokan melintasi bagian dengan pemformatan berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.