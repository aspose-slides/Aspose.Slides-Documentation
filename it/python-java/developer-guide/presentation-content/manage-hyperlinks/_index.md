---
title: Gestire i collegamenti ipertestuali della presentazione in Python tramite Java
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/python-java/manage-hyperlinks/
keywords:
- aggiungere URL
- aggiungere collegamento ipertestuale
- creare collegamento ipertestuale
- formattare collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- collegamento ipertestuale di testo
- collegamento ipertestuale di diapositiva
- collegamento ipertestuale di forma
- collegamento ipertestuale di immagine
- collegamento ipertestuale di video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Aggiungi, formatta, aggiorna e rimuovi collegamenti ipertestuali in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python tramite Java, utilizzando esempi Python."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito web da testo, forma o fotogramma multimediale.  
* Passare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides per Python via Java consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti a livello di presentazione, diapositiva o casella di testo.

{{% alert color="info" title="Nota" %}}
Puoi anche modificare le presentazioni con il [gratuito editor online di Aspose PowerPoint](https://products.aspose.app/slides/it/editor).
{{% /alert %}} 

## **Aggiungere collegamenti URL**

È possibile assegnare un URL di un sito web a testo, forma o fotogramma multimediale. L'elemento a cui si assegna il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un fotogramma collega l'oggetto della diapositiva.

### **Aggiungere collegamenti URL al testo**

Per collegare il testo a un sito web, passa un [Hyperlink](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/) al metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/#setHyperlinkClick) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Aggiungere collegamenti URL a forme e fotogrammi multimediali**

Per rendere una forma o un fotogramma cliccabile, chiama il suo metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#setHyperlinkClick). Il collegamento ipertestuale appartiene all'oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio si applica a fotogrammi di immagine, audio e video: assegna il collegamento al fotogramma e chiama [setTooltip](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setTooltip) se necessario.

Il seguente esempio rende un rettangolo cliccabile:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usare i collegamenti per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. Il seguente esempio utilizza [setInternalHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) per collegare il testo “Page 2” della prima diapositiva alla seconda diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formattare i collegamenti**

### **Colore**

Il metodo [setColorSource](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setColorSource) di [Hyperlink](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/) determina se un collegamento utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, seleziona [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkcolorsource/) e imposta il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

Il seguente esempio aggiunge due collegamenti ipertestuali a testo nella stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito dei collegamenti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando viene attivato o fermare un suono già in riproduzione. Usa i seguenti metodi per configurare questi comportamenti:

- [Hyperlink.setSound](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setSound) specifica l'audio associato al collegamento.  
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) controlla se l'attivazione del collegamento interrompe il suono precedente.

#### **Aggiungere un suono al collegamento**

Il seguente esempio carica `sampleaudio.wav` e lo associa a un pulsante sulla prima diapositiva. Cliccando il pulsante si riproduce il suono e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire un'azione di navigazione.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Estrarre un suono dal collegamento**

Il seguente esempio apre la presentazione creata sopra e legge l'audio del collegamento della prima forma nella memoria tramite [getSound](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#getSound) e [getBinaryData](https://reference.aspose.com/slides/it/python-java/aspose.slides/audio/#getBinaryData).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Impostazioni di tooltip e interazione**

È possibile chiamare i seguenti metodi di [Hyperlink](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/) dopo aver assegnato un collegamento a testo o a una forma:

- [setTooltip](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setTooltip) imposta il testo che un visualizzatore può visualizzare come suggerimento per il collegamento.  
- [setTargetFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setTargetFrame) specifica il frame di destinazione all'interno di un frameset HTML padre, se applicabile.  
- [setHistory](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setHistory) controlla se l'attivazione del collegamento aggiunge la sua destinazione all'elenco dei collegamenti visualizzati.  
- [setHighlightClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#setHighlightClick) controlla se il collegamento è evidenziato quando viene cliccato.

## **Rimuovere i collegamenti dalle presentazioni**

Utilizza [getAnyHyperlinks](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) per raccogliere i contenitori dei collegamenti, inclusi i collegamenti delle porzioni di testo, prima di modificarli. Il seguente esempio rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiama solo [removeHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); la rimozione di un'azione di click non rimuove la sua controparte al passaggio del mouse.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

Per rimozione incondizionata, [removeAllHyperlinks](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) rimuove entrambi i tipi di attivazione nell'ambito selezionato con una sola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedi [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti**

Prima di distribuire una presentazione, effettua l'inventario delle sue azioni interattive così come dei suoi collegamenti web. [getAnyHyperlinks](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) restituisce contenitori di collegamenti, come gli oggetti [Shape](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/) e [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/), non un elenco piatto di stringhe URL. Ispeziona sia [getHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getHyperlinkClick) sia [getHyperlinkMouseOver](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getHyperlinkMouseOver) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un report completo necessita fino a due righe per contenitore.

Scansionare solo i collegamenti a livello di forma può far perdere i collegamenti collegati a porzioni di testo. Interroga invece l'ambito appropriato e conserva i contenitori restituiti in modo da poter successivamente aggiornare o rimuovere le loro azioni.

### **Interrogare gli ambiti di presentazione, diapositiva e casella di testo**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/) è disponibile tramite [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getHyperlinkQueries) e [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/#getHyperlinkQueries). Ogni ambito supporta le stesse query:

- [getHyperlinkClicks](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) restituisce i contenitori con un'azione di click.  
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) restituisce i contenitori con un'azione al passaggio del mouse.  
- [getAnyHyperlinks](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) restituisce i contenitori con una o entrambe le azioni.

L'esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento click esterno, un collegamento mouse-over a file, una navigazione interna diapositive, un collegamento mouse-over a testo e un'azione macro. Non esegue nessuna di queste azioni. Le stesse tre query funzionano in ogni ambito; i conteggi descrivono i contenitori, non il totale delle azioni. L'ambito della casella di testo esclude i collegamenti propri della forma contenitore.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per questo esempio, le query di presentazione e di diapositiva riportano ciascuna tre contenitori click, due contenitori mouse-over e tre contenitori con una delle due azioni. La query della casella di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Usa [Hyperlink.getActionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#getActionType) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; ispeziona l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione incorporata della presentazione, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Fine della presentazione corrente o avvio di una presentazione personalizzata. |
| `StartMacro` | Esecuzione di una macro. |
| `StartProgram` | Avvio di un programma. |
| `OpenFile`, `OpenPresentation` | Apertura di un file o di un'altra presentazione; da revisionare separatamente dagli URL web. |
| `StartStopMedia` | Avvio o interruzione della riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggi le destinazioni esterne con [getExternalUrl](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#getExternalUrl) e le destinazioni interne specifiche con [getTargetSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#getTargetSlide). Le azioni interne e i comandi integrati possono non avere un URL esterno; un URL vuoto non indica che il contenitore non abbia azioni. Conserva il valore restituito da [getExternalUrlOriginal](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) quando differisce dall'URL normalizzato e includi il tooltip restituito da [getTooltip](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlink/#getTooltip) quando disponibile.

### **Report, Sanitize, and Verify Hyperlinks**

Il seguente esempio Python legge una presentazione esistente (usa il file creato sopra), scrive `hyperlink-audit.json`, applica una policy, salva `hyperlink-sanitized.pptx` e la riapre per controllare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'uguaglianza di riferimento per evitare di elaborare lo stesso contenitore due volte. Le query di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, interroga inoltre esplicitamente master, layout, note e i master di note e di handout quando presenti.

Il report registra un indice di diapositiva basato su 1 e [getSlideId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseslide/#getSlideId) dove disponibile. [getSlide](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getSlide) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati per ambito. I contenitori di forma e i contenitori di formattazione delle porzioni di testo sono etichettati separatamente; altri tipi di contenitore conservano il loro nome di tipo runtime. Ogni contenitore ottiene un ID locale al report in modo che le sue due azioni possano essere correlate. Il report memorizza i tipi di azione come le costanti intere definite dall'enumerazione Java.

Questa politica applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e target di diapositive interni validi. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di policy, non un verdetto di sicurezza di Aspose.Slides. HTTPS da solo non garantisce fiducia: aggiungi whitelist di host e altri controlli per la tua applicazione. Sia gli URL esterni originali che quelli normalizzati sono controllati. L'esempio verifica i metadati senza seguire i collegamenti o eseguire le azioni.

Per la rimediation, il [getHyperlinkManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/shape/#getHyperlinkManager) del contenitore supporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). Qui, i collegamenti click esterni proibiti sono sostituiti con una pagina di destinazione HTTPS fissa; gli altri click proibiti e le azioni mouse-over proibite sono rimosse in modo indipendente. Imposta `replace_external_clicks` su `False` per rimuovere tutte le violazioni di policy. Scegli una pagina di sostituzione di proprietà dell'applicazione prima del deployment.

La bandiera di esportazione del report utilizza una politica conservativa di revisione PDF: segnala le azioni mouse-over e tutto ciò che non è un collegamento esterno o un salto a una diapositiva specifica come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravvivano all'esportazione. Le esportazioni PDF e HTML supportate [PDF](/slides/it/python-java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/python-java/convert-powerpoint-to-html/) possono preservare i collegamenti, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/python-java/convert-powerpoint-to-png/) e i [video](/slides/it/python-java/convert-powerpoint-to-video/) raster non possono preservare i collegamenti interattivi; segnala ogni azione quando esegui un audit per questi output.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

Con l'input creato sopra, il report contiene cinque righe di azioni. Il collegamento mouse-over al file e il click macro sono rimossi, mentre i collegamenti HTTPS e la navigazione interna delle diapositive rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL click esterno proibito attiva anche il ramo di sostituzione. Un contenitore con un click consentito e un mouse-over proibito mantiene la sua azione di click.

Questo pulizia selettiva differisce da [removeAllHyperlinks](https://reference.aspose.com/slides/it/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), che rimuove entrambi i tipi di attivazione nell'intero ambito selezionato indipendentemente dalla policy. La verifica qui controlla solo le azioni dei collegamenti; non rimuove progetti VBA incorporati, oggetti OLE o altri contenuti attivi, e non valida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una singola diapositiva. Per creare una navigazione a una sezione, collega alla prima diapositiva di quella sezione.

**Posso allegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno preservati quando si esporta in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti; le immagini raster e i video non possono. Consulta le considerazioni sull'esportazione in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).