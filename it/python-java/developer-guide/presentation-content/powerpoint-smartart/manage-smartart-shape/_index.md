---
title: Gestisci le grafiche SmartArt nelle presentazioni con Python
linktitle: Grafica SmartArt
type: docs
weight: 20
url: /it/python-java/manage-smartart-shape/
keywords:
- oggetto SmartArt
- grafica SmartArt
- stile SmartArt
- colore SmartArt
- creare SmartArt
- aggiungere SmartArt
- modificare SmartArt
- cambiare SmartArt
- accedere SmartArt
- tipo layout SmartArt
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Automatizza la creazione, modifica e stile delle SmartArt di PowerPoint in Python usando Aspose.Slides, con esempi di codice concisi e indicazioni incentrate sulle prestazioni."
---
## **Panoramica**

Aspose.Slides consente di creare e gestire grafica SmartArt nelle presentazioni PowerPoint in modo programmatico. Questo articolo spiega come aggiungere una forma SmartArt a una diapositiva, accedere alle forme SmartArt esistenti, trovare SmartArt in base a un tipo di layout specifico e aggiornare l'aspetto visivo modificando lo stile SmartArt o lo stile colore.

Gli esempi mostrano come lavorare con le forme SmartArt tramite la raccolta di forme della diapositiva della presentazione, verificare se una forma è SmartArt e quindi modificare o ispezionare le sue proprietà.

## **Creare una forma SmartArt**
Aspose.Slides per Python via Java fornisce un'API per creare forme SmartArt. Per creare una forma SmartArt in una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni una diapositiva per indice.
1. [Aggiungi una forma SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addSmartArt) specificando un [SmartArtLayoutType](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartartlayouttype/).
1. Salva la presentazione modificata come file PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Ottieni la prima diapositiva.
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Salva la presentazione.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![Forma SmartArt](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt aggiunta alla diapositiva**|

## **Accedere a una forma SmartArt su una diapositiva**
L'esempio seguente accede alle forme SmartArt su una diapositiva della presentazione. Scorre tutte le forme sulla diapositiva e verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Accedere a una forma SmartArt con un tipo di layout particolare**
L'esempio seguente accede a una forma [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/) con un tipo di layout particolare, restituito da [SmartArt.getLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/#getLayout).

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Scorri tutte le forme nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Verifica se la forma SmartArt ha il tipo di layout specificato ed esegui l'operazione richiesta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Verifica il layout dello SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Modificare lo stile di una forma SmartArt**
Questo esempio mostra come modificare lo stile rapido di una forma SmartArt.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Scorri tutte le forme nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Trova la forma SmartArt con lo stile specificato.
1. Imposta il nuovo stile per la forma SmartArt.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Verifica e cambia lo stile dello SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![Forma SmartArt](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figura: Forma SmartArt con stile modificato**|

## **Modificare lo stile colore di una forma SmartArt**
Questo esempio accede a una forma SmartArt con uno stile colore particolare e ne modifica lo stile.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e carica la presentazione contenente una forma SmartArt.
1. Ottieni la prima diapositiva per indice.
1. Scorri tutte le forme nella prima diapositiva.
1. Verifica se la forma è un'istanza di [SmartArt](https://reference.aspose.com/slides/it/python-java/aspose.slides/smartart/).
1. Trova la forma SmartArt con lo stile colore specificato.
1. Imposta il nuovo stile colore per la forma SmartArt.
1. Salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jp    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Itera attraverso ogni forma nella prima diapositiva.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Verifica e cambia lo stile dello SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![Forma SmartArt](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figura: Forma SmartArt con stile colore modificato**|

## **FAQ**

**Posso animare SmartArt come un unico oggetto?**

Sì. SmartArt è una forma, quindi puoi applicare [animazioni standard](/slides/it/python-java/powerpoint-animation/) tramite l'API delle animazioni (ingresso, uscita, enfasi, percorsi di movimento) proprio come per le altre forme.

**Come posso trovare uno specifico SmartArt su una diapositiva se non conosco il suo ID interno?**

Imposta e utilizza il [testo alternativo](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setAlternativeText) e cerca la forma con quel valore: è un metodo consigliato per individuare la forma desiderata.

**Posso raggruppare SmartArt con altre forme?**

Sì. Puoi raggruppare SmartArt con altre forme (immagini, tabelle, ecc.) e quindi [manipolare il gruppo](/slides/it/python-java/group/).

**Come ottengo un'immagine di uno specifico SmartArt (ad es., per un'anteprima o un report)?**

Esporta una miniatura/immagine della forma; la libreria può [renderizzare forme individuali](/slides/it/python-java/create-shape-thumbnails/) in file raster (PNG/JPG/TIFF).

**L'aspetto di SmartArt verrà preservato quando si converte l'intera presentazione in PDF?**

Sì. Il motore di rendering mira a un'alta fedeltà per l'[esportazione PDF](/slides/it/python-java/convert-powerpoint-to-pdf/), con una gamma di opzioni di qualità e compatibilità.