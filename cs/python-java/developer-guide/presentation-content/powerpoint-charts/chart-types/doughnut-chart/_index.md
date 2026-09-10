---
title: Přizpůsobení prstencových grafů v prezentacích pomocí Pythonu přes Java
linktitle: Prstencový graf
type: docs
weight: 30
url: /cs/python-java/doughnut-chart/
keywords:
- prstencový graf
- středová mezera
- velikost díry
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte, jak vytvořit a přizpůsobit prstencové grafy v Aspose.Slides pro Python přes Java, podporující formáty PowerPoint pro dynamické prezentace."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s prstencovým grafem v Aspose.Slides přidáním grafu do snímku, nastavením velikosti centrální díry a uložením prezentace. Zaměřuje se na metodu [setDoughnutHoleSize](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) a demonstruje základní kroky potřebné k přizpůsobení tohoto typu grafu v kódu.

Také obsahuje krátkou sekci FAQ, která pokrývá související scénáře prstencových grafů, jako je použití více sérií k vytvoření více kruhů, práce s rozšířenými prstencovými grafy a export grafu jako rastrového obrázku nebo SVG.

## **Určení středové mezery v prstencovém grafu**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java podporuje nastavení velikosti díry v prstencovém grafu. Tato sekce ukazuje, jak nastavit velikost díry pomocí příkladu.
{{% /alert %}}

Pro nastavení velikosti díry v prstencovém grafu postupujte podle těchto kroků:

1. Vytvořte objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
2. Přidejte prstencový graf do snímku.
3. Určete velikost díry v prstencovém grafu.
4. Uložte prezentaci na disk.

Následující příklad nastavuje velikost díry v prstencovém grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Uložte prezentaci na disk.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Mohu vytvořit vícestupňový prstenec s více kruhy?**

Ano. Přidejte do jediného prstencového grafu více sérií – každá série se stane samostatným kruhem. Pořadí kruhů je určeno pořadím sérií v kolekci.

**Je podporován “rozšířený” prstenec (oddělené výseče)?**

Ano. Existuje typ grafu Exploded Doughnut [chart type](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/) a vlastnost explosion na bodech dat; můžete oddělit jednotlivé výseče.

**Jak mohu získat obrázek prstencového grafu (PNG/SVG) pro zprávu?**

Graf je [shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/); můžete jej převést na [raster image](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) nebo exportovat graf jako SVG obrázek.