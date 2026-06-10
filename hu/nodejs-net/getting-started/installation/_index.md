---
title: Telepítés
type: docs
weight: 70
url: /hu/nodejs-net/installation/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítés
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Az Aspose.Slides for Node.js via .NET telepítése Windows, Linux vagy macOS rendszeren"
---
Az Aspose.Slides for Node.js via .NET egy platformfüggetlen API, amely bármely platformon (Windows, Linux és macOS) használható, ahol a `Node.js` és az `edge-js` híd telepítve van.

## **Telepítés NPM-ből**

Az Aspose.Slides for Node.js via .NET egyszerűen telepíthető a [NPM](https://www.npmjs.com/) segítségével a következő paranccsal:
```
$ npm install aspose.slides.via.net
```
Ha a telepítési folyamat során bármilyen problémába ütközik, kérjük, tekintse meg a https://www.npmjs.com/package/edge-js címet.

## **Telepítés ZIP archívumból**

Az Aspose.Slides for Node.js via .NET ZIP archívumból történő telepítéséhez és használatához kövesse az alábbi utasításokat:

### **Windows**

1. Telepítsen .NET6-ot vagy újabbat.  
1. Telepítse a Node.js-t (https://nodejs.org/en/download/) és adja hozzá a node.exe-t a `PATH`-hoz.  
1. Telepítse az edge-js-t.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Töltse le az Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/hu/nodejs-net/) és csomagolja ki a `aspose.slides.nodejs/node_modules/aspose.slides.via.net` könyvtárba.  
7. Hozzon létre egy `hello.js` nevű fájlt az `aspose.slides.nodejs.net` mappában a következő példakód felhasználásával:

```javascript
// Az Aspose.Slides modul importálása PowerPoint fájlok kezeléséhez
const asposeSlides = require('aspose.slides.via.net');

// A szükséges osztályok hozzáadása az asposeSlides-ből
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Új üres prezentáció inicializálása
function createEmptyPresentation() {
	
    // Új üres prezentáció inicializálása
    var emptyPresentation = new Presentation();
    
    // Az üres prezentáció mentése PPTX formátumban
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // A prezentációhoz kapcsolódó erőforrások felszabadítása
    emptyPresentation.dispose();
}

createEmptyPresentation(); // A függvény végrehajtása egy üres prezentáció létrehozásához
```

8. Ezután futtassa a `node hello.js` parancsot a parancssorban.

### **Linux**

1. Telepítsen .NET6-ot vagy újabbat.  
1. Telepítse a Node.js-t (https://nodejs.org/en/download/) és adja hozzá a node.exe-t a `PATH`-hoz.  
1. Telepítse az edge-js-t.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Töltse le az Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/hu/nodejs-net/) és csomagolja ki a `aspose.slides.nodejs/node_modules/aspose.slides.via.net` könyvtárba.  
6. Hozzon létre egy `hello.js` nevű tesztfájlt a következő példakóddal az `aspose.slides.nodejs.net` mappában:

```javascript
// Az Aspose.Slides modul importálása PowerPoint fájlok kezeléséhez
const asposeSlides = require('aspose.slides.via.net');

// A szükséges osztályok hozzáadása az asposeSlides-ből
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Új üres prezentáció létrehozása és mentése az alapvető funkcionalitás bemutatásához
function createEmptyPresentation() {
	
    // Új üres prezentáció inicializálása
    var emptyPresentation = new Presentation();
    
    // Az üres prezentáció mentése PPTX formátumban
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // A prezentációhoz kapcsolódó erőforrások felszabadítása
    emptyPresentation.dispose();
}

createEmptyPresentation(); // A függvény végrehajtása egy üres prezentáció létrehozásához
```
7. Ezután futtassa a `node hello.js` parancsot a parancssorban.

### **Mac**

1. Telepítsen .NET6-ot vagy újabbat.  
1. Telepítse a Node.js-t (https://nodejs.org/en/download/) és adja hozzá a node.exe-t a `PATH`-hoz.  
1. Telepítse az edge-js-t.

$ mkdir aspose.slides.nodejs.net
$ cd aspose.slides.nodejs.net
$ npm install edge-js
```

```javascript
// Importálja az Aspose.Slides modult a PowerPoint fájlok kezeléséhez
const asposeSlides = require('aspose.slides.via.net');

// Adja hozzá a szükséges osztályokat az asposeSlides-ből
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Üres prezentáció létrehozása és mentése az alapvető funkcionalitás bemutatásához
function createEmptyPresentation() {
	
    // Új üres prezentáció inicializálása
    var emptyPresentation = new Presentation();
    
    // Üres prezentáció mentése PPTX formátumban
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // A prezentációhoz kapcsolódó erőforrások felszabadítása
    emptyPresentation.dispose();
}

createEmptyPresentation(); // A függvény végrehajtása egy üres prezentáció létrehozásához
9. Ezután futtassa a `node hello.js` parancsot a parancssorban.