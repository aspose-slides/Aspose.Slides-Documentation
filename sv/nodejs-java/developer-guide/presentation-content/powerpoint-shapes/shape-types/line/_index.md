---
title: Lägg till linjeformer i presentationer med JavaScript
linktitle: Linje
type: docs
weight: 50
url: /sv/nodejs-java/line/
keywords:
- linje
- skapa linje
- lägga till linje
- vanlig linje
- konfigurera linje
- anpassa linje
- streckstil
- pilspets
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: Lär dig att manipulera linjeformatering i PowerPoint-presentationer med JavaScript och Aspose.Slides för Node.js. Upptäck egenskaper, metoder och exempel.
---
## **Översikt**

Aspose.Slides gör att du kan lägga till linjeformer i PowerPoint‑bilder programvarumässigt. Den här artikeln visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du lär dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska formateringsinställningar för linjer såsom stil, bredd, streckmönster, pilspetsalternativ och fyllningsfärg.

## **Skapa enkel linje**

För att lägga till en enkel linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess index.
- Lägg till en AutoShape av typ Line med metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```javascript
// Instansiera PresentationEx-klassen som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av typen linje
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Spara PPTX-filen till disk
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Skapa pilformad linje**

Aspose.Slides for Node.js via Java låter också utvecklare konfigurera vissa egenskaper för linjen så att den blir mer attraktiv. Låt oss konfigurera några egenskaper för att få linjen att se ut som en pil. Följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess index.
- Lägg till en AutoShape av typ Line med metoden [addAutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).
- Ställ in [Line Style](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LineStyle) till en av de stilar som erbjuds av Aspose.Slides for Node.js via Java.
- Ställ in bredden på linjen.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LineDashStyle) för linjen till en av de stilar som erbjuds av Aspose.Slides for Node.js via Java.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LineArrowheadLength) för startpunkten på linjen.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/LineArrowheadLength) för slutpunkten på linjen.
- Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
// Instansiera PresentationEx-klassen som representerar PPTX-filen
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av typen linje
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Applicera viss formatering på linjen
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Spara PPTX-filen till disk
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kan jag konvertera en vanlig linje till en anslutare så att den "snäpper" till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) av typen [Line](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapetype/)) blir inte automatiskt en anslutare. För att få den att snäppa till former, använd den dedikerade [Connector](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/connector/)‑typen och de [corresponding APIs](/slides/sv/nodejs-java/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper ärvs från temat och det är svårt att avgöra de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/nodejs-java/shape-effective-properties/) via klasserna `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Former tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/getautoshapelock/) som låter dig förbjuda redigeringsåtgärder.