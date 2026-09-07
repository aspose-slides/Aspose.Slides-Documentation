---
title: Converti PPTX in PPT in Python
linktitle: PPTX in PPT
type: docs
weight: 21
url: /it/python-java/convert-pptx-to-ppt/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPTX
- PPTX in PPT
- salva PPTX come PPT
- esporta PPTX in PPT
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Converti PPTX nel formato legacy PPT in Python con Aspose.Slides per Python via Java. Include un esempio di codice e note sulla compatibilità e sui file protetti."
---
## **Panoramica**

Aspose.Slides per Python via Java consente di convertire una presentazione PPTX nel formato legacy PPT utilizzato da PowerPoint 97–2003 senza che Microsoft PowerPoint sia installato. Carica il file PPTX e salvalo con il formato di output PPT, come mostrato di seguito.

## **Converti PPTX in PPT**

Carica il file di origine con la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/), poi chiama [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) passando il percorso di output e [SaveFormat.Ppt](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Ppt).

L'esempio seguente avvia la macchina virtuale Java se necessario e converte `template.pptx` in `output.ppt` usando le opzioni predefinite. Sostituisci i percorsi con i nomi dei tuoi file. Il blocco `finally` rilascia le risorse della presentazione anche se il salvataggio fallisce.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Carica la presentazione PPTX.
presentation = Presentation("template.pptx")
try:
    # Salva la presentazione in formato PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

L'argomento [SaveFormat.Ppt](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Ppt) seleziona il formato di output; modificare solo l'estensione del file non converte una presentazione. Mantieni il file PPTX originale così potrai tornare a esso se una funzionalità più recente non ha un equivalente in PPT.

## **Converti PPTX in altri formati**

Aspose.Slides supporta anche altri formati di output. Consulta gli articoli corrispondenti per opzioni specifiche del formato ed esempi:

- [Converti PowerPoint in PDF in Python](/slides/it/python-java/convert-powerpoint-to-pdf/)
- [Converti PowerPoint in XPS in Python](/slides/it/python-java/convert-powerpoint-to-xps/)
- [Converti PowerPoint in HTML in Python](/slides/it/python-java/convert-powerpoint-to-html/)
- [Salva presentazioni come ODP in Python](/slides/it/python-java/save-presentation/)
- [Converti PowerPoint in PNG in Python](/slides/it/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Tutti gli effetti e le funzionalità PPTX sopravvivono alla conversione in PPT?**

Non sempre. Il formato legacy PPT non supporta tutte le funzionalità disponibili in PPTX. Alcuni effetti, oggetti o comportamenti potrebbero essere semplificati o visualizzati in modo diverso. Verifica la presentazione convertita nel visualizzatore previsto, soprattutto se contiene funzionalità più recenti di PowerPoint.

**Posso convertire solo le diapositive selezionate in PPT?**

Salvare in PPT scrive l'intera presentazione. Per convertire solo diapositive selezionate, crea una nuova presentazione, rimuovi la diapositiva vuota iniziale, clona le diapositive necessarie al suo interno e salvala come PPT. Vedi [Clone Slides in Python](/slides/it/python-java/clone-slides/).

**Posso convertire un file PPTX protetto da password?**

Sì, se fornisci la password corretta durante il caricamento della presentazione di origine. Puoi anche configurare la protezione per il file di output. Vedi [Password-Protected Presentations](/slides/it/python-java/password-protected-presentation/).