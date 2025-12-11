---
title: Convertir les présentations PowerPoint en TIFF avec notes sur Android
linktitle: PowerPoint en TIFF avec notes
type: docs
weight: 100
url: /fr/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint en TIFF avec notes en utilisant Aspose.Slides pour Android via Java. Apprenez comment exporter des diapositives avec les notes du présentateur de manière efficace."
---

## **Vue d'ensemble**

Aspose.Slides for Android via Java offre une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d’images de haute qualité, l’impression et l’archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec des notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Notes de la diapositive. Le processus de conversion est simple et efficace, en utilisant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) pour transformer l’ensemble de la présentation en une série d’images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument en TIFF avec notes à l’aide d’Aspose.Slides for Android via Java implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation en TIFF : transmettre les options configurées à la méthode [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

Supposons que nous ayons un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![La diapositive de la présentation avec des notes du présentateur](slide_with_notes.png)

Le fragment de code ci‑dessous montre comment convertir la présentation en image TIFF dans la vue Notes de la diapositive en utilisant la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .
```java
// Instancier la classe Presentation qui représente un fichier de présentation.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Afficher les notes sous la diapositive.

    // Configurer les options TIFF avec la mise en page des notes.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrer la présentation en TIFF avec les notes du présentateur.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


Le résultat :

![L’image TIFF avec les notes du présentateur](TIFF_with_notes.png)

{{% alert title="Astuce" color="primary" %}}

Découvrez le [Convertisseur gratuit PowerPoint en Affiche Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Puis‑je contrôler la position de la zone des notes dans le TIFF résultant ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pour choisir parmi les options telles que `None`, `BottomTruncated` ou `BottomFull`, qui masquent respectivement les notes, les ajustent sur une seule page ou les laissent se poursuivre sur des pages supplémentaires.

**Comment réduire la taille d’un fichier TIFF avec notes sans perte visible de qualité ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (par ex., `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) inférieur (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l’image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) peut également aider sans nuire sensiblement à la lisibilité.

**La police des notes influence‑t‑elle le résultat si les polices d’origine sont absentes du système ?**

Oui. L’absence de polices déclenche une [substitution](/slides/fr/androidjava/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/androidjava/custom-font/) ou définissez une police de secours [par défaut](/slides/fr/androidjava/fallback-font/) afin que les polices prévues soient utilisées.