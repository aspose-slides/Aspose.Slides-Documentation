---
title: Pas dia-indelingen toe of wijzig ze in .NET
linktitle: Dia-indeling
type: docs
weight: 60
url: /nl/net/slide-layout/
keywords:
- dia-indeling
- inhoudsindeling
- plaatshouder
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte indeling
- zichtbaarheid van voettekst
- titeldia
- titel en inhoud
- sectiekop
- twee inhoud
- vergelijking
- alleen titel
- lege indeling
- inhoud met bijschrift
- afbeelding met bijschrift
- titel en verticale tekst
- verticale titel en tekst
- PowerPoint
- OpenDocument
- presentatie
- C#
- .NET
- Aspose.Slides
description: "Beheer en pas dia-indelingen aan in Aspose.Slides voor .NET. Ontdek indelingstypen, controle over plaatshouders en zichtbaarheid van de voettekst via C#-codevoorbeelden."
---
## **Introductie**

Een dia‑indeling bepaalt de rangschikking van plaatshoudervakken en de opmaak van de inhoud op een dia. Ze regelt welke plaatshouders beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen je presentaties snel en consistent te ontwerpen — of je nu iets eenvoudigs of complexers maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Title Slide layout** – Bevat twee tekst‑plaatshouders: één voor de titel en één voor de ondertitel.

**Title and Content layout** – Beschikt over een kleinere titel‑plaatshouder bovenin en een grotere eronder voor de hoofdinhoud (zoals tekst, opsommingstekens, grafieken, afbeeldingen, enz.).

**Blank layout** – Heeft geen plaatshouders, zodat je de dia volledig zelf kunt ontwerpen.

Dia‑indelingen maken deel uit van een dia‑master, de bovenliggende dia die de indelingsstijlen voor de presentatie definieert. Je kunt indelingsdia’s benaderen en aanpassen via de dia‑master — op basis van type, naam of unieke ID. Als alternatief kun je een specifieke indelingsdia rechtstreeks in de presentatie bewerken.

Om met dia‑indelingen te werken in Aspose.Slides for .NET, kun je gebruiken:

- Eigenschappen zoals [LayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/layoutslides/) en [Masters](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/masters/) onder de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse
- Types zoals [ILayoutSlide](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutplaceholdermanager/) en [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Om meer te leren over het werken met master‑dia’s, bekijk het artikel [Slide Master](/slides/nl/net/slide-master/).
{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van je dia’s aan te passen, moet je mogelijk nieuwe indelingsdia’s aan een presentatie toevoegen. Aspose.Slides for .NET stelt je in staat te controleren of een specifieke indeling al bestaat, een nieuwe toe te voegen indien nodig, en deze te gebruiken om dia’s in te voegen op basis van die indeling.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Benader de [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/imasterlayoutslidecollection/).
1. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg dan de benodigde indelingsdia toe.
1. Voeg een lege dia toe op basis van de nieuwe indelingsdia.
1. Sla de presentatie op.

De volgende C#‑code toont hoe je een dia‑indeling toevoegt aan een PowerPoint‑presentatie:

```cs
// Instantieer de Presentation-klasse die een PowerPoint-bestand vertegenwoordigt.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Doorloop de verschillende indelingsdia-typen om een indelingsdia te selecteren.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Een situatie waarin de presentatie niet alle indelingstypen bevat.
        // Het presentiebestand bevat alleen de typen Blank en Custom.
        // Echter, indelingsdia’s met aangepaste typen kunnen herkenbare namen hebben,
        // zoals "Title", "Title and Content", enz., die gebruikt kunnen worden voor het selecteren van een indelingsdia.
        // Je kunt ook vertrouwen op een set van plaatshouder-vormtypen.
        // Bijvoorbeeld, een titeldia zou alleen de Title plaatshouder moeten hebben, enzovoort.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Voeg een lege dia toe met de toegevoegde indelingsdia.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Sla de presentatie op naar schijf.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Ongebruikte dia‑indelingen verwijderen**

Aspose.Slides biedt de methode [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) van de [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/)‑klasse om ongewenste en ongebruikte indelingsdia’s te verwijderen.

De volgende C#‑code laat zien hoe je een indelingsdia verwijdert uit een PowerPoint‑presentatie:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Plaatshouders toevoegen aan dia‑indelingen**

Aspose.Slides biedt de eigenschap [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutslide/placeholdermanager/) waarmee je nieuwe plaatshouders aan een indelingsdia kunt toevoegen.

Deze manager bevat methoden voor de volgende plaatshoudertypen:

| PowerPoint‑plaatshouder            | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ilayoutplaceholdermanager/)‑methode |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | AddContentPlaceholder(float x,float y,float width,float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x,float y,float width,float height) |
| ![Text](text.png)                   | AddTextPlaceholder(float x,float y,float width,float height) |
| ![Text (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x,float y,float width,float height) |
| ![Picture](picture.png)             | AddPicturePlaceholder(float x,float y,float width,float height) |
| ![Chart](chart.png)                 | AddChartPlaceholder(float x,float y,float width,float height) |
| ![Table](table.png)                 | AddTablePlaceholder(float x,float y,float width,float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x,float y,float width,float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x,float y,float width,float height) |
| ![Online Image](onlineimage.png)    | AddOnlineImagePlaceholder(float x,float y,float width,float height) |

De volgende C#‑code demonstreert hoe je nieuwe plaatshoudervormen toevoegt aan de **Blank**‑indelingsdia:

```cs
using (var presentation = new Presentation())
{
    // Haal de lege indelingsdia op.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Haal de plaatshoudermanager van de indelingsdia op.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Voeg verschillende plaatshouders toe aan de lege indelingsdia.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Voeg een nieuwe dia toe met de lege indeling.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

Resultaat:

![De plaatshouders op de indelingsdia](add_placeholders.png)

## **Voettekstekens zichtbaar maken voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, dia‑nummer en aangepaste tekst worden getoond of verborgen afhankelijk van de dia‑indeling. Aspose.Slides for .NET stelt je in staat de zichtbaarheid van deze voettekst‑plaatshouders te regelen. Handig wanneer je voor bepaalde indelingen voettekst wilt weergeven en voor andere een strakke, minimale weergave wilt behouden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een indelingsdia op via de index.
1. Zet de voettekst‑plaatshouder van de dia op zichtbaar.
1. Zet de dia‑nummer‑plaatshouder op zichtbaar.
1. Zet de datum‑tijd‑plaatshouder op zichtbaar.
1. Sla de presentatie op.

De volgende C#‑code toont hoe je de zichtbaarheid van een dia‑voettekst instelt en gerelateerde acties uitvoert:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **Voettekst van onderliggende dia’s zichtbaar maken**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, dia‑nummer en aangepaste tekst op het niveau van de master‑dia worden beheerd om consistentie over alle indelingsdia’s te waarborgen. Aspose.Slides for .NET maakt het mogelijk de zichtbaarheid en inhoud van deze voettekst‑plaatshouders op de master‑dia in te stellen en deze instellingen door te geven aan alle onderliggende indelingsdia’s. Zo behoud je uniforme voettekstinformatie gedurende de hele presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar de master‑dia op via de index.
1. Zet de voettekst‑plaatshouders van de master en alle onderliggende dia’s op zichtbaar.
1. Zet de dia‑nummer‑plaatshouders van de master en alle onderliggende dia’s op zichtbaar.
1. Zet de datum‑tijd‑plaatshouders van de master en alle onderliggende dia’s op zichtbaar.
1. Sla de presentatie op.

De volgende C#‑code demonstreert deze bewerking:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Wat is het verschil tussen een master‑dia en een indelingsdia?**

Een master‑dia bepaalt het algemene thema en de standaardopmaak, terwijl indelingsdia’s specifieke rangschikkingen van plaatshouders voor verschillende soorten inhoud definiëren.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, je kunt een indelingsdia klonen vanuit de [LayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/layoutslides/)‑collectie van een presentatie en deze invoegen in een andere met de `AddClone`‑methode.

**Wat gebeurt er als ik een indelingsdia verwijder die nog door een dia wordt gebruikt?**

Als je probeert een indelingsdia te verwijderen die nog door ten minste één dia in de presentatie wordt gerefereerd, zal Aspose.Slides een [PptxEditException](https://reference.aspose.com/slides/nl/net/aspose.slides/pptxeditexception/) werpen. Gebruik in plaats daarvan [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) om veilig alleen de ongebruikte indelingsdia’s te verwijderen.