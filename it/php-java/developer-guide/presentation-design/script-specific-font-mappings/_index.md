---
title: Gestire i font del tema specifici per script in PHP
linktitle: Font del tema specifici per script
type: docs
weight: 15
url: /it/php-java/script-specific-font-mappings/
keywords:
- font specifico per script
- mappatura dei font del tema
- presentazione multilingue
- sistema di scrittura
- font cirillico
- font arabo
- font giapponese
- font georgiano
- font thaana
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di font specifici per script nei temi PowerPoint con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Un tema di presentazione può selezionare famiglie di caratteri diverse per diversi sistemi di scrittura. Ciò consente al testo multilingue che utilizza ancora i caratteri del tema di seguire uno schema di caratteri coordinato, usando caratteri adatti per il cirillico, l'arabo, il giapponese, il georgiano, il thaana e altri script.

Il [FontScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontscheme/) del tema contiene una collezione di caratteri principali, tipicamente usata per i titoli, e una collezione di caratteri secondari, tipicamente usata per il testo del corpo. Oltre alle impostazioni di caratteri per il Latino e l'Est asiatico, entrambe le collezioni di [Fonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/) espongono le mappature dai tag dei sistemi di scrittura ai nomi delle famiglie di caratteri.

Questo articolo mostra come ispezionare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e riapertura.

## **Comprendere i tag di script**

I metodi dei caratteri di script utilizzano sottotag di script BCP 47 a quattro lettere per identificare i sistemi di scrittura. I valori comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

## **Accedere e Ispezionare le Mappature dei Caratteri Script**

Usa [Presentation::getMasterTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasterTheme) per accedere al tema a livello di presentazione. I metodi [MasterTheme::getFontScheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontscheme/#getMajor) e [FontScheme::getMinor](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontscheme/#getMinor) forniscono l'accesso alle due collezioni di [Fonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/).

Chiama [Fonts::getScriptFontMap](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/#getScriptFontMap) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [Fonts::getScriptFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/#getScriptFont) con il relativo tag script. `Fonts::getScriptFont` restituisce `null` quando quella collezione non definisce la mappatura richiesta.

## **Modificare le Mappature e Verificare la Persistenza**

Usa [Fonts::setScriptFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/#setScriptFont) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [Fonts::removeScriptFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/#removeScriptFont) per rimuovere una mappatura.

Il seguente esempio end‑to‑end legge tutte le mappature principali e secondarie esistenti, cerca il carattere principale giapponese, modifica il carattere principale cirillico, rimuove la mappatura secondaria Thaana, salva la presentazione e la riapre per verificare entrambe le modifiche. Per rendere il passo di rimozione indipendente dal tema iniziale, l'esempio crea prima una mappatura Thaana solo se non è già definita.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

La verifica utilizza lo stesso comportamento `null` di una ricerca ordinaria: dopo che la rimozione è stata salvata, `Fonts::getScriptFont("Thaa")` restituisce `null` per la collezione secondaria.

## **Distinguere le Mappature del Tema da Altre Impostazioni di Carattere**

Le mappature del tema specifiche per script partecipano alla selezione del carattere, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto della modifica di una mappatura del tema |
|---|---|---|
| Mappatura del carattere del tema specifica per script | Seleziona un carattere del tema principale o secondario per un sistema di scrittura. | Il testo che continua a utilizzare il carattere del tema corrispondente può risolvere alla nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la sua formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione del carattere | Sostituisce un carattere richiesto quando quel carattere non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che un carattere è stato richiesto; non ridefinisce la mappatura script del tema. |
| Fallback del carattere | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Compensa la copertura di glifi mancanti; non modifica la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, vedi [Sostituzione dei caratteri](/slides/it/php-java/font-substitution/) e [Caratteri di fallback](/slides/it/php-java/fallback-font/).

Modificare una mappatura in [Presentation::getMasterTheme](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasterTheme) influisce solo sul contenuto il cui formattazione effettiva dipende ancora da quel tema. Il testo può invece ereditare una sovrascrittura del tema da un master, layout o slide, oppure utilizzare un carattere assegnato esplicitamente. Ispeziona questi livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere Disponibili i Caratteri Mappati e Validare il Risultato**

Una mappatura script memorizza il nome di una famiglia di caratteri; non installa né carica il relativo file di carattere. Per un rendering e un'esportazione coerenti, ogni carattere mappato deve essere installato nell'ambiente o fornito ad Aspose.Slides tramite una fonte personalizzata come [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsloader/#loadExternalFonts) o [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Vedi [Custom Fonts](/slides/it/php-java/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non dimostra che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout previsto. Renderizza testo rappresentativo per ogni sistema di scrittura richiesto in un'immagine o PDF e ispeziona l'output. Questo individuerà caratteri mancanti, copertura di glifi incompleta, comportamento di fallback e modifiche di layout prima che la presentazione venga distribuita. Vedi [Convert PowerPoint Presentations](/slides/it/php-java/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `Fonts::getScriptFont` quando uno script non è mappato?**

`[Fonts::getScriptFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/#getScriptFont)` restituisce `null` quando la mappatura dello script richiesto non è definita in quella collezione di caratteri principale o secondaria.

**`Fonts::setScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. `[Fonts::setScriptFont](https://reference.aspose.com/slides/it/php-java/aspose.slides/fonts/#setScriptFont)` crea la mappatura quando è mancante e sostituisce la famiglia di caratteri mappata quando lo stesso tag script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato alcuni testi?**

Il testo può avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite una sovrascrittura, o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura script a livello di presentazione controlla solo il testo la cui formattazione effettiva fa ancora riferimento a quella collezione di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l'output multilingue?**

No. La riapertura verifica la persistenza dei dati del tema. Inoltre, renderizza testo rappresentativo da ogni sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.