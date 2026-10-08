---
title: Configura la sostituzione dei caratteri nelle presentazioni usando Python via Java
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/python-java/font-substitution/
keywords:
- carattere
- sostituzione del carattere
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

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene resa o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e si possono ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con diversi caratteri installati.

Se un carattere è disponibile ma non ha un tipo di carattere grassetto dedicato, vedere [Handle Fonts Without a Dedicated Bold Typeface](/slides/it/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Quella sezione spiega come rasterizzare il testo interessato durante l'esportazione in PDF e le conseguenze per la selezione del testo, la ricerca e il ridimensionamento.

## **Ottenere le sostituzioni dei caratteri**

Utilizzare il metodo [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) per determinare quali caratteri saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e sostituito.

Il seguente esempio Python elenca tutte le sostituzioni dei caratteri per una presentazione:

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

## **Ottenere le sostituzioni dei caratteri per le diapositive selezionate**

Utilizzare la sovraccarico [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) con un argomento array di interi Java per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o esporta una parte di una presentazione, si verifica una grande presentazione in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto minimo di caratteri per un server o un container, o si diagnosticano differenze di rendering senza elaborare diapositive non pertinenti.

L'array `slides` contiene indici delle diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessore della collezione [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) utilizza l'indicizzazione basata su 0, quindi la stessa diapositiva è accessibile come `presentation.getSlides().get_Item(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di scorrimento di uno.

Chiamare la sovraccarico tramite il metodo [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e sostituito. Il risultato riflette l'ambiente di caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) e i [caratteri caricati esternamente](/slides/it/python-java/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. De‑duplicare i risultati quando si crea un inventario dei caratteri o un rapporto di pre‑flight. Il seguente esempio riporta ogni sostituzione restituita e quindi crea un elenco ordinato di mappature dei caratteri uniche:

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

La classe [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) fornisce entrambi i sovraccarichi. Scegliere uno in base all'ambito dell'operazione di rendering:

| Sovraccarico | Usalo quando |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with no arguments | Hai bisogno delle sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) with a Java integer array | Hai bisogno delle sostituzioni per un intervallo selezionato, controllo incrementale o esportazione parziale. |

## **Impostare le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides dovrebbe usare quando un carattere sorgente non è disponibile:

1. Caricare la presentazione.
2. Creare le definizioni dei caratteri per i caratteri sorgente e di sostituzione.
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible).
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/).
5. Assegnare la collezione utilizzando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList).
6. Renderizzare o convertire la presentazione.

L'esempio Python seguente sostituisce `Arial` al posto di `SomeRareFont` quando `SomeRareFont` non è disponibile, e quindi renderizza la prima diapositiva per verificare il risultato. Il carattere di sostituzione deve essere disponibile per Aspose.Slides.

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

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con il carattere disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** per questo scopo, e il rendering può ancora segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una tale presentazione, rendere **Cambria Math** disponibile a Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [carattere esterno](/slides/it/python-java/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra si applicano ancora al testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra font replacement e font substitution?**

[Font replacement](/slides/it/python-java/font-replacement/) cambia intenzionalmente un carattere con un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [font selection sequence](/slides/it/python-java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola è utilizzata solo quando Aspose.Slides non può accedere al carattere sorgente.

**Cosa succede quando un carattere manca e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il carattere disponibile più vicino in base al suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. È possibile [caricare caratteri esterni](/slides/it/python-java/custom-font/) in modo che Aspose.Slides possa usarli durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. Sei responsabile di fornire i caratteri e di rispettare le loro licenze.

**I risultati di sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri variano a seconda del sistema operativo, quindi un carattere disponibile su una macchina può richiedere una sostituzione su un'altra.

**Come posso rendere coerente la selezione dei caratteri nelle conversioni batch?**

Utilizzare gli stessi file e versioni dei caratteri su ogni macchina o container, [caricare i caratteri esterni richiesti](/slides/it/python-java/custom-font/) e [incorporare i caratteri](/slides/it/python-java/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) prima dell'esportazione per identificare sostituzioni inaspettate.