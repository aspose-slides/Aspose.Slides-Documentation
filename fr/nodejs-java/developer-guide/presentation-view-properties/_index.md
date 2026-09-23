---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en JavaScript
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/nodejs-java/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- enclencher le séparateur vertical
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
description: "Découvrez les propriétés de vue d’Aspose.Slides pour Node.js via Java afin de personnaliser les formats de diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d’affichage."
---
## **Introduction**

La vue normale se compose de trois régions de contenu : la diapositive elle‑même, une région de contenu latérale et une région de contenu inférieure. Propriétés concernant le positionnement des différentes régions de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors de la réouverture la vue se trouve dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

[NormalViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewRestoredProperties) classes et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType) ont été ajoutés.

## **À propos de NormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) spécifient si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des régions de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) spécifient si le séparateur vertical doit s’enclencher en état réduit lorsque la région latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) spécifient si l’utilisateur préfère voir une région à contenu unique en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si activé, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la région de contenu située sous la diapositive, tandis qu’une barre de séparation verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) spécifient la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SplitterBarStateType#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) en conséquence.

## **À propos de la restauration de NormalViewProperties**

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) de la vue normale, lorsque la région a une taille restaurée variable (ni réduite ni maximisée).  

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).  

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la région de contenu latéral doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple est fourni ci‑dessous pour montrer comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation de sorte que, lorsqu’elle est ouverte, le zoom est déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définies par programme. Dans cet article, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation) dans Aspose.Slides.

{{% /alert %}} 

Pour définir les propriétés de la vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).
2. Définissez les [View Properties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation).
3. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/) file.  
   Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Définir les propriétés de vue de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue notes
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getViewProperties--) pour accéder aux paramètres de vue au niveau de la présentation. Les méthodes [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) et [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) lisent ou modifient l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est spécifié en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

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

La grille est différente des [guides de dessin](/slides/fr/nodejs-java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou présentations. Le fait de stocker l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du lecteur ou de l’éditeur.

## **Afficher ou masquer les commentaires à l’ouverture d’une présentation**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getViewProperties--) pour accéder aux paramètres de vue au niveau de la présentation. Utilisez [ViewProperties.getShowComments](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#getShowComments--) et [ViewProperties.setShowComments](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte--) pour lire ou modifier la préférence enregistrée indiquant si les commentaires doivent être affichés lorsque la présentation s’ouvre dans PowerPoint ou un autre éditeur compatible.

Ce paramètre ne contrôle que la préférence de vue enregistrée. Il n’ajoute, ne supprime, ne modifie ni ne résout les commentaires. Masquer les commentaires conserve leur contenu, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Voir [Presentation Comments](/slides/fr/nodejs-java/presentation-comments/) pour les opérations qui modifient les commentaires eux‑mêmes.

L’exemple suivant nécessite un fichier `comments.pptx` contenant des commentaires. Il affiche le paramètre de visibilité actuel, demande que les commentaires soient masqués et enregistre un nouveau PPTX sans supprimer aucun commentaire. Il utilise également [ViewProperties.setLastView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) avec [ViewType.SlideView](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewtype/#SlideView) pour configurer la vue d’édition initiale ainsi que la visibilité des commentaires.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce paramètre ne détermine pas si les commentaires sont inclus dans les exportations PDF, HTML, image, notes ou supports. Configurez séparément les options d’exportation spécifiques.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**  
Le fichier enregistre l’espacement de la grille, mais c’est l’éditeur qui contrôle son affichage. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**Le fait de supprimer les guides de dessin modifie‑t‑il l’espacement de la grille ?**  
Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de la grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  
Les [paramètres de vue](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getviewproperties/) sont définis au niveau de la présentation ([Normal View]/[Slide View]), pas par section, de sorte qu’un seul ensemble de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**  
Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**  
Oui. Comme les [view properties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getviewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.