---
title: Hantera SmartArt i PowerPoint-presentationer i .NET
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/net/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för .NET med tydliga C#-kodexempel som påskyndar bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som är gjort av noder, nodformer och en layout. Med Aspose.Slides för .NET kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, undersöka dolda noder, konfigurera organisationskartslayouter och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa text från nodformerna, iterera genom [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), och läs sedan [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) som returneras av [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

Exemplet kräver en presentation med minst en bild och ett SmartArt-objekt som den första formen på den bilden. Det skriver ut varje tillgänglig textram till konsolen.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Ändra layouttyp för ett SmartArt-objekt**

SmartArt-layouten styr hur noder arrangeras och kopplas samman. Följande exempel skapar ett SmartArt-objekt med värdet `BasicBlockList` från [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), ändrar det till värdet `BasicProcess` och sparar presentationen. Positionen och storleken som skickas till [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) mäts i punkter. Ställ in [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) för att ändra layouten.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Kontrollera om en SmartArt-nod är dold**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) anger om noden är dold i SmartArt-datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramdelar.

Följande exempel lägger till en nod i ett SmartArt-objekt som använder värdet `RadialCycle` från [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/), och kontrollerar den tillagda nodens dolda tillstånd. Det skriver ut ett meddelande om noden är dold och sparar diagrammet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Hämta eller ange organisationskartslayouten**

För SmartArt-diagram som använder en organisationskartslayout definierar [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) hur barnnoder arrangeras under en föräldranod. Till exempel kan du låta barnnoder hänga från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och ställer in layouten för den första noden till värdet `LeftHanging` från [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/). Det nollbaserade indexet `0` väljer den första toppnivånoden; dess barnnoder använder den valda arrangemanget. Den modifierade presentationen sparas sedan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Skapa ett bildorganisationsdiagram**

Ett bildorganisationsdiagram är en SmartArt-layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd värdet `PictureOrganizationChart` från [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) när du lägger till SmartArt-objektet på en bild. Detta exempel sparar ett diagram med bildplatshållare; det fyller inte i platshållarna med bilder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Konvertera äldre diagram till grupper av former**

När du moderniserar en befintlig presentation kan du behöva uppdatera ett organisationsdiagram som ursprungligen skapades i PowerPoint 97–2003. Aspose.Slides representerar dessa äldre diagram som [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/)‑objekt. Använd [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) för att konvertera ett diagram till en grupp av former så att du kan redigera enskilda visuella element. Se [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) för detaljer.

Konverteringen lägger till en ny grupp i formsamlingen utan att ta bort det ursprungliga diagrammet. Efter en lyckad konvertering, ta bort det ursprungliga med [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) för att undvika dubbelt innehåll. Samla de äldre diagrammen i en array innan du konverterar dem så att tillägg och borttagning av former inte stör iterationen.

Följande exempel öppnar en presentation, söker igenom varje bild, konverterar diagrammen till grupper av former och sparar den uppdaterade presentationen som PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Den sparade presentationen innehåller redigerbara grupper av former i stället för de konverterade äldre diagrammen, utan några ursprungliga diagram kvar bredvid dem. Öppna PPTX-filen i PowerPoint för att redigera enskilda element inom varje grupp, såsom deras text, fyllning eller position.

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Egenskapen [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) växlar diagramriktningen från vänster-till-höger till höger-till-vänster, eller tillbaka, när den valda SmartArt-layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt-formen](/slides/sv/net/shape-manipulations/) med [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) eller [klona hela bilden](/slides/sv/net/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/net/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt-objekt på en bild om det finns flera?**

Ange ett distinkt [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) eller [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/)‑värde på SmartArt‑formen, sök efter det värdet i [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), och kontrollera sedan att den matchande formen är en [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).