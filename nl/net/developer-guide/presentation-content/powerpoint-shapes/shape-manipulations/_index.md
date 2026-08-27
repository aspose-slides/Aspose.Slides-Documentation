---
title: Beheer presentatievormen in .NET
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/net/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- interop-vorm-ID ophalen
- alternatieve tekst van vorm
- aanpassingspunt van vorm
- preset-vormaanpassing
- vormgeometrie
- layout-opmaak van vorm
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u presentatievormen kunt identificeren, aanpassen, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET vertegenwoordigt de vormen op een dia als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/). De collectie is zowel de plek waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de achterste vorm, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren en vooraf ingestelde aanpassingpunten kunt wijzigen, en laat vervolgens zien hoe je vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen lay-out‑niveau opmaak, SVG‑export, uitlijning en spiegelinstellingen. Elk voorbeeld staat op zich, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Vormen Identificeren en Vinden**

Collectie‑indexen zijn handig bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identifiers. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identifier op basis van hoe de presentatie is vervaardigd en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/name/) is nuttig voor door ontwikkelaars gecontroleerde sjablonen en is gemakkelijk te bekijken in het selectie‑paneel van PowerPoint. Namen kunnen bewerkt worden en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie op als code afhankelijk is van deze namen.
- [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetext/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan gelokaliseerd of herschreven worden voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik geen betekenisvolle toegankelijkheidstekst stilzwijgend als een databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/officeinteropshapeid/) is een alleen‑lezen identifier die uniek is binnen een dia en overeenkomt met de vorm‑ID die PowerPoint‑interop gebruikt. Gebruik dit wanneer je integreert met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De gerelateerde [UniqueId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/uniqueid/)‑eigenschap heeft presentatie‑breedte, maar is bedoeld voor add‑ins en kan opnieuw toegewezen worden. Zie het niet als een permanente externe sleutel. Als langdurige identiteit essentieel is, bewaar de mapping in applicatie‑data en controleer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op `Name` met een ordinale vergelijking en meldt de interop‑ID scoped op de dia. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een bewerking specifiek is voor een type vorm, controleer dan de interface vóór het gebruiken van type‑specifieke leden. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is.

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

## **Vooraf Ingestelde Vormaanpassingen Identificeren en Wijzigen**

Vooraf ingestelde geometrievormen kunnen aanpassingpunten exposeren die kenmerken regelen zoals hoekgrootte, pijlnormen of booghoeken. Toegang krijg je via de alleen‑lezen [IGeometryShape.Adjustments](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/adjustments/)‑collectie. De collectie zelf wordt geleverd door de vorm, maar elk [IAdjustValue](https://reference.aspose.com/slides/nl/net/aspose.slides/iadjustvalue/) bevat een waarde die aangepast kan worden.

Vertrouw niet uitsluitend op een vaste collectie‑index. Doorloop de aanpassingen en inspecteer de alleen‑lezen [Type](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/type/)‑eigenschap, waarvan de [ShapeAdjustmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeadjustmenttype/)‑waarde beschrijft wat de aanpassing regelt. De alleen‑lezen [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/name/)‑eigenschap biedt extra identificatie‑informatie en is vooral nuttig wanneer een preset meer dan één aanpassing met hetzelfde semantische type bevat.

Gebruik de waardeigenschap die overeenkomt met de betekenis van de aanpassing:

| Aanpassingstype | Doel | Waarde om te wijzigen |
|---|---|---|
| `CornerSize` | Grootte van afgeronde hoeken | [RawValue](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Dikte van een pijpoot | `RawValue` |
| `ArrowheadLength` | Lengte van een pijlkop | `RawValue` |
| `ArrowheadWidth` | Breedte van een pijlkop | `RawValue` |
| `StartAngle` | Beginhoek van een sector of boog | [AngleValue](https://reference.aspose.com/slides/nl/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Eindhoek van een sector of boog | `AngleValue` |

`Type` en `Name` kunnen niet worden toegewezen. `RawValue` is een lees‑/schrijf‑integer in de native geometrie‑eenheden van de preset, terwijl `AngleValue` een lees‑/schrijf‑hoek in graden is. Het aantal, de volgorde, de betekenis en het geldige bereik van aanpassingen hangen af van het preset‑[ShapeType](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/shapetype/). Een waarde die geldig is voor de ene preset kan ongeldige of een ander effect hebben voor een andere.

Wanneer `Type` `ShapeAdjustmentType.Custom` is, herkent de API geen standaard semantische betekenis. Inspecteer `Name`, het preset‑type en de bestaande waarde, en laat de aanpassing ongewijzigd tenzij de verwachte betekenis en het bereik bekend zijn. Zelfs voor herkende types, controleer of hetzelfde type meer dan één keer voorkomt voordat je een waarde selecteert. Het artikel over [Connector](/slides/nl/net/connector/) toont deze situatie met buig‑aanpassingen van connectors.

Het volgende volledige voorbeeld maakt standaard‑ en gewijzigde versies van drie preset‑vormen. Het doorloopt elke aanpassing, meldt diens `Name` en `Type`, wijzigt grootte‑gerelateerde waarden via `RawValue`, wijzigt hoeken via `AngleValue` en slaat het resultaat op. De linkerkolom behoudt de standaardgeometrie; de rechterkolom toont de aangepaste afgeronde rechthoek, vierweg‑pijl en cirkelsector.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Voegt kopteksten toe voor de kolommen met standaard- en aangepaste vormen.
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

Het controleren van het semantische type vóór het wijzigen van een waarde maakt de code expliciet over de bedoeling en voorkomt de veronderstelling dat een bepaalde collectie‑index dezelfde betekenis heeft bij verschillende preset‑vormen.

## **De Vormcollectie Wijzigen**

De methoden voor toevoegen, klonen, verwijderen en herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen wijzigt, vertrouw dan niet meer op indexen die vóór die bewerking zijn vastgelegd.

### **Een Vorm Klonen**

[AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addclone/) maakt een onafhankelijke kopie en voegt deze toe aan de doelcollectie. [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/insertclone/) maakt ook een kopie maar plaatst deze op een opgegeven z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doeldia, kloont een gelabelde rechthoek naar de voorkant, en voegt een tweede kloon toe aan de achterkant. Wijzigingen aan een van beide klonen wijzigen de brondvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief de naam en alternatieve tekst. Ken nieuwe logische identifiers toe aan de kloon wanneer die waarden uniek moeten zijn. Bronnen die door complexe vormen worden gebruikt, worden door de presentatie beheerd, maar een kloon blijft een nieuw collectie‑item met een nieuwe vorm‑identiteit.

### **Vormen Verwijderen**

[Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je meerdere overeenkomsten tijdens een geïndiceerde iteratie wilt verwijderen, doorloop dan van het einde zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest `slide.Shapes[i]`, niet een vaste collectie‑item, en cast de vorm niet onnodig.

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

Na verwijdering veranderen het aantal vormen en de indexen van latere vormen. Referenties naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectors, animaties en andere presentatiefuncties die kunnen verwijzen naar het verwijderde object; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen het uiterlijk van de dia.

### **Een Vorm Verbergen**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/hidden/) op `true` houdt de vorm in de collectie, maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later eventueel hersteld kunnen worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden ontdekt en zichtbaar worden gemaakt door een gebruiker of door code, en het blijft deel uitmaken van het presentatie‑bestand.

### **De Z‑Order Wijzigen**

Overlap‑vormen worden geschilderd in de volgorde van de collectie. [Reorder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `Count - 1` is de voorkant.

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

De rechthoek wordt eerst aangemaakt en zit aanvankelijk achter de ellips. Het verplaatsen naar de laatste index plaatst hem vooraan. Finaliseer de z‑order nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, omdat die bewerkingen nieuwe collectie‑items toevoegen of invoegen en de beoogde stapel kunnen wijzigen.

## **Vormen op Layout‑Dia’s Inspecteren**

Normale dia’s, layout‑dia’s en master‑dia’s hebben gescheiden vormcollecties. Een vorm in een layout‑collectie is niet hetzelfde object als een vergelijkbaar gepositioneerde vorm op een normale dia. Inspecteer layout‑vormen wanneer je de door een layout geleverde opmaak moet begrijpen of wijzigen.

Het volgende voorbeeld leest elk layout‑vorm [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/fillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/lineformat/) zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een layout kan meerdere dia’s die deze gebruiken beïnvloeden. Bepaal vóór het wijzigen van een layout‑vorm of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die layout gebruikt.

## **Een Vorm Exporteren naar SVG**

[WriteAsSvg](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/writeassvg/) schrijft de gerenderde inhoud van één vorm naar een stream. Het resultaat bevat alleen de vorm, niet de volledige dia‑achtergrond of naburige vormen.

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

Houd de presentatie open tijdens het renderen. De output hangt af van de opmaak van de vorm en van bronnen zoals lettertypen en afbeeldingen. Als je de volledige compositie nodig hebt, exporteer dan de dia i.p.v. een individuele vorm. De aanroeper bezit de stream en moet deze vrijgeven.

## **Vormen Uitlijnen**

De overloads van [SlideUtil.AlignShapes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/alignshapes/) lijnen ofwel alle vormen uit of geselecteerde collectie‑indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapesalignmenttype/) specificeert de rand, middellijn of distributiemodus. Zet `alignToSlide` op `true` om de dia‑randen te gebruiken; zet op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijn drie vormen uit op de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór uitlijning omgezet naar hun huidige indexen.

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

Uitlijnen wijzigt posities, niet de z‑order. Relatieve uitlijning vereist normaliter minstens twee vormen, terwijl horizontale of verticale distributie voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt voordat je de methode aanroept.

## **Een Vorm Spiegelen**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/) slaat positie, grootte, horizontale en verticale spiegelinstellingen, en rotatie op. De `FlipH`‑ en `FlipV`‑waarden gebruiken [NullableBool](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/): `True` activeert de spiegel, `False` deactiveert deze, en `NotDefined` behoudt de ongespecificeerde/default‑status.

De invoerpresentatie hieronder bevat één niet‑gespiegelde vorm.

![De vorm vóór het spiegelen](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee spiegelinstellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/frame/) het volledige frame vervangt.

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

De opgeslagen vorm is horizontaal en verticaal gespiegeld terwijl positie, grootte en rotatie behouden blijven.

![De vorm na het spiegelen](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vormidentifier?**

Alleen voor kort‑levende verwerking wanneer de collectie niet zal veranderen voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor vervaardigde sjablonen, of `OfficeInteropShapeId` voor interop‑werk scoped op de dia.

**Verwijdert het verbergen van een vorm deze uit de z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Ze kan worden gevonden, herschikt, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`AddClone` voegt de kloon toe aan het einde van de collectie, wat de voorkant van de z‑order is. Gebruik `InsertClone` om de initiële index te kiezen of `Reorder` nadat alle vormen zijn toegevoegd.

**Kan ik een vaste index gebruiken om een preset‑vormaanpassing te identificeren?**

Alleen na het valideren van de exacte preset en collectie‑lay‑out. Geef de voorkeur aan itereren door `IGeometryShape.Adjustments` en het controleren van `IAdjustValue.Type`; gebruik `IAdjustValue.Name` als extra informatie wanneer hetzelfde semantische type meer dan één keer voorkomt.