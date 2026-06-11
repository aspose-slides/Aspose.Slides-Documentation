---
title: Hantera bildmaster i presentationer i Java
linktitle: Bildmaster
type: docs
weight: 70
url: /sv/java/slide-master/
keywords:
- bildmaster
- masterbild
- PPT-masterbild
- flera masterbilder
- jämför masterbilder
- bakgrund
- platshållare
- klona masterbild
- kopiera masterbild
- duplicera masterbild
- oanvänd masterbild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera bildmaster i Aspose.Slides för Java: få åtkomst till, redigera, klona, jämföra och ta bort masterbilder i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **bildmaster** definierar delade designinställningar för en grupp bilder. Den kan innehålla gemensamma former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en bildmaster det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides for Java stöder samma modell. En presentation kan innehålla en eller flera bildmasterar, och varje bildmaster kan innehålla flera layoutbilder. Normala bilder refererar vanligtvis inte direkt till en bildmaster. Istället använder en normal bild en layoutbild, och den layoutbilden tillhör en bildmaster.

Hierarkin är:

1. **Bildmaster** – definierar den delade designen och temat.  
1. **Layoutbild** – definierar en specifik placering av platshållare och layoutnivåformatering.  
1. **Normal bild** – innehåller själva presentationsinnehållet och använder en layoutbild.

![Hierarkin för masterbilder, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en bildmaster av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/). Alla bildmasterar i en presentation finns tillgängliga via samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasters--) som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Arv" %}}

När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en bildmaster och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutbakgrunden. För mer information om layoutbilder, se [Tillämpa eller ändra bildlayouter](/slides/sv/java/slide-layout/).

{{% /alert %}}

## **Få åtkomst till bildmasterar**

I PowerPoint kan du öppna Bildmaster‑vyn via **View** > **Slide Master**.

![Bildmaster‑kommandot på PowerPoint‑fliken Visa](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `getMasters()` för att komma åt bildmasterar:

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

Du kan också hämta bildmastern som används av en normal bild via dess layout:

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

## **Vad en bildmaster innehåller**

En bildmaster är ett bild‑liknande objekt. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/), så den exponerar många av samma bildegenskaper som används av normala och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [IMasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslide/).

Vanligt använda bildmaster‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `getBackground()` | Anger master‑nivåns bildbakgrund. |
| `getShapes()` | Lagrar former som placerats på mastern, såsom logotyper, bildramar och delad text. |
| `getLayoutSlides()` | Lagrar layoutbilderna som tillhör mastern. |
| `getThemeManager()` | Ger åtkomst till mastertemats API:er. |
| `getHeaderFooterManager()` | Styr sidhuvuden, sidfötter, datum och bildnummer för mastern och dess underliggande layouter. |
| `getDependingSlides()` | Returnerar normala bilder som är beroende av mastern via sina layouter. |

## **Lägg till en bild i en bildmaster**

När du lägger till en bild i en bildmaster visas den på bilder som använder layouter från den mastern. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första bildmastern:

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

För mer information om bildramar, se [Bildram](/slides/sv/java/picture-frame/).

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Bildmastern tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns kommandon för platshållare i Bildmaster‑vyn.

![Infoga platshållare‑kommandot i PowerPoint‑Bildmaster‑vyn](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med layoutbilden som tillhör mastern:

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

Du kan också formatera platshållarformer som redan finns på en bildmaster. Följande exempel hittar titel‑platshållaren och tillämpar en linjär gradientfyllning:

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

![Formaterad titel‑platshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Ange uppmaningstext i platshållare](/slides/sv/java/manage-placeholder/) och [Textformatering](/slides/sv/java/text-formatting/).

## **Ändra bakgrund för en bildmaster**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första bildmastern:

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

För relaterade ämnen, se [Presentationsbakgrund](/slides/sv/java/presentation-background/) och [Presentationstema](/slides/sv/java/presentation-theme/).

## **Klona en bildmaster till en annan presentation**

Använd [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) för att kopiera en bildmaster till en annan presentation. Den kopierade mastern kan sedan användas av layouter och bilder i destinationspresentationen.

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

Om du behöver klona normala bilder tillsammans med deras master, se [Klona bilder](/slides/sv/java/clone-slides/).

## **Lägg till flera bildmasterar**

En presentation kan innehålla flera bildmasterar. Detta är användbart när olika sektioner kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera bildmasterar](slide-master_9.jpg)

Följande exempel klonar standard‑mastern, ger klonen en annan bakgrund, skapar en layout under den klonade mastern och lägger till en ny bild baserad på den layouten:

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

## **Jämför bildmasterar**

Bildmasterar kan jämföras med metoden `equals` som ärvs från [IBaseSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Jämför presentationsbilder](/slides/sv/java/compare-slides/).

## **Ställ in Bildmaster‑vy som standardsyn**

Använd metoden `setLastView` på [ViewProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Bildmaster‑vyn:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För fler vyinställningar, se [Spara presentation](/slides/sv/java/save-presentation/).

## **Ta bort oanvända bildmasterar**

Presentationer kan ibland innehålla bildmasterar som inte längre används av några normala bilder. Att ta bort oanvända masterar kan minska filstorleken och förenkla mallunderhåll.

Använd `removeUnused` för att ta bort oanvända masterar från samlingen `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Du kan också använda low‑code‑metoden [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

**Vad är skillnaden mellan en bildmaster och en layoutbild?**

En bildmaster definierar delade designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en bildmaster och definierar en specifik placering av platshållare. En normal bild använder en layoutbild, så den ärvd både layout‑ och master‑inställningarna.

**Kan en presentation innehålla flera bildmasterar?**

Ja. En presentation kan innehålla flera bildmasterar. Använd flera masterar när olika sektioner behöver olika visuella system eller varumärkesprofil.

**Ska jag lägga till platshållare på en bildmaster eller en layoutbild?**

I de flesta fall lägger du till platshållare på layoutbilder. Placera delade visuella element och delad formatering på bildmastern och sätt sedan innehållsplatshållare på de layouter som normala bilder ska använda.

**Kan jag ta bort en bildmaster som fortfarande används?**

Nej. En bildmaster som har beroende bilder kan inte säkert tas bort direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en metod för att rensa bort oanvända masterar som endast tar bort masterar som inte är i bruk.