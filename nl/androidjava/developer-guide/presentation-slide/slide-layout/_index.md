---
title: Slide-indelingen toepassen of wijzigen op Android
linktitle: Slide-indeling
type: docs
weight: 60
url: /nl/androidjava/slide-layout/
keywords:
- slide-indeling
- inhoudsindeling
- plaatsaanduiding
- presentatie-ontwerp
- dia-ontwerp
- ongebruikte indeling
- voettekst-zichtbaarheid
- titel-dia
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
- Android
- Java
- Aspose.Slides
description: "Beheer en pas slide-indelingen aan in Aspose.Slides voor Android. Verken indelingstypen, controle over plaatsaanduidingen en voettekst-zichtbaarheid via Java-codevoorbeelden."
---
## **Inleiding**

Een dia‑indeling bepaalt de rangschikking van tijdelijke‑plaatsvakken en de opmaak van de inhoud op een dia. Het regelt welke tijdelijke‑plaatsvakken beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen je presentaties snel en consistent te ontwerpen — of je nu iets eenvoudigs of complexers maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Titel‑dia‑indeling** – Bevat twee tekst‑plaatsaanduidingen: één voor de titel en één voor de ondertitel.

**Titel‑en‑inhoud‑indeling** – Heeft een kleinere titel‑plaatsaanduiding bovenaan en een grotere eronder voor de hoofdinhoud (zoals tekst, opsommingstekens, grafieken, afbeeldingen, enz.).

**Lege indeling** – Bevat geen tijdelijke‑plaatsvakken, waardoor je volledige controle hebt om de dia vanaf nul te ontwerpen.

Dia‑indelingen maken deel uit van een dia‑master, de bovenliggende dia die de indelingsstijlen voor de presentatie bepaalt. Je kunt indelingsdia’s benaderen en aanpassen via de dia‑master — op type, naam of unieke ID. Alternatief kun je een specifieke indelingsdia rechtstreeks in de presentatie bewerken.

Om met dia‑indelingen te werken in Aspose.Slides voor Android, kun je gebruiken:
- Methoden zoals [getLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) en [getMasters](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getMasters--) onder de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) 
- Typen zoals [ILayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) en [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Wil je meer leren over het werken met master‑dia’s, bekijk dan het artikel [Slide Master](/slides/nl/androidjava/slide-master/).
{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van je dia’s aan te passen, moet je mogelijk nieuwe indelingsdia’s aan een presentatie toevoegen. Aspose.Slides voor Android maakt het mogelijk te controleren of een bepaalde indeling al bestaat, er een nieuwe toe te voegen indien nodig, en deze te gebruiken om dia’s in te voegen gebaseerd op die indeling.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) aan.
2. Open de [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
3. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg dan de benodigde indelingsdia toe.
4. Voeg een lege dia toe op basis van de nieuwe indelingsdia.
5. Sla de presentatie op.

De volgende Java‑code toont hoe je een dia‑indeling toevoegt aan een PowerPoint‑presentatie:

```java
// Maak een instantie van de Presentation-klasse die een PowerPoint-bestand vertegenwoordigt.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Doorloop de layout-dia-types om een layout-dia te selecteren.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Een situatie waarin de presentatie niet alle layout-types bevat.
        // Het presentiebestand bevat alleen de Blank- en Custom-layout-types.
        // Echter kunnen layout-dia’s met custom-types herkenbare namen hebben,
        // zoals "Title", "Title and Content", etc., die gebruikt kunnen worden voor het selecteren van een layout-dia.
        // Je kunt ook vertrouwen op een set van placeholder-vormtypes.
        // Bijvoorbeeld, een Title-dia zou alleen het Title-placeholder-type moeten hebben, en zo verder.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Voeg een lege dia toe met de toegevoegde layout-dia.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Sla de presentatie op schijf.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ongebruikte indelingsdia’s verwijderen**

Aspose.Slides biedt de methode [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) van de klasse [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) om ongewenste en ongebruikte indelingsdia’s te verwijderen.

De volgende Java‑code laat zien hoe je een indelingsdia verwijdert uit een PowerPoint‑presentatie:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Plaatsvullers toevoegen aan dia‑indelingen**

Aspose.Slides biedt de methode [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) die het mogelijk maakt nieuwe plaatsvullers toe te voegen aan een indelingsdia.

Deze manager bevat methoden voor de volgende plaatsvuller‑types:

| PowerPoint‑plaatsaanduiding | [ILayoutPlaceholderManager] Methode |
| --------------------------- | ------------------------------------ |
| ![Inhoud](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Inhoud (Verticaal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Tekst](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Tekst (Verticaal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Afbeelding](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafiek](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabel](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑afbeelding](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

De volgende Java‑code toont hoe je nieuwe plaatsvuller‑vormen toevoegt aan de lege indelingsdia:

```java
Presentation presentation = new Presentation();
try {
    // Haal de lege indelingsdia op.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Haal de placeholder-manager van de indelingsdia op.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Voeg verschillende plaatsvullers toe aan de lege indelingsdia.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Voeg een nieuwe dia toe met de lege indeling.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De plaatsvullers op de indelingsdia](add_placeholders.png)

## **Voettekst‑zichtbaarheid instellen voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekst‑elementen zoals datum, dia‑nummer en aangepaste tekst worden getoond of verborgen afhankelijk van de dia‑indeling. Aspose.Slides voor Android maakt het mogelijk de zichtbaarheid van deze voettekst‑plaatsaanduidingen te regelen. Dit is handig wanneer je wilt dat bepaalde indelingen voettekst‑informatie tonen terwijl andere schoon en minimaal blijven.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) aan.
2. Haal een referentie naar een indelingsdia op basis van de index.
3. Zet de voettekst‑plaatsaanduiding van de dia op zichtbaar.
4. Zet de dia‑nummer‑plaatsaanduiding op zichtbaar.
5. Zet de datum‑tijd‑plaatsaanduiding op zichtbaar.
6. Sla de presentatie op.

De volgende Java‑code laat zien hoe je de zichtbaarheid van een dia‑voettekst instelt en gerelateerde taken uitvoert:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Voettekst‑zichtbaarheid van onderliggende dia’s instellen**

In PowerPoint‑presentaties kunnen voettekst‑elementen zoals datum, dia‑nummer en aangepaste tekst op master‑dia‑niveau worden beheerd om consistentie over alle indelingsdia’s te garanderen. Aspose.Slides voor Android stelt je in staat de zichtbaarheid en inhoud van deze voettekst‑plaatsaanduidingen op de master‑dia in te stellen en deze instellingen door te voeren naar alle onderliggende indelingsdia’s. Deze aanpak zorgt voor uniforme voettekst‑informatie door de gehele presentatie.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) aan.
2. Haal een referentie naar de master‑dia op basis van de index.
3. Zet de voettekst‑plaatsaanduidingen van de master en alle onderliggende dia’s op zichtbaar.
4. Zet de dia‑nummer‑plaatsaanduidingen van de master en alle onderliggende dia’s op zichtbaar.
5. Zet de datum‑tijd‑plaatsaanduidingen van de master en alle onderliggende dia’s op zichtbaar.
6. Sla de presentatie op.

De volgende Java‑code demonstreert deze bewerking:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Wat is het verschil tussen een master‑dia en een indelingsdia?**

Een master‑dia definieert het algemene thema en de standaardopmaak, terwijl indelingsdia’s specifieke rangschikkingen van plaatsaanduidingen voor verschillende soorten inhoud bepalen.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, je kunt een indelingsdia klonen vanuit de indelingsdia‑collectie van een presentatie, toegankelijk via de methode [getLayoutSlides], en deze in een andere presentatie invoegen met de `addClone`‑methode.

**Wat gebeurt er als ik een indelingsdia verwijder die nog door een dia wordt gebruikt?**

Als je probeert een indelingsdia te verwijderen die nog door minstens één dia in de presentatie wordt gerefereerd, zal Aspose.Slides een [PptxEditException] werpen. Gebruik [removeUnusedLayoutSlides] om alleen de indelingsdia’s die niet in gebruik zijn veilig te verwijderen.