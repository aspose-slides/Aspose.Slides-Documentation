---
title: Beheer slide masters van presentaties op Android
linktitle: Slide master
type: docs
weight: 70
url: /nl/androidjava/slide-master/
keywords:
- slide master
- masterdia
- PPT masterdia
- meerdere masterdia's
- masterdia's vergelijken
- achtergrond
- placeholder
- masterdia klonen
- masterdia kopiëren
- masterdia dupliceren
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer slide masters in Aspose.Slides voor Android via Java: toegang, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Een **slide master** bepaalt gedeelde ontwerpinstellingen voor een groep dia's. Hij kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for Android via Java ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia's bevatten, en elke masterdia kan meerdere layoutdia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een normale dia een layoutdia, en die layoutdia behoort tot een masterdia.

The hierarchy is:

1. **Slide master** - bepaalt het gedeelde ontwerp en thema.  
1. **Layout slide** - bepaalt een specifieke rangschikking van placeholders en lay‑out‑niveau‑opmaak.  
1. **Normal slide** - bevat de daadwerkelijke presentatiewaarde en gebruikt één layoutdia.  

![De hiërarchie van masterdia's, layoutdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een slide master weergegeven door de [IMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/) interface. Alle masterdia's in een presentatie zijn beschikbaar via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getMasters--) collectie, die de [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) implementeert. Voor het volledige Android‑via‑Java API‑oppervlak, zie de [com.aspose.slides API reference](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/).

{{% alert color="info" title="Erfenis" %}}
Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, heeft het specifieker niveau voorrang. Bijvoorbeeld, als een masterdia en een layoutdia beiden een achtergrond definiëren, gebruiken dia's gebaseerd op die layout de achtergrond van de layout. Voor meer informatie over layoutdia's, zie [Apply or Change Slide Layouts](/slides/nl/androidjava/slide-layout/).
{{% /alert %}}

## **Toegang tot slide masters**

In PowerPoint kun je de Slide Master‑weergave openen via **View** > **Slide Master**.

![De Slide Master‑opdracht op het PowerPoint‑tabblad View](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters()`‑collectie om masterdia's te benaderen:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Je kunt ook de masterdia die door een normale dia wordt gebruikt verkrijgen via zijn layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Wat een slide master bevat**

Een masterdia is een dia‑achtig object. Het implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/), waardoor het veel van dezelfde dia‑eigenschappen biedt die door normale en layoutdia's worden gebruikt.

Veelgebruikte leden van een masterdia zijn onder andere:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond van de master‑dia in. |
| `getShapes()` | Bewaar vormen die op de master zijn geplaatst, zoals logo's, afbeeldingkaders en gedeelde tekst. |
| `getLayoutSlides()` | Bewaar de layoutdia's die tot de master behoren. |
| `getThemeManager()` | Biedt toegang tot de master‑thema‑API's. |
| `getHeaderFooterManager()` | Beheert kopteksten, voetteksten, datums en dia‑nummers voor de master en zijn onderliggende lay-outs. |
| `getDependingSlides()` | Geeft normale dia's terug die via hun lay-outs afhankelijk zijn van de master. |

## **Afbeelding toevoegen aan een slide master**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia's die lay-outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste masterdia:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer informatie over afbeeldingkaders, zie [Afbeeldingskader](/slides/nl/androidjava/picture-frame/).

## **Werken met placeholders**

Placeholders worden normaal gedefinieerd op layoutdia's. De masterdia levert de gedeelde stijl en het thema die die lay-outs overnemen, terwijl elke lay-out bepaalt welke placeholders beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de Slide Master‑weergave.

![De Insert Placeholder‑opdracht in de PowerPoint‑Slide‑Master‑weergave](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werk je met de layoutdia die bij de master hoort:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook placeholder‑vormen die al op een masterdia bestaan opmaken. Het volgende voorbeeld vindt de titel‑placeholder en past een lineaire gradient‑vulling toe:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        int redGradientColor = Color.valueOf(255, 0, 0).toArgb();
        int purpleGradientColor = Color.valueOf(128, 0, 128).toArgb();

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Opgemaakte titel‑placeholder geërfd door normale dia's](slide-master_8.png)

Voor meer opties voor placeholders en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/androidjava/manage-placeholder/) en [Text Formatting](/slides/nl/androidjava/text-formatting/).

## **Achtergrond van een slide master wijzigen**

Een master‑achtergrond wordt geërfd door lay-outs en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    int masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor gerelateerde onderwerpen, zie [Presentation Background](/slides/nl/androidjava/presentation-background/) en [Presentation Theme](/slides/nl/androidjava/presentation-theme/).

## **Een slide master klonen naar een andere presentatie**

Gebruik [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens door lay-outs en dia's in de doelpresentatie worden gebruikt.

```java
Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Als je normale dia's samen met hun master wilt klonen, zie [Clone Slides](/slides/nl/androidjava/clone-slides/).

## **Meerdere slide masters toevoegen**

Een presentatie kan meerdere masterdia's bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginastuctuur of thema‑instellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia's](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard master, geeft de kloon een andere achtergrond, maakt een layout onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die layout:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    int sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Slide masters vergelijken**

Masterdia's kunnen worden vergeleken met de `equals`‑methode die ze erven van [IBaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

```java
Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/androidjava/compare-slides/).

## **Slide Master‑weergave als standaardweergave instellen**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Slide Master‑weergave:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/androidjava/save-presentation/).

## **Ongebruikte masterdia's verwijderen**

Presentaties kunnen soms masterdia's bevatten die niet meer door enige normale dia worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de `getMasters()`‑collectie te verwijderen:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook de low‑code‑methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) gebruiken:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een slide master en een layoutdia?**

Een slide master bepaalt gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layoutdia behoort tot een masterdia en bepaalt een specifieke rangschikking van placeholders. Een normale dia gebruikt een layoutdia, zodat hij zowel van de layout als van de master erft.

**Kan één presentatie meerdere slide masters bevatten?**

Ja. Een presentatie kan meerdere slide masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik placeholders toevoegen aan een masterdia of aan een layoutdia?**

In de meeste gevallen voeg je placeholders toe aan layoutdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia, en plaats inhouds‑placeholders op de lay-outs die normale dia's zullen gebruiken.

**Kan ik een masterdia verwijderen die nog in gebruik is?**

Nee. Een masterdia met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats die dia's eerst naar lay-outs onder een andere master, of gebruik een opruimmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.