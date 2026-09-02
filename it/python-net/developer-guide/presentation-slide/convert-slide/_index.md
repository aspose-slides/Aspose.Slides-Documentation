---
title: Converti diapositive di presentazione in immagini in Python
linktitle: Diapositiva in immagine
type: docs
weight: 41
url: /it/python-net/convert-slide/
keywords:
- converti diapositiva
- esporta diapositiva
- diapositiva in immagine
- salva diapositiva come immagine
- diapositiva in EMF
- diapositiva in PNG
- diapositiva in JPEG
- diapositiva in bitmap
- diapositiva in TIFF
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Converti le diapositive da presentazioni PPT, PPTX e ODP in PNG, JPEG, GIF, TIFF, EMF e altri formati immagine in Python con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET può renderizzare diapositive individuali da presentazioni PowerPoint e OpenDocument come PNG, JPEG, GIF, TIFF e altri formati immagine.

Per convertire una diapositiva in un'immagine, segui questi passaggi:

1. Carica la presentazione con la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Seleziona la diapositiva che desideri renderizzare.
3. Se necessario, configura il rendering con la classe [RenderingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/) o [TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/).
4. Chiama il metodo [Slide.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/). Restituisce un oggetto [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/).
5. Chiama il metodo [IImage.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/save/) e specifica il formato di output con un valore [ImageFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/imageformat/).

## **Converti una diapositiva in un'immagine PNG**

La conversione più semplice utilizza le impostazioni di rendering predefinite. L'oggetto [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) risultante può essere elaborato in memoria o salvato su disco.

Il seguente esempio Python renderizza la prima diapositiva e la salva come immagine PNG:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Converti diapositive in immagini con dimensioni personalizzate**

Utilizza la sovraccarico [Slide.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) che accetta un valore [Size](https://reference.aspose.com/slides/it/python-net/aspose.pydrawing/size/) per renderizzare una diapositiva con dimensioni pixel esatte.

Il seguente esempio crea un'immagine JPEG 1820 × 1040:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Converti diapositive con note e commenti in immagini**

Per impostazione predefinita, le immagini delle diapositive non includono note o commenti. Assegna un oggetto [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) alla proprietà [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) per controllare dove appaiono note e commenti.

Il seguente esempio posiziona note troncate sotto la diapositiva e commenti a destra:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Per la conversione diapositive‑immagine, non impostare la proprietà [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) su [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notespositions/). Le note possono contenere più testo di quanto la dimensione fissa dell'immagine possa contenere. Usa invece [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Converti diapositive in immagini usando le opzioni TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/tiffoptions/) consente di controllare dimensione, risoluzione e altre proprietà dell'immagine TIFF renderizzata.

Il seguente esempio renderizza la prima diapositiva come immagine TIFF 2160 × 2880 a 300 DPI:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Converti tutte le diapositive in immagini**

Itera la collezione di diapositive per convertire l'intera presentazione in una serie di immagini. Le diapositive nascoste sono incluse a meno che non le salti esplicitamente.

Il seguente esempio renderizza ogni diapositiva come immagine JPEG con fattori di scala orizzontale e verticale pari a 2:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Crea output Metafile avanzato**

Enhanced Metafile (EMF) è utile quando le grafiche vettoriali devono essere scambiate con Microsoft Office o altre applicazioni Windows che supportano i metafile Windows. A differenza di un'immagine basata su pixel, un EMF può conservare le operazioni di disegno vettoriale che si scalano senza la stessa perdita di nitidezza. Tuttavia, EMF è principalmente un formato di compatibilità per le applicazioni con supporto ai metafile Windows, non un formato di scambio universale. Inoltre, contenuti complessi delle diapositive, come immagini bitmap e alcuni effetti, possono essere memorizzati come elementi rasterizzati all'interno del contenitore vettoriale del metafile.

### **Esporta una diapositiva in EMF**

Il metodo [Slide.write_as_emf](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/write_as_emf/) scrive una [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/) su un flusso di destinazione in formato EMF. Il seguente esempio carica una presentazione, seleziona la prima diapositiva e la scrive su un flusso di file EMF:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

Il chiamante possiede il flusso passato a [Slide.write_as_emf](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/write_as_emf/) e deve chiuderlo. Aspose.Slides scrive nella posizione corrente del flusso e lo lascia aperto.

### **Converti un'immagine SVG in EMF e aggiungila a una presentazione**

Usa [SvgImage.write_as_emf](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/write_as_emf/) per convertire il contenuto SVG in EMF. I byte risultanti possono essere aggiunti alla presentazione tramite [ImageCollection.add_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/add_image/) e posizionati su una diapositiva con [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/).

Il seguente esempio crea un [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/) dal markup SVG, lo converte in un EMF in memoria, inserisce il metafile nella prima diapositiva e salva la presentazione:

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/write_as_emf/) non prende possesso del flusso di destinazione. Dopo la scrittura, la posizione del flusso è alla fine dei dati generati. Chiama `getvalue` per ottenere il buffer completo indipendentemente dalla posizione corrente del flusso, come mostrato sopra. Mantieni il flusso aperto finché i dati non sono stati letti, quindi chiudilo.

La generazione di EMF è disponibile sui sistemi operativi supportati da Aspose.Slides per Python tramite .NET, ma il rendering può variare tra le piattaforme quando i caratteri o le dipendenze grafiche native non sono disponibili. Installa i caratteri utilizzati dal contenuto di origine o configura sostituzioni adeguate, segui i [requisiti di piattaforma](/slides/it/python-net/system-requirements/) per Aspose.Slides e valida il risultato nell'applicazione di destinazione che consuma EMF. Le applicazioni Linux e macOS hanno spesso supporto limitato o incoerente per la visualizzazione e la modifica dei metafile Windows.

## **Rendering di Emoji a colori**

{{% alert title="Note" color="info" %}}
Per renderizzare correttamente le emoji a colori durante la conversione delle diapositive della presentazione in immagini, i caratteri emoji utilizzati nella presentazione devono essere installati e disponibili sul sistema che esegue la conversione. Ad esempio, se la presentazione utilizza **Segoe UI Emoji** e questo carattere manca, le emoji potrebbero apparire in bianco e nero nelle immagini di output.
{{% /alert %}}

## **Domande frequenti**

**Aspose.Slides supporta il rendering di diapositive con animazioni?**

No. Il metodo [Slide.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/) renderizza un'immagine statica della diapositiva e non esporta le animazioni.

**Le diapositive nascoste possono essere esportate come immagini?**

Sì. Le diapositive nascoste possono essere renderizzate come diapositive normali. Includile nel ciclo di elaborazione, come mostrato nell'esempio sopra.

**Le ombre e altri effetti sono preservati nelle immagini delle diapositive?**

Sì. Aspose.Slides renderizza ombre, trasparenza e altri effetti grafici supportati nelle immagini delle diapositive.