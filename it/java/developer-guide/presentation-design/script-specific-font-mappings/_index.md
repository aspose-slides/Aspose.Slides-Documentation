---
title: Gestisci i caratteri del tema specifici per script in Java
linktitle: Caratteri del tema specifici per script
type: docs
weight: 15
url: /it/java/script-specific-font-mappings/
keywords:
- font specifico per script
- mappatura del carattere del tema
- presentazione multilingue
- sistema di scrittura
- font cirillico
- font arabo
- font giapponese
- font georgiano
- font thaana
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Ispeziona, aggiungi, sostituisci e rimuovi le mappature di font specifici per script nei temi PowerPoint con Aspose.Slides per Java."
---
## **Panoramica**

Un tema di presentazione può selezionare famiglie di caratteri diverse per sistemi di scrittura diversi. Ciò consente al testo multilingue che utilizza ancora i caratteri del tema di seguire uno schema di caratteri coordinato usando caratteri adatti per cirillico, arabo, giapponese, georgiano, thaana e altri script.

Il tema contiene un [IFontScheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontscheme/) che include una collezione di caratteri principale, tipicamente usata per i titoli, e una collezione di caratteri secondaria, tipicamente usata per il corpo del testo. Oltre alle impostazioni di caratteri Latini e dell’Est Asiatico, entrambe le collezioni espongono mappature dai tag dei sistemi di scrittura ai nomi delle famiglie di caratteri tramite l’interfaccia [IFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifonts/).

Questo articolo mostra come ispezionare e modificare tali mappature nel tema master della presentazione e verificare che le modifiche sopravvivano a un ciclo di salvataggio e ricarica.

## **Comprendere i tag script**

I metodi dei caratteri script utilizzano sottotag script a quattro lettere BCP 47 per identificare i sistemi di scrittura. I valori comuni includono:

| Tag script | Sistema di scrittura |
|---|---|
| `Cyrl` | Cirillico |
| `Arab` | Arabo |
| `Hans` | Cinese semplificato |
| `Jpan` | Giapponese |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Queste mappature appartengono allo schema dei caratteri del tema, non a singole porzioni di testo. Una presentazione può definire mappature diverse per le collezioni principale e secondaria e può omettere mappature per alcuni script.

## **Accedere e ispezionare le mappature dei caratteri script**

Usa [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasterTheme--) per accedere al tema a livello di presentazione. I metodi [IFontScheme.getMajor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontscheme/#getMajor--) e [IFontScheme.getMinor](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontscheme/#getMinor--) restituiscono le due collezioni [IFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifonts/).

Chiama [IFonts.getScriptFontMap](https://reference.aspose.com/slides/it/java/com.aspose.slides/fonts/#getScriptFontMap--) per recuperare tutte le mappature da una collezione. Per cercare un singolo sistema di scrittura, chiama [IFonts.getScriptFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) con il suo tag script. `getScriptFont` restituisce `null` quando quella collezione non definisce la mappatura richiesta.

## **Modificare le mappature e verificarne la persistenza**

Usa [IFonts.setScriptFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) per creare una mappatura o sostituire la famiglia di caratteri corrente. Usa [IFonts.removeScriptFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) per rimuovere una mappatura.

L’esempio end‑to‑end seguente legge tutte le mappature principali e secondarie esistenti, cerca il carattere principale giapponese, cambia il carattere principale cirillico, rimuove la mappatura secondaria thaana, salva la presentazione e la riapre per verificare entrambi i cambiamenti. Per rendere il passo di rimozione indipendente dal tema iniziale, l’esempio crea prima una mappatura thaana solo se non è già definita.

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

Le mappature del tema specifiche per script partecipano alla selezione del carattere, ma risolvono un problema diverso rispetto alla formattazione diretta del testo, alla sostituzione e al fallback:

| Meccanismo | Scopo | Effetto della modifica di una mappatura del tema |
|---|---|---|
| Mappatura del carattere del tema specifica per script | Seleziona un carattere tema principale o secondario per un sistema di scrittura. | Il testo che continua a usare il carattere tema corrispondente può risolversi nella nuova famiglia mappata. |
| Carattere assegnato esplicitamente a una porzione di testo | Fissa la famiglia di caratteri richiesta su quella porzione invece di fare affidamento sul tema. | La porzione può rimanere invariata perché la formattazione diretta sovrascrive la scelta del tema. |
| Sostituzione dei font | Sostituisce un carattere richiesto quando non è disponibile o quando si applica una regola di sostituzione. | Agisce dopo che un carattere è stato richiesto; non ridefinisce la mappatura script del tema. |
| Fallback dei font | Fornisce glifi che il carattere selezionato non contiene, spesso per intervalli Unicode specifici. | Copre le lacune di glifi; non modifica la mappatura del tema memorizzata. |

Per ulteriori informazioni sugli ultimi due meccanismi, vedi [Sostituzione dei font](/slides/it/java/font-substitution/) e [Font di fallback](/slides/it/java/fallback-font/).

Modificare una mappatura in [Presentation.getMasterTheme](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasterTheme--) influisce solo sul contenuto il cui formattazione effettiva dipende ancora da quel tema. Il testo può invece ereditare una sovrascrittura del tema da un master, layout o diapositiva, o usare un carattere assegnato esplicitamente. Ispeziona quei livelli quando il risultato visibile non segue la mappatura a livello di presentazione.

## **Rendere disponibili i caratteri mappati e convalidare il risultato**

Una mappatura script memorizza un nome di famiglia di caratteri; non installa né carica il file del carattere corrispondente. Per una resa e un’esportazione coerenti, ogni carattere mappato deve essere installato nell’ambiente o fornito ad Aspose.Slides tramite una fonte personalizzata come [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) o [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--). Vedi [Font personalizzati](/slides/it/java/custom-font/) per le opzioni di caricamento disponibili.

Verificare la mappatura salvata conferma solo che la definizione del tema è stata preservata. Non dimostra che il carattere sia disponibile, contenga tutti i glifi richiesti o produca il layout previsto. Renderizza testo rappresentativo per ogni sistema di scrittura richiesto in un’immagine o PDF e ispeziona l’output. Questo individua caratteri mancanti, copertura incompleta dei glifi, comportamento di fallback e variazioni di layout prima della distribuzione della presentazione. Vedi [Convertire presentazioni PowerPoint](/slides/it/java/convert-powerpoint/) per esempi di rendering ed esportazione.

## **FAQ**

**Cosa restituisce `getScriptFont` quando uno script non è mappato?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) restituisce `null` quando la mappatura dello script richiesto non è definita in quella collezione principale o secondaria.

**`setScriptFont` aggiunge una seconda mappatura quando lo script esiste già?**

No. [IFonts.setScriptFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) crea la mappatura quando manca e sostituisce la famiglia di caratteri mappata quando il medesimo tag script è già presente.

**Perché la modifica di una mappatura del tema non ha cambiato alcuni testi?**

Il testo potrebbe avere un carattere assegnato esplicitamente, ereditare un tema diverso tramite una sovrascrittura o essere influenzato da sostituzione o fallback durante il rendering. Una mappatura script a livello di presentazione controlla solo il testo il cui formattazione effettiva fa ancora riferimento a quella collezione di caratteri del tema.

**Salvare e riaprire è sufficiente per convalidare l’output multilingue?**

No. Riaprire verifica la persistenza dei dati del tema. È necessario anche renderizzare testo rappresentativo da ciascun sistema di scrittura richiesto per confermare che i caratteri mappati siano disponibili e contengano i glifi necessari.