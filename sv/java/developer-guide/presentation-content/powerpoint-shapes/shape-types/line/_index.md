---
title: Lägg till linjeformer i presentationer i Java
linktitle: Linje
type: docs
weight: 50
url: /sv/java/line/
keywords:
- linje
- skapa linje
- lägg till linje
- vanlig linje
- konfigurera linje
- anpassa linje
- streckstil
- pilhuvud
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig manipulera linjeformatering i PowerPoint-presentationer med Aspose.Slides för Java. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides låter dig lägga till linjeformer i PowerPoint‑bilder programatiskt. Den här artikeln visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska formateringsinställningar för linjer såsom stil, bredd, streckmönster, pilarhuvudsalternativ och fyllningsfärg.

## **Skapa en enkel linje**

För att lägga till en enkel linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Linje med hjälp av [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑metoden som exponeras av [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection)‑objektet.
- Spara den modifierade presentationen som en PPTX‑fil.

I exemplen nedan har vi lagt till en linje på den första bilden i presentationen.

```java
// Instansiera PresentationEx-klassen som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Lägg till en AutoShape av typen linje
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Skriv PPTX-filen till disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skapa en pilformad linje**

Aspose.Slides för Java låter också utvecklare konfigurera vissa egenskaper för linjen så att den ser mer attraktiv ut. Låt oss prova att konfigurera några egenskaper för en linje så att den ser ut som en pil. Följ stegen nedan för att göra detta:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation)‑klassen.
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Linje med hjälp av [addAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-)‑metoden som exponeras av [IShapeCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection)‑objektet.
- Ställ in [Line Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineStyle) till en av de stilar som erbjuds av Aspose.Slides för Java.
- Ställ in linjens bredd.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineDashStyle) för linjen till en av de stilar som erbjuds av Aspose.Slides för Java.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadLength) för startpunkten på linjen.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/java/com.aspose.slides/LineArrowheadLength) för slutpunkten på linjen.
- Spara den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera PresentationEx-klassen som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen linje
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Tillämpa viss formatering på linjen
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Skriv PPTX-filen till disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag konvertera en vanlig linje till en anslutning så att den "snäpper" till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/) av typen [Line](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapetype/)) blir inte automatiskt en connector. För att låta den snäppa till former, använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/java/com.aspose.slides/connector/)‑typen och de [corresponding APIs](/slides/sv/java/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper är ärvda från temat och det är svårt att bestämma de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/java/shape-effective-properties/) via ILineFormatEffectiveData/ILineFillFormatEffectiveData‑gränssnitten—dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Former tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/java/com.aspose.slides/autoshape/#getAutoShapeLock--) som låter dig [disallow editing operations](/slides/sv/java/applying-protection-to-presentation/).