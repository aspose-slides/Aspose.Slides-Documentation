---
title: Exportera presentationsdiagram på Android
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/androidjava/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagrambild
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för Android via Java, med stöd för PPT- och PPTX-format, och effektiviserar rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Denna artikel visar hur du hämtar en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramgrafik utanför en PowerPoint-presentation.

Förutom det grundläggande arbetsflödet för bildexport behandlar artikeln även vanliga frågor relaterade till export, inklusive att spara diagraminnehåll som SVG, kontroll av utdata storlek via renderingsalternativ, inläsning av teckensnitt för att bevara etikett- och förklaringsrutautseende, samt att behålla den ursprungliga presentationens formatering såsom teman, stilar, fyllningar och effekter under rendering.

## **Hämta en diagrambild**
Aspose.Slides för Android via Java ger stöd för att extrahera en bild av ett specifikt diagram. Nedan följer ett exempel.

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

Ja. Ett diagram är en form, och dess innehåll kan sparas som SVG med hjälp av [metoden för att spara shape som SVG](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Hur kan jag ange den exakta storleken på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑överladdningarna som låter dig ange storlek eller skala – biblioteket stöder rendering av objekt med angivna dimensioner/skala.

**Vad bör jag göra om teckensnitt i etiketter och förklaringsrutan ser felaktiga ut efter export?**

[Läs in de nödvändiga teckensnitten](/slides/sv/androidjava/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsloader/) så att diagramrenderingen bevarar mått och textutseende.

**Respekterar exporten PowerPoint‑temat, stilar och effekter?**

Ja. Aspose.Slides‑renderaren följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings‑/exportmöjligheter utanför diagrambilder?**

Se [API](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/)/[dokumentation](/slides/sv/androidjava/convert-powerpoint/) för utdata‑mål ([PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.