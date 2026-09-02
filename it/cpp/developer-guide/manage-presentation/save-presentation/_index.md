---
title: Salva presentazioni in C++
linktitle: Salva presentazione
type: docs
weight: 80
url: /it/cpp/save-presentation/
keywords:
- salva PowerPoint
- salva OpenDocument
- salva presentazione
- salva diapositiva
- salva PPT
- salva PPTX
- salva ODP
- presentazione su file
- presentazione su stream
- tipo di visualizzazione predefinito
- Formato Strict Office Open XML
- modalità Zip64
- aggiornamento miniatura
- avanzamento del salvataggio
- C++
- Aspose.Slides
description: "Scopri come salvare presentazioni in C++ usando Aspose.Slides—esporta in PowerPoint o OpenDocument mantenendo layout, font ed effetti."
---
## **Panoramica**

[L'Open Presentations in C++](/slides/it/cpp/open-presentation/) descrive come utilizzare la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) per aprire una presentazione. Questo articolo spiega come creare e salvare presentazioni. La classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) contiene il contenuto di una presentazione. Che tu stia creando una presentazione da zero o modificando una esistente, vorrai salvarla al termine. Con Aspose.Slides per C++, è possibile salvare in un **file** o in uno **stream**. Questo articolo illustra i diversi modi per salvare una presentazione.

## **Salva presentazioni su file**

Salva una presentazione su un file chiamando il metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Passa il nome del file e il formato di salvataggio al metodo. L'esempio seguente mostra come salvare una presentazione con Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Esegui del lavoro qui...

// Salva la presentazione su un file.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Salva presentazioni su stream**

Puoi salvare una presentazione su uno stream passando uno stream di output al metodo `Save` della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/). Una presentazione può essere scritta su molti tipi di stream. Nell'esempio seguente, creiamo una nuova presentazione e la salviamo su uno stream di file.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Istanziare la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

Aspose.Slides consente di impostare la visualizzazione iniziale che PowerPoint utilizza quando la presentazione generata viene aperta tramite la classe [ViewProperties](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/). Usa il metodo [set_LastView](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/set_lastview/) con un valore dell'enumerazione [ViewType](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Salva presentazioni nel formato Strict Office Open XML**

Aspose.Slides consente di salvare una presentazione nel formato Strict Office Open XML. Utilizza la classe [PptxOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/) e imposta la sua proprietà conformance durante il salvataggio. Se imposti `Conformance.Iso29500_2008_Strict`, il file di output viene salvato nel formato Strict Office Open XML.

L'esempio seguente crea una presentazione e la salva nel formato Strict Office Open XML.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Istanziare la classe Presentation che rappresenta un file di presentazione.
auto presentation = MakeObject<Presentation>();

// Salvare la presentazione nel formato Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salva presentazioni nel formato Office Open XML in modalità Zip64**

Un file Office Open XML è un archivio ZIP che impone limiti di 4 GB (2^32 byte) sulla dimensione non compressa di qualsiasi file, sulla dimensione compressa di qualsiasi file e sulla dimensione totale dell'archivio, e limita anche l'archivio a 65.535 (2^16‑1) file. Le estensioni del formato ZIP64 aumentano questi limiti a 2^64.

Il metodo [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) consente di scegliere quando utilizzare le estensioni del formato ZIP64 durante il salvataggio di un file Office Open XML.

Questo metodo può essere usato con le seguenti modalità:

- `IfNecessary` usa le estensioni del formato ZIP64 solo se la presentazione supera le limitazioni sopra. È la modalità predefinita.
- `Never` non usa mai le estensioni ZIP64.
- `Always` usa sempre le estensioni ZIP64.

Il codice seguente dimostra come salvare una presentazione come file PPTX con le estensioni del formato ZIP64 abilitate:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Quando salvi con `Zip64Mode.Never`, viene generata un'eccezione [PptxException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxexception/) se la presentazione non può essere salvata nel formato ZIP32.
{{% /alert %}}

## **Salva presentazioni nel formato Office Open XML con livelli di compressione**

Quando lavori con presentazioni di grandi dimensioni, puoi regolare il livello di compressione per bilanciare dimensione del file e tempo di elaborazione. A seconda delle tue esigenze, potresti preferire un'elaborazione più rapida o file di output più piccoli.

Aspose.Slides fornisce il metodo [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) che consente di specificare il livello di compressione usato durante il salvataggio di una presentazione nel formato Office Open XML.

I seguenti livelli di compressione sono disponibili:

- **None**: Nessuna compressione viene applicata. I file sono memorizzati così come sono.
- **Level1:** La compressione più veloce con il rapporto di compressione più basso.
- **Level2:** Compressione più veloce con un rapporto di compressione leggermente migliore rispetto a **Level1**.
- **Level3:** Fornisce una compressione migliore rispetto a **Level2** con un impatto moderato sul tempo di elaborazione.
- **Level4:** Fornisce una compressione migliore rispetto a **Level3**.
- **Level5:** Fornisce una compressione migliorata rispetto a **Level4** con tempo di elaborazione aggiuntivo.
- **Level6:** Compressione standard che offre un buon equilibrio tra velocità di elaborazione e dimensione del file. Questo è il *livello di compressione predefinito*.
- **Level7:** Fornisce una compressione migliore rispetto a **Level6** con elaborazione più lenta.
- **Level8:** Fornisce una compressione migliore rispetto a **Level7**.
- **Level9:** Compressione massima. Produce la dimensione di file più piccola al costo del tempo di elaborazione più lungo.

L'esempio seguente dimostra come salvare una presentazione come file PPTX *senza compressione*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Questo esempio mostra come salvare una presentazione come file PPTX con *compressione massima*:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Salva presentazioni senza aggiornare la miniatura**

Il metodo [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controlla la generazione della miniatura quando si salva una presentazione in PPTX:

- Se impostato a `true`, la miniatura viene aggiornata durante il salvataggio. È il valore predefinito.
- Se impostato a `false`, la miniatura corrente viene preservata. Se la presentazione non ha una miniatura, non ne viene generata alcuna.

Nel codice seguente, la presentazione viene salvata in PPTX senza aggiornare la sua miniatura.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Questa opzione aiuta a ridurre il tempo necessario per salvare una presentazione nel formato PPTX.
{{% /alert %}}

## **Salva aggiornamenti di avanzamento in percentuale**

L'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprogresscallback/) viene utilizzata tramite il metodo `set_ProgressCallback` esposto dall'interfaccia [ISaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isaveoptions/) e dalla classe astratta [SaveOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/). Assegna un'implementazione di [IProgressCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprogresscallback/) con `set_ProgressCallback` per ricevere aggiornamenti sul progresso del salvataggio in percentuale.

I seguenti frammenti di codice mostrano come utilizzare `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Utilizza qui il valore percentuale di avanzamento.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// La classe di callback di avanzamento definita sopra.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose ha sviluppato una [app gratuita PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) utilizzando la propria API. L'app consente di dividere una presentazione in più file salvando le diapositive selezionate come nuovi file PPTX o PPT.
{{% /alert %}}

## **FAQ**

**Il salvataggio rapido (salvataggio incrementale) è supportato in modo che vengano scritte solo le modifiche?**

No. Il salvataggio crea il file di destinazione completo ogni volta; il salvataggio rapido incrementale non è supportato.

**È thread-safe salvare la stessa istanza di Presentation da più thread?**

No. Un'istanza di [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) non è thread-safe [/slides/it/cpp/multithreading/]; salvala da un solo thread.

**Cosa succede ai collegamenti ipertestuali e ai file collegati esternamente durante il salvataggio?**

[I collegamenti ipertestuali](/slides/it/cpp/manage-hyperlinks/) sono preservati. I file collegati esternamente (ad esempio video tramite percorsi relativi) non vengono copiati automaticamente — assicurati che i percorsi di riferimento rimangano accessibili.

**Posso impostare/salvare i metadati del documento (Autore, Titolo, Società, Data)?**

Sì. Le [proprietà standard del documento](/slides/it/cpp/presentation-properties/) sono supportate e verranno scritte nel file al momento del salvataggio.