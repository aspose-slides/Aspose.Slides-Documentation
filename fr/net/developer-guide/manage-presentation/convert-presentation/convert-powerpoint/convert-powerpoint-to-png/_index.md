---
title: Convertir les diapositives PowerPoint en PNG dans .NET
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
description: "Convertissez les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour .NET, garantissant des résultats précis et automatisés."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PNG en utilisant C#. Il couvre les sujets suivants.

- [Convertir PowerPoint en PNG en C#](#convert-powerpoint-to-png)
- [Convertir PPT en PNG en C#](#convert-powerpoint-to-png)
- [Convertir PPTX en PNG en C#](#convert-powerpoint-to-png)
- [Convertir ODP en PNG en C#](#convert-powerpoint-to-png)
- [Convertir une diapositive PowerPoint en image en C#](#convert-powerpoint-to-png)

## **PowerPoint en PNG avec .NET**

Pour le code d’exemple C# qui convertit PowerPoint en PNG, voir la section ci‑dessous, c’est‑à‑dire [Convertir PowerPoint en PNG](#convert-powerpoint-to-png). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans l’objet Presentation, puis enregistrer la miniature de chaque diapositive au format PNG. Les autres conversions PowerPoint en image similaires, telles que JPG, BMP, TIFF et SVG, sont abordées dans ces articles.

- [C# PowerPoint en JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint en BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [C# PowerPoint en TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint en SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n’est pas aussi répandu que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.  

**Cas d’utilisation :** lorsqu’une image est complexe et que la taille n’est pas un problème, le PNG est un meilleur format d’image que le JPEG.  

{{% alert title="Tip" color="primary" %}} Vous pouvez consulter les convertisseurs gratuits PowerPoint en PNG d’Aspose :**PowerPoint to PNG Converters** : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils illustrent concrètement le processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Récupérer l’objet diapositive depuis la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) via l’interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Utiliser la méthode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pour obtenir la miniature de chaque diapositive.
4. Utiliser la méthode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) pour enregistrer la miniature de la diapositive au format PNG.

Ce code C# montre comment convertir une présentation PowerPoint en PNG. L’objet Presentation peut charger PPT, PPTX, ODP, etc., puis chaque diapositive est convertie au format PNG ou dans d’autres formats d’image.
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

Si vous souhaitez obtenir des fichiers PNG à une échelle précise, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.  

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

Si vous voulez obtenir des fichiers PNG d’une taille donnée, vous pouvez transmettre vos paramètres préférés `width` et `height` à `imageSize`.  

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

**Comment exporter uniquement une forme spécifique (par exemple, un graphique ou une image) plutôt que la diapositive entière ?**  
Aspose.Slides prend en charge [la génération de miniatures pour des formes individuelles](/slides/fr/net/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

**La conversion parallèle est‑elle supportée sur un serveur ?**  
Oui, mais [ne partagez pas](/slides/fr/net/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance séparée par thread ou par processus.

**Quelles sont les limitations de la version d’évaluation lors de l’exportation en PNG ?**  
Le mode d’évaluation ajoute un filigrane aux images de sortie et impose [d’autres restrictions](/slides/fr/net/licensing/) tant qu’une licence n’est pas appliquée.