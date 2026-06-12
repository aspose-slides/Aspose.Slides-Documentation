---
title: Installazione
type: docs
weight: 70
url: /it/nodejs-java/installation/
keywords:
- installa Aspose.Slides
- scarica Aspose.Slides
- usa Aspose.Slides
- installazione Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come installare rapidamente Aspose.Slides. Guida passo passo, requisiti di sistema e esempi di codice — inizia a lavorare con presentazioni PowerPoint oggi!"
---
## **Introduzione**

Aspose.Slides for Node.js via Java è un'API indipendente dalla piattaforma e può essere utilizzata su qualsiasi piattaforma (Windows, Linux e MacOS) dove sono installati `Node.js` e il bridge [`java`](https://www.npmjs.com/package/java).

## **Installa da NPM**

Puoi installare facilmente Aspose.Slides for Node.js via Java da [NPM](https://www.npmjs.com/).

1. Crea una nuova cartella e avvia un nuovo progetto usando il comando seguente:
	```
	$ npm init
	```
	
2. Compila i campi titolo e versione (lascia gli altri campi con i valori predefiniti).

3. Installa Aspose.Slides for Node.js via Java usando il comando seguente:
	```
	$ npm install aspose.slides.via.java
	```

Se incontri problemi durante il processo di installazione, consulta questo [articolo](/slides/it/nodejs-java/troubleshooting-installation/).

**Esempio di utilizzo**:

Crea un file chiamato `hello.js` nella cartella del tuo progetto e aggiungi il seguente codice di esempio:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Installa da archivio ZIP**

Per installare e utilizzare Aspose.Slides for Node.js via Java da un archivio ZIP, segui queste istruzioni:

### **Windows**

1. Installa JDK8 e configura la variabile d'ambiente `JAVA_HOME`.
1. Installa Node.js (https://nodejs.org/en/download/) e aggiungi node.exe a `PATH`.
1. Installa node-gyp.
1. Installa Windows Build Tools.
1. Installa il bridge [`java`](https://www.npmjs.com/package/java) e esegui questi comandi in Prompt dei comandi come amministratore:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
2. Scarica Aspose.Slides for Node.js via Java (https://releases.aspose.com/slides/it/nodejs-java/) ed estrailo in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
3. Crea un file chiamato `hello.js` nella cartella `aspose.slides.nodejs` usando il seguente codice di esempio:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
4. Ora esegui `node hello.js` dal prompt dei comandi per avviarlo.

### **Linux**

1. Installa Node.js (https://nodejs.org/en/download/).
1. Installa JDK8 per Linux e configura la variabile d'ambiente `JAVA_HOME`.
1. Installa python 2.x
1. Installa il bridge [`java`](https://www.npmjs.com/package/java). Puoi eseguire questi comandi nel terminale:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
2. Scarica Aspose.Slides for Node.js via Java (https://releases.aspose.com/slides/it/nodejs-java/) ed estrailo in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
3. Crea un file di test chiamato `hello.js` usando questo codice di esempio nella cartella `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
4. Ora esegui `node hello.js` dal prompt dei comandi per avviarlo.

### **Mac**

1. Installa Node.js (https://nodejs.org/en/download/).
1. Installa JDK8 per Mac e configura la variabile d'ambiente `JAVA_HOME`.
1. Modifica la sezione JVMCapabilities in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` con privilegi di root. `jdk1.8.x_xxx.jdk` dipende dalla versione del tuo JDK. Fallo apparire così:
	```xml
	<key>JavaVM</key>
		<dict>
			<key>JVMCapabilities</key>
			<array>
					<string>JNI</string>
					<string>BundledApp</string>
					<string>CommandLine</string>
			</array>
	```
2. Installa python 2.x (se non è già installato).
3. Installa Xcode Command Line Tools.
4. Installa il bridge [`java`](https://www.npmjs.com/package/java). Puoi eseguire i comandi seguenti nel terminale:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
5. Scarica Aspose.Slides for Node.js via Java ed estrailo in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Crea un file di test chiamato `hello.js` usando questo codice di esempio nella cartella `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Ora esegui `node hello.js` dal prompt dei comandi per avviarlo.

{{% alert color="primary" %}}
Si prega di utilizzare il seguente [articolo](https://docs.aspose.com/slides/it/nodejs-java/troubleshooting-installation/) se incontri errori di compilazione durante l'installazione di Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **FAQ**

**Esiste una versione gratuita o limitazioni della prova?**

Sì, per impostazione predefinita, Aspose.Slides opera in modalità di valutazione, che aggiunge filigrane e può presentare altre limitazioni. Per rimuovere le restrizioni, è necessario applicare una [licenza](/slides/it/nodejs-java/licensing/) valida.