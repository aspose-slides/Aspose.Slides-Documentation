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
- séparateur vertical à enclenchement
- vue unique
- état de la barre
- taille de dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Utilisez Aspose.Slides pour .NET afin de configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive s'affiche entre un volet latéral contenant des miniatures ou un plan et un volet de notes en dessous. Aspose.Slides for .NET expose les préférences d'édition enregistrées de la présentation via [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/). Elles comprennent la disposition des volets, les niveaux de zoom, l'espacement de la grille et la visibilité des commentaires.

## **À propos de INormalViewProperties**

Utilisez [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) pour accéder à l'interface [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/). [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) contrôle si des icônes apparaissent à côté des titres de diapositives dans le plan. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) permet au volet latéral de s'enclencher à son état minimisé lorsque l'utilisateur le rétrécit. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) indique une préférence pour l'affichage d'un seul volet dans la fenêtre entière.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) contrôle le séparateur entre le volet latéral et la diapositive. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) de `Minimized`, `Maximized` ou `Restored`.

## **À propos de la restauration d'INormalViewProperties**

Lorsque un séparateur est restauré, [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) fournit la taille enregistrée du volet latéral et [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) fournit la taille enregistrée de la zone supérieure de la diapositive. Les deux exposent [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/). Sa propriété [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) accepte un pourcentage de 0 à 100, et [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) contrôle si l'éditeur ajuste la taille lorsque la fenêtre est redimensionnée.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, définit [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) à 80% avec l'ajustement automatique activé, et maximise le séparateur vertical. Il active également [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) pour la vue plan.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **Définir la valeur de zoom par défaut**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) et [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) stockent des réglages de zoom indépendants pour l'éditeur. Ces réglages n'affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d'exportation des images.

Cet exemple ouvre une présentation existante et active [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) pour adapter la diapositive à la fenêtre d'édition. Pour la page de notes, il désactive le redimensionnement automatique et définit [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) à un zoom fixe de 80%.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **Définir l'espacement de la grille**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) définit la distance entre les lignes de la grille d'édition dans toute la présentation. Elle accepte une valeur positive en points, avec 72 points par pouce. Cet exemple affiche l'espacement actuel dans une présentation existante et enregistre une grille d'un quart de pouce en réglant l'intervalle à 18 points.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

La grille se répète à un intervalle fixe. [Drawing guides](/slides/fr/net/drawing-guides/) marquent des positions horizontales ou verticales individuelles. Les deux sont des aides à l'édition et n'apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations vers PDF, images ou SVG les omettent.

## **Afficher ou masquer les commentaires lors de l'ouverture d'une présentation**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) enregistre une préférence que les éditeurs compatibles utilisent lors de l'ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le réglage actuel et enregistre une copie avec les commentaires masqués. Il définit également [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) sur [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) afin que la copie s'ouvre en mode diapositive.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

Masquer les commentaires conserve leur texte, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Pour modifier les commentaires eux‑mêmes, consultez [Presentation Comments](/slides/fr/net/presentation-comments/). Les paramètres d'exportation déterminent si les commentaires apparaissent dans le PDF, le HTML, les images, les notes ou les documents de travail.

## **FAQ**

**Pourquoi la grille est‑elle masquée lorsque je rouvre la présentation ?**

La présentation enregistre l'intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l'éditeur.

**Le fait de supprimer les guides de dessin modifie‑t‑il l'espacement de la grille ?**

Non. Ajouter, déplacer ou supprimer un guide ne modifie pas l'intervalle de la grille.

**Différentes sections d'une présentation peuvent‑elles avoir des paramètres d'affichage différents ?**

Non. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) s'applique à l'ensemble de la présentation.

**Puis‑je enregistrer des paramètres d'affichage différents pour différents utilisateurs ?**

Le fichier stocke un seul jeu de propriétés d'affichage pour tous. Un éditeur peut également appliquer les préférences locales d'un utilisateur.

**Puis‑je enregistrer des paramètres d'affichage dans un modèle ?**

Oui. Les présentations créées à partir du modèle héritent de ses paramètres d'affichage enregistrés.