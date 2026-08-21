---
title: Gérer les repères de dessin dans les présentations en .NET
linktitle: Repères de dessin
type: docs
weight: 85
url: /fr/net/drawing-guides/
keywords:
- repère de dessin
- repère horizontal
- repère vertical
- repère d'alignement
- vue de diapositive
- diapositive maître
- diapositive de disposition
- masque de notes
- masque de prospectus
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajouter, accéder et supprimer les repères de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Les repères de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière cohérente lors de la modification d'une présentation dans PowerPoint. Ils sont particulièrement utiles lorsqu'une application génère une présentation qui sera ensuite affinée manuellement : l'application peut enregistrer les mêmes aides à l'alignement que les auteurs doivent suivre lors de l'ajout ou du déplacement de contenu.

Les repères de dessin sont des aides à l'édition, pas du contenu de diapositive. Ils n'apparaissent pas dans un diaporama ni dans la sortie rendue. Aspose.Slides for .NET les expose via l'interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguidescollection/). Un repère est représenté par [IDrawingGuide](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points à partir du coin supérieur gauche de la diapositive ou du masque concerné. Un repère vertical utilise une coordonnée horizontale, généralement comprise entre zéro et la largeur de la diapositive. Un repère horizontal utilise une coordonnée verticale, généralement comprise entre zéro et la hauteur de la diapositive.

## **Ajouter des repères à la vue diapositive**

Utilisez [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/fr/net/aspose.slides/icommonslideviewproperties/drawingguides/) pour gérer les repères affichés lors de la modification des diapositives normales. Appelez [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguidescollection/add/) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/net/aspose.slides/orientation/) et une position en points.

L'exemple suivant ajoute un repère vertical à droite du centre de la diapositive et un repère horizontal en dessous :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **Accéder aux repères de dessin**

La propriété [IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguidescollection/count/) et l'indexeur permettent d'accéder aux repères existants. Les propriétés [IDrawingGuide.Orientation](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguide/position/) et [IDrawingGuide.Color](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguide/color/) peuvent être lues ou modifiées.

L'exemple suivant lit les repères de la vue diapositive à partir de la présentation créée ci-dessus :

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **Ajouter des repères au masque et aux diapositives de disposition**

Un masque de diapositive et chacune de ses diapositives de disposition peuvent posséder leurs propres collections de repères de dessin. Utilisez [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterslide/drawingguides/) pour un masque de diapositive et [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/fr/net/aspose.slides/ilayoutslide/drawingguides/) pour une diapositive de disposition.

L'exemple suivant ajoute un repère vertical à la première diapositive maître et un repère horizontal à la première diapositive de disposition :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Ajouter des repères aux masques de notes et de prospectus**

Les masques de notes et les masques de prospectus prennent également en charge les repères de dessin. Utilisez [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslide/drawingguides/) et [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterhandoutslide/drawingguides/) pour accéder à leurs collections. Si une présentation ne contient pas l'un de ces masques, [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) ou [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) crée le masque par défaut et le renvoie.

L'exemple suivant ajoute un repère horizontal à un masque de notes et un repère vertical à un masque de prospectus :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **Effacer les repères de dessin**

Appelez [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/idrawingguidescollection/clear/) pour supprimer tous les repères d'une collection donnée. La suppression d'une collection n'affecte pas les repères stockés dans un autre domaine.

L'exemple suivant efface les repères de la vue diapositive ainsi que tous les repères sur les masques de diapositive, les diapositives de disposition, le masque de notes et le masque de prospectus sans créer les masques manquants :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Les repères de dessin apparaissent-ils dans un diaporama ou sur des images exportées ?**

Non. Les repères de dessin sont des aides à l'alignement pour l'édition et ne sont pas rendus comme contenu de la présentation.

**Un repère de dessin peut‑il être ajouté directement à une diapositive normale individuelle ?**

Les repères d'édition des diapositives normales sont stockés dans les propriétés de vue diapositive de la présentation. Des collections de repères séparées sont disponibles pour les masques de diapositives, les diapositives de disposition, les masques de notes et les masques de prospectus.

**Quelles unités sont utilisées pour les positions des repères ?**

Les positions sont spécifiées en points, où 72 points correspondent à un pouce. Les positions verticales sont mesurées à partir du bord gauche, et les positions horizontales à partir du bord supérieur.

**La suppression des repères de dessin supprime‑t‑elle des formes ou modifie le contenu de la diapositive ?**

Non. La méthode `Clear` supprime uniquement les repères de la collection sélectionnée. Les formes et les autres contenus de la diapositive restent inchangés.