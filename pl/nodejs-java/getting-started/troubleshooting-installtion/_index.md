---
title: Rozwiązywanie problemów z instalacją Aspose.Slides dla Node.js przy użyciu Java
linktitle: Rozwiązywanie problemów z instalacją
type: docs
weight: 75
url: /pl/nodejs-java/troubleshooting-installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- rozwiązywanie problemów z instalacją
- wymagania wersji
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Rozwiąż problemy z instalacją Aspose.Slides dla Node.js via Java, napraw typowe błędy i zależności oraz zapewnij płynną pracę z plikami PPT, PPTX i ODP."
---
## **Wprowadzenie**

Podczas [instalacji](/slides/pl/nodejs-java/installation/) `aspose.slides.via.java` przy użyciu `npm` zdarzają się sytuacje, w których występują błędy podczas kompilacji modułów `java` i `node-gyp`. Zbadaliśmy te błędy szczegółowo i zidentyfikowaliśmy konkretne wymagania dotyczące wersji zainstalowanych programów i pakietów. 

## **Wymagania wersji**

1. Dla Node.js 12 i starszych:
   - Python nie wyższy niż 3.10.
   - Dla systemu Windows zaleca się zainstalowanie Visual Studio Build Tools nie nowszych niż 2017.
   - Wersja pakietu npm java: 0.12.1.

2. Dla Node.js 13:
   - Te same wymagania co dla Node.js 12.

3. Dla Node.js 14:
   - Python 3.10.
   - Wersja pakietu npm java: 0.14.0.

4. Dla Node.js 15:
   - Python 3.12.
   - Wersja pakietu npm java: 0.14.0.

5. Dla Node.js 16 i nowszych:
   - Python 3.12.
   - Wersja pakietu npm java: 0.14.0.

**Postępuj zgodnie z poniższymi instrukcjami, aby zainstalować wymagane programy.**

### **Instalacja na Unix**

- Zainstaluj [Node.js](https://nodejs.org/en/download).
- Zainstaluj [Python](https://devguide.python.org/versions/).
- Zainstaluj Java (JDK 1.8).
- Zainstaluj odpowiedni zestaw narzędzi kompilatora C/C++, taki jak [GCC](https://gcc.gnu.org).

### **Instalacja na macOS**

- Zainstaluj [Node.js](https://nodejs.org/en/download).
- Zainstaluj [Python](https://devguide.python.org/versions/).
- Zainstaluj Java (JDK 1.8) i zmodyfikuj sekcję JVMCapabilities w /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist z uprawnieniami administratora. jdk1.8.x_xxx.jdk zależy od twojej wersji jdk. Powinno to wyglądać tak: 
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
- Zainstaluj samodzielnie `Xcode Command Line Tools`, uruchamiając `xcode-select --install`. -- OR -- Alternatywnie, jeśli masz już [pełny Xcode zainstalowany](https://developer.apple.com/xcode/download/), możesz zainstalować Command Line Tools w menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Instalacja w systemie Windows**

- Zainstaluj [Node.js](https://nodejs.org/en/download).
- Zainstaluj [Python](https://devguide.python.org/versions/) ze [Sklepu Microsoft](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Zainstaluj Java (JDK 1.8).
- Zainstaluj [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (używaj "Visual C++ build tools", jeśli korzystasz z wersji starszej niż VS2019, w przeciwnym razie użyj obciążenia "Desktop development with C++" lub [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) z obciążeniem "Desktop development with C++").

Upewnij się, że Node.js, Python i Java zostały dodane do zmiennej PATH.

## **Instalacja Aspose.Slides for Node.js via Java w wersji Node.js 14 i nowszych**

Po prostu użyj polecenia:
```
npm i aspose.slides.via.java
```

## **Instalacja Aspose.Slides for Node.js via Java w wersji Node.js 12 lub 13**

Aspose.Slides for Node.js via Java wymaga ręcznej instalacji. Użyj następującego polecenia:

- Dla Node.js 12:
```
npm i java@0.12.1
```
- Dla Node.js 13:
```
npm i java@0.13.0
```

Następnie pobierz [aspose.slides.via.java](https://releases.aspose.com/slides/pl/nodejs-java/) i rozpakuj go do folderu `node_modules/aspose.slides.via.java`.

## **Weryfikacja instalacji**

Aby zweryfikować instalację, utwórz plik `index.js` w katalogu głównym projektu z następującą treścią:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Uruchom ten plik poleceniem `node index.js`.

## **Dodatkowe informacje**

Nie jest możliwe omówienie wszystkich potencjalnych problemów w ramach tego artykułu. Ponieważ problemy wynikają z kompilacji modułów `java` i `node-gyp`, przydatne będą następujące linki:
- [instalacja java](https://www.npmjs.com/package/java#installation) 
- [instalacja node-gyp](https://www.npmjs.com/package/node-gyp#installation)