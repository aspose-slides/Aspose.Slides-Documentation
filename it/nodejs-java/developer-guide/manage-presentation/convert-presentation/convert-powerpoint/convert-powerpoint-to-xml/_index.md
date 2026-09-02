---
title: Convertire le presentazioni PowerPoint in XML in JavaScript
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/nodejs-java/convert-powerpoint-to-xml/
keywords:
- convertire PowerPoint in XML
- convertire presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat.Xml
- salvare la presentazione come XML
- esportare la presentazione in XML
- stream XML
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in file o stream PowerPoint XML in JavaScript con Aspose.Slides per Node.js via Java."
---
## **Panoramica**

Aspose.Slides for Node.js via Java può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione testuale per ispezionare la struttura della presentazione, risolvere problemi dei documenti generati, confrontare l'output nei test automatizzati o integrarsi con un flusso di lavoro che utilizza XML anziché un pacchetto di presentazione.

Usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) con il valore `Xml` dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/saveformat/). Puoi scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Nota" %}}
`SaveFormat.Xml` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML contenute in un pacchetto PPTX. Se ti servono le parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, ispeziona il pacchetto PPTX stesso.
{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione sorgente con la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) e poi passa il percorso di destinazione e `SaveFormat.Xml` a [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save). La sorgente può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

L'esempio seguente converte una presentazione PPTX in un file XML:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Scrivere l'output XML in uno stream**

Usa la sovraccarico stream di [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un web service, un provider di storage o una pipeline di elaborazione XML. L'esempio seguente scrive il risultato in un `ByteArrayOutputStream` Java e copia i dati generati in un `Buffer` Node.js:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // Passa xmlBuffer al componente successivo nel flusso di lavoro.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Confrontare XML con i formati di presentazione ed esportazione**

Scegli il formato di output in base a come verrà utilizzato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una presentazione PowerPoint XML | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o un'immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Una rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione in browser e pubblicazione web |

Diversamente da PPT e PPTX, l'output XML è principalmente destinato a ispezioni e flussi di lavoro orientati ai dati. Diversamente da PDF, TIFF, HTML e dai formati immagine delle diapositive, rappresenta i dati della presentazione anziché renderizzare le diapositive come pagine o risorse visive. La tabella dei [formati di file supportati](/slides/it/nodejs-java/supported-file-formats/) elenca PowerPoint XML Presentation come formato solo di salvataggio, quindi non usarlo quando un flusso di lavoro deve ricaricare il file esportato in Aspose.Slides per ulteriori modifiche.

## **FAQ**

**Il `SaveFormat.Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat.Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save). Ad esempio, usa un `ByteArrayOutputStream` Java e copia i suoi dati in un `Buffer` Node.js per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio, non per il caricamento. Usa PPTX o un altro formato di presentazione supportato quando è necessaria una modifica a ciclo chiuso.

**La conversione XML rende ogni diapositiva come una pagina o un'immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato alle pagine, o PNG, JPEG e SVG per immagini singole delle diapositive.