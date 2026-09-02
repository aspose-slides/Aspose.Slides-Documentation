---
title: Personalizza i font di PowerPoint in .NET
linktitle: Font personalizzato
type: docs
weight: 20
url: /it/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Personalizza i font nelle diapositive PowerPoint con Aspose.Slides per .NET per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una presentazione specifica tramite font source a livello di documento, oppure caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere coerente l’output della presentazione in ambienti diversi. L’articolo spiega anche come ispezionare le cartelle dei caratteri usate da Aspose.Slides e come svuotare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall’incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all’interno della presentazione stessa, usare esplicitamente le funzionalità di embedding dei caratteri.

Un tema della presentazione può fare riferimento a famiglie di caratteri diverse per i vari sistemi di scrittura. queste mappature memorizzano i nomi dei caratteri ma non installano né caricano i file dei caratteri. Vedi [Script-Specific Theme Fonts](/slides/it/net/script-specific-font-mappings/) per gestire le mappature e utilizza le opzioni di caricamento qui sotto per rendere disponibili i caratteri di riferimento per un rendering coerente.

{{% alert color="info" title="Nota" %}}

Aspose Slides consente di caricare questi caratteri usando il metodo [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/):

* Caratteri TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Caratteri OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Caricare caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri usati in una presentazione senza installarli sul sistema. Ciò influisce sull’output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti hanno un aspetto coerente in tutti gli ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei caratteri.  
2. Chiama il metodo statico [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) per caricare i caratteri da quelle cartelle.  
3. Carica e renderizza/esporta la presentazione.  
4. Chiama [FontsLoader.ClearCache](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/clearcache/) per svuotare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definisci le cartelle che contengono i file dei font personalizzati.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i font caricati.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Svuota la cache dei font dopo aver terminato il lavoro.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Nota" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l’ordine di inizializzazione dei caratteri.  
I caratteri vengono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottenere cartelle di caratteri personalizzati**

Aspose.Slides fornisce il metodo [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di sistema.

Questo codice C# mostra come utilizzare [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Questa riga restituisce le cartelle controllate per i file dei font.
// Si tratta di cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specificare i caratteri personalizzati usati con una presentazione**

Aspose.Slides fornisce la proprietà [DocumentLevelFontSources](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/documentlevelfontsources/) per consentire di specificare i caratteri esterni che verranno utilizzati con la presentazione.

Questo codice C# mostra come utilizzare la proprietà [DocumentLevelFontSources](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Lavora con la presentazione
    // CustomFont1, CustomFont2 e i font dalle cartelle assets\fonts e global\fonts e le loro sottocartelle sono disponibili per la presentazione
}
```

## **Gestire i caratteri esternamente**

Aspose.Slides fornisce il metodo [LoadExternalFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) per consentire di caricare caratteri esterni da dati binari.

Questo codice C# dimostra il processo di caricamento del carattere da un array di byte:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // font esterno caricato durante la durata della presentazione
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**I caratteri personalizzati influiscono sull’esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I caratteri collegati sono utilizzati dal renderer in tutti i formati di esportazione.

**I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un carattere per il rendering non è la stessa cosa dell’incorporamento in un PPTX. Se è necessario che il carattere sia contenuto nel file della presentazione, occorre utilizzare esplicitamente le [funzionalità di embedding](/slides/it/net/embedded-font/).

**Posso controllare il comportamento di fallback quando un carattere personalizzato manca di alcuni glifi?**

Sì. Configura la [sostituzione dei caratteri](/slides/it/net/font-substitution/), le [regole di sostituzione](/slides/it/net/font-replacement/) e i [set di fallback](/slides/it/net/fallback-font/) per definire esattamente quale carattere usare quando il glifo richiesto è assente.

**Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?**

Sì. Puntare alle proprie cartelle dei caratteri o caricare i caratteri da array di byte rimuove qualsiasi dipendenza dalle directory di sistema del contenitore.

> **Nota per Linux/Docker**: quando si chiama `FontsLoader.LoadExternalFonts`, assicurarsi che ogni voce nell’array `directories` contenga un percorso non vuoto a una cartella esistente. Se una variabile d’ambiente usata per costruire il percorso del carattere è indefinita o vuota, Aspose.Slides potrebbe tentare di risolvere il valore vuoto come percorso completo, generando `System.ArgumentException`.

**Cosa riguarda le licenze—posso incorporare qualsiasi carattere personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze proibiscono l’incorporamento o l’uso commerciale. Consulta sempre l’EULA del carattere prima di distribuire i risultati.