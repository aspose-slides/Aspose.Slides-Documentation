---
title: Converti le presentazioni PowerPoint in TIFF con C++
titlelink: PowerPoint in TIFF
type: docs
weight: 90
url: /it/cpp/convert-powerpoint-to-tiff/
keywords:
- converti PowerPoint
- converti OpenDocument
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in TIFF
- presentazione in TIFF
- diapositiva in TIFF
- PPT in TIFF
- PPTX in TIFF
- salva PPT come TIFF
- salva PPTX come TIFF
- esporta PPT in TIFF
- esporta PPTX in TIFF
- C++
- Aspose.Slides
description: "Scopri come convertire facilmente le presentazioni PowerPoint (PPT, PPTX) in immagini TIFF ad alta qualità utilizzando Aspose.Slides per C++, con esempi di codice."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato raster senza perdita ampiamente usato, noto per la sua qualità eccezionale e la conservazione dettagliata della grafica. Designer, fotografi e editori desktop scelgono spesso TIFF per mantenere i livelli, l'accuratezza dei colori e le impostazioni originali nelle loro immagini.

Con Aspose.Slides, puoi convertire facilmente le diapositive PowerPoint (PPT, PPTX) e le diapositive OpenDocument (ODP) direttamente in immagini TIFF di alta qualità, garantendo che le tue presentazioni mantengano la massima fedeltà visiva.

## **Convertire una presentazione in TIFF**

Utilizzando il metodo [Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/), puoi convertire rapidamente un'intera presentazione PowerPoint in TIFF. Le immagini TIFF risultanti corrispondono alle dimensioni predefinite della diapositiva.

Questo codice C++ dimostra come convertire una presentazione PowerPoint in TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Salva la presentazione come TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **Convertire una presentazione in TIFF in bianco e nero**

Il metodo [set_BwConversionMode](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) nella classe [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/) consente di specificare l'algoritmo utilizzato quando si converte una diapositiva o un'immagine a colori in un TIFF in bianco e nero. Nota che questa impostazione si applica solo quando il metodo [set_CompressionType](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) è impostato su `CCITT4` o `CCITT3`.

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

![A presentation slide](slide_black_and_white.png)

Questo codice C++ dimostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

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

Il risultato:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Convertire una presentazione in TIFF con dimensioni personalizzate**

Se necessiti di un'immagine TIFF con dimensioni specifiche, puoi impostare i valori desiderati utilizzando i metodi disponibili in [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/). Per esempio, il metodo [set_ImageSize](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_imagesize/) ti permette di definire le dimensioni dell'immagine risultante.

Questo codice C++ dimostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

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

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// Imposta il tipo di compressione.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Tipi di compressione:
    Default - Specifica lo schema di compressione predefinito (LZW).
    None - Specifica nessuna compressione.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// La profondità dipende dal tipo di compressione e non può essere impostata manualmente.

// Imposta i DPI dell'immagine.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// Imposta le dimensioni dell'immagine.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Salva la presentazione come TIFF con le dimensioni specificate.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **Convertire una presentazione in TIFF con formato pixel dell'immagine personalizzato**

Utilizzando il metodo [set_PixelFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) della classe [TiffOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/), è possibile specificare il formato pixel preferito per l'immagine TIFF risultante.

Questo codice C++ dimostra come convertire una presentazione PowerPoint in un'immagine TIFF con un formato pixel personalizzato:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istanzia la classe Presentation che rappresenta un file di presentazione (PPT, PPTX, ODP, ecc.).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat contiene i seguenti valori (come indicato nella documentazione):
    Format1bppIndexed - 1 bit per pixel, indicizzato.
    Format4bppIndexed - 4 bit per pixel, indicizzato.
    Format8bppIndexed - 8 bit per pixel, indicizzato.
    Format24bppRgb    - 24 bit per pixel, RGB.
    Format32bppArgb   - 32 bit per pixel, ARGB.
*/

// Salva la presentazione come TIFF con le dimensioni dell'immagine specificate.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}

Scopri il convertitore GRATUITO di Aspose da PowerPoint a Poster [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

### Posso convertire una singola diapositiva anziché l'intera presentazione PowerPoint in TIFF?

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

### Esiste un limite al numero di diapositive durante la conversione di una presentazione in TIFF?

No, Aspose.Slides non impone alcuna restrizione sul numero di diapositive. Puoi convertire presentazioni di qualsiasi dimensione in formato TIFF.

### Le animazioni e gli effetti di transizione di PowerPoint vengono conservati nella conversione delle diapositive in TIFF?

No, TIFF è un formato immagine statico. Pertanto, le animazioni e gli effetti di transizione non vengono conservati; vengono esportate solo istantanee statiche delle diapositive.