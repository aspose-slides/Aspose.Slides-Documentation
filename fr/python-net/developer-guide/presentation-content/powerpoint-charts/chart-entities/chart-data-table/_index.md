---
title: Personnaliser les tableaux de données des graphiques en Python
linktitle: Tableau de données du graphique
type: docs
url: /fr/python-net/chart-data-table/
keywords:
- données de graphique
- tableau de données
- propriétés de police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Personnalisez les tableaux de données des graphiques en Python pour PPT, PPTX et ODP avec Aspose.Slides afin d’améliorer l’efficacité et l’attrait des présentations."
---

## **Définir les propriétés de police pour le tableau de données du graphique**
Aspose.Slides pour Python via .NET offre la prise en charge de la modification de la couleur des catégories dans la couleur d’une série.

1. Instancier l’objet de classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

Un exemple d’utilisation est présenté ci-dessous.
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

**Puis‑je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datatable/show_legend_key/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera‑t‑il conservé lors de l’exportation de la présentation en PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique comme faisant partie de la diapositive, de sorte que le [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/python-net/convert-powerpoint-to-html/)/[image](/slides/fr/python-net/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont‑ils pris en charge pour les graphiques provenant d’un fichier modèle ?**

Oui. Pour tout graphique chargé à partir d’une présentation ou d’un modèle existant, vous pouvez vérifier et modifier si le tableau de données [est affiché](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) à l’aide des propriétés du graphique.

**Comment puis‑je rapidement identifier quels graphiques d’un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique indiquant si le tableau de données [est affiché](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/has_data_table/) et parcourez les diapositives pour identifier les graphiques où il est activé.