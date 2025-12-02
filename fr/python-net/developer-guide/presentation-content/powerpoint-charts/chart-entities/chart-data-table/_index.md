---
title: Personnaliser les tables de données des graphiques en Python
linktitle: Table de données
type: docs
url: /fr/python-net/chart-data-table/
keywords:
- données de graphique
- table de données
- propriétés de police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Personnalisez les tables de données des graphiques en Python pour PPT, PPTX et ODP avec Aspose.Slides afin d'améliorer l'efficacité et l'attrait des présentations."
---

## **Définir les propriétés de police pour le tableau de données du graphique**
Aspose.Slides for Python via .NET offre la prise en charge de la modification de la couleur des catégories dans une couleur de série.

1. Instanciez l'objet de classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajoutez un graphique sur la diapositive.
1. définissez le tableau du graphique.
1. Définissez la hauteur de la police.
1. Enregistrez la présentation modifiée.

L'exemple ci-dessous est fourni.
```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [legend keys](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation en PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, de sorte que le [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/python-net/convert-powerpoint-to-html/)/[image](/slides/fr/python-net/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont-ils pris en charge pour les graphiques provenant d'un fichier modèle ?**

Oui. Pour tout graphique chargé à partir d'une présentation ou d'un modèle existant, vous pouvez vérifier et modifier si un tableau de données [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) à l'aide des propriétés du graphique.

**Comment puis-je rapidement trouver quels graphiques dans un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique qui indique si le tableau de données [is shown](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) est affiché, puis parcourez les diapositives pour identifier les graphiques où il est activé.