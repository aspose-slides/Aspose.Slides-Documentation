---
title: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /fr/androidjava/render-a-slide-as-an-svg-image/
---

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou apparence.

SVG est l'un des rares formats d'images qui respecte des normes très élevées en termes de : évolutivité, interactivité, performance, accessibilité, programmabilité, et autres. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous souhaiterez peut-être utiliser des fichiers SVG lorsque vous avez besoin de

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et des tableaux de vos diapositives dans *différents supports ou plateformes*.* La plupart des lecteurs peuvent interpréter les fichiers SVG.
- **utiliser les *tailles d'images les plus petites possibles*.* Les fichiers SVG sont généralement plus petits que leurs équivalents haute résolution dans d'autres formats, en particulier ceux basés sur des images bitmap (JPEG ou PNG).

Aspose.Slides pour Android via Java vous permet d'exporter des diapositives de vos présentations en tant qu'images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. itérez à travers toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileOutputStream.

{{% alert color="primary" %}} 

Vous souhaiterez peut-être essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour Android via Java.

{{% /alert %}} 

Ce code d'exemple en Java vous montre comment convertir PPT en SVG en utilisant Aspose.Slides :

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```