---
title: Configurare la sostituzione dei font nelle presentazioni usando JavaScript
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/nodejs-java/font-substitution/
keywords:
- font
- font sostituto
- sostituzione dei font
- sostituire il font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Configura le regole di sostituzione dei font e ispeziona i font sostituiti in Aspose.Slides per Node.js tramite Java durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei caratteri consente ad Aspose.Slides di utilizzare un carattere disponibile al posto di un carattere che non può essere accesso quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il carattere assegnato al contenuto della presentazione.

È possibile definire il carattere da utilizzare quando un determinato carattere non è disponibile e ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con diversi caratteri installati.

## **Ottenere le sostituzioni dei caratteri**

Utilizza il metodo [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) per determinare quali caratteri saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del carattere originale e di quello sostituito.

Il seguente esempio JavaScript elenca tutte le sostituzioni di carattere per una presentazione:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Ottenere le sostituzioni dei caratteri per le diapositive selezionate**

Utilizza la overload di [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con un array di indici diapositive per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o si esporta una parte di una presentazione, si controlla una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da caratteri non disponibili, si prepara un pacchetto di caratteri minimale per un server o un container, o si diagnosticano differenze di rendering senza elaborare diapositive non correlate.

La overload si aspetta un primitivo Java `int[]`. Crealo con `java.newArray("int", [...])`; un semplice array JavaScript viene convertito in `Integer[]` e non corrisponde a questa overload.

L'array contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessore della collezione [Presentation.getSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getslides/) utilizza un indice a base zero, quindi la stessa diapositiva è accessibile come `presentation.getSlides().get_Item(0)`. Tieni presente questa differenza quando costruisci l'array per evitare errori di offset.

Chiama la overload tramite [Presentation.getFontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getfontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del carattere originale e di quello sostituito. Il risultato riflette l'ambiente di caratteri corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsubstrulecollection/) e i [caratteri caricati esternamente](/slides/it/nodejs-java/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. De‑duplica i risultati quando crei un inventario dei caratteri o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e poi crea un elenco ordinato di mappature di caratteri uniche:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

La classe [FontsManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/) fornisce entrambe le overload. Scegline una in base all'ambito dell'operazione di rendering:

| Overload | Quando usarlo |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con nessun argomento | Hai bisogno di sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con un Java `int[]` di indici diapositive | Hai bisogno di sostituzioni per un intervallo selezionato, un controllo incrementale o un'esportazione parziale. |

## **Impostare le regole di sostituzione dei caratteri**

Per specificare il carattere che Aspose.Slides deve utilizzare quando un carattere di origine non è disponibile:

1. Carica la presentazione.
2. Crea le definizioni dei caratteri per i caratteri di origine e di sostituzione.
3. Crea una [FontSubstRule](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsubstcondition/).
4. Aggiungi la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Assegna la collezione utilizzando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Renderizza o converti la presentazione.

Il seguente esempio JavaScript sostituisce `Arial` per `SomeRareFont` quando `SomeRareFont` non è disponibile, e poi renderizza la prima diapositiva per verificare il risultato. Il carattere sostitutivo deve essere disponibile per Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Per una modifica incondizionata dei caratteri utilizzati in tutta la presentazione, vedi [Font Replacement](/slides/it/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i caratteri delle equazioni matematiche**

Le regole di sostituzione dei caratteri fanno parte del processo standard di selezione dei caratteri utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un carattere non accessibile con il carattere disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno esattamente di quel carattere per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro carattere matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una tale presentazione, rendi **Cambria Math** disponibile per Aspose.Slides. Installalo nel sistema operativo o caricalo come [external font](/slides/it/nodejs-java/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano ad applicarsi al testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra Font Replacement e Font Substitution?**  
[Font replacement](/slides/it/nodejs-java/font-replacement/) modifica intenzionalmente un carattere con un altro in tutta la presentazione. La sostituzione dei caratteri seleziona un carattere per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il carattere originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**  
Le regole partecipano alla [sequenza di selezione dei caratteri](/slides/it/nodejs-java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene utilizzata solo quando Aspose.Slides non può accedere al carattere di origine.

**Cosa accade quando un carattere è mancante e non è configurata alcuna regola di sostituzione?**  
Aspose.Slides seleziona il carattere disponibile più vicino in base al suo processo di selezione dei caratteri. Il risultato dipende dai caratteri disponibili nell'ambiente di runtime.

**Posso caricare caratteri esterni per evitare la sostituzione?**  
Sì. Puoi [caricare caratteri esterni](/slides/it/nodejs-java/custom-font/) in modo che Aspose.Slides possa utilizzarli durante il rendering e la conversione.

**Aspose distribuisce i caratteri con la libreria?**  
No. Sei responsabile di fornire i caratteri e di rispettare le relative licenze.

**I risultati di sostituzione possono differire tra Windows, Linux e macOS?**  
Sì. I caratteri installati e le posizioni di ricerca dei caratteri variano a seconda del sistema operativo, quindi un carattere disponibile su una macchina può richiedere una sostituzione su un'altra.

**Come posso rendere la selezione dei caratteri coerente nelle conversioni batch?**  
Utilizza gli stessi file di caratteri e le stesse versioni su ogni macchina o container, [carica i caratteri esterni richiesti](/slides/it/nodejs-java/custom-font/) e [incorpora i caratteri](/slides/it/nodejs-java/embedded-font/) quando le licenze lo consentono. Puoi anche chiamare [FontsManager.getSubstitutions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) prima dell'esportazione per identificare sostituzioni inattese.