---
title: Ta bort bilder från presentationer på Android
linktitle: Ta bort bild
type: docs
weight: 30
url: /sv/androidjava/remove-slide-from-presentation/
keywords:
- ta bort bild
- radera bild
- ta bort oanvänd bild
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Ta enkelt bort bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android. Få tydliga Java-kodexempel och förbättra ditt arbetsflöde."
---
## **Introduktion**

Om en bild (eller dess innehåll) blir överflödig kan du ta bort den. Aspose.Slides tillhandahåller klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) som kapslar in [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/), vilket är ett arkiv för alla bilder i en presentation. Genom att använda pekare (referens eller index) för ett känt [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/)‑objekt kan du ange vilken bild du vill ta bort.

## **Ta bort en bild med referens**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Hämta en referens till bilden du vill ta bort via dess ID eller index.
1. Ta bort den refererade bilden från presentationen.
1. Spara den modifierade presentationen. 

Denna Java‑kod visar hur du tar bort en bild via dess referens:

```java
// Instansiera ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("demo.pptx");
try {
    // Hämtar en bild via dess index i bildsamlingen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tar bort en bild via dess referens
    pres.getSlides().remove(slide);
    
    // Sparar den ändrade presentationen
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ta bort en bild med index**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
1. Ta bort bilden från presentationen via dess indexposition.
1. Spara den modifierade presentationen. 

Denna Java‑kod visar hur du tar bort en bild via dess index:

```java
// Instansierar ett Presentation-objekt som representerar en presentationsfil
Presentation pres = new Presentation("demo.pptx");
try {
    // Tar bort en bild via dess bildindex
    pres.getSlides().removeAt(0);
    
    // Sparar den ändrade presentationen
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (från klassen [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/)) för att du ska kunna ta bort oönskade och oanvända layoutbilder. Denna Java‑kod visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ta bort oanvända masterbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (från klassen [Compress](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/compress/)) för att du ska kunna ta bort oönskade och oanvända masterbilder. Denna Java‑kod visar hur du tar bort en masterbild från en PowerPoint‑presentation:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **Vanliga frågor**

**Vad händer med bildindexen efter att jag raderat en bild?**

Efter raderingen omindexeras [collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidecollection/): varje efterföljande bild flyttas ett steg åt vänster, så tidigare indexnummer blir föråldrade. Om du behöver en stabil referens, använd varje bilds beständiga ID istället för dess index.

**Är en bilds ID annorlunda än dess index, och förändras det när närliggande bilder tas bort?**

Ja. Indexet är bildens position och ändras när bilder läggs till eller tas bort. Bildens ID är en beständig identifierare och ändras inte när andra bilder raderas.

**Hur påverkar det att radera en bild bildsektionerna?**

Om bilden tillhörde en sektion kommer den sektionen bara att ha en bild mindre. Sektionens struktur förblir; om en sektion blir tom kan du [remove or reorganize sections](/slides/sv/androidjava/slide-section/) vid behov.

**Vad händer med anteckningar och kommentarer som är knutna till en bild när den raderas?**

[Notes](/slides/sv/androidjava/presentation-notes/) och [comments](/slides/sv/androidjava/presentation-comments/) är knutna till den specifika bilden och tas bort tillsammans med den. Innehåll på andra bilder påverkas inte.

**Hur skiljer sig radering av bilder från att rensa oanvända layouter/masterbilder?**

Radering tar bort specifika vanliga bilder från presentationen. Rensning av oanvända layouter/masterbilder tar bort layout‑ eller masterbilder som inget refererar till, vilket minskar filstorleken utan att förändra resterande bildinnehåll. Dessa åtgärder är komplementära: vanligtvis raderas först, sedan rensas.