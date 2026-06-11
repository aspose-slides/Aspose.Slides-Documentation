---
title: Exportera presentationsdiagram i PHP
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/php-java/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagrambild
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för PHP via Java, stödjer PPT- och PPTX-format och förenklar rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Den här artikeln visar hur du får en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

## **Hämta en diagrambild**
Aspose.Slides för PHP via Java erbjuder stöd för att extrahera en bild av ett specifikt diagram. Nedanstående exempel ges.

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas till SVG med hjälp av [shape-to-SVG sparningsmetod](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/).

**Hur kan jag ange den exakta storleken på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑overloads som låter dig ange storlek eller skala – biblioteket stöder rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om typsnitt i etiketter och förklaringen ser felaktiga ut efter export?**

[Ladda de nödvändiga typsnitten](/slides/sv/php-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsloader/) så att diagramrenderingen bevarar mått och textutseende.

**Respekterar exporten PowerPoint‑temat, stilarna och effekterna?**

Ja. Aspose.Slides‑renderaren följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings‑/exportmöjligheter utöver diagrambilder?**

Se [API](https://reference.aspose.com/slides/sv/php-java/aspose.slides/)/[dokumentation](/slides/sv/php-java/convert-powerpoint/) för utdata mål ([PDF](/slides/sv/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/sv/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/php-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/php-java/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.