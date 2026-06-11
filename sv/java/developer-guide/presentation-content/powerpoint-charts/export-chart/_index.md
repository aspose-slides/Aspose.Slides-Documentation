---
title: Exportera presentationsdiagram i Java
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/java/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagram bild
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för Java, stöder PPT- och PPTX-format, och effektiviserar rapportering i vilket arbetsflöde som helst."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Den här artikeln visar hur du får en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

Förutom det grundläggande arbetsflödet för bildexport behandlar artikeln också vanliga frågor relaterade till export, inklusive att spara diagraminnehåll till SVG, styra utdata storlek via renderingsalternativ, ladda teckensnitt för att bevara etikett- och legendutseende, samt behålla presentationens ursprungliga formatering såsom teman, stilar, fyllningar och effekter under rendering.

## **Hämta en diagrambild**
Aspose.Slides för Java erbjuder stöd för att extrahera en bild av ett specifikt diagram. Nedanstående exempel ges.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas till SVG med hjälp av [shape-to-SVG sparningsmetod](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Hur kan jag ange exakt storlek på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑overloads som låter dig ange storlek eller skala – biblioteket stöder rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om teckensnitten i etiketter och legenden ser felaktiga ut efter export?**

[Ladda de erforderliga teckensnitten](/slides/sv/java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsloader/) så att diagramrenderingen bevarar mått och textutseende.

**Respekterar exporten PowerPoint‑tema, stilar och effekter?**

Ja. Aspose.Slides‑renderaren följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings‑/exportfunktioner utöver diagrambilder?**

Se [API](https://reference.aspose.com/slides/sv/java/com.aspose.slides/)/[dokumentation](/slides/sv/java/convert-powerpoint/) för utdata‑mål ([PDF](/slides/sv/java/convert-powerpoint-to-pdf/), [SVG](/slides/sv/java/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/java/convert-powerpoint-to-xps/), [HTML](/slides/sv/java/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.