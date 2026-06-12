---
title: Installa Aspose.Slides per Node.js tramite Java usando Docker
type: docs
weight: 75
url: /it/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- installazione Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- compatibilità multipiattaforma
- isolamento delle dipendenze
- distribuzione semplificata
- configurazione del progetto
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esegui Aspose.Slides in contenitori Docker: configura immagini, dipendenze, caratteri e licenze per creare servizi scalabili che elaborano PowerPoint e OpenDocument."
---
## Prerequisiti:
* Installa Docker sulla tua macchina. Puoi seguire la guida ufficiale di installazione [qui](https://docs.docker.com/get-docker/).

## Passaggi:

### 1. **Crea Dockerfile**
   Crea un nuovo file chiamato Dockerfile nella directory del tuo progetto con il seguente contenuto:
   ```
   # Usa Ubuntu 20.04 come immagine di base
   FROM ubuntu:20.04

   # Aggiorna l'elenco dei pacchetti e installa i pacchetti essenziali per aggiungere repository e scaricare file
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Installa Node.js versione 18.x dal repository Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Installa Python 2.x, necessario per alcuni pacchetti npm come node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Installa OpenJDK 11, necessario per le dipendenze Java di Aspose.Slides
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Installa il pacchetto build-essential, che include strumenti come 'make' necessari per compilare moduli nativi
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Installa node-gyp globalmente, uno strumento usato per compilare componenti aggiuntivi nativi per Node.js
   RUN npm install -g node-gyp

   # Imposta la directory di lavoro nel contenitore su /app
   WORKDIR /app

   # Crea il file package.json con i dettagli e le dipendenze necessari
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

   # Crea il file index.js con codice di esempio per creare una presentazione usando Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Installa il pacchetto Aspose.Slides via Java specificato in package.json
   RUN npm install aspose.slides.via.java

   # Imposta il comando predefinito per eseguire l'applicazione quando il contenitore avvia
   CMD ["node", "index.js"]
   ```

### 2. **Crea l'immagine Docker**
   Esegui il comando seguente nella directory in cui si trova il tuo Dockerfile per creare l'immagine Docker:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Esegui il contenitore Docker**
   Avvia il contenitore e salva il suo ID:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Accedi a Aspose.Slides in Docker**
   Dopo aver avviato il contenitore, lo script genererà un file PPTX. Puoi trovare il file di output generato `NewPresentation.pptx` nella cartella `/app` all'interno del contenitore:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Rimuovi il contenitore temporaneo:
   ```bash
   docker rm $CONTAINER_ID
   ```