---
title: Risoluzione dei problemi di installazione di Aspose.Slides per Node.js via Java
linktitle: Risoluzione dei problemi
type: docs
weight: 75
url: /it/nodejs-java/troubleshooting-installation/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- risoluzione dei problemi di installazione
- requisiti di versione
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Risolvi i problemi di installazione di Aspose.Slides per Node.js via Java, correggi gli errori comuni e le dipendenze, e garantisci un funzionamento fluido con PPT, PPTX e ODP."
---
## **Introduzione**

Durante l'[installazione](/slides/it/nodejs-java/installation/) `aspose.slides.via.java` usando `npm`, ci sono casi in cui si verificano errori durante la compilazione dei moduli `java` e `node-gyp`. Abbiamo approfondito questi errori e identificato requisiti specifici per le versioni dei programmi e dei pacchetti installati.

## **Requisiti di versione**

1. Per Node.js 12 e versioni precedenti:
   - Python non superiore a 3.10.
   - Per Windows, si consiglia di installare Visual Studio Build Tools non più recenti del 2017.
   - Versione del pacchetto npm java: 0.12.1.

2. Per Node.js 13:
   - Stessi requisiti di Node.js 12.

3. Per Node.js 14:
   - Python 3.10.
   - Versione del pacchetto npm java: 0.14.0.

4. Per Node.js 15:
   - Python 3.12.
   - Versione del pacchetto npm java: 0.14.0.

5. Per Node.js 16 e versioni successive:
   - Python 3.12.
   - Versione del pacchetto npm java: 0.14.0.

**Segui le istruzioni seguenti per installare i programmi richiesti.**

### **Installazione su Unix**

- Installa [Node.js](https://nodejs.org/en/download).
- Installa [Python](https://devguide.python.org/versions/).
- Installa Java (JDK 1.8).
- Installa una toolchain C/C++ appropriata, ad esempio [GCC](https://gcc.gnu.org).

### **Installazione su macOS**

- Installa [Node.js](https://nodejs.org/en/download).
- Installa [Python](https://devguide.python.org/versions/).
- Installa Java (JDK 1.8) e modifica la sezione JVMCapabilities in /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist con privilegi di root. jdk1.8.x_xxx.jdk dipende dalla tua versione di jdk. Falla apparire così:
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
- Installa gli `Xcode Command Line Tools` in modalità standalone eseguendo `xcode-select --install`. -- OR -- In alternativa, se hai già installato il [Xcode completo](https://developer.apple.com/xcode/download/), puoi installare gli Command Line Tools dal menu `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Installazione su Windows**

- Installa [Node.js](https://nodejs.org/en/download).
- Installa [Python](https://devguide.python.org/versions/) dal [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Installa Java (JDK 1.8).
- Installa [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (usando "Visual C++ build tools" se utilizzi una versione precedente a VS2019, altrimenti utilizza il carico di lavoro "Desktop development with C++" o [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) usando il carico di lavoro "Desktop development with C++").

Assicurati che Node.js, Python e Java siano aggiunti alla variabile PATH.

## **Installazione di Aspose.Slides per Node.js via Java su Node.js versione 14 e successive**

Utilizza semplicemente il comando:
```
npm i aspose.slides.via.java
```

## **Installazione di Aspose.Slides per Node.js via Java su Node.js versione 12 o 13**

Aspose.Slides per Node.js via Java deve essere installato manualmente. Usa il comando seguente:

- Per Node.js 12:
```
npm i java@0.12.1
```
- Per Node.js 13:
```
npm i java@0.13.0
```

Successivamente, scarica [aspose.slides.via.java](https://releases.aspose.com/slides/it/nodejs-java/) ed estrailo nella cartella `node_modules/aspose.slides.via.java`.

## **Validazione dell'installazione**

Per convalidare l'installazione, crea un file `index.js` nella radice del tuo progetto con il seguente contenuto:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Esegui questo file con il comando `node index.js`.

## **Informazioni aggiuntive**

Non è possibile coprire tutti i problemi possibili nell'ambito di questo articolo. Poiché i problemi nascono dalla compilazione dei moduli `java` e `node-gyp`, i seguenti link saranno utili:
- [installazione java](https://www.npmjs.com/package/java#installation) 
- [installazione node-gyp](https://www.npmjs.com/package/node-gyp#installation)