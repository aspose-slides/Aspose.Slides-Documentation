---
title: Exportera presentationsdiagram i Python via Java
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/python-java/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagrambild
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för Python via Java, med stöd för PPT- och PPTX-format, och förenklar rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Den här artikeln visar hur du får en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

Förutom det grundläggande arbetsflödet för bildexport behandlar artikeln även vanliga frågor relaterade till export, inklusive att spara diagraminnehåll till SVG, kontrollera utskriftsstorlek via renderingsalternativ, ladda teckensnitt för att bevara etikett- och legendutseende samt behålla den ursprungliga presentationsformateringen såsom teman, stilar, fyllningar och effekter under rendering.

## **Hämta en diagrambild**
Aspose.Slides för Python via Java stöder att extrahera en bild av ett specifikt diagram. Följande exempel visar hur man gör detta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **Vanliga frågor**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas till SVG med hjälp av [shape-to-SVG saving method](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#writeAsSvgToBytes).

**Hur kan jag ange den exakta storleken på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑överladdningarna som låter dig ange storlek eller skala – biblioteket stöder rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om typsnitten i etiketter och legenden ser felaktiga ut efter export?**

[Load the required fonts](/slides/sv/python-java/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/python-java/aspose.slides/fontsloader/) så att diagramrenderingen bevarar metrik och textutseende.

**Respekterar exporten PowerPoint‑temat, stilar och effekter?**

Ja. Aspose.Slides‑renderern följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings-/exportmöjligheter utöver diagrambilder?**

Se [API](https://reference.aspose.com/slides/sv/python-java/aspose.slides/)/[documentation](/slides/sv/python-java/convert-powerpoint/) för mål för utskrift ([PDF](/slides/sv/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/sv/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/python-java/convert-powerpoint-to-xps/), [HTML](/slides/sv/python-java/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.