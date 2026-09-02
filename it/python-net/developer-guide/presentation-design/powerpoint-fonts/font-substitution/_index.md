---
title: Configura la sostituzione dei caratteri nelle presentazioni con Python
linktitle: Sostituzione dei caratteri
type: docs
weight: 70
url: /it/python-net/font-substitution/
keywords:
- carattere
- font sostitutivo
- sostituzione dei caratteri
- sostituzione carattere
- sostituzione del carattere
- regola di sostituzione
- regola di rimpiazzo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Configura le regole di sostituzione dei caratteri e ispeziona i caratteri sostituiti in Aspose.Slides per Python tramite .NET durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di usare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e si possono ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere coerente l'output tra ambienti con diversi caratteri installati.

## **Ottenere le sostituzioni dei caratteri**

Usa il metodo [FontsManager.get_substitutions](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/) per determinare quali caratteri verranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e di quello sostituito.

Il seguente esempio Python elenca tutte le sostituzioni dei caratteri per una presentazione:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **Ottenere le sostituzioni dei caratteri per le diapositive selezionate**

Usa [FontsManager.get_substitutions](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/) con un elenco di indici di diapositiva per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o si esporta una parte di una presentazione, si verifica una presentazione grande in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimo per un server o contenitore, o si diagnosticano differenze di rendering senza elaborare diapositive non correlate.

L'elenco contiene indici di diapositiva basati su 1: `1` identifica la prima diapositiva. Al contrario, la collezione [Presentation.slides](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slides/it/) è indicizzata a partire da 0, quindi la stessa diapositiva è accessibile come `presentation.slides[0]`. Tieni presente questa differenza quando costruisci l'elenco per evitare errori di offset.

Chiama il metodo tramite la proprietà [Presentation.fonts_manager](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/fonts_manager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsubstitutioninfo/) contenente i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente dei caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [IFontSubstRuleCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/ifontsubstrulecollection/), e [external fonts](/slides/it/python-net/custom-font/).

La stessa sostituzione può essere necessaria per più di una diapositiva selezionata. De‑duplica i risultati quando crei un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e poi crea un elenco ordinato di mappature di caratteri uniche:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

La classe [FontsManager](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/) fornisce entrambe le forme del metodo. Scegli quella più adatta al raggio d'azione dell'operazione di rendering:

| Chiamata del metodo | Quando usarla |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/) senza argomenti | Hai bisogno di sostituzioni per l'intera presentazione. |
| [get_substitutions](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/) con un elenco di indici di diapositiva | Hai bisogno di sostituzioni per un intervallo selezionato, controllo incrementale o esportazione parziale. |

## **Definire le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere sorgente non è disponibile:

1. Carica la presentazione.
2. Crea le definizioni dei caratteri per il carattere sorgente e quello sostitutivo.
3. Crea una [FontSubstRule](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsubstrule/) con la condizione [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsubstcondition/).
4. Aggiungi la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsubstrulecollection/).
5. Assegna la collezione alla proprietà [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/font_subst_rule_list/).
6. Renderizza o converti la presentazione.

Il seguente esempio Python sostituisce `Arial` per `SomeRareFont` quando `SomeRareFont` non è disponibile, e quindi renderizza la prima diapositiva per verificare il risultato. Il carattere sostitutivo deve essere disponibile per Aspose.Slides.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
Per una modifica incondizionata dei caratteri usati in tutta la presentazione, vedere [Font Replacement](/slides/it/python-net/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere inaccessibile con il carattere disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel carattere esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una tale presentazione, rendi **Cambria Math** disponibile per Aspose.Slides. Installalo nel sistema operativo o caricalo come [external font](/slides/it/python-net/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano ad applicarsi al testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra font replacement e font substitution?**

[Font replacement](/slides/it/python-net/font-replacement/) modifica intenzionalmente un carattere in un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando viene soddisfatta la condizione configurata, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [font selection sequence](/slides/it/python-net/font-selection-sequence/) durante il rendering e la conversione. Con `WHEN_INACCESSIBLE`, una regola è utilizzata solo quando Aspose.Slides non può accedere al carattere sorgente.

**Cosa succede quando un carattere è mancante e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il carattere disponibile più vicino secondo il suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**

Sì. È possibile [load external fonts](/slides/it/python-net/custom-font/) affinché Aspose.Slides possa usarli durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**

No. Sei responsabile di fornire i caratteri e di rispettare le loro licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I caratteri installati e le posizioni di ricerca dei caratteri variano a seconda del sistema operativo, quindi un carattere disponibile su una macchina potrebbe richiedere una sostituzione su un'altra.

**Come posso rendere la selezione dei caratteri coerente nelle conversioni batch?**

Utilizza gli stessi file e versioni dei caratteri su ogni macchina o container, [load required external fonts](/slides/it/python-net/custom-font/), e [embed fonts](/slides/it/python-net/embedded-font/) quando le licenze lo permettono. È inoltre possibile chiamare [FontsManager.get_substitutions](https://reference.aspose.com/slides/it/python-net/aspose.slides/fontsmanager/get_substitutions/) prima dell'esportazione per identificare sostituzioni inaspettate.