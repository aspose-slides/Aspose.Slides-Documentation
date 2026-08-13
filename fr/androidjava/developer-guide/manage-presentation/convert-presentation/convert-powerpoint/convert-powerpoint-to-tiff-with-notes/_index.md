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
description: "Convertir des présentations PowerPoint en TIFF avec notes à l’aide d’Aspose.Slides pour Android via Java. Apprenez à exporter des diapositives avec les notes du présentateur de manière efficace."
---
## **Introduction**

Aspose.Slides for Android via Java propose une solution simple pour convertir les présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d’images de haute qualité, l’impression et l’archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec des notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Notes Slide. Le processus de conversion est simple et efficace, utilisant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) pour transformer la présentation entière en une série d’images TIFF tout en préservant les notes et la disposition.

## **Convert a Presentation to TIFF with Notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l’aide d’Aspose.Slides for Android via Java implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de disposition de la sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-).

Imaginons que nous disposions d’un fichier « speaker_notes.pptx » contenant la diapositive suivante :

![The presentation slide with speaker notes](slide_with_notes.png)

L’extrait de code ci‑dessous montre comment convertir la présentation en image TIFF dans la vue Notes Slide en utilisant la méthode [setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .

```java
import com.aspose.slides.*;

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

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}

Découvrez l’outil gratuit Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

### Can I control the position of the notes area in the resulting TIFF?

Oui. Utilisez les [notes layout settings](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pour choisir parmi des options telles que `None`, `BottomTruncated` ou `BottomFull`, qui masquent respectivement les notes, les ajustent sur une page unique ou les laissent se poursuivre sur des pages supplémentaires.

### How can I reduce the size of a TIFF file with notes without visible loss of quality?

Choisissez une [efficient compression](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (par ex. `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [pixel format](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) plus bas (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [image dimensions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) peut également aider sans nuire perceptiblement à la lisibilité.

### Does the font in the notes affect the result if the original fonts are missing from the system?

Oui. Les polices manquantes entraînent une [substitution](/slides/fr/androidjava/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. Pour éviter cela, [supply the required fonts](/slides/fr/androidjava/custom-font/) ou définissez une [fallback font](/slides/fr/androidjava/fallback-font/) par défaut afin que les polices prévues soient utilisées.