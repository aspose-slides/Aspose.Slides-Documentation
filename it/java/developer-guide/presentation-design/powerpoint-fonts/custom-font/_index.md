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

Aspose.Slides consente di utilizzare font personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font source a livello di documento, oppure caricare font esterni direttamente da dati binari.

I font caricati vengono utilizzati quando una presentazione viene resa o esportata, ad esempio in PDF, immagini e altri formati supportati. Ciò aiuta a mantenere l'output della presentazione coerente tra diversi ambienti. L'articolo spiega inoltre come ispezionare le cartelle dei font utilizzate da Aspose.Slides e come cancellare la cache dei font dopo aver lavorato con font esterni.

La registrazione di font personalizzati per il rendering è separata dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei font.

{{% alert color="primary" %}} 
Aspose Slides consente di caricare questi font utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Caricare Font Personalizzati**

Aspose.Slides consente di caricare i font utilizzati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti tra gli ambienti. I font vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei font.
2. Chiamare il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) per caricare i font da tali cartelle.
3. Caricare e rendere/esportare la presentazione.
4. Chiamare [FontsLoader.clearCache](https://reference.aspose.com/slides/it/java/com.aspose.slides/FontsLoader#clearCache--) per cancellare la cache dei font.

Il seguente esempio di codice dimostra il processo di caricamento dei font:

```java
// Definisci le cartelle che contengono i file dei font personalizzati.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

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
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font.  
I font vengono inizializzati in questo ordine:

1. Il percorso predefinito dei font del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/).
{{%/alert %}}

## **Ottenere Cartelle di Font Personalizzate**
Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--) per consentire di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei font di sistema.

Questo codice Java mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Questa riga restituisce le cartelle in cui vengono cercati i file dei font.
// Sono cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specificare i Font Personalizzati Usati con una Presentazione**
Aspose.Slides fornisce la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) per consentire di specificare i font esterni che verranno utilizzati con la presentazione. 

Questo codice Java mostra come utilizzare la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Lavora con la presentazione
    // CustomFont1, CustomFont2 e i font dalle cartelle assets\fonts & global\fonts e le loro sottocartelle sono disponibili per la presentazione
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestire i Font Esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentire di caricare font esterni da dati binari.

Questo codice Java dimostra il processo di caricamento del font da array di byte:

```java
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

**I font personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I font collegati sono utilizzati dal renderizzatore in tutti i formati di esportazione.

**I font personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un font per il rendering non è la stessa cosa dell'incorporarlo in un PPTX. Se è necessario che il font sia incluso nel file della presentazione, è necessario utilizzare esplicitamente le [funzionalità di incorporamento](/slides/it/java/embedded-font/).

**Posso controllare il comportamento di fallback quando un font personalizzato manca di alcuni glifi?**

Sì. Configura la [sostituzione dei font](/slides/it/java/font-substitution/), le [regole di sostituzione](/slides/it/java/font-replacement/) e i [set di fallback](/slides/it/java/fallback-font/) per definire esattamente quale font utilizzare quando il glifo richiesto è mancante.

**Posso usare i font in container Linux/Docker senza installarli a livello di sistema?**

Sì. Indirizza le tue cartelle di font o carica i font da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei font di sistema nell'immagine del container.

**Che ne è della licenza—posso incorporare qualsiasi font personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze proibiscono l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del font prima di distribuire i risultati.