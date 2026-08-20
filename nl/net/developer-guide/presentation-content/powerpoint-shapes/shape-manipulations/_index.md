---
title: "Beheer presentatievormen in .NET"
linktitle: "Vormmanipulatie"
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
- vormlay-outformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- vorm spiegelen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe je presentatievormen kunt identificeren, klonen, verwijderen, verbergen, herschikken, exporteren, uitlijnen en spiegelen met Aspose.Slides voor .NET."
---
## **Overzicht**

Aspose.Slides for .NET stelt de vormen op een dia voor als een geordende [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/). De collectie is zowel de plek waar je vormen vindt en wijzigt als de bron van hun stapelvolgorde: index `0` is de vorm achterste, terwijl de laatste index de voorste vorm is.

Dit artikel volgt dat model. Het legt eerst uit hoe je een vorm betrouwbaar kunt identificeren, en toont vervolgens hoe je vormen kunt klonen, verwijderen, verbergen en herschikken. De laatste secties behandelen opmaak op lay-outniveau, SVG-export, uitlijning en flip‑instellingen. Elk voorbeeld is onafhankelijk, zodat je alleen de bewerkingen kunt gebruiken die jouw workflow vereist.

## **Identificeer en vind vormen**

Collectie‑indexen zijn praktisch bij het verwerken van een bekend bestand, maar ze zijn geen stabiele identificatoren. Het toevoegen, verwijderen of herschikken van een vorm kan de index wijzigen. Kies een identificator op basis van hoe de presentatie is opgesteld en onderhouden:

- [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/name/) is nuttig voor door ontwikkelaars beheerde sjablonen en is gemakkelijk te inspecteren in het Selectievenster van PowerPoint. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, dus stel een naamgevingsconventie vast als code ervan afhankelijk is.
- [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetext/) is nuttig wanneer een toegankelijkheidsbeschrijving of een door de auteur toegevoegde tag de vorm al identificeert. Het is zichtbaar voor gebruikers, kan worden gelokaliseerd of herschreven voor toegankelijkheid, en is niet gegarandeerd uniek. Gebruik betekenisvolle toegankelijkheidstekst niet stilletjes als databasesleutel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/officeinteropshapeid/) is een alleen‑lezende identifier die uniek is binnen een dia en overeenkomt met de shape‑ID die PowerPoint‑interop gebruikt. Gebruik deze wanneer je integreert met PowerPoint of wanneer je een ondubbelzinnige referentie nodig hebt gedurende de levensduur van een vorm. Een gekloonde of opnieuw aangemaakte vorm is een andere vorm en krijgt een eigen ID.

De verwante eigenschap [UniqueId](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/uniqueid/) heeft presentatiescope, maar is bedoeld voor add‑ins en kan worden herhaald. Hij dient niet als permanente externe sleutel te worden behandeld. Als langdurige identiteit cruciaal is, bewaar dan de mapping in applicatie‑data en controleer dat de verwachte vorm nog bestaat.

Het volgende voorbeeld zoekt op `Name` met een ordinale vergelijking en geeft de interop‑ID binnen de dia weer. Wanneer de sjabloon de verwachte vorm niet bevat, meldt de code dat resultaat in plaats van door te gaan met het verkeerde object.

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

Wanneer een operatie specifiek is voor een type vorm, controleer dan de interface voordat je type‑specifieke leden gebruikt. Dit voorbeeld werkt tekst en alternatieve tekst bij alleen als het benoemde object een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is.

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

## **Wijzig de vormcollectie**

De methoden om toe te voegen, klonen, te verwijderen en te herschikken werken direct op de collectie. Als een bewerking het aantal of de volgorde van vormen verandert, moet je niet blijven vertrouwen op indexen die vóór die bewerking zijn vastgelegd.

### **Kloon een vorm**

[AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/addclone/) maakt een onafhankelijk exemplaar en voegt het toe aan de doelcollectie. [InsertClone](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/insertclone/) maakt ook een kopie, maar plaatst deze op een opgegeven Z‑order‑index. De overloads die coördinaten accepteren verplaatsen de kloon zonder de grootte te wijzigen; overloads met breedte en hoogte kunnen deze ook aanpassen.

Het voorbeeld maakt een doeldia, kloont een gelabelde rechthoek naar de voorgrond en voegt een tweede kloon toe achterin. Wijzigingen aan één van de klonen beïnvloeden de brondvorm niet.

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

Klonen kopieert de inhoud en opmaak van de vorm, inclusief naam en alternatieve tekst. Wijs nieuwe logische identificatoren toe aan de kloon wanneer die waarden uniek moeten zijn. Resources die door complexe vormen worden gebruikt, worden door de presentatie afgehandeld, maar een kloon blijft een nieuw collectie‑item met een nieuwe vormidentiteit.

### **Verwijder vormen**

[Remove](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/remove/) verwijdert een specifiek vormobject uit zijn collectie. Wanneer je meerdere overeenkomsten wilt verwijderen tijdens een geïndexeerde iteratie, loop dan van het einde zodat elke overgebleven index geldig blijft.

Dit voorbeeld verwijdert elke vorm met een aangewezen naam. Het leest `slide.Shapes[i]`, niet een vast collection‑item, en cast de vorm niet onnodig.

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

Na verwijdering veranderen het aantal vormen en de indexen van de latere vormen. Verwijzingen naar ongewijzigde vormen blijven betrouwbaarder dan opgeslagen indexen. Houd ook rekening met connectors, animaties en andere presentatiefuncties die naar het verwijderde object kunnen verwijzen; het verwijderen van een zichtbare vorm kan meer veranderen dan alleen de weergave van de dia.

### **Verberg een vorm**

Het instellen van [Hidden](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/hidden/) op `true` houdt de vorm in de collectie maar voorkomt dat deze verschijnt in de normale diavoorstelling. De index, opmaak en inhoud blijven beschikbaar voor code, dus verbergen is geschikt voor optionele elementen die later mogelijk hersteld worden.

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

Verbergen is geen verwijdering of beveiliging. Het object kan nog steeds worden gevonden en zichtbaar gemaakt door een gebruiker of door code, en blijft onderdeel van het presentatie‑bestand.

### **Wijzig de Z‑order**

Overlappende vormen worden getekend volgens de collectiebestelling. [Reorder](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/reorder/) verplaatst een bestaande vorm naar een doel‑index zonder deze te klonen. Index `0` is de achterkant; `Count - 1` is de voorkant.

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

De rechthoek wordt eerst aangemaakt en zit oorspronkelijk achter de ellips. Verplaatsing naar de laatste index brengt deze naar de voorgrond. Finaliseer de Z‑order nadat je alle gerelateerde vormen hebt toegevoegd of gekloond, want die bewerkingen voegen nieuwe collectie‑items toe of inserten ze, wat de beoogde stapel kan wijzigen.

## **Inspecteer vormen op lay‑outdia's**

Normale dia's, lay‑outdia's en masterdia's hebben elk hun eigen vormcollecties. Een vorm in een lay‑outcollectie is niet hetzelfde object als een gelijk gepositioneerde vorm op een normale dia. Inspecteer lay‑outvormen wanneer je de opmaak die door een lay‑out wordt geleverd moet begrijpen of wijzigen.

Het volgende voorbeeld leest de [FillFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/fillformat/) en [LineFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/lineformat/) van elke lay‑outvorm zonder aan te nemen dat elke vorm een `AutoShape` is.

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

Het bewerken van een lay‑out kan meerdere dia's die de lay‑out gebruiken beïnvloeden. Voordat je een lay‑outvorm wijzigt, bepaal of een normale dia het object erft of een lokale overschrijving bevat, en test elke dia die die lay‑out gebruikt.

## **Exporteer een vorm naar SVG**

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

Houd de presentatie geopend tijdens het renderen. De output hangt af van de vormopmaak en van resources zoals lettertypen en afbeeldingen. Als je de hele compositie nodig hebt, exporteer dan de dia in plaats van een individuele vorm. De aanroeper bezit de stream en moet deze afsluiten.

## **Lijn vormen uit**

De overloads van [SlideUtil.AlignShapes](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/alignshapes/) lijnen ofwel alle vormen uit of geselecteerde collectie‑indexen. [ShapesAlignmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapesalignmenttype/) specificeert de rand, middellijn of verdeelmodus. Zet `alignToSlide` op `true` om de dia‑randen te gebruiken; zet het op `false` om de geselecteerde vormen ten opzichte van elkaar uit te lijnen.

Dit voorbeeld lijnt drie vormen uit tegen de bovenrand van de dia. De geretourneerde vormreferenties worden direct vóór uitlijning omgezet naar hun huidige indexen.

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

Uitlijning wijzigt posities, niet de Z‑order. Relatieve uitlijning vereist normaal minstens twee vormen, terwijl horizontale of verticale verdeling voldoende vormen nodig heeft om de afstand te bepalen. Herbereken indexen als je de collectie wijzigt vóór het aanroepen van de methode.

## **Flip een vorm**

De klasse [ShapeFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/) bewaart positie, grootte, horizontale en verticale flip‑instellingen, en rotatie. De waarden `FlipH` en `FlipV` gebruiken [NullableBool](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/): `True` activeert de flip, `False` deactiveert deze, en `NotDefined` behoudt de ongedefinieerde/standaardstatus.

De invoerpresentatie hieronder bevat één niet‑geflipte vorm.

![The shape before flipping](shape_to_be_flipped.png)

Het voorbeeld behoudt alle andere frame‑waarden en vervangt alleen de twee flip‑instellingen. Dit is belangrijk omdat het toewijzen van een nieuw [Frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/frame/) het volledige frame vervangt.

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

De opgeslagen vorm wordt horizontaal en verticaal gespiegeld, terwijl positie, grootte en rotatie behouden blijven.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Moet ik een collectie‑index gebruiken als vormidentificator?**

Alleen voor kortdurende verwerking wanneer de collectie niet verandert voordat de index wordt gebruikt. Geef de voorkeur aan een gevalideerde `Name`‑ of `AlternativeText`‑conventie voor door auteurs gemaakte sjablonen, of `OfficeInteropShapeId` voor interop‑werk binnen een dia.

**Verwijdert verbergen van een vorm deze uit de Z‑order?**

Nee. Een verborgen vorm blijft in de collectie op dezelfde index. Hij kan worden gevonden, herschikt, bewerkt of weer zichtbaar gemaakt.

**Waarom verscheen een gekloonde vorm voor een andere vorm?**

`AddClone` plakt de kloon aan het einde van de collectie, wat de voorste positie in de Z‑order is. Gebruik `InsertClone` om de initiële index te kiezen of `Reorder` nadat alle vormen zijn toegevoegd.