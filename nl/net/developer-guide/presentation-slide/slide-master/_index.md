---
title: Beheer presentatie‑slide‑masters in .NET
linktitle: Dia‑master
type: docs
weight: 80
url: /nl/net/slide-master/
keywords:
- dia master
- master dia
- PPT master dia
- meerdere master dia's
- master dia's vergelijken
- achtergrond
- placeholder
- master dia klonen
- master dia kopiëren
- master dia dupliceren
- ongebruikte master dia
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer slide‑masters in Aspose.Slides voor .NET: toegang, bewerken, klonen, vergelijken en verwijderen van master‑dia's in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Het kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for .NET ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere layoutdia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een normale dia een layoutdia, en die layoutdia behoort tot een masterdia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke indeling van placeholders en lay-outniveau‑opmaak.  
1. **Normal slide** – bevat de feitelijke presentatiewaarde en gebruikt één layout slide.

![De hiërarchie van masterdia's, lay-outdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een slide master weergegeven door de [IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/) interface. Alle masterdia's in een presentatie zijn beschikbaar via de [Presentation.Masters](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/) collectie, die de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/) implementeert.

{{% alert color="info" title="Overerving" %}}
Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een masterdia en een layoutdia beide een achtergrond definiëren, gebruiken dia's op basis van die layout de layout‑achtergrond. Voor meer informatie over layoutdia's, zie [Apply or Change Slide Layouts](/slides/nl/net/slide-layout/).
{{% /alert %}}

## **Toegang tot Slide Masters**

In PowerPoint kunt u de Slide Master‑weergave openen via **View** > **Slide Master**.

![De Slide Master‑opdracht op het PowerPoint‑tabblad View](slide-master_3.jpg)

In Aspose.Slides gebruikt u de `Masters`‑collectie om masterdia's te benaderen:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

U kunt ook de masterdia ophalen die door een normale dia wordt gebruikt via de layout:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Wat een Slide Master Bevat**

Een masterdia is een dia‑achtig object. Het implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/), zodat het vele van dezelfde dia‑eigenschappen blootlegt die door normale en layoutdia's worden gebruikt. Master‑specifieke leden staan vermeld op de [IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/) API‑pagina.

Veelgebruikte masterdia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| `Background` | Stelt de master‑niveau dia‑achtergrond in. |
| `Shapes` | Bewaart vormen die op de master zijn geplaatst, zoals logo's, afbeeldingskaders en gedeelde tekst. |
| `LayoutSlides` | Bewaart de layoutdia's die bij de master horen. |
| `ThemeManager` | Biedt toegang tot de master‑thema‑API's. |
| `HeaderFooterManager` | Regelt kop‑ en voetteksten, datums en dia‑nummers voor de master en de onderliggende lay-outs. |
| `GetDependingSlides` | Retourneert normale dia's die via hun lay‑out afhankelijk zijn van de master. |

## **Afbeelding toevoegen aan een Slide Master**

Wanneer u een afbeelding toevoegt aan een masterdia, verschijnt deze op dia's die lay‑outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste masterdia:

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

Voor meer informatie over afbeeldingskaders, zie [Picture Frame](/slides/nl/net/picture-frame/).

## **Zichtbaarheid van Mastergrafieken beheren**

Gebruik [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/showmastershapes/) om geërfde mastergrafieken, zoals logo's of decoratieve vormen, te verbergen zonder ze uit de master te verwijderen. Stel [Slide.ShowMasterShapes](https://reference.aspose.com/slides/nl/net/aspose.slides/slide/showmastershapes/) in op `false` op de dia die die grafieken moet weglaten en houd het `true` op dia's die ze moeten weergeven.

Het volgende zelf‑containende voorbeeld maakt een blauwe decoratieve band op een master en twee dia's die dezelfde lege lay‑out gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding nodig.

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

Het voorbeeld gebruikt de **Blank**‑lay‑out die bij een nieuwe presentatie wordt geleverd en verwijdert de eigen placeholders van de initiële dia.

### **Kies de reikwijdte van de instelling**

Een normale dia gebruikt zijn master via [ISlide.LayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/layoutslide/) en [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/masterslide/). Het instellen van de eigenschap op een individuele dia heeft alleen effect op die dia. Het instellen van [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/showmastershapes/) op `false` verbergt mastergrafieken voor dia's die die gedeelde lay‑out gebruiken, zelfs als hun eigen instelling `true` is. Om grafieken alleen op één dia te verbergen, wijzig dan de dia‑eigenschap en laat de gedeelde lay‑out ongewijzigd.

De instelling wordt niet ondersteund als een zichtbaarheids‑controle op de masterdia zelf. Op een master retourneert ze altijd `false`, en het toewijzen van `true` veroorzaakt een `NotSupportedException`. Pas het toe op een normale dia of een lay‑out.

### **Grafische elementen onderscheiden van de achtergrond**

| Operatie | Effect |
| --- | --- |
| Mastergrafieken verbergen | Regelt de zichtbaarheid van geërfde mastervormen zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| De dia‑achtergrondvulling wijzigen | Wijzigt de achtergrondkleur, -gradient of -afbeelding. Mastergrafieken zijn aparte vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentation Background](/slides/nl/net/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, zodat deze niet meer beschikbaar is voor dia's die die master gebruiken. |

## **Werken met placeholders**

Placeholders worden normaal gesproken gedefinieerd op layoutdia's. De masterdia levert de gedeelde stijl en het thema dat die lay‑-outs erven, terwijl elke lay‑out bepaalt welke placeholders beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![De opdracht Plaats Placeholder in de Slide Master‑weergave van PowerPoint](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werkt u met de layoutdia die bij de master hoort:

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

U kunt ook placeholder‑vormen formatteren die al op een masterdia bestaan. Het volgende voorbeeld zoekt de titel‑placeholder en past een lineaire gradientvulling toe:

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

![Opgemaakte titel‑placeholder geërfd door normale dia's](slide-master_8.png)

Voor meer placeholder‑ en tekst‑opmaakopties, zie [Set Prompt Text in Placeholder](/slides/nl/net/manage-placeholder/) en [Text Formatting](/slides/nl/net/text-formatting/).

## **Achtergrond van een Slide Master wijzigen**

Een masterachtergrond wordt geërfd door lay‑outs en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

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

Voor gerelateerde onderwerpen, zie [Presentation Background](/slides/nl/net/presentation-background/) en [Presentation Theme](/slides/nl/net/presentation-theme/).

## **Slide Master klonen naar een andere presentatie**

Gebruik [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/) om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan dan worden gebruikt door lay‑outs en dia's in de bestemmingspresentatie.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Als u normale dia's samen met hun master wilt klonen, zie [Clone Slides](/slides/nl/net/clone-slides/).

## **Meerdere Slide Masters toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is nuttig wanneer verschillende secties verschillende branding, paginaststructuur of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaardmaster, geeft de kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die lay‑out:

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

## **Slide Masters vergelijken**

Masterdia's kunnen worden vergeleken met de `Equals`‑methode die afkomstig is van [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifieren, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

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

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/net/compare-slides/).

## **Slide Master‑weergave instellen als standaardweergave**

Gebruik de `LastView`‑eigenschap op [ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/net/save-presentation/).

## **Niet‑gebruikte Master Slides verwijderen**

Presentaties bevatten soms masterdia's die niet langer door enige normale dia worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslidecollection/removeunused/) om ongebruikte masters te verwijderen uit de `Masters`‑collectie:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

U kunt ook de low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) methode gebruiken:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Wat is het verschil tussen een slide master en een layout slide?**  
Een slide master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout slide behoort tot een master en definieert een specifieke indeling van placeholders. Een normale dia gebruikt een layout slide, waardoor hij zowel van de layout als van de master erft.

**Kan een presentatie meerdere slide masters bevatten?**  
Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties andere visuele systemen of branding nodig hebben.

**Moet ik placeholders toevoegen aan een master slide of een layout slide?**  
In de meeste gevallen voegt u placeholders toe aan layoutdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de master slide, en plaats content‑placeholders op de lay‑outs die normale dia's zullen gebruiken.

**Kan ik een master slide verwijderen die nog wordt gebruikt?**  
Nee. Een master slide met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats die dia's eerst naar lay‑outs onder een andere master, of gebruik een opruimmethode die alleen ongebruikte masters verwijdert.