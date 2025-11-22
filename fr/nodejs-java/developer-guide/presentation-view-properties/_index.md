---
title: Propriétés d'affichage de la présentation
type: docs
weight: 80
url: /fr/nodejs-java/presentation-view-properties/
keywords:
- propriétés d'affichage
- affichage normal
- contenu du plan
- icônes du plan
- ajustement du séparateur vertical
- affichage unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- présentation
- Node.js
- Java
- Aspose.Slides pour Node.js via Java
description: "Gérer les propriétés d'affichage des présentations PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors d’une nouvelle ouverture la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.

Les classes [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType) ont été ajoutés.

{{% /alert %}} 

## **À propos de NormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode de vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) spécifient si le séparateur vertical doit se réduire à l’état minimisé lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) spécifient si l’utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) spécifient la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SplitterBarStateType#Restored) est appliquée pour [getVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) respectivement.

## **À propos de la restauration de NormalViewProperties** 

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est un enfant de [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) en vue normale, lorsque la région a une taille restaurée variable (ni minimisée ni maximisée).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) spécifie la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de restoredTop, hauteur lorsqu’elle est un enfant de restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) spécifie si la taille de la zone de contenu latérale doit s’ajuster à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple est donné ci‑dessous montrant comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.  
```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Restaurer les propriétés de vue de la présentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Définir la valeur de zoom par défaut**

{{% alert color="primary" %}} 

Aspose.Slides pour Node.js via Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation afin que, lors de l’ouverture de la présentation, le zoom soit déjà défini. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) d’une présentation. Les [getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que les [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définis par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) dans [Aspose.Slides](/slides/fr/).

{{% /alert %}} 

Pour définir les propriétés de vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Définissez les [View Properties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/) . Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.  
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Définition des propriétés de vue de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue des notes
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les paramètres de vue sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), et non par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des View Properties pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les view properties sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.