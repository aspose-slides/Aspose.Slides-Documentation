---
title: Přizpůsobení oblastí vykreslování grafů v prezentacích v JavaScriptu
linktitle: Oblast vykreslování
type: docs
url: /cs/nodejs-java/chart-plot-area/
keywords:
- graf
- oblast vykreslování
- šířka oblasti vykreslování
- výška oblasti vykreslování
- velikost oblasti vykreslování
- režim rozvržení
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslování grafů v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js. Zlepšete vzhled svých snímků bez námahy."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslování grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslování ověřením rozložení grafu a následným načtením hodnot X, Y, šířky a výšky. Také ukazuje, jak nakonfigurovat režim rozvržení oblasti vykreslování, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType`, který určuje, zda je oblast vykreslování vypočítána podle své vnitřní oblasti nebo podle vnější oblasti společně s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslování grafu**

Aspose.Slides pro Node.js přes Java poskytuje jednoduché API pro .

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) .
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Zavolejte metodu [Chart.validateChartLayout()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#validateChartLayout--) před získáním skutečných hodnot.
5. Získá skutečnou X polohu (vlevo) prvku grafu relativně k levému hornímu rohu grafu.
6. Získá skutečnou horní polohu prvku grafu relativně k levému hornímu rohu grafu.
7. Získá skutečnou šířku prvku grafu.
8. Získá skutečnou výšku prvku grafu.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení režimu rozvržení oblasti vykreslování grafu**

Aspose.Slides pro Node.js přes Java poskytuje jednoduché API pro nastavení režimu rozvržení oblasti vykreslování grafu. Metody [**setLayoutTargetType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartPlotArea#setLayoutTargetType-int-) a [**getLayoutTargetType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartPlotArea#getLayoutTargetType--) byly přidány do třídy [**ChartPlotArea**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartPlotArea). Pokud je rozvržení oblasti vykreslování definováno ručně, tato vlastnost určuje, zda rozvrhnout oblast vykreslování podle jejího vnitřku (bez os a popisků os) nebo podle vnějšího okraje (včetně os a popisků os). Existují dvě možné hodnoty, které jsou definovány v výčtu [**LayoutTargetType**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LayoutTargetType#Inner) – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, ne zahrnuje značky a popisky os.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LayoutTargetType#Outer) – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, značky a popisky os.

Ukázkový kód je uveden níže.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny skutečné X, skutečné Y, skutečná šířka a skutečná výška?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslování liší od oblasti grafu co se týče obsahu?**

Oblast vykreslování je oblast pro kreslení dat (serií, mřížek, trendových čar atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). V 3D grafech oblast vykreslování také zahrnuje stěny/podlahu a osy.

**Jak jsou X, Y, šířka a výška oblasti vykreslování interpretovány, když je rozvržení nastaveno ručně?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umístění vypnuto a použijí se nastavené zlomky.

**Proč se pozice oblasti vykreslování změnila po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslování, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslování může při zapnutém automatickém umístění posunout. (Jedná se o standardní chování grafů v PowerPointu.)