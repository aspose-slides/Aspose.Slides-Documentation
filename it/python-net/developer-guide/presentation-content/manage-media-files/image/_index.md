---
title: "Ottimizza la gestione delle immagini in PowerPoint con Python"
linktitle: "Gestisci le immagini"
type: docs
weight: 10
url: /it/python-net/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- dal web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- presentazione
- Python
- Aspose.Slides
description: "Semplifica la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Python via .NET, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre fonti nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive in diversi modi.

{{% alert  title="Suggerimento" color="primary" %}}
Aspose offre converter gratuiti—[JPEG a PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG a PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire da immagini.
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Se desideri aggiungere un'immagine come oggetto frame—soprattutto se intendi utilizzare opzioni di formattazione standard come il ridimensionamento o l'applicazione di effetti—vedi [Aggiungere fotogrammi immagine alle presentazioni con Python](https://docs.aspose.com/slides/it/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Nota" color="warning" %}}
Puoi utilizzare le operazioni I/O di immagini e presentazioni per convertire le immagini tra formati. Vedi queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/python-net/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-png/); converti [PNG in JPG](https://products.aspose.com/slides/it/python-net/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/python-net/conversion/png-to-svg/); e converti [SVG in PNG](https://products.aspose.com/slides/it/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides supporta la gestione delle immagini nei formati più diffusi, come JPEG, PNG, BMP, GIF e altri.

## **Aggiungere immagini salvate localmente alle diapositive**

È possibile aggiungere una o più immagini dal proprio computer a una diapositiva di una presentazione. Il seguente esempio Python mostra come aggiungere un'immagine a una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere immagini dal Web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi inserirla direttamente dal web.

Il seguente esempio Python mostra come aggiungere un'immagine da un URL a una diapositiva:

```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere immagini ai master delle diapositive**

Un master diapositiva è la diapositiva di livello superiore che memorizza e controlla le informazioni—tema, layout, ecc.—per tutte le diapositive sottostanti. Quando aggiungi un'immagine a un master diapositiva, quell'immagine appare su ogni diapositiva che utilizza quel master.

Il seguente esempio Python mostra come aggiungere un'immagine a un master diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Impostare un'immagine come sfondo della diapositiva**

Potresti voler utilizzare un'immagine come sfondo per una diapositiva specifica o per più diapositive. Per dettagli, vedi [Impostare un'immagine come sfondo di una diapositiva](https://docs.aspose.com/slides/it/python-net/presentation-background/#set-image-as-background-for-slide).

## **Aggiungere SVG alle presentazioni**

È possibile inserire qualsiasi immagine in una presentazione usando il metodo [add_picture_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_picture_frame/) della classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/).

Per creare un oggetto immagine da un SVG, segui questi passaggi:

1. Crea un [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/) e aggiungilo alla collezione di immagini della presentazione.  
2. Crea un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) a partire dal [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/).  
3. Crea un oggetto [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) utilizzando il [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).

Il seguente esempio Python mostra come aggiungere un'immagine SVG a una presentazione utilizzando questi passaggi:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Leggi il contenuto di un file SVG.
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # Crea un oggetto SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Crea un oggetto PPImage.
        pp_image = presentation.images.add_image(svg_image)

        # Crea un nuovo PictureFrame.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # Salva la presentazione in formato PPTX.
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Convertire SVG in un insieme di forme**

Aspose.Slides converte gli SVG in un insieme di forme in modo simile alla gestione degli SVG di PowerPoint.

![Menu a comparsa di PowerPoint](img_01_01.png)

Questa funzionalità è fornita da una sovraccarico del metodo [add_group_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_group_shape/) nella classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/), che accetta un [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/) come primo argomento.  

Il codice di esempio sotto mostra come convertire un file SVG in un insieme di forme.

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Leggi il contenuto del file SVG.
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # Crea un oggetto SvgImage.
        svg_image = slides.SvgImage(svg_content)

        # Ottieni le dimensioni della diapositiva.
        slide_size = presentation.slide_size.size

        # Converti l'immagine SVG in un gruppo di forme e scala alle dimensioni della diapositiva.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Salva la presentazione in formato PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungere immagini come EMF nelle diapositive**

Aspose.Slides per Python consente di inserire immagini Enhanced Metafile (EMF) nelle presentazioni.

Il seguente esempio Python dimostra questo:

```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Sostituire immagini nella raccolta di immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella raccolta di immagini di una presentazione, incluse quelle utilizzate dalle forme delle diapositive. Questa sezione descrive diversi approcci per aggiornare le immagini nella raccolta. L'API offre metodi semplici per sostituire un'immagine con dati byte grezzi, con un'istanza di [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) o con un'altra immagine già presente nella raccolta.

1. Carica la presentazione che contiene le immagini usando la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).  
2. Carica una nuova immagine da un file in un array di byte.  
3. Sostituisci l'immagine target con la nuova immagine usando l'array di byte.  
4. In alternativa, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/) e sostituisci l'immagine target con quell'oggetto.  
5. Oppure sostituisci l'immagine target con un'immagine già presente nella raccolta di immagini della presentazione.  
6. Salva la presentazione modificata come file PPTX.

```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:

    # Il primo modo.
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # Il secondo modo.
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # Il terzo modo.
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # Salva la presentazione in un file.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Info" color="info" %}}
Con il convertitore gratuito [Testo in GIF](https://products.aspose.app/slides/it/text-to-gif) di Aspose, puoi facilmente animare il testo e creare GIF dal testo.
{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel di origine sono preservati, ma l'aspetto finale dipende da come il [picture](/slides/it/python-net/picture-frame/) è ridimensionato sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella raccolta di immagini della presentazione—gli aggiornamenti si propagheranno a tutti gli elementi che usano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. Puoi convertire un SVG in un gruppo di forme, dopodiché le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/python-net/presentation-background/) sul master della diapositiva o sul layout pertinente—tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come posso impedire che la presentazione aumenti notevolmente di dimensioni a causa di molte immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica compressione al salvataggio e mantieni le grafiche ripetute sul master quando opportuno.