---
title: Converti presentazioni PowerPoint in GIF animate in .NET
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Converti facilmente presentazioni PowerPoint (PPT, PPTX) in GIF animate con Aspose.Slides per .NET. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero, ampiamente supportato, che può essere incorporato in pagine web, messaggistica o documentazione. Questo articolo spiega come esportare una presentazione in GIF usando le impostazioni predefinite e come personalizzare l'output configurando opzioni come dimensione del fotogramma, ritardo delle diapositive e frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/gifoptions/).

## **Converti le presentazioni in GIF animate usando le impostazioni predefinite**

Questo esempio di codice in C# mostra come convertire una presentazione in GIF animata usando le impostazioni standard:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

La GIF animata verrà creata con i parametri predefiniti.

{{%  alert  title="TIP"  color="info"  %}} 

Se preferisci personalizzare i parametri per la GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/gifoptions). Vedi il codice di esempio di seguito. 

{{% /alert %}} 

## **Converti le presentazioni in GIF animate usando le impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animata usando impostazioni personalizzate in C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // la dimensione della GIF risultante  
        DefaultDelay = 2000, // quanto tempo verrà mostrata ogni diapositiva prima di passare a quella successiva
        TransitionFps = 35 // aumenta gli FPS per migliorare la qualità dell'animazione di transizione
    });
}
```

{{% alert title="Info" color="info" %}}

Potresti voler provare il convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 

{{% /alert %}}

## **FAQ**

### Cosa succede se i caratteri utilizzati nella presentazione non sono installati sul sistema?

Installa i caratteri mancanti o [configura i caratteri di riserva](/slides/it/net/powerpoint-fonts/). Aspose.Slides li sostituirà, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i tipi di carattere richiesti siano esplicitamente disponibili.

### Posso sovrapporre una filigrana sui fotogrammi GIF?

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/net/watermark/) al master slide o alle singole diapositive prima dell'esportazione — la filigrana apparirà su ogni fotogramma.