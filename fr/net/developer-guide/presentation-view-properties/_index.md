---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en .NET
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/net/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- ancrer le séparateur vertical
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
description: "Découvrez les propriétés de vue d'Aspose.Slides pour .NET afin de personnaliser les formats PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Des propriétés concernant le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer son état de vue dans le fichier, de sorte que, lorsqu’il est rouvert, la vue se trouve dans le même état que lors de la dernière sauvegarde de la présentation.

La propriété [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/iviewproperties/properties/normalviewproperties) a été ajoutée pour fournir un accès aux propriétés de la vue normale de la présentation.  

[INormalViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/inormalviewrestoredproperties), interfaces et leurs descendants, l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/net/aspose.slides/splitterbarstatetype) ont été ajoutés.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lorsqu’elle montre le contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une zone de contenu unique en plein écran plutôt que la vue normale standard à trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des zones de contenu sur toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont :**SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** indiquent la taille de la zone supérieure ou latérale de la diapositive dans la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement à **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration d’INormalViewProperties**

Spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft) de la vue normale, lorsque la zone a une taille restaurée variable (ni réduite ni agrandie).  

La propriété **DimensionSize** indique la taille de la zone de diapositive (largeur lorsqu’elle est enfant de restoredTop, hauteur lorsqu’elle est enfant de restoredLeft).  

La propriété **AutoAdjust** indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.  

Un exemple ci‑dessus montre comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides pour .NET prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation de sorte que, lorsqu’elle est ouverte, le zoom soit déjà appliqué. Cela peut se faire en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties) d’une présentation. Les propriétés de vue de diapositive ainsi que les [NotesViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/properties/notesviewproperties) peuvent être réglées par programme. Dans ce sujet, nous verrons avec un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation)
1. Définir les [Properties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties) de vue de la présentation
1. Enregistrer la présentation au format PPTX

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Définir les propriétés de vue de la présentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valeur du zoom en pourcentage pour la vue des notes 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) pour accéder aux paramètres de vue à l’échelle de la présentation. La propriété [IViewProperties.GridSpacing](https://reference.aspose.com/slides/fr/net/aspose.slides/iviewproperties/gridspacing/) lit ou modifie l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, comme le requiert la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche son espacement de grille actuel, définit un intervalle d’un quart de pouce et enregistre le résultat.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");
var gridSpacing = presentation.ViewProperties.GridSpacing;
Console.WriteLine($"Current grid spacing: {gridSpacing} points");

presentation.ViewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

La grille est différente des [drawing guides](/slides/fr/net/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin ne modifie pas l’espacement de la grille.

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou un diaporama. Enregistrer l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après la réouverture de la présentation ?**  
Le fichier stocke l’espacement de la grille, mais c’est l’éditeur qui décide si la grille est affichée. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**  
Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  
Les [view settings](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/slideviewproperties/)), pas par section, ainsi un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je prédéfinir des états de vue différents pour différents utilisateurs ?**  
Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent respecter les préférences des utilisateurs, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés de vue.

**Puis‑je préparer un modèle avec des View Properties prédéfinies afin que les nouvelles présentations s’ouvrent de la même façon ?**  
Oui. Comme les [view properties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.