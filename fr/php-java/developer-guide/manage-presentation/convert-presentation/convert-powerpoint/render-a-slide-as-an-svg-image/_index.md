---
title: Rendu des diapositives de présentation en images SVG avec PHP
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
description: "Exportez les diapositives PowerPoint en images SVG avec PHP et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image XML évolutif qui convient parfaitement à la publication Web, aux visionneuses de diapositives, aux workflows d'accessibilité et au post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG séparé et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) lorsque le SVG exporté doit être compact, prévisible entre les navigateurs ou prêt pour une utilisation interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux avec [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). L’exemple suivant exporte chaque diapositive d’une présentation en tant que fichier SVG distinct.

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

Le nom de fichier utilise [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) plutôt que l’indice de la boucle. Vous pouvez également exporter une forme individuelle avec [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) lorsqu’une visionneuse de diapositives ou une page Web n’a besoin que de cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) sur `true` lorsque le texte doit être rendu sans ligatures.

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

Lors de l’exportation de diapositives vers SVG, vous pouvez contrôler si le texte reste du texte ou est converti en graphiques vectoriels, ainsi que la façon dont les polices externes sont incluses ou référencées. Les options suivantes vous aident à équilibrer la cohérence visuelle, la sélection du texte et les dépendances de police dans le SVG exporté.

### **Vectoriser tout le texte**

Définissez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) sur `true` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le rendu plus cohérent entre les navigateurs, mais le texte n’est plus sélectionnable ni recherchable en tant que texte SVG.

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

### **Choisir la gestion des polices externes**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) pour les polices chargées à l’extérieur. Choisissez `AddLinksToFontFiles` pour référencer des fichiers de police séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte utilisant des polices externes sous forme de graphiques. Vérifiez la licence des polices avant de les incorporer.

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

## **Réduire la taille des images intégrées**

Utilisez [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression) pour réduire la résolution des images intégrées, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) pour omettre les zones recadrées à la source, et [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality) pour contrôler la qualité d’encodage JPEG. Ces paramètres réduisent la taille du fichier au prix d’une perte de fidélité ou de données d’image.

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

## **Contrôler la résolution de rasterisation des métafi­c­hes**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) définit la limite de résolution minimale pour la rasterisation des métafi­c­hes lors de l’exportation SVG. Utilisez‑la pour équilibrer le niveau de détail et la taille du fichier lorsqu’une image EMF ou WMF est rasterisée. Elle ne définit pas un DPI global pour le SVG ni ne force chaque objet de la diapositive à devenir une image raster.

Téléchargez [metafile-rasterization.pptx](metafile-rasterization.pptx), qui contient une image EMF avec des lignes diagonales rapprochées. L’exemple suivant exporte la première diapositive à trois résolutions de rasterisation via [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Tous les autres paramètres d’exportation restent identiques afin que les résultats puissent être comparés.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

Dans la sortie, l’EMF est devenu un PNG intégré dans chaque SVG. Les mesures suivantes concernent la présentation fournie ; elles ne constituent pas une formule générale de conversion DPI → pixels.

| DPI de rasterisation du méta‑fichier | Dimensions du PNG intégré | Taille du fichier SVG (octets) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparaison ci‑dessous montre la même zone du raster intégré à la même taille d’affichage agrandie. Les lignes diagonales affichent une pixellisation visible à 72 DPI et des bords plus lisses à des résolutions supérieures, tandis que le fichier SVG augmente. L’augmentation de la valeur n’améliore pas nécessairement chaque détail ni ne modifie chaque image exportée.

![Détail agrandi des lignes diagonales à 72, 150 et 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) contrôle la réduction de la résolution d’image et peut masquer l’effet du changement de résolution de rasterisation du méta‑fichier. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) contrôle la qualité d’encodage JPEG, pas la résolution de rasterisation du méta‑fichier.

## **Attribuer des ID stables aux formes et au texte**

Fournissez une fonction de rappel de formatage à [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) pour définir [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) pour chaque forme SVG. Le rappel peut également définir des valeurs [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) sur les éléments `tspan` du texte.

PhpJavaBridge ne peut pas invoquer un rappel PHP depuis `writeAsSvg` lorsqu’il s’exécute en mode flux. Placez la logique de formatage dans une petite classe d’assistance Java, compilez‑la et ajoutez le JAR résultant au classpath du bridge. L’assistant peut utiliser [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), qui est stable pendant la durée de vie de la forme, ainsi qu’un compteur réutilisable pour ses spans de texte. Consultez l’[implémentation Java de `StableSvgIdController`](/slides/fr/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) pour le code d’assistance.

Après avoir ajouté la classe compilée `com.example.slides.StableSvgIdController` au classpath du bridge, instanciez‑la depuis PHP et assignez‑la à `SVGOptions` :

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

## **Ajouter des gestionnaires d’événements SVG**

Dans un rappel de formatage, appelez [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) avec une valeur [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) pour ajouter un gestionnaire d’événement JavaScript à une forme exportée. Assignez le rappel avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) et définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

Comme pour les ID stables, implémentez le rappel dans une classe d’assistance Java lorsque PhpJavaBridge utilise le mode flux. L’[implémentation Java de `SvgEventController`](/slides/fr/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) assigne un ID et un gestionnaire `OnClick` à une forme nommée `ActionButton`. Compilez cet assistant, ajoutez‑le au classpath du bridge sous le nom `com.example.slides.SvgEventController`, et utilisez‑le depuis PHP comme suit :

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

La page hôte peut définir la fonction JavaScript référencée par le gestionnaire. L’attribution d’ID et de gestionnaires d’événements rend possible les visionneuses de diapositives, les améliorations d’accessibilité et d’autres workflows SVG interactifs.

## **FAQ**

**Quand faut‑il utiliser [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) au lieu de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Utilisez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) lorsque seul le texte utilisant des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d’un SVG ?**

Commencez par compresser les images intégrées, supprimer les zones d’images recadrées et choisir des fichiers de police liés lorsque l’environnement cible peut les servir. Testez le résultat car une résolution d’image plus basse, une qualité JPEG moindre et le texte vectorisé entraînent chacun des compromis différents en termes de qualité et de taille.

**Puis‑je modifier les éléments SVG exportés après l’exportation ?**

Oui. Attribuez des ID via un rappel de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou votre script de navigateur.