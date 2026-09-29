---
title: Convertire presentazioni PowerPoint in XML con Java
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/java/convert-powerpoint-to-xml/
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
- stream XML
- Java
- Aspose.Slides
description: "Converti presentazioni PowerPoint e OpenDocument in file o stream PowerPoint XML con Java utilizzando Aspose.Slides per Java."
---
## **Panoramica**

Aspose.Slides for Java può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere problemi dei documenti generati, confrontare l'output in test automatizzati o integrare un flusso di lavoro che consuma XML anziché un pacchetto di presentazione.

Usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) con il valore `Xml` della classe [SaveFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/). È possibile scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML contenute in un pacchetto PPTX. Se ti servono le parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, ispeziona direttamente il pacchetto PPTX.
{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione di origine con la classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e poi passa il percorso di output e `SaveFormat.Xml` a [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-). L'origine può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

Il seguente esempio converte una presentazione PPTX in un file XML:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **Scrivere l'output XML in uno stream**

Usa la sovraccarico stream di [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un servizio web, un provider di storage o una pipeline di elaborazione XML. Il seguente esempio scrive il risultato in un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) e ottiene l'XML risultante come array di byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // Passa xmlData al prossimo componente nel flusso di lavoro.
} finally {
    presentation.dispose();
}
```

## **Confrontare XML con i formati di presentazione ed esportazione**

Scegli il formato di output in base a come verrà utilizzato il risultato:

| Formato | Output | Uso tipico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Ispezione della struttura, risoluzione dei problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF o TIFF | Pagine a layout fisso o immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG o SVG | Rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML o HTML5 | Output di presentazione orientato al web | Visualizzazione nel browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è principalmente destinato a ispezioni e a flussi di lavoro orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle diapositive, rappresenta i dati della presentazione anziché renderizzare le diapositive come pagine o risorse visive. La tabella dei [formati di file supportati](/slides/it/java/supported-file-formats/) elenca tutti i formati che Aspose.Slides può caricare, importare, salvare o renderizzare.

## **FAQ**

**Il `SaveFormat.Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat.Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Ad esempio, usa un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

Sì. Passa il file XML o uno stream al costruttore [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#Presentation-java.lang.String-). [Presentation.getSourceFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSourceFormat--) restituisce quindi `SourceFormat.Xml`. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) segnala `LoadFormat.Unknown` per questo formato, quindi non usarlo per decidere se un file XML può essere aperto.

**La conversione XML renderizza ogni diapositiva come una pagina o immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato alle pagine, o PNG, JPEG e SVG per immagini delle singole diapositive.