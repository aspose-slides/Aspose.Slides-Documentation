---
title: Créer des miniatures de formes de présentation en .NET
linktitle: Miniatures de formes
type: docs
weight: 70
url: /fr/net/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- limites visuelles
- limites de forme
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Générez des miniatures de formes de haute qualité à partir de diapositives PowerPoint avec Aspose.Slides pour .NET – créez et exportez facilement des miniatures de présentations."
---
## **Introduction**

Aspose.Slides for .NET est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans ces cas, Aspose.Slides for .NET vous aide à générer des images miniatures des formes de diapositive. La façon d'utiliser cette fonctionnalité est décrite dans cet article.

Cet article explique comment générer des miniatures de diapositive de différentes manières :

- Générer une miniature de forme à l'intérieur d'une diapositive.
- Générer une miniature de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature de forme dans les limites de l'apparence d'une forme.

## **Générer une miniature de forme à partir d'une diapositive**
Pour générer une miniature de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides for .NET :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de forme de la diapositive référencée à l'échelle par défaut.
1. Enregistrer l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une miniature de forme.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Générer une miniature avec facteur d'échelle défini par l'utilisateur**
Pour générer la miniature de forme de n'importe quelle forme de diapositive en utilisant Aspose.Slides for .NET :

1. Créer une instance de la classe `Presentation`.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de la forme.
1. Enregistrer l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous génère une miniature avec un facteur d'échelle défini par l'utilisateur.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Mise à l'échelle le long des axes X et Y.
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Créer une miniature d'apparence de forme basée sur les limites**
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est restreinte par les limites de la diapositive. Pour générer une miniature de n'importe quelle forme de diapositive dans les limites de son apparence, utilisez le code d'exemple suivant :

1. Créer une instance de la classe `Presentation`.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de forme en tant qu'apparence.
1. Enregistrer l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous crée une miniature en générant une miniature avec un facteur d'échelle défini par l'utilisateur.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Mise à l'échelle le long des axes X et Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Obtenir les limites visuelles réelles d'une forme**

Les propriétés de cadre de [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/) — ses propriétés `X`, `Y`, `Width` et `Height` — décrivent le rectangle stocké dans le modèle de présentation. Le contenu réellement rendu peut s'étendre au-delà de ce cadre ou occuper un rectangle aligné différemment. La rotation, les contours, les pointes de flèches, la mise en page et le dépassement du texte, la géométrie SmartArt générée et d'autres effets de rendu peuvent tous modifier la zone occupée.

Utilisez [GetVisualBounds](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getvisualbounds/) pour calculer cette zone occupée sans créer d'image. La méthode renvoie un [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) en coordonnées de diapositive. Le rectangle renvoyé n'est pas découpé à la diapositive, ses coordonnées peuvent donc être négatives lorsque le contenu dépasse l'origine de la diapositive.

[GetVisualBounds](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getvisualbounds/) n'est actuellement pas déclaré par l'interface [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/). Par conséquent, conservez la forme obtenue à partir de la collection de formes de la diapositive en tant que valeur d'interface et effectuez le cast uniquement lors de l'appel de la méthode.

L'exemple suivant obtient et compare le cadre et les limites visuelles :

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Le même [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) peut être utilisé pour aligner les formes à proximité sur son bord `Left`, `Right`, `Top` ou `Bottom`; réserver suffisamment d'espace dans une mise en page générée; ou détecter du contenu en dehors d'une région autorisée. Les limites visuelles sont particulièrement utiles pour SmartArt, les zones de texte, les flèches, les images, les formes tournées et les formes groupées, où le cadre stocké peut ne pas représenter le résultat rendu complet.

Utilisez [GetVisualBounds](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getvisualbounds/) lorsque vous avez besoin de coordonnées pour la mise en page ou la validation et que vous n'avez pas besoin d'un bitmap. Utilisez [IShape.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/getimage/) lorsque vous devez rendre la forme. Avec [ShapeThumbnailBounds](https://reference.aspose.com/slides/fr/net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` dimensionne l'image à partir des limites de la forme, y compris les paramètres de contour, tandis que `ShapeThumbnailBounds.Appearance` la dimensionne à partir de l'apparence de la forme et restreint le résultat aux limites de la diapositive. En revanche, [GetVisualBounds](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/getvisualbounds/) ne renvoie que le rectangle calculé et ne le découpe pas à la diapositive.

## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées en tant que SVG vectoriel](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d'une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/net/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme masquée ? Sera-t-elle toujours rendue en miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, les graphiques, SmartArt et d'autres objets complexes sont-ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/fr/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/chart/) et [SmartArt](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/smartart/)) peut être enregistré en tant que miniature ou en tant que SVG.

**Les polices installées sur le système affectent-elles la qualité des miniatures pour les formes de texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/net/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/net/font-substitution/)) pour éviter les rétrogradations indésirables et le réarrangement du texte.