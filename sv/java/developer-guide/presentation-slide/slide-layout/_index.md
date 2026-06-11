---
title: Applicera eller ändra bildlayouter i Java
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationdesign
- bilddesign
- oanvänd layout
- fotovisning
- titelsida
- titel och innehåll
- avsnittsrubrik
- två innehåll
- jämförelse
- endast titel
- tom layout
- innehåll med bildtext
- bild med bildtext
- titel och vertikal text
- vertikal titel och text
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera och anpassa bildlayouter i Aspose.Slides för Java. Utforska layouttyper, kontroll av platshållare och fotovisning genom Java-kodexempel."
---
## **Introduktion**

Ett bildlayout definierar arrangemanget av platshållarboxar och formatering för innehållet på en bild. Det styr vilka platshållare som är tillgängliga och var de visas. Bildlayouter hjälper dig att snabbt och konsekvent skapa presentationer—oavsett om du skapar något enkelt eller mer avancerat. Några av de vanligaste bildlayouterna i PowerPoint är:

**Titelbildslayout** – Innehåller två textplatshållare: en för titeln och en för undertiteln.

**Titel‑ och innehållslayout** – Har en mindre titelplatshållare högst upp och en större nedanför för huvudinnehåll (såsom text, punktlistor, diagram, bilder och mer).

**Tom layout** – Innehåller inga platshållare, vilket ger dig full kontroll att designa bilden från grunden.

Bildlayouter är en del av en bildmaster, som är den översta bilden som definierar layoutstilar för presentationen. Du kan komma åt och ändra layoutbilder via bildmastern—antingen efter deras typ, namn eller unika ID. Alternativt kan du redigera en specifik layoutbild direkt i presentationen.

För att arbeta med bildlayouter i Aspose.Slides for Java, kan du använda:

- Metoder som [getLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getLayoutSlides--) och [getMasters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasters--) under klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) 
- Typer som [ILayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/), och [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
För att lära dig mer om att arbeta med masternbilder, se artikeln [Slide Master](/slides/sv/java/slide-master/).
{{% /alert %}}

## **Lägg till bildlayouter i presentationer**

För att anpassa utseendet och strukturen på dina bilder kan du behöva lägga till nya layoutbilder i en presentation. Aspose.Slides for Java låter dig kontrollera om en specifik layout redan finns, lägga till en ny om det behövs, och använda den för att infoga bilder baserade på den layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Få åtkomst till [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/imasterlayoutslidecollection/).
3. Kontrollera om den önskade layoutbilden redan finns i samlingen. Om den inte finns, lägg till den layoutbild du behöver.
4. Lägg till en tom bild baserad på den nya layoutbilden.
5. Spara presentationen.

Följande Java‑kod demonstrerar hur du lägger till en bildlayout i en PowerPoint‑presentation:

```java
// Skapa ett Presentation‑objekt som representerar en PowerPoint‑fil.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Gå igenom layout‑bildtyperna för att välja en layout‑bild.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // En situation där presentationen inte innehåller alla layouttyper.
        // presentationsfilen innehåller endast tomma och anpassade layouttyper.
        // Dock kan layoutbilder med anpassade typer ha igenkännliga namn,
        // såsom "Title", "Title and Content", osv., vilket kan användas för att välja layoutbild.
        // Du kan också förlita dig på en uppsättning platshållar‑formtyper.
        // Till exempel bör en titelsida bara ha platshållartypen Title, och så vidare.
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

    // Lägg till en tom bild med den tillagda layoutbilden.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Spara presentationen till disk.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) från klassen [Compress](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/), så att du kan ta bort oönskade och oanvända layoutbilder.

Följande Java‑kod visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till platshållare i bildlayouter**

Aspose.Slides tillhandahåller metoden [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) , som låter dig lägga till nya platshållare i en layoutbild.

Denna manager innehåller metoder för följande platshållartyper:

| PowerPoint‑platshållare | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ilayoutplaceholdermanager/) Metod |
| ----------------------- | ------------------------------------------------------------ |
| ![Innehåll](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Innehåll (Vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertikal)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabell](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑bild](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Följande Java‑kod demonstrerar hur du lägger till nya platshållarformer i den Tomma layoutbilden:

```java
Presentation presentation = new Presentation();
try {
    // Hämta den tomma layoutbilden.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Hämta platshållarhanteraren för layoutbilden.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Lägg till olika platshållare i den tomma layoutbilden.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Lägg till en ny bild med den tomma layouten.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![The placeholders on the layout slide](add_placeholders.png)

## **Ange synlighet för sidfot på en layoutbild**

I PowerPoint‑presentationer kan fotelement som datum, bildnummer och anpassad text visas eller döljas beroende på bildlayouten. Aspose.Slides for Java låter dig styra synligheten för dessa fot‑platshållare. Detta är användbart när du vill att vissa layouter visar fotinformation medan andra förblir rena och minimalistiska.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta en referens till en layoutbild med dess index.
3. Ställ in bildens fot‑platshållare till synlig.
4. Ställ in bildnummer‑platshållaren till synlig.
5. Ställ in datum‑tid‑platshållaren till synlig.
6. Spara presentationen.

Följande Java‑kod visar hur du ställer in synligheten för en bildfot och utför relaterade uppgifter:

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

## **Ange synlighet för underordnad fot på en bild**

I PowerPoint‑presentationer kan fotelement som datum, bildnummer och anpassad text kontrolleras på masternivå för att säkerställa konsekvens över alla layoutbilder. Aspose.Slides for Java gör det möjligt att ange synlighet och innehåll för dessa fot‑platshållare på mastern och sprida dessa inställningar till alla underordnade layoutbilder. Detta tillvägagångssätt säkerställer enhetlig fotinformation i hela din presentation.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Hämta en referens till mastern med dess index.
3. Ställ in masterns och alla underordnade fot‑platshållare till synliga.
4. Ställ in masterns och alla underordnade bildnummer‑platshållare till synliga.
5. Ställ in masterns och alla underordnade datum‑tid‑platshållare till synliga.
6. Spara presentationen.

Följande Java‑kod demonstrerar denna operation:

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

**Vad är skillnaden mellan en mastern och en layoutbild?**

En mastern definierar det övergripande temat och standardformatering, medan layoutbilder definierar specifika arrangemang av platshållare för olika typer av innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja, du kan klona en layoutbild från en presentations layoutsamling, som är åtkomlig via metoden [getLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getLayoutSlides--) , och infoga den i en annan presentation med metoden `addClone`.

**Vad händer om jag tar bort en layoutbild som fortfarande används av en bild?**

Om du försöker ta bort en layoutbild som fortfarande refereras av minst en bild i presentationen, kommer Aspose.Slides att kasta ett [PptxEditException](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pptxeditexception/). För att undvika detta, använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) , som på ett säkert sätt tar bort endast de layoutbilder som inte används.