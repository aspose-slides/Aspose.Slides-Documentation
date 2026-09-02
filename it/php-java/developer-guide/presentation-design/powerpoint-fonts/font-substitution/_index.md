---
title: Configura la sostituzione dei font nelle presentazioni usando PHP
linktitle: Sostituzione dei font
type: docs
weight: 70
url: /it/php-java/font-substitution/
keywords:
- font
- font sostituto
- sostituzione del font
- sostituire il font
- sostituzione del font
- regola di sostituzione
- regola di sostituzione
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Configura le regole di sostituzione dei font e controlla i font sostituiti in Aspose.Slides per PHP tramite Java durante il rendering o la conversione di presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

La sostituzione dei font permette ad Aspose.Slides di utilizzare un font disponibile al posto di un font a cui non è possibile accedere quando una presentazione viene renderizzata o convertita. La sostituzione influisce sull'output renderizzato; non modifica il font assegnato al contenuto della presentazione.

È possibile definire il font da usare quando un determinato font non è disponibile e inspectare le sostituzioni che Aspose.Slides effettuerà durante il rendering. Questo aiuta a mantenere l'output coerente tra ambienti con font installati diversi.

## **Ottenere le sostituzioni dei font**

Usa il metodo [FontsManager::getSubstitutions](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getsubstitutions/) per determinare quali font saranno sostituiti quando la presentazione viene renderizzata. Il metodo restituisce oggetti [FontSubstitutionInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstitutioninfo/) che identificano i nomi del font originale e di quello sostituito.

Il seguente esempio PHP elenca tutte le sostituzioni dei font per una presentazione:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Ottenere le sostituzioni dei font per le diapositive selezionate**

Usa la sovraccarico di [FontsManager::getSubstitutions](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getsubstitutions/) con un argomento `int[] slides` per analizzare solo le sostituzioni necessarie a renderizzare diapositive specifiche. È utile quando si renderizza o esporta una parte della presentazione, si verifica una presentazione di grandi dimensioni in modo incrementale, si individuano diapositive che dipendono da font non disponibili, si prepara un pacchetto di font minimale per un server o container, o si diagnosticano differenze di rendering senza elaborare diapositive non pertinenti.

L'array `slides` contiene indici diapositive basati su 1: `1` identifica la prima diapositiva. Al contrario, l'accessore della collezione [Presentation::getSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSlides) utilizza l'indicizzazione a partire da zero, quindi la stessa diapositiva viene acceduta come `$presentation->getSlides()->get_Item(0)`. Tieni presente questa differenza quando costruisci l'array per evitare errori di off-by-one.

Chiama la sovraccarico tramite il metodo [Presentation::getFontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getFontsManager). Restituisce solo le sostituzioni determinate durante il rendering delle diapositive selezionate. Ogni risultato è un oggetto [FontSubstitutionInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstitutioninfo/) che contiene i nomi del font originale e di quello sostituito. Il risultato riflette l'ambiente di font corrente, le regole di fallback configurate, le regole di sostituzione memorizzate in una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstrulecollection/), e i [font caricati esternamente](/slides/it/php-java/custom-font/).

La stessa sostituzione può essere richiesta da più di una diapositiva selezionata. De‑duplicare i risultati quando crei un inventario dei font o un rapporto di preflight. Il seguente esempio riporta ogni sostituzione restituita e quindi crea un elenco ordinato di mappature di font uniche:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

La classe [FontsManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/) fornisce entrambe le sovraccarichi. Scegli quella più adatta all'ambito dell'operazione di rendering:

| Sovraccarico | Quando usarlo |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getsubstitutions/) senza argomenti | Hai bisogno delle sostituzioni per l'intera presentazione. |
| [getSubstitutions](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getsubstitutions/) con `int[] slides` | Hai bisogno delle sostituzioni per un intervallo selezionato, verifica incrementale o esportazione parziale. |

## **Impostare le regole di sostituzione dei font**

Per specificare il font che Aspose.Slides deve usare quando un font sorgente non è disponibile:

1. Carica la presentazione.  
2. Crea le definizioni dei font per i font sorgente e sostituto.  
3. Crea un [FontSubstRule](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstrule/) con la condizione [WhenInaccessible](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstcondition/).  
4. Aggiungi la regola a una [FontSubstRuleCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsubstrulecollection/).  
5. Assegna la collezione usando il metodo [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Renderizza o converti la presentazione.

Il seguente esempio PHP sostituisce `Arial` con `SomeRareFont` quando `SomeRareFont` non è disponibile, quindi renderizza la prima diapositiva per verificare il risultato. Il font sostituto deve essere disponibile per Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Nota" %}}
Per una modifica incondizionata dei font usati in tutta la presentazione, consulta [Sostituzione dei font](/slides/it/php-java/font-replacement/).
{{% /alert %}}

## **Limitazioni per i font delle equazioni matematiche**

Le regole di sostituzione dei font fanno parte del processo standard di selezione dei font utilizzato durante il rendering e la conversione. Funzionano per il testo normale quando Aspose.Slides può sostituire un font inaccessibile con il font disponibile specificato da una regola.

Le equazioni di Office Math hanno un requisito aggiuntivo. Se un'equazione utilizza **Cambria Math**, Aspose.Slides potrebbe aver bisogno di quel font esatto per calcolare e renderizzare il layout dell'equazione. Una regola che sostituisce un altro font matematico, come **STIX Two Math**, non può sostituire **Cambria Math** a questo scopo, e il rendering potrebbe ancora segnalare che **Cambria Math** è necessario.

Per renderizzare o convertire una presentazione del genere, rendi **Cambria Math** disponibile per Aspose.Slides. Installalo nel sistema operativo o caricalo come [font esterno](/slides/it/php-java/custom-font/).

Questa limitazione si applica al layout dell'equazione. Le regole di sostituzione descritte sopra continuano a valere per il testo normale della presentazione.

## **FAQ**

**Qual è la differenza tra sostituzione dei font e sostituzione dei font?**

[Font replacement](/slides/it/php-java/font-replacement/) cambia intenzionalmente un font con un altro in tutta la presentazione. La sostituzione dei font seleziona un font per l'output renderizzato quando la condizione configurata è soddisfatta, ad esempio quando il font originale non è disponibile.

**Quando vengono applicate le regole di sostituzione?**

Le regole partecipano alla [sequenza di selezione dei font](/slides/it/php-java/font-selection-sequence/) durante il rendering e la conversione. Con `WhenInaccessible`, una regola è usata solo quando Aspose.Slides non può accedere al font sorgente.

** Cosa succede quando un font manca e non è configurata alcuna regola di sostituzione?**

Aspose.Slides seleziona il font più vicino disponibile secondo il suo processo di selezione dei font. Il risultato dipende dai font disponibili nell'ambiente di runtime.

**Posso caricare font esterni per evitare la sostituzione?**

Sì. Puoi [caricare font esterni](/slides/it/php-java/custom-font/) in modo che Aspose.Slides li utilizzi durante il rendering e la conversione.

**Aspose distribuisce i font con la libreria?**

No. Sei responsabile di fornire i font e di rispettare le loro licenze.

**I risultati della sostituzione possono differire tra Windows, Linux e macOS?**

Sì. I font installati e le posizioni di ricerca dei font variano a seconda del sistema operativo, quindi un font disponibile su una macchina può richiedere una sostituzione su un'altra.

**Come posso rendere la selezione dei font coerente nelle conversioni batch?**

Usa gli stessi file e versioni dei font su ogni macchina o container, [carica i font esterni richiesti](/slides/it/php-java/custom-font/), e [incorpora i font](/slides/it/php-java/embedded-font/) quando le licenze lo consentono. Puoi anche chiamare [FontsManager::getSubstitutions](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getsubstitutions/) prima dell'esportazione per identificare sostituzioni inattese.