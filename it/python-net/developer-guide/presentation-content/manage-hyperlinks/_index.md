---
title: Gestire i collegamenti ipertestuali nelle presentazioni con Python
linktitle: Gestire collegamento
type: docs
weight: 20
url: /it/python-net/manage-hyperlinks/
keywords:
- aggiungere URL
- aggiungere collegamento ipertestuale
- creare collegamento ipertestuale
- formattare collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- collegamento ipertestuale su testo
- collegamento ipertestuale su diapositiva
- collegamento ipertestuale su forma
- collegamento ipertestuale su immagine
- collegamento ipertestuale su video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- Python
description: "Gestisci senza sforzo i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET—migliora l'interattività e il flusso di lavoro in pochi minuti."
---
## **Introduzione**

Un collegamento ipertestuale è un riferimento a una risorsa esterna, a un oggetto o a un elemento di dati, oppure a una posizione specifica all'interno di un file. I tipi comuni di collegamenti ipertestuali nelle presentazioni PowerPoint includono:

* Collegamenti a siti web incorporati in testo, forme o media
* Collegamenti a diapositive

Aspose.Slides per Python via .NET consente un'ampia gamma di operazioni relative ai collegamenti ipertestuali nelle presentazioni.

## **Aggiungere collegamenti ipertestuali URL**

Questa sezione spiega come aggiungere collegamenti ipertestuali URL agli elementi delle diapositive quando si lavora con Aspose.Slides. Copre l'assegnazione degli indirizzi dei collegamenti a testo, forme e immagini per garantire una navigazione fluida durante le presentazioni.

### **Aggiungere collegamenti ipertestuali URL al testo**

L'esempio di codice seguente mostra come aggiungere un collegamento ipertestuale a un sito web al testo:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Aggiungere collegamenti ipertestuali URL a forme o cornici**

L'esempio di codice seguente mostra come aggiungere un collegamento ipertestuale a un sito web a una forma:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Aggiungere collegamenti ipertestuali URL ai media**

Aspose.Slides consente di aggiungere collegamenti ipertestuali a immagini, file audio e video.

L'esempio di codice seguente mostra come aggiungere un collegamento ipertestuale a un'**immagine**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aggiungi un'immagine alla presentazione.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Crea un frame immagine sulla diapositiva 1 usando l'immagine aggiunta in precedenza.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

L'esempio di codice seguente mostra come aggiungere un collegamento ipertestuale a un **file audio**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

L'esempio di codice seguente mostra come aggiungere un collegamento ipertestuale a un **video**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Potresti voler vedere [Gestisci OLE nelle presentazioni usando Python](/slides/it/python-net/manage-ole/).
{{% /alert %}}

## **Usare i collegamenti ipertestuali per creare un indice**

Poiché i collegamenti ipertestuali consentono di fare riferimento a oggetti o posizioni, puoi usarli per creare un indice.

L'esempio di codice qui sotto mostra come creare un indice con collegamenti ipertestuali:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formattare i collegamenti ipertestuali**

Questa sezione mostra come formattare l'aspetto dei collegamenti ipertestuali in Aspose.Slides. Imparerai a controllare il colore e altre opzioni di stile per mantenere una formattazione coerente dei collegamenti ipertestuali su testo, forme e immagini.

### **Colore del collegamento ipertestuale**

Utilizzando la proprietà [color_source](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/color_source/) della classe [Hyperlink](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/), è possibile impostare il colore di un collegamento ipertestuale e leggere le informazioni sul colore. Questa funzionalità è stata introdotta in PowerPoint 2019, quindi le modifiche apportate tramite questa proprietà non si applicano alle versioni precedenti di PowerPoint.

L'esempio seguente dimostra come aggiungere collegamenti ipertestuali con colori diversi alla stessa diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Questa sezione spiega come rimuovere i collegamenti ipertestuali dalle presentazioni quando si lavora con Aspose.Slides. Imparerai come cancellare le destinazioni dei collegamenti da testo, forme e immagini preservando il contenuto e la formattazione originali.

### **Rimuovere i collegamenti ipertestuali dal testo**

L'esempio di codice seguente mostra come rimuovere i collegamenti ipertestuali dal testo su una diapositiva della presentazione:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Rimuovere i collegamenti ipertestuali da forme o cornici**

L'esempio di codice seguente mostra come rimuovere i collegamenti ipertestuali da forme su una diapositiva della presentazione:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Collegamenti ipertestuali modificabili**

La classe [Hyperlink](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/) è modificabile. Utilizzando questa classe, è possibile cambiare i valori di queste proprietà:

- [target_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

L'esempio di codice seguente mostra come aggiungere un collegamento ipertestuale a una diapositiva e poi modificare il suo tooltip:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Proprietà supportate in IHyperlinkQueries**

Puoi accedere a [HyperlinkQueries](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/) dalla presentazione, dalla diapositiva o dal testo che contiene il collegamento ipertestuale.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/hyperlink_queries/)

La classe [HyperlinkQueries](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/) supporta questi metodi:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Potresti voler dare un'occhiata al semplice e gratuito editor online di Aspose per [editor PowerPoint](https://products.aspose.app/slides/it/editor).
{{% /alert %}}

## **FAQ**

**Come posso creare una navigazione interna non solo a una diapositiva, ma a una "sezione" o alla prima diapositiva di una sezione?**

Le sezioni in PowerPoint sono raggruppamenti di diapositive; la navigazione tecnicamente punta a una diapositiva specifica. Per "navigare a una sezione", tipicamente si crea un collegamento alla sua prima diapositiva.

**Posso collegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. Tali collegamenti appaiono sulle diapositive figlie e sono cliccabili durante la presentazione.

**I collegamenti ipertestuali saranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Nella [PDF](/slides/it/python-net/convert-powerpoint-to-pdf/) e [HTML](/slides/it/python-net/convert-powerpoint-to-html/), sì — i collegamenti sono generalmente conservati. Quando si esporta in [immagini](/slides/it/python-net/convert-powerpoint-to-png/) e [video](/slides/it/python-net/convert-powerpoint-to-video/), la possibilità di fare clic non verrà mantenuta a causa della natura di quei formati (fotogrammi raster/video non supportano i collegamenti ipertestuali).