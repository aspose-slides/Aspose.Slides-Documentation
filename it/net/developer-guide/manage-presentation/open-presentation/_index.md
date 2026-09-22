---
title: Aprire presentazioni in .NET
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/net/open-presentation/
keywords:
- apri PowerPoint
- apri presentazione
- apri PPTX
- apri PPT
- apri ODP
- carica presentazione
- carica PPTX
- carica PPT
- carica ODP
- presentazione protetta
- presentazione di grandi dimensioni
- risorsa esterna
- oggetto binario
- .NET
- C#
- Aspose.Slides
description: "Scopri come aprire presentazioni PowerPoint e OpenDocument in C#, fornire password di apertura, controllare il caricamento delle risorse e ridurre l'uso della memoria con Aspose.Slides per .NET."
---
## **Introduzione**

[Aspose.Slides for .NET](https://products.aspose.com/slides/it/net/) può caricare presentazioni PowerPoint e OpenDocument da file e stream. Dopo che una presentazione è stata caricata, è possibile ispezionarne la struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari fuori dalla memoria gestita, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire presentazioni**

Dopo aver caricato un file o uno stream, è possibile [determinare il formato originale della presentazione](/slides/it/net/detect-presentation-source-format/) per scegliere come l'applicazione la elabora.

Per aprire una presentazione esistente, passare il percorso del file al costruttore [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Disporre della presentazione dopo l'uso in modo che i handle dei file, i dati temporanei e le altre risorse vengano rilasciati prontamente.

Il seguente esempio C# mostra come aprire una presentazione e ottenere il conteggio delle diapositive:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Aprire presentazioni protette da password**

Una password di apertura crittografa il contenuto della presentazione. Per caricare l'intera presentazione, assegnare la password corretta a [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/) e passare le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Il caricamento fallisce se la password è mancante o errata.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Per rilevamento password, convalida e flussi di lavoro di crittografia, consultare [Password-Protect Presentations](/slides/it/net/password-protected-presentation/). Se una presentazione crittografata è stata salvata deliberatamente con proprietà di documento pubbliche, tali proprietà possono essere lette senza password; vedere [Manage Presentation Properties](/slides/it/net/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/blobmanagementoptions/) controlla come Aspose.Slides gestisce i BLOB (Binary Large Objects) come immagini, audio e video. È possibile mantenere il file sorgente bloccato, consentire file temporanei e limitare la quantità di dati BLOB conservata in memoria.

Il seguente codice C# dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Con `PresentationLockingBehavior.KeepLocked`, il file sorgente rimane bloccato fino a quando l'oggetto `Presentation` non viene smaltito. Non spostare, sovrascrivere o eliminare il file sorgente mentre quell'oggetto è in vita.
{{% /alert %}}

Aspose.Slides potrebbe copiare il contenuto di uno stream di input durante il caricamento. Per presentazioni di grandi dimensioni, un percorso file è quindi generalmente più efficiente di uno stream. Vedere [Manage BLOBs](/slides/it/net/manage-blob/) per ulteriori opzioni di archiviazione e gestione della memoria.

## **Controllare risorse esterne**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/resourceloadingcallback/) accetta un'implementazione di [IResourceLoadingCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iresourceloadingcallback/). Il callback può fornire dati di sostituzione, reindirizzare una risorsa, utilizzare il caricatore predefinito o saltare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o di archiviazione specifiche dell'applicazione.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole conservare. Esempi includono:

- Progetti VBA, disponibili tramite [IPresentation.VbaProject](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/vbaproject/);
- Dati OLE incorporati, disponibili tramite [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/it/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- Dati di controllo ActiveX, disponibili tramite [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/it/net/aspose.slides/icontrol/activexcontrolbinary/).

Impostare [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) su `true` per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per mantenere il risultato sanificato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanitizzazione dei contenuti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Come posso capire se un file è corrotto e non può essere aperto?**

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestire tale errore separatamente da un errore di password errata in modo che l'applicazione possa segnalare la causa in modo accurato.

**Cosa succede se i font richiesti sono mancanti?**

La presentazione può comunque essere caricata, ma il rendering e l'esportazione potrebbero sostituire i font. È possibile [configurare la sostituzione dei font](/slides/it/net/font-substitution/) o [fornire font personalizzati](/slides/it/net/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

L'audio e il video incorporati diventano disponibili tramite il modello a oggetti della presentazione. Le risorse esterne vengono risolte secondo il comportamento di caricamento delle risorse configurato e potrebbero non essere disponibili se le loro posizioni non sono accessibili.