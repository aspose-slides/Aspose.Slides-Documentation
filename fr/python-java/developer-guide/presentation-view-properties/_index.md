---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en Python via Java
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/python-java/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- accrochage du séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez les propriétés de vue d'Aspose.Slides pour Python via Java afin de personnaliser les diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés de la vue normale décrivent le positionnement de ces zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors d’une réouverture la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/) et [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/) ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/) ont été ajoutées.

## **À propos de NormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) indiquent si l’application doit afficher des icônes lorsqu’elle montre le contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) spécifient si le séparateur vertical doit se réduire à l’état minimisé lorsque la zone latérale est suffisamment petite.

Les méthodes [getPreferSingleView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) et [setPreferSingleView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indiquent si l’utilisateur préfère voir une unique région de contenu occuper toute la fenêtre plutôt que la vue normale standard à trois régions. Si activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) définissent l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive ; une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) et [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) spécifient la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Restored) est appliquée respectivement à [getVerticalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState).

## **À propos de la restauration de NormalViewProperties**

Spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) de la vue normale, lorsque la zone possède une taille restaurée variable (ni minimisée ni maximisée).

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) indique la taille de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) précise si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

L’exemple ci‑dessous montre comment accéder à [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pour une présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Restaurer les propriétés d'affichage de la présentation.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la valeur de zoom par défaut**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java prend en charge la définition de la valeur de zoom par défaut afin qu’elle soit déjà appliquée à l’ouverture de la présentation. Cela peut être fait en configurant les [ViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getSlideViewProperties) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNotesViewProperties) peuvent être configurées par programme. Dans cet article, nous verrons avec un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) d’une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) dans Aspose.Slides.
{{% /alert %}}

Pour définir les propriétés de la vue, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Définissez les [View Properties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) de la [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Enregistrez la présentation au format [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l’exemple ci‑dessous, nous définissons la valeur de zoom pour la vue diapositive et la vue notes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Définir les propriétés d'affichage de la présentation.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Pourcentage de zoom pour la vue diapositive.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Pourcentage de zoom pour la vue notes.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) pour accéder aux paramètres de vue à l’échelle de la présentation. Les méthodes [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getGridSpacing) et [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#setGridSpacing) lisent ou modifient l’intervalle de la grille d’édition sous‑jacente. Ce réglage s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est indiqué en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, applique un intervalle d’un quart de pouce et enregistre le résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La grille diffère des [drawing guides](/slides/fr/python-java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans un PDF, des images, du SVG ou un diaporama. Le fait de stocker l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après la réouverture de la présentation ?**

Le fichier stocke l’espacement de la grille, mais c’est l’éditeur qui décide de l’afficher. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des réglages indépendants. Supprimer les guides ne change pas l’intervalle de grille enregistré.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [view settings](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document à l’ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je créer un modèle avec des View Properties prédéfinies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) sont enregistrées au niveau de la présentation, vous pouvez les incorporer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.