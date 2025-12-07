---
title: Convertir les présentations PowerPoint en TIFF en C++
titlelink: PowerPoint en TIFF
type: docs
weight: 90
url: /fr/cpp/convert-powerpoint-to-tiff/
keywords:
- convertir PowerPoint
- convertir OpenDocument
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
- C++
- Aspose.Slides
description: "Apprenez à convertir facilement les présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité avec Aspose.Slides pour C++, à l'aide d'exemples de code."
---

## **Vue d'ensemble**

TIFF (Tagged Image File Format) est un format d'image raster sans perte largement utilisé, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et éditeurs de bureau choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les réglages d'origine dans leurs images.

Avec Aspose.Slides, vous pouvez convertir facilement vos diapositives PowerPoint (PPT, PPTX) et les diapositives OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convertir une présentation en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) fournie par la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Les images TIFF résultantes correspondent à la taille de diapositive par défaut.

Ce code C++ montre comment convertir une présentation PowerPoint en TIFF :
```cpp
// Instanciez la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Enregistrez la présentation au format TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **Convertir une présentation en TIFF noir et blanc**

La méthode [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) dans la classe [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou image en couleur en TIFF noir et blanc. Notez que ce paramètre ne s'applique que lorsque la méthode [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) est définie sur `CCITT4` ou `CCITT3`.

Supposons que nous ayons un fichier "sample.pptx" avec la diapositive suivante :

![Une diapositive de présentation](slide_black_and_white.png)

Ce code C++ montre comment convertir la diapositive en couleur en TIFF noir et blanc :
```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Le résultat :

![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées en utilisant les méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/). Par exemple, la méthode [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) permet de définir la taille de l'image résultante.

Ce code C++ montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :
```cpp
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Définir le type de compression.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Types de compression :
    Default - Spécifie le schéma de compression par défaut (LZW).
    None - Indique aucune compression.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// La profondeur dépend du type de compression et ne peut pas être définie manuellement.

// Définir le DPI de l'image.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Définir la taille de l'image.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Enregistrer la présentation au format TIFF avec la taille spécifiée.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


## **Convertir une présentation en TIFF avec format de pixel d'image personnalisé**

En utilisant la méthode [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) de la classe [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

Ce code C++ montre comment convertir une présentation PowerPoint en image TIFF avec un format de pixel personnalisé :
```cpp
// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation):
    Format1bppIndexed - 1 bit par pixel, indexé.
    Format4bppIndexed - 4 bits par pixel, indexé.
    Format8bppIndexed - 8 bits par pixel, indexé.
    Format24bppRgb    - 24 bits par pixel, RGB.
    Format32bppArgb   - 32 bits par pixel, ARGB.
*/

// Enregistrer la présentation au format TIFF avec la taille d'image spécifiée.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


{{% alert title="Astuce" color="primary" %}}
Découvrez le [convertisseur GRATUIT PowerPoint vers Poster](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis‑je convertir une diapositive individuelle plutôt que l'intégralité d'une présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles provenant de présentations PowerPoint et OpenDocument en images TIFF séparément.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion d'une présentation en TIFF ?**

Non, Aspose.Slides n'impose aucune restriction sur le nombre de diapositives. Vous pouvez convertir des présentations de toute taille au format TIFF.

**Les animations et les effets de transition de PowerPoint sont‑ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures d'écran statiques des diapositives sont exportées.