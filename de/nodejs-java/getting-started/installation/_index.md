---
title: Installation
type: docs
weight: 70
url: /de/nodejs-java/installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides Installation
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installieren Sie Aspose.Slides für Node.js via Java unter Windows, Linux oder macOS"
---

Aspose.Slides für Node.js via Java ist eine plattformunabhängige API und kann auf jeder Plattform (Windows, Linux und macOS) verwendet werden, auf der `Node.js` und die [`java`](https://www.npmjs.com/package/java)‑Brücke installiert sind.

## **Installation von NPM**

Sie können Aspose.Slides für Node.js via Java einfach über [NPM](https://www.npmjs.com/) installieren.

1. Erstellen Sie einen neuen Ordner und initialisieren Sie ein neues Projekt mit folgendem Befehl:
	```
	$ npm init
	```
	
2. Füllen Sie die Felder Titel und Version aus (lassen Sie die übrigen Felder mit den Standardwerten).

3. Installieren Sie Aspose.Slides für Node.js via Java mit folgendem Befehl:
	```
	$ npm install aspose.slides.via.java
	```

Falls Sie während des Installationsvorgangs ein Problem haben, lesen Sie bitte diesen [Artikel](/nodejs-java/troubleshooting-installation/).

**Beispiel für die Verwendung**:

Erstellen Sie eine Datei namens `hello.js` in Ihrem Projektordner und fügen Sie den folgenden Beispielcode hinzu:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Installation aus ZIP‑Archiv**

Um Aspose.Slides für Node.js via Java aus einem ZIP‑Archiv zu installieren und zu verwenden, folgen Sie stattdessen diesen Anweisungen:

### **Windows**

1. Installieren Sie JDK8 und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Installieren Sie Node.js (https://nodejs.org/en/download/) und fügen Sie `node.exe` zu `PATH` hinzu.
1. Installieren Sie node-gyp.
1. Installieren Sie Windows Build Tools.
1. Installieren Sie die [`java`](https://www.npmjs.com/package/java)‑Brücke und führen Sie diese Befehle in einer als Administrator gestarteten Eingabeaufforderung aus:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Laden Sie Aspose.Slides für Node.js via Java herunter](https://releases.aspose.com/slides/nodejs-java/) und extrahieren Sie es nach `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Erstellen Sie eine Datei namens `hello.js` im Ordner `aspose.slides.nodejs` mit folgendem Beispielcode:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Jetzt führen Sie `node hello.js` in der Eingabeaufforderung aus.

### **Linux**

1. Installieren Sie Node.js (https://nodejs.org/en/download/).
1. Installieren Sie JDK8 für Linux und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Installieren Sie Python 2.x
1. Installieren Sie die [`java`](https://www.npmjs.com/package/java)‑Brücke. Führen Sie diese Befehle im Terminal aus:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Laden Sie Aspose.Slides für Node.js via Java herunter](https://releases.aspose.com/slides/nodejs-java/) und extrahieren Sie es nach `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Erstellen Sie eine Testdatei namens `hello.js` mit diesem Beispielcode im Ordner `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Jetzt führen Sie `node hello.js` in der Eingabeaufforderung aus.

### **Mac**

1. Installieren Sie Node.js (https://nodejs.org/en/download/).
1. Installieren Sie JDK8 für macOS und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Ändern Sie den Abschnitt `JVMCapabilities` in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` mit Administratorrechten. `jdk1.8.x_xxx.jdk` hängt von Ihrer JDK‑Version ab. Er sollte folgendermaßen aussehen:
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
4. Installieren Sie Python 2.x (falls nicht vorhanden).
5. Installieren Sie die Xcode Command Line Tools.
6. Installieren Sie die [`java`](https://www.npmjs.com/package/java)‑Brücke. Führen Sie die folgenden Befehle im Terminal aus:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Laden Sie Aspose.Slides für Node.js via Java herunter und extrahieren Sie es in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Erstellen Sie eine Testdatei namens `hello.js` mit diesem Beispielcode im Ordner `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Jetzt führen Sie `node hello.js` in der Eingabeaufforderung aus.


{{% alert color="primary" %}}

Bitte verwenden Sie den folgenden [Artikel](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/), wenn Sie während der Installation von Aspose.Slides für Node.js via Java Kompilierungsfehler erhalten.

{{% /alert %}}

## **FAQ**

**Gibt es eine kostenlose Version oder eine Testbeschränkung?**

Ja, standardmäßig läuft Aspose.Slides im Evaluierungsmodus, der Wasserzeichen einblendet und weitere Einschränkungen haben kann. Um Beschränkungen zu entfernen, müssen Sie eine gültige [Lizenz](/slides/de/nodejs-java/licensing/) anwenden.