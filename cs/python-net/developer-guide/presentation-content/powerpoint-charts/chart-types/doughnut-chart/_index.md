---
title: Přizpůsobení prstencových grafů v prezentacích pomocí Pythonu
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/python-net/doughnut-chart/
keywords:
- prstencový graf
- střední mezera
- velikost díry
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat prstencové grafy v Aspose.Slides pro Python pomocí .NET, s podporou formátů PowerPoint a OpenDocument pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu do snímku, nastavením velikosti centrální díry a uložením prezentace. Soustředí se na nastavení `doughnut_hole_size` a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

Obsahuje také krátkou sekci FAQ, která pokrývá související scénáře s prstencovým grafem, jako je použití více sérií k vytvoření více kruhů, práce s rozpadlými prstencovými grafy a export grafu jako rastrový obrázek nebo SVG.

## **Určení mezery uprostřed prstencového grafu**
V pořádku, aby byla určena velikost díry v prstencovém grafu. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
- Přidejte prstencový graf na snímek.
- Zadejte velikost díry v prstencovém grafu.
- Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili velikost díry v prstencovém grafu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvořte instanci třídy Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Uložte prezentaci na disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu vytvořit víceúrovňový prstencový graf s více kruhy?**

Ano. Přidejte do jednoho prstencového grafu více sérií – každá série se stane samostatným kruhem. Pořadí kruhů je určeno pořadím sérií v kolekci.

**Je podporován „rozpadlý“ prstencový graf (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/) a vlastnost exploze na datových bodech; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek prstencového grafu (PNG/SVG) pro report?**

Graf je tvar; můžete jej vykreslit jako [raster image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/) nebo exportovat graf jako [SVG image](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/).