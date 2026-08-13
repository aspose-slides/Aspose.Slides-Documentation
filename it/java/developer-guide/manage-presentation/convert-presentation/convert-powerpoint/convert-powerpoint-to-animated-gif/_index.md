---
title: Converti le presentazioni PowerPoint in GIF animati in Java
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animato
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
- PowerPoint in GIF
- presentazione in GIF
- diapositiva in GIF
- PPT in GIF
- PPTX in GIF
- salvare PPT come GIF
- salvare PPTX come GIF
- esportare PPT come GIF
- esportare PPTX come GIF
- impostazioni predefinite
- impostazioni personalizzate
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animati con Aspose.Slides per Java. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero, ampiamente supportato, che può essere incorporato in pagine web, messenger o documentazione. Questo articolo spiega come esportare una presentazione in GIF usando le impostazioni predefinite e come personalizzare l'output configurando opzioni come dimensione del fotogramma, ritardo della diapositiva e frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/gifoptions/).

## **Converti le presentazioni in GIF animati usando le impostazioni predefinite**

Questo esempio di codice Java mostra come convertire una presentazione in GIF animato usando le impostazioni standard:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Il GIF animato sarà creato con i parametri predefiniti. 

{{%  alert  title="TIP"  color="info"  %}} 
Se preferisci personalizzare i parametri per il GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/java/com.aspose.slides/GifOptions). Vedi il codice di esempio di seguito. 
{{% /alert %}} 

## **Converti le presentazioni in GIF animati usando impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animato usando impostazioni personalizzate in Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
    GifOptions gifOptions = new GifOptions();
    gifOptions.setFrameSize(new Dimension(960, 720)); // la dimensione del GIF risultante  
    gifOptions.setDefaultDelay(2000); // per quanto tempo ogni diapositiva sarà mostrata prima di passare alla successiva
    gifOptions.setTransitionFps(35); // aumentare FPS per una migliore qualità dell'animazione di transizione

    pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Potresti voler provare un convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 
{{% /alert %}}

## **FAQ**

### Cosa fare se i font utilizzati nella presentazione non sono installati sul sistema?

Installa i font mancanti o [configura i font di fallback](/slides/it/java/powerpoint-fonts/). Aspose.Slides effettuerà la sostituzione, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i tipi di carattere richiesti siano esplicitamente disponibili.

### Posso sovrapporre una filigrana sui fotogrammi GIF?

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/java/watermark/) alla diapositiva master o alle singole diapositive prima dell'esportazione — la filigrana apparirà su ogni fotogramma.