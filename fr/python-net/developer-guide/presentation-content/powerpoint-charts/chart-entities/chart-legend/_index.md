---
title: Légende de Graphique
type: docs
url: /fr/python-net/chart-legend/
keywords: "Légende de graphique, taille de police de légende, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Définir le positionnement et la taille de police pour la légende de graphique dans des présentations PowerPoint en Python"
---

## **Positionnement de la Légende**
Afin de définir les propriétés de la légende. Veuillez suivre les étapes ci-dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
- Obtenir la référence de la diapositive.
- Ajouter un graphique sur la diapositive.
- Définir les propriétés de la légende.
- Enregistrer la présentation en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons défini la position et la taille de la légende de graphique.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Créer une instance de la classe Presentation
with slides.Presentation() as presentation:

    # Obtenir la référence de la diapositive
    slide = presentation.slides[0]

    # Ajouter un graphique à colonnes groupées sur la diapositive
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Définir les Propriétés de la Légende
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Enregistrer la présentation sur le disque
    presentation.save("Legend_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Définir la Taille de Police de la Légende**
Aspose.Slides pour Python via .NET permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci-dessous :

- Instancier la classe `Presentation`.
- Créer le graphique par défaut.
- Définir la Taille de la Police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Enregistrer la présentation sur le disque.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.legend.text_format.portion_format.font_height = 20
	chart.axes.vertical_axis.is_automatic_min_value = False
	chart.axes.vertical_axis.min_value = -5
	chart.axes.vertical_axis.is_automatic_max_value = False
	chart.axes.vertical_axis.max_value = 10

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la Taille de Police de Légende Individuelle**
Aspose.Slides pour Python via .NET permet aux développeurs de définir la taille de police des entrées individuelles de la légende. Veuillez suivre les étapes ci-dessous :

- Instancier la classe `Presentation`.
- Créer le graphique par défaut.
- Accéder à l'entrée de la légende.
- Définir la Taille de la Police.
- Définir la valeur minimale de l'axe.
- Définir la valeur maximale de l'axe.
- Enregistrer la présentation sur le disque.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw
 
 
with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	tf = chart.legend.entries[1].text_format

	tf.portion_format.font_bold = 1
	tf.portion_format.font_height = 20
	tf.portion_format.font_italic = 1
	tf.portion_format.fill_format.fill_type = slides.FillType.SOLID 
	tf.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```