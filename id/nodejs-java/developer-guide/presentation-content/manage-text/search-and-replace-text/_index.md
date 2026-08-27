---
title: Mencari dan Mengganti Teks di Presentasi PowerPoint dengan JavaScript
linktitle: Mencari dan Mengganti Teks
type: docs
weight: 55
url: /id/nodejs-java/search-and-replace-text/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Cari, sorot, dan ganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk Node.js via Java."
---
## **Gambaran Umum**

Aspose.Slides for Node.js via Java dapat mencari, menyorot, dan mengganti teks dalam satu bingkai teks atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Hal ini memungkinkan pembaruan presentasi sekaligus membangun jejak audit yang berisi teks yang cocok, konteksnya, posisi, bingkai teks, dan nomor slide.

Kemampuan ini berguna untuk tinjauan, penyensoran, pengecekan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Pada contoh pertama di bawah, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) untuk membatasi operasi ke satu bingkai teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/) untuk memproses semua teks yang berlaku dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [TextFrame.highlightText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Sorot kecocokan ekspresi reguler | [TextFrame.highlightRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Ganti teks literal | [TextFrame.replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Ganti kecocokan ekspresi reguler | [TextFrame.replaceRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/) untuk mengendalikan pencocokan:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) membatasi kecocokan hanya pada kata lengkap.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) mengontrol apakah huruf besar/kecil harus cocok.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) menyertakan catatan slide dalam operasi pencarian, penggantian, dan penyorotan pada tingkat presentasi.

Operasi ekspresi reguler menggunakan `Pattern` Java, sehingga aturan pencocokan seperti kepekaan huruf dan batas kata didefinisikan oleh ekspresi dan flag-nya.

## **Identifikasi Pemilik Bingkai Teks**

Alur kerja pemrosesan teks umum sering menerima sebuah [TextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/) saat mencari, mengganti, memvalidasi, atau mengekspor teks. Gunakan [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape--) dan [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell--) untuk menentukan objek presentasi mana yang memiliki bingkai teks tersebut.

Nilai yang diharapkan bergantung pada pemiliknya:

| Pemilik bingkai teks | `getParentShape` | `getParentCell` |
|---|---|---|
| Sebuah AutoShape atau bentuk lain yang berisi teks | [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/) yang memiliki | `null` |
| Sel tabel | `null` | [Cell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/cell/) yang memiliki |

Kedua metode menyediakan navigasi read‑only. Memanggilnya tidak memindahkan bingkai teks atau mengubah pemiliknya. Kode generik harus memeriksa kedua nilai untuk `null` dan menangani kemungkinan bahwa tidak ada pemilik yang tersedia.

Contoh berikut menggunakan [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) untuk mengiterasi semua bingkai teks dalam sebuah presentasi. Untuk bentuk, ia melaporkan nama bentuk, tipe runtime Java, dan slide yang memuatnya. Untuk sel tabel, ia melaporkan koordinat kolom dan baris berbasis nol serta slide yang memuatnya.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Untuk konten SmartArt, iterasikan bentuk‑bentuk dalam [SmartArtNode.getShapes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartnode/#getShapes--) dan akses masing‑masing [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Bingkai teks dapat ditelusuri ke bentuk terkait melalui [TextFrame.getParentShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentShape--), sementara [TextFrame.getParentCell](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getParentCell--) mengembalikan `null`. Karena itu, cabang bentuk dalam contoh juga menangani teks dari node SmartArt.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Buat proxy Java untuk callback hasil agar menerima notifikasi untuk setiap kecocokan. Fungsi proxy menerima bingkai teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah menurunkannya melalui bentuk atau sel tabel yang memiliki bingkai teks, dengan [TextFrame.getSlide](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#getSlide--) sebagai cadangan. Ia juga menangani teks yang ditemukan dalam catatan slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Untuk operasi penggantian, `foundText` berisi teks asli yang cocok, sehingga callback dapat mencatat tepat istilah yang diganti.

## **Sorot Teks**

Gunakan metode [TextFrame.highlightText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/) untuk mengendalikan pencarian.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian hanya menyorot kata lengkap **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Sorot setiap kemunculan "try" dalam bingkai teks.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Sorot hanya kata lengkap "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [TextFrame.highlightRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang berisi tujuh karakter atau lebih:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [Presentation.highlightText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [Presentation.highlightRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) untuk mencari semua bingkai teks yang berlaku dalam presentasi. Contoh berikut menyorot istilah literal dan semua alamat email:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ganti Teks dalam Bingkai Teks**

Gunakan [TextFrame.replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) untuk teks literal dan [TextFrame.replaceRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) untuk penggantian berbasis pola. Metode‑metode ini memperbarui teks yang cocok di dalam bingkai teks yang sudah ada, sehingga mempertahankan pemformatan bagian sekitarnya alih‑alih membangun ulang bingkai teks dari string mentah.

Contoh berikut menstandarisasi varian ejaan dan kemudian mengganti label versi:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jika satu kecocokan melintasi bagian dengan pemformatan berbeda, tinjau output untuk memastikan pemformatan yang tepat diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [Presentation.replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [Presentation.replaceRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan penyensoran.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kelompokkan Kecocokan untuk Pelaporan**

Karena setiap hasil yang dikumpulkan menyimpan nomor slide dan bingkai teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja tinjauan. Contoh berikut mengelompokkan hasil pertama berdasarkan slide, kemudian berdasarkan bingkai teks:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Bagaimana cara mencari hanya satu kotak teks saja, bukan seluruh presentasi?**

Dapatkan bingkai teks bentuk tersebut dan panggil [TextFrame.highlightText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), atau [TextFrame.replaceRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pada bingkai teks tersebut. Metode pada tingkat presentasi memproses semua bingkai teks yang berlaku.

**Bagaimana cara mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Setel [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) dan [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ke `true`, lalu berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan kepekaan huruf dalam `Pattern` Java itu sendiri.

**Apakah pencarian dan penggantian dapat mencakup teks dalam catatan slide?**

Ya. Setel [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) ke `true` saat menggunakan operasi teks literal pada tingkat presentasi. Implementasi callback di atas memetakan kecocokan dalam slide catatan kembali ke nomor slide induknya.

**Bagaimana cara membuat laporan tanpa memindai presentasi lagi?**

Berikan proxy callback hasil Java ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan saat operasi berlangsung, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, bingkai teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah mengganti teks mempertahankan pemformatannya?**

[TextFrame.replaceText](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) dan [TextFrame.replaceRegex](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) memodifikasi teks yang cocok di dalam bingkai teks yang sudah ada dan mempertahankan pemformatan bagian sekitarnya. Jika satu kecocokan melintasi bagian dengan pemformatan berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.