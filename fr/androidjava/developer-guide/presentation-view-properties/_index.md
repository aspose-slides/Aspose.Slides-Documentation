---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation sur Android
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/androidjava/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- verrouillage du séparateur vertical
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
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour Android via Java afin de personnaliser les formats PPT, PPTX et ODP des diapositives — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés concernent le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, à la réouverture, la vue retrouve le même état que lorsque la présentation a été enregistrée pour la dernière fois.

Méthode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewRestoredProperties) et leurs dérivées, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SplitterBarStateType) ont été ajoutées.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) indiquent si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) indiquent si l’utilisateur préfère voir une région de contenu unique sur toute la fenêtre plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous celle‑ci, tandis qu’une barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) indiquent la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SplitterBarStateType#Restored) est appliquée respectivement à [getVerticalBarState](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--).

## **À propos de la restauration d’INormalViewProperties**

Spécifie la taille de la région de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vue normale, lorsque la région possède une taille restaurée variable (ni minimisée ni maximisée).

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) indique la taille de la région de diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la zone de contenu latérale doit être ajustée pour compenser le nouveau dimensionnement lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}} 

Aspose.Slides for Android via Java prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation afin que, lorsqu’elle est ouverte, le zoom soit déjà appliqué. Cela peut être réalisé en configurant les [ViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ViewProperties) d’une présentation. Les propriétés [getSlideViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définies par programme. Dans cet article, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ViewProperties) d’une [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).

{{% /alert %}} 

Pour définir les propriétés de vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).
2. Définissez les [View Properties](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation).
3. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Définition des propriétés d'affichage de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue notes 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Puis‑je définir des paramètres de vue différents pour des sections distinctes d’une présentation ?

Les [paramètres de vue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sont définis au niveau de la présentation ([Vue normale](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Vue diapositive](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

### Puis‑je pré‑définir des états de vue différents pour des utilisateurs différents ?

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

### Puis‑je préparer un modèle avec des propriétés de vue prédéfinies afin que les nouvelles présentations s’ouvrent de la même manière ?

Oui. Comme les [propriétés de vue](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#getViewProperties--) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.