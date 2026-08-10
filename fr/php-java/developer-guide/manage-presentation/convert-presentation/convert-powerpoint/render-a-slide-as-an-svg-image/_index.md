---
title: Rendre les diapositives de présentation en images SVG avec PHP
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- options d'export SVG
- SVG interactif
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Exportez les diapositives PowerPoint au format SVG en PHP et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image extensible basé sur XML qui s'adapte bien à la publication Web, aux visionneuses de diapositives, aux flux de travail d'accessibilité et au post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt à être utilisé de manière interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux avec [Slide.writeAsSvg](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#writeAsSvg). L'exemple suivant exporte chaque diapositive d'une présentation sous forme de fichier SVG distinct.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Le nom de fichier utilise [Slide.getSlideNumber](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getSlideNumber) plutôt que l'index de la boucle. Vous pouvez également exporter une forme individuelle avec [Shape.writeAsSvg](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#writeAsSvg) lorsqu'un visionneur de diapositives ou une page Web n'a besoin que de cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setUseFrameSize) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setUseFrameRotation) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) sur `true` lorsque le texte doit être rendu sans ligatures.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Contrôler le texte et les polices**

### **Vectoriser tout le texte**

Réglez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setVectorizeText) sur `true` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le résultat visuel plus cohérent sur tous les navigateurs, mais le texte n’est plus sélectionnable ni recherchable en tant que texte SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Choisir comment les polices externes sont gérées**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgexternalfontshandling/) pour les polices chargées de manière externe. Choisissez `AddLinksToFontFiles` pour référencer des fichiers de police séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte utilisant des polices externes sous forme de graphiques. Vérifiez les licences des polices avant de les incorporer.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Réduire la taille des images incorporées**

Utilisez [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setPicturesCompression) pour réduire la résolution des images incorporées, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) pour omettre les zones recadrées de la source, et [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setJpegQuality) pour contrôler la qualité d'encodage JPEG. Ces paramètres réduisent la taille du fichier au prix d'une perte de fidélité d'image ou de données d'image conservées.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Attribuer des ID stables aux formes et au texte**

Fournissez un rappel de formatage à [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setShapeFormattingController) pour définir [SvgShape.setId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgshape/#setId) pour chaque forme SVG. Le rappel peut également définir les valeurs [SvgTSpan.setId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgtspan/#setId) sur les éléments `tspan` du texte.

PhpJavaBridge ne peut pas invoquer un rappel PHP depuis `writeAsSvg` lorsqu'il fonctionne en mode flux. Placez la logique de formatage dans une petite classe d'aide Java, compilez‑la et ajoutez le fichier JAR résultant au chemin de classe du pont. L'aide peut utiliser [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getOfficeInteropShapeId), qui est stable pendant la durée de vie de la forme, ainsi qu'un compteur réutilisable pour ses portions de texte. Consultez l'[implémentation Java de `StableSvgIdController`](/slides/fr/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) pour le code d'aide.

Après avoir ajouté la classe compilée `com.example.slides.StableSvgIdController` au chemin de classe du pont, instanciez‑la depuis PHP et assignez‑la à `SVGOptions` :

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Ajouter des gestionnaires d'événements SVG**

Dans un rappel de formatage, appelez [SvgShape.setEventHandler](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgshape/#setEventHandler) avec une valeur [SvgEvent](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgevent/) pour ajouter un gestionnaire d'événement JavaScript à une forme exportée. Assignez le rappel avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setShapeFormattingController) et définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

Comme pour les ID stables, implémentez le rappel dans une aide Java lorsque PhpJavaBridge utilise le mode flux. L'[implémentation Java de `SvgEventController`](/slides/fr/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) attribue un ID et un gestionnaire `OnClick` à une forme nommée `ActionButton`. Compilez cette aide, ajoutez‑la au chemin de classe du pont sous le nom `com.example.slides.SvgEventController`, et utilisez‑la depuis PHP comme suit :

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

La page hébergeuse peut définir la fonction JavaScript référencée par le gestionnaire. L'attribution d'ID et de gestionnaires d'événements permet aux visionneuses de diapositives, aux améliorations d'accessibilité et à d'autres flux de travail SVG interactifs.

## **FAQ**

**Quand dois‑je utiliser [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setVectorizeText) plutôt que [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgexternalfontshandling/)?**

Utilisez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#setVectorizeText) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgexternalfontshandling/) lorsque seul le texte utilisant des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d'un SVG ?**

Commencez par compresser les images incorporées, supprimer les zones d'image recadrées et choisir des fichiers de police liés lorsque l'environnement cible peut les fournir. Testez le résultat car la résolution d'image réduite, la qualité JPEG plus basse et le texte vectorisé ont chacun des compromis différents entre qualité et taille.

**Puis‑je modifier les éléments SVG exportés après l'exportation ?**

Oui. Attribuez des ID via un rappel de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou votre script de navigateur.