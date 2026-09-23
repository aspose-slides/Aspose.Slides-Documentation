---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en Python
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/python-net/presentation-view-properties/
keywords:
- propriétés de vue
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
- présentation
- Python
- Aspose.Slides
description: "Découvrez les propriétés de vue d’Aspose.Slides for Python via .NET pour personnaliser les formats PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d’affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors de la réouverture la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La propriété [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/normal_view_properties/) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/normalviewrestoredproperties/) ainsi que leurs descendants, et l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/splitterbarstatetype/) ont été ajoutés.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** spécifie si l’application doit afficher les icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit s’enclencher sur un état réduit lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** définissent la taille de la région supérieure ou latérale de la diapositive dans la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration d'INormalViewProperties**

Spécifie la taille de la région de diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft) de la vue normale, lorsque la région a une taille restaurée variable (ni réduite ni maximisée).  

La propriété **DimensionSize** spécifie la taille de la région de diapositive (largeur lorsqu’elle est un enfant de restoredTop, hauteur lorsqu’elle est un enfant de restoredLeft).  

La propriété **AutoAdjust** indique si la taille de la région de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

L’exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.

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

Aspose.Slides for Python via .NET prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation de façon à ce que, lorsqu’elle est ouverte, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) d’une présentation. Les propriétés de vue de la diapositive ainsi que les [notes_view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/notes_view_properties/) peuvent être définies par programmation. Dans ce sujet, nous verrons avec un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes suivantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/)
1. Définissez les [view properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/) de la présentation
1. Enregistrez la présentation sous forme de fichier PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as presentation:
    # Définir les propriétés de vue de la présentation
    presentation.view_properties.slide_view_properties.scale = 100 # Valeur du zoom en pourcentage pour la vue des diapositives
    presentation.view_properties.notes_view_properties.scale = 100 # Valeur du zoom en pourcentage pour la vue des notes 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) pour accéder aux paramètres de vue à l’échelle de la présentation. La propriété [ViewProperties.grid_spacing](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/grid_spacing/) lit ou modifie l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme l’exige la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, définit un intervalle de un quart de pouce et enregistre le résultat.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    grid_spacing = presentation.view_properties.grid_spacing
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.view_properties.grid_spacing = 18.0
    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La grille est différente des [drawing guides](/slides/fr/python-net/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou effacer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les fichiers PDF, images, SVG ou lors d’un diaporama. Le fait d’enregistrer l’espacement de la grille ne garantit pas qu’un éditeur l’affiche : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **Afficher ou masquer les commentaires lors de l’ouverture d’une présentation**

Utilisez [Presentation.view_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) pour accéder aux paramètres de vue à l’échelle de la présentation. Lisez ou modifiez [ViewProperties.show_comments](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/show_comments/) pour enregistrer une préférence indiquant si les commentaires doivent être affichés lorsque la présentation s’ouvre dans PowerPoint ou un autre éditeur compatible.

Ce paramètre ne contrôle que la préférence de vue stockée. Il n’ajoute, ne supprime, ne modifie ni ne résout les commentaires. Masquer les commentaires en préserve le contenu, les auteurs, les positions, les réponses et les états. Consultez [Presentation Comments](/slides/fr/python-net/presentation-comments/) pour les opérations qui modifient les commentaires eux‑mêmes.

L’exemple suivant nécessite un fichier `comments.pptx` existant contenant des commentaires. Il affiche le paramètre de visibilité actuel, demande que les commentaires soient masqués et enregistre un nouveau PPTX sans supprimer aucun commentaire. Il définit également [ViewProperties.last_view](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/last_view/) sur [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewtype/) pour configurer la vue d’édition initiale en même temps que la visibilité des commentaires.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    show_comments = presentation.view_properties.show_comments
    print(f"Current comment visibility: {show_comments}")

    presentation.view_properties.show_comments = slides.NullableBool.FALSE
    presentation.view_properties.last_view = slides.ViewType.SLIDE_VIEW
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Ce paramètre ne détermine pas si les commentaires sont inclus dans les exportations PDF, HTML, image, notes ou support. Configurez séparément les options spécifiques à chaque type d’exportation.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**  
Le fichier enregistre l’espacement de la grille, mais c’est l’éditeur qui décide si la grille est affichée. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**Le fait de supprimer les guides de dessin modifie‑t‑il l’espacement de la grille ?**  
Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  
Les [view settings](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/slide_view_properties/)), pas par section, de sorte qu’un seul ensemble de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**  
Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**  
Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/view_properties/) sont stockées au niveau de la présentation, vous pouvez les incorporer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.