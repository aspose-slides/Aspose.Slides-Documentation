---
title: Aggiungere cornici di immagine alle presentazioni con Python
linktitle: Cornice di immagine
type: docs
weight: 10
url: /it/python-net/picture-frame/
keywords:
- cornice di immagine
- aggiungere cornice di immagine
- creare cornice di immagine
- aggiungere immagine
- creare immagine
- estrarre immagine
- immagine raster
- immagine vettoriale
- ritagliare immagine
- area ritagliata
- proprietà StretchOff
- formattazione della cornice di immagine
- proprietà della cornice di immagine
- scala relativa
- effetto immagine
- rapporto d'aspetto
- trasparenza immagine
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungi cornici di immagine a presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python tramite .NET. Semplifica il tuo flusso di lavoro e migliora il design delle diapositive."
---
## **Introduzione**

Le cornici di immagine in Aspose.Slides per Python consentono di posizionare e gestire immagini raster e vettoriali come forme native delle diapositive. È possibile inserire immagini da file o stream, posizionarle e ridimensionarle con coordinate precise, applicare rotazioni, impostare la trasparenza e controllare l'ordine Z insieme alle altre forme. L'API supporta anche il ritaglio, il mantenimento del rapporto d'aspetto, l'impostazione di bordi ed effetti e la sostituzione dell'immagine di base senza ricostruire il layout. Poiché le cornici di immagine si comportano come forme normali, è possibile aggiungere animazioni, collegamenti ipertestuali e testo alternativo, rendendo semplice creare presentazioni visivamente ricche e accessibili.

## **Creare cornici di immagine**

Questa sezione mostra come inserire un'immagine in una diapositiva creando un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) con Aspose.Slides per Python. Imparerai come caricare l'immagine, posizionarla con precisione sulla diapositiva e controllarne dimensioni e formattazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni una diapositiva per indice.
3. Crea un [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo l'immagine alla [ImageCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/) della presentazione. Questa immagine verrà usata per riempire la forma.
4. Specifica la larghezza e l’altezza della cornice.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) di tale dimensione usando il metodo [add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/).
6. Salva la presentazione come file PPTX.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare un file PPTX.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi l'immagine alla presentazione.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Aggiungi una cornice di immagine con le dimensioni dell'immagine.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Salva la presentazione come PPTX.
        presentation.save("picture_frame.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}}
Le cornici di immagine ti consentono di creare rapidamente diapositive da immagini. Quando combini le cornici di immagine con le opzioni di salvataggio di Aspose.Slides, puoi controllare le operazioni di I/O per convertire le immagini da un formato all'altro. Potresti voler consultare queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/python-net/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-png/); converti [PNG in JPG](https://products.aspose.com/slides/it/python-net/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/python-net/conversion/png-to-svg/); converti [SVG in PNG](https://products.aspose.com/slides/it/python-net/conversion/svg-to-png/).
{{% /alert %}}

## **Creare cornici di immagine con scala relativa**

Questa sezione dimostra come posizionare un'immagine a dimensione fissa, quindi applicare una scala basata su percentuale indipendentemente per larghezza e altezza. Poiché le percentuali possono differire, il rapporto d'aspetto può variare. La scala viene eseguita rispetto alle dimensioni originali dell'immagine.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni una diapositiva per indice.
3. Crea un [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo l'immagine alla [ImageCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/) della presentazione.
4. Aggiungi un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) alla diapositiva.
5. Imposta la larghezza e l’altezza relativa della cornice di immagine.
6. Salva la presentazione come file PPTX.

```py
import aspose.slides as slides

# Istanziare la classe Presentation per rappresentare un file PPTX.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi l'immagine alla collezione di immagini della presentazione.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Aggiungi una cornice di immagine alla diapositiva.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # Imposta la larghezza e l'altezza della scala relativa.
        picture_frame.relative_scale_height = 0.8
        picture_frame.relative_scale_width = 1.35

        # Salva la presentazione.
        presentation.save("relative_scaling.pptx", slides.export.SaveFormat.PPTX)
```

## **Estrarre immagini raster da cornici di immagine**

Puoi estrarre immagini raster da oggetti [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) e salvarle in PNG, JPG e altri formati. L'esempio di codice qui sotto dimostra come estrarre un'immagine dal documento "sample.pptx" e salvarla in formato PNG.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **Estrarre immagini SVG da cornici di immagine**

Quando una presentazione contiene grafiche SVG posizionate all'interno di forme [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/), Aspose.Slides per Python tramite .NET ti permette di recuperare le immagini vettoriali originali con piena fedeltà. Attraverso l'analisi della collezione di forme della diapositiva, puoi identificare ogni [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/), verificare se la [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) sottostante contiene contenuto SVG e quindi salvare quell'immagine su disco o su uno stream nel suo formato SVG nativo.

Il seguente esempio di codice dimostra come estrarre un'immagine SVG da una cornice di immagine:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.PictureFrame):
        svg_image = shape.picture_format.picture.image.svg_image

        if svg_image is not None:
            with open("output.svg", "w", encoding="utf-8") as svg_stream:
                svg_stream.write(svg_image.svg_content)
```

## **Ottenere la trasparenza dell'immagine**

Aspose.Slides consente di recuperare l'effetto di trasparenza applicato a un'immagine. Questo codice Python dimostra l'operazione:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    picture_frame = presentation.slides[0].shapes[0]
    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.AlphaModulateFixed):
            transparency_value = 100 - effect.amount
            print("Picture transparency: " + str(transparency_value))
```

{{% alert color="primary" %}}
È possibile trovare tutti gli effetti applicati alle immagini in [aspose.slides.effects](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/).
{{% /alert %}}

## **Ottenere luminosità e contrasto di un'immagine**

Aspose.Slides consente di recuperare l'effetto di luminosità e contrasto applicato a un'immagine. La classe [Luminance](https://reference.aspose.com/slides/it/python-net/aspose.slides.effects/luminance/) rappresenta questo effetto di trasformazione dell'immagine.

Questo codice Python dimostra come ottenere le impostazioni di luminosità e contrasto da una cornice di immagine:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    picture_frame = shape

    image_transform = picture_frame.picture_format.picture.image_transform
    for effect in image_transform:
        if isinstance(effect, slides.effects.Luminance):
            luminance = effect.get_effective()
            brightness = luminance.brightness
            contrast = luminance.contrast

            print("Brightness: " + str(brightness))
            print("Contrast: " + str(contrast))
```

## **Formattazione della cornice di immagine**

Aspose.Slides fornisce molte opzioni di formattazione che puoi applicare a una cornice di immagine. Con queste opzioni, puoi regolare la cornice di immagine per soddisfare requisiti specifici.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni una diapositiva per indice.
3. Crea un [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo l'immagine alla [ImageCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/) della presentazione. Questa immagine verrà usata per riempire la forma.
4. Specifica la larghezza e l’altezza della cornice.
5. Crea un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) di tale dimensione usando il metodo [add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/) della diapositiva.
6. Imposta il colore della linea della cornice di immagine.
7. Imposta la larghezza della linea della cornice di immagine.
8. Ruota la cornice di immagine fornendo un valore positivo (in senso orario) o negativo (in senso antiorario).
9. Salva la presentazione modificata come file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanziare la classe Presentation per rappresentare un file PPTX.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi l'immagine alla collezione di immagini della presentazione.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

        # Aggiungi una cornice di immagine con le dimensioni dell'immagine.
        picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        # Applica la formattazione alla cornice di immagine.
        picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
        picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        picture_frame.line_format.width = 20
        picture_frame.rotation = 45

    # Salva la presentazione come PPTX.
    presentation.save("picture_formatting.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Aspose ha sviluppato un [Collage Maker](https://products.aspose.app/slides/it/collage) gratuito. Se hai bisogno di [unire JPG/JPEG](https://products.aspose.app/slides/it/collage/jpg) o immagini PNG, o di [creare griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid), puoi usare questo servizio.
{{% /alert %}}

## **Aggiungere immagini come collegamenti**

Per mantenere i file delle presentazioni di piccole dimensioni, puoi aggiungere immagini o video tramite collegamenti anziché incorporare i file direttamente nelle presentazioni. Il seguente codice Python mostra come inserire un'immagine e un video in un segnaposto:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    shapes_to_remove = []

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_frame = slide.shapes.add_picture_frame(
                slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, None)

            picture_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapes_to_remove.append(shape)

        elif shape.placeholder.type == slides.PlaceholderType.MEDIA:
            video_frame = slide.shapes.add_video_frame(shape.X, shape.Y, shape.width, shape.height, "")

            video_frame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            video_frame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Ritagliare le immagini**

In questa sezione imparerai a ritagliare l'area visibile di un'immagine all'interno di una cornice di immagine senza alterare il file sorgente. Imparerai anche il metodo base per applicare margini di ritaglio per creare una composizione pulita e focalizzata direttamente sulla diapositiva.

Il seguente codice Python mostra come ritagliare un'immagine su una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi l'immagine alla collezione di immagini della presentazione.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Aggiungi una cornice di immagine alla diapositiva.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 100, 100, 420, 250, image)

    # Ritaglia l'immagine (valori percentuali).
    picture_frame.picture_format.crop_left = 23.6
    picture_frame.picture_format.crop_right = 21.5
    picture_frame.picture_format.crop_top = 3
    picture_frame.picture_format.crop_bottom = 31

    # Salva il risultato.
    presentation.save("cropped_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminare le aree ritagliate delle immagini**

Se desideri eliminare le aree ritagliate di un'immagine in una cornice, usa il metodo [delete_picture_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/). Questo metodo restituisce l'immagine ritagliata, o l'immagine originale se non è necessario alcun ritaglio.

Il seguente codice Python dimostra l'operazione:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Ottieni la PictureFrame dalla prima diapositiva.
    picture_frame = slides.shape[0]

    # Ottieni la PictureFrame dalla prima diapositiva.
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # Salva il risultato.
    presentation.save("deleted_cropped_areas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Il metodo [delete_picture_cropped_areas](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) aggiunge l'immagine ritagliata alla collezione di immagini della presentazione. Se l'immagine è usata solo nella [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) elaborata, ciò può ridurre le dimensioni della presentazione; altrimenti, il numero di immagini nella presentazione risultante può aumentare.

Durante il ritaglio, questo metodo converte i metafili WMF/EMF in un'immagine PNG raster.
{{% /alert %}}

## **Comprimere le immagini**

Puoi comprimere un'immagine in una presentazione usando il metodo [PictureFillFormat.compress_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/compress_image/).
Questo metodo comprime un'immagine riducendone le dimensioni in base alla dimensione della forma e alla risoluzione specificata, con l'opzione di eliminare le aree ritagliate.

Regola la dimensione e la risoluzione dell'immagine in modo analogo alla funzionalità **Formato immagine → Comprimi immagini → Risoluzione** di PowerPoint.

I seguenti esempi Python mostrano come comprimere un'immagine in una presentazione specificando una risoluzione target e, facoltativamente, rimuovendo le aree ritagliate:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimi l'immagine con una risoluzione target di 150 DPI (risoluzione Web) e rimuovi le aree ritagliate.
    result = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)

    # Verifica il risultato della compressione.
    if result:
        print("Image successfully compressed.")
    else:
        print("Image compression failed or no changes were necessary.")

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

Oppure usando direttamente un valore DPI personalizzato:

```python
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes[0]

    # Comprimi l'immagine a 150 DPI (risoluzione web), rimuovendo le aree ritagliate.
    picture_frame.picture_format.compress_image(True, 150)

    presentation.save("compressed_image.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Il metodo converte l'immagine a una risoluzione inferiore basandosi sulle dimensioni della forma e sul DPI fornito. Le regioni ritagliate possono anche essere eliminate per ottimizzare le dimensioni del file.
Se l'immagine è un metafile (WMF/EMF) o SVG, la compressione non verrà applicata. Inoltre, la qualità JPEG è preservata o leggermente ridotta in base alla risoluzione, similmente a quanto fa PowerPoint con JPEG ad alta risoluzione.
{{% /alert %}}

## **Bloccare il rapporto d'aspetto**

Se desideri che una forma contenente un'immagine mantenga il suo rapporto d'aspetto dopo aver modificato le dimensioni dell'immagine, imposta la proprietà [aspect_ratio_locked](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) su `True`.

Il seguente codice Python mostra come bloccare il rapporto d'aspetto di una forma:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
    empty_slide = presentation.slides.add_empty_slide(layout)

    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = empty_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

    # Blocca il rapporto d'aspetto durante il ridimensionamento.
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("aspect_ratio_locked.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
Questa impostazione *Lock Aspect Ratio* preserva solo il rapporto d'aspetto della forma, non il rapporto d'aspetto dell'immagine al suo interno.
{{% /alert %}}

## **Utilizzare le proprietà Stretch Offset**

Utilizzando le proprietà `stretch_offset_left`, `stretch_offset_top`, `stretch_offset_right` e `stretch_offset_bottom` della classe [PictureFillFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillformat/), è possibile definire un rettangolo di riempimento.

Quando viene specificata la tensione per un'immagine, il rettangolo sorgente viene scalato per adattarsi al rettangolo di riempimento. Ogni bordo del rettangolo di riempimento è definito da uno scostamento percentuale rispetto al bordo corrispondente della bounding box della forma. Una percentuale positiva specifica un rientro, mentre una percentuale negativa specifica un'estensione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni un riferimento a una diapositiva per indice.
3. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) rettangolare.
4. Imposta il tipo di riempimento della forma.
5. Imposta la modalità di riempimento immagine della forma.
6. Carica un'immagine.
7. Assegna l'immagine per riempire la forma.
8. Specifica gli offset dell'immagine rispetto ai bordi corrispondenti della bounding box della forma.
9. Salva la presentazione come file PPTX.

```py
import aspose.slides as slides

# Istanziare la classe Presentation che rappresenta un file PPTX.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi un AutoShape rettangolare.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 300, 300)

    # Imposta il tipo di riempimento della forma.
    shape.fill_format.fill_type = slides.FillType.PICTURE

    # Imposta la modalità di riempimento immagine della forma.
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Carica l'immagine e aggiungila alla presentazione.
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)

    # Assegna l'immagine per riempire la forma.
    shape.fill_format.picture_fill_format.picture.image = image

    # Specifica gli offset dell'immagine rispetto ai bordi corrispondenti della bounding box della forma.
    shape.fill_format.picture_fill_format.stretch_offset_left = 25
    shape.fill_format.picture_fill_format.stretch_offset_right = 25
    shape.fill_format.picture_fill_format.stretch_offset_top = -20
    shape.fill_format.picture_fill_format.stretch_offset_bottom = -10

    # Salva il file PPTX su disco.
    presentation.save("stretch_offset.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Aspose fornisce convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che ti permettono di creare rapidamente presentazioni da immagini.
{{% /alert %}}

## **FAQ**

**Come posso scoprire quali formati immagine sono supportati per PictureFrame?**

Aspose.Slides supporta sia immagini raster (PNG, JPEG, BMP, GIF, ecc.) sia immagini vettoriali (ad esempio SVG) tramite l'oggetto immagine assegnato a una [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/). L'elenco dei formati supportati si sovrappone generalmente alle capacità del motore di conversione di diapositive e immagini.

**Come influisce l'aggiunta di decine di immagini grandi sulle dimensioni e sulle prestazioni del PPTX?**

L'incorporamento di immagini grandi aumenta le dimensioni del file e l'uso della memoria; collegare le immagini aiuta a mantenere ridotte le dimensioni della presentazione ma richiede che i file esterni rimangano accessibili. Aspose.Slides offre la possibilità di aggiungere immagini tramite collegamento per ridurre le dimensioni del file.

**Come posso bloccare un oggetto immagine per evitare spostamenti/ridimensionamenti accidentali?**

Usa i [shape locks](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/picture_frame_lock/) per una [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) (ad esempio, disabilita lo spostamento o il ridimensionamento). Il meccanismo di blocco è descritto per le forme in un [articolo sulla protezione](/slides/it/python-net/applying-protection-to-presentation/) separato ed è supportato per vari tipi di forma, incluse le [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/).

**La fedeltà vettoriale SVG viene preservata quando si esporta una presentazione in PDF/immagini?**

Aspose.Slides consente di estrarre un SVG da una [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) come vettore originale. Quando si [esporta in PDF](/slides/it/python-net/convert-powerpoint-to-pdf/) o in [formati raster](/slides/it/python-net/convert-powerpoint-to-png/), il risultato può essere rasterizzato a seconda delle impostazioni di esportazione; il fatto che l'SVG originale sia memorizzato come vettore è confermato dal comportamento di estrazione.