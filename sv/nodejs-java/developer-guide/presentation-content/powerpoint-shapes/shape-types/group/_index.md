---
title: Gruppformer i PowerPoint med JavaScript
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/nodejs-java/group/
keywords:
- gruppform
- formgrupp
- lägg till grupp
- alternativ text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig att gruppera och avgruppera former i PowerPoint-presentationer med Aspose.Slides för Node.js via Java — snabb steg‑för‑steg‑guide med gratis JavaScript‑kod."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med gruppformer i Aspose.Slides. Den visar hur man lägger till en gruppform på en bild, placerar former i den och sparar den uppdaterade presentationen. Den demonstrerar också hur man får åtkomst till former som lagras i en grupp och läser deras `AlternativeText`-värden. Dessutom täcker artikeln kort relaterade funktioner för gruppformer såsom nästlade grupper, Z‑ordning och låsalternativ.

## **Lägg till gruppform**
Aspose.Slides stöder arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides för Node.js via Java stöder att lägga till eller komma åt gruppformer. Det är möjligt att lägga till former i en tillagd gruppform för att fylla den eller komma åt någon egenskap hos gruppformen. Så här lägger du till en gruppform på en bild med Aspose.Slides för Node.js via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
1. Hämta referensen till en bild genom att använda dess Index.
1. Lägg till en gruppform på bilden.
1. Lägg till formerna i den tillagda gruppformen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```javascript
// Instansiera Presentation-klass
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Hämtar formsamlingen för bilderna
    var slideShapes = sld.getShapes();
    // Lägger till en gruppform på bilden
    var groupShape = slideShapes.addGroupShape();
    // Lägger till former i den tillagda gruppformen
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Lägger till ram för gruppformen
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Skriver PPTX-filen till disk
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kom åt AltText‑egenskap**
Detta avsnitt visar enkla steg, komplett med kodexempel, för att lägga till en gruppform och komma åt AltText‑egenskapen för gruppformer på bilder. Så här får du åtkomst till AltText för en gruppform på en bild med Aspose.Slides för Node.js via Java:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) som representerar en PPTX‑fil.
1. Hämta referensen till en bild genom att använda dess Index.
1. Kom åt samlingen av former på bilderna.
1. Kom åt gruppformen.
1. Anropa egenskapen [getAlternativeText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getAlternativeText--).

Exemplet nedan får åtkomst till alternativ text för gruppformen.

```javascript
// Instansiera Presentation-klass som representerar PPTX-fil
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Hämtar formsamlingen för bilderna
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Hämtar gruppformen.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Hämtar AltText-egenskapen
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Stöds nästlad gruppering (en grupp inom en grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/) har en [getParentGroup](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getparentgroup/)‑metod, vilket tydligt visar stöd för hierarki (en grupp kan vara ett barn till en annan grupp).

**Hur kontrollerar jag gruppens Z‑ordning i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/)‑metoden [getZOrderPosition](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getzorderposition/) för att inspektera dess position i visningsstacken.

**Kan jag förhindra att gruppen flyttas/redigeras/avgrupperas?**

Ja. Gruppens låsavsnitt exponeras via [GroupShapeLock](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), vilket låter dig begränsa operationer på objektet.