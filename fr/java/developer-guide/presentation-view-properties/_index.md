---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en Java
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/java/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- aligner le séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez les propriétés d'affichage d'Aspose.Slides for Java pour personnaliser les formats PPT, PPTX et ODP des diapositives — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés concernant le positionnement des différentes zones de contenu. Cette information permet à l’application d’enregistrer son état de vue dans le fichier, de sorte que, lors de la réouverture, la vue soit dans le même état que lors du dernier enregistrement de la présentation.

La méthode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour fournir un accès aux propriétés de la vue normale d’une présentation.

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties) ainsi que leurs descendants, et l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) indiquent si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) indiquent si le séparateur vertical doit s’enclencher en état minimisé lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) indique si l’utilisateur préfère voir une seule zone de contenu en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si activée, l’application peut choisir d’afficher l’une des zones de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) indiquent la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/java/com.aspose.slides/SplitterBarStateType#Restored) est appliquée pour [getVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) en conséquence.

## **À propos de la restauration de INormalViewProperties** 

Spécifie la taille de la zone de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) en vue normale, lorsque la zone a une taille restaurée variable (ni réduite ni agrandie). 

La méthode [getDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) indique la taille de la zone de la diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft). 

La méthode [getAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la zone de contenu latérale doit s’ajuster à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application. 

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.
```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurer les propriétés d'affichage de la présentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Définir la valeur de zoom par défaut**

{{% alert color="primary" %}} 

Aspose.Slides for Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation ; ainsi, lorsque la présentation est ouverte, le zoom est déjà réglé. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) d’une présentation. Les [getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que les [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définis par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).

{{% /alert %}} 

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Définissez les [View Properties](https://reference.aspose.com/slides/java/com.aspose.slides/ViewProperties) de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/) . Dans l’exemple ci‑dessus, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.
```java
Presentation presentation = new Presentation();
try {
    // Définir les propriétés d'affichage de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue notes 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je définir différents paramètres de vue pour différentes sections d’une présentation ?**

Les paramètres de vue sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Les propriétés de vue étant stockées au niveau de la présentation, vous pouvez les incorporer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.