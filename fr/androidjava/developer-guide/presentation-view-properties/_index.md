---
title: Récupérer et mettre à jour les propriétés de vue de la présentation sur Android
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/androidjava/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- accrochage du séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Découvrez les propriétés de vue d'Aspose.Slides pour Android via Java afin de personnaliser les formats de diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lors d’une réouverture, la vue se retrouve dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties) ainsi que leurs descendantes, et l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType) ont été ajoutées.

{{% /alert %}} 

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l’application doit afficher des icônes lors de l’affichage du contour dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) indiquent si le séparateur vertical doit se placer en position réduite lorsque la zone latérale devient suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) indique si l’utilisateur préfère voir une région de contenu unique occupant toute la fenêtre plutôt que la vue normale standard à trois zones de contenu. Si activé, l’application peut choisir d’afficher l’une des zones de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, tandis qu’une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) définissent la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SplitterBarStateType#Restored) est appliquée à la fois à [getVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et à [getHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--).

## **À propos de la restauration de INormalViewProperties**

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) en vue normale, lorsque la région possède une taille restaurée variable (ni réduite, ni agrandie).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) indique la taille de la région de la diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la zone de contenu latérale doit s’adapter à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.  
```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaure les propriétés de vue de la présentation
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

Aspose.Slides for Android via Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation afin que, lors de l’ouverture de la présentation, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définies par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) d’une [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).

{{% /alert %}} 

Pour définir les propriétés de vue, veuillez suivre les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Définissez les [View Properties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.  
```java
Presentation presentation = new Presentation();
try {
    // Définir les propriétés de vue de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur de zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur de zoom en pourcentage pour la vue des notes

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour des sections différentes d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à tout le document lors de son ouverture.

**Puis‑je prédéfinir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue prédéfinies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les [propriétés de vue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.