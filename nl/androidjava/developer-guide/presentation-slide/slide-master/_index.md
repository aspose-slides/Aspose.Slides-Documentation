---
title: Beheer dia-masters van presentatie op Android
linktitle: Dia-master
type: docs
weight: 70
url: /nl/androidjava/slide-master/
keywords:
- dia-master
- masterdia
- PPT-masterdia
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
- Android
- Java
- Aspose.Slides
description: "Beheer dia-masters in Aspose.Slides voor Android via Java: toegang, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Een **dia‑master** definieert gedeelde ontwerpeigenschappen voor een groep dia’s. Het kan gemeenschappelijke vormen, logo’s, achtergronden, tekststijlen, themainstellingen en voetteksteigenschappen bevatten. In PowerPoint is het bewerken van een dia‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak voor elke dia te herhalen.

Aspose.Slides voor Android via Java ondersteunt hetzelfde model. Een presentatie kan één of meer masterdia’s bevatten, en elke masterdia kan meerdere layout‑dia’s bevatten. Gewone dia’s verwijzen meestal niet rechtstreeks naar een masterdia. In plaats daarvan gebruikt een gewone dia een layout‑dia, en die layout‑dia behoort tot een masterdia.

De hiërarchie is:

1. **Dia‑master** – definieert het gedeelde ontwerp en thema.  
1. **Layout‑dia** – definieert een specifieke rangschikking van tijdelijke aanduidingen en lay-out‑niveau opmaak.  
1. **Normale dia** – bevat de feitelijke presentatie‑inhoud en gebruikt één layout‑dia.

![De hiërarchie van masterdia’s, layout‑dia’s en normale dia’s](slide-master_2.jpg)

In Aspose.Slides wordt een dia‑master weergegeven door de [IMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/)‑interface. Alle masterdia’s in een presentatie zijn beschikbaar via de [Presentation.getMasters](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getMasters--)‑collectie, die [IMasterSlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/) implementeert. Voor het volledige Android‑via‑Java‑API‑oppervlak, zie de [com.aspose.slides API‑referentie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
Wanneer dezelfde eigenschap op meer dan één niveau wordt gedefinieerd, wint het meer specifieke niveau. Bijvoorbeeld, als een masterdia en een layout‑dia beide een achtergrond definiëren, gebruiken dia’s die op die layout zijn gebaseerd de achtergrond van de layout. Voor meer informatie over layout‑dia’s, zie [Apply or Change Slide Layouts](/slides/nl/androidjava/slide-layout/).
{{% /alert %}}

## **Toegang tot Dia‑masters**

In PowerPoint kun je de Dia‑master‑weergave openen via **Beeld** > **Dia‑master**.

![De Dia‑master‑opdracht op het PowerPoint‑tabblad Beeld](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters()`‑collectie om masterdia’s te benaderen:

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

Je kunt ook de masterdia ophalen die door een normale dia wordt gebruikt via de bijbehorende layout:

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

## **Wat een Dia‑master Bevat**

Een masterdia is een object dat op een dia lijkt. Het implementeert [IBaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/), waardoor het veel van dezelfde dia‑eigenschappen blootlegt die door normale en layout‑dia’s worden gebruikt.

Veelgebruikte leden van een masterdia zijn onder andere:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond van de master‑dia in. |
| `getShapes()` | Bewaart vormen die op de master zijn geplaatst, zoals logo’s, foto‑frames en gedeelde tekst. |
| `getLayoutSlides()` | Bewaart de layout‑dia’s die bij de master horen. |
| `getThemeManager()` | Biedt toegang tot de master‑thema‑API’s. |
| `getHeaderFooterManager()` | Beheert kop‑ en voetteksten, datums en dia‑nummers voor de master en haar onderliggende layouts. |
| `getDependingSlides()` | Retourneert normale dia’s die via hun layouts van de master afhangen. |

## **Een Afbeelding Toevoegen aan een Dia‑master**

Wanneer je een afbeelding toevoegt aan een masterdia, verschijnt deze op dia’s die layouts van die master gebruiken. Dit is handig voor logo’s, watermerken, decoratieve banden en andere herhaalde visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste masterdia:

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

Voor meer informatie over foto‑frames, zie [Picture Frame](/slides/nl/androidjava/picture-frame/).

## **De Zichtbaarheid van Master‑Grafische Objecten Sturen**

Gebruik [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) om geërfde master‑grafische objecten, zoals logo’s of decoratieve vormen, te verbergen zonder ze van de master te verwijderen. Geef `false` door aan [Slide.setShowMasterShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) op de dia die die grafische objecten moet weglaten en houd `true` op dia’s die ze wel moeten weergeven.

Het volgende zelf‑voorzienende voorbeeld maakt een blauwe decoratieve band op een master en twee dia’s die dezelfde lege layout gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding nodig.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
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

Het voorbeeld gebruikt de **Blank**‑layout die wordt meegeleverd met een nieuwe presentatie en verwijdert de initiële tijdelijke aanduidingen van de eerste dia.

### **Kies de Reikwijdte van de Instelling**

Een normale dia gebruikt zijn master via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/#getLayoutSlide--) en [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). De eigenschap op een individuele dia instellen heeft alleen effect op die specifieke dia. `false` doorgeven aan [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) verbergt master‑grafische objecten voor alle dia’s die die gedeelde layout gebruiken, zelfs als hun eigen instelling `true` is. Om grafische objecten slechts op één dia te verbergen, wijzig je de dia‑eigenschap en laat je de gedeelde layout ongewijzigd.

De instelling wordt niet ondersteund als een zichtbaarheid‑controle op de masterdia zelf. Op een master geeft [getShowMasterShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) altijd `false` terug, en `true` doorgeven aan [setShowMasterShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) veroorzaakt een uitzondering. Pas het toe op een normale dia of een layout.

### **Grafische Objecten Onderscheiden van de Achtergrond**

| Handeling | Effect |
| --- | --- |
| Master‑grafische objecten verbergen | Stelt de zichtbaarheid van geërfde master‑vormen in zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| Dia‑achtergrond vullen wijzigen | Verandert de achtergrondkleur, -gradient of -afbeelding. Master‑grafische objecten zijn afzonderlijke vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentation Background](/slides/nl/androidjava/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, zodat deze niet langer beschikbaar is voor enige dia die die master gebruikt. |

## **Werken met Tijdelijke Aanduidingen**

Tijdelijke aanduidingen worden normaal gedefinieerd op layout‑dia’s. De masterdia levert de gedeelde stijl en het thema die die layouts erven, terwijl elke layout beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn tijdelijke‑aanduidings‑opdrachten beschikbaar in de Dia‑master‑weergave.

![De opdracht Tijdelijke aanduiding invoegen in de PowerPoint‑Dia‑master‑weergave](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de layout‑dia die bij de master hoort:

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

Je kunt ook de vormen van bestaande tijdelijke aanduidingen op een masterdia opmaken. Het volgende voorbeeld vindt de titel‑tijdelijke aanduiding en past een lineaire gradient‑vulling toe:

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

![Opgepaste titel‑tijdelijke aanduiding geërfd door normale dia’s](slide-master_8.png)

Voor meer opties voor tijdelijke aanduidingen en tekstopmaak, zie [Set Prompt Text in Placeholder](/slides/nl/androidjava/manage-placeholder/) en [Text Formatting](/slides/nl/androidjava/text-formatting/).

## **Een Dia‑master‑Achtergrond Wijzigen**

Een master‑achtergrond wordt geërfd door layouts en dia’s die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste masterdia:

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

Zie voor gerelateerde onderwerpen [Presentation Background](/slides/nl/androidjava/presentation-background/) en [Presentation Theme](/slides/nl/androidjava/presentation-theme/).

## **Een Dia‑master Klonen naar Een Andere Presentatie**

Gebruik [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) om een masterdia naar een andere presentatie te kopiëren. De gekopieerde master kan vervolgens worden gebruikt door layouts en dia’s in de bestemmingspresentatie.

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

Als je normale dia’s wilt klonen samen met hun master, zie [Clone Slides](/slides/nl/androidjava/clone-slides/).

## **Meerdere Dia‑masters Toevoegen**

Een presentatie kan meerdere masterdia’s bevatten. Dit is nuttig wanneer verschillende secties verschillende branding, paginastuctuur of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van masterdia’s](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard‑master, geeft de kloon een andere achtergrond, maakt een layout onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die layout:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

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

## **Dia‑masters Vergelijken**

Masterdia’s kunnen worden vergeleken met de `equals`‑methode die wordt geërfd van [IBaseSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers zoals dia‑ID’s of dynamische tijdelijke‑aanduidingswaarden zoals de huidige datum worden niet vergeleken.

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

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/androidjava/compare-slides/).

## **Dia‑master‑Weergave Als Standaard‑Weergave Instellen**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in de Dia‑master‑weergave:

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

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/androidjava/save-presentation/).

## **Ongebruikte Masterdia’s Verwijderen**

Presentaties kunnen soms masterdia’s bevatten die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verminderen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de `getMasters()`‑collectie te verwijderen:

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

Je kunt ook de low‑code‑methode [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) gebruiken:

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

**Wat is het verschil tussen een dia‑master en een layout‑dia?**

Een dia‑master definieert gedeelde ontwerp‑instellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een layout‑dia behoort tot een masterdia en definieert een specifieke rangschikking van tijdelijke aanduidingen. Een normale dia gebruikt een layout‑dia, zodat hij zowel van de layout als van de master erft.

**Kan een presentatie meerdere dia‑masters bevatten?**

Ja. Een presentatie kan meerdere masterdia’s bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding vereisen.

**Moet ik tijdelijke aanduidingen toevoegen aan een masterdia of een layout‑dia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan layout‑dia’s. Plaats gedeelde visuele elementen en gedeelde opmaak op de masterdia en zet inhoudelijke tijdelijk‑aanduidingen op de layouts die normale dia’s gaan gebruiken.

**Kan ik een masterdia verwijderen die nog in gebruik is?**

Nee. Een masterdia met afhankelijke dia’s kan niet veilig direct worden verwijderd. Verplaats die dia’s eerst naar layouts onder een andere master, of gebruik een opruimmethode die alleen ongebruikte masters verwijdert.