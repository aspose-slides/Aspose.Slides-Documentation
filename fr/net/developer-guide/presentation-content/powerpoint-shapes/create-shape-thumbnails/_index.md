---
title: Créer des miniatures de formes de présentation dans .NET
linktitle: Miniatures de forme
type: docs
weight: 70
url: /fr/net/create-shape-thumbnails/
keywords:
- miniature de forme
- image de forme
- rendu de forme
- rendu de forme
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Générez des miniatures de forme de haute qualité à partir des diapositives PowerPoint avec Aspose.Slides pour .NET – créez et exportez facilement des miniatures de présentation."
---

Aspose.Slides for .NET est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de voir les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides for .NET vous aide à générer des images miniatures des formes de diapositive. La façon d'utiliser cette fonctionnalité est décrite dans cet article.
Cet article explique comment générer des miniatures de diapositives de différentes manières :

- Générer une miniature d’une forme à l'intérieur d’une diapositive.
- Générer une miniature d’une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une miniature d’une forme dans les limites de l’apparence de la forme.
- Générer une miniature d’un nœud enfant de SmartArt.

## **Générer une miniature de forme à partir d’une diapositive**
Pour générer une miniature de forme à partir de n'importe quelle diapositive à l'aide d'Aspose.Slides for .NET :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la forme de la diapositive référencée à l'échelle par défaut.
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


## **Générer une miniature avec facteur d’échelle défini par l'utilisateur**
Pour générer la miniature d’une forme de n'importe quelle diapositive à l'aide d'Aspose.Slides for .NET :

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
Cette méthode de création de miniatures de formes permet aux développeurs de générer une miniature dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La miniature de forme générée est limitée par les limites de la diapositive. Pour générer une miniature de n'importe quelle forme de diapositive dans les limites de son apparence, utilisez le code d'exemple suivant :

1. Créer une instance de la classe `Presentation`.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de forme en tant qu'apparence.
1. Enregistrer l'image miniature dans le format d'image souhaité.

L'exemple ci-dessous crée une miniature avec un facteur d'échelle défini par l'utilisateur.
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


## **FAQ**

**Quels formats d'image peuvent être utilisés lors de l'enregistrement des miniatures de forme ?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), et d'autres. Les formes peuvent également être [exportées en SVG vectoriel](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) en enregistrant le contenu de la forme au format SVG.

**Quelle est la différence entre les limites Shape et Appearance lors du rendu d'une miniature ?**

`Shape` utilise la géométrie de la forme ; `Appearance` prend en compte les [effets visuels](/slides/fr/net/shape-effect/) (ombres, lueurs, etc.).

**Que se passe-t-il si une forme est marquée comme masquée ? Sera-t-elle toujours rendue en miniature ?**

Une forme masquée reste partie du modèle et peut être rendue ; le drapeau masqué affecte l'affichage du diaporama mais n'empêche pas la génération de l'image de la forme.

**Les formes groupées, graphiques, SmartArt et autres objets complexes sont-ils pris en charge ?**

Oui. Tout objet représenté comme [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (y compris [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/) et [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) peut être enregistré en tant que miniature ou en SVG.

**Les polices installées sur le système affectent-elles la qualité des miniatures des formes texte ?**

Oui. Vous devez [fournir les polices requises](/slides/fr/net/custom-font/) (ou [configurer les substitutions de polices](/slides/fr/net/font-substitution/)) pour éviter les substitutions indésirables et le réarrangement du texte.