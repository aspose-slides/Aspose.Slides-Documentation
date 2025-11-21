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
- .NET
- C#
- Aspose.Slides
description: "Convertir les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour .NET, garantissant des résultats précis et automatisés."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PNG à l’aide de C#. Il couvre les sujets suivants.

- [Convertir PowerPoint en PNG en C#](#convert-powerpoint-to-png)
- [Convertir PPT en PNG en C#](#convert-powerpoint-to-png)
- [Convertir PPTX en PNG en C#](#convert-powerpoint-to-png)
- [Convertir ODP en PNG en C#](#convert-powerpoint-to-png)
- [Convertir une diapositive PowerPoint en image en C#](#convert-powerpoint-to-png)

## **PowerPoint C# en PNG**

Pour le code d’exemple C# de conversion PowerPoint en PNG, consultez la section ci‑dessous, à savoir [Convertir PowerPoint en PNG](#convert-powerpoint-to-png). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans l’objet Presentation, puis enregistrer la vignette de chaque diapositive au format PNG. Les autres conversions PowerPoint vers image, telles que JPG, BMP, TIFF et SVG, sont abordées dans ces articles.

- [C# PowerPoint en JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint en BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint en TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint en SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n’est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très utilisé.

**Cas d’utilisation :** lorsque vous avez une image complexe et que la taille n’est pas un problème, le PNG est un meilleur format d’image que le JPEG.

{{% alert title="Tip" color="primary" %}} Vous pouvez essayer les convertisseurs gratuits Aspose **PowerPoint en PNG** : [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Il s’agit d’une implémentation en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenir l’objet diapositive à partir de la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) sous l’interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Utiliser la méthode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pour obtenir la vignette de chaque diapositive.
4. Utiliser la méthode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) pour enregistrer la vignette au format PNG.

Ce code C# montre comment convertir une présentation PowerPoint en PNG. L’objet Presentation peut charger PPT, PPTX, ODP, etc., puis chaque diapositive est convertie au format PNG ou à d’autres formats d’image.
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

Si vous souhaitez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la vignette générée.

Ce code C# illustre l’opération décrite :
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

Si vous voulez obtenir des fichiers PNG d’une certaine taille, vous pouvez passer vos arguments préférés `width` et `height` pour `imageSize`.

Ce code montre comment convertir un PowerPoint en PNG en spécifiant la taille des images :
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

**Comment exporter uniquement une forme spécifique (par exemple un graphique ou une image) plutôt que la diapositive entière ?**

Aspose.Slides prend en charge la [génération de vignettes pour des formes individuelles](/slides/fr/net/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui, mais [ne partagez pas](/slides/fr/net/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

**Quelles sont les limitations de la version d’essai lors de l’exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images de sortie et applique [d’autres restrictions](/slides/fr/net/licensing/) jusqu’à ce qu’une licence soit appliquée.