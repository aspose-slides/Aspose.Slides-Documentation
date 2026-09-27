---
title: Telepítés
type: docs
weight: 70
url: /hu/nodejs-java/installation/
keywords:
  - Aspose.Slides telepítése
  - Aspose.Slides letöltése
  - Aspose.Slides használata
  - Aspose.Slides telepítése
  - Windows
  - Linux
  - macOS
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Telepítse az Aspose.Slides for Node.js via Java csomagot npm‑ről Windows, Linux és macOS rendszereken: a szükséges JDK, Python és C++ build eszközök, az npm parancs, valamint egy első szkript az instaláció ellenőrzéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan telepíthető az Aspose.Slides for Node.js via Java Windows, Linux és macOS operációs rendszereken, valamint hogyan ellenőrizhető, hogy a telepítés működik-e.

Az Aspose.Slides for Node.js via Java a `aspose.slides.via.java` csomagként érhető el az npm-en. A [`java`](https://github.com/joeferner/node-java) csomag segítségével egy Java virtuális gépen futtatja az Aspose.Slides-t; ez egy natív Node.js kiegészítő, amelyet az npm a telepítés során a számítógépen fordít le. Ezért a telepítéshez a Node.js-en kívül a következőkre is szükség van:

- **Java Development Kit (JDK) 8 vagy újabb.** A Java futtatókörnyezet önmagában nem elegendő: a fordításhoz a JDK fejlécfájljaira van szükség.
- **Python 3**, amelyet a [node-gyp](https://github.com/nodejs/node-gyp) build eszköz használ.
- **C++ build eszközkészlet** az operációs rendszerhez.

## **A követelmények telepítése**

### **Windows**

1. Telepítse a [Node.js](https://nodejs.org/en/download) 20 vagy újabb verzióját.  
1. Telepítsen egy JDK‑t, például az [Eclipse Temurin](https://adoptium.net/) verziót, és állítsa be a `JAVA_HOME` környezeti változót a telepítési mappára. A build a `JAVA_HOME` által mutatott JDK‑t használja.  
1. Telepítse a [Python 3](https://www.python.org/downloads/) verziót.  
1. Telepítse a [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) csomagot a **Desktop development with C++** munkaterülettel. Hagyja a munkaterület alapértelmezett összetevőit, amelyek tartalmazzák a **MSVC v143 – VS 2022 C++ x64/x86 build tools** és a **Windows 11 SDK** elemeket. A Visual Studio 2026 nem működik: a `java` csomag által lefordított node‑gyp verzió nem ismeri fel azt.

### **Linux**

Telepítse a Node.js 20 vagy újabb verzióját a [nodejs.org](https://nodejs.org/en/download) oldalról vagy a disztribúciója csomagforrásából. Ezután telepítsen egy JDK‑t, a Python 3‑at és a C++ build eszközöket. Debian és Ubuntu rendszerek esetén:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Linuxon a build automatikusan megtalálja a telepített JDK‑t további konfiguráció nélkül. Ha több JDK van telepítve, állítsa be a `JAVA_HOME` változót arra, amelyet használni szeretne.

### **macOS**

Telepítse a Node.js 20 vagy újabb verzióját, egy JDK‑t, valamint az Xcode Command Line Tools‑t, amelyek tartalmazzák a Python 3‑at és a C++ fordítót. A macOS‑specifikus megjegyzéseket a [Telepítés hibakeresése](/slides/hu/nodejs-java/troubleshooting-installation/) oldalon találja.

## **Telepítés npm‑ből**

Hozzon létre egy projektmappát, és telepítse a csomagot:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

Az npm letölti az Aspose.Slides‑t, és lefordítja a `java` hidat, ami néhány percet vehet igénybe. Ha a fordítás sikertelen, tekintse meg a [Telepítés hibakeresése](/slides/hu/nodejs-java/troubleshooting-installation/) oldalt.

## **A telepítés ellenőrzése**

Hozzon létre egy *hello.js* nevű fájlt a projektmappában a következő kóddal. A kód létrehoz egy prezentációt, szövegdobozt ad az első diára, és *hello.pptx* néven menti el az eredményt:

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

// Az Aspose.Slides egy Java virtuális gépen fut, ami a Node.js futását fenntartja, ezért a folyamatot kifejezetten le kell állítani.
process.exit(0);
```

Futtassa a szkriptet:

```bash
node hello.js
```

Ha a *hello.pptx* megjelenik a projektmappában, a telepítés sikeres. A Java virtuális gép, amely az Aspose.Slides‑t futtatja, megakadályozza, hogy a Node.js önmagától kilépjen, ezért a szkript a `process.exit(0)` utasítással fejeződik be. A [Prezentációk létrehozása](/slides/hu/nodejs-java/create-presentation/) rész magyarázza a kódot.

## **Telepítés ZIP‑archívumból**

A csomag ZIP‑archívumként is elérhető, ugyanazzal a tartalommal, mint az npm csomag. A telepítés az archívumból a következőképpen történik:

1. Telepítse a fenti operációs rendszeréhez szükséges előfeltételeket.  
1. Töltse le az archívumot az [Aspose.Slides for Node.js via Java letöltési oldaláról](https://releases.aspose.com/slides/nodejs-java/).  
1. Hozzon létre egy projektmappát:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Csomagolja ki az archívumot a projektmappán belül egy *aspose.slides.via.java* nevű almappába, úgy, hogy az archívum *package.json* fájlja a *hello-slides/aspose.slides.via.java/package.json* helyen legyen.  
1. Telepítse a csomagot ebből a mappából:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    Az npm telepíti a csomag által használt `java` hidat, és lefordítja, akárcsak az npm csomag esetén.

1. Ellenőrizze a telepítést a [A telepítés ellenőrzése](#check-the-installation) szakaszban leírtak szerint.

## **GYIK**

**Van ingyenes változat vagy próbaidőkorlát?**

Igen. Licenc nélkül az Aspose.Slides értékelő módban fut: minden mentett diára vizuális vízjelet helyez, valamint a bemeneti prezentációkból beolvasott szöveget csonkolja. Ezeknek a korlátozásoknak a feloldásához alkalmazzon érvényes [licencet](/slides/hu/nodejs-java/licensing/).

**Miért nem lép ki a szkript a futás befejezése után?**

A `java` csomag egy Java virtuális gépet indít a Node.js folyamaton belül, és ez a virtuális gép tartja a folyamatot futásban. Hívja meg a `process.exit`-t, amikor a szkript befejezte a munkáját.