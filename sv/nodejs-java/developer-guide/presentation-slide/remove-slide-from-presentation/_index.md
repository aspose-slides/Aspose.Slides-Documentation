---
title: Ta bort bilder från presentationer i JavaScript
linktitle: Ta bort bild
type: docs
weight: 30
url: /sv/nodejs-java/remove-slide-from-presentation/
keywords:
- ta bort bild
- radera bild
- ta bort oanvänd bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ta enkelt bort bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js. Få tydliga kodexempel och förbättra ditt arbetsflöde."
---
## **Introduktion**

Om en bild (eller dess innehåll) blir överflödig kan du ta bort den. Aspose.Slides tillhandahåller klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) som kapslar in [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/), vilket är ett förråd för alla bilder i en presentation. Genom att använda pekare (referens eller index) för ett känt [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/)‑objekt kan du ange vilken bild du vill ta bort.

## **Ta bort bild med referens**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till den bild du vill ta bort via dess ID eller index.
1. Ta bort den refererade bilden från presentationen.
1. Spara den ändrade presentationen. 

Denna JavaScript‑kod visar hur du tar bort en bild via dess referens:

```javascript
// Instansiera ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Åtkomst till en bild via dess index i bildsamlingen
    var slide = pres.getSlides().get_Item(0);
    // Tar bort en bild via dess referens
    pres.getSlides().remove(slide);
    // Sparar den ändrade presentationen
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ta bort bild med index**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Ta bort bilden från presentationen via dess indexposition.
1. Spara den ändrade presentationen. 

Denna JavaScript‑kod visar hur du tar bort en bild via dess index:

```javascript
// Instansierar ett Presentation-objekt som representerar en presentationsfil
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Tar bort en bild via dess bildindex
    pres.getSlides().removeAt(0);
    // Sparar den ändrade presentationen
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ta bort oanvänd layout‑bild**

Aspose.Slides tillhandahåller metoden [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (från klassen [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/)) som låter dig ta bort oönskade och oanvända layoutbilder. Denna JavaScript‑kod visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort oanvänd master‑bild**

Aspose.Slides tillhandahåller metoden [removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (från klassen [Compress](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/compress/)) som låter dig ta bort oönskade och oanvända masterbilder. Denna JavaScript‑kod visar hur du tar bort en masterbild från en PowerPoint‑presentation:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Vad händer med bildindex efter att jag har raderat en bild?**

Efter raderingen omindexeras [collection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/): varje efterföljande bild flyttas ett steg åt vänster, så tidigare indexnummer blir föråldrade. Om du behöver en stabil referens, använd varje bilds beständiga ID istället för dess index.

**Är en bilds ID annorlunda än dess index, och förändras det när angränsande bilder raderas?**

Ja. Indexet är bildens position och kommer att ändras när bilder läggs till eller tas bort. Bildens ID är en beständig identifierare och förändras inte när andra bilder raderas.

**Hur påverkar radering av en bild bildavsnitt?**

Om bilden tillhörde ett avsnitt kommer det avsnittet helt enkelt att ha en bild mindre. Avsnittets struktur förblir; om ett avsnitt blir tomt kan du [remove or reorganize sections](/slides/sv/nodejs-java/slide-section/) efter behov.

**Vad händer med anteckningar och kommentarer som är kopplade till en bild när den raderas?**

[Notes](/slides/sv/nodejs-java/presentation-notes/) och [comments](/slides/sv/nodejs-java/presentation-comments/) är knutna till den specifika bilden och tas bort tillsammans med den. Innehåll på andra bilder påverkas inte.

**Hur skiljer sig radering av bilder från att rensa upp oanvända layouter/masterbilder?**

Att radera tar bort specifika vanliga bilder från presentationen. Att rensa upp oanvända layouter/masterbilder tar bort layout‑ eller masterbilder som ingen refererar till, vilket minskar filens storlek utan att ändra återstående bildinnehåll. Dessa åtgärder kompletterar varandra: vanligtvis raderas först, sedan städas upp.