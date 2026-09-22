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
- avanzamento salvataggio
- C++
- Aspose.Slides
description: "Salva presentazioni PowerPoint e OpenDocument su file o stream in C++ con Aspose.Slides e configura l'output PPTX e la segnalazione del progresso."
---
## **Panoramica**

Dopo aver creato una presentazione o [open an existing one](/slides/it/cpp/open-presentation/), utilizzare il metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) per scrivere il risultato. Aspose.Slides per C++ può salvare una presentazione su file o stream nei formati PowerPoint, OpenDocument, PDF e altri. Le sezioni seguenti descrivono le operazioni di salvataggio standard e le opzioni disponibili per l'output PPTX.

## **Salva presentazioni su file**

Per salvare una presentazione su un file, passare il percorso di destinazione e un valore [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/) al metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/). Il valore del formato determina il tipo di file che Aspose.Slides crea.

Il seguente esempio crea una presentazione e la salva come file PPTX:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Aggiungi o modifica il contenuto della presentazione qui.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Salva presentazioni nel loro formato originale**

Per esempi di rilevamento di file e stream, il comportamento delle presentazioni appena create e la differenza tra formati di origine e di destinazione, vedere [Determine the Original Presentation Format](/slides/it/cpp/detect-presentation-source-format/).

In un'applicazione di elaborazione batch, il formato di input potrebbe non essere noto in anticipo. Dopo aver caricato un file, leggere il suo formato originale con [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_sourceformat/). Passare il valore [SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/sourceformat/) risultante a [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/tosaveformat/) per ottenere il corrispondente valore [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/), quindi utilizzare [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) per scrivere la presentazione modificata.

Il seguente esempio completo elabora tutti i file in una directory di input, aggiorna il titolo e li salva in una directory di output nel formato da cui sono stati caricati:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.util/slideutil/tosaveformat/) mappa PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP e PowerPoint XML ai corrispondenti formati di salvataggio delle presentazioni. Mappa solo i formati di origine delle presentazioni; non è destinato a selezionare formati di esportazione come PDF, HTML, TIFF o immagini. Passare un valore [SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/sourceformat/) non supportato o non valido genera un'eccezione [ArgumentException](https://reference.aspose.com/slides/it/cpp/system/argumentexception/).

I file legacy PPT, PPS e POT usano lo stesso contenitore binario. Quando una di queste presentazioni è caricata da uno stream senza estensione, un file PPS o POT può quindi essere identificato come PPT. Se è necessario preservare questi sottotipi legacy, conservare il nome file originale o i metadati del formato separatamente e usarli quando si sceglie il nome file e il formato di output.

## **Salva presentazioni su stream**

Per scrivere una presentazione senza dipendere da un percorso file definitivo, passare un oggetto [Stream](https://reference.aspose.com/slides/it/cpp/system.io/stream/) scrivibile e un valore [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/) al metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/). Questo approccio è utile quando l'output deve essere restituito da un servizio web, memorizzato in un database o elaborato in memoria.

Il seguente esempio salva una nuova presentazione su uno stream di file:

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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Salva presentazioni con un tipo di visualizzazione predefinito**

È possibile specificare la visualizzazione con cui PowerPoint apre inizialmente una presentazione salvata. Chiamare [ViewProperties::set_LastView](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewproperties/set_lastview/) con un valore [ViewType](https://reference.aspose.com/slides/it/cpp/aspose.slides/viewtype/) prima del salvataggio.

Il seguente esempio configura la visualizzazione Master Slide come visualizzazione iniziale:

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

Per creare un file PPTX conforme al profilo Strict di Office Open XML, creare un'istanza di [PptxOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/) e chiamare [PptxOptions::set_Conformance](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_conformance/) con `Conformance::Iso29500_2008_Strict`. Quindi passare le opzioni al metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/).

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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salva presentazioni in Office Open XML in modalità Zip64**

Un archivio ZIP standard limita le dimensioni compresse e non compresse di ogni voce, la dimensione totale dell'archivio e il numero di voci. Poiché un file PPTX è un archivio ZIP, una presentazione molto grande può superare tali limiti. Le estensioni ZIP64 aumentano i limiti di dimensione e conteggio delle voci applicabili.

Usare [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) per controllare se Aspose.Slides scrive le estensioni ZIP64:

- `IfNecessary` usa ZIP64 solo quando la presentazione supera i limiti ZIP standard. È la modalità predefinita.
- `Never` disabilita le estensioni ZIP64.
- `Always` scrive sempre le estensioni ZIP64.

Il seguente esempio abilita sempre le estensioni ZIP64 per la presentazione di output:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Se `Zip64Mode` è impostato su `Never` e la presentazione non può rientrare nei limiti ZIP standard, l'operazione di salvataggio genera un'eccezione [PptxException](https://reference.aspose.com/slides/it/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Salva presentazioni in Office Open XML con livelli di compressione**

Per l'output PPTX è possibile bilanciare la velocità di salvataggio rispetto alle dimensioni del file chiamando [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). L'enumerazione [CompressionLevel](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/compressionlevel/) fornisce questi valori:

- `None` memorizza i dati senza compressione.
- `Level1` offre la compressione più veloce e l'output compresso più grande.
- `Level2` fino a `Level5` favoriscono progressivamente un output più piccolo a scapito della velocità di salvataggio.
- `Level6` bilancia velocità di salvataggio e dimensione del file. È il livello predefinito.
- `Level7` e `Level8` favoriscono ulteriormente un output più piccolo.
- `Level9` fornisce la compressione più forte e richiede più tempo di elaborazione.

Il seguente esempio salva una presentazione senza compressione:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

Il seguente esempio utilizza il livello di compressione massimo:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Salva presentazioni senza aggiornare la miniatura**

Quando una presentazione è salvata come PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) controlla la miniatura del documento:

- `true` rigenera la miniatura durante l'operazione di salvataggio. È il valore predefinito.
- `false` conserva la miniatura esistente. Se la presentazione non ha una miniatura, Aspose.Slides non ne genera una.

Il seguente esempio salva una presentazione senza aggiornare la sua miniatura:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Disabilitare l'aggiornamento della miniatura può ridurre il tempo necessario per salvare un file PPTX.
{{% /alert %}}

## **Aggiornamenti di avanzamento del salvataggio in percentuale**

Per monitorare un'operazione di salvataggio, implementare l'interfaccia [IProgressCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprogresscallback/) e passare l'implementazione a [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides quindi chiama [IProgressCallback::Reporting](https://reference.aspose.com/slides/it/cpp/aspose.slides/iprogresscallback/reporting/) con i valori di avanzamento durante l'esportazione.

Il seguente esempio segnala l'avanzamento di un'esportazione PDF sulla console:

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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose offre un gratuito [PowerPoint Splitter](https://products.aspose.app/slides/it/splitter) basato sull'API Aspose.Slides. Consente di salvare le diapositive selezionate da una presentazione come file PPT o PPTX separati.
{{% /alert %}}

## **FAQ**

**Aspose.Slides supporta il salvataggio incrementale o “fast save”?**

No. Ogni operazione di salvataggio scrive un file di output completo anziché aggiornare solo le parti modificate.

**È possibile che più thread salvino la stessa istanza di Presentation?**

No. Una [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) non è thread‑safe [/slides/it/cpp/multithreading/]. Accedere e salvare ogni istanza da un solo thread alla volta.

** Cosa succede a collegamenti ipertestuali e file esternamente collegati quando salvo una presentazione?**

[Hyperlinks](/slides/it/cpp/manage-hyperlinks/) rimangono nella presentazione. Aspose.Slides non copia i file esternamente collegati, quindi la presentazione salvata deve comunque poter accedere alle loro posizioni.

**Posso salvare i metadati del documento come autore, titolo, azienda e data di creazione?**

Sì. Impostare le appropriate [document properties](/slides/it/cpp/presentation-properties/) prima del salvataggio, e Aspose.Slides le scrive nel file di output.