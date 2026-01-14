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
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez les propriétés de vue d’Aspose.Slides pour Python via .NET pour personnaliser les formats PPT, PPTX et ODP des diapositives — ajustez la disposition, les niveaux de zoom et les paramètres d’affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés concernent le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lors de la réouverture la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La propriété [ViewProperties.normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

[NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/), [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) classes et leurs dérivées, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties** 

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se placer en état réduit lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** définissent la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration d’INormalViewProperties** 

Spécifie la taille de la région de diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft) en vue normale, lorsque la région possède une taille restaurée variable (ni réduite ni agrandie).  

La propriété **DimensionSize** indique la taille de la région de diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft).  

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit s’ajuster à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.  
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    # Restaurer les propriétés de vue de la présentation
    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```


## **Définir la valeur de zoom par défaut** 

Aspose.Slides for Python via .NET prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation de façon à ce que, lors de l’ouverture de la présentation, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) d’une présentation. Les propriétés de vue de la diapositive ainsi que les [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) peuvent être définies programmaticalement. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les Propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :  

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)  
1. Définissez les [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) de la présentation  
1. Enregistrez la présentation au format PPTX  

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.  
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Définir les propriétés de vue de la présentation
    presentation.view_properties.slide_view_properties.scale = 100 # Valeur de zoom en pourcentage pour la vue diapositive
    presentation.view_properties.notes_view_properties.scale = 100 # Valeur de zoom en pourcentage pour la vue des notes

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**  

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  

Les [view settings](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Slide View](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.  

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**  

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.  

**Puis‑je préparer un modèle avec des View Properties pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**  

Oui. Comme les [view properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.