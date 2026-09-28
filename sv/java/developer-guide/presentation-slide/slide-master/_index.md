---
title: "Hantera slide‑master i Java"
linktitle: "Slide‑master"
type: docs
weight: 70
url: /sv/java/slide-master/
keywords:
- slide‑master
- master‑slide
- PPT‑master‑slide
- flera master‑bilder
- jämför master‑bilder
- bakgrund
- platshållare
- klona master‑slide
- kopiera master‑slide
- duplicera master‑slide
- oanvänd master‑slide
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera slide‑mastrar i Aspose.Slides för Java: åtkomst, redigering, kloning, jämförelse och borttagning av master‑bilder i PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

En **slide master** definierar gemensamma designinställningar för en grupp bildspel. Den kan innehålla vanliga former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides for Java stöder samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Vanliga bilder refererar normalt inte direkt till en masterbild. Istället använder en vanlig bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Slide master** – definierar den gemensamma designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layoutnivåformatering.  
1. **Normal slide** – innehåller själva presentationsinnehållet och använder en layoutbild.

![Hierarkin av masterbilder, layoutbilder och vanliga bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/). Alla masterbilder i en presentation är tillgängliga via samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasters--) som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå har den mer specifika nivån företräde. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder som baseras på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Applicera eller ändra bildlayout](/slides/sv/java/slide-layout/).
{{% /alert %}}

## **Åtkomst till slide master**

I PowerPoint kan du öppna Slide Master‑vyn via **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoints flik View](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `getMasters()` för att komma åt masterbilder:

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

Du kan också hämta masterbilden som en normal bild använder via dess layout:

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

## **Vad en slide master innehåller**

En masterbild är ett bildliknande objekt. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/), så den exponerar många av samma bildegenskaper som används av vanliga bilder och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [IMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/).

Vanligt använda master‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `getBackground()` | Ställer in masternivåns bildbakgrund. |
| `getShapes()` | Lagrar former placerade på mastern, såsom logotyper, bildramar och delad text. |
| `getLayoutSlides()` | Lagrar layoutbilderna som tillhör mastern. |
| `getThemeManager()` | Ger åtkomst till mastertemats API:er. |
| `getHeaderFooterManager()` | Kontrollerar sidhuvuden, sidfotter, datum och bildnummer för mastern och dess underlayouter. |
| `getDependingSlides()` | Returnerar vanliga bilder som beror på mastern via deras layouter. |

## **Lägg till en bild i en slide master**

När du lägger till en bild i en masterbild visas den på bilder som använder layouter från den mastern. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

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

För mer information om bildramar, se [Bildram](/slides/sv/java/picture-frame/).

## **Styr synligheten för mastergrafik**

Använd [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) för att dölja ärvd mastergrafik, såsom logotyper eller dekorativa former, utan att radera dem från mastern. Skicka `false` till [Slide.setShowMasterShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slide/#setShowMasterShapes-boolean-) på den bild som ska utelämna grafiken och håll den `true` på bilder som ska visa den.

Följande fristående exempel skapar ett blått dekorativt band på en master och två bilder som använder samma tomma layout. Bandet är synligt på den första bilden och dolt på den andra. Ingen inmatnings‑presentation eller bild krävs.

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

Exemplet använder den **Blank** layout som följer med en ny presentation och tar bort de ursprungliga platshållarna på den första bilden.

### **Välj omfattning för inställningen**

En normal bild använder sin master via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islide/#getLayoutSlide--) och [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#getMasterSlide--). Att sätta egenskapen på en enskild bild påverkar bara den bilden. Att skicka `false` till [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) döljer mastergrafik för bilder som använder den delade layouten, även om deras egna inställning är `true`. För att dölja grafik på endast en bild, ändra bildens egenskap och låt den delade layouten vara oförändrad.

Inställningen stöds inte som en synlighetskontroll på själva masterbilden. På en master returnerar [getShowMasterShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterslide/#getShowMasterShapes--) alltid `false`, och att skicka `true` till [setShowMasterShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) kastar ett undantag. Använd den på en normal bild eller en layout istället.

### **Skilj grafik från bakgrunden**

| Operation | Effekt |
| --- | --- |
| Dölj mastergrafik | Styr synligheten för ärvda masterformer utan att radera dem eller ändra bildens egna former. |
| Ändra bildens bakgrundsfyllning | Ändrar bakgrundens färg, gradient eller bild. Mastergrafik är separata former och kan förbli synliga över bakgrunden. Se [Presentationbakgrund](/slides/sv/java/presentation-background/). |
| Radera en form från mastern | Tar bort den delade källformen, så den inte längre är tillgänglig för någon bild som använder den mastern. |

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns kommandon för platshållare i Slide Master‑vyn.

![Infoga platshållare‑kommandot i PowerPoints Slide Master‑vy](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med den layoutbild som tillhör mastern:

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

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titelplatshållaren och applicerar en linjär gradientfyllning:

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

![Formaterad titelplatshållare ärvd av vanliga bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Ställ in prompttext i platshållare](/slides/sv/java/manage-placeholder/) och [Textformatering](/slides/sv/java/text-formatting/).

## **Ändra en slide master‑bakgrund**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första masterbilden:

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

För relaterade ämnen, se [Presentationbakgrund](/slides/sv/java/presentation-background/) och [Presentationstema](/slides/sv/java/presentation-theme/).

## **Klona en slide master till en annan presentation**

Använd [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) för att kopiera en masterbild till en annan presentation. Den kopierade mastern kan sedan användas av layouter och bilder i mål‑presentationen.

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

Om du behöver klona vanliga bilder tillsammans med deras master, se [Klona bilder](/slides/sv/java/clone-slides/).

## **Lägg till flera slide masters**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika sektioner kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standardmastern, ger klonen en annan bakgrund, skapar en layout under den klonade mastern och lägger till en ny bild baserad på den layouten:

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

## **Jämför slide masters**

Masterbilder kan jämföras med `equals`‑metoden som ärvts från [IBaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Jämför presentationsbilder](/slides/sv/java/compare-slides/).

## **Ställ in Slide Master‑vyn som standardvy**

Använd metoden `setLastView` på [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

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

För fler vyinställningar, se [Spara presentation](/slides/sv/java/save-presentation/).

## **Ta bort oanvända masterbilder**

Presentationer kan ibland innehålla masterbilder som inte längre används av någon normal bild. Att ta bort oanvända mastrar kan minska filstorleken och förenkla underhållet av mallar.

Använd `removeUnused` för att ta bort oanvända mastrar från samlingen `getMasters()`:

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

Du kan också använda den låg‑kodade metoden [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-):

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

**Vad är skillnaden mellan en slide master och en layout slide?**

En slide master definierar gemensamma designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layout slide tillhör en masterbild och definierar en specifik placering av platshållare. En normal bild använder en layout slide, så den ärver både från layouten och mastern.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera slide masters. Använd flera mastrar när olika sektioner behöver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare på en masterbild eller en layout slide?**

I de flesta fall lägger du till platshållare på layoutbilder. Placera delade visuella element och delad formatering på masterbilden, och placera innehålls‑platshållare på de layouter som de vanliga bilderna ska använda.

**Kan jag radera en masterbild som fortfarande används?**

Nej. En masterbild som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en rengöringsmetod som bara tar bort mastrar som inte är i bruk.