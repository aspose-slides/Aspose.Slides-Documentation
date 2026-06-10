---
title: Aspose.Slides telepítése Node.js-hez Java használatával Docker segítségével
type: docs
weight: 75
url: /hu/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítés
- Docker
- Windows
- macOS
- Linux
- keresztplatformos kompatibilitás
- függőség izoláció
- egyszerűsített telepítés
- projekt beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides futtatása Docker konténerekben: képek, függőségek, betűtípusok és licenc beállítása a skálázható szolgáltatások építéséhez, amelyek PowerPoint-ot és OpenDocument-et dolgoznak fel."
---
## Előkövetelmények:
* Telepítse a Docker-t a gépére. Kövesse a hivatalos telepítési útmutatót [itt](https://docs.docker.com/get-docker/).

## Lépések:

### 1. **Dockerfile létrehozása** 
   Hozzon létre egy új fájlt Dockerfile néven a projekt könyvtárában a következő tartalommal:
   ```
   # Használja az Ubuntu 20.04-et alapképként
   FROM ubuntu:20.04

   # Frissíti a csomaglistát és telepíti a szükséges csomagokat tárolók hozzáadásához és fájlok letöltéséhez
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Node.js 18.x verzió telepítése a Nodesource tárolóból
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Python 2.x telepítése, amely néhány npm csomaghoz, például a node-gyp-hez szükséges
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # OpenJDK 11 telepítése, amely az Aspose.Slides Java függőségeihez szükséges
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # build-essential csomag telepítése, amely olyan eszközöket tartalmaz, mint a 'make', a natív modulok építéséhez szükséges
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # node-gyp globális telepítése, egy eszköz a natív kiegészítők Node.js-hez való fordításához
   RUN npm install -g node-gyp

   # A konténeren belüli munkakönyvtár beállítása /app-re
   WORKDIR /app

   # package.json fájl létrehozása a szükséges részletekkel és függőségekkel
   RUN echo '{\n\
     "name": "aspose-slides-app",\n\
     "version": "1.0.0",\n\
     "main": "index.js",\n\
     "scripts": {\n\
      "start": "node index.js"\n\
     },\n\
     "dependencies": {\n\
      "aspose.slides.via.java": "^25.12.0"\n\
     }\n\
   }' > package.json

   # index.js fájl létrehozása minta kóddal az Aspose.Slides használatával prezentáció készítéséhez
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Az Aspose.Slides via Java csomag telepítése a package.json-ban megadottak szerint
   RUN npm install aspose.slides.via.java

   # Alapértelmezett parancs beállítása az alkalmazás futtatásához, amikor a konténer elindul
   CMD ["node", "index.js"]
   ```


### 2. **Docker kép felépítése**
   Futtassa a következő parancsot abban a könyvtárban, ahol a Dockerfile található, a Docker kép felépítéséhez:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Docker tároló indítása**
   Indítsa el a tárolót és mentse el annak azonosítóját:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Aspose.Slides elérése Dockerben** 
   A tároló indítása után a script egy PPTX fájlt generál. A generált kimeneti fájlt, a `NewPresentation.pptx`-et megtalálja a `/app` mappában a tárolón belül:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Távolítsa el az ideiglenes tárolót:
   ```bash
   docker rm $CONTAINER_ID
   ```