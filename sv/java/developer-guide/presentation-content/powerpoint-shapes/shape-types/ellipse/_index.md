---
title: Lägg till ellipser i presentationer i Java
linktitle: Ellips
type: docs
weight: 30
url: /sv/java/ellipse/
keywords:
- ellips
- form
- lägg till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för Java i både PPT- och PPTX-presentationer – Java-kodexempel ingår."
---
## **Översikt**

Denna artikel visar hur man lägger till ellipser i PowerPoint‑bilder med hjälp av Aspose.Slides. Den täcker att skapa en enkel ellips, skapa en formaterad ellips och spara den uppdaterade presentationen som en PPTX‑fil. Den berör också relaterade frågor såsom att arbeta med ellipsens position och storlek, kontrollera staplingsordning och tillämpa animationseffekter.

## **Skapa en ellips**
För att lägga till en enkel ellips på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Ellipse med metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection)‑objektet.
- Skriv den ändrade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en ellips på den första bilden

```java
// Instansiera Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Lägg till AutoShape av ellipstyp
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Skriv PPTX-filen till disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skapa en formaterad ellips**
För att lägga till en bättre formaterad ellips på en bild, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Ellipse med metoden [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection)‑objektet.
- Ställ in fyllningstypen för ellipsen till Solid.
- Ställ in färgen på ellipsen med egenskapen SolidFillColor.Color som exponeras av [FillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IFillFormat)‑objektet som är associerat med [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShape)‑objektet.
- Ställ in färgen på ellipsens linjer.
- Ställ in bredden på ellipsens linjer.
- Skriv den ändrade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en formaterad ellips på den första bilden i presentationen.

```java
// Instansiera Presentation-klassen som representerar PPTX
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till AutoShape av ellipstyp
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Applicera viss formatering på ellipsformen
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Applicera viss formatering på ellipsens linje
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Skriv PPTX-filen till disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Hur ställer jag in exakt position och storlek på en ellips i förhållande till bildens enheter?**

Koordinater och storlekar anges vanligtvis **i punkter**. För förutsägbara resultat bör du basera dina beräkningar på bildens storlek och konvertera erforderliga millimeter eller tum till punkter innan du tilldelar värden.

**Hur kan jag placera en ellips ovanför eller under andra objekt (styra staplingsordning)?**

Justera ritordningen för objektet genom att flytta det framåt eller skicka det bakåt. Detta låter ellipsen överlappa andra objekt eller avslöja de som ligger under den.

**Hur animerar jag en ellipss framträdande eller betoning?**

[Apply](/slides/sv/java/shape-animation/) inträdes‑, betoning‑ eller avslutningseffekter på formen, och konfigurera triggrar och tidsinställningar för att orkestrera när och hur animationen spelas upp.