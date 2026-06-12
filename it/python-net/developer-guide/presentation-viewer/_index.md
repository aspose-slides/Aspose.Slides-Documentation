---
title: Crea un visualizzatore di presentazioni in Python
linktitle: Visualizzatore di presentazioni
type: docs
weight: 50
url: /it/python-net/presentation-viewer/
keywords:
- visualizzare presentazione
- visualizzatore di presentazioni
- creare visualizzatore di presentazioni
- visualizzare PPT
- visualizzare PPTX
- visualizzare ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Scopri come creare un visualizzatore di presentazioni personalizzato in Python utilizzando Aspose.Slides. Visualizza facilmente file PowerPoint (PPTX, PPT) e OpenDocument (ODP) senza Microsoft PowerPoint o altro software di office."
---
## **Introduzione**

Aspose.Slides per Python viene utilizzato per creare file di presentazione con diapositive. Queste diapositive possono essere visualizzate aprendo le presentazioni in Microsoft PowerPoint, ad esempio. Tuttavia, gli sviluppatori a volte hanno bisogno di visualizzare le diapositive come immagini nel visualizzatore di immagini preferito o di usarle in un visualizzatore di presentazioni personalizzato. In questi casi, Aspose.Slides consente di esportare singole diapositive come immagini. Questo articolo spiega come fare.

## **Generare un'immagine SVG da una diapositiva**

Per generare un'immagine SVG da una diapositiva di presentazione con Aspose.Slides, segui i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere un riferimento alla diapositiva tramite il suo indice.
1. Aprire un flusso di file.
1. Salvare la diapositiva come immagine SVG nel flusso di file.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Creare un'immagine miniatura della diapositiva**

Aspose.Slides ti aiuta a generare immagini miniatura delle diapositive. Per generare una miniatura di una diapositiva usando Aspose.Slides, segui i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere un riferimento alla diapositiva tramite il suo indice.
1. Creare un'immagine miniatura della diapositiva di riferimento alla scala desiderata.
1. Salvare l'immagine miniatura nel formato immagine preferito.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Creare una miniatura della diapositiva con dimensioni definite dall'utente**

Per creare un'immagine miniatura della diapositiva con dimensioni definite dall'utente, segui i passaggi seguenti:

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere un riferimento alla diapositiva tramite il suo indice.
1. Generare un'immagine miniatura della diapositiva di riferimento con le dimensioni specificate.
1. Salvare l'immagine miniatura nel formato immagine preferito.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Creare una miniatura della diapositiva con note del relatore**

Per generare una miniatura di una diapositiva con note del relatore usando Aspose.Slides, segui i passaggi seguenti:

1. Creare un'istanza della classe [RenderingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/).
1. Utilizzare la proprietà `RenderingOptions.slides_layout_options` per impostare la posizione delle note del relatore.
1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottenere un riferimento alla diapositiva tramite il suo indice.
1. Generare un'immagine miniatura della diapositiva di riferimento utilizzando le opzioni di rendering.
1. Salvare l'immagine miniatura nel formato immagine preferito.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Esempio live**

Prova l'app gratuita [**Aspose.Slides Viewer**](https://products.aspose.app/slides/it/viewer/) per vedere cosa puoi implementare con l'API di Aspose.Slides:

[![Visualizzatore PowerPoint online](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/it/viewer/)

## **FAQ**

**Posso incorporare un visualizzatore di presentazioni in un'applicazione web ASP.NET?**

Sì. È possibile utilizzare Aspose.Slides sul lato server per rendere le diapositive come [images](/slides/it/python-net/convert-powerpoint-to-png/) o [HTML](/slides/it/python-net/convert-powerpoint-to-html/) e visualizzarle nel browser. Le funzionalità di navigazione e zoom possono essere implementate con JavaScript per un'esperienza interattiva.

**Qual è il modo migliore per visualizzare le diapositive all'interno di un visualizzatore .NET personalizzato?**

La soluzione consigliata è rendere ogni diapositiva come [image](/slides/it/python-net/convert-powerpoint-to-png/) (ad es., PNG o SVG) o convertirla in [HTML](/slides/it/python-net/convert-powerpoint-to-html/) usando Aspose.Slides, quindi visualizzare l'output all'interno di una picture box (per desktop) o di un contenitore HTML (per web).

**Come gestire presentazioni di grandi dimensioni con molte diapositive?**

Per deck di grandi dimensioni, considerare il caricamento pigro o il rendering su richiesta delle diapositive. Ciò significa generare il contenuto di una diapositiva solo quando l'utente vi naviga, riducendo memoria e tempi di caricamento.