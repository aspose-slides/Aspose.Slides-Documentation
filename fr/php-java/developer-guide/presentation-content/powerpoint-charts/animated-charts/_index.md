---
title: Animer les graphiques PowerPoint en PHP
linktitle: Graphiques animés
type: docs
weight: 80
url: /fr/php-java/animated-charts/
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
- PHP
- Aspose.Slides
description: "Créez des graphiques animés époustouflants avec Aspose.Slides pour PHP via Java. Dynamisez vos présentations avec des visuels dynamiques dans les fichiers PPT et PPTX — commencez dès maintenant."
---

{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java prend en charge l'animation des éléments du graphique. **Series**, **Categories**, **Series Elements**, **Categories Elements** peuvent être animés avec la méthode [**ISequence**.**addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) et deux énumérations [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) et [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType).

{{% /alert %}} 

## **Animation des séries de graphique**
Si vous souhaitez animer une série de graphique, écrivez le code selon les étapes ci‑dessous :

1. Charger une présentation.  
2. Obtenir la référence de l’objet graphique.  
3. Animer la série.  
4. Écrire le fichier de présentation sur le disque.  

Dans l’exemple ci‑dessous, nous avons animé les séries du graphique.  
```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obtenir la référence de l'objet graphique
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animer la série
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Enregistrer la présentation modifiée sur le disque
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation des catégories de graphique**
Si vous souhaitez animer une catégorie de graphique, écrivez le code selon les étapes ci‑dessous :

1. Charger une présentation.  
2. Obtenir la référence de l’objet graphique.  
3. Animer la catégorie.  
4. Écrire le fichier de présentation sur le disque.  

Dans l’exemple ci‑dessus, nous avons animé la catégorie du graphique.  
```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation d’un élément de série**
Si vous souhaitez animer des éléments de série, écrivez le code selon les étapes ci‑dessous :

1. Charger une présentation.  
2. Obtenir la référence de l’objet graphique.  
3. Animer les éléments de série.  
4. Écrire le fichier de présentation sur le disque.  

Dans l’exemple ci‑dessous, nous avons animé les éléments des séries.  
```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obtenir la référence de l'objet graphique
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animer les éléments de série
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Enregistrer le fichier de présentation sur le disque
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation d’un élément de catégorie**
Si vous souhaitez animer des éléments de catégorie, écrivez le code selon les étapes ci‑dessous :

1. Charger une présentation.  
2. Obtenir la référence de l’objet graphique.  
3. Animer les éléments de catégorie.  
4. Écrire le fichier de présentation sur le disque.  

Dans l’exemple ci‑dessous, nous avons animé les éléments des catégories.  
```php
  # Instancier la classe Presentation qui représente un fichier de présentation
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Obtenir la référence de l'objet graphique
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Animer les éléments des catégories
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Enregistrer le fichier de présentation sur le disque
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Différents types d’effets (par exemple : entrée, mise en évidence, sortie) sont‑ils pris en charge pour les graphiques comme pour les formes classiques ?**

Oui. Un graphique est traité comme une forme, il prend donc en charge les types d’effets d’animation standard, y compris entrée, mise en évidence et sortie, avec un contrôle complet via la chronologie de la diapositive et les séquences d’animation.

**Puis‑je combiner l’animation du graphique avec les transitions de diapositive ?**

Oui. Les [Transitions](/slides/fr/php-java/slide-transition/) s’appliquent à la diapositive, tandis que les effets d’animation s’appliquent aux objets de la diapositive. Vous pouvez les utiliser ensemble dans la même présentation et les contrôler indépendamment.

**Les animations du graphique sont‑elles conservées lors de l’enregistrement au format PPTX ?**

Oui. Lorsque vous [enregistrez au format PPTX](/slides/fr/php-java/save-presentation/), tous les effets d’animation et leur ordre sont conservés car ils font partie du modèle d’animation natif de la présentation.

**Puis‑je lire les animations existantes d’un graphique dans une présentation et les modifier ?**

Oui. L’API donne accès à la chronologie de la diapositive, aux séquences et aux effets, vous permettant d’inspecter les animations de graphique existantes et de les ajuster sans recréer tout depuis le départ.

**Puis‑je produire une vidéo incluant les animations de graphique avec Aspose.Slides ?**

Oui. Vous pouvez [exportez une présentation en vidéo](/slides/fr/php-java/convert-powerpoint-to-video/) tout en conservant les animations, en configurant les minutages et les autres paramètres d’exportation afin que le clip résultant reflète la lecture animée.