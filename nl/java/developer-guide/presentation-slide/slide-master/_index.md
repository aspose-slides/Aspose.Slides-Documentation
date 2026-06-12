---
title: Beheer slide‑masters van presentaties in Java
linktitle: Slide‑master
type: docs
weight: 70
url: /nl/java/slide-master/
keywords:
- slide‑master
- master‑dia
- PPT‑master‑dia
- meerdere master‑dia’s
- master‑dia’s vergelijken
- achtergrond
- plaatshouder
- master‑dia klonen
- master‑dia kopiëren
- master‑dia dupliceren
- ongebruikte master‑dia
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer slide‑masters in Aspose.Slides voor Java: openen, bewerken, klonen, vergelijken en verwijderen van master‑dia’s in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **slide master** definieert gedeelde ontwerpinstellingen voor een groep dia’s. Hij kan gemeenschappelijke vormen, logo’s, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een slide master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for Java ondersteunt hetzelfde model. Een presentatie kan één of meerdere masterdia’s bevatten, en elke masterdia kan verschillende indelingsdia’s bevatten. Normale dia’s verwijzen doorgaans niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een normale dia een indelingsdia, en die indelingsdia behoort tot een masterdia.

De hiërarchie is:

1. **Slide master** – definieert het gedeelde ontwerp en thema.  
1. **Layout slide** – definieert een specifieke ordening van plaatshouders en opmaak op indelingsniveau.  
1. **Normal slide** – bevat de daadwerkelijke presentatiewaarde en gebruikt één indelingsdia.

![De hiërarchie van masterdia’s, indelingsdia’s en normale dia’s](slide-master_2.jpg)

In Aspose.Slides wordt een slide‑master weergegeven door de interface [IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) . Alle masterdia’s in een presentatie zijn beschikbaar via de collectie [Presentation.getMasters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasters--) die de interface [IMasterSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) implementeert.

{{% alert color="info" title="Inheritance" %}}

Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, heeft het specifiekere niveau voorrang. Bijvoorbeeld, als een masterdia en een indelingsdia beide een achtergrond definiëren, gebruiken dia’s die gebaseerd zijn op die indeling de achtergrond van de indeling. Voor meer informatie over indelingsdia’s, zie [Toepassen of wijzigen van dia‑indelingen](/slides/nl/java/slide-layout/).

{{% /alert %}}

## **Toegang tot slide‑masters**

In PowerPoint kun je de weergave Slide Master openen via **View** > **Slide Master**.

![Het Slide Master‑commando op het PowerPoint‑tabblad View](slide-master_3.jpg)

In Aspose.Slides gebruik je de collectie `getMasters()` om masterdia’s te benaderen:

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

Je kunt ook de masterdia opvragen die door een normale dia wordt gebruikt via zijn indeling:

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

## **Wat een slide‑master bevat**

Een masterdia is een dia‑achtig object. Het implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/), zodat het veel van dezelfde dia‑eigenschappen blootlegt die door normale en indelingsdia’s worden gebruikt. Master‑specifieke leden staan vermeld op de API‑pagina van [IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/).

Veelgebruikte masterdia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond van de master‑dia in. |
| `getShapes()` | Bewaar vormen die op de master zijn geplaatst, zoals logo’s, foto‑frames en gedeelde tekst. |
| `getLayoutSlides()` | Bewaar de indelingsdia’s die tot de master behoren. |
| `getThemeManager()` | Biedt toegang tot de master‑themabibliotheken. |
| `getHeaderFooterManager()` | Beheert headers, voetteksten, datums en dia‑nummers voor de master en de onderliggende indelingen. |
| `getDependingSlides()` | Geeft normale dia’s terug die via hun indelingen van de master afhankelijk zijn. |

## **Afbeelding toevoegen aan een slide‑master**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia’s die indelingen van die master gebruiken. Dit is handig voor logo’s, watermerken, decoratieve banden en andere herhaalde visuele elementen.

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

Voor meer informatie over foto‑frames, zie [Afbeeldingsframe](/slides/nl/java/picture-frame/).

## **Werken met plaatshouders**

Plaatshouders worden normaal gedefinieerd op indelingsdia’s. De masterdia levert de gedeelde stijl en het thema waar die indelingen van erven, terwijl elke indeling beslist welke plaatshouders beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn plaatshouder‑commando’s beschikbaar in de Slide Master‑weergave.

![Het commando Plaats plaatshouder in PowerPoint‑Slide‑Master‑weergave](slide-master_5.png)

Om nieuwe plaatshouders toe te voegen met Aspose.Slides, werk je met de indelingsdia die tot de master behoort:

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

Je kunt ook plaatshouder‑vormen die al op een masterdia bestaan opmaken. Het volgende voorbeeld vindt de titel‑plaatshouder en past een lineaire kleurverloop‑vulling toe:

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
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Opgeformatteerde titel‑plaatshouder geërfd door normale dia’s](slide-master_8.png)

Voor meer plaatshouder‑ en tekstopmaakopties, zie [Prompt‑tekst instellen in plaatshouder](/slides/nl/java/manage-placeholder/) en [Tekstopmaak](/slides/nl/java/text-formatting/).

## **Achtergrond van een slide‑master wijzigen**

Een master‑achtergrond wordt geërfd door indelingen en dia’s die het niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor gerelateerde onderwerpen, zie [Presentatie‑achtergrond](/slides/nl/java/presentation-background/) en [Presentatie‑thema](/slides/nl/java/presentation-theme/).

## **Een slide‑master klonen naar een andere presentatie**

Gebruik [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) om een masterdia te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens door indelingen en dia’s in de doelfpresentatie worden gebruikt.

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

Als je normale dia’s samen met hun master moet klonen, zie [Dia's klonen](/slides/nl/java/clone-slides/).

## **Meerdere slide‑masters toevoegen**

Een presentatie kan meerdere masterdia’s bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginavormgeving of themainstellingen vereisen.

![PowerPoint‑commando’s voor het invoegen en beheren van masterdia’s](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaardmaster, geeft de kloon een andere achtergrond, maakt een indeling onder die gekloonde master en voegt een nieuwe dia toe op basis van die indeling:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.LIGHT_GRAY;

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

## **Slide‑masters vergelijken**

Masterdia’s kunnen worden vergeleken met de `equals`‑methode die ze van [IBaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/) erven. De vergelijking controleert de structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID’s, of dynamische plaatshouder‑waarden, zoals de huidige datum.

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

Voor meer informatie, zie [Presentatiedia’s vergelijken](/slides/nl/java/compare-slides/).

## **Slide‑master‑weergave als standaardweergave instellen**

Gebruik de methode `setLastView` op [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in de Slide Master‑weergave:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer weergave‑instellingen, zie [Presentatie opslaan](/slides/nl/java/save-presentation/).

## **Ongebruikte masterdia’s verwijderen**

Presentaties kunnen soms masterdia’s bevatten die niet meer door normale dia’s worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de collectie `getMasters()` te verwijderen:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook de low‑code‑methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) gebruiken:

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

**Wat is het verschil tussen een slide‑master en een indelingsdia?**

Een slide‑master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een indelingsdia behoort tot een slide‑master en definieert een specifieke ordening van plaatshouders. Een normale dia gebruikt een indelingsdia, waardoor hij zowel van de indeling als van de master erft.

**Kan één presentatie meerdere slide‑masters bevatten?**

Ja. Een presentatie kan meerdere slide‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik plaatshouders toevoegen aan een masterdia of een indelingsdia?**

In de meeste gevallen voeg je plaatshouders toe aan indelingsdia’s. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia, en zet de inhouds‑plaatshouders op de indelingen die normale dia’s zullen gebruiken.

**Kan ik een masterdia verwijderen die nog in gebruik is?**

Nee. Een masterdia die afhankelijke dia’s heeft, kan niet veilig direct worden verwijderd. Verplaats eerst die dia’s naar indelingen onder een andere master, of gebruik een opruimmethode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.