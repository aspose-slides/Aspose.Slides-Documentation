---
title: Anpassa bubbeldiagram i presentationer med C++
linktitle: Bubbeldiagram
type: docs
url: /sv/cpp/bubble-chart/
keywords:
- bubbeldiagram
- bubbelförstorning
- storleksskalning
- storleksrepresentation
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med Aspose.Slides för C++ för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Denna artikel visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbelförstorningar via metoden `set_BubbleSizeScale` och styrning av hur bubbelförstoringsvärden representeras via metoden `set_BubbleSizeRepresentation`.

Exemplen demonstrerar hur man skapar ett bubbeldiagram, justerar dess storleksskalning och byter bubbelförstoringsrepresentation till att använda bredd. Artikeln innehåller också ett kort FAQ‑avsnitt som klargör stöd för diagramtypen “Bubble with 3-D”, noterar att praktiska diagramgränser beror på prestanda och målversionen av PowerPoint, samt förklarar att export bevarar diagrammets utseende via Aspose.Slides renderingsmotor.

## **Skalning av bubbeldiagramstorlek**
Aspose.Slides för C++ erbjuder stöd för skalning av bubbeldiagramstorlek. I Aspose.Slides för **C++ IChartSeries.BubbleSizeScale** och **IChartSeriesGroup.BubbleSizeScale** har egenskaper lagts till. Nedanstående exempel ges. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representera data som bubbeldiagramstorlekar**
Den nya metoden **get_BubbleSizeRepresentation()** har lagts till i klasserna **IChartSeries** och **ChartSeries**. **BubbleSizeRepresentation** specificerar hur bubbelförstoringsvärdena representeras i bubbeldiagrammet. Möjliga värden är: **BubbleSizeRepresentationType.Area** och **BubbleSizeRepresentationType.Width**. Därmed har enum‑typen **BubbleSizeRepresentationType** lagts till för att ange de möjliga sätten att representera data som bubbeldiagramstorlekar. Nedanstående exempel visar koden.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Stöds ett "bubbeldiagram med 3‑D‑effekt", och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, "Bubble with 3-D". Den tillämpar 3‑D‑stil på bubblorna men lägger inte till en extra axel; data förblir X‑Y‑S (storlek). Typen finns i enumerationen [chart type](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/).

**Finns det någon gräns för antalet serier och punkter i ett bubbeldiagram?**

Det finns ingen strikt gräns på API‑nivå; begränsningarna bestäms av prestanda och målversionen av PowerPoint. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödda format bevarar diagrammets utseende; renderingen utförs av Aspose.Slides‑motorn. För raster‑/vektormatser gäller allmänna regler för diagramgrafikrendering (upplösning, kantutjämning), så välj tillräckligt DPI för utskrift.