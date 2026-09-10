---
title: Personnaliser les tables de données des graphiques dans les présentations avec Python
linktitle: Table de données
type: docs
url: /fr/python-java/chart-data-table/
keywords:
- données de graphique
- table de données
- propriétés de police
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Personnalisez les tables de données des graphiques en Python pour PPT et PPTX avec Aspose.Slides for Python via Java afin d'améliorer l'efficacité et l'attrait des présentations."
---
## **Aperçu**

Cet article explique comment travailler avec les tables de données de graphiques dans Aspose.Slides. Il montre comment afficher une table de données pour un graphique et personnaliser le formatage du texte en définissant des propriétés de police telles que le style gras et la hauteur de la police. L’exemple démontre la création d’une présentation, l’ajout d’un graphique, l’activation de la table de données du graphique, l’application des paramètres de police et l’enregistrement de la présentation mise à jour.

Il inclut également des réponses rapides aux questions courantes concernant l’affichage des clés de légende dans une table de données de graphique, la conservation de la table de données lors de l’exportation, le travail avec des graphiques chargés à partir de présentations ou de modèles existants, et l’identification des graphiques où la table de données est activée.

## **Définir les propriétés de police pour une table de données de graphique**

Aspose.Slides for Python via Java vous permet d’afficher la table de données d’un graphique et de modifier les propriétés de police de son texte.

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajoutez un graphique à la diapositive.
1. Affichez la table de données du graphique.
1. Définissez le style gras et la hauteur de la police du texte de la table de données.
1. Enregistrez la présentation modifiée.

L’exemple suivant illustre ces étapes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Créez une présentation vide.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je afficher de petites clés de légende à côté des valeurs dans la table de données du graphique ?**

Oui. La table de données prend en charge les [legend keys](https://reference.aspose.com/slides/fr/python-java/aspose.slides/datatable/#setShowLegendKey), et vous pouvez les activer ou les désactiver.

**La table de données sera‑t‑elle conservée lors de l’exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique en tant que partie de la diapositive, de sorte que le [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/python-java/convert-powerpoint-to-html/)/[image](/slides/fr/python-java/convert-powerpoint-to-png/) exporté comprend le graphique avec sa table de données.

**Les tables de données sont‑elles prises en charge pour les graphiques provenant d’un fichier modèle ?**

Oui. Pour tout graphique chargé à partir d’une présentation ou d’un modèle existant, vous pouvez vérifier et modifier si une table de données [is shown](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#hasDataTable) en utilisant les propriétés du graphique.

**Comment puis‑je rapidement trouver quels graphiques d’un fichier ont la table de données activée ?**

Inspectez la propriété de chaque graphique indiquant si la table de données [is shown](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/#hasDataTable) et parcourez les diapositives pour identifier les graphiques où elle est activée.