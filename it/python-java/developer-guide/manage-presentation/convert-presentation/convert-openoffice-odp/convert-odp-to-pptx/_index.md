---
title: Converti ODP in PPTX in Python
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/python-java/convert-odp-to-pptx/
keywords:
- converti OpenDocument
- converti presentazione
- converti diapositiva
- converti ODP
- OpenDocument in PPTX
- ODP in PPTX
- salva ODP come PPTX
- esporta ODP in PPTX
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Converti le presentazioni ODP in PPTX con Aspose.Slides per Python tramite Java. Usa un esempio completo in Python senza installare PowerPoint o LibreOffice."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione OpenDocument (ODP) in formato PowerPoint (PPTX) utilizzando Aspose.Slides per Python tramite Java.

## **Convertire ODP in PPTX**

La classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) può caricare direttamente un file ODP. Salva la presentazione caricata nel formato PPTX utilizzando [SaveFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/).

Segui le [istruzioni di installazione](/slides/it/python-java/installation/) prima di eseguire l'esempio. Posiziona una presentazione ODP denominata `AccessOpenDoc.odp` nella directory di lavoro. Il codice seguente avvia la JVM se necessario, apre il file ODP e lo salva come `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Salva la presentazione ODP in formato PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Esempio live**

Prova l'app web [Aspose.Slides Conversion](https://products.aspose.app/slides/it/conversion/) per vedere la conversione da ODP a PPTX alimentata da Aspose.Slides.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides per Python tramite Java legge e scrive file di presentazione senza nessuna delle due applicazioni. Hai bisogno del pacchetto Python e di un runtime Java compatibile.

**Le diapositive master, i layout e i temi vengono preservati durante la conversione?**

Aspose.Slides mappa la struttura e la formattazione della presentazione di origine su PPTX. Tuttavia, ODP e PPTX supportano funzionalità diverse, quindi alcuni elementi potrebbero apparire diversi dopo la conversione. Rendi disponibili i caratteri richiesti e revisiona le presentazioni con formattazione complessa. Vedi la [conversione OpenDocument](/slides/it/python-java/convert-openoffice-odp/) per considerazioni sulla compatibilità.

**Posso convertire file ODP protetti da password?**

Sì, fornendo la password necessaria per aprire il file. Vedi le [presentazioni protette da password](/slides/it/python-java/password-protected-presentation/) per i dettagli su come caricare file protetti prima di salvarli in un altro formato.

**Aspose.Slides è adatto per servizi di conversione cloud o basati su REST?**

Sì. Puoi utilizzare Aspose.Slides per Python tramite Java nel tuo backend con il runtime Java richiesto. Per un'API REST, vedi [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/).