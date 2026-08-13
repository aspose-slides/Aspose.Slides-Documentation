---
title: Effectieve vormeigenschappen ophalen uit presentaties in .NET
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/net/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- bevelvorm
- tekstkader
- tekststijl
- letterhoogte
- opvulopmaak
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor .NET effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die direct op een bepaald opmaakniveau worden ingesteld, bijvoorbeeld:

1. Portion‑eigenschappen op een dia.
1. Prototype‑vorm‑tekststijlen op een lay‑out‑ of master‑dia, wanneer de tekstkader‑vorm van de portion er een heeft.
1. Globale tekstopmaakinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de definitieve “zoals gerenderde” opmaak nodig heeft, doorloopt het de ervaringsketen en retourneert **effectieve** waarden. Je kunt deze verkrijgen door de `GetEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe je effectieve waarden kunt opvragen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is met een tekstkader en minstens één portion.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Effectieve opmaakgegevens vertegenwoordigen de op dat moment berekende opmaak nadat erfelijkheid is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformateffectivedata/), intern worden gecached. Als je na het wijzigen van de bovenliggende of geërfde opmaak `GetEffective` opnieuw aanroept, kan de cache worden vernieuwd en kan een eerder verkregen object niet langer de eerdere toestand vertegenwoordigen. Als je effectieve waarden later opnieuw wilt gebruiken, kopieer dan de benodigde eigenschappen, zoals lettergrootte, opvulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een camera op te halen. De interface [ICameraEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/icameraeffectivedata/) vertegenwoordigt een onveranderlijk object dat de effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/icameraeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/) levert.

De volgende code‑voorbeeld laat zien hoe je de effectieve eigenschappen van de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Effectieve eigenschappen van een lichtinstallatie ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een lichtinstallatie op te halen. De interface [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrigeffectivedata/) vertegenwoordigt een onveranderlijk object dat de effectieve lichtinstallatie‑eigenschappen bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrigeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/) levert.

De volgende code‑voorbeeld laat zien hoe je de effectieve eigenschappen van de lichtinstallatie kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Effectieve eigenschappen van een bevel‑vorm ophalen**

Aspose.Slides maakt het mogelijk om de effectieve eigenschappen van een vormbevel op te halen. De interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapebeveleffectivedata/) vertegenwoordigt een onveranderlijk object dat de effectieve relief‑eigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapebeveleffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/), die effectieve waarden voor [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/) levert.

De volgende code‑voorbeeld laat zien hoe je de effectieve eigenschappen voor het boven‑bevel van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Effectieve eigenschappen van een tekstkader ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstkader ophalen. De interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformateffectivedata/) bevat effectieve opmaak‑eigenschappen voor een tekstkader.

De volgende code‑voorbeeld laat zien hoe je de effectieve opmaak‑eigenschappen van een tekstkader kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is met een tekstkader.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Effectieve eigenschappen van een tekststijl ophalen**

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. De interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/itextstyleeffectivedata/) bevat effectieve tekststijl‑eigenschappen.

De volgende code‑voorbeeld laat zien hoe je de effectieve tekststijl‑eigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is met een tekstkader.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **De effectieve letterhoogte‑waarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code toont hoe de effectieve letterhoogte van een portion verandert nadat lokale letterhoogte‑waarden op verschillende presentatiestructuurniveaus zijn ingesteld.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **De effectieve opvul­opmaak voor een tabel ophalen**

Met Aspose.Slides kun je de effectieve opvul‑opmaak voor verschillende tabelonderdelen ophalen. De interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/) bevat effectieve opvul‑opmaak‑eigenschappen. Cel‑opmaak heeft hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft hogere prioriteit dan de opmaak van de volledige tabel.

Als gevolg daarvan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/icellformateffectivedata/) gebruikt om de tabelcel te tekenen. De volgende code‑voorbeeld toont hoe je de effectieve opvul‑opmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) is.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **FAQ**

### Retourneert `GetEffective` een momentopname?

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve gegevensobjecten kunnen intern gecached zijn. Een volgende `GetEffective`‑aanroep kan de opmaak opnieuw berekenen en de cache verversen, zodat een eerder verkregen object niet moet worden beschouwd als een duurzame momentopname.

### Wanneer moet ik effectieve eigenschappen opnieuw uitlezen?

Roep `GetEffective` opnieuw aan nadat je lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, master‑opmaak of presentatie‑standaardwaarden hebt gewijzigd. De volgende aanroep evalueert de opmaakhiërarchie opnieuw en geeft het huidige effectieve resultaat terug.

### Heeft het wijzigen of verwijderen van een lay‑out/master‑dia invloed op reeds opgehaalde effectieve eigenschappen?

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `GetEffective`‑aanroep. Als een bovenliggende opmaakbron wordt gewijzigd of verwijderd, kunnen eerder verkregen effectieve gegevens verouderd zijn. Zodra `GetEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden veranderen.

### Kan ik waarden wijzigen via effectieve gegevensobjecten?

Nee. Effectieve gegevensobjecten geven alleen berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal daarna opnieuw de effectieve waarden op.

### Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/master, noch in de globale instellingen?

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardwaarden van PowerPoint en Aspose.Slides omvat. Die bepaalde waarde wordt onderdeel van de huidige effectieve gegevens.

### Kan ik vanuit een effectieve letterwaarde afleiden op welk niveau de grootte of het lettertype is gedefinieerd?

Niet direct. Effectieve gegevens geven de uiteindelijke waarde terug. Om de bron te vinden, controleer je de lokale waarden op portion‑, alinea‑, tekstkader‑ en tekststijlniveau in de lay‑out, master en presentatie om te zien waar de eerste expliciete definitie voorkomt.

### Waarom lijken effectieve waarden soms identiek aan de lokale waarden?

Omdat de lokale waarde uiteindelijk de definitieve waarde bleek te zijn (er was geen hogere‑niveau erfelijkheid nodig). In dat geval komt de effectieve waarde overeen met de lokale waarde.

### Wanneer moet ik effectieve eigenschappen gebruiken en wanneer alleen lokale?

Gebruik effectieve gegevens wanneer je het “zoals gerenderde” resultaat nodig hebt nadat alle erfelijkheid is toegepast, bijvoorbeeld om kleuren, inspringingen of groottes op elkaar af te stemmen. Als je die waarden wilt behouden ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je de opmaak op een specifiek niveau wilt wijzigen, pas dan de lokale eigenschappen aan en lees vervolgens, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.