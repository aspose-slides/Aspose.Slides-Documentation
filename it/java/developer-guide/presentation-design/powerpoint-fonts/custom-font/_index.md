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
- carica font
- gestisci font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare font personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font a livello di documento, o caricare font esterni direttamente da dati binari.

I font caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente su ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei font utilizzate da Aspose.Slides e come cancellare la cache dei font dopo aver lavorato con font esterni.

La registrazione di font personalizzati per il rendering è separata dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei font.

Un tema della presentazione può fare riferimento a diverse famiglie di font per sistemi di scrittura individuali. Queste associazioni memorizzano i nomi dei font ma non installano né caricano i file dei font. Vedi [Font Tematici Specifici per Script](/slides/it/java/script-specific-font-mappings/) per gestire le associazioni e utilizza le opzioni di caricamento qui sotto per rendere i font di riferimento disponibili per un rendering coerente.

{{% alert color="info" title="Nota" %}}

Aspose Slides consente di caricare questi font utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica Font Personalizzati**

Aspose.Slides consente di caricare i font usati in una presentazione senza installarli sul sistema. Ciò influisce sull'output di esportazione — ad esempio PDF, immagini e altri formati supportati — in modo che i documenti risultanti appaiano coerenti su ambienti diversi. I font vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei font.
2. Chiamare il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) per caricare i font da quelle cartelle.
3. Caricare e renderizzare/esportare la presentazione.
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader#clearCache--) per cancellare la cache dei font.

Il seguente esempio di codice dimostra il processo di caricamento dei font:

```java
import com.aspose.slides.*;

// Definisci le cartelle che contengono i file dei font personalizzati.
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

{{% alert color="info" title="Nota" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font. I font sono inizializzati in questo ordine:

1. Il percorso dei font predefinito del sistema operativo.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni Cartelle Font Personalizzate**
Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--) per consentire di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei font di sistema.

Questo codice Java mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Questa riga restituisce le cartelle dove vengono cercati i file dei font.
// Queste sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specifica Font Personalizzati Usati con una Presentazione**
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
    // CustomFont1, CustomFont2 e i font dalle cartelle assets\fonts & global\fonts e dalle loro sottocartelle sono disponibili per la presentazione
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestisci Font Esternamente**

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

### I font personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I font collegati sono utilizzati dal motore di rendering su tutti i formati di esportazione.

### I font personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. Registrare un font per il rendering non è lo stesso di incorporarlo in un PPTX. Se è necessario che il font sia contenuto nel file della presentazione, è necessario utilizzare esplicitamente le [funzionalità di incorporamento](/slides/it/java/embedded-font/).

### Posso controllare il comportamento di fallback quando un font personalizzato manca di alcuni glifi?

Sì. Configura la [sostituzione dei font](/slides/it/java/font-substitution/), le [regole di sostituzione](/slides/it/java/font-replacement/) e i [set di fallback](/slides/it/java/fallback-font/) per definire esattamente quale font utilizzare quando il glifo richiesto è assente.

### Posso usare i font in contenitori Linux/Docker senza installarli a livello di sistema?

Sì. Indica le tue cartelle di font o carica i font da array di byte. Questo elimina qualsiasi dipendenza dalle directory di font di sistema nell'immagine del contenitore.

### Per quanto riguarda le licenze—posso incorporare qualsiasi font personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze proibiscono l'incorporamento o l'uso commerciale. Rivedi sempre l'EULA del font prima di distribuire i risultati.