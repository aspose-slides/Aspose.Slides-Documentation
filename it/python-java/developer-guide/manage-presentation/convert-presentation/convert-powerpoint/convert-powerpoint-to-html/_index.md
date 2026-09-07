---
title: Converti le presentazioni PowerPoint in HTML in Python tramite Java
linktitle: PowerPoint in HTML
type: docs
weight: 30
url: /it/python-java/convert-powerpoint-to-html/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint a HTML
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
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint in HTML in Python tramite Java. Utilizza Aspose.Slides per esportare file PPT e PPTX, diapositive selezionate, note, font, immagini, SVG e media."
---
## **Panoramica**

Aspose.Slides for Python via Java può salvare le presentazioni PowerPoint come HTML senza Microsoft PowerPoint. La conversione di base è un singolo caricamento di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e una chiamata a [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/). Usa [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/) quando è necessario controllare il layout esportato, i caratteri, le immagini, le note, i commenti, l'output SVG o le risorse collegate.

La presente guida si concentra su scenari pratici di esportazione HTML:

- Esporta un'intera presentazione o le diapositive selezionate.
- Genera HTML a layout fisso, responsive o basato su SVG.
- Includi le note del relatore e i commenti.
- Controlla la qualità delle immagini e i dati delle aree ritagliate.
- Incorpora i font o salva i file dei font separatamente.
- Scegli come le risorse esterne e i file multimediali vengono scritti e riferiti.

Per impostazione predefinita, l'esportazione HTML produce un documento HTML autonomo in cui la maggior parte delle risorse è incorporata. Ciò è comodo per condividere un unico file, ma può aumentare le dimensioni dell'output. Per la pubblicazione web, considera l'uso di risorse esterne, una DPI delle immagini più bassa e l'incorporamento solo dei font che non sono disponibili in modo affidabile nell'ambiente di destinazione.

## **Convertire una Presentation in HTML**

Per esportare una presentation in HTML, caricala con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e salvala con [SaveFormat.Html](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Html).

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

Ogni esempio carica `presentation.pptx` dalla directory di lavoro corrente. Installa Aspose.Slides for Python via Java e un runtime Java compatibile prima di eseguirlo. La JVM viene avviata una volta per processo Python.

Questo esempio scrive un file HTML. L'oggetto presentation viene eliminato nel blocco `finally`, che rilascia i handle dei file e le risorse di rendering dopo l'esportazione.

## **Configurare l'Esportazione HTML**

[HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/) è la classe principale di configurazione per l'esportazione HTML. Le impostazioni comuni includono:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): aggiunge note, commenti, dispense o altre informazioni di layout.
- [setHtmlFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setHtmlFormatter): modifica la struttura del documento HTML o delega la formattazione a un controller.
- [setSlideImageFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSlideImageFormat): modifica il modo in cui le diapositive sono rappresentate, ad esempio come SVG.
- [setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression): controlla la DPI dell'immagine e le dimensioni dell'output.
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): mantiene o rimuove i dati delle aree ritagliate delle immagini.
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): consente al contenuto SVG esportato di adattarsi al suo contenitore.
- [setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): include le diapositive nascoste quando necessario.

Le sezioni seguenti mostrano le opzioni più comuni separatamente in modo da poter combinare solo quelle necessarie al tuo flusso di lavoro.

## **Convertire Diapositive Selezionate in HTML**

Il sovraccarico [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) che accetta numeri di diapositive utilizza posizioni diapositive basate su 1. Il ciclo seguente salva ogni diapositiva in un file HTML separato.

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

Usa questo schema quando un sito web o un'applicazione necessita di una pagina HTML per diapositiva. Se ogni diapositiva deve avere lo stesso layout, crea un'istanza di [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/) e passala a ciascuna chiamata [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save).

## **Creare HTML Responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/it/python-java/aspose.slides/responsivehtmlcontroller/) fornisce output HTML responsive tramite [HtmlFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/). Usalo quando la pagina esportata deve adattarsi meglio alla larghezza del browser.

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

Per un layout responsive basato su SVG, chiama [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) con `True`. Questo è utile quando il contenuto della diapositiva è esportato come markup SVG scalabile.

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

## **Includere Note del Relatore e Commenti**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) tramite [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) per includere le note del relatore o i commenti. Note e commenti sono nascosti per impostazione predefinita a meno che non ne scegli le posizioni.

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

L'HTML esportato include l'area delle note:

![Output HTML con la diapositiva e le note del relatore](HTML_with_notes.png)

Per esportare i commenti, chiama [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition), ad esempio con [CommentsPositions.Right](https://reference.aspose.com/slides/it/python-java/aspose.slides/commentspositions/#Right) o [CommentsPositions.Bottom](https://reference.aspose.com/slides/it/python-java/aspose.slides/commentspositions/#Bottom). Se ti servono solo i commenti, ometti [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Se ti servono sia note che commenti, chiama entrambi i metodi.

## **Controllare la Qualità dell'Immagine e le Aree Ritagliate**

L'esportazione HTML può comprimere le immagini delle diapositive per ridurre le dimensioni dell'output. Passa un valore a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression) da [PicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/picturescompression/) quando hai bisogno di una qualità dell'immagine più alta.

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

Per una semplice formattazione, passa una stringa CSS a [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/#createDocumentFormatter). Questo modifica il documento HTML circostante mentre Aspose.Slides continua a renderizzare il contenuto della diapositiva.

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

Per un'intestazione del documento personalizzata, un file CSS collegato o markup personalizzato attorno a diapositive e forme, utilizza un controller di formattazione personalizzato tramite un proxy di interfaccia JPype e passalo a [HtmlFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/) con [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmlformatter/#createCustomFormatter).

## **Incorporare Font**

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

Escludi i font solo quando sei sicuro che i browser o i sistemi di destinazione li forniscano già. Per i font del brand o i font meno comuni, l'incorporamento è generalmente più sicuro.

## **Salvare le Risorse in Modo Esterno**

Un HTML autonomo è facile da spostare, ma le risorse Base64 incorporate possono rendere il file grande. Se la tua applicazione necessita di file immagine esterni, implementa un controller di collegamento delle risorse tramite un proxy di interfaccia JPype e passalo al costruttore [HtmlOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/).

When you externalize resources, choose two paths deliberately:
- Il percorso di output del file system, dove la tua applicazione scrive immagini, font, audio o video generati.
- Il percorso URL, che è quello che il browser utilizza dal documento HTML per caricare quei file.

## **Esportare File Multimediali**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/it/python-java/aspose.slides/videoplayerhtmlcontroller/) esporta file video e audio e scrive HTML che può riprodurli in un browser. Il suo costruttore accetta:
- `path`: la directory in cui verranno scritti i file multimediali generati.
- `fileName`: il nome del file HTML in fase di generazione.
- `baseUri`: il prefisso URI assoluto usato nei collegamenti HTML ai file multimediali.

La seguente esempio esporta media già incorporati in `presentation.pptx`. L'HTML generato fa riferimento ai file multimediali solo per nome file, relativo al documento HTML, quindi `path` deve essere la directory che riceve anche il file HTML. `baseUri` deve essere un URI assoluto: per l'anteprima locale, costruisci un URI `file:///` dalla directory di output; per un'applicazione distribuita, usa l'URL assoluto della directory pubblicata.

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

Usa directory di output uniche per ogni lavoro di esportazione, specialmente nelle applicazioni server. Percorsi di output condivisi possono causare la sovrascrittura dei file provenienti da conversioni diverse.

## **Prestazioni e Gestione delle Risorse**

La conversione HTML è un'operazione di rendering, quindi i tempi di elaborazione e l'uso della memoria dipendono dal numero di diapositive, dalla risoluzione delle immagini, dai font, dagli effetti, dai grafici e dai media incorporati. Valori DPI delle immagini più alti passati a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression), font incorporati, output SVG e aree ritagliate mantenute possono migliorare la fedeltà ma di solito aumentano le dimensioni dell'output.

Per la conversione in batch:
- Elimina prontamente ogni istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
- Utilizza directory di output separate per lavori separati.
- Evita di incorporare font comuni a meno che non sia necessaria la fedeltà.
- Abbassa la DPI delle immagini quando l'HTML è destinato a anteprime o miniature.
- Mantieni la presentazione di origine, l'HTML generato e le risorse esterne insieme fino a quando i percorsi di distribuzione non siano definitivi.

## **FAQ**

**I collegamenti ipertestuali sono conservati nell'output HTML?**

Sì. I collegamenti ipertestuali della presentation sono esportati in HTML e rimangono cliccabili quando l'URL di destinazione è valido.

**Posso convertire le presentation in HTML in parallelo?**

Sì, ma non condividere una singola istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) tra thread. Elabora file diversi con istanze di presentation separate, stream separati e directory di output separate. Vedi la [multithreading guidance](/slides/it/python-java/multithreading/) per i dettagli.

**Un oggetto presentation è thread‑safe?**

No. Una singola istanza di [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) dovrebbe essere caricata, modificata, salvata ed eliminata su un solo thread. Per lavori paralleli, crea un'istanza indipendente per thread o processo.

**Perché il file HTML generato è grande?**

L'esportazione predefinita può incorporare risorse direttamente nell'HTML. Font incorporati, immagini ad alta DPI, media, contenuto SVG e aree ritagliate mantenute aumentano le dimensioni. Usa risorse esterne, escludi i font comuni dall'incorporamento e passa un valore DPI più basso a [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setPicturesCompression) quando un output più piccolo è più importante della massima fedeltà.

**Perché i valori di font‑size in HTML possono differire dai valori di PowerPoint?**

La pagina esportata può utilizzare sistemi di coordinate SVG e trasformazioni di scala. Un valore CSS o SVG di font‑size da solo non descrive la dimensione finale visualizzata. Confronta la diapositiva renderizzata al livello di zoom previsto e verifica la disponibilità dei font se il testo appare diverso.

**Come dovrei scegliere baseUri per l'esportazione dei media?**

Scegli `baseUri` dal punto di vista del browser e passalo come URI assoluto. Per l'anteprima locale, puoi derivarlo dalla directory di output con `output_directory.as_uri() + "/"`. Per la distribuzione, usa l'URL assoluto della directory pubblicata. Il `path` del file system e il `baseUri` del browser non devono essere la stessa stringa, ma devono descrivere la stessa posizione, e quella posizione deve essere la directory che contiene l'HTML generato perché i collegamenti media sono scritti in modo relativo a essa.

**Posso includere diapositive nascoste?**

Sì. Chiama [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) con `True` quando le diapositive nascoste devono essere esportate.