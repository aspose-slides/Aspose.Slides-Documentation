---
title: Récupérer et mettre à jour les propriétés de la vue de la présentation en Python
linktitle: Propriétés de la vue
type: docs
weight: 80
url: /fr/python-net/presentation-view-properties/
keywords:
- propriétés de la vue
- vue normale
- contenu du plan
- icônes du plan
- ajustement du séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez les propriétés de vue d’Aspose.Slides pour Python via .NET afin de personnaliser les formats PPT, PPTX et ODP : ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l'application d'enregistrer son état de vue dans le fichier, de sorte que lors de la réouverture la vue se retrouve dans le même état que lors de la dernière sauvegarde de la présentation.

La propriété [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/normal_view_properties/) a été ajoutée pour fournir l'accès aux propriétés de la vue normale d'une présentation. 

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/normalviewrestoredproperties/) et leurs dérivées, ainsi que l'énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/splitterbarstatetype/) ont été ajoutées.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l'application doit afficher des icônes lors de l'affichage du contenu du plan dans l'une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l'utilisateur préfère voir une zone de contenu unique en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si elle est activée, l'application peut choisir d'afficher l'une des zones de contenu sur toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l'état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** définissent la taille de la zone supérieure ou latérale de la diapositive dans la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration d'INormalViewProperties**

Spécifie la taille de la zone de diapositive (largeur lorsqu'elle est enfant de RestoredTop, hauteur lorsqu'elle est enfant de RestoredLeft) de la vue normale, lorsque la zone a une taille restaurée variable (ni minimisée ni maximisée).

La propriété **DimensionSize** indique la taille de la zone de diapositive (largeur lorsqu'elle est enfant de restoredTop, hauteur lorsqu'elle est enfant de restoredLeft).

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit être ajustée pour compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l'application.

Un exemple est présenté ci‑dessous pour montrer comment accéder aux propriétés **ViewProperties.NormalViewProperties** d'une présentation.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Restaurer les propriétés de vue de la présentation
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la valeur de zoom par défaut**

Aspose.Slides for Python via .NET prend désormais en charge la définition de la valeur de zoom par défaut d'une présentation afin que, à l'ouverture, le zoom soit déjà appliqué. Cela peut être fait en définissant les [view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) d'une présentation. Les propriétés de la vue diapositive ainsi que les [notes_view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/notes_view_properties/) peuvent être définies par programme. Dans ce sujet, nous verrons à l'aide d'un exemple comment définir les propriétés de vue d'une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/)
1. Définir les [view properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/) de la présentation
1. Enregistrer la présentation sous forme de fichier PPTX

Dans l'exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Définir les propriétés de vue de la présentation
    presentation.view_properties.slide_view_properties.scale = 100 # Valeur du zoom en pourcentage pour la vue diapositive
    presentation.view_properties.notes_view_properties.scale = 100 # Valeur du zoom en pourcentage pour la vue des notes

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l'espacement de la grille**

Utilisez [Presentation.view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) pour accéder aux paramètres de vue à l'échelle de la présentation. La propriété [ViewProperties.grid_spacing](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/grid_spacing/) lit ou modifie l'intervalle de la grille d'édition sous‑jacent. Ce paramètre s'applique à l'ensemble de la présentation, pas à une diapositive individuelle. L'espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l'exige la documentation de l'API.

L'exemple suivant ouvre un fichier `demo.pptx` existant, affiche l'espacement de grille actuel, définit un intervalle d'un quart de pouce et enregistre le résultat.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La grille est différente des [drawing guides](/slides/fr/python-net/drawing-guides/). L'espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d'alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l'espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l'édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou un diaporama. Enregistrer l'espacement de la grille ne garantit pas qu'un éditeur affichera la grille : sa visibilité dépend également des préférences du visualiseur ou de l'éditeur.

## **FAQ**

**Pourquoi la grille n'est‑elle pas visible après la réouverture de la présentation ?**

Le fichier stocke l'espacement de la grille, mais c'est l'éditeur qui décide si la grille est affichée. Vérifiez les paramètres de visibilité de la grille dans l'éditeur.

**La suppression des guides de dessin modifie‑t‑elle l'espacement de la grille ?**

Non. Les guides de dessin et l'espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l'intervalle de la grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d'une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/slide_view_properties/)), pas par section, ainsi un seul jeu de paramètres s'applique à l'ensemble du document lors de son ouverture.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l'utilisateur, mais le fichier lui‑même ne contient qu'un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s'ouvrent de la même manière ?**

Oui. Parce que les [view properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.