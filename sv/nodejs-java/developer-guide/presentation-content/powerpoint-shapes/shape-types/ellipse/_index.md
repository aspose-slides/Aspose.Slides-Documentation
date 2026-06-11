---
title: Lägg till ellipser i presentationer i JavaScript
linktitle: Ellips
type: docs
weight: 30
url: /sv/nodejs-java/ellipse/
keywords:
- ellips
- form
- lägg till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för Node.js i PPT- och PPTX-presentationer – JavaScript-kodexempel inkluderade."
---
## **Översikt**

Denna artikel visar hur du lägger till ellipsformer i PowerPoint-bilder med hjälp av Aspose.Slides. Den beskriver hur man skapar en enkel ellips, en formaterad ellips och sparar den uppdaterade presentationen som en PPTX-fil. Den berör även relaterade frågor såsom att arbeta med ellipsens position och storlek, styra staplingsordning och applicera animationseffekter.

## **Skapa ellips**
För att lägga till en enkel ellips på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Ellipse med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).
- Skriv den modifierade presentationen som en PPTX-fil.

I exemplet nedan har vi lagt till en ellips på den första bilden

```javascript
// Skapa en Presentation-klass som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av ellipstyp
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Skriv PPTX-filen till disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Skapa formaterad ellips**
För att lägga till en bättre formaterad ellips på en bild, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Ellipse med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).
- Ställ in fyllningstypen för ellipsen till Solid.
- Ställ in färgen på ellipsen med egenskapen SolidFillColor.Color som exponeras av objektet [FillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FillFormat) som är associerat med objektet [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape).
- Ställ in färgen på ellipsens linjer.
- Ställ in bredden på ellipsens linjer.
- Skriv den modifierade presentationen som en PPTX-fil.

I exemplet nedan har vi lagt till en formaterad ellips på den första bilden i presentationen.

```javascript
// Skapa ett Presentation-objekt som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av ellipstyp
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Applicera lite formatering på ellipsformen
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Applicera lite formatering på ellipsens linje
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Skriv PPTX-filen till disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **Vanliga frågor**

**Hur ställer jag in exakt position och storlek för en ellips i förhållande till bildens enheter?**

Koordinater och storlekar specificeras vanligtvis **i punkter**. För förutsägbara resultat bör du basera dina beräkningar på bildens storlek och konvertera nödvändiga millimeter eller tum till punkter innan du tilldelar värden.

**Hur kan jag placera en ellips ovanför eller under andra objekt (styra staplingsordning)?**

Justera ritordningen för objektet genom att föra det framåt eller skicka det bakåt. Detta gör att ellipsen kan överlappa andra objekt eller avslöja dem som ligger däunder.

**Hur animerar jag framträdandet eller betoningen av en ellips?**

[Apply](/slides/sv/nodejs-java/shape-animation/) ingångs-, betoning- eller avslutningseffekter på formen, och konfigurera triggers och tidpunkter för att samordna när och hur animationen spelas.