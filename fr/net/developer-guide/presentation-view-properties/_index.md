---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation dans .NET
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/net/presentation-view-properties/
keywords:
- propriétés d'affichage
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
- .NET
- C#
- Aspose.Slides
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour .NET afin de personnaliser les formats PPT, PPTX et ODP—ajuster la mise en page, les niveaux de zoom et les paramètres d'affichage."
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle‑même, une région de contenu latérale et une région de contenu inférieure. Les propriétés concernent le positionnement des différentes régions de contenu. Ces informations permettent à l'application d'enregistrer son état de vue dans le fichier, de sorte que lors de la réouverture la vue soit dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La propriété [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) a été ajoutée pour fournir un accès aux propriétés de la vue normale d’une présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype), ont été ajoutés.

{{% /alert %}}

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l'application doit afficher des icônes lors de l'affichage du contenu du plan dans l'une des régions de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se placer en état minimisé lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l'utilisateur préfère voir une région de contenu unique en plein écran plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l'application peut choisir d'afficher l'une des régions de contenu sur toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** définissent l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la région de contenu située sous la diapositive, une barre de séparation verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** précisent la taille de la région supérieure ou latérale de la diapositive en vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration des INormalViewProperties** 

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de RestoredTop, hauteur lorsqu’elle est un enfant de RestoredLeft) en vue normale, lorsque la région a une taille restaurée variable (ni minimisée ni maximisée).  

La propriété **DimensionSize** indique la taille de la région de la diapositive (largeur lorsqu’elle est un enfant de restoredTop, hauteur lorsqu’elle est un enfant de restoredLeft).  

La propriété **AutoAdjust** indique si la taille de la région de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple est présenté ci‑dessous pour montrer comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.  
```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Restaurer les propriétés de vue de la présentation
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```


## **Définir la valeur de zoom par défaut**

Aspose.Slides pour .NET prend désormais en charge la définition de la valeur de zoom par défaut pour une présentation afin que, lorsqu’elle est ouverte, le zoom soit déjà défini. Cela peut être fait en définissant les [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) d’une présentation. Les propriétés de vue de la diapositive ainsi que les [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) peuvent être définies programmétiquement. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
1. Définissez les [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) de vue de la présentation.  
1. Enregistrez la présentation sous forme de fichier PPTX.  

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue des notes.  
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Définir les propriétés de vue de la présentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valeur du zoom en pourcentage pour la vue des notes 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  

Les [view settings](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), pas par section, de sorte qu’un seul ensemble de paramètres s’applique à l’ensemble du document lors de son ouverture.  

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**  

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.  

**Puis‑je préparer un modèle avec des View Properties pré‑définies afin que les nouvelles présentations s’ouvrent de la même manière ?**  

Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.