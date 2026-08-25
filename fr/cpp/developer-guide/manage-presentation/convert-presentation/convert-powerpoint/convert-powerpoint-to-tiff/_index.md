---
title: Convertir des présentations PowerPoint en TIFF en C++
titlelink: PowerPoint vers TIFF
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
- PowerPoint vers TIFF
- présentation en TIFF
- diapositive en TIFF
- PPT en TIFF
- PPTX en TIFF
- enregistrer PPT en tant que TIFF
- enregistrer PPTX en tant que TIFF
- exporter PPT en TIFF
- exporter PPTX en TIFF
- C++
- Aspose.Slides
description: "Apprenez comment convertir facilement des présentations PowerPoint (PPT, PPTX) en images TIFF de haute qualité à l'aide d'Aspose.Slides pour C++, avec des exemples de code."
---
## **Introduction**

TIFF (**Tagged Image File Format**) est un format d'image raster sans perte très répandu, connu pour sa qualité exceptionnelle et la préservation détaillée des graphiques. Les concepteurs, photographes et auteurs de publications assistées par ordinateur choisissent souvent le TIFF pour conserver les calques, la précision des couleurs et les paramètres d'origine de leurs images.

Avec Aspose.Slides, vous pouvez convertir facilement vos diapositives PowerPoint (PPT, PPTX) et les diapositives OpenDocument (ODP) directement en images TIFF de haute qualité, garantissant que vos présentations conservent une fidélité visuelle maximale.

## **Convertir une présentation en TIFF**

En utilisant la méthode [Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) fournie par la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/), vous pouvez rapidement convertir une présentation PowerPoint complète en TIFF. Les images TIFF résultantes correspondent à la taille de diapositive par défaut.

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

// Enregistrer la présentation au format TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Convertir une présentation en TIFF noir et blanc**

La méthode [set_BwConversionMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/) vous permet de spécifier l'algorithme utilisé lors de la conversion d'une diapositive ou d'une image en couleur en TIFF noir et blanc. Notez que ce paramètre s'applique uniquement lorsque la méthode [set_CompressionType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) est définie sur `CCITT4` ou `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) est un paramètre au niveau de l'exportation qui sélectionne un algorithme de conversion de pixels pour l'image TIFF complète. Pour définir comment une forme individuelle doit apparaître lorsque le mode d'affichage noir et blanc est actif, utilisez [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishape/set_blackwhitemode/). Consultez [Contrôle du rendu noir et blanc pour les formes](/slides/fr/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) pour des exemples.
{{% /alert %}}

Supposons que nous ayons un fichier "sample.pptx" avec la diapositive suivante :

![Une diapositive de présentation](slide_black_and_white.png)

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

Résultat :

![TIFF noir et blanc](TIFF_black_and_white.png)

## **Convertir une présentation en TIFF avec taille personnalisée**

Si vous avez besoin d'une image TIFF avec des dimensions spécifiques, vous pouvez définir les valeurs souhaitées en utilisant les méthodes disponibles dans [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/). Par exemple, la méthode [set_ImageSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_imagesize/) vous permet de définir la taille de l'image résultante.

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

En utilisant la méthode [set_PixelFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) de la classe [TiffOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/tiffoptions/), vous pouvez spécifier le format de pixel souhaité pour l'image TIFF résultante.

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
ImagePixelFormat contient les valeurs suivantes (comme indiqué dans la documentation) :
    Format1bppIndexed - 1 bit par pixel, indexé.
    Format4bppIndexed - 4 bits par pixel, indexé.
    Format8bppIndexed - 8 bits par pixel, indexé.
    Format24bppRgb    - 24 bits par pixel, RVB.
    Format32bppArgb   - 32 bits par pixel, ARGB.
*/

// Enregistrer la présentation au format TIFF avec la taille d'image spécifiée.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
Découvrez le [convertisseur PowerPoint vers Poster GRATUIT](https://products.aspose.app/slides/fr/conversion/convert-ppt-to-poster-online) d'Aspose.
{{% /alert %}}

## **FAQ**

**Puis-je convertir une diapositive individuelle au lieu de la présentation PowerPoint entière en TIFF ?**

Oui. Aspose.Slides vous permet de convertir des diapositives individuelles provenant des présentations PowerPoint et OpenDocument en images TIFF séparément.

**Existe-t-il une limite au nombre de diapositives lors de la conversion d'une présentation en TIFF ?**

Non, Aspose.Slides n'impose aucune restriction quant au nombre de diapositives. Vous pouvez convertir des présentations de n'importe quelle taille au format TIFF.

**Les animations et les effets de transition PowerPoint sont-ils conservés lors de la conversion des diapositives en TIFF ?**

Non, le TIFF est un format d'image statique. Par conséquent, les animations et les effets de transition ne sont pas conservés ; seules des captures d'écran statiques des diapositives sont exportées.