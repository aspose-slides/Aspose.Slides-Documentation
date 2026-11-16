---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en JavaScript
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/nodejs-java/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- accrochage du séparateur vertical
- vue unique
- état de la barre
- taille de dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilisez Aspose.Slides pour Node.js via Java pour configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive apparaît entre un volet latéral pour les vignettes ou le plan et un volet de notes en dessous. Aspose.Slides pour Node.js via Java expose les préférences d’édition enregistrées de la présentation via [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Celles‑ci comprennent la disposition des volets, les niveaux de zoom, l’espacement de la grille et la visibilité des commentaires.

## **À propos de NormalViewProperties**

Utilisez [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) pour accéder à la classe [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) contrôle si des icônes apparaissent à côté des titres des diapositives dans le plan. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) permet au volet latéral de se réduire à son état minimisé lorsque l’utilisateur le rétrécit. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) indique une préférence pour l’affichage d’un seul volet dans la fenêtre complète.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) contrôle le séparateur entre le volet latéral et la diapositive. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **À propos de la restauration de NormalViewProperties**

Lorsque un séparateur est restauré, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) fournit la taille enregistrée du volet latéral et [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) fournit la taille enregistrée de la zone supérieure de la diapositive. Les deux exposent [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Sa méthode [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) accepte un pourcentage de 0 à 100, et [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) contrôle si l’éditeur ajuste la taille lorsque la fenêtre est redimensionnée.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, fixe la taille renvoyée par [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) à 80 % avec l’ajustement automatique activé, et maximise le séparateur vertical. Il appelle également [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) pour afficher des icônes dans la vue plan.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la valeur de zoom par défaut**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) et [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) stockent des paramètres de zoom indépendants pour l’éditeur. Ces paramètres n’affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d’exportation d’image.

Cet exemple ouvre une présentation existante et appelle [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) pour adapter la diapositive à la fenêtre d’édition. Pour la page de notes, il désactive le redimensionnement automatique et appelle [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) pour fixer un zoom à 80 %.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l'espacement de la grille**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) définit la distance entre les lignes de la grille d’édition dans toute la présentation. Elle accepte une valeur positive en points, avec 72 points par pouce. Cet exemple affiche l’espacement actuel dans une présentation existante et enregistre une grille de un quart de pouce en définissant l’intervalle à 18 points.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La grille se répète à intervalle fixe. [Drawing guides](/slides/fr/nodejs-java/drawing-guides/) marquent des positions horizontales ou verticales individuelles. Les deux sont des aides à l’édition et n’apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations vers PDF, images ou SVG les omettent.

## **Afficher ou masquer les commentaires lors de l'ouverture d'une présentation**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) enregistre une préférence que les éditeurs compatibles utilisent lors de l’ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le paramètre actuel et enregistre une copie avec les commentaires masqués. Il appelle également [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) avec [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) afin que la copie s’ouvre en vue diapositive.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Masquer les commentaires préserve leur texte, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Pour modifier les commentaires eux‑mêmes, consultez [Presentation Comments](/slides/fr/nodejs-java/presentation-comments/). Les paramètres d’exportation déterminent si les commentaires apparaissent dans le PDF, le HTML, les images, les notes ou les supports de cours.

## **FAQ**

**Pourquoi la grille est‑elle masquée lorsque je rouvre la présentation ?**  
La présentation enregistre l’intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l’éditeur.

**Le fait de supprimer les repères de dessin modifie‑t‑il l'espacement de la grille ?**  
Non. Ajouter, déplacer ou supprimer un repère ne modifie pas l’intervalle de la grille.

**Différentes sections d'une présentation peuvent‑elles avoir des paramètres d'affichage différents ?**  
Non. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) s’applique à l’ensemble de la présentation.

**Puis‑je enregistrer des paramètres d'affichage différents pour différents utilisateurs ?**  
Le fichier stocke un seul jeu de propriétés d’affichage pour tous. Un éditeur peut également appliquer les préférences locales de l’utilisateur.

**Puis‑je enregistrer les paramètres d'affichage dans un modèle ?**  
Oui. Les présentations créées à partir du modèle héritent de ses paramètres d’affichage enregistrés.