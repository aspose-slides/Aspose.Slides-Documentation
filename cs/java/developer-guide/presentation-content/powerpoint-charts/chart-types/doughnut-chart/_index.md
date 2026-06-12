---
title: Přizpůsobení prstencových grafů v prezentacích pomocí Javy
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/java/doughnut-chart/
keywords:
- prstencový graf
- středová mezera
- velikost díry
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat prstencové grafy v Aspose.Slides pro Javu, podporující formáty PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu do snímku, nastavením velikosti jeho středové díry a uložením prezentace. Zaměřuje se na metodu `setDoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

Obsahuje také krátkou sekci FAQ, která pokrývá související scénáře s prstencovým grafem, jako je použití více sérií pro vytvoření více prstenců, práce s explozi (roztrženým) prstencovým grafem a export grafu jako rastrového obrazu nebo SVG.

## **Určení středové mezery v prstencovém grafu**
{{% alert color="primary" %}} 

Aspose.Slides pro Java nyní podporuje určení velikosti díry v prstencovém grafu. V tomto tématu si ukážeme na příkladu, jak zadat velikost díry v prstencovém grafu.

{{% /alert %}} 

Pro určení velikosti díry v prstencovém grafu postupujte podle následujících kroků:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Přidejte prstencový graf na snímek.
3. Určete velikost díry v prstencovém grafu.
4. Uložte prezentaci na disk.

V následujícím příkladu jsme nastavili velikost díry v prstencovém grafu.

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

## **Často kladené otázky**

**Mohu vytvořit víceúrovňový prstenec s několika prstenci?**

Ano. Přidejte do jednoho prstencového grafu několik sérií — každá série se stane samostatným prstencem. Pořadí prstenců je určeno pořadím sérií v kolekci.

**Je podporován „explodovaný“ prstenec (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/charttype/) a vlastnost exploze u datových bodů; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek prstencového grafu (PNG/SVG) pro report?**

Graf je tvar; můžete jej vykreslit do [rastrového obrazu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-) nebo exportovat graf jako [SVG obrázek](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).