---
title: Converti le presentazioni PowerPoint in GIF animati su Android
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
description: "Converti facilmente le presentazioni PowerPoint (PPT, PPTX) in GIF animati con Aspose.Slides per Android via Java. Risultati rapidi e di alta qualità."
---
## **Panoramica**

Aspose.Slides consente di convertire le presentazioni PowerPoint in file GIF animati con poche righe di codice. Questo è utile quando è necessario condividere il contenuto delle diapositive in un formato animato leggero e ampiamente supportato, che può essere incorporato in pagine web, messaggisti o documentazione. Questo articolo spiega come esportare una presentazione in GIF usando le impostazioni predefinite e come personalizzare l'output configurando opzioni come dimensione del fotogramma, ritardo della diapositiva e frequenza dei fotogrammi di transizione tramite [GifOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/gifoptions/).

## **Convertire le presentazioni in GIF animati con impostazioni predefinite**

Questo esempio di codice in Java mostra come convertire una presentazione in GIF animato usando le impostazioni standard:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

Il GIF animato verrà creato con i parametri predefiniti. 

{{%  alert  title="TIP"  color="primary"  %}} 

Se preferisci personalizzare i parametri per il GIF, puoi utilizzare la classe [GifOptions](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/GifOptions). Vedi il codice di esempio di seguito.

{{% /alert %}} 

## **Convertire le presentazioni in GIF animati con impostazioni personalizzate**

Questo esempio di codice mostra come convertire una presentazione in GIF animato usando impostazioni personalizzate in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // la dimensione del GIF risultante  
	gifOptions.setDefaultDelay(2000); // quanto tempo verrà mostrata ogni diapositiva prima di passare a quella successiva
	gifOptions.setTransitionFps(35); // aumenta gli FPS per migliorare la qualità dell'animazione di transizione
	
	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

Potresti voler provare il convertitore GRATUITO [Text to GIF](https://products.aspose.app/slides/it/text-to-gif) sviluppato da Aspose. 

{{% /alert %}}

## **FAQ**

**Cosa succede se i font utilizzati nella presentazione non sono installati sul sistema?**

Installa i font mancanti o [configura i font di fallback](/slides/it/androidjava/powerpoint-fonts/). Aspose.Slides effettuerà una sostituzione, ma l'aspetto potrebbe differire. Per il branding, assicurati sempre che i caratteri richiesti siano disponibili esplicitamente.

**Posso sovrapporre una filigrana sui fotogrammi GIF?**

Sì. [Aggiungi un oggetto/logo semi‑trasparente](/slides/it/androidjava/watermark/) alla diapositiva master o alle singole diapositive prima dell'esportazione — la filigrana apparirà su ogni fotogramma.