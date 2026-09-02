---
title: Cerca e sostituisci testo nelle presentazioni PowerPoint in Python
linktitle: Cerca e sostituisci testo
type: docs
weight: 55
url: /it/python-net/search-and-replace-text/
keywords:
- cerca testo
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

Aspose.Slides per Python via .NET può cercare, evidenziare e sostituire testo in un singolo frame di testo o in un'intera presentazione. Queste funzionalità sono utili per la revisione, la redazione, il controllo della terminologia, la pulizia dei modelli e altri flussi di lavoro automatizzati di elaborazione dei documenti.

Nei primi esempi seguenti, utilizziamo un file chiamato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente testo:

![Testo di esempio](sample_text.png)

## **Scegli l'ambito di ricerca**

Utilizza i metodi su [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) per limitare un'operazione a un singolo frame di testo. Utilizza i metodi su [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) per elaborare tutto il testo applicabile nella presentazione.

| Operazione | Un frame di testo | Intera presentazione |
|---|---|---|
| Evidenzia testo letterale | [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_text/) |
| Evidenzia corrispondenze di espressione regolare | [TextFrame.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_regex/) |
| Sostituisci testo letterale | [TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_text/) |
| Sostituisci corrispondenze di espressione regolare | [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_regex/) |

## **Configura il confronto del testo**

Per le operazioni su testo letterale, utilizza [TextSearchOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/) per controllare il confronto:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/whole_words_only/) limita le corrispondenze a parole complete.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/case_sensitive/) controlla se il case dei caratteri deve corrispondere.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/include_notes/) include le note della diapositiva nella ricerca, sostituzione ed evidenziazione a livello di presentazione.

Le operazioni con espressioni regolari usano una stringa di pattern, quindi le regole di corrispondenza come la sensibilità al caso e i confini di parola sono definiti dall'espressione.

## **Evidenzia testo**

Utilizza il metodo [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/) per evidenziare le corrispondenze di testo letterale in un frame di testo. Passa [TextSearchOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/) per controllare la ricerca.

L'esempio di codice seguente evidenzia tutte le occorrenze dei caratteri **"try"** e poi evidenzia solo la parola completa **"to"**.

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

## **Evidenzia testo usando espressioni regolari**

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

## **Evidenzia testo nell'intera presentazione**

Utilizza [Presentation.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_text/) e [Presentation.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/highlight_regex/) per cercare tutti i frame di testo applicabili in una presentazione. Il seguente esempio evidenzia un termine letterale e tutti gli indirizzi email:

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

Usa [TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) per testo letterale e [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) per sostituzioni basate su pattern. Questi metodi aggiornano il testo corrispondente all'interno del frame di testo esistente, mantenendo la formattazione della parte circostante invece di ricostruire il frame di testo da una stringa semplice.

Il seguente esempio standardizza una variante ortografica e poi sostituisce le etichette di versione:

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

Se una corrispondenza copre parti con formattazioni diverse, verifica l'output per confermare quale formattazione dovrebbe essere applicata al testo sostituito.

## **Sostituisci testo nell'intera presentazione**

Utilizza [Presentation.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_text/) e [Presentation.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/replace_regex/) per applicare le stesse operazioni all'intera presentazione. Questo è utile per la pulizia dei modelli, gli aggiornamenti di terminologia e la redazione.

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

Ottieni il frame di testo della forma e chiama [TextFrame.highlight_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/), o [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) su quel frame di testo. I metodi a livello di presentazione elaborano tutti i frame di testo applicabili.

**Come posso corrispondere parole complete con la corretta capitalizzazione?**

Imposta [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/whole_words_only/) e [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/case_sensitive/) su `True` e passa le opzioni a un metodo di evidenziazione o sostituzione di testo letterale. Per le espressioni regolari, definisci i confini di parola e la sensibilità al caso direttamente nel pattern.

**La ricerca e la sostituzione possono includere il testo nelle note delle diapositive?**

Sì. Imposta [TextSearchOptions.include_notes](https://reference.aspose.com/slides/it/python-net/aspose.slides/textsearchoptions/include_notes/) su `True` quando utilizzi un'operazione di testo letterale a livello di presentazione.

**La sostituzione del testo ne conserva la formattazione?**

[TextFrame.replace_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_text/) e [TextFrame.replace_regex](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/replace_regex/) modificano il testo corrispondente all'interno del frame di testo esistente e mantengono la formattazione della parte circostante. Se una corrispondenza copre parti con formattazioni diverse, ispeziona il risultato per assicurarti che la sostituzione utilizzi lo stile desiderato.