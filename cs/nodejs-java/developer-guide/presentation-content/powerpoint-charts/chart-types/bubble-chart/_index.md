---
title: Přizpůsobení bublinových grafů v prezentacích pomocí JavaScriptu
linktitle: Bublinový graf
type: docs
url: /cs/nodejs-java/bubble-chart/
keywords:
- bublinový graf
- velikost bubliny
- škálování velikosti
- reprezentace velikosti
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte a přizpůsobte výkonné bublinové grafy v PowerPointu pomocí JavaScriptu a Aspose.Slides pro Node.js prostřednictvím Javy a snadno vylepšete svou vizualizaci dat."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s bublinovými grafy v Aspose.Slides. Pokrývá dvě konkrétní možnosti přizpůsobení: škálování velikostí bublin pomocí metody `setBubbleSizeScale` a řízení toho, jak jsou hodnoty velikosti bubliny zobrazovány pomocí metody `setBubbleSizeRepresentation`. Příklady ukazují, jak vytvořit bublinový graf, upravit jeho škálování velikosti a přepnout reprezentaci velikosti bubliny na šířku. Článek také obsahuje krátkou sekci FAQ, která objasňuje podporu typu grafu „Bubble with 3-D“, upozorňuje, že praktické limity grafu závisí na výkonu a cílové verzi PowerPointu, a vysvětluje, že export zachovává vzhled grafu prostřednictvím vykreslovacího enginu Aspose.Slides.

## **Škálování velikosti bublin v grafu**
Aspose.Slides pro Node.js prostřednictvím Java poskytuje podporu pro škálování velikosti bublin v grafu. V Aspose.Slides pro Node.js prostřednictvím Java byly přidány metody [**ChartSeries.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeries#getBubbleSizeScale--), [**ChartSeriesGroup.getBubbleSizeScale**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeScale--) a [**ChartSeriesGroup.setBubbleSizeScale**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeScale-int-). Níže je uveden ukázkový příklad. 

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 100, 100, 400, 300);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150);
    pres.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Reprezentovat data jako velikosti bublin v grafu**
Metody [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesGroup#setBubbleSizeRepresentation-int-) a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesGroup#getBubbleSizeRepresentation--) byly přidány do tříd [ChartSeries](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeries), [ChartSeriesGroup](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartSeriesGroup) a souvisejících tříd. **BubbleSizeRepresentation** určuje, jak jsou hodnoty velikosti bubliny v bublinovém grafu reprezentovány. Možné hodnoty jsou: [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Area) a [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BubbleSizeRepresentationType#Width). Podle toho byl přidán výčet [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/BubbleSizeRepresentationType) pro specifikaci možných způsobů, jak reprezentovat data jako velikosti bublin v grafu. Níže je ukázkový kód.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(aspose.slides.BubbleSizeRepresentationType.Width);
    pres.save("Presentation_BubbleSizeRepresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Je podporován „bublinový graf s 3‑D efektem“ a v čem se liší od běžného?**

Ano. Existuje samostatný typ grafu „Bubble with 3‑D“. Aplikuje 3‑D stylování na bubliny, ale nepřidává další osu; data zůstávají X‑Y‑S (velikost). Tento typ je dostupný v enumeraci [chart type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/).

**Existuje omezení počtu sérií a bodů v bublinovém grafu?**

Na úrovni API neexistuje pevné omezení; omezení jsou dána výkonem a cílovou verzí PowerPointu. Doporučuje se udržovat počet bodů na rozumné úrovni pro čitelnost a rychlost vykreslování.

**Jak ovlivní export vzhled bublinového grafu (PDF, obrázky)?**

Export do podporovaných formátů zachovává vzhled grafu; vykreslování provádí engine Aspose.Slides. Pro rastrové/vektorové formáty se uplatňují obecná pravidla vykreslování grafů (rozlišení, antialiasing), proto zvolte dostatečné DPI pro tisk.