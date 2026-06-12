---
title: Format Teks Presentasi di Android
linktitle: Pemformatan Teks
type: docs
weight: 50
url: /id/androidjava/text-formatting/
keywords:
- menyorot teks
- ekspresi reguler
- menyelaraskan paragraf
- gaya teks
- latar belakang teks
- transparansi teks
- spasi karakter
- properti font
- keluarga font
- rotasi teks
- sudut rotasi
- frame teks
- jarak baris
- properti autofit
- anchor frame teks
- tabulasi teks
- bahasa default
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Memformat dan menata teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Sesuaikan font, warna, perataan, dan lainnya."
---
## **Ikhtisar**

Artikel ini menunjukkan cara memformat teks dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java. Artikel ini mencakup penyorotan, warna latar belakang, transparansi, spasi karakter, properti font, rotasi, spasi paragraf, perilaku autofit, penempatan teks, tab stop, dan pengaturan bahasa.

Pada contoh di bawah, kami akan menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Sorot Teks**

Gunakan metode [ITextFrame.highlightText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) ketika Anda perlu menyorot teks yang cocok dengan contoh tertentu dalam sebuah frame teks. Metode ini menerapkan warna sorot pada fragmen teks yang cocok dan dapat digunakan bersama [ITextSearchOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextSearchOptions) untuk mengontrol cara pencarian dilakukan, misalnya untuk mencocokkan hanya kata lengkap.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Dapatkan shape pertama dari slide pertama.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Sorot kata "try" pada shape.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Sorot kata "to" pada shape.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler.

Contoh kode di bawah menyorot semua kata yang mengandung **tujuh karakter atau lebih**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Sorot semua kata dengan tujuh karakter atau lebih.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Atur Warna Latar Belakang Teks**

Gunakan [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) untuk mengatur warna sorot default untuk sebuah paragraf, atau gunakan [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) untuk bagian teks individu.

Contoh kode berikut menunjukkan cara mengatur warna latar belakang untuk **seluruh paragraf**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Set warna sorot untuk seluruh paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Paragraf abu‑abu](gray_paragraph.png)

Contoh kode di bawah menunjukkan cara mengatur warna latar belakang untuk **bagian teks dengan font tebal**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Set warna sorot untuk bagian teks.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Bagian teks abu‑abu](gray_text_portions.png)

## **Ratakan Paragraf Teks**

Gunakan [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) untuk mengatur perataan paragraf dalam sebuah frame teks. Nilainya dapat berupa centered, left‑aligned, right‑aligned, justified, dan sebagainya.

Contoh kode berikut menunjukkan cara meratakan paragraf ke **tengah**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Set perataan paragraf ke tengah.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Paragraf yang diratakan](aligned_paragraph.png)

## **Atur Transparansi untuk Teks**

Transparansi teks dikontrol melalui komponen alfa dari warna yang ditetapkan pada [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Dalam contoh di bawah, `alpha = 50` adalah nilai saluran alfa ARGB pada skala 0‑255, bukan persentase transparansi.

Contoh kode berikut menunjukkan cara menerapkan transparansi ke **seluruh paragraf**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Set warna isian teks menjadi warna transparan.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Paragraf transparan](transparent_paragraph.png)

Contoh kode berikut menunjukkan cara menerapkan transparansi ke **bagian teks dengan font tebal**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Atur transparansi bagian teks.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Bagian teks transparan](transparent_text_portions.png)

## **Atur Spasi Karakter untuk Teks**

Gunakan [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) untuk memperlebar atau mempersempit spasi antar karakter dalam sebuah kotak teks.

Kode Java berikut menunjukkan cara memperlebar spasi karakter dalam **seluruh paragraf**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Catatan: Gunakan nilai negatif untuk memperkecil jarak karakter.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Perluas jarak karakter.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Spasi karakter dalam paragraf](character_spacing_in_paragraph.png)

Contoh kode di bawah menunjukkan cara memperlebar spasi karakter dalam **bagian teks dengan font tebal**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Catatan: Gunakan nilai negatif untuk memperkecil jarak karakter.
            portion.getPortionFormat().setSpacing(3); // Perluas jarak karakter.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Spasi karakter dalam bagian teks](character_spacing_in_text_portions.png)

### **Nonaktifkan Kerning untuk Font Tertentu**

Dalam beberapa kasus, teks yang dirender oleh Aspose.Slides dapat terlihat sedikit lebih rapat dibandingkan teks yang sama ditampilkan di PowerPoint. Hal ini dapat terjadi karena PowerPoint mungkin mengabaikan data kerning untuk font tertentu, bahkan ketika font tersebut memiliki informasi kerning yang valid dan kerning diaktifkan dalam pengaturan PowerPoint.

Untuk membuat hasil render lebih mendekati PowerPoint dalam kasus tersebut, Anda dapat menonaktifkan kerning untuk bagian teks yang menggunakan font yang terpengaruh. Atur [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) ke nilai yang jauh lebih besar daripada ukuran font sebenarnya:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pengaturan ini mencegah kerning diterapkan pada bagian teks yang cocok dan dapat membantu menyelaraskan rendering Aspose.Slides dengan output visual PowerPoint untuk font yang dipengaruhi oleh perilaku khusus PowerPoint ini.

## **Kelola Properti Font Teks**

Properti font dapat diatur pada tingkat paragraf melalui [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) atau pada bagian individual melalui [IPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPortionFormat).

Kode berikut mengatur font dan gaya teks untuk seluruh paragraf: ia menerapkan ukuran font, tebal, miring, garis bawah titik, dan font Times New Roman ke semua bagian dalam paragraf.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Atur properti font untuk paragraf.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Properti font untuk paragraf](font_properties_for_paragraph.png)

Contoh kode di bawah menerapkan properti serupa ke **bagian teks dengan font tebal**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Set properti font untuk bagian teks.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Properti font untuk bagian teks](font_properties_for_text_portions.png)

## **Atur Rotasi Teks**

Gunakan [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) untuk mengatur orientasi teks bawaan dalam sebuah bentuk.

Contoh kode berikut mengatur orientasi teks dalam bentuk ke `Vertical270`, yang memutar teks **90 derajat berlawanan arah jarum jam**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Rotasi teks](text_rotation.png)

## **Atur Rotasi Kustom untuk Frame Teks**

Gunakan [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) untuk mengatur sudut rotasi kustom untuk sebuah [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame).

Contoh kode di bawah memutar frame teks sebesar 3 derajat searah jarum jam dalam bentuk:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Rotasi kustom teks](custom_text_rotation.png)

## **Atur Jarak Baris Paragraf**

Aspose.Slides menyediakan [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-), dan [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) untuk mengontrol spasi paragraf. Properti ini digunakan sebagai berikut:

* Gunakan nilai positif untuk menentukan jarak baris sebagai persentase dari tinggi baris.
* Gunakan nilai negatif untuk menentukan jarak baris dalam poin.

Contoh kode berikut menunjukkan cara menentukan jarak baris dalam paragraf:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Jarak baris dalam paragraf](line_spacing.png)

## **Atur Tipe Autofit untuk Frame Teks**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) menentukan bagaimana teks berperilaku ketika melebihi batas wadahnya. Gunakan untuk mengontrol apakah teks menyusut, meluap, atau mengubah ukuran bentuk secara otomatis.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Penambatan Frame Teks**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) mendefinisikan bagaimana teks diposisikan secara vertikal di dalam bentuk, misalnya di bagian atas, tengah, atau bawah.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Tabulasi Teks**

Gunakan [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) dan [IParagraphFormat.getTabs](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) untuk mengkonfigurasi tab stop dalam sebuah paragraf.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasil:

![Tabulasi paragraf](paragraph_tabs.png)

## **Atur Bahasa Proofing**

Aspose.Slides menyediakan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-), yang memungkinkan Anda mengatur bahasa proofing untuk sebuah bagian teks. Bahasa proofing menentukan bahasa yang digunakan untuk pemeriksaan ejaan dan tata bahasa di PowerPoint.

Contoh kode berikut menunjukkan cara mengatur bahasa proofing untuk sebuah bagian teks:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Setel ID bahasa proofing.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Bahasa Default**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) untuk mendefinisikan bahasa default bagi teks yang dibuat saat memuat atau membuat presentasi.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Tambahkan bentuk persegi panjang baru dengan teks.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Periksa bahasa bagian pertama.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Atur Gaya Teks Default**

Untuk menerapkan format teks default pada tingkat presentasi, gunakan [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Contoh kode berikut menunjukkan cara mengatur font tebal default dengan ukuran 14 pt untuk semua teks di seluruh slide dalam presentasi baru.

```java
Presentation presentation = new Presentation();
try {
    // Dapatkan format paragraf tingkat atas.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ekstrak Teks dengan Efek All‑Caps**

Di PowerPoint, menerapkan efek font **All Caps** membuat teks muncul dalam huruf kapital pada slide meskipun awalnya diketik dengan huruf kecil. Saat Anda mengambil bagian teks tersebut dengan Aspose.Slides, perpustakaan mengembalikan teks persis seperti yang dimasukkan. Untuk mencocokkan teks yang ditampilkan, periksa [TextCapType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/TextCapType) dan ubah string yang dikembalikan menjadi huruf kapital ketika nilainya `All`.

Misalkan kita memiliki kotak teks berikut pada slide pertama file sample2.pptx.

![Efek All Caps](all_caps_effect.png)

Contoh kode di bawah menunjukkan cara mengekstrak teks dengan efek **All Caps** yang diterapkan:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
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

**Cara mengubah teks dalam tabel pada slide?**

Untuk mengubah teks dalam tabel pada slide, gunakan [ITable](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITable). Iterasi melalui sel dan perbarui setiap sel melalui [ICell.getTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ICell#getTextFrame--) serta format paragraf melalui [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Cara menerapkan warna gradien pada teks di slide PowerPoint?**

Untuk menerapkan warna gradien pada teks, gunakan [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Atur [IFillFormat.setFillType](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) ke [FillType.Gradient](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/FillType) dan konfigurasikan titik gradien, arah, serta transparansi.