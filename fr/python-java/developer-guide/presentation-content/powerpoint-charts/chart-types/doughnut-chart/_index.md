---
title: Personnaliser les diagrammes en beignet dans les présentations avec Python via Java
linktitle: Diagramme en beignet
type: docs
weight: 30
url: /fr/python-java/doughnut-chart/
keywords:
- diagramme en beignet
- écart central
- taille du trou
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez comment créer et personnaliser des diagrammes en beignet dans Aspose.Slides pour Python via Java, en prenant en charge les formats PowerPoint pour des présentations dynamiques."
---
## **Vue d'ensemble**

Cet article montre comment travailler avec un diagramme en beignet dans Aspose.Slides en ajoutant le diagramme à une diapositive, en définissant la taille du trou central et en enregistrant la présentation. Il se concentre sur la méthode [setDoughnutHoleSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) et démontre les étapes de base nécessaires pour personnaliser ce type de diagramme dans le code.

Il comprend également une courte FAQ couvrant les scénarios liés aux diagrammes en beignet, tels que l’utilisation de plusieurs séries pour créer plusieurs anneaux, le travail avec des diagrammes en beignet éclatés et l’exportation d’un diagramme sous forme d’image raster ou SVG.

## **Spécifier l'écart central dans un diagramme en beignet**

{{% alert color="info" title="Note" %}}

Aspose.Slides for Python via Java prend en charge la spécification de la taille du trou dans un diagramme en beignet. Cette section montre comment spécifier la taille du trou avec un exemple.

{{% /alert %}}

Pour spécifier la taille du trou dans un diagramme en beignet, suivez ces étapes :

1. Instanciez un objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajoutez un diagramme en beignet à la diapositive.
1. Spécifiez la taille du trou dans le diagramme en beignet.
1. Enregistrez la présentation sur le disque.

L'exemple suivant définit la taille du trou dans un diagramme en beignet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Créer une instance de la classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Enregistrer la présentation sur le disque.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je créer un beignet à plusieurs niveaux avec plusieurs anneaux ?**

Oui. Ajoutez plusieurs séries à un seul diagramme en beignet — chaque série devient un anneau séparé. L'ordre des anneaux est déterminé par l'ordre des séries dans la collection.

**Un beignet « explosé » (tranches séparées) est-il pris en charge ?**

Oui. Il existe un type de diagramme [chart type](https://reference.aspose.com/slides/fr/python-java/aspose.slides/charttype/) Exploded Doughnut et une propriété d'explosion sur les points de données ; vous pouvez séparer des tranches individuelles.

**Comment obtenir une image d'un diagramme en beignet (PNG/SVG) pour un rapport ?**

Un diagramme est une [shape](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/); vous pouvez le rendre sous forme d'[raster image](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage) ou exporter le diagramme vers une image SVG.