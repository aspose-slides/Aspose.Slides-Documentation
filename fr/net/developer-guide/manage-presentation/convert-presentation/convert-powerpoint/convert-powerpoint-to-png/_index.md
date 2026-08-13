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
## **Vue d’ensemble**

Cet article explique comment convertir des présentations PowerPoint en images PNG à l’aide d’Aspose.Slides. Il montre comment charger des fichiers de présentation dans des formats tels que PPT, PPTX et ODP, rendre les diapositives sous forme d’images et enregistrer les résultats au format PNG.

L’article montre également comment personnaliser les images PNG générées en définissant des valeurs d’échelle ou en spécifiant la largeur et la hauteur souhaitées.

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Récupérez l’objet diapositive depuis la collection [Presentation.Slides](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/properties/slides) via l’interface [ISlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide).
3. Utilisez la méthode [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/) pour rendre chaque diapositive à l’échelle souhaitée.
4. Utilisez la méthode [IPresentation.Save(String,SaveFormat,ISaveOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.ipresentation/save/methods/5) pour enregistrer la vignette de la diapositive au format PNG.

Ce code C# montre comment convertir une présentation PowerPoint en PNG. L’objet Presentation peut charger PPT, PPTX, ODP, etc., puis chaque diapositive de l’objet présentation est convertie au format PNG ou à d’autres formats d’image.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 

**Remarque :** Les arguments d’échelle `1f, 1f` rendent chaque diapositive à sa taille réelle, ainsi une diapositive de 720×540 pt produit une image de 720×540 px. La surcharge sans paramètres de [GetImage()](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/) renvoie une vignette d’aperçu beaucoup plus petite.

{{% /alert %}} 

## **Convertir PowerPoint en PNG avec dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG à une certaine échelle, vous pouvez définir les valeurs pour `desiredX` et `desiredY`, qui déterminent les dimensions de la vignette résultante.

Ce code C# illustre l’opération décrite :

```c#
using Aspose.Slides;

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

Si vous souhaitez obtenir des fichiers PNG à une taille précise, vous pouvez passer vos arguments `width` et `height` préférés pour `imageSize`.

Ce code montre comment convertir un PowerPoint en PNG tout en spécifiant la taille des images :

```c#
using System.Drawing;
using Aspose.Slides;

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

### Comment exporter uniquement une forme spécifique (par ex., un graphique ou une image) plutôt que la diapositive entière ?

Aspose.Slides prend en charge la [génération de vignettes pour des formes individuelles](/slides/fr/net/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

### La conversion parallèle est‑elle prise en charge sur un serveur ?

Oui, mais [ne partagez pas](/slides/fr/net/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

### Quelles sont les limitations de la version d’évaluation lors de l’exportation en PNG ?

Le mode d’évaluation ajoute un filigrane aux images produites et impose [d’autres restrictions](/slides/fr/net/licensing/) jusqu’à ce qu’une licence soit appliquée.