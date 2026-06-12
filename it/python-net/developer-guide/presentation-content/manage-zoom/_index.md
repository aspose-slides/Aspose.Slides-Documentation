---
title: Gestire gli Zoom nelle Presentazioni con Python
linktitle: Zoom
type: docs
weight: 60
url: /it/python-net/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom diapositiva
- zoom sezione
- zoom riepilogo
- aggiungere zoom
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Crea e personalizza lo Zoom con Aspose.Slides per Python tramite .NET — passa tra le sezioni, aggiungi miniature e transizioni in presentazioni PPT, PPTX e ODP."
---
## **Introduzione**

Gli Zoom in PowerPoint consentono di spostarsi da e verso diapositive specifiche, sezioni e parti di una presentazione. Quando si presenta, questa capacità di navigare rapidamente tra i contenuti può rivelarsi molto utile. 

![overview](overview.png)

* Per riassumere un'intera presentazione in un'unica diapositiva, utilizzare uno [Zoom di riepilogo](#Summary-Zoom).
* Per mostrare solo le diapositive selezionate, utilizzare uno [Zoom diapositiva](#Slide-Zoom).
* Per mostrare una sola sezione, utilizzare uno [Zoom sezione](#Section-Zoom).

## **Zoom diapositiva**

Uno zoom diapositiva può rendere la presentazione più dinamica, consentendo di navigare liberamente tra le diapositive in qualsiasi ordine si scelga senza interrompere il flusso della presentazione. Gli zoom diapositiva sono ottimi per presentazioni brevi senza molte sezioni, ma è comunque possibile usarli in diversi scenari di presentazione.

Gli zoom diapositiva ti aiutano a approfondire più informazioni contemporaneamente, pur dando l'impressione di essere su una singola tela. 

![slidezoomsel](slidezoomsel.png)

Per gli oggetti zoom diapositiva, Aspose.Slides fornisce l'enumerazione [ZoomImageType](https://reference.aspose.com/slides/it/python-net/aspose.slides/zoomimagetype/) , la classe [ZoomFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/zoomframe/) e alcuni metodi nella classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/) .

### **Creazione dei frame di zoom**
È possibile aggiungere un frame di zoom su una diapositiva in questo modo:

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare nuove diapositive a cui si intende collegare. 
3.	Aggiungere un testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungere i frame di zoom (contenenti i riferimenti alle diapositive create) nella prima diapositiva.
5.	Scrivere la presentazione modificata come file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Aggiungi nuove diapositive alla presentazione
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crea uno sfondo per la seconda diapositiva
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crea una casella di testo per la seconda diapositiva
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Crea uno sfondo per la terza diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crea una casella di testo per la terza diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Aggiungi oggetti ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Salva la presentazione
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Creazione di frame di zoom con immagini personalizzate**
Con Aspose.Slides per Python via .NET, è possibile creare un frame di zoom con un'immagine diversa dall'immagine di anteprima della diapositiva in questo modo: 
1.	Creare un'istanza della classe `Presentation` .
2.	Creare una nuova diapositiva a cui si intende collegare. 
3.	Aggiungere un testo di identificazione e uno sfondo alla diapositiva creata.
4.	Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo un'immagine alla collezione Images associata all'oggetto Presentation che verrà usata per riempire il frame.
5.	Aggiungere i frame di zoom (contenenti il riferimento alla diapositiva creata) nella prima diapositiva.
6.	Scrivere la presentazione modificata come file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Aggiungi una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crea uno sfondo per la seconda diapositiva
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crea una casella di testo per la terza diapositiva
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Crea una nuova immagine per l'oggetto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Aggiungi l'oggetto ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Salva la presentazione
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formattazione dei frame di zoom**
Nelle sezioni precedenti (sopra), ti abbiamo mostrato come creare frame di zoom semplici. Per creare frame di zoom più complessi, è necessario modificare la formattazione dei frame. Esistono diverse impostazioni di formattazione che è possibile applicare a un frame di zoom. 

È possibile controllare la formattazione di un frame di zoom su una diapositiva in questo modo:

1.	Creare un'istanza della classe `Presentation` .
2.	Creare nuove diapositive a cui collegarsi. 
3.	Aggiungere un testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungere i frame di zoom (contenenti i riferimenti alle diapositive create) nella prima diapositiva.
5.	Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo un'immagine alla collezione Images associata all'oggetto Presentation che verrà usata per riempire il frame.
6.	Impostare un'immagine personalizzata per il primo oggetto frame di zoom.
7.	Modificare il formato della linea per il secondo oggetto frame di zoom.
8.	Rimuovere lo sfondo da un'immagine del secondo oggetto frame di zoom.
5.	Scrivere la presentazione modificata come file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Aggiungi nuove diapositive alla presentazione
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Crea uno sfondo per la seconda diapositiva
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Crea una casella di testo per la seconda diapositiva
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Crea uno sfondo per la terza diapositiva
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Crea una casella di testo per la terza diapositiva
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Aggiungi oggetti ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Crea una nuova immagine per l'oggetto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Imposta immagine personalizzata per l'oggetto zoomFrame1
    zoomFrame1.image = image

    # Imposta un formato di frame zoom per l'oggetto zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Non mostrare lo sfondo per l'oggetto zoomFrame2
    zoomFrame2.show_background = False

    # Salva la presentazione
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom sezione**

Uno zoom sezione è un collegamento a una sezione della tua presentazione. Puoi usare gli zoom sezione per tornare a sezioni che vuoi davvero enfatizzare. Oppure puoi usarli per evidenziare come certe parti della tua presentazione si collegano. 

![seczoomsel](seczoomsel.png)

Per gli oggetti zoom sezione, Aspose.Slides fornisce la classe [SectionZoomFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectionzoomframe/) e alcuni metodi nella classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/) .

### **Creazione di frame zoom sezione**

È possibile aggiungere un frame zoom sezione a una diapositiva in questo modo:

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare una nuova diapositiva. 
3.	Aggiungere uno sfondo di identificazione alla diapositiva creata.
4.	Creare una nuova sezione a cui collegare il frame zoom.
5.	Aggiungere un frame zoom sezione (contenente i riferimenti alla sezione creata) alla prima diapositiva.
6.	Scrivere la presentazione modificata come file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 1", slide)

    # Aggiunge un oggetto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Salva la presentazione
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Creazione di frame zoom sezione con immagini personalizzate**

Utilizzando Aspose.Slides per Python, è possibile creare un frame zoom sezione con un'immagine di anteprima della diapositiva diversa in questo modo: 

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare una nuova diapositiva.
3.	Aggiungere uno sfondo di identificazione alla diapositiva creata.
4.	Creare una nuova sezione a cui collegare il frame zoom. 
5.	Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) che verrà usata per riempire il frame.
6.	Aggiungere un frame zoom sezione (contenente un riferimento alla sezione creata) alla prima diapositiva.
7.	Scrivere la presentazione modificata come file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 1", slide)

    # Crea una nuova immagine per l'oggetto zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Aggiunge un oggetto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Salva la presentazione
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formattazione dei frame zoom sezione**

Per creare frame zoom sezione più complicati, è necessario modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che è possibile applicare a un frame zoom sezione. 

È possibile controllare la formattazione di un frame zoom sezione su una diapositiva in questo modo:

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare una nuova diapositiva.
3.	Aggiungere uno sfondo di identificazione alla diapositiva creata.
4.	Creare una nuova sezione a cui collegare il frame zoom. 
5.	Aggiungere un frame zoom sezione (contenente i riferimenti alla sezione creata) alla prima diapositiva.
6.	Modificare le dimensioni e la posizione dell'oggetto zoom sezione creato.
7.	Creare un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) che verrà usata per riempire il frame.
8.	Impostare un'immagine personalizzata per l'oggetto frame zoom sezione creato.
9.	Impostare la funzionalità *ritorno alla diapositiva originale dalla sezione collegata*.
10.	Rimuovere lo sfondo da un'immagine dell'oggetto frame zoom sezione.
11.	Modificare il formato della linea per il secondo oggetto frame di zoom.
12.	Modificare la durata della transizione.
13.	Scrivere la presentazione modificata come file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 1", slide)

    # Aggiunge un oggetto SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formattazione per SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Salva la presentazione
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom di riepilogo**

Uno zoom di riepilogo è come una pagina di destinazione in cui tutte le parti della tua presentazione sono visualizzate contemporaneamente. Quando presenti, puoi usare lo zoom per passare da un punto all'altro della presentazione in qualsiasi ordine desideri. Puoi essere creativo, saltare avanti o tornare a parti della presentazione senza interrompere il flusso. 

![overview_image](summaryzoom.png)

Per gli oggetti zoom di riepilogo, Aspose.Slides fornisce le classi [SummaryZoomFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/it/python-net/aspose.slides/summaryzoomsection/) e [SummaryZoomSectionCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/summaryzoomsectioncollection/) e alcuni metodi nella classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/) .

### **Creazione di zoom di riepilogo**

È possibile aggiungere un frame zoom di riepilogo a una diapositiva in questo modo:

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungere il frame zoom di riepilogo alla prima diapositiva.
4.	Scrivere la presentazione modificata come file PPTX.

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Crea un array di diapositive
    for slideNumber in range(5):
        #Aggiungi nuove diapositive alla presentazione
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Crea uno sfondo per la diapositiva
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Crea una casella di testo per la diapositiva
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Crea oggetti zoom per tutte le diapositive nella prima diapositiva
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Imposta la proprietà ReturnToParent per tornare alla prima diapositiva
        zoomFrame.return_to_parent = True

    # Salva la presentazione
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Aggiunta e rimozione di sezioni zoom di riepilogo**

Tutte le sezioni in un frame zoom di riepilogo sono rappresentate da oggetti [SummaryZoomSection], che sono memorizzati nell'oggetto [SummaryZoomSectionCollection]. È possibile aggiungere o rimuovere un oggetto sezione zoom di riepilogo tramite la classe [SummaryZoomSectionCollection] in questo modo:

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungere un frame zoom di riepilogo nella prima diapositiva.
4.	Aggiungere una nuova diapositiva e una nuova sezione alla presentazione.
5.	Aggiungere la sezione creata al frame zoom di riepilogo.
6.	Rimuovere la prima sezione dal frame zoom di riepilogo.
7.	Scrivere la presentazione modificata come file PPTX.

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 1", slide)

    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 2", slide)

    # Aggiunge l'oggetto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Aggiunge una nuova sezione alla presentazione
    section3 = pres.sections.add_section("Section 3", slide)

    # Aggiunge una sezione allo Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Rimuove la sezione dallo Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Salva la presentazione
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formattazione delle sezioni zoom di riepilogo**

Per creare oggetti sezione zoom di riepilogo più complessi, è necessario modificare la formattazione di un frame semplice. Esistono diverse opzioni di formattazione che è possibile applicare a un oggetto sezione zoom di riepilogo. 

È possibile controllare la formattazione di un oggetto sezione zoom di riepilogo in un frame zoom di riepilogo in questo modo:

1.	Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) .
2.	Creare nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungere un frame zoom di riepilogo alla prima diapositiva.
4.	Ottenere un oggetto sezione zoom di riepilogo per il primo oggetto dalla `SummaryZoomSectionCollection` .
5.	Creare un oggetto `PPImage` aggiungendo un'immagine alla collezione images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) che verrà usata per riempire il frame.
6.	Impostare un'immagine personalizzata per l'oggetto frame zoom sezione creato.
7.	Impostare la funzionalità *ritorno alla diapositiva originale dalla sezione collegata*.
8.	Modificare il formato della linea per il secondo oggetto frame di zoom.
9.	Modificare la durata della transizione.
10.	Scrivere la presentazione modificata come file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 1", slide)

    #Aggiunge una nuova diapositiva alla presentazione
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Aggiunge una nuova sezione alla presentazione
    pres.sections.add_section("Section 2", slide)

    # Aggiunge un oggetto SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Ottiene il primo oggetto SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formattazione per l'oggetto SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Salva la presentazione
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso controllare il ritorno alla diapositiva 'genitore' dopo aver mostrato il target?**

Sì. Il [Zoom frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectionzoomframe/) ha un comportamento `return_to_parent` che, quando abilitato, riporta gli spettatori alla diapositiva originaria dopo che hanno visualizzato il contenuto di destinazione.

**Posso regolare la 'velocità' o la durata della transizione Zoom?**

Sì. Zoom supporta l'impostazione di `transition_duration`, così è possibile controllare la durata dell'animazione di salto.

**Ci sono limiti al numero di oggetti Zoom che una presentazione può contenere?**

Non esiste un limite rigido documentato dall'API. I limiti pratici dipendono dalla complessità complessiva della presentazione e dalle prestazioni del visualizzatore. È possibile aggiungere molti frame Zoom, ma è consigliabile considerare la dimensione del file e il tempo di rendering.