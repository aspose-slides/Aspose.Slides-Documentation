---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en Java
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/java/presentation-view-properties/
keywords:
- propriétés d'affichage
- affichage normal
- contenu du plan
- icônes du plan
- séparateur vertical d'accrochage
- affichage unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides for Java pour configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive apparaît entre un volet latéral pour les miniatures ou le plan et un volet de notes en dessous. Aspose.Slides for Java expose les préférences d'édition enregistrées de la présentation via [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--). Celles‑ci incluent la disposition des volets, les niveaux de zoom, l'espacement de la grille et la visibilité des commentaires.

## **À propos de INormalViewProperties**

Utilisez [getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) pour accéder à l'interface [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) contrôle si des icônes apparaissent à côté des titres de diapositives dans le plan. [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) permet au volet latéral de se placer en position réduite lorsque l'utilisateur le rétrécit. [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) indique une préférence pour afficher un seul volet en plein écran.

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) contrôle le séparateur entre le volet latéral et la diapositive. [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **À propos de la restauration d'INormalViewProperties**

Lorsque un séparateur est restauré, [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) fournit la taille enregistrée du volet latéral et [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) fournit la taille enregistrée de la zone supérieure de la diapositive. Les deux exposent [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/). Sa méthode [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) accepte un pourcentage de 0 à 100, et [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) contrôle si l'éditeur ajuste la taille lorsque la fenêtre est redimensionnée.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, définit la taille renvoyée par [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) à 80% avec l'ajustement automatique activé, et maximise le séparateur vertical. Il appelle également [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) pour afficher les icônes dans la vue plan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir la valeur de zoom par défaut**

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) et [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) stockent des paramètres de zoom indépendants pour l'éditeur. Ces paramètres n'affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d'exportation des images.

Cet exemple ouvre une présentation existante et appelle [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) pour adapter la diapositive à la fenêtre d'édition. Pour la page de notes, il désactive le redimensionnement automatique et appelle [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) pour définir un zoom fixe de 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l'espacement de la grille**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) définit la distance entre les lignes de la grille d'édition dans l'ensemble de la présentation. Il prend une valeur positive en points, avec 72 points par pouce. Cet exemple affiche l'espacement actuel dans une présentation existante et enregistre une grille d'un quart de pouce en réglant l'intervalle à 18 points.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);
    
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La grille se répète à intervalle fixe. [Guides de dessin](/slides/fr/java/drawing-guides/) marquent des positions horizontales ou verticales individuelles. Les deux sont des aides à l'édition et n'apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations vers PDF, images ou SVG les omettent.

## **Afficher ou masquer les commentaires lors de l'ouverture d'une présentation**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) enregistre une préférence que les éditeurs compatibles utilisent lors de l'ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le paramètre actuel et enregistre une copie avec les commentaires masqués. Il appelle également [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) avec [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) afin que la copie s'ouvre en mode diapositive.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Masquer les commentaires préserve leur texte, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Pour modifier les commentaires eux‑mêmes, consultez [Presentation Comments](/slides/fr/java/presentation-comments/). Les paramètres d'exportation contrôlent si les commentaires apparaissent dans le PDF, le HTML, les images, les notes ou les documents de support.

## **FAQ**

**Pourquoi la grille est‑elle masquée lorsque je rouvre la présentation ?**

La présentation enregistre l'intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l'éditeur.

**Effacer les guides de dessin modifie‑t‑il l'espacement de la grille ?**

Non. Ajouter, déplacer ou effacer un guide ne modifie pas l'intervalle de la grille.

**Des sections différentes d'une présentation peuvent‑elles avoir des paramètres d'affichage différents ?**

Non. [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) s'applique à l'ensemble de la présentation.

**Puis‑je enregistrer des paramètres d'affichage différents pour différents utilisateurs ?**

Le fichier stocke un seul ensemble de propriétés d'affichage pour tous. Un éditeur peut également appliquer les préférences locales d'un utilisateur.

**Puis‑je enregistrer les paramètres d'affichage dans un modèle ?**

Oui. Les présentations créées à partir du modèle héritent de ses paramètres d'affichage enregistrés.