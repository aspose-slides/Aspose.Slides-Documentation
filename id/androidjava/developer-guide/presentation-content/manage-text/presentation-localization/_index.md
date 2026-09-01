---
title: Otomatisasi Lokalisasi Presentasi di Android
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/androidjava/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- tekan pemeriksaan ejaan
- bahasa pemeriksaan
- id bahasa
- teks multibahasa
- PowerPoint
- presentasi
- Android
- Java
- Aspose.Slides
description: "Atur bahasa pemeriksaan untuk teks presentasi PowerPoint dan OpenDocument di Android dengan Aspose.Slides untuk Android via Java, termasuk nilai default dan paragraf multibahasa."
---
## **Gambaran Umum**

Aspose.Slides for Android via Java memungkinkan Anda mengkonfigurasi metadata pemeriksaan bahasa untuk bagian teks individu. Gunakan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) untuk mengidentifikasi bahasa pemeriksaan, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) untuk mengizinkan atau menekan pemeriksaan ejaan, dan [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) untuk mengontrol keadaan “tidak memeriksa” yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi banyak bahasa dan aturan pemeriksaan yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa ke teks tertentu, mengatur bahasa default untuk teks baru dengan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), membuat paragraf multibahasa, memilih antara `SpellCheck` dan `ProofDisabled`, serta mempertahankan pengaturan yang diinginkan saat menggunakan [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Atur Bahasa Pemeriksaan untuk Teks**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [IPortion.getPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/#getPortionFormat--), dan tetapkan pengidentifikasi bahasa nya. Contoh berikut membuat sebuah shape, menetapkan Bahasa Inggris Britania sebagai bahasa pemeriksaan, dan menyimpan hasilnya dengan [Presentation.save](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Atur Bahasa Default untuk Teks Baru**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) untuk menentukan bahasa pemeriksaan yang akan diberikan Aspose.Slides ke teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau seluruh teks baru dalam presentasi menggunakan bahasa yang sama. Pengaturan ini tidak mengubah metadata bahasa dari teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi yang teks barunya menggunakan aturan pemeriksaan Bahasa Jerman:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gunakan Beberapa Bahasa dalam Satu Paragraf**

Sebuah [IParagraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iparagraph/) berisi koleksi bagian teks. Buat [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) terpisah untuk setiap bahasa dan atur `LanguageId`‑nya secara independen.

Contoh ini membuat satu paragraf dengan bagian Bahasa Inggris dan Prancis:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aktifkan atau Tekan Pemeriksaan Ejaan untuk Bagian Individual**

[IPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportionformat/) mewarisi properti teks umum yang didefinisikan oleh [IBasePortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/). Akses format bagian melalui [IPortion.getPortionFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iportion/#getPortionFormat--) dan gunakan [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) untuk mengontrol apakah aplikasi presentasi dapat memeriksa ejaan untuk bagian tersebut. Nilai default adalah `false`: `true` mengizinkan pemeriksaan ejaan, sementara `false` menekannya.

Pengaturan ini berlaku untuk bagian teks individual. Bagian yang berbeda dalam paragraf yang sama dapat menggunakan nilai yang berbeda. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) dan `setSpellCheck` melayani tujuan yang saling melengkapi: `setLanguageId` mengidentifikasi bahasa pemeriksaan, sedangkan `setSpellCheck` menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) juga mengontrol pemeriksaan, tetapi mewakili keadaan “tidak memeriksa” yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/nullablebool/). Gunakan `setSpellCheck` bila Anda membutuhkan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan `setProofDisabled` bila Anda perlu mempertahankan atau secara eksplisit mengontrol metadata “tidak memeriksa” presentasi, termasuk keadaan `NotDefined`‑nya. Jika Anda mengatur kedua properti, jaga konsistensi nilainya; jangan menggabungkan `setSpellCheck(true)` dengan `setProofDisabled(NullableBool.True)`.

Properti ini mengkonfigurasi metadata pemeriksaan yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan properti ini untuk menjalankan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat presentasi masuk, memuatnya, menetapkan pengaturan pemeriksaan ejaan serta bahasa pemeriksaan yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membukanya kembali, dan memverifikasi nilai yang disimpan:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) menggabungkan bagian‑bagian yang berdekatan dan memiliki format yang sama. Perbedaan pada `SpellCheck` saja tidak membuat bagian tersebut tetap terpisah; setelah digabung, bagian hasil tetap mempertahankan nilai `SpellCheck` dari bagian pertama. Jika bagian memerlukan pengaturan pemeriksaan ejaan yang berbeda, panggil `joinPortionsWithSameFormatting` sebelum menetapkan pengaturan tersebut, atau periksa batas‑batas bagian hasil dan terapkan kembali pengaturannya setelahnya. Bagian dengan nilai `LanguageId` yang berbeda tetap terpisah karena format bahasa pemeriksaannya berbeda.

## **FAQ**

**Apakah ID bahasa menerjemahkan teks?**

Tidak. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) menyimpan metadata pemeriksaan untuk ejaan dan tata bahasa; ia tidak mengubah isi teks. Terjemahkan teks secara terpisah, kemudian tetapkan pengidentifikasi bahasa yang sesuai untuk setiap bagian yang telah diterjemahkan.

**Apakah bahasa pemeriksaan mengontrol font, hyphenation, atau pembungkus baris?**

Tidak. Pengidentifikasi bahasa hanya untuk pemeriksaan. Rendering teks dan tata letak terutama bergantung pada [font](/slides/id/androidjava/powerpoint-fonts/) yang tersedia, sistem penulisan, dan pengaturan bingkai teks. Untuk rendering yang dapat diandalkan, sediakan font yang diperlukan, konfigurasikan [penggantian font](/slides/id/androidjava/font-substitution/), atau [sematkan font](/slides/id/androidjava/embedded-font/) dalam presentasi.

**Dapatkah satu paragraf menggunakan beberapa bahasa pemeriksaan?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan dalam contoh paragraf multibahasa.

**Haruskah saya menggunakan `setDefaultTextLanguage` atau `setLanguageId`?**

Gunakan [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) ketika Anda menginginkan bahasa default untuk teks yang baru dibuat. Gunakan [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) ketika sebuah bagian spesifik memerlukan bahasa pemeriksaan eksplisit atau ketika sebuah paragraf berisi beberapa bahasa.