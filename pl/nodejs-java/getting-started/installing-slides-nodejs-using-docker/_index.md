---
title: Zainstaluj Aspose.Slides dla Node.js przy użyciu Java w Dockerze
type: docs
weight: 75
url: /pl/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatybilność wieloplatformowa
- izolacja zależności
- uproszczone wdrożenie
- konfiguracja projektu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Uruchom Aspose.Slides w kontenerach Docker: konfiguruj obrazy, zależności, czcionki i licencjonowanie, aby budować skalowalne usługi przetwarzające PowerPoint i OpenDocument."
---
## Wymagania wstępne:
* Zainstaluj Docker na swoim komputerze. Możesz skorzystać z oficjalnego przewodnika instalacji [tutaj](https://docs.docker.com/get-docker/).

## Kroki:

### 1. **Utwórz Dockerfile** 
   Utwórz nowy plik o nazwie Dockerfile w katalogu projektu z następującą zawartością:
   ```
   # Użyj Ubuntu 20.04 jako obrazu bazowego
   FROM ubuntu:20.04

   # Zaktualizuj listę pakietów i zainstaluj niezbędne pakiety do dodawania repozytoriów oraz pobierania plików
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Zainstaluj Node.js w wersji 18.x z repozytorium Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Zainstaluj Pythona 2.x, który jest wymagany przez niektóre pakiety npm, takie jak node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Zainstaluj OpenJDK 11, który jest wymagany przez Aspose.Slides jako zależności Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Zainstaluj pakiet build-essential, który zawiera narzędzia takie jak 'make' wymagane do budowania natywnych modułów
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Zainstaluj node-gyp globalnie, narzędzie używane do kompilacji natywnych dodatków dla Node.js
   RUN npm install -g node-gyp

   # Ustaw katalog roboczy wewnątrz kontenera na /app
   WORKDIR /app

   # Utwórz plik package.json z niezbędnymi szczegółami i zależnościami
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

   # Utwórz plik index.js z przykładowym kodem do tworzenia prezentacji przy użyciu Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Zainstaluj pakiet Aspose.Slides via Java określony w package.json
   RUN npm install aspose.slides.via.java

   # Ustaw domyślne polecenie uruchamiające aplikację przy starcie kontenera
   CMD ["node", "index.js"]
   ```


### 2. **Zbuduj obraz Docker** 
   Uruchom następujące polecenie w katalogu, w którym znajduje się Twój Dockerfile, aby zbudować obraz Docker:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Uruchom kontener Docker** 
   Uruchom kontener i zapisz jego identyfikator:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Uzyskaj dostęp do Aspose.Slides w Dockerze** 
   Po uruchomieniu kontenera skrypt wygeneruje plik PPTX. Możesz znaleźć wygenerowany plik wyjściowy `NewPresentation.pptx` w folderze `/app` wewnątrz kontenera:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Usuń tymczasowy kontener:
   ```bash
   docker rm $CONTAINER_ID
   ```