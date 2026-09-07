---
title: Converti le presentazioni PowerPoint in TIFF con Python
linktitle: PowerPoint in TIFF
type: docs
weight: 90
url: /it/python-java/convert-powerpoint-to-tiff/
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
- Python
- Java
- Aspose.Slides
description: "Scopri come convertire facilmente le presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità utilizzando Aspose.Slides per Python tramite Java, con esempi di codice."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato di immagine raster che supporta più pagine e compressione senza perdita. È utile per memorizzare le diapositive renderizzate in un unico file immagine.

Utilizzando Aspose.Slides per Python tramite Java, è possibile convertire presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) in TIFF. Ogni esempio qui sotto avvia la macchina virtuale Java se necessario e rilascia la presentazione dopo l'uso. 

## **Convertire una presentazione in TIFF**

Usando il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) è possibile convertire rapidamente un'intera presentazione PowerPoint in TIFF. Il TIFF multipagina risultante contiene un'immagine renderizzata di ogni diapositiva nella dimensione predefinita.

Questo codice dimostra come convertire una presentazione PowerPoint in TIFF:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Salva tutte le diapositive in un file TIFF multipagina.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **Convertire una presentazione in TIFF in bianco e nero**

Il metodo [setBwConversionMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setBwConversionMode) nella classe [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/) consente di specificare l'algoritmo utilizzato durante la conversione di una diapositiva o immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando il metodo [setCompressionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setCompressionType) è impostato su [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) o [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Nota" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setBwConversionMode) è un'impostazione a livello di esportazione che seleziona un algoritmo di conversione dei pixel per l'intera immagine TIFF. Per definire come dovrebbe apparire una singola forma quando è attiva la modalità in bianco e nero, usare [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setBlackWhiteMode). Vedere [Control Black-and-White Rendering for Shapes](/slides/it/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) per esempi.

{{% /alert %}}

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

![Una diapositiva di presentazione](slide_black_and_white.png)

Questo codice dimostra come convertire la diapositiva a colori in un TIFF in bianco e nero:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

Il risultato:

![TIFF in bianco e nero](TIFF_black_and_white.png)

## **Convertire una presentazione in TIFF con dimensioni personalizzate**

Se è necessaria un'immagine TIFF con dimensioni specifiche, è possibile impostare i valori desiderati utilizzando i metodi disponibili in [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/). Ad esempio, il metodo [setImageSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setImageSize) consente di definire la dimensione dell'immagine risultante.

Questo codice dimostra come convertire una presentazione PowerPoint in immagini TIFF con dimensioni personalizzate:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # Imposta la risoluzione orizzontale e verticale.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # Imposta le dimensioni di output in pixel.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # Includi le note del relatore complete sotto ogni diapositiva.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **Convertire una presentazione in TIFF con formato pixel dell'immagine personalizzato**

Utilizzando il metodo [setPixelFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setPixelFormat) della classe [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/) è possibile specificare il formato pixel preferito per l'immagine TIFF risultante.

Questo codice dimostra come convertire una presentazione PowerPoint in un'immagine TIFF con formato pixel personalizzato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="Suggerimento" color="success" %}}

Scopri il [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online) di Aspose.

{{% /alert %}}

## **FAQ**

**Posso convertire una singola diapositiva invece dell'intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive quando si converte una presentazione in TIFF?**

Non vi è alcun limite fisso al conteggio delle diapositive per l'esportazione in TIFF. La memoria disponibile, la complessità delle diapositive e le dimensioni di output influiscono sulla dimensione delle presentazioni che è possibile elaborare.

**Le animazioni e gli effetti di transizione di PowerPoint vengono conservati durante la conversione in TIFF?**

No, TIFF è un formato immagine statico. Pertanto, animazioni ed effetti di transizione non vengono conservati; vengono esportate solo istantanee statiche delle diapositive.