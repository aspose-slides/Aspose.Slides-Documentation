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
- enregistrer PPT au format TIFF
- enregistrer PPTX au format TIFF
- exporter PPT vers TIFF
- exporter PPTX vers TIFF
- PowerPoint avec notes
- présentation avec notes
- diapositive avec notes
- PPT avec notes
- PPTX avec notes
- TIFF avec notes
- C++
- Aspose.Slides
description: "Convertir les présentations PowerPoint en TIFF avec notes à l'aide d'Aspose.Slides pour C++. Apprenez comment exporter les diapositives avec les notes du présentateur efficacement."
---

## **Vue d'ensemble**

Aspose.Slides for C++ offre une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec notes au format TIFF. Ce format est largement utilisé pour le stockage d'images de haute qualité, l'impression et l'archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations complètes avec les notes du présentateur, mais aussi générer des vignettes de diapositives dans la vue Diapositive avec notes. Le processus de conversion est simple et efficace, en utilisant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour transformer la présentation entière en une série d'images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument au format TIFF avec notes à l'aide d'Aspose.Slides for C++ implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) : charger un fichier PowerPoint ou OpenDocument.  
2. Configurer les options de mise en page de sortie : utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
3. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Supposons que nous ayons un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![Diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

L'extrait de code ci‑dessous montre comment convertir la présentation en image TIFF dans la vue Diapositive avec notes en utilisant la méthode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) .
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

// Enregistrer la présentation au format TIFF avec les notes du présentateur.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Le résultat :

![Image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Astuce" color="primary" %}}
Découvrez le Convertisseur gratuit PowerPoint vers Poster d'Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis‑je contrôler la position de la zone de notes dans le TIFF résultant ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) pour choisir parmi des options telles que `None`, `BottomTruncated` ou `BottomFull`, qui masquent respectivement les notes, les ajustent sur une seule page ou permettent qu'elles s'étendent sur plusieurs pages.

**Comment réduire la taille d'un fichier TIFF avec notes sans perte de qualité visible ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (par ex. `LZW` ou `RLE`), définissez une résolution DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (tel que 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l'image](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) peut également aider sans nuire de façon notable à la lisibilité.

**La police des notes affecte‑t‑elle le résultat si les polices d'origine sont absentes du système ?**

Oui. Les polices manquantes déclenchent une [substitution](/slides/fr/cpp/font-selection-sequence/), qui peut modifier les métriques et l'apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/cpp/custom-font/) ou définissez une [police de secours](/slides/fr/cpp/fallback-font/) afin que les polices prévues soient utilisées.