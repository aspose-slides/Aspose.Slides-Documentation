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
- formattazione frame immagine
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

Un picture frame è una forma di diapositiva che visualizza un'immagine. In Aspose.Slides, la risorsa immagine e la forma che la visualizza sono oggetti separati: una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) possiede risorse immagine incorporate tramite la sua [ImageCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/), mentre una [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) controlla la posizione, le dimensioni, la formattazione della linea, la rotazione, il ritaglio, gli effetti immagine e altre impostazioni a livello di frame.

Questa separazione è utile quando la stessa immagine viene mostrata più di una volta. Aggiungi l'immagine alla presentazione una sola volta, conserva il [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) restituito e utilizza quella risorsa immagine quando crei i picture frame.

I picture frame possono contenere immagini raster come PNG o JPEG e immagini vettoriali SVG. Possono anche fare riferimento a immagini collegate invece di memorizzare i byte dell'immagine nella presentazione. La scelta influisce sulla portabilità, sulle dimensioni del file, sull'estrazione e sul comportamento di esportazione, quindi è utile decidere come l'immagine deve essere archiviata prima di applicare formattazioni o ottimizzazioni.

## **Aggiungere e Formattare un'Immagine Incorporata**

Per un'immagine incorporata, aggiungi i dati dell'immagine alla presentazione e crea un picture frame con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/). L'immagine diventa parte del pacchetto della presentazione, quindi la presentazione rimane autonoma quando viene spostata su un altro computer.

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

Il picture frame controlla la geometria visualizzata; modificare le dimensioni del frame non cambia le dimensioni originali dei pixel memorizzate nella risorsa immagine incorporata. Questa distinzione diventa importante quando si ritaglia o si comprime un'immagine in seguito.

## **Usare la Scala Relativa**

[PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) espone [relative_scale_width](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/relative_scale_width/) e [relative_scale_height](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/relative_scale_height/) per il frame. Un valore di `1.0` corrisponde al 100% della dimensione originale dell'immagine. La scala relativa è utile quando un flusso di lavoro deve preservare una relazione con la dimensione dell'immagine sorgente invece di calcolare manualmente le dimensioni finali.

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

## **Immagini Incorporate e Collegate**

Un'immagine incorporata memorizza i dati dell'immagine all'interno della presentazione e rappresenta quindi la scelta più sicura per la portabilità e un rendering prevedibile. Un'immagine collegata memorizza un percorso esterno tramite il collegamento [Picture](https://reference.aspose.com/slides/it/python-net/aspose.slides/picture/) invece di incorporare i dati dell'immagine nello stesso modo.

Le immagini collegate possono ridurre la quantità di dati immagine memorizzati nel PPTX, ma introducono una dipendenza esterna. Il file collegato deve rimanere accessibile all'applicazione che apre o rende la presentazione. Se il percorso cambia, il file viene spostato o la risorsa non è disponibile, l'immagine collegata potrebbe non essere visualizzata come previsto. Per presentazioni che devono essere inviate via e‑mail, archiviate o renderizzate in ambienti isolati, le immagini incorporate sono generalmente più affidabili.

### **Aggiungere un'Immagine Collegata**

L'esempio seguente crea un picture frame e lo punta a un file immagine locale. Gestisce solo il collegamento dell'immagine; il collegamento video è un flusso di lavoro multimediale separato e non è intenzionalmente mescolato in questo esempio.

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

Usa i collegamenti quando la gestione di file esterni è intenzionale. Non usarli semplicemente come sostituto della compressione: un PPTX piccolo con dipendenze immagine rotte è generalmente meno utile di una presentazione più grande e autonoma.

## **Estrarre Immagini dai Picture Frame**

Prima di estrarre un'immagine da una presentazione esistente, verifica che una forma sia effettivamente un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) e che contenga un'immagine incorporata. I picture frame collegati potrebbero non contenere i byte dell'immagine che possono essere estratti allo stesso modo.

### **Estrarre un'Immagine Raster**

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

Salvare tramite [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) converte l'immagine estratta nel formato di output richiesto. Se ti servono i byte codificati memorizzati nella presentazione invece di un file raster convertito, usa la proprietà [PPImage.binary_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/binary_data/).

### **Estrarre un'Immagine SVG**

Per un'immagine SVG, il [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) espone un oggetto [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/). Questo ti consente di recuperare direttamente i dati SVG invece di rasterizzare prima l'immagine.

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

Mantenere il contenuto SVG come SVG preserva la sorgente vettoriale all'interno della presentazione. Le esportazioni raster come PNG o JPEG rendono necessariamente quel contenuto vettoriale in pixel. L'esportazione della diapositiva in PDF o SVG è anch'essa un'operazione di rendering, quindi la grafica esportata non dovrebbe essere trattata come una copia byte‑per‑byte dell'SVG incorporato originale; usa l'[SvgImage.svg_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/svg_data/) incorporato quando è necessaria la risorsa vettoriale originale.

## **Ritagliare un'Immagine**

Il ritaglio modifica quale parte di un'immagine è visibile all'interno del frame. I valori di ritaglio su [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/) sono percentuali delle dimensioni dell'immagine sorgente. Il ritaglio non elimina inizialmente i pixel nascosti dall'immagine incorporata; cambia solo la regione visibile.

L'esempio seguente trova in modo sicuro un picture frame e applica i valori di ritaglio:

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

Poiché i dati dell'immagine nascosta sono ancora presenti, il ritaglio può essere modificato in seguito senza perdere i pixel originali. Se le dimensioni del file sono più importanti della reversibilità, le regioni ritagliate possono essere rimosse fisicamente come descritto nella sezione successiva.

## **Rimuovere i Dati dell'Immagine Ritagliata**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) rimuove i dati immagine al di fuori del rettangolo di ritaglio corrente e restituisce la risorsa immagine risultante. Questo può ridurre le dimensioni del file, ma è un'ottimizzazione distruttiva: dopo il salvataggio della presentazione, i pixel rimossi non sono più disponibili per un'operazione di annullamento del ritaglio successiva.

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

Il metodo può aggiungere una nuova risorsa immagine alla presentazione. Se l'immagine originale è anche utilizzata da altri picture frame, quei frame hanno ancora bisogno della loro risorsa esistente, quindi la cancellazione delle aree ritagliate non riduce necessariamente il numero totale di immagini. Il ritaglio di contenuti WMF o EMF con questo metodo rasterizza il risultato ritagliato in PNG.

## **Comprimere Immagini Raster**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/compress_image/) riduce la risoluzione dell'immagine raster rispetto alle dimensioni con cui l'immagine è visualizzata. Può anche rimuovere le regioni ritagliate nella stessa operazione. Il metodo restituisce `True` quando l'immagine è stata ridimensionata o ritagliata e `False` quando non è stato necessario alcun cambiamento.

Utilizza un valore predefinito di [PicturesCompression](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/picturescompression/) quando una risoluzione target standard è sufficiente:

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

È possibile passare un valore DPI positivo personalizzato invece di un valore enum quando è richiesto un target specifico.

La compressione è destinata alle immagini raster. Il contenuto SVG e i metafile non vengono ridotti da questo flusso di lavoro di compressione raster. Ricorda inoltre che una risoluzione più bassa e le regioni ritagliate cancellate non possono essere recuperate dalla presentazione ottimizzata. Scegli una risoluzione target in base alla dimensione più grande con cui l'immagine verrà effettivamente visualizzata o esportata, piuttosto che applicare il DPI più basso a livello globale.

## **Ispezionare gli Effetti Immagine**

Gli effetti immagine sono memorizzati sull'immagine usata dal frame. La collezione di trasformazioni dell'immagine può contenere effetti come la modulazione alfa fissa per la trasparenza e la luminanza per luminosità e contrasto. L'esempio seguente legge in modo sicuro entrambi i tipi di effetto dal primo picture frame su una diapositiva:

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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/alphamodulatefixed/) e [Luminance](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/luminance/) cambiano il modo in cui l'immagine è renderizzata nel frame; non riscrivono i byte originali dell'immagine incorporata.

## **Bloccare la Geometria del Picture Frame**

Le impostazioni di [PictureFrameLock](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframelock/) controllano quali operazioni di modifica sono disabilitate per un picture frame. Ad esempio, la proprietà [aspect_ratio_locked](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) preserva le proporzioni della forma mentre viene ridimensionata.

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

Il blocco si applica alla forma del picture frame. Non costringe l'immagine sorgente a essere ricampionata o modificata permanentemente nello stesso rapporto d'aspetto.

## **Regolare i Valori StretchOffset**

Quando la modalità di riempimento dell'immagine è stretch, i valori stretch‑offset su [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/) definiscono il rettangolo di riempimento rispetto al riquadro delimitante del picture frame. Le percentuali positive creano un'inserzione dal bordo, mentre le percentuali negative creano una sporgenza.

Questo è diverso dal ritaglio. I valori di crop selezionano quale parte dell'immagine sorgente è visibile; gli stretch offset modificano il rettangolo in cui il riempimento dell'immagine visibile è allungato.

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

Usa gli stretch offset per il posizionamento del riempimento. Usa le proprietà di crop quando l'obiettivo è nascondere i bordi dell'immagine sorgente.

## **Considerazioni su Archiviazione, Dimensioni del File e Esportazione**

I principali compromessi sono più facili da gestire quando l'archiviazione delle immagini e la formattazione dei picture frame sono trattati separatamente:

- **Immagini incorporate** rendono la presentazione autonoma e sono le più affidabili per la condivisione e il rendering lato server, ma le grandi immagini raster aumentano le dimensioni del PPTX e l'uso della memoria.
- **Immagini collegate** possono mantenere il pacchetto più piccolo, ma la presentazione dipende dal fatto che i file esterni rimangano disponibili nei percorsi o nelle posizioni memorizzate.
- **Ritaglio** è inizialmente non distruttivo. I pixel nascosti rimangono incorporati fino a quando le aree ritagliate non vengono esplicitamente eliminate o rimosse durante la compressione.
- **Compressione** può ridurre notevolmente le dimensioni del file per immagini raster troppo grandi, ma sacrifica la risoluzione di origine. Dovrebbe essere applicata dopo aver determinato le dimensioni effettive dell'immagine nella diapositiva.
- **Immagini SVG** dovrebbero rimanere come SVG quando la preservazione vettoriale è importante. Estrai direttamente l'SVG incorporato quando hai bisogno della risorsa vettoriale stessa. Le esportazioni raster delle diapositive convertono sempre la diapositiva renderizzata in pixel.
- **Immagini ripetute** dovrebbero riutilizzare una risorsa [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) esistente quando possibile, invece di caricare ripetutamente lo stesso file nel flusso di lavoro della presentazione.

Per presentazioni di grandi dimensioni, l'ottimizzazione delle immagini è di solito più efficace quando viene eseguita in modo selettivo: mantieni loghi e diagrammi come contenuto vettoriale, comprimi le fotografie in base alle loro dimensioni di visualizzazione reale, rimuovi i pixel ritagliati solo quando non è necessario modificare in seguito, ed evita i collegamenti esterni a meno che la gestione delle dipendenze non faccia parte del design di distribuzione.

## **FAQ**

**Qual è la differenza tra un picture frame e una risorsa immagine?**

Un [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) rappresenta una risorsa immagine associata alla presentazione. Un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) è una forma su una diapositiva che visualizza un'immagine e memorizza la geometria e la formattazione a livello di frame, come dimensioni, rotazione, valori di crop, effetti e blocchi.

**Devo incorporare o collegare le immagini?**

Incorpora le immagini quando la presentazione deve essere portabile, archiviata o renderizzata senza accesso a risorse esterne. Collega le immagini solo quando mantenere i file immagine al di fuori del PPTX è intenzionale e le posizioni esterne possono essere gestite in modo affidabile.

**Il ritaglio riduce le dimensioni del file PPTX?**

Non di per sé. Le impostazioni di crop normali nascondono parti dell'immagine sorgente ma mantengono i pixel sottostanti. Usa [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) o la compressione dell'immagine con rimozione delle aree ritagliate quando quei pixel possono essere eliminati definitivamente.

**Posso ripristinare la qualità dell'immagine dopo la compressione?**

No. La compressione può ridurre la risoluzione raster memorizzata e la rimozione delle regioni ritagliate elimina i dati dell'immagine. Mantieni l'immagine sorgente originale al di fuori della presentazione se in seguito potrebbe essere necessario un editing ad alta risoluzione.

**Come gestire le immagini SVG?**

Mantieni il contenuto SVG come SVG quando la fedeltà vettoriale è importante. L'[SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/) incorporato può essere estratto direttamente. Il rendering di una diapositiva in un formato raster come PNG o JPEG rasterizza l'SVG come parte dell'immagine della diapositiva.

**Come posso evitare cast non sicuri durante la lettura delle diapositive esistenti?**

Verifica il tipo di forma prima di utilizzare i membri specifici del picture frame. L'uso di `isinstance(shape, slides.PictureFrame)` evita cast non validi e consente al codice di gestire le diapositive che non contengono picture frame.