---
title: Converti le presentazioni PowerPoint in XML in .NET
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/net/convert-powerpoint-to-xml/
keywords:
- convertire PowerPoint in XML
- convertire la presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat.Xml
- salvare la presentazione come XML
- esportare la presentazione in XML
- flusso XML
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in file o flussi PowerPoint XML in C# con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere problemi dei documenti generati, confrontare l'output in test automatizzati o integrare con un flusso di lavoro che utilizza XML invece di un pacchetto di presentazione.

Usa il metodo [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) con il valore `Xml` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). È possibile scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML memorizzate all'interno di un pacchetto PPTX. Se hai bisogno delle parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, ispeziona direttamente il pacchetto PPTX.
{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione di origine con la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e quindi passa il percorso di destinazione e `SaveFormat.Xml` a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). L'origine può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

Il seguente esempio converte una presentazione PPTX in un file XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Scrivere l'output XML su uno stream**

Usa la sovraccarico stream di [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un servizio web, un provider di storage o una pipeline di elaborazione XML. Il seguente esempio scrive il risultato in un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) e lo riavvolge per una lettura successiva:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// Passa xmlStream al prossimo componente nel flusso di lavoro.
```

## **Confrontare XML con i formati di presentazione ed esportazione**

Scegli il formato di output in base a come verrà utilizzato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentazione PowerPoint XML | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF or TIFF | Pagine a layout fisso o immagini TIFF | Visualizzazione, stampa e archiviazione |
| PNG, JPEG, or SVG | Una rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML or HTML5 | Output di presentazione orientato al web | Visualizzazione in browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è principalmente destinato a flussi di lavoro di ispezione e orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle diapositive, esso rappresenta i dati della presentazione invece di renderizzare le diapositive come pagine o risorse visive. La tabella dei [formati di file supportati](/slides/it/net/supported-file-formats/) elenca tutti i formati che Aspose.Slides può caricare, importare, salvare o renderizzare.

## **FAQ**

**Il `SaveFormat.Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat.Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). Ad esempio, utilizza un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

Sì. Passa il file XML o uno stream al costruttore [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) restituisce quindi `SourceFormat.Xml`. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) segnala `LoadFormat.Unknown` per questo formato, quindi non usarlo per decidere se un file XML può essere aperto.

**La conversione XML rende ogni diapositiva come una pagina o un'immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato alle pagine, oppure PNG, JPEG e SVG per immagini di singole diapositive.