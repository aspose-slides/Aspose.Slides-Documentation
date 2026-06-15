---
title: Beheer dia‑masters in presentaties in .NET
linktitle: Dia‑master
type: docs
weight: 80
url: /nl/net/slide-master/
keywords:
- dia‑master
- masterdia
- PPT‑masterdia
- meerdere masterdia's
- masterdia's vergelijken
- achtergrond
- tijdelijke aanduiding
- masterdia klonen
- masterdia kopiëren
- masterdia dupliceren
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer dia‑masters in Aspose.Slides voor .NET: toegang, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Een **dia‑master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Hij kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een dia‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor .NET ondersteunt hetzelfde model. Een presentatie kan een of meer dia‑masters bevatten, en elke dia‑master kan verschillende lay‑outdia's bevatten. Normale dia's verwijzen doorgaans niet rechtstreeks naar een dia‑master. In plaats daarvan gebruikt een normale dia een lay‑outdia, en die lay‑outdia behoort tot een dia‑master.

De hiërarchie is:

1. **Dia‑master** – definieert het gedeelde ontwerp en thema.  
1. **Lay‑outdia** – definieert een specifieke ordening van tijdelijke aanduidingen en lay‑out‑level opmaak.  
1. **Normale dia** – bevat de daadwerkelijke presentatiestructuur en gebruikt één lay‑outdia.

![De hiërarchie van masterdia's, lay‑outdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een dia‑master weergegeven door de interface [IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/). Alle dia‑masters in een presentatie zijn beschikbaar via de collectie [Presentation.Masters](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/), die de interface [IMasterSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/) implementeert.

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een dia‑master en een lay‑outdia beide een achtergrond definiëren, gebruiken dia's die gebaseerd zijn op die lay‑out de lay‑out‑achtergrond. Voor meer informatie over lay‑outdia's, zie [Toepassen of wijzigen van dia‑lay‑outs](/slides/nl/net/slide-layout/).
{{% /alert %}}

## **Toegang tot dia‑masters**

In PowerPoint kun je de weergave **Dia‑master** openen via **Weergave** > **Dia‑master**.

![De Dia‑master‑opdracht op het PowerPoint‑tabblad Weergave](slide-master_3.jpg)

In Aspose.Slides gebruik je de collectie `Masters` om toegang te krijgen tot dia‑masters:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Je kunt ook de dia‑master opvragen die door een normale dia wordt gebruikt via de lay‑out ervan:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Wat een dia‑master bevat**

Een dia‑master is een object dat op een dia lijkt. Hij implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/), zodat hij veel van dezelfde dia‑eigenschappen blootlegt die door normale en lay‑outdia's worden gebruikt. Master‑specifieke leden staan opgesomd op de API‑pagina van [IMasterSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslide/).

Veelgebruikte leden van een dia‑master zijn:

| Lid | Doel |
| --- | --- |
| `Background` | Stelt de achtergrond van de dia‑master in. |
| `Shapes` | Bewaart vormen die op de master staan, zoals logo's, fotokaders en gedeelde tekst. |
| `LayoutSlides` | Bewaart de lay‑outdia's die bij de master horen. |
| `ThemeManager` | Biedt toegang tot de master‑thema‑API's. |
| `HeaderFooterManager` | Beheert kopteksten, voetteksten, datums en dia‑nummers voor de master en zijn onderliggende lay‑outs. |
| `GetDependingSlides` | Retourneert normale dia's die via hun lay‑outs afhankelijk zijn van de master. |

## **Afbeelding toevoegen aan een dia‑master**

Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt deze op dia's die lay‑outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste dia‑master:

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

Voor meer informatie over fotokaders, zie [Fotokader](/slides/nl/net/picture-frame/).

## **Werken met tijdelijke aanduidingen**

Tijdelijke aanduidingen worden normaal gesproken gedefinieerd op lay‑outdia's. De dia‑master levert de gedeelde stijl en het thema dat die lay‑outs erven, terwijl elke lay‑out beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn de opdrachten voor tijdelijke aanduidingen beschikbaar in de weergave Dia‑master.

![De opdracht Tijdelijke aanduiding invoegen in PowerPoint‑dia‑master‑weergave](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de lay‑outdia die bij de master hoort:

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

Je kunt ook de vorm van een al bestaande tijdelijke aanduiding op een dia‑master opmaken. Het volgende voorbeeld zoekt de titel‑tijdelijke aanduiding en past een lineaire kleurverloopvulling toe:

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

![Opgemaakte titel‑tijdelijke aanduiding geërfd door normale dia's](slide-master_8.png)

Voor meer opties voor tijdelijke aanduidingen en tekstopmaak, zie [Prompt‑tekst instellen in tijdelijke aanduiding](/slides/nl/net/manage-placeholder/) en [Tekstopmaak](/slides/nl/net/text-formatting/).

## **Achtergrond van een dia‑master wijzigen**

Een master‑achtergrond wordt geërfd door lay‑outs en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste dia‑master:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Voor gerelateerde onderwerpen, zie [Achtergrond van de presentatie](/slides/nl/net/presentation-background/) en [Thema van de presentatie](/slides/nl/net/presentation-theme/).

## **Dia‑master klonen naar een andere presentatie**

Gebruik [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterslidecollection/addclone/) om een dia‑master te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door lay‑outs en dia's in de doelfile.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Als je normale dia's wilt klonen samen met hun master, zie [Dia's klonen](/slides/nl/net/clone-slides/).

## **Meerdere dia‑masters toevoegen**

Een presentatie kan meerdere dia‑masters bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginacompositie of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van dia‑masters](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard‑master, geeft de kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master en voegt een nieuwe dia toe op basis van die lay‑out:

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

## **Dia‑masters vergelijken**

Dia‑masters kunnen worden vergeleken met de `Equals`‑methode die is geërfd van [IBaseSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ibaseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers, zoals dia‑ID's, of dynamische tijdelijke‑aanduidingswaarden, zoals de huidige datum, worden niet meegewogen.

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

Voor meer informatie, zie [Dia's in presentaties vergelijken](/slides/nl/net/compare-slides/).

## **Dia‑masterweergave als standaardweergave instellen**

Gebruik de eigenschap `LastView` op [ViewProperties](https://reference.aspose.com/slides/nl/net/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint bij het openen eerst toont. Het volgende voorbeeld opent de presentatie in de dia‑master‑weergave:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Voor meer weergave‑instellingen, zie [Presentatie opslaan](/slides/nl/net/save-presentation/).

## **Ongebruikte dia‑masters verwijderen**

Presentaties bevatten soms dia‑masters die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslidecollection/removeunused/) om ongebruikte masters uit de collectie `Masters` te verwijderen:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Je kunt ook de low‑code‑methode [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) gebruiken:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Wat is het verschil tussen een dia‑master en een lay‑outdia?**

Een dia‑master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een lay‑outdia behoort tot een dia‑master en definieert een specifieke ordening van tijdelijke aanduidingen. Een normale dia gebruikt een lay‑outdia, zodat hij zowel van de lay‑out als van de master erft.

**Kan één presentatie meerdere dia‑masters bevatten?**

Ja. Een presentatie kan meerdere dia‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik tijdelijke aanduidingen toevoegen aan een dia‑master of een lay‑outdia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan lay‑outdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de dia‑master en zet de inhoudstijdelijke aanduidingen op de lay‑outs die normale dia's zullen gebruiken.

**Kan ik een dia‑master verwijderen die nog in gebruik is?**

Nee. Een dia‑master met afhankelijke dia's kan niet veilig rechtstreeks worden verwijderd. Verplaats eerst die dia's naar lay‑outs onder een andere master, of gebruik een opruimmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.