---
title: Dapatkan Batas Bagian Teks dari Presentasi di .NET
linktitle: Batas Bagian
type: docs
weight: 47
url: /id/net/portion-bounds/
keywords:
- batas bagian teks
- bagian teks
- bagian teks
- koordinat teks
- posisi teks
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengambil batas bagian teks dalam presentasi PowerPoint menggunakan Aspose.Slides untuk .NET."
---
## **Gambaran Umum**

Bagian teks mewakili fragmen teks tertentu di dalam sebuah paragraf dan memungkinkan Anda bekerja dengan fragmen tersebut secara independen dari konten di sekitarnya. Dalam Aspose.Slides, bagian dapat digunakan ketika Anda perlu mengambil batas fragmen teks, menerapkan pemformatan hanya pada sebagian paragraf, atau mengontrol perilaku teks pada tingkat yang lebih rinci.

Artikel ini menunjukkan cara mendapatkan persegi panjang pembatas sebuah bagian dengan menggunakan [IPortion.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/getrect/). Artikel ini juga menunjukkan cara mendapatkan koordinat awal sebuah bagian dengan menggunakan [IPortion.GetCoordinates](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/getcoordinates/). Selain itu, artikel ini menyoroti skenario umum terkait bagian, seperti menerapkan hyperlink pada satu fragmen teks, memahami cara pemformatan diselesaikan melalui warisan bagian, paragraf, bingkai teks, dan tema, serta menangani kasus di mana font yang ditentukan tidak tersedia.

## **Dapatkan Batas Bagian Teks**

Gunakan [IPortion.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/getrect/) untuk mengambil persegi panjang pembatas sebuah bagian teks:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Dapatkan Koordinat Bagian Teks**

Gunakan [IPortion.GetCoordinates](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/getcoordinates/) untuk mengambil koordinat awal sebuah bagian teks:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Apakah saya dapat menerapkan hyperlink hanya pada sebagian teks dalam satu paragraf?**

Ya, Anda dapat [menetapkan hyperlink](/slides/id/net/manage-hyperlinks/) pada bagian individu; hanya fragmen itu yang akan dapat diklik, bukan seluruh paragraf.

**Bagaimana cara kerja pewarisan gaya: apa yang ditimpa oleh bagian, dan apa yang diambil dari paragraf atau bingkai teks?**

Properti pada tingkat bagian memiliki prioritas tertinggi. Jika sebuah properti tidak diatur pada [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/), Aspose.Slides mengambilnya dari [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/). Jika juga tidak diatur di sana, Aspose.Slides menggunakan gaya dari [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) atau [theme](https://reference.aspose.com/slides/id/net/aspose.slides.theme/theme/) .

**Apa yang terjadi jika font yang ditentukan untuk sebuah bagian tidak ada di mesin atau server target?**

[Aturan substitusi font](/slides/id/net/font-selection-sequence/) diterapkan. Teks dapat mengalir ulang: metrik, hyphenation, dan lebar dapat berubah, yang penting untuk penempatan yang tepat.

**Apakah saya dapat mengatur transparansi isian teks khusus bagian atau gradien secara terpisah dari sisa paragraf?**

Ya, warna teks, isian, dan transparansi pada tingkat [IPortion](https://reference.aspose.com/slides/id/net/aspose.slides/iportion/) dapat berbeda dari fragmen tetangga.