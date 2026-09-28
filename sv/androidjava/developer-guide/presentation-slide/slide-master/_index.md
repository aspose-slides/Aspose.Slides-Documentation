---
title: Hantera presentations slide masters på Android
linktitle: Slide master
type: docs
weight: 70
url: /sv/androidjava/slide-master/
keywords:
- slide master
- master slide
- PPT master slide
- flera master slides
- jämför master slides
- bakgrund
- platshållare
- klona master slide
- kopiera master slide
- duplicera master slide
- oanvänd master slide
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera slide masters i Aspose.Slides för Android via Java: åtkomst, redigering, kloning, jämförelse och borttagning av master slides i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **slide master** definierar delade designinställningar för en grupp av slides. Den kan innehålla gemensamma former, logotyper, bakgrunder, textstilar, temainställningar och fotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje slide.

Aspose.Slides för Android via Java stöder samma modell. En presentation kan innehålla en eller flera master slides, och varje master slide kan innehålla flera layout slides. Vanliga slides refererar vanligtvis inte direkt till en master slide. Istället använder en normal slide en layout slide, och den layout slide tillhör en master slide.

Hierarkin är:

1. **Slide master** – definierar den delade designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layout‑nivåformatering.  
1. **Normal slide** – innehåller det faktiska presentationsinnehållet och använder en layout slide.

![Hierarkin av master slides, layout slides och normal slides](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/) . Alla master slides i en presentation är tillgängliga via samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getMasters--) , som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslidecollection/). För hela Android via Java API‑ytan, se [com.aspose.slides API reference](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en master slide och en layout slide båda definierar en bakgrund, använder slides baserade på den layouten layout‑bakgrunden. För mer information om layout slides, se [Apply or Change Slide Layouts](/slides/sv/androidjava/slide-layout/).
{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn från **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoint‑fliken View](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `getMasters()` för att få åtkomst till master slides:

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

Du kan också hämta master‑sliden som en normal slide använder via dess layout:

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

## **Vad en Slide Master innehåller**

En master slide är ett bildlikt objekt. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/) , så den exponerar många av samma bildegenskaper som används av normal‑ och layout‑slides.

| Medlem | Syfte |
| --- | --- |
| `getBackground()` | Anger master‑nivåets bildbakgrund. |
| `getShapes()` | Lagrar former placerade på master, såsom logotyper, bildramar och delad text. |
| `getLayoutSlides()` | Lagrar layout‑slides som tillhör mastern. |
| `getThemeManager()` | Tillhandahåller åtkomst till master‑temats API:er. |
| `getHeaderFooterManager()` | Kontrollerar sidhuvuden, sidfötter, datum och bildnummer för mastern och dess underliggande layouter. |
| `getDependingSlides()` | Returnerar normala slides som är beroende av mastern via deras layouter. |

## **Lägg till en bild i en Slide Master**

När du lägger till en bild i en master slide visas den på slides som använder layouter från den mastern. Detta är användbart för logotyper, vattenmärken, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första master‑sliden:

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

För mer information om bildramar, se [Picture Frame](/slides/sv/androidjava/picture-frame/).

## **Styr synligheten för master‑grafik**

Använd [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) för att dölja ärvd master‑grafik, såsom logotyper eller dekorativa former, utan att ta bort dem från mastern. Skicka `false` till [Slide.setShowMasterShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) på den slide som ska utelämna den grafiken och behåll `true` på slides som ska visa dem.

Följande fristående exempel skapar ett blått dekorativt band på en master och två slides som använder samma tomma layout. Bandet är synligt på den första sliden och dolt på den andra. Ingen indata‑presentation eller bild krävs.

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

Exemplet använder den **Blank**‑layout som levereras med en ny presentation och tar bort den ursprungliga bildens egna platshållare.

### **Välj räckvidden för inställningen**

En normal slide använder sin master via [ISlide.getLayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getLayoutSlide--) och [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Att sätta egenskapen på en enskild slide påverkar endast den sliden. Att skicka `false` till [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) döljer master‑grafik för slides som använder den delade layouten, även om deras egen inställning är `true`. För att dölja grafik på bara en slide, ändra slide‑egenskapen och lämna den delade layouten oförändrad.

Inställningen stöds inte som en synlighetskontroll på själva master‑sliden. På en master returnerar [getShowMasterShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) alltid `false`, och att skicka `true` till [setShowMasterShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) kastar ett undantag. Använd den på en normal slide eller en layout istället.

### **Skilj på grafik och bakgrund**

| Åtgärd | Effekt |
| --- | --- |
| Dölj master‑grafik | Styr synligheten för ärvda master‑former utan att radera dem eller ändra bildens egna former. |
| Ändra bildens bakgrundsfyllning | Ändrar bakgrundens färg, gradient eller bild. Master‑grafik är separata former och kan förbli synliga över den bakgrunden. Se [Presentation Background](/slides/sv/androidjava/presentation-background/). |
| Ta bort en form från mastern | Tar bort den delade källformen, så den inte längre är tillgänglig för någon slide som använder den mastern. |

## **Arbeta med platshållare**

Platshållare defineras normalt på layout‑slides. Master‑sliden tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon tillgängliga i Slide Master‑vyn.

![Infoga platshållarkommandot i PowerPoint Slide Master‑vyn](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med den layout‑slide som tillhör mastern:

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

Du kan också formatera platshållarformer som redan finns på en master slide. Följande exempel hittar titel‑platshållaren och tillämpar en linjär gradientfyllning:

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

![Formaterad titel‑platshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/androidjava/manage-placeholder/) och [Text Formatting](/slides/sv/androidjava/text-formatting/).

## **Ändra en Slide Master‑bakgrund**

En master‑bakgrund ärvs av layouter och slides som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första master‑sliden:

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

För relaterade ämnen, se [Presentation Background](/slides/sv/androidjava/presentation-background/) och [Presentation Theme](/slides/sv/androidjava/presentation-theme/).

## **Klona en Slide Master till en annan presentation**

Använd [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) för att kopiera en master slide till en annan presentation. Den kopierade master‑sliden kan sedan användas av layouter och slides i destination‑presentationen.

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

Om du behöver klona normala slides tillsammans med deras master, se [Clone Slides](/slides/sv/androidjava/clone-slides/).

## **Lägg till flera Slide Masters**

En presentation kan innehålla flera master slides. Detta är användbart när olika sektioner kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera master slides](slide-master_9.jpg)

Följande exempel klonar standard‑master, ger klonen en annan bakgrund, skapar en layout under den klonade mastern och lägger till en ny slide baserad på den layouten:

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

## **Jämför Slide Masters**

Master slides kan jämföras med `equals`‑metoden som ärvd från [IBaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra slide‑inställningar. Den jämför inte unika identifierare, såsom slide‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Compare Presentation Slides](/slides/sv/androidjava/compare-slides/).

## **Ställ in Slide Master‑vyn som standardvy**

Använd `setLastView`‑metoden på [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

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

För fler vyinställningar, se [Save Presentation](/slides/sv/androidjava/save-presentation/).

## **Ta bort oanvända master slides**

Presentationer kan ibland innehålla master slides som inte längre används av några normala slides. Att ta bort oanvända masters kan minska filstorleken och förenkla underhållet av mallar.

Använd `removeUnused` för att ta bort oanvända masters från `getMasters()`‑samlingen:

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

Du kan också använda lågkods‑metoden [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

En slide master definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layout slide tillhör en master slide och definierar en specifik placering av platshållare. En normal slide använder en layout slide, så den ärver både från layouten och mastern.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera slide masters. Använd flera masters när olika sektioner behöver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare på en master slide eller en layout slide?**

I de flesta fall lägger du till platshållare på layout slides. Placera delade visuella element och gemensam formatering på master‑sliden, och lägg sedan innehålls‑platshållare på de layouter som normala slides kommer att använda.

**Kan jag ta bort en master slide som fortfarande används?**

Nej. En master slide som har beroende slides kan inte tas bort direkt på ett säkert sätt. Flytta först de slides till layouter under en annan master, eller använd en städningsmetod för oanvända masters som endast tar bort masters som inte är i bruk.