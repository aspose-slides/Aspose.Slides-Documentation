---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst pomocí JavaScriptu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/nodejs-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- graf treemap
- graf sunburst
- datový bod
- barva popisku
- barva větve
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak spravovat datové body v grafech treemap a sunburst pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java, kompatibilní s formáty PowerPointu."
---
## **Úvod**

Mezi ostatními typy grafů PowerPointu existují dva „hierarchické“ typy – **Treemap** a **Sunburst** graf (také známý jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph nebo Multi Level Pie Chart). Tyto grafy zobrazují hierarchická data uspořádaná jako strom – od listů až po vrchol větve. Listy jsou definovány datovými body řady, a každá následná vnořená úroveň seskupení je definována odpovídající kategorií. Aspose.Slides pro Node.js přes Java umožňuje formátovat datové body Sunburst grafu a Treemap v JavaScriptu.

Zde je Sunburst graf, kde data ve sloupci Series1 definují listové uzly, zatímco ostatní sloupce definují hierarchické datové body:

![todo:image_alt_text](https://lh6.googleusercontent.com/TSSU5O7SLOi5NZD9JaubhgGU1QU5tYKc23RQX_cal3tlz5TpOvsgUFLV_rHvruwN06ft1XYgsLhbeEDXzVqdAybPIbpfGy-lwoQf_ydxDwcjAeZHWfw61c4koXezAAlEeCA7x6BZ)

Začněme přidáním nového Sunburst grafu do prezentace:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" title="Viz také" %}} 
- [**Vytvořit nebo aktualizovat grafy PowerPoint prezentace v JavaScriptu**](/slides/cs/nodejs-java/create-chart/)
{{% /alert %}}

Pokud je potřeba formátovat datové body grafu, měli bychom použít následující:

[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevelsManager), 
[ChartDataPointLevel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevel) třídy 
a [**ChartDataPoint.getDataPointLevels**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPoint#getDataPointLevels--) metoda 
poskytují přístup k formátování datových bodů Treemap a Sunburst grafů. 
[**ChartDataPointLevelsManager**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevelsManager)
se používá pro přístup k višejazykovým kategoriím – představuje kontejner pro 
[**ChartDataPointLevel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevel) objekty.
V podstatě je to obal pro 
[**ChartCategoryLevelsManager**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartCategoryLevelsManager) s
vlastnostmi přidanými specificky pro datové body. 
Třída [**ChartDataPointLevel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevel) má
dvě metody: [**getFormat**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevel#getFormat--) a 
[**getDataLabel**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ChartDataPointLevel#getLabel--) které
poskytují přístup k odpovídajícím nastavením.

## **Zobrazit hodnotu datového bodu**
Zobrazit hodnotu datového bodu „Leaf 4“:

```javascript
var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
dataPoints.get_Item(3).getDataPointLevels().get_Item(0).getLabel().getDataLabelFormat().setShowValue(true);
```

![todo:image_alt_text](https://lh6.googleusercontent.com/bKHMf5Bj37ZkMwUE1OfXjw7_CRmDhafhQOUuVWDmitwbtdkwD68ibWluY6Q1HQz_z2Q-BR_SBrBPZ_gID5bGH0PUqI5w37S22RT-ZZal6k7qIDstKntYi5QXS8z-SgpnsI78WGiu)

## **Nastavit popisek a barvu datového bodu**
Nastavte popisek datového bodu „Branch 1“ tak, aby zobrazoval název řady („Series1“) místo názvu kategorie. Poté nastavte barvu textu na žlutou:

```javascript
var branch1Label = dataPoints.get_Item(0).getDataPointLevels().get_Item(0).getLabel();
branch1Label.getDataLabelFormat().setShowCategoryName(false);
branch1Label.getDataLabelFormat().setShowSeriesName(true);
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
branch1Label.getDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
```

![todo:image_alt_text](https://lh6.googleusercontent.com/I9g0kewJnxkhUVlfSWRN39Ng-wzjWyRwF3yTbOD9HhLTLBt_sMJiEfDe7vOfqRNx89o9AVZsYTW3Vv_TIuj4EgM4_UEEi7zQ3jdvaO8FoG2JcsOqNRgbiE5HQZNz8xx_q9qdj8JQ)

## **Nastavit barvu větve datového bodu**
Změňte barvu větve „Steam 4“:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 100, 100, 450, 400);
    var dataPoints = chart.getChartData().getSeries().get_Item(0).getDataPoints();
    var stem4branch = dataPoints.get_Item(9).getDataPointLevels().get_Item(1);
    stem4branch.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    stem4branch.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![todo:image_alt_text](https://lh5.googleusercontent.com/Zll4cpQ5tTDdgwmJ4yuupolfGaANR8SWWTU3XaJav_ZVXVstV1pI1z1OFH-gov6FxPoDz1cxmMyrgjsdYGS24PlhaYa2daKzlNuL1a0xYcqEiyyO23AE6JMOLavWpvqA6SzOCA6_)

## **Často kladené otázky**

**Mohu změnit pořadí (řazení) segmentů v Sunburst/Treemap?**

Ne. PowerPoint řadí segmenty automaticky (obvykle podle sestupných hodnot, po směru hodinových ručiček). Aspose.Slides tento postup napodobuje: pořadí nelze změnit přímo; dosáhnete toho předzpracováním dat.

**Jak téma prezentace ovlivňuje barvy segmentů a popisků?**

Barvy grafu dědí [theme/palette](/slides/cs/nodejs-java/presentation-theme/) prezentace, pokud explicitně nenastavíte výplně/písma. Pro konzistentní výsledky zajistěte pevné výplně a formátování textu na požadovaných úrovních.

**Zachová export do PDF/PNG vlastní barvy větví a nastavení popisků?**

Ano. Při exportu prezentace jsou nastavení grafu (výplně, popisky) zachována v výstupních formátech, protože Aspose.Slides renderuje s aplikovaným formátováním grafu.

**Mohu vypočítat skutečné souřadnice popisku/elementu pro umístění vlastního překrytí nad grafem?**

Ano. Po ověření rozvržení grafu jsou pro elementy k dispozici skutečné hodnoty X a Y (například pro [DataLabel](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datalabel/)), což pomáhá s přesným umístěním překryvů.