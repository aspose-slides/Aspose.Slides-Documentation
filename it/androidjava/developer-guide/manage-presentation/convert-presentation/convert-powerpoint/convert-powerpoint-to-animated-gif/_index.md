---
title: Converti presentazioni PowerPoint in GIF animati su Android
linktitle: PowerPoint in GIF
type: docs
weight: 65
url: /it/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Converti facilmente presentazioni PowerPoint (PPT, PPTX) in GIF animati con Aspose.Slides per Android via Java. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides ti consente di convertire presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando devi condividere il contenuto delle diapositive in un formato animato leggero e ampiamente supportato che può essere incorporato in pagine web, messaggisti o documentazione. Questo articolo spiega come esportare una presentazione in GIF utilizzando le impostazioni predefinite e come personalizzare l'output configurando opzioni come la dimensione del fotogramma, il ritardo della diapositiva e la frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/gifoptions/).

## **Convertire le presentazioni in GIF animati con le impostazioni predefinite**

Questo esempio di codice in Java mostra come convertire una presentazione in GIF animato usando le impostazioni standard:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Il GIF animato verrà creato con i parametri predefiniti. 

{{%  alert  title="TIP"  color="info"  %}} 
Se preferisci personalizzare i parametri per il GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/GifOptions). Vedi il codice di esempio qui sotto.
{{% /alert %}} 

## **Convertire le presentazioni in GIF animati con impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animato utilizzando impostazioni personalizzate in Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // la dimensione del GIF risultante  
	gifOptions.setDefaultDelay(2000); // quanto tempo verrà mostrata ogni diapositiva prima di passare alla successiva
	gifOptions.setTransitionFps(35); // aumenta FPS per migliorare la qualità dell'animazione di transizione
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Potresti voler provare un convertitore GRATUITO da Testo a GIF sviluppato da Aspose. 
{{% /alert %}}

## **FAQ**

### E se i font utilizzati nella presentazione non sono installati sul sistema?

Installa i font mancanti o [configura i font di fallback](/slides/it/androidjava/powerpoint-fonts/). Aspose.Slides effettuerà una sostituzione, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano disponibili esplicitamente.

### Posso sovrapporre una filigrana ai fotogrammi GIF?

Sì. [Aggiungi un oggetto/logo semitrasparente](/slides/it/androidjava/watermark/) alla diapositiva master o alle diapositive individuali prima dell'esportazione — la filigrana apparirà su ogni fotogramma.