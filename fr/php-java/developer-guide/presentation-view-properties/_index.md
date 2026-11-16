---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en PHP
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/php-java/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- séparateur vertical ajustable
- affichage unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Utilisez Aspose.Slides for PHP via Java pour configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive apparaît entre un volet latéral pour les miniatures ou le plan et un volet de notes en dessous. Aspose.Slides for PHP via Java expose les préférences d'édition enregistrées de la présentation via [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Celles‑ci comprennent la disposition des volets, les niveaux de zoom, l'espacement de la grille et la visibilité des commentaires.

## **À propos de NormalViewProperties**

Utilisez [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) pour accéder à la classe [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) contrôle si des icônes apparaissent à côté des titres des diapositives dans le plan. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) permet au volet latéral de s’enclencher à son état réduit lorsque l'utilisateur le rapetisse. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) indique une préférence pour l'affichage d'un seul volet dans la fenêtre complète.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) contrôle le séparateur entre le volet latéral et la diapositive. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **À propos de la restauration de NormalViewProperties**

Lorsque un séparateur est restauré, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) fournit la taille enregistrée du volet latéral et [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) fournit la taille enregistrée de la zone supérieure de la diapositive. Les deux exposent [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Sa méthode [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) accepte un pourcentage de 0 à 100, et [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) contrôle si l'éditeur ajuste la taille lorsque la fenêtre est redimensionnée.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, définit la taille renvoyée par [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) à 80 % avec l'ajustement automatique activé, et maximise le séparateur vertical. Il appelle également [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) pour afficher les icônes en mode plan.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir la valeur de zoom par défaut**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) et [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) stockent des paramètres de zoom indépendants pour l'éditeur. Ces paramètres n'affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d'exportation d'images.

Cet exemple ouvre une présentation existante et appelle [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) pour ajuster la diapositive à la fenêtre d'édition. Pour la page de notes, il désactive le redimensionnement automatique et appelle [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) pour définir un zoom fixe à 80 %.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Définir l'espacement de la grille**

La méthode `setGridSpacing` de [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) définit la distance entre les lignes de la grille d'édition dans l'ensemble de la présentation. Elle prend une valeur positive en points, avec 72 points par pouce. Cet exemple affiche l'espacement actuel dans une présentation existante et enregistre une grille d'un quart de pouce en définissant l'intervalle à 18 points.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La grille se répète à un intervalle fixe. [Guides de dessin](/slides/fr/php-java/drawing-guides/) marquent des positions horizontales ou verticales individuelles. Les deux sont des aides à l'édition et n'apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations en PDF, images ou SVG les omettent.

## **Afficher ou masquer les commentaires lors de l'ouverture d'une présentation**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) enregistre une préférence que les éditeurs compatibles utilisent lors de l'ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le paramètre actuel et enregistre une copie avec les commentaires masqués. Il appelle également [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) avec [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) afin que la copie s'ouvre en mode diapositive.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Masquer les commentaires en préserve le texte, les auteurs, les positions, les réponses et les statuts. Pour modifier les commentaires eux‑mêmes, consultez [Commentaires de présentation](/slides/fr/php-java/presentation-comments/). Les paramètres d'exportation contrôlent si les commentaires apparaissent dans le PDF, le HTML, les images, les notes ou les supports de cours.

## **FAQ**

**Pourquoi la grille est‑elle cachée lorsque je rouvre la présentation ?**

La présentation enregistre l'intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l'éditeur.

**Supprimer les guides de dessin modifie‑t‑il l'espacement de la grille ?**

Non. Ajouter, déplacer ou supprimer un guide laisse l'intervalle de la grille inchangé.

**Les différentes sections d'une présentation peuvent‑elles avoir des paramètres d'affichage différents ?**

Non. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) s'applique à l'ensemble de la présentation.

**Puis‑je enregistrer des paramètres d'affichage différents pour chaque utilisateur ?**

Le fichier stocke un seul ensemble de propriétés d'affichage pour tous. Un éditeur peut également appliquer les préférences locales d'un utilisateur.

**Puis‑je enregistrer les paramètres d'affichage dans un modèle ?**

Oui. Les présentations créées à partir du modèle héritent de ses paramètres d'affichage enregistrés.