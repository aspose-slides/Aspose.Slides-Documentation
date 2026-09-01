---
title: "Automatizza la localizzazione delle presentazioni con Python"
linktitle: "Localizzazione delle presentazioni"
type: docs
weight: 100
url: /it/python-net/presentation-localization/
keywords:
- "cambia lingua"
- "controllo ortografico"
- "sopprimi controllo ortografico"
- "lingua di revisione"
- "ID lingua"
- "testo multilingue"
- "PowerPoint"
- "presentazione"
- "Python"
- "Aspose.Slides"
description: "Imposta le lingue di revisione per il testo delle presentazioni PowerPoint e OpenDocument in Python con Aspose.Slides, inclusi valori predefiniti e paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides for Python via .NET consente di configurare i metadati di revisione per singole parti di testo. Utilizza [BasePortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/language_id/) per identificare la lingua di revisione, [BasePortionFormat.spell_check](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/spell_check/) per consentire o sopprimere il controllo ortografico e [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/proof_disabled/) per controllare lo stato più ampio di "non revisionare". Poiché queste impostazioni vengono applicate a livello di porzione, un paragrafo può contenere più lingue e regole di revisione differenti.

Questo articolo spiega come assegnare una lingua a testo specifico, impostare la lingua predefinita per nuovo testo con [LoadOptions.default_text_language](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/default_text_language/), creare paragrafi multilingue, scegliere tra `spell_check` e `proof_disabled` e preservare le impostazioni previste quando si utilizza [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/join_portions_with_same_formatting/). Queste proprietà memorizzano metadati per le applicazioni di presentazione; non traducono il testo, non eseguono il controllo ortografico basato su dizionario né restituiscono parole errate.

## **Imposta la lingua di revisione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/), accedi alla porzione di testo desiderata tramite [Portion.portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/portion_format/) e assegna il suo identificatore di lingua. L'esempio seguente crea una forma, imposta l'inglese britannico come lingua di revisione e salva il risultato con [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/):

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Imposta la lingua predefinita per nuovo testo**

Utilizza [LoadOptions.default_text_language](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/default_text_language/) per specificare la lingua di revisione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo di una presentazione utilizza la stessa lingua. Non modifica i metadati di lingua del testo che ha già una lingua esplicita.

L'esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di revisione tedesche:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Usa più lingue in un unico paragrafo**

Un [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) contiene una raccolta di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) separata per ciascuna lingua e imposta il suo `language_id` in modo indipendente.

Questo esempio crea un paragrafo con porzioni in inglese e francese:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Abilita o sopprimi il controllo ortografico per porzioni individuali**

[PortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/portionformat/) eredita le proprietà di testo comuni definite da [BasePortionFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/). Accedi al formato di una porzione tramite [Portion.portion_format](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/portion_format/) e imposta [BasePortionFormat.spell_check](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/spell_check/) per controllare se un'applicazione di presentazione può verificare l'ortografia per quella porzione. Il valore predefinito è `False`: `True` consente il controllo ortografico, mentre `False` lo sopprime.

L'impostazione si applica a singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi utilizzare valori differenti. [BasePortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/language_id/) e `spell_check` hanno scopi complementari: `language_id` identifica la lingua di revisione, mentre `spell_check` determina se i controlli ortografici sono consentiti per la porzione.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/proof_disabled/) controlla anch'esso la revisione, ma rappresenta lo stato più ampio "non revisionare" come un [NullableBool](https://reference.aspose.com/slides/it/python-net/aspose.slides/nullablebool/). Usa `spell_check` quando ti serve un interruttore booleano diretto per i controlli ortografici. Usa `proof_disabled` quando devi preservare o controllare esplicitamente i metadati "non revisionare" della presentazione, incluso lo stato `NOT_DEFINED`. Se imposti entrambe le proprietà, mantieni i loro valori coerenti; non combinare `spell_check = True` con `proof_disabled = slides.NullableBool.TRUE`.

Queste proprietà configurano i metadati di revisione utilizzati da PowerPoint e altre applicazioni di presentazione. Aspose.Slides non li utilizza per eseguire controlli ortografici basati su dizionario né per restituire un elenco di parole errate.

L'esempio completo seguente crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di revisione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) combina porzioni adiacenti che hanno lo stesso formato. Una differenza solo in `spell_check` non mantiene separate tali porzioni; dopo la fusione, la porzione risultante mantiene il valore `spell_check` della prima porzione. Se le porzioni necessitano di impostazioni di controllo ortografico diverse, chiama `join_portions_with_same_formatting` prima di assegnare quelle impostazioni, oppure ispeziona i confini delle porzioni risultanti e riapplica le impostazioni in seguito. Le porzioni con valori diversi di `language_id` rimangono separate perché il loro formato di lingua di revisione differisce.

## **FAQ**

**L'ID lingua traduce il testo?**

No. [BasePortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/language_id/) memorizza metadati di revisione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l'identificatore di lingua appropriato per ogni porzione tradotta.

**La lingua di revisione controlla caratteri, sillabazione o interlinea?**

No. L'identificatore di lingua è solo per la revisione. Il rendering del testo e il layout dipendono principalmente dai [font](/slides/it/python-net/powerpoint-fonts/), dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [sostituzione dei font](/slides/it/python-net/font-substitution/) o [incorpora i font](/slides/it/python-net/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di revisione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell'esempio del paragrafo multilingue.

**Devo usare `default_text_language` o `language_id`?**

Usa [LoadOptions.default_text_language](https://reference.aspose.com/slides/it/python-net/aspose.slides/loadoptions/default_text_language/) quando vuoi un valore predefinito per il testo appena creato. Usa [BasePortionFormat.language_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/baseportionformat/language_id/) quando una porzione specifica richiede una lingua di revisione esplicita o quando un paragrafo contiene più lingue.