---
title: Convertir des présentations PowerPoint en TIFF avec notes en C++
linktitle: PowerPoint vers TIFF avec notes
type: docs
weight: 100
url: /fr/cpp/convert-powerpoint-to-tiff-with-notes/
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
description: "Convertissez des présentations PowerPoint en TIFF avec notes à l’aide d’Aspose.Slides pour C++. Apprenez à exporter des diapositives avec notes du présentateur efficacement."
---

## **Aperçu**

Aspose.Slides for C++ fournit une solution simple pour convertir des présentations PowerPoint et OpenDocument (PPT, PPTX et ODP) avec des notes au format TIFF. Ce format est largement utilisé pour le stockage d'images de haute qualité, l'impression et l'archivage de documents. Avec Aspose.Slides, vous pouvez non seulement exporter des présentations entières avec les notes du présentateur, mais aussi générer des miniatures de diapositives en mode diapositive de notes. Le processus de conversion est simple et efficace, utilisant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) pour transformer la présentation complète en une série d'images TIFF tout en conservant les notes et la mise en page.

## **Convertir une présentation en TIFF avec notes**

Enregistrer une présentation PowerPoint ou OpenDocument en TIFF avec notes à l'aide d'Aspose.Slides for C++ implique les étapes suivantes :

1. Instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) : Charger un fichier PowerPoint ou OpenDocument.  
2. Configurer les options de mise en page de sortie : Utiliser la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) pour spécifier comment les notes et les commentaires doivent être affichés.  
3. Enregistrer la présentation au format TIFF : transmettre les options configurées à la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

Supposons que nous ayons un fichier "speaker_notes.pptx" contenant la diapositive suivante :

![Diapositive de la présentation avec notes du présentateur](slide_with_notes.png)

L'extrait de code ci-dessous montre comment convertir la présentation en image TIFF en mode diapositive de notes à l'aide de la méthode [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) .
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Affichez les notes sous la diapositive.

// Configurez les options TIFF avec la mise en page des notes.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Le résultat :

![Image TIFF avec notes du présentateur](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Découvrez le [convertisseur gratuit PowerPoint vers Poster d'Aspose](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Puis-je contrôler la position de la zone des notes dans le TIFF résultant ?**

Oui. Utilisez les [paramètres de mise en page des notes](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) pour choisir parmi des options telles que `None`, `BottomTruncated` ou `BottomFull`, qui respectivement masquent les notes, les ajustent sur une seule page ou permettent qu'elles se poursuivent sur des pages supplémentaires.

**Comment puis‑je réduire la taille d'un fichier TIFF avec notes sans perte de qualité visible ?**

Choisissez une [compression efficace](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (par ex., `LZW` ou `RLE`), définissez une résolution DPI raisonnable et, si cela convient, utilisez un [format de pixel](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) inférieur (tel que 8 bpp ou 1 bpp pour le monochrome). Réduire légèrement les [dimensions de l'image](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) peut également aider sans nuire de façon notable à la lisibilité.

**La police des notes affecte‑t‑elle le résultat si les polices d'origine sont absentes du système ?**

Oui. Les polices manquantes déclenchent une [substitution](/slides/fr/cpp/font-selection-sequence/), ce qui peut modifier les métriques et l'apparence du texte. Pour éviter cela, [fournissez les polices requises](/slides/fr/cpp/custom-font/) ou définissez une [police de secours](/slides/fr/cpp/fallback-font/) par défaut afin que les polices prévues soient utilisées.