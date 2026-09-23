---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en PHP
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/php-java/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- séparateur vertical à enclenchement
- vue unique
- état de la barre
- taille de dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Découvrez les propriétés de vue d'Aspose.Slides pour PHP via Java pour personnaliser les formats de diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte qu’à la réouverture la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) a été ajoutée pour fournir un accès aux propriétés de vue normale d’une présentation.

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewRestoredProperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType) ont été ajoutées.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) spécifient si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode de vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) spécifient si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

Les méthodes [getPreferSingleView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) et [setPreferSingleView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) spécifient si l’utilisateur préfère voir une région de contenu unique occupant toute la fenêtre plutôt que la vue normale standard avec trois régions de contenu. Si activé, l’application peut choisir d’afficher l’une des régions de contenu dans toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Maximized) et [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) et [getRestoredTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties#getRestoredTop) spécifient la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType::Restored](https://reference.aspose.com/slides/fr/php-java/aspose.slides/SplitterBarStateType/#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) en conséquence.

## **À propos de la restauration de INormalViewProperties**

Spécifie la dimension de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) de la vue normale, lorsque la zone possède une taille restaurée variable (ni minimisée ni maximisée).

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) spécifie si la taille de la zone de contenu latéral doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) d’une présentation.

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

Aspose.Slides pour PHP via Java prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation, de sorte que lorsque la présentation est ouverte, le zoom est déjà appliqué. Cela peut être fait en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) peuvent être définies par programme. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation) dans Aspose.Slides.

{{% /alert %}} 

Pour définir les propriétés de vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Définissez les [View Properties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation).
1. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).
   Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```php
  $presentation = new Presentation();
  try {
    # Définir les propriétés de vue de la présentation
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Valeur de zoom en pourcentage pour la vue diapositive
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Valeur de zoom en pourcentage pour la vue notes

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Définir l’espacement de la grille**

Utilisez [Presentation::getViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getViewProperties) pour accéder aux paramètres de vue au niveau de la présentation. Les méthodes [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/#getGridSpacing) et [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/#setGridSpacing) lisent ou modifient l’intervalle de la grille d’édition sous‑jacent. Ce réglage s’applique à l’ensemble de la présentation, et non à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche l’espacement de grille actuel, définit un intervalle d’un quart de pouce, puis enregistre le résultat.

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

La grille est différente des [drawing guides](/slides/fr/php-java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou effacer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou diaporamas. Le fait de stocker l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **Afficher ou masquer les commentaires lors de l’ouverture d’une présentation**

Utilisez [Presentation::getViewProperties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getviewproperties/) pour accéder aux paramètres de vue au niveau de la présentation. Utilisez [ViewProperties::getShowComments](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/getshowcomments/) et [ViewProperties::setShowComments](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/setshowcomments/) pour lire ou modifier la préférence enregistrée indiquant si les commentaires doivent être affichés lorsque la présentation s’ouvre dans PowerPoint ou un autre éditeur compatible.

Ce réglage ne contrôle que la préférence de vue enregistrée. Il n’ajoute, ne supprime, n’édite ou ne résout pas les commentaires. Masquer les commentaires préserve leur contenu, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Consultez [Presentation Comments](/slides/fr/php-java/presentation-comments/) pour les opérations qui modifient les commentaires eux‑mêmes.

L’exemple suivant nécessite un fichier `comments.pptx` existant contenant des commentaires. Il affiche le réglage de visibilité actuel, demande que les commentaires soient masqués, puis enregistre un nouveau PPTX sans supprimer aucun commentaire. Il utilise également [ViewProperties::setLastView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/setlastview/) avec [ViewType::SlideView](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewtype/#SlideView) pour configurer la vue d’édition initiale en même temps que la visibilité des commentaires.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ce réglage ne détermine pas si les commentaires sont inclus dans les exportations PDF, HTML, image, notes ou livret. Configurez séparément les options d’exportation spécifiques.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après la réouverture de la présentation ?**  
Le fichier conserve l’espacement de la grille, mais c’est l’éditeur qui détermine si la grille est affichée. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**Le nettoyage des guides de dessin modifie‑t‑il l’espacement de la grille ?**  
Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  
Les [view settings](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getviewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/php-java/aspose.slides/viewproperties/getslideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lorsqu’il s’ouvre.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**  
Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**  
Oui. Comme les [view properties](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getviewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.