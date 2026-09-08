---
title: Converti presentazioni in HTML5 in Python via Java
linktitle: Presentazione a HTML5
type: docs
weight: 40
url: /it/python-java/export-to-html5/
keywords:
- PowerPoint a HTML5
- OpenDocument a HTML5
- presentazione a HTML5
- diapositiva a HTML5
- PPT a HTML5
- PPTX a HTML5
- ODP a HTML5
- salva PPT come HTML5
- salva PPTX come HTML5
- salva ODP come HTML5
- esporta PPT a HTML5
- esporta PPTX a HTML5
- esporta ODP a HTML5
- Python
- Java
- Aspose.Slides
description: "Esporta presentazioni PowerPoint e OpenDocument in HTML5 reattivo con Aspose.Slides per Python via Java. Mantieni formattazione, animazioni e interattività."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in HTML5 usando Aspose.Slides. Copre l'esportazione HTML5 di base senza estensioni web aggiuntive, nonché le opzioni per controllare le animazioni delle forme e le transizioni delle diapositive. L'articolo mostra anche il processo standard di esportazione da PowerPoint a HTML, spiega come generare output HTML5 in modalità visualizzazione diapositiva e dimostra come includere i commenti nel documento esportato configurandone il layout.

Gli esempi richiedono Aspose.Slides per Python tramite Java e un runtime Java compatibile. Posizionare `pres.pptx` (o `sample.pptx` per l'esempio dei commenti) nella directory di lavoro corrente. Ogni esempio avvia la JVM solo se non è già in esecuzione.

## **Esporta PowerPoint in HTML5**

Usa [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Html5](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Html5) per esportare una presentazione senza estensioni web aggiuntive:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 

L'esportatore HTML5 crea contenuto HTML per la visualizzazione in un browser. 

{{% /alert %}}

Usa [Html5Options](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/) per configurare l'esportazione. Chiama [setAnimateShapes](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setAnimateShapes) e [setAnimateTransitions](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setAnimateTransitions) con `False` per disabilitare le animazioni delle forme e le transizioni delle diapositive:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Esporta PowerPoint in HTML**

Usa [SaveFormat.Html](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Html) per l'esportazione HTML standard. Vedi [Convert PowerPoint to HTML](/slides/it/python-java/convert-powerpoint-to-html/) per ulteriori opzioni:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

In questo caso, il contenuto della presentazione viene renderizzato tramite SVG in una forma come questa:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Avviso" color="warning" %}} 

L'esportazione HTML standard renderizza il contenuto delle diapositive tramite SVG e non fornisce le opzioni di animazione delle forme e di transizione delle diapositive di HTML5. 

{{% /alert %}}

## **Esporta PowerPoint in Visualizzazione Diapositiva HTML5**

**Aspose.Slides** consente di convertire una presentazione PowerPoint in un documento HTML5 in cui le diapositive sono presentate in modalità visualizzazione diapositiva. In questo caso, aprendo il file HTML5 risultante in un browser, si visualizza la presentazione in modalità visualizzazione diapositiva su una pagina web. 

Questo codice Python dimostra il processo di esportazione da PowerPoint a Visualizzazione Diapositiva HTML5:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **Converti Presentazioni in Documenti HTML5 con Commenti**

I commenti in PowerPoint sono uno strumento che consente agli utenti di lasciare note o feedback sulle diapositive della presentazione. Sono particolarmente utili nei progetti collaborativi, dove più persone possono aggiungere suggerimenti o osservazioni a elementi specifici delle diapositive senza modificare il contenuto principale. Ogni commento mostra il nome dell'autore, facilitando l'individuazione di chi ha lasciato l'osservazione.

Supponiamo di avere la seguente presentazione PowerPoint salvata nel file "sample.pptx".

![Due commenti sulla diapositiva della presentazione](two_comments_pptx.png)

Quando si converte una presentazione PowerPoint in un documento HTML5, è possibile specificare se includere i commenti della presentazione nel documento di output. Per farlo, passa i parametri di visualizzazione per i commenti al metodo [setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) della classe [Html5Options](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/).

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) e [setCommentsPosition](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) con [CommentsPositions.Right](https://reference.aspose.com/slides/it/python-java/aspose.slides/commentspositions/#Right). L'esempio di codice seguente converte una presentazione in un documento HTML5 con i commenti visualizzati a destra delle diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

Il documento "output.html" è mostrato nell'immagine sottostante.

![I commenti nel documento HTML5 di output](two_comments_html5.png)

## **FAQ**

**Posso controllare se le animazioni degli oggetti e le transizioni delle diapositive verranno riprodotte in HTML5?**

Sì, HTML5 fornisce opzioni separate per abilitare o disabilitare le [animazioni delle forme](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setAnimateShapes) e le [transizioni delle diapositive](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setAnimateTransitions).

**Il supporto per l'output dei commenti è disponibile e dove possono essere posizionati rispetto alla diapositiva?**

Sì, i commenti possono essere aggiunti in HTML5 e posizionati (ad esempio, a destra della diapositiva) tramite le [impostazioni di layout](https://reference.aspose.com/slides/it/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) per note e commenti.

**Posso ignorare i collegamenti che invocano JavaScript per motivi di sicurezza o CSP?**

Sì, esiste un [impostazione](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) che consente di saltare i collegamenti ipertestuali con chiamate JavaScript durante il salvataggio. Questo rimuove tali collegamenti; non garantisce, di per sé, che tutti gli script HTML5 generati soddisfino la Content Security Policy di un sito.