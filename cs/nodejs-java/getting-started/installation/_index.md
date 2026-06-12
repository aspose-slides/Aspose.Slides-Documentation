---
title: Instalace
type: docs
weight: 70
url: /cs/nodejs-java/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- používat Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak rychle nainstalovat Aspose.Slides. Průvodce krok za krokem, systémové požadavky a ukázkové kódy — začněte ještě dnes pracovat s prezentacemi PowerPoint!"
---
## **Úvod**

Aspose.Slides pro Node.js prostřednictvím Java je platformně nezávislé API a může být použito na jakékoli platformě (Windows, Linux a macOS), kde jsou nainstalovány `Node.js` a most [`java`](https://www.npmjs.com/package/java) bridge.

## **Instalace z NPM**

Můžete snadno nainstalovat Aspose.Slides pro Node.js prostřednictvím Java z [NPM](https://www.npmjs.com/).

1. Vytvořte nový adresář a inicializujte nový projekt pomocí následujícího příkazu:
	```
	$ npm init
	```
	
2. Vyplňte pole název a verze (zbytek polí ponechte s výchozími hodnotami).

3. Nainstalujte Aspose.Slides pro Node.js prostřednictvím Java pomocí následujícího příkazu:
	```
	$ npm install aspose.slides.via.java
	```

Pokud během instalačního procesu narazíte na jakýkoli problém, podívejte se na tento [článek](/slides/cs/nodejs-java/troubleshooting-installation/).

**Ukázka použití**:

Vytvořte soubor s názvem `hello.js` ve složce projektu a přidejte následující ukázkový kód:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Instalace ze ZIP archivu**

Pro instalaci a použití Aspose.Slides pro Node.js prostřednictvím Java ze ZIP archivu postupujte podle následujících pokynů:

### **Windows**

1. Nainstalujte JDK8 a nakonfigurujte proměnnou prostředí `JAVA_HOME`.
1. Nainstalujte Node.js (https://nodejs.org/en/download/) a přidejte node.exe do `PATH`.
1. Nainstalujte node-gyp.
1. Nainstalujte Windows Build Tools.
1. Nainstalujte most [`java`](https://www.npmjs.com/package/java) bridge a spusťte následující příkazy v příkazovém řádku jako administrátor:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Stáhněte Aspose.Slides pro Node.js prostřednictvím Java](https://releases.aspose.com/slides/cs/nodejs-java/) a rozbalte jej do `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Vytvořte soubor s názvem `hello.js` ve složce `aspose.slides.nodejs` pomocí následujícího ukázkového kódu:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. Nyní spusťte `node hello.js` v příkazovém řádku.

### **Linux**

1. Nainstalujte Node.js (https://nodejs.org/en/download/).
1. Nainstalujte JDK8 pro Linux a nakonfigurujte proměnnou prostředí `JAVA_HOME`.
1. Nainstalujte python 2.x
1. Nainstalujte most [`java`](https://www.npmjs.com/package/java). Můžete spustit následující příkazy v terminálu:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Stáhněte Aspose.Slides pro Node.js prostřednictvím Java](https://releases.aspose.com/slides/cs/nodejs-java/) a rozbalte jej do `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Vytvořte testovací soubor s názvem `hello.js` pomocí tohoto ukázkového kódu ve složce `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Nyní spusťte `node hello.js` v příkazovém řádku.

### **Mac**

1. Nainstalujte Node.js (https://nodejs.org/en/download/).
1. Nainstalujte JDK8 pro Mac a nakonfigurujte proměnnou prostředí `JAVA_HOME`.
1. Upravte sekci JVMCapabilities v `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` s oprávněním root. `jdk1.8.x_xxx.jdk` závisí na verzi vašeho JDK. Výsledek by měl vypadat takto:
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
4. Nainstalujte python 2.x (pokud není nainstalován).
5. Nainstalujte Xcode Command Line Tools.
6. Nainstalujte most [`java`](https://www.npmjs.com/package/java). Můžete spustit následující příkazy v terminálu:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Stáhněte Aspose.Slides pro Node.js prostřednictvím Java a rozbalte jej do `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Vytvořte testovací soubor s názvem `hello.js` pomocí tohoto ukázkového kódu ve složce `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Nyní spusťte `node hello.js` v příkazovém řádku.

{{% alert color="primary" %}}
Použijte následující [článek](https://docs.aspose.com/slides/cs/nodejs-java/troubleshooting-installation/), pokud narazíte na chyby při kompilaci během instalace Aspose.Slides pro Node.js prostřednictvím Java.
{{% /alert %}}

## **Často kladené otázky**

**Existuje bezplatná verze nebo omezení zkušební doby?**

Ano, ve výchozím nastavení Aspose.Slides běží v evaluačním režimu, který přidává vodotisk a může mít další omezení. Pro odstranění omezení musíte použít platnou [licenci](/slides/cs/nodejs-java/licensing/).