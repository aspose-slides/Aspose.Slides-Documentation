---
title: Convertir PowerPoint en PNG en C#
linktitle: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /fr/net/convert-powerpoint-to-png/
keywords:
- PowerPoint en png
- ppt en png
- pptx en png
- odp en png
- PowerPoint en PNG
- PPT en PNG
- PPTX en PNG
- ODP en PNG
- C#
- Csharp
- Aspose.Slides pour .NET
description: Convertir une présentation PowerPoint en PNG avec C#. Convertir PPT en PNG avec C#. Convertir PPTX en PNG avec C#. Convertir ODP en PNG avec C#
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PNG à l'aide de C#. Il couvre les sujets suivants.

- [Convertir PowerPoint en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir PPT en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir PPTX en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir ODP en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir une diapositive PowerPoint en image avec C#](#convert-powerpoint-to-png)

## **PowerPoint C# vers PNG**

Pour le code d'exemple C# permettant de convertir PowerPoint en PNG, consultez la section ci‑dessous, à savoir [Convertir PowerPoint en PNG](#convert-powerpoint-to-png). Le code peut charger de nombreux formats comme PPT, PPTX et ODP dans l'objet Presentation, puis enregistrer la vignette de chaque diapositive au format PNG. Les autres conversions PowerPoint vers image, similaires, comme JPG, BMP, TIFF et SVG sont présentées dans les articles suivants.

- [C# PowerPoint vers JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint vers BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint vers TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint vers SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi répandu que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.

**Cas d'utilisation :** lorsqu'une image est complexe et que la taille n’est pas un problème, le PNG constitue un meilleur format que le JPEG.

{{% alert title="Tip" color="primary" %}} Vous pouvez essayer les convertisseurs gratuits Aspose **PowerPoint vers PNG** : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils représentent une implémentation fonctionnelle du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenir l'objet diapositive à partir de la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) via l'interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Utiliser la méthode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pour récupérer la vignette de chaque diapositive.
4. Utiliser la méthode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) pour enregistrer la vignette au format PNG.

Ce code C# montre comment convertir une présentation PowerPoint en PNG. L'objet Presentation peut charger PPT, PPTX, ODP, etc., puis chaque diapositive est convertie au format PNG ou vers d’autres formats d’image.
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG selon une certaine échelle, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la vignette résultante.

Ce code C# démontre l'opération décrite :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **Convertir PowerPoint en PNG avec une taille personnalisée**

Si vous désirez obtenir des fichiers PNG d’une taille précise, vous pouvez fournir vos arguments préférés `width` et `height` pour `imageSize`.

Ce code montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```


## **FAQ**

**Comment exporter uniquement une forme spécifique (par exemple, un graphique ou une image) au lieu de toute la diapositive ?**

Aspose.Slides prend en charge [la génération de vignettes pour des formes individuelles](/slides/fr/net/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui, mais [ne partagez pas](/slides/fr/net/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images générées et impose [d'autres restrictions](/slides/fr/net/licensing/) jusqu’à l’application d’une licence.