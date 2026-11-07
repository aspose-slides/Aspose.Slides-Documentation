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

Az Aspose.Slides for .NET-ben a diavetítés szövege szövegdobozokban (text frames) tárolódik, amelyek alakzatokhoz tartoznak. Az [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) interfész képviseli a leggyakoribb szöveget tartalmazó alakzatot, és a szövegét a [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) tulajdonságon keresztül teszi elérhetővé.

{{% alert color="info" title="Note" %}}
Minden automatikus alakzat megvalósítja a [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) interfészt, de nem minden alakzat automatikus alakzat, vagy támogatja a szövegdobozt. Egy meglévő prezentáció feldolgozásakor ellenőrizze, hogy az alakzat megvalósítja‑e a `IAutoShape`‑t, mielőtt hozzáférne a szövegéhez.
{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Szövegdoboz létrehozásához adjunk egy automatikus alakzatot a diára, szöveget a szövegdobozához, majd mentsük a prezentációt. A következő példa egy téglalap alakú szövegdobozt hoz létre:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Az [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/)‑nek átadott koordinátákat és méreteket pontban mérik. Az [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) inicializálja a szövegdobozt a megadott szöveggel.

## **Szövegdoboz alakzat ellenőrzése**

Használja a [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) tulajdonságot annak meghatározásához, hogy egy automatikus alakzat szövegdobozként van‑e kezelve. Ez akkor hasznos, amikor egy prezentáció szöveget tartalmazó és tisztán grafikus automatikus alakzatokat egyaránt tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

A következő példa minden automatikus alakzatot ellenőriz egy prezentációban:

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

Hozzáadott új automatikus alakzat csak akkor tekinthető szövegdoboznak, ha nem üres szöveget tartalmaz. A szöveget megadhatja az [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) vagy a [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése `IsTextBox`‑et `false`‑ra állítja:

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

## **Szövegdobozt birtokló alakzat megtalálása**

Az általános szövegfeldolgozó kód megkaphat egy [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) objektumot anélkül, hogy tudná, mely prezentációs objektum tartalmazza. Használja a csak‑olvasható [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) tulajdonságot a tulajdonos [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) visszanavigálásához.

Egy automatikus alakzat vagy más szöveget tartalmazó alakzat által birtokolt szövegdoboz esetén a `ParentShape` tartalmazza a tulajdonost, és az [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) `null`. Ellenőrizze a visszaadott értéket, mielőtt hozzáférne. A alakzat és a táblacella tulajdonosok, beleértve a SmartArt‑csomópontokhoz társított alakzatok azonosításához lásd a [Search and Replace Text](/slides/hu/net/search-and-replace-text/) oldalt.

## **Az alakzat szövegtéglalapjának lekérése**

Az Aspose.Slides for .NET 26.11‑től kezdve a [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) visszaadja a szövegterületet, amelyet a szülő alakzat geometriája definiál. Koordinátái és méretei pontban vannak, a alakzat bal‑felső sarkához képest. Például egy ellipszis szövegtéglalapja kisebb, mint a külső határa.

Ez a téglalap az alakzatot írja le, nem a megjelenített karaktereket. A szöveg vagy a szövegdoboz margóinak módosítása nem alakítja mérőeszközzé az elfoglalt szöveget. A megjelenített szöveg méréséhez használja a [paragraph bounds](/slides/hu/net/paragraph-bounds/) vagy a [portion bounds](/slides/hu/net/portion-bounds/) oldalakat.

A [installing Aspose.Slides for .NET](/slides/hu/net/installation/) 26.11 vagy újabb verzió telepítése után futtassa ezt a példát, hogy pirossal rajzolja meg a geometriai szövegtéglalapot. Az alakzatok nincsenek elforgatva és nem csoportosítva, ezért az X/Y pozíciójuk hozzáadásával elegendő a fedőréteg elhelyezése a dián.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

A fenti 200 × 100 point méretű alakzatok esetén a téglalap `(0, 0, 200, 100)` értéket ad vissza; az ellipszis körülbelül `(29.289, 14.645, 141.421, 70.711)`. A metódus egy egyedi geometria deklarált szövegtéglalapját is olvassa. Nem alkalmazza a diaterület forgatását vagy a csoporttranszformációkat; ezeket külön kell figyelembe venni a fedőréteg elhelyezésekor. A geometriai alakzat nélküli szövegdoboz, például egy táblacella szövegdoboz, `InvalidOperationException`‑t dobhat.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) tulajdonság oszlopokra osztja a szövegdobozt, míg az [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) pontban állítja be az oszlopok közötti távolságot. Mindkét beállítás az [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) része, és egy meglévő szövegdoboz szövegdobozán keresztül módosítható. A szöveg újraosztása az oszlopok között az ugyanabban az alakzatban történik; nem folytatódik egy másik alakzatra.

Az alábbi példa egy háromoszlopos szövegdobozt hoz létre, 10 pont távolsággal az oszlopok között, elmenti a prezentációt, és visszaolvassa a tárolt beállításokat a kimeneti fájlból:

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

Használja a [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) metódust, hogy visszakapja egy meglévő szövegdoboz minden vizuális oszlopához rendelt szöveget. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop alapú olvasási sorrendben. Egy egyoszlopos szövegdoboz egy elemű tömböt eredményez, és egy üres oszlop üres karakterláncként jelenik meg. A karakterláncok csak egyszerű szöveget tartalmaznak; a részlet‑szintű formázás nem kerül megőrzésre.

Ez akkor hasznos, ha szükség van a következőkre:
- Szöveg kinyerése úgy, hogy megmaradjon az oszlop‑alapú olvasási sorrend.
- Többoszlopos diák tartalmának indexelése vagy összehasonlítása.
- Az egyes oszlopok exportálása külön fájlba, adatbázismezőbe vagy más célra.
- Megvizsgálni, hogyan oszlik újra a szöveg a [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), a betűtípus vagy a szövegdoboz méretének módosítása után.

A metódus a jelenlegi [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)‑ben elosztott szöveget adja vissza; nem folyik automatikusan szöveg át más külön alakzatokra vagy szövegdobozokra. Az oszlopelrendezés függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg‑elrendezési beállításoktól, ezért biztosítsa, hogy a szükséges betűtípusok elérhetők legyenek, ha konzisztens eredmény fontos.

Az alábbi példa betölt egy prezentációt, megtalálja az első többoszlopos automatikus alakzatot szövegdobozzal, kiolvassa a konfigurált oszlopszámot, és az egyes oszlopok szövegét külön fájlba írja. A szövegdoboz nélküli alakzatok ki lesznek hagyva.

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

A szöveg frissítéséhez egy egész prezentációban iteráljon a diákon és alakzatokon, válassza ki az automatikus alakzatokat, majd szerkessze a szöveg‑részeiket. A részlet‑szinten történő munka lehetővé teszi a szöveg és a karakterformázás egyidejű módosítását.

Az alábbi példa minden `years` előfordulást `months`‑re cserél az automatikus alakzat szövegében, és minden érintett részt félkövérre állít:

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

Ez a bejárás csak az automatikus alakzatok szövegét frissíti. A táblákban, diagramokban, SmartArt‑ban vagy csoportos alakzatokban tárolt szöveg a megfelelő objektumgyűjtemények bejárását igényli.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Egy hiperhivatkozást egy adott szövegrészhez lehet rendelni, így csak az a szöveg lesz kattintható link. Használja az [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)‑t a rész külső URL‑hez való társításához.

Az alábbi példa összekapcsolt szöveget hoz létre, és egy prezentációba menti:

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

**Mi a különbség egy szövegdoboz és egy szöveghelyettesítő (placeholder) között egy mester vagy elrendezés dián?**

A [placeholder](/slides/hu/net/manage-placeholder/) örökölheti pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) alapján. Egy szabályos szövegdoboz egy független alakzat a dián, ahol létre lett hozva, és nem veszi fel a placeholder viselkedést, ha az elrendezés megváltozik.

**Hogyan cserélhetem ki a szöveget anélkül, hogy a diagramok, táblázatok vagy SmartArt szövegét módosítanám?**

Korlátozza a bejárást azokra az alakzatokra, amelyek megvalósítják a [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)-t, ahogy azt az Szöveg frissítése példában láthatja. A diagramok, táblázatok és a SmartArt saját objektummodelljükben tárolják a szöveget, ezért az a ciklus nem módosítja őket.