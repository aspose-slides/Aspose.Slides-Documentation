---
title: Dapatkan Batas Paragraf dari Presentasi di .NET
linktitle: Batas Paragraf
type: docs
weight: 43
url: /id/net/paragraph-bounds/
keywords:
- batas paragraf
- koordinat paragraf
- ukuran paragraf
- bingkai teks
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Pelajari cara mengambil batas paragraf di Aspose.Slides untuk .NET guna mengoptimalkan penempatan teks dalam presentasi PowerPoint."
---
## **Ikhtisar**

Artikel ini menjelaskan cara mendapatkan batas, ukuran, dan koordinat paragraf dalam Aspose.Slides. Artikel ini menunjukkan cara mengambil persegi panjang paragraf dari sebuah [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/) dengan menggunakan [IParagraph.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getrect/), cara mendapatkan koordinat paragraf di dalam bingkai teks sel tabel, dan menyoroti detail penting seperti satuan pengukuran, efek pembungkus teks pada batas, konversi piksel, dan nilai format paragraf yang efektif.

## **Dapatkan Koordinat Persegi Panjang Paragraf**

Gunakan [IParagraph.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getrect/) untuk mendapatkan persegi panjang pembatas sebuah paragraf.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Dapatkan Ukuran Paragraf di Dalam TextFrame Sel Tabel**

Untuk mendapatkan ukuran dan koordinat sebuah [IParagraph](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/) di dalam text frame sel tabel, gunakan [IParagraph.GetRect](https://reference.aspose.com/slides/id/net/aspose.slides/iparagraph/getrect/). Persegi panjang yang dikembalikan bersifat relatif terhadap text frame sel tabel, jadi tambahkan posisi tabel dan offset sel ketika Anda membutuhkan koordinat pada tingkat slide.

Contoh berikut mendapatkan batas paragraf di dalam sel tabel dan menggambar persegi panjang pada slide untuk memvisualisasikan batas tersebut:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Dalam satuan apa koordinat paragraf diukur?**

Koordinat diukur dalam point, di mana 1 inci sama dengan 72 point. Ini berlaku untuk semua koordinat dan dimensi pada slide.

**Apakah pembungkus kata memengaruhi batas paragraf?**

Ya. Jika [TextFrameFormat.WrapText](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat/wraptext/) diaktifkan untuk [ITextFrame](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/), teks akan dipotong agar sesuai dengan lebar area, yang mengubah batas aktual paragraf.

**Apakah koordinat paragraf dapat dipetakan secara andal ke piksel dalam gambar yang diekspor?**

Ya. Konversikan point ke piksel menggunakan rumus berikut: pixels = points × (DPI / 72). Hasilnya tergantung pada DPI yang dipilih untuk rendering atau ekspor.

**Bagaimana cara mendapatkan parameter format paragraf "effective", dengan mempertimbangkan pewarisan gaya?**

Gunakan [effective paragraph formatting data structure](/slides/id/net/shape-effective-properties/); ini mengembalikan nilai akhir yang terkonsolidasi untuk indentasi, spasi, pembungkusan, RTL, dan lainnya.