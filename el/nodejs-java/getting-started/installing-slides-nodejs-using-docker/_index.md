---
title: Εγκατάσταση Aspose.Slides για Node.js μέσω Java χρησιμοποιώντας Docker
type: docs
weight: 75
url: /el/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- συμβατότητα πολλαπλών πλατφορμών
- απομόνωση εξαρτήσεων
- απλοποιημένη ανάπτυξη
- ρύθμιση έργου
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εκτελέστε Aspose.Slides σε κοντέινερ Docker: διαμορφώστε εικόνες, εξαρτήσεις, γραμματοσειρές και άδειες για να δημιουργήσετε επεκτάσιμες υπηρεσίες που επεξεργάζονται PowerPoint & OpenDocument."
---
## Προαπαιτούμενα:
* Εγκαταστήστε το Docker στον υπολογιστή σας. Μπορείτε να ακολουθήσετε τον επίσημο οδηγό εγκατάστασης [εδώ](https://docs.docker.com/get-docker/).

## Βήματα:

### 1. **Δημιουργήστε Dockerfile** 
   Δημιουργήστε ένα νέο αρχείο με όνομα Dockerfile στον φάκελο του έργου σας με το παρακάτω περιεχόμενο:
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

### 2. **Δομήστε Docker Image**
   Εκτελέστε την παρακάτω εντολή στον φάκελο όπου βρίσκεται το Dockerfile για να δομήσετε την εικόνα Docker:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Εκτελέστε Docker Container**
   Εκτελέστε το container και αποθηκεύστε το αναγνωριστικό του:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Πρόσβαση στο Aspose.Slides στο Docker** 
   Μετά την εκκίνηση του container, το script θα δημιουργήσει ένα αρχείο PPTX. Μπορείτε να βρείτε το παραγόμενο αρχείο εξόδου `NewPresentation.pptx` στο φάκελο `/app` μέσα στο container:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Αφαιρέστε το προσωρινό container:
   ```bash
   docker rm $CONTAINER_ID
   ```