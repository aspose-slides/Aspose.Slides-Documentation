---
title: Telepítés
type: docs
weight: 70
url: /hu/nodejs-java/installation/
keywords:
- Aspose.Slides telepítése
- Aspose.Slides letöltése
- Aspose.Slides használata
- Aspose.Slides telepítés
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan telepítheti gyorsan az Aspose.Slides-et. Lépésről lépésre útmutató, rendszerkövetelmények és kódminták — kezdjen el még ma PowerPoint-prezentációkkal dolgozni!"
---
## **Bevezetés**

Az Aspose.Slides for Node.js via Java egy platformfüggetlen API, és bármilyen platformon (Windows, Linux és macOS) használható, ahol a `Node.js` és a [`java`](https://www.npmjs.com/package/java) bridge telepítve van.

## **Telepítés NPM-ből**

Az Aspose.Slides for Node.js via Java könnyen telepíthető a [NPM](https://www.npmjs.com/) oldalról.

1. Hozzon létre egy új mappát, és indítson egy új projektet a következő paranccsal:
	```
	$ npm init
	```
	
2. Töltse ki a cím és verzió mezőket (hagyja a többi mezőt az alapértelmezett értékekkel).

3. Telepítse az Aspose.Slides for Node.js via Java-t a következő paranccsal:
	```
	$ npm install aspose.slides.via.java
	```

Ha a telepítés során bármilyen problémába ütközik, kérjük, tekintse meg ezt a [cikket](/slides/hu/nodejs-java/troubleshooting-installation/).

**Használati példa**:

Hozzon létre egy `hello.js` nevű fájlt a projekt mappájában, és adja hozzá a következő mintakódot:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Telepítés ZIP archívumból**

Az Aspose.Slides for Node.js via Java ZIP archívumból történő telepítéséhez és használatához kövesse inkább az alábbi utasításokat:

### **Windows**

1. Telepítse a JDK8-at, és állítsa be a `JAVA_HOME` környezeti változót.  
1. Telepítse a Node.js-t (https://nodejs.org/en/download/), és adja hozzá a node.exe-t a `PATH`-hoz.  
1. Telepítse a node-gyp-et.  
1. Telepítse a Windows Build Tools-t.  
1. Telepítse a [`java`](https://www.npmjs.com/package/java) bridge-t, és futtassa a következő parancsokat a Parancssorban rendszergazdaként:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Töltse le az Aspose.Slides for Node.js via Java-t](https://releases.aspose.com/slides/hu/nodejs-java/) és csomagolja ki a `aspose.slides.nodejs/node_modules/aspose.slides.via.java` mappába.  
7. Hozzon létre egy `hello.js` nevű fájlt az `aspose.slides.nodejs` mappában a következő mintakód használatával:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. Most futtassa a `node hello.js` parancsot a parancssorban.

### **Linux**

1. Telepítse a Node.js-t (https://nodejs.org/en/download/).  
1. Telepítse a Linuxra szánt JDK8-at, és állítsa be a `JAVA_HOME` környezeti változót.  
1. Telepítse a python 2.x-et.  
1. Telepítse a [`java`](https://www.npmjs.com/package/java) bridge-t. A következő parancsokat futtathatja a terminálban:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Töltse le az Aspose.Slides for Node.js via Java-t](https://releases.aspose.com/slides/hu/nodejs-java/) és csomagolja ki a `aspose.slides.nodejs/node_modules/aspose.slides.via.java` mappába.  
6. Hozzon létre egy `hello.js` nevű tesztfájlt ezzel a mintakóddal az `aspose.slides.nodejs` mappában:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Most futtassa a `node hello.js` parancsot a parancssorban.

### **Mac**

1. Telepítse a Node.js-t (https://nodejs.org/en/download/).  
1. Telepítse a Mac-re szánt JDK8-at, és állítsa be a `JAVA_HOME` környezeti változót.  
1. Módosítsa a JVMCapabilities szekciót a `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` fájlban root jogosultsággal. A `jdk1.8.x_xxx.jdk` a JDK verziójától függ. Így nézzen ki:
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
4. Telepítse a python 2.x-et (ha még nincs telepítve).  
5. Telepítse az Xcode Command Line Tools-t.  
6. Telepítse a [`java`](https://www.npmjs.com/package/java) bridge-t. Az alábbi parancsokat futtathatja a terminálban:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Töltse le az Aspose.Slides for Node.js via Java-t, és csomagolja ki a `aspose.slides.nodejs/node_modules/aspose.slides.via.java` mappába.  
8. Hozzon létre egy `hello.js` nevű tesztfájlt ezzel a mintakóddal az `aspose.slides.nodejs` mappában:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Most futtassa a `node hello.js` parancsot a parancssorban.

{{% alert color="primary" %}}
Kérjük, használja a következő [cikket](https://docs.aspose.com/slides/hu/nodejs-java/troubleshooting-installation/), ha összeállítási hibákkal találkozik az Aspose.Slides for Node.js via Java telepítése során.
{{% /alert %}}

## **GYIK**

**Van ingyenes verzió vagy próbaidőkorlát?**

Igen, alapértelmezés szerint az Aspose.Slides értékelési módban fut, amely vízjelet helyez el, és egyéb korlátozások is lehetnek. A korlátozások eltávolításához alkalmazzon érvényes [licencet](/slides/hu/nodejs-java/licensing/).