---
title: "Migliora l'elaborazione delle immagini con l'API moderna in Python"
linktitle: "API Moderna"
type: docs
weight: 237
url: /it/python-java/modern-api/
keywords:
- "API moderna"
- "disegno"
- "miniatura diapositiva"
- "diapositiva in immagine"
- "miniatura forma"
- "forma in immagine"
- "miniatura presentazione"
- "presentazione in immagini"
- "aggiungi immagine"
- "aggiungi foto"
- Python
- Java
- Aspose.Slides
description: "Modernizza l'elaborazione delle immagini in Python tramite Java: renderizza diapositive e forme, aggiungi foto e migra le chiamate di imaging deprecate all'API moderna di Aspose.Slides."
---
## **Introduzione**

Aspose.Slides per Python tramite Java accede alla libreria Java tramite JPype. La sua API legacy per l’elaborazione delle immagini utilizzava [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) e [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) da `java.awt`.

La libreria Java ha deprecato queste API di imaging a partire dalla versione 24.4. L’API Moderna utilizza [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/) per caricare, renderizzare e salvare le immagini. Usala per il nuovo codice Python e quando migri i flussi di lavoro di elaborazione delle immagini esistenti.

{{% alert color="info" title="Note" %}}
I nomi dei metodi vecchi di seguito sono riferimenti di migrazione. Non sono più disponibili nelle versioni attuali. Gli esempi eseguibili usano l’API Moderna.

Questo cambiamento non elimina tutti i tipi `java.awt`: gli overload di dimensione immagine e colore pattern accettano ancora [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) e [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).
{{% /alert %}}

## **API Moderna**

I principali tipi per l’elaborazione delle immagini sono:

- [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/) — rappresenta un’immagine raster o vettoriale.  
- [ImageFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/) — fornisce costanti per i formati dei file immagine.  
- [Images](https://reference.aspose.com/slides/it/python-java/aspose.slides/images/) — crea immagini, ad esempio con [Images.fromFile](https://reference.aspose.com/slides/it/python-java/aspose.slides/images/#fromFile).

Usa [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) o [Shape.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) per renderizzare una diapositiva o una forma. Usa [Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con opzioni di rendering per renderizzare più diapositive. L’overload senza argomenti restituisce invece la collezione di immagini della presentazione.

Carica un’immagine con [Images.fromFile](https://reference.aspose.com/slides/it/python-java/aspose.slides/images/#fromFile), aggiungila con [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage) o aggiorna un’immagine esistente della presentazione con [PPImage.replaceImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#replaceImage). Entrambe le operazioni sulla collezione di immagini accettano [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/).

Rilascia ogni immagine che carichi o renderizzi chiamando il suo metodo `dispose` in un blocco `finally`. Rilascia la presentazione con [Presentation.dispose](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#dispose).

### **Prepara l’Ambiente Python**

Installa i pacchetti come descritto in [Installation](/slides/it/python-java/installation/). Ogni esempio importa `asposeslides` prima di avviare la JVM, poi importa l’API dopo che la JVM è in esecuzione. Gli esempi lasciano la JVM attiva così da poterla riutilizzare. Vedi [Limitations and API Differences](/slides/it/python-java/limitations-and-api-differences/#import-the-library) per le indicazioni sul ciclo di vita del notebook e della JVM.

Gli esempi che aprono `pres.pptx` richiedono una presentazione nella directory di lavoro. Gli esempi che caricano `image.png` richiedono un file immagine esistente.

### **Carica un’Immagine e Renderizza una Diapositiva**

Questo esempio aggiunge un’immagine alla prima diapositiva e salva la diapositiva come immagine JPEG. [IImage.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/#save) scrive l’immagine renderizzata nel formato specificato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Sostituire il Codice Legacy con l’API Moderna**

Sostituisci le chiamate legacy per le miniature con metodi che restituiscono [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/), quindi salva il risultato con [IImage.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/#save). Questo elimina la necessità di passare le immagini renderizzate a [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Renderizzare una Diapositiva a Dimensione Specificata**

Sostituisci la chiamata legacy `slide.getThumbnail(image_size)` con [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) usando la stessa dimensione immagine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Ottenere una Miniatura di una Diapositiva**

Sostituisci la chiamata legacy `slide.getThumbnail()` con [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) senza argomenti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Ottenere una Miniatura di una Forma**

Sostituisci la chiamata legacy `shape.getThumbnail()` con [Shape.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage). Verifica che la diapositiva contenga una forma prima di accedervi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Ottenere una Miniatura di una Presentazione**

Sostituisci la chiamata legacy `presentation.getThumbnails(options, image_size)` con [Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages). Usa [RenderingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/) per configurare il rendering.

Itera direttamente sull’array restituito con `enumerate` di Python. Dispone di ogni immagine restituita in un blocco `finally` in modo che un fallimento di salvataggio non lasci le immagini rimanenti non disponibili.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Aggiungere un’Immagine a una Presentazione**

Sostituisci il caricamento tramite [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) con [Images.fromFile](https://reference.aspose.com/slides/it/python-java/aspose.slides/images/#fromFile), quindi passa l’immagine risultante a [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage). Aggiungi l’immagine alla diapositiva e salva la presentazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Metodi Deprecati e la Loro Sostituzione nell’API Moderna**

Le tabelle usano la notazione di chiamata Python. I nomi nella colonna legacy identificano le API rimosse; usa i metodi di sostituzione collegati. I metodi moderni di rendering delle immagini restituiscono oggetti [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/) anziché immagini buffer Java.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) restituisce un array di immagini renderizzate quando viene chiamato con opzioni di rendering.

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con `options, image_size` |

Qui, `slides` è un `int[]` Java con numeri di diapositiva a base 1; crealo con `jpype.JArray(jpype.JInt)([1, 3])` per selezionare le diapositive 1 e 3. `image_size` è una [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) senza argomenti |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getImage) con `bounds, scale_x, scale_y` |

### **Slide**

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) senza argomenti |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con `image_size` |
| `slide.renderToGraphics(options, graphics)` | Nessuna sostituzione diretta; renderizza invece su un’immagine |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Nessuna sostituzione diretta; renderizza invece su un’immagine |
| `slide.renderToGraphics(options, graphics, image_size)` | Nessuna sostituzione diretta; renderizza invece su un’immagine |

Qui, `options` è [RenderingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/), e `tiff_options` è [TiffOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/tiffoptions/).

### **Output**

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/output/#add) con `path, image`, dove `image` è [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/#addImage) con un [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/) |

### **PPImage**

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#getImage) |

Per sostituire il contenuto di un’immagine esistente nella presentazione, usa [PPImage.replaceImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/#replaceImage) con un [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/it/python-java/aspose.slides/patternformat/#getTile) con `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/it/python-java/aspose.slides/patternformat/#getTile) con `background, foreground` |

Gli argomenti di colore rimangono oggetti Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Per i dati di pattern efficaci restituiti dall’API Java tramite JPype, il metodo di sostituzione mantiene il nome `getTileIImage`.

| Chiamata legacy | Sostituzione moderna |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, che restituisce un [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/) |

## **Supporto API per Graphics2D**

Gli overload legacy `renderToGraphics` disegnavano in un contesto [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) fornito dall’applicazione chiamante. L’API Moderna non ha una sostituzione diretta che disegni in quel contesto.

Usa [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) per renderizzare una diapositiva o [Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) per renderizzare più diapositive, quindi salva le immagini restituite con [IImage.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/#save). Le applicazioni che combinavano il rendering di diapositive con disegni Java personalizzati dovranno adattare il loro passaggio di composizione.

## **FAQ**

**Perché l’API Java di imaging legacy è stata sostituita?**

L’API Moderna sposta il caricamento, il rendering e il salvataggio delle immagini su [IImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/iimage/). Questo fornisce un’astrazione d’immagine comune invece di esporre immagini buffer Java o un contesto grafico Java.

**Devo ancora usare Java e JPype?**

Sì. Aspose.Slides per Python tramite Java continua a funzionare sulla JVM. L’API Moderna modifica le chiamate di elaborazione delle immagini, non i requisiti di runtime. Vedi [System Requirements](/slides/it/python-java/system-requirements/).

**Come rilascio le immagini in Python?**

Chiama `dispose` su ogni immagine che carichi o renderizzi in un blocco `finally`. Se renderizzi diverse diapositive, rilascia ogni immagine nell’array restituito. Rilascia la presentazione separatamente con [Presentation.dispose](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#dispose).

**Il passaggio all’API Moderna garantisce una generazione di miniature più veloce?**

Nessun miglioramento di performance è garantito. Le sostituzioni supportano opzioni di rendering, scaling e dimensioni immagine; misura le prestazioni con le tue presentazioni e impostazioni di output.

**Perché il getter dell’immagine a volte restituisce una collezione?**

[Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) senza argomenti restituisce le immagini incorporate nella presentazione. I suoi overload con opzioni di rendering restituiscono le immagini delle diapositive renderizzate.