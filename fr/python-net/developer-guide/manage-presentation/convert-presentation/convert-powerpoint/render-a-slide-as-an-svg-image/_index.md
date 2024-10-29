---
title: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /fr/python-net/render-a-slide-as-an-svg-image/
---

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou apparence. 

SVG est l'un des rares formats d'images qui répond à de très hauts standards en termes : de scalabilité, d'interactivité, de performance, d'accessibilité, de programmabilité, et d'autres. Pour ces raisons, il est couramment utilisé dans le développement web. 

Vous pourriez vouloir utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation en un *très grand format*.** Les images SVG peuvent être mises à l'échelle à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et des diagrammes de vos diapositives sur *différents supports ou plateformes*.** La plupart des lecteurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles d'images les plus petites possibles***. Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur des bitmap (JPEG ou PNG).

Aspose.Slides pour Python via .NET vous permet d'exporter des diapositives de vos présentations en tant qu'images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileStream.

{{% alert color="primary" %}} 

Vous pourriez vouloir essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour Python via .NET.

{{% /alert %}} 

Ce code d'exemple en Python vous montre comment convertir PPT en SVG à l'aide d'Aspose.Slides :

```py
import aspose.slides as slides

# Instancier un objet Presentation qui représente un fichier de présentation 
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```