---
title: Automatizza la localizzazione della presentazione in Python tramite Java
linktitle: Localizzazione della presentazione
type: docs
weight: 100
url: /it/python-java/presentation-localization/
keywords:
- cambiare lingua
- correzione ortografica
- sopprimere la correzione ortografica
- lingua di correzione
- ID lingua
- testo multilingue
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Imposta le lingue di correzione per il testo delle presentazioni PowerPoint e OpenDocument in Python tramite Java con Aspose.Slides, includendo impostazioni predefinite e paragrafi multilingue."
---
## **Panoramica**

Aspose.Slides per Python via Java consente di configurare i metadati di correzione per singole porzioni di testo. Utilizza [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) per identificare la lingua di correzione, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) per consentire o sopprimere i controlli ortografici e [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setProofDisabled) per controllare lo stato più ampio di "non correggere". Poiché queste impostazioni vengono applicate a livello di porzione, un paragrafo può contenere più lingue e regole di correzione diverse.

Questo articolo spiega come assegnare una lingua a testo specifico, impostare la lingua predefinita per il nuovo testo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), creare paragrafi multilingue, scegliere tra [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) e [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setProofDisabled) e conservare le impostazioni desiderate quando si usa [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Queste proprietà memorizzano i metadati per le applicazioni di presentazione; non traducono il testo, non eseguono controlli ortografici basati su dizionario e non restituiscono parole errate.

## **Imposta la lingua di correzione per il testo**

Crea o carica una [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), accedi alla porzione di testo richiesta tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getPortionFormat) e assegna il suo identificatore di lingua. L'esempio seguente crea una forma, imposta l'inglese britannico come lingua di correzione e salva il risultato con [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la lingua predefinita per il nuovo testo**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per specificare la lingua di correzione che Aspose.Slides assegna al testo appena creato. Questa impostazione è utile quando la maggior parte o tutto il nuovo testo in una presentazione utilizza la stessa lingua. Non modifica i metadati di lingua del testo che ha già una lingua esplicita.

L'esempio seguente crea una presentazione il cui nuovo testo utilizza le regole di correzione tedesche:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Usa più lingue in un paragrafo**

Un [Paragraph](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/) contiene una raccolta di porzioni di testo. Crea una [Portion](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/) separata per ogni lingua e imposta il suo [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) in modo indipendente.

Questo esempio crea un paragrafo con porzioni in inglese e francese:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Abilita o sopprimi il controllo ortografico per le singole porzioni**

[PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/) eredita le proprietà di testo comuni definite da [BasePortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/). Accedi al formato di una porzione tramite [Portion.getPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portion/#getPortionFormat) e utilizza [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) per controllare se un'applicazione di presentazione può verificare l'ortografia per quella porzione. Il valore predefinito è `False`: `True` consente il controllo ortografico, mentre `False` lo sopprime.

L'impostazione si applica alle singole porzioni di testo. Porzioni diverse nello stesso paragrafo possono quindi usare valori differenti. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) e [setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) hanno scopi complementari: [setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) identifica la lingua di correzione, mentre [setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) determina se i controlli ortografici sono consentiti per la porzione.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setProofDisabled) controlla anch'esso la correzione, ma rappresenta lo stato più ampio di "non correggere" come un [NullableBool](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/). Usa [setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) quando ti serve un interruttore booleano diretto specifico per i controlli ortografici. Usa [setProofDisabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setProofDisabled) quando devi preservare o controllare esplicitamente i metadati di "non correggere" della presentazione, incluso lo stato [NullableBool.NotDefined](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/#NotDefined). Se imposti entrambe le proprietà, mantieni i valori coerenti; non combinare [setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) impostato su `True` con [setProofDisabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setProofDisabled) impostato sullo stato [NullableBool.True](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/#True).

Queste proprietà configurano i metadati di correzione usati da PowerPoint e altre applicazioni di presentazione. Aspose.Slides non li utilizza per eseguire controlli ortografici basati su dizionario né per restituire un elenco di parole errate.

L'esempio completo seguente crea una presentazione di input, la carica, assegna impostazioni di controllo ortografico e lingue di correzione diverse a due porzioni nello stesso paragrafo, salva il risultato, lo riapre e verifica i valori memorizzati:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combina porzioni adiacenti che hanno la stessa formattazione. Una differenza in [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) da sola non mantiene separate tali porzioni; dopo la fusione, la porzione risultante conserva il valore di [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpellCheck) della prima porzione. Se le porzioni richiedono impostazioni di controllo ortografico diverse, chiama [joinPortionsWithSameFormatting](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) prima di assegnare tali impostazioni, oppure ispeziona i confini delle porzioni risultanti e riapplica le impostazioni in seguito. Porzioni con valori diversi di [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) rimangono separate perché la formattazione della lingua di correzione differisce.

## **FAQ**

**L'ID lingua traduce il testo?**

No. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) memorizza i metadati di correzione per ortografia e grammatica; non altera il contenuto del testo. Traduci il testo separatamente, quindi imposta l'identificatore di lingua appropriato per ogni porzione tradotta.

**La lingua di correzione controlla i font, la sillabazione o l'interruzione di riga?**

No. L'identificatore di lingua è destinato alla correzione. Il rendering del testo e il layout dipendono principalmente dai [fonts](/slides/it/python-java/powerpoint-fonts/), dal sistema di scrittura e dalle impostazioni del riquadro di testo. Per un rendering affidabile, fornisci i font necessari, configura la [font substitution](/slides/it/python-java/font-substitution/) o [embed fonts](/slides/it/python-java/embedded-font/) nella presentazione.

**Un paragrafo può usare più lingue di correzione?**

Sì. Assegna ogni lingua a una porzione separata, come mostrato nell'esempio del paragrafo multilingue.

**Devo usare [setDefaultTextLanguage](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) o [setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId)?**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) quando desideri un valore predefinito per il testo appena creato. Usa [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId) quando una porzione specifica necessita di una lingua di correzione esplicita o quando un paragrafo contiene più lingue.