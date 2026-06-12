---
title: Přidání elips do prezentací v .NET
linktitle: Elipsa
type: docs
weight: 30
url: /cs/net/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- nakreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak vytvářet, formátovat a manipulovat s eliptickými tvary v Aspose.Slides pro .NET v prezentacích PPT a PPTX — včetně příkladů kódu v C#."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat eliptické tvary do snímků PowerPointu. Pokrývá vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Také se dotýká souvisejících otázek, jako je práce s pozicí a velikostí elipsy, řízení pořadí vrstev a aplikace animačních efektů.

## **Vytvoření elipsy**
Chcete‑li přidat jednoduchou elipsu na vybraný snímek prezentace, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class
2. Získejte odkaz na snímek pomocí jeho indexu
3. Přidejte AutoShape typu Ellipse pomocí metody AddAutoShape, která je k dispozici v objektu IShapes
4. Uložte upravenou prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme přidali elipsu na první snímek.

```c#
// Vytvořte instanci třídy Presentation, která představuje PPTX
using (Presentation pres = new Presentation())
{
    // Získejte první snímek
    ISlide sld = pres.Slides[0];

    // Přidejte automatický tvar typu elipsa
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Uložte soubor PPTX na disk
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Vytvoření formátované elipsy**
Pro přidání lépe formátované elipsy na snímek postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation)class
2. Získejte odkaz na snímek pomocí jeho indexu
3. Přidejte AutoShape typu Ellipse pomocí metody AddAutoShape, která je k dispozici v objektu IShapes
4. Nastavte typ výplně elipsy na Solid
5. Nastavte barvu elipsy pomocí vlastnosti SolidFillColor.Color, která je k dispozici v objektu FillFormat přidruženém k objektu IShape
6. Nastavte barvu čar elipsy
7. Nastavte šířku čar elipsy
8. Uložte upravenou prezentaci jako soubor PPTX

V níže uvedeném příkladu jsme přidali formátovanou elipsu na první snímek prezentace.

```c#
 // Vytvořte instanci třídy Presentation, která představuje PPTX
using (Presentation pres = new Presentation())
{

    // Získejte první snímek
    ISlide sld = pres.Slides[0];

    // Přidejte automatický tvar typu elipsa
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Použijte nějaké formátování na tvar elipsy
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Použijte nějaké formátování na čáru elipsy
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    // Uložte soubor PPTX na disk
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Jak nastavit přesnou pozici a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a velikosti se typicky uvádějí **v bodech**. Pro předvídatelné výsledky se zakládejte na velikosti snímku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládat pořadí vrstev)?**

Upravte pořadí vykreslování objektu tím, že jej přenesete do popředí nebo do pozadí. Tím umožníte, aby elipsa překrývala jiné objekty nebo odhalila ty pod ní.

**Jak animuji vzhled nebo důraz elipsy?**

[Použít](/slides/cs/net/shape-animation/) vstupní, zdůrazňovací nebo výstupní efekty na tvar a nakonfigurujte spouštěče a časování, aby bylo určeno, kdy a jak se animace přehrává.