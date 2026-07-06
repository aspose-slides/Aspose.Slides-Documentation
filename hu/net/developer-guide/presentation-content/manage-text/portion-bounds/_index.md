---
title: Szövegrészlet határainak lekérése .NET-ben a bemutatókból
linktitle: Részlet határok
type: docs
weight: 47
url: /hu/net/portion-bounds/
keywords:
- szövegrészlet határok
- szövegrészlet
- szövegrész
- szöveg koordináták
- szöveg pozíció
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a szövegrészlet határait PowerPoint bemutatókban az Aspose.Slides for .NET használatával."
---
## **Áttekintés**

A szövegrészlet egy bekezdésen belüli konkrét szövegtöredéket képvisel, és lehetővé teszi, hogy a környező tartalomtól függetlenül dolgozzon azzal a töredékkel. Az Aspose.Slides-ban a részleteket akkor használhatja, amikor egy szövegtöredék határait szeretné lekérdezni, csak a bekezdés egy részére szeretne formázást alkalmazni, vagy részletesebb szinten szeretné irányítani a szöveg viselkedését.

Ez a cikk bemutatja, hogyan kaphatja meg egy részlet körülíró téglalapját a [IPortion.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getrect/) használatával. Emellett bemutatja, hogyan szerezheti meg egy részlet kezdetének koordinátáit a [IPortion.GetCoordinates](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getcoordinates/) segítségével. Továbbá kiemeli a gyakori, részletekkel kapcsolatos forgatókönyveket, mint például egy hiperhivatkozás alkalmazása egyetlen szövegtöredékre, a formázás feloldásának megértése a részlet, bekezdés, szövegkeret és téma öröklődése alapján, valamint a megadott betűtípus hiánya esetén történő kezelése.

## **A szövegrészlet határainak lekérése**

Használja a [IPortion.GetRect](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getrect/) metódust, hogy lekérje egy szövegrészlet körülíró téglalapját:

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

## **A szövegrészlet koordinátáinak lekérése**

Használja a [IPortion.GetCoordinates](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/getcoordinates/) metódust, hogy lekérje egy szövegrészlet kezdetének koordinátáit:

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

**Alkalmazhatok hiperhivatkozást csak egyetlen bekezdésen belül a szöveg egy részére?**

Igen, egy [hiperhivatkozás hozzárendelésével](/slides/hu/net/manage-hyperlinks/) egy egyedi részlethez; csak ez a töredék lesz kattintható, nem a teljes bekezdés.

**Hogyan működik a stílusöröklés: mit felülír egy részlet, és mi származik a bekezdésből vagy a szövegkeretből?**

Az egyes részletek szintjén meghatározott tulajdonságok a legmagasabb precedenciával bírnak. Ha egy tulajdonság nincs beállítva az [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/), az Aspose.Slides az [IParagraph](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraph/) elemtől veszi át. Ha ott sem van beállítva, az Aspose.Slides az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) vagy a [theme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/theme/) stílust használja.

**Mi történik, ha a részlethez megadott betűtípus hiányzik a célgép vagy szerver rendszerén?**

[A betűtípus-helyettesítési szabályok](/slides/hu/net/font-selection-sequence/) érvényesek. A szöveg újraelrendeződhet: a metrikák, elválasztás és a szélesség változhat, ami fontos a pontos pozicionálás szempontjából.

**Beállíthatok a részletre vonatkozó szövegtöltés átlátszóságot vagy színátmenetet a bekezdés többi részétől függetlenül?**

Igen, a szöveg színe, kitöltése és átlátszósága az [IPortion](https://reference.aspose.com/slides/hu/net/aspose.slides/iportion/) szintjén eltérhet a szomszédos töredékektől.