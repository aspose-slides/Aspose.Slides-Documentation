---
title: Mencari dan Mengganti Teks dalam Presentasi PowerPoint di .NET
linktitle: Mencari dan Mengganti Teks
type: docs
weight: 55
url: /id/net/search-and-replace-text/
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
- .NET
- C#
- Aspose.Slides
description: "Mencari, menyorot, dan mengganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides for .NET dapat mencari, menyorot, dan mengganti teks dalam satu bingkai teks atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Ini memungkinkan memperbarui presentasi dan sekaligus membangun jejak audit yang berisi teks yang cocok, konteksnya, posisi, bingkai teks, dan nomor slide.

Kemampuan ini berguna untuk peninjauan, penyensoran, pemeriksaan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Pada contoh pertama di bawah ini, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Teks contoh](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) untuk membatasi operasi pada satu bingkai teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk memproses semua teks yang berlaku dalam presentasi.

| Operasi | Satu bingkai teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlighttext/) |
| Sorot kecocokan ekspresi reguler | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlightregex/) |
| Ganti teks literal | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replacetext/) |
| Ganti kecocokan ekspresi reguler | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replaceregex/) |

## **Konfigurasi Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/wholewordsonly/) membatasi kecocokan hanya pada kata lengkap.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/casesensitive/) mengontrol apakah huruf kapital harus cocok.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/includenotes/) menyertakan catatan slide dalam operasi pencarian, penggantian, dan penyorotan pada level presentasi.

Operasi ekspresi reguler menggunakan .NET `Regex`, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh ekspresi dan opsi-opsinya.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Implementasikan [IFindResultCallback](https://reference.aspose.com/slides/id/net/aspose.slides/ifindresultcallback/) untuk menerima notifikasi untuk setiap kecocokan. Metode [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/id/net/aspose.slides/ifindresultcallback/foundresult/)‑nya menyediakan bingkai teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah ini menurunkannya dari slide induk dan juga menangani teks yang ditemukan dalam catatan slide. Nomor slide yang dapat bernilai null memungkinkan model hasil yang sama merepresentasikan teks yang terkait dengan tipe slide lain.

```cs
using System.Collections.Generic;
using Aspose.Slides;

public sealed class TextMatch
{
    public TextMatch(ITextFrame textFrame, string sourceText, string foundText, int textPosition, int? slideNumber)
    {
        TextFrame = textFrame;
        SourceText = sourceText;
        FoundText = foundText;
        TextPosition = textPosition;
        SlideNumber = slideNumber;
    }

    public ITextFrame TextFrame { get; }
    public string SourceText { get; }
    public string FoundText { get; }
    public int TextPosition { get; }
    public int? SlideNumber { get; }
}

public sealed class TextSearchCallback : IFindResultCallback
{
    public List<TextMatch> Results { get; } = new();

    public void FoundResult(ITextFrame textFrame, string sourceText, string foundText, int textPosition)
    {
        var slideNumber = GetSlideNumber(textFrame);
        var result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);

        Results.Add(result);
    }

    private static int? GetSlideNumber(ITextFrame textFrame)
    {
        if (textFrame is not TextFrame concreteTextFrame)
        {
            return null;
        }

        var parentSlide = concreteTextFrame.Slide;

        if (parentSlide is ISlide slide)
        {
            return slide.SlideNumber;
        }

        if (parentSlide is INotesSlide notesSlide)
        {
            return notesSlide.ParentSlide.SlideNumber;
        }

        return null;
    }
}
```

Untuk operasi penggantian, `FoundText` berisi teks asli yang cocok, sehingga callback dapat mencatat dengan tepat istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/) untuk menyorot kecocokan teks literal dalam sebuah bingkai teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/) untuk mengontrol pencarian dan sebuah callback untuk mengumpulkan detail kecocokan.

Contoh kode di bawah ini menyorot semua kemunculan karakter **"try"** dan kemudian menyorot hanya kata lengkap **"to"**. Kedua pencarian melaporkan kecocokannya ke callback yang sama.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Dapatkan shape pertama dari slide pertama.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Sorot setiap kemunculan "try" dalam bingkai teks.
shape.TextFrame.HighlightText("try", Color.LightBlue, substringSearchOptions, callback);

var wholeWordSearchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

// Sorot hanya kata lengkap "to".
shape.TextFrame.HighlightText("to", Color.Violet, wholeWordSearchOptions, callback);

foreach (var result in callback.Results)
{
    Console.WriteLine($"Found '{result.FoundText}' at position {result.TextPosition} on slide {result.SlideNumber}.");
}

presentation.Save("highlighted_text.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Teks yang disorot](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah bingkai teks.

Kode berikut menyorot semua kata yang mengandung tujuh atau lebih karakter dan mengumpulkan setiap kecocokan:

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var regex = new Regex(@"\b[^\s]{7,}\b");

shape.TextFrame.HighlightRegex(regex, Color.Yellow, callback);

presentation.Save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
```

Hasilnya:

![Teks yang disorot menggunakan ekspresi reguler](highlighted_text_using_regex.png)

## **Sorot Teks Di Seluruh Presentasi**

Gunakan [Presentation.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlighttext/) dan [Presentation.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlightregex/) untuk mencari semua bingkai teks yang berlaku dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email sambil menjaga koleksi hasil terpisah untuk kedua pencarian.

```cs
using System.Drawing;
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var termCallback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

presentation.HighlightText("confidential", Color.Orange, searchOptions, termCallback);

var emailCallback = new TextSearchCallback();
var emailRegex = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b", RegexOptions.IgnoreCase);

presentation.HighlightRegex(emailRegex, Color.Yellow, emailCallback);

presentation.Save("highlighted_presentation.pptx", SaveFormat.Pptx);
```

## **Ganti Teks dalam Bingkai Teks**

Gunakan [ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/) untuk teks literal dan [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) untuk penggantian berbasis pola. Metode ini memperbarui teks yang cocok di dalam bingkai teks yang ada, yang mempertahankan format bagian sekitarnya alih-alih membangun ulang bingkai teks dari string biasa.

Contoh berikut menstandarkan varian ejaan dan kemudian mengganti label versi. Callback yang sama mencatat istilah asli yang cocok oleh kedua operasi.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = false
};

shape.TextFrame.ReplaceText("colour", "color", searchOptions, callback);

var versionRegex = new Regex(@"\bv\d+(?:\.\d+)*\b", RegexOptions.IgnoreCase);
shape.TextFrame.ReplaceRegex(versionRegex, "current version", callback);

presentation.Save("updated_text_frame.pptx", SaveFormat.Pptx);
```

Jika satu kecocokan mencakup bagian dengan format berbeda, tinjau output untuk memastikan format mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks Di Seluruh Presentasi**

Gunakan [Presentation.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replacetext/) dan [Presentation.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replaceregex/) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan penyensoran.

```cs
using System.Text.RegularExpressions;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var callback = new TextSearchCallback();
var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};

presentation.ReplaceText("Contoso", "Example Corp", searchOptions, callback);

var accountNumberRegex = new Regex(@"\bACCT-\d{6}\b");
presentation.ReplaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

presentation.Save("updated_presentation.pptx", SaveFormat.Pptx);
```

## **Kelompokkan Kecocokan untuk Pelaporan**

Karena setiap hasil menyimpan nomor slide dan bingkai teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja peninjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama per slide lalu per bingkai teks:

```cs
using System;
using System.Linq;

var matchesBySlide = callback.Results.GroupBy(result => result.SlideNumber);

foreach (var slideGroup in matchesBySlide)
{
    var slideLabel = slideGroup.Key.HasValue ? slideGroup.Key.Value.ToString() : "Other";
    Console.WriteLine($"Slide: {slideLabel}");

    var matchesByTextFrame = slideGroup.GroupBy(result => result.TextFrame);
    foreach (var textFrameGroup in matchesByTextFrame)
    {
        Console.WriteLine($"  Text frame: {textFrameGroup.Key.Text}");

        foreach (var result in textFrameGroup)
        {
            Console.WriteLine($"    '{result.FoundText}' at position {result.TextPosition}; context: '{result.SourceText}'");
        }
    }
}
```

## **FAQ**

**Bagaimana saya dapat mencari hanya satu kotak teks alih-alih seluruh presentasi?**

Dapatkan bingkai teks dari shape dan panggil [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/), atau [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) pada bingkai teks tersebut. Metode pada level presentasi memproses semua bingkai teks yang berlaku sebagai gantinya.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Atur [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/wholewordsonly/) dan [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/casesensitive/) menjadi `true`, dan berikan opsi tersebut ke metode penyorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `Regex` .NET itu sendiri.

**Bisakah pencarian dan penggantian mencakup teks dalam catatan slide?**

Ya. Atur [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/includenotes/) menjadi `true` saat menggunakan operasi teks literal pada level presentasi. Implementasi callback yang ditunjukkan di atas memetakan kecocokan dalam slide catatan kembali ke nomor slide induknya.

**Bagaimana saya dapat membuat laporan tanpa memindai presentasi untuk kedua kalinya?**

Berikan implementasi [IFindResultCallback](https://reference.aspose.com/slides/id/net/aspose.slides/ifindresultcallback/) ke operasi penyorotan atau penggantian. Callback menerima setiap kecocokan saat operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, bingkai teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor nanti.

**Apakah mengganti teks mempertahankan formatnya?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/) dan [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) mengubah teks yang cocok di dalam bingkai teks yang ada dan mempertahankan format bagian sekitarnya. Jika satu kecocokan mencakup bagian dengan format berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.