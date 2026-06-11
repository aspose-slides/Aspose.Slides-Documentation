---
title: Exportera presentationsdiagram i JavaScript
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/nodejs-java/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagram som bild
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för Node.js via Java, stöder PPT- och PPTX-format och förenklar rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides gör det möjligt att exportera ett diagram från en presentation som en bild. Denna artikel visar hur du får en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

## **Hämta diagrambild**
Aspose.Slides för Node.js via Java erbjuder stöd för att extrahera bild av ett specifikt diagram. Nedan ges ett exempel.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vanliga frågor**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas som SVG med hjälp av [metoden för att spara shape till SVG](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/writeassvg/).

**Hur kan jag ange exakt storlek på det exporterade diagrammet i pixlar?**

Använd image-rendering‑överladdningarna som låter dig ange storlek eller skala – biblioteket stöder rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om teckensnitt i etiketter och förklaringen ser felaktiga ut efter export?**

[Läs in de erforderliga teckensnitten](/slides/sv/nodejs-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsloader/) så att diagramrenderingen bevarar mått och textutseende.

**Respekterar exporten PowerPoint‑temat, stilarna och effekterna?**

Ja. Aspose.Slides‑renderaren följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings-/exportmöjligheter utöver diagrambilder?**

Se [API](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/)/[dokumentation](/slides/sv/nodejs-java/convert-powerpoint/) för utdata mål ([PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/sv/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.