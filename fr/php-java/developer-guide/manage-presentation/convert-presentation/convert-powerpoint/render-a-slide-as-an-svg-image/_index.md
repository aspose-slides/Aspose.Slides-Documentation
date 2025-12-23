---
title: Rendre les diapositives de présentation en images SVG avec PHP
linktitle: Diapositive vers SVG
type: docs
weight: 50
url: /fr/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint vers SVG
- présentation vers SVG
- diapositive vers SVG
- PPT vers SVG
- PPTX vers SVG
- enregistrer PPT en SVG
- enregistrer PPTX en SVG
- exporter PPT en SVG
- exporter PPTX en SVG
- rendre diapositive
- convertir diapositive
- exporter diapositive
- image vectorielle
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à rendre les diapositives PowerPoint en images SVG à l'aide d'Aspose.Slides pour PHP via Java. Des visuels de haute qualité avec des exemples de code simples."
---

## **Format SVG**

SVG—un acronyme pour Scalable Vector Graphics—est un type ou format graphique standard utilisé pour rendre des images bidimensionnelles. SVG stocke les images sous forme de vecteurs dans du XML avec des détails qui définissent leur comportement ou leur apparence. 

SVG est l’un des rares formats d’images qui répond à des exigences très élevées dans ces domaines : évolutivité, interactivité, performance, accessibilité, programmabilité, etc. Pour ces raisons, il est couramment utilisé dans le développement web. 

Vous pouvez envisager d’utiliser les fichiers SVG lorsque vous devez

- **imprimer votre présentation dans un *format très grand*.** Les images SVG peuvent s’adapter à n’importe quelle résolution ou niveau. Vous pouvez redimensionner les images SVG autant de fois que nécessaire sans sacrifier la qualité.
- **utiliser les graphiques et diagrammes de vos diapositives sur *différents supports ou plateformes*.** La plupart des visualiseurs peuvent interpréter les fichiers SVG. 
- **utiliser les *tailles d’image les plus petites possibles*.** Les fichiers SVG sont généralement plus légers que leurs équivalents haute résolution dans d’autres formats, notamment les formats basés sur le bitmap (JPEG ou PNG).

## **Rendre une diapositive en tant qu’image SVG**

Aspose.Slides for PHP via Java vous permet d’exporter les diapositives de vos présentations sous forme d’images SVG. Suivez ces étapes pour générer des images SVG :

1. Créez une instance de la classe Presentation.
2. Parcourez toutes les diapositives de la présentation.
3. Écrivez chaque diapositive dans son propre fichier SVG à l’aide de FileOutputStream.

{{% alert color="primary" %}} 

Vous pouvez essayer notre [application web gratuite](https://products.aspose.app/slides/conversion/ppt-to-svg) dans laquelle nous avons implémenté la fonction de conversion PPT vers SVG d’Aspose.Slides for PHP via Java.

{{% /alert %}} 

Ce code d’exemple vous montre comment convertir un PPT en SVG en utilisant Aspose.Slides :
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


## **FAQ**

**Pourquoi le SVG résultant peut-il apparaître différemment selon les navigateurs ?**

La prise en charge de certaines fonctionnalités SVG est implémentée différemment par les moteurs de navigateur. Les paramètres de [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) aident à lisser les incompatibilités.

**Est-il possible d’exporter non seulement les diapositives mais aussi des formes individuelles au format SVG ?**

Oui. Toute [forme peut être enregistrée en tant que SVG séparé](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/), ce qui est pratique pour les icônes, pictogrammes et la réutilisation de graphiques.

**Peut-on combiner plusieurs diapositives en un seul SVG (bande/document) ?**

Le scénario standard est une diapositive → un SVG. Combiner plusieurs diapositives en un seul canevas SVG constitue une étape de post‑traitement effectuée au niveau de l’application.