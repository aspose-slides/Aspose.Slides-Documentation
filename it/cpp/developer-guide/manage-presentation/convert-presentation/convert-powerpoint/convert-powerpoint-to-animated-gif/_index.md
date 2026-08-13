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

Aspose.Slides consente di convertire presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero e ampiamente supportato, che può essere incorporato nelle pagine web, nei messaggeri o nella documentazione. Questo articolo spiega come esportare una presentazione in GIF utilizzando le impostazioni predefinite e come personalizzare l'output configurando opzioni come la dimensione del fotogramma, il ritardo della diapositiva e la frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/gifoptions/).

## **Convertire le presentazioni in GIF animati usando le impostazioni predefinite**

Questo esempio di codice in C++ mostra come convertire una presentazione in GIF animato usando le impostazioni standard:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Il GIF animato verrà creato con i parametri predefiniti. 

{{%  alert  title="TIP"  color="info"  %}} 

Se preferisci personalizzare i parametri del GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.gif_options). Vedi il codice di esempio di seguito. 

{{% /alert %}} 

## **Convertire le presentazioni in GIF animati usando le impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animato usando impostazioni personalizzate in C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// la dimensione della GIF risultante
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// quanto tempo verrà mostrata ogni diapositiva prima di passare alla successiva
gifOptions->set_DefaultDelay(2000);
// aumenta gli FPS per una migliore qualità dell'animazione di transizione
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Potresti voler provare un convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 

{{% /alert %}}

## **FAQ**

### Cosa succede se i caratteri utilizzati nella presentazione non sono installati sul sistema?

Installa i caratteri mancanti o [configura i caratteri di riserva](/slides/it/cpp/powerpoint-fonts/). Aspose.Slides li sostituirà, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano esplicitamente disponibili.

### Posso sovrapporre una filigrana sui fotogrammi GIF?

Sì. [Aggiungi un oggetto/logo semi-trasparente](/slides/it/cpp/watermark/) alla diapositiva master o alle singole diapositive prima dell'esportazione — la filigrana apparirà su ogni fotogramma.