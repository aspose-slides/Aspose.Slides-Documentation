---
title: Converti le presentazioni PowerPoint in GIF animati in C++
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF animato
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
- C++
- Aspose.Slides
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animati con Aspose.Slides per C++. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero e ampiamente supportato, che può essere incorporato in pagine web, messaggistica o documentazione. Questo articolo spiega come esportare una presentazione in GIF utilizzando le impostazioni predefinite e come personalizzare il risultato configurando opzioni come la dimensione del fotogramma, il ritardo della diapositiva e la frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/gifoptions/).

## **Convertire le presentazioni in GIF animati con impostazioni predefinite**

Questo esempio di codice in C++ mostra come convertire una presentazione in GIF animato usando le impostazioni standard:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Il GIF animato verrà creato con i parametri predefiniti. 

{{%  alert  title="TIP"  color="primary"  %}} 
Se preferisci personalizzare i parametri per il GIF, puoi utilizzare la [GifOptions](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.gif_options). Vedi il codice di esempio qui sotto. 
{{% /alert %}} 

## **Convertire le presentazioni in GIF animati con impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animato usando impostazioni personalizzate in C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// la dimensione del GIF risultante 
gifOptions->set_FrameSize(Size(960, 720));
// per quanto tempo ogni diapositiva sarà mostrata fino a quando non verrà cambiata con la successiva
gifOptions->set_DefaultDelay(2000);
// aumenta gli FPS per migliorare la qualità dell'animazione di transizione
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Potresti voler provare un convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 
{{% /alert %}}

## **FAQ**

**E se i caratteri utilizzati nella presentazione non sono installati sul sistema?**

Installa i caratteri mancanti o [configura i caratteri di fallback](/slides/it/cpp/powerpoint-fonts/). Aspose.Slides li sostituirà, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i tipi di carattere necessari siano esplicitamente disponibili.

**Posso sovrapporre una filigrana ai fotogrammi GIF?**

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/cpp/watermark/) alla diapositiva master o alle diapositive individuali prima dell'esportazione — la filigrana apparirà su ogni fotogramma.