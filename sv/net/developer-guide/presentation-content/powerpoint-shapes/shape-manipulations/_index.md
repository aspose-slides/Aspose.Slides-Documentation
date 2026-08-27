---
title: Hantera presentationsformer i .NET
linktitle: Formmanipulering
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
- hämta interop form-ID
- formens alternativtext
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
description: "Lär dig hur du identifierar, justerar, klonar, tar bort, döljer, omordnar, exporterar, justerar och vänder presentationsformer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan för deras staplingsordning: index `0` är den bakre formen, medan det sista indexet är den främsta formen.

Denna artikel följer den modellen. Den förklarar först hur du på ett tillförlitligt sätt identifierar en form och ändrar förinställda justeringspunkter, och visar sedan hur du klonar, tar bort, döljer och omordnar former. De sista avsnitten täcker formateringsnivå på layout, SVG‑export, justering och vändningsinställningar. Varje exempel är oberoende, så du kan använda endast de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Samlingsindex är praktiska när du bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller omordna en form kan förändra dess index. Välj en identifierare utifrån hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/name/) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/alternativetext/) är användbart när en tillgänglighetsbeskrivning eller en författargiven tagg redan identifierar formen. Den är synlig för användare, kan lokalanpassas eller skrivas om för tillgänglighet, och är inte garanterad att vara unik. Återanvänd inte tyst meningsfull tillgänglighetstext som en databaskey.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/officeinteropshapeid/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den shape‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller återskapad form är en annan form och får sitt eget ID.

Den relaterade [UniqueId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/uniqueid/)‑egenskapen har presentationsomfång, men är avsedd för tillägg och kan återtilldelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är avgörande, behåll mappningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker med `Name` med en ordinal jämförelse och rapporterar den bild‑specifika interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

Förinställda geometriska former kan exponera justeringspunkter som styr egenskaper såsom hörnstorlek, pilproportioner eller båg‑vinklar. Åtkomst sker via den skrivskyddade [IGeometryShape.Adjustments](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/adjustments/)‑samlingen. Samlingen tillhandahålls av formen, men varje [IAdjustValue](https://reference.aspose.com/slides/sv/net/aspose.slides/iadjustvalue/) innehåller ett värde som kan ändras.

Lita inte enbart på ett fast samlingsindex. Iterera genom justeringarna och inspektera den skrivskyddade [Type](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/type/)‑egenskapen, vars [ShapeAdjustmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeadjustmenttype/)‑värde beskriver vad justeringen styr. Den skrivskyddade [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/name/)‑egenskapen ger ytterligare identifieringsinformation och är särskilt användbar när en förinställning innehåller mer än en justering med samma semantiska typ.

Använd den värdeegenskap som matchar justeringens innebörd:

| Justeringstyp | Syfte | Värde att ändra |
|---|---|---|
| `CornerSize` | Storlek på rundade hörn | [RawValue](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Tjocklek på pilspets | `RawValue` |
| `ArrowheadLength` | Längd på pilspets | `RawValue` |
| `ArrowheadWidth` | Bredd på pilspets | `RawValue` |
| `StartAngle` | Startvinkel för en tårtbit eller båge | [AngleValue](https://reference.aspose.com/slides/sv/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Slutvinkel för en tårtbit eller båge | `AngleValue` |

`Type` och `Name` kan inte tilldelas. `RawValue` är ett läs‑/skriv‑heltal i förinställningens ursprungliga geometrienheter, medan `AngleValue` är ett läs‑/skriv‑vinkelvärde i grader. Antalet, ordningen, betydelsen och det giltiga intervallet för justeringar beror på förinställningens [ShapeType](https://reference.aspose.com/slides/sv/net/aspose.slides/igeometryshape/shapetype/). Ett värde som är giltigt för en förinställning kan vara ogiltigt eller ha annan effekt för en annan.

När `Type` är `ShapeAdjustmentType.Custom` känner API‑et inte igen någon standard‑semantisk betydelse. Inspektera `Name`, förinställningstypen och det befintliga värdet, och låt justeringen vara oförändrad såvida inte den förväntade betydelsen och intervallet är känt. Även för erkända typer, kontrollera om samma typ förekommer mer än en gång innan du väljer ett värde. Artikeln [Connector](/slides/sv/net/connector/) visar detta scenario med justeringar av böjning på anslutare.

Följande kompletta exempel skapar standard‑ och modifierade versioner av tre förinställda former. Det itererar genom varje justering, rapporterar dess `Name` och `Type`, ändrar storleksrelaterade värden via `RawValue`, ändrar vinklar via `AngleValue` och sparar resultatet. Den vänstra kolumnen behåller standardgeometrin; den högra kolumnen visar den justerade rundade rektangeln, fyrvägs‑pilen och tårtbiten.

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

Att kontrollera den semantiska typen innan ett värde ändras gör koden tydlig i sin avsikt och undviker antagandet att ett visst samlingsindex har samma betydelse över olika förinställda former.

## **Ändra formsamlingen**

Metoderna för att lägga till, klona, ta bort och omordna fungerar på samlingen omedelbart. Om en operation förändrar antalet eller ordningen av former, fortsätt inte att förlita dig på index som fångats innan den operationen.

### **Klona en form**

[AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addclone/) skapar en oberoende kopia och lägger till den i mål‑samlingen. [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/insertclone/) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringar som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storleken.

Exemplet skapar en målbild, klonar en märkt rektangel till fronten och infogar en andra klon i bakgrunden. Ändringar på någon av klonerna påverkar inte källformen.

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

Kloning kopierar formens innehåll och formatering, inklusive namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/remove/) raderar ett specifikt formobjekt från dess samling. När flera matchningar tas bort under indexerad iteration, gå igenom samlingen bakifrån så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser `slide.Shapes[i]`, inte ett fast samlingsobjekt, och kastar inte formen onödigt.

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

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutare, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan förändra mer än bara bildens utseende.

### **Dölja en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/hidden/) till `true` behåller formen i samlingen men förhindrar att den visas i det normala bildspelet. Dess index, formatering och innehåll förblir tillgängliga för kod, så doldning är lämplig för valfria element som kan återställas senare.

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

Dölja är inte borttagning eller säkerhet. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordningen**

Överlappande former målas i samlingsordning. [Reorder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bak, `Count - 1` är fram.

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

Rektangeln skapas först och ligger initialt bakom ellipsen. Att flytta den till det sista indexet placerar den framtill. Slutför z‑ordningen efter att alla relaterade former har lagts till eller klonats, eftersom de operationerna lägger till eller infogar nya samlingsobjekt och kan ändra den avsedda stapeln.

## **Inspektera former på layoutbilder**

Normala bilder, layoutbilder och mastebilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en likadant placerad form på en normal bild. Inspektera layoutformer när du behöver förstå eller ändra formatering som tillhandahålls av en layout.

Följande exempel läser varje layoutforms [FillFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/fillformat/) och [LineFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/lineformat/) utan att anta att varje form är en `AutoShape`.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layoutform, avgör om en normal bild ärver objektet eller har en lokal överskuggning, och testa varje bild som använder den layouten.

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

Behåll presentationen öppen under rendering. Utdata beror på formens formatering och på resurser såsom teckensnitt och bilder. Om du behöver hela kompositionen, exportera bilden snarare än en enskild form. Anroparen äger strömmen och måste avyttra den.

## **Justera former**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/alignshapes/)‑överladdningarna justerar antingen alla former eller utvalda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller fördelningsläge. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former mot bildens övre kant. De returnerade formreferenserna konverteras till sina aktuella index omedelbart före justeringen.

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

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om indexen om du ändrar samlingen innan du anropar metoden.

## **Vända en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala vändningsinställningar samt rotation. Dess `FlipH` och `FlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/): `True` aktiverar vändning, `False` inaktiverar den, och `NotDefined` bevarar det odefinierade/standardtillståndet.

Den inmatade presentationen nedan innehåller en ovänd form.

![Formen före spegling](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två vändningsinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/frame/) ersätter hela ramen.

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

Den sparade formen speglas horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![Formen efter spegling](flipped_shape.png)

## **FAQ**

**Bör jag använda ett samlingsindex som formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för skapade mallar, eller `OfficeInteropShapeId` för bild‑specifik interop‑arbete.

**Tar dolda former bort sig från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför placerades en klonad form framför en annan form?**

`AddClone` lägger till klonen i slutet av samlingen, vilket är fronten i z‑ordningen. Använd `InsertClone` för att välja startindex eller `Reorder` efter att alla former har lagts till.

**Kan jag använda ett fast index för att identifiera en förinställd formjustering?**

Endast efter att ha validerat exakt förinställning och samlingslayout. Föredra att iterera genom `IGeometryShape.Adjustments` och kontrollera `IAdjustValue.Type`; använd `IAdjustValue.Name` som ytterligare information när samma semantiska typ förekommer mer än en gång.