---
title: Convertir des présentations PowerPoint en TIFF avec notes en Python
linktitle: PowerPoint vers TIFF avec notes
type: docs
weight: 100
url: /fr/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers TIFF
- présentation vers TIFF
- diapositive vers TIFF
- PPT vers TIFF
- PPTX vers TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- TIFF avec notes
- Python
- Aspose.Slides
description: "Convertir des présentations PowerPoint en TIFF avec notes en utilisant Aspose.Slides pour Python via .NET. Apprenez comment exporter des diapositives avec les notes du présentateur efficacement."
---

## **Vue d'ensemble**

Aspose.Slides for Python via .NET fournit une solution simple pour convertir les présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d'images haute qualité, l’impression et l’archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Note de la diapositive. Le processus de conversion est simple et efficace, utilisant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour transformer l’ensemble de la présentation en une série d’images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument en TIFF avec notes à l’aide d’Aspose.Slides for Python via .NET implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
2. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
3. Enregistrer la présentation en TIFF : passer les options configurées à la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions).

Imaginons que nous disposions d’un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![Diapositive de présentation avec notes du présentateur](slide_with_notes.png)

L’extrait de code ci‑dessous montre comment convertir la présentation en image TIFF dans la vue Note de la diapositive en utilisant la propriété [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) .
```py
# Instanciez la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("speaker_notes.pptx") as presentation:
    
    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL  # Affiche les notes sous la diapositive.
    
    # Configurez les options TIFF avec la mise en forme des notes.
    tiff_options = slides.export.TiffOptions()
    tiff_options.dpi_x = 300
    tiff_options.dpi_y = 300
    tiff_options.slides_layout_options = notes_options
    
    # Enregistrez la présentation au format TIFF avec les notes du présentateur.
    presentation.save("TIFF_with_notes.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```


Résultat :

![Image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez l’[outil gratuit de conversion PowerPoint vers affiche d’Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis‑je contrôler la position de la zone des notes dans le TIFF résultant ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/slides_layout_options/) pour choisir parmi les options telles que `NONE`, `BOTTOM_TRUNCATED` ou `BOTTOM_FULL`, qui masquent respectivement les notes, les ajustent sur une seule page ou les laissent s’étendre sur des pages supplémentaires.

**Comment réduire la taille d’un fichier TIFF avec notes sans perte visible de qualité ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/compression_type/) (par ex., `LZW` ou `RLE`), définissez un DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/pixel_format/) inférieur (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l’image](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/image_size/) peut également aider sans altérer nettement la lisibilité.

**La police des notes influence‑t‑elle le résultat si les polices d’origine sont absentes du système ?**

Oui. L’absence de polices déclenche une [substitution](/slides/fr/python-net/font-selection-sequence/), ce qui peut modifier les métriques et l’apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/python-net/custom-font/) ou définissez une [police de secours par défaut](/slides/fr/python-net/fallback-font/) afin que les polices prévues soient utilisées.