---
title: Hantera presentations‑masterbilder i .NET
linktitle: Bildmaster
type: docs
weight: 80
url: /sv/net/slide-master/
keywords:
- bildmaster
- masterbild
- PPT‑masterbild
- flera masterbilder
- jämför masterbilder
- bakgrund
- platshållare
- klona masterbild
- kopiera masterbild
- duplicera masterbild
- oanvänd masterbild
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera masterbilder i Aspose.Slides för .NET: åtkomst, redigering, kloning, jämförelse och borttagning av masterbilder i PowerPoint- och OpenDocument‑presentationer."
---
## **Översikt**

En **slide master** definierar gemensamma designinställningar för en grupp bilder. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotsinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för .NET stöder samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Normala bilder hänvisar vanligtvis inte direkt till en masterbild. Istället använder en normal bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Slide master** – definierar den gemensamma designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layout‑nivåformatering.  
1. **Normal slide** – innehåller själva presentationsinnehållet och använder en layoutbild.

![Hierarkin av masterbilder, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/). Alla masterbilder i en presentation är tillgängliga via samlingen [Presentation.Masters](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/masters/), som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Tillämpa eller ändra bildlayouter](/slides/sv/net/slide-layout/).
{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn via **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoints flik View](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `Masters` för att komma åt masterbilder:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Du kan också hämta masterbilden som används av en normal bild via dess layout:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Vad en Slide Master innehåller**

En masterbild är ett bild‑liknande objekt. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/), så den exponerar många av samma bildegenskaper som används av normala bilder och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [IMasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/).

Vanligt använda master‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `Background` | Anger master‑nivåns bildbakgrund. |
| `Shapes` | Lagrar former som placerats på masteren, t.ex. logotyper, bildramar och delad text. |
| `LayoutSlides` | Lagrar layoutbilderna som tillhör masteren. |
| `ThemeManager` | Ger åtkomst till master‑tema‑API:er. |
| `HeaderFooterManager` | Styr sidhuvuden, sidfötter, datum och bildnummer för masteren och dess underliggande layouter. |
| `GetDependingSlides` | Returnerar normala bilder som är beroende av masteren via sina layouter. |

## **Lägg till en bild i en Slide Master**

När du lägger till en bild i en masterbild visas den på bilder som använder layouter från den masteren. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

För mer information om bildramar, se [Bildram](/slides/sv/net/picture-frame/).

## **Styr synligheten för mastergrafik**

Använd [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/showmastershapes/) för att dölja ärvd mastergrafik, såsom logotyper eller dekorativa former, utan att ta bort dem från masteren. Sätt [Slide.ShowMasterShapes](https://reference.aspose.com/slides/sv/net/aspose.slides/slide/showmastershapes/) till `false` på den bild som ska utesluta dessa grafiker och behåll den `true` på bilder som ska visa dem.

Följande självständiga exempel skapar ett blått dekorativt band på en master och två bilder som använder samma tomma layout. Bandet är synligt på den första bilden och dolt på den andra. Ingen inmatningspresentation eller bild behövs.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

Exemplet använder layouten **Blank** som levereras med en ny presentation och tar bort den ursprungliga bildens egna platshållare.

### **Välj omfattning för inställningen**

En normal bild använder sin master via [ISlide.LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/islide/layoutslide/) och [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ilayoutslide/masterslide/). Att sätta egenskapen på en enskild bild påverkar endast den bilden. Att sätta [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslide/showmastershapes/) till `false` döljer mastergrafik för bilder som använder den delade layouten, även om deras egna inställning är `true`. För att dölja grafik på endast en bild, ändra bildens egenskap och låt den delade layouten vara orörd.

Inställningen stöds inte som en synlighetskontroll på själva masterbilden. På en master returneras alltid `false`, och att tilldela `true` kastar `NotSupportedException`. Använd den på en normal bild eller en layout istället.

### **Skilj grafik från bakgrunden**

| Åtgärd | Effekt |
| --- | --- |
| Dölj mastergrafik | Styr synligheten för ärvda masterformer utan att ta bort dem eller ändra bildens egna former. |
| Ändra bildens bakgrundsfyllning | Ändrar bakgrundsfärgen, gradienten eller bilden. Mastergrafik är separata former och kan förbli synliga över den bakgrunden. Se [Presentation Background](/slides/sv/net/presentation-background/). |
| Ta bort en form från masteren | Tar bort den delade källformen, så den inte längre är tillgänglig för någon bild som använder den masteren. |

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon i Slide Master‑vyn.

![Infoga platshållarkommando i PowerPoint Slide Master‑vy](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides arbetar du med layoutbilden som tillhör masteren:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titelplatshållaren och tillämpar en linjär gradientfyllning:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Formaterad titelplatshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Ange uppmaningstext i platshållare](/slides/sv/net/manage-placeholder/) och [Textformatering](/slides/sv/net/text-formatting/).

## **Ändra en Slide Master‑bakgrund**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första masterbilden:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

För relaterade ämnen, se [Presentation Background](/slides/sv/net/presentation-background/) och [Presentation Theme](/slides/sv/net/presentation-theme/).

## **Klona en Slide Master till en annan presentation**

Använd [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/addclone/) för att kopiera en masterbild till en annan presentation. Den kopierade masteren kan sedan användas av layouter och bilder i destinationspresentationen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Om du behöver klona normala bilder tillsammans med deras master, se [Klona bilder](/slides/sv/net/clone-slides/).

## **Lägg till flera Slide Masters**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standard‑masteren, ger klonen en annan bakgrund, skapar en layout under den klonade masteren och lägger till en ny bild baserad på den layouten:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Jämför Slide Masters**

Masterbilder kan jämföras med metoden `Equals` som ärvts från [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, som bild‑ID:n, eller dynamiska platshållarvärden, som aktuellt datum.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

För mer information, se [Jämför presentationsbilder](/slides/sv/net/compare-slides/).

## **Ställ in Slide Master‑vyn som standardvy**

Använd egenskapen `LastView` på [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

För fler vyinställningar, se [Spara presentation](/slides/sv/net/save-presentation/).

## **Ta bort oanvända Master Slides**

Presentationer kan ibland innehålla masterbilder som inte längre används av några normala bilder. Att ta bort oanvända masterbilder kan minska filstorleken och förenkla underhållet av mallar.

Använd [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/sv/net/aspose.slides/masterslidecollection/removeunused/) för att ta bort oanvända masterbilder från samlingen `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Du kan även använda lågkods‑metoden [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Vad är skillnaden mellan en slide master och en layoutbild?**

En slide master definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en master och definierar en specifik placering av platshållare. En normal bild använder en layoutbild och ärver därför både från layouten och masteren.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera masterbilder. Använd flera masterbilder när olika avsnitt behöver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare på en masterbild eller en layoutbild?**

I de flesta fall lägger du till platshållare på layoutbilder. Placera delade visuella element och delad formatering på masterbilden och lägg sedan innehålls‑platshållare på de layouter som normala bilder kommer att använda.

**Kan jag ta bort en masterbild som fortfarande används?**

Nej. En masterbild som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en metod för rengöring av oanvända masterbilder som endast tar bort masterbilder som inte är i bruk.