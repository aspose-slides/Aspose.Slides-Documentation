---
title: Tableau de données de graphique
type: docs
url: /fr/python-net/chart-data-table/
keywords: "Propriétés de police, tableau de données de graphique, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Définir les propriétés de police pour le tableau de données de graphique dans les présentations PowerPoint en Python"
---

## **Définir les propriétés de police pour le tableau de données de graphique**
Aspose.Slides pour Python via .NET permet de changer la couleur des catégories dans une couleur de série.

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Ajouter un graphique à la diapositive.
1. Définir le tableau de graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

 Un exemple ci-dessous est fourni.

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