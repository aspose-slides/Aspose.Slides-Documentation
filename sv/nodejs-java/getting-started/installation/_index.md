---
title: Installation
type: docs
weight: 70
url: /sv/nodejs-java/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du snabbt installerar Aspose.Slides. Steg-för-steg-guide, systemkrav och kodexempel — börja arbeta med PowerPoint-presentationer idag!"
---
## **Introduktion**

Aspose.Slides för Node.js via Java är ett plattformsoberoende API och kan användas på alla plattformar (Windows, Linux och macOS) där `Node.js` och [`java`](https://www.npmjs.com/package/java)‑bro är installerade.

## **Installera från NPM**

Du kan enkelt installera Aspose.Slides för Node.js via Java från [NPM](https://www.npmjs.com/).

1. Skapa en ny mapp och initiera ett nytt projekt med följande kommando:
	```
	$ npm init
```
	
2. Fyll i fälten för titel och version (lämna de övriga fälten med sina standardvärden).

3. Installera Aspose.Slides för Node.js via Java med följande kommando:
	```
	$ npm install aspose.slides.via.java
	```

Om du stöter på några problem under installationsprocessen, se denna [artikel](/slides/sv/nodejs-java/troubleshooting-installation/).

**Exempel på användning**:

Skapa en fil med namnet `hello.js` i din projektmapp och lägg till följande exempel på kod:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Installera från ZIP‑arkiv**

För att installera och använda Aspose.Slides för Node.js via Java från ett ZIP‑arkiv, följ dessa instruktioner istället:

### **Windows**

1. Installera JDK8 och konfigurera miljövariabeln `JAVA_HOME`.
1. Installera Node.js (https://nodejs.org/en/download/) och lägg till node.exe i `PATH`.
1. Installera node-gyp.
1. Installera Windows Build Tools.
1. Installera [`java`](https://www.npmjs.com/package/java)‑bro och kör dessa kommandon i Kommandoprompten som administratör:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. Ladda ner Aspose.Slides för Node.js via Java (https://releases.aspose.com/slides/sv/nodejs-java/) och extrahera det till `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Skapa en fil med namnet `hello.js` i mappen `aspose.slides.nodejs` med följande exempel kod:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. Kör nu `node hello.js` i kommandoprompten för att köra den.

### **Linux**

1. Installera Node.js (https://nodejs.org/en/download/).
1. Installera JDK8 för Linux och konfigurera miljövariabeln `JAVA_HOME`.
1. Installera python 2.x
1. Installera [`java`](https://www.npmjs.com/package/java)‑bro. Du kan köra dessa kommandon i terminalen:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. Ladda ner Aspose.Slides för Node.js via Java (https://releases.aspose.com/slides/sv/nodejs-java/) och extrahera det till `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Skapa en testfil med namnet `hello.js` med denna exempel kod i mappen `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Kör nu `node hello.js` i kommandoprompten för att köra den.

### **Mac**

1. Installera Node.js (https://nodejs.org/en/download/).
1. Installera JDK8 för Mac och konfigurera miljövariabeln `JAVA_HOME`.
1. Ändra JVMCapabilities‑avsnittet i `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` med root‑privilegier. `jdk1.8.x_xxx.jdk` beror på din jdk‑version. Det ska se ut så här:
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
4. Installera python 2.x (om den inte är installerad).
5. Installera Xcode Command Line Tools.
6. Installera [`java`](https://www.npmjs.com/package/java)‑bro. Du kan köra nedanstående kommandon i terminalen:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Ladda ner Aspose.Slides för Node.js via Java och extrahera det till `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Skapa en testfil med namnet `hello.js` med denna exempel kod i mappen `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Kör nu `node hello.js` i kommandoprompten för att köra den.

{{% alert color="primary" %}}
Vänligen använd följande [artikel](https://docs.aspose.com/slides/sv/nodejs-java/troubleshooting-installation/) om du stöter på kompileringsfel under installationen av Aspose.Slides för Node.js via Java.
{{% /alert %}}

## **Vanliga frågor**

**Finns det en gratis version eller begränsning i provperioden?**

Ja, som standard kör Aspose.Slides i evalueringsläge, vilket placerar vattenmärken och kan ha andra begränsningar. För att ta bort restriktionerna måste du tillämpa en giltig [licens](/slides/sv/nodejs-java/licensing/).