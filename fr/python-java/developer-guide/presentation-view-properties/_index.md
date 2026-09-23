---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en Python via Java
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/python-java/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- ajustement du séparateur vertical
- vue unique
- état de la barre
- taille de dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Découvrez les propriétés de vue d'Aspose.Slides for Python via Java pour personnaliser les diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés de la vue normale décrivent le positionnement de ces zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lors de la réouverture, la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/) , [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/) et l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/) ont été ajoutées.

## **À propos de NormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) indiquent si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) déterminent si le séparateur vertical doit s’enclencher dans un état réduit lorsque la zone latérale est suffisamment petite.

Les méthodes [getPreferSingleView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) et [setPreferSingleView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indiquent si l’utilisateur préfère voir une région à contenu unique sur toute la fenêtre plutôt que la vue normale standard avec trois zones de contenu. Si cette option est activée, l’application peut choisir d’afficher l’une des zones de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située en dessous de la diapositive ; une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Minimized) , [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Restored) .

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) et [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) définissent la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivement.

## **À propos de la restauration de NormalViewProperties**

Spécifie la taille de la zone de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) , hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) ) en vue normale, lorsque la zone possède une taille restaurée variable (ni réduite ni agrandie).

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) indique la taille de la zone de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) , hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) ).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) indique si la taille de la zone de contenu latérale doit s’ajuster à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

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

    # Restaurer les propriétés de vue de la présentation.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la valeur de zoom par défaut**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java prend en charge la définition de la valeur de zoom par défaut afin qu’elle soit déjà appliquée lors de l’ouverture de la présentation. Cela peut être fait en définissant les [ViewProperties] d’une présentation. [getSlideViewProperties] ainsi que [getNotesViewProperties] peuvent être configurés par programme. Dans cet article, nous verrons avec un exemple comment définir les [View Properties] de la classe [Presentation] dans Aspose.Slides.
{{% /alert %}}

Pour définir les propriétés de la vue, suivez les étapes suivantes :
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Définissez les [View Properties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) de la [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
3. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l’exemple ci‑dessous, nous définissons la valeur de zoom à la fois pour la vue diapositive et la vue notes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Définir les propriétés de vue de la présentation.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Pourcentage de zoom pour la vue diapositive.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Pourcentage de zoom pour la vue des notes.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) pour accéder aux paramètres de vue à l’échelle de la présentation. Les méthodes [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getGridSpacing) et [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#setGridSpacing) lisent ou modifient l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est indiqué en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, conformément à la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, définit un intervalle d’un quart de pouce et enregistre le résultat.

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

La grille est différente des [drawing guides](/slides/fr/python-java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou un diaporama. Le fait d’enregistrer l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **Afficher ou masquer les commentaires à l’ouverture d’une présentation**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) pour accéder aux paramètres de vue à l’échelle de la présentation. Utilisez [ViewProperties.getShowComments](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getShowComments) et [ViewProperties.setShowComments](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#setShowComments) pour lire ou modifier la préférence enregistrée indiquant si les commentaires doivent être affichés à l’ouverture de la présentation dans PowerPoint ou un autre éditeur compatible.

Ce paramètre ne contrôle que la préférence de vue enregistrée. Il n’ajoute, ne supprime, ne modifie ni ne résout les commentaires. Masquer les commentaires en préserve le contenu, les auteurs, les positions, les réponses et les statuts. Voir [Presentation Comments](/slides/fr/python-java/presentation-comments/) pour les opérations qui modifient les commentaires eux‑mêmes.

L’exemple suivant nécessite un fichier `comments.pptx` existant contenant des commentaires. Il affiche le paramètre de visibilité actuel, demande que les commentaires soient masqués et enregistre un nouveau PPTX sans supprimer aucun commentaire. Il utilise également [ViewProperties.setLastView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#setLastView) avec [ViewType.SlideView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewtype/#SlideView) pour configurer la vue d’édition initiale ainsi que la visibilité des commentaires.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ce paramètre ne détermine pas si les commentaires sont inclus dans les exportations PDF, HTML, image, notes ou support. Configurez séparément les options spécifiques à chaque type d’exportation.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après la réouverture de la présentation ?**

Le fichier enregistre l’espacement de la grille, mais c’est l’éditeur qui contrôle son affichage. Vérifiez les paramètres de visibilité de la grille de l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [view settings](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent prendre en compte les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.