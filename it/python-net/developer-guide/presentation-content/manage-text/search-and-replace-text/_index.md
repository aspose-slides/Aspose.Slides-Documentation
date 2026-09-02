---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in Python
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/python-net/search-and-replace-text/
keywords:
- ricerca testo
- evidenzia testo
- sostituisci testo
- espressione regolare
- frame di testo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Cerca, evidenzia e sostituisci testo nelle presentazioni PowerPoint con Aspose.Slides per Python via .NET."
---
## **Panoramica**

Aspose.Slides for Python via .NET può cercare, evidenziare e sostituire testo in un singolo frame di testo o in tutta una presentazione. Queste funzionalità sono utili per revisioni, redazione, controlli terminologici, pulizia di modelli e altri flussi di lavoro automatizzati di elaborazione dei documenti.

Nel primo esempio sotto, utilizziamo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Sample text](sample_text.png)

## **Scegli l'ambito della ricerca**

Utilizza i metodi di [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) per limitare un'operazione a un frame di testo. Utilizza i metodi di [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un frame di testo | Intera presentazione |
|---|---|---|
| Evidenzia testo letterale | [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_text/) |
| Evidenzia corrispondenze di espressione regolare | [TextFrame.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_regex/) |
| Sostituisci testo letterale | [TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_text/) |
| Sostituisci corrispondenze di espressione regolare | [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_regex/) |

## **Configura l'abbinamento del testo**

Per le operazioni su testo letterale, utilizza [TextSearchOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/) per controllare l'abbinamento:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/whole_words_only/) limita le corrispondenze a parole intere.  
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/case_sensitive/) controlla se la distinzione tra maiuscole e minuscole deve essere rispettata.  
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/include_notes/) include le note della diapositiva nelle operazioni di ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari usano una stringa di modello, quindi regole di abbinamento come la sensibilità al maiuscolo/minuscolo e i confini di parola sono definite dall'espressione stessa.

## **Identifica il proprietario di un frame di testo**

I flussi di lavoro generici di elaborazione del testo spesso ricevono un [TextFrame] durante la ricerca, la sostituzione, la validazione o l'esportazione del testo. Usa [TextFrame.parent_shape] e [TextFrame.parent_cell] per determinare quale oggetto della presentazione è proprietario del frame di testo.

I valori attesi dipendono dal proprietario:

| Proprietario del frame di testo | `parent_shape` | `parent_cell` |
|---|---|---|
| Una AutoShape o un'altra forma contenente testo | La [Shape] proprietaria | `None` |
| Una cella di tabella | `None` | La [Cell] proprietaria |

Entrambe le proprietà sono di sola lettura e servono per la navigazione. Leggerle non sposta il frame di testo né ne cambia il proprietario. Il codice generico dovrebbe verificare entrambe le proprietà per `None` e gestire il caso in cui nessuno dei due proprietari sia disponibile.

L'esempio seguente utilizza [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/it/python-net/aspose.slides.util/slideutil/get_all_text_frames/) per iterare attraverso i frame di testo in una presentazione. Per le forme, riporta il nome della forma, il tipo di runtime Python e la diapositiva contenente. Per le celle di tabella, riporta le coordinate di colonna e riga (indice zero) e la diapositiva contenente.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

Per i contenuti SmartArt, itera attraverso le forme in [SmartArtNode.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartartnode/shapes/) e accedi a ciascuna [ISmartArtShape.text_frame](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Il frame di testo può essere ricondotto alla forma associata tramite [TextFrame.parent_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_shape/), mentre [TextFrame.parent_cell](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/parent_cell/) è `None`. Pertanto, il ramo della forma nell'esempio gestisce anche il testo proveniente dai nodi SmartArt.

## **Evidenzia testo**

Usa il metodo [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa [TextSearchOptions] per controllare la ricerca.

Il codice di esempio qui sotto evidenzia tutte le occorrenze del carattere **"try"** e poi evidenzia solo la parola completa **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Evidenzia ogni occorrenza di "try" nel frame di testo.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Evidenzia solo la parola completa "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Il risultato:

![Il testo evidenziato](highlighted_text.png)

## **Evidenzia testo usando le espressioni regolari**

Il metodo [TextFrame.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_regex/) evidenzia le corrispondenze di testo trovate da un'espressione regolare in un frame di testo.

Il codice seguente evidenzia tutte le parole contenenti sette o più caratteri:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Il risultato:

![Il testo evidenziato usando l'espressione regolare](highlighted_text_using_regex.png)

## **Evidenzia testo in tutta la presentazione**

Usa [Presentation.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_text/) e [Presentation.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_regex/) per cercare tutti i frame di testo applicabili in una presentazione. L'esempio seguente evidenzia un termine letterale e tutti gli indirizzi e‑mail:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Sostituisci testo in un frame di testo**

Usa [TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) per testo letterale e [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) per sostituzioni basate su modello. Questi metodi aggiornano il testo corrispondente all'interno del frame di testo esistente, mantenendo la formattazione delle parti circostanti invece di ricostruire il frame da una stringa semplice.

L'esempio seguente uniforma una variante ortografica e poi sostituisce le etichette di versione:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Se una corrispondenza attraversa parti con formattazioni diverse, controlla il risultato per confermare quale formattazione deve essere applicata al testo di sostituzione.

## **Sostituisci testo in tutta la presentazione**

Usa [Presentation.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_text/) e [Presentation.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_regex/) per applicare le stesse operazioni a tutta la presentazione. Questo è utile per la pulizia di modelli, aggiornamenti terminologici e redazione.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **FAQ**

**Come posso cercare solo una casella di testo invece dell'intera presentazione?**

Ottieni il frame di testo della forma e chiama [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) o [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) su quel frame. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili.

**Come posso abbinare parole complete con la corretta capitalizzazione?**

Imposta [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/whole_words_only/) e [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/case_sensitive/) su `True` e passa le opzioni a un metodo di evidenziazione o sostituzione per testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al maiuscolo/minuscolo direttamente nel modello.

**La ricerca e la sostituzione possono includere il testo nelle note della diapositiva?**

Sì. Imposta [TextSearchOptions.include_notes](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/include_notes/) su `True` quando utilizzi un'operazione a livello di presentazione per testo letterale.

**La sostituzione del testo preserva la sua formattazione?**

[TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) e [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) modificano il testo corrispondente all'interno del frame di testo esistente e mantengono la formattazione delle parti circostanti. Se una corrispondenza attraversa parti con formattazioni diverse, esamina il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.