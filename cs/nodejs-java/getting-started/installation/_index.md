---
title: Instalace
type: docs
weight: 70
url: /cs/nodejs-java/installation/
keywords:
- instalovat Aspose.Slides
- stáhnout Aspose.Slides
- použít Aspose.Slides
- instalace Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Instalujte Aspose.Slides pro Node.js prostřednictvím Java z npm na Windows, Linuxu a macOS: JDK, Python a nástroje pro sestavení C++, které jsou potřeba, příkaz npm a první skript pro ověření instalace."
---
## **Přehled**

Tento článek vysvětluje, jak nainstalovat Aspose.Slides pro Node.js prostřednictvím Java na Windows, Linux a macOS a jak ověřit, že instalace funguje.

Aspose.Slides pro Node.js prostřednictvím Java je distribuováno jako balíček `aspose.slides.via.java` na npm. Spouští Aspose.Slides ve virtuálním stroji Java pomocí balíčku[`java`](https://github.com/joeferner/node-java), nativního doplňku Node.js, který npm během instalace zkompiluje ve vašem počítači. Proto instalace kromě Node.js vyžaduje:

- **Java Development Kit (JDK) 8 nebo novější.** Pouze Java runtime nestačí: kompilace vyžaduje hlavičkové soubory JDK.
- **Python 3**, který používá nástroj pro sestavení [node-gyp](https://github.com/nodejs/node-gyp).
- **Sada nástrojů pro sestavení C++** pro váš operační systém.

## **Instalace předpokladů**

### **Windows**

1. Nainstalujte [Node.js](https://nodejs.org/en/download) 20 nebo novější.  
1. Nainstalujte JDK, například [Eclipse Temurin](https://adoptium.net/), a nastavte proměnnou prostředí `JAVA_HOME` na jeho instalační složku. Kompilace používá JDK, na kterou ukazuje `JAVA_HOME`.  
1. Nainstalujte [Python 3](https://www.python.org/downloads/).  
1. Nainstalujte [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) s pracovním zatížením **Desktop development with C++**. Zachovejte výchozí komponenty pracovního zatížení, které zahrnují **MSVC v143 – VS 2022 C++ x64/x86 build tools** a **Windows 11 SDK**. Visual Studio 2026 nefunguje: verze node-gyp, kterou kompiluje balíček `java`, ji nepozná.

### **Linux**

Nainstalujte Node.js 20 nebo novější z [nodejs.org](https://nodejs.org/en/download) nebo z repozitáře vaší distribuce. Poté nainstalujte JDK, Python 3 a nástroje pro sestavení C++. Na Debianu a Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Na Linuxu kompilace najde nainstalované JDK bez další konfigurace. Pokud je nainstalováno více JDK, nastavte `JAVA_HOME` na to, které chcete použít.

### **macOS**

Nainstalujte Node.js 20 nebo novější, JDK a Xcode Command Line Tools, které obsahují Python 3 a kompilátor C++. Podívejte se na [Troubleshooting Installation](/slides/cs/nodejs-java/troubleshooting-installation/) pro specifické poznámky k macOS.

## **Instalace z npm**

Vytvořte projektovou složku a nainstalujte balíček:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm stáhne Aspose.Slides a zkompiluje most `java`, což může trvat několik minut. Pokud kompilace selže, podívejte se na [Troubleshooting Installation](/slides/cs/nodejs-java/troubleshooting-installation/).

## **Ověření instalace**

Vytvořte soubor s názvem *hello.js* v projektové složce s následujícím kódem. Vytvoří prezentaci, přidá textové pole na první snímek a výsledek uloží jako *hello.pptx*:

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

// Aspose.Slides běží ve virtuálním stroji Java, který udržuje Node.js běžet, takže proces ukončete explicitně.
process.exit(0);
```

Spusťte skript:

```bash
node hello.js
```

Pokud se soubor *hello.pptx* objeví v projektové složce, instalace funguje. Virtuální stroj Java, který spouští Aspose.Slides, zabraňuje Node.js ukončit se samostatně, proto skript končí `process.exit(0)`. [Create Presentations](/slides/cs/nodejs-java/create-presentation/) vysvětluje kód.

## **Instalace ze ZIP archivu**

Balíček je také k dispozici jako ZIP archiv se stejným obsahem jako npm balíček. Pro instalaci z archivu:

1. Nainstalujte předpoklady pro svůj operační systém, jak je popsáno výše.  
1. Stáhněte archiv ze [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/nodejs-java/).  
1. Vytvořte projektovou složku:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Rozbalte archiv do podsložky pojmenované *aspose.slides.via.java* uvnitř projektové složky, aby soubor *package.json* z archivu byl v *hello-slides/aspose.slides.via.java/package.json*.  
1. Nainstalujte balíček z této složky:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm nainstaluje most `java`, na kterém balíček závisí, a zkompiluje jej, stejně jako u npm balíčku.  
1. Ověřte instalaci podle popisu v [Check the Installation](#check-the-installation).

## **FAQ**

**Existuje bezplatná verze nebo omezení zkušební verze?**

**Ano.** Bez licence běží Aspose.Slides v evaluačním režimu: přidává na každý uložený snímek vodoznak hodnocení a ořezává text načtený z prezentací. Pro odstranění těchto omezení použijte platnou [licenci](/slides/cs/nodejs-java/licensing/).

**Proč se můj skript neukončí po dokončení?**

Balíček `java` spustí ve procesu Node.js virtuální stroj Java a tento stroj udržuje proces v chodu. Zavolejte `process.exit`, až skript dokončí svou práci.