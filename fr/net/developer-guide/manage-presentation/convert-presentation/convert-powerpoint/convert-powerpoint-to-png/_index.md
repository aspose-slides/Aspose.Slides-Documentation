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
description: "Convertissez les présentations PowerPoint en images PNG de haute qualité rapidement avec Aspose.Slides pour .NET, assurant des résultats précis et automatisés."
---

## **Vue d'ensemble**

Cet article explique comment convertir une présentation PowerPoint au format PNG en utilisant C#. Il couvre les sujets suivants.

- [Convertir PowerPoint en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir PPT en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir PPTX en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir ODP en PNG avec C#](#convert-powerpoint-to-png)
- [Convertir la diapositive PowerPoint en image avec C#](#convert-powerpoint-to-png)

## **PowerPoint C# vers PNG**

Pour le code d'exemple C# permettant de convertir PowerPoint en PNG, veuillez consulter la section ci‑dessus, c’est‑à‑dire [Convertir PowerPoint en PNG](#convert-powerpoint-to-png). Le code peut charger plusieurs formats tels que PPT, PPTX et ODP dans l'objet Presentation, puis enregistrer la miniature de chaque diapositive au format PNG. Les autres conversions PowerPoint vers image, similaires comme JPG, BMP, TIFF et SVG, sont abordées dans ces articles.

- [PowerPoint C# en JPG](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint C# en BMP](https://docs.aspose.com/slides/net/convert-powerpoint-to-jpg/)
- [PowerPoint C# en TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [PowerPoint C# en SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très utilisé.

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.

{{% alert title="Tip" color="primary" %}} Vous voudrez peut‑être consulter les convertisseurs gratuits **PowerPoint vers PNG** d'Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils sont une implémentation en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenir l'objet diapositive à partir de la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) via l'interface [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Utiliser la méthode [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) pour obtenir la miniature de chaque diapositive.
4. Utiliser la méthode [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5) pour enregistrer la miniature de la diapositive au format PNG.

Ce code C# vous montre comment convertir une présentation PowerPoint en PNG. L'objet Presentation peut charger PPT, PPTX, ODP, etc., puis chaque diapositive de l'objet Presentation est convertie au format PNG ou d'autres formats d'image.
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


## **Convertir PowerPoint en PNG avec dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG à une échelle précise, vous pouvez définir les valeurs de `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.

Ce code en C# illustre l'opération décrite :
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


## **Convertir PowerPoint en PNG avec taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG d'une taille précise, vous pouvez transmettre vos arguments `width` et `height` souhaités pour `imageSize`.

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :
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

**Comment puis‑je exporter uniquement une forme spécifique (par ex. un graphique ou une image) plutôt que la diapositive entière ?**  
Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/net/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**  
Oui, mais [ne partagez pas](/slides/fr/net/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**  
Le mode d'évaluation ajoute un filigrane aux images de sortie et impose [d'autres restrictions](/slides/fr/net/licensing/) jusqu'à ce qu'une licence soit appliquée.