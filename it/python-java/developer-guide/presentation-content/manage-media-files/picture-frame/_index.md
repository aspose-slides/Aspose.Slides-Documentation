---
title: Gestire i frame immagine nelle presentazioni usando Python
linktitle: Frame immagine
type: docs
weight: 10
url: /it/python-java/picture-frame/
keywords:
- frame immagine
- aggiungi frame immagine
- crea frame immagine
- immagine incorporata
- immagine collegata
- estrai immagine
- immagine raster
- immagine SVG
- ritaglia immagine
- elimina aree ritagliate
- comprimi immagine
- StretchOffset
- formattazione frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i frame immagine nelle presentazioni con Aspose.Slides per Python via Java."
---
## **Panoramica**

Un picture frame è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) possiede le risorse immagine incorporate tramite la sua [ImageCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/), mentre un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti dell'immagine e altre impostazioni a livello di cornice.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) restituito e utilizza quella risorsa immagine quando crei picture frame.

I picture frame possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce sulla portabilità, sulla dimensione del file, sull'estrazione e sul comportamento di esportazione, quindi è utile decidere come l'immagine debba essere archiviata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e formattare un'immagine incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un picture frame con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/shapecollection/#addPictureFrame). L'immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

L'esempio seguente aggiunge un'immagine JPEG, crea un frame alle dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il picture frame controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni in pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare la scala relativa**

[PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) espone la scala relativa di larghezza e altezza per il frame tramite [setRelativeScaleWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Un valore di `1.0` corrisponde al 100% della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con le dimensioni dell'immagine sorgente invece di calcolare manualmente le dimensioni finali.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La scala relativa modifica le impostazioni di scala del frame; non ricampiona né comprime l'immagine incorporata.

## **Immagini incorporate e collegate**

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un'immagine collegata memorizza una posizione esterna tramite il metodo [Picture.setLinkPathLong](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#setLinkPathLong) invece di incorporare i dati dell'immagine allo stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via email, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono generalmente più affidabili.

### **Aggiungere un'immagine collegata**

L'esempio seguente crea un picture frame e lo punta a un file immagine locale. Tratta solo il collegamento delle immagini; il collegamento dei video è un flusso di lavoro multimediale separato e non è intenzionalmente mescolato in questo esempio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usa i collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze di immagine rotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini da picture frame**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia realmente un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) e che contenga un'immagine incorporata. I picture frame collegati potrebbero non contenere byte di immagine estraibili nello stesso modo.

### **Estrarre un'immagine raster**

L'API immagine moderna lavora direttamente con immagini raster e non richiede il wrapper immagine Java più vecchio. L'esempio seguente trova la prima immagine raster incorporata su una diapositiva e la salva come PNG:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

Salvare l'immagine raster converte l'immagine estratta nel formato di output richiesto. Se hai bisogno dei byte codificati memorizzati nella presentazione anziché di un file raster convertito, utilizza i dati binari della risorsa immagine.

### **Estrarre un'immagine SVG**

Per un'immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/). Questo ti permette di recuperare i dati SVG direttamente invece di rasterizzare prima l'immagine.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

Mantenere il contenuto SVG come SVG preserva la fonte vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione della diapositiva in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non dovrebbe essere trattata come una copia byte-per-byte dell'SVG incorporato originale; utilizza i dati [SvgImage.getSvgData](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/#getSvgData) incorporati quando è necessario la risorsa vettoriale originale.

## **Ritagliare un'immagine**

Il ritaglio modifica quale parte di un'immagine è visibile all'interno del frame. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

L'esempio seguente trova un picture frame in modo sicuro e applica i valori di ritaglio:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poiché i dati dell'immagine nascosta sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati immagine ritagliati**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre la dimensione del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un'operazione di annullamento del ritaglio successiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è anche usata da altri picture frame, questi frame hanno ancora bisogno della loro risorsa esistente, quindi l'eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Ritagliare contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#compressImage) riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `True` quando l'immagine è stata ridimensionata o ritagliata e `False` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito [PicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturescompression/) quando è sufficiente una risoluzione di destinazione standard:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

È possibile passare un valore DPI positivo personalizzato invece di un valore predefinito quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non è ridotto da questo flusso di lavoro di compressione raster. Ricorda anche che una risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione di destinazione basata sulla dimensione più grande con cui l'immagine sarà effettivamente visualizzata o esportata invece di applicare il DPI più basso a livello globale.

## **Gestire gli effetti di trasformazione delle immagini**

Per un flusso di lavoro completo che copre luminosità, contrasto, trasformazioni di colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round-trip, vedi [Image Transform Effects](/slides/it/python-java/image-transform-effects/).

## **Bloccare la geometria del picture frame**

Le impostazioni [PictureFrameLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un picture frame. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) conserva le proporzioni della forma mentre viene ridimensionata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il blocco si applica alla forma del picture frame. Non forza l'immagine sorgente a essere ricampionata o modificata permanentemente allo stesso rapporto d'aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento dell'immagine è stretch, i valori stretch-offset su [PictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento relativo al riquadro di delimitazione del picture frame. Percentuali positive creano un rientro dal bordo, mentre percentuali negative creano un'estensione.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine sorgente è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento dell'immagine visibile viene allungato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Usa gli stretch offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine sorgente.

## **Considerazioni su archiviazione, dimensione del file ed esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei picture frame vengono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le immagini raster di grandi dimensioni aumentano la dimensione del PPTX e l'uso della memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dalla disponibilità dei file esterni ai percorsi o alle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente la dimensione del file per immagini raster sovradimensionate, ma sacrifica la risoluzione originale. Deve essere applicata dopo aver conosciuto la dimensione prevista sulla slide.
- **Immagini SVG** dovrebbero rimanere come SVG quando la conservazione del vettoriale è importante. Estrai l'SVG incorporato direttamente quando hai bisogno della risorsa vettoriale stessa. Le esportazioni raster delle slide convertono sempre la slide renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) esistente quando possibile invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alle loro reali dimensioni di visualizzazione, rimuovi i pixel ritagliati solo quando la modifica successiva non è necessaria e evita collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un picture frame e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza la geometria a livello di frame e la formattazione come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando è intenzionale mantenere i file immagine fuori dal PPTX e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce la dimensione del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normali nascondono parti dell'immagine sorgente ma mantengono i pixel sottostanti. Usa [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere scartati in modo permanente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati dell'immagine. Conserva l'immagine sorgente originale al di fuori della presentazione se in seguito potrebbe essere necessario un editing ad alta risoluzione.

**Come dovrebbero essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Il rendering di una diapositiva in un formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri quando leggo slide esistenti?**

Verifica il tipo di forma prima di utilizzare i membri specifici del picture frame. Un controllo `isinstance` contro [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) evita cast non validi e consente al codice di gestire le slide che non contengono picture frame.