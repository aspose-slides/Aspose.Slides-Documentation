---
title: Convertir PowerPoint en PNG en C#
linktitle: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /net/convert-powerpoint-to-png/
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
description: Convertir une présentation PowerPoint en PNG en C#. Convertir PPT en PNG en C#. Convertir PPTX en PNG en C#. Convertir ODP en PNG en C#
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format PNG en utilisant C#. Il couvre les sujets suivants.

- [Convertir PowerPoint en PNG en C#](#convertir-powerpoint-en-png-en-c#)
- [Convertir PPT en PNG en C#](#convertir-powerpoint-en-png-en-c#)
- [Convertir PPTX en PNG en C#](#convertir-powerpoint-en-png-en-c#)
- [Convertir ODP en PNG en C#](#convertir-powerpoint-en-png-en-c#)
- [Convertir une diapositive PowerPoint en image en C#](#convertir-powerpoint-en-png-en-c#)

## **C# PowerPoint en PNG**

Pour le code d'exemple C# afin de convertir PowerPoint en PNG, veuillez consulter la section ci-dessous c'est-à-dire [Convertir PowerPoint en PNG](#convertir-powerpoint-en-png-en-c#). Le code peut charger un certain nombre de formats comme PPT, PPTX et ODP dans l'objet Presentation, puis enregistrer la miniature de sa diapositive au format PNG. Les autres conversions PowerPoint en image qui sont assez similaires comme JPG, BMP, TIFF et SVG sont discutées dans ces articles.

- [C# PowerPoint en JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint en BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint en TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint en SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.

{{% alert title="Astuce" color="primary" %}} Vous voudrez peut-être consulter les **Convertisseurs PowerPoint en PNG** gratuits d'Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ce sont une mise en œuvre en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez l'objet diapositive de la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) sous l'interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Utilisez une méthode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pour obtenir la miniature de chaque diapositive.
4. Utilisez la méthode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) pour enregistrer la miniature de la diapositive au format PNG.

Ce code C# vous montre comment convertir une présentation PowerPoint en PNG. L'objet Presentation peut charger PPT, PPTX, ODP, etc., puis chaque diapositive de l'objet présentation est convertie en format PNG ou dans d'autres formats d'image.

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

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine échelle, vous pouvez définir les valeurs pour `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.

Ce code en C# démontre l'opération décrite :

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

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine taille, vous pouvez passer vos arguments préférés `width` et `height` pour `imageSize`.

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille pour les images :

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