---
title: Přizpůsobení prstencových grafů v prezentacích na Androidu
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/androidjava/doughnut-chart/
keywords:
- prstencový graf
- středová mezera
- velikost díry
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat prstencové grafy v Aspose.Slides pro Android via Java, podporující formáty PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým (doughnut) grafem v Aspose.Slides přidáním grafu do snímku, nastavením velikosti jeho středové díry a uložením prezentace. Soustředí se na metodu `setDoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

Obsahuje také krátkou sekci FAQ, která pokrývá související scénáře s prstencovými grafy, jako je použití více sérií k vytvoření více kruhů, práce s „exploded“ prstencovými grafy a export grafu jako rastru nebo SVG.

## **Určení středové mezery v prstencovém grafu**
{{% alert color="primary" %}} 

Aspose.Slides pro Android via Java nyní podporuje určení velikosti díry v prstencovém grafu. V tomto tématu si na příkladu ukážeme, jak velikost díry v prstencovém grafu nastavit.

{{% /alert %}} 

Pro určení velikosti díry v prstencovém grafu postupujte podle následujících kroků:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
1. Přidejte prstencový graf na snímek.
1. Určete velikost díry v prstencovém grafu.
1. Zapište prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v prstencovém grafu.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Uložte prezentaci na disk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu vytvořit vícestupňový prstencový graf s více kruhy?**

Ano. Přidejte několik sérií do jednoho prstencového grafu — každá série se stane samostatným kruhem. Pořadí kruhů je určeno pořadím sérií v kolekci.

**Je podporován „exploded“ prstencový graf (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/charttype/) a vlastnost explozí u datových bodů; můžete oddělit jednotlivé výseče.

**Jak získám obrázek prstencového grafu (PNG/SVG) pro zprávu?**

Graf je tvar; můžete jej vykreslit do [raster image](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) nebo exportovat graf jako [SVG image](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).