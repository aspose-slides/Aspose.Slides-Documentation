---
title: Gestire i frame immagine nelle presentazioni con Python
linktitle: Frame immagine
type: docs
weight: 10
url: /it/python-net/picture-frame/
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
- formattazione del frame immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Crea, formatta, collega, ritaglia, estrae e comprime i frame immagine nelle presentazioni con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Un frame immagine è una forma della diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) possiede le risorse immagine incorporate tramite la sua [ImageCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/), mentre una [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) restituito e utilizza quella risorsa immagine quando crei i frame immagine.

I frame immagine possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce sulla portabilità, sulle dimensioni del file, sull'estrazione e sul comportamento di esportazione, perciò è utile decidere come l'immagine dovrebbe essere memorizzata prima di applicare formattazione o ottimizzazione.

## **Aggiungere e formattare un'immagine incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un frame immagine con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/). L'immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

L'esempio seguente aggiunge un'immagine JPEG, crea un frame alle dimensioni native dell'immagine e applica la formattazione della linea e la rotazione:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Il frame immagine controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni pixel originali memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare la scala relativa**

[PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) espone [relative_scale_width](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/relative_scale_width/) e [relative_scale_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/relative_scale_height/) per il frame. Un valore di `1.0` corrisponde al 100 % della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell'immagine di origine invece di calcolare manualmente le dimensioni finali.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

La scala relativa modifica le impostazioni di scala del frame; non ricampiona né comprime l'immagine incorporata.

## **Immagini incorporate e collegate**

Un'immagine incorporata conserva i dati dell'immagine all'interno della presentazione ed è quindi la scelta più sicura per la portabilità e il rendering prevedibile. Un'immagine collegata memorizza un percorso di collegamento esterno tramite il link [Picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/picture/) invece di incorporare i dati dell'immagine nella stessa maniera.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è più disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o rese in ambienti isolati, le immagini incorporate sono solitamente più affidabili.

### **Aggiungere un'immagine collegata**

L'esempio seguente crea un frame immagine e lo punta a un file immagine locale. Si occupa solo del collegamento delle immagini; il collegamento dei video è un flusso di lavoro multimediale separato e non è mescolato in questo esempio.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Usa i collegamenti quando la gestione dei file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è solitamente meno utile di una presentazione più grande e autonoma.

## **Estrarre immagini dai frame immagine**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) e che contenga un'immagine incorporata. I frame immagine collegati potrebbero non contenere bytes dell'immagine estraibili nello stesso modo.

### **Estrarre un'immagine raster**

L'API immagine moderna utilizza direttamente [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/). L'esempio seguente trova la prima immagine raster incorporata in una diapositiva e la salva come PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

Il salvataggio tramite [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) converte l'immagine estratta nel formato di output richiesto. Se ti servono i byte codificati memorizzati nella presentazione anziché un file raster convertito, usa invece la proprietà [PPImage.binary_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/binary_data/).

### **Estrarre un'immagine SVG**

Per un'immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/). Questo consente di recuperare i dati SVG direttamente invece di rasterizzare prima l'immagine.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

Mantenere il contenuto SVG come SVG preserva la fonte vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione di diapositive in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non deve essere considerata una copia byte‑per‑byte dell'SVG originale incorporato; usa l'[SvgImage.svg_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/svg_data/) incorporato quando è richiesta la risorsa vettoriale originale.

## **Ritagliare un'immagine**

Il ritaglio cambia quale parte di un'immagine è visibile all'interno del frame. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell'immagine di origine. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; modifica solo la regione visibile.

L'esempio seguente trova un frame immagine in modo sicuro e applica i valori di ritaglio:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

Poiché i dati dell'immagine nascosta sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se la dimensione del file è più importante della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i dati delle aree ritagliate**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre le dimensioni del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per una successiva operazione di "uncrop".

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è usata anche da altri frame immagine, quei frame hanno ancora bisogno della loro risorsa esistente, quindi la cancellazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere immagini raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/compress_image/) riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine viene visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `True` quando l'immagine è stata ridimensionata o ritagliata e `False` quando non è stato necessario alcun cambiamento.

Usa un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/picturescompression/) quando una risoluzione target standard è sufficiente:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

È possibile passare un valore DPI positivo personalizzato anziché un valore enum quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e metafile non viene ridotto da questo flusso di compressione raster. Ricorda anche che una risoluzione più bassa e le regioni ritagliate eliminate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target basandoti sulla dimensione massima alla quale l'immagine verrà effettivamente visualizzata o esportata, invece di applicare il DPI più basso a livello globale.

## **Gestire gli effetti di trasformazione dell'immagine**

Per un flusso di lavoro completo che copra luminosità, contrasto, trasformazioni di colore, sfocatura, effetti alfa, catene ordinate, ispezione, rimozione e verifica round‑trip, consulta [Image Transform Effects](/slides/it/python-net/image-transform-effects/).

## **Bloccare la geometria del frame immagine**

Le impostazioni del [PictureFrameLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un frame immagine. Ad esempio, la proprietà [aspect_ratio_locked](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) preserva le proporzioni della forma mentre viene ridimensionata.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

Il blocco si applica alla forma del frame immagine. Non costringe l'immagine di origine a essere ricampionata o modificata permanentemente per avere lo stesso rapporto d'aspetto.

## **Regolare i valori StretchOffset**

Quando la modalità di riempimento immagine è "stretch", i valori stretch‑offset su [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento rispetto al bounding box del frame immagine. Percentuali positive creano un'inset da un bordo, mentre percentuali negative creano un outset.

Questo è diverso dal ritaglio. I valori di ritaglio selezionano quale parte dell'immagine di origine è visibile; gli offset di stretch modificano il rettangolo in cui il riempimento immagine visibile è allungato.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

Usa gli stretch‑offset per il posizionamento del riempimento. Usa le proprietà di ritaglio quando l'obiettivo è nascondere i bordi dell'immagine di origine.

## **Considerazioni su archiviazione, dimensione file ed esportazione**

I principali trade‑off sono più facili da gestire quando l'archiviazione dell'immagine e la formattazione del frame vengono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le grandi immagini raster aumentano le dimensioni del PPTX e il consumo di memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni archiviate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati fino a quando le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente le dimensioni del file per immagini raster sovradimensionate, ma sacrifica la risoluzione di origine. Deve essere applicata dopo aver conosciuto la dimensione finale sull diapositiva.
- **Immagini SVG** dovrebbero rimanere SVG quando la conservazione del vettoriale è importante. Estrai direttamente l'SVG incorporato quando ti serve la risorsa vettoriale stessa. Le esportazioni raster delle diapositive convertono sempre la diapositiva resa in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) esistente, quando possibile, invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è solitamente più efficace quando viene eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le foto in base alle loro dimensioni reali di visualizzazione, rimuovi i pixel ritagliati solo quando la successiva modifica non è necessaria e evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un frame immagine e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza geometria e formattazione a livello di frame, come dimensioni, rotazione, valori di ritaglio, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o resa senza accesso a risorse esterne. Collega le immagini solo quando è intenzionale mantenere i file immagine fuori dal PPTX e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce le dimensioni del file PPTX?**

Non da solo. Le impostazioni di ritaglio normali nascondono parti dell'immagine di origine ma mantengono i pixel sottostanti. Usa [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster archiviata e la rimozione delle regioni ritagliate elimina i dati immagine. Conserva l'immagine originale al di fuori della presentazione se in futuro potresti aver bisogno di modifiche ad alta risoluzione.

**Come devono essere gestite le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Renderizzare una diapositiva in formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri quando leggo diapositive esistenti?**

Verifica il tipo della forma prima di utilizzare membri specifici del frame immagine. Usare `isinstance(shape, slides.PictureFrame)` evita cast non validi e consente al codice di gestire le diapositive che non contengono frame immagine.