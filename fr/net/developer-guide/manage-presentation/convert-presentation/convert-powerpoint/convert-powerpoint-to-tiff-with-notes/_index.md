---
title: Convertir PowerPoint en TIFF avec notes en C#
linktitle: PowerPoint en TIFF avec notes
type: docs
weight: 100
url: /fr/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint en TIFF
- convertir une présentation en TIFF
- convertir une diapositive en TIFF
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
- C#
- .NET
- Aspose.Slides
description: "Convertir les présentations PowerPoint et OpenDocument en TIFF avec notes à l'aide d'Aspose.Slides pour .NET. Apprenez comment exporter des diapositives avec notes du présentateur efficacement."
---

## **Vue d'ensemble**

Aspose.Slides pour .NET offre une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d’images de haute qualité, l’impression et l’archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Notes de la diapo. Le processus de conversion est simple et efficace, utilisant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) pour transformer l’ensemble de la présentation en une série d’images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l’aide d’Aspose.Slides pour .NET implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
2. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
3. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

Supposons que nous ayons un fichier "speaker_notes.pptx" avec la diapositive suivante :

![La diapositive de présentation avec notes du présentateur](slide_with_notes.png)

L’extrait de code ci‑dessous montre comment convertir la présentation en une image TIFF dans la vue Notes de la diapo en utilisant la propriété [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).

```c#
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

![L’image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez le [Convertisseur gratuit PowerPoint vers Poster d’Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis‑je contrôler la position de la zone de notes dans le TIFF résultant ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) pour choisir parmi des options telles que `None`, `BottomTruncated` ou `BottomFull`, qui respectivement masquent les notes, les ajustent sur une seule page ou permettent qu’elles s’étendent sur des pages supplémentaires.

**Comment réduire la taille d’un fichier TIFF avec notes sans perte de qualité visible ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (par ex. `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) inférieur (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l’image](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) peut également aider sans nuire de façon perceptible à la lisibilité.

**La police des notes influence‑t‑elle le résultat si les polices d’origine sont absentes du système ?**

Oui. Les polices manquantes déclenchent la [substitution](/slides/fr/net/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/net/custom-font/) ou définissez une [police de secours](/slides/fr/net/fallback-font/) par défaut afin que les types de caractères prévus soient utilisés.