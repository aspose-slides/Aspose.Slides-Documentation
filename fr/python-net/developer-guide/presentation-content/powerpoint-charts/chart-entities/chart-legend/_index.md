---
title: Personnaliser les légendes de graphiques dans les présentations avec Python
linktitle: Légende du graphique
type: docs
url: /fr/python-net/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de la police
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour Python via .NET afin d'optimiser les présentations PowerPoint et OpenDocument avec un formatage de légende sur mesure."
---

## **Vue d’ensemble**

Aspose.Slides pour Python offre un contrôle complet sur les légendes de graphiques afin que vous puissiez rendre les libellés de données clairs et prêts pour la présentation. Vous pouvez afficher ou masquer la légende, choisir sa position sur la diapositive, et ajuster la mise en page pour éviter le chevauchement avec la zone du tracé. L’API vous permet de styliser le texte et les marques, d’ajuster finement les marges et l’arrière‑plan, ainsi que de formater les bordures et les remplissages pour correspondre à votre thème. Les développeurs peuvent également accéder aux entrées individuelles de la légende pour les renommer ou les filtrer, garantissant que seules les séries les plus pertinentes sont affichées. Avec ces capacités, vos graphiques restent lisibles, cohérents et alignés avec les normes de conception de votre présentation.

## **Positionnement de la légende**

Avec Aspose.Slides, vous pouvez rapidement contrôler où la légende du graphique apparaît et comment elle s’intègre à la mise en page de votre diapositive. Apprenez à placer la légende avec précision.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive.
1. Ajoutez un graphique à la diapositive.
1. Définissez les propriétés de la légende.
1. Enregistrez la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous définissons la position et la taille de la légende du graphique :

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Créez une instance de la classe Presentation.
with slides.Presentation() as presentation:

    # Obtenez une référence à la diapositive.
    slide = presentation.slides[0]

    # Ajoutez un graphique à colonnes groupées à la diapositive.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Définissez les propriétés de la légende.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Enregistrez la présentation sur le disque.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la taille de police de la légende**

La légende d’un graphique doit être aussi lisible que les données qu’elle explique. Cette section montre comment ajuster la taille de police de la légende afin que vous puissiez harmoniser la typographie de votre présentation et améliorer l’accessibilité.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Créez un graphique.
1. Définissez la taille de la police.
1. Enregistrez la présentation sur le disque.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la taille de police pour une entrée de légende**

Aspose.Slides vous permet d’affiner l’apparence des légendes de graphiques en formatant les entrées individuelles. L’exemple ci‑dessous montre comment cibler un élément de légende spécifique et définir ses propriétés sans modifier le reste de la légende.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Créez un graphique.
1. Accédez à une entrée de légende.
1. Définissez les propriétés de l’entrée.
1. Enregistrez la présentation sur le disque.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Puis‑je activer la légende de façon à ce que le graphique réserve automatiquement de l’espace pour elle au lieu de la superposer ?**

Oui. Utilisez le mode sans superposition ([overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) = `false`) ; dans ce cas, la zone du tracé rétrécira pour accueillir la légende.

**Puis‑je créer des libellés de légende sur plusieurs lignes ?**

Oui. Les libellés longs sont automatiquement renvoyés à la ligne lorsque l’espace est insuffisant ; les sauts de ligne forcés sont pris en charge via les caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le jeu de couleurs du thème de la présentation ?**

N’ajoutez pas de couleurs/remplissages/polices explicites à la légende ou à son texte. Ils hériteront alors du thème et seront mis à jour correctement lorsque le design changera.