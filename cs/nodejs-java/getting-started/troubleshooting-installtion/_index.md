---
title: "Řešení problémů s instalací Aspose.Slides pro Node.js pomocí Javy"
linktitle: "Řešení instalace"
type: docs
weight: 75
url: /cs/nodejs-java/troubleshooting-installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- řešení problémů s instalací
- požadavky na verzi
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Řešte problémy s instalací Aspose.Slides pro Node.js pomocí Javy, opravte běžné chyby a závislosti a zajistěte plynulou práci s PPT, PPTX a ODP."
---
## **Úvod**

Při [instalaci](/slides/cs/nodejs-java/installation/) `aspose.slides.via.java` pomocí `npm` se v některých případech vyskytují chyby během kompilace modulů `java` a `node-gyp`. Tyto chyby jsme podrobněji prozkoumali a určili specifické požadavky na verze nainstalovaných programů a balíčků. 

## **Požadavky na verze**

1. Pro Node.js 12 a starší:
   - Python ne vyšší než 3.10.
   - Pro Windows se doporučuje nainstalovat Visual Studio Build Tools nejnovější verze z roku 2017.
   - verze npm balíčku java: 0.12.1.

2. Pro Node.js 13:
   - Stejné požadavky jako pro Node.js 12.

3. Pro Node.js 14:
   - Python 3.10.
   - verze npm balíčku java: 0.14.0.

4. Pro Node.js 15:
   - Python 3.12.
   - verze npm balíčku java: 0.14.0.

5. Pro Node.js 16 a novější:
   - Python 3.12.
   - verze npm balíčku java: 0.14.0.

**Postupujte podle níže uvedených instrukcí a nainstalujte požadované programy.**

### **Instalace na Unixu**

- Nainstalujte [Node.js](https://nodejs.org/en/download).
- Nainstalujte [Python](https://devguide.python.org/versions/).
- Nainstalujte Java (JDK 1.8).
- Nainstalujte vhodný toolchain C/C++ kompilátoru, například [GCC](https://gcc.gnu.org).

### **Instalace na macOS**

- Nainstalujte [Node.js](https://nodejs.org/en/download).
- Nainstalujte [Python](https://devguide.python.org/versions/).
- Nainstalujte Java (JDK 1.8) a upravte sekci JVMCapabilities v souboru /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist s právy root. jdk1.8.x_xxx.jdk závisí na vaší verzi jdk. Výsledek by měl vypadat takto: 
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
- Nainstalujte `Xcode Command Line Tools` samostatně pomocí příkazu `xcode-select --install`. -- NEBO -- Případně, pokud již máte [plně nainstalovaný Xcode](https://developer.apple.com/xcode/download/), můžete nainstalovat Command Line Tools v nabídce `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Instalace ve Windows**

- Nainstalujte [Node.js](https://nodejs.org/en/download).
- Nainstalujte [Python](https://devguide.python.org/versions/) z [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Nainstalujte Java (JDK 1.8).
- Nainstalujte [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (použijte „Visual C++ build tools“, pokud používáte verzi starší než VS2019, jinak použijte pracovní zátěž „Desktop development with C++“ nebo [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) s pracovní zátěží „Desktop development with C++“).

Ujistěte se, že Node.js, Python a Java jsou přidány do proměnné PATH.

## **Instalace Aspose.Slides pro Node.js přes Java na verzi Node.js 14 a novější**

Jednoduše použijte příkaz:
```
npm i aspose.slides.via.java
```

## **Instalace Aspose.Slides pro Node.js přes Java na verzi Node.js 12 nebo 13**

Aspose.Slides pro Node.js přes Java je nutné nainstalovat ručně. Použijte následující příkaz:

- Pro Node.js 12:
```
npm i java@0.12.1
```
- Pro Node.js 13: 
```
npm i java@0.13.0
```

Poté stáhněte [aspose.slides.via.java](https://releases.aspose.com/slides/cs/nodejs-java/) a rozbalte jej do složky `node_modules/aspose.slides.via.java`.

## **Ověření instalace**

Pro ověření instalace vytvořte v kořenovém adresáři projektu soubor `index.js` s následujícím obsahem:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Spusťte tento soubor příkazem `node index.js`.

## **Další informace**

Není možné pokrýt všechny možné problémy v rámci tohoto článku. Jelikož problémy vznikají při kompilaci modulů `java` a `node-gyp`, budou užitečné následující odkazy:
- [instalace java](https://www.npmjs.com/package/java#installation) 
- [instalace node-gyp](https://www.npmjs.com/package/node-gyp#installation)