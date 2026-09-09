---
title: Converti presentazioni PowerPoint in TIFF con Python
linktitle: PowerPoint in TIFF
type: docs
weight: 90
url: /it/python-java/convert-powerpoint-to-tiff/
keywords:
- convertire PowerPoint
- convertire OpenDocument
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in TIFF
- presentazione in TIFF
- diapositiva in TIFF
- PPT in TIFF
- PPTX in TIFF
- salvare PPT come TIFF
- salvare PPTX come TIFF
- esportare PPT in TIFF
- esportare PPTX in TIFF
- Python
- Java
- Aspose.Slides
description: "Scopri come convertire facilmente le presentazioni PowerPoint (PPT, PPTX) in immagini TIFF di alta qualità usando Aspose.Slides per Python via Java, con esempi di codice."
---
## **Introduzione**

TIFF (**Tagged Image File Format**) è un formato di immagine raster che supporta più pagine e compressione senza perdita. È utile per memorizzare diapositive renderizzate in un unico file immagine.

Utilizzando Aspose.Slides per Python via Java, è possibile convertire presentazioni PowerPoint (PPT, PPTX) e OpenDocument (ODP) in TIFF. Ogni esempio qui sotto avvia la macchina virtuale Java se necessario e rilascia la presentazione dopo l'uso. 

## **Convertire una presentazione in TIFF**

Utilizzando il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) fornito dalla classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), è possibile convertire rapidamente un'intera presentazione PowerPoint in TIFF. Il TIFF multipagina risultante contiene un'immagine renderizzata di ogni diapositiva nella dimensione predefinita.

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

Il metodo [setBwConversionMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setBwConversionMode) nella classe [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/) consente di specificare l'algoritmo usato quando si converte una diapositiva o immagine a colori in un TIFF in bianco e nero. Si noti che questa impostazione si applica solo quando il metodo [setCompressionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setCompressionType) è impostato su [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) o [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffcompressiontypes/#CCITT3).

{{% alert color="info" title="Nota" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setBwConversionMode) è un'impostazione a livello di esportazione che seleziona un algoritmo di conversione dei pixel per l'intera immagine TIFF. Per definire come deve apparire una forma individuale quando è attiva la modalità di visualizzazione in bianco e nero, utilizzare [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setBlackWhiteMode). Vedi [Control Black-and-White Rendering for Shapes](/slides/it/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes) per esempi.
{{% /alert %}}

Supponiamo di avere un file "sample.pptx" con la seguente diapositiva:

![A presentation slide](slide_black_and_white.png)

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

![Black-and-White TIFF](TIFF_black_and_white.png)

## **Convertire una presentazione in TIFF con dimensioni personalizzate**

Se è necessaria un'immagine TIFF con dimensioni specifiche, è possibile impostare i valori desiderati utilizzando i metodi disponibili in [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/). Per esempio, il metodo [setImageSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setImageSize) consente di definire la dimensione dell'immagine risultante.

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

Utilizzando il metodo [setPixelFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/#setPixelFormat) della classe [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/), è possibile specificare il formato pixel preferito per l'immagine TIFF risultante.

Questo codice dimostra come convertire una presentazione PowerPoint in un'immagine TIFF con un formato pixel personalizzato:

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
Scopri il [convertitore GRATUITO di PowerPoint in Poster di Aspose](https://products.aspose.app/slides/it/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Posso convertire una singola diapositiva anziché l'intera presentazione PowerPoint in TIFF?**

Sì. Aspose.Slides consente di convertire singole diapositive da presentazioni PowerPoint e OpenDocument in immagini TIFF separatamente.

**Esiste un limite al numero di diapositive quando si converte una presentazione in TIFF?**

Non vi è un limite fisso al numero di diapositive per l'esportazione in TIFF. Memoria disponibile, complessità delle diapositive e dimensioni di output influenzano la quantità di presentazioni che è possibile elaborare.

**Le animazioni e gli effetti di transizione di PowerPoint vengono mantenuti durante la conversione delle diapositive in TIFF?**

No, TIFF è un formato di immagine statico. Pertanto, animazioni ed effetti di transizione non vengono conservati; solo snapshot statici delle diapositive vengono esportati.