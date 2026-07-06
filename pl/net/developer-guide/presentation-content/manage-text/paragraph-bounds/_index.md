---
title: Pobieranie granic akapitu z prezentacji w .NET
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/net/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu w Aspose.Slides dla .NET, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) przy użyciu [IParagraph.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getrect/), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersja pikseli oraz wartości efektywnego formatowania akapitu.

## **Uzyskaj prostokątne współrzędne akapitu**

Użyj [IParagraph.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getrect/) aby uzyskać prostokąt ograniczający akapit.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Uzyskaj rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) w ramce tekstowej komórki tabeli, użyj [IParagraph.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getrect/). Zwrócony prostokąt jest względny względem ramki tekstowej komórki tabeli, więc dodaj pozycję tabeli i offset komórki, gdy potrzebujesz współrzędnych na poziomie slajdu.

Poniższy przykład pobiera granice akapitu wewnątrz komórki tabeli i rysuje prostokąty na slajdzie, aby zwizualizować te granice:

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

**W jakich jednostkach mierzone są współrzędne akapitu?**

Są mierzone w punktach, gdzie 1 cal równa się 72 punktom. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [TextFrameFormat.WrapText](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/wraptext/) jest włączone dla [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), tekst jest dzielony, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przekształcić na piksele w wyeksportowanym obrazie?**

Tak. Przekształć punkty na piksele, używając następującego wzoru: piksele = punkty × (DPI / 72). Wynik zależy od wybranej rozdzielczości DPI podczas renderowania lub eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylów?**

Użyj [effective paragraph formatting data structure](/slides/pl/net/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.