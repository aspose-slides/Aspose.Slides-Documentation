---
title: Az Aspose.Slides Node.js Java-n keresztüli telepítésének hibaelhárítása
linktitle: Telepítés hibaelhárítása
type: docs
weight: 75
url: /hu/nodejs-java/troubleshooting-installation/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- telepítés hibaelhárítása
- verziókövetelmények
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides Node.js Java-n keresztüli telepítési problémáit hibaelhárítva, a gyakori hibákat és függőségeket javítva, biztosítva a zökkenőmentes munkát PPT, PPTX és ODP fájlokkal."
---
## **Bevezetés**

Amikor a `npm` segítségével telepíted az `aspose.slides.via.java`-t, előfordulhat, hogy hibák lépnek fel a `java` és a `node-gyp` modulok fordítása során. Részletesebben megvizsgáltuk ezeket a hibákat, és azonosítottuk a telepített programok és csomagok verzióira vonatkozó konkrét követelményeket. 

## **Verziókövetelmények**

1. A Node.js 12 és korábbi verzióihoz:
   - Python 3.10-nél nem magasabb.
   - Windows esetén ajánlott a Visual Studio Build Tools 2017-es vagy annál régebbi verziójának telepítése.
   - npm java csomag verziója: 0.12.1.

2. A Node.js 13-hoz:
   - Ugyanazok a követelmények, mint a Node.js 12 esetében.

3. A Node.js 14-hez:
   - Python 3.10.
   - npm java csomag verziója: 0.14.0.

4. A Node.js 15-höz:
   - Python 3.12.
   - npm java csomag verziója: 0.14.0.

5. A Node.js 16 és újabb verzióihoz:
   - Python 3.12.
   - npm java csomag verziója: 0.14.0.

**Kövesd az alábbi utasításokat a szükséges programok telepítéséhez.**

### **Telepítés Unix rendszeren**

- Telepítsd a [Node.js](https://nodejs.org/en/download) oldalt.
- Telepítsd a [Python](https://devguide.python.org/versions) oldalt.
- Telepítsd a Java (JDK 1.8) környezetet.
- Telepíts egy megfelelő C/C++ fordító láncot, például a [GCC](https://gcc.gnu.org) eszközt.

### **Telepítés macOS rendszeren**

- Telepítsd a [Node.js](https://nodejs.org/en/download) alkalmazást.
- Telepítsd a [Python](https://devguide.python.org/versions) alkalmazást.
- Telepítsd a Java (JDK 1.8) és módosítsd a JVMCapabilities szekciót a /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist fájlban root jogosultsággal. A jdk1.8.x_xxx.jdk a JDK verziódtól függ. Így nézzen ki: 
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
- Telepítsd az `Xcode Command Line Tools` önállóan a `xcode-select --install` parancs futtatásával. -- VAGY -- Alternatívaként, ha már telepítetted a [teljes Xcode](https://developer.apple.com/xcode/download/) programot, a Parancssori Eszközöket a `Xcode -> Open Developer Tool -> More Developer Tools...` menüpont alatt telepítheted.

### **Telepítés Windows rendszeren**

- Telepítsd a [Node.js](https://nodejs.org/en/download) programot.
- Telepítsd a [Python](https://devguide.python.org/versions) programot a [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation) áruházból.
- Telepítsd a Java (JDK 1.8) környezetet.
- Telepítsd a [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (használd a "Visual C++ build tools"‑t, ha a VS2019‑nél régebbi verziót használod, egyébként a "Desktop development with C++" munkaterületet, vagy a [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) verziót a "Desktop development with C++" munkaterülettel).

Győződj meg róla, hogy a Node.js, a Python és a Java a PATH változóhoz hozzá vannak adva.

## **Aspose.Slides telepítése Node.js-hez Java-n keresztül Node.js 14 és újabb verziókon**

Egyszerűen használd a következő parancsot:
```
npm i aspose.slides.via.java
```

## **Aspose.Slides telepítése Node.js-hez Java-n keresztül Node.js 12 vagy 13 verzión**

Az Aspose.Slides for Node.js via Java‑t manuálisan kell telepíteni. Használd a következő parancsot:

- Node.js 12-hoz:
```
npm i java@0.12.1
```
- Node.js 13-hoz: 
```
npm i java@0.13.0
```

Ezután töltsd le a [aspose.slides.via.java](https://releases.aspose.com/slides/hu/nodejs-java/) csomagot, és csomagold ki a `node_modules/aspose.slides.via.java` mappába.

## **A telepítés ellenőrzése**

A telepítés ellenőrzéséhez hozz létre egy `index.js` nevű fájlt a projekt gyökerében a következő tartalommal:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Futtasd ezt a fájlt a `node index.js` paranccsal.

## **További információk**

Nem lehetséges a cikk keretein belül minden lehetséges problémát lefedni. Mivel a problémák a `java` és a `node-gyp` modulok fordításából adódnak, az alábbi hivatkozások is hasznosak lesznek:
- [java telepítés](https://www.npmjs.com/package/java#installation) 
- [node-gyp telepítés](https://www.npmjs.com/package/node-gyp#installation)