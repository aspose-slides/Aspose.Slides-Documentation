---
title: Přizpůsobení prstencových grafů v prezentacích pomocí JavaScriptu
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/nodejs-java/doughnut-chart/
keywords:
- prstencový graf
- mezera ve středu
- velikost díry
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte, jak pomocí JavaScriptu a Aspose.Slides pro Node.js vytvářet a přizpůsobovat prstencové grafy, s podporou formátů PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu na snímek, nastavením velikosti středu díry a uložením prezentace. Soustředí se na metodu `setDoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

C také obsahuje krátké FAQ pokrývající související scénáře prstencových grafů, jako je použití více sérií pro vytvoření více prstenů, práce s explodovanými prstencovými grafy a export grafu jako rastrového obrázku nebo SVG.

## **Změna mezery ve středu prstencového grafu**

Pro určení velikosti díry v prstencovém grafu postupujte podle následujících kroků:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
1. Přidejte prstencový graf na snímek.
1. Určete velikost díry v prstencovém grafu.
1. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v prstencovém grafu.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Uložte prezentaci na disk
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mohu vytvořit víceúrovňový prstencový graf s více prstenci?**

Ano. Přidejte do jednoho prstencového grafu více sérií – každá série se stane samostatným prstencem. Pořadí prstenů je určeno pořadím sérií v kolekci.

**Je podporován „explodovaný“ prstencový graf (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/charttype/) a vlastnost exploze na datových bodech; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek prstencového grafu (PNG/SVG) pro report?**

Graf je tvar; můžete jej renderovat do [rasterového obrázku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage) nebo exportovat graf do [SVG obrázku](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/).