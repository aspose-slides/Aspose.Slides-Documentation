---
title: Beheer dia‑masters in presentaties met Java
linktitle: Dia‑master
type: docs
weight: 70
url: /nl/java/slide-master/
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
- Java
- Aspose.Slides
description: "Beheer dia‑masters in Aspose.Slides voor Java: openen, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Een **dia‑master** definieert gedeelde ontwerpinstellingen voor een groep dia’s. Het kan gemeenschappelijke vormen, logo’s, achtergronden, tekststijlen, themainstellingen en voetteksteigenschappen bevatten. In PowerPoint is het bewerken van een dia‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides for Java ondersteunt hetzelfde model. Een presentatie kan één of meer dia‑masters bevatten, en elke dia‑master kan meerdere indelingsdia’s bevatten. Normale dia’s verwijzen meestal niet direct naar een dia‑master. In plaats daarvan gebruikt een normale dia een indelingsdia, en die indelingsdia behoort tot een dia‑master.

De hiërarchie is:

1. **Dia‑master** – definieert het gedeelde ontwerp en thema.  
1. **Indelingsdia** – definieert een specifieke rangschikking van tijdelijke aanduidingen en opmaak op indelingsniveau.  
1. **Normale dia** – bevat de daadwerkelijke presentatiewaarde en gebruikt één indelingsdia.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides wordt een dia‑master weergegeven door de [IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) interface. Alle dia‑masters in een presentatie zijn beschikbaar via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getMasters--) collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/) implementeert.

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, heeft het specifiekere niveau voorrang. Bijvoorbeeld, als een dia‑master en een indelingsdia beide een achtergrond definiëren, gebruiken dia’s gebaseerd op die indeling de achtergrond van de indeling. Zie voor meer informatie over indelingsdia’s [Apply or Change Slide Layouts](/slides/nl/java/slide-layout/).
{{% /alert %}}

## **Dia‑masters benaderen**

In PowerPoint kun je de Dia‑masterweergave openen via **Beeld** > **Dia‑master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters()` collectie om dia‑masters te benaderen:

```java
import com.aspose.slides.*;

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

Je kunt ook de dia‑master verkrijgen die door een normale dia wordt gebruikt via zijn indeling:

```java
import com.aspose.slides.*;

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

## **Wat een dia‑master bevat**

Een dia‑master is een object dat op een dia lijkt. Het implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/), waardoor het vele van dezelfde dia‑eigenschappen blootlegt die door normale en indelingsdia’s worden gebruikt. Master‑specifieke leden staan vermeld op de [IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/) API‑pagina.

Veelgebruikte leden van een dia‑master zijn onder andere:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond op master‑niveau in. |
| `getShapes()` | Opslag van vormen die op de master zijn geplaatst, zoals logo’s, foto‑frames en gedeelde tekst. |
| `getLayoutSlides()` | Opslag van de indelingsdia’s die tot de master behoren. |
| `getThemeManager()` | Biedt toegang tot de master‑thema‑API’s. |
| `getHeaderFooterManager()` | Beheert kop‑ en voetteksten, datum en dia‑nummers voor de master en zijn onderliggende indelingen. |
| `getDependingSlides()` | Geeft normale dia’s terug die afhankelijk zijn van de master via hun indelingen. |

## **Een afbeelding toevoegen aan een dia‑master**

Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt deze op dia’s die indelingen van die master gebruiken. Dit is handig voor logo’s, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste dia‑master:

```java
import com.aspose.slides.*;

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

Voor meer informatie over foto‑frames, zie [Picture Frame](/slides/nl/java/picture-frame/).

## **De zichtbaarheid van master‑graphics beheren**

Gebruik [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) om geërfde master‑graphics, zoals logo’s of decoratieve vormen, te verbergen zonder ze van de master te verwijderen. Geef `false` door aan [Slide.setShowMasterShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) op de dia die die graphics moet weglaten en houd het `true` op dia’s die ze moeten weergeven.

Het volgende zelfstandige voorbeeld maakt een blauwe decoratieve band op een master en twee dia’s die dezelfde lege indeling gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding vereist.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    Color bandColor = new Color(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het voorbeeld maakt gebruik van de **Blank** indeling die wordt geleverd met een nieuwe presentatie en verwijdert de oorspronkelijke tijdelijke aanduidingen van de eerste dia.

### **De reikwijdte van de instelling kiezen**

Een normale dia gebruikt zijn master via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islide/#getLayoutSlide--) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Het instellen van de eigenschap op een individuele dia heeft alleen effect op die dia. Het doorgeven van `false` aan [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) verbergt master‑graphics voor alle dia’s die die gedeelde indeling gebruiken, zelfs als hun eigen instelling `true` is. Om graphics alleen op één dia te verbergen, wijzig je de dia‑eigenschap en laat je de gedeelde indeling ongewijzigd.

De instelling wordt niet ondersteund als zichtbaarheid‑controle op de dia‑master zelf. Op een master geeft [getShowMasterShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterslide/#getShowMasterShapes--) altijd `false` terug, en het doorgeven van `true` aan [setShowMasterShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) veroorzaakt een uitzondering. Pas het toe op een normale dia of een indeling.

### **Graphics onderscheiden van de achtergrond**

| Handeling | Effect |
| --- | --- |
| Master‑graphics verbergen | Beheert de zichtbaarheid van geërfde master‑vormen zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| Dia‑achtergrondvulling wijzigen | Wijzigt de achtergrondkleur, -gradient of -afbeelding. Master‑graphics blijven aparte vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentation Background](/slides/nl/java/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, zodat deze niet langer beschikbaar is voor enige dia die die master gebruikt. |

## **Werken met tijdelijke aanduidingen**

Tijdelijke aanduidingen worden meestal gedefinieerd op indelingsdia’s. De dia‑master levert de gedeelde stijl en het thema waar die indelingen van erven, terwijl elke indeling beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn tijdelijke aanduiding‑opdrachten beschikbaar in de Dia‑masterweergave.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de indelingsdia die tot de master behoort:

```java
import com.aspose.slides.*;

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

Je kunt ook tijdelijke aanduiding‑vormen die al op een dia‑master bestaan, opmaken. Het volgende voorbeeld vindt de titel‑tijdelijke aanduiding en past een lineaire gradientvulling toe:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Voor meer opties voor tijdelijke aanduidingen en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/java/manage-placeholder/) en [Text Formatting](/slides/nl/java/text-formatting/).

## **De achtergrond van een dia‑master wijzigen**

Een master‑achtergrond wordt geërfd door indelingen en dia’s die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste dia‑master:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Voor gerelateerde onderwerpen, zie [Presentation Background](/slides/nl/java/presentation-background/) en [Presentation Theme](/slides/nl/java/presentation-theme/).

## **Een dia‑master klonen naar een andere presentatie**

Gebruik [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) om een dia‑master te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door indelingen en dia’s in de bestemmingspresentatie.

```java
import com.aspose.slides.*;

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

Als je normale dia’s moet klonen samen met hun master, zie [Clone Slides](/slides/nl/java/clone-slides/).

## **Meerdere dia‑masters toevoegen**

Een presentatie kan meerdere dia‑masters bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginacompositie of themainstellingen vereisen.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard master, geeft de kloon een andere achtergrond, maakt een indeling onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die indeling:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Dia‑masters vergelijken**

Dia‑masters kunnen worden vergeleken met de `equals`‑methode die van [IBaseSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/) is geërfd. De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID’s, of dynamische tijdelijke‑aanduidingswaarden, zoals de huidige datum.

```java
import com.aspose.slides.*;

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

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/java/compare-slides/).

## **Dia‑masterweergave als standaardweergave instellen**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Dia‑masterweergave:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/java/save-presentation/).

## **Ongebruikte dia‑masters verwijderen**

Presentaties kunnen dia‑masters bevatten die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de `getMasters()` collectie te verwijderen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook de low‑code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) methode gebruiken:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een dia‑master en een indelingsdia?**

Een dia‑master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een indelingsdia behoort tot een dia‑master en definieert een specifieke rangschikking van tijdelijke aanduidingen. Een normale dia gebruikt een indelingsdia, waardoor hij zowel van de indeling als van de master erft.

**Kan een presentatie meerdere dia‑masters bevatten?**

Ja. Een presentatie kan meerdere dia‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik tijdelijke aanduidingen toevoegen aan een dia‑master of een indelingsdia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan indelingsdia’s. Plaats gedeelde visuele elementen en gedeelde opmaak op de dia‑master en plaats inhoudelijke tijdelijke aanduidingen op de indelingen die normale dia’s zullen gebruiken.

**Kan ik een dia‑master verwijderen die nog in gebruik is?**

Nee. Een dia‑master met afhankelijke dia’s kan niet veilig direct worden verwijderd. Verplaats die dia’s eerst naar indelingen onder een andere master, of gebruik een opschonings‑methode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.