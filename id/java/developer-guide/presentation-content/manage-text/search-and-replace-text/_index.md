---
title: Cari dan Ganti Teks dalam Presentasi PowerPoint di Java
linktitle: Cari dan Ganti Teks
type: docs
weight: 55
url: /id/java/search-and-replace-text/
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
- Java
- Aspose.Slides
description: "Cari, sorot, dan ganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk Java."
---
## **Ikhtisar**

Aspose.Slides for Java dapat mencari, menyorot, dan mengganti teks dalam sebuah bingkai teks individu atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Hal ini memungkinkan memperbarui presentasi dan secara bersamaan membuat jejak audit yang berisi teks yang cocok, konteksnya, posisi, bingkai teks, dan nomor slide.

Kemampuan ini berguna untuk peninjauan, redaksi, pemeriksaan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Dalam contoh pertama di bawah, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [ITextFrame](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/) untuk membatasi operasi ke satu bingkai teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/) untuk memproses semua teks yang berlaku dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Sorot kecocokan ekspresi reguler | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Ganti teks literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Ganti kecocokan ekspresi reguler | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) membatasi kecocokan hanya pada kata lengkap.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) mengontrol apakah kapitalisasi karakter harus cocok.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) termasuk catatan slide dalam pencarian, penggantian, dan penyorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan Java `Pattern`, jadi aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi dan flag-nya.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Implementasikan [IFindResultCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifindresultcallback/) untuk menerima notifikasi untuk setiap kecocokan. Metodenya [IFindResultCallback.foundResult](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) menyediakan bingkai teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah ini menurunkannya dari slide induk dan juga menangani teks yang ditemukan dalam catatan slide. `Integer` yang nullable memungkinkan model hasil yang sama mewakili teks yang terkait dengan tipe slide lain.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Untuk operasi penggantian, `foundText` berisi teks asli yang cocok, sehingga callback dapat mencatat persis istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [ITextFrame.highlightText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/) untuk mengontrol pencarian dan callback untuk mengumpulkan detail kecocokan.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian hanya menyorot kata lengkap **"to"**. Kedua pencarian melaporkan kecocokannya ke callback yang sama.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Sorot setiap kemunculan "try" dalam bingkai teks.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Sorot hanya kata lengkap "to".
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang mengandung tujuh atau lebih karakter dan mengumpulkan setiap kecocokan:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [Presentation.highlightText](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [Presentation.highlightRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) untuk mencari semua bingkai teks yang berlaku dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email sambil menjaga koleksi hasil terpisah untuk dua pencarian.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ganti Teks dalam Bingkai Teks**

Gunakan [ITextFrame.replaceText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk teks literal dan [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) untuk penggantian berbasis pola. Metode-metode ini memperbarui teks yang cocok dalam bingkai teks yang ada, yang mempertahankan pemformatan bagian sekitarnya alih-alih membangun kembali bingkai teks dari string biasa.

Contoh berikut menstandardisasi varian ejaan dan kemudian mengganti label versi. Callback yang sama mencatat istilah asli yang cocok oleh kedua operasi.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika satu kecocokan mencakup bagian dengan pemformatan berbeda, tinjau output untuk mengonfirmasi pemformatan mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [Presentation.replaceText](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [Presentation.replaceRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan redaksi.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kelompokkan Kecocokan untuk Pelaporan**

Karena setiap hasil menyimpan nomor slide dan bingkai teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja peninjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama per slide lalu per bingkai teks:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **FAQ**

**Bagaimana saya dapat mencari hanya satu kotak teks bukan seluruh presentasi?**

Dapatkan bingkai teks shape dan panggil [ITextFrame.highlightText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), atau [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pada bingkai teks tersebut. Metode tingkat presentasi memproses semua bingkai teks yang berlaku sebagai gantinya.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Setel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) dan [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ke `true`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `Pattern` Java itu sendiri.

**Apakah pencarian dan penggantian dapat menyertakan teks dalam catatan slide?**

Ya. Setel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/id/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) ke `true` saat menggunakan operasi teks literal tingkat presentasi. Implementasi callback di atas memetakan kecocokan di slide catatan kembali ke nomor slide induknya.

**Bagaimana saya dapat membuat laporan tanpa memindai presentasi untuk kedua kalinya?**

Berikan implementasi [IFindResultCallback](https://reference.aspose.com/slides/id/java/com.aspose.slides/ifindresultcallback/) ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan selama operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, bingkai teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah mengganti teks mempertahankan pemformatannya?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) memodifikasi teks yang cocok dalam bingkai teks yang ada dan mempertahankan pemformatan bagian sekitarnya. Jika sebuah kecocokan mencakup bagian dengan pemformatan berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.