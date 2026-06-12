---
title: Installeer Aspose.Slides voor Node.js via Java met Docker
type: docs
weight: 75
url: /nl/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- installatie van Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- cross-platform compatibiliteit
- isolatie van afhankelijkheden
- vereenvoudigde implementatie
- projectconfiguratie
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Voer Aspose.Slides uit in Docker-containers: configureer images, afhankelijkheden, lettertypen en licenties om schaalbare services te bouwen die PowerPoint- en OpenDocument-bestanden verwerken."
---
## Vereisten:
* Installeer Docker op uw machine. U kunt de officiële installatiehandleiding [hier](https://docs.docker.com/get-docker/) volgen.

## Stappen:

### 1. **Dockerfile maken** 
   Maak een nieuw bestand met de naam Dockerfile in uw projectdirectory met de volgende inhoud:
   ```
   # Use Ubuntu 20.04 as the base image
   FROM ubuntu:20.04

   # Update the package list and install essential packages for adding repositories and downloading files
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Install Node.js version 18.x from Nodesource repository
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Install Python 2.x, which is required by some npm packages like node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Install OpenJDK 11, which is required by Aspose.Slides for Java dependencies
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Install build-essential package, which includes tools like 'make' required for building native modules
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Install node-gyp globally, a tool used to compile native add-ons for Node.js
   RUN npm install -g node-gyp

   # Set the working directory inside the container to /app
   WORKDIR /app

   # Create package.json file with necessary details and dependencies
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

   # Create index.js file with sample code to create a presentation using Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Install the Aspose.Slides via Java package specified in package.json
   RUN npm install aspose.slides.via.java

   # Set the default command to run the application when the container starts
   CMD ["node", "index.js"]
   ```

### 2. **Docker-image bouwen**
   Voer het volgende commando uit in de map waar uw Dockerfile zich bevindt om de Docker-image te bouwen:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Docker-container uitvoeren**
   Start de container en sla het ID op:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Toegang tot Aspose.Slides in Docker** 
   Nadat de container is gestart, genereert het script een PPTX-bestand. U vindt het gegenereerde uitvoerbestand `NewPresentation.pptx` in de map `/app` binnen de container:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Verwijder de tijdelijke container:
   ```bash
   docker rm $CONTAINER_ID
   ```