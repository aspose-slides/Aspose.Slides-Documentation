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
description: "Duplicera PowerPoint‑bilder snabbt med Aspose.Slides för Node.js. Följ våra kodexempel för att automatisera skapandet av PPT på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen för att göra en exakt kopia eller replika av något. Aspose.Slides för Node.js via Java gör det också möjligt att skapa en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppnad presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra originalbilden. Det finns flera möjliga sätt att klona en bild:

- Klon i slutet inom en presentation.
- Klon på en annan position inom en presentation.
- Klon i slutet i en annan presentation.
- Klon på en annan position i en annan presentation.
- Klon på en specifik position i en annan presentation.

I Aspose.Slides för Node.js via Java (en samling av [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Slide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) objektet tillhandahåller metoderna [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) och [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) för att utföra ovanstående typer av bildkloning

## **Klon i slutet inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden.
1. Skriv den ändrade presentationsfilen.

I exemplet nedan har vi klonat en bild (placerad på den första positionen – index 0 – i presentationen) till slutet av presentationen.

```javascript
// Skapa en Presentation-klass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Skriv den ändrade presentationen till disken
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon på en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑metoden:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Instansiera klassen genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet.
1. Anropa [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden som ska klonas tillsammans med indexet för den nya positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑metoden.
1. Skriv den ändrade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (placerad på index 0 – position 1 – i presentationen) till index 1 – position 2 – i presentationen.

```javascript
// Skapa en Presentation-klass som representerar en presentationsfil
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    var slds = pres.getSlides();
    // Klona den önskade bilden till det angivna indexet i samma presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Skriv den ändrade presentationen till disken
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon i slutet i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller den presentation som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller destinationspresentationen som bilden ska läggas till i.
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection) genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑samlingen som exponeras av Presentation‑objektet för destinationspresentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen som en parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden.
1. Skriv den ändrade destinationspresentationsfilen.

I exemplet nedan har vi klonat en bild (från det första indexet i källpresentationen) till slutet av destinationspresentationen.

```javascript
// Instansiera Presentation-klass för att läsa in källpresentationsfilen
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klass för destinations-PPTX (där bilden ska klonas)
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

## **Klon på en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller den presentation som bilden ska läggas till i.
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för destinationspresentationen.
1. Anropa [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen tillsammans med önskad position som en parameter till [insertClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-)‑metoden.
1. Skriv den ändrade destinationspresentationsfilen.

I exemplet nedan har vi klonat en bild (från index 0 i källpresentationen) till index 1 (position 2) i destinationspresentationen.

```javascript
// Instansiera Presentation-klass för att läsa in källpresentationsfilen
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klass för destinations-PPTX (där bilden ska klonas)
    var destPres = new aspose.slides.Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av bildsamlingen i destinationspresentationen
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Skriv destinationspresentationen till disk
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon på specifik position i en annan presentation**
Om du behöver klona en bild med en mastern bild från en presentation och använda den i en annan presentation, måste du först klona den önskade mastern från källpresentationen till destinationspresentationen. Därefter måste du använda den mastern för att klona bilden med mastern. Metoden [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) förväntar sig en mastern från destinationspresentationen snarare än från källpresentationen. För att klona bilden med en mastern, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som innehåller destinationspresentationen som bilden ska klonas till.
1. Åtkomst till bilden som ska klonas tillsammans med mastern.
1. Instansiera klassen [MasterSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet för destinationspresentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden som exponeras av [MasterSlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterSlideCollection)‑objektet och skicka mastern från käll‑PPTX som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden.
1. Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation)‑objektet för destinationspresentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden som exponeras av [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen som ska klonas samt mastern som en parameter till [addClone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-)‑metoden.
1. Skriv den ändrade destinationspresentationsfilen.

I exemplet nedan har vi klonat en bild med en mastern (placerad på index 0 i källpresentationen) till slutet av destinationspresentationen med en mastern från källbilden.

```javascript
// Instansiera Presentation-klass för att läsa in källpresentationsfilen
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiera Presentation-klass för destinationspresentationen (där bilden ska klonas)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
        // Masterbild
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klona den önskade masterbilden från källpresentationen till samlingen av masterbilder i
        // destinationspresentationen
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Klona den önskade masterbilden från källpresentationen till samlingen av masterbilder i
        // destinationspresentationen
        var iSlide = masters.addClone(SourceMaster);
        // Klona den önskade bilden från källpresentationen med den önskade masterbilden till slutet av
        // samlingen av bilder i destinationspresentationen
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Spara destinationspresentationen till disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon i slutet i angiven sektion**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i en annan sektion, använd då [**addClone**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-)‑metoden som exponeras av klassen [**SlideCollection**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides för Node.js via Java gör det möjligt att klona en bild från den första sektionen och sedan infoga den klonade bilden i den andra sektionen i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i en angiven sektion.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Spara destinationspresentationen till disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Klona anteckningar för talare och granskningskommentarer?**

Ja. Noteringssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/nodejs-java/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. ett OLE‑inbäddat arbetsbok), bevaras den länken som ett [OLE‑objekt](/slides/sv/nodejs-java/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och sektionerna för klonen?**

Ja. Du kan infoga klonen vid ett specifikt bildindex och placera den i en vald [sektion](/slides/sv/nodejs-java/slide-section/). Om målsektionen inte finns, skapa den först och flytta sedan bilden dit.