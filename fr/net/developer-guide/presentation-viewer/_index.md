---
title: Créer un visionneur de présentation en C#
linktitle: Visionneur de présentation
type: docs
weight: 50
url: /fr/net/presentation-viewer/
keywords:
- voir la présentation
- visionneur de présentation
- créer un visionneur de présentation
- voir PPT
- voir PPTX
- voir ODP
- PowerPoint
- OpenDocument
- C#
- Csharp
- Aspose.Slides for .NET
description: "Apprenez à créer un visionneur de présentation personnalisé en .NET avec Aspose.Slides. Affichez facilement les fichiers PowerPoint (PPTX, PPT) et OpenDocument (ODP) sans Microsoft PowerPoint ni autre logiciel de bureautique."
---

## **Vue d'ensemble**

Aspose.Slides pour .NET est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être visualisées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, les développeurs peuvent parfois avoir besoin de visualiser les diapositives sous forme d'images dans leur visionneuse d'images préférée ou de les utiliser dans un visionneur de présentation personnalisé. Dans de tels cas, Aspose.Slides vous permet d'exporter des diapositives individuelles sous forme d'images. Cet article explique comment procéder.

## **Générer une image SVG à partir d'une diapositive**

Pour générer une image SVG à partir d'une diapositive de présentation avec Aspose.Slides, suivez les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence à la diapositive par son indice.
1. Ouvrir un flux de fichier.
1. Enregistrer la diapositive sous forme d'image SVG dans le flux de fichier.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream);
    }
}
```


## **Générer un SVG avec un ID de forme personnalisé**

Aspose.Slides peut être utilisé pour générer un [SVG](https://docs.fileformat.com/page-description-language/svg/) à partir d'une diapositive avec un `ID` de forme personnalisé. Pour ce faire, utilisez la propriété Id de l'interface [ISvgShape](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape). La classe `CustomSvgShapeFormattingController` peut être utilisée pour définir l'ID de la forme.
```c#
int slideIndex = 0;

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];
    
    SVGOptions svgOptions = new SVGOptions
    {
        ShapeFormattingController = new CustomSvgShapeFormattingController()
    };

    using (FileStream svgStream = File.Create("output.svg"))
    {
        slide.WriteAsSvg(svgStream, svgOptions);
    }
}
```

```c#
class CustomSvgShapeFormattingController : ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.Id = string.Format("shape-{0}", m_shapeIndex++);
    }
}
```


## **Créer une image miniature d'une diapositive**

Aspose.Slides vous aide à générer des images miniatures de diapositives. Pour générer une miniature d'une diapositive avec Aspose.Slides, suivez les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence à la diapositive par son indice.
1. Créer une image miniature de la diapositive référencée à l'échelle souhaitée.
1. Enregistrer l'image miniature dans le format d'image de votre choix.
```c#
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(scaleX, scaleY))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Créer une miniature de diapositive avec des dimensions définies par l'utilisateur**

Pour créer une image miniature de diapositive avec des dimensions définies par l'utilisateur, suivez les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence à la diapositive par son indice.
1. Générer une image miniature de la diapositive référencée avec les dimensions spécifiées.
1. Enregistrer l'image miniature dans le format d'image de votre choix.
```c#
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("sample.odp"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(slideSize))
    {
        image.Save("output.jpg", ImageFormat.Jpeg);
    }
}
```


## **Créer une miniature de diapositive avec des notes du présentateur**

Pour générer une miniature d'une diapositive avec des notes du présentateur à l'aide d'Aspose.Slides, suivez les étapes ci-dessous :

1. Créer une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/).
1. Utiliser la propriété `RenderingOptions.SlidesLayoutOptions` pour définir la position des notes du présentateur.
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenir une référence à la diapositive par son indice.
1. Générer une image miniature de la diapositive référencée en utilisant les options de rendu.
1. Enregistrer l'image miniature dans le format d'image de votre choix.
```c#
int slideIndex = 0;

RenderingOptions renderingOptions = new RenderingOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomTruncated
    }
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[slideIndex];

    using (IImage image = slide.GetImage(renderingOptions))
    {
        image.Save("output.png", ImageFormat.Png);
    }
}
```


## **Exemple en direct**

Essayez l'application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l'API Aspose.Slides :

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Puis-je intégrer un visionneur de présentation dans une application web ASP.NET ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d'images ou de HTML et les afficher dans le navigateur. Les fonctionnalités de navigation et de zoom peuvent être implémentées avec JavaScript pour une expérience interactive.

**Quelle est la meilleure façon d'afficher les diapositives dans un visionneur .NET personnalisé ?**

L'approche recommandée consiste à rendre chaque diapositive sous forme d'image (par ex. PNG ou SVG) ou à la convertir en HTML à l'aide d'Aspose.Slides, puis à afficher le résultat dans une boîte d'image (pour le bureau) ou un conteneur HTML (pour le web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour les présentations volumineuses, envisagez le chargement paresseux ou le rendu à la demande des diapositives. Cela signifie générer le contenu d'une diapositive uniquement lorsque l'utilisateur y accède, réduisant ainsi la mémoire et le temps de chargement.