---
title: Gestire i collegamenti ipertestuali della presentazione in Python
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/python-net/manage-hyperlinks/
keywords:
- aggiungere URL
- aggiungere collegamento ipertestuale
- creare collegamento ipertestuale
- formattare collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- collegamento ipertestuale testo
- collegamento ipertestuale diapositiva
- collegamento ipertestuale forma
- collegamento ipertestuale immagine
- collegamento ipertestuale video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Aggiungere, formattare, aggiornare e rimuovere i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET, usando esempi Python."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all’interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito web da testo, forma o cornice multimediale.
* Passare a un’altra diapositiva, ad esempio da un indice.

Aspose.Slides per Python via .NET consente di aggiungere questi collegamenti, controllarne l’aspetto e il suono, aggiornarne le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti a livello di presentazione, diapositiva o riquadro di testo.

{{% alert color="info" title="Nota" %}}
È inoltre possibile modificare le presentazioni con il [editor gratuito online di Aspose PowerPoint](https://products.aspose.app/slides/it/editor).
{{% /alert %}}

## **Aggiungere collegamenti ipertestuali URL**

È possibile assegnare un URL di sito web a testo, forma o cornice multimediale. L’elemento a cui si assegna il collegamento ipertestuale determina l’area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o una cornice collega l’oggetto della diapositiva.

### **Aggiungere collegamenti ipertestuali URL a testo**

Per collegare del testo a un sito web, assegnare un [Hyperlink](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/) alla proprietà [hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/hyperlink_click/) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Aggiungere collegamenti ipertestuali URL a forme e cornici multimediali**

Per rendere cliccabile una forma o una cornice, impostare la sua proprietà [hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/hyperlink_click/). Il collegamento ipertestuale appartiene all’oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio si applica a cornici di immagine, audio e video: assegnare il collegamento alla cornice e impostare il [tooltip](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/tooltip/) del collegamento, se necessario.

L’esempio seguente rende un rettangolo cliccabile:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Utilizzare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L’esempio seguente usa [set_internal_hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) per collegare il testo “Pagina 2” della prima diapositiva alla seconda diapositiva.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Formattare i collegamenti ipertestuali**

### **Colore**

La proprietà [color_source](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/color_source/) di [Hyperlink](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/) determina se un collegamento ipertestuale utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, selezionare [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkcolorsource/) e impostare il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

L’esempio seguente aggiunge due collegamenti ipertestuali testuali alla stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito dei collegamenti.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando attivato o interrompere un suono già in riproduzione. Utilizzare le seguenti proprietà per configurare questi comportamenti:

- [Hyperlink.sound](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/sound/) specifica l’audio associato al collegamento.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/stop_sound_on_click/) controlla se l’attivazione del collegamento interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

L’esempio seguente carica `sampleaudio.wav` e lo associa a un pulsante nella prima diapositiva. Cliccando il pulsante si riproduce il suono e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando cliccata, senza eseguire alcuna azione di navigazione.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Estrarre un suono dal collegamento ipertestuale**

L’esempio seguente apre la presentazione creata sopra e legge l’audio del collegamento della prima forma nella memoria tramite [sound](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/sound/) e [binary_data](https://reference.aspose.com/slides/it/python-net/aspose.slides/audio/binary_data/).

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Tooltip e impostazioni di interazione**

È possibile aggiornare le seguenti proprietà di [Hyperlink](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/) dopo aver assegnato un collegamento a testo o a una forma:

- [tooltip](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/tooltip/) imposta il testo che un visualizzatore può visualizzare come suggerimento per il collegamento.
- [target_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/target_frame/) specifica il frame di destinazione all’interno di un frameset HTML padre, se applicabile.
- [history](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/history/) controlla se l’attivazione del collegamento aggiunge la destinazione all’elenco dei collegamenti visualizzati.
- [highlight_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/highlight_click/) controlla se il collegamento è evidenziato quando cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Utilizzare [get_any_hyperlinks](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) per raccogliere i contenitori di collegamenti, inclusi i collegamenti delle porzioni di testo, prima di modificarli. L’esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiamare solo [remove_hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) o [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); la rimozione di un’azione di clic non rimuove la controparte di mouse‑over.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Per una rimozione incondizionata, [remove_all_hyperlinks](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) elimina entrambi i tipi di attivazione nello scope selezionato con una sola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedere [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, fare l’inventario delle sue azioni interattive così come dei collegamenti web. [get_any_hyperlinks](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/it/python-net/aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispezionare sia [hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) sia [hyperlink_mouse_over](https://reference.aspose.com/slides/it/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un rapporto completo richiede fino a due righe per contenitore.

La scansione solo a livello di forme può perdere collegamenti collegati a porzioni di testo. Interrogare lo scope appropriato invece, e conservare i contenitori restituiti così da poterli aggiornare o rimuovere in seguito.

### **Interrogare scope di presentazione, diapositiva e riquadro di testo**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/) è disponibile tramite [Presentation.hyperlink_queries](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/hyperlink_queries/) e [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/hyperlink_queries/). Ogni scope supporta le stesse query:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) restituisce contenitori con azione di clic.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) restituisce contenitori con azione di mouse‑over.
- [get_any_hyperlinks](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) restituisce contenitori con una o entrambe le azioni.

L’esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento di clic esterno, un collegamento di mouse‑over a file, una navigazione interna di diapositiva, un collegamento di mouse‑over al testo e un’azione macro. Non esegue nessuna di queste azioni. Le tre query funzionano in ogni scope; i conteggi descrivono contenitori, non il totale delle azioni. Lo scope del riquadro di testo esclude i collegamenti propri della forma contenente.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Per questo esempio, le query di presentazione e diapositiva riportano tre contenitori di clic, due di mouse‑over e tre contenitori con una delle due azioni. La query del riquadro di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Usare [Hyperlink.action_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/action_type/) per interpretare un’azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `HYPERLINK` | Collegamento ipertestuale esterno; ispezionare l’URL e il suo schema. |
| `JUMP_SPECIFIC_SLIDE` | Navigazione interna a una diapositiva specifica. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Navigazione incorporata della presentazione, risolta nel contesto della presentazione. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Terminare lo spettacolo corrente o avviare uno spettacolo personalizzato. |
| `START_MACRO` | Eseguire una macro. |
| `START_PROGRAM` | Avviare un programma. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Aprire un file o un’altra presentazione; esaminarli separatamente dagli URL web. |
| `START_STOP_MEDIA` | Avviare o fermare la riproduzione multimediale. |
| `NO_ACTION`, `UNKNOWN` | Nessuna azione di navigazione o azione non riconosciuta che richiede revisione. |

Leggere le destinazioni esterne da [external_url](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/external_url/) e le destinazioni interne specifiche da [target_slide](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/target_slide/). Le azioni interne e i comandi incorporati potrebbero non avere un URL esterno; un URL vuoto non significa che il contenitore non abbia alcuna azione. Conservare [external_url_original](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/external_url_original/) quando differisce dall’URL normalizzato e includere il [tooltip](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlink/tooltip/) quando disponibile.

### **Report, Sanitize, and Verify Hyperlinks**

L’esempio Python seguente legge una presentazione esistente (usare il file creato sopra), scrive `hyperlink-audit.json`, applica una policy, salva `hyperlink-sanitized.pptx` e lo riapre per verificare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e interroga ciascuno scope di diapositiva una sola volta per evitare elaborazioni duplicate. Le query di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, l’esempio interroga diapositive ordinarie, master, layout, note e i master di note e handout quando presenti.

Il report registra un indice di diapositiva basato su 1 e [slide_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseslide/slide_id/) dove disponibile. Il raccoglitore mantiene la diapositiva proprietaria e lo scope accanto a ciascun contenitore restituito. I master, i layout e le note non hanno indice di diapositiva ordinario e sono identificati dallo scope. I contenitori di forma e i contenitori di formattazione di porzione di testo sono etichettati separatamente; altri tipi di contenitore conservano il loro nome di tipo a runtime. Ogni contenitore ottiene un ID locale al report così le sue due azioni possono essere correlate.

Questa policy di applicazione volutamente restrittiva consente solo URL HTTPS assoluti e destinazioni interne diapositive valide. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Queste rifiuti sono decisioni di policy, non un giudizio sulla sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungere whitelist di host e altri controlli per la propria applicazione. Entrambi gli URL esterni originali e normalizzati sono controllati. L’esempio esegue audit dei metadati senza seguire i collegamenti o eseguire azioni.

Per la rimessione, il [hyperlink_manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) del contenitore supporta [set_external_hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) e [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). Qui, i collegamenti di clic esterni proibiti sono sostituiti con una pagina di atterraggio HTTPS fissa; gli altri clic proibiti e le azioni di mouse‑over proibite sono rimossi indipendentemente. Impostare `replace_external_clicks` a `False` per rimuovere tutte le violazioni di policy. Scegliere una pagina di sostituzione appartenente all’applicazione prima del deployment.

Il flag di esportazione del report utilizza una politica di revisione PDF conservatrice: segnala le azioni di mouse‑over e qualsiasi cosa diversa da un collegamento esterno o da un salto di diapositiva specifico come potenzialmente non supportata. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravvivranno all’esportazione. Le esportazioni PDF e HTML supportate possono preservare i collegamenti, a seconda dell’azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/python-net/convert-powerpoint-to-png/) raster e i [video](/slides/it/python-net/convert-powerpoint-to-video/) non possono preservare i collegamenti interattivi; segnalare ogni azione quando si effettua l’audit per tali output.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Interrogare ogni ambito di diapositiva una volta, conservando il proprio proprietario per ogni contenitore.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

Con l’input creato sopra, il report contiene cinque righe di azione. Il collegamento di mouse‑over a file e la macro di clic sono rimossi, mentre i collegamenti HTTPS e la navigazione interna di diapositiva rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL di clic esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un clic consentito e un mouse‑over proibito conserva la sua azione di clic.

Questa pulizia selettiva differisce da [remove_all_hyperlinks](https://reference.aspose.com/slides/it/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/), che rimuove entrambi i tipi di attivazione in tutto lo scope selezionato indipendentemente dalla policy. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altro contenuto attivo, e non convalida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento interno punta a una singola diapositiva. Per creare una navigazione verso una sezione, collegare alla prima diapositiva di quella sezione.

**Posso associare un collegamento ipertestuale agli elementi del master così da funzionare su tutte le diapositive?**

Sì. Gli elementi del master e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno conservati quando si esporta in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono conservare i collegamenti ipertestuali; le immagini raster e i video no. Vedere le considerazioni sull’esportazione in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).