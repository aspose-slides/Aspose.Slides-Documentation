---
title: Rendre une diapositive en tant qu'image SVG
type: docs
weight: 50
url: /php-java/render-a-slide-as-an-svg-image/
---

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images en deux dimensions. SVG stocke les images sous forme de vecteurs en XML avec des détails qui définissent leur comportement ou leur apparence.

SVG est l'un des rares formats d'images qui répondent à des normes très élevées en termes de : évolutivité, interactivité, performance, accessibilité, programmabilité, et autres. Pour ces raisons, il est couramment utilisé dans le développement web.

Vous pourriez vouloir utiliser des fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent être agrandies jusqu'à n'importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser des graphiques et des diagrammes de vos diapositives dans *différents supports ou plateformes***. La plupart des lecteurs peuvent interpréter les fichiers SVG.
- **utiliser les *tailles d'images les plus petites possibles***. Les fichiers SVG sont généralement plus petits que leurs équivalents en haute résolution dans d'autres formats, en particulier ceux basés sur des bitmaps (JPEG ou PNG).

Aspose.Slides pour PHP via Java vous permet d'exporter des diapositives dans vos présentations en tant qu'images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Itérez à travers toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG via FileOutputStream.

{{% alert color="primary" %}} 

Vous pourriez vouloir essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT en SVG d'Aspose.Slides pour PHP via Java.

{{% /alert %}} 

Ce code d'exemple vous montre comment convertir PPT en SVG en utilisant Aspose.Slides :

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```