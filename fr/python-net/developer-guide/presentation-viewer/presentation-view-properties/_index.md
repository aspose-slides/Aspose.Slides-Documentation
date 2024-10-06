---
title: Propriétés de la vue de présentation
type: docs
url: /python-net/presentation-view-properties/
keywords: "Visionneuse PowerPoint, propriétés de la visionneuse, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Propriétés de la visionneuse de présentation PowerPoint en Python"
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle-même, une région de contenu latérale et une région de contenu inférieure. Propriétés concernant le positionnement des différentes régions de contenu. Ces informations permettent à l'application de sauvegarder son état de vue dans le fichier, de sorte qu'à la réouverture, la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La propriété [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/iviewproperties/) a été ajoutée pour fournir un accès aux propriétés de vue normale de la présentation. 

[**INormalViewProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewproperties/), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/python-net/aspose.slides/inormalviewrestoredproperties/) interfaces et ses descendants, [**SplitterBarStateType**](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) enum ont été ajoutés.

{{% /alert %}} 



## **À propos de INormalViewProperties** 

Représente les propriétés de vue normale.

La propriété **ShowOutlineIcons** spécifie si l'application doit afficher des icônes lorsqu'elle affiche le contenu de l'outline dans l'une des régions de contenu du mode de vue normale.

La propriété **SnapVerticalSplitter** spécifie si le séparateur vertical doit s'enclencher dans un état minimisé lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** spécifie si l'utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si activé, l'application peut choisir d'afficher l'une des régions de contenu dans la fenêtre entière.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l'état dans lequel la barre de séparation horizontale ou verticale doit apparaître. Une barre de séparation horizontale sépare la diapositive de la région de contenu située en dessous de la diapositive, la barre de séparation verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored.**

Les propriétés **RestoredLeft** et **RestoredTop** spécifient les dimensions de la région de diapositive supérieure ou latérale de la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée pour **VerticalBarState** et **HorizontalBarState** respectivement.



## **À propos de INormalViewRestoredProperties** 

Spécifie la taille de la région de diapositive (largeur lorsqu'elle est enfant de RestoredTop, hauteur lorsqu'elle est enfant de RestoredLeft) de la vue normale, lorsque la région a une taille restaurée variable (ni minimisée ni maximisée).

La propriété **DimensionSize** spécifie la taille de la région de diapositive (largeur lorsqu'elle est enfant de restoredTop, hauteur lorsqu'elle est enfant de restoredLeft).

La propriété **AutoAdjust** spécifie si la taille de la région de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l'application.

Un exemple est donné ci-dessous montrant comment accéder aux propriétés **ViewProperties.NormalViewProperties** pour une présentation.

```py
import aspose.slides as slides

#Instancier un objet présentation qui représente un fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.view_properties.normal_view_properties.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    pres.view_properties.normal_view_properties.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED

    pres.view_properties.normal_view_properties.restored_top.auto_adjust = True
    pres.view_properties.normal_view_properties.restored_top.dimension_size = 80
    pres.view_properties.normal_view_properties.show_outline_icons = True

    pres.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```




## **Définir la valeur de zoom par défaut**
Aspose.Slides pour Python via .NET prend désormais en charge la définition de la valeur de zoom par défaut pour la présentation de sorte qu'à l'ouverture de la présentation, le zoom soit déjà défini. Cela peut être fait en définissant les [**view_properties**](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) d'une présentation. Les propriétés de vue de diapositive ainsi que [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) peuvent être définies par programmation. Dans ce sujet, nous allons voir avec un exemple comment définir les propriétés de vue de la présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
1. Définir les [Properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) de vue de la présentation
1. Écrire la présentation en tant que fichier PPTX

Dans l'exemple donné ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Définir les propriétés de vue de la présentation
    presentation.view_properties.slide_view_properties.scale = 100 # Valeur de zoom en pourcentages pour la vue de diapositive
    presentation.view_properties.notes_view_properties.scale = 100 # Valeur de zoom en pourcentages pour la vue des notes 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Définir les propriétés de vue**
Pour définir les propriétés de vue, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe Presentation.
1. Définir les propriétés de vue de la présentation.
1. Écrire la présentation en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Définir les propriétés de vue de la présentation
    presentation.view_properties.slide_view_properties.scale = 100 # Valeur de zoom en pourcentages pour la vue de diapositive
    presentation.view_properties.notes_view_properties.scale = 100 # Valeur de zoom en pourcentages pour la vue des notes 

    presentation.save("Zoom_out.pptx", slides.export.SaveFormat.PPTX)
```