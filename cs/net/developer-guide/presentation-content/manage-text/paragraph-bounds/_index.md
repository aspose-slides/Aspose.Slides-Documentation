---
title: Získání hranic odstavce z prezentací v .NET
linktitle: Hranice odstavce
type: docs
weight: 43
url: /cs/net/paragraph-bounds/
keywords:
- hranice odstavce
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak v Aspose.Slides pro .NET získat hranice odstavce a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat hranice, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak získat obdélník odstavce z [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) pomocí [IParagraph.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getrect/), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky, a upozorňuje na důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na hranice, převod na pixely a efektivní hodnoty formátování odstavců.

## **Získání obdélníkových souřadnic odstavce**

Použijte [IParagraph.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getrect/) k získání ohraničujícího obdélníku odstavce.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Získání velikosti odstavce v textovém rámci buňky tabulky**

Pro získání velikosti a souřadnic [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/) v textovém rámci buňky tabulky použijte [IParagraph.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/getrect/). Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže při potřebě souřadnic na úrovni snímku přičtěte pozici tabulky a offset buňky.

Následující příklad získá hranice odstavce uvnitř buňky tabulky a nakreslí obdélníky na snímku pro vizualizaci těchto hranic:

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

## **Často kladené otázky**

**V jakých jednotkách jsou měřeny souřadnice odstavce?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. To platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu hranice odstavce?**

Ano. Pokud je pro [TextFrameFormat.WrapText](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/wraptext/) povoleno [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), text se zalomí tak, aby se vešel do šířky oblasti, což mění skutečné hranice odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely provedete pomocí vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylů?**

Použijte [effective paragraph formatting data structure](/slides/cs/net/shape-effective-properties/); vrací konečné sloučené hodnoty odsazení, mezery, zalamování, RTL a další.