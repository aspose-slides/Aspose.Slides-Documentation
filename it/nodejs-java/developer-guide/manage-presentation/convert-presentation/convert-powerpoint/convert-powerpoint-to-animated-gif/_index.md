---
title: Converti le presentazioni PowerPoint in GIF animate in JavaScript
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/nodejs-java/convert-powerpoint-to-animated-gif/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animate in JavaScript con Aspose.Slides per Node.js via Java. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero e ampiamente supportato, che può essere incorporato in pagine web, messaggistica o documentazione. Questo articolo spiega come esportare una presentazione in GIF utilizzando le impostazioni predefinite e come personalizzare l'output configurando opzioni come la dimensione del fotogramma, il ritardo della diapositiva e la frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/gifoptions/).

## **Conversione delle presentazioni in GIF animate con impostazioni predefinite**

Questo esempio di codice in JavaScript mostra come convertire una presentazione in GIF animata utilizzando le impostazioni standard:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

La GIF animata verrà creata con i parametri predefiniti. 

{{%  alert  title="TIP"  color="primary"  %}} 

Se preferisci personalizzare i parametri della GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/GifOptions). Vedi il codice di esempio sotto.

{{% /alert %}} 

## **Conversione delle presentazioni in GIF animate con impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animata utilizzando impostazioni personalizzate in JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// la dimensione della GIF risultante
    gifOptions.setDefaultDelay(2000);// quanto tempo verrà mostrata ogni diapositiva prima di passare a quella successiva
    gifOptions.setTransitionFps(35);// aumenta FPS per una migliore qualità dell'animazione di transizione
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}

Potresti voler provare un convertitore GRATUITO da [Testo a GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 

{{% /alert %}}

## **FAQ**

**Cosa succede se i font utilizzati nella presentazione non sono installati sul sistema?**

Installa i font mancanti o [configura i font di riserva](/slides/it/nodejs-java/powerpoint-fonts/). Aspose.Slides li sostituirà, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano esplicitamente disponibili.

**Posso sovrapporre una filigrana sui fotogrammi GIF?**

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/nodejs-java/watermark/) alla diapositiva master o alle diapositive individuali prima dell'esportazione — la filigrana comparirà su ogni fotogramma.