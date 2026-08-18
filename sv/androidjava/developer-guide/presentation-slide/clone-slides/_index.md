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
description: "Duplicera PowerPoint-bilder med Aspose.Slides för Android. Följ våra tydliga Java-kodexempel för att automatisera PPT-skapande på sekunder och eliminera manuellt arbete."
---
## **Introduktion**

Kloning är processen att göra en exakt kopia eller replik av något. Aspose.Slides för Android via Java möjliggör också att skapa en kopia eller klon av vilken bild som helst och sedan infoga den klonade bilden i den aktuella eller någon annan öppen presentation. Processen för bildkloning skapar en ny bild som kan modifieras av utvecklare utan att ändra den ursprungliga bilden. Det finns flera möjliga sätt att klona en bild:

- Kloning i slutet inom en presentation.
- Kloning på annan position inom en presentation.
- Kloning i slutet i en annan presentation.
- Kloning på annan position i en annan presentation.
- Kloning på en specifik position i en annan presentation.

I Aspose.Slides för Android via Java, (en samling av [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlide) objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet tillhandahåller metoderna [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) och [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) för att utföra ovanstående typer av bildkloning

## **Klon en bild i slutet av en presentation**
Om du vill klona en bild och sedan använda den i samma presentationsfil i slutet av de befintliga bilderna, använd [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden enligt stegen nedanstående:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden som ska klonas som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden.
1. Skriv den modifierade presentationsfilen.

I exemplet nedan har vi klonat en bild (som ligger på den första positionen – index 0 – i presentationen) till slutet av presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil
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
1. Instansiera klassen genom att referera till **Slides**‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet.
1. Anropa [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden som ska klonas samt indexet för den nya positionen som parametrar till [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-)‑metoden.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi klonat en bild (som ligger på index 1 – position 2 – i presentationen) till index 2 – position 3 – i presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen som representerar en presentationsfil
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // Hämta samlingen av bilder i samma presentation
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

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller presentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection) genom att referera till **Slides**‑samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden från källpresentationen som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från första indexet i källpresentationen) till slutet av mål‑presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation‑klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation‑klassen för destinations‑PPTX (där bilden ska klonas)
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
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller presentationen som bilden ska läggas till i.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) genom att referera till Slides‑samlingen som exponeras av Presentation‑objektet för mål‑presentationen.
1. Anropa [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden från källpresentationen samt önskad position som parametrar till [insertClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-)‑metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild (från index 0 i källpresentationen) till index 1 (position 2) i mål‑presentationen.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen för att läsa in källpresentationsfilen
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instansiera Presentation-klassen för destination-PPTX (där bilden ska klonas)
    Presentation destPres = new Presentation();
    try {
        // Klona den önskade bilden från källpresentationen till det angivna indexet i destinationspresentationen
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

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
Om du behöver klona en bild med en master‑bild från en presentation och använda den i en annan presentation, måste du först klona den önskade master‑bilden från källpresentationen till mål‑presentationen. Därefter använder du den master‑bilden för att klona bilden med master. Metoden [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) förväntar sig en master‑bild från mål‑presentationen snarare än från källpresentationen. För att klona bilden med en master, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller källpresentationen som bilden ska klonas från.
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) som innehåller mål‑presentationen som bilden ska klonas till.
1. Åtkom bilden som ska klonas tillsammans med master‑bilden.
1. Instansiera klassen [IMasterSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMasterSlideCollection) genom att referera till Masters‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet för mål‑presentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑metoden som exponeras av [IMasterSlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IMasterSlideCollection)-objektet och skicka med master‑bilden från käll‑PPTX som parameter till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑metoden.
1. Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) genom att sätta referensen till Slides‑samlingen som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-objektet för mål‑presentationen.
1. Anropa [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑metoden som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑objektet och skicka med bilden från källpresentationen som ska klonas samt master‑bilden som parametrar till [addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-)‑metoden.
1. Skriv den modifierade mål‑presentationsfilen.

I exemplet nedan har vi klonat en bild med en master (som ligger på index 0 i källpresentationen) till slutet av mål‑presentationen med hjälp av en master från käll‑bilden.

```java
import com.aspose.slides.*;

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

        // Klona den önskade master‑bilden från källpresentationen till samlingen av master‑bilder i
        // destinationspresentationen
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // Klona den önskade bilden från källpresentationen med den önskade master‑bilden till slutet av
        // samlingen av bilder i destinationspresentationen
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

## **Klon en bild i slutet av ett specificerat avsnitt**
Om du vill klona en bild och sedan använda den i samma presentationsfil men i ett annat avsnitt, använd då [**addClone**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-)‑metoden som exponeras av gränssnittet [**ISlideCollection**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides för Android via Java gör det möjligt att klona en bild från det första avsnittet och sedan infoga den klonade bilden i det andra avsnittet i samma presentation.

Följande kodsnutt visar hur du klonar en bild och infogar den klonade bilden i ett specificerat avsnitt.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// Spara destinationspresentationen till disk
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Säkerställ att bildstorleken matchar**

När du klonar bilder till en annan presentation, se till att mål‑presentationen har samma bildstorlek som källan. Om bildstorlekarna skiljer sig, skalar inte Aspose.Slides automatiskt de klonade formerna – deras ursprungliga koordinater och dimensioner bevaras, vilket kan leda till att innehållet blir feljusterat eller sträcker sig utanför bildens gränser.

Du kan sätta mål‑presentationens bildstorlek så att den matchar källans innan du klonar master‑ och bild‑objekten:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

Gör detta innan du klonar master‑ och bild‑objekten.

## **FAQ**

**Klonas talarnoter och granskningskommentarer?**

Ja. Notssidan och granskningskommentarerna inkluderas i klonen. Om du inte vill ha dem, [ta bort dem](/slides/sv/androidjava/presentation-notes/) efter infogning.

**Hur hanteras diagram och deras datakällor?**

Diagramobjektet, formateringen och inbäddade data kopieras. Om diagrammet var länkat till en extern källa (t.ex. en OLE‑inbäddad arbetsbok) bevaras den länken som ett [OLE‑objekt](/slides/sv/androidjava/manage-ole/). Efter flytt mellan filer, kontrollera datatillgänglighet och uppdateringsbeteende.

**Kan jag kontrollera infogningsposition och avsnitt för klonen?**

Ja. Du kan infoga klonen på ett specifikt bildindex och placera den i ett valt [avsnitt](/slides/sv/androidjava/slide-section/). Om mål‑avsnittet inte finns, skapa det först och flytta sedan bilden dit.