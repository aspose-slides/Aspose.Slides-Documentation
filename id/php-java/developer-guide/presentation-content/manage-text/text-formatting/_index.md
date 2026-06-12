---
title: Format Teks Presentasi di PHP
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/php-java/text-formatting/
keywords:
- menyorot teks
- ekspresi reguler
- menyelaraskan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- keluarga font
- rotasi teks
- sudut rotasi
- bingkai teks
- jarak baris
- properti autofit
- jangkar bingkai teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP melalui Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks pada presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Ini mencakup penyorotan, warna latar belakang, transparansi, jarak karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tabulasi, dan pengaturan bahasa.

Dalam contoh di bawah, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Sorot Teks**

Gunakan metode [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/)`::highlightText` ketika Anda perlu menyorot teks yang cocok dengan contoh tertentu dalam sebuah bingkai teks. Metode ini menerapkan warna sorotan pada potongan teks yang cocok dan dapat digunakan bersama [TextHighlightingOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/texthighlightingoptions/) untuk mengendalikan cara pencarian dilakukan, misalnya, untuk mencocokkan hanya kata lengkap.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Dapatkan bentuk pertama dari slide pertama.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Sorot kata "try" dalam bentuk.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Sorot kata "to" dalam bentuk.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/)`::highlightRegex` menyorot kecocokan teks yang ditemukan oleh sebuah ekspresi reguler.

Contoh kode di bawah menyorot semua kata yang mengandung **tujuh karakter atau lebih**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Sorot semua kata dengan tujuh karakter atau lebih.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Atur Warna Latar Belakang Teks**

Gunakan format bagian default [ParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/) untuk mengatur warna sorotan default bagi sebuah paragraf, atau gunakan [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/) untuk bagian teks individu.

Contoh kode berikut memperlihatkan cara mengatur warna latar belakang untuk **seluruh paragraf**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Atur warna sorotan untuk seluruh paragraf.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Paragraf abu‑abu](gray_paragraph.png)

Contoh kode di bawah menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Atur warna sorotan untuk bagian teks.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bagian teks abu‑abu](gray_text_portions.png)

## **Ratakan Paragraf Teks**

Gunakan metode [ParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/)`::setAlignment` untuk mengatur perataan paragraf dalam sebuah bingkai teks. Nilainya dapat berupa centered, left‑aligned, right‑aligned, justified, dan sebagainya.

Contoh kode berikut memperlihatkan cara meratakan paragraf ke **tengah**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Atur perataan paragraf ke tengah.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Atur Transparansi untuk Teks**

Transparansi teks dikendalikan melalui komponen alfa dari warna yang ditetapkan pada format isian [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/). Pada contoh di bawah, `alpha = 50` adalah nilai kanal alfa ARGB pada skala 0‑255, bukan persentase transparansi.

Contoh kode berikut memperlihatkan cara menerapkan transparansi pada **seluruh paragraf**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Atur warna isian teks menjadi warna transparan.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut memperlihatkan cara menerapkan transparansi pada **bagian teks dengan font tebal**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Atur transparansi bagian teks.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bagian teks transparan](transparent_text_portions.png)

## **Atur Jarak Karakter untuk Teks**

Gunakan metode [BasePortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/)`::setSpacing` untuk memperlebar atau mempersempit jarak antara karakter dalam sebuah kotak teks.

Contoh kode PHP berikut memperlihatkan cara memperlebar jarak karakter pada **seluruh paragraf**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Catatan: Gunakan nilai negatif untuk memperkecil jarak karakter.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Perluas jarak karakter.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode di bawah memperlihatkan cara memperlebar jarak karakter pada **bagian teks dengan font tebal**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Catatan: Gunakan nilai negatif untuk memperkecil jarak karakter.
            $portion->getPortionFormat()->setSpacing(3); // Perluas jarak karakter.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Jarak karakter dalam bagian teks](character_spacing_in_text_portions.png)

### **Nonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides mungkin terlihat sedikit lebih rapat dibandingkan teks yang sama di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan di pengaturan PowerPoint.

Untuk membuat hasil render lebih mirip dengan PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terdampak. Atur metode [BasePortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` ke nilai yang jauh lebih besar daripada ukuran font sebenarnya:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pengaturan ini mencegah kerning diterapkan pada bagian teks yang cocok dan dapat membantu menyelaraskan rendering Aspose.Slides dengan output visual PowerPoint untuk font yang dipengaruhi perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui format bagian default [ParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/) atau pada bagian individu melalui [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/).

Contoh kode berikut mengatur font dan gaya teks untuk seluruh paragraf: ia menerapkan ukuran font, tebal, miring, garis bawah titik, dan font Times New Roman ke semua bagian dalam paragraf.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Atur properti font untuk paragraf.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh kode di bawah menerapkan properti serupa pada **bagian teks dengan font tebal**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Atur properti font untuk bagian teks.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Atur Rotasi Teks**

Gunakan metode [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` untuk mengatur orientasi teks bawaan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk menjadi `Vertical270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Bingkai Teks**

Gunakan metode [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/)`::setRotationAngle` untuk mengatur sudut rotasi kustom bagi sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/).

Contoh kode di bawah memutar bingkai teks sebesar 3 derajat searah jarum jam dalam bentuk:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan metode [ParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore`, dan `ParagraphFormat::setSpaceWithin` untuk mengendalikan jarak paragraf. Metode‑metode ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut memperlihatkan cara menentukan jarak baris dalam paragraf:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Jarak baris dalam paragraf](line_spacing.png)

## **Atur Tipe Autofit untuk Bingkai Teks**

Metode [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/)`::setAutofitType` menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengendalikan apakah teks menyusut, meluap, atau mengubah ukuran bentuk secara otomatis.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Jangkauan Vertikal Bingkai Teks**

Metode [TextFrameFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/)`::setAnchoringType` mendefinisikan bagaimana teks diposisikan secara vertikal di dalam sebuah bentuk, misalnya di atas, tengah, atau bawah.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Tabulasi Teks**

Gunakan metode [ParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` dan koleksi tabnya untuk mengonfigurasi titik tab dalam sebuah paragraf.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Tab paragraf](paragraph_tabs.png)

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan metode [BasePortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/)`::setLanguageId`, yang memungkinkan Anda mengatur bahasa proofing untuk sebuah bagian teks. Bahasa proofing menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut memperlihatkan cara mengatur bahasa proofing untuk sebuah bagian teks:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Atur ID bahasa proofing.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Bahasa Default**

Gunakan metode [LoadOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` untuk menentukan bahasa default bagi teks yang dibuat saat memuat atau membuat sebuah presentasi.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Tambahkan bentuk persegi panjang baru dengan teks.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Periksa bahasa bagian pertama.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Atur Gaya Teks Default**

Untuk menerapkan format teks default pada tingkat presentasi, gunakan gaya teks default [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/).

Contoh kode berikut memperlihatkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam sebuah presentasi baru.

```php
$presentation = new Presentation();
try {
    // Dapatkan format paragraf tingkat atas.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ekstrak Teks dengan Efek Semua Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital pada slide meskipun awalnya diketik dalam huruf kecil. Saat Anda mengambil bagian teks semacam itu dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/php-java/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf kapital ketika nilai tersebut adalah `All`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek All Caps](all_caps_effect.png)

Contoh kode berikut memperlihatkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/). Iterasi sel‑sel dan perbarui setiap sel melalui bingkai teks [Cell](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/) serta pemformatan paragraf melalui [Paragraph](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/)'s paragraph format.

**Bagaimana cara menerapkan warna gradasi pada teks di slide PowerPoint?**

Untuk menerapkan warna gradasi pada teks, gunakan format isian [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/). Atur tipe isian [FillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/) menjadi [FillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) `Gradient` dan konfigurasikan titik gradasi, arah, serta transparansi.