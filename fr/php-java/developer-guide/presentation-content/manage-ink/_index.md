---
title: Gérer les objets d'encre de présentation PowerPoint en PHP
linktitle: Gérer l'encre
type: docs
weight: 95
url: /fr/php-java/manage-ink/
keywords:
- encre
- objet d'encre
- trace d'encre
- gérer l'encre
- dessiner l'encre
- dessin
- export d'encre
- rendu d'encre
- masquer l'encre
- InkOptions
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Gérez les objets d'encre PowerPoint, modifiez les traces et les propriétés du pinceau, et contrôlez l'apparence de l'encre lors de l'exportation en PDF, HTML, SVG, TIFF et image avec Aspose.Slides pour PHP via Java."
---
## **Introduction**

PowerPoint propose une fonction d'encre qui vous permet de dessiner des traits libres. L'encre peut être utilisée pour mettre en surbrillance d'autres objets, montrer des connexions et des processus, et attirer l'attention sur des éléments spécifiques d'une diapositive.

Aspose.Slides fournit les types nécessaires pour travailler avec les objets d'encre. Par exemple, la classe [Ink](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ink/) représente un objet d'encre sur une diapositive.

## **Différences entre les objets normaux et les objets d'encre**

Les objets sur une diapositive PowerPoint sont généralement représentés par des objets [Shape](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/). Dans sa forme la plus simple, une forme est un conteneur qui définit la zone de l'objet lui‑-même (son cadre) ainsi que des propriétés telles que la taille du conteneur, la forme et l'arrière‑plan. Pour plus d'informations, voir [Shape Layout Format](https://docs.aspose.com/slides/fr/php-java/shape-manipulations/#access-layout-formats-for-shape).

Cependant, lorsquPowerPoint gère un objet d'encre, il ignore toutes les propriétés du cadre de l'objet (conteneur) sauf sa taille. La taille de la zone du conteneur est déterminée par les méthodes standard [Shape.getWidth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getWidth) et [Shape.getHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getHeight) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traces d'encre**

Une trace d'encre est un élément de base utilisé pour enregistrer la trajectoire d'un stylo lorsqu'un utilisateur écrit de l'encre numérique. Une trace stocke une séquence de points connectés.

La forme la plus simple d'encodage spécifie les coordonnées X et Y de chaque point d'échantillonnage. Lorsque tous les points connectés sont rendus, ils produisent une image comme celle‑ci :

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriétés du pinceau pour le dessin**

Un pinceau est utilisé pour tracer les lignes qui relient les points d'une trace d'encre. Le pinceau possède sa propre couleur et taille, représentées par les méthodes [InkBrush.getColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkbrush/#getColor) et [InkBrush.getSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkbrush/#getSize).

### **Définir la couleur du pinceau d'encre**

Ce code PHP montre comment définir la couleur d'un pinceau d'encre :

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Définir la taille du pinceau d'encre**

Ce code PHP montre comment définir la taille d'un pinceau d'encre :

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

En général, la largeur et la hauteur d'un pinceau ne correspondent pas, de sorte que PowerPoint n'affiche pas la taille du pinceau (la section de données correspondante est grisée). Lorsque la largeur et la hauteur du pinceau coïncident, PowerPoint affiche sa taille de la manière suivante :

![ink_powerpoint3](ink_powerpoint3.png)

Pour plus de clarté, augmentons la hauteur de l'objet d'encre et examinons les dimensions importantes :

![ink_powerpoint4](ink_powerpoint4.png)

Le conteneur (cadre) ne tient pas compte de la taille des pinceaux — il suppose toujours que l'épaisseur de la ligne est nulle (voir l'image précédente).

Par conséquent, pour déterminer la zone visible de l'ensemble de l'objet d'encre, il faut prendre en compte la taille du pinceau de ses traces. Ici, l'objet cible (la trace de texte manuscrit) a été mis à l'échelle à la taille du conteneur (cadre). Lorsque la taille du conteneur change, la taille du pinceau reste constante, et inversement.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint adopte un comportement similaire pour les objets texte :

![ink_powerpoint6](ink_powerpoint6.png)

## **Contrôler l'apparence de l'encre lors de l'exportation et du rendu**

Aspose.Slides fournit la classe [InkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/) pour contrôler la façon dont les objets d'encre apparaissent dans la sortie exportée ou rendue. Vous pouvez utiliser ses propriétés pour masquer complètement l'encre ou modifier la manière dont les opérations de masque de pinceau d'encre sont interprétées.

Les options d'encre sont disponibles via les options d'exportation ou de rendu pour plusieurs types de sortie :

| Sortie | Propriété des options d'encre |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Image de diapositive | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Les méthodes suivantes de [InkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/) exposent les mêmes deux réglages :

- [InkOptions.getHideInk](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#getHideInk) détermine si les objets d'encre sont inclus dans la sortie. Sa valeur par défaut est `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) détermine si une opération de masque est interprétée comme une opacité lors du rendu d'un pinceau d'encre. Sa valeur par défaut est `true` ; appelez [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) avec `false` pour utiliser l'opération ROP à la place.

### **Masquer les objets d'encre dans la sortie PDF**

Par défaut, les objets d'encre restent visibles lors de l'exportation. Pour créer une sortie épurée sans annotations manuscrites ou autre contenu d'encre, appelez [InkOptions.setHideInk](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#setHideInk) avec `true`.

L'exemple PHP suivant exporte une présentation en PDF tout en masquant tous les objets d'encre :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Masquer les objets d'encre lors du rendu d'une diapositive en image**

Pour masquer les objets d'encre lors du rendu des diapositives en images bitmap, configurez [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/#getInkOptions) et transmettez les options de rendu à [Slide.getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage).

L'exemple PHP suivant rend la première diapositive en image PNG sans objets d'encre :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Contrôler le rendu du masque d'encre**

Le réglage [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) contrôle la façon dont les opérations de masque sont interprétées lors du rendu des pinceaux d'encre. La valeur par défaut est `true`, ce qui utilise l'opacité. Pour utiliser l'opération ROP à la place, appelez [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) avec `false`.

L'exemple PHP suivant exporte une diapositive au format SVG et utilise un rendu basé sur ROP pour les opérations de masque d'encre :

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Le même réglage peut être appliqué via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tiffoptions/#getInkOptions) lors de l'exportation d'une présentation ou du rendu d'une diapositive au format TIFF.

### **Choisir de masquer ou de conserver l'encre**

Lorsque vous avez besoin d'une version épurée d'une présentation annotée pour la distribution sans marques de révision, appelez [InkOptions.setHideInk](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#setHideInk) avec `true` lors de l'exportation.

Laissez [InkOptions.getHideInk](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#getHideInk) à sa valeur par défaut `false` lorsque les annotations d'encre font partie du contenu prévu, comme les commentaires de révision, les notes manuscrites, les surlignages ou les dessins qui doivent rester visibles dans le résultat exporté. Cela permet aux applications de générer des sorties de révision et finales séparées à partir de la même présentation sans modifier les objets d'encre sources.

## **FAQ**

**Puis-je modifier la couleur ou la taille d'un trait d'encre existant ?**

Oui. Récupérez la trace avec [Ink.getTraces](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ink/#getTraces), puis modifiez son [InkTrace.getBrush](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inktrace/#getBrush). Appelez [InkBrush.setColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkbrush/#setColor) ou [InkBrush.setSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkbrush/#setSize) pour changer le pinceau.

**Le masquage de l'encre modifie-t-il la présentation source ?**

Non. L'appel à [InkOptions.setHideInk](https://reference.aspose.com/slides/fr/php-java/aspose.slides/inkoptions/#setHideInk) n'affecte que le résultat rendu ou exporté ; il ne supprime ni ne modifie les objets d'encre dans la présentation source.

**Quels formats d'exportation prennent en charge les options d'encre ?**

Vous pouvez configurer les options d'encre pour PDF, HTML, SVG, TIFF et les images bitmap de diapositives via les options d'exportation ou de rendu correspondantes présentées ci‑dessus.

**Lectures complémentaires**

* Pour en savoir plus sur les formes en général, consultez la section [PowerPoint Shapes](https://docs.aspose.com/slides/fr/php-java/powerpoint-shapes/).
* Pour plus d'informations sur les valeurs effectives, voyez [Shape Effective Properties](https://docs.aspose.com/slides/fr/php-java/shape-effective-properties/#get-effective-font-height-value).
* Pour les détails de l'exportation PDF, voir [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/fr/php-java/convert-powerpoint-to-pdf/).
* Pour les détails de l'exportation HTML, voir [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/fr/php-java/convert-powerpoint-to-html/).
* Pour les détails de l'exportation SVG, voir [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/fr/php-java/render-a-slide-as-an-svg-image/).
* Pour les détails de l'exportation TIFF, voir [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/fr/php-java/convert-powerpoint-to-tiff/).
* Pour le rendu diapositive‑vers‑image, voir [Convert Presentation Slides to Images](https://docs.aspose.com/slides/fr/php-java/convert-slide/).