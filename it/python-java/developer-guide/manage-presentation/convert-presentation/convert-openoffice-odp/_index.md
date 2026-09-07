---
title: Converti presentazioni OpenDocument in Python
linktitle: Converti OpenDocument
type: docs
weight: 10
url: /it/python-java/convert-openoffice-odp/
keywords:
- converti ODP
- ODP in PDF
- ODP in HTML
- ODP in TIFF
- ODP in PPT
- ODP in PPTX
- ODP in XPS
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni OpenDocument (ODP) in PDF, HTML e altri formati con Aspose.Slides per Python tramite Java, senza installare OpenOffice o LibreOffice."
---
## **Introduzione**

Aspose.Slides per Python tramite Java consente di convertire presentazioni OpenDocument (ODP) in formati come PDF, HTML, TIFF, XPS, PPT e PPTX. La conversione ODP utilizza la stessa API della conversione PowerPoint: carica il file di origine con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) e seleziona il formato di output con [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/).

## **Converti ODP in PDF**

Segui le [istruzioni di installazione](/slides/it/python-java/installation/) prima di eseguire l'esempio. Posiziona una presentazione ODP denominata `pres.odp` nella directory di lavoro. Il codice seguente avvia la JVM se necessario, carica la presentazione e la salva come `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Presentazione OpenDocument in diverse applicazioni**

Una presentazione ODP può apparire diversa in PowerPoint e in LibreOffice/OpenOffice Impress perché queste applicazioni supportano funzionalità di presentazione e comportamenti di rendering differenti. Verifica le presentazioni convertite quando il loro layout dipende da formattazioni complesse.

Le differenze di compatibilità possono influire su:

- Tabelle, incluso il loro ordine di sovrapposizione rispetto ad altre forme e il supporto per riempimenti immagine.
- Rotazione e allineamento del testo.
- Riempimenti di immagine, gradiente e motivo applicati al testo.
- Elenchi numerati e puntati.

L'immagine seguente mostra un elenco creato in LibreOffice Impress:

![Esempio di elenco ODP in LibreOffice Impress](odp-list-example.png)

Aspose.Slides salva gli elenchi ODP per la compatibilità con LibreOffice/OpenOffice Impress.

Per dettagli sulla compatibilità delle funzionalità, consulta la [guida di Microsoft al formato OpenDocument Presentation](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Cosa succede se la formattazione del mio file ODP cambia dopo la conversione?**

ODP e PowerPoint utilizzano modelli di presentazione differenti. Tabelle, caratteri e stili di riempimento possono essere visualizzati in modo diverso. Verifica che i caratteri richiesti siano disponibili, controlla il risultato e, se necessario, regola il layout o la formattazione.

**Devo avere OpenOffice o LibreOffice installati per convertire file ODP?**

No. Aspose.Slides per Python tramite Java elabora le presentazioni senza nessuna delle due applicazioni. È necessario un runtime Java compatibile e il pacchetto Python.

**Posso personalizzare l'output PDF durante la conversione di una presentazione ODP?**

Sì. Usa [PdfOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/) per configurare le impostazioni di esportazione PDF, come la qualità dell'immagine e la compressione.

**Posso convertire presentazioni ODP su un server o in un container?**

Sì. Installa il pacchetto Python, un runtime Java compatibile e i caratteri richiesti dalle tue presentazioni nell'ambiente di destinazione. Non è necessaria alcuna applicazione Office.