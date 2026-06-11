---
title: Hantera bildmastere för presentationer på Android
linktitle: Bildmaster
type: docs
weight: 70
url: /sv/androidjava/slide-master/
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
- Android
- Java
- Aspose.Slides
description: "Hantera bildmastere i Aspose.Slides för Android via Java: få åtkomst till, redigera, klona, jämföra och ta bort masterbilder i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **bildmaster** definierar gemensamma designinställningar för en grupp bildspel. Den kan innehålla gemensamma former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en bildmaster det vanliga sättet att hålla en presentation enhetlig utan att upprepa samma formatering på varje bild.

**Aspose.Slides for Android via Java** stöder samma modell. En presentation kan innehålla en eller flera bildmastere, och varje bildmaster kan innehålla flera layoutbilder. Vanliga bilder refererar vanligtvis inte direkt till en bildmaster. Istället använder en vanlig bild en layoutbild, och den layoutbilden tillhör en bildmaster.

Hierarkin är:

1. **Bildmaster** – definierar den gemensamma designen och temat.  
2. **Layoutbild** – definierar en specifik placering av platshållare och layoutnivåformatering.  
3. **Normal bild** – innehåller det faktiska presentationsinnehållet och använder en layoutbild.  

![Hierarkin av bildmastere, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en bildmaster av gränssnittet [IMasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslide/) . Alla bildmastere i en presentation är tillgängliga via samlingen [Presentation.getMasters](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getMasters--) , som implementerar [IMasterSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslidecollection/). För hela Android via Java API‑ytan, se [com.aspose.slides API‑referensen](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/).

{{% alert color="info" title="Inheritance" %}}
När samma egenskap är definierad på mer än en nivå vinner den mer specifika nivån. Till exempel, om en bildmaster och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Apply or Change Slide Layouts](/slides/sv/androidjava/slide-layout/).
{{% /alert %}}

## **Åtkomst till bildmastere**

I PowerPoint kan du öppna bildmaster‑visning via **Visa** > **Bildmaster**.

![Bildmaster‑kommandot på PowerPoints flik Visa](slide-master_3.jpg)

I Aspose.Slides, använd samlingen `getMasters()` för att komma åt bildmastere:

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

En bildmaster är ett objekt liknande en bild. Den implementerar [IBaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/), så den exponerar många av samma bildegenskaper som används av normala bilder och layoutbilder.

Vanligt använda medlemmar i en bildmaster inkluderar:

| Medlem | Syfte |
| --- | --- |
| `getBackground()` | Ställer in bakgrunden på masternivå för bilden. |
| `getShapes()` | Lagrar former placerade på mastern, såsom logotyper, bildramar och delad text. |
| `getLayoutSlides()` | Lagrar layoutbilderna som tillhör mastern. |
| `getThemeManager()` | Ger åtkomst till mastertema‑API:erna. |
| `getHeaderFooterManager()` | Styr sidhuvuden, sidfötter, datum och bildnummer för mastern och dess underliggande layouter. |
| `getDependingSlides()` | Returnerar normala bilder som är beroende av mastern via deras layouter. |

## **Lägg till en bild i en bildmaster**

När du lägger till en bild i en bildmaster visas den på bilder som använder layouter från den mastern. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp till den första bildmastern:

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

För mer information om bildramar, se [Picture Frame](/slides/sv/androidjava/picture-frame/).

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Bildmastern tillhandahåller den delade stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon tillgängliga i bildmaster‑vyn.

![Infoga platshållarkommandot i PowerPoints bildmaster‑vy](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med den layoutbild som tillhör mastern:

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

Du kan också formatera platshållarformer som redan finns på en bildmaster. Följande exempel hittar titelplatshållaren och applicerar en linjär gradientfyllning:

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

![Formaterad titelplatshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/slides/sv/androidjava/manage-placeholder/) och [Text Formatting](/slides/sv/androidjava/text-formatting/).

## **Ändra en bildmasters bakgrund**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första bildmastern:

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

För relaterade ämnen, se [Presentation Background](/slides/sv/androidjava/presentation-background/) och [Presentation Theme](/slides/sv/androidjava/presentation-theme/).

## **Klona en bildmaster till en annan presentation**

Använd [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) för att kopiera en bildmaster till en annan presentation. Den kopierade mastern kan sedan användas av layouter och bilder i destinationspresentationen.

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

Om du behöver klona normala bilder tillsammans med deras master, se [Clone Slides](/slides/sv/androidjava/clone-slides/).

## **Lägg till flera bildmastere**

En presentation kan innehålla flera bildmastere. Detta är användbart när olika sektioner kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera bildmastere](slide-master_9.jpg)

Följande exempel klonar standardmastern, ger klonen en annan bakgrund, skapar en layout under den klonade mastern och lägger till en ny bild baserad på den layouten:

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

## **Jämför bildmastere**

Bildmastere kan jämföras med `equals`‑metoden som ärvd från [IBaseSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Compare Presentation Slides](/slides/sv/androidjava/compare-slides/).

## **Ställ in bildmaster‑vyn som standardvy**

Använd metoden `setLastView` på [ViewProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/viewproperties/) för att styra den vy som PowerPoint öppnar först. Följande exempel öppnar presentationen i bildmaster‑vyn:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

För fler vyinställningar, se [Save Presentation](/slides/sv/androidjava/save-presentation/).

## **Ta bort oanvända bildmastere**

Presentationer kan ibland innehålla bildmastere som inte längre används av någon normal bild. Att ta bort oanvända mastere kan minska filstorleken och förenkla underhållet av mallar.

Använd `removeUnused` för att ta bort oanvända mastere från samlingen `getMasters()`:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Du kan också använda low‑code‑metoden [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

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

En bildmaster definierar gemensamma designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en bildmaster och definierar en specifik placering av platshållare. En normal bild använder en layoutbild, så den ärver både från layouten och från mastern.

**Kan en presentation innehålla flera bildmastere?**

Ja. En presentation kan innehålla flera bildmastere. Använd flera mastere när olika sektioner kräver olika visuella system eller varumärkesprofil.

**Bör jag lägga till platshållare i en bildmaster eller en layoutbild?**

I de flesta fall lägger du till platshållare i layoutbilder. Placera delade visuella element och gemensam formatering på bildmastern, och lägg sedan innehållsplatshållare på de layouter som normala bilder kommer att använda.

**Kan jag ta bort en bildmaster som fortfarande används?**

Nej. En bildmaster som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en städningsmetod för oanvända mastere som bara tar bort mastere som inte används.