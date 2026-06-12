---
title: Dia‑indelingen toepassen of wijzigen in C++
linktitle: Dia‑indeling
type: docs
weight: 60
url: /nl/cpp/slide-layout/
keywords:
- dia‑indeling
- inhoudsindeling
- placeholder
- presentatieontwerp
- dia‑ontwerp
- ongebruikte indeling
- voettekst‑zichtbaarheid
- titel‑dia
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
- C++
- Aspose.Slides
description: "Beheer en pas dia‑indelingen aan in Aspose.Slides voor C++. Ontdek indelingstypen, placeholder‑beheer en voettekst‑zichtbaarheid via C++‑codevoorbeelden."
---
## **Inleiding**

Een dia‑indeling definieert de rangschikking van placeholder‑vakken en de opmaak van de inhoud op een dia. Het bepaalt welke placeholders beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen je om presentaties snel en consistent te ontwerpen – of je nu iets eenvoudigs of complexere maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Titel‑dia‑indeling** – Bevat twee tekst‑placeholders: één voor de titel en één voor de ondertitel.

**Titel‑en‑Inhoud‑indeling** – Heeft een kleiner titel‑placeholder bovenaan en een groter eronder voor de hoofdinhoud (zoals tekst, opsommingstekens, grafieken, afbeeldingen en meer).

**Lege indeling** – Bevat geen placeholders, zodat je volledige controle hebt om de dia vanaf nul te ontwerpen.

Dia‑indelingen maken deel uit van een dia‑master, die de bovenste dia is die lay‑outstijlen voor de presentatie definieert. Je kunt indelingsdia’s benaderen en wijzigen via de dia‑master – ofwel op basis van hun type, naam of unieke ID. Alternatief kun je een specifieke indelingsdia rechtstreeks binnen de presentatie bewerken.

Om met dia‑indelingen te werken in Aspose.Slides for Android, kun je gebruiken:

- Methoden zoals [get_LayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_layoutslides/) en [get_Masters](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_masters/) onder de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse
- Types zoals [ILayoutSlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/) en [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Om meer te leren over het werken met masterslides, bekijk het artikel [Slide Master](/slides/nl/cpp/slide-master/).
{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van je dia’s aan te passen, moet je mogelijk nieuwe indelingsdia’s aan een presentatie toevoegen. Aspose.Slides for Android stelt je in staat te controleren of een specifieke indeling al bestaat, er een nieuwe toe te voegen indien nodig, en deze te gebruiken om dia’s in te voegen op basis van die indeling.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Benader de [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg dan de benodigde indelingsdia toe.
1. Voeg een lege dia toe op basis van de nieuwe indelingsdia.
1. Sla de presentatie op.

De volgende C++‑code toont hoe je een dia‑indeling toevoegt aan een PowerPoint‑presentatie:

```cpp
// Instantieer de Presentation-klasse die een PowerPoint-bestand vertegenwoordigt.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Ga door de indelingsdia‑types om een indelingsdia te selecteren.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Een situatie waarin de presentatie niet alle indelingstypen bevat.
    // Het presentiebestand bevat alleen lege en aangepaste indelingstypen.
    // Echter kunnen indelingsdia's met aangepaste typen herkenbare namen hebben,
    // zoals "Titel", "Titel en Inhoud", enz., die gebruikt kunnen worden voor het selecteren van een indelingsdia.
    // Je kunt ook vertrouwen op een reeks placeholder-vormtypen.
    // Bijvoorbeeld, een titel-diapositief moet alleen het Titel-placeholder-type hebben, enzovoort.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Voeg een lege dia toe met behulp van de toegevoegde indelingsdia.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Sla de presentatie op naar schijf.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Ongebruikte indelingsdia's verwijderen**

Aspose.Slides biedt de [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑methode uit de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑klasse om ongewenste en ongebruikte indelingsdia’s te verwijderen.

De volgende C++‑code laat zien hoe je een indelingsdia uit een PowerPoint‑presentatie verwijdert:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Placeholders toevoegen aan dia‑indelingen**

Aspose.Slides biedt de [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/)‑methode, waarmee je nieuwe placeholders aan een indelingsdia kunt toevoegen.

Deze manager bevat methoden voor de volgende placeholder‑typen:

| PowerPoint‑placeholder              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ilayoutplaceholdermanager/) Methode |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

De volgende C++‑code demonstreert hoe je nieuwe placeholder‑vormen toevoegt aan de lege indelingsdia:

```cpp
auto presentation = MakeObject<Presentation>();

// Haal de lege indelingsdia op.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Get the placeholder manager of the layout slide.
auto placeholderManager = layout->get_PlaceholderManager();

// Add different placeholders to the Blank layout slide.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Het resultaat:

![De placeholders op de indelingsdia](add_placeholders.png)

## **Voettekst‑zichtbaarheid instellen voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, paginanummer en aangepaste tekst worden weergegeven of verborgen afhankelijk van de dia‑indeling. Aspose.Slides for Android stelt je in staat de zichtbaarheid van deze voettekst‑placeholders te regelen. Dit is handig wanneer je wilt dat bepaalde indelingen voettekstinformatie tonen terwijl andere schoon blijven.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar een indelingsdia op via de index.
1. Stel de voettekst‑placeholder van de dia in op zichtbaar.
1. Stel de paginanummer‑placeholder van de dia in op zichtbaar.
1. Stel de datum‑tijd‑placeholder van de dia in op zichtbaar.
1. Sla de presentatie op.

De volgende C++‑code laat zien hoe je de zichtbaarheid van een dia‑voettekst instelt en gerelateerde taken uitvoert:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Voettekst‑zichtbaarheid van sub‑dia's instellen**

In PowerPoint‑presentaties kunnen voettekstelementen zoals datum, paginanummer en aangepaste tekst op master‑dia‑niveau worden beheerd om consistentie over alle indelingsdia’s te waarborgen. Aspose.Slides for Android maakt het mogelijk om de zichtbaarheid en inhoud van deze voettekst‑placeholders op de master‑dia in te stellen en deze instellingen door te voeren naar alle onderliggende indelingsdia’s. Deze aanpak zorgt voor uniforme voettekst‑informatie in de gehele presentatie.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal een referentie naar de master‑dia op via de index.
1. Stel de master‑ en alle onderliggende voettekst‑placeholders in op zichtbaar.
1. Stel de master‑ en alle onderliggende paginanummer‑placeholders in op zichtbaar.
1. Stel de master‑ en alle onderliggende datum‑tijd‑placeholders in op zichtbaar.
1. Sla de presentatie op.

De volgende C++‑code demonstreert deze bewerking:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Wat is het verschil tussen een masterslide en een indelingsdia?**

Een masterslide definieert het algemene thema en de standaardopmaak, terwijl indelingsdia’s specifieke rangschikkingen van placeholders voor verschillende soorten inhoud definiëren.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, je kunt een indelingsdia klonen vanuit de indelingsdia‑collectie van een presentatie, toegankelijk via de [get_LayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_layoutslides/)‑methode, en deze invoegen in een andere presentatie met de `AddClone`‑methode.

**Wat gebeurt er als ik een indelingsdia verwijder dat nog door een dia wordt gebruikt?**

Als je probeert een indelingsdia te verwijderen dat nog wordt gerefereerd door ten minste één dia in de presentatie, zal Aspose.Slides een [PptxEditException](https://reference.aspose.com/slides/nl/cpp/aspose.slides/pptxeditexception/) werpen. Om dit te voorkomen, gebruik je [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), die veilig alleen de niet‑gebruikte indelingsdia’s verwijdert.