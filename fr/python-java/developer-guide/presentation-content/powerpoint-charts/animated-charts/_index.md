---
title: Animer des graphiques PowerPoint en Python via Java
linktitle: Graphiques animés
type: docs
weight: 80
url: /fr/python-java/animated-charts/
keywords:
- graphique
- graphique animé
- animation de graphique
- série de graphique
- catégorie de graphique
- élément de série
- élément de catégorie
- ajouter un effet
- type d'effet
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créez des graphiques animés impressionnants en Python via Java avec Aspose.Slides. Renforcez vos présentations avec des visuels dynamiques dans les fichiers PPT et PPTX — commencez dès maintenant."
---
## **Introduction**

Aspose.Slides for Python via Java prend en charge l'animation des éléments de graphique. **Series**, **Categories**, **Series Elements** et **Category Elements** peuvent être animés à l'aide de la méthode [Sequence.addEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sequence/#addEffect) et de deux énumérations : [EffectChartMajorGroupingType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effectchartmajorgroupingtype/) et [EffectChartMinorGroupingType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/effectchartminorgroupingtype/).

## **Animation des séries de graphique**

Si vous souhaitez animer une série de graphique, écrivez le code selon les étapes ci-dessous :

1. Charger une présentation.
1. Obtenir une référence à l'objet graphique.
1. Animer la série.
1. Enregistrer le fichier de présentation sur le disque.

L'exemple suivant anime les séries de graphique. Le graphique du fichier d'exemple comporte trois séries, donc un effet est ajouté pour chaque indice de 0 à 2. Aspose.Slides ne vérifie pas l'indice par rapport aux données du graphique, et un effet ajouté pour une série qui n'existe pas est écrit dans le fichier mais n'anime rien — gardez l'indice inférieur au nombre de séries dans votre propre graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Charger la présentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtenir une référence à l'objet graphique.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animer les éléments du graphique.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation des catégories de graphique**

Si vous souhaitez animer une catégorie de graphique, écrivez le code selon les étapes ci-dessous :

1. Charger une présentation.
1. Obtenir une référence à l'objet graphique.
1. Animer la catégorie.
1. Enregistrer le fichier de présentation sur le disque.

L'exemple suivant anime les catégories de graphique.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Charger la présentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtenir une référence à l'objet graphique.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animer les éléments du graphique.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation dans un élément de série**

Si vous souhaitez animer des éléments de série, écrivez le code selon les étapes ci-dessous :

1. Charger une présentation.
1. Obtenir une référence à l'objet graphique.
1. Animer les éléments de série.
1. Enregistrer le fichier de présentation sur le disque.

L'exemple suivant anime les éléments de série.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Charger la présentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtenir une référence à l'objet graphique.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animer les éléments du graphique.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Animation dans un élément de catégorie**

Si vous souhaitez animer des éléments de catégorie, écrivez le code selon les étapes ci-dessous :

1. Charger une présentation.
1. Obtenir une référence à l'objet graphique.
1. Animer les éléments de catégorie.
1. Enregistrer le fichier de présentation sur le disque.

L'exemple suivant anime les éléments de catégorie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# Charger la présentation.
presentation = Presentation("ExistingChart.pptx")
try:
    # Obtenir une référence à l'objet graphique.
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # Animer les éléments du graphique.
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # Enregistrer la présentation modifiée sur le disque.
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Différents types d'effets (par ex., entrée, mise en valeur, sortie) sont-ils pris en charge pour les graphiques comme pour les formes classiques ?**

Oui. Un graphique est traité comme une forme, il prend donc en charge les types d'effets d'animation standard, y compris l'entrée, la mise en valeur et la sortie, avec un contrôle complet via la chronologie de la diapositive et les séquences d'animation.

**Puis-je combiner l'animation d'un graphique avec les transitions de diapositive ?**

Oui. Les [Transitions](/slides/fr/python-java/slide-transition/) s'appliquent à la diapositive, tandis que les effets d'animation s'appliquent aux objets de la diapositive. Vous pouvez les utiliser tous les deux dans la même présentation et les contrôler indépendamment.

**Les animations de graphiques sont-elles conservées lors de l'enregistrement en PPTX ?**

Oui. Lorsque vous [enregistrez en PPTX](/slides/fr/python-java/save-presentation/), tous les effets d'animation et leur ordre sont conservés car ils font partie du modèle d'animation natif de la présentation.

**Puis-je lire les animations de graphique existantes d'une présentation et les modifier ?**

Oui. L'API donne accès à la chronologie de la diapositive, aux séquences et aux effets, vous permettant d'inspecter les animations de graphique existantes et de les ajuster sans tout recréer à partir de zéro.

**Puis-je créer une vidéo incluant les animations de graphique avec Aspose.Slides ?**

Oui. Vous pouvez [exporter une présentation vers une vidéo](/slides/fr/python-java/convert-powerpoint-to-video/) tout en conservant les animations, en configurant les durées et les autres paramètres d'exportation afin que le clip résultant reflète la lecture animée.