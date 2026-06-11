---
title: Exportera presentationsdiagram med Python
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/python-net/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagrambild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du exporterar diagram i presentationer med Aspose.Slides för Python via .NET, med stöd för PPT-, PPTX- och ODP-format, och effektivisera rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Den här artikeln visar hur du får en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

## **Hämta diagrambild**
Aspose.Slides för Python via .NET ger stöd för att extrahera en bild av ett specifikt diagram. Nedanstående exempel ges.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **Vanliga frågor**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas som SVG med hjälp av [shape-to-SVG sparningsmetod](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/write_as_svg/).

**Hur kan jag ange den exakta storleken på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑överladdningarna som låter dig ange storlek eller skala – biblioteket stödjer rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om teckensnitt i etiketter och förklaringen ser felaktiga ut efter export?**

[Ladda de nödvändiga teckensnitten](/slides/sv/python-net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsloader/) så att diagramrenderingen bevarar metriker och textutseende.

**Respekterar exporten PowerPoint‑temat, stilarna och effekterna?**

Ja. Aspose.Slides‑renderaren följer presentationens formatering (tema, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings-/exportfunktioner bortom diagrambilder?**

Se exportsektionen i [API](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/)/[dokumentation](/slides/sv/python-net/convert-powerpoint/) för målformat ([PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/sv/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/python-net/convert-powerpoint-to-xps/), [HTML](/slides/sv/python-net/convert-powerpoint-to-html/), osv.) och relaterade renderingsalternativ.