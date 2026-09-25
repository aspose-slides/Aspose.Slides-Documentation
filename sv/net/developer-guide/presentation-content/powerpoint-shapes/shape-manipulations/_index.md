---
title: Hantera presentationens former i .NET
linktitle: Formmanipulation
type: docs
weight: 40
url: /sv/net/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formjusteringspunkt
- förinställd formjustering
- formgeometri
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- vänd form
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, ändrar ordning, exporterar, justerar och vänder presentationsformer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och modifierar former samt källan till deras staplingsordning: index `0` är den längst bak, medan det sista indexet är den längst fram.

Denna artikel följer den modellen. Den förklarar först hur du på ett pålitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur du klonar, tar bort, döljer och omordnar former. De sista sektionerna täcker layout‑nivåformatering, SVG‑export, justering och speglingsinställningar. Varje exempel är fristående, så du kan använda bara de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingsindex är praktiska när du bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan ändra dess index. Välj en identifierare enligt hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/name/) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och garanteras inte unika, så etablera en namnkonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/alternativetext/) är användbart när en tillgänglighetsbeskrivning eller en författarskapad tagg redan identifierar formen. Den är synlig för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och garanteras inte unik. Återanvänd inte meningsfull tillgänglighetstext som en databasnyckel i hemlighet.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/officeinteropshapeid/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en otvetydig referens under en formes livstid. En klonad eller återskapad form är en annan form och får ett eget ID.

Den relaterade egenskapen [UniqueId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/uniqueid/) har presentationsomfång, men är avsedd för tillägg och kan omfördelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är viktig, håll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

För ett praktiskt exempel på att läsa och uppdatera både alternativ text‑titel och beskrivning, se [Manage Alternative Text Titles and Descriptions](/slides/sv/net/presentation-accessibility/). Använd alternativ text för att förklara visuell betydelse för läsare, och håll den separerad från formnamn som kod använder för att hitta former.

Följande exempel söker efter `Name` med en ordinal jämförelse och rapporterar den bild‑omfattande interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

När en operation är specifik för en formtyp, kontrollera gränssnittet innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).

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

## **Identifiera och ändra förinställda formjusteringar**

Förinställda geometriformer kan exponera justeringspunkter som styr egenskaper som hörnstorlek, pilförhållanden eller båg‑vinklar. Åtkomst sker via den skrivskyddade [IGeometryShape.Adjustments](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/adjustments/)‑samlingen. Själva samlingen tillhandahålls av formen, men varje [IAdjustValue](https://reference.aspose.com/slides/sv/net/aspose.slides/iadjustvalue/) innehåller ett värde som kan ändras.

Lita inte bara på ett fast samlingsindex. Iterera genom justeringarna och inspektera den skrivskyddade [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/type/)‑egenskapen, vars [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeadjustmenttype/)‑värde beskriver vad justeringen styr. Den skrivskyddade [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/name/)‑egenskapen ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd värdeegenskapen som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CornerSize` | Storlek på avrundade hörn | [RawValue](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Tjocklek på en pilsvans | `RawValue` |
| `ArrowheadLength` | Längd på en pilspets | `RawValue` |
| `ArrowheadWidth` | Bredd på en pilspets | `RawValue` |
| `StartAngle` | Startvinkel för en tårtbit eller båge | [AngleValue](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Slutvinkel för en tårtbit eller båge | `AngleValue` |

`Type` och `Name` kan inte tilldelas. `RawValue` är ett läs‑/skriv‑heltal i förinställningens ursprungliga geometrienheter, medan `AngleValue` är en läs‑/skriv‑vinkel i grader. Antalet, ordningen, innebörden och det giltiga intervallet för justeringar beror på förinställningens [ShapeType](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/shapetype/). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha en annan effekt för en annan.

När `Type` är `ShapeAdjustmentType.Custom` känner API‑et inte igen en standard semantisk betydelse. Inspektera `Name`, förinställningstypen och det befintliga värdet, och lämna justeringen oförändrad om den förväntade betydelsen och intervallet inte är känt. Även för igenkända typer, kontrollera om samma typ förekommer mer än en gång innan du väljer ett värde. Artikeln [Connector](/slides/sv/net/connector/) visar detta scenario med justeringar av connector‑böjningar.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess `Name` och `Type`, ändrar storleksrelaterade värden via `RawValue`, ändrar vinklar via `AngleValue` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra kolumnen visar den justerade avrundade rektangeln, fyrvägs‑pilen och tårtbiten.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Lägger till rubriker för standard- och justerade formkolumner.
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

Att kontrollera den semantiska typen innan ett värde ändras gör koden explicit om avsikten och undviker antagandet att ett visst samlingsindex har samma innebörd över olika förinställda former.

## **Ändra form‑samlingen**

Metoderna för att lägga till, klona, ta bort och omordna verkar direkt på samlingen. Om en operation ändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som fångats innan den operationen.

### **Klona en form**

[AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addclone/) skapar en självständig kopia och lägger till den i mål‑samlingen. [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/insertclone/) skapar också en kopia men placerar den på ett specificerat z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra storlek; överlagringarna med bredd och höjd kan även ändra storlek.

Exemplet skapar en destinationsbild, klonar en märkt rektangel till framsidan och infogar en andra klon längst bak. Ändringar i någon av klonerna påverkar inte källformen.

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

Klonning kopierar formens innehåll och formatering, inklusive dess namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/remove/) raderar ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under indexerad iteration, gå igenom från slutet så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett bestämt namn. Det läser `slide.Shapes[i]`, inte ett fast samlingsobjekt, och kastar inte formen onödigt.

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

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former är mer pålitliga än sparade index. Tänk också på connectors, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/hidden/) till `true` behåller formen i samlingen men hindrar den från att visas i den normala bildspeln. Dess index, formatering och innehåll förblir tillgängliga för kod, så dold är lämpligt för valfria element som kan återställas senare.

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

Döljning är ingen radering eller säkerhetsåtgärd. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra z‑ordning**

Överlappande former målas i samlingsordning. [Reorder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är längst bak; `Count - 1` är längst fram.

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

Rektangeln skapas först och ligger initialt bakom ellipsen. Att flytta den till det sista indexet placerar den framåt. Slutför z‑ordning efter att du har lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Granska former på layout‑bilder**

Normala bilder, layout‑bilder och maste­rbilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Granska layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

Följande exempel läser varje layout‑forms [FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/fillformat/) och [LineFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/lineformat/) utan att anta att varje form är en `AutoShape`.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[WriteAsSvg](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/writeassvg/) skriver en forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildbakgrunden eller intilliggande former.

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

Behåll presentationen öppen under rendering. Utdata beror på formens formatering samt resurser som teckensnitt och bilder. Om du behöver hela kompositionen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste avyttra den.

## **Justera former**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/alignshapes/)‑överlagringarna justerar antingen alla former eller utvalda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller fördelningsläge. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former mot bildens överkant. De återgivna formreferenserna konverteras till sina aktuella index omedelbart före justeringen.

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

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning behöver tillräckligt många former för att definiera avstånd. Beräkna om index om du modifierar samlingen innan du anropar metoden.

## **Spegelvänd en form**

Klassen [ShapeFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/) lagrar position, storlek, horisontella och vertikala spegelinställningar samt rotation. Dess `FlipH`‑ och `FlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/): `True` aktiverar spegeln, `False` inaktiverar den, och `NotDefined` bevarar det ospecificerade/default‑tillståndet.

Den inmatade presentationen nedan innehåller en icke‑spegelvänd form.

![The shape before flipping](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter bara de två spegelinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/frame/)‑tilldelning ersätter hela ramen.

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

Den sparade formen är spegelvänd horisontellt och vertikalt samtidigt som dess position, storlek och rotation behålls.

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Only for short-lived processing when the collection will not change before the index is used. Prefer a validated `Name` or `AlternativeText` convention for authored templates, or `OfficeInteropShapeId` for slide-scoped interop work.

**Does hiding a shape remove it from the z-order?**

No. A hidden shape remains in the collection at the same index. It can be found, reordered, edited, or made visible again.

**Why did a cloned shape appear in front of another shape?**

`AddClone` appends the clone to the end of the collection, which is the front of the z-order. Use `InsertClone` to choose the initial index or `Reorder` after all shapes have been added.

**Can I use a fixed index to identify a preset shape adjustment?**

Only after validating the exact preset and collection layout. Prefer iterating through `IGeometryShape.Adjustments` and checking `IAdjustValue.Type`; use `IAdjustValue.Name` as additional information when the same semantic type appears more than once.