---
title: Beheer tekstvakken in presentaties in .NET
linktitle: Beheer Tekstvak
type: docs
weight: 20
url: /nl/net/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Maak, identificeer, formatteer en werk tekstvakken bij in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET."
---
## **Inleiding**

In Aspose.Slides for .NET wordt de tekst van dia’s opgeslagen in tekstframes die bij vormen behoren. De interface [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) vertegenwoordigt de meest voorkomende vorm met tekst en maakt de tekst toegankelijk via de eigenschap [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Note" %}}
Elke auto‑vorm implementeert [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), maar niet elke vorm is een auto‑vorm of ondersteunt een tekstframe. Bij het verwerken van een bestaande presentatie, controleer of een vorm `IAutoShape` implementeert voordat je de tekst benadert.
{{% /alert %}}

## **Een tekstvak op een dia maken**

Om een tekstvak te maken, voeg je een auto‑vorm toe aan een dia, voeg je tekst toe aan het tekstframe en sla je de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

De coördinaten en afmetingen die aan [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) worden doorgegeven, worden gemeten in points. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) initialiseert het tekstframe met de opgegeven tekst.

## **Controleren op een tekstvakvorm**

Gebruik de eigenschap [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/) om te bepalen of een auto‑vorm als een tekstvak wordt beschouwd. Dit is handig wanneer een presentatie zowel tekstdragende als uitsluitend grafische auto‑vormen bevat.

![Een tekstvak en een vorm](istextbox.png)

Het volgende voorbeeld inspecteert elke auto‑vorm in een presentatie:

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

Een nieuw toegevoegde auto‑vorm wordt pas als een tekstvak beschouwd zodra er niet‑lege tekst in staat. Je kunt die tekst leveren via [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) of [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/). Het toevoegen of toewijzen van een lege tekenreeks laat `IsTextBox` op `false` staan:

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

De eerste twee aanroepen geven `True` weer; de laatste twee geven `False` weer.

## **Zoek de vorm die een tekstframe bezit**

Generieke tekstverwerkingscode kan een [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) ontvangen zonder te weten welk presentatie‑object het bevat. Gebruik de alleen‑lezen‑eigenschap [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) om terug te navigeren naar de bijbehorende [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/).

Voor een tekstframe dat eigendom is van een auto‑vorm of een andere tekstdragende vorm, bevat `ParentShape` de eigenaar en is [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) `null`. Controleer de geretourneerde waarde voordat je er toegang toe krijgt. Om zowel vorm‑ als tabel‑cel‑eigenaars te identificeren, inclusief vormen die aan SmartArt‑knooppunten zijn gekoppeld, zie [Search and Replace Text](/slides/nl/net/search-and-replace-text/).

## **Haal de tekstrechthoek van de vorm op**

Vanaf Aspose.Slides for .NET 26.11 retourneert [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) het tekstgebied dat wordt gedefinieerd door de geometrie van de bovenliggende vorm. De coördinaten en afmetingen zijn in points, relatief ten opzichte van de linkerbovenhoek van die vorm. Een ellips heeft bijvoorbeeld een kleinere tekstrechthoek dan zijn buitenste omtrek.

Deze rechthoek beschrijft de vorm, niet de gerenderde tekens. Het wijzigen van de tekst of de marges van het tekstframe verandert het niet in een maat voor bezette tekst. Gebruik [paragraafgrenzen](/slides/nl/net/paragraph-bounds/) of [gedeeltesgrenzen](/slides/nl/net/portion-bounds/) voor metingen van gerenderde tekst.

Na het [installing Aspose.Slides for .NET](/slides/nl/net/installation/) 26.11 of later, voer je dit voorbeeld uit om de geometrie‑tekstrechthoek in rood te tekenen. De vormen zijn niet geroteerd en niet gegroepeerd, dus het toevoegen van hun X/Y‑positie is voldoende om de overlay op de dia te plaatsen.

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

Voor de 200 × 100‑point‑vormen hierboven retourneert de rechthoek `(0, 0, 200, 100)`; de ellips retourneert ongeveer `(29.289, 14.645, 141.421, 70.711)`. De methode leest ook de gedeclareerde tekstrechthoek van een aangepaste geometrie. De rotatie in dia‑ruimte of groeps‑transformaties worden niet toegepast; houd daar rekening mee bij het positioneren van een overlay. Een tekstframe zonder een geometrievorm, zoals een tabel‑cel‑tekstframe, kan een `InvalidOperationException` veroorzaken.

## **Kolommen toevoegen aan een tekstvak**

De eigenschap [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/) verdeelt het tekstframe in kolommen, terwijl [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) de ruimte tussen kolommen in points instelt. Beide instellingen behoren tot [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) en kunnen via het tekstframe van een bestaand tekstvak worden gewijzigd. Tekst stroomt opnieuw tussen kolommen binnen dezelfde vorm; het gaat niet verder naar een andere vorm.

Het volgende voorbeeld maakt een tekstvak met drie kolommen en 10 points tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

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

## **Tekst uit afzonderlijke kolommen extraheren**

Gebruik [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/) om de tekst op te halen die aan elke zichtbare kolom in een bestaand tekstframe is toegewezen. De methode retourneert één tekenreeks per kolom, in kolom‑gebaseerde leesvolgorde. Een tekstframe met één kolom geeft een array met één element terug, en een lege kolom wordt weergegeven door een lege tekenreeks. De tekenreeksen bevatten alleen platte tekst; opgedeelde‑niveau‑opmaak wordt niet behouden.

Dit is nuttig wanneer je:

- Tekst wilt extraheren met behoud van de kolomgebaseerde leesvolgorde.
- De inhoud van dia’s met meerdere kolommen wilt indexeren of vergelijken.
- Elke kolom wilt exporteren naar een afzonderlijk bestand, databaseveld of andere bestemming.
- Wilt inspecteren hoe tekst wordt herschikt na het wijzigen van [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), het lettertype of de grootte van het tekstframe.

De methode rapporteert de tekst die zich binnen het huidige [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) bevindt; hij laat tekst niet automatisch van de ene vorm naar de andere tekstvak stromen. Kolomverdeling kan afhangen van beschikbare lettertypen en andere tekst‑layout‑instellingen, dus zorg ervoor dat de vereiste lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, vindt de eerste auto‑vorm met meerdere kolommen en een tekstframe, leest het geconfigureerde aantal kolommen en schrijft de tekst van elke kolom naar een afzonderlijk bestand. Vormen die geen tekstframe bieden, worden overgeslagen.

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

## **Tekst bijwerken**

Om tekst in de gehele presentatie bij te werken, doorloop je de dia’s en vormen, selecteer je auto‑vormen en bewerk je vervolgens hun tekstgedeelten. Werken op het niveau van gedeelten maakt het mogelijk zowel tekst als teken­opmaak te wijzigen.

Het volgende voorbeeld vervangt elke vermelding van `years` door `months` in auto‑vorm‑tekst en maakt elk getroffen gedeelte vet:

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

Deze traversering werkt alleen tekst bij in auto‑vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist traversering van de eigen collecties van die objecten.

## **Een tekstvak met een hyperlink toevoegen**

Een hyperlink kan worden toegewezen aan een specifiek tekstgedeelte, zodat alleen die tekst als klikbare link fungeert. Gebruik [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) om het gedeelte te koppelen aan een externe URL.

Het volgende voorbeeld maakt gekoppelde tekst en slaat deze op in een presentatie:

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

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder op een master‑ of layout‑dia?**

Een [placeholder](/slides/nl/net/manage-placeholder/) kan zijn positie en opmaak overerven van een [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) of een [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/). Een regulier tekstvak is een zelfstandige vorm op de dia waarop het is gemaakt en krijgt geen placeholder‑gedrag wanneer de lay‑out wijzigt.

**Hoe kan ik tekst vervangen zonder tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de traversering tot vormen die [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) implementeren, zoals getoond in het voorbeeld Tekst bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, dus die worden niet aangepast door die lus.