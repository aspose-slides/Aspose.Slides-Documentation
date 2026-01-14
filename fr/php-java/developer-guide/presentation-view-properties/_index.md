---
title: "Récupérer et mettre à jour les propriétés de vue de la présentation en PHP"
linktitle: "Propriétés de vue"
type: docs
weight: 80
url: /fr/php-java/presentation-view-properties/
keywords:
  - "propriétés de vue"
  - "vue normale"
  - "contenu du plan"
  - "icônes du plan"
  - "aimantation du séparateur vertical"
  - "vue unique"
  - "état de la barre"
  - "taille de la dimension"
  - "ajustement automatique"
  - "zoom par défaut"
  - "PowerPoint"
  - "OpenDocument"
  - "présentation"
  - "PHP"
  - "Aspose.Slides"
description: "Découvrez les propriétés de vue d’Aspose.Slides pour PHP via Java pour personnaliser les formats PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d’affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lors de la réouverture, la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) a été ajoutée pour fournir un accès aux propriétés de vue normale de la présentation.  

Les classes [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties), leurs descendants, et l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties**

Représente les propriétés de vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) et [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) indiquent si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) indiquent si le séparateur vertical doit s’enclencher en état minimisé lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) et [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) indiquent si l’utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si activé, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, tandis qu’une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Maximized) et [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) et [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties#getRestoredTop) définissent la dimension de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType/#Restored) est appliquée de manière correspondante à [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState).

## **À propos de la restauration de INormalViewProperties**

Spécifie la dimension de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) de la vue normale, lorsque la zone a une taille restaurée variable (ni minimisée ni maximisée).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) d’une présentation.
```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Restaure les propriétés de vue de la présentation
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Définir la valeur de zoom par défaut**
{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation, de sorte que, à l’ouverture, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) peuvent être configurées par programme. Dans cet article, nous verrons, à l’aide d’un exemple, comment définir les [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) d’une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).

{{% /alert %}} 

Pour définir les propriétés de vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
2. Définissez les [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
3. Enregistrez la présentation au format [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.  
   Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.  
```php
  $presentation = new Presentation();
  try {
    # Définir les propriétés de vue de la présentation
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valeur du zoom en pourcentage pour la vue des notes

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Puis-je définir différents paramètres de vue pour différentes sections d’une présentation ?**

Les [Paramètres de vue](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) sont définis au niveau de la présentation ([Vue normale](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Vue diapositive](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Comme les [propriétés de vue](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.