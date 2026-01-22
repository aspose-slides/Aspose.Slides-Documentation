---
title: Fehlerbehebung bei der Installation von Aspose.Slides für Node.js über Java
linktitle: Fehlerbehebung bei der Installation
type: docs
weight: 75
url: /de/nodejs-java/troubleshooting-installation/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Installation Fehlerbehebung
- Versionsanforderungen
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheben Sie Installationsprobleme von Aspose.Slides für Node.js über Java, lösen Sie häufige Fehler und Abhängigkeiten und gewährleisten einen reibungslosen Umgang mit PPT, PPTX und ODP."
---

Beim [Installieren](/slides/de/nodejs-java/installation/) `aspose.slides.via.java` mit `npm` gibt es Fälle, in denen Fehler bei der Kompilierung der Module `java` und `node-gyp` auftreten. Wir haben diese Fehler genauer untersucht und spezifische Anforderungen an die Versionen der installierten Programme und Pakete ermittelt.

## **Versionsanforderungen**

1. Für Node.js 12 und früher:
   - Python nicht höher als 3.10.
   - Für Windows wird empfohlen, Visual Studio Build Tools nicht neuer als 2017 zu installieren.
   - npm‑java‑Paketversion: 0.12.1.

2. Für Node.js 13:
   - Gleiche Anforderungen wie für Node.js 12.

3. Für Node.js 14:
   - Python 3.10.
   - npm‑java‑Paketversion: 0.14.0.

4. Für Node.js 15:
   - Python 3.12.
   - npm‑java‑Paketversion: 0.14.0.

5. Für Node.js 16 und neuer:
   - Python 3.12.
   - npm‑java‑Paketversion: 0.14.0.

**Befolgen Sie die nachstehenden Anweisungen, um die erforderlichen Programme zu installieren.**

### **Installation unter Unix**

- Installieren Sie [Node.js](https://nodejs.org/en/download).
- Installieren Sie [Python](https://devguide.python.org/versions/).
- Installieren Sie Java (JDK 1.8).
- Installieren Sie eine geeignete C/C++‑Compiler‑Toolchain, z. B. [GCC](https://gcc.gnu.org).

### **Installation unter macOS**

- Installieren Sie [Node.js](https://nodejs.org/en/download).
- Installieren Sie [Python](https://devguide.python.org/versions/).
- Installieren Sie Java (JDK 1.8) und ändern Sie den Abschnitt JVMCapabilities in /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist mit Root‑Privilegien. jdk1.8.x_xxx.jdk hängt von Ihrer JDK‑Version ab. Lassen Sie es wie folgt aussehen:
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```

- Installieren Sie die eigenständigen `Xcode Command Line Tools`, indem Sie `xcode-select --install` ausführen. – ODER – Alternativ, falls Sie bereits das [vollständige Xcode installiert](https://developer.apple.com/xcode/download/) haben, können Sie die Command Line Tools über das Menü `Xcode -> Open Developer Tool -> More Developer Tools...` installieren.

### **Installation unter Windows**

- Installieren Sie [Node.js](https://nodejs.org/en/download).
- Installieren Sie [Python](https://devguide.python.org/versions/) aus dem [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installieren Sie Java (JDK 1.8).
- Installieren Sie [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (verwenden Sie "Visual C++ build tools", wenn Sie eine Version älter als VS2019 nutzen, andernfalls verwenden Sie die Arbeitslast "Desktop development with C++" oder [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) mit der Arbeitslast "Desktop development with C++").

Stellen Sie sicher, dass Node.js, Python und Java zur PATH‑Variable hinzugefügt wurden.

## **Installation von Aspose.Slides für Node.js über Java bei Node.js-Version 14 und neuer**

Verwenden Sie einfach den Befehl:
```
npm i aspose.slides.via.java
```


## **Installation von Aspose.Slides für Node.js über Java bei Node.js-Version 12 oder 13**

Aspose.Slides für Node.js über Java muss manuell installiert werden. Verwenden Sie den folgenden Befehl:

- Für Node.js 12:
```
npm i java@0.12.1
```

- Für Node.js 13:
```
npm i java@0.13.0
```


Danach laden Sie [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) herunter und entpacken es in den Ordner `node_modules/aspose.slides.via.java`.

## **Validierung der Installation**

Um die Installation zu validieren, erstellen Sie eine Datei `index.js` im Stammverzeichnis Ihres Projekts mit folgendem Inhalt:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```


Führen Sie diese Datei mit dem Befehl `node index.js` aus.

## **Zusätzliche Informationen**

Es ist nicht möglich, alle möglichen Probleme im Rahmen dieses Artikels abzudecken. Da Probleme aufgrund der Kompilierung der Module `java` und `node-gyp` auftreten, sind die folgenden Links ebenfalls hilfreich:
- [java-Installation](https://www.npmjs.com/package/java#installation)
- [node-gyp-Installation](https://www.npmjs.com/package/node-gyp#installation)