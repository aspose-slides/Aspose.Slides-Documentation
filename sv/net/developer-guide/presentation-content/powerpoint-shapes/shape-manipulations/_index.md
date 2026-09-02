---
title: Hantera presentationsformer i .NET
linktitle: Formhantering
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
- dölja form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- vända form
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du identifierar, klonar, tar bort, döljer, omordnar, exporterar, justerar och vänder presentationsformer med Aspose.Slides för .NET."
---
## **Översikt**

Aspose.Slides for .NET representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/). Kollektionen är både platsen där du hittar och ändrar former och källan för deras staplingsordning: index `0` är den bakre formen, medan det sista indexet är den främsta formen.

Denna artikel följer den modellen. Den förklarar först hur man på ett pålitligt sätt identifierar en form, och visar sedan hur man klonar, tar bort, döljer och ändrar ordning på former. De sista avsnitten behandlar layoutnivåformatering, SVG‑export, justering och vändinställningar. Varje exempel är fristående, så du kan använda bara de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

Kollektionsindex är praktiska när man bearbetar en känd fil, men de är inte stabila identifierare. Att lägga till, ta bort eller ändra ordning på en form kan ändra dess index. Välj en identifierare enligt hur presentationen skapas och underhålls:

- [Name](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/name/) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvalspanel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/alternativetext/) är användbart när en tillgänglighetsbeskrivning eller en författargiven tagg redan identifierar formen. Den är synlig för användare, kan lokaliseras eller skrivas om för tillgänglighet och är inte garanterad att vara unik. Återskapa inte tyst meningsfull tillgänglighetstext som en databasnyckel.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/officeinteropshapeid/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under hela formens livstid. En klonad eller återskapad form är en annan form och får sitt eget ID.

Den relaterade egenskapen [UniqueId](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/uniqueid/) har presentationsomfång, men är avsedd för tillägg och kan återtilldelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är väsentlig, håll kartläggningen i applikationsdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter `Name` med en ordinal jämförelse och rapporterar den bild‑specifika interop‑ID:n. När mallen inte innehåller den förväntade formen rapporterar koden det resultatet istället för att fortsätta med fel objekt.

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

## **Ändra formsamlingen**

Metoderna för att lägga till, klona, ta bort och ändra ordning opererar på kollektionen omedelbart. Om en operation ändrar antalet eller ordningen på former, fortsätt inte att förlita dig på index som fångades före den operationen.

### **Klona en form**

[AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/addclone/) skapar en oberoende kopia och lägger till den i slutet av målkolelsen. [InsertClone](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/insertclone/) skapar också en kopia men placerar den på ett specificerat z‑order‑index. Överlagringar som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storlek.

Exemplet skapar en mål‑bild, klonar en märkt rektangel till framsidan och infogar en andra klon längst bak. Ändringar i någon av klonerna påverkar inte källformen.

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

Kloning kopierar formens innehåll och formatering, inklusive dess namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon är ett nytt kollektionsobjekt med en ny formidentitet.

### **Ta bort former**

[Remove](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/remove/) tar bort ett specifikt formobjekt från dess kollektion. När du tar bort flera matchningar under indexerad iteration, gå från slutet så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett bestämt namn. Det läser `slide.Shapes[i]`, inte ett fast kollektionsobjekt, och det kastar inte formen onödigt.

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

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på anslutningar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bildens utseende.

### **Dölj en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/hidden/) till `true` behåller formen i kollektionen men hindrar den från att visas i den normala bildspelsvisningen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dold är lämplig för valfria element som kan återställas senare.

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

Döljning är inte borttagning eller säkerhet. Objektet kan fortfarande upptäckas och göras synligt igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i kollektionsordning. [Reorder](https://reference.aspose.com/slides/sv/net/aspose.slides/ishapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bakåt; `Count - 1` är framåt.

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

Rektangeln skapas först och ligger initialt bakom ellipsen. Att flytta den till det sista indexet placerar den längst fram. Slutför z‑ordning efter att ha lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya kollektionsobjekt och kan ändra den avsedda stapeln.

## **Inspektera former på layoutbilder**

Normala bilder, layoutbilder och maste­rbilder har separata form‑kollektioner. En form i en layout‑kollektion är inte samma objekt som en likadant placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som levereras av en layout.

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

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[WriteAsSvg](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/writeassvg/) skriver en forms renderade innehåll till en ström. Resultatet innehåller bara formen, inte hela bildbakgrunden eller närliggande former.

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

Håll presentationen öppen under rendering. Utdata beror på formens formatering samt på resurser som teckensnitt och bilder. Om du behöver hela sammansättningen, exportera bilden istället för en enskild form. Den som anropar äger strömmen och måste disponera den.

## **Justera former**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/sv/net/aspose.slides.util/slideutil/alignshapes/)‑överladdningar justerar antingen alla former eller valda kollektionsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/net/aspose.slides/shapesalignmenttype/) specificerar kant, mittlinje eller distributionsläge. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt den till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens överkant. De återvända formreferenserna konverteras till sina aktuella index omedelbart innan justering.

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

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om indexen om du ändrar kollektionen innan du anropar metoden.

## **Vänd en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala vändinställningar samt rotation. Dess `FlipH`‑ och `FlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/net/aspose.slides/nullablebool/): `True` aktiverar vändning, `False` inaktiverar den, och `NotDefined` bevarar det odefinierade/std‑standardtillståndet.

Den inkommande presentationen nedan innehåller en opåverkad form.

![Formen före vändning](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två vändinställningarna. Detta är viktigt eftersom en ny [Frame](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/frame/) ersätter hela ramen.

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

Den sparade formen är speglad horisontellt och vertikalt samtidigt som position, storlek och rotation behålls.

![Formen efter vändning](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

Endast för kortlivad bearbetning när kollektionen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för författade mallar, eller `OfficeInteropShapeId` för interop‑arbete på bildnivå.

**Does hiding a shape remove it from the z-order?**

Nej. En dold form förblir i kollektionen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Why did a cloned shape appear in front of another shape?**

`AddClone` lägger till klonen i slutet av kollektionen, vilket är fronten av z‑ordningen. Använd `InsertClone` för att välja ett initialt index eller `Reorder` efter att alla former har lagts till.