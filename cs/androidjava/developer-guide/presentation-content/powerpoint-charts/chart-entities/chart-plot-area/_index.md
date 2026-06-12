---
title: Přizpůsobení oblastí vykreslování grafů v prezentacích na Androidu
linktitle: Oblast vykreslování
type: docs
url: /cs/androidjava/chart-plot-area/
keywords:
- graf
- oblast vykreslování
- šířka oblasti vykreslování
- výška oblasti vykreslování
- velikost oblasti vykreslování
- režim rozvržení
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslování grafů v prezentacích PowerPoint pomocí Aspose.Slides pro Android via Java. Vylepšete vizuální podobu snímků snadno."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslování grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslování ověřením rozvržení grafu a následným načtením hodnot X, Y, šířky a výšky.

Také ukazuje, jak nastavit režim rozvržení oblasti vykreslování, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType` k určení, zda je oblast vykreslování počítána podle svého vnitřního regionu nebo podle vnějšího regionu společně s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslování grafu**
Aspose.Slides pro Android via Java poskytuje jednoduché rozhraní API pro . 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Zavolejte metodu [IChart.validateChartLayout()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChart#validateChartLayout--) před získáním skutečných hodnot.
5. Získá skutečnou X polohu (vlevo) prvku grafu relativně k levému hornímu rohu grafu.
6. Získá skutečnou horní pozici prvku grafu relativně k levému hornímu rohu grafu.
7. Získá skutečnou šířku prvku grafu.
8. Získá skutečnou výšku prvku grafu.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();

    double x = chart.getPlotArea().getActualX();
    double y = chart.getPlotArea().getActualY();
    double w = chart.getPlotArea().getActualWidth();
    double h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení režimu rozvržení oblasti vykreslování grafu**
Aspose.Slides pro Android via Java poskytuje jednoduché rozhraní API pro nastavení režimu rozvržení oblasti vykreslování grafu. Metody [**setLayoutTargetType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) a [**getLayoutTargetType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) byly přidány do třídy [**ChartPlotArea**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ChartPlotArea) a rozhraní [**IChartPlotArea**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartPlotArea). Pokud je rozvržení oblasti vykreslování definováno ručně, tato vlastnost určuje, zda oblast vykreslování rozvrhnout podle jejího vnitřku (bez os a popisků os) nebo podle vnějšího (včetně os a popisků os). Existují dvě možné hodnoty, které jsou definovány v enumeraci [**LayoutTargetType**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LayoutTargetType#Inner) – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, neobsahuje značky a popisky os.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LayoutTargetType#Outer) – určuje, že velikost oblasti vykreslování určuje velikost oblasti vykreslování, značky a popisky os.

Ukázkový kód je uveden níže.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2f);
    chart.getPlotArea().setY(0.2f);
    chart.getPlotArea().setWidth(0.7f);
    chart.getPlotArea().setHeight(0.7f);
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);

    pres.save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny skutečné x, skutečné y, skutečná šířka a skutečná výška?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslování liší od oblasti grafu z hlediska obsahu?**

Oblast vykreslování je oblast, kde se kreslí data (série, mřížky, trendové čáry atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). Ve 3D grafech oblast vykreslování také zahrnuje stěny/podlahu a osy.

**Jak jsou x, y, šířka a výška oblasti vykreslování interpretovány, když je rozvržení ruční?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umístění vypnuto a použijí se zadané zlomky.

**Proč se pozice oblasti vykreslování změnila po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslování, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslování se může posunout, když je zapnuto automatické umístění. (Jedná se o standardní chování grafů v PowerPointu.)