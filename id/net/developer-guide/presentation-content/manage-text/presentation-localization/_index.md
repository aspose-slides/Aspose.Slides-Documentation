---
title: Otomatisasi Lokalisasi Presentasi di .NET
linktitle: Lokalisasi Presentasi
type: docs
weight: 100
url: /id/net/presentation-localization/
keywords:
- ubah bahasa
- pemeriksaan ejaan
- nonaktifkan pemeriksaan ejaan
- bahasa pemeriksaan
- id bahasa
- teks multibahasa
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Tetapkan bahasa pemeriksaan untuk teks presentasi PowerPoint dan OpenDocument di .NET dengan Aspose.Slides, termasuk nilai default dan paragraf multibahasa."
---
## **Gambaran Umum**

Aspose.Slides for .NET memungkinkan Anda mengonfigurasi metadata pemeriksaan untuk bagian teks individu. Gunakan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/) untuk mengidentifikasi bahasa pemeriksaan, [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/spellcheck/) untuk mengizinkan atau menekan pemeriksaan ejaan, dan [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/proofdisabled/) untuk mengendalikan keadaan tidak‑pemeriksaan yang lebih luas. Karena pengaturan ini diterapkan pada tingkat bagian, satu paragraf dapat berisi beberapa bahasa dan aturan pemeriksaan yang berbeda.

Artikel ini menjelaskan cara menetapkan bahasa ke teks tertentu, mengatur bahasa default untuk teks baru dengan [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaulttextlanguage/), membuat paragraf multibahasa, memilih antara `SpellCheck` dan `ProofDisabled`, serta mempertahankan pengaturan yang dimaksud saat menggunakan [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/joinportionswithsameformatting/). Properti ini menyimpan metadata untuk aplikasi presentasi; mereka tidak menerjemahkan teks, melakukan pemeriksaan ejaan berbasis kamus, atau mengembalikan kata yang salah eja.

## **Atur Bahasa Pemeriksaan untuk Teks**

Buat atau muat sebuah [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/), akses bagian teks yang diperlukan melalui [IPortion.PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/portionformat/), dan tetapkan pengenal bahasa‑nya. Contoh berikut membuat sebuah shape, mengatur Bahasa Inggris Britania sebagai bahasa pemeriksaan, dan menyimpan hasilnya dengan [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **Atur Bahasa Default untuk Teks Baru**

Gunakan [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaulttextlanguage/) untuk menentukan bahasa pemeriksaan yang diberikan Aspose.Slides ke teks yang baru dibuat. Pengaturan ini berguna ketika sebagian besar atau semua teks baru dalam presentasi menggunakan bahasa yang sama. Ini tidak mengubah metadata bahasa pada teks yang sudah memiliki bahasa eksplisit.

Contoh berikut membuat sebuah presentasi yang teks barunya menggunakan aturan pemeriksaan bahasa Jerman:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **Gunakan Banyak Bahasa dalam Satu Paragraf**

Sebuah [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) berisi kumpulan bagian teks. Buat [Portion](https://reference.aspose.com/slides/id/net/aspose.slides/portion/) terpisah untuk setiap bahasa dan atur `LanguageId`‑nya secara independen.

Contoh ini membuat satu paragraf dengan bagian Bahasa Inggris dan Prancis:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **Aktifkan atau Nonaktifkan Pemeriksaan Ejaan untuk Bagian Individu**

[IPortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportionformat/) mewarisi properti teks umum yang didefinisikan oleh [IBasePortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/). Akses format sebuah bagian melalui [IPortion.PortionFormat](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/portionformat/) dan atur [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/spellcheck/) untuk mengendalikan apakah aplikasi presentasi dapat memeriksa ejaan untuk bagian tersebut. Nilai default adalah `false`: `true` mengizinkan pemeriksaan ejaan, sementara `false` menekannya.

Pengaturan ini berlaku untuk bagian teks individu. Bagian yang berbeda dalam paragraf yang sama dapat menggunakan nilai yang berbeda. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/languageid/) dan `SpellCheck` melayani tujuan yang saling melengkapi: `LanguageId` mengidentifikasi bahasa pemeriksaan, sementara `SpellCheck` menentukan apakah pemeriksaan ejaan diizinkan untuk bagian tersebut.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/id/net/aspose.slides/baseportionformat/proofdisabled/) juga mengontrol pemeriksaan, tetapi ia mewakili keadaan "jangan periksa" yang lebih luas sebagai [NullableBool](https://reference.aspose.com/slides/id/net/aspose.slides/nullablebool/). Gunakan `SpellCheck` ketika Anda membutuhkan saklar Boolean langsung khusus untuk pemeriksaan ejaan. Gunakan `ProofDisabled` ketika Anda perlu mempertahankan atau secara eksplisit mengendalikan metadata tidak‑pemeriksaan presentasi, termasuk keadaan `NotDefined`. Jika Anda mengatur kedua properti, pertahankan nilainya konsisten; jangan menggabungkan `SpellCheck = true` dengan `ProofDisabled = NullableBool.True`.

Properti ini mengonfigurasi metadata pemeriksaan yang digunakan oleh PowerPoint dan aplikasi presentasi lainnya. Aspose.Slides tidak menggunakan mereka untuk menjalankan pemeriksaan ejaan berbasis kamus atau mengembalikan daftar kata yang salah eja.

Contoh lengkap berikut membuat sebuah presentasi input, memuatnya, menetapkan pengaturan pemeriksaan ejaan dan bahasa pemeriksaan yang berbeda ke dua bagian dalam paragraf yang sama, menyimpan hasilnya, membukanya kembali, dan memverifikasi nilai yang disimpan:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/joinportionswithsameformatting/) menggabungkan bagian‑bagian berdekatan yang memiliki format yang sama. Perbedaan hanya pada `SpellCheck` tidak membuat bagian tersebut tetap terpisah; setelah digabung, bagian yang dihasilkan mempertahankan nilai `SpellCheck` dari bagian pertama. Jika bagian membutuhkan pengaturan pemeriksaan ejaan yang berbeda, panggil `JoinPortionsWithSameFormatting` sebelum menetapkan pengaturan tersebut, atau periksa batas‑batas bagian yang dihasilkan dan terapkan kembali pengaturan setelahnya. Bagian dengan nilai `LanguageId` yang berbeda tetap terpisah karena format bahasa pemeriksanya berbeda.

## **FAQ**

**Apakah ID bahasa menerjemahkan teks?**

Tidak. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/) menyimpan metadata pemeriksaan untuk ejaan dan tata bahasa; ia tidak mengubah isi teks. Terjemahkan teks secara terpisah, kemudian tetapkan pengenal bahasa yang sesuai untuk setiap bagian yang telah diterjemahkan.

**Apakah bahasa pemeriksaan mengontrol font, penghubungan kata, atau pembungkus baris?**

Tidak. Pengidentifikasi bahasa digunakan untuk pemeriksaan. Rendering teks dan tata letak terutama bergantung pada [fonts](/slides/id/net/powerpoint-fonts/), sistem penulisan, dan pengaturan bingkai teks. Untuk rendering yang dapat diandalkan, sediakan font yang diperlukan, konfigurasikan [font substitution](/slides/id/net/font-substitution/), atau [embed fonts](/slides/id/net/embedded-font/) dalam presentasi.

**Bisakah satu paragraf menggunakan beberapa bahasa pemeriksaan?**

Ya. Tetapkan setiap bahasa ke bagian terpisah, seperti yang ditunjukkan dalam contoh paragraf multibahasa.

**Haruskah saya menggunakan `DefaultTextLanguage` atau `LanguageId`?**

Gunakan [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/id/net/aspose.slides/loadoptions/defaulttextlanguage/) ketika Anda menginginkan nilai default untuk teks yang baru dibuat. Gunakan [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseportionformat/languageid/) ketika sebuah bagian spesifik memerlukan bahasa pemeriksaan eksplisit atau ketika sebuah paragraf berisi banyak bahasa.