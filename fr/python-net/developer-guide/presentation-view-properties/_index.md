---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en Python
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/python-net/presentation-view-properties/
keywords:
- propriétés d'affichage
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
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour Python via .NET afin de personnaliser les formats PPT, PPTX et ODP — ajuster les mises en page, les niveaux de zoom et les paramètres d'affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle‑même, une région de contenu latérale et une région de contenu inférieure. Les propriétés concernent le positionnement des différentes régions de contenu. Ces informations permettent à l’application d’enregistrer son état de vue dans le fichier, de sorte que, lors de la réouverture, la vue soit dans le même état que lors de la dernière sauvegarde de la présentation.

La propriété [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) a été ajoutée pour fournir l’accès aux propriétés de la vue normale de la présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) ainsi que leurs descendants, l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) ont été ajoutés.

{{% /alert %}} 

## **À propos de INormalViewProperties** 

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des régions de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimisé lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une région de contenu unique plein écran plutôt que la vue normale standard avec trois régions de contenu. Si activée, l’application peut choisir d’afficher l’une des régions de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la région de contenu située sous la diapositive, tandis qu’une barre de séparateur verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** spécifient la taille de la région de diapositive supérieure ou latérale de la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration de INormalViewProperties**

Spécifie la taille de la région de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft) de la vue normale, lorsque la région possède une taille restaurée variable (ni minimisée ni maximisée).  

La propriété **DimensionSize** spécifie la taille de la région de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft).  

La propriété **AutoAdjust** indique si la taille de la région de contenu latérale doit s’ajuster à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

L’exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.
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

Aspose.Slides for Python via .NET prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation afin que, lorsqu’elle est ouverte, le zoom soit déjà appliqué. Cela peut être réalisé en configurant les [view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) d’une présentation. Les propriétés de vue de diapositive ainsi que les [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) peuvent être définies par programme. Dans ce sujet, nous verrons avec un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Définir les [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) de vue de la présentation
1. Enregistrer la présentation sous forme de fichier PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue des diapositives ainsi que pour la vue des notes.
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Définir les propriétés de vue de la présentation
    presentation.view_properties.slide_view_properties.scale = 100 # Valeur de zoom en pourcentage pour la vue diapositive
    presentation.view_properties.notes_view_properties.scale = 100 # Valeur de zoom en pourcentage pour la vue notes 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je définir différents paramètres de vue pour différentes sections d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) sont définis au niveau de la présentation ([Vue normale](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/)/[Vue diapositive](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue prédéfinies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Parce que les [propriétés de vue](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.