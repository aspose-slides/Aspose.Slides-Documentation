---
title: Install Aspose.Slides for Node.js via Java Using Docker
type: docs
weight: 75
url: /nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- Aspose.Slides installation
- Docker
- Windows
- macOS
- Linux
- cross-platform compatibility
- dependency isolation
- simplified deployment
- project setup
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Run Aspose.Slides in Docker containers: configure images, dependencies, fonts, and licensing to build scalable services that process PowerPoint & OpenDocument."
---

## Prerequisites:
* Install Docker on your machine. You can follow the official installation guide [here](https://docs.docker.com/get-docker/).

## Steps:

### 1. **Create Dockerfile** 
   Create a new file named Dockerfile in your project directory with the following content:
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

### 2. **Build Docker Image**
   Run the following command in the directory where your Dockerfile is located to build the Docker image:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Run Docker Container**
   Run the container and save its ID:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Access Aspose.Slides in Docker** 
   After starting the container, the script will generate a PPTX file. You can find the generated output file `NewPresentation.pptx` in the `/app` folder inside the container:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Remove the temporary container:
   ```bash
   docker rm $CONTAINER_ID
   ```