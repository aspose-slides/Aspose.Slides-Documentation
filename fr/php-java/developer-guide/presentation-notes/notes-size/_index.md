---
title: Modifier la taille et l'orientation de la page de notes en PHP
linktitle: Taille de la page de notes
type: docs
weight: 10
url: /fr/php-java/notes-size/
keywords:
- taille de la page de notes
- orientation des notes
- notes en paysage
- notes en portrait
- taille du prospectus
- PowerPoint
- présentation
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lire et modifier les dimensions de la page de notes dans Aspose.Slides pour PHP via Java, changer l'orientation, vérifier les tailles enregistrées, et exporter les notes ou les prospectus au format PDF et images."
---
## **Aperçu**

Utilisez [Presentation::getNotesSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getnotessize/) pour accéder aux paramètres de la page de notes de la présentation. Elle renvoie un objet [NotesSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notessize/) dont la méthode [setSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notessize/setsize/) définit les dimensions de la page. Bien que l'objet de paramètres ne puisse pas être remplacé, vous pouvez attribuer de nouvelles dimensions via cette méthode.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s'appliquent à la présentation, et non aux notes d'une diapositive individuelle.

| Paramètre | Utilité |
| --- | --- |
| [Presentation::getNotesSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getnotessize/) | Contrôle les dimensions de la page de notes et les dimensions de page utilisées pour l'exportation de prospectus. |
| [Presentation::getSlideSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getslidesize/) | Contrôle les dimensions des diapositives normales de la présentation via [SlideSize](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidesize/). |

Modifier l'un ou l'autre paramètre ne modifie pas automatiquement l'autre. Modifier l'orientation de la page de notes ne fait pas pivoter les diapositives normales non plus. Voir [Slide Size](/slides/fr/php-java/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d'exportation, utilisez une présentation contenant au moins une diapositive avec des notes de présentateur. Chaque exemple peut être exécuté indépendamment après le chargement du PHP/Java Bridge et du wrapper PHP Aspose.Slides. Les valeurs numériques renvoyées par Java sont converties en valeurs PHP avec `java_values` avant toute comparaison ou calcul.

## **Lire la taille et l’orientation de la page de notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l’orientation : une page plus large est en paysage, une page plus haute est en portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer une taille de papier standard.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();
    $orientation = "Square";

    if (java_values($size->getWidth()) > java_values($size->getHeight())) {
        $orientation = "Landscape";
    } else if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $orientation = "Portrait";
    }

    echo "Notes page: " . java_values($size->getWidth()) . " x " . java_values($size->getHeight()) . " points" . PHP_EOL;
    echo "Orientation: " . $orientation . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Passer en paysage sans modifier la taille du papier**

Pour ne changer que l’orientation, échangez la largeur et la hauteur existantes. Cela préserve les longueurs des deux côtés, y compris celles d’une taille de papier personnalisée. La condition ci‑dessous empêche une page déjà en paysage d’être reconvertie en portrait et laisse une page carrée inchangée.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = $presentation->getNotesSize()->getSize();

    if (java_values($size->getWidth()) < java_values($size->getHeight())) {
        $width = java_values($size->getWidth());
        $size->setSize(java_values($size->getHeight()), $width);
        $presentation->getNotesSize()->setSize($size);
    }

    $presentation->save("landscape-notes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour l’orientation portrait, utilisez la même affectation lorsque `java_values($size->getWidth()) > java_values($size->getHeight())`. Ne remplacez pas les dimensions A4 ou Letter sauf si vous souhaitez également modifier la taille du papier.

## **Définir et vérifier une taille de page de notes personnalisée**

Attribuez les deux dimensions simultanément, puis utilisez [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/save/) pour enregistrer la présentation. Cet exemple définit une page en paysage de 900 × 600 points, la sauvegarde au format PPTX, puis rouvre le fichier enregistré pour vérifier les valeurs persistées. La comparaison autorise une tolérance de 0,01 point pour les valeurs à virgule flottante ; ce n’est pas une garantie de précision pour chaque format de fichier.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $expectedSize = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($expectedSize);

    $presentation->save("custom-notes.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom-notes.pptx");
    try {
        $actualSize = $reopened->getNotesSize()->getSize();
        $widthMatches = abs(java_values($actualSize->getWidth()) - java_values($expectedSize->getWidth())) < 0.01;
        $heightMatches = abs(java_values($actualSize->getHeight()) - java_values($expectedSize->getHeight())) < 0.01;
        $preserved = $widthMatches && $heightMatches;

        echo "Stored notes page: " . java_values($actualSize->getWidth()) . " x " . java_values($actualSize->getHeight()) . " points" . PHP_EOL;
        echo "Size preserved: " . ($preserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Le résultat attendu est `900 x 600 points` et `Size preserved: true`. Vérifier une présentation nouvellement ouverte confirme le fichier sauvegardé, plutôt que uniquement les paramètres en mémoire.

## **Exportation des notes et des prospectus**

Les dimensions de la page définissent la zone disponible pour les mises en page des notes ou des prospectus. Elles n’activent pas ces mises en page seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions de la diapositive.

### **Exporter les notes au PDF et au PNG**

Attribuez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notescommentslayoutingoptions/) à [PdfOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes au format PNG en utilisant [Slide::getImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slide/#getImage) et [RenderingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notespositions/) conserve les notes sur une seule page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l’échelle d’image de 1 × 1 utilisée ci‑dessous, le PNG fait 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\RenderingOptions;
use aspose\slides\ImageFormat;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new NotesCommentsLayoutingOptions();
    $layout->setNotesPosition(NotesPositions::BottomTruncated);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("notes.pdf", SaveFormat::Pdf, $pdfOptions);

    $renderingOptions = new RenderingOptions();
    $renderingOptions->setSlidesLayoutOptions($layout);

    $image = $presentation->getSlides()->get_Item(0)->getImage($renderingOptions, 1, 1);
    try {
        $image->save("first-slide-notes.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Pour l’exportation PDF avec des notes longues, [BottomFull](https://reference.aspose.com/slides/fr/php-java/aspose.slides/notespositions/) autorise des pages supplémentaires si nécessaire. N’utilisez pas ce mode avec l’appel d’image mono‑diapositive ci‑dessus, qui ne le supporte pas. Après le redimensionnement, examinez la sortie pour des notes coupées et le placement des objets notes‑master existants ; changer uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu tiendra. Voir [Convert PowerPoint to PDF with Notes](/slides/fr/php-java/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’exportation des notes.

### **Exporter les prospectus au PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handoutlayoutingoptions/) pour plusieurs miniatures de diapositives sur une même page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/fr/php-java/aspose.slides/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le préréglage horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PdfOptions;
use aspose\slides\HandoutLayoutingOptions;
use aspose\slides\HandoutType;

$presentation = new Presentation("sample.pptx");
try {
    $size = new Java("java.awt.Dimension", 900, 600);
    $presentation->getNotesSize()->setSize($size);

    $layout = new HandoutLayoutingOptions();
    $layout->setHandout(HandoutType::Handouts4Horizontal);

    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($layout);

    $presentation->save("handouts.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Modifier la taille de la page modifie la zone disponible pour la grille du prospectus sans changer les dimensions des diapositives sources. Pour les images de prospectus, utilisez [Presentation::getImages](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/getimages/) avec la mise en page du prospectus, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu de prospectus au niveau de la présentation utilise les dimensions de la page de notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page de prospectus. Voir [Handout Mode](/slides/fr/php-java/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l’exportation et l’impression**

Conservez distinctes la taille de la présentation stockée, la taille de page exportée et la taille du papier imprimé :

- **Visionneuses de présentation** : Une visionneuse peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d’exportation** : Les exemples de PDF de notes et de prospectus ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions en pixels entiers et une échelle de rendu, de sorte que les valeurs de points fractionnaires peuvent être arrondies dans la sortie image. L’exportation des diapositives normales n’applique pas la taille de la page de notes.
- **Pilotes d’imprimante** : La sélection du papier, la rotation automatique et les paramètres d’ajustement à la page peuvent modifier le rendu physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour une taille de papier spécifique, alignez les paramètres de l’imprimante et vérifiez l’aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page de notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent contenir un contenu de notes différent, mais cette propriété ne fournit pas de taille de page distincte pour chaque diapositive.

**Pourquoi la modification de l’orientation des notes n’a‑t‑elle pas changé mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille des diapositives normales lorsque vous souhaitez redimensionner les diapositives elles‑mêmes.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Commencez par rouvrir la présentation enregistrée et comparer ses dimensions de notes. Si celles‑ci ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la mise en page d’exportation, l’échelle d’image, les paramètres du visionneur et la sélection du papier d’imprimante.