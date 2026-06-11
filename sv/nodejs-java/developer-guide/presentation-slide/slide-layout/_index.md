---
title: Tillämpa eller ändra bildlayouter i JavaScript
linktitle: Bildlayout
type: docs
weight: 60
url: /sv/nodejs-java/slide-layout/
keywords:
- bildlayout
- innehållslayout
- platshållare
- presentationsdesign
- bilddesign
- oanvänd layout
- fotnotssynlighet
- titelsida
- titel och innehåll
- sektionrubrik
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera och anpassa bildlayouter i Aspose.Slides för Node.js. Utforska layouttyper, platshållarkontroll och fotnotssynlighet genom kodexempel."
---
## **Introduktion**

Ett bildlayout definierar arrangemanget av platshållarbokslådor och formatering för innehållet på en bild. Det styr vilka platshållare som är tillgängliga och var de visas. Bildlayouter hjälper dig att skapa presentationer snabbt och konsekvent — oavsett om du skapar något enkelt eller mer komplext. Några av de vanligaste bildlayouterna i PowerPoint är:

**Title Slide layout** – Inkluderar två textplatshållare: en för titel och en för underrubrik.

**Title and Content layout** – Har en mindre titelplatshållare högst upp och en större under för huvudinnehåll (såsom text, punktlistor, diagram, bilder med mera).

**Blank layout** – Innehåller inga platshållare, vilket ger dig full kontroll att designa bilden från grunden.

Bildlayouter är en del av en bildmaster, som är den översta bilden som definierar layoutstilar för presentationen. Du kan komma åt och ändra layoutbilder via bildmastern — antingen efter typ, namn eller unik ID. Alternativt kan du redigera en specifik layoutbild direkt i presentationen.

För att arbeta med bildlayouter i Aspose.Slides för Node.js kan du använda:

- Metoder som [getLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getLayoutSlides) och [getMasters](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getMasters) under klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/)
- Typer som [LayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/) och [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

För att lära dig mer om att arbeta med bildmastrar, läs artikeln [Slide Master](/slides/sv/nodejs-java/slide-master/).

{{% /alert %}}

## **Lägg till bildlayouter i presentationer**

För att anpassa utseendet och strukturen på dina bilder kan du behöva lägga till nya layoutbilder i en presentation. Aspose.Slides för Node.js låter dig kontrollera om en viss layout redan finns, lägga till en ny om den behövs och använda den för att infoga bilder baserade på den layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Få åtkomst till [MasterLayoutSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterlayoutslidecollection/).
1. Kontrollera om den önskade layoutbilden redan finns i samlingen. Om den inte finns, lägg till den layoutbild du behöver.
1. Lägg till en tom bild baserad på den nya layoutbilden.
1. Spara presentationen.

Följande JavaScript‑kod demonstrerar hur du lägger till en bildlayout i en PowerPoint‑presentation:

```js
// Skapa ett Presentation‑objekt som representerar en PowerPoint‑fil.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Gå igenom layoutbildtyperna för att välja en layoutbild.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Ett fall där presentationen inte innehåller alla layouttyper.
        // presentationsfilen innehåller endast tomma och anpassade layouttyper.
        // Men layoutbilder med anpassade typer kan ha igenkännbara namn,
        // såsom "Title", "Title and Content" osv., vilka kan användas för att välja layoutbild.
        // Du kan också förlita dig på en uppsättning av platshållarformstyper.
        // Till exempel bör en titelsida bara ha typ av titel‑platshållare, med mera.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Lägg till en tom bild med den lagda layoutbilden.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Spara presentationen till disk.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) i klassen [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/) för att låta dig radera oönskade och oanvända layoutbilder.

Följande JavaScript‑kod visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till platshållare i bildlayouter**

Aspose.Slides tillhandahåller metoden [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager), som låter dig lägga till nya platshållare i en layoutbild.

Denna manager innehåller metoder för följande platshållartyper:

| PowerPoint‑platshållare            | [LayoutPlaceholderManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutplaceholdermanager/)‑metod |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Innehåll](content.png)            | addContentPlaceholder(float x, float y, float width, float height) |
| ![Innehåll (Vertikal)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertikal)](textV.png)       | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Bild](picture.png)                | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabell](table.png)                | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online‑bild](onlineimage.png)     | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Följande JavaScript‑kod demonstrerar hur du lägger till nya platshållarformer i den tomma layoutbilden:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den tomma layoutbilden.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Hämta platshållarhanteraren för layoutbilden.
    let placeholderManager = layout.getPlaceholderManager();

    // Lägg till olika platshållare i den tomma layoutbilden.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Lägg till en ny bild med den tomma layouten.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Platshållarna på layoutbilden](add_placeholders.png)

## **Ställ in fotnotssynlighet för en layoutbild**

I PowerPoint‑presentationer kan fotnotelement som datum, bildnummer och anpassad text visas eller döljas beroende på bildlayouten. Aspose.Slides för Node.js låter dig kontrollera synligheten för dessa fotnotplatshållare. Detta är användbart när du vill att vissa layouter ska visa fotnotinformation medan andra ska vara rena och minimalistiska.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en layoutbild via dess index.
1. Ställ in fotnotsplatsför bildens sidfot till synlig.
1. Ställ in bildnummer‑platshållaren till synlig.
1. Ställ in datum‑tid‑platshållaren till synlig.
1. Spara presentationen.

Följande JavaScript‑kod visar hur du ställer in synligheten för en bildfot och utför relaterade uppgifter:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Ställ in barnfotnotssynlighet för en bild**

​I PowerPoint‑presentationer kan fotnotelement såsom datum, bildnummer och anpassad text kontrolleras på masternivå för att säkerställa konsistens över alla layoutbilder. Aspose.Slides för Node.js möjliggör att du ställer in synlighet och innehåll för dessa fotnotplatshållare på mastern och sprider inställningarna till alla underordnade layoutbilder. Detta tillvägagångssätt garanterar enhetlig fotnotinformation i hela presentationen.​

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till mastern via dess index.
1. Ställ in master‑ och alla barns fotnot‑platshållare till synliga.
1. Ställ in master‑ och alla barns bildnummer‑platshållare till synliga.
1. Ställ in master‑ och alla barns datum‑tid‑platshållare till synliga.
1. Spara presentationen.

Följande JavaScript‑kod demonstrerar denna operation:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad är skillnaden mellan en mastern och en layoutbild?**

En mastern definierar det övergripande temat och standardformateringen, medan layoutbilder definierar specifika arrangemang av platshållare för olika typer av innehåll.

**Kan jag kopiera en layoutbild från en presentation till en annan?**

Ja, du kan klona en layoutbild från en presentations layoutbildssamling, åtkomlig via metoden [getLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getLayoutSlides), och infoga den i en annan presentation med metoden `addClone`.

**Vad händer om jag tar bort en layoutbild som fortfarande används av en bild?**

Om du försöker ta bort en layoutbild som fortfarande refereras av minst en bild i presentationen, kommer Aspose.Slides att kasta ett [PptxEditException](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pptxeditexception/). För att undvika detta, använd [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) som säkert tar bort endast de layoutbilder som inte är i bruk.