---
title: Přizpůsobení bublinových grafů v prezentacích pomocí Pythonu
linktitle: Bublinový graf
type: docs
url: /cs/python-net/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vytvořte a přizpůsobte výkonné bublinové grafy v PowerPointu a OpenDocument pomocí Aspose.Slides pro Python via .NET a snadno vylepšete vizualizaci dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikosti bublin pomocí vlastnosti `bubble_size_scale` a řízení toho, jak jsou hodnoty velikosti bublin reprezentovány pomocí vlastnosti `bubble_size_representation`.

Příklady ukazují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bublin na použití šířky. Článek také obsahuje krátkou sekci Často kladené otázky, která objasňuje podporu typu grafu „Bubble with 3-D“, uvádí, že praktická omezení grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu pomocí vykreslovacího enginu Aspose.Slides.

## **Škálování velikosti bublinového grafu**
Aspose.Slides for Python via .NET poskytuje podporu pro škálování velikosti bublinových grafů. V Aspose.Slides for Python via .NET byly přidány vlastnosti **ChartSeries.bubble_size_scale** a **ChartSeriesGroup.bubble_size_scale**. Níže je uveden ukázkový příklad.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Reprezentace dat jako velikosti bublinových grafů**
Do tříd ChartSeries a ChartSeriesGroup byla přidána vlastnost **bubble_size_representation**. **bubble_size_representation** určuje, jak jsou hodnoty velikosti bublin v bublinovém grafu reprezentovány. Možné hodnoty jsou: **BubbleSizeRepresentationType.AREA** a **BubbleSizeRepresentationType.WIDTH**. V souladu s tím byl přidán výčet **BubbleSizeRepresentationType**, který specifikuje možné způsoby reprezentace dat jako velikosti bublinových grafů. Níže je uveden ukázkový kód.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Je podporován „bubble chart with 3-D effect“ a jak se liší od běžného?**

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Na bubliny aplikuje 3‑D stylizaci, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Typ je k dispozici v enumeraci [chart type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/).

**Existuje limit na počet sérií a bodů v bublinovém grafu?**

Na úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržet počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jak export ovlivní vzhled bublinového grafu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled grafu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty platí obecná pravidla vykreslování grafických prvků (rozlišení, antialiasing), takže zvolte dostatečnou DPI pro tisk.