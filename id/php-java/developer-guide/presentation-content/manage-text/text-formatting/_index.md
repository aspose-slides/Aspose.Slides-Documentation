---
title: Format Teks Presentasi dalam PHP
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/php-java/text-formatting/
keywords:
- penyelarasan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- jarak karakter
- properti font
- famili font
- rotasi teks
- sudut rotasi
- bingkai teks
- jarak baris
- properti autofit
- anchor bingkai teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- PHP
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Gambaran Umum**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk PHP via Java. Artikel ini mencakup warna latar belakang, transparansi, jarak karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Dalam contoh di bawah, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Sample text](sample_text.png)

Untuk menemukan dan menyorot teks literal atau kecocokan ekspresi reguler, lihat [Cari dan Ganti Teks](/slides/id/php-java/search-and-replace-text/).

## **Atur Warna Latar Belakang Teks**

Gunakan [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) untuk mengatur warna sorot default untuk sebuah paragraf, atau gunakan [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#getHighlightColor) untuk bagian teks individu.

Contoh kode berikut menunjukkan cara mengatur warna latar belakang untuk **seluruh paragraf**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Atur warna sorot untuk seluruh paragraf.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Paragraf abu-abu](gray_paragraph.png)

Berikut contoh kode menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Atur warna sorot untuk bagian teks.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Bagian teks abu-abu](gray_text_portions.png)

## **Ratakan Paragraf Teks**

Gunakan [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setAlignment) untuk mengatur perataan paragraf dalam bingkai teks. Nilainya dapat berupa tengah, rata kiri, rata kanan, justified, dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Transparansi teks dikendalikan melalui komponen alfa dari warna yang ditetapkan pada [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#getFillFormat). Dalam contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0–255, bukan persentase transparansi.

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Atur warna isi teks menjadi warna transparan.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **bagian teks dengan font tebal**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Atur transparansi bagian teks.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
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

Gunakan [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setSpacing) untuk memperluas atau memperkecil jarak antar karakter dalam sebuah kotak teks.

Kode PHP berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Perluas jarak karakter.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode berikut menunjukkan cara memperluas jarak karakter dalam **bagian teks dengan font tebal**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
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

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat tampak sedikit lebih rapat dibandingkan teks yang sama ditampilkan di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, meskipun font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk membuat output yang dirender lebih mendekati PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terpengaruh. Atur [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) ke nilai yang jauh lebih besar daripada ukuran font sebenarnya:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Pengaturan ini mencegah kerning diterapkan pada bagian teks yang cocok dan dapat membantu menyelaraskan rendering Aspose.Slides dengan output visual PowerPoint untuk font yang dipengaruhi oleh perilaku spesifik PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) atau pada bagian individu melalui [PortionFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/portionformat/).

Kode berikut mengatur font dan gaya teks untuk seluruh paragraf: ia menerapkan ukuran font, tebal, miring, garis bawah titik, dan font Times New Roman ke semua bagian dalam paragraf.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Atur properti font untuk paragraf.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh kode berikut menerapkan properti serupa pada **bagian teks dengan font tebal**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Atur properti font untuk bagian teks.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
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

Gunakan [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setTextVerticalType) untuk mengatur orientasi teks bawaan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk ke `Vertical270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Bingkai Teks**

Gunakan [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setRotationAngle) untuk mengatur sudut rotasi kustom untuk sebuah [TextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframe/).

Contoh kode berikut memutar bingkai teks sebesar 3 derajat searah jarum jam dalam bentuk:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hasilnya:

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setSpaceBefore), dan [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setSpaceWithin) untuk mengontrol jarak paragraf. Properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut menunjukkan cara menentukan jarak baris dalam paragraf:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setAutofitType) menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengontrol apakah teks menyusut, meluap, atau mengubah ukuran bentuk secara otomatis.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Anchor Bingkai Teks**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/id/php-java/aspose.slides/textframeformat/#setAnchoringType) menentukan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di atas, tengah, atau bawah.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Tabulasi Teks**

Gunakan [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) dan [ParagraphFormat::getTabs](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraphformat/#getTabs) untuk mengkonfigurasi tab stop dalam sebuah paragraf.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Aspose.Slides menyediakan [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#setLanguageId), yang memungkinkan Anda mengatur bahasa proofing untuk sebuah bagian teks. Bahasa proofing menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut menunjukkan cara mengatur bahasa proofing untuk sebuah bagian teks:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Atur Id bahasa proofing.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Atur Bahasa Default**

Gunakan [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/id/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) untuk mendefinisikan bahasa default untuk teks yang dibuat saat memuat atau membuat presentasi.

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

Untuk menerapkan format teks default pada tingkat presentasi, gunakan [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/id/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Contoh kode berikut menunjukkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam presentasi baru.

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

## **Ekstrak Teks dengan Efek Semua Huruf Besar**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital di slide meskipun semula diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/php-java/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf besar ketika nilainya `All`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek Semua Huruf Besar](all_caps_effect.png)

Contoh kode berikut menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

**Cara mengubah teks dalam tabel pada slide?**

Untuk mengubah teks dalam tabel pada slide, gunakan [Table](https://reference.aspose.com/slides/id/php-java/aspose.slides/table/). Iterasi melalui sel-sel dan perbarui setiap sel melalui [Cell::getTextFrame](https://reference.aspose.com/slides/id/php-java/aspose.slides/cell/#getTextFrame) serta format paragraf melalui [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Cara menerapkan warna gradien ke teks dalam slide PowerPoint?**

Untuk menerapkan warna gradien ke teks, gunakan [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/id/php-java/aspose.slides/baseportionformat/#getFillFormat). Atur [FillFormat::setFillType](https://reference.aspose.com/slides/id/php-java/aspose.slides/fillformat/#setFillType) ke [FillType::Gradient](https://reference.aspose.com/slides/id/php-java/aspose.slides/filltype/) dan konfigurasikan titik-titik gradien, arah, serta transparansi.