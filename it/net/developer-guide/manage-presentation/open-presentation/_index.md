---
title: Aprire presentazioni in .NET
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/net/open-presentation/
keywords:
- aprire PowerPoint
- aprire presentazione
- aprire PPTX
- aprire PPT
- aprire ODP
- caricare presentazione
- caricare PPTX
- caricare PPT
- caricare ODP
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

[Aspose.Slides for .NET](https://products.aspose.com/slides/it/net/) può caricare presentazioni PowerPoint e OpenDocument da file e flussi. Dopo che una presentazione è stata caricata, è possibile ispezionarne la struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, mantenere i grandi oggetti binari fuori dalla memoria gestita, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire le presentazioni**

Per aprire una presentazione esistente, passi il percorso del file al costruttore [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Disponi della presentazione dopo l'uso affinché i handle dei file, i dati temporanei e le altre risorse vengano rilasciati tempestivamente.

Il seguente esempio C# mostra come aprire una presentazione e ottenere il numero di diapositive:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Aprire presentazioni protette da password**

Una password di apertura cripta il contenuto della presentazione. Per caricare l'intera presentazione, assegna la password corretta a [LoadOptions.Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/) e passa le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/). Il caricamento fallisce quando la password è assente o errata.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Per la rilevazione, la validazione e i flussi di lavoro di crittografia delle password, vedi [Password-Protect Presentations](/slides/it/net/password-protected-presentation/). Se una presentazione crittata è stata salvata deliberatamente con proprietà di documento pubbliche, tali proprietà possono essere lette senza password; vedi [Manage Presentation Properties](/slides/it/net/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/blobmanagementoptions/) controlla come Aspose.Slides gestisce oggetti binari di grandi dimensioni come immagini, audio e video. Puoi mantenere il file sorgente bloccato, consentire file temporanei e limitare la quantità di dati BLOB trattenuti in memoria.

Il seguente codice C# dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

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

{{% alert color="info" title="Nota" %}}
Con `PresentationLockingBehavior.KeepLocked`, il file sorgente rimane bloccato fino a quando l'oggetto `Presentation` non viene eliminato. Non spostare, sovrascrivere o eliminare il file sorgente mentre quell'oggetto è attivo.

Aspose.Slides può copiare i contenuti di un flusso di input durante il caricamento. Per presentazioni di grandi dimensioni, un percorso di file è quindi generalmente più efficiente di un flusso. Consulta [Manage BLOBs](/slides/it/net/manage-blob/) per ulteriori opzioni di archiviazione e gestione della memoria.
{{% /alert %}}

## **Controllare le risorse esterne**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/resourceloadingcallback/) accetta un'implementazione di [IResourceLoadingCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iresourceloadingcallback/). Il callback può fornire dati sostitutivi, reindirizzare una risorsa, utilizzare il loader predefinito o saltare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o archiviazione specifiche dell'applicazione.

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

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non desidera mantenere. Esempi includono:

- progetti VBA, disponibili tramite [IPresentation.VbaProject](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/vbaproject/);
- dati OLE incorporati, disponibili tramite [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/it/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- dati di controlli ActiveX, disponibili tramite [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/it/net/aspose.slides/icontrol/activexcontrolbinary/).

Imposta [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) su `true` per rimuovere questi dati binari durante il caricamento. Salva la presentazione caricata per conservare il risultato sanificato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non è un sistema completo di rilevamento malware o di sanificazione dei contenuti.

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

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestisci quel tipo di errore separatamente da quello di password errata in modo che l'applicazione possa segnalare la causa con precisione.

**Cosa succede se mancano i font richiesti?**

La presentazione può comunque essere caricata, ma il rendering e l'esportazione potrebbero sostituire i font. Puoi [configurare la sostituzione dei font](/slides/it/net/font-substitution/) o [fornire font personalizzati](/slides/it/net/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i media incorporati?**

Audio e video incorporati diventano disponibili tramite il modello a oggetti della presentazione. Le risorse esterne vengono risolte secondo il comportamento configurato per il caricamento delle risorse e potrebbero non essere disponibili se le loro posizioni non sono accessibili.