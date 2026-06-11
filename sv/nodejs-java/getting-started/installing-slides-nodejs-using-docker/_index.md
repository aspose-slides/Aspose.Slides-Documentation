---
title: Installera Aspose.Slides för Node.js via Java med Docker
type: docs
weight: 75
url: /sv/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- Aspose.Slides-installation
- Docker
- Windows
- macOS
- Linux
- plattformoberoende kompatibilitet
- beroendeisolering
- förenklad distribution
- projektuppsättning
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Kör Aspose.Slides i Docker-containrar: konfigurera images, beroenden, teckensnitt och licensiering för att bygga skalbara tjänster som bearbetar PowerPoint och OpenDocument."
---
## Förutsättningar:
* Installera Docker på din maskin. Du kan följa den officiella installationsguiden [here](https://docs.docker.com/get-docker/).

## Steg:

### 1. **Skapa Dockerfile** 
   Skapa en ny fil med namnet Dockerfile i din projektkatalog med följande innehåll:
   ```   
   # Använd Ubuntu 20.04 som basavbild
   FROM ubuntu:20.04

   # Uppdatera paketlistan och installera nödvändiga paket för att lägga till arkiv och ladda ner filer
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Installera Node.js version 18.x från Nodesource-arkivet
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Installera Python 2.x, som krävs av vissa npm-paket som node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Installera OpenJDK 11, som krävs av Aspose.Slides för Java-beroenden
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Installera paketet build-essential, som inkluderar verktyg som 'make' som krävs för att bygga inhemska moduler
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Installera node-gyp globalt, ett verktyg som används för att kompilera inhemska tillägg för Node.js
   RUN npm install -g node-gyp

   # Ställ in arbetskatalogen i containern till /app
   WORKDIR /app

   # Skapa package.json-fil med nödvändiga detaljer och beroenden
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

   # Skapa index.js-fil med exempelkod för att skapa en presentation med Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Installera Aspose.Slides via Java-paketet som anges i package.json
   RUN npm install aspose.slides.via.java

   # Ställ in standardkommandot för att köra applikationen när containern startas
   CMD ["node", "index.js"]
   ```

### 2. **Bygg Docker-image** 
   Kör följande kommando i katalogen där din Dockerfile finns för att bygga Docker-image:n:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Kör Docker-container** 
   Kör containern och spara dess ID:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Åtkomst till Aspose.Slides i Docker** 
   Efter att containern har startats kommer skriptet att generera en PPTX-fil. Du kan hitta den genererade utdatafilen `NewPresentation.pptx` i mappen `/app` inne i containern:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Ta bort den temporära containern:
   ```bash
   docker rm $CONTAINER_ID
   ```