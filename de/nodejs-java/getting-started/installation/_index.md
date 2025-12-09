---
title: Installation
type: docs
weight: 70
url: /de/nodejs-java/installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides-Installation
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installieren Sie Aspose.Slides für Node.js über Java unter Windows, Linux oder macOS"
---

Aspose.Slides for Node.js via Java ist eine plattformunabhängige API und kann auf jeder Plattform (Windows, Linux und MacOS) verwendet werden, auf der `Node.js` und [`java`](https://www.npmjs.com/package/java) Bridge installiert sind.

## **Installation von NPM**

Sie können Aspose.Slides for Node.js via Java einfach von [NPM](https://www.npmjs.com/) installieren.

1. Erstellen Sie einen neuen Ordner und initiieren Sie ein neues Projekt mit dem folgenden Befehl:
	```
	$ npm init
	```

	
2. Füllen Sie die Felder Titel und Version aus (lassen Sie die übrigen Felder mit ihren Standardwerten).

3. Installieren Sie Aspose.Slides for Node.js via Java mit dem folgenden Befehl:
	```
	$ npm install aspose.slides.via.java
	```


Wenn Sie während des Installationsvorgangs auf ein Problem stoßen, lesen Sie bitte diesen [Artikel](/nodejs-java/troubleshooting-installation/).

**Verwendungsbeispiel**:

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


## **Installation aus ZIP-Archiv**

Um Aspose.Slides for Node.js via Java aus einem ZIP-Archiv zu installieren und zu verwenden, folgen Sie stattdessen diesen Anweisungen:

### **Windows**

1. Installieren Sie JDK8 und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Installieren Sie Node.js (https://nodejs.org/en/download/) und fügen Sie node.exe zum `PATH` hinzu.
1. Installieren Sie node-gyp.
1. Installieren Sie Windows Build Tools.
1. Installieren Sie [`java`](https://www.npmjs.com/package/java) Bridge und führen Sie diese Befehle in der Eingabeaufforderung als Administrator aus:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```

6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) und extrahieren Sie es nach `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Erstellen Sie eine Datei namens `hello.js` im `aspose.slides.nodejs`-Ordner mit dem folgenden Beispielcode:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```


8. Führen Sie nun `node hello.js` in der Eingabeaufforderung aus, um es zu starten.

### **Linux**

1. Installieren Sie Node.js (https://nodejs.org/en/download/).
1. Installieren Sie JDK8 für Linux und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Installieren Sie python 2.x
1. Installieren Sie [`java`](https://www.npmjs.com/package/java) Bridge. Sie können diese Befehle im Terminal ausführen:
```bash
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```

5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) und extrahieren Sie es nach `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Erstellen Sie eine Testdatei namens `hello.js` mit diesem Beispielcode im `aspose.slides.nodejs`-Ordner:
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

7. Führen Sie nun `node hello.js` in der Eingabeaufforderung aus, um es zu starten.

### **Mac**

1. Installieren Sie Node.js (https://nodejs.org/en/download/).
1. Installieren Sie JDK8 für Mac und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Ändern Sie den Abschnitt JVMCapabilities in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` mit Root-Rechten. `jdk1.8.x_xxx.jdk` hängt von Ihrer JDK-Version ab. Es sollte wie folgt aussehen:
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

4. Installieren Sie python 2.x (falls nicht bereits installiert).
5. Installieren Sie Xcode Command Line Tools.
6. Installieren Sie [`java`](https://www.npmjs.com/package/java) Bridge. Sie können die folgenden Befehle im Terminal ausführen:
```bash
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```

7. Laden Sie Aspose.Slides for Node.js via Java herunter und extrahieren Sie es in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Erstellen Sie eine Testdatei namens `hello.js` mit diesem Beispielcode im `aspose.slides.nodejs`-Ordner:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

9. Führen Sie nun `node hello.js` in der Eingabeaufforderung aus, um es zu starten.

{{% alert color="primary" %}}
Bitte verwenden Sie den folgenden [Artikel](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/), wenn Sie während der Installation von Aspose.Slides for Node.js via Java auf Kompilierungsfehler stoßen.
{{% /alert %}}

## **FAQ**

**Gibt es eine kostenlose Version oder eine Testbeschränkung?**

Ja, standardmäßig läuft Aspose.Slides im Evaluierungsmodus, der Wasserzeichen einfügt und möglicherweise weitere Einschränkungen hat. Um die Beschränkungen zu entfernen, müssen Sie eine gültige [Lizenz](/slides/de/nodejs-java/licensing/) anwenden.