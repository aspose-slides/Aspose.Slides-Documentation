---
title: Installieren Sie Aspose.Slides für Node.js über Java mit Docker
type: docs
weight: 75
url: /de/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- Aspose.Slides herunterladen
- Aspose.Slides installieren
- Aspose.Slides Installation
- Docker
- Windows
- macOS
- Linux
- Plattformübergreifende Kompatibilität
- Abhängigkeitsisolierung
- Vereinfachte Bereitstellung
- Projekteinrichtung
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Führen Sie Aspose.Slides in Docker-Containern aus: Konfigurieren Sie Images, Abhängigkeiten, Schriftarten und Lizenzen, um skalierbare Dienste zu erstellen, die PowerPoint- und OpenDocument-Dateien verarbeiten."
---

## Voraussetzungen:
* Installieren Sie Docker auf Ihrem Rechner. Sie können der offiziellen Installationsanleitung [hier](https://docs.docker.com/get-docker/) folgen.

## Schritte:

### 1. **Dockerfile erstellen** 
   Erstellen Sie eine neue Datei mit dem Namen Dockerfile in Ihrem Projektverzeichnis mit folgendem Inhalt:
   ```
   # Verwenden Sie Ubuntu 20.04 als Basis-Image
   FROM ubuntu:20.04

   # Aktualisieren Sie die Paketliste und installieren Sie erforderliche Pakete zum Hinzufügen von Repositorys und zum Herunterladen von Dateien
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Installieren Sie Node.js Version 18.x aus dem Nodesource-Repository
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Installieren Sie Python 2.x, das von einigen npm-Paketen wie node-gyp benötigt wird
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Installieren Sie OpenJDK 11, das für die Java-Abhängigkeiten von Aspose.Slides erforderlich ist
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Installieren Sie das Paket build-essential, das Werkzeuge wie 'make' enthält, die zum Erstellen nativer Module erforderlich sind
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Installieren Sie node-gyp global, ein Werkzeug zum Kompilieren nativer Add-ons für Node.js
   RUN npm install -g node-gyp

   # Legen Sie das Arbeitsverzeichnis im Container auf /app fest
   WORKDIR /app

   # Erstellen Sie die Datei package.json mit den erforderlichen Details und Abhängigkeiten
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

   # Erstellen Sie die Datei index.js mit Beispielcode zum Erstellen einer Präsentation mit Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Installieren Sie das Aspose.Slides via Java-Paket, das in package.json angegeben ist
   RUN npm install aspose.slides.via.java

   # Legen Sie den Standardbefehl fest, um die Anwendung beim Start des Containers auszuführen
   CMD ["node", "index.js"]
   ```


### 2. **Docker-Image erstellen**
   Führen Sie den folgenden Befehl im Verzeichnis aus, in dem sich Ihre Dockerfile befindet, um das Docker-Image zu erstellen:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```


### 3. **Docker-Container ausführen**
   Starten Sie den Container und speichern Sie dessen ID:
```bash
CONTAINER_ID=$(docker create aspose-slides-nodejs)
docker start -a $CONTAINER_ID
```


### 4. **Auf Aspose.Slides in Docker zugreifen** 
   Nach dem Starten des Containers generiert das Skript eine PPTX-Datei. Sie finden die erzeugte Ausgabedatei `NewPresentation.pptx` im Ordner `/app` im Container:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```

   Entfernen Sie den temporären Container:
```bash
docker rm $CONTAINER_ID
```
