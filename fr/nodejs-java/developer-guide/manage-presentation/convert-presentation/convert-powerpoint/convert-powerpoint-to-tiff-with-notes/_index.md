---
title: Convertir PowerPoint en TIFF avec notes en JavaScript
linktitle: PowerPoint en TIFF avec notes
type: docs
weight: 100
url: /fr/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint en TIFF
- convertir la présentation en TIFF
- convertir la diapositive en TIFF
- convertir PPT en TIFF
- convertir PPTX en TIFF
- convertir ODP en TIFF
- PowerPoint en TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- ODP en TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- ODP avec notes
- TIFF avec notes
- Node.js
- JavaScript
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en TIFF avec notes en utilisant Aspose.Slides pour Node.js via Java. Apprenez comment exporter les diapositives avec les notes du présentateur de manière efficace."
---

## **Vue d'ensemble**

Aspose.Slides for Node.js via Java fournit une solution simple pour convertir les présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d’images de haute qualité, l’impression et l’archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Notes Slide. Le processus de conversion est simple et efficace, utilisant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) pour transformer la présentation entière en une série d’images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument en TIFF avec notes à l’aide d’Aspose.Slides for Node.js via Java implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation en TIFF : transmettre les options configurées à la méthode [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save).

Supposons que nous ayons un fichier "speaker_notes.pptx" avec la diapositive suivante :

![Diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

Le fragment de code ci-dessous montre comment convertir la présentation en image TIFF dans la vue Notes Slide en utilisant la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).
```js
// Instancier la classe Presentation qui représente un fichier de présentation.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Afficher les notes sous la diapositive.

    // Configurer les options TIFF avec la mise en page des notes.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrer la présentation au format TIFF avec les notes du présentateur.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


Le résultat :

![Image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Découvrez le Convertisseur gratuit PowerPoint vers Poster d'Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Puis-je contrôler la position de la zone des notes dans le TIFF résultant ?**

Oui. Utilisez les [notes layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) pour choisir parmi les options `None`, `BottomTruncated` ou `BottomFull`, qui masquent respectivement les notes, les ajustent sur une seule page ou permettent leur débordement sur des pages supplémentaires.

**Comment réduire la taille d’un fichier TIFF avec notes sans perte de qualité visible ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (par ex., `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) plus bas (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l’image](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setimagesize/) peut également aider sans nuire notablement à la lisibilité.

**La police des notes influence‑t‑elle le résultat si les polices d’origine sont manquantes sur le système ?**

Oui. Les polices manquantes déclenchent une [substitution](/slides/fr/nodejs-java/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/nodejs-java/custom-font/) ou définissez une [police de secours](/slides/fr/nodejs-java/fallback-font/) par défaut afin que les polices prévues soient utilisées.