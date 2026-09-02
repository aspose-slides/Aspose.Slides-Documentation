---
title: Mengotomatisasi Lokalisasi Presentasi dalam JavaScript
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/nodejs-java/presentation-localization/
keywords:
- ubah bahasa
- periksa ejaan
- menekan pemeriksaan ejaan
- bahasa pemeriksaan bukti
- ID bahasa
- teks multibahasa
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Mengatur bahasa pemeriksaan bukti untuk teks presentasi PowerPoint dan OpenDocument dalam JavaScript dengan Aspose.Slides, termasuk nilai default dan paragraf multibahasa."
---
## **Overview**

Aspose.Slides for Node.js via Java memungkinkan Anda mengonfigurasi metadata pemeriksaan bukti untuk bagian teks individual. Gunakan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) untuk mengidentifikasi bahasa pemeriksaan bukti, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) untuk mengizinkan atau menekan pemeriksaan ejaan, dan [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) untuk mengendalikan status “tidak memeriksa bukti” yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi beberapa bahasa dan aturan pemeriksaan bukti yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa untuk teks tertentu, mengatur bahasa default untuk teks baru dengan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), membuat paragraf multibahasa, memilih antara `SpellCheck` dan `ProofDisabled`, serta mempertahankan pengaturan yang dimaksud ketika menggunakan [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Set the Proofing Language for Text**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#getPortionFormat--), dan tetapkan identifier bahasanya. Contoh berikut membuat sebuah shape, mengatur Bahasa Inggris Britania sebagai bahasa pemeriksaan bukti, dan menyimpan hasilnya dengan [Presentation.save](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Default Language for New Text**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) untuk menentukan bahasa pemeriksaan bukti yang akan diberikan Aspose.Slides pada teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau seluruh teks baru dalam presentasi menggunakan bahasa yang sama. Pengaturan ini tidak mengubah metadata bahasa pada teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi yang teks barunya menggunakan aturan pemeriksaan bukti Bahasa Jerman:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Use Multiple Languages in One Paragraph**

Sebuah [Paragraph](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/paragraph/) berisi koleksi bagian teks. Buat [Portion](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/) terpisah untuk setiap bahasa dan atur `LanguageId`‑nya secara independen.

Contoh ini membuat satu paragraf dengan bagian Bahasa Inggris dan Prancis:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Enable or Suppress Spell Checking for Individual Portions**

[PortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portionformat/) mewarisi properti teks umum yang didefinisikan oleh [BasePortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/). Akses format bagian melalui [Portion.getPortionFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/portion/#getPortionFormat--) dan gunakan [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) untuk mengendalikan apakah aplikasi presentasi boleh memeriksa ejaan untuk bagian tersebut. Nilai default adalah `false`: `true` mengizinkan pemeriksaan ejaan, sementara `false` menekannya.

Pengaturan ini berlaku untuk bagian teks individual. Bagian yang berbeda dalam paragraf yang sama sehingga dapat menggunakan nilai yang berbeda. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) dan `setSpellCheck` melayani tujuan yang saling melengkapi: `setLanguageId` mengidentifikasi bahasa pemeriksaan bukti, sedangkan `setSpellCheck` menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) juga mengendalikan pemeriksaan bukti, tetapi mewakili status “tidak memeriksa bukti” yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/nullablebool/). Gunakan `setSpellCheck` bila Anda memerlukan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan `setProofDisabled` bila Anda harus mempertahankan atau secara eksplisit mengendalikan metadata “tidak memeriksa bukti” pada presentasi, termasuk status `NotDefined`. Jika Anda mengatur kedua properti, pertahankan nilai mereka konsisten; jangan menggabungkan `setSpellCheck(true)` dengan `setProofDisabled(NullableBool.True)`.

Properti ini mengonfigurasi metadata pemeriksaan bukti yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan metadata ini untuk melakukan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat presentasi input, memuatnya, menetapkan pengaturan pemeriksaan ejaan dan bahasa pemeriksaan bukti yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membukanya kembali, dan memverifikasi nilai yang disimpan:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) menggabungkan bagian yang bersebelahan yang memiliki format yang sama. Perbedaan pada `SpellCheck` saja tidak membuat bagian tersebut tetap terpisah; setelah digabung, bagian hasil mempertahankan nilai `SpellCheck` dari bagian pertama. Jika bagian memerlukan pengaturan pemeriksaan ejaan yang berbeda, panggil `joinPortionsWithSameFormatting` sebelum menetapkan pengaturan tersebut, atau inspeksi batas bagian hasil dan terapkan kembali pengaturan setelahnya. Bagian dengan nilai `LanguageId` yang berbeda tetap terpisah karena format bahasa pemeriksaan bukti mereka berbeda.

## **FAQ**

**Does a language ID translate the text?**

Tidak. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) menyimpan metadata pemeriksaan bukti untuk ejaan dan tata bahasa; ia tidak mengubah konten teks. Terjemahkan teks secara terpisah, kemudian tetapkan identifier bahasa yang tepat untuk setiap bagian yang telah diterjemahkan.

**Does the proofing language control fonts, hyphenation, or line wrapping?**

Tidak. Identifier bahasa digunakan untuk pemeriksaan bukti. Rendering teks dan tata letak terutama bergantung pada [fonts](/slides/id/nodejs-java/powerpoint-fonts/) yang tersedia, sistem penulisan, dan pengaturan bingkai teks. Untuk rendering yang dapat diandalkan, sediakan font yang diperlukan, konfigurasikan [font substitution](/slides/id/nodejs-java/font-substitution/), atau [embed fonts](/slides/id/nodejs-java/embedded-font/) dalam presentasi.

**Can one paragraph use several proofing languages?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan pada contoh paragraf multibahasa.

**Should I use `setDefaultTextLanguage` or `setLanguageId`?**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) ketika Anda menginginkan bahasa default untuk teks yang baru dibuat. Gunakan [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) ketika sebuah bagian spesifik memerlukan bahasa pemeriksaan bukti eksplisit atau ketika sebuah paragraf berisi beberapa bahasa.