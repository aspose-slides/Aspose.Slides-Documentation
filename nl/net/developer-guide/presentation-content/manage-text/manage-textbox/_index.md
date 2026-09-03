---
title: Beheer tekstvakken in presentaties in .NET
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/net/manage-textbox/
keywords:
- tekstvak
- tekstkader
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

In Aspose.Slides for .NET wordt de tekst van dia's opgeslagen in tekstkaders die behoren tot vormen. De [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) interface vertegenwoordigt de meest voorkomende vorm die tekst bevat en maakt de tekst beschikbaar via de eigenschap [IAutoShape.TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/textframe/).

{{% alert color="info" title="Opmerking" %}}
Elke auto-vorm implementeert [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/), maar niet elke vorm is een auto-vorm of ondersteunt een tekstkader. Bij het verwerken van een bestaande presentatie controleer je of een vorm `IAutoShape` implementeert voordat je de tekst benadert.
{{% /alert %}}

## **Maak een Tekstvak op een Dia**

Om een tekstvak te maken, voeg je een auto-vorm toe aan een dia, voeg je tekst toe aan het tekstkader en sla je de presentatie op. Het volgende voorbeeld maakt een rechthoekig tekstvak:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

De coördinaten en afmetingen die aan [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addautoshape/) worden doorgegeven, worden gemeten in punten. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/addtextframe/) initialiseert het tekstkader met de opgegeven tekst.

## **Controleren op een Tekstvakvorm**

Gebruik de eigenschap [AutoShape.IsTextBox](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/istextbox/) om te bepalen of een auto-vorm wordt behandeld als een tekstvak. Dit is nuttig wanneer een presentatie zowel tekstdragende als puur grafische auto-vormen bevat.

![Een tekstvak en een vorm](istextbox.png)

Het volgende voorbeeld inspecteert elke auto-vorm in een presentatie:

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

Een nieuw toegevoegde auto-vorm wordt niet beschouwd als een tekstvak totdat deze niet-lege tekst bevat. Je kunt die tekst leveren via [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/addtextframe/) of [ITextFrame.Text](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/text/). Het toevoegen of toewijzen van een lege tekenreeks laat `IsTextBox` op `false` staan:

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

De eerste twee oproepen geven `True` weer; de laatste twee geven `False` weer.

## **Vind de Vorm die een Tekstkader Bezit**

Generieke tekstverwerkingscode kan een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) ontvangen zonder te weten welk presentatie-object het bevat. Gebruik de alleen-lezen eigenschap [ITextFrame.ParentShape](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentshape/) om terug te navigeren naar de bijbehorende [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/).

Voor een tekstkader dat eigendom is van een auto-vorm of een andere tekstdragende vorm, bevat `ParentShape` de eigenaar en is [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) `null`. Controleer de geretourneerde waarde voordat je deze benadert. Om zowel vorm- als tabelcel-eigenaren te identificeren, inclusief vormen die gekoppeld zijn aan SmartArt-knooppunten, zie [Zoeken en Vervangen van Tekst](/slides/nl/net/search-and-replace-text/).

## **Kolommen Toevoegen aan een Tekstvak**

De eigenschap [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/columncount/) verdeelt het tekstkader in kolommen, terwijl [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/columnspacing/) de ruimte tussen kolommen in punten instelt. Beide instellingen behoren tot [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/) en kunnen worden aangepast via het tekstkader van een bestaand tekstvak. Tekst wordt opnieuw verdeeld tussen kolommen binnen dezelfde vorm; het gaat niet verder naar een andere vorm.

Het volgende voorbeeld maakt een tekstvak met drie kolommen en 10 punten tussen de kolommen, slaat de presentatie op en leest de opgeslagen instellingen terug uit het uitvoerbestand:

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

## **Tekst Extracten uit Individuele Kolommen**

Gebruik [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/splittextbycolumns/) om de tekst op te halen die aan elke visuele kolom in een bestaand tekstkader is toegewezen. De methode retourneert één tekenreeks voor elke kolom, in kolomgebaseerde leesvolgorde. Een tekstkader met één kolom levert een array met één element op, en een lege kolom wordt weergegeven door een lege tekenreeks. De tekenreeksen bevatten alleen platte tekst; opgedeelde opmaak wordt niet bewaard.

Dit is nuttig wanneer je moet:
- Tekst extraheren terwijl de kolomgebaseerde leesvolgorde behouden blijft.
- De inhoud van dia's met meerdere kolommen indexeren of vergelijken.
- Elke kolom exporteren naar een apart bestand, database-veld of andere bestemming.
- Controleren hoe tekst opnieuw wordt verdeeld na het wijzigen van [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/columnspacing/), het lettertype of de grootte van het tekstkader.

De methode rapporteert de tekst die binnen het huidige [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) is verdeeld; het laat tekst niet automatisch vloeien tussen afzonderlijke vormen of tekstvakken. Kolomverdeling kan afhankelijk zijn van beschikbare lettertypen en andere tekst-lay-outinstellingen, dus zorg ervoor dat de benodigde lettertypen beschikbaar zijn wanneer consistente resultaten belangrijk zijn.

Het volgende voorbeeld laadt een presentatie, vindt de eerste auto-vorm met meerdere kolommen en een tekstkader, leest het geconfigureerde aantal kolommen, en schrijft de tekst van elke kolom naar een apart bestand. Vormen die geen tekstkader bieden, worden overgeslagen.

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

## **Tekst Bijwerken**

Om tekst in een hele presentatie bij te werken, doorloop je de dia's en vormen, selecteer je auto-vormen en bewerk je vervolgens hun tekstdelen. Werken op het niveau van delen stelt je in staat zowel tekst als teken-opmaak te wijzigen.

Het volgende voorbeeld vervangt elke instantie van `years` door `months` in auto-vormtekst en maakt elk getroffen deel vet:

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

Deze doorloop werkt alleen tekst bij in auto-vormen. Tekst die is opgeslagen in tabellen, grafieken, SmartArt of gegroepeerde vormen vereist een doorloop van de eigen collecties van die objecten.

## **Een Tekstvak Toevoegen met een Hyperlink**

Een hyperlink kan aan een specifiek tekstddeel worden toegewezen, zodat alleen die tekst als klikbare link fungeert. Gebruik [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) om het deel te koppelen aan een externe URL.

Het volgende voorbeeld maakt gelinkte tekst aan en slaat deze op in een presentatie:

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

Een [placeholder](/slides/nl/net/manage-placeholder/) kan zijn positie en opmaak overnemen van een [master‑dia](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslide/) of [layout‑dia](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/). Een regulier tekstvak is een onafhankelijke vorm op de dia waarop het is gemaakt en krijgt geen placeholder‑gedrag wanneer de lay‑out verandert.

**Hoe kan ik tekst vervangen zonder de tekst in grafieken, tabellen of SmartArt te wijzigen?**

Beperk de doorloop tot vormen die [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) implementeren, zoals getoond in het voorbeeld Tekst Bijwerken. Grafieken, tabellen en SmartArt slaan tekst op in hun eigen objectmodellen, dus die worden niet aangepast door die lus.