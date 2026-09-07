---
title: Converti le presentazioni PowerPoint in XML con Python tramite Java
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/python-java/convert-powerpoint-to-xml/
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
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in file XML PowerPoint o in stream con Python tramite Java utilizzando Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Aspose.Slides per Python tramite Java può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere i problemi dei documenti generati, confrontare l'output in test automatizzati o integrarsi con un flusso di lavoro che consuma XML anziché un pacchetto di presentazione.

Usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con il valore [Xml](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Xml) della classe [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/). Puoi scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Nota" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Xml) crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML memorizzate all'interno di un pacchetto PPTX. Se ti servono le parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, ispeziona direttamente il pacchetto PPTX.

{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione di origine con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e quindi passa il percorso di destinazione e [SaveFormat.Xml](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Xml) a [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save). L'origine può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

L'esempio seguente converte una presentazione PPTX in un file XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Scrivere l'output XML su uno stream**

Usa la sovraccarico dello stream di [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un servizio web, un provider di archiviazione o una pipeline di elaborazione XML. L'esempio seguente scrive il risultato in un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) e ottiene l'XML risultante come oggetto bytes Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Passa xml_data al prossimo componente del flusso di lavoro.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Confrontare XML con presentazione e formati di esportazione**

Scegli il formato di output in base a come verrà utilizzato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione nel browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è pensato principalmente per l'ispezione e i flussi di lavoro orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle diapositive, rappresenta i dati della presentazione anziché renderizzare le diapositive come pagine o risorse visive. La tabella [formati di file supportati](/slides/it/python-java/supported-file-formats/) elenca PowerPoint XML Presentation come formato solo di salvataggio, quindi non usarlo quando un flusso di lavoro deve caricare nuovamente il file esportato in Aspose.Slides per ulteriori modifiche.

## **FAQ**

**L'esportazione XML è la stessa cosa del salvataggio di un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre [SaveFormat.Xml](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Xml) crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream di output Java scrivibile a [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save). Ad esempio, usa un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio, non per il caricamento. Usa PPTX o un altro formato di presentazione supportato quando è necessario un ciclo completo di modifica.

**La conversione XML rende ogni diapositiva come pagina o immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato alle pagine, o PNG, JPEG e SVG per immagini di singole diapositive.