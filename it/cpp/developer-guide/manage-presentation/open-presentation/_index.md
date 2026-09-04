---
title: Aprire presentazioni in C++
linktitle: Apri presentazione
type: docs
weight: 20
url: /it/cpp/open-presentation/
keywords:
- apri PowerPoint
- apri OpenDocument
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
- C++
- Aspose.Slides
description: "Scopri come aprire presentazioni PowerPoint e OpenDocument in C++, fornire password di apertura, controllare il caricamento delle risorse e ridurre l'uso della memoria con Aspose.Slides per C++."
---
## **Introduzione**

[Aspose.Slides for C++](https://products.aspose.com/slides/it/cpp/) può caricare presentazioni PowerPoint e OpenDocument da file e stream. Dopo che una presentazione è stata caricata, è possibile ispezionarne la struttura, modificare le diapositive, gestire le risorse e salvarla nel formato originale o in un altro formato supportato.

Il comportamento di caricamento può essere personalizzato tramite la classe [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/). Ad esempio, è possibile fornire una password di apertura, tenere gli oggetti binari di grandi dimensioni fuori dalla memoria, controllare le risorse esterne o omettere i dati binari incorporati.

## **Aprire presentazioni**

Per aprire una presentazione esistente, passare il percorso file al costruttore [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Disporre della presentazione dopo l'uso in modo che handle di file, dati temporanei e altre risorse vengano rilasciati prontamente.

Il seguente esempio C++ mostra come aprire una presentazione e ottenere il numero di diapositive:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Aprire presentazioni protette da password**

Una password di apertura cripta il contenuto della presentazione. Per caricare l'intera presentazione, passare la password corretta a [LoadOptions::set_Password](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_password/) e passare le opzioni al costruttore [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Il caricamento fallisce se la password è mancante o errata.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Per la rilevazione, la validazione e i flussi di lavoro di crittografia delle password, vedere [Password-Protect Presentations](/slides/it/cpp/password-protected-presentation/). Se una presentazione crittografata è stata salvata deliberatamente con proprietà di documento pubbliche, tali proprietà possono essere lette senza password; vedere [Manage Presentation Properties](/slides/it/cpp/presentation-properties/).

## **Aprire presentazioni di grandi dimensioni**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) controlla come Aspose.Slides gestisce gli oggetti binari di grandi dimensioni, come immagini, audio e video. È possibile mantenere il file sorgente bloccato, consentire file temporanei e limitare la quantità di dati BLOB mantenuti in memoria.

Il seguente codice C++ dimostra il caricamento di una presentazione di grandi dimensioni (ad esempio, 2 GB):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Nota" %}}
Con `PresentationLockingBehavior::KeepLocked`, il file sorgente rimane bloccato fino a quando l'oggetto `Presentation` non viene disposto. Non spostare, sovrascrivere o eliminare il file sorgente mentre quell'oggetto è in vita.

Aspose.Slides potrebbe copiare il contenuto di uno stream di input durante il caricamento. Per presentazioni di grandi dimensioni, un percorso file è generalmente più efficiente di uno stream. Vedere [Manage BLOBs](/slides/it/cpp/manage-blob/) per ulteriori opzioni di archiviazione e gestione della memoria.
{{% /alert %}}

## **Controllare le risorse esterne**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accetta un'implementazione di [IResourceLoadingCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iresourceloadingcallback/). Il callback può fornire dati sostitutivi, reindirizzare una risorsa, utilizzare il loader predefinito o ignorare la risorsa. Questo è utile quando le presentazioni contengono immagini esterne che devono essere risolte secondo regole di sicurezza o storage specifiche dell'applicazione.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Caricare presentazioni senza oggetti binari incorporati**

Una presentazione può contenere dati binari incorporati che un'applicazione non necessita o non vuole conservare. Esempi includono:

- progetti VBA, disponibili tramite [IPresentation::get_VbaProject](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_vbaproject/);
- dati OLE incorporati, disponibili tramite [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/it/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- dati di controlli ActiveX, disponibili tramite [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/it/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Passare `true` a [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) per rimuovere questi dati binari durante il caricamento. Salvare la presentazione caricata per persistere il risultato sanitizzato.

Questa opzione riduce l'esposizione a payload incorporati indesiderati, ma non costituisce un sistema completo di rilevamento malware o di sanitizzazione del contenuto.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Domande frequenti**

**Come posso capire se un file è corrotto e non può essere aperto?**

Aspose.Slides genera un'eccezione di parsing o di formato durante il caricamento. Gestire questo fallimento separatamente da un errore di password errata in modo che l'applicazione possa segnalare la causa con precisione.

**Cosa succede se i caratteri richiesti mancano?**

La presentazione può comunque essere caricata, ma il rendering e l'esportazione potrebbero sostituire i caratteri. È possibile [configurare la sostituzione dei caratteri](/slides/it/cpp/font-substitution/) o [fornire caratteri personalizzati](/slides/it/cpp/custom-font/) per rendere l'output più prevedibile.

**Il caricamento di una presentazione carica anche i suoi media incorporati?**

Audio e video incorporati diventano disponibili tramite il modello a oggetti della presentazione. Le risorse esterne sono risolte secondo il comportamento di caricamento delle risorse configurato e potrebbero non essere disponibili se le loro posizioni non possono essere raggiunte.