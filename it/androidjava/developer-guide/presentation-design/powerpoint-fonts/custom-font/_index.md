---
title: Personalizza i caratteri PowerPoint su Android
linktitle: Carattere personalizzato
type: docs
weight: 20
url: /it/androidjava/custom-font/
keywords:
- carattere
- carattere personalizzato
- carattere esterno
- caricare carattere
- gestire caratteri
- cartella dei caratteri
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza i caratteri nelle diapositive PowerPoint con Aspose.Slides per Android tramite Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite font a livello di documento, o caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono usati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei caratteri usate da Aspose.Slides e come cancellare la cache dei caratteri dopo aver lavorato con caratteri esterni.

{{% alert color="info" %}} 

Aspose Slides consente di caricare questi caratteri utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri usati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti tra ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei caratteri.  
2. Chiamare il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) per caricare i caratteri da quelle cartelle.  
3. Caricare e renderizzare/esportare la presentazione.  
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsLoader#clearCache--) per cancellare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```java
import com.aspose.slides.*;

// Definisci le cartelle che contengono i file dei caratteri personalizzati.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Carica i caratteri personalizzati dalle cartelle specificate.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i caratteri caricati.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Cancella la cache dei caratteri dopo che il lavoro è terminato.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l'ordine di inizializzazione dei caratteri.  
I caratteri vengono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartelle dei caratteri personalizzati**
Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di sistema.

Questo codice Java mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Questa riga restituisce le cartelle dove vengono cercati i file dei caratteri.
// Queste sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle di sistema dei caratteri.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specifica i caratteri personalizzati utilizzati con una presentazione**
Aspose.Slides fornisce la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) per consentire di specificare caratteri esterni che saranno usati con la presentazione.

Questo codice Java mostra come utilizzare la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 e i caratteri dalle cartelle assets\fonts & global\fonts e dalle loro sottocartelle sono disponibili per la presentazione
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestisci i caratteri esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentire di caricare caratteri esterni da dati binari.

Questo codice Java dimostra il processo di caricamento del carattere da array di byte:

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

### I caratteri personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?

Sì. I caratteri collegati vengono utilizzati dal renderizzatore in tutti i formati di esportazione.

### I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?

No. Registrare un carattere per il rendering non è la stessa cosa di incorporarlo in un PPTX. Se è necessario che il carattere sia contenuto all'interno del file della presentazione, è necessario utilizzare le [embedding features](/slides/it/androidjava/embedded-font/).

### Posso controllare il comportamento di fallback quando un carattere personalizzato non dispone di alcuni glifi?

Sì. Configura la [font substitution](/slides/it/androidjava/font-substitution/), le [replacement rules](/slides/it/androidjava/font-replacement/) e i [fallback sets](/slides/it/androidjava/fallback-font/) per definire esattamente quale carattere viene usato quando il glifo richiesto è mancante.

### Posso usare i caratteri in container Linux/Docker senza installarli a livello di sistema?

Sì. Indirizza le tue cartelle dei caratteri o carica i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory di sistema dei caratteri nell'immagine del container.

### E per le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Controlla sempre l'EULA del carattere prima di distribuire i risultati.