---
title: Probleemoplossing bij installatie van Aspose.Slides voor Node.js via Java
linktitle: Probleemoplossing installatie
type: docs
weight: 75
url: /nl/nodejs-java/troubleshooting-installation/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- probleemoplossing installatie
- versievereisten
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Los installatieproblemen van Aspose.Slides voor Node.js via Java op, herstel veelvoorkomende fouten en afhankelijkheden, en zorg voor een soepele werking met PPT, PPTX en ODP."
---
## **Inleiding**

Wanneer je [installeren](/slides/nl/nodejs-java/installation/) `aspose.slides.via.java` met `npm` gebruikt, zijn er gevallen waarin fouten optreden tijdens het compileren van de `java`- en `node-gyp`‑modules. We hebben deze fouten nader onderzocht en specifieke vereisten vastgesteld voor de versies van de geïnstalleerde programma's en pakketten. 

## **Versievereisten**

1. Voor Node.js 12 en ouder:
   - Python niet hoger dan 3.10.
   - Voor Windows wordt aanbevolen Visual Studio Build Tools te installeren die niet nieuwer zijn dan 2017.
   - npm‑java‑pakketversie: 0.12.1.

2. Voor Node.js 13:
   - Dezelfde vereisten als voor Node.js 12.

3. Voor Node.js 14:
   - Python 3.10.
   - npm‑java‑pakketversie: 0.14.0.

4. Voor Node.js 15:
   - Python 3.12.
   - npm‑java‑pakketversie: 0.14.0.

5. Voor Node.js 16 en nieuwer:
   - Python 3.12.
   - npm‑java‑pakketversie: 0.14.0.

**Volg de onderstaande instructies om de vereiste programma's te installeren.**

### **Installatie op Unix**

- Installeer [Node.js](https://nodejs.org/en/download).
- Installeer [Python](https://devguide.python.org/versions/).
- Installeer Java (JDK 1.8).
- Installeer een geschikte C/C++‑compilertoolchain, zoals [GCC](https://gcc.gnu.org).

### **Installatie op macOS**

- Installeer [Node.js](https://nodejs.org/en/download).
- Installeer [Python](https://devguide.python.org/versions/).
- Installeer Java (JDK 1.8) en wijzig de JVMCapabilities‑sectie in /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist met root‑rechten. jdk1.8.x_xxx.jdk hangt af van jouw jdk‑versie. Laat het er als volgt uitzien: 
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
- Installeer de `Xcode Command Line Tools` zelfstandig door `xcode-select --install` uit te voeren. -- OF -- Als je al de [volledige Xcode geïnstalleerd](https://developer.apple.com/xcode/download/) hebt, kun je de Command Line Tools installeren via het menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Installatie op Windows**

- Installeer [Node.js](https://nodejs.org/en/download).
- Installeer [Python](https://devguide.python.org/versions/) vanuit de [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installeer Java (JDK 1.8).
- Installeer [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (gebruik "Visual C++ build tools" als je een versie ouder dan VS2019 gebruikt, anders gebruik je de "Desktop development with C++"‑workload of [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) met de "Desktop development with C++"‑workload).

Zorg ervoor dat Node.js, Python en Java aan de PATH‑variabele zijn toegevoegd.

## **Installatie van Aspose.Slides voor Node.js via Java op Node.js‑versie 14 en nieuwer**

Gebruik eenvoudigweg het commando:
```
npm i aspose.slides.via.java
```

## **Installatie van Aspose.Slides voor Node.js via Java op Node.js‑versie 12 of 13**

Aspose.Slides voor Node.js via Java moet handmatig worden geïnstalleerd. Gebruik het volgende commando:

- Voor Node.js 12:
```
npm i java@0.12.1
```
- Voor Node.js 13: 
```
npm i java@0.13.0
```

Download daarna [aspose.slides.via.java](https://releases.aspose.com/slides/nl/nodejs-java/) en pak het uit naar de map `node_modules/aspose.slides.via.java`.

## **Validatie van installatie**

Om de installatie te valideren, maak een bestand `index.js` in de root van je project met de volgende inhoud:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Voer dit bestand uit met het commando `node index.js`.

## **Aanvullende informatie**

Het is niet mogelijk om alle mogelijke problemen binnen de reikwijdte van dit artikel te behandelen. Aangezien de problemen ontstaan door het compileren van `java`- en `node-gyp`‑modules, zijn de volgende links ook nuttig:
- [java‑installatie](https://www.npmjs.com/package/java#installation) 
- [node-gyp‑installatie](https://www.npmjs.com/package/node-gyp#installation)