---
title: Converti presentazioni PowerPoint in XML in C++
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/cpp/convert-powerpoint-to-xml/
keywords:
- converti PowerPoint in XML
- converti presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat::Xml
- salva presentazione come XML
- esporta presentazione in XML
- flusso XML
- C++
- Aspose.Slides
description: "Converti presentazioni PowerPoint e OpenDocument in file o flussi PowerPoint XML in C++ con Aspose.Slides per C++."
---
## **Panoramica**

Aspose.Slides for C++ può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere problemi nei documenti generati, confrontare l'output in test automatizzati o integrare un flusso di lavoro che consuma XML anziché un pacchetto di presentazione.

Usa il metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) con il valore `Xml` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/). È possibile scrivere il risultato direttamente su un file o su un flusso.

{{% alert color="info" title="Note" %}}

`SaveFormat::Xml` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML memorizzate all'interno di un pacchetto PPTX. Se ti servono le parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, esamina il pacchetto PPTX stesso.

{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione di origine con la classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) e poi passa il percorso di destinazione e `SaveFormat::Xml` a [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/). L'origine può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

L'esempio seguente converte una presentazione PPTX in un file XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Scrivere l'output XML in un flusso**

Usa la sovraccarico di stream di [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un servizio web, un provider di storage o una pipeline di elaborazione XML. L'esempio seguente scrive il risultato in un [MemoryStream](https://reference.aspose.com/slides/it/cpp/system.io/memorystream/) e lo riavvolge per una lettura successiva:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Passa xmlStream al prossimo componente nel flusso di lavoro.
```

## **Confrontare XML con i formati di presentazione ed esportazione**

Scegli il formato di output in base a come verrà usato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentazione PowerPoint XML | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica standard di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o un'immagine multi-pagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Una rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione nel browser e pubblicazione web |

Diversamente da PPT e PPTX, l'output XML è destinato principalmente all'ispezione e a flussi di lavoro orientati ai dati. Diversamente da PDF, TIFF, HTML e formati immagine delle diapositive, rappresenta i dati della presentazione piuttosto che renderizzare le diapositive come pagine o risorse visive. La tabella dei [formati di file supportati](/slides/it/cpp/supported-file-formats/) elenca PowerPoint XML Presentation come formato di solo salvataggio, quindi non usarlo quando un flusso di lavoro deve caricare nuovamente il file esportato in Aspose.Slides per ulteriori modifiche.

## **FAQ**

**`SaveFormat::Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat::Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa un flusso scrivibile a [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/). Per esempio, utilizza un [MemoryStream](https://reference.aspose.com/slides/it/cpp/system.io/memorystream/) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio e non per il caricamento. Utilizza PPTX o un altro formato di presentazione supportato quando è necessario un ciclo di modifica completo.

**La conversione XML rende ogni diapositiva come pagina o immagine?**

No. La conversione XML scrive dati di presentazione strutturati. Utilizza PDF o TIFF per output orientato a pagine, o PNG, JPEG e SVG per immagini di singole diapositive.