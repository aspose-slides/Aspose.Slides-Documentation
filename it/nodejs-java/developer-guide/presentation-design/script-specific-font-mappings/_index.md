---
title: Gestire i caratteri del tema specifici per script in JavaScript
linktitle: Caratteri del tema specifici per script
type: docs
weight: 15
url: /it/nodejs-java/script-specific-font-mappings/
keywords:
- carattere specifico per script
- mappatura del carattere del tema
- presentazione multilingue
- sistema di scrittura
- carattere cirillico
- carattere arabo
- carattere giapponese
- carattere georgiano
- carattere thaana
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di caratteri specifici per script nei temi PowerPoint con Aspose.Slides per Node.js."
---
## **Panoramica**

Un tema di presentazione può selezionare famiglie di caratteri diverse per sistemi di scrittura diversi. Ciò consente di avere testo multilingue che utilizza ancora i caratteri del tema e segue uno schema tipografico coordinato, usando al contempo caratteri appropriati per cirillico, arabo, giapponese, georgiano, thaana e altri script.

Il [FontScheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontscheme/) del tema contiene una collezione di caratteri principale, tipicamente usata per i titoli, e una collezione di caratteri secondaria, tipicamente usata per il corpo del testo. Oltre alle impostazioni dei caratteri latini e dell’Estremo Oriente, entrambe le collezioni espongono mappature da tag di sistema di scrittura a nomi di famiglie di caratteri attraverso la classe [Fonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/).

Questo articolo mostra come ispezionare e modificare quelle mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio‑e‑riapertura.

## **Comprendere i tag di script**

I metodi per i caratteri di script usano sottotag BCP 47 di quattro lettere per identificare i sistemi di scrittura. I valori più comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Queste mappature appartengono allo schema dei caratteri del tema, non a singole porzioni di testo. Una presentazione può definire mappature diverse per le collezioni principale e secondaria e può omettere mappature per alcuni script.

## **Accedere e ispezionare le mappature dei caratteri di script**

Usa [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getmastertheme/) per accedere al tema a livello di presentazione. I metodi [FontScheme.getMajor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontscheme/) e [FontScheme.getMinor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontscheme/) restituiscono le due collezioni di [Fonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/).

Chiama [Fonts.getScriptFontMap](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [Fonts.getScriptFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/) con il suo tag di script. `getScriptFont` restituisce `null` quando quella collezione non definisce la mappatura richiesta.

## **Modificare le mappature e verificare la persistenza**

Usa [Fonts.setScriptFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [Fonts.removeScriptFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/) per rimuovere una mappatura.

L’esempio end‑to‑end seguente legge tutte le mappature principali e secondarie esistenti, ricerca il carattere principale giapponese, modifica il carattere principale cirillico, rimuove la mappatura secondaria thaana, salva la presentazione e la riapre per verificare entrambe le modifiche. Per rendere il passaggio di rimozione indipendente dal tema iniziale, l’esempio crea prima una mappatura thaana solo se non è già definita.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

La verifica utilizza lo stesso comportamento `null` di una ricerca ordinaria: dopo aver salvato la rimozione, `getScriptFont("Thaa")` restituisce `null` per la collezione secondaria.

## **Distinguere le mappature del tema da altre impostazioni di carattere**

Le mappature specifiche per script partecipano alla selezione dei caratteri, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto della modifica di una mappatura del tema |
|---|---|---|
| Mappatura di carattere specifica per script del tema | Seleziona un carattere principale o secondario del tema per un sistema di scrittura. | Il testo che continua a usare il carattere del tema corrispondente può risolvere nella nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione di carattere | Sostituisce un carattere richiesto quando quel carattere non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che è stato richiesto un carattere; non ridefinisce la mappatura dello script del tema. |
| Fallback dei caratteri | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Copre la mancanza di glifi; non modifica la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, consulta [Font Substitution](/slides/it/nodejs-java/font-substitution/) e [Fallback Fonts](/slides/it/nodejs-java/fallback-font/).

Modificare una mappatura in [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/getmastertheme/) influisce solo sul contenuto la cui formattazione efficace dipende ancora da quel tema. Il testo può invece ereditare una sovrascrittura del tema da un master, layout o diapositiva, o usare un carattere assegnato esplicitamente. Ispeziona quei livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura di script memorizza un nome di famiglia di caratteri; non installa né carica il file del carattere corrispondente. Per una resa e un’esportazione coerenti, ogni carattere mappato deve essere installato nell’ambiente o fornito ad Aspose.Slides tramite una sorgente personalizzata come [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/). Vedi [Custom Fonts](/slides/it/nodejs-java/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non dimostra che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout previsto. Renderizza testo rappresentativo per ogni sistema di scrittura richiesto in un’immagine o PDF e ispeziona l’output. Questo individua caratteri mancanti, copertura incompleta dei glifi, comportamento di fallback e cambiamenti di layout prima della distribuzione della presentazione. Vedi [Convert PowerPoint Presentations](/slides/it/nodejs-java/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `getScriptFont` quando uno script non è mappato?**

[Fonts.getScriptFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/) restituisce `null` quando la mappatura dello script richiesta non è definita in quella collezione principale o secondaria.

**`setScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. [Fonts.setScriptFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fonts/) crea la mappatura quando manca e sostituisce la famiglia di caratteri mappata quando il tag di script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato qualche testo?**

Il testo potrebbe avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite una sovrascrittura, o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura di script a livello di presentazione controlla solo il testo la cui formattazione efficace fa ancora riferimento a quella collezione di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l’output multilingue?**

No. La riapertura verifica la persistenza dei dati del tema. È inoltre necessario renderizzare testo rappresentativo da ciascun sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.