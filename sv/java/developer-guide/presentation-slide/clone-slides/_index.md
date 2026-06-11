---
title: Klona presentationsbilder i Java
linktitle: Klona bilder
type: docs
weight: 35
url: /sv/java/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides for Java. Följ våra tydliga kodexempel för att automatiskt skapa PPT på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att skapa en exakt kopia eller replik av något. Aspose.Slides for Java gör det också möjligt att göra en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona på en annan position inom en presentation.
- Klona i slutet i en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona på en specifik position i en annan presentation.

I Aspose.Slides for Java, (en samling av [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-objektet tillhandahåller metoderna [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) och [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) för att utföra ovanstående typer av bildkloning

## **Klona en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-objektet.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka den bild som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)-metoden.
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (som ligger på den första positionen – nollindex – i presentationen) till slutet av presentationen.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // Skriv den modifierade presentationen till disk
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klona en bild till en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd metoden [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Instansiera klassen genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-objektet.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka den bild som ska klonas tillsammans med indexet för den nya positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)-metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (som ligger på nollindex – position 1 – i presentationen) till index 1 – position 2 – i presentationen.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    ISlideCollection slds = pres.getSlides();

    // Klona den önskade bilden till det specificerade indexet i samma presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Skriv den modifierade presentationen till disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klona en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller presentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection) genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑samlingen som exponeras av Presentation‑objektet i mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)-metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från det första indexet i källpresentationen) till slutet av mål‑presentationen.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för mål‑PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i målpresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Skriv mål‑presentationen till disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona en bild till en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet i mål‑presentationen.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen tillsammans med den önskade positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)-metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från nollindex i källpresentationen) till index 1 (position 2) i mål‑presentationen.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för mål-PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i målpresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Skriv mål-presentationen till disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona en bild på en specifik position i en annan presentation**
Om du behöver klona en bild med en master‑bild från en presentation och använda den i en annan presentation, måste du först klona den önskade master‑bilden från källpresentationen till mål‑presentationen. Därefter måste du använda den master‑bilden för att klona bilden med master‑bilden. Metoden [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) förväntar sig en master‑bild från mål‑presentationen snarare än från källpresentationen. För att klona bilden med en master, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska klonas till.
1. Åtkomst till bilden som ska klonas tillsammans med master‑bilden.
1. Instansiera klassen [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IMasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-objektet i mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IMasterSlideCollection)-objektet och skicka master‑bilden från käll‑PPTX som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)-metoden.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)-objektet i mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen som ska klonas samt master‑bilden som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)-metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild med en master (som ligger på nollindex i källpresentationen) till slutet av mål‑presentationen med en master från käll‑bilden.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiera Presentation-klassen för målpresentationen (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
        // Master-bild
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klona den önskade master-bilden från källpresentationen till samlingen av master-bilder i
        // Målpresentationen
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klona den önskade master-bilden från källpresentationen till samlingen av master-bilder i
        // Målpresentationen
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klona den önskade bilden från källpresentationen med den önskade master-bilden till slutet av
        // Samlingen av bilder i målpresentationen
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Spara målpresentationen till disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona en bild i slutet av en specificerad sektion**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i en annan sektion, använd då metoden [**addClone**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) som exponeras av gränssnittet [**ISlideCollection**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection). Aspose.Slides for Java gör det möjligt att klona en bild från den första sektionen och sedan infoga den klonade bilden i den andra sektionen av samma presentation.

Följande kodexempel visar hur du klonar en bild och infogar den klonade bilden i en specificerad sektion.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Spara målpresentationen till disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Klonas talarnoteringar och granskningskommentarer?**

Ja. Notssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/java/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/java/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och sektionerna för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i en vald [sektion](/slides/sv/java/slide-section/). Om målsektionen inte finns, skapa den först och flytta sedan bilden dit.