---
title: Anpassa 3D-diagram i presentationer med C++
linktitle: 3D-diagram
type: docs
url: /sv/cpp/3d-chart/
keywords:
- 3D-diagram
- rotation
- djup
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du skapar och anpassar 3-D-diagram i Aspose.Slides för C++, med stöd för PPT- och PPTX-filer – förbättra dina presentationer idag."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar ett 3D-diagram i Aspose.Slides genom att konfigurera `Rotation3D`‑inställningar såsom `RotationX`, `RotationY`, `DepthPercents` och `RightAngleAxes`. Den går igenom hur du skapar en presentation, lägger till ett 3D-diagram med standarddata, tillämpar de erforderliga 3D‑visningsinställningarna och sparar den modifierade presentationen som en PPTX‑fil.

## **Ställ in egenskaperna RotationX, RotationY och DepthPercents för ett 3D-diagram**
Aspose.Slides för C++ tillhandahåller ett enkelt API för att ange dessa egenskaper. Följande artikel hjälper dig att sätta olika egenskaper som X‑, Y‑rotation, **DepthPercents** osv. Exempelkoden visar hur de ovannämnda egenskaperna sätts.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Kom åt den första bilden.
3. Lägg till ett diagram med standarddata.
4. Ställ in Rotation3D‑egenskaper.
5. Skriv den modifierade presentationen till en PPTX‑fil.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Vilka diagramtyper stödjer 3D‑läge i Aspose.Slides?**

Aspose.Slides stödjer 3D‑varianter av stapeldiagram, inklusive Column 3D, Clustered Column 3D, Stacked Column 3D och 100 % Stacked Column 3D, samt relaterade 3D‑typer som exponeras via uppräkningen [ChartType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/). För en exakt och aktuell lista, kontrollera medlemmarna i [ChartType](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/) i API‑referensen för den version du har installerad.

**Kan jag få en rasterbild av ett 3D-diagram för en rapport eller webben?**

Ja. Du kan exportera ett diagram till en bild via [diagram‑API:t](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/) eller [rendera hela bilden](/slides/sv/cpp/convert-powerpoint-to-png/) till format som PNG eller JPEG. Detta är användbart när du behöver en pixelperfekt förhandsgranskning eller vill bädda in diagrammet i dokument, instrumentpaneler eller webbsidor utan att kräva PowerPoint.

**Hur presterar byggandet och renderingen av stora 3D-diagram?**

Prestandan beror på datavolym och visuell komplexitet. För bästa resultat, håll 3D‑effekter minimala, undvik tunga texturer på väggar och plotområden, begränsa antalet datapunkter per serie när det är möjligt, och rendera till en lämpligt stor utdata (upplösning och dimensioner) som matchar målskärmen eller utskriftsbehoven.