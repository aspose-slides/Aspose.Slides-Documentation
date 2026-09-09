---
title: Converti le presentazioni PowerPoint in HTML in Python tramite Java
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/python-java/convert-powerpoint-to-html/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in HTML
- presentazione in HTML
- diapositiva in HTML
- PPT in HTML
- PPTX in HTML
- salva PowerPoint come HTML
- salva presentazione come HTML
- salva diapositiva come HTML
- salva PPT come HTML
- salva PPTX come HTML
- esporta PPT in HTML
- esporta PPTX in HTML
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML in Python tramite Java. Usa Aspose.Slides per esportare file PPT e PPTX, diapositive selezionate, note, font, immagini, SVG e media."
---
## **Panoramica**

Aspose.Slides for Python via Java può salvare le presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base consiste in un unico caricamento di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e una chiamata a [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/). Usa [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/) quando è necessario controllare il layout esportato, i font, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

Questa guida si concentra su scenari pratici di esportazione HTML:

- Esporta un'intera presentazione o diapositive selezionate.
- Genera HTML a layout fisso, reattivo o basato su SVG.
- Include note del relatore e commenti.
- Controlla la qualità dell'immagine e i dati delle immagini ritagliate.
- Incorpora i font o salva i file dei font separatamente.
- Scegli come le risorse esterne e i file multimediali vengono scritti e referenziati.

Per impostazione predefinita, l'esportazione HTML genera un documento HTML autonomo in cui la maggior parte delle risorse è incorporata. Questo è comodo per condividere un solo file, ma può aumentare le dimensioni dell'output. Per la pubblicazione web, considera l'uso di risorse esterne, DPI più bassi per le immagini e l'incorporazione solo dei font che non sono affidabilmente disponibili nell'ambiente di destinazione.

## **Convertire una presentazione in HTML**

Per esportare una presentazione in HTML, caricala con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e salvala con [SaveFormat.Html](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Html).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

Ogni esempio carica `presentation.pptx` dalla directory di lavoro corrente. Installa Aspose.Slides per Python tramite Java e un runtime Java compatibile prima di eseguirlo. La JVM è avviata una volta per processo Python.

Questo esempio scrive un file HTML. L'oggetto Presentation viene eliminato nel blocco `finally`, il che rilascia i handle dei file e le risorse di rendering dopo l'esportazione.

## **Configurare l'esportazione HTML**

[HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/) è la classe di configurazione principale per l'esportazione HTML. Le impostazioni comuni includono:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): aggiunge note, commenti, dispense o altre informazioni di layout.
- [setHtmlFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setHtmlFormatter): cambia la struttura del documento HTML o delega la formattazione a un controller.
- [setSlideImageFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSlideImageFormat): cambia il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression): controlla DPI dell'immagine e dimensione dell'output.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): mantiene o rimuove i dati delle immagini ritagliate.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): fa sì che il contenuto SVG esportato si adatti al suo contenitore.
- [setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): include le diapositive nascoste quando necessario.

Le sezioni seguenti mostrano separatamente le opzioni più comuni in modo da poter combinare solo quelle necessarie al tuo flusso di lavoro.

## **Convertire diapositive selezionate in HTML**

La sovraccarico [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) che accetta numeri di diapositiva usa posizioni basate su 1. Il ciclo qui sotto salva ogni diapositiva in un file HTML separato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

Usa questo modello quando un sito web o un'applicazione richiede una pagina HTML per diapositiva. Se ogni diapositiva deve avere lo stesso layout, crea un'istanza di [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/) e passala a ciascuna chiamata [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save).

## **Creare HTML reattivo**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/python-java/aspose.slides/responsivehtmlcontroller/) fornisce un output HTML reattivo tramite [HtmlFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Per un layout reattivo basato su SVG, chiama [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) con `True`. Questo è utile quando il contenuto della diapositiva è esportato come markup SVG scalabile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Includere note del relatore e commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) tramite [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) per includere note del relatore o commenti. Note e commenti sono nascosti per impostazione predefinita a meno che non ne selezioni le posizioni.

Supponiamo che la presentazione di origine contenga note del relatore:

![Diapositiva con note del relatore in PowerPoint](slide_with_notes.png)

Il codice seguente esporta il contenuto della diapositiva con le note del relatore sotto la diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

![Output HTML con la diapositiva e le note del relatore](HTML_with_notes.png)

Per esportare i commenti, chiama [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), ad esempio con [CommentsPositions.Right](https://reference.aspose.com/slides/it/python-java/aspose.slides/commentspositions/#Right) o [CommentsPositions.Bottom](https://reference.aspose.com/slides/it/python-java/aspose.slides/commentspositions/#Bottom). Se ti servono solo i commenti, ometti [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Se ti servono sia note che commenti, chiama entrambi i metodi.

## **Controllare la qualità dell'immagine e le aree ritagliate**

L'esportazione HTML può comprimere le immagini delle diapositive per ridurre le dimensioni dell'output. Fornisci un valore a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression) da [PicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturescompression/) quando è necessaria una qualità dell'immagine più alta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Per impostazione predefinita, le aree ritagliate delle immagini possono essere rimosse dall'output esportato. Mantieni i dati ritagliati solo quando gli utenti devono poter recuperare o ispezionare quelle parti nascoste dell'immagine. Mantenerli può aumentare le dimensioni dell'HTML.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **Aggiungere CSS**

Per una semplice stilizzazione, passa una stringa CSS a [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Questo cambia il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Per un'intestazione di documento personalizzata, un file CSS collegato o un markup personalizzato intorno a diapositive e forme, utilizza un controller di formattazione personalizzato tramite un proxy di interfaccia JPype e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/) con [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Incorporare i font**

Se l'ambiente di destinazione potrebbe non avere i font della presentazione installati, incorpora i font nell'HTML con [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/it/python-java/aspose.slides/embedallfontshtmlcontroller/). L'incorporamento migliora la fedeltà visiva ma aumenta le dimensioni dell'output.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Escludi i font solo quando sei sicuro che i browser o i sistemi di destinazione li forniscano già. Per i font di marca o i font meno comuni, l'incorporamento è solitamente più sicuro.

## **Salvare le risorse esternamente**

Un HTML autonomo è facile da spostare, ma le risorse Base64 incorporate possono rendere il file voluminoso. Se la tua applicazione necessita di file immagine esterni, implementa un controller di collegamento risorse tramite un proxy di interfaccia JPype e passalo al costruttore di [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/).

Quando esternalizzi le risorse, scegli due percorsi in modo deliberato:

- Il percorso di output del file system, dove la tua applicazione scrive le immagini, i font, l'audio o il video generati.
- Il percorso URL, che è ciò che il browser utilizza dal documento HTML per caricare quei file.

## **Esportare file multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoplayerhtmlcontroller/) esporta file video e audio e genera HTML che può riprodurli in un browser. Il suo costruttore accetta:

- `path`: la directory in cui verranno scritti i file multimediali generati.
- `fileName`: il nome del file HTML in fase di generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

L'esempio seguente esporta i media già incorporati in `presentation.pptx`. L'HTML generato fa riferimento ai file multimediali solo per nome file, relativo al documento HTML, quindi `path` deve essere la directory che riceve anche il file HTML. `baseUri` deve essere un URI assoluto: per l'anteprima locale, costruisci un URI `file:///` dalla directory di output; per un'applicazione distribuita, usa l'URL assoluto della directory pubblicata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Usa directory di output uniche per ogni attività di esportazione, specialmente nelle applicazioni server. Percorsi di output condivisi possono far sovrascrivere i file di conversioni diverse.

## **Prestazioni e gestione delle risorse**

La conversione HTML è un'operazione di rendering, quindi i tempi di elaborazione e l'uso della memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai font, dagli effetti, dai grafici e dai media incorporati. Valori DPI più alti per le immagini passati a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression), i font incorporati, l'output SVG e il mantenimento delle aree ritagliate delle immagini possono migliorare la fedeltà ma di solito aumentano le dimensioni dell'output.

Per conversioni batch:

- Elimina prontamente ogni istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Usa directory di output separate per lavori separati.
- Evita di incorporare font comuni a meno che non sia necessaria la fedeltà.
- Riduci i DPI dell'immagine quando l'HTML è per anteprima o miniature.
- Mantieni la presentazione di origine, l'HTML generato e le risorse esterne insieme fino a quando i percorsi di distribuzione non sono definitivi.

## **FAQ**

**I collegamenti ipertestuali sono preservati nell'output HTML?**

Sì. I collegamenti ipertestuali della presentazione sono esportati in HTML e rimangono cliccabili quando l'URL di destinazione è valido.

**Posso convertire le presentazioni in HTML in parallelo?**

Sì, ma non condividere una singola istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) tra thread. Elabora file diversi con istanze di presentazione separate, stream separati e directory di output separate. Consulta la [multithreading guidance](/slides/it/python-java/multithreading/) per i dettagli.

**L'oggetto presentazione è thread-safe?**

No. Una singola istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) dovrebbe essere caricata, modificata, salvata ed eliminata su un unico thread. Per lavoro parallelo, crea un'istanza indipendente per thread o processo.

**Perché il file HTML generato è grande?**

L'esportazione predefinita può incorporare risorse direttamente nell'HTML. Font incorporati, immagini ad alto DPI, media, contenuti SVG e aree ritagliate delle immagini mantenute aumentano le dimensioni. Usa risorse esterne, escludi i font comuni dall'incorporamento e passa un valore DPI più basso a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression) quando un output più piccolo è più importante della massima fedeltà.

**Perché i valori font-size in HTML possono differire da quelli di PowerPoint?**

La pagina esportata può utilizzare sistemi di coordinate SVG e trasformazioni di scaling. Un valore grezzo di font-size in CSS o SVG da solo non descrive la dimensione finale visualizzata. Confronta la diapositiva renderizzata al livello di zoom previsto e verifica la disponibilità dei font se il testo appare diverso.

**Come devo scegliere baseUri per l'esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per l'anteprima locale, puoi derivarlo dalla directory di output con `output_directory.as_uri() + "/"`. Per la distribuzione, usa l'URL assoluto della directory pubblicata. Il percorso file system `path` e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione, e quella posizione deve essere la directory che contiene il file HTML generato perché i link ai media sono scritti in modo relativo a essa.

**Posso includere diapositive nascoste?**

Sì. Chiama [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) con `True` quando le diapositive nascoste devono essere esportate.