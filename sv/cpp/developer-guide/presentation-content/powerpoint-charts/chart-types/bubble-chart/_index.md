---
title: "Anpassa bubbeldiagram i presentationer med C++"
linktitle: "Bubbeldiagram"
type: docs
url: /sv/cpp/bubble-chart/
keywords:
- "bubbeldiagram"
- "bubbelstorlek"
- "storleksskalning"
- "storleksrepresentation"
- "PowerPoint"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med Aspose.Slides för C++ för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Den här artikeln visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbeltstorlekar via metoden `set_BubbleSizeScale` och kontroll av hur bubble size‑värden representeras via metoden `set_BubbleSizeRepresentation`.

Exemplen demonstrerar hur man skapar ett bubbeldiagram, justerar dess storleksskalning och byter bubble size‑representation till att använda bredd. Artikeln innehåller också en kort FAQ‑sektion som klargör stöd för diagramtypen “Bubble with 3-D”, noterar att praktiska diagramgränser beror på prestanda och mål‑PowerPoint‑version, och förklarar att export bevarar diagrammets utseende via Aspose.Slides renderingsmotor.

## **Skalning av bubbeldiagramstorlek**

Aspose.Slides för C++ erbjuder stöd för skalning av bubbeldiagramstorlek. I Aspose.Slides för **C++ IChartSeries.BubbleSizeScale** och **IChartSeriesGroup.BubbleSizeScale** egenskaper har lagts till. Nedanstående exempel ges.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Representera data som bubbeldiagramstorlekar**

Den nya metoden **get_BubbleSizeRepresentation()** har lagts till i klasserna **IChartSeries** och **ChartSeries**. **BubbleSizeRepresentation** anger hur bubble‑storleksvärden representeras i bubbeldiagrammet. Möjliga värden är: **BubbleSizeRepresentationType.Area** och **BubbleSizeRepresentationType.Width**. Därför har enum‑typen **BubbleSizeRepresentationType** lagts till för att specificera de möjliga sätten att representera data som bubbeldiagramstorlekar. Exempelkod ges nedan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Stöds ett "bubbeldiagram med 3-D-effekt" och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, "Bubble with 3-D". Den applicerar 3‑D‑stil på bubblorna men lägger inte till någon extra axel; data förblir X‑Y‑S (storlek). Typen är tillgänglig i enumerationen [chart type](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/).

**Finns det en gräns för antal serier och punkter i ett bubbeldiagram?**

Det finns ingen fast gräns på API‑nivå; begränsningarna bestäms av prestanda och mål‑PowerPoint‑version. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödjade format bevarar diagrammets utseende; rendering utförs av Aspose.Slides‑motorn. För raster‑/vektormatier gäller generella regler för diagramgrafikrendering (upplösning, anti‑aliasing), så välj tillräckligt DPI för utskrift.