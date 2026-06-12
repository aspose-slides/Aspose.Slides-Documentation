---
title: Personalizza i caratteri PowerPoint in JavaScript
linktitle: Carattere personalizzato
type: docs
weight: 20
url: /it/nodejs-java/custom-font/
keywords:
- font
- font personalizzato
- font esterno
- carica carattere
- gestisci font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalizza i caratteri nelle diapositive PowerPoint con JavaScript e Aspose.Slides per Node.js tramite Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire i caratteri per una presentazione specifica tramite font a livello di documento, oppure caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere coerente l'output della presentazione in ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei caratteri utilizzate da Aspose.Slides e come cancellare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall'incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei caratteri.

{{% alert color="primary" %}} 
Aspose Slides consente di caricare questi caratteri utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedere [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Caratteri OpenType (.otf). Vedere [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione — come PDF, immagini e altri formati supportati — in modo che i documenti risultanti appaiano coerenti tra ambienti diversi. I caratteri vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei caratteri.
2. Chiamare il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) per caricare i caratteri da tali cartelle.
3. Caricare e renderizzare/esportare la presentazione.
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/clearcache/) per cancellare la cache dei caratteri.

La seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```js
// Definisci le cartelle che contengono i file dei font personalizzati.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Carica i font personalizzati dalle cartelle specificate.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderizza/esporta la presentazione (ad esempio, in PDF, immagini o altri formati) usando i font caricati.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Cancella la cache dei font dopo aver terminato il lavoro.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri. I caratteri sono inizializzati in questo ordine:

1. Il percorso dei caratteri predefinito del sistema operativo.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartella dei caratteri personalizzati**
Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei caratteri di sistema.

Questo codice JavaScript mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Questa riga restituisce le cartelle in cui vengono cercati i file dei font.
// Sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Specifica i caratteri personalizzati usati con la presentazione**
Aspose.Slides fornisce la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) per consentire di specificare i caratteri esterni che verranno usati con la presentazione.

Questo codice JavaScript mostra come utilizzare la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Lavora con la presentazione
    // CustomFont1, CustomFont2 e i font dalle cartelle assets\fonts e global\fonts e le loro sottocartelle sono disponibili per la presentazione
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestisci i caratteri esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentire di caricare caratteri esterni da dati binari.

Questo codice JavaScript dimostra il processo di caricamento dei caratteri da array di byte:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // font esterno caricato durante la durata della presentazione
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**I caratteri personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I caratteri collegati vengono utilizzati dal renderer in tutti i formati di esportazione.

**I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un carattere per il rendering non è la stessa cosa dell'incorporarlo in un PPTX. Se è necessario che il carattere sia incluso nel file della presentazione, è necessario utilizzare le [funzionalità di incorporamento](/slides/it/nodejs-java/embedded-font/).

**Posso controllare il comportamento di fallback quando un carattere personalizzato non dispone di alcuni glifi?**

Sì. Configura la [sostituzione dei caratteri](/slides/it/nodejs-java/font-substitution/), le [regole di sostituzione](/slides/it/nodejs-java/font-replacement/) e i [set di fallback](/slides/it/nodejs-java/fallback-font/) per definire esattamente quale carattere utilizzare quando il glifo richiesto è mancante.

**Posso usare i caratteri in container Linux/Docker senza installarli a livello di sistema?**

Sì. Puntare alle proprie cartelle dei caratteri o caricare i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei caratteri di sistema nell'immagine del container.

**E per quanto riguarda le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre la EULA del carattere prima di distribuire i risultati.