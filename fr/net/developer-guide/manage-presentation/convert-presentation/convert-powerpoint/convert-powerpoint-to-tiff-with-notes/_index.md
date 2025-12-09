---
title: Convertir des présentations PowerPoint en TIFF avec notes dans .NET
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
- .NET
- C#
- Aspose.Slides
description: "Convertir des présentations PowerPoint en TIFF avec notes en utilisant Aspose.Slides pour .NET. Apprenez à exporter des diapositives avec les notes du présentateur efficacement."
---

## **Vue d’ensemble**

Aspose.Slides pour .NET fournit une solution simple pour convertir les présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d'images de haute qualité, l'impression et l'archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec des notes du présentateur, mais aussi générer des vignettes de diapositives en mode Vue des notes. Le processus de conversion est simple et efficace, utilisant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) pour transformer la présentation entière en une série d'images TIFF tout en préservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument en TIFF avec notes à l'aide d'Aspose.Slides pour .NET implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
2. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et commentaires doivent être affichés.  
3. Enregistrer la présentation au format TIFF : passer les options configurées à la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

Supposons que nous ayons un fichier "speaker_notes.pptx" avec la diapositive suivante :

![Diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

```c#
 // Instancier la classe Presentation qui représente un fichier de présentation.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Configurer les options TIFF avec la disposition des notes.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Afficher les notes sous la diapositive.
        }
    };

    // Enregistrer la présentation au format TIFF avec les notes du présentateur.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


Le résultat :

![Image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez le [Convertisseur gratuit PowerPoint vers Affiche Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis-je contrôler la position de la zone de notes dans le TIFF résultant ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) pour choisir parmi les options comme `None`, `BottomTruncated` ou `BottomFull`, qui respectivement masquent les notes, les ajustent sur une seule page ou les laissent s'étendre sur plusieurs pages.

**Comment puis-je réduire la taille d'un fichier TIFF avec notes sans perte visible de qualité ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (par exemple, `LZW` ou `RLE`), définissez une résolution DPI raisonnable et, si cela convient, utilisez un format de pixel inférieur ([pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)) (tel que 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l'image](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) peut également aider sans nuire de façon perceptible à la lisibilité.

**La police des notes influence‑t‑elle le résultat si les polices originales sont absentes du système ?**

Oui. Les polices manquantes déclenchent une [substitution](/slides/fr/net/font-selection-sequence/), ce qui peut modifier les métriques et l'apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/net/custom-font/) ou définissez une [police de secours par défaut](/slides/fr/net/fallback-font/) afin que les polices prévues soient utilisées.