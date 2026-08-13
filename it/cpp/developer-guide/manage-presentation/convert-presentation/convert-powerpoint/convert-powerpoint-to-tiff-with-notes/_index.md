---
title: Converti presentazioni PowerPoint in TIFF con note in C++
linktitle: PowerPoint in TIFF con note
type: docs
weight: 100
url: /it/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- converti PowerPoint
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
- PowerPoint con note
- presentazione con note
- diapositiva con note
- PPT con note
- PPTX con note
- TIFF con note
- C++
- Aspose.Slides
description: Converti presentazioni PowerPoint in TIFF con note utilizzando Aspose.Slides per C++. Scopri come esportare diapositive con note del relatore in modo efficiente.
---
## **Introduzione**

Aspose.Slides per C++ offre una soluzione semplice per convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX e ODP) con note nel formato TIFF. Questo formato è ampiamente utilizzato per l'archiviazione di immagini ad alta qualità, la stampa e l'archiviazione di documenti. Con Aspose.Slides, è possibile non solo esportare intere presentazioni con note del relatore, ma anche generare miniatura delle diapositive nella visualizzazione Note della diapositiva. Il processo di conversione è semplice ed efficiente, utilizzando il metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) per trasformare l'intera presentazione in una serie di immagini TIFF preservando note e layout.

## **Convertire una presentazione in TIFF con note**

Salvare una presentazione PowerPoint o OpenDocument in TIFF con note utilizzando Aspose.Slides per C++ comporta i seguenti passaggi:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/): caricare un file PowerPoint o OpenDocument.  
1. Configurare le opzioni di layout di output: utilizzare la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) per specificare come devono essere visualizzate note e commenti.  
1. Salvare la presentazione in TIFF: passare le opzioni configurate al metodo [Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/).

Supponiamo di avere un file "speaker_notes.pptx" con la seguente diapositiva:

![La diapositiva della presentazione con note del relatore](slide_with_notes.png)

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanzia la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Visualizza le note sotto la diapositiva.

// Configura le opzioni TIFF con layout delle note.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Salva la presentazione in TIFF con le note del relatore.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

Il risultato:

![L'immagine TIFF con note del relatore](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Scopri Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Posso controllare la posizione dell'area delle note nel TIFF risultante?

Sì. Utilizzare le [impostazioni di layout delle note](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) per scegliere tra opzioni come `None`, `BottomTruncated` o `BottomFull`, che rispettivamente nascondono le note, le adattano a una singola pagina o consentono di estenderle su pagine aggiuntive.

### Come posso ridurre le dimensioni di un file TIFF con note senza una perdita visibile di qualità?

Scegliere una [compressione efficiente](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (ad es. `LZW` o `RLE`), impostare un DPI ragionevole e, se accettabile, utilizzare un [pixel format](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) più basso (come 8 bpp o 1 bpp per il bianco e nero). Ridurre leggermente le [dimensioni dell'immagine](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/tiffoptions/set_imagesize/) può anche aiutare senza compromettere visibilmente la leggibilità.

### Il carattere nelle note influisce sul risultato se i caratteri originali sono mancanti nel sistema?

Sì. I caratteri mancanti attivano la [sostituzione](/slides/it/cpp/font-selection-sequence/), che può modificare le metriche e l'aspetto del testo. Per evitarlo, [fornire i caratteri richiesti](/slides/it/cpp/custom-font/) o impostare un [carattere di fallback](/slides/it/cpp/fallback-font/) predefinito in modo che vengano utilizzati i tipi di carattere desiderati.