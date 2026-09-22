---
title: Determinare il formato originale della presentazione in C++
linktitle: Formato di origine
type: docs
weight: 35
url: /it/cpp/detect-presentation-source-format/
keywords:
- formato di origine
- rilevare il formato della presentazione
- PowerPoint
- OpenDocument
- presentazione
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Leggi il formato originale di una presentazione caricata in C++ con Aspose.Slides per C++, confronta le API di rilevamento e gestisci file, stream e formati legacy."
---
## **Panoramica**

Dopo aver caricato una presentazione, chiama [Presentation::get_SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sourceformat/) per determinare il suo formato originale. Il metodo è disponibile anche tramite [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_sourceformat/). Usalo quando l’elaborazione successiva dipende dal formato da cui è stata caricata l’istanza corrente.

Il formato di origine è distinto dal [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/) selezionato per un file di output. Il salvataggio in un altro formato non modifica il formato di origine dell’istanza esistente.

## **Leggere il Formato di Origine di un File**

Questo esempio richiede un file `sample.pptx` esistente. Carica il file e seleziona una politica di elaborazione dell’applicazione usando [Presentation::get_SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sourceformat/), anziché il nome file. Modifica il percorso di input per provare altri formati. L’esempio stampa la politica selezionata; sostituisci i messaggi con la logica della tua applicazione.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Riconoscere i Valori Supportati**

L’enumerazione [SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/sourceformat/) distingue i seguenti formati di presentazione. Le estensioni riportate sono estensioni convenzionali, non una ricostruzione del nome file originale.

| Valore SourceFormat | Estensione | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | Presentazione PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Presentazione Office Open XML |
| `Pptm` | `.pptm` | Presentazione Office Open XML con macro |
| `Pps` | `.pps` | Presentazione PowerPoint 97–2003 (presentazione) |
| `Ppsx` | `.ppsx` | Presentazione Office Open XML (presentazione) |
| `Ppsm` | `.ppsm` | Presentazione Office Open XML con macro (presentazione) |
| `Pot` | `.pot` | Modello PowerPoint 97–2003 |
| `Potx` | `.potx` | Modello Office Open XML |
| `Potm` | `.potm` | Modello Office Open XML con macro |
| `Odp` | `.odp` | Presentazione OpenDocument |
| `Otp` | `.otp` | Modello di presentazione OpenDocument |
| `Fodp` | `.fodp` | Presentazione Flat XML ODF |
| `Xml` | `.xml` | Presentazione PowerPoint XML |

## **Leggere il Formato di Origine da uno Stream**

Questo esempio richiede un file `sample.pps` esistente. Leggere i suoi byte in uno stream di memoria simula un input ricevuto senza nome file, ad esempio un valore di database o un array di byte caricato. Il costruttore [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) riceve solo lo stream.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS e POT utilizzano lo stesso formato binario sottostante. Quando si carica tramite percorso file, l’estensione può aiutare a distinguere una presentazione, una presentazione o un modello. Senza nome file, il contenuto legacy PPS e POT può essere segnalato come `SourceFormat::Ppt`; l’esempio PPS sopra segnala `Ppt`.

Se la tua applicazione deve preservare questa distinzione, conserva separatamente il nome file originale o i metadati di sottotipo. Un’estensione è un indizio utile per questi sottotipi legacy, ma non dovrebbe essere l’unica base per identificare contenuti di presentazione arbitrari.

## **Confrontare il Rilevamento Prima e Dopo il Caricamento**

Usa [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/getpresentationinfo/) e [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentationinfo/get_loadformat/) quando è necessario ispezionare un file prima di caricare il suo modello di oggetti completo. Usa [Presentation::get_SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sourceformat/) quando l’istanza esiste già.

Questo esempio richiede `sample.pptx` e stampa `Pptx` per entrambe le verifiche. In produzione, scegli l’API appropriata allo stadio di elaborazione; una presentazione già caricata non richiede una seconda ispezione solo per ottenere il suo formato di origine.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

I risultati hanno tipi di enumerazione diversi: [LoadFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadformat/) e [SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/sourceformat/). Non confrontarli castando i valori numerici né assumere che ogni formato abbia risultati di rilevamento identici. PowerPoint XML può essere segnalato come `LoadFormat::Unknown` prima del caricamento e `SourceFormat::Xml` dopo il caricamento.

## **Mantenere Separati Formati di Origine e di Output**

Questo esempio richiede `sample.pptx` e scrive `converted.odp`. Stampa `Pptx` sia prima sia dopo il salvataggio dell’istanza originale. Solo la nuova istanza caricata dall’output ODP segnala `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Una presentazione creata da zero con `MakeObject<Presentation>()` segnala `SourceFormat::Pptx`. Non ha un file di input: questo è il valore predefinito per un’istanza appena creata, non una prova che sia stato caricato un file PPTX. Tieni traccia separatamente se la tua applicazione ha creato o caricato l’istanza, se tale distinzione è importante.

## **Mappare un Formato di Origine a un’Estensione**

Il seguente esempio richiede `sample.pptx`. Mappa ogni valore attualmente supportato di [SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/sourceformat/) a un’estensione convenzionale, senza analizzare il nome file di input. Il fallback evita di assegnare silenziosamente un’estensione a un valore non riconosciuto.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Questa mappatura non converte un file né recupera un sottotipo legacy PPS/POT perduto durante il caricamento dallo stream. Per il salvataggio effettivo, seleziona esplicitamente un [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/) o usa la conversione mostrata in [Save Presentations in Their Original Format](/slides/it/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Verificare i Formati Salvando e Riaprendo**

Questo esempio autonomo crea una presentazione e scrive tre file nella directory di lavoro, sovrascrivendo file con lo stesso nome. Riapre ogni output sia tramite percorso sia tramite uno stream di memoria. Per PPTX e ODP, entrambi i percorsi segnalano il formato salvato. Per PPS, il caricamento tramite percorso segnala `Pps`, mentre il caricamento degli stessi byte senza nome file segnala `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

La tabella seguente riassume l’identificazione del formato di origine per presentazioni con estensioni corrispondenti:

| Formato salvato | SourceFormat da percorso file | SourceFormat da stream senza nome |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` rispettivamente | Stesso del percorso file |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` rispettivamente | Stesso del percorso file |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` rispettivamente | Stesso del percorso file |
| ODP, OTP | `Odp`, `Otp` rispettivamente | Stesso del percorso file |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Il contenuto legacy PPS/POT è normalizzato a `Ppt` per stream senza nome. La tabella descrive l’identificazione del formato, non la conservazione di ogni caratteristica della presentazione durante la conversione.

## **FAQ**

**Il salvataggio in ODP cambia il formato di origine di una presentazione caricata da PPTX?**

No. L’istanza esistente continua a segnalare `Pptx`. Un’istanza caricata dal file ODP salvato segnala `Odp`.

**Uno stream può sempre distinguere una presentazione legacy, una presentazione e un modello?**

No. PPT, PPS e POT condividono lo stesso formato binario. Conserva separatamente il nome file o i metadati di sottotipo quando è necessaria tale distinzione.

**Quale API devo usare se la presentazione è già caricata?**

Leggi [Presentation::get_SourceFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_sourceformat/). Usa [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentationfactory/getpresentationinfo/) per l’ispezione prima del caricamento.