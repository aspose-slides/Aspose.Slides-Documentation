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
- gestione font
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

Aspose.Slides consente di utilizzare font personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i font da cartelle personalizzate, fornire font per una presentazione specifica tramite font a livello di documento, oppure caricare font esterni direttamente da dati binari.

I font caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo aiuta a mantenere l'output della presentazione coerente su ambienti diversi. L'articolo spiega anche come ispezionare le cartelle dei font utilizzate da Aspose.Slides e come svuotare la cache dei font dopo aver lavorato con font esterni.

La registrazione di font personalizzati per il rendering è distinta dall'incorporamento dei font in un file PPTX. Se un font deve essere memorizzato all'interno della presentazione stessa, utilizzare esplicitamente le funzionalità di incorporamento dei font.

{{% alert color="primary" %}} 

Aspose Slides consente di caricare questi font utilizzando il metodo [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/):

* Font TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Font OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica font personalizzati**

Aspose.Slides consente di caricare i font utilizzati in una presentazione senza installarli sul sistema. Questo influenza l'output di esportazione, come PDF, immagini e altri formati supportati, in modo che i documenti risultanti appaiano coerenti su tutti gli ambienti. I font vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei font.  
2. Chiamare il metodo statico [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) per caricare i font da tali cartelle.  
3. Caricare e renderizzare/esportare la presentazione.  
4. Chiamare [FontsLoader.ClearCache](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/clearcache/) per svuotare la cache dei font.

Il seguente esempio di codice dimostra il processo di caricamento dei font:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definisci le cartelle che contengono i file dei font personalizzati.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Carica i font personalizzati dalle cartelle specificate.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizza/esporta la presentazione (ad es., in PDF, immagini o altri formati) utilizzando i font caricati.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Svuota la cache dei font dopo che il lavoro è terminato.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei font, ma non modifica l'ordine di inizializzazione dei font. I font sono inizializzati in questo ordine:

1. Il percorso dei font predefinito del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartelle dei font personalizzati**

Aspose.Slides fornisce il metodo [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei font. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle dei font di sistema.

Questo codice C# mostra come utilizzare [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Questa riga restituisce le cartelle controllate per i file dei font.
// Sono cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei font di sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specificare i font personalizzati usati con una presentazione**

Aspose.Slides fornisce la proprietà [DocumentLevelFontSources](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/documentlevelfontsources/) per consentire di specificare i font esterni che verranno utilizzati con la presentazione.

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

## **Gestire i font esternamente**

Aspose.Slides fornisce il metodo [LoadExternalFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) per consentire di caricare font esterni da dati binari.

Questo codice C# dimostra il processo di caricamento del font da array di byte:

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

**I font personalizzati influenzano l'esportazione in tutti i formati (PDF, PNG, SVG, HTML)?**

Sì. I font collegati vengono utilizzati dal renderizzatore in tutti i formati di esportazione.

**I font personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un font per il rendering non è la stessa cosa dell'incorporarlo in un PPTX. Se è necessario che il font sia presente all'interno del file di presentazione, è necessario utilizzare esplicitamente le [funzioni di incorporamento](/slides/it/net/embedded-font/).

**Posso controllare il comportamento di fallback quando un font personalizzato manca di alcuni glifi?**

Sì. Configura la [sostituzione dei font](/slides/it/net/font-substitution/), le [regole di sostituzione](/slides/it/net/font-replacement/) e i [set di fallback](/slides/it/net/fallback-font/) per definire esattamente quale font utilizzare quando il glifo richiesto è mancante.

**Posso usare i font in container Linux/Docker senza installarli a livello di sistema?**

Sì. Indica le tue cartelle dei font o carica i font da array di byte. Questo elimina ogni dipendenza dalle directory dei font di sistema nell'immagine del container.

> **Nota per Linux/Docker**: Quando si chiama `FontsLoader.LoadExternalFonts`, assicurarsi che ogni voce nell'array `directories` contenga un percorso non vuoto a una directory esistente. Se una variabile d'ambiente usata per costruire un percorso dei font è indefinita o vuota, Aspose.Slides potrebbe tentare di risolvere il valore vuoto come percorso completo, generando `System.ArgumentException`.

**E per quanto riguarda le licenze—posso incorporare qualsiasi font personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei font. I termini variano; alcune licenze vietano l'incorporamento o l'uso commerciale. È sempre consigliabile verificare l'EULA del font prima di distribuire i risultati.