---
title: Klonade presentationsbilder i Java
linktitle: Klonade bilder
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
description: "Duplicera snabbt PowerPoint-bilder med Aspose.Slides för Java. Följ våra tydliga kodexempel för att automatisera skapandet av PPT på några sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Klona är processen att göra en exakt kopia eller replika av något. Aspose.Slides for Java gör det också möjligt att skapa en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Klona i slutet inom en presentation.
- Klona på en annan position inom presentationen.
- Klona i slutet i en annan presentation.
- Klona på en annan position i en annan presentation.
- Klona tillsammans med dess masternedbild in i en annan presentation.

I Aspose.Slides for Java, (en samling av [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) objektet tillhandahåller metoderna [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) och [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) för att utföra ovanstående typer av bildkloning

## **Klona en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoden enligt stegen nedan:

1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) objektet.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) objektet och skicka den bild som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoden.
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (liggande på första positionen – nollindex – i presentationen) till slutet av presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass som representerar en presentationsfil
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
Om du vill klona en bild och sedan använda den i samma presentationsfil men på en annan position, använd [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metoden:

1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
1. Instansiera klassen genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) objektet.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) objektet och skicka bilden som ska klonas tillsammans med indexet för den nya positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (liggande på index 1 – position 2 – i presentationen) till index 2 – position 3 – i presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass som representerar en presentationsfil
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Hämta samlingen av bilder i presentationen
    ISlideCollection slds = pres.getSlides();

    // Klona den önskade bilden till det angivna indexet i samma presentation
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // Skriv den modifierade presentationen till disk
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Klona en bild i slutet av en annan presentation**
Om du behöver klona en bild från en presentation och använda den i en annan presentationsfil, i slutet av de befintliga bilderna:

1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller presentationen som bilden ska klonas från.
1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection) genom att referera till [**Slides**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) objektet och skicka bilden från källpresentationen som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) metoden.
1. Skriv den modifierade mål‑presentationens fil.

I exemplet nedan har vi klonat en bild (från första indexet i källpresentationen) till slutet av mål‑presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klass för mål‑PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till slutet av samlingen av bilder i målpresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // Skriv målpresentationen till disk
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

1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa metoden [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) objektet och skicka bilden från källpresentationen tillsammans med den önskade positionen som en parameter till [insertClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) metoden.
1. Skriv den modifierade mål‑presentationens fil.

I exemplet nedan har vi klonat en bild (från nollindex i källpresentationen) till index 1 (position 2) i mål‑presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klass för mål-PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klon den önskade bilden från källpresentationen till det specificerade indexet i målpresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // Skriv målpresentationen till disk
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona en bild med dess masternedbild till en annan presentation**
Om du behöver klona en bild med en masternedbild från en presentation och använda den i en annan presentation, måste du först klona den önskade masternedbilden från källpresentationen till mål‑presentationen. Därefter använder du den masternedbilden för att klona bilden med masternedbild. Metoden [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) förväntar en masternedbild från mål‑presentationen snarare än från källpresentationen. För att klona bilden med en masternedbild, följ stegen nedan:

1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa ett exempel av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska klonas till.
1. Åtkomst till bilden som ska klonas tillsammans med masternedbilden.
1. Instansiera klassen [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IMasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IMasterSlideCollection) objektet och skicka mastern från käll‑PPTX som ska klonas som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metoden.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) objektet för mål‑presentationen.
1. Anropa metoden [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) objektet och skicka bilden från källpresentationen som ska klonas samt masternedbilden som en parameter till [addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) metoden.
1. Skriv den modifierade mål‑presentationens fil.

I exemplet nedan har vi klonat en bild med en masternedbild (liggande på nollindex i källpresentationen) till slutet av mål‑presentationen med en masternedbild från källbilden.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klass för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instansiera Presentation-klass för mål‑presentation (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Instansiera ISlide från samlingen av bilder i källpresentationen tillsammans med
        // Masternedbild
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // Klona den önskade masternedbilden från källpresentationen till samlingen av masternedbilder i
        // Målpresentationen
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // Klona den önskade bilden från källpresentationen med den önskade masternedbilden till slutet av
        // Samlingen av bilder i målpresentationen
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // Spara målpresentationen till disk
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Klona en bild i slutet av ett specificerat avsnitt**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd [**addClone**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) metoden som exponeras av [**ISlideCollection**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection)‑gränssnittet. Aspose.Slides for Java möjliggör kloning av en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // Spara målpresentationen till disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Säkerställ matchande bildstorlek**

När du klonar bilder till en annan presentation, se till att mål‑presentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar inte Aspose.Slides automatiskt om de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir felplacerat eller sträcker sig utanför bildens gränser.

Du kan ställa in mål‑presentationens bildstorlek så att den matchar källan innan du klonar mastern och bilden:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Gör detta innan du klonar mastern och bilden.

## **FAQ**

**Klona talarnoter och granskningskommentarer?**

Ja. Notssidan och granskningskommentarerna ingår i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/java/presentation-notes/) efter insättningen.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/java/manage-ole/). Efter flytt mellan filer, verifiera datatillgänglighet och uppdateringsbeteende.

**Kan jag kontrollera insättningspositionen och avsnitten för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/java/slide-section/). Om målavsnittet saknas, skapa det först och flytta sedan bilden dit.