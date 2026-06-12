---
title: Converti PPT, PPTX e ODP in JPG con Python
linktitle: Converti diapositive in immagini JPG
type: docs
weight: 60
url: /it/python-net/convert-powerpoint-to-jpg/
keywords:
- converti PowerPoint in JPG
- converti presentazione in JPG
- converti diapositiva in JPG
- converti PPT in JPG
- converti PPTX in JPG
- converti ODP in JPG
- PowerPoint in JPG
- presentazione in JPG
- diapositiva in JPG
- PPT in JPG
- PPTX in JPG
- ODP in JPG
- converti PowerPoint in JPEG
- converti presentazione in JPEG
- converti diapositiva in JPEG
- converti PPT in JPEG
- converti PPTX in JPEG
- converti ODP in JPEG
- PowerPoint in JPEG
- presentazione in JPEG
- diapositiva in JPEG
- PPT in JPEG
- PPTX in JPEG
- ODP in JPEG
- Python
- Aspose.Slides
description: "Scopri come trasformare le tue diapositive da presentazioni PowerPoint e OpenDocument in immagini JPEG di alta qualità con poche righe di codice in Python. Ottimizza le presentazioni per l'uso web, la condivisione e l'archiviazione. Leggi la guida completa ora!"
---
## **Introduzione**

Convertire presentazioni PowerPoint e OpenDocument in immagini JPG aiuta a condividere le diapositive, ottimizzare le prestazioni e incorporare i contenuti in siti web o applicazioni. Aspose.Slides per Python consente di trasformare file PPTX, PPT e ODP in immagini JPEG di alta qualità. Questa guida spiega i diversi metodi di conversione.

Con queste funzionalità è facile implementare il proprio visualizzatore di presentazioni e creare una miniatura per ogni diapositiva. Questo può essere utile se desideri proteggere le diapositive dalla copia o mostrare la presentazione in modalità sola lettura. Aspose.Slides permette di convertire l'intera presentazione o una diapositiva specifica in formati immagine.

## **Converti le diapositive della presentazione in immagini JPG**

Ecco i passaggi per convertire un file PPT, PPTX o ODP in JPG:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni l'oggetto diapositiva di tipo [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/) dalla collezione [Presentation.slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/).
1. Crea un'immagine della diapositiva utilizzando il metodo [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#float-float).
1. Chiama il metodo [IImage.save(filename, format)](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/save/#str-imageformat) sull'oggetto immagine. Passa il nome del file di output e il formato dell'immagine come argomenti.

{{% alert color="primary" %}}

**Nota:** la conversione da PPT, PPTX o ODP a JPG differisce dalla conversione verso altri formati nell'API Python di Aspose.Slides. Per altri formati, solitamente utilizzi il metodo [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). Tuttavia, per la conversione a JPG, è necessario utilizzare il metodo [IImage.save(filename, format)](https://reference.aspose.com/slides/it/python-net/aspose.slides/iimage/save/#str-imageformat).

{{% /alert %}}

```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Salva l'immagine su disco in formato JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Converti le diapositive in JPG con dimensioni personalizzate**

Per modificare le dimensioni delle immagini JPG risultanti, è possibile impostare la dimensione dell'immagine passando il valore al metodo [Slide.get_image(image_size)](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/#asposepydrawingsize). Ciò consente di generare immagini con larghezza e altezza specifiche, garantendo che l'output soddisfi i requisiti di risoluzione e proporzioni. Questa flessibilità è particolarmente utile quando si generano immagini per applicazioni web, report o documentazione, dove sono necessarie dimensioni precise dell'immagine.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Crea un'immagine della diapositiva delle dimensioni specificate.
        with slide.get_image(image_size) as thumbnail:
            # Salva l'immagine su disco in formato JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```

## **Rendi i commenti quando si salvano le diapositive come immagini**

Aspose.Slides per Python offre una funzionalità che consente di renderizzare i commenti sulle diapositive di una presentazione durante la conversione in immagini JPG. Questa funzionalità è particolarmente utile per preservare annotazioni, feedback o discussioni aggiunte dai collaboratori nelle presentazioni PowerPoint. Abilitando questa opzione, i commenti saranno visibili nelle immagini generate, facilitando la revisione e la condivisione del feedback senza dover aprire il file della presentazione originale.

Supponiamo di avere un file di presentazione, "sample.pptx", con una diapositiva che contiene commenti:

![La diapositiva con commenti](slide_with_comments.png)

Il seguente codice Python converte la diapositiva in un'immagine JPG preservando i commenti:

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Imposta le opzioni per i commenti della diapositiva.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Converte la prima diapositiva in un'immagine.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```

Il risultato:

![L'immagine JPG con commenti](image_with_comments.png)

## **Vedi anche**

Consulta altre opzioni per convertire PPT, PPTX o ODP in immagini, ad esempio:

- [Converti PowerPoint in GIF](/slides/it/python-net/convert-powerpoint-to-animated-gif/)
- [Converti PowerPoint in PNG](/slides/it/python-net/convert-powerpoint-to-png/)
- [Converti PowerPoint in TIFF](/slides/it/python-net/convert-powerpoint-to-tiff/)
- [Converti PowerPoint in SVG](/slides/it/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Per vedere come Aspose.Slides converte PowerPoint in immagini JPG, prova questi convertitori online gratuiti: PowerPoint [PPTX in JPG](https://products.aspose.app/slides/it/conversion/pptx-to-jpg) e [PPT in JPG](https://products.aspose.app/slides/it/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Convertitore online gratuito PPTX in JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose offre una [app web GRATUITA per collage](https://products.aspose.app/slides/it/collage). Utilizzando questo servizio online, puoi unire immagini [JPG in JPG](https://products.aspose.app/slides/it/collage/jpg) o PNG in PNG, creare [griglie fotografiche](https://products.aspose.app/slides/it/collage/photo-grid) e così via. 

Usando gli stessi principi descritti in questo articolo, puoi convertire le immagini da un formato all'altro. Per ulteriori informazioni, consulta queste pagine: converti [immagine in JPG](https://products.aspose.com/slides/it/python-net/conversion/image-to-jpg/); converti [JPG in immagine](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-image/); converti [JPG in PNG](https://products.aspose.com/slides/it/python-net/conversion/jpg-to-png/); converti [PNG in JPG](https://products.aspose.com/slides/it/python-net/conversion/png-to-jpg/); converti [PNG in SVG](https://products.aspose.com/slides/it/python-net/conversion/png-to-svg/); converti [SVG in PNG](https://products.aspose.com/slides/it/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Questo metodo supporta la conversione batch?**

Sì, Aspose.Slides permette la conversione batch di più diapositive in JPG in un'unica operazione.

**La conversione supporta SmartArt, grafici e altri oggetti complessi?**

Sì, Aspose.Slides renderizza tutti i contenuti, inclusi SmartArt, grafici, tabelle, forme e altro. Tuttavia, la precisione del rendering può variare leggermente rispetto a PowerPoint, specialmente quando si utilizzano caratteri personalizzati o mancanti.

**Esistono limitazioni sul numero di diapositive che possono essere elaborate?**

Aspose.Slides di per sé non impone limiti rigidi sul numero di diapositive che è possibile elaborare. Tuttavia, potresti incontrare errori di out-of-memory lavorando con presentazioni molto grandi o immagini ad alta risoluzione.