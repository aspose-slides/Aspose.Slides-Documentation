---
title: Hantera bildmaster i presentationer i .NET
linktitle: Bildmaster
type: docs
weight: 80
url: /sv/net/slide-master/
keywords:
- bildmaster
- masterbild
- PPT-masterbild
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
description: "Hantera bildmaster i Aspose.Slides för .NET: åtkomst, redigering, kloning, jämförelse och borttagning av masterbilder i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **bildmaster** definierar delade designinställningar för en grupp bilder. Den kan innehålla gemensamma former, logotyper, bakgrunder, textstilar, temainställningar och sidfotsinställningar. I PowerPoint är redigering av en bildmaster det normala sättet att hålla en presentation enhetlig utan att upprepa samma formatering på varje bild.

Aspose.Slides för .NET stöder samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Vanliga bilder refererar vanligtvis inte direkt till en masterbild. Istället använder en vanlig bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Bildmaster** – definierar den delade designen och temat.  
1. **Layoutbild** – definierar en specifik placering av platshållare och layoutnivåformatering.  
1. **Normal bild** – innehåller det faktiska presentationsinnehållet och använder en layoutbild.

![Hierarkin av masterbilder, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en bildmaster av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/) . Alla masterbilder i en presentation är tillgängliga via samlingen [Presentation.Masters](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/masters/) som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå, vinner den mer specifika nivån. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Apply or Change Slide Layouts](/slides/sv/net/slide-layout/).
{{% /alert %}}

## **Åtkomst till bildmaster**

I PowerPoint kan du öppna Bildmaster‑vyn från **Visa** > **Bildmaster**.

![Bildmaster‑kommandot på PowerPoints flik Visa](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `Masters` för att komma åt masterbilder:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Du kan också hämta masterbilden som en normal bild använder via dess layout:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Vad en bildmaster innehåller**

En masterbild är ett bildlikt objekt. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/), så den exponerar många av samma bildegenskaper som används av normala bilder och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [IMasterSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslide/).

Vanligt använda masterbild‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `Background` | Anger master‑nivåns bildbakgrund. |
| `Shapes` | Lagrar former placerade på masterbilden, såsom logotyper, bildramar och delad text. |
| `LayoutSlides` | Lagrar layoutbilderna som tillhör masterbilden. |
| `ThemeManager` | Ger åtkomst till master‑tema‑API:erna. |
| `HeaderFooterManager` | Styr sidhuvuden, sidfötter, datum och bildnummer för masterbilden och dess underliggande layouter. |
| `GetDependingSlides` | Returnerar normala bilder som är beroende av masterbilden via deras layouter. |

## **Lägg till en bild i en bildmaster**

När du lägger till en bild i en masterbild visas den på bilder som använder layouter från den masterbilden. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

```csharp
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

För mer information om bildramar, se [Picture Frame](/slides/sv/net/picture-frame/).

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint är platshållarkommandon tillgängliga i Bildmaster‑vyn.

![Infoga platshållare‑kommandot i PowerPoints Bildmaster‑vy](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides arbetar du med den layoutbild som tillhör masterbilden:

```csharp
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

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titel‑platshållaren och applicerar en linjär gradientfyllning:

```csharp
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

![Formaterad titel‑platshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/net/manage-placeholder/) och [Text Formatting](/slides/sv/net/text-formatting/).

## **Ändra en bildmasters bakgrund**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första masterbilden:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

För relaterade ämnen, se [Presentation Background](/slides/sv/net/presentation-background/) och [Presentation Theme](/slides/sv/net/presentation-theme/).

## **Klona en bildmaster till en annan presentation**

Använd [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/sv/net/aspose.slides/imasterslidecollection/addclone/) för att kopiera en masterbild till en annan presentation. Den kopierade masterbilden kan sedan användas av layouter och bilder i mål‑presentationen.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Om du behöver klona normala bilder tillsammans med deras master, se [Clone Slides](/slides/sv/net/clone-slides/).

## **Lägg till flera bildmaster**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika sektioner kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standard‑masterbilden, ger klonen en annan bakgrund, skapar en layout under den klonade masterbilden och lägger till en ny bild baserad på den layouten:

```csharp
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

## **Jämför bildmaster**

Masterbilder kan jämföras med `Equals`‑metoden som ärvd från [IBaseSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

```csharp
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

För mer information, se [Compare Presentation Slides](/slides/sv/net/compare-slides/).

## **Ställ in Bildmaster‑vyn som standardvyn**

Använd egenskapen `LastView` på [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/) för att kontrollera vilken vy som PowerPoint öppnar först. Följande exempel öppnar presentationen i Bildmaster‑vyn:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

För fler vyinställningar, se [Save Presentation](/slides/sv/net/save-presentation/).

## **Ta bort oanvända masterbilder**

Presentationer kan ibland innehålla masterbilder som inte längre används av några normala bilder. Att ta bort oanvända masterbilder kan minska filstorleken och förenkla underhållet av mallar.

Använd [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/sv/net/aspose.slides/masterslidecollection/removeunused/) för att ta bort oanvända masterbilder från samlingen `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Du kan också använda low‑code‑metoden [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/sv/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Vad är skillnaden mellan en bildmaster och en layoutbild?**

En bildmaster definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en masterbild och definierar en specifik placering av platshållare. En normal bild använder en layoutbild, så den ärver både från layouten och masterbilden.

**Kan en presentation innehålla flera bildmaster?**

Ja. En presentation kan innehålla flera bildmaster. Använd flera masterbilder när olika sektioner behöver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare i en masterbild eller en layoutbild?**

I de flesta fall bör du lägga till platshållare i layoutbilder. Placera delade visuella element och gemensam formatering på masterbilden och lägg sedan innehållsplatshållare på de layouter som normala bilder kommer att använda.

**Kan jag ta bort en masterbild som fortfarande används?**

Nej. En masterbild som har beroende bilder kan inte säkert tas bort direkt. Flytta först de bilderna till layouter under en annan master, eller använd en metod för att rensa oanvända masterbilder som endast tar bort masterbilder som inte är i bruk.