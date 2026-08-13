---
title: Přizpůsobení donut diagramů v prezentacích pomocí Javy
linktitle: Donut diagram
type: docs
weight: 30
url: /cs/java/doughnut-chart/
keywords:
- donut diagram
- střední mezera
- velikost díry
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak vytvořit a přizpůsobit donut diagramy v Aspose.Slides pro Javu, podporující formáty PowerPointu pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s donut diagramem v Aspose.Slides přidáním diagramu na snímek, nastavením velikosti jeho centrální díry a uložením prezentace. Zaměřuje se na metodu `setDoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu diagramu v kódu.

Obsahuje také krátkou sekci FAQ, která pokrývá související scénáře s donut diagramy, jako je použití více sérií k vytvoření více prstenců, práce s explodovanými donut diagramy a export diagramu jako rastrového obrazu nebo SVG.

## **Specifikujte centrální díru v donut diagramu**
{{% alert color="info" %}} 

Aspose.Slides pro Java nyní podporuje určení velikosti díry v donut diagramu. V tomto tématu si ukážeme na příkladu, jak velikost díry v donut diagramu nastavit.

{{% /alert %}} 

Pro určení velikosti díry v donut diagramu postupujte podle následujících kroků:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
1. Přidejte donut diagram na snímek.
1. Určete velikost díry v donut diagramu.
1. Uložte prezentaci na disk.

V ukázce níže jsme nastavili velikost díry v donut diagramu.

```java
import com.aspose.slides.*;

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

### Mohu vytvořit víceúrovňový donut s více prstenci?

Ano. Přidejte několik sérií do jednoho donut diagramu – každá série se stane samostatným prstencem. Pořadí prstenců je určeno pořadím sérií v kolekci.

### Je podporován „explodovaný“ donut (oddělené výseče)?

Ano. Existuje typ diagramu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) a vlastnost exploze u datových bodů; můžete oddělit jednotlivé výseče.

### Jak mohu získat obrázek donut diagramu (PNG/SVG) pro zprávu?

Diagram je tvar; můžete jej vykreslit do [raster image](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-) nebo exportovat diagram jako [SVG image](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).