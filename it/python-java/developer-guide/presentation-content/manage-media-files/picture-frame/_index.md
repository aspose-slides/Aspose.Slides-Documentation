---
title: Gestire i picture frame nelle presentazioni usando Python
linktitle: Frame immagine
type: docs
weight: 10
url: /it/python-java/picture-frame/
keywords:
- frame immagine
- aggiungere frame immagine
- creare frame immagine
- immagine incorporata
- immagine collegata
- estrarre immagine
- immagine raster
- immagine SVG
- ritagliare immagine
- eliminare aree ritagliate
- comprimere immagine
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
description: "Crea, formatta, collega, ritaglia, estrae e comprime i frame immagine nelle presentazioni con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Un picture frame è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) possiede risorse immagine incorporate attraverso la sua [ImageCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/imagecollection/), mentre un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione delle linee, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) restituito e utilizza quella risorsa immagine quando crei i picture frame.

I picture frame possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce sulla portabilità, le dimensioni del file, l'estrazione e il comportamento di esportazione, quindi è utile decidere come l'immagine dovrebbe essere archiviata prima di applicare formattazioni o ottimizzazioni.

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

Il picture frame controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni dei pixel originali memorizzati nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare la scala relativa**

[PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) espone la scala relativa di larghezza e altezza per il frame tramite [setRelativeScaleWidth](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) e [setRelativeScaleHeight](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight). Un valore di `1.0` corrisponde al 100% della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell'immagine di origine invece di calcolare manualmente le dimensioni finali.

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

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un'immagine collegata memorizza un percorso esterno tramite il metodo [Picture.setLinkPathLong](https://reference.aspose.com/slides/it/python-java/aspose.slides/picture/#setLinkPathLong) invece di incorporare i dati dell'immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine archiviati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, il picture frame collegato potrebbe non essere visualizzato come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'immagine collegata**

L'esempio seguente crea un picture frame e lo collega a un file immagine locale. Si occupa solo del collegamento dell'immagine; il collegamento dei video è un flusso di lavoro multimediale separato e non è mescolato intenzionalmente in questo esempio.

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

Usa i collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine interrotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini dai picture frame**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) e che contenga un'immagine incorporata. I picture frame collegati potrebbero non contenere byte immagine estraibili nello stesso modo.

### **Estrarre un'immagine raster**

L'API immagine moderna lavora direttamente con immagini raster e non richiede l'wrapper Java più vecchio. L'esempio seguente trova la prima immagine raster incorporata in una diapositiva e la salva come PNG:

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

Per un'immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/). Questo ti consente di recuperare direttamente i dati SVG invece di rasterizzare prima l'immagine.

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

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG devono necessariamente renderizzare quel contenuto vettoriale in pixel. L'esportazione della diapositiva in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non deve essere trattata come una copia byte‑per‑byte dell'SVG incorporato originale; utilizza i dati di [SvgImage.getSvgData](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/#getSvgData) quando è richiesto il recurso vettoriale originale.

## **Ritagliare un'immagine**

Il ritaglio cambia quale parte dell'immagine è visibile all'interno del frame. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell'immagine di origine. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; modifica solo la regione visibile.

L'esempio seguente trova in modo sicuro un picture frame e applica i valori di ritaglio:

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

Poiché i dati dell'immagine nascosta sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se le dimensioni del file sono più importanti della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati di immagine ritagliati**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre le dimensioni del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un'operazione di "uncrop" successiva.

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

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è utilizzata anche da altri picture frame, quei frame hanno ancora bisogno della loro risorsa esistente, quindi l'eliminazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#compressImage) riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `True` quando l'immagine è stata ridimensionata o ritagliata e `False` quando non è stato necessario alcun cambiamento.

Utilizza un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturescompression/) quando è sufficiente una risoluzione target standard:

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

È possibile passare un valore DPI positivo personalizzato al posto di un valore predefinito quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non è ridotto da questo flusso di lavoro di compressione raster. Ricorda anche che una risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basata sulla dimensione massima alla quale l'immagine verrà effettivamente visualizzata o esportata, anziché applicare il DPI più basso a livello globale.

## **Gestire gli effetti di trasformazione dell'immagine**

Per un flusso di lavoro completo che copra luminosità, contrasto, trasformazioni di colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica end‑to‑end, vedi [Image Transform Effects](/slides/it/python-java/image-transform-effects/).

## **Bloccare la geometria del picture frame**

Le impostazioni di [PictureFrameLock](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un picture frame. Ad esempio, [setAspectRatioLocked](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) preserva le proporzioni della forma durante il ridimensionamento.

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

Il blocco si applica alla forma del picture frame. Non forza l'immagine di origine a essere ricampionata o permanentemente modificata per avere lo stesso rapporto d'aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento dell'immagine è stretch, i valori stretch‑offset su [PictureFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento relativo al bounding box del picture frame. Percentuali positive creano un inset da un bordo, mentre percentuali negative creano un outset.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine di origine è visibile; gli stretch offset modificano il rettangolo in cui il riempimento immagine visibile è allungato.

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

Usa gli stretch offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine di origine.

## **Considerazioni su archiviazione, dimensione del file ed esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei picture frame sono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le grandi immagini raster aumentano le dimensioni del PPTX e l'uso di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati finché le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente le dimensioni del file per immagini raster sovradimensionate, ma sacrifica la risoluzione di origine. Deve essere applicata dopo aver definito la dimensione finale sulla diapositiva.
- **Immagini SVG** dovrebbero rimanere come SVG quando la conservazione vettoriale è importante. Estrai l'SVG incorporato direttamente quando è necessario il recurso vettoriale stesso. Le esportazioni raster della diapositiva convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) esistente quando possibile, invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni grandi, l'ottimizzazione delle immagini è solitamente più efficace quando eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alla loro reale dimensione di visualizzazione, rimuovi i pixel ritagliati solo quando non è necessaria una modifica successiva e evita i link esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un picture frame e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza geometria e formattazione a livello di frame come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando mantenere i file immagine fuori dal PPTX è intenzionale e le posizioni esterne possono essere mantenute in modo affidabile.

**Il ritaglio riduce le dimensioni del file PPTX?**

Non di per sé. Le impostazioni di ritaglio normali nascondono parti dell'immagine di origine ma mantengono i pixel sottostanti. Usa [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati dell'immagine. Mantieni l'immagine originale al di fuori della presentazione se in seguito potresti aver bisogno di modifiche ad alta risoluzione.

**Come dovrebbero essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[SvgImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Il rendering di una diapositiva in formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come evitare cast non sicuri quando leggo le diapositive esistenti?**

Controlla il tipo di forma prima di utilizzare membri specifici del picture frame. Un controllo `isinstance` contro [PictureFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/pictureframe/) evita cast invalidi e consente al codice di gestire le diapositive che non contengono picture frame.