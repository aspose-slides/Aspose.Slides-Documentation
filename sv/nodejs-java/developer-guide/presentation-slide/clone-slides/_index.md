---
title: Klona presentationsbilder i JavaScript
linktitle: Klona bilder
type: docs
weight: 35
url: /sv/nodejs-java/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för Node.js. Följ våra kodexempel för att automatisera skapandet av PPT på sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att göra en exakt kopia eller replika av något. Aspose.Slides for Node.js via Java gör det också möjligt att göra en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona på en annan position inom en presentation.
- Klona i slutet i en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

I Aspose.Slides for Node.js via Java, (en samling av [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-objektet ger metoderna [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) och [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) för att utföra ovanstående typer av bildkloning

## **Klona i slutet inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metoden enligt stegen som listas nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) genom att referera till Slides-samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-objektet.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka med den bild som ska klonas som parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metoden.
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (placerad på den första positionen – index 0 – i presentationen) till slutet av presentationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiera Presentation-klassen som representerar en presentationsfil
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klona den önskade bilden till slutet av bildsamlingen i samma presentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Skriv den modifierade presentationen till disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klona på en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metoden:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Instansiera klassen genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-objektet.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden som ska klonas tillsammans med index för den nya positionen som parameter till [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (placerad på index 1 – position 2 – i presentationen) till index 2 – position 3 – i presentationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiera Presentation-klassen som representerar en presentationsfil
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klona den önskade bilden till slutet av bildsamlingen i samma presentation
    var slds = pres.getSlides();
    // Klona den önskade bilden till det angivna indexet i samma presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Skriv den modifierade presentationen till disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klona i slutet i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller den presentation som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska läggas till i.
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection) genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden från källpresentationen som parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metoden.
1. Skriv den modifierade mål‑presentationens fil.

I exemplet nedan har vi klonat en bild (från det första indexet i källpresentationen) till slutet av mål‑presentationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Skriv destinationspresentationen till disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona på en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller den presentation som bilden ska läggas till i.
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden från källpresentationen tillsammans med önskad position som parameter till [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) metoden.
1. Skriv den modifierade mål‑presentationens fil.

I exemplet nedan har vi klonat en bild (från index 0 i källpresentationen) till index 1 (position 2) i mål‑presentationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Skriv destinationspresentationen till disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona på en specifik position i en annan presentation**
Om du behöver klona en bild med en master‑bild från en presentation och använda den i en annan presentation, måste du först klona den önskade master‑bilden från källpresentationen till mål‑presentationen. Därefter använder du den master‑bilden för att klona bilden med master‑bilden. Metoden [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) förväntar sig en master‑bild från mål‑presentationen snarare än från källpresentationen. För att klona bilden med en master, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska klonas till.
1. Kom åt bilden som ska klonas tillsammans med master‑bilden.
1. Instansiera klassen [MasterSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) som exponeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterSlideCollection)-objektet och skicka med master‑bilden från käll‑PPTX som ska klonas som parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metoden.
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)-objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden från källpresentationen som ska klonas samt master‑bilden som parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metoden.
1. Skriv den modifierade mål‑presentationens fil.

I exemplet nedan har vi klonat en bild med en master (placerad på index 0 i källpresentationen) till slutet av mål‑presentationen med en master från käll‑bilden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiera Presentation-klassen för destinationspresentationen (där bilden ska klonas)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
        // Master-bild
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klona den önskade master-bilden från källpresentationen till samlingen av masterbilder i
        // Destinationspresentationen
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Klona den önskade bilden från källpresentationen med den önskade master-bilden till slutet av
        // Bildsamlingen i destinationspresentationen
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Spara destinationspresentationen till disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona i slutet i en specificerad sektion**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i en annan sektion, använd då [**addClone**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) metoden som exponeras av klassen [**SlideCollection**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java gör det möjligt att klona en bild från den första sektionen och sedan infoga den klonade bilden i den andra sektionen av samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i en specificerad sektion.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Spara destinationspresentationen till disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Säkerställ matchande bildstorlek**

När du klonar bilder till en annan presentation, se till att mål‑presentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar Aspose.Slides inte automatiskt om de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehåll blir feljusterat eller sträcker sig utanför bildens gränser.

Du kan ställa in mål‑presentationens bildstorlek så att den matchar källan innan du klonar master‑ och bild‑objekten:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Gör detta innan du klonar master‑ och bild‑objekten.

## **FAQ**

**Klona talarnoter och granskningskommentarer?**

Ja. Notssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/nodejs-java/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/nodejs-java/manage-ole/). Efter flyttning mellan filer, kontrollera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningsposition och sektioner för klonen?**

Ja. Du kan infoga klonen på ett specifikt bild‑index och placera den i en vald [sektion](/slides/sv/nodejs-java/slide-section/). Om målsektionen inte finns, skapa den först och flytta sedan bilden till den.