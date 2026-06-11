---
title: Felsökning av installation av Aspose.Slides för Node.js via Java
linktitle: Felsökning av installation
type: docs
weight: 75
url: /sv/nodejs-java/troubleshooting-installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- felsökning av installation
- versionskrav
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Felsök installationsproblem för Aspose.Slides för Node.js via Java, åtgärda vanliga fel och beroenden, och säkerställ smidig hantering av PPT, PPTX och ODP."
---
## **Introduktion**

När du [installerar](/slides/sv/nodejs-java/installation/) `aspose.slides.via.java` med `npm` uppstår ibland fel under kompileringen av `java`- och `node-gyp`‑modulerna. Vi har undersökt dessa fel mer i detalj och identifierat specifika krav för versionerna av installerade program och paket. 

## **Versionskrav**

1. För Node.js 12 och tidigare:
   - Python inte högre än 3.10.
   - För Windows rekommenderas att installera Visual Studio Build Tools som inte är nyare än 2017.
   - npm java‑paketversion: 0.12.1.

2. För Node.js 13:
   - Samma krav som för Node.js 12.

3. För Node.js 14:
   - Python 3.10.
   - npm java‑paketversion: 0.14.0.

4. För Node.js 15:
   - Python 3.12.
   - npm java‑paketversion: 0.14.0.

5. För Node.js 16 och nyare:
   - Python 3.12.
   - npm java‑paketversion: 0.14.0.

**Följ instruktionerna nedan för att installera de erforderliga programmen.**

### **Installation på Unix**

- Installera [Node.js](https://nodejs.org/en/download).
- Installera [Python](https://devguide.python.org/versions/).
- Installera Java (JDK 1.8).
- Installera en lämplig C/C++‑kompilatorverktygskedja, exempelvis [GCC](https://gcc.gnu.org).

### **Installation på macOS**

- Installera [Node.js](https://nodejs.org/en/download).
- Installera [Python](https://devguide.python.org/versions/).
- Installera Java (JDK 1.8) och ändra JVMCapabilities‑sektionen i /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist med root‑behörighet. jdk1.8.x_xxx.jdk beror på din JDK‑version. Gör så här: 
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
- Installera de fristående `Xcode Command Line Tools` genom att köra `xcode-select --install`. -- OR -- Alternativt, om du redan har [fullständiga Xcode installerat](https://developer.apple.com/xcode/download/), kan du installera Command Line Tools under menyn `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Installation på Windows**

- Installera [Node.js](https://nodejs.org/en/download).
- Installera [Python](https://devguide.python.org/versions/) från [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installera Java (JDK 1.8).
- Installera [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (använd "Visual C++ build tools" om du använder en version äldre än VS2019, annars använd arbetsbelastningen "Desktop development with C++" eller [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) med arbetsbelastningen "Desktop development with C++").

Se till att Node.js, Python och Java har lagts till i PATH‑variabeln.

## **Installation av Aspose.Slides for Node.js via Java på Node.js‑version 14 och nyare**

Använd helt enkelt kommandot:
```
npm i aspose.slides.via.java
```

## **Installation av Aspose.Slides for Node.js via Java på Node.js‑version 12 eller 13**

Aspose.Slides for Node.js via Java måste installeras manuellt. Använd följande kommando:

- För Node.js 12:
```
npm i java@0.12.1
```
- För Node.js 13: 
```
npm i java@0.13.0
```

Efter det, ladda ner [aspose.slides.via.java](https://releases.aspose.com/slides/sv/nodejs-java/) och extrahera den till mappen `node_modules/aspose.slides.via.java`.

## **Validering av installationen**

För att validera installationen, skapa en fil `index.js` i projektets rot med följande innehåll:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Kör denna fil med kommandot `node index.js`.

## **Ytterligare information**

Det är inte möjligt att täcka alla möjliga problem inom ramen för den här artikeln. Eftersom problemen uppstår på grund av kompileringen av `java`‑ och `node-gyp`‑modulerna kan följande länkar också vara användbara:
- [java‑installation](https://www.npmjs.com/package/java#installation) 
- [node-gyp‑installation](https://www.npmjs.com/package/node-gyp#installation)