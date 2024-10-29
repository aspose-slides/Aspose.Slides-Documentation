---
title: Fehlersuche bei der Installation von Aspose.Slides für Node.js über Java
type: docs
weight: 75
url: /de/nodejs-java/troubleshooting-installation/
keySlides: "Laden Sie Aspose.Slides herunter, Installieren Sie Aspose.Slides, Aspose.Slides Fehlersuche bei der Installation, Windows, macOS, Linux, Javascript, Node.js"
description: "Fehlersuche bei der Installation von Aspose.Slides für Node.js über Java in Windows, Linux oder macOS"
---

Beim [Installieren](/nodejs-java/installation/) von `aspose.slides.via.java` über `npm` treten in einigen Fällen Fehler während der Kompilierung von `java`- und `node-gyp`-Modulen auf. Wir haben diese Fehler genauer untersucht und spezifische Anforderungen für die Versionen der installierten Programme und Pakete identifiziert.

## **Versionsanforderungen**

1. Für Node.js 12 und früher:
   - Python nicht höher als 3.10.
   - Für Windows wird empfohlen, Visual Studio Build Tools nicht neuer als 2017 zu installieren.
   - npm Java-Paketversion: 0.12.1.

2. Für Node.js 13:
   - Dieselben Anforderungen wie für Node.js 12.

3. Für Node.js 14:
   - Python 3.10.
   - npm Java-Paketversion: 0.14.0.

4. Für Node.js 15:
   - Python 3.12.
   - npm Java-Paketversion: 0.14.0.

5. Für Node.js 16 und neuer:
   - Python 3.12.
   - npm Java-Paketversion: 0.14.0.

**Befolgen Sie die folgenden Anweisungen, um die erforderlichen Programme zu installieren.**

### **Installation auf Unix**

- Installieren Sie [Node.js](https://nodejs.org/en/download).
- Installieren Sie [Python](https://devguide.python.org/versions/).
- Installieren Sie Java (JDK 1.8).
- Installieren Sie eine geeignete C/C++ Compiler-Toolchain, wie [GCC](https://gcc.gnu.org).

### **Installation auf macOS**

- Installieren Sie [Node.js](https://nodejs.org/en/download).
- Installieren Sie [Python](https://devguide.python.org/versions/).
- Installieren Sie Java (JDK 1.8) und ändern Sie den JVMCapabilities-Bereich in /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist mit Root-Rechten. jdk1.8.x_xxx.jdk hängt von Ihrer JDK-Version ab. Lassen Sie es folgendermaßen aussehen: 
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
- Installieren Sie die `Xcode Command Line Tools` unabhängig, indem Sie `xcode-select --install` ausführen. -- ODER -- Alternativ, wenn Sie bereits das [vollständige Xcode installiert](https://developer.apple.com/xcode/download/) haben, können Sie die Command Line Tools unter dem Menüpunkt `Xcode -> Open Developer Tool -> More Developer Tools...` installieren.

### **Installation auf Windows**

- Installieren Sie [Node.js](https://nodejs.org/en/download).
- Installieren Sie [Python](https://devguide.python.org/versions/) aus dem [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installieren Sie Java (JDK 1.8).
- Installieren Sie [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (verwenden Sie "Visual C++ Build Tools", wenn Sie eine Version älter als VS2019 verwenden, andernfalls verwenden Sie "Desktopentwicklung mit C++"-Arbeitslast oder [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community), indem Sie die Arbeitslast "Desktopentwicklung mit C++" verwenden).


Stellen Sie sicher, dass Node.js, Python und Java zur PATH-Variable hinzugefügt werden.

## **Installation von Aspose.Slides für Node.js über Java auf Node.js Version 14 und neuer**

Verwenden Sie einfach den Befehl:
```
npm i aspose.slides.via.java
```

## **Installation von Aspose.Slides für Node.js über Java auf Node.js Version 12 oder 13**

Aspose.Slides für Node.js über Java muss manuell installiert werden. Verwenden Sie den folgenden Befehl:

- Für Node.js 12:
```
npm i java@0.12.1
```
- Für Node.js 13: 
```
npm i java@0.13.0
```

Laden Sie danach [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) herunter und entpacken Sie es in den Ordner `node_modules/aspose.slides.via.java`.

## **Überprüfung der Installation**

Um die Installation zu überprüfen, erstellen Sie eine Datei `index.js` im Stammverzeichnis Ihres Projekts mit folgendem Inhalt:

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

Es ist nicht möglich, alle möglichen Probleme im Rahmen dieses Artikels abzudecken. Da Probleme aufgrund der Kompilierung von `java`- und `node-gyp`-Modulen auftreten, sind die folgenden Links ebenfalls nützlich:
- [java installation](https://www.npmjs.com/package/java#installation) 
- [node-gyp installation](https://www.npmjs.com/package/node-gyp#installation)