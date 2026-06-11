---
title: Hantera diagramdatamarkörer i presentationer med PHP
linktitle: Datamarkör
type: docs
url: /sv/php-java/chart-data-marker/
keywords:
- diagram
- datapunkt
- markör
- marköralternativ
- markörstorlek
- fyllningstyp
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du anpassar diagramdatamarkörer i Aspose.Slides för PHP, vilket förbättrar presentationens genomslag i PPT- och PPTX-format med tydliga kodexempel."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramdatamarkörer i Aspose.Slides. Den visar hur man skapar ett diagram, får åtkomst till en serie och dess datapunkter, applicerar bildfyllningar på markörer på datapunktsnivå, justerar markörstorlek och sparar den uppdaterade presentationen. Den nämner också att standardmarkörformer finns tillgängliga via uppräkningen `MarkerStyleType` och att markörens utseende bevaras när diagram exporteras till rasterformat eller SVG.

## **Ställ in diagrammarköralternativ**
Markörerna kan ställas in på diagramdatapunkter inom specifika serier. För att ställa in diagrammarköralternativ, följ stegen nedan:

- Instansiera klassen Presentation.
- Skapa standarddiagrammet.
- Ange bilden.
- Hämta den första diagramserien.
- Lägg till en ny datapunkt.
- Skriv presentationen till disk.

I exemplet nedan har vi ställt in diagrammarköralternativ på datapunktsnivå.

```php
  # Skapar tom presentation
  $pres = new Presentation();
  try {
    # Åtkomst till första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Skapar standarddiagrammet
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Hämtar standarddiagramdata arbetsbladets index
    $defaultWorksheetIndex = 0;
    # Hämtar diagramdata arbetsbladet
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Radera demo-serie
    $chart->getChartData()->getSeries()->clear();
    # Lägg till ny serie
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Ladda bild 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Ladda bild 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Hämta första diagramserien
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Lägg till ny punkt (1:3) där.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Ändra diagramseriens markör
    $series->getMarker()->setSize(15);
    # Spara presentation med diagram
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Vilka markörformer är tillgängliga från början?**

Standardformer är tillgängliga (cirkel, kvadrat, diamant, triangel osv.); listan definieras av klassen [MarkerStyleType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/markerstyletype/). Om du behöver en icke-standardform, använd en markör med bildfyllning för att efterlikna anpassade visuella element.

**Behålls markörer när ett diagram exporteras till en bild eller SVG?**

Ja. När diagram renderas till [rasterformat](/slides/sv/php-java/convert-powerpoint-to-png/) eller när [former sparas som SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/), behåller markörerna sitt utseende och sina inställningar, inklusive storlek, fyllning och kontur.