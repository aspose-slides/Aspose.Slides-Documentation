---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en Java
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/java/presentation-view-properties/
keywords:
- propriétés de vue
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
description: "Découvrez les propriétés de vue d'Aspose.Slides for Java pour personnaliser les formats PPT, PPTX et ODP des diapositives — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés concernent le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors de la réouverture la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour fournir un accès aux propriétés de vue normale d’une présentation.  

[INormalViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewRestoredProperties) les interfaces et leurs dérivées, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType) ont été ajoutés.

## **À propos d'INormalViewProperties**

Représente les propriétés de vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) indiquent si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) précisent si le séparateur vertical doit se placer en état réduit lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) indique si l’utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) indiquent la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Restored) est appliquée aux propriétés [getVerticalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) respectivement.

## **À propos de la restauration d'INormalViewProperties**

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est un enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) en vue normale, lorsque la région possède une taille restaurée variable (ni réduite ni agrandie).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) spécifie la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de restoredTop, hauteur lorsqu’elle est un enfant de restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la région de contenu latérale doit se compenser en fonction de la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple est présenté ci‑dessous pour montrer comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurer les propriétés de vue de la présentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Définir la valeur de zoom par défaut**

{{% alert color="info" %}} 

Aspose.Slides for Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation de sorte que, lors de l’ouverture de la présentation, le zoom soit déjà réglé. Cela peut être effectué en configurant les [ViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définies par programme. Dans cet article, nous verrons, à l’aide d’un exemple, comment définir les [Propriétés de vue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).

{{% /alert %}} 

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Définissez les [View Properties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/). Dans l’exemple ci‑dessus, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Définir les propriétés de vue de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue notes 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Puis‑je définir des paramètres d’affichage différents pour différentes sections d’une présentation ?

Les [paramètres d’affichage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getViewProperties--) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fr/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), pas par section, ainsi un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

### Puis‑je pré‑définir des états d’affichage différents pour différents utilisateurs ?

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés d’affichage.

### Puis‑je préparer un modèle avec des propriétés d’affichage pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?

Oui. Étant donné que les [propriétés d’affichage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getViewProperties--) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration d’affichage initiale.