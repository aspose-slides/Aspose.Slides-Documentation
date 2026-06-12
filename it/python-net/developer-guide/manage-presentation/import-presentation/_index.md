---
title: Importa presentazioni con Python
linktitle: Importa presentazione
type: docs
weight: 60
url: /it/python-net/import-presentation/
keywords:
- importa PowerPoint
- importa presentazione
- importa diapositiva
- PDF in presentazione
- PDF in PPT
- PDF in PPTX
- PDF in ODP
- HTML in presentazione
- HTML in PPT
- HTML in PPTX
- HTML in ODP
- Python
- Aspose.Slides
description: "Importa senza sforzo documenti PDF e HTML in presentazioni PowerPoint e OpenDocument in Python con Aspose.Slides per una elaborazione di diapositive fluida e ad alte prestazioni."
---
## **Introduzione**

Con [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/it/python-net/), è possibile importare contenuti in una presentazione da altri formati di file. La classe [SlideCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/) fornisce metodi per importare diapositive da PDF, HTML e altre sorgenti.

## **Convertire un PDF in una presentazione**

Questa sezione mostra come convertire un PDF in una presentazione utilizzando Aspose.Slides. Ti guida attraverso l'importazione del PDF, la trasformazione delle sue pagine in diapositive e il salvataggio del risultato come file PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Chiama il metodo [add_from_pdf](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_from_pdf/) e passa il file PDF.
3. Utilizza il metodo [save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per salvare la presentazione nel formato PowerPoint.

Il seguente esempio Python dimostra la conversione di un PDF in una presentazione:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Tip" color="primary" %}}
Potresti provare la web app **gratuita di Aspose** [PDF to PowerPoint](https://products.aspose.app/slides/it/import/pdf-to-powerpoint) — è un'implementazione live del processo descritto qui.
{{% /alert %}}

## **Convertire un HTML in una presentazione**

Questa sezione mostra come importare contenuti HTML in una presentazione utilizzando Aspose.Slides. Copre il caricamento dell'HTML, la trasformazione in diapositive con testo, immagini e formattazione di base preservati, e il salvataggio del risultato come file PPTX.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Chiama il metodo [add_from_html](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidecollection/add_from_html/) e passa il file HTML.
3. Utilizza il metodo [save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per salvare la presentazione nel formato PowerPoint.

Il seguente esempio Python dimostra la conversione di un HTML in una presentazione:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Le tabelle vengono conservate durante l'importazione di un PDF e la loro rilevazione può essere migliorata?**

Le tabelle possono essere rilevate durante l'importazione; [PdfImportOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.importing/pdfimportoptions/) include un parametro [detect_tables](https://reference.aspose.com/slides/it/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) che consente il riconoscimento delle tabelle. L'efficacia dipende dalla struttura del PDF.

{{% alert title="Note" color="info" %}}
Puoi anche utilizzare Aspose.Slides per convertire HTML in altri formati di file popolari:

* [HTML in immagine](https://products.aspose.com/slides/it/python-net/conversion/html-to-image/)
* [HTML in JPG](https://products.aspose.com/slides/it/python-net/conversion/html-to-jpg/)
* [HTML in XML](https://products.aspose.com/slides/it/python-net/conversion/html-to-xml/)
* [HTML in TIFF](https://products.aspose.com/slides/it/python-net/conversion/html-to-tiff/)

{{% /alert %}}