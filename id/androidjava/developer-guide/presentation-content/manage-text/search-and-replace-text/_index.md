---
title: Cari dan Ganti Teks dalam Presentasi PowerPoint di Android
linktitle: Cari dan Ganti Teks
type: docs
weight: 55
url: /id/androidjava/search-and-replace-text/
keywords:
- cari teks
- sorot teks
- ganti teks
- ekspresi reguler
- callback hasil
- frame teks
- laporan audit
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Cari, sorot, dan ganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk Android via Java."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java dapat mencari, menyorot, dan mengganti teks dalam sebuah frame teks tunggal atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap temuan melalui callback hasil. Ini memungkinkan memperbarui presentasi dan secara bersamaan membangun jejak audit yang berisi teks yang cocok, konteksnya, posisi, frame teks, dan nomor slide.

Kemampuan ini berguna untuk peninjauan, penyensoran, pengecekan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Pada contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Ruang Lingkup Pencarian**

Gunakan metode pada [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) untuk membatasi operasi pada satu frame teks. Gunakan metode pada [IPresentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/) untuk memproses semua teks yang berlaku dalam presentasi.

| Operasi | Satu frame teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [ITextFrame.highlightText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Sorot kecocokan ekspresi reguler | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Ganti teks literal | [ITextFrame.replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Ganti kecocokan ekspresi reguler | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurasi Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/) untuk mengendalikan pencocokan:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) membatasi kecocokan hanya pada kata lengkap.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) mengontrol apakah huruf harus cocok dengan case.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) menyertakan catatan slide dalam pencarian, penggantian, dan operasi penyorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan `Pattern` Java, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi dan flag-nya.

## **Identifikasi Pemilik Frame Teks**

Alur kerja pemrosesan teks umum sering menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/) saat mencari, mengganti, memvalidasi, atau mengekspor teks. Gunakan [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentShape--) dan [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentCell--) untuk menentukan objek presentasi mana yang memiliki frame teks tersebut.

Nilai yang diharapkan bergantung pada pemilik:

| Pemilik frame teks | `getParentShape` | `getParentCell` |
|---|---|---|
| Sebuah AutoShape atau bentuk lain yang berisi teks | Pemilik [IShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ishape/) | `null` |
| Sebuah sel tabel | `null` | Pemilik [ICell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/icell/) |

Kedua metode menyediakan navigasi hanya-baca. Memanggilnya tidak memindahkan frame teks atau mengubah pemiliknya. Kode umum harus memeriksa kedua nilai untuk `null` dan menangani kemungkinan bahwa tidak ada pemilik yang tersedia.

Contoh berikut menggunakan [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) untuk mengiterasi frame teks dalam sebuah presentasi. Untuk shape, ia melaporkan nama shape, tipe runtime Java, dan slide yang berisi. Untuk sel tabel, ia melaporkan koordinat kolom dan baris berbasis nol serta slide yang berisi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Untuk konten SmartArt, iterasikan shape dalam [ISmartArtNode.getShapes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartartnode/#getShapes--) dan akses setiap [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Frame teks dapat ditelusuri ke shape terkait melalui [ITextFrame.getParentShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentShape--), sementara [ITextFrame.getParentCell](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#getParentCell--) mengembalikan `null`. Karena itu, cabang shape dalam contoh juga menangani teks dari node SmartArt.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Implementasikan [IFindResultCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifindresultcallback/) untuk menerima notifikasi pada setiap kecocokan. Metode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) menyediakan frame teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah ini menurunkannya dari slide induk dan juga menangani teks yang ditemukan dalam catatan slide. `Integer` yang dapat bernilai null memungkinkan model hasil yang sama merepresentasikan teks yang terkait dengan tipe slide lain.

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

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

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

Untuk operasi penggantian, `foundText` berisi teks yang cocok asli, sehingga callback dapat mencatat secara tepat istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [ITextFrame.highlightText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk menyorot kecocokan teks literal dalam sebuah frame teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/) untuk mengendalikan pencarian dan sebuah callback untuk mengumpulkan detail kecocokan.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**. Kedua pencarian melaporkan kecocokannya ke callback yang sama.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // Sorot setiap kemunculan "try" dalam frame teks.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

Hasil:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah frame teks.

Kode berikut menyorot semua kata yang mengandung tujuh karakter atau lebih dan mengumpulkan setiap kecocokan:

```java
import com.aspose.slides.*;
import android.graphics.Color;
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

Hasil:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [IPresentation.highlightText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [IPresentation.highlightRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) untuk mencari semua frame teks yang berlaku dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email sambil mempertahankan kumpulan hasil terpisah untuk dua pencarian.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

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

## **Ganti Teks dalam Frame Teks**

Gunakan [ITextFrame.replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk teks literal dan [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) untuk penggantian berbasis pola. Metode-metode ini memperbarui teks yang cocok dalam frame teks yang ada, yang mempertahankan pemformatan bagian sekitarnya alih-alih membangun ulang frame teks dari string biasa.

Contoh berikut menstandarkan variasi ejaan kemudian mengganti label versi. Callback yang sama mencatat istilah asli yang cocok pada kedua operasi.

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

Jika satu kecocokan mencakup bagian dengan pemformatan berbeda, tinjau output untuk memastikan pemformatan mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [IPresentation.replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [IPresentation.replaceRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan penyensoran.

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

Karena setiap hasil menyimpan nomor slide dan frame teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja peninjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama berdasarkan slide dan kemudian berdasarkan frame teks:

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

**Bagaimana saya dapat mencari hanya satu kotak teks alih-alih seluruh presentasi?**

Dapatkan frame teks dari shape dan panggil [ITextFrame.highlightText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), atau [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pada frame teks tersebut. Metode tingkat presentasi memproses semua frame teks yang berlaku sebagai gantinya.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Atur [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) dan [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ke `true`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `Pattern` Java itu sendiri.

**Apakah pencarian dan penggantian dapat menyertakan teks dalam catatan slide?**

Ya. Atur [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) ke `true` saat menggunakan operasi teks literal tingkat presentasi. Implementasi callback yang ditunjukkan di atas memetakan kecocokan dalam slide catatan kembali ke nomor slide induknya.

**Bagaimana saya dapat membuat laporan tanpa memindai presentasi lagi?**

Berikan sebuah implementasi [IFindResultCallback](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ifindresultcallback/) ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan saat operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, frame teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah penggantian teks mempertahankan formatnya?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [ITextFrame.replaceRegex](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) memodifikasi teks yang cocok dalam frame teks yang ada dan mempertahankan pemformatan bagian sekitarnya. Jika satu kecocokan mencakup bagian dengan format berbeda, periksa hasilnya untuk memastikan pengganti menggunakan gaya yang diinginkan.