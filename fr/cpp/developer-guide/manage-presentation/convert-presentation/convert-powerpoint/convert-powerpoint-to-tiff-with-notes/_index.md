---
title: Convertir les présentations PowerPoint en TIFF avec notes en C++
linktitle: PowerPoint en TIFF avec notes
type: docs
weight: 100
url: /fr/cpp/convert-powerpoint-to-tiff-with-notes/
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
- C++
- Aspose.Slides
description: "Convertir les présentations PowerPoint en TIFF avec notes en utilisant Aspose.Slides pour C++. Apprenez à exporter les diapositives avec des notes du présentateur efficacement."
---

## **Vue d'ensemble**

Aspose.Slides for C++ fournit une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d'images de haute qualité, l'impression et l'archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des miniatures de diapositives dans la vue Notes Slide. Le processus de conversion est simple et efficace, en utilisant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour transformer la présentation entière en une série d'images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation au format TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l'aide d'Aspose.Slides for C++ implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
1. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et commentaires doivent être affichés.  
1. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Supposons que nous ayons un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![Diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

L'extrait de code ci‑dessous montre comment convertir la présentation en image TIFF dans la vue Notes Slide en utilisant la méthode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) .
```cpp
// Instancier la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Afficher les notes sous la diapositive.

// Configurer les options TIFF avec la mise en page des notes.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Enregistrer la présentation en TIFF avec les notes du présentateur.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Le résultat :

![Image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez le [Convertisseur gratuit PowerPoint en affiche](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis‑je contrôler la position de la zone des notes dans le TIFF généré ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) pour choisir parmi des options telles que `None`, `BottomTruncated` ou `BottomFull`, qui masquent respectivement les notes, les ajustent sur une seule page, ou les laissent s’étendre sur des pages supplémentaires.

**Comment réduire la taille d'un fichier TIFF avec notes sans perte de qualité visible ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (par ex., `LZW` ou `RLE`), définissez un DPI raisonnable et, si acceptable, utilisez un [format de pixel](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) inférieur (comme 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l'image](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) peut également aider sans nuire de manière notable à la lisibilité.

**La police des notes affecte‑t‑elle le résultat si les polices d'origine sont manquantes sur le système ?**

Oui. Les polices manquantes déclenchent une [substitution](/slides/fr/cpp/font-selection-sequence/) qui peut modifier les métriques et l'apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/cpp/custom-font/) ou définissez une [police de secours](/slides/fr/cpp/fallback-font/) par défaut afin que les polices prévues soient utilisées.