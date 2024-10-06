---
title: Propriétés de la vue de présentation
type: docs
url: /net/presentation-view-properties/
keywords: "visionneuse PowerPoint, propriétés de la visionneuse, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Propriétés de la visionneuse de présentation PowerPoint en C# ou .NET"
---

{{% alert color="primary" %}} 

La vue normale se compose de trois régions de contenu : la diapositive elle-même, une région de contenu latéral et une région de contenu inférieure. Propriétés relatives au positionnement des différentes régions de contenu. Ces informations permettent à l'application de sauvegarder son état de vue dans le fichier, de sorte que lorsqu'il est rouvert, la vue est dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

La propriété [**IViewProperties.NormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/properties/normalviewproperties) a été ajoutée pour fournir un accès aux propriétés de vue normale de la présentation. 

Les interfaces [**INormalViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties), [**INormalViewRestoredProperties**](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties) et ses descendants, l'énumération [**SplitterBarStateType**](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype) ont été ajoutés.

{{% /alert %}} 

## **À propos des INormalViewProperties** #

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** spécifie si l'application doit afficher des icônes lors de l'affichage du contenu en plan dans l'une des régions de contenu du mode de vue normale.

La propriété **SnapVerticalSplitter** spécifie si le séparateur vertical doit se fixer à un état minimisé lorsque la région latérale est suffisamment petite.

La propriété **PreferSingleView** spécifie si l'utilisateur préfère voir une région de contenu unique en pleine fenêtre plutôt que la vue normale standard avec trois régions de contenu. Si activé, l'application peut choisir d'afficher l'une des régions de contenu dans toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l'état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la région de contenu en dessous de la diapositive, la barre de séparation verticale sépare la diapositive de la région de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored.**

Les propriétés **RestoredLeft** et **RestoredTop** spécifient la taille de la région de diapositive supérieure ou latérale de la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée pour **VerticalBarState** et **HorizontalBarState** respectivement.

## **À propos des INormalViewRestoredProperties** #

Spécifie la taille de la région de diapositive ((largeur lorsqu'elle est un enfant de RestoredTop, hauteur lorsqu'elle est un enfant de RestoredLeft) de la vue normale, lorsque la région est de taille restaurée variable (ni minimisée ni maximisée).

La propriété **DimensionSize** spécifie la taille de la région de diapositive (largeur lorsqu'elle est un enfant de restoredTop, hauteur lorsqu'elle est un enfant de restoredLeft).

La propriété **AutoAdjust** spécifie si la taille de la région de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l'application.

Un exemple ci-dessous montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** pour une présentation.

```c#
//Instancier un objet de présentation qui représente un fichier de présentation
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Définir la valeur de zoom par défaut**
Aspose.Slides pour .NET prend maintenant en charge la définition de la valeur de zoom par défaut pour la présentation de sorte que lorsque la présentation est ouverte, le zoom est déjà défini. Cela peut être réalisé en définissant les [**ViewProperties**](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) d'une présentation. Les propriétés de vue de diapositive ainsi que les [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties/properties/notesviewproperties) peuvent être définies par programmation. Dans ce sujet, nous allons voir avec un exemple comment définir les propriétés de vue de la présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
1. Définissez les [Properties](https://reference.aspose.com/slides/net/aspose.slides/viewproperties) de la présentation
1. Écrivez la présentation en tant que fichier PPTX

Dans l'exemple ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue de notes.

```c#
// Instancier un objet de présentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Définir les propriétés de vue de la présentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valeur de zoom en pourcentages pour la vue de diapositive
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valeur de zoom en pourcentages pour la vue de notes 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Définir les propriétés de vue**
Pour définir les propriétés de vue, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Définissez les propriétés de vue de la présentation.
1. Écrivez la présentation en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue de notes.

```c#
// Instancier un objet de présentation qui représente un fichier de présentation
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Définir les propriétés de vue de la présentation

    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valeur de zoom en pourcentages pour la vue de diapositive
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valeur de zoom en pourcentages pour la vue de notes 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```