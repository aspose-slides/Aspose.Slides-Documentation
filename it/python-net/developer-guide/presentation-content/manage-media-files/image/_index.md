---
title: Ottimizza la gestione delle immagini in PowerPoint con Python
linktitle: Gestisci Immagini
type: docs
weight: 10
url: /it/python-net/image/
keywords:
- aggiungi immagine
- aggiungi foto
- aggiungi bitmap
- sostituisci immagine
- sostituisci foto
- da web
- sfondo
- aggiungi PNG
- aggiungi JPG
- aggiungi SVG
- aggiungi EMF
- aggiungi WMF
- aggiungi TIFF
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Semplifica la gestione delle immagini in PowerPoint e OpenDocument con Aspose.Slides per Python su .NET, ottimizzando le prestazioni e automatizzando il tuo flusso di lavoro."
---
## **Introduzione**

Le immagini rendono le presentazioni più coinvolgenti e interessanti. In Microsoft PowerPoint, è possibile inserire immagini da un file, da Internet o da altre fonti nelle diapositive. Allo stesso modo, Aspose.Slides consente di aggiungere immagini alle diapositive in diversi modi.

{{% alert  title="Suggerimento" color="primary" %}}
Aspose offre convertitori gratuiti—[JPEG to PowerPoint](https://products.aspose.app/slides/it/import/jpg-to-ppt) e [PNG to PowerPoint](https://products.aspose.app/slides/it/import/png-to-ppt)—che consentono di creare rapidamente presentazioni a partire dalle immagini.
{{% /alert %}}

{{% alert title="Informazione" color="info" %}}
Se desideri aggiungere un'immagine come oggetto fotogramma—specialmente se prevedi di utilizzare opzioni di formattazione standard come il ridimensionamento o l'applicazione di effetti—vedi [Add Picture Frames to Presentations with Python](https://docs.aspose.com/slides/it/python-net/picture-frame/).
{{% /alert %}}

{{% alert title="Nota" color="warning" %}}
È possibile utilizzare le operazioni I/O di immagini e presentazioni per convertire le immagini tra formati. Vedi queste pagine: converti [image to JPG](https://products.aspose.com/slides/it/python-net/conversion/image-to-jpg/); converti [JPG to image](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-image/); converti [JPG to PNG](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-png/); converti [PNG to JPG](https://products.aspose.com/slides/it/python-net/conversion/png-to-jpg/); converti [PNG to SVG](https://products.aspose.com/slides/it/python-net/conversion/png-to-svg/); e converti [SVG to PNG](https://products.aspose.com/slides/it/python-net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides supporta il lavoro con immagini nei formati più diffusi come JPEG, PNG, BMP, GIF e altri.

## **Aggiungi immagini memorizzate localmente alle diapositive**

È possibile aggiungere una o più immagini dal proprio computer a una diapositiva in una presentazione. Il seguente esempio Python mostra come aggiungere un'immagine a una diapositiva:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi immagini dal Web alle diapositive**

Se l'immagine che desideri aggiungere a una diapositiva non è disponibile sul tuo computer, puoi inserirla direttamente dal web.

Il seguente esempio Python mostra come aggiungere un'immagine da un URL a una diapositiva:

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Scarica i byte grezzi dell'immagine.
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi immagini ai master delle diapositive**

Un master della diapositiva è la diapositiva di livello superiore che memorizza e controlla le informazioni—tema, layout e così via—per tutte le diapositive al di sotto di essa. Quando aggiungi un'immagine a un master della diapositiva, quell'immagine compare su ogni diapositiva che utilizza quel master.

Il seguente esempio Python mostra come aggiungere un'immagine a un master della diapositiva:

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

## **Aggiungi immagini come sfondi delle diapositive**

Puoi utilizzare un'immagine come sfondo per una o più diapositive. Per i dettagli, vedere *[Setting Images as Backgrounds for Slides](/slides/it/python-net/presentation-background/#setting-images-as-background-for-slides)*.

## **Aggiungi SVG alle presentazioni**

Il contenuto SVG può essere aggiunto a una presentazione utilizzando la classe [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/). L'immagine SVG risultante può quindi essere aggiunta alla raccolta immagini della presentazione e utilizzata per creare un fotogramma immagine.

Il seguente esempio Python importa una stringa SVG autonoma. Tutte le immagini, gli stili e le altre risorse utilizzate da questo SVG sono incorporati direttamente nel contenuto SVG.

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **Converti SVG in un insieme di forme**

Aspose.Slides converte gli SVG in un insieme di forme in modo simile alla gestione degli SVG di PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Questa funzionalità è fornita da una sovraccarico del metodo [add_group_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_group_shape/) nella classe [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/) che accetta un [SvgImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/svgimage/) come primo argomento.

Il codice di esempio qui sotto mostra come convertire un file SVG in un insieme di forme.

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

        # Converte l'immagine SVG in un gruppo di forme e la ridimensiona alla dimensione della diapositiva.
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # Salva la presentazione in formato PPTX.
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiungi immagini come EMF alle diapositive**

Aspose.Slides per Python consente di inserire immagini Enhanced Metafile (EMF) nelle presentazioni.

Il seguente esempio Python dimostra questo:

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **Sostituisci immagini nella raccolta immagini**

Aspose.Slides consente di sostituire le immagini memorizzate nella raccolta immagini di una presentazione, incluse quelle utilizzate dalle forme delle diapositive. Questa sezione descrive diversi approcci per aggiornare le immagini nella raccolta. L'API offre metodi semplici per sostituire un'immagine con dati byte grezzi, un'istanza [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/), o un'altra immagine già presente nella raccolta.

Segui questi passaggi:

1. Carica la presentazione che contiene le immagini utilizzando la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Carica una nuova immagine da un file in un array di byte.
3. Sostituisci l'immagine target con la nuova immagine utilizzando l'array di byte.
4. In alternativa, carica l'immagine in un oggetto [IImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/), e sostituisci l'immagine target con quell'oggetto.
5. Oppure sostituisci l'immagine target con un'immagine che esiste già nella raccolta immagini della presentazione.
6. Salva la presentazione modificata come file PPTX.

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# Istanziate la classe Presentation che rappresenta un file di presentazione.
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

{{% alert title="Informazione" color="info" %}}
Con il convertitore gratuito [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) di Aspose, è possibile animare facilmente il testo e creare GIF dal testo.
{{% /alert %}}

## **FAQ**

**La risoluzione originale dell'immagine rimane intatta dopo l'inserimento?**

Sì. I pixel originali sono preservati, ma l'aspetto finale dipende da come l[picture](/slides/it/python-net/picture-frame/) viene scalato sulla diapositiva e da eventuali compressioni applicate al salvataggio.

**Qual è il modo migliore per sostituire lo stesso logo su decine di diapositive contemporaneamente?**

Posiziona il logo sul master della diapositiva o su un layout e sostituiscilo nella raccolta immagini della presentazione—gli aggiornamenti si propagheranno a tutti gli elementi che utilizzano quella risorsa.

**Un SVG inserito può essere convertito in forme modificabili?**

Sì. È possibile convertire un SVG in un gruppo di forme, dopo di che le singole parti diventano modificabili con le proprietà standard delle forme.

**Come posso impostare un'immagine come sfondo per più diapositive contemporaneamente?**

[Assegna l'immagine come sfondo](/slides/it/python-net/presentation-background/) sul master della diapositiva o sul layout pertinente—tutte le diapositive che utilizzano quel master/layout erediteranno lo sfondo.

**Come posso evitare che una presentazione diventi troppo grande a causa di molte immagini?**

Riutilizza una singola risorsa immagine invece di duplicati, scegli risoluzioni ragionevoli, applica la compressione al salvataggio e mantieni le grafiche ripetute sul master dove opportuno.