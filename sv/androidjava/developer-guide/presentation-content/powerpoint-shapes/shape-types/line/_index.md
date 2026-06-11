---
title: Lägg till linjeformer i presentationer på Android
linktitle: Linje
type: docs
weight: 50
url: /sv/androidjava/Line/
keywords:
- linje
- skapa linje
- lägga till linje
- enkel linje
- konfigurera linje
- anpassa linje
- streckstil
- pilspets
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig manipulera linjeformatering i PowerPoint-presentationer med Aspose.Slides för Android. Upptäck egenskaper, metoder och Java-exempel."
---
## **Översikt**

Aspose.Slides gör det möjligt att lägga till linjeformer i PowerPoint‑bilder programatiskt. Denna artikel visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska formateringsinställningar för linjer såsom stil, bredd, streckmönster, pilspetsalternativ och fyllningsfärg.

## **Skapa en enkel linje**

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Line med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

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

Aspose.Slides för Android via Java låter också utvecklare konfigurera vissa egenskaper hos linjen för att göra den mer attraktiv. Låt oss försöka konfigurera några egenskaper på en linje så att den ser ut som en pil. Följ stegen nedan för att göra detta:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Line med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) som exponeras av objektet [IShapeCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection).
- Ställ in [Line Style](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LineStyle) till någon av de stilar som erbjuds av Aspose.Slides för Android via Java.
- Ställ in linjens bredd.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LineDashStyle) för linjen till någon av de stilar som erbjuds av Aspose.Slides för Android via Java.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LineArrowheadLength) för linjens startpunkt.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/LineArrowheadLength) för linjens slutpunkt.
- Skriv den modifierade presentationen som en PPTX‑fil.

```java
// Instansiera PresentationEx-klassen som representerar PPTX-filen
Presentation pres = new Presentation();
try {
    // Hämta den första bilden
    ISlide sld = pres.getSlides().get_Item(0);

    // Lägg till en AutoShape av typen linje
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Applicera viss formatering på linjen
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

**Kan jag konvertera en vanlig linje till en anslutning så att den "fäster" vid former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/) av typen [Line](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapetype/)) blir inte automatiskt en connector. För att få den att fästa vid former, använd den speciella [Connector](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/connector/)‑typen och de [corresponding APIs](/slides/sv/androidjava/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper ärvs från temat och det är svårt att fastställa de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/androidjava/shape-effective-properties/) via gränssnitten [ILineFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Former tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) som låter dig förbjuda redigeringsåtgärder.