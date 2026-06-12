---
title: Installatie
type: docs
weight: 70
url: /nl/nodejs-java/installation/
keywords:
- Installeer Aspose.Slides
- Download Aspose.Slides
- Gebruik Aspose.Slides
- Installatie van Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u Aspose.Slides snel kunt installeren. Stapsgewijze handleiding, systeemvereisten en codevoorbeelden — begin vandaag nog met het werken met PowerPoint‑presentaties!"
---
## **Inleiding**

Aspose.Slides for Node.js via Java is een platformonafhankelijke API en kan op elk platform (Windows, Linux en macOS) worden gebruikt waar `Node.js` en de [`java`](https://www.npmjs.com/package/java) bridge zijn geïnstalleerd.

## **Installeer via NPM**

U kunt eenvoudig Aspose.Slides for Node.js via Java installeren via [NPM](https://www.npmjs.com/).

1. Maak een nieuwe map aan en initialiseert een nieuw project met het volgende commando:
	```
	$ npm init
	```
	
2. Vul de velden titel en versie in (laat de overige velden op hun standaardwaarden).

3. Installeer Aspose.Slides for Node.js via Java met het volgende commando:
	```
	$ npm install aspose.slides.via.java
	```

Als u een probleem ondervindt tijdens het installatieproces, raadpleeg dan dit [artikel](/slides/nl/nodejs-java/troubleshooting-installation/).

**Gebruikvoorbeeld**:

Maak een bestand met de naam `hello.js` aan in uw projectmap en voeg de volgende voorbeeldcode toe:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Installeer vanuit ZIP-archief**

Om Aspose.Slides for Node.js via Java te installeren en te gebruiken vanuit een ZIP-archief, volg dan in plaats daarvan deze instructies:

### **Windows**

1. Installeer JDK8 en configureer de omgevingsvariabele `JAVA_HOME`.
1. Installeer Node.js (https://nodejs.org/en/download/) en voeg node.exe toe aan `PATH`.
1. Installeer node-gyp.
1. Installeer Windows Build Tools.
1. Installeer de [`java`](https://www.npmjs.com/package/java) bridge en voer de volgende opdrachten uit in de Command Prompt als administrator:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```
6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nl/nodejs-java/) en pak het uit naar `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Maak een bestand met de naam `hello.js` in de map `aspose.slides.nodejs` met de volgende voorbeeldcode:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Voer nu `node hello.js` uit in de opdrachtprompt om het te starten.

### **Linux**

1. Installeer Node.js (https://nodejs.org/en/download/).
1. Installeer JDK8 voor Linux en configureer de omgevingsvariabele `JAVA_HOME`.
1. Installeer python 2.x
1. Installeer de [`java`](https://www.npmjs.com/package/java) bridge. U kunt de volgende opdrachten in de terminal uitvoeren:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nl/nodejs-java/) en pak het uit naar `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Maak een testbestand met de naam `hello.js` met deze voorbeeldcode in de map `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Voer nu `node hello.js` uit in de opdrachtprompt om het te starten.

### **Mac**

1. Installeer Node.js (https://nodejs.org/en/download/).
1. Installeer JDK8 voor Mac en configureer de omgevingsvariabele `JAVA_HOME`.
1. Wijzig de sectie JVMCapabilities in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` met rootprivileges. `jdk1.8.x_xxx.jdk` hangt af van uw jdk‑versie. Laat het er zo uitzien:
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
4. Installeer python 2.x (indien niet geïnstalleerd).
5. Installeer Xcode Command Line Tools.
6. Installeer de [`java`](https://www.npmjs.com/package/java) bridge. U kunt de onderstaande opdrachten in de terminal uitvoeren:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
```
7. Download Aspose.Slides for Node.js via Java en pak het uit naar `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Maak een testbestand met de naam `hello.js` met deze voorbeeldcode in de map `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Voer nu `node hello.js` uit in de opdrachtprompt om het te starten.

{{% alert color="primary" %}}

Gebruik het volgende [artikel](https://docs.aspose.com/slides/nl/nodejs-java/troubleshooting-installation/) als u compilatiefouten ondervindt tijdens de installatie van Aspose.Slides for Node.js via Java.

{{% /alert %}}

## **FAQ**

**Is er een gratis versie of een proefbeperking?**

Ja, standaard draait Aspose.Slides in evaluatiemodus, waardoor watermerken worden geplaatst en er mogelijk andere beperkingen zijn. Om de restricties te verwijderen moet u een geldige [licentie](/slides/nl/nodejs-java/licensing/) toepassen.