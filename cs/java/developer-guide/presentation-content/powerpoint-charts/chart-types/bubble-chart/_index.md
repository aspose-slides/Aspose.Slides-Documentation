---
title: "Přizpůsobení bublinových grafů v prezentacích pomocí Java"
linktitle: "Bublinový graf"
type: docs
url: /cs/java/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte výkonné bublinové grafy v PowerPointu pomocí Aspose.Slides pro Java a snadno vylepšujte vizualizaci svých dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikosti bublin pomocí metody `setBubbleSizeScale` a řízení toho, jak jsou hodnoty velikosti bublin reprezentovány pomocí metody `setBubbleSizeRepresentation`.

Příklady demonstrují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a změnit reprezentaci velikosti bublin na šířku. Článek také obsahuje stručnou sekci FAQ, která objasňuje podporu typu grafu „Bubble with 3‑D“, uvádí, že praktická omezení grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu pomocí vykreslovacího enginu Aspose.Slides.

## **Škálování velikosti bublinového grafu**
Aspose.Slides for Java poskytuje podporu pro škálování velikosti bublinových grafů. V Aspose.Slides for Java [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) a [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-) byly přidány metody. Níže je uveden ukázkový příklad.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);

    pres.save("Result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Reprezentace dat jako velikosti bublinového grafu**
Metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) byly přidány do rozhraní [IChartSeries](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartSeriesGroup) a souvisejících tříd. **BubbleSizeRepresentation** určuje, jak jsou hodnoty velikosti bublin v grafu reprezentovány. Možné hodnoty jsou: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/BubbleSizeRepresentationType#Area) a [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/BubbleSizeRepresentationType#Width). Vzhledem k tomu byl přidán výčet [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/BubbleSizeRepresentationType), který specifikuje možné způsoby reprezentace dat jako velikosti bublinového grafu. Níže je uveden ukázkový kód.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width);

    pres.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Je podporován „bublinový graf s 3‑D efektem“ a jak se liší od běžného?**

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Používá 3‑D stylování na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Typ je k dispozici ve třídě [chart type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/).

**Existuje limit počtu sérií a bodů v bublinovém grafu?**

Na úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržovat počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jak export ovlivní vzhled bublinového grafu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled grafu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty platí obecná pravidla vykreslování grafiky (rozlišení, anti‑aliasing), takže zvolte dostatečné DPI pro tisk.