---
title: Format Teks Presentasi dalam JavaScript
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/nodejs-java/text-formatting/
keywords:
- menyorot teks
- ekspresi reguler
- meratakan paragraf
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Format dan gaya teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js melalui Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Ikhtisar**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Node.js via Java. Ini mencakup penyorotan, warna latar belakang, transparansi, jarak antar karakter, properti font, rotasi, jarak paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Dalam contoh di bawah, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Sorot Teks**

Gunakan metode [TextFrame.highlightText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) ketika Anda perlu menyorot teks yang cocok dengan contoh tertentu dalam sebuah bingkai teks. Metode ini menerapkan warna sorot pada fragmen teks yang cocok dan dapat digunakan dengan [TextSearchOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/) untuk mengontrol cara pencarian dilakukan, misalnya untuk mencocokkan hanya kata lengkap.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Sorot kata "try" dalam bentuk.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Sorot kata "to" dalam bentuk.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame.highlightRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler. Pada Node.js via Java, API ini tersedia pada [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).

Contoh kode di bawah menyorot semua kata yang mengandung **tujuh atau lebih karakter**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Sorot semua kata dengan tujuh atau lebih karakter.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Atur Warna Latar Belakang Teks**

Gunakan [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) untuk mengatur warna sorot default untuk sebuah paragraf, atau gunakan [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) untuk potongan teks individu.

Contoh kode berikut menunjukkan cara mengatur warna latar belakang untuk **seluruh paragraf**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur warna sorotan untuk seluruh paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Paragraf abu-abu](gray_paragraph.png)

Contoh kode di bawah mendemonstrasikan cara mengatur warna latar belakang untuk **potongan teks dengan font tebal**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur warna sorotan untuk potongan teks.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Potongan teks abu-abu](gray_text_portions.png)

## **Rata Teks Paragraf**

Gunakan [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) untuk mengatur perataan paragraf dalam bingkai teks. Nilainya dapat berupa rata tengah, rata kiri, rata kanan, justify, dan lain-lain.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur perataan paragraf ke tengah.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Atur Transparansi untuk Teks**

Transparansi teks dikontrol melalui komponen alfa dari warna yang diberikan kepada [PortionFormat.getFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Dalam contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0-255, bukan persentase transparansi.

Contoh kode di bawah menunjukkan cara menerapkan transparansi pada **seluruh paragraf**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Atur warna isi teks menjadi warna transparan.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi pada **potongan teks dengan font tebal**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Atur transparansi potongan teks.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Potongan teks transparan](transparent_text_portions.png)

## **Atur Jarak Karakter untuk Teks**

Gunakan [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) untuk memperluas atau memperkecil jarak antar karakter dalam sebuah kotak teks.

Kode JavaScript berikut menunjukkan cara memperluas jarak karakter dalam **seluruh paragraf**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Perluas jarak karakter.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Jarak karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode di bawah menunjukkan cara memperluas jarak karakter dalam **potongan teks dengan font tebal**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Catatan: Gunakan nilai negatif untuk memampatkan jarak karakter.
            portion.getPortionFormat().setSpacing(3); // Perluas jarak karakter.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Jarak karakter dalam potongan teks](character_spacing_in_text_portions.png)

### **Nonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides mungkin terlihat sedikit lebih rapat dibandingkan teks yang sama ditampilkan di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, bahkan ketika font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan di pengaturan PowerPoint.

Untuk membuat output yang dirender lebih mirip dengan PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk potongan teks yang menggunakan font yang terpengaruh. Atur [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) ke nilai yang jauh lebih besar daripada ukuran font sebenarnya:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pengaturan ini mencegah kerning diterapkan pada potongan teks yang cocok dan dapat membantu menyamakan render Aspose.Slides dengan output visual PowerPoint untuk font yang terpengaruh oleh perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) atau pada potongan individual melalui [PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/).

Kode berikut mengatur font dan gaya teks untuk seluruh paragraf: ia menerapkan ukuran font, tebal, miring, garis bawah titik, dan font Times New Roman ke semua potongan dalam paragraf.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Atur properti font untuk paragraf.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh kode di bawah menerapkan properti serupa pada **potongan teks dengan font tebal**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Atur properti font untuk potongan teks.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Properti font untuk potongan teks](font_properties_for_text_portions.png)

## **Atur Rotasi Teks**

Gunakan [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) untuk mengatur orientasi teks yang telah ditentukan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk ke `Vertical270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Bingkai Teks**

Gunakan [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) untuk mengatur sudut rotasi kustom untuk sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/).

Contoh kode di bawah memutar bingkai teks sebesar 3 derajat searah jarum jam dalam bentuk:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Rotasi teks kustom](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-), dan [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) untuk mengontrol jarak paragraf. Properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut menunjukkan cara menentukan jarak baris dalam paragraf:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Jarak baris dalam paragraf](line_spacing.png)

## **Atur Tipe Autofit untuk Bingkai Teks**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) menentukan bagaimana teks berperilaku ketika melebihi batas kontainernya. Gunakan untuk mengontrol apakah teks mengecil, meluap, atau mengubah ukuran bentuk secara otomatis.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Jangkar Bingkai Teks**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) mendefinisikan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di atas, tengah, atau bawah.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Tabulasi Teks**

Gunakan [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) dan [ParagraphFormat.getTabs](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraphformat/#getTabs--) untuk mengonfigurasi tab stop dalam sebuah paragraf.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Tab paragraf](paragraph_tabs.png)

## **Atur Bahasa Pemeriksaan**

Aspose.Slides menyediakan [PortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), yang memungkinkan Anda mengatur bahasa pemeriksaan untuk sebuah potongan teks. Bahasa pemeriksaan menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut menunjukkan cara mengatur bahasa pemeriksaan untuk sebuah potongan teks:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Atur Id bahasa pemeriksaan.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Bahasa Default**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) untuk mendefinisikan bahasa default untuk teks yang dibuat saat memuat atau membuat presentasi.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Tambahkan bentuk persegi panjang baru dengan teks.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Periksa bahasa potongan pertama.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Atur Gaya Teks Default**

Untuk menerapkan pemformatan teks default pada tingkat presentasi, gunakan [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Contoh kode berikut menunjukkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam sebuah presentasi baru.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Dapatkan format paragraf tingkat atas.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ekstrak Teks dengan Efek Semua Kapital**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital pada slide bahkan ketika teks awalnya ditulis dengan huruf kecil. Ketika Anda mengambil potongan teks semacam itu dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textcaptype/) dan ubah string yang dikembalikan menjadi huruf besar ketika nilainya `All`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek All Caps](all_caps_effect.png)

Contoh kode di bawah menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Bagaimana cara memodifikasi teks dalam tabel pada slide?**

Untuk memodifikasi teks dalam tabel pada slide, gunakan [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/). Iterasi melalui sel-sel dan perbarui setiap sel melalui [Cell.getTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/#getTextFrame--) serta pemformatan paragraf melalui [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Bagaimana cara menerapkan warna gradien pada teks dalam slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [PortionFormat.getFillFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Atur [FillFormat.setFillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) ke [FillType.Gradient](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) dan konfigurasikan titik-titik gradien, arah, serta transparansi.