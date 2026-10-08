---
title: Configura la sostituzione dei font nelle presentazioni usando JavaScript
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/nodejs-java/font-substitution/
keywords:
- font
- font sostituito
- sostituzione del font
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
description: "Configura le regole di sostituzione dei font e verifica i font sostituiti in Aspose.Slides per Node.js tramite Java durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei font consente ad Aspose.Slides di utilizzare un font disponibile al posto di un font che non può essere raggiunto quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il font assegnato al contenuto della presentazione.

È possibile definire il font da usare quando un determinato font non è disponibile e ispezionare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con font installati diversi.

Se un font è disponibile ma non ha un tipo grassetto dedicato, vedere [Gestire i font senza un tipo di carattere grassetto dedicato](/slides/it/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Quella sezione spiega come rasterizzare il testo interessato durante l'esportazione in PDF e le conseguenze per la selezione del testo, la ricerca e lo scaling.

## **Ottenere le sostituzioni di font**

Utilizzare il metodo [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) per determinare quali font verranno sostituiti quando la presentazione è renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del font originale e di quello sostituito.

Il seguente esempio JavaScript elenca tutte le sostituzioni di font per una presentazione:

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

## **Ottenere le sostituzioni di font per diapositive selezionate**

Utilizzare la sovraccarico del metodo [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con un array di indici di diapositiva per ispezionare solo le sostituzioni necessarie a renderizzare diapositive specifiche. Questo è utile quando si renderizza o esporta una parte di una presentazione, si controlla una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da font non disponibili, si prepara un pacchetto di font minimale per un server o container, o si diagnosticano differenze di rendering senza elaborare diapositive non pertinenti.

La sovraccarico accetta un primitive Java `int[]`. Crearlo con `java.newArray("int", [...])`; un semplice array JavaScript viene convertito in `Integer[]` e non corrisponde a questa sovraccarico.

L'array contiene indici di diapositiva basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessor della collezione [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) utilizza l'indicizzazione basata su 0, quindi la stessa diapositiva viene acceduta come `presentation.getSlides().get_Item(0)`. Tenere presente questa differenza quando si costruisce l'array per evitare errori di offset.

Chiamare la sovraccarico tramite [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del font originale e di quello sostituito. Il risultato riflette l'ambiente font corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) e i [font caricati esternamente](/slides/it/nodejs-java/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. De‑duplicare i risultati quando si crea un inventario dei font o un report di preflight. Il seguente esempio segnala ogni sostituzione restituita e poi crea un elenco ordinato di mappature di font uniche:

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

La classe [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) fornisce entrambe le sovraccarichi. Scegliere quella più adatta all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) senza argomenti | Sono necessarie le sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) con un `int[]` Java di indici di diapositiva | Sono necessarie le sostituzioni per un intervallo selezionato, controllo incrementale o esportazione parziale. |

## **Impostare le regole di sostituzione dei font**

Per specificare il font che Aspose.Slides deve utilizzare quando un font di origine non è disponibile:

1. Caricare la presentazione.  
2. Creare le definizioni dei font per il font di origine e quello sostitutivo.  
3. Creare una [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/).  
4. Aggiungere la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).  
5. Assegnare la collezione utilizzando il metodo [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Renderizzare o convertire la presentazione.

Il seguente esempio JavaScript sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, quindi renderizza la prima diapositiva per verificare il risultato. Il font sostitutivo deve essere disponibile per Aspose.Slides.

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
Per una modifica incondizionata dei font utilizzati in tutta la presentazione, vedere [Sostituzione dei font](/slides/it/nodejs-java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font fanno parte del processo standard di selezione dei font utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un font inaccessibile con il font disponibile specificato da una regola.

Le equazioni Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel font esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro font matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe comunque segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire tale presentazione, rendere **Cambria Math** disponibile per Aspose.Slides. Installarlo nel sistema operativo o caricarlo come [font esterno](/slides/it/nodejs-java/custom-font/).

Questa limitazione si applica al layout delle equazioni. Le regole di sostituzione descritte sopra continuano a valere per il testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra sostituzione dei font e sostituzione dei font?**

[Font replacement](/slides/it/nodejs-java/font-replacement/) cambia intenzionalmente un font in un altro in tutta la presentazione. La sostituzione dei font seleziona un font per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il font originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione del font](/slides/it/nodejs-java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola viene usata solo quando Aspose.Slides non può accedere al font di origine.

** Cosa accade quando un font manca e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il font disponibile più vicino secondo il suo processo di selezione dei font. Il risultato dipende dai font presenti nell'ambiente di runtime.

**Posso caricare font esterni per evitare la sostituzione?**

Sì. È possibile [caricare font esterni](/slides/it/nodejs-java/custom-font/) affinché Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce i font con la libreria?**

No. È responsabilità dell'utente fornire i font e rispettare le relative licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I font installati e le posizioni di ricerca dei font differiscono a seconda del sistema operativo, quindi un font disponibile su una macchina può richiedere una sostituzione su un'altra.

**Come posso rendere coerente la selezione dei font nelle conversioni batch?**

Utilizzare gli stessi file di font e versioni su ogni macchina o container, [caricare i font esterni richiesti](/slides/it/nodejs-java/custom-font/), e [incorporare i font](/slides/it/nodejs-java/embedded-font/) quando le licenze lo consentono. È inoltre possibile chiamare [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) prima dell'esportazione per identificare eventuali sostituzioni inattese.