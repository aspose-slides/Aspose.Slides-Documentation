---
title: Convertir les diapositives PowerPoint en PNG en PHP
linktitle: PowerPoint vers PNG
type: docs
weight: 30
url: /fr/php-java/convert-powerpoint-to-png/
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
- PHP
- Aspose.Slides
description: "Convertir rapidement les présentations PowerPoint en images PNG de haute qualité avec Aspose.Slides pour PHP via Java, en garantissant des résultats précis et automatisés."
---
## **Vue d'ensemble**

Cet article explique comment convertir des diapositives de présentation en images PNG en utilisant Aspose.Slides pour PHP via Java. Vous pouvez charger des présentations dans des formats tels que PPT, PPTX et ODP, rendre chaque diapositive et l’enregistrer comme une image PNG distincte.

Les exemples ci‑dessous démontrent le rendu à l’échelle par défaut, l’augmentation de l’échelle, la spécification des dimensions de sortie en pixels et le choix d’un style de rendu en dégradé.

## **Convertir PowerPoint en PNG**

Chargez une présentation avec la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) et accédez à ses diapositives via la collection [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). L’exemple rend chaque diapositive avec [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) sans paramètres pour créer une miniature. Il appelle ensuite [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) avec [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png) pour enregistrer chaque diapositive rendue en tant qu’image PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
La surcharge de [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) sans paramètres rend à une échelle de 0,2. Par exemple, une diapositive mesurant 720 × 540 points produit une miniature de 144 × 108 pixels. Pour contrôler les dimensions de sortie, utilisez les surcharges avec des facteurs d’échelle ou une taille d’image explicite indiquée ci‑dessous.
{{% /alert %}}

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Passez des facteurs d’échelle horizontaux et verticaux à [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) pour contrôler les dimensions rendues. Dans cet exemple, les deux facteurs sont 2, ainsi une diapositive mesurant 720 Г— 540 points produit une image de 1440 Г— 1080 pixels. Des facteurs d’échelle égaux conservent le ratio d’aspect de la diapositive. Chaque image est enregistrée au format PNG avec [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Pour spécifier les dimensions de sortie en pixels, passez une taille à [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) au lieu de facteurs d’échelle. Cet exemple rend chaque diapositive à 960 Г— 720 pixels et enregistre le résultat avec [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Choisissez des dimensions qui correspondent au ratio d’aspect de la diapositive afin d’éviter d’étirer l’image.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Choisir un style de rendu de dégradé**

Supposons qu’une diapositive contienne des remplissages dégradés, mais que les transitions dans le PNG exporté apparaissent plus claires ou différentes de ce que vous voyez dans PowerPoint. Vous pouvez utiliser la méthode [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) héritée par [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/) pour choisir comment les dégradés sont rendus.

Téléchargez [gradient-styles.pptx](gradient-styles.pptx) et placez-le dans le répertoire de travail de l’application. Sa première diapositive contient deux dégradés linéaires : du cyan à l’orange en haut et du bleu au jaune en bas. Chaque dégradé comporte deux arrêts, à 0 % et à 100 %.

L’exemple suivant charge cette présentation et rend la même première diapositive dans les deux modes avec [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![Dégradés cyan‑à‑orange et bleu‑à‑jaune rendus avec Default](gradient-Default.png) | ![Les mêmes dégradés rendus avec PowerPointUI](gradient-PowerPointUI.png) |

Dans cet exemple, `Default` produit des couleurs intermédiaires plus claires, tandis que `PowerPointUI` produit des couleurs intermédiaires plus sombres. La différence dépend des couleurs et des arrêts du dégradé.

Choisissez `Default` lorsque la sortie standard d’Aspose.Slides répond à vos besoins. Essayez `PowerPointUI` si votre priorité est de reproduire l’apparence de PowerPoint. Comparez les deux sorties avec le résultat souhaité ; aucun des modes n’est universellement préférable.

## **FAQ**

**Comment puis‑je exporter une forme spécifique, telle qu’un graphique ou une image, au lieu de toute la diapositive ?**

Aspose.Slides prend en charge la [génération de miniatures pour des formes individuelles](/slides/fr/php-java/create-shape-thumbnails/), vous permettant de rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui. Utilisez une instance de présentation distincte pour chaque thread ou processus ; [ne partagez pas une seule instance entre les threads](/slides/fr/php-java/multithreading/).

**Quelles sont les limitations de l’évaluation lors de l’exportation en PNG ?**

Le mode d’évaluation ajoute un filigrane aux images générées et applique [d’autres restrictions](/slides/fr/php-java/licensing/) jusqu’à ce qu’une licence soit appliquée.