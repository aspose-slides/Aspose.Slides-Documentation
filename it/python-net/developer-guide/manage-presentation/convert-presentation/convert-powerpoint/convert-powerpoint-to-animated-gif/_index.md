---
title: Converti presentazioni in GIF animate con Python
linktitle: Presentazione in GIF
type: docs
weight: 65
url: /it/python-net/convert-powerpoint-to-animated-gif/
keywords:
- GIF animata
- convertire PowerPoint
- convertire OpenDocument
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- convertire ODP
- PowerPoint in GIF
- OpenDocument in GIF
- presentazione in GIF
- diapositiva in GIF
- PPT in GIF
- PPTX in GIF
- ODP in GIF
- impostazioni predefinite
- impostazioni personalizzate
- Python
- Aspose.Slides
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) e i file OpenDocument (ODP) in GIF animate con Aspose.Slides per Python. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides ti consente di convertire presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero, ampiamente supportato, che può essere incorporato in pagine web, messaggi o documentazione. Questo articolo spiega come esportare una presentazione in GIF usando le impostazioni predefinite e come personalizzare l'output configurando opzioni quali dimensione del fotogramma, ritardo della diapositiva e frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/gifoptions/).

## **Converti le presentazioni in GIF animata usando le impostazioni predefinite**

Questo esempio di codice in Python mostra come convertire una presentazione in GIF animata utilizzando le impostazioni standard:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

La GIF animata sarà creata con i parametri predefiniti. 

{{%  alert  title="TIP"  color="primary"  %}} 

Se preferisci personalizzare i parametri per la GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/gifoptions/). Vedi il codice di esempio qui sotto. 

{{% /alert %}} 

## **Converti le presentazioni in GIF animata usando impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animata usando impostazioni personalizzate in Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # la dimensione della GIF risultante
options.default_delay = 2000 # per quanto tempo ogni diapositiva sarà mostrata fino al passaggio alla successiva
options.transition_fps = 35  # aumentare gli FPS per migliorare la qualità dell'animazione di transizione

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

Potresti voler provare un convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 

{{% /alert %}}

## **FAQ**

**E se i font usati nella presentazione non sono installati sul sistema?**

Installa i font mancanti o [configura i font di fallback](/slides/it/python-net/powerpoint-fonts/). Aspose.Slides li sostituirà, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano esplicitamente disponibili.

**Posso sovrapporre una filigrana ai fotogrammi GIF?**

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/python-net/watermark/) al master slide o alle singole diapositive prima dell'esportazione — la filigrana comparirà su ogni fotogramma.