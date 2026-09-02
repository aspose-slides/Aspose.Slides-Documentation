---
title: Effectieve vormeigenschappen ophalen uit presentaties in .NET
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/net/shape-effective-properties/
keywords:
- vormeigenschappen
- camera‑eigenschappen
- lichtrig
- bevel vorm
- tekstkader
- tekststijl
- letterhoogte
- vullingsformaat
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u Aspose.Slides voor .NET kunt gebruiken om lokale, geërfde en effectieve vormopmaak in PowerPoint‑presentaties te onderscheiden."
---
## **Begrijp lokale, geërfde en effectieve eigenschappen**

PowerPoint-opmaak kan uit verschillende bronnen komen. De waarde die rechtstreeks op een object is opgeslagen, is de **lokale waarde**. Als die waarde niet is ingesteld, kijkt PowerPoint naar bovenliggende opmaakbronnen, zoals een alinea‑standaard, een tekststijl, een lay‑out‑ of masterslide, een thema, of standaardinstellingen op presentatieniveau. Die waarden zijn **geërfde waarden**. De waarde die overblijft nadat de volledige hiërarchie is opgelost, is de **effectieve waarde** — de waarde die wordt gebruikt om het object weer te geven.

Bijvoorbeeld, een tekstgedeelte definieert mogelijk niet zijn eigen letterhoogte. De lokale [FontHeight](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseportionformat/fontheight/) is dan `float.NaN`, wat betekent "niet hier ingesteld". Het gedeelte kan een hoogte erven van de alinea, de standaardtekststijl van de presentatie, of een andere toepasselijke bron. Het aanroepen van [GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/geteffective/) op het gedeelte‑formaat retourneert de definitief opgeloste hoogte.

Gebruik de twee soorten opmaakgegevens voor verschillende doeleinden:

- Lees of wijzig een lokaal formaatobject, zoals [IPortionFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/), wanneer u moet controleren waar een waarde wordt gedefinieerd.
- Lees een effectief gegevensobject, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformateffectivedata/), wanneer u het uiteindelijke, gerenderde resultaat nodig heeft. Effectieve gegevens zijn alleen-lezen.

## **Vergelijk lokale, geërfde en effectieve waarden**

Het volgende volledige voorbeeld maakt een vorm aan en past letterhoogtes toe op presentatie‑, alinea‑ en gedeelte‑niveau. Elke stap drukt de op die niveaus gedefinieerde waarden af en de resulterende effectieve waarde voor hetzelfde tekstgedeelte. Het laat ook zien waarom effectieve gegevens opnieuw moeten worden gelezen na opmaakwijzigingen.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Definieer geërfde waarden op twee verschillende niveaus.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// Een lokale waarde op het gedeelte overschrijft beide geërfde waarden.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Het wijzigen van een geërfde waarde overschrijft een bestaande lokale waarde niet.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Wis de lokale waarde. Het gedeelte erft nu opnieuw van de alinea.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Wis de alinea‑waarde. De standaard van de presentatie levert nu het resultaat.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Lees effectieve gegevens na de voorgaande wijzigingen.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

De prioriteit in dit voorbeeld is lokale opmaak van het gedeelte, vervolgens alinea‑opmaak, dan de presentatie‑standaard. Andere objecten kunnen andere erfenisketens hebben, maar het principe is hetzelfde: een meer specifieke expliciete waarde wint, en [GetEffective](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/geteffective/) retourneert het eindresultaat.

## **Effectieve tekst‑eigenschappen ophalen**

Tekstopmaak is verdeeld over verschillende objecten:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/geteffective/) lost tekst‑frame‑eigenschappen op, zoals marges, verankering, automatische grootteaanpassing en verticale tekstrichting.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/nl/net/aspose.slides/itextstyle/geteffective/) lost alinea‑opmaak op voor elk tekststijlniveau.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/geteffective/) lost alinea‑eigenschappen op, zoals uitlijning, inspringing en opsommingstekens.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformat/geteffective/) lost teken‑eigenschappen op, zoals letterhoogte, lettertype, kleur, vet en cursief.

Voor het volgende voorbeeld moet `text-formatting.pptx` ten minste één dia en één [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) met een niet‑leeg tekstframe bevatten. De AutoShape kan zich op elke positie in de vormverzameling bevinden; de code zoekt een geschikt object en valideert dit vóór gebruik.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Effectieve 3D‑eigenschappen ophalen**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/geteffective/) retourneert één [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/) object dat alle opgeloste 3D‑instellingen groepeert. De eigenschappen [Camera](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/beveltop/) en [BevelBottom](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) geven de bijbehorende effectieve gegevens weer. Het gezamenlijk lezen van deze gerelateerde instellingen maakt het makkelijker om het uiteindelijke 3D‑uiterlijk van een vorm te begrijpen.

Voor dit voorbeeld moet `shape-3d.pptx` op de eerste dia ten minste één vorm bevatten. Pas 3D‑camera‑, belichtings‑ of bevelinstellingen toe op die vorm als u wilt dat de uitvoer andere waarden dan de standaard bevat.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Effectieve tabelopmaak ophalen**

Tabelopmaak kan afkomstig zijn van de tabelstijl en van opmaak die is toegepast op de hele tabel, een kolom, een rij of een individuele cel. Bij conflicten tussen expliciet gedefinieerde vullingen heeft de volgorde prioriteit: cel, rij, kolom, en daarna de hele tabel. Het effectieve formaat van een cel is de uiteindelijke opmaak die wordt gebruikt om die cel te tekenen.

Voor dit voorbeeld moet `table-formatting.pptx` op de eerste dia ten minste één tabel bevatten. De tabel moet minstens één rij en één kolom hebben. De code zoekt naar een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) in plaats van aan te nemen dat `Shapes[0]` een tabel is.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Als u de kleur nodig heeft in plaats van alleen het vullingstype, controleer dan eerst de effectieve [FillType](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/filltype/), en lees daarna de eigenschap die op dat type van toepassing is — bijvoorbeeld [SolidFillColor](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) voor een effen vulling.

## **Effectieve gegevens opnieuw lezen na wijzigingen**

Effectieve gegevens beschrijven de opmaakhiërarchie op het moment dat deze wordt opgelost. Roep `GetEffective` opnieuw aan nadat u iets heeft gewijzigd dat deel kan uitmaken van die hiërarchie, inclusief:

- de lokale opmaak van het object;
- alinea‑ of tekst‑frame‑standaarden;
- een tabelstijl, tabel, kolom, rij of cel‑opmaak;
- lay‑out‑ of masterslide‑opmaak;
- themagegevens of standaardinstellingen op presentatieniveau;
- de lay‑out of master die aan een dia is toegewezen.

Bewaar een effectief gegevensobject niet als een permanent momentopname. Aspose.Slides kan sommige effectieve gegevens intern cachen, en een latere `GetEffective`‑aanroep kan die gegevens vernieuwen. Als u waarden vóór en na een wijziging wilt vergelijken, kopieer dan de scalare waarden die u nodig heeft — zoals een letterhoogte, kleur, uitlijning of bevelbreedte — naar uw eigen variabelen voordat u de wijziging aanbrengt.

Om een waarde te wijzigen, werkt u het juiste lokale formaatobject bij en roep vervolgens `GetEffective` aan om het resultaat te verifiëren. Effectieve gegevensobjecten zelf zijn alleen‑lezen.

## **FAQ**

**Hoe kan ik zien welk niveau een effectieve waarde heeft geleverd?**

Effectieve gegevens bevatten de uiteindelijke waarde, niet de bron. Inspecteer de toepasselijke lokale objecten vanaf het meest specifieke niveau naar buiten toe. Voor tekst kan dit onder andere het gedeelte, de alinea, het tekstframe, de lay‑out, de master, het thema en de standaardinstellingen van de presentatie omvatten. Niet‑gedefinieerde waarden zoals `float.NaN` of `null` geven aan dat de zoektocht doorgaat naar een ander niveau.

**Wat gebeurt er als geen enkel niveau een eigenschap definieert?**

Aspose.Slides lost de juiste PowerPoint‑ of bibliotheekstandaard op. Die opgeloste waarde verschijnt in de effectieve gegevens, ook al definieert geen lokaal object deze expliciet.

**Waarom is een effectieve waarde soms gelijk aan de lokale waarde?**

De lokale waarde heeft de erfenisberekening gewonnen. Dit is te verwachten wanneer de eigenschap expliciet op het object is ingesteld en geen specifiekere regel deze overschrijft.

**Wanneer moet ik lokale gegevens gebruiken in plaats van effectieve gegevens?**

Gebruik lokale gegevens om een specifiek opmaakniveau te inspecteren of te bewerken. Gebruik effectieve gegevens wanneer u het uiteindelijke uiterlijk nodig heeft nadat erfenis, themaregels en toepasselijke stijlen zijn verwerkt. Het [complete vergelijkingvoorbeeld](#compare-local-inherited-and-effective-values) toont beide in dezelfde workflow.