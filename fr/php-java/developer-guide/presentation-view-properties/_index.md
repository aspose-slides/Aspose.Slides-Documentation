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
- "séparateur vertical à enclencher"
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
description: "Découvrez les propriétés de vue d’Aspose.Slides pour PHP via Java pour personnaliser les formats PPT, PPTX et ODP — ajustez les dispositions, les niveaux de zoom et les paramètres d’affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Cette information permet à l’application d’enregistrer son état de vue dans le fichier, de sorte que lorsqu’il est rouvert la vue se retrouve dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) indiquent si le séparateur vertical doit se placer en état réduit lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) indiquent si l’utilisateur préfère voir une région de contenu unique plein écran plutôt que la vue normale standard à trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--) indiquent la taille de la zone de diapositive supérieure ou latérale de la vue normale, lorsque la valeur [SplitterBarStateType::Restored](https://reference.aspose.com/slides/php-java/aspose.slides/SplitterBarStateType#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivement.

## **À propos de la restauration d'INormalViewProperties**

Spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vue normale, lorsque la zone possède une taille restaurée variable (ni réduite ni agrandie).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getDimensionSize--) indique la taille de la zone de diapositive (largeur lorsqu’elle appartient à restoredTop, hauteur lorsqu’elle appartient à restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.  
```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Restaurer les propriétés de vue de la présentation
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

Aspose.Slides for PHP via Java prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation afin que, lors de l’ouverture de la présentation, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définies par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) d’une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).  

{{% /alert %}} 

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Définissez les [View Properties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).  
1. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/) .  
   Dans l’exemple fourni ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.  
```php
  $presentation = new Presentation();
  try {
    # Définir les propriétés de vue de la présentation
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valeur du zoom en pourcentage pour la vue notes

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Comme les [propriétés de vue](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.