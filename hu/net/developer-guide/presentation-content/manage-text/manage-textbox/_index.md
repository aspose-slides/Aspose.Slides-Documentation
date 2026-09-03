---
title: Szövegdobozok kezelése prezentációkban .NET-ben
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/net/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for .NET használatával."
---
## **Bevezetés**

Az Aspose.Slides for .NET-ben a dia szövege szövegkeretekben tárolódik, amelyek alakzatokhoz tartoznak. Az [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) interfész képviseli a leggyakoribb szöveget tartalmazó alakzatot, és a szövegét a [IAutoShape.TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/textframe/) tulajdonságon keresztül teszi elérhetővé.

{{% alert color="info" title="Note" %}}
Minden auto alakzat megvalósítja az [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) interfészt, de nem minden alakzat auto alakzat, vagy támogat szövegkeretet. Egy meglévő prezentáció feldolgozásakor ellenőrizze, hogy egy alakzat implementálja-e a `IAutoShape`-t, mielőtt hozzáférne a szövegéhez.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Szövegdoboz létrehozásához adjon egy auto alakzatot a diához, szöveget az alakzat szövegkeretéhez, majd mentse a prezentációt. Az alábbi példa egy téglalap alakú szövegdobozt hoz létre:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Az [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addautoshape/)‑nek átadott koordinátákat és méreteket pontban mérik. Az [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/addtextframe/) inicializálja a szövegkeretet a megadott szöveggel.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [AutoShape.IsTextBox](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/istextbox/) tulajdonságot annak meghatározására, hogy egy auto alakzat szövegdobozként legyen kezelve. Ez akkor hasznos, ha egy prezentáció szöveget tartalmazó és kizárólag grafikus auto alakzatokat egyaránt tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

Az alábbi példa minden auto alakzatot átvizsgál a prezentációban:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Egy újonnan hozzáadott auto alakzat nem tekinthető szövegdoboznak, amíg nem tartalmaz nem üres szöveget. A szöveget megadhatja az [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/addtextframe/) vagy az [ITextFrame.Text](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/text/) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése esetén az `IsTextBox` értéke `false` marad:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Az első két hívás `True`‑t, az utolsó két hívás `False`‑t ír ki.

## **A szövegkeretet birtokló alakzat megtalálása**

Általános szövegfeldolgozó kód kaphat egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) példányt anélkül, hogy tudná, melyik prezentációs objektum tartalmazza azt. Használja a csak olvasható [ITextFrame.ParentShape](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentshape/) tulajdonságot a tulajdonos [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) visszakereséséhez.

Auto alakzathoz vagy más szöveget tartalmazó alakzathoz tartozó szövegkeret esetén a `ParentShape` a tulajdonost tartalmazza, míg az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) értéke `null`. Az érték felhasználása előtt ellenőrizze azt. A forma‑ és táblacella‑tulajdonosok, beleértve a SmartArt‑csomópontokhoz kapcsolódó alakzatokat, azonosításához lásd a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/columncount/) tulajdonság oszlopokra osztja a szövegkeretet, míg az [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/columnspacing/) beállítja az oszlopok közti hézagot pontban. Mindkét beállítás az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/) része, és módosítható egy meglévő szövegdoboz szövegkeretén keresztül. A szöveg az ugyanazon alakzaton belül áramlik az oszlopok között; nem folytatódik egy másik alakzatba.

Az alábbi példa háromoszlopos szövegdobozt hoz létre 10 pont oszloptávolsággal, menti a prezentációt, majd visszaolvassa a mentett beállításokat a kimeneti fájlból:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Szöveg kinyerése az egyes oszlopokból**

Használja a [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/hu/net/aspose.slides/textframe/splittextbycolumns/) metódust a meglévő szövegkeret egyes vizuális oszlopaihoz rendelt szöveg lekérésére. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop‑alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egy elemmel rendelkező tömböt eredményez, egy üres oszlop pedig egy üres karakterlánccal jelenik meg. A karakterláncok csak egyszerű szöveget tartalmaznak; a rész‑szintű formázás nem kerül megőrzésre.

Ez akkor hasznos, ha a következőkre van szükség:

- Szöveg kinyerése az oszlop‑alapú olvasási sorrend megőrzésével.
- Többoszlopos diák tartalmának indexelése vagy összehasonlítása.
- Minden oszlop exportálása külön fájlba, adatbázismezőbe vagy más célba.
- Annak vizsgálata, hogy a szöveg hogyan oszlik újra a [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/columncount/), a [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/columnspacing/), a betűtípus vagy a szövegkeret méretének módosítása után.

A metódus a jelenlegi [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/)‑ben elosztott szöveget jelenti; nem folyik automatikusan szöveg áramlás külön alakzatok vagy szövegdobozok között. Az oszlopeloszlás függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg‑elrendezési beállításoktól, ezért ügyeljen arra, hogy a szükséges betűtípusok elérhetők legyenek, ha konzisztens eredményekre van szükség.

Az alábbi példa betölti a prezentációt, megtalálja az első többoszlopos auto alakzatot szövegkerettel, kiolvassa a beállított oszlopszámot, és minden oszlop szövegét külön fájlba írja. A szövegkeretet nem biztosító alakzatok kihagyásra kerülnek.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Szöveg frissítése**

A szöveg frissítéséhez a prezentációban iteráljon a diákon és az alakzatokon, válassza ki az auto alakzatokat, majd szerkessze azok szövegrészeit. A rész‑szintű szerkesztés lehetővé teszi a szöveg és a karakterformázás együttes módosítását.

Az alábbi példa minden `years` előfordulást `months`‑re cserél az auto‑alakzatok szövegében, és a módosított részeket félkövérrel formázza:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Ez a bejárás csak az auto alakzatok szövegét módosítja. A táblákban, diagramokban, SmartArt‑ban vagy csoportos alakzatokban tárolt szöveg frissítéséhez ezeknek az objektumoknak a saját gyűjteményeit is be kell járni.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Hipertárcát egy adott szövegrészhez lehet rendelni, így csak az adott szöveg lesz kattintható. Használja az [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) metódust a rész külső URL‑hez való kötéséhez.

Az alábbi példa hivatkozással ellátott szöveget hoz létre, majd elmenti a prezentációba:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelytartó között egy mester‑ vagy elrendezésdian?**

Egy [helytartó](/slides/hu/net/manage-placeholder/) örökölheti a pozícióját és formázását egy [mester diától](https://reference.aspose.com/slides/hu/net/aspose.slides/masterslide/) vagy [elrendezésdiától](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslide/). Egy szokásos szövegdoboz független alakzat a dián, ahol létrehozták, és nem veszi át a helytartó viselkedését, ha az elrendezés megváltozik.

**Hogyan cserélhetem le a szöveget anélkül, hogy a diagramokban, táblázatokban vagy SmartArt‑ban lévő szöveget megváltoztatnám?**

Korlátozza a bejárást csak azokra az alakzatokra, amelyek implementálják a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) interfészt, ahogyan az **Szöveg frissítése** példában szerepel. A diagramok, táblázatok és SmartArt saját objektummodellben tárolják a szöveget, ezért azt a ciklus nem módosítja.