---
title: Získání ohraničení textových částí z prezentací v .NET
linktitle: Ohraničení části
type: docs
weight: 47
url: /cs/net/portion-bounds/
keywords:
- hranice textové části
- textová část
- textový úsek
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak získat ohraničení textových částí v prezentacích PowerPoint pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Textová část představuje konkrétní úsek textu uvnitř odstavce a umožňuje pracovat s tímto úsekem nezávisle na okolním obsahu. V Aspose.Slides lze části používat, když potřebujete získat ohraničení úseku textu, použít formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník části pomocí [IPortion.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/getrect/). Také ukazuje, jak získat souřadnice začátku části pomocí [IPortion.GetCoordinates](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/getcoordinates/). Kromě toho zdůrazňuje běžné scénáře související s částmi, jako je aplikace hypertextového odkazu na jediný úsek textu, pochopení, jak je formátování řešeno prostřednictvím dědičnosti částí, odstavců, textových rámců a motivu, a řešení situací, kdy je požadované písmo nedostupné.

## **Získání ohraničení textové části**

Použijte [IPortion.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/getrect/) k získání ohraničujícího obdélníku textové části:

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

## **Získání souřadnic textové části**

Použijte [IPortion.GetCoordinates](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/getcoordinates/) k získání souřadnic začátku textové části:

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

## **Často kladené otázky**

**Mohu aplikovat hypertextový odkaz pouze na část textu v jediném odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/net/manage-hyperlinks/) k jednotlivé části; pouze tento úsek bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co část přepisuje a co je převzato z odstavce nebo textového rámce?**

Vlastnosti na úrovni části mají nejvyšší přednost. Pokud není vlastnost nastavena na [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/), Aspose.Slides ji převezme z [IParagraph](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/). Pokud není nastavena ani zde, Aspose.Slides použije styl z [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) nebo [theme](https://reference.aspose.com/slides/cs/net/aspose.slides.theme/theme/).

**Co se stane, pokud je písmo určené pro část na cílovém počítači nebo serveru chybějící?**

[Pravidla nahrazování písem](/slides/cs/net/font-selection-sequence/) se použijí. Text se může přetvořit: metriky, dělení slov a šířka se mohou změnit, což má vliv na přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo přechod specifické pro část nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [IPortion](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/) se mohou lišit od sousedních úseků.