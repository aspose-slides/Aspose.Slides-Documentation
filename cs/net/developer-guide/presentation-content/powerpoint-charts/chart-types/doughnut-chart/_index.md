---
title: Přizpůsobení prstencových grafů v prezentacích v .NET
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/net/doughnut-chart/
keywords:
- prstencový graf
- středová mezera
- velikost díry
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak vytvořit a přizpůsobit prstencové grafy v Aspose.Slides pro .NET, podporující formáty PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu na snímek, nastavením velikosti jeho středové díry a uložením prezentace. Zaměřuje se na nastavení `DoughnutHoleSize` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

Obsahuje také krátké FAQ s otázkami souvisejícími s prstencovými grafy, jako je použití více sérií pro vytvoření více prstenců, práce s explodovanými prstencovými grafy a export grafu jako rastrový obrázek nebo SVG.

## **Určete středovou mezeru v prstencovém grafu**
Chcete-li určit velikost díry v prstencovém grafu, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
- Přidejte prstencový graf na snímek.
- Zadejte velikost díry v prstencovém grafu.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v prstencovém grafu.

```c#
// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Uložte prezentaci na disk
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Mohu vytvořit víceúrovňový prstenec s více prstenci?**

Ano. Přidejte více sérií do jednoho prstencového grafu – každá série se stane samostatným prstencem. Pořadí prstenců je určeno pořadím sérií v kolekci.

**Je podporován „explodovaný“ prstenec (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/) a vlastnost exploze na jednotlivých bodech dat; můžete oddělit jednotlivé výseče.

**Jak získat obrázek prstencového grafu (PNG/SVG) pro report?**

Graf je tvar; můžete jej vykreslit do [raster image](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/) nebo exportovat graf do [SVG image](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/writeassvg/).