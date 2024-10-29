---
title: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /fr/net/render-slide-as-svg-image/
---

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images deux dimensions. SVG stocke les images sous forme de vecteurs dans XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l'un des rares formats pour les images qui répondent à des normes très élevées en termes de : évolutivité, interactivité, performance, accessibilité, programmabilité, et d'autres. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous voudrez peut-être utiliser des fichiers SVG dans ces scénarios :

- lorsque vous prévoyez d'imprimer votre présentation dans un format très grand. Les images SVG peuvent être redimensionnées à toute résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans compromettre la qualité.
- lorsque vous avez l'intention d'utiliser des graphiques et des diagrammes de vos diapositives sur différents supports ou plates-formes. La plupart des lecteurs peuvent interpréter les fichiers SVG.
- lorsque vous devez utiliser les tailles d'images les plus petites possibles. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur des bitmap (JPEG ou PNG).

Aspose.Slides pour .NET vous permet d'exporter des diapositives de vos présentations en tant qu'images **SVG**. Pour générer une image SVG à partir de n'importe quelle diapositive, procédez comme suit :

- Créez une instance de la classe Presentation.
- Parcourez toutes les diapositives de la présentation.
- Écrivez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous voudrez peut-être essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour .NET.

{{% /alert %}} 

Ce code exemple en C# vous montre comment convertir PPT en SVG en utilisant Aspose.Slides :

``` csharp
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