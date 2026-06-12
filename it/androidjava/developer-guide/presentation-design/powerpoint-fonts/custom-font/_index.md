---
title: Personalizza i font di PowerPoint su Android
linktitle: Font personalizzato
type: docs
weight: 20
url: /it/androidjava/custom-font/
keywords:
- font
- font personalizzato
- font esterno
- carica font
- gestire i font
- cartella dei font
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per Android tramite Java per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides ti consente di utilizzare font personalizzati nelle presentazioni senza installarli sul sistema operativo. Puoi caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font a livello di documento, o caricare font esterni direttamente da dati binari.

I font caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente tra ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei font utilizzate da Aspose.Slides e come cancellare la cache dei font dopo aver lavorato con font esterni.

Registrare font personalizzati per il rendering è separato dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizza esplicitamente le funzionalità di incorporamento dei font.

{{% alert color="primary" %}} 

Aspose Slides ti consente di caricare questi font utilizzando il metodo [loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica font personalizzati**

Aspose.Slides ti consente di caricare i font usati in una presentazione senza installarli sul sistema. Ciò influisce sull'output di esportazione — come PDF, immagini e altri formati supportati — in modo che i documenti risultanti appaiano coerenti tra gli ambienti. I font vengono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei font.
2. Chiama il metodo statico [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) per caricare i font da quelle cartelle.
3. Carica e renderizza/esporta la presentazione.
4. Chiama [FontsLoader.clearCache](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FontsLoader#clearCache--) per cancellare la cache dei font.

Il seguente esempio di codice dimostra il processo di caricamento dei font:

```java
// Definisci le cartelle che contengono file di font personalizzati.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderizza/esporta la presentazione (ad esempio in PDF, immagini o altri formati) utilizzando i font caricati.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Cancella la cache dei font dopo aver terminato il lavoro.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font.
I font sono inizializzati in questo ordine:

1. Il percorso predefinito dei font del sistema operativo.
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartelle dei font personalizzati**

Aspose.Slides fornisce il metodo [getFontFolders](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) per consentirti di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei font di sistema.

Questo codice Java mostra come utilizzare [getFontFolders](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Questa riga restituisce le cartelle dove vengono cercati i file dei font.
// Sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specifica i font personalizzati usati con una presentazione**

Aspose.Slides fornisce la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) per consentirti di specificare i font esterni che saranno utilizzati con la presentazione.

Questo codice Java mostra come utilizzare la proprietà [setDocumentLevelFontSources](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

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

## **Gestisci i font esternamente**

Aspose.Slides fornisce il metodo [loadExternalFont](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) per consentirti di caricare font esterni da dati binari.

Questo codice Java dimostra il processo di caricamento dei font da array di byte:

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

**I font personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I font collegati sono utilizzati dal renderer in tutti i formati di esportazione.

**I font personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un font per il rendering non è la stessa cosa dell'incorporarlo in un PPTX. Se hai bisogno che il font sia presente all'interno del file della presentazione, devi utilizzare le [funzionalità di incorporamento](/slides/it/androidjava/embedded-font/).

**Posso controllare il comportamento di fallback quando un font personalizzato non ha alcuni glifi?**

Sì. Configura la [sostituzione dei font](/slides/it/androidjava/font-substitution/), le [regole di sostituzione](/slides/it/androidjava/font-replacement/) e i [set di fallback](/slides/it/androidjava/fallback-font/) per definire esattamente quale font utilizzare quando il glifo richiesto è mancante.

**Posso usare i font in contenitori Linux/Docker senza installarli a livello di sistema?**

Sì. Indica le tue cartelle di font o carica i font da array di byte. Questo rimuove qualsiasi dipendenza dalle directory di font di sistema nell'immagine del contenitore.

**E per quanto riguarda le licenze: posso incorporare qualsiasi font personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Rivedi sempre la licenza EULA del font prima di distribuire i risultati.