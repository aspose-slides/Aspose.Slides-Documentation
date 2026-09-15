---
title: Crea un visualizzatore di presentazioni in Python tramite Java
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/python-java/presentation-viewer/
keywords:
- visualizzare presentazione
- visualizzatore di presentazioni
- creare visualizzatore di presentazioni
- visualizzare PPT
- visualizzare PPTX
- visualizzare ODP
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea un visualizzatore di presentazioni personalizzato in Python tramite Java usando Aspose.Slides. Visualizza facilmente file PowerPoint e OpenDocument senza Microsoft PowerPoint."
---
## **Introduzione**

Aspose.Slides per Python tramite Java viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, a volte gli sviluppatori potrebbero aver bisogno di visualizzare le diapositive come immagini nel loro visualizzatore di immagini preferito o creare il proprio visualizzatore di presentazioni. In questi casi, Aspose.Slides consente di esportare una diapositiva singola come immagine. Questo articolo descrive come farlo.

## **Generare un'immagine SVG da una diapositiva**

Per generare un'immagine SVG da una diapositiva di presentazione con Aspose.Slides, seguire i passaggi indicati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Apri un flusso di byte.
1. Salva la diapositiva come immagine SVG nel flusso e scrivila in un file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Generare un SVG con un ID forma personalizzato**

Aspose.Slides può essere utilizzato per generare un [SVG](https://docs.fileformat.com/page-description-language/svg/) da una diapositiva con un ID forma personalizzato. Per farlo, utilizzare il metodo [SvgShape.setId](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgshape/#setId) di [SvgShape](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` può essere usato per impostare l'ID della forma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Creare un'immagine miniatura di una diapositiva**

Aspose.Slides ti aiuta a generare immagini miniatura delle diapositive. Per generare una miniatura di una diapositiva usando Aspose.Slides, seguire i passaggi indicati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento a una scala definita.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Creare una miniatura di diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura di diapositiva con dimensioni definite dall'utente, seguire i passaggi indicati di seguito:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le dimensioni definite.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Creare una miniatura di diapositiva con note del relatore**

Per generare la miniatura di una diapositiva con note del relatore usando Aspose.Slides, seguire i passaggi indicati di seguito:

1. Crea un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/).
1. Usa il metodo [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) per impostare la posizione delle note del relatore.
1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
1. Ottieni il riferimento alla diapositiva per indice.
1. Ottieni l'immagine miniatura della diapositiva di riferimento con le opzioni di rendering.
1. Salva l'immagine miniatura in qualsiasi formato immagine desiderato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Esempio live**

Puoi provare l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa puoi implementare con l'API di Aspose.Slides:

![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web?**

Sì. È possibile utilizzare Aspose.Slides lato server per renderizzare le diapositive come immagini o HTML e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore personalizzato?**

L'approccio consigliato è renderizzare ogni diapositiva come immagine (ad esempio PNG o SVG) o convertirla in HTML usando Aspose.Slides, quindi visualizzare il risultato all'interno di un picture box (per desktop) o di un contenitore HTML (per web).

**Come gestire presentazioni di grandi dimensioni con molte diapositive?**

Per deck di grandi dimensioni, considerare il caricamento lazy o il rendering su richiesta delle diapositive. Ciò significa generare il contenuto di una diapositiva solo quando l'utente vi naviga, riducendo memoria e tempi di caricamento.