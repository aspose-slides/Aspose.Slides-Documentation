---
title: Converti le presentazioni PowerPoint in XML in Python
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/python-net/convert-powerpoint-to-xml/
keywords:
- converti PowerPoint in XML
- converti presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat.XML
- salva presentazione come XML
- esporta presentazione in XML
- stream XML
- Python
- Aspose.Slides
description: "Converti presentazioni PowerPoint e OpenDocument in file o stream PowerPoint XML con Python e Aspose.Slides."
---
## **Panoramica**

Aspose.Slides per Python tramite .NET può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione testuale per ispezionare la struttura della presentazione, risolvere problemi dei documenti generati, confrontare l'output nei test automatizzati o integrare un flusso di lavoro che consuma XML anziché un pacchetto di presentazione.

Utilizza il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) con il valore `XML` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/). È possibile scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Nota" %}}

`SaveFormat.XML` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML memorizzate all'interno di un pacchetto PPTX. Se ti servono le parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, esamina direttamente il pacchetto PPTX.

{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) e quindi passa il percorso di destinazione e `SaveFormat.XML` a [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/). La sorgente può essere in qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

L'esempio seguente converte una presentazione PPTX in un file XML:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Scrivere l'output XML su uno stream**

Usa la sovraccarico stream di [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) quando l'XML deve rimanere in memoria o essere passato a un altro componente, ad esempio un servizio web, un provider di archiviazione o una pipeline di elaborazione XML. L'esempio seguente scrive il risultato in uno stream [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) e lo riavvolge per una lettura successiva:

```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Passa xml_stream al componente successivo nel flusso di lavoro.
```

## **Confrontare XML con i formati di presentazione ed esportazione**

Scegli il formato di output in base a come verrà utilizzato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o un'immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Una rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione in browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è destinato principalmente a ispezioni e flussi di lavoro orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle diapositive, esso rappresenta i dati della presentazione anziché renderizzare le diapositive come pagine o risorse visive. La tabella [supported file formats](/slides/it/python-net/supported-file-formats/) elenca PowerPoint XML Presentation come formato di sola scrittura, pertanto non usarla quando un flusso di lavoro deve caricare nuovamente il file esportato in Aspose.Slides per ulteriori modifiche.

## **FAQ**

**Il `SaveFormat.XML` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat.XML` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/). Ad esempio, utilizza uno stream [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio, non per il caricamento. Usa PPTX o un altro formato di presentazione supportato quando è necessario un ciclo di editing completo.

**La conversione XML rende ogni diapositiva come una pagina o un'immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato alle pagine, o PNG, JPEG e SVG per immagini di singole diapositive.