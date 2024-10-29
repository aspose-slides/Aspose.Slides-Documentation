---
title: Installation
type: docs
weight: 70
url: /de/nodejs-java/installation/
keySlides: "Laden Sie Aspose.Slides herunter, Installieren Sie Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, Javascript, Node.js"
description: "Installieren Sie Aspose.Slides für Node.js über Java in Windows, Linux oder macOS"
---

Aspose.Slides für Node.js über Java ist eine plattformunabhängige API und kann auf jeder Plattform (Windows, Linux und MacOS) verwendet werden, auf der `Node.js` und das [`java`](https://www.npmjs.com/package/java) Bridge installiert sind.

## **Installieren von NPM**

Sie können Aspose.Slides für Node.js über Java einfach von [NPM](https://www.npmjs.com/) installieren.

Erstellen Sie einen neuen Ordner und initialisieren Sie ein neues Projekt mit dem folgenden Befehl:
```
$ npm init
```
Füllen Sie die Felder Titel und Version aus (lassen Sie die verbleibenden Felder mit Standardwerten).

Installieren Sie Aspose.Slides für Node.js über Java mit dem folgenden Befehl:
```
$ npm install aspose.slides.via.java
```

Wenn Sie während des Installationsprozesses auf ein Problem stoßen, lesen Sie bitte diesen [Artikel](/nodejs-java/troubleshooting-installation/).

## **Installieren aus ZIP-Archiv**

Um Aspose.Slides für Node.js über Java aus einem ZIP-Archiv zu installieren und zu verwenden, befolgen Sie stattdessen diese Anweisungen:

### **Windows**

1. Installieren Sie JDK8 und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Installieren Sie Node.js (https://nodejs.org/en/download/) und fügen Sie node.exe zum `PATH` hinzu.
1. Installieren Sie node-gyp.
1. Installieren Sie Windows Build Tools.
1. Installieren Sie die [`java`](https://www.npmjs.com/package/java) Bridge und führen Sie diese Befehle in der Eingabaufforderung als Administrator aus:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [Laden Sie Aspose.Slides für Node.js über Java herunter](https://releases.aspose.com/slides/nodejs-java/) und extrahieren Sie es in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Erstellen Sie eine Datei mit dem Namen `hello.js` im Ordner `aspose.slides.nodejs` mit folgendem Beispielcode:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Folientitel");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Fertig");
```

8. Führen Sie nun `node hello.js` in der Eingabaufforderung aus, um es auszuführen.

### **Linux**

1. Installieren Sie Node.js (https://nodejs.org/en/download/).
1. Installieren Sie JDK8 für Linux und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Installieren Sie python 2.x.
1. Installieren Sie die [`java`](https://www.npmjs.com/package/java) Bridge. Sie können diese Befehle im Terminal ausführen:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [Laden Sie Aspose.Slides für Node.js über Java herunter](https://releases.aspose.com/slides/nodejs-java/) und extrahieren Sie es in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Erstellen Sie eine Testdatei mit dem Namen `hello.js` mit diesem Beispielcode im Ordner `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Folientitel");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Fertig");
```
7. Führen Sie nun `node hello.js` in der Eingabaufforderung aus, um es auszuführen.

### **Mac**

1. Installieren Sie Node.js (https://nodejs.org/en/download/).
1. Installieren Sie JDK8 für Mac und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
1. Ändern Sie den Abschnitt JVMCapabilities in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` mit Root-Rechten. `jdk1.8.x_xxx.jdk` hängt von Ihrer JDK-Version ab. Lassen Sie es so aussehen:
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
4. Installieren Sie python 2.x (falls es noch nicht installiert ist).
5. Installieren Sie Xcode Command Line Tools.
6. Installieren Sie die [`java`](https://www.npmjs.com/package/java) Bridge. Sie können die folgenden Befehle im Terminal ausführen:
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. Laden Sie Aspose.Slides für Node.js über Java herunter und extrahieren Sie es in `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Erstellen Sie eine Testdatei mit dem Namen `hello.js` mit diesem Beispielcode im Ordner `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Folientitel");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Fertig");
```
9. Führen Sie nun `node hello.js` in der Eingabaufforderung aus, um es auszuführen.


{{% alert color="primary" %}}

Bitte verwenden Sie den folgenden [Artikel](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/), wenn Sie während der Installation von Aspose.Slides für Node.js über Java auf Kompilierungsfehler stoßen.

{{% /alert %}}