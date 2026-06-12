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
description: "Apri presentazioni PowerPoint (.pptx, .ppt) e OpenDocument (.odp) in modo semplice con Aspose.Slides per .NET—veloce, affidabile, completa."
---
## **Introduzione**

Oltre a creare presentazioni PowerPoint da zero, Aspose.Slides consente anche di aprire presentazioni esistenti. Dopo aver caricato una presentazione, è possibile recuperare informazioni al riguardo, modificare il contenuto delle diapositive, aggiungere nuove diapositive, rimuovere quelle esistenti e molto altro.

## **Aprire presentazioni**

Per aprire una presentazione esistente, istanzia la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) e passa il percorso del file al suo costruttore.

Il seguente esempio C# mostra come aprire una presentazione e ottenere il numero di diapositive:

```cs
// Istanzia la classe Presentation e passa un percorso di file al suo costruttore.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Stampa il numero totale di diapositive nella presentazione.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Aprire presentazioni protette da password**

Quando è necessario aprire una presentazione protetta da password, passa la password tramite la proprietà [Password](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/password/) della classe [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/) per decrittarla e caricarla. Il seguente codice C# dimostra questa operazione:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Esegui operazioni sulla presentazione decrittata.
}
```

## **Aprire presentazioni di grandi dimensioni**

Aspose.Slides fornisce opzioni—in particolare la proprietà [BlobManagementOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/blobmanagementoptions/) nella classe [LoadOptions](https://reference.aspose.com/slides/it/net/aspose.slides/loadoptions/)—per aiutarti a caricare presentazioni di grandi dimensioni.

Il seguente codice C# dimostra come caricare una presentazione di grandi dimensioni (ad esempio, 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Scegli il comportamento KeepLocked—il file della presentazione resterà bloccato per tutta la durata di 
        // l'istanza Presentation, ma non è necessario caricarlo in memoria né copiarlo in un file temporaneo.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // La presentazione di grandi dimensioni è stata caricata e può essere usata, mentre il consumo di memoria rimane basso.

    // Apporta modifiche alla presentazione.
    presentation.Slides[0].Name = "Large presentation";

    // Salva la presentazione in un altro file. Il consumo di memoria rimane basso durante questa operazione.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Non farlo! Verrà sollevata un'eccezione I/O perché il file è bloccato fino a quando l'oggetto Presentation non viene eliminato.
    File.Delete(filePath);
}

// È corretto farlo qui. Il file sorgente non è più bloccato dall'oggetto Presentation.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Per aggirare alcune limitazioni quando si lavora con i flussi, Aspose.Slides potrebbe copiare il contenuto di un flusso. Caricare una presentazione di grandi dimensioni da un flusso comporta la copia della presentazione e può rallentare il caricamento. Pertanto, quando è necessario caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione anziché un flusso.

Quando si crea una presentazione che contiene oggetti di grandi dimensioni (video, audio, immagini ad alta risoluzione, ecc.), è possibile utilizzare la [gestione BLOB](/slides/it/net/manage-blob/) per ridurre il consumo di memoria.
{{%/alert %}}

## **Controllare le risorse esterne**

Aspose.Slides fornisce l'interfaccia [IResourceLoadingCallback](https://reference.aspose.com/slides/it/net/aspose.slides/iresourceloadingcallback/) che consente di gestire le risorse esterne. Il seguente codice C# mostra come utilizzare l'interfaccia `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Carica un'immagine sostitutiva.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Imposta un URL sostitutivo.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Salta tutte le altre immagini.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione PowerPoint può contenere i seguenti tipi di oggetti binari incorporati:

- Progetto VBA (accessibile tramite [IPresentation.VbaProject](https://reference.aspose.com/slides/it/net/aspose.slides/ipresentation/vbaproject/));
- Dati incorporati di oggetti OLE (accessibili tramite [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/it/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Dati binari di controlli ActiveX (accessibili tramite [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/it/net/aspose.slides/icontrol/activexcontrolbinary/)).

Utilizzando la proprietà [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), è possibile caricare una presentazione senza alcun oggetto binario incorporato.

Questa proprietà è utile per rimuovere contenuti binari potenzialmente dannosi. Il seguente codice C# dimostra come caricare una presentazione senza alcun contenuto binario incorporato:

```cs
LoadOptions loadOptions = new LoadOptions()
{
    DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Esegui operazioni sulla presentazione.
}
```

## **FAQ**

**Come posso capire se un file è danneggiato e non può essere aperto?**

Durante il caricamento verrà generata un'eccezione di validazione/parsing del formato. Questi errori spesso indicano una struttura ZIP non valida o record PowerPoint danneggiati.

**Cosa succede se i font richiesti mancano durante l'apertura?**

Il file si aprirà, ma successivamente la [renderizzazione/esportazione](/slides/it/net/convert-presentation/) potrebbe sostituire i font. [Configura le sostituzioni dei font](/slides/it/net/font-substitution/) o [aggiungi i font richiesti](/slides/it/net/custom-font/) all'ambiente di runtime.

**Cosa succede ai media incorporati (video/audio) durante l'apertura?**

Diventano disponibili come risorse della presentazione. Se i media sono referenziati tramite percorsi esterni, assicurati che tali percorsi siano accessibili nel tuo ambiente; altrimenti la [renderizzazione/esportazione](/slides/it/net/convert-presentation/) potrebbe omettere i media.