---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst na Androidu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/androidjava/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf treemap
- graf sunburst
- datový bod
- barva popisku
- barva větve
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat datové body v grafech treemap a sunburst pomocí Aspose.Slides pro Android přes Java, kompatibilní s formáty PowerPoint."
---
## **Úvod**

Mezi ostatními typy grafů PowerPointu existují dva „hierarchické“ typy – **Treemap** a **Sunburst** graf (také známý jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph nebo Multi Level Pie Chart). Tyto grafy zobrazují hierarchická data uspořádaná jako strom – od listů až k vrcholu větve. Listy jsou definovány datovými body řady a každá další vnořená úroveň skupiny je definována odpovídající kategorií. Aspose.Slides pro Android přes Java umožňuje formátovat datové body Sunburst grafu a Treemap v Javě.

Zde je Sunburst graf, kde data ve sloupci Series1 definují listové uzly, zatímco ostatní sloupce definují hierarchické datové body:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Pojďme začít přidáním nového Sunburst grafu do prezentace:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" title="Viz také" %}} 
- [**Vytvořit nebo aktualizovat grafy PowerPoint prezentace na Androidu**](/slides/cs/androidjava/create-chart/)
{{% /alert %}}

Pokud je potřeba formátovat datové body grafu, měli bychom použít následující:

[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPointLevelsManager), 
[IChartDataPointLevel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPointLevel) třídy 
a [**IChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPoint#getDataPointLevels--) metoda 
poskytují přístup k formátování datových bodů Treemap a Sunburst grafů. 
[**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPointLevelsManager)
se používá k přístupu k víceúrovňovým kategoriím – představuje kontejner pro 
[**IChartCategoryLevelsManager**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartCategoryLevelsManager) s
vlastnostmi přidanými specificky pro datové body. 
Třída [**IChartDataPointLevel**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPointLevel) má
dvě metody: [**getFormat**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPointLevel#getFormat--) a 
[**getDataLabel**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataPointLevel#getLabel--) které
poskytují přístup k odpovídajícím nastavením.

## **Zobrazit hodnotu datového bodu**

Zobrazit hodnotu datového bodu „Leaf 4“:

```java
IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Nastavit popisek a barvu datového bodu**

Nastavte popisek datového bodu „Branch 1“, aby zobrazoval název řady („Series1“) místo názvu kategorie. Pak nastavte barvu textu na žlutou:

```java
IDataLabel branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);

branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Nastavit barvu větve datového bodu**

Změňte barvu větve „Steam 4“:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 100, 100, 450, 400);

    IChartDataPointCollection dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();

    IChartDataPointLevel stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);

    stem4branch.getFormat().getFill().setFillType(FillType.Solid);
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **FAQ**

**Mohu změnit pořadí (třídění) segmentů v Sunburst/Treemap?**

Ne. PowerPoint řadí segmenty automaticky (obvykle podle sestupných hodnot, po směru hodinových ručiček). Aspose.Slides tuto funkci napodobuje: pořadí nelze změnit přímo; dosáhnete toho předzpracováním dat.

**Jak ovlivňuje téma prezentace barvy segmentů a popisků?**

Barvy grafu dědí [téma/paletu](/slides/cs/androidjava/presentation-theme/) prezentace, pokud výslovně nenastavíte výplně/písma. Pro konzistentní výsledky uzamkněte plné výplně a formátování textu na požadovaných úrovních.

**Zachová export do PDF/PNG vlastní barvy větví a nastavení popisků?**

Ano. Při exportu prezentace jsou nastavení grafu (výplně, popisky) zachována v výstupních formátech, protože Aspose.Slides vykresluje s aplikovaným formátováním grafu.

**Mohu vypočítat skutečné souřadnice popisku/elementu pro vlastní umístění překrytí nad grafem?**

Ano. Po ověření rozvržení grafu jsou pro elementy k dispozici skutečné *x* a *y* (například u [DataLabel](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/datalabel/)), což usnadňuje přesné umístění překryvů.