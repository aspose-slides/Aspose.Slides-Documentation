---
title: Personalizza i font di PowerPoint in Java
linktitle: Font personalizzato
type: docs
weight: 20
url: /it/java/custom-font/
keywords:
- font
- font personalizzato
- font esterno
- caricare font
- gestire font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite font a livello di documento, o caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra diversi ambienti. L'articolo spiega anche come ispezionare le cartelle dei caratteri utilizzate da Aspose.Slides e come cancellare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione dei caratteri personalizzati per il rendering è separata dall'incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei caratteri.

Un tema della presentazione può fare riferimento a diverse famiglie di caratteri per sistemi di scrittura individuali. Queste mappature memorizzano i nomi dei caratteri ma non installano né caricano i file dei caratteri. Consulta [Script-Specific Theme Fonts](/slides/it/java/script-specific-font-mappings/) per gestire le mappature e utilizza le opzioni di caricamento qui sotto per rendere i caratteri di riferimento disponibili per un rendering coerente.

{{% alert color="info" title="Note" %}}

Aspose Slides consente di caricare questi caratteri utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Caratteri OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri usati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti tra gli ambienti. I caratteri sono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei caratteri.
2. Chiama il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) per caricare i caratteri da quelle cartelle.
3. Carica e renderizza/esporta la presentazione.
4. Chiama [FontsLoader.clearCache](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#clearCache--) per cancellare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```java
import com.aspose.slides.*;

// Definisci le cartelle che contengono file di font personalizzati.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i font caricati.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Cancella la cache dei font dopo che il lavoro è terminato.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri.  
I caratteri vengono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartelle di caratteri personalizzati**

Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di sistema.

Questo codice Java mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Questa riga restituisce le cartelle dove vengono cercati i file dei font.
// Queste sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle di sistema dei font.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specifica i caratteri personalizzati usati con una presentazione**

Aspose.Slides fornisce la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) per consentire di specificare font esterni che saranno usati con la presentazione.

Questo codice Java mostra come utilizzare la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Lavora con la presentazione
    // CustomFont1, CustomFont2 e i font delle cartelle assets\fonts e global\fonts e delle loro sottocartelle sono disponibili per la presentazione
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestisci i caratteri esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentire di caricare font esterni da dati binari.

Questo codice Java dimostra il processo di caricamento del font da array di byte:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // font esterno caricato durante la durata della presentazione
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### I caratteri personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I caratteri collegati vengono utilizzati dal renderer in tutti i formati di esportazione.

### I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. La registrazione di un carattere per il rendering non è la stessa cosa dell'incorporamento in un PPTX. Se è necessario che il carattere sia contenuto nel file della presentazione, è necessario utilizzare esplicitamente le [funzionalità di incorporamento](/slides/it/java/embedded-font/).

### Posso controllare il comportamento di fallback quando un carattere personalizzato non dispone di alcuni glifi?

Sì. Configura la [sostituzione dei font](/slides/it/java/font-substitution/), le [regole di sostituzione](/slides/it/java/font-replacement/) e i [set di fallback](/slides/it/java/fallback-font/) per definire esattamente quale carattere viene usato quando il glifo richiesto è assente.

### Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?

Parzialmente. Aspose.Slides può utilizzare i caratteri dalle proprie cartelle o da array di byte senza installarli, ma il supporto ai font di Java richiede almeno un carattere installato nell'immagine. In assenza di uno, il caricamento fallisce con l'errore “Fontconfig head is null, check your fonts or fonts configuration”. Vedi [Deploy Fonts](/slides/it/java/deploy-fonts/).

### E per quanto riguarda le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del carattere prima di distribuire i risultati.