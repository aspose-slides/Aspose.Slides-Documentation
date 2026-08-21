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
description: "Apprenez à convertir facilement les présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité à l’aide d’Aspose.Slides pour C++, avec des exemples de code."
---
## **Introduction**

TIFF (**Tagged Image File Format**) est un format d’image raster sans perte largement utilisé, reconnu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et éditeurs de bureau choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les paramètres d’origine de leurs images.

Avec Aspose.Slides, vous pouvez convertir facilement vos diapositives PowerPoint (PPT, PPTX) et OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convert a Presentation to TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) fournie par la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Les images TIFF générées correspondent à la taille de diapositive par défaut.

Ce code C++ montre comment convertir une présentation PowerPoint en TIFF :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **Convert a Presentation to Black-and-White TIFF**

La méthode [set_BwConversionMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/) vous permet de spécifier l’algorithme utilisé lors de la conversion d’une diapositive ou d’une image couleur en TIFF noir et blanc. Notez que ce réglage s’applique uniquement lorsque la méthode [set_CompressionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) est définie sur `CCITT4` ou `CCITT3`.

{{% alert color="info" title="Note" %}}

[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) est un paramètre au niveau de l’exportation qui sélectionne un algorithme de conversion des pixels pour l’image TIFF complète. Pour définir comment une forme individuelle doit apparaître en mode noir et blanc, utilisez [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/set_blackwhitemode/). Consultez [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) pour des exemples.

{{% /alert %}}

Supposons que nous disposions d’un fichier **sample.pptx** contenant la diapositive suivante :

![A presentation slide](slide_black_and_white.png)

Ce code C++ montre comment convertir la diapositive en couleur en TIFF noir et blanc :

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Le résultat :

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

Si vous avez besoin d’une image TIFF avec des dimensions spécifiques, vous pouvez définir vos valeurs souhaitées à l’aide des méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/). Par exemple, la méthode [set_ImageSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_imagesize/) vous permet de spécifier la taille de l’image résultante.

Ce code C++ montre comment convertir une présentation PowerPoint en images TIFF avec une taille personnalisée :

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Définir le type de compression.
/*
Types de compression :
    Default - Spécifie le schéma de compression par défaut (LZW).
    None - Indique qu'aucune compression n'est appliquée.
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

// Enregistrer la présentation en TIFF avec la taille spécifiée.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

En utilisant la méthode [set_PixelFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l’image TIFF résultante.

Ce code C++ montre comment convertir une présentation PowerPoint en image TIFF avec un format de pixel personnalisé :

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation qui représente un fichier de présentation (PPT, PPTX, ODP, etc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contient les valeurs suivantes (tel qu'indiqué dans la documentation) :
    Format1bppIndexed - 1 bit par pixel, indexé.
    Format4bppIndexed - 4 bits par pixel, indexé.
    Format8bppIndexed - 8 bits par pixel, indexé.
    Format24bppRgb    - 24 bits par pixel, RGB.
    Format32bppArgb   - 32 bits par pixel, ARGB.
*/

// Enregistrer la présentation en TIFF avec la taille d'image spécifiée.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}

Découvrez le convertisseur GRATUIT PowerPoint vers Affiche d’Aspose : [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle au lieu de toute la présentation PowerPoint en TIFF ?**

Oui. Aspose.Slides vous permet de convertir séparément des diapositives individuelles de présentations PowerPoint et OpenDocument en images TIFF.

**Existe‑t‑il une limite au nombre de diapositives lors de la conversion d’une présentation en TIFF ?**

Non, Aspose.Slides n’impose aucune restriction quant au nombre de diapositives. Vous pouvez convertir des présentations de toute taille en format TIFF.

**Les animations et effets de transition PowerPoint sont‑ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d’image statique. Ainsi, les animations et les effets de transition ne sont pas conservés ; seules des captures d’écran statiques des diapositives sont exportées.