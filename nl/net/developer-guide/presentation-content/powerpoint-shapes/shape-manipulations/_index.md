---
title: Beheer presentatie‑shapes in .NET
linktitle: Shape-manipulatie
type: docs
weight: 40
url: /nl/net/shape-manipulations/
keywords:
- PowerPoint‑shape
- presentatie‑shape
- shape op dia
- shape vinden
- shape klonen
- shape verwijderen
- shape verbergen
- shape‑volgorde wijzigen
- interop‑shape‑ID ophalen
- alternatieve tekst van shape
- shape‑aanpassingspunt
- preset‑shape‑aanpassing
- shape‑geometrie
- shape‑lay-out‑formaten
- shape als SVG
- shape naar SVG
- shape uitlijnen
- shape spiegelen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u presentatie‑shapes kunt identificeren, aanpassen, klonen, verwijderen, verbergen, opnieuw ordenen, exporteren, uitlijnen en spiegelen met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET stelt de shapes op een dia voor als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/). De collectie is zowel de plek waar je shapes vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de achterste shape, terwijl de laatste index de voorste shape is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een shape betrouwbaar kunt identificeren en vooraf ingestelde aanpassingspunten kunt wijzigen, vervolgens laat het zien hoe je shapes kunt klonen, verwijderen, verbergen en opnieuw ordenen. De laatste secties behandelen layout‑niveau opmaak, SVG‑export, uitlijning en spiegel‑instellingen. Elk voorbeeld is onafhankelijk, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeren en Vinden van Shapes**

Collectie‑indexen zijn handig tijdens het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of opnieuw ordenen van een shape kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is gemaakt en beheerd:

- [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/name/) is bruikbaar voor door ontwikkelaars beheerde templates en is eenvoudig te inspecteren in het Selectiepaneel van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie op als code daarvan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetext/) is handig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de shape al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilzwijgend als database‑sleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/officeinteropshapeid/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een eenduidige referentie nodig hebt gedurende de levensduur van een shape. Een gekloonde of opnieuw aangemaakte shape is een andere shape en krijgt een eigen ID.

De gerelateerde eigenschap [UniqueId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/uniqueid/) heeft een presentatie‑omvang, maar is bedoeld voor add‑ins en kan opnieuw toegewezen worden. Beschouw het niet als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar dan de mapping in toepassingsdata en valideer dat de verwachte shape nog bestaat.

Voor een praktisch voorbeeld van het lezen en bijwerken van zowel de alternatieve‑tekst‑titel als -beschrijving, zie [Beheer Alternatieve Tekst Titels en Beschrijvingen](/slides/nl/net/presentation-accessibility/). Gebruik alternatieve tekst om de betekenis van het visuele element uit te leggen aan lezers, en houd het gescheiden van shape‑namen die door code worden gebruikt om shapes te vinden.

Het volgende voorbeeld zoekt op `Name` met een ordinale vergelijking en meldt de slide‑specifieke interop‑ID. Wanneer de template de verwachte shape niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Wanneer een bewerking specifiek is voor een bepaalde shape‑type, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Identificeren en Aanpassen van Vooraf Ingestelde Shape‑Aanpassingen**

Voorinstelling‑geometrieshapes kunnen aanpassingspunten blootstellen die eigenschappen regelen zoals hoekgrootte, pijlverhoudingen of booghoeken. Toegang daartoe krijg je via de alleen‑lezen collectie [IGeometryShape.Adjustments](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/adjustments/). De collectie zelf wordt door de shape geleverd, maar elke [IAdjustValue](https://reference.aspose.com/slides/nl/net/aspose.slides/iadjustvalue/) bevat een waarde die kan worden aangepast.

Vertrouw niet alleen op een vaste collectie‑index. Loop door de aanpassingen en inspecteer de alleen‑lezen eigenschap [Type](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/type/), waarvan de waarde [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeadjustmenttype/) beschrijft wat de aanpassing regelt. De alleen‑lezen eigenschap [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/name/) geeft extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardeeigenschap die overeenkomt met de betekenis van de aanpassing:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [RawValue](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Dikte van een pijlpuntstaart | `RawValue` |
| `ArrowheadLength` | Lengte van een pijlpunt | `RawValue` |
| `ArrowheadWidth` | Breedte van een pijlpunt | `RawValue` |
| `StartAngle` | Starthoek van een taart‑ of boogvorm | [AngleValue](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Eindhoek van een taart‑ of boogvorm | `AngleValue` |

`Type` en `Name` kunnen niet toegewezen worden. `RawValue` is een lees‑/schrijf‑integer in de native eenheden van de preset‑geometrie, terwijl `AngleValue` een lees‑/schrijf‑hoek in graden is. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van de preset‑[ShapeType](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/shapetype/). Een waarde die geldig is voor de ene preset kan ongeldig of anderswerkend zijn voor een andere.

Wanneer `Type` `ShapeAdjustmentType.Custom` is, herkent de API geen standaard semantische betekenis. Inspecteer `Name`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor herkende typen, controleer of hetzelfde type meer dan één keer voorkomt voordat je een waarde selecteert. Het artikel [Connector](/slides/nl/net/connector/) toont deze situatie met buig‑aanpassingen van connectors.

Het volgende volledige voorbeeld maakt standaard‑ en aangepaste versies van drie preset‑shapes. Het loopt door elke aanpassing, meldt zijn `Name` en `Type`, wijzigt grootte‑gerelateerde waarden via `RawValue`, wijzigt hoeken via `AngleValue`, en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont de aangepaste afgeronde rechthoek, vier‑weg pijl en taart.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Voegt kopteksten toe voor de standaard- en aangepaste shape-kolommen.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet wat betreft intentie en voorkomt de veronderstelling dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑shapes.

## **De Shape‑collectie wijzigen**

De methoden voor toevoegen, klonen, verwijderen en opnieuw ordenen werken direct op de collectie. Als een bewerking het aantal of de volgorde van shapes wijzigt, blijf dan niet blijven vertrouwen op indexen die vóór die bewerking zijn vastgelegd.

### **Een Shape klonen**

[AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addclone/) maakt een onafhankelijke kopie en voegt die toe aan de doel‑collectie. [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/insertclone/) maakt ook een kopie maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze eveneens aanpassen.

Het voorbeeld maakt een doeldia, kloont een gelabelde rechthoek naar de voorgrond, en voegt een tweede kloon toe aan de achtergrond. Wijzigingen aan een van beide klonen wijzigen de bron‑shape niet.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Klonen kopieert de inhoud en opmaak van de shape, inclusief de naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe shapes worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw collectie‑item met een nieuwe shape‑identiteit.

### **Shapes verwijderen**

[Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/remove/) verwijdert een specifiek shape‑object uit zijn collectie. Wanneer je meerdere overeenkomsten tijdens een geïndexeerde iteratie wilt verwijderen, doorloop de collectie dan van achteren zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke shape met een aangewezen naam. Het leest `slide.Shapes[i]`, niet een vaste collectie‑item, en cast de shape niet onnodig.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Na het verwijderen wijzigen het aantal shapes en de indexen van latere shapes. Verwijzingen naar ongewijzigde shapes blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectors, animaties en andere presentatie‑features die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare shape kan meer veranderen dan alleen het uiterlijk van de dia.

### **Een Shape verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/hidden/) op `true` houdt de shape in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. Zijn index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later eventueel weer zichtbaar gemaakt kunnen worden.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en onzichtbaar gemaakt door een gebruiker of door code, en het blijft deel uitmaken van het presentatie‑bestand.

### **Z‑orde wijzigen**

Overlappende shapes worden getekend in de volgorde van de collectie. [Reorder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/reorder/) verplaatst een bestaande shape naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `Count - 1` is de voorkant.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

De rechthoek wordt eerst aangemaakt en bevindt zich aanvankelijk achter de ellips. Het verplaatsen naar de laatste index brengt hem naar de voorkant. Finaliseer de z‑order nadat je alle gerelateerde shapes hebt toegevoegd of gekloond, omdat die bewerkingen nieuwe collectie‑items toevoegen of invoegen en de beoogde stapel kunnen wijzigen.

## **Shapes op Layout‑slides inspecteren**

Normale slides, layout‑slides en master‑slides hebben afzonderlijke shape‑collecties. Een shape in een layout‑collectie is niet hetzelfde object als een vergelijkbaar gepositioneerde shape op een normale slide. Inspecteer layout‑shapes wanneer je de door een layout geleverde opmaak wilt begrijpen of wijzigen.

Het volgende voorbeeld leest voor elke layout‑shape de [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/fillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/lineformat/) zonder aan te nemen dat elke shape een `AutoShape` is.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Het wijzigen van een layout kan meerdere slides beïnvloeden die de layout gebruiken. Voordat je een layout‑shape wijzigt, bepaal of een normale slide het object erft of een lokale overschrijving bevat, en test elke slide die die layout gebruikt.

## **Een Shape exporteren naar SVG**

[WriteAsSvg](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/writeassvg/) schrijft de gerenderde inhoud van één shape naar een stream. Het resultaat bevat alleen de shape, niet de volledige slide‑achtergrond of aangrenzende shapes.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Houd de presentatie geopend tijdens het renderen. De output hangt af van de opmaak van de shape en van resources zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de slide in plaats van een individuele shape. De aanroeper bezit de stream en moet deze vrijgeven.

## **Shapes uitlijnen**

De overloads van [SlideUtil.AlignShapes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/alignshapes/) kunnen ofwel alle shapes of geselecteerde collectie‑indexen uitlijnen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapesalignmenttype/) specificeert de rand, de middenlijn of de distributiemodus. Stel `alignToSlide` in op `true` om de slide‑randen te gebruiken; stel het in op `false` om de geselecteerde shapes ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie shapes uit op de bovenrand van de slide. De geretourneerde shape‑referenties worden direct vóór uitlijning omgezet naar hun huidige indexen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Uitlijning wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaal gesproken minimaal twee shapes, terwijl horizontale of verticale distributie voldoende shapes nodig heeft om de tussenruimte te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Een Shape spiegelen**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegel‑instellingen en rotatie op. De waarden `FlipH` en `FlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/): `True` schakelt de spiegel in, `False` schakelt deze uit, en `NotDefined` behoudt de ongespecificeerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑gespiegelde shape.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegel‑instellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/frame/) het volledige frame vervangt.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

De opgeslagen shape wordt zowel horizontaal als verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als shape‑identifier?**

Alleen voor kortstondige verwerking wanneer de collectie niet zal veranderen vóórdat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor door de auteur beheerde templates, of aan `OfficeInteropShapeId` voor slide‑specifieke interop‑werkzaamheden.

**Verwijdert het verbergen van een shape deze uit de z‑order?**

Nee. Een verborgen shape blijft in de collectie op dezelfde index. Hij kan nog steeds worden gevonden, opnieuw geordend, bewerkt of opnieuw zichtbaar worden gemaakt.

**Waarom verscheen een gekloonde shape voor een andere shape?**

`AddClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `InsertClone` om een initiële index te kiezen of `Reorder` nadat alle shapes zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑shape‑aanpassing te identificeren?**

Alleen na het valideren van de exacte preset en collectie‑lay-out. Geef de voorkeur aan itereren door `IGeometryShape.Adjustments` en het controleren van `IAdjustValue.Type`; gebruik `IAdjustValue.Name` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.