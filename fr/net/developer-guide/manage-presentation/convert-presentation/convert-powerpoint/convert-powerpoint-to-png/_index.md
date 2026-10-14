---
title: Convertir les diapositives PowerPoint en PNG avec .NET
linktitle: PowerPoint en PNG
type: docs
weight: 30
url: /fr/net/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- enregistrer PPT en PNG
- enregistrer PPTX en PNG
- exporter PPT en PNG
- exporter PPTX en PNG
- .NET
- C#
- Aspose.Slides
description: "Convertir rapidement des présentations PowerPoint en images PNG de haute qualité avec Aspose.Slides pour .NET, garantissant des résultats précis et automatisés."
---
## **Vue d'ensemble**

Cet article explique comment convertir des diapositives de présentation en images PNG à l'aide d'Aspose.Slides pour .NET. Vous pouvez charger des présentations dans des formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l'enregistrer en tant qu'image PNG distincte.

Les exemples ci-dessous montrent le rendu de miniatures, la définition des facteurs d'échelle, la spécification des dimensions de sortie en pixels et le choix d'un style de rendu de dégradé.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) et accédez à ses diapositives via la collection [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). L'exemple rend chaque diapositive avec [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) sans paramètres pour créer une miniature. Il appelle ensuite [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) avec [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) pour enregistrer chaque diapositive rendue en tant qu'image PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
La surcharge sans paramètre de [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) rend à une échelle de 0,2. Par exemple, une diapositive mesurant 720 × 540 points produit une miniature de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d'échelle ou une taille d'image explicite ci-dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez des facteurs d'échelle horizontaux et verticaux à [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont égaux à 2, ainsi une diapositive mesurant 720 × 540 points produit une image de 1440 × 1080 pixels. Des facteurs d'échelle égaux conservent le rapport d'aspect de la diapositive. Chaque image est enregistrée au format PNG avec [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, transmettez une taille à [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) au lieu des facteurs d'échelle. Cet exemple rend chaque diapositive à 960 × 720 pixels et enregistre le résultat avec [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Choisissez des dimensions qui correspondent au rapport d'aspect de la diapositive afin d'éviter d'étirer l'image.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Choisir un style de rendu de dégradé**

Supposons qu'une diapositive contienne des remplissages en dégradé, mais que les transitions dans le PNG exporté apparaissent plus claires ou autrement différentes de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la propriété [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) de [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) pour choisir la façon dont les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez-le dans le répertoire de travail de l'application. Sa première diapositive contient deux dégradés linéaires : du cyan à l'orange en haut et du bleu au jaune en bas. Chaque dégradé possède deux arrêts, à 0 % et 100 %.

L'exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Dégradés cyan à orange et bleu à jaune rendus avec Default](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `Default` produit des couleurs intermédiaires plus claires, tandis que `PowerPointUI` produit des couleurs intermédiaires plus sombres. La différence dépend des couleurs et des arrêts dans le dégradé.

Choisissez `Default` lorsque la sortie standard d'Aspose.Slides correspond à vos besoins. Essayez `PowerPointUI` si votre priorité est de reproduire l'apparence dans PowerPoint. Comparez les deux sorties avec le résultat souhaité ; aucun des deux modes n'est universellement préférable.

## **FAQ**

**Comment puis-je exporter une forme spécifique, telle qu'un graphique ou une image, au lieu de toute la diapositive ?**

Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/net/create-shape-thumbnails/), vous permettant de rendre une forme sous forme d'image PNG.

**La conversion parallèle est-elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque fil d'exécution ou processus ; [ne partagez pas une même instance entre les fils](/slides/fr/net/multithreading/).

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**

Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/net/licensing/) jusqu'à ce qu'une licence soit appliquée.