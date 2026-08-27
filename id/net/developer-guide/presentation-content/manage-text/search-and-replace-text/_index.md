---
title: Cari dan Ganti Teks dalam Presentasi PowerPoint di .NET
linktitle: Cari dan Ganti Teks
type: docs
weight: 55
url: /id/net/search-and-replace-text/
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
- .NET
- C#
- Aspose.Slides
description: "Cari, sorot, dan ganti teks dalam presentasi PowerPoint sambil mengumpulkan setiap kecocokan dengan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Aspose.Slides for .NET dapat mencari, menyorot, dan mengganti teks dalam satu frame teks atau di seluruh presentasi. Setiap operasi juga dapat memberi tahu aplikasi tentang setiap kecocokan melalui callback hasil. Hal ini memungkinkan pembaruan presentasi sekaligus membangun jejak audit yang berisi teks yang cocok, konteksnya, posisi, frame teks, dan nomor slide.

Kemampuan ini berguna untuk tinjauan, redaksi, pemeriksaan terminologi, pembersihan templat, dan alur kerja pelaporan otomatis.

Pada contoh pertama di bawah, kami menggunakan file bernama "sample.pptx", yang berisi satu kotak teks pada slide pertama dengan teks berikut:

![Sample text](sample_text.png)

## **Pilih Lingkup Pencarian**

Gunakan metode pada [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) untuk membatasi operasi ke satu frame teks. Gunakan metode pada [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) untuk memproses semua teks yang berlaku dalam presentasi.

| Operasi | Satu frame teks | Seluruh presentasi |
|---|---|---|
| Sorot teks literal | [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/) | [Presentation.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlighttext/) |
| Sorot kecocokan ekspresi reguler | [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/) | [Presentation.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlightregex/) |
| Ganti teks literal | [ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/) | [Presentation.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replacetext/) |
| Ganti kecocokan ekspresi reguler | [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) | [Presentation.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replaceregex/) |

## **Konfigurasikan Pencocokan Teks**

Untuk operasi teks literal, gunakan [TextSearchOptions](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/) untuk mengontrol pencocokan:

- [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/wholewordsonly/) membatasi kecocokan hanya pada kata lengkap.
- [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/casesensitive/) mengatur apakah huruf besar/kecil harus cocok.
- [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/includenotes/) menyertakan catatan slide dalam pencarian, penggantian, dan operasi sorotan tingkat presentasi.

Operasi ekspresi reguler menggunakan `Regex` .NET, sehingga aturan pencocokan seperti sensitivitas huruf dan batas kata didefinisikan oleh pola dan opsinya.

## **Identifikasi Pemilik Frame Teks**

Alur kerja pemrosesan teks umum sering menerima sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) saat mencari, mengganti, memvalidasi, atau mengekspor teks. Gunakan [ITextFrame.ParentShape](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentshape/) dan [ITextFrame.ParentCell](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentcell/) untuk menentukan objek presentasi mana yang memiliki frame teks tersebut.

Nilai yang diharapkan bergantung pada pemiliknya:

| Pemilik frame teks | `ParentShape` | `ParentCell` |
|---|---|---|
| AutoShape atau bentuk lain yang berisi teks | [IShape](https://reference.aspose.com/slides/id/net/aspose.slides/ishape/) pemiliknya | `null` |
| Sel tabel | `null` | [ICell](https://reference.aspose.com/slides/id/net/aspose.slides/icell/) pemiliknya |

Kedua properti bersifat read‑only. Membacanya tidak memindahkan frame teks atau mengubah pemiliknya. Kode generik harus memeriksa kedua nilai untuk `null` dan menangani kemungkinan bahwa tidak ada pemilik yang tersedia.

Contoh berikut menggunakan [SlideUtil.GetAllTextFrames](https://reference.aspose.com/slides/id/net/aspose.slides.util/slideutil/getalltextframes/) untuk mengiterasi frame teks dalam sebuah presentasi. Untuk bentuk, ia melaporkan nama bentuk, tipe bentuk, dan slide yang memuatnya. Untuk sel tabel, ia melaporkan koordinat kolom dan baris berbasis nol serta slide yang memuatnya.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation("presentation.pptx");

var textFrames = SlideUtil.GetAllTextFrames(presentation, false);

foreach (var textFrame in textFrames)
{
    var ownerShape = textFrame.ParentShape;
    if (ownerShape != null)
    {
        var shapeName = string.IsNullOrEmpty(ownerShape.Name) ? "(unnamed)" : ownerShape.Name;
        var shapeType = GetShapeType(ownerShape);
        var slideLabel = GetSlideLabel(ownerShape.Slide);
        Console.WriteLine($"Shape: {shapeName}; type: {shapeType}; {slideLabel}");

        continue;
    }

    var ownerCell = textFrame.ParentCell;
    if (ownerCell != null)
    {
        var slideLabel = GetSlideLabel(ownerCell.Slide);
        Console.WriteLine($"Table cell: column {ownerCell.FirstColumnIndex}, row {ownerCell.FirstRowIndex}; {slideLabel}");
        continue;
    }

    Console.WriteLine("The text frame owner is not available as a shape or table cell.");
}

static string GetShapeType(IShape shape)
{
    if (shape is IGeometryShape geometryShape)
    {
        return geometryShape.ShapeType.ToString();
    }

    return shape.GetType().Name;
}

static string GetSlideLabel(IBaseSlide baseSlide)
{
    if (baseSlide is ISlide slide)
    {
        return $"slide {slide.SlideNumber}";
    }

    if (baseSlide is INotesSlide notesSlide)
    {
        return $"notes for slide {notesSlide.ParentSlide.SlideNumber}";
    }

    return baseSlide.GetType().Name;
}
```

Untuk konten SmartArt, iterasikan bentuk dalam [ISmartArtNode.Shapes](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartartnode/shapes/) dan akses setiap [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/id/net/aspose.slides.smartart/ismartartshape/textframe/). Frame teks dapat ditelusuri ke bentuk terkait melalui [ITextFrame.ParentShape](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentshape/), sementara [ITextFrame.ParentCell](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/parentcell/) bernilai `null`. Oleh karena itu, cabang bentuk dalam contoh juga menangani teks dari node SmartArt.

## **Kumpulkan Informasi Kecocokan dengan Callback**

Implementasikan [IFindResultCallback](https://reference.aspose.com/slides/id/net/aspose.slides/ifindresultcallback/) untuk menerima notifikasi pada setiap kecocokan. Metode [IFindResultCallback.FoundResult](https://reference.aspose.com/slides/id/net/aspose.slides/ifindresultcallback/foundresult/) menyediakan frame teks terkait, teks sumber, teks yang cocok, dan posisi kecocokan.

Callback tidak menerima nomor slide secara langsung. Implementasi di bawah ini menurunkannya dari slide induk dan juga menangani teks yang ditemukan di catatan slide. Nomor slide yang dapat bernilai null memungkinkan model hasil yang sama merepresentasikan teks yang terkait dengan tipe slide lain.

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
        var parentSlide = textFrame.ParentShape?.Slide ?? textFrame.ParentCell?.Slide ?? textFrame.Slide;

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

Untuk operasi penggantian, `FoundText` berisi teks asli yang cocok, sehingga callback dapat mencatat istilah mana yang diganti.

## **Sorot Teks**

Gunakan metode [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/) untuk menyorot kecocokan teks literal dalam sebuah frame teks. Berikan [TextSearchOptions](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/) untuk mengontrol pencarian dan sebuah callback untuk mengumpulkan detail kecocokan.

Contoh kode di bawah menyorot semua kemunculan karakter **"try"** dan kemudian hanya menyorot kata lengkap **"to"**. Kedua pencarian melaporkan kecocokannya ke callback yang sama.

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");

// Dapatkan bentuk pertama dari slide pertama.
var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
var callback = new TextSearchCallback();

var substringSearchOptions = new TextSearchOptions
{
    CaseSensitive = false
};

// Sorot setiap kemunculan "try" dalam frame teks.
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

![The highlighted text](highlighted_text.png)

## **Sorot Teks Menggunakan Ekspresi Reguler**

Metode [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/) menyorot kecocokan teks yang ditemukan oleh ekspresi reguler dalam sebuah frame teks.

Kode berikut menyorot semua kata yang mengandung tujuh karakter atau lebih dan mengumpulkan tiap kecocokan:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Sorot Teks di Seluruh Presentasi**

Gunakan [Presentation.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlighttext/) dan [Presentation.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/highlightregex/) untuk mencari semua frame teks yang berlaku dalam sebuah presentasi. Contoh berikut menyorot istilah literal dan semua alamat email sekaligus, dengan koleksi hasil terpisah untuk masing‑masing pencarian.

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

## **Ganti Teks dalam Frame Teks**

Gunakan [ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/) untuk teks literal dan [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) untuk penggantian berbasis pola. Metode ini memperbarui teks yang cocok di dalam frame teks yang ada, sehingga mempertahankan pemformatan bagian di sekitarnya alih‑alih membangun ulang frame teks dari string polos.

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

Jika satu kecocokan mencakup bagian dengan pemformatan berbeda, tinjau output untuk memastikan pemformatan mana yang harus diterapkan pada teks pengganti.

## **Ganti Teks di Seluruh Presentasi**

Gunakan [Presentation.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replacetext/) dan [Presentation.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/replaceregex/) untuk menerapkan operasi yang sama di seluruh presentasi. Ini berguna untuk pembersihan templat, pembaruan terminologi, dan redaksi.

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

Karena setiap hasil menyimpan nomor slide dan frame teks, aplikasi dapat mengelompokkan kecocokan untuk audit, pelaporan, atau alur kerja peninjauan. Contoh berikut mengelompokkan hasil yang dikumpulkan pertama per slide lalu per frame teks:

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

**Bagaimana saya dapat mencari hanya satu kotak teks saja, bukan seluruh presentasi?**

Dapatkan frame teks bentuk tersebut dan panggil [ITextFrame.HighlightText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlighttext/), [ITextFrame.HighlightRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/highlightregex/), [ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/), atau [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) pada frame teks itu. Metode tingkat presentasi memproses semua frame teks yang berlaku.

**Bagaimana saya dapat mencocokkan kata lengkap dengan kapitalisasi yang tepat?**

Atur [TextSearchOptions.WholeWordsOnly](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/wholewordsonly/) dan [TextSearchOptions.CaseSensitive](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/casesensitive/) menjadi `true`, lalu berikan opsi tersebut ke metode sorotan atau penggantian teks literal. Untuk ekspresi reguler, definisikan batas kata dan sensitivitas huruf dalam `Regex` .NET itu sendiri.

**Apakah pencarian dan penggantian dapat menyertakan teks dalam catatan slide?**

Ya. Atur [TextSearchOptions.IncludeNotes](https://reference.aspose.com/slides/id/net/aspose.slides/textsearchoptions/includenotes/) menjadi `true` saat menggunakan operasi teks literal tingkat presentasi. Implementasi callback yang ditunjukkan di atas memetakan kecocokan pada slide catatan kembali ke nomor slide induknya.

**Bagaimana saya dapat membuat laporan tanpa memindai presentasi lagi?**

Berikan implementasi [IFindResultCallback](https://reference.aspose.com/slides/id/net/aspose.slides/ifindresultcallback/) ke operasi sorotan atau penggantian. Callback menerima setiap kecocokan saat operasi berjalan, sehingga aplikasi dapat menyimpan teks sumber, teks yang cocok, posisi, frame teks, dan nomor slide yang diturunkan untuk pengelompokan atau ekspor selanjutnya.

**Apakah penggantian teks mempertahankan pemformatannya?**

[ITextFrame.ReplaceText](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replacetext/) dan [ITextFrame.ReplaceRegex](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/replaceregex/) memodifikasi teks yang cocok di dalam frame teks yang ada dan mempertahankan pemformatan bagian di sekitarnya. Jika kecocokan mencakup bagian dengan pemformatan berbeda, periksa hasilnya untuk memastikan penggantian menggunakan gaya yang diinginkan.