---
title: Renderizza le diapositive della presentazione come immagini SVG in Python tramite Java
linktitle: Diapositiva in SVG
type: docs
weight: 50
url: /it/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint in SVG
- presentazione in SVG
- diapositiva in SVG
- PPT in SVG
- PPTX in SVG
- opzioni di esportazione SVG
- SVG interattivo
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Esporta le diapositive PowerPoint come immagini SVG in Python tramite Java e controlla caratteri, testo, immagini, ID ed eventi con Aspose.Slides."
---
## **Panoramica**

SVG è un formato immagine basato su XML scalabile che funziona bene per la pubblicazione web, i visualizzatori di diapositive, i flussi di lavoro di accessibilità e l'elaborazione automatica post‑produzione. Aspose.Slides esporta ogni diapositiva in un file SVG separato e consente di controllare come vengono scritti testo, caratteri, immagini e elementi SVG.

Utilizza [SVGOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/) quando lo SVG esportato deve essere compatto, prevedibile tra i browser o pronto per l'uso interattivo.

## **Esporta una diapositiva come SVG**

Crea una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), seleziona una diapositiva e scrivila in uno stream con [Slide.writeAsSvg](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/). Gli esempi richiedono un file `presentation.pptx` esistente. Ogni esempio avvia la JVM se necessario e chiude i relativi stream di output. L'esempio seguente esporta ogni diapositiva di una presentazione in un file SVG separato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Il nome file utilizza [Slide.getSlideNumber](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getSlideNumber) anziché l'indice del ciclo. È inoltre possibile esportare una singola forma con [Shape.writeAsSvg](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) quando un visualizzatore di diapositive o una pagina web richiede solo quella forma.

## **Configura l'output SVG**

[SVGOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/) controlla il rendering SVG. Per i riquadri di testo, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setUseFrameSize) include il riquadro di testo nell'area di rendering, e [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setUseFrameRotation) determina se viene applicata la rotazione del riquadro. Imposta [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) su `True` quando il testo deve essere renderizzato senza legature.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Controlla testo e caratteri**

### **Vettorizza tutto il testo**

Imposta [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setVectorizeText) su `True` per scrivere tutto il testo della diapositiva come grafica vettoriale. Ciò elimina le dipendenze dai caratteri e rende il risultato visivo più coerente tra i browser, ma il testo non è più selezionabile né ricercabile come testo SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Scegli come gestire i caratteri esterni**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilizza un valore [SvgExternalFontsHandling](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgexternalfontshandling/) per i caratteri caricati esternamente. Scegli `AddLinksToFontFiles` per fare riferimento a file di caratteri separati, `Embed` per includere i dati dei caratteri nello SVG, o `Vectorize` per renderizzare come grafica solo il testo che utilizza caratteri esterni. Verifica le licenze dei caratteri prima di incorporarli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Riduci le dimensioni delle immagini incorporate**

Utilizza [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setPicturesCompression) per ridurre la risoluzione delle immagini incorporate, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) per omettere le aree di origine ritagliate e [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setJpegQuality) per controllare la qualità della codifica JPEG. Queste impostazioni riducono le dimensioni del file a scapito della fedeltà dell'immagine o dei dati immagine conservati.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Assegna ID stabili a forme e testo**

Utilizza un controller di formattazione Python registrato tramite `jpype.JProxy` per assegnare valori `SvgShape.setId` alle forme e valori `SvgTSpan.setId` agli elementi di testo `tspan`. Assegna il proxy con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Il controller seguente utilizza [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getOfficeInteropShapeId), che è stabile per tutta la durata della forma, e un contatore ripetibile per i suoi segmenti di testo. Questo rende gli ID generati adatti per il post‑processing di una presentazione non modificata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Aggiungi gestori di eventi SVG**

In un controller di formattazione Python, chiama [SvgShape.setEventHandler](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgshape/#setEventHandler) con un valore [SvgEvent](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgevent/) per aggiungere un gestore di eventi JavaScript a una forma esportata. Registra il controller tramite `jpype.JProxy` e assegnalo con [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definisci la funzione JavaScript nella pagina o nel documento SVG che ospita il risultato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

La pagina host può definire la funzione JavaScript a cui fa riferimento il gestore. L'assegnazione di ID e gestori di eventi consente visualizzatori di diapositive, miglioramenti di accessibilità e altri flussi di lavoro SVG interattivi.

## **FAQ**

**Quando dovrei usare [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setVectorizeText) invece di [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Usa [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgoptions/#setVectorizeText) quando tutto il testo deve essere indipendente dai caratteri. Usa [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) quando solo il testo che utilizza caratteri esterni deve essere convertito in grafica.

**Qual è il modo migliore per ridurre le dimensioni di un SVG?**

Inizia comprimendo le immagini incorporate, eliminando le aree di immagine ritagliate e scegliendo file di caratteri collegati quando l'ambiente di destinazione può servirli. Verifica il risultato perché una risoluzione immagine più bassa, una qualità JPEG inferiore e il testo vettorizzato comportano diversi compromessi tra qualità e dimensione.

**Posso modificare gli elementi SVG esportati dopo l'esportazione?**

Sì. Assegna ID tramite un controller di formattazione, quindi seleziona gli elementi SVG corrispondenti nel tuo strumento di post‑processing o nello script del browser.