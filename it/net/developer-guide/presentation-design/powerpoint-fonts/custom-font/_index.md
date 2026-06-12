---
title: Personalizza i Font di PowerPoint in .NET
linktitle: Font Personalizzato
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
description: "Personalizza i font nelle slide PowerPoint con Aspose.Slides per .NET per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare font personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font a livello di documento, o caricare font esterni direttamente da dati binari.

I font caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo consente di mantenere l'output della presentazione coerente tra ambienti diversi. L'articolo spiega inoltre come ispezionare le cartelle dei font utilizzate da Aspose.Slides e come cancellare la cache dei font dopo aver lavorato con font esterni.

La registrazione di font personalizzati per il rendering è separata dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei font.

{{% alert color="primary" %}} 
Aspose Slides consente di caricare questi font mediante il metodo [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica Font Personalizzati**

Aspose.Slides consente di caricare i font utilizzati in una presentazione senza installarli sul sistema. Ciò influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—perché i documenti risultanti appaiano coerenti tra gli ambienti. I font vengono caricati da directory personalizzate.

1. Specifica una o più cartelle che contengono i file dei font.  
2. Chiama il metodo statico [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) per caricare i font da quelle cartelle.  
3. Carica e renderizza/esporta la presentazione.  
4. Chiama [FontsLoader.ClearCache](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/clearcache/) per cancellare la cache dei font.

Esempio di codice seguente che dimostra il processo di caricamento dei font:

```cs
// Definisci le cartelle che contengono file di font personalizzati.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) usando i font caricati.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Cancella la cache dei font dopo che il lavoro è terminato.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Nota" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font. I font vengono inizializzati in questo ordine:

1. Il percorso predefinito dei font del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni Cartelle dei Font Personalizzati**
Aspose.Slides fornisce il metodo [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei font di sistema.

Questo codice C# mostra come utilizzare [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// Questa riga restituisce le cartelle controllate per i file di font.
// Quelle sono cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specifica Font Personalizzati Utilizzati con una Presentazione**
Aspose.Slides fornisce la proprietà [DocumentLevelFontSources](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/documentlevelfontsources/) per consentire di specificare i font esterni che verranno utilizzati con la presentazione.

Questo codice C# mostra come utilizzare la proprietà [DocumentLevelFontSources](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
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

## **Gestisci Font Esterne**

Aspose.Slides fornisce il metodo [LoadExternalFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) per consentire di caricare font esterni da dati binari.

Questo codice C# dimostra il processo di caricamento del font da array di byte: 

```c#
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

## **Domande Frequenti**

**I font personalizzati influiscono sull'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I font collegati vengono utilizzati dal renderer in tutti i formati di esportazione.

**I font personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un font per il rendering non è lo stesso che incorporarlo in un PPTX. Se è necessario che il font sia incluso nel file della presentazione, è necessario utilizzare esplicitamente le [funzionalità di incorporamento](/slides/it/net/embedded-font/).

**Posso controllare il comportamento di fallback quando un font personalizzato manca di alcuni glifi?**

Sì. Configura la [sostituzione dei font](/slides/it/net/font-substitution/), le [regole di sostituzione](/slides/it/net/font-replacement/) e i [set di fallback](/slides/it/net/fallback-font/) per definire esattamente quale font utilizzare quando il glifo richiesto è assente.

**Posso utilizzare i font in contenitori Linux/Docker senza installarli a livello di sistema?**

Sì. Puntare alle proprie cartelle dei font o caricare i font da array di byte. Questo elimina qualsiasi dipendenza dalle directory dei font di sistema nell'immagine del contenitore.

**E per quanto riguarda le licenze—posso incorporare qualsiasi font personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. Consulta sempre l'EULA del font prima di distribuire i risultati.