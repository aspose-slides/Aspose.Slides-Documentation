---
title: Přizpůsobení bublinových grafů v prezentacích v .NET
linktitle: Bublinový graf
type: docs
url: /cs/net/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte výkonné bublinové grafy v PowerPointu pomocí Aspose.Slides pro .NET a snadno vylepšete vizualizaci svých dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikosti bublin pomocí vlastnosti `BubbleSizeScale` a řízení toho, jak jsou hodnoty velikosti bublin reprezentovány pomocí vlastnosti `BubbleSizeRepresentation`.

Příklady ukazují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bublin na šířku. Článek také obsahuje krátkou sekci Často kladené otázky, která objasňuje podporu typu grafu “Bubble with 3‑D”, uvádí, že praktické limity grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu pomocí renderovacího enginu Aspose.Slides.

## **Škálování velikosti bublinového grafu**
Aspose.Slides pro .NET poskytuje podporu škálování velikosti bublinových grafů. V Aspose.Slides pro .NET byly přidány vlastnosti **IChartSeries.BubbleSizeScale** a **IChartSeriesGroup.BubbleSizeScale**. Níže je uveden ukázkový příklad.  

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 100, 100, 400, 300);
	chart.ChartData.SeriesGroups[0].BubbleSizeScale = 150;
	pres.Save("Result.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Zobrazit data jako velikosti bublin v grafu**
Vlastnost **BubbleSizeRepresentation** byla přidána do rozhraní IChartSeries, IChartSeriesGroup a souvisejících tříd. **BubbleSizeRepresentation** určuje, jak jsou hodnoty velikosti bublin v bublinovém grafu reprezentovány. Možné hodnoty jsou: **BubbleSizeRepresentationType.Area** a **BubbleSizeRepresentationType.Width**. V souladu s tím byl přidán výčet **BubbleSizeRepresentationType**, který specifikuje možné způsoby reprezentace dat jako velikostí bublin v grafu. Níže je uveden ukázkový kód.  

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
    chart.ChartData.SeriesGroups[0].BubbleSizeRepresentation = BubbleSizeRepresentationType.Width;
    pres.Save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Je podporován „bubble chart with 3‑D effect“ a v čem se liší od běžného?**

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Používá 3‑D stylování na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Tento typ je k dispozici v výčtu [chart type](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/).

**Existuje limit na počet sérií a bodů v bublinovém grafu?**

Na úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržovat počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jak export ovlivní vzhled bublinového grafu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled grafu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty se používají obecná pravidla pro vykreslování grafiky (rozlišení, antialiasing), takže pro tisk zvolte dostatečnou DPI.