---
title: Instalace Aspose.Slides pro Node.js pomocí Javy s Dockerem
type: docs
weight: 75
url: /cs/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- instalace Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- kompatibilita napříč platformami
- izolace závislostí
- zjednodušené nasazení
- nastavení projektu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Spusťte Aspose.Slides v Docker kontejnerech: nakonfigurujte obrazy, závislosti, fonty a licencování pro vytváření škálovatelných služeb, které zpracovávají PowerPoint a OpenDocument."
---
## Požadavky:
* Nainstalujte Docker na svůj počítač. Oficiální návod k instalaci najdete [zde](https://docs.docker.com/get-docker/).

## Kroky:

### 1. **Vytvořte Dockerfile** 
   Vytvořte nový soubor pojmenovaný Dockerfile ve vašem projektovém adresáři s následujícím obsahem:
   ```
   # Použijte Ubuntu 20.04 jako základní obraz
   FROM ubuntu:20.04

   # Aktualizujte seznam balíčků a nainstalujte základní balíčky pro přidávání repozitářů a stahování souborů
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Nainstalujte Node.js verze 18.x z repozitáře Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Nainstalujte Python 2.x, který je vyžadován některými npm balíčky jako node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Nainstalujte OpenJDK 11, který je vyžadován Aspose.Slides pro Java závislosti
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Nainstalujte balíček build-essential, který obsahuje nástroje jako 'make' potřebné pro sestavování nativních modulů
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Nainstalujte node-gyp globálně, nástroj používaný k sestavování nativních doplňků pro Node.js
   RUN npm install -g node-gyp

   # Nastavte pracovní adresář uvnitř kontejneru na /app
   WORKDIR /app

   # Vytvořte soubor package.json s potřebnými informacemi a závislostmi
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

   # Vytvořte soubor index.js se vzorovým kódem pro vytvoření prezentace pomocí Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Nainstalujte Aspose.Slides via Java balíček uvedený v package.json
   RUN npm install aspose.slides.via.java

   # Nastavte výchozí příkaz pro spuštění aplikace při startu kontejneru
   CMD ["node", "index.js"]
   ```

### 2. **Vytvořte Docker image**
   Spusťte následující příkaz v adresáři, kde se nachází váš Dockerfile, pro vytvoření Docker image:
   ```bash
   docker build -t aspose-slides-nodejs .
   ```

### 3. **Spusťte Docker kontejner**
   Spusťte kontejner a uložte jeho ID:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```

### 4. **Přístup k Aspose.Slides v Dockeru** 
   Po spuštění kontejneru skript vygeneruje soubor PPTX. Vygenerovaný výstupní soubor `NewPresentation.pptx` najdete ve složce `/app` uvnitř kontejneru:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```
   Odstraňte dočasný kontejner:
   ```bash
   docker rm $CONTAINER_ID
   ```