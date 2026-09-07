---
title: Converti presentazioni PowerPoint in XPS in Python
linktitle: PowerPoint in XPS
type: docs
weight: 70
url: /it/python-java/convert-powerpoint-to-xps/
keywords:
- converti PowerPoint
- converti presentazione
- converti PPT
- converti PPTX
- PowerPoint in XPS
- presentazione in XPS
- PPT in XPS
- PPTX in XPS
- salva PPT come XPS
- salva PPTX come XPS
- esporta PPT in XPS
- esporta PPTX in XPS
- Python
- Java
- Aspose.Slides
description: "Converti presentazioni PowerPoint PPT e PPTX in XPS in Python usando Aspose.Slides per Python via Java, con impostazioni di esportazione predefinite o personalizzate."
---
## **Panoramica**

Aspose.Slides per Python via Java consente di convertire presentazioni PowerPoint in XPS salvando un file PPT o PPTX nel formato XPS. Questo articolo spiega quando XPS può essere utile e mostra come esportare una presentazione usando le impostazioni predefinite o impostazioni personalizzate [XpsOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xpsoptions/).

## **Informazioni su XPS**

XPS (XML Paper Specification) è un formato di documento basato su XML sviluppato da Microsoft. Descrive pagine fisse, preservando il layout di testo e grafica per la visualizzazione e la stampa con software compatibili.

## **Quando utilizzare il formato Microsoft XPS**

Utilizza XPS quando un flusso di lavoro documentale richiede file a layout fisso per la condivisione o la stampa tramite strumenti compatibili con XPS. I destinatari hanno bisogno di software che supporti XPS. Se il tuo flusso di lavoro richiede PDF, consulta [Converti PowerPoint in PDF](/slides/it/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Nota" %}}

Per provare a convertire una presentazione PPT o PPTX in XPS, utilizza il [convertitore online gratuito](https://products.aspose.app/slides/it/conversion).

{{% /alert %}}

| Presentazione PowerPoint di input | Documento XPS di output |
| --- | --- |
| ![Presentazione PowerPoint originale](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Presentazione convertita in XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Conversione XPS con Aspose.Slides**

Utilizza il metodo [save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) della classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) con [SaveFormat.Xps](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#Xps) per esportare una presentazione. È possibile usare le impostazioni di esportazione predefinite o fornire [XpsOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/xpsoptions/) per personalizzare l'output.

Ogni esempio riportato di seguito avvia la macchina virtuale Java se necessario e rilascia la presentazione dopo l'uso. Sostituisci il nome del file di input con il percorso del tuo file PPT o PPTX.

### **Converti le presentazioni in XPS usando le impostazioni predefinite**

Il seguente codice Python converte una presentazione in XPS usando le impostazioni predefinite:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Salva la presentazione come documento XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Converti le presentazioni in XPS usando impostazioni personalizzate**

Il seguente esempio utilizza [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/it/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) per salvare i metafile come immagini PNG nel documento XPS risultante:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Salva la presentazione con le impostazioni XPS personalizzate.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso salvare XPS su uno stream anziché su un file?**

Sì. Il metodo [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) ha overload che accettano uno stream di output Java. Con Python via Java, utilizza uno stream Java compatibile tramite JPype, ad esempio uno stream di output a byte array Java, per mantenere i dati esportati in memoria.

**Le diapositive nascoste sono incluse nell'output XPS?**

Le diapositive nascoste sono escluse per impostazione predefinita. Per includerle, imposta [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) su `True` prima di salvare.

**Le animazioni e le transizioni delle diapositive vengono preservate in XPS?**

No. XPS contiene pagine fisse, quindi le diapositive esportate non riproducono animazioni né effetti di transizione.