---
title: Converti presentazioni PowerPoint in GIF animate con Python
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/python-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animata
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in GIF
- presentazione in GIF
- diapositiva in GIF
- PPT in GIF
- PPTX in GIF
- salva PPT come GIF
- salva PPTX come GIF
- esporta PPT come GIF
- esporta PPTX come GIF
- impostazioni predefinite
- impostazioni personalizzate
- PowerPoint
- presentazione
- Python
- Java
- Aspose.Slides
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animate con Aspose.Slides per Python tramite Java. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides per Python tramite Java consente di convertire presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile per condividere il contenuto delle diapositive in pagine web, messaggi o documentazione. Questo articolo spiega come esportare una presentazione usando le impostazioni predefinite e come personalizzare la dimensione del fotogramma, il ritardo della diapositiva e la frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/gifoptions/).

## **Converti le presentazioni in GIF animati usando le impostazioni predefinite**

L'esempio Python seguente carica `pres.pptx` e lo salva come GIF animata usando le impostazioni standard:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Suggerimento" %}}
Per personalizzare l'output GIF, passa un oggetto [GifOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/gifoptions/) durante il salvataggio, come mostrato di seguito.
{{% /alert %}}

## **Converti le presentazioni in GIF animati usando impostazioni personalizzate**

Usa [setFrameSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/gifoptions/#setFrameSize) per specificare le dimensioni di output in pixel, [setDefaultDelay](https://reference.aspose.com/slides/it/python-java/aspose.slides/gifoptions/#setDefaultDelay) per impostare il ritardo predefinito della diapositiva in millisecondi e [setTransitionFps](https://reference.aspose.com/slides/it/python-java/aspose.slides/gifoptions/#setTransitionFps) per controllare la frequenza dei fotogrammi di transizione.

L'esempio seguente esporta una GIF 960 × 720 con un ritardo predefinito della diapositiva di due secondi e 35 fotogrammi al secondo per le transizioni. Il ritardo predefinito viene applicato quando il tempo di avanzamento della diapositiva non è impostato.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Puoi anche provare il convertitore gratuito di Aspose [Testo in GIF](https://products.aspose.app/slides/it/text-to-gif).
{{% /alert %}}

## **Domande frequenti**

**Cosa succede se i caratteri utilizzati nella presentazione non sono installati sul sistema?**

Installa i caratteri mancanti o [configura i caratteri di riserva](/slides/it/python-java/powerpoint-fonts/). La sostituzione dei caratteri può modificare l'aspetto della GIF esportata. È fondamentale rendere disponibili i caratteri originali quando è importante mantenere il design della presentazione.

**Posso sovrapporre una filigrana sui fotogrammi GIF?**

Sì. [Aggiungi un oggetto o logo semitrasparente](/slides/it/python-java/watermark/) alle slide master rilevanti o alle slide individuali prima dell'esportazione. La filigrana diventa parte del contenuto della slide renderizzata.