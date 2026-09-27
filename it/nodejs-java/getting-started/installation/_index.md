---
title: Installazione
type: docs
weight: 70
url: /it/nodejs-java/installation/
keywords:
- installare Aspose.Slides
- scarica Aspose.Slides
- usa Aspose.Slides
- installazione Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Installa Aspose.Slides per Node.js tramite Java da npm su Windows, Linux e macOS: il JDK, Python e gli strumenti di compilazione C++ necessari, il comando npm e uno script iniziale per verificare l'installazione."
---
## **Panoramica**

Questo articolo spiega come installare Aspose.Slides per Node.js tramite Java su Windows, Linux e macOS e come verificare che l'installazione funzioni.

Aspose.Slides per Node.js tramite Java è distribuito come pacchetto `aspose.slides.via.java` su npm. Esegue Aspose.Slides in una macchina virtuale Java tramite il pacchetto [`java`](https://github.com/joeferner/node-java), un componente aggiuntivo nativo di Node.js che npm compila sul tuo computer durante l'installazione. Per questo l'installazione richiede, oltre a Node.js:

- **Un Java Development Kit (JDK) 8 o successivo.** Un runtime Java da solo non è sufficiente: la compilazione necessita dei file header del JDK.
- **Python 3**, utilizzato dallo strumento di compilazione [node-gyp](https://github.com/nodejs/node-gyp).
- **Una toolchain di compilazione C++** per il tuo sistema operativo.

## **Installa i prerequisiti**

### **Windows**

1. Installa [Node.js](https://nodejs.org/en/download) 20 o successivo.  
1. Installa un JDK, ad esempio [Eclipse Temurin](https://adoptium.net/), e imposta la variabile d'ambiente `JAVA_HOME` sulla cartella di installazione. La compilazione utilizza il JDK a cui punta `JAVA_HOME`.  
1. Installa [Python 3](https://www.python.org/downloads/).  
1. Installa [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) con il carico di lavoro **Desktop development with C++**. Mantieni i componenti predefiniti del carico di lavoro, che includono **MSVC v143 - VS 2022 C++ x64/x86 build tools** e il **Windows 11 SDK**. Visual Studio 2026 non funziona: la versione di node-gyp con cui il pacchetto `java` viene compilato non lo riconosce.

### **Linux**

Installa Node.js 20 o successivo da [nodejs.org](https://nodejs.org/en/download) o dalla sorgente dei pacchetti della tua distribuzione. Quindi installa un JDK, Python 3 e gli strumenti di compilazione C++. Su Debian e Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Su Linux, la compilazione trova il JDK installato senza ulteriori configurazioni. Se sono installati più JDK, imposta `JAVA_HOME` su quello che desideri utilizzare.

### **macOS**

Installa Node.js 20 o successivo, un JDK e gli Xcode Command Line Tools, che includono Python 3 e il compilatore C++. Vedi [Troubleshooting Installation](/slides/it/nodejs-java/troubleshooting-installation/) per note specifiche su macOS.

## **Installa da npm**

Crea una cartella di progetto e installa il pacchetto:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm scarica Aspose.Slides e compila il ponte `java`, operazione che può richiedere alcuni minuti. Se la compilazione fallisce, consulta [Troubleshooting Installation](/slides/it/nodejs-java/troubleshooting-installation/).

## **Verifica l'installazione**

Crea un file chiamato *hello.js* nella cartella del progetto con il seguente codice. Crea una presentazione, aggiunge una casella di testo alla prima diapositiva e salva il risultato come *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides viene eseguito in una macchina virtuale Java che mantiene attivo Node.js, quindi termina il processo esplicitamente.
process.exit(0);
```

Esegui lo script:

```bash
node hello.js
```

Se *hello.pptx* appare nella cartella del progetto, l'installazione funziona. La macchina virtuale Java che esegue Aspose.Slides impedisce a Node.js di terminare autonomamente, per questo lo script termina con `process.exit(0)`. [Create Presentations](/slides/it/nodejs-java/create-presentation/) spiega il codice.

## **Installa da un archivio ZIP**

Il pacchetto è disponibile anche come archivio ZIP con gli stessi contenuti del pacchetto npm. Per installarlo dall'archivio:

1. Installa i prerequisiti per il tuo sistema operativo, come descritto sopra.  
1. Scarica l'archivio dalla [pagina di download di Aspose.Slides per Node.js tramite Java](https://releases.aspose.com/slides/nodejs-java/).  
1. Crea una cartella di progetto:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Estrai l'archivio in una sottocartella chiamata *aspose.slides.via.java* all'interno della cartella di progetto, in modo che il *package.json* dell'archivio si trovi in *hello-slides/aspose.slides.via.java/package.json*.  
1. Installa il pacchetto da quella cartella:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm installa il ponte `java` di cui il pacchetto dipende e lo compila, come avviene per il pacchetto npm.

1. Verifica l'installazione come descritto in [Check the Installation](#check-the-installation).

## **FAQ**

**Esiste una versione gratuita o limitata di prova?**

Sì. Senza licenza, Aspose.Slides funziona in modalità di valutazione: aggiunge una filigrana di valutazione a ogni diapositiva salvata e tronca il testo letto dalle presentazioni. Per rimuovere queste limitazioni, applica una [licenza](/slides/it/nodejs-java/licensing/) valida.

**Perché lo script non termina dopo il completamento?**

Il pacchetto `java` avvia una macchina virtuale Java all'interno del processo Node.js, e quella macchina virtuale mantiene il processo attivo. Chiama `process.exit` quando lo script ha terminato il suo lavoro.