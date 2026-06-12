---
title: Convertire le presentazioni PowerPoint in HTML con Python
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/python-net/convert-powerpoint-to-html/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- salvare PowerPoint come HTML
- salvare presentazione come HTML
- salvare diapositiva come HTML
- salvare PPT come HTML
- salvare PPTX come HTML
- esportare PPT in HTML
- esportare PPTX in HTML
- Python
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML con Python. Usa Aspose.Slides per esportare file PPT e PPTX, diapositive selezionate, note, caratteri, immagini, SVG e contenuti multimediali."
---
## **Panoramica**

Aspose.Slides per Python via .NET può salvare le presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un unico caricamento di [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e una chiamata a `save` con [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/). Utilizza [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/) quando è necessario controllare il layout esportato, i caratteri, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esportare un'intera presentazione o diapositive selezionate.
- Generare HTML a layout fisso, responsive o basato su SVG.
- Includere note del relatore e commenti.
- Controllare la qualità delle immagini e i dati delle immagini ritagliate.
- Incorporare i caratteri o salvare i file dei caratteri separatamente.
- Scegliere come le risorse esterne e i file multimediali vengano scritti e referenziati.

Per impostazione predefinita, l'esportazione HTML produce un documento HTML autonomo in cui la maggior parte delle risorse è incorporata. Questo è comodo per condividere un unico file, ma può aumentare le dimensioni dell'output. Per la pubblicazione web, considerare risorse esterne, DPI immagine più bassi e incorporare solo i caratteri non disponibili in modo affidabile nell'ambiente di destinazione.

## **Convertire una presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e salvala con [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

Questo esempio scrive un file HTML. L'istruzione `with` elimina l'oggetto presentazione e rilascia i gestori di file e le risorse di rendering dopo l'esportazione.

## **Utilizzare HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/) è la classe di configurazione principale per l'esportazione HTML. Le impostazioni comuni includono:

- `slides_layout_options`: aggiunge note, commenti, dispense o altre informazioni di layout.
- `html_formatter`: modifica la struttura del documento HTML o delega la formattazione a un controller.
- `slide_image_format`: cambia il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- `pictures_compression`: controlla DPI dell'immagine e dimensione dell'output.
- `delete_pictures_cropped_areas`: conserva o rimuove i dati delle immagini ritagliate.
- `svg_responsive_layout`: fa sì che il contenuto SVG esportato si adatti al contenitore.
- `show_hidden_slides`: include le diapositive nascoste quando richiesto.

Le sezioni seguenti mostrano le opzioni più comuni separatamente, così da poter combinare solo quelle necessarie al tuo flusso di lavoro.

## **Convertire diapositive selezionate in HTML**

Il sovraccarico `save` che accetta numeri di diapositiva utilizza posizioni basate su 1. Il ciclo sottostante salva ogni diapositiva in un file HTML separato.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

Usa questo modello quando un sito web o un'applicazione necessita di una pagina HTML per diapositiva. Se ogni diapositiva deve avere lo stesso layout, crea un'istanza di [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/) e passala a ogni chiamata `save`.

## **Creare HTML responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/responsivehtmlcontroller/) fornisce output HTML responsive tramite [HtmlFormatter](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

Per un layout responsive basato su SVG, imposta `svg_responsive_layout` su [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/). Questo è utile quando il contenuto della diapositiva viene esportato come markup SVG scalabile.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **Includere note del relatore e commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) tramite `html_options.slides_layout_options` per includere note del relatore o commenti. Note e commenti sono nascosti per impostazione predefinita a meno che non vengano scelte le loro posizioni.

Supponiamo che la presentazione di origine contenga note del relatore:

![Diapositiva con note del relatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del relatore sotto la diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

L'HTML esportato include l'area delle note:

![Output HTML con diapositiva e note del relatore](HTML_with_notes.png)

Per esportare i commenti, imposta `comments_position`, ad esempio su `CommentsPositions.RIGHT` o `CommentsPositions.BOTTOM`. Se ti servono solo i commenti, ometti `notes_position`. Se ti servono sia note sia commenti, imposta entrambe le proprietà.

## **Controllare la qualità dell'immagine e le aree ritagliate**

L'esportazione HTML può comprimere le immagini delle diapositive per ridurre le dimensioni dell'output. Imposta `pictures_compression` a un valore di [PicturesCompression](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/picturescompression/) quando hai bisogno di una qualità d'immagine più alta.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

Per impostazione predefinita, le aree ritagliate delle immagini possono essere rimosse dall'output esportato. Conserva i dati ritagliati solo quando gli utenti devono poter recuperare o ispezionare quelle parti nascoste dell'immagine. Mantenerli può aumentare la dimensione dell'HTML.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **Aggiungere CSS**

Per una stilizzazione semplice, passa una stringa CSS a [HtmlFormatter](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmlformatter/). Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

Per un'intestazione di documento personalizzata, un file CSS collegato o markup personalizzato intorno a diapositive e forme, utilizza un controller di formattazione personalizzato e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmlformatter/) con `create_custom_formatter`.

## **Incorporare i caratteri**

Se l'ambiente di destinazione potrebbe non avere i caratteri della presentazione installati, incorpora i caratteri nell'HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/embedallfontshtmlcontroller/). L'incorporamento migliora la fedeltà visiva ma aumenta le dimensioni dell'output.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

Escludi un carattere solo quando sei certo che i browser o i sistemi di destinazione lo forniscano già. Per caratteri di brand o meno comuni, l'incorporamento è solitamente più sicuro.

## **Collegare file di caratteri invece di incorporarli**

Per ridurre la dimensione del file HTML, puoi scrivere i dati dei caratteri in file WOFF separati e aggiungere regole `@font-face` all'HTML. Questo richiede un controller che personalizzi come i dati dei caratteri vengono scritti durante l'esportazione. In Python via .NET, implementa quel controller in un piccolo assembly .NET di supporto, caricalo in Python e passa l'oggetto di supporto a [HtmlFormatter](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmlformatter/) con `create_custom_formatter`.

Quando esternalizzi i caratteri, scegli due percorsi in modo deliberato:

- La directory di output del file system dove verranno scritti i file WOFF generati.
- Il percorso URL che apparirà nel documento HTML e che il browser utilizzerà per caricare quei file di caratteri.

Mantieni il file HTML e i file dei caratteri generati insieme fino a quando i percorsi di distribuzione non siano definitivi. Se i file vengono distribuiti in un'altra posizione, fai corrispondere il prefisso URL al percorso URL distribuito.

## **Salvare le risorse esternamente**

HTML autonomo è facile da spostare, ma le risorse Base64 incorporate possono rendere il file grande. Se la tua applicazione necessita di immagini, caratteri, audio o video esterni, utilizza un controller personalizzato di collegamento/incorporamento e passalo al costruttore di [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/).

Quando esternalizzi le risorse, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove la tua applicazione scrive le immagini, i caratteri, l'audio o il video generati.
- Il percorso URL, che è ciò che il browser usa dal documento HTML per caricare quei file.

Per una discussione completa sul collegamento delle immagini, vedi [Esportare presentazioni in HTML con immagini collegate esternamente](/slides/it/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **Esportare file multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/videoplayerhtmlcontroller/) esporta file video e audio e genera HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory dove verranno scritti i file multimediali generati.
- `file_name`: il nome del file HTML in fase di generazione.
- `base_uri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

Se il file HTML è `html-output/presentation.html` e i file multimediali sono salvati in `html-output/media`, `path` dovrebbe puntare alla directory multimediale sul disco, mentre `base_uri` dovrebbe puntare alla stessa directory dal punto di vista del browser. Per l'anteprima locale, puoi costruire un URI `file:///` dalla directory multimediale. Per un'applicazione distribuita, utilizza l'URL assoluto della directory multimediale pubblicata.

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

Usa directory di output uniche per ogni lavoro di esportazione, specialmente nelle applicazioni server. Percorsi di output condivisi possono far sì che i file di conversioni diverse si sovrascrivano.

## **Prestazioni e gestione delle risorse**

La conversione HTML è un'operazione di rendering, quindi tempo di elaborazione e utilizzo della memoria dipendono dal numero di diapositive, risoluzione delle immagini, caratteri, effetti, grafici e media incorporati. Valori DPI più alti per `pictures_compression`, caratteri incorporati, output SVG e aree immagine ritagliate conservate possono migliorare la fedeltà ma solitamente aumentano le dimensioni dell'output.

Per la conversione batch:

- Elimina tempestivamente ogni istanza di [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
- Usa directory di output separate per lavori separati.
- Evita di incorporare i caratteri comuni a meno che la fedeltà non lo richieda.
- Riduci DPI delle immagini quando l'HTML è destinato a anteprime o miniature.
- Mantieni la presentazione di origine, l'HTML generato e le risorse esterne insieme fino a quando i percorsi di distribuzione non siano definitivi.

## **FAQ**

**I collegamenti ipertestuali vengono conservati nell'output HTML?**

Sì. I collegamenti ipertestuali della presentazione vengono esportati in HTML e rimangono cliccabili quando l'URL di destinazione è valido.

**Posso convertire presentazioni in HTML in parallelo?**

Sì, ma non condividere un'istanza di [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) tra thread. Elabora file diversi con istanze di presentazione separate, flussi separati e directory di output separate. Vedi le [linee guida sul multithreading](/slides/it/python-net/multithreading/) per i dettagli.

**Un oggetto Presentazione è thread‑safe?**

No. Un'unica istanza di [Presentazione](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) deve essere caricata, modificata, salvata ed eliminata su un solo thread. Per lavoro parallelo, crea un'istanza indipendente per thread o processo.

**Perché il file HTML generato è grande?**

L'esportazione predefinita può incorporare risorse direttamente nell'HTML. Caratteri incorporati, immagini ad alta DPI, media, contenuto SVG e aree immagine ritagliate conservate aumentano anche le dimensioni. Usa risorse esterne, escludi i caratteri comuni dall'incorporamento e riduci `pictures_compression` quando un output più piccolo è più importante della massima fedeltà.

**Perché una dimensione di carattere PowerPoint come 24 pt appare come 17.999819 pt nell'HTML?**

Ciò può accadere perché PowerPoint e HTML usano modelli DPI diversi. PowerPoint memorizza le dimensioni del testo in punti tipografici basati su 72 DPI, mentre il layout HTML si basa su pixel CSS in un modello a 96 DPI. Quando Aspose.Slides esporta una presentazione in HTML, la dimensione del carattere è tradotta tra questi sistemi e la conversione può introdurre piccole differenze di arrotondamento.

Questi valori non indicano un reale cambiamento visivo della dimensione del carattere. Sono solo un effetto collaterale matematico della conversione delle metriche del testo tra PowerPoint e HTML.

**Come dovrei scegliere base_uri per l'esportazione dei media?**

Scegli `base_uri` dal punto di vista del browser e passalo come URI assoluto. Per l'anteprima locale, puoi derivarlo dalla directory di output con `Path(media_directory).as_uri() + "/"`. Per la distribuzione, usa l'URL assoluto della directory multimediale pubblicata. Il `path` del file system e il `base_uri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione della risorsa.

**Posso includere diapositive nascoste?**

Sì. Imposta `show_hidden_slides = True` su [HtmlOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/htmloptions/) quando le diapositive nascoste devono essere esportate.