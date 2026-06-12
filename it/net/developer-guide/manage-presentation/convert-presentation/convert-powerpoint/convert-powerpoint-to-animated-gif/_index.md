---
title: Converti le presentazioni PowerPoint in GIF animate in .NET
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
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animate con Aspose.Slides per .NET. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in file GIF animati con poche righe di codice. È utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero e ampiamente supportato, che può essere incorporato in pagine web, messaggistica o documentazione. Questo articolo spiega come esportare una presentazione in GIF usando le impostazioni predefinite e come personalizzare l'output configurando opzioni come dimensione del fotogramma, ritardo della diapositiva e frequenza dei fotogrammi di transizione attraverso [GifOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/gifoptions/).

## **Convertire le presentazioni in GIF animate con impostazioni predefinite**

Questo esempio di codice in C# mostra come convertire una presentazione in GIF animata usando le impostazioni standard:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

La GIF animata verrà creata con i parametri predefiniti. 

{{%  alert  title="TIP"  color="primary"  %}} 
Se preferisci personalizzare i parametri per la GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/gifoptions) . Vedi il codice di esempio di seguito. 
{{% /alert %}} 

## **Convertire le presentazioni in GIF animate con impostazioni personalizzate**

Questo esempio di codice ti mostra come convertire una presentazione in GIF animata usando impostazioni personalizzate in C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // la dimensione della GIF risultante
        DefaultDelay = 2000, // quanto tempo verrà mostrata ogni diapositiva prima di passare alla successiva
        TransitionFps = 35 // aumenta FPS per migliorare la qualità dell'animazione di transizione
    });
}
```

{{% alert title="Info" color="info" %}}
Potresti voler provare un convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 
{{% /alert %}}

## **FAQ**

**Cosa succede se i font utilizzati nella presentazione non sono installati sul sistema?**

Installa i font mancanti o [configura i font di fallback](/slides/it/net/powerpoint-fonts/). Aspose.Slides li sostituirà, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano esplicitamente disponibili.

**Posso sovrapporre una filigrana sui fotogrammi della GIF?**

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/net/watermark/) alla diapositiva master o alle singole diapositive prima dell'esportazione — la filigrana apparirà su ogni fotogramma.