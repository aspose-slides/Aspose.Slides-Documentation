---
title: Exportera presentationsdiagram i C++
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/cpp/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagrambild
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för C++, stödjer PPT- och PPTX-format och förenklar rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Den här artikeln visar hur du hämtar en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

## **Hämta en diagrambild**
Aspose.Slides för C++ erbjuder stöd för att extrahera en bild av ett specifikt diagram. Nedanstående exempel ges. 

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas till SVG med hjälp av [shape-to-SVG sparningsmetoden](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/).

**Hur kan jag ange den exakta storleken på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑överladdningarna som låter dig ange storlek eller skala – biblioteket stödjer rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om teckensnitten i etiketter och förklaringen ser felaktiga ut efter export?**

[Läs in de nödvändiga teckensnitten](/slides/sv/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsloader/) så att diagramrenderingen bevarar metriks och textutseende.

**Respekterar exporten PowerPoint-temat, stilarna och effekterna?**

Ja. Aspose.Slides‑renderaren följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings-/exportfunktioner utöver diagrambilder?**

Se exportsektionen i [API](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/)/[dokumentation](/slides/sv/cpp/convert-powerpoint/) för utdata‑mål ([PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/sv/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/cpp/convert-powerpoint-to-xps/), [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.