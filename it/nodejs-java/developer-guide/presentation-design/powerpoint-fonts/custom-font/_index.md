---
title: Personalizza i caratteri di PowerPoint in JavaScript
linktitle: Carattere personalizzato
type: docs
weight: 20
url: /it/nodejs-java/custom-font/
keywords:
- carattere
- carattere personalizzato
- carattere esterno
- carica carattere
- gestisci caratteri
- cartella dei caratteri
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza i caratteri nelle diapositive PowerPoint con JavaScript e Aspose.Slides per Node.js tramite Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite font a livello di documento, o caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei caratteri usate da Aspose.Slides e come svuotare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall'incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all'interno della presentazione stessa, utilizzare le funzioni di incorporamento dei caratteri in modo esplicito.

Un tema della presentazione può fare riferimento a diverse famiglie di caratteri per sistemi di scrittura individuali. Queste mappature memorizzano i nomi dei caratteri ma non installano né caricano i file dei caratteri. Consulta [Script-Specific Theme Fonts](/slides/it/nodejs-java/script-specific-font-mappings/) per gestire le mappature e usa le opzioni di caricamento qui sotto per rendere disponibili i caratteri di riferimento per un rendering coerente.

{{% alert color="info" title="Nota" %}}
Aspose Slides consente di caricare questi caratteri utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Caratteri OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri usati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti tra gli ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei caratteri.
2. Chiama il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) per caricare i caratteri da quelle cartelle.
3. Carica e renderizza/esporta la presentazione.
4. Chiama [FontsLoader.clearCache](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/clearcache/) per svuotare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Definisci le cartelle che contengono i file dei caratteri personalizzati.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Carica i caratteri personalizzati dalle cartelle specificate.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i caratteri caricati.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Svuota la cache dei caratteri dopo aver completato il lavoro.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Nota" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri.  
I caratteri vengono inizializzati in questo ordine:

1. Il percorso predefinito del sistema operativo per i caratteri.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Ottieni cartella dei caratteri personalizzati**

Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) per consentirti di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di sistema.

Questo codice JavaScript mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Questa linea restituisce le cartelle dove vengono cercati i file dei caratteri.
// Queste sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle di sistema dei caratteri.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Specifica i caratteri personalizzati usati con la presentazione**

Aspose.Slides fornisce la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) per consentirti di specificare caratteri esterni che saranno usati con la presentazione.

Questo codice JavaScript mostra come utilizzare la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Lavora con la presentazione
    // CustomFont1, CustomFont2 e i caratteri dalle cartelle assets\fonts e global\fonts e le loro sottocartelle sono disponibili per la presentazione
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestisci i caratteri esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentirti di caricare caratteri esterni da dati binari.

Questo codice JavaScript dimostra il processo di caricamento del carattere da array di byte:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        //        // caricato esterno durante la durata della presentazione
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### I caratteri personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I caratteri collegati vengono utilizzati dal renderer in tutti i formati di esportazione.

### I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. Registrare un carattere per il rendering non è la stessa cosa dell'incorporarlo in un PPTX. Se hai bisogno che il carattere sia presente all'interno del file della presentazione, devi usare le [funzionalità di incorporamento](/slides/it/nodejs-java/embedded-font/).

### Posso controllare il comportamento di fallback quando un carattere personalizzato manca di alcuni glifi?

Sì. Configura la [sostituzione dei caratteri](/slides/it/nodejs-java/font-substitution/), le [regole di sostituzione](/slides/it/nodejs-java/font-replacement/) e i [set di fallback](/slides/it/nodejs-java/fallback-font/) per definire esattamente quale carattere usare quando il glifo richiesto è assente.

### Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?

Sì. Punta alle tue cartelle dei caratteri o carica i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory di sistema dei caratteri nell'immagine del contenitore.

### E per quanto riguarda le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze proibiscono l'incorporamento o l'uso commerciale. Rivedi sempre l'EULA del carattere prima di distribuire i risultati.