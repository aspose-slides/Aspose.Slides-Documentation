---
title: Aprire presentazioni in C++
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/cpp/open-presentation/
keywords:
- aprire PowerPoint
- aprire OpenDocument
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
- C++
- Aspose.Slides
description: "Apri le presentazioni PowerPoint (.pptx, .ppt) e OpenDocument (.odp) senza sforzo con Aspose.Slides per C++—veloce, affidabile, completamente funzionale."
---
## **Introduzione**

Oltre a creare presentazioni PowerPoint da zero, Aspose.Slides consente anche di aprire presentazioni esistenti. Dopo aver caricato una presentazione, è possibile recuperare informazioni su di essa, modificare il contenuto delle diapositive, aggiungere nuove diapositive, rimuovere quelle esistenti e altro ancora.

## **Aprire presentazioni**

Per aprire una presentazione esistente, istanziare la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e passare il percorso del file al suo costruttore.

Il seguente esempio C++ mostra come aprire una presentazione e ottenere il conteggio delle diapositive:

```cpp
// Instanzia la classe Presentation e passa un percorso file al suo costruttore.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Stampa il numero totale di diapositive nella presentazione.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Aprire presentazioni protette da password**

Quando è necessario aprire una presentazione protetta da password, passare la password tramite il metodo [set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/) della classe [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/) per decifrarla e caricarla. Il seguente codice C++ dimostra quest'operazione:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Esegui operazioni sulla presentazione decrittata.

presentation->Dispose();
```

## **Aprire presentazioni di grandi dimensioni**

Aspose.Slides fornisce opzioni—in particolare il metodo [get_BlobManagementOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) nella classe [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/)—per aiutare a caricare presentazioni di grandi dimensioni.

Il seguente codice C++ dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Scegli il comportamento KeepLocked—il file della presentazione rimarrà bloccato per tutta la durata di
// l'istanza Presentation, ma non è necessario caricarlo in memoria o copiarlo in un file temporaneo.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// La presentazione di grandi dimensioni è stata caricata e può essere usata, mantenendo un consumo di memoria basso.

// Apporta modifiche alla presentazione.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// Salva la presentazione in un altro file. Il consumo di memoria rimane basso durante questa operazione.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Non farlo! Verrà generata un'eccezione I/O perché il file è bloccato fino a quando l'oggetto presentation non viene eliminato.
File::Delete(filePath);

presentation->Dispose();

// Qui va bene farlo. Il file di origine non è più bloccato dall'oggetto presentation.
File::Delete(filePath);
```

{{% alert color="info" title="Info" %}}

Per aggirare alcune limitazioni quando si lavora con gli stream, Aspose.Slides potrebbe copiare il contenuto di uno stream. Caricare una presentazione di grandi dimensioni da uno stream provoca la copia della presentazione e può rallentare il caricamento. Pertanto, quando è necessario caricare una presentazione di grandi dimensioni, consigliamo vivamente di utilizzare il percorso del file della presentazione anziché uno stream.

Quando si crea una presentazione che contiene oggetti di grandi dimensioni (video, audio, immagini ad alta risoluzione, ecc.), è possibile utilizzare la [gestione BLOB](/slides/it/cpp/manage-blob/) per ridurre il consumo di memoria.

{{%/alert %}}

## **Controllare le risorse esterne**

Aspose.Slides fornisce l'interfaccia [IResourceLoadingCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iresourceloadingcallback/) che consente di gestire le risorse esterne. Il seguente codice C++ mostra come utilizzare l'interfaccia `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Carica un'immagine sostitutiva.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Imposta un URL sostitutivo.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Ignora tutte le altre immagini.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione PowerPoint può contenere i seguenti tipi di oggetti binari incorporati:

- Progetto VBA (accessibile tramite [IPresentation::get_VbaProject](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Dati incorporati di oggetti OLE (accessibile tramite [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Dati binari di controlli ActiveX (accessibile tramite [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/it/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Utilizzando il metodo [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) è possibile caricare una presentazione senza alcun oggetto binario incorporato.

Questo metodo è utile per rimuovere contenuti binari potenzialmente dannosi. Il seguente codice C++ dimostra come caricare una presentazione senza alcun contenuto binario incorporato:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Esegui operazioni sulla presentazione.

presentation->Dispose();
```

## **FAQ**

**Come posso capire se un file è corrotto e non può essere aperto?**

Durante il caricamento si genera un'eccezione di convalida del parsing/formato. Tali errori spesso indicano una struttura ZIP non valida o record PowerPoint danneggiati.

**Cosa succede se mancano i font richiesti durante l'apertura?**

Il file si apre, ma successivamente la [renderizzazione/esportazione](/slides/it/cpp/convert-presentation/) potrebbe sostituire i font. [Configura le sostituzioni dei font](/slides/it/cpp/font-substitution/) o [aggiungi i font richiesti](/slides/it/cpp/custom-font/) all'ambiente di runtime.

**E i media incorporati (video/audio) durante l'apertura?**

Diventano disponibili come risorse della presentazione. Se i media sono riferiti tramite percorsi esterni, assicurati che tali percorsi siano accessibili nel tuo ambiente; altrimenti la [renderizzazione/esportazione](/slides/it/cpp/convert-presentation/) potrebbe omettere i media.