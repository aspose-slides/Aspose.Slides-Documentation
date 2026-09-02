---
title: Converti le presentazioni PowerPoint in XML con .NET
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/net/convert-powerpoint-to-xml/
keywords:
- convertire PowerPoint in XML
- convertire presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat.Xml
- salvare presentazione come XML
- esportare presentazione in XML
- stream XML
- .NET
- C#
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in file o stream XML PowerPoint in C# con Aspose.Slides per .NET."
---
## **Panoramica**

Aspose.Slides per .NET può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere problemi nei documenti generati, confrontare l'output nei test automatizzati o integrare con un flusso di lavoro che utilizza XML invece di un pacchetto di presentazione.

Usa il metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) con il valore `Xml` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveformat/). Puoi scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML memorizzate all'interno di un pacchetto PPTX. Se hai bisogno delle parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole slide, analizza il pacchetto PPTX stesso.

{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione di origine con la classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) quindi passa il percorso di destinazione e `SaveFormat.Xml` a [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). La fonte può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

L'esempio seguente converte una presentazione PPTX in un file XML:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **Scrivere l'output XML su uno stream**

Usa la sovraccarico stream di [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) quando l'XML deve rimanere in memoria o essere trasmesso a un altro componente, ad esempio un servizio web, un provider di storage o una pipeline di elaborazione XML. L'esempio seguente scrive il risultato in un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) e lo riavvolge per una lettura successiva:

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

## **Confrontare XML con i formati di presentazione e di esportazione**

Scegli il formato di output in base al modo in cui verrà utilizzato il risultato:

| Formato | Output | Utilizzo tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Ispezionare la struttura, risolvere problemi, confrontare l'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Rappresentazione renderizzata di una singola slide | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione su browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è destinato principalmente a ispezioni e flussi di lavoro orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle slide, rappresenta i dati della presentazione anziché renderizzare le slide come pagine o risorse visive. La tabella [formati file supportati](/slides/it/net/supported-file-formats/) elenca PowerPoint XML Presentation come formato solo per il salvataggio, quindi non usarlo quando un flusso di lavoro deve caricare il file esportato nuovamente in Aspose.Slides per continuare l'editing.

## **FAQ**

**`SaveFormat.Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat.Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/). Ad esempio, usa un [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio, non per il caricamento. Usa PPTX o un altro formato di presentazione supportato quando è necessario un ciclo di modifica completo.

**La conversione XML rende ogni slide come una pagina o un'immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato alle pagine, oppure PNG, JPEG e SVG per immagini delle singole slide.