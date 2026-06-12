---
title: Přizpůsobení oblastí vykreslování grafů v prezentacích v Java
linktitle: Oblast vykreslování
type: docs
url: /cs/java/chart-plot-area/
keywords:
- graf
- oblast vykreslování
- šířka oblasti vykreslování
- výška oblasti vykreslování
- velikost oblasti vykreslování
- režim rozvržení
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslování grafů v prezentacích PowerPoint pomocí Aspose.Slides pro Java. Jednoduše vylepšete vizuální stránku svých snímků."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s vykreslovací oblastí grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost vykreslovací oblasti ověřením rozvržení grafu a následným načtením hodnot X, Y, šířky a výšky.

Také ukazuje, jak nastavit režim rozvržení vykreslovací oblasti, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType` k definování, zda je vykreslovací oblast počítána podle svého vnitřního regionu nebo podle vnějšího regionu spolu s osami a popisky os.

## **Získání šířky a výšky vykreslovací oblasti grafu**
Aspose.Slides pro Java poskytuje jednoduché API pro .

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Zavolejte metodu [IChart.validateChartLayout()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChart#validateChartLayout--) před získáním skutečných hodnot.
1. Získá skutečnou polohu X (levý) prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečnou horní pozici prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečnou šířku prvku grafu.
1. Získá skutečnou výšku prvku grafu.

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

## **Nastavení režimu rozvržení vykreslovací oblasti grafu**
Aspose.Slides pro Java poskytuje jednoduché API pro nastavení režimu rozvržení vykreslovací oblasti grafu. Metody [**setLayoutTargetType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ChartPlotArea#setLayoutTargetType-int-) a [**getLayoutTargetType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ChartPlotArea#getLayoutTargetType--) byly přidány do třídy [**ChartPlotArea**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ChartPlotArea) a rozhraní [**IChartPlotArea**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartPlotArea). Pokud je rozvržení vykreslovací oblasti definováno ručně, tato vlastnost určuje, zda rozvrhnout oblast podle jejího vnitřku (bez os a popisků os) nebo vnějšího (s osami a popisky os). Existují dvě možné hodnoty, které jsou definovány v enumeraci [**LayoutTargetType**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LayoutTargetType).

- [**LayoutTargetType.Inner**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LayoutTargetType#Inner) – určuje, že velikost vykreslovací oblasti určuje velikost oblasti, aniž by zahrnovala značky os a popisky os.
- [**LayoutTargetType.Outer**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LayoutTargetType#Outer) – určuje, že velikost vykreslovací oblasti určuje velikost oblasti, značky os a popisky os.

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

**Jak se liší vykreslovací oblast od oblasti grafu z hlediska obsahu?**

Vykreslovací oblast je oblast pro kreslení dat (řady, mřížky, trendové čáry atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). U 3D grafů vykreslovací oblast také zahrnuje stěny/podlahu a osy.

**Jak jsou hodnoty x, y, šířka a výška vykreslovací oblasti interpretovány při ručním rozvržení?**

Jedná se o zlomky (0‑1) celkové velikosti grafu; v tomto režimu je automatické umístění vypnuto a použijí se nastavené zlomky.

**Proč se pozice vykreslovací oblasti změnila po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo vykreslovací oblast, ale ovlivňuje rozvržení a dostupný prostor, takže se vykreslovací oblast může posunout, když je aktivní automatické umístění. (Jedná se o standardní chování grafů v PowerPointu.)