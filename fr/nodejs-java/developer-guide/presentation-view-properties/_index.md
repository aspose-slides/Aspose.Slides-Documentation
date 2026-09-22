---
title: "Récupérer et Mettre à jour les propriétés d'affichage de la présentation en JavaScript"
linktitle: "Propriétés d'affichage"
type: docs
weight: 80
url: /fr/nodejs-java/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- diviseur vertical d'accrochage
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour Node.js via Java afin de personnaliser les formats de diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Des propriétés concernant le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors d’une réouverture la vue se trouve dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) a été ajoutée pour fournir un accès aux propriétés de la vue normale d’une présentation.  

[NormalViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewRestoredProperties) classes et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType) ont été ajoutés.

## **About NormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) spécifient si le séparateur vertical doit se placer en état réduit lorsque la zone latérale est suffisamment petite.

Les propriétés [getPreferSingleView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) spécifient si l’utilisateur préfère voir une seule région de contenu en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) spécifient la dimension de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) en conséquence.

## **About Restoring NormalViewProperties** 

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) de la vue normale, lorsque la région a une taille restaurée variable (ni réduite ni agrandie).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) spécifie si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Restaurer les propriétés d'affichage de la présentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Set Default Zoom Value**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation de sorte que, lorsqu’elle est ouverte, le zoom est déjà réglé. Cela peut être fait en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties) d’une présentation. [getSlideViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définis par programme. Dans cet article, nous verrons avec un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) dans Aspose.Slides.

{{% /alert %}} 

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).  
1. Définissez les [View Properties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).  
1. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/). Dans l’exemple ci‑dessus, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Définir les propriétés d'affichage de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue notes
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Set the Grid Spacing**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getViewProperties--) pour accéder aux paramètres de vue au niveau de la présentation. Les méthodes [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) et [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) lisent ou modifient l’intervalle de la grille d’édition sous‑jacent. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme le requiert la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, définit un intervalle d’un quart de pouce et enregistre le résultat.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La grille est différente des [drawing guides](/slides/fr/nodejs-java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou un diaporama. Enregistrer l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**

Le fichier enregistre l’espacement de la grille, mais c’est l’éditeur qui détermine si la grille est affichée. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de la grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [view settings](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getviewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), pas par section, ainsi un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je prédéfinir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences des utilisateurs, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des View Properties prédéfinies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getviewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.