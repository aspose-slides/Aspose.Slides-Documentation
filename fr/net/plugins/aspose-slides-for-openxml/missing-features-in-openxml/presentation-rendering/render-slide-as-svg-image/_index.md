---
title: Rendre la diapositive en image SVG
type: docs
weight: 50
url: /fr/net/render-slide-as-svg-image/
---
SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence. 

SVG est l’un des rares formats d’images qui répond à des normes très élevées dans ces domaines : évolutivité, interactivité, performances, accessibilité, programmabilité, et d’autres. Pour ces raisons, il est couramment utilisé en développement web. 

Vous pourriez vouloir utiliser des fichiers SVG dans les scénarios suivants :

- lorsque vous prévoyez d’imprimer votre présentation dans un format très grand. Les images SVG peuvent être agrandies à n’importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité. 
- lorsque vous avez l’intention d’utiliser des graphiques et diagrammes de vos diapositives sur différents médias ou plates‑formes. La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- lorsque vous devez utiliser les plus petites tailles possibles d’images. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d’autres formats, en particulier les formats basés sur le bitmap (JPEG ou PNG). 

Aspose.Slides for .NET vous permet d’exporter les diapositives de vos présentations en tant qu’images **SVG**. Pour générer une image SVG à partir de n’importe quelle diapositive, procédez comme suit :

- Créez une instance de la classe Presentation. 
- Parcourez toutes les diapositives de la présentation. 
- Écrivez chaque diapositive dans son propre fichier SVG via FileStream. 

{{% alert color="info" %}} 
Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/fr/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d’Aspose.Slides for .NET. 
{{% /alert %}} 

Ce code d’exemple en C# montre comment convertir un PPT en SVG à l’aide d’Aspose.Slides : 

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```