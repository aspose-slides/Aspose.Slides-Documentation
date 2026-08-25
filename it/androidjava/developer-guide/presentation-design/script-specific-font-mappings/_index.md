---
title: Gestisci i caratteri di tema specifici per script su Android
linktitle: Caratteri di tema specifici per script
type: docs
weight: 15
url: /it/androidjava/script-specific-font-mappings/
keywords:
- font specifico per script
- mappatura del font del tema
- presentazione multilingue
- sistema di scrittura
- font cirillico
- font arabo
- font giapponese
- font georgiano
- font thaana
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di font specifici per script nei temi PowerPoint con Aspose.Slides per Android via Java."
---
## **Panoramica**

Un tema di presentazione può selezionare famiglie di caratteri diverse per sistemi di scrittura differenti. Questo consente al testo multilingue che utilizza ancora i caratteri del tema di seguire uno schema di caratteri coordinato utilizzando caratteri appropriati per il cirillico, l'arabo, il giapponese, il georgiano, il thaana e altri script.

Il [IFontScheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontscheme/) del tema contiene una collezione di caratteri principale, tipicamente usata per le intestazioni, e una collezione di caratteri secondaria, tipicamente usata per il corpo del testo. Oltre alle impostazioni dei caratteri latino e dell'Asia orientale, entrambe le collezioni espongono mappature dai tag dei sistemi di scrittura ai nomi delle famiglie di caratteri tramite l'interfaccia [IFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifonts/).

Questo articolo mostra come ispezionare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e riapertura.

## **Comprendere i tag degli script**

I metodi per i caratteri script utilizzano sottotag script BCP 47 a quattro lettere per identificare i sistemi di scrittura. I valori comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Queste mappature appartengono allo schema di caratteri del tema, non a singole porzioni di testo. Una presentazione può definire mappature differenti per le collezioni principale e secondaria, e può omettere mappature per alcuni script.

## **Accedere e ispezionare le mappature dei caratteri script**

Usa [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getMasterTheme--) per accedere al tema a livello di presentazione. I metodi [IFontScheme.getMajor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontscheme/#getMajor--) e [IFontScheme.getMinor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontscheme/#getMinor--) restituiscono le due collezioni [IFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifonts/).

Chiama [IFonts.getScriptFontMap](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [IFonts.getScriptFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) con il suo tag script. `getScriptFont` restituisce `null` quando quella collezione non definisce la mappatura richiesta.

## **Modificare le mappature e verificarne la persistenza**

Usa [IFonts.setScriptFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [IFonts.removeScriptFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) per rimuovere una mappatura.

Il seguente esempio end-to-end legge tutte le mappature principali e secondarie esistenti, cerca il carattere principale giapponese, modifica il carattere principale cirillico, rimuove la mappatura secondaria Thaana, salva la presentazione e la riapre per verificare entrambi i cambiamenti. Per rendere il passaggio di rimozione indipendente dal tema iniziale, l'esempio crea prima una mappatura Thaana solo se non è già definita.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

La verifica utilizza lo stesso comportamento `null` di una ricerca ordinaria: dopo che la rimozione è stata salvata, `getScriptFont("Thaa")` restituisce `null` per la collezione secondaria.

## **Distinguere le mappature del tema da altre impostazioni dei caratteri**

Le mappature del tema specifiche per script partecipano alla selezione dei caratteri, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto della modifica di una mappatura del tema |
|---|---|---|
| Mappatura del carattere tema specifica per script | Seleziona un carattere tema principale o secondario per un sistema di scrittura. | Il testo che continua a utilizzare il carattere tema corrispondente può risolversi nella nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la sua formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione del carattere | Sostituisce un carattere richiesto quando quel carattere non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che un carattere è stato richiesto; non ridefinisce la mappatura script del tema. |
| Fallback del carattere | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Compensa la copertura dei glifi mancanti; non cambia la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, vedi [Font Substitution](/slides/it/androidjava/font-substitution/) e [Fallback Fonts](/slides/it/androidjava/fallback-font/).

Modificare una mappatura in [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getMasterTheme--) influisce solo sul contenuto la cui formattazione efficace dipende ancora da quel tema. Il testo può invece ereditare un override del tema da un master, da un layout o da una diapositiva, o utilizzare un carattere assegnato esplicitamente. Ispeziona questi livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura script memorizza il nome di una famiglia di caratteri; non installa né carica il file di carattere corrispondente. Per una resa e un'esportazione coerenti, ogni carattere mappato deve essere installato nell'ambiente o fornito ad Aspose.Slides tramite una fonte personalizzata come [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Vedi [Custom Fonts](/slides/it/androidjava/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non prova che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout desiderato. Renderizza testo rappresentativo per ogni sistema di scrittura richiesto in un'immagine o PDF e ispeziona l'output. Questo rileva caratteri mancanti, copertura di glifi incompleta, comportamento di fallback e modifiche al layout prima della distribuzione della presentazione. Vedi [Convert PowerPoint Presentations](/slides/it/androidjava/convert-powerpoint/) per esempi di renderizzazione ed esportazione.

## **FAQ**

**Cosa restituisce `getScriptFont` quando uno script non è mappato?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) restituisce `null` quando la mappatura script richiesta non è definita in quella collezione di caratteri principale o secondaria.

**`setScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. [IFonts.setScriptFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) crea la mappatura quando è assente e sostituisce la famiglia di caratteri mappata quando lo stesso tag script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato alcuni testi?**

Il testo può avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite un override, o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura script a livello di presentazione controlla solo il testo la cui formattazione efficace fa ancora riferimento a quella collezione di caratteri del tema.

**Il salvataggio e la riapertura sono sufficienti per convalidare l'output multilingue?**

No. Riaprire verifica la persistenza dei dati del tema. Inoltre, renderizza testo rappresentativo da ciascun sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.