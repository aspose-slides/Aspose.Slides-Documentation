---
title: Récupérer et Mettre à jour les propriétés d'affichage de la présentation en .NET
linktitle: Propriétés d'affichage
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
  - OpenDocument
  - présentation
  - .NET
  - C#
  - Aspose.Slides
description: "Découvrez les propriétés d'affichage d'Aspose.Slides pour .NET afin de personnaliser les formats PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d'affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés concernent le positionnement des différentes zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lorsqu’elle est rouverte, la vue se trouve dans le même état que lorsque la présentation a été enregistrée pour la dernière fois.

Propriété [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/iviewproperties/properties/normalviewproperties) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/inormalviewrestoredproperties), ainsi que leurs descendants, l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/net/aspose.slides/splitterbarstatetype) ont été ajoutées.

## **À propos de INormalViewProperties**

Représente les propriétés de la vue normale.

La propriété **ShowOutlineIcons** indique si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

La propriété **SnapVerticalSplitter** indique si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

La propriété **PreferSingleView** indique si l’utilisateur préfère voir une région de contenu unique occupant toute la fenêtre plutôt que la vue normale standard avec trois régions de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les propriétés **VerticalBarState** et **HorizontalBarState** spécifient l’état dans lequel la barre de séparation verticale ou horizontale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, la barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** et **SplitterBarStateType.Restored**.

Les propriétés **RestoredLeft** et **RestoredTop** définissent la taille de la zone supérieure ou latérale de la diapositive de la vue normale, lorsque la valeur **SplitterBarStateType.Restored** est appliquée respectivement aux propriétés **VerticalBarState** et **HorizontalBarState**.

## **À propos de la restauration de INormalViewProperties**

Spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft) de la vue normale, lorsque la zone a une taille restaurée variable (ni minimisée ni maximisée).

La propriété **DimensionSize** spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de RestoredTop, hauteur lorsqu’elle est enfant de RestoredLeft).

La propriété **AutoAdjust** indique si la taille de la zone de contenu latéral doit s’ajuster à la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple est fourni ci‑dessous montrant comment accéder aux propriétés **ViewProperties.NormalViewProperties** d’une présentation.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Restaurer les propriétés d'affichage de la présentation
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Définir la valeur de zoom par défaut**

Aspose.Slides for .NET prend désormais en charge la définition de la valeur de zoom par défaut d’une présentation, de sorte que le zoom soit déjà appliqué lors de l’ouverture de la présentation. Cela peut être fait en définissant les [ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties) d’une présentation. Les propriétés de la vue de diapositive ainsi que les [NotesViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/properties/notesviewproperties) peuvent être définies par programme. Dans ce sujet, nous verrons à travers un exemple comment définir les propriétés de vue d’une présentation dans Aspose.Slides.

Pour définir les propriétés de vue, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Définissez les [Properties](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties) de vue de la présentation.
3. Enregistrez la présentation sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue de diapositive ainsi que pour la vue des notes.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Définir les propriétés d'affichage de la présentation
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Valeur de zoom en pourcentage pour la vue diapositive
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Valeur de zoom en pourcentage pour la vue notes 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) pour accéder aux paramètres de vue au niveau de la présentation. La propriété [IViewProperties.GridSpacing](https://reference.aspose.com/slides/fr/net/aspose.slides/iviewproperties/gridspacing/) lit ou modifie l’intervalle de la grille d’édition sous‑jacente. Ce paramètre s’applique à l’ensemble de la présentation, pas à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points correspondent à un pouce. Utilisez une valeur positive, conformément à la documentation de l’API.

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

La grille et les guides de dessin sont tous deux des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou un diaporama. Stocker l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **Afficher ou masquer les commentaires lors de l’ouverture d’une présentation**

Utilisez [Presentation.ViewProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) pour accéder aux paramètres de vue au niveau de la présentation. Lisez ou modifiez [IViewProperties.ShowComments](https://reference.aspose.com/slides/fr/net/aspose.slides/iviewproperties/showcomments/) pour enregistrer une préférence quant à l’affichage des commentaires lors de l’ouverture de la présentation dans PowerPoint ou un autre éditeur compatible.

Ce paramètre ne contrôle que la préférence de vue stockée. Il n’ajoute, ne supprime, ne modifie ni ne résout les commentaires. Masquer les commentaires préserve leur contenu, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Consultez [Presentation Comments](/slides/fr/net/presentation-comments/) pour les opérations qui modifient les commentaires eux‑mêmes.

L’exemple suivant nécessite un fichier `comments.pptx` existant contenant des commentaires. Il affiche le paramètre de visibilité actuel, demande que les commentaires soient masqués et enregistre un nouveau PPTX sans supprimer aucun commentaire. Il définit également [IViewProperties.LastView](https://reference.aspose.com/slides/fr/net/aspose.slides/iviewproperties/lastview/) à [ViewType.SlideView](https://reference.aspose.com/slides/fr/net/aspose.slides/viewtype/) pour configurer la vue d’édition initiale ainsi que la visibilité des commentaires.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");
var showComments = presentation.ViewProperties.ShowComments;
Console.WriteLine($"Current comment visibility: {showComments}");

presentation.ViewProperties.ShowComments = NullableBool.False;
presentation.ViewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Ce paramètre ne détermine pas si les commentaires sont inclus dans les exportations PDF, HTML, image, notes ou support. Configurez séparément les options spécifiques à chaque export.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après avoir rouvert la présentation ?**  
Le fichier stocke l’espacement de la grille, mais c’est l’éditeur qui contrôle son affichage. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**  
Non. Les guides de dessin et l’espacement de la grille sont des paramètres indépendants. Supprimer les guides ne modifie pas l’intervalle de grille stocké.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**  
Les [view settings](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/fr/net/aspose.slides/viewproperties/slideviewproperties/)), pas par section, ainsi un seul ensemble de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je prédéfinir différents états de vue pour différents utilisateurs ?**  
Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent prendre en compte les préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul jeu de propriétés de vue.

**Puis‑je préparer un modèle avec des propriétés de vue prédéfinies afin que les nouvelles présentations s’ouvrent de la même façon ?**  
Oui. Étant donné que les [view properties](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/viewproperties/) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration de vue initiale.