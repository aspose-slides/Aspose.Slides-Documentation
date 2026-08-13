---
title: Convertir des présentations PowerPoint en TIFF avec notes sous .NET
linktitle: PowerPoint vers TIFF avec notes
type: docs
weight: 100
url: /fr/net/convert-powerpoint-to-tiff-with-notes/
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
- enregistrer PPT au format TIFF
- enregistrer PPTX au format TIFF
- exporter PPT en TIFF
- exporter PPTX en TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- TIFF avec notes
- .NET
- C#
- Aspose.Slides
description: "Convertir des présentations PowerPoint en TIFF avec notes à l'aide d'Aspose.Slides pour .NET. Apprenez comment exporter des diapositives avec les notes du présentateur de manière efficace."
---
## **Introduction**

Aspose.Slides for .NET fournit une solution simple pour convertir les présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d’images haute qualité, l’impression et l’archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Notes Slide. Le processus de conversion est simple et efficace, en utilisant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) pour transformer la présentation entière en une série d’images TIFF tout en préservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l’aide d’Aspose.Slides for .NET implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
1. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/methods/save/index).

Supposons que nous ayons le fichier "speaker_notes.pptx" contenant la diapositive suivante :

![The presentation slide with speaker notes](slide_with_notes.png)

L’extrait de code ci‑dessous montre comment convertir la présentation en image TIFF dans la vue Notes Slide en utilisant la propriété [SlidesLayoutOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Configurer les options TIFF avec la mise en page des notes.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Afficher les notes sous la diapositive.
        }
    };

    // Enregistrer la présentation en TIFF avec les notes du présentateur.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Le résultat :

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}

Découvrez Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

### Puis‑je contrôler la position de la zone de notes dans le TIFF généré ?

Oui. Utilisez les [notes layout settings](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) pour choisir parmi les options `None`, `BottomTruncated` ou `BottomFull`, qui masquent respectivement les notes, les ajustent sur une seule page ou permettent qu’elles s’étendent sur plusieurs pages.

### Comment réduire la taille d’un fichier TIFF avec notes sans perte visible de qualité ?

Choisissez une [efficient compression](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/compressiontype/) (par ex. `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [pixel format](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/pixelformat/) inférieur (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [image dimensions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/imagesize/) peut également aider sans nuire notablement à la lisibilité.

### La police des notes influence‑t‑elle le résultat si les polices d’origine sont absentes du système ?

Oui. Les polices manquantes déclenchent une [substitution](/slides/fr/net/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. Pour éviter cela, [supply the required fonts](/slides/fr/net/custom-font/) ou définissez une [fallback font](/slides/fr/net/fallback-font/) par défaut afin que les polices prévues soient utilisées.