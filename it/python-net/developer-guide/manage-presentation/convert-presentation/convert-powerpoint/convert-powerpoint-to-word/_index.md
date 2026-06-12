---
title: Convertire presentazioni PowerPoint in documenti Word con Python
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /it/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint in DOCX
- OpenDocument in DOCX
- presentazione in DOCX
- diapositiva in DOCX
- PPT in DOCX
- PPTX in DOCX
- ODP in DOCX
- PowerPoint in DOC
- OpenDocument in DOC
- presentazione in DOC
- diapositiva in DOC
- PPT in DOC
- PPTX in DOC
- ODP in DOC
- PowerPoint in Word
- OpenDocument in Word
- presentazione in Word
- diapositiva in Word
- PPT in Word
- PPTX in Word
- ODP in Word
- convertire PowerPoint
- convertire OpenDocument
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- convertire ODP
- Python
- Aspose.Slides
description: "Scopri come convertire facilmente presentazioni PowerPoint e OpenDocument in documenti Word utilizzando Aspose.Slides per Python via .NET. La nostra guida passo‑passo con esempio di codice Python offre la soluzione per gli sviluppatori che desiderano ottimizzare i flussi di lavoro dei documenti."
---
## **Panoramica**

Questo articolo fornisce una soluzione per gli sviluppatori per la conversione di presentazioni PowerPoint e OpenDocument in documenti Word utilizzando Aspose.Slides per Python via .NET e Aspose.Words per Python via .NET. La guida passo‑passo ti accompagna attraverso ogni fase del processo di conversione.

## **Convertire una presentazione in un documento Word**

Segui le istruzioni riportate di seguito per convertire una presentazione PowerPoint o OpenDocument in un documento Word:

1. Istanziare la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e caricare un file di presentazione.
2. Istanziare le classi [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) e [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) per generare un documento Word.
3. Impostare le dimensioni della pagina del documento Word in modo da corrispondere a quelle della presentazione utilizzando la proprietà [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
4. Impostare i margini nel documento Word usando la proprietà [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/).
5. Scorrere tutte le diapositive della presentazione usando la proprietà [Presentation.slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/).
    - Generare un'immagine della diapositiva usando il metodo `get_image` della classe [Slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/) e salvarla in uno stream di memoria.
    - Aggiungere l'immagine della diapositiva al documento Word usando il metodo `insert_image` della classe [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) .
6. Salvare il documento Word su un file.

Supponiamo di avere una presentazione "sample.pptx" che appare così:

![Presentazione PowerPoint](PowerPoint.png)

```py
import aspose.slides as slides
import aspose.words as words

# Carica un file di presentazione.
with slides.Presentation("sample.pptx") as presentation:

    # Crea gli oggetti Document e DocumentBuilder.
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # Imposta le dimensioni della pagina nel documento Word.
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # Imposta i margini nel documento Word.
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # Scorri tutte le diapositive della presentazione.
    for slide in presentation.slides:

        # Genera un'immagine della diapositiva e salvala in uno stream di memoria.
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # Aggiungi l'immagine della diapositiva al documento Word.
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # Salva il documento Word su un file.
    document.save("output.docx")
```

Il risultato:

![Documento Word](Word.png)

{{% alert color="primary" %}} 
Prova il nostro [**Convertitore PPT in Word online**](https://products.aspose.app/slides/it/conversion/ppt-to-word) per vedere cosa potresti ottenere convertendo presentazioni PowerPoint e OpenDocument in documenti Word. 
{{% /alert %}}

## **FAQ**

**Quali componenti devono essere installati per convertire presentazioni PowerPoint e OpenDocument in documenti Word?**

È sufficiente aggiungere i rispettivi pacchetti per [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) e [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) al tuo progetto Python. Entrambi i pacchetti funzionano come API autonome e non è necessario avere Microsoft Office installato.

**Sono supportati tutti i formati di presentazione PowerPoint e OpenDocument?**

Aspose.Slides per Python .NET [supporta tutti i formati di presentazione](/slides/it/python-net/supported-file-formats/), inclusi PPT, PPTX, ODP e altri formati comuni. Questo garantisce che tu possa lavorare con presentazioni create in varie versioni di Microsoft PowerPoint.