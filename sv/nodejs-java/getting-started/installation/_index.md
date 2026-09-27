---
title: Installation
type: docs
weight: 70
url: /sv/nodejs-java/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Installera Aspose.Slides för Node.js via Java från npm på Windows, Linux och macOS: JDK, Python och C++-byggverktyg som krävs, npm-kommandot och ett första skript för att kontrollera installationen."
---
## **Översikt**

Den här artikeln förklarar hur du installerar Aspose.Slides för Node.js via Java på Windows, Linux och macOS, och hur du kontrollerar att installationen fungerar.

Aspose.Slides för Node.js via Java distribueras som paketet `aspose.slides.via.java` på npm. Det kör Aspose.Slides i en Java‑virtuell maskin via paketet [`java`](https://github.com/joeferner/node-java), ett inbyggt Node.js‑tillägg som npm kompilera på din dator under installationen. Därför kräver installationen, förutom Node.js:

- **Ett Java Development Kit (JDK) 8 eller senare.** Enbart en Java‑runtime räcker inte: byggprocessen behöver JDK:ns header‑filer.
- **Python 3**, som byggverktyget [node-gyp](https://github.com/nodejs/node-gyp) använder.
- **En C++‑byggverktygskedja** för ditt operativsystem.

## **Installera förutsättningarna**

### **Windows**

1. Installera [Node.js](https://nodejs.org/en/download) 20 eller senare.
2. Installera ett JDK, till exempel [Eclipse Temurin](https://adoptium.net/), och sätt miljövariabeln `JAVA_HOME` till dess installationsmapp. Byggprocessen använder det JDK som `JAVA_HOME` pekar på.
3. Installera [Python 3](https://www.python.org/downloads/).
4. Installera [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) med arbetsbelastningen **Desktop development with C++**. Behåll arbetsbelastningens standardkomponenter, som inkluderar **MSVC v143 - VS 2022 C++ x64/x86 build tools** och **Windows 11 SDK**. Visual Studio 2026 fungerar inte: den node‑gyp‑version som paketet `java` kompilerar med känner inte igen den.

### **Linux**

Installera Node.js 20 eller senare från [nodejs.org](https://nodejs.org/en/download) eller ditt distributions paketkälla. Installera sedan ett JDK, Python 3 och C++‑byggverktygen. På Debian och Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

På Linux hittar byggprocessen det installerade JDK:t utan ytterligare konfiguration. Om flera JDK:n är installerade, sätt `JAVA_HOME` till det du vill använda.

### **macOS**

Installera Node.js 20 eller senare, ett JDK och Xcode Command Line Tools, som innehåller Python 3 och C++‑kompilatorn. Se [Troubleshooting Installation](/slides/sv/nodejs-java/troubleshooting-installation/) för macOS‑specifika anteckningar.

## **Installera från npm**

Skapa en projektmapp och installera paketet:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm hämtar Aspose.Slides och kompilerar `java`‑bron, vilket kan ta några minuter. Om kompileringen misslyckas, se [Troubleshooting Installation](/slides/sv/nodejs-java/troubleshooting-installation/).

## **Kontrollera installationen**

Skapa en fil med namnet *hello.js* i projektmappen med följande kod. Den skapar en presentation, lägger till en textruta på den första bilden och sparar resultatet som *hello.pptx*:

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

// Aspose.Slides körs i en Java-virtuell maskin som håller Node.js igång, så avsluta processen explicit.
process.exit(0);
```

Kör skriptet:

```bash
node hello.js
```

Om *hello.pptx* visas i projektmappen fungerar installationen. Den Java‑virtuella maskin som kör Aspose.Slides hindrar Node.js från att avslutas själv, vilket är anledningen till att skriptet avslutas med `process.exit(0)`. [Create Presentations](/slides/sv/nodejs-java/create-presentation/) förklarar koden.

## **Installera från ett ZIP‑arkiv**

Paketet finns också som ett ZIP‑arkiv med samma innehåll som npm‑paketet. För att installera det från arkivet:

1. Installera förutsättningarna för ditt operativsystem, enligt beskrivningen ovan.
2. Ladda ner arkivet från [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/sv/nodejs-java/).
3. Skapa en projektmapp:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Extrahera arkivet till en undermapp med namnet *aspose.slides.via.java* i projektmappen, så att arkivets *package.json* ligger på *hello-slides/aspose.slides.via.java/package.json*.
5. Installera paketet från den mappen:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm installerar `java`‑bron som paketet är beroende av och kompilerar den, precis som för npm‑paketet.

6. Kontrollera installationen enligt [Check the Installation](#check-the-installation).

## **FAQ**

**Finns det en gratis version eller provbegränsning?**

Ja. Utan licens kör Aspose.Slides i evalueringsläge: den lägger till ett utvärderingsvattenstämpel på varje bild den sparar och trunkerar text som läses från presentationer. För att ta bort dessa begränsningar, tillämpa en giltig [license](/slides/sv/nodejs-java/licensing/).

**Varför avslutas mitt skript inte när det är klart?**

`java`‑paketet startar en Java‑virtuell maskin inne i Node.js‑processen, och den virtuella maskinen håller processen igång. Anropa `process.exit` när ditt skript har avslutat sitt arbete.