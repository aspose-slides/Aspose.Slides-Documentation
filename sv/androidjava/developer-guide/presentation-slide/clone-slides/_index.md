---
title: Klona presentationsbilder på Android
linktitle: Klona bilder
type: docs
weight: 35
url: /sv/androidjava/clone-slides/
keywords:
- klona bild
- kopiera bild
- spara bild
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Duplicera PowerPoint-bilder med Aspose.Slides för Android. Följ våra tydliga Java-kodexempel för att automatisera skapandet av PPT på sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att skapa en exakt kopia eller replika av något. Aspose.Slides för Android via Java gör det också möjligt att skapa en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppnad presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Kloning i slutet inom en presentation.
- Kloning på en annan position inom en presentation.
- Kloning i slutet i en annan presentation.
- Kloning på en annan position i en annan presentation.
- Kloning på en specifik position i en annan presentation.

I Aspose.Slides för Android via Java ger (en samling av [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑objektet metoderna [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) och [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) för att utföra ovanstående typer av bildkloning

## **Klon en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden enligt stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑objektet.
3. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka den bild som ska klonas som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden.
4. Skriv den modifierade presentationsfilen.

I exemplaret nedan har vi klonat en bild (som ligger på den första positionen – noll‑index – i presentationen) till slutet av presentationen.

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

## **Klon en bild till en annan position inom en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
2. Instansiera klassen genom att referera till **Slides**‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑objektet.
3. Anropa [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka den bild som ska klonas tillsammans med indexet för den nya positionen som parameter till [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden.
4. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplaret nedan har vi klonat en bild (som ligger på noll‑index – position 1 – i presentationen) till index 1 – position 2 – i presentationen.

```java
// Instansiera Presentation-klassen som representerar en presentationsfil
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Klona den önskade bilden till slutet av samlingen av bilder i samma presentation
    ISlideCollection slds = pres.getSlides();

    // Klona den önskade bilden till det angivna indexet i samma presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Skriv den modifierade presentationen till disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klon en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller den presentation som bilden ska klonas från.
2. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller destinationspresentationen som bilden ska läggas till i.
3. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection) genom att referera till **Slides**‑samlingen som exponeras av Presentation‑objektet i destinationspresentationen.
4. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden.
5. Skriv den modifierade destinationspresentationsfilen.

I exemplaret nedan har vi klonat en bild (från det första indexet i källpresentationen) till slutet av destinationspresentationen.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för destinations-PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i destinationspresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Skriv destinationspresentationen till disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon en bild till en annan position i en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, på en specifik position:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
2. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller den presentation som bilden ska läggas till i.
3. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet i destinationspresentationen.
4. Anropa [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen tillsammans med önskad position som parameter till [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden.
5. Skriv den modifierade destinationspresentationsfilen.

I exemplaret nedan har vi klonat en bild (från noll‑index i källpresentationen) till index 1 (position 2) i destinationspresentationen.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för destination PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i destinationspresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // Skriv destinationspresentationen till disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon en bild på en specifik position i en annan presentation**
Om du behöver klona en bild med en master‑bild från en presentation och använda den i en annan presentation, måste du först klona den önskade master‑bilden från källpresentationen till destinationspresentationen. Därefter måste du använda den master‑bilden för att klona bilden med master. Metoden [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) förväntar sig en master‑bild från destinationspresentationen snarare än från källpresentationen. För att klona bilden med en master, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
2. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller destinationspresentationen som bilden ska klonas till.
3. Åtkomst till bilden som ska klonas tillsammans med master‑bilden.
4. Instansiera klassen [IMasterSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑objektet i destinationspresentationen.
5. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMasterSlideCollection)‑objektet och skicka master‑bilden från käll‑PPTX som ska klonas som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden.
6. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)‑objektet i destinationspresentationen.
7. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka bilden från källpresentationen som ska klonas samt master‑bilden som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden.
8. Skriv den modifierade destinationspresentationsfilen.

I exemplaret nedan har vi klonat en bild med en master (som ligger på noll‑index i källpresentationen) till slutet av destinationspresentationen med en master från källbilden.

```java
// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiera Presentation-klassen för destinationspresentationen (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
        // Master-bild
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klona den önskade master-bilden från källpresentationen till samlingen av master-bilder i
        // Destinationspresentationen
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klona den önskade master-bilden från källpresentationen till samlingen av master-bilder i
        // Destinationspresentationen
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klona den önskade bilden från källpresentationen med önskad master till slutet av
        // Samlingen av bilder i destinationspresentationen
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // Spara destinationspresentationen till disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klon en bild i slutet av ett angivet avsnitt**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd då [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)‑metoden som exponeras av gränssnittet [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides för Android via Java gör det möjligt att klona en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // Spara destinationspresentationen till disk
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Klona föreläsarnoter och granskningskommentarer?**

Ja. Notssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/androidjava/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/androidjava/manage-ole/). Efter flytt mellan filer, kontrollera datatillgänglighet och uppdateringsbeteende.

**Kan jag styra infogningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/androidjava/slide-section/). Om målavsnittet inte finns, skapa det först och flytta sedan bilden dit.