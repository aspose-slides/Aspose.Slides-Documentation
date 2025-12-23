---
title: Convertir des présentations PowerPoint en TIFF avec notes en PHP
linktitle: PowerPoint vers TIFF avec notes
type: docs
weight: 100
url: /fr/php-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- enregistrer PPT en TIFF
- enregistrer PPTX en TIFF
- exporter PPT en TIFF
- exporter PPTX en TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- TIFF avec notes
- PHP
- Aspose.Slides
description: "Convertissez des présentations PowerPoint en TIFF avec notes à l'aide d'Aspose.Slides pour PHP via Java. Apprenez à exporter des diapositives avec les notes du présentateur efficacement."
---

## **Vue d'ensemble**

Aspose.Slides for PHP via Java fournit une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes en format TIFF. Ce format est largement utilisé pour le stockage d'images de haute qualité, l'impression et l'archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des vignettes de diapositives dans la vue Notes Slide. Le processus de conversion est simple et efficace, utilisant la méthode `save` de la classe [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) pour transformer l'ensemble de la présentation en une série d'images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument en TIFF avec notes à l'aide d'Aspose.Slides for PHP via Java implique les étapes suivantes :

1. Instancier la classe [Présentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save).

Supposons que nous disposions d'un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![La diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

```php
// Instancie la classe Presentation qui représente un fichier de présentation.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Affiche les notes sous la diapositive.

    // Configure les options TIFF avec la mise en page des notes.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Enregistre la présentation au format TIFF avec les notes du présentateur.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


Le résultat :

![L'image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez le [Convertisseur gratuit PowerPoint vers affiche Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis-je contrôler la position de la zone de notes dans le TIFF résultant ?**  
Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) pour choisir parmi des options comme `None`, `BottomTruncated` ou `BottomFull`, qui respectivement masquent les notes, les ajustent sur une seule page ou permettent leur débordement sur des pages supplémentaires.

**Comment réduire la taille d'un fichier TIFF avec notes sans perte visible de qualité ?**  
Choisissez une [compression efficace](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setcompressiontype/) (par ex., `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setpixelformat/) inférieur (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l'image](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setimagesize/) peut également aider sans détériorer nettement la lisibilité.

**La police des notes influence-t-elle le résultat si les polices d'origine sont absentes du système ?**  
Oui. L'absence de polices déclenche une [substitution](/slides/fr/php-java/font-selection-sequence/), ce qui peut modifier les métriques et l'apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/php-java/custom-font/) ou définissez une [police de secours](/slides/fr/php-java/fallback-font/) par défaut afin que les polices prévues soient utilisées.