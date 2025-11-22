---
title: Propriétés d'affichage de la présentation
type: docs
weight: 80
url: /fr/net/presentation-view-properties/
keywords:
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- verrouillage du séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Gérer les propriétés d'affichage d'une présentation PowerPoint en C# ou .NET"
---

{{% alert color="primary" %}} 

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Propriétés relatives au positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que lorsqu’elle est rouverte, la vue se trouve dans le même état que lors de la dernière sauvegarde de la présentation.

La propriété [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) ont été ajoutés.

{{% /alert %}}

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se placer en position minimisée lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une zone de contenu unique plein écran plutôt que la vue normale standard à trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** indiquent l’état dans lequel la barre de séparateur verticale ou horizontale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous la diapositive, tandis qu’une barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** indiquent la taille de la zone supérieure ou latérale de la diapositive en vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration de INormalViewProperties** 

Indique la taille de la zone de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft) en vue normale, lorsque la zone possède une taille restaurée variable (ni minimisée ni maximisée).  

La propriété **DimensionSize** indique la taille de la zone de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft).  

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit être ajustée pour compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.  
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

Aspose.Slides for .NET prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation de façon à ce que, lorsqu’elle est ouverte, le zoom soit déjà appliqué. Cela peut être réalisé en définissant les [ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) d’une présentation. Les propriétés de vue de diapositive ainsi que les [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) peuvent être définies programmatique­ment. Dans ce sujet, nous verrons, à l’aide d’un exemple, comment définir les propriétés de vue d’une présentation avec Aspose.Slides.

Pour définir les propriétés de vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Définissez les View Properties de la présentation
3. Enregistrez la présentation sous forme de fichier PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue des notes.  
```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Définir les propriétés de vue de la présentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valeur du zoom en pourcentage pour la vue notes 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/slideviewproperties/)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lorsqu’il est ouvert.

**Puis‑je pré‑définir des états de vue différents pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue pré‑définies afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Puisque les [view properties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.