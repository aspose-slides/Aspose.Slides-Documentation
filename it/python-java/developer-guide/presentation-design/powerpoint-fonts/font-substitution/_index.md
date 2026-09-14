---
title: Configura la sostituzione dei caratteri nelle presentazioni usando Python via Java
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/python-java/font-substitution/
keywords:
- carattere
- carattere sostitutivo
- sostituzione del carattere
- sostituire carattere
- sostituzione del carattere
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per Python via Java durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e si possono ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Ciò aiuta a mantenere l'output coerente tra ambienti con caratteri installati differenti.

## **Ottieni sostituzioni di carattere**

Usa il metodo [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions) per determinare quali caratteri verranno sostituiti quando la presentazione è renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e di quello sostituito.

Il seguente esempio Python elenca tutte le sostituzioni di carattere per una presentazione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **Ottieni sostituzioni di carattere per le diapositive selezionate**

Usa il sovraccarico [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions) con un argomento array di interi Java per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si sta renderizzando o esportando una parte di una presentazione, controllando incrementalmene una presentazione di grandi dimensioni, individuando diapositive che dipendono da caratteri non disponibili, preparando un pacchetto di caratteri minimo per un server o contenitore, o diagnosticando differenze di rendering senza elaborare diapositive non pertinenti.

L'array `slides` contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessore della collezione [Presentation.getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides) utilizza l'indicizzazione a zero, quindi la stessa diapositiva è accessibile come `presentation.getSlides().get_Item(0)`. Tieni presente questa differenza quando costruisci l'array per evitare errori di scarto di uno.

Chiama il sovraccarico tramite il metodo [Presentation.getFontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getFontsManager). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente attuale dei caratteri, le regole di fallback configurate, le regole di sostituzione memorizzate in una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstrulecollection/), e i [caratteri caricati esternamente](/slides/it/python-java/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. De‑duplica i risultati quando crei un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e poi crea un elenco ordinato di mappature di caratteri uniche:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

La classe [FontsManager](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/) fornisce entrambi i sovraccarichi. Scegli quello più adatto all'ambito dell'operazione di rendering:

| Sovraccarico | Usalo quando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions) senza argomenti | Hai bisogno delle sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions) con un array di interi Java | Hai bisogno delle sostituzioni per un intervallo selezionato, un controllo incrementale o un'esportazione parziale. |

## **Imposta regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere di origine non è disponibile:

1. Carica la presentazione.
2. Crea le definizioni dei caratteri per i caratteri di origine e di sostituzione.
3. Crea un [FontSubstRule](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Aggiungi la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsubstrulecollection/).
5. Assegna la collezione usando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Esegui il rendering o la conversione della presentazione.

Il seguente esempio Python sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, e poi rende la prima diapositiva per verificare il risultato. Il carattere sostitutivo deve essere disponibile per Aspose.Slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Per una modifica incondizionata dei caratteri utilizzati in tutta la presentazione, vedere [Font Replacement](/slides/it/python-java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri usato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con quello disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una presentazione di questo tipo, rendi disponibile **Cambria Math** per Aspose.Slides. Installalo nel sistema operativo o caricalo come [carattere esterno](/slides/it/python-java/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano a valere per il testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra la sostituzione dei caratteri e la sostituzione di carattere?**

[Font replacement](/slides/it/python-java/font-replacement/) cambia intenzionalmente un carattere in un altro lungo tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei caratteri](/slides/it/python-java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene usata solo quando Aspose.Slides non può accedere al carattere di origine.

**Cosa accade quando un carattere manca e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il carattere disponibile più vicino secondo il suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. Puoi [caricare caratteri esterni](/slides/it/python-java/custom-font/) affinché Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. Sei responsabile di fornire i caratteri e di rispettare le loro licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri differiscono a seconda del sistema operativo, quindi un carattere disponibile su una macchina può richiedere sostituzione su un'altra.

**Come posso rendere la selezione dei caratteri coerente nelle conversioni batch?**

Usa gli stessi file di caratteri e le stesse versioni su ogni macchina o contenitore, [carica i caratteri esterni richiesti](/slides/it/python-java/custom-font/), e [incorpora i caratteri](/slides/it/python-java/embedded-font/) quando le licenze lo consentono. Puoi anche chiamare [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/python-java/aspose.slides/fontsmanager/#getSubstitutions) prima dell'esportazione per identificare sostituzioni inattese.