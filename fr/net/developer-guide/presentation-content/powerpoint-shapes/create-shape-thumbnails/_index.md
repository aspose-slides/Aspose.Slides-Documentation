---
title: Créer des vignettes de forme
type: docs
weight: 70
url: /fr/net/create-shape-thumbnails/
keywords: 
- vignette de forme
- image de forme
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Extraire des vignettes de forme des présentations PowerPoint en C# ou .NET"
---

Aspose.Slides pour .NET est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation avec Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides pour .NET vous aide à générer des images de vignettes des formes des diapositives. Comment utiliser cette fonctionnalité est décrit dans cet article. Cet article explique comment générer des vignettes de diapositive de différentes manières :

- Générer une vignette de forme à l'intérieur d'une diapositive.
- Générer une vignette de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une vignette de forme dans les limites de l'apparence d'une forme.
- Générer une vignette d'un nœud enfant SmartArt.


## **Générer une vignette de forme à partir d'une diapositive**
Pour générer une vignette de forme à partir de n'importe quelle diapositive en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image de vignette de la forme référencée sur l'échelle par défaut.
1. Enregistrez l'image de la vignette dans n'importe quel format d'image désiré.

L'exemple ci-dessous génère une vignette de forme.

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


## **Générer une vignette avec un facteur d'échelle défini par l'utilisateur**
Pour générer la vignette de forme de n'importe quelle forme de diapositive en utilisant Aspose.Slides pour .NET :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image de la vignette de la diapositive référencée avec les limites de la forme.
1. Enregistrez l'image de la vignette dans n'importe quel format d'image désiré.

L'exemple ci-dessous génère une vignette avec un facteur d'échelle défini par l'utilisateur.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Échelle le long des axes X et Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **Créer une vignette de l'apparence d'une forme dans ses limites**
Cette méthode de création de vignettes de formes permet aux développeurs de générer une vignette dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de forme. La vignette de forme générée est limitée par les limites de la diapositive. Pour générer une vignette de n'importe quelle forme de diapositive dans les limites de son apparence, utilisez le code exemple suivant :

1. Créez une instance de la classe `Presentation`.
1. Obtenez la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenez l'image de la vignette de la diapositive référencée avec les limites de la forme comme apparence.
1. Enregistrez l'image de la vignette dans n'importe quel format d'image désiré.

L'exemple ci-dessous crée une vignette avec un facteur d'échelle défini par l'utilisateur.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Échelle le long des axes X et Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```