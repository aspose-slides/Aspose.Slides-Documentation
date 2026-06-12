---
title: Získání ohraničení odstavců z prezentací v .NET
linktitle: Odstavec
type: docs
weight: 60
url: /cs/net/paragraph/
keywords:
- ohraničení odstavce
- ohraničení části textu
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost části textu
- textový rámec
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak získat ohraničení odstavců a částí textu v Aspose.Slides pro .NET a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a částí textu v Aspose.Slides. Ukazuje, jak pomocí `GetRect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavce a části uvnitř textového rámce buňky tabulky a zdůrazňuje důležité podrobnosti, jako jsou měrné jednotky, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavce.

## **Získání souřadnic odstavce a části v TextFrame**
Pomocí Aspose.Slides pro .NET mohou vývojáři nyní získat obdélníkové souřadnice pro odstavec uvnitř kolekce odstavců v TextFrame. Umožňuje také získat souřadnice části uvnitř kolekce částí odstavce. V tomto tématu ukážeme na příkladu, jak získat obdélníkové souřadnice odstavce spolu s pozicí části uvnitř odstavce.

## **Získání obdélníkových souřadnic odstavce**
Byla přidána nová metoda **GetRect()**. Umožňuje získat obdélník ohraničení odstavce.

```c#
// Vytvořte objekt Presentation, který představuje soubor prezentace
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Získání velikosti odstavce a části uvnitř textového rámce buňky tabulky**
Pro získání velikosti a souřadnic [Portion](https://reference.aspose.com/slides/cs/net/aspose.slides/portion) nebo [Paragraph](https://reference.aspose.com/slides/cs/net/aspose.slides/paragraph) v textovém rámci buňky tabulky můžete použít metody [IPortion.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iportion/methods/getrect) a [IParagraph.GetRect](https://reference.aspose.com/slides/cs/net/aspose.slides/iparagraph/methods/getrect).

Tento ukázkový kód demonstruje popsanou operaci:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny souřadnice odstavce a částí textu?**

V bodech, kde 1 palec = 72 bodů. To platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je v [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/textframe/) povoleno [wrapping](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/wraptext/), text se rozbije tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely provádějte pomocí: pixels = points × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení/export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylů?**

Použijte [effective paragraph formatting data structure](/slides/cs/net/shape-effective-properties/); vrátí konečné konsolidované hodnoty pro odsazení, mezerování, zalamování, RTL a další.