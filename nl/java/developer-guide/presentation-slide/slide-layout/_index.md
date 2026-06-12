---
title: "Dia‑indelingen toepassen of wijzigen in Java"
linktitle: "Dia‑indeling"
type: docs
weight: 60
url: /nl/java/slide-layout/
keywords:
- "dia‑indeling"
- "inhoudsindeling"
- "plaatshouder"
- "presentatieontwerp"
- "diaontwerp"
- "ongebruikte indeling"
- "voettekst‑zichtbaarheid"
- "titeldia"
- "titel en inhoud"
- "sectiekop"
- "twee inhoud"
- "vergelijking"
- "alleen titel"
- "lege indeling"
- "inhoud met bijschrift"
- "afbeelding met bijschrift"
- "titel en verticale tekst"
- "verticale titel en tekst"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "Java"
- "Aspose.Slides"
description: "Beheer en pas dia‑indelingen aan in Aspose.Slides voor Java. Verken indelingstypen, beheer van plaatshouders en voettekst‑zichtbaarheid via Java‑codevoorbeelden."
---
## **Introductie**

Een dia‑indeling bepaalt de rangschikking van plaatshoudervakken en de opmaak van de inhoud op een dia. Ze regelt welke plaatshouders beschikbaar zijn en waar ze verschijnen. Dia‑indelingen helpen je presentaties snel en consistent te ontwerpen—of je nu iets eenvoudigs of complexere maakt. Enkele van de meest voorkomende dia‑indelingen in PowerPoint zijn:

**Title Slide layout** – Bevat twee tekst‑plaatshouders: één voor de titel en één voor de ondertitel.

**Title and Content layout** – Heeft een kleinere titel‑plaatshouder bovenaan en een grotere eronder voor de hoofdinhoud (zoals tekst, opsomming, grafieken, afbeeldingen, enz.).

**Blank layout** – Bevat geen plaatshouders, zodat je volledige controle hebt om de dia vanaf nul te ontwerpen.

Dia‑indelingen maken deel uit van een dia‑master, de bovenliggende dia die de indelingsstijlen voor de presentatie definieert. Je kunt indelingsdia’s benaderen en aanpassen via de dia‑master—op type, naam of unieke ID. Alternatief kun je een specifieke indelingsdia rechtstreeks in de presentatie bewerken.

Om met dia‑indelingen te werken in Aspose.Slides for Java, kun je gebruiken:

- Methodes zoals [getLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getLayoutSlides--) en [getMasters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasters--) onder de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse
- Types zoals [ILayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/) en [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Om meer te leren over het werken met master‑dia’s, bekijk het artikel [Slide Master](/slides/nl/java/slide-master/).

{{% /alert %}}

## **Dia‑indelingen toevoegen aan presentaties**

Om het uiterlijk en de structuur van je dia’s aan te passen, moet je mogelijk nieuwe indelingsdia’s aan een presentatie toevoegen. Aspose.Slides for Java stelt je in staat te controleren of een bepaalde indeling al bestaat, er een nieuwe toe te voegen indien nodig, en deze te gebruiken om dia’s in te voegen op basis van die indeling.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Benader de [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterlayoutslidecollection/).
3. Controleer of de gewenste indelingsdia al bestaat in de collectie. Zo niet, voeg de benodigde indelingsdia toe.
4. Voeg een lege dia toe gebaseerd op de nieuwe indelingsdia.
5. Sla de presentatie op.

De volgende Java‑code laat zien hoe je een dia‑indeling toevoegt aan een PowerPoint‑presentatie:

```java
// Instantieer de Presentation‑klasse die een PowerPoint‑bestand vertegenwoordigt.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Doorloop de indelingsdia‑typen om een indelingsdia te selecteren.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Een situatie waarin de presentatie niet alle indelingstypen bevat.
        // Het presentatie‑bestand bevat alleen de typen Blank en Custom.
        // Echter, indelingsdia's met aangepaste typen kunnen herkenbare namen hebben,
        // zoals "Title", "Title and Content", enz., die gebruikt kunnen worden voor het selecteren van een indelingsdia.
        // Je kunt ook vertrouwen op een set van plaatshouder‑vormtypen.
        // Bijvoorbeeld, een Titeldia moet alleen het Title‑plaatshoudertype hebben, enzovoort.
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

    // Voeg een lege dia toe met behulp van de toegevoegde indelingsdia.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Sla de presentatie op schijf.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ongebruikte indelingsdia’s verwijderen**

Aspose.Slides biedt de [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)‑methode van de [Compress](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/)‑klasse om ongewenste en ongebruikte indelingsdia’s te verwijderen.

De volgende Java‑code toont hoe je een indelingsdia uit een PowerPoint‑presentatie verwijdert:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Plaatshouders toevoegen aan dia‑indelingen**

Aspose.Slides biedt de [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--)‑methode, waarmee je nieuwe plaatshouders kunt toevoegen aan een indelingsdia.

Deze manager bevat methodes voor de volgende plaatshouder‑typen:

| PowerPoint‑plaatshouder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutplaceholdermanager/) Methode |
| ---------------------- | ----------------------------------------------------------------------------- |
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

De volgende Java‑code laat zien hoe je nieuwe plaatshouder‑vormen toevoegt aan de lege indelingsdia:

```java
Presentation presentation = new Presentation();
try {
    // Haal de lege indelingsdia op.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Haal de plaatshouder‑manager van de indelingsdia op.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Voeg verschillende plaatshouders toe aan de lege indelingsdia.
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

![De plaatshouders op de indelingsdia](add_placeholders.png)

## **Voettekst‑zichtbaarheid instellen voor een indelingsdia**

In PowerPoint‑presentaties kunnen voettekst‑elementen zoals datum, dia‑nummer en aangepaste tekst worden getoond of verborgen afhankelijk van de dia‑indeling. Aspose.Slides for Java stelt je in staat de zichtbaarheid van deze voettekst‑plaatshouders te regelen. Dit is handig wanneer je wilt dat bepaalde indelingen voettekst‑informatie tonen, terwijl andere juist minimalistisch blijven.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Haal een indelingsdia‑referentie op via de index.
3. Stel de voettekst‑plaatshouder van de dia in op zichtbaar.
4. Stel de dia‑nummer‑plaatshouder in op zichtbaar.
5. Stel de datum‑tijd‑plaatshouder in op zichtbaar.
6. Sla de presentatie op.

De volgende Java‑code toont hoe je de zichtbaarheid van een dia‑voettekst instelt en verwante taken uitvoert:

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

## **Kind‑voettekst‑zichtbaarheid instellen voor een dia**

​In PowerPoint‑presentaties kunnen voettekst‑elementen zoals datum, dia‑nummer en aangepaste tekst worden beheerd op master‑dia‑niveau om consistentie over alle indelingsdia’s te waarborgen. Aspose.Slides for Java maakt het mogelijk om de zichtbaarheid en inhoud van deze voettekst‑plaatshouders op de master‑dia in te stellen en die instellingen door te geven aan alle onderliggende indelingsdia’s. Deze aanpak garandeert uniforme voettekst‑informatie in de hele presentatie.​

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Haal een referentie naar de master‑dia op via de index.
3. Stel de master‑ en alle onderliggende voettekst‑plaatshouders in op zichtbaar.
4. Stel de master‑ en alle onderliggende dia‑nummer‑plaatshouders in op zichtbaar.
5. Stel de master‑ en alle onderliggende datum‑tijd‑plaatshouders in op zichtbaar.
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

## **FAQ**

**Wat is het verschil tussen een master‑dia en een indelingsdia?**

Een master‑dia definieert het algemene thema en de standaardopmaak, terwijl indelingsdia’s specifieke rangschikkingen van plaatshouders voor verschillende soorten inhoud bepalen.

**Kan ik een indelingsdia van de ene presentatie naar de andere kopiëren?**

Ja, je kunt een indelingsdia klonen vanuit de indelingsdia‑collectie van een presentatie, toegankelijk via de [getLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getLayoutSlides--)‑methode, en deze invoegen in een andere presentatie met de `addClone`‑methode.

**Wat gebeurt er als ik een indelingsdia verwijder die nog door een dia wordt gebruikt?**

Als je probeert een indelingsdia te verwijderen die nog door ten minste één dia in de presentatie wordt gerefereerd, zal Aspose.Slides een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/) werpen. Gebruik in plaats daarvan [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) om veilig alleen de ongebruikte indelingsdia’s te verwijderen.