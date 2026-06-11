---
title: Exportera presentationsdiagram i .NET
linktitle: Exportera diagram
type: docs
weight: 90
url: /sv/net/export-chart/
keywords:
- diagram
- diagram till bild
- diagram som bild
- extrahera diagrambild
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du exporterar presentationsdiagram med Aspose.Slides för .NET, stödjer PPT- och PPTX-format och förenklar rapportering i alla arbetsflöden."
---
## **Översikt**

Aspose.Slides låter dig exportera ett diagram från en presentation som en bild. Denna artikel visar hur du får en bild från ett diagram och sparar den, vilket är användbart när du behöver återanvända diagramvisualiseringar utanför en PowerPoint-presentation.

Förutom det grundläggande arbetsflödet för bildexport behandlar artikeln även vanliga exportrelaterade frågor, inklusive att spara diagraminnehåll som SVG, styra utmatningsstorlek via renderingsalternativ, ladda teckensnitt för att bevara etikett- och legendutseende, samt behålla presentationens ursprungliga formatering såsom teman, stilar, fyllningar och effekter under rendering.

## **Hämta en diagrambild**
Aspose.Slides för .NET erbjuder stöd för att extrahera en bild av ett specifikt diagram. Nedanstående exempel visas.

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```

## **FAQ**

**Kan jag exportera ett diagram som en vektor (SVG) istället för en rasterbild?**

Ja. Ett diagram är en form, och dess innehåll kan sparas som SVG med hjälp av [shape-to-SVG sparmetoden](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/).

**Hur kan jag ange exakt storlek på det exporterade diagrammet i pixlar?**

Använd bildrenderings‑överladdningarna som låter dig ange storlek eller skala – biblioteket stödjer rendering av objekt med angivna dimensioner/skala.

**Vad ska jag göra om teckensnitt i etiketter och legend ser felaktiga ut efter export?**

[Ladda de erforderliga teckensnitten](/slides/sv/net/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsloader/) så att diagramrenderingen bevarar mått och textutseende.

**Respekterar exporten PowerPoint‑temat, stilar och effekter?**

Ja. Aspose.Slides renderare följer presentationens formatering (teman, stilar, fyllningar, effekter), så diagrammets utseende bevaras.

**Var kan jag hitta tillgängliga renderings-/exportmöjligheter utöver diagrambilder?**

Se exportsektionen i [API](https://reference.aspose.com/slides/sv/net/aspose.slides.export/)/[dokumentationen](/slides/sv/net/convert-powerpoint/) för utmatningsmål ([PDF](/slides/sv/net/convert-powerpoint-to-pdf/), [SVG](/slides/sv/net/render-a-slide-as-an-svg-image/), [XPS](/slides/sv/net/convert-powerpoint-to-xps/), [HTML](/slides/sv/net/convert-powerpoint-to-html/), etc.) och relaterade renderingsalternativ.