---
title: Effectieve Vormeigenschappen Ophalen uit Presentaties in .NET
linktitle: Effectieve eigenschappen
type: docs
weight: 50
url: /nl/net/shape-effective-properties/
keywords:
- vormeigenschappen
- camera-eigenschappen
- lichtinstallatie
- afgeschuinde vorm
- tekstkader
- tekststijl
- letterhoogte
- vulopmaak
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor .NET effectieve vormeigenschappen berekent en toepast voor nauwkeurige PowerPoint-weergave."
---
## **Overzicht**

Dit onderwerp legt het verschil uit tussen **lokale** en **effectieve** eigenschappen. Lokale waarden zijn waarden die rechtstreeks op een bepaald opmaakniveau worden ingesteld, zoals:

1. Portie‑eigenschappen op een dia.
1. Tekststijlen van prototypevormen op een lay‑out of matrixdia, wanneer de vorm van het tekstkader van de portie er een heeft.
1. Globale tekstinstellingen in een presentatie.

Lokale waarden kunnen op elk niveau worden gedefinieerd of weggelaten. Wanneer Aspose.Slides de uiteindelijke “as rendered”-opmaak nodig heeft, lost het de erfelijkheidsketen op en retourneert **effectieve** waarden. Je kunt ze verkrijgen door de `GetEffective`‑methode aan te roepen op het lokale opmaakobject.

Het volgende voorbeeld toont hoe je effectieve waarden kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) is met een tekstkader en minstens één portie.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Effectieve opmaakgegevens vertegenwoordigen de momenteel berekende opmaak nadat erfelijkheid is toegepast. In de huidige implementatie kunnen sommige effectieve gegevensobjecten, zoals [IPortionFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/iportionformateffectivedata/), intern worden gecached. Het opnieuw aanroepen van `GetEffective` nadat de bovenliggende of geërfde opmaak is gewijzigd, kan de gecachete gegevens verversen, en een eerder verkregen object vertegenwoordigt mogelijk niet meer de eerdere toestand. Als je effectieve waarden wilt behouden voor later hergebruik, kopieer dan de benodigde eigenschappen, zoals letterhoogte, vulkleur, lettertype‑stijl of uitlijning, naar je eigen gegevensobject.
{{% /alert %}}

## **Effectieve eigenschappen van een camera ophalen**

Aspose.Slides stelt je in staat om de effectieve eigenschappen van een camera op te halen. De interface [ICameraEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/icameraeffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve camera‑eigenschappen bevat. Een [ICameraEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/icameraeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/).

De volgende code‑voorbeeld toont hoe je de effectieve eigenschappen van de camera kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```csharp
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

Aspose.Slides stelt je in staat om de effectieve eigenschappen van een lichtinstallatie op te halen. De interface [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrigeffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve eigenschappen van de lichtinstallatie bevat. Een [ILightRigEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ilightrigeffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/).

De volgende code‑voorbeeld toont hoe je de effectieve eigenschappen van de lichtinstallatie kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Effectieve eigenschappen van een afgeschuinde vorm ophalen**

Aspose.Slides stelt je in staat om de effectieve eigenschappen van een afgeschuinde vorm op te halen. De interface [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapebeveleffectivedata/) vertegenwoordigt een onveranderlijk object dat effectieve afschuiningseigenschappen voor een vorm bevat. Een [IShapeBevelEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapebeveleffectivedata/)‑instantie wordt blootgesteld via [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformateffectivedata/), die effectieve waarden levert voor [IThreeDFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ithreedformat/).

De volgende code‑voorbeeld toont hoe je de effectieve eigenschappen van de bovenzijde‑afschuining van een vorm kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia 3D‑opmaak heeft.

```csharp
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

Met Aspose.Slides kun je de effectieve eigenschappen van een tekstkader ophalen. De interface [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformateffectivedata/) bevat effectieve opmaakeigenschappen van een tekstkader.

De volgende code‑voorbeeld toont hoe je effectieve opmaak­eigenschappen van een tekstkader kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) met een tekstkader is.

```csharp
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

Met Aspose.Slides kun je de effectieve eigenschappen van een tekststijl ophalen. De interface [ITextStyleEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/itextstyleeffectivedata/) bevat effectieve tekststijleigenschappen.

De volgende code‑voorbeeld toont hoe je effectieve tekststijleigenschappen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) met een tekstkader is.

```csharp
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

## **De effectieve letterhoogte waarde ophalen**

Met Aspose.Slides kun je de effectieve letterhoogte ophalen. De volgende code toont hoe de effectieve letterhoogte van een portie verandert nadat lokale letterhoogte‑waarden op verschillende niveaus van de presentatie‑structuur zijn ingesteld.

```csharp
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

## **Effectief vulformaat voor een tabel ophalen**

Met Aspose.Slides kun je effectieve vulopmaak voor verschillende tabelonderdelen ophalen. De interface [IFillFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/ifillformateffectivedata/) bevat effectieve vulopmaak‑eigenschappen. Celopmaak heeft een hogere prioriteit dan rij‑opmaak, rij‑opmaak heeft een hogere prioriteit dan kolom‑opmaak, en kolom‑opmaak heeft een hogere prioriteit dan volledige‑tabel‑opmaak.

Als gevolg hiervan worden de eigenschappen van [ICellFormatEffectiveData](https://reference.aspose.com/slides/nl/net/aspose.slides/icellformateffectivedata/) gebruikt om de tabelcel te tekenen. De volgende code‑voorbeeld toont hoe je effectieve vulopmaak voor verschillende tabelonderdelen kunt ophalen. Het gaat ervan uit dat de eerste vorm op de eerste dia een [ITable](https://reference.aspose.com/slides/nl/net/aspose.slides/itable/) is.

```csharp
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

**Geeft `GetEffective` een momentopname terug?**

Niet altijd. Effectieve gegevens vertegenwoordigen de berekende opmaak nadat erfelijkheid is toegepast, maar sommige effectieve gegevensobjecten kunnen intern worden gecached. Een latere `GetEffective`‑aanroep kan de opmaak opnieuw berekenen en de cached gegevens verversen, zodat een eerder verkregen object niet moet worden beschouwd als een blijvende momentopname.

**Wanneer moet ik de effectieve eigenschappen opnieuw lezen?**

Roep `GetEffective` opnieuw aan na het wijzigen van lokale opmaak, bovenliggende stijlen, lay‑out‑opmaak, matrix‑opmaak of standaardinstellingen op presentatieniveau. De volgende aanroep herbeoordeelt de opmaakhiërarchie en geeft het huidige effectieve resultaat terug.

**Heeft het wijzigen of verwijderen van een lay‑out/matrixdia invloed op reeds opgehaalde effectieve eigenschappen?**

Ja, maar de wijziging wordt pas zichtbaar bij de volgende `GetEffective`‑aanroep. Als een bovenliggende opmaakbron wordt gewijzigd of verwijderd, kunnen eerder opgehaalde effectieve gegevens verouderd zijn. Zodra `GetEffective` opnieuw wordt aangeroepen, evalueert Aspose.Slides de opmaakboom opnieuw en kunnen de resulterende lettertypen, kleuren, groottes of andere waarden wijzigen.

**Kan ik waarden via effectieve gegevensobjecten aanpassen?**

Nee. Effectieve gegevensobjecten geven slechts berekende waarden weer. Breng wijzigingen aan in de lokale opmaakobjecten en haal vervolgens de effectieve waarden opnieuw op.

**Wat gebeurt er als een eigenschap niet is ingesteld op vormniveau, noch in de lay‑out/matrix, noch in de globale instellingen?**

De effectieve waarde wordt bepaald door het standaardmechanisme, dat de standaardwaarden van PowerPoint en Aspose.Slides omvat. Die bepaalde waarde wordt onderdeel van de huidige effectieve gegevens.

**Kan ik aan een effectieve lettertypewaarde zien op welk niveau de grootte of het lettertype is bepaald?**

Niet rechtstreeks. Effectieve gegevens geven de uiteindelijke waarde terug. Om de bron te achterhalen, controleer je de lokale waarden op portie‑, alinea‑, tekstkader‑ en tekststijlniveau op lay‑out, matrix en presentatieniveau om te zien waar de eerste expliciete definitie voorkomt.

**Waarom lijken effectieve waarden soms identiek aan de lokale?**

Omdat de lokale waarde uiteindelijk de uiteindelijke is (er is geen hogere‑niveau‑erfenis nodig geweest). In dat geval komt de effectieve waarde overeen met de lokale.

**Wanneer moet ik effectieve eigenschappen gebruiken, en wanneer alleen met lokale werken?**

Gebruik effectieve gegevens wanneer je het “as rendered” resultaat nodig hebt na toepassing van alle erfelijkheid, bijvoorbeeld om kleuren, inspringingen of groottes af te stemmen. Als je die waarden wilt behouden, ongeacht latere opmaakwijzigingen, kopieer dan de benodigde eigenschappen naar je eigen object. Als je de opmaak op een specifiek niveau wilt wijzigen, wijzig je de lokale eigenschappen en lees je daarna, indien nodig, de effectieve gegevens opnieuw om het resultaat te verifiëren.