---
title: Lägg till linjeformer i presentationer i PHP
linktitle: Linje
type: docs
weight: 50
url: /sv/php-java/line/
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
- PHP
- Aspose.Slides
description: "Lär dig att manipulera linjeformat i PowerPoint-presentationer med Aspose.Slides för PHP via Java. Upptäck egenskaper, metoder och exempel."
---
## **Översikt**

Aspose.Slides gör det möjligt att lägga till linjeformer i PowerPoint‑bilder programmässigt. Den här artikeln visar hur du skapar en enkel linje och hur du anpassar en linje så att den visas som en pil.

Du kommer att lära dig hur du lägger till en linjeform på en bild, justerar dess visuella utseende och sparar den uppdaterade presentationen. Exemplen fokuserar på praktiska inställningar för linjeformat som stil, bredd, streckmönster, pilspetsalternativ och fyllningsfärg.

## **Skapa en enkel linje**

För att lägga till en enkel rak linje på en vald bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Line med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en linje på den första bilden i presentationen.

```php
  # Instansiera PresentationEx-klass som representerar PPTX-filen
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till en AutoShape av typen linje
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Skriv PPTX till disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Skapa en pilformad linje**

Aspose.Slides för PHP via Java låter också utvecklare konfigurera vissa egenskaper för linjen så att den ser mer attraktiv ut. Låt oss försöka konfigurera några egenskaper för en linje så att den ser ut som en pil. Följ stegen nedan för att göra detta:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typ Line med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).
- Ställ in [Line Style](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LineStyle) till en av de stilar som erbjuds av Aspose.Slides för PHP via Java.
- Ställ in linjens bredd.
- Ställ in [Dash Style](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LineDashStyle) för linjen till en av de stilar som erbjuds av Aspose.Slides för PHP via Java.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LineArrowheadLength) för startpunkten på linjen.
- Ställ in [Arrow Head Style](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LineArrowheadStyle) och [Length](https://reference.aspose.com/slides/sv/php-java/aspose.slides/LineArrowheadLength) för slutpunkten på linjen.
- Skriv den modifierade presentationen som en PPTX‑fil.

```php
  # Instansiera PresentationEx-klass som representerar PPTX-filen
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till en AutoShape av typen linje
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Tillämpa viss formatering på linjen
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Skriv PPTX till disk
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Kan jag konvertera en vanlig linje till en anslutning så att den "snäpper" till former?**

Nej. En vanlig linje (en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) av typ [Line](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapetype/)) blir inte automatiskt en connector. För att få den att snäppa till former, använd den dedikerade typen [Connector](https://reference.aspose.com/slides/sv/php-java/aspose.slides/connector/) och de [corresponding APIs](/slides/sv/php-java/connector/) för anslutningar.

**Vad ska jag göra om en linjes egenskaper är ärvda från temat och det är svårt att fastställa de slutgiltiga värdena?**

[Läs de effektiva egenskaperna](/slides/sv/php-java/shape-effective-properties/) via `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—dessa tar redan hänsyn till arv och temastilar.

**Kan jag låsa en linje mot redigering (flytt, storleksändring)?**

Ja. Former tillhandahåller [lock objects](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/getautoshapelock/) som låter dig förbjuda redigeringsoperationer.