---
title: Converti le presentazioni PowerPoint in XML su Android
linktitle: PowerPoint in XML
type: docs
weight: 145
url: /it/androidjava/convert-powerpoint-to-xml/
keywords:
- converti PowerPoint in XML
- converti presentazione in XML
- PPT in XML
- PPTX in XML
- ODP in XML
- Presentazione PowerPoint XML
- SaveFormat.Xml
- salva presentazione come XML
- esporta presentazione in XML
- stream XML
- Android
- Java
- Aspose.Slides
description: "Converti le presentazioni PowerPoint e OpenDocument in file o stream PowerPoint XML su Android con Aspose.Slides."
---
## **Panoramica**

Aspose.Slides for Android via Java può convertire le presentazioni PowerPoint nel formato PowerPoint XML Presentation. L'output XML è utile quando è necessaria una rappresentazione basata su testo per ispezionare la struttura della presentazione, risolvere problemi dei documenti generati, confrontare l'output in test automatizzati o integrare un flusso di lavoro che consuma XML invece di un pacchetto di presentazione.

Usa il metodo [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) con [SaveFormat.Xml](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/#Xml). Puoi scrivere il risultato direttamente su un file o su uno stream.

{{% alert color="info" title="Nota" %}}
`SaveFormat.Xml` crea una PowerPoint XML Presentation. Non estrae le singole parti Office Open XML archiviate all'interno di un pacchetto PPTX. Se hai bisogno delle parti esatte del pacchetto PPTX, come `ppt/presentation.xml` o i file XML delle singole diapositive, esamina direttamente il pacchetto PPTX.
{{% /alert %}}

## **Convertire una presentazione in un file XML**

Carica una presentazione di origine con la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e poi passa il percorso di destinazione e [SaveFormat.Xml](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/saveformat/#Xml) a [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). L'origine può essere qualsiasi formato di presentazione supportato per il caricamento, come PPT, PPTX o ODP.

L'esempio seguente converte una presentazione PPTX in un file XML:

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

Usa la sovraccarico stream di [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) quando l'XML deve rimanere in memoria o essere passato a un altro componente, come un servizio web, un provider di storage o una pipeline di elaborazione XML. L'esempio seguente scrive il risultato in un [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) e ottiene l'XML generato come array di byte:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // Passa xmlData al prossimo componente nel flusso di lavoro.
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
| PowerPoint XML (`.xml`) | Una presentazione PowerPoint XML | Ispezione della struttura, risoluzione di problemi, confronto dell'output generato e integrazione basata su XML |
| PPT (`.ppt`) | Un file di presentazione binario legacy | Compatibilità con flussi di lavoro PowerPoint più vecchi |
| PPTX (`.pptx`) | Un pacchetto Office Open XML contenente più parti | Modifica regolare di PowerPoint e scambio di presentazioni |
| PDF or TIFF | Pagine a layout fisso o un'immagine multipagina | Visualizzazione, stampa e archiviazione |
| PNG, JPEG, or SVG | Una rappresentazione renderizzata di una singola diapositiva | Miniature, anteprime e risorse immagine |
| HTML or HTML5 | Output di presentazione orientato al web | Visualizzazione in browser e pubblicazione web |

A differenza di PPT e PPTX, l'output XML è destinato principalmente all'ispezione e a flussi di lavoro orientati ai dati. A differenza di PDF, TIFF, HTML e dei formati immagine delle diapositive, esso rappresenta i dati della presentazione anziché renderizzare le diapositive come pagine o risorse visive. La tabella dei [formati di file supportati](/slides/it/androidjava/supported-file-formats/) indica PowerPoint XML Presentation come formato di sola scrittura, quindi non usarlo quando un flusso di lavoro deve caricare nuovamente il file esportato in Aspose.Slides per continuare a modificare.

## **FAQ**

**`SaveFormat.Xml` è lo stesso di salvare un file PPTX?**

No. PPTX è un pacchetto contenente più parti Office Open XML, mentre `SaveFormat.Xml` crea un file PowerPoint XML Presentation.

**Posso salvare l'output XML senza creare un file su disco?**

Sì. Passa uno stream scrivibile a [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). Ad esempio, usa un [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) per l'elaborazione in memoria.

**Aspose.Slides può caricare nuovamente il file XML esportato?**

No. PowerPoint XML Presentation è attualmente supportato solo per il salvataggio, non per il caricamento. Usa PPTX o un altro formato di presentazione supportato quando è necessario un ciclo di modifica completo.

**La conversione XML rende ogni diapositiva come una pagina o un'immagine?**

No. La conversione XML scrive dati strutturati della presentazione. Usa PDF o TIFF per output orientato a pagine, o PNG, JPEG e SVG per immagini delle singole diapositive.