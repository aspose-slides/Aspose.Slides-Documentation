---
title: Přizpůsobení bublinových grafů v prezentacích na Androidu
linktitle: Bublinový graf
type: docs
url: /cs/androidjava/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte výkonné bublinové grafy v PowerPointu pomocí Aspose.Slides for Android via Java a snadno vylepšete vizualizaci svých dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikostí bublin pomocí metody `setBubbleSizeScale` a řízení toho, jak jsou hodnoty velikosti bublin reprezentovány pomocí metody `setBubbleSizeRepresentation`.  

Příklady ukazují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bublin na šířku. Článek také obsahuje krátkou sekci FAQ, která objasňuje podporu typu grafu „Bubble with 3-D“, uvádí, že praktické limity grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu pomocí renderovacího motoru Aspose.Slides.

## **Škálování velikosti bublin v grafu**
Aspose.Slides for Android via Java poskytuje podporu pro škálování velikosti bublin v grafu. V Aspose.Slides for Android via Java byly přidány metody [**IChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeries#getBubbleSizeScale--), [**IChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeScale--) a [**IChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeScale-int-). Níže je uveden ukázkový příklad.  

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

## **Reprezentace dat jako velikosti bublin v grafu**
Metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesGroup#setBubbleSizeRepresentation-int-) a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesGroup#getBubbleSizeRepresentation--) byly přidány do rozhraní [IChartSeries](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeries), [IChartSeriesGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartSeriesGroup) a souvisejících tříd. **BubbleSizeRepresentation** určuje, jak jsou hodnoty velikosti bublin v grafu reprezentovány. Možné hodnoty jsou: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Area) a [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/BubbleSizeRepresentationType#Width). V důsledku toho byl do [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/BubbleSizeRepresentationType) enumu přidán popis možných způsobů reprezentace dat jako velikostí bublin v grafu. Níže je uveden ukázkový kód.  

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

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Aplikuje 3‑D stylování na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Tento typ je k dispozici ve třídě [chart type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/).

**Existuje limit počtu sérií a bodů v bublinovém grafu?**  

V úrovni API neexistuje pevný limit; omezení jsou určena výkonem a cílovou verzí PowerPointu. Doporučuje se udržovat počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jaký vliv má export na vzhled bublinového grafu (PDF, obrázky)?**  

Export do podporovaných formátů zachovává vzhled grafu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty platí obecná pravidla pro vykreslování grafiky (rozlišení, antialiasing), proto zvolte dostatečnou DPI pro tisk.