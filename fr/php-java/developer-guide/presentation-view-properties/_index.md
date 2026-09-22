---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en PHP
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/php-java/presentation-view-properties/
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
- PHP
- Aspose.Slides
description: "Découvrez les propriétés de vue d'Aspose.Slides for PHP via Java pour personnaliser les formats de diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lorsqu’il est rouvert, la vue se trouve dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) a été ajoutée pour fournir un accès aux propriétés de la vue normale d’une présentation. 

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewRestoredProperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType) ont été ajoutées.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) indiquent si l’application doit afficher les icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) indiquent si le séparateur vertical doit se placer en position réduite lorsque la zone latérale est suffisamment petite.

Les propriétés [getPreferSingleView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) et [setPreferSingleView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) indiquent si l’utilisateur préfère voir une région de contenu unique plein écran plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Maximized) et [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) et [getRestoredTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties#getRestoredTop) définissent la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) respectivement.

## **À propos de la restauration d’INormalViewProperties**

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) de la vue normale, lorsque la région possède une taille restaurée variable (ni réduite ni maximisée). 

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple donné ci‑dessous montre comment accéder aux propriétés [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) d’une présentation.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Restaurer les propriétés de vue de la présentation
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Définir la valeur de zoom par défaut**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation de sorte que, lors de l’ouverture de la présentation, le zoom soit déjà appliqué. Cela peut être fait en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) peuvent être définies programmatiquement. Dans ce sujet, nous verrons à travers un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation) dans Aspose.Slides.

{{% /alert %}} 

Pour définir les propriétés de la vue, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Définir les [View Properties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Enregistrer la présentation sous forme de fichier [PPTX ](https://docs.fileformat.com/presentation/pptx/) . Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```php
  $presentation = new Presentation();
  try {
    # Définir les propriétés de vue de la présentation
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valeur du zoom en pourcentage pour la vue notes

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Définir l’espacement de la grille**

Utilisez [Presentation::getViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getViewProperties) pour accéder aux paramètres de vue à l’échelle de la présentation. Les méthodes [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/#getGridSpacing) et [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/#setGridSpacing) lisent ou modifient l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est indiqué en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, définit un intervalle d’un quart de pouce, puis enregistre le résultat.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La grille diffère des [drawing guides](/slides/fr/php-java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou un diaporama. Le stockage de l’espacement de la grille ne garantit pas qu’un éditeur affichera la grille : sa visibilité dépend également des préférences du visionneur ou de l’éditeur.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**

Le fichier enregistre l’espacement de la grille, mais c’est l’éditeur qui contrôle son affichage. Vérifiez les paramètres de visibilité de la grille de l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [view settings](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getviewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/getslideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des View Properties pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getviewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.