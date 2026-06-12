---
title: Přizpůsobení bublinových diagramů v prezentacích pomocí C++
linktitle: Bublinový diagram
type: docs
url: /cs/cpp/bubble-chart/
keywords:
- bublinový diagram
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Vytvořte a přizpůsobte výkonné bublinové diagramy v PowerPointu pomocí Aspose.Slides pro C++, abyste snadno vylepšili vizualizaci svých dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými diagramy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikosti bublin pomocí metody `set_BubbleSizeScale` a řízení způsobu, jakým jsou hodnoty velikosti bublin reprezentovány pomocí metody `set_BubbleSizeRepresentation`.

Příklady ukazují, jak vytvořit bublinový diagram, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bublin na šířku. Článek také obsahuje krátkou sekci FAQ, která objasňuje podporu typu diagramu „Bubble with 3-D“, uvádí, že praktické limity diagramu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled diagramu pomocí renderovacího enginu Aspose.Slides.

## **Škálování velikosti bublin v diagramu**
Aspose.Slides for C++ poskytuje podporu pro škálování velikosti bublin v diagramu. V Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** a **IChartSeriesGroup.BubbleSizeScale** byly přidány nové vlastnosti. Níže je uveden ukázkový příklad.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Reprezentovat data jako velikosti bublin v diagramu**
Do tříd **IChartSeries** a **ChartSeries** byla přidána nová metoda **get_BubbleSizeRepresentation()**. **BubbleSizeRepresentation** určuje, jak jsou hodnoty velikosti bublin v diagramu reprezentovány. Možné hodnoty jsou: **BubbleSizeRepresentationType.Area** a **BubbleSizeRepresentationType.Width**. V souladu s tím byl do enumu **BubbleSizeRepresentationType** přidán způsob specifikace možných způsobů reprezentace dat jako velikosti bublin v diagramu. Níže je uveden ukázkový kód.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Je podporován „bublinový diagram s 3‑D efektem“ a jak se liší od běžného?**

Ano. Existuje samostatný typ diagramu „Bubble with 3-D“. Používá 3‑D stylizaci na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Typ je k dispozici v enumeraci [chart type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/).

**Existuje limit na počet řad a bodů v bublinovém diagramu?**

Na úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržovat počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jaký vliv má export na vzhled bublinového diagramu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled diagramu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty platí obecná pravidla vykreslování diagramů (rozlišení, anti‑aliasing), takže zvolte dostatečné DPI pro tisk.