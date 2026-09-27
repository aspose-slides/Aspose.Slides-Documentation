---
title: Installatie
type: docs
weight: 70
url: /nl/nodejs-java/installation/
keywords:
- Installeer Aspose.Slides
- Download Aspose.Slides
- Gebruik Aspose.Slides
- Aspose.Slides installatie
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Installeer Aspose.Slides voor Node.js via Java via npm op Windows, Linux en macOS: de JDK, Python en C++-buildtools die het nodig heeft, het npm-commando en een eerste script om de installatie te controleren."
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides voor Node.js via Java installeert op Windows, Linux en macOS, en hoe u kunt controleren of de installatie werkt.

Aspose.Slides for Node.js via Java wordt gedistribueerd als het `aspose.slides.via.java` pakket op npm. Het draait Aspose.Slides in een Java virtual machine via het [`java`](https://github.com/joeferner/node-java) pakket, een native Node.js‑add‑on die npm tijdens de installatie op uw computer compileert. Daarom heeft de installatie, naast Node.js, het volgende nodig:

- **Een Java Development Kit (JDK) 8 of later.** Alleen een Java‑runtime is niet voldoende: de build heeft de header‑bestanden van de JDK nodig.
- **Python 3**, dat door het build‑tool [node-gyp](https://github.com/nodejs/node-gyp) wordt gebruikt.
- **Een C++‑build‑toolchain** voor uw besturingssysteem.

## **Installeer de vereisten**

### **Windows**

1. Installeer [Node.js](https://nodejs.org/en/download) 20 of later.  
1. Installeer een JDK, bijvoorbeeld [Eclipse Temurin](https://adoptium.net/), en stel de omgevingsvariabele `JAVA_HOME` in op de installatiemap. De build gebruikt de JDK waar `JAVA_HOME` naar verwijst.  
1. Installeer [Python 3](https://www.python.org/downloads/).  
1. Installeer [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) met de **Desktop development with C++** workload. Houd de standaardcomponenten van de workload, waaronder **MSVC v143 - VS 2022 C++ x64/x86 build tools** en de **Windows 11 SDK**. Visual Studio 2026 werkt niet: de node‑gyp‑versie waarmee het `java`‑pakket wordt gecompileerd herkent het niet.

### **Linux**

Installeer Node.js 20 of later vanaf [nodejs.org](https://nodejs.org/en/download) of de pakketbron van uw distributie. Installeer vervolgens een JDK, Python 3 en de C++‑build‑tools. Op Debian en Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Op Linux vindt de build de geïnstalleerde JDK zonder extra configuratie. Als er meerdere JDK’s zijn geïnstalleerd, stel `JAVA_HOME` in op degene die u wilt gebruiken.

### **macOS**

Installeer Node.js 20 of later, een JDK en de Xcode Command Line Tools, die Python 3 en de C++‑compiler bevatten. Zie [Troubleshooting Installation](/slides/nl/nodejs-java/troubleshooting-installation/) voor macOS‑specifieke opmerkingen.

## **Installeer via npm**

Maak een projectmap aan en installeer het pakket:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm download Aspose.Slides en compileert de `java`‑bridge, wat enkele minuten kan duren. Als de compilatie mislukt, zie [Troubleshooting Installation](/slides/nl/nodejs-java/troubleshooting-installation/).

## **Controleer de installatie**

Maak een bestand met de naam *hello.js* in de projectmap met de volgende code. Het maakt een presentatie aan, voegt een tekstvak toe aan de eerste dia en slaat het resultaat op als *hello.pptx*:

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

// Aspose.Slides draait in een Java virtual machine die Node.js actief houdt, dus beëindig het proces expliciet.
process.exit(0);
```

Voer het script uit:

```bash
node hello.js
```

Als *hello.pptx* in de projectmap verschijnt, werkt de installatie. De Java‑virtual machine die Aspose.Slides uitvoert voorkomt dat Node.js vanzelf afsluit, waardoor het script eindigt met `process.exit(0)`. [Create Presentations](/slides/nl/nodejs-java/create-presentation/) legt de code uit.

## **Installeer vanuit een ZIP‑archief**

Het pakket is ook beschikbaar als een ZIP‑archief met dezelfde inhoud als het npm‑pakket. Om het vanuit het archief te installeren:

1. Installeer de vereisten voor uw besturingssysteem, zoals hierboven beschreven.  
1. Download het archief vanaf de [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/nl/nodejs-java/).  
1. Maak een projectmap aan:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
```

1. Pak het archief uit in een submap met de naam *aspose.slides.via.java* binnen de projectmap, zodat *package.json* van het archief zich bevindt op *hello-slides/aspose.slides.via.java/package.json*.  
1. Installeer het pakket vanuit die map:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm installeert de `java`‑bridge waarop het pakket afhankelijk is en compileert deze, zoals bij het npm‑pakket.

1. Controleer de installatie zoals beschreven in [Check the Installation](#check-the-installation).

## **FAQ**

**Is er een gratis versie of proefbeperking?**

Ja. Zonder licentie draait Aspose.Slides in evaluatiemodus: het voegt een evaluatiewatermerk toe aan elke dia die wordt opgeslagen en knipt tekst af die uit presentaties wordt gelezen. Om deze beperkingen te verwijderen, past u een geldige [license](/slides/nl/nodejs-java/licensing/) toe.

**Waarom sluit mijn script niet af nadat het klaar is?**

Het `java`‑pakket start een Java‑virtual machine binnen het Node.js‑proces, en die virtual machine houdt het proces actief. Roep `process.exit` aan wanneer uw script zijn werk heeft voltooid.