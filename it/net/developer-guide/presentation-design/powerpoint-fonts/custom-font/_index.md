---
title: Personalizza i caratteri di PowerPoint in .NET
linktitle: Carattere personalizzato
type: docs
weight: 20
url: /it/net/custom-font/
keywords:
- carattere
- carattere personalizzato
- carattere esterno
- caricare carattere
- gestire i caratteri
- cartella dei caratteri
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Personalizza i caratteri nelle diapositive PowerPoint con Aspose.Slides per .NET per mantenere le tue presentazioni nitide e coerenti su qualsiasi dispositivo."
---
## **Panoramica**

Aspose.Slides consente di utilizzare caratteri personalizzati nelle presentazioni senza installarli sul sistema operativo. È possibile caricare i caratteri da cartelle personalizzate, fornire caratteri per una specifica presentazione tramite font a livello di documento, oppure caricare caratteri esterni direttamente da dati binari.

I caratteri caricati vengono utilizzati quando una presentazione viene renderizzata o esportata, ad esempio in PDF, immagini e altri formati supportati. Questo garantisce che l'output della presentazione rimanga coerente in ambienti diversi. L’articolo spiega anche come ispezionare le cartelle dei caratteri usate da Aspose.Slides e come svuotare la cache dei caratteri dopo aver lavorato con caratteri esterni.

La registrazione di caratteri personalizzati per il rendering è separata dall’incorporamento dei caratteri in un file PPTX. Se un carattere deve essere memorizzato all’interno della presentazione, utilizzare esplicitamente le funzionalità di incorporamento dei caratteri.

{{% alert color="info" %}} 

Aspose Slides consente di caricare questi caratteri utilizzando il metodo [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) e TrueType Collection (.ttc). Vedi [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf). Vedi [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Carica caratteri personalizzati**

Aspose.Slides consente di caricare i caratteri usati in una presentazione senza installarli sul sistema. Questo influisce sull'output di esportazione—come PDF, immagini e altri formati supportati—così i documenti risultanti appaiono coerenti tra gli ambienti. I caratteri vengono caricati da directory personalizzate.

1. Specificare una o più cartelle che contengono i file dei caratteri.  
2. Chiamare il metodo statico [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) per caricare i caratteri da quelle cartelle.  
3. Caricare e renderizzare/esportare la presentazione.  
4. Chiamare [FontsLoader.ClearCache](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/clearcache/) per svuotare la cache dei caratteri.

Il seguente esempio di codice dimostra il processo di caricamento dei caratteri:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definisci le cartelle che contengono i file dei caratteri personalizzati.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Carica i caratteri personalizzati dalle cartelle specificate.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizza/esporta la presentazione (ad esempio in PDF, immagini o altri formati) usando i caratteri caricati.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Svuota la cache dei caratteri dopo che il lavoro è terminato.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Nota" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfonts/) aggiunge cartelle aggiuntive ai percorsi di ricerca dei caratteri, ma non modifica l’ordine di inizializzazione dei caratteri.  
I caratteri sono inizializzati in questo ordine:

1. Il percorso predefinito dei caratteri del sistema operativo.  
1. I percorsi caricati tramite [FontsLoader](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Ottieni cartelle dei caratteri personalizzati**
Aspose.Slides fornisce il metodo [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/) per consentire di trovare le cartelle dei caratteri. Questo metodo restituisce le cartelle aggiunte tramite il metodo `LoadExternalFonts` e le cartelle di sistema dei caratteri.

Questo codice C# mostra come utilizzare [GetFontFolders](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Questa riga restituisce le cartelle controllate per i file dei caratteri.
// Queste sono le cartelle aggiunte tramite il metodo LoadExternalFonts e le cartelle dei caratteri di sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Specifica i caratteri personalizzati usati con una presentazione**
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
    // Lavorare con la presentazione
    // CustomFont1, CustomFont2 e i caratteri dalle cartelle assets\fonts & global\fonts e le loro sottocartelle sono disponibili per la presentazione
}
```

## **Gestisci i caratteri esternamente**

Aspose.Slides fornisce il metodo [LoadExternalFont](https://reference.aspose.com/slides/it/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) per consentire di caricare caratteri esterni da dati binari.

Questo codice C# dimostra il processo di caricamento dei caratteri da un array di byte: 

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

Sì. I caratteri collegati vengono utilizzati dal renderer per tutti i formati di esportazione.

**I caratteri personalizzati vengono incorporati automaticamente nel PPTX risultante?**

No. Registrare un carattere per il rendering non è la stessa cosa dell’incorporamento in un PPTX. Se è necessario che il carattere sia contenuto nel file della presentazione, occorre utilizzare le esplicite [funzionalità di incorporamento](/slides/it/net/embedded-font/).

**Posso controllare il comportamento di fallback quando un carattere personalizzato manca di alcuni glifi?**

Sì. Configura [sostituzione dei caratteri](/slides/it/net/font-substitution/), [regole di sostituzione](/slides/it/net/font-replacement/) e [insiemi di fallback](/slides/it/net/fallback-font/) per definire esattamente quale carattere utilizzare quando il glifo richiesto è assente.

**Posso usare i caratteri in contenitori Linux/Docker senza installarli a livello di sistema?**

Sì. Puntare alle proprie cartelle dei caratteri o caricare i caratteri da array di byte. Questo elimina qualsiasi dipendenza dalle directory di sistema dei caratteri nell’immagine del contenitore.

> **Nota per Linux/Docker**: Quando si chiama `FontsLoader.LoadExternalFonts`, assicurarsi che ogni voce nell’array `directories` contenga un percorso non vuoto a una directory esistente. Se una variabile d’ambiente usata per costruire un percorso dei caratteri è indefinita o vuota, Aspose.Slides potrebbe tentare di risolvere il valore vuoto come percorso completo, risultando in `System.ArgumentException`.

**Cosa dice la licenza—posso incorporare qualsiasi carattere personalizzato senza restrizioni?**

Sei responsabile della conformità alle licenze dei caratteri. I termini variano; alcune licenze vietano l’incorporamento o l’uso commerciale. Verifica sempre la EULA del carattere prima di distribuire gli output.