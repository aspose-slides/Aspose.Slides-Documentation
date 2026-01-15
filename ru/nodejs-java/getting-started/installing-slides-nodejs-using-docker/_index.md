---
title: Установка Aspose.Slides для Node.js через Java с использованием Docker
type: docs
weight: 75
url: /ru/nodejs-java/installing-slides-nodejs-using-docker/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- кросс-платформенная совместимость
- изоляция зависимостей
- упрощенное развертывание
- настройка проекта
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Запустите Aspose.Slides в Docker-контейнерах: настройте образы, зависимости, шрифты и лицензирование для создания масштабируемых сервисов, обрабатывающих PowerPoint и OpenDocument."
---

## Требования:
* Установите Docker на ваш компьютер. Вы можете следовать официальному руководству по установке [здесь](https://docs.docker.com/get-docker/).

## Шаги:

### 1. **Создать Dockerfile** 
   Создайте новый файл с именем Dockerfile в каталоге вашего проекта со следующим содержимым:
   ```
   # Использовать Ubuntu 20.04 в качестве базового образа
   FROM ubuntu:20.04

   # Обновить список пакетов и установить необходимые пакеты для добавления репозиториев и загрузки файлов
   RUN apt-get update && \
      apt-get install -y curl gnupg2 software-properties-common && \
      rm -rf /var/lib/apt/lists/*

   # Установить Node.js версии 18.x из репозитория Nodesource
   RUN curl -fsSL https://deb.nodesource.com/setup_22.x | bash - && \
      apt-get install -y nodejs && \
      rm -rf /var/lib/apt/lists/*

   # Установить Python 2.x, который требуется некоторым npm‑пакетам, например node-gyp
   RUN apt-get update && \
      apt-get install -y python2 && \
      rm -rf /var/lib/apt/lists/*

   # Установить OpenJDK 11, который требуется Aspose.Slides для зависимостей Java
   RUN apt-get update && \
      apt-get install -y openjdk-11-jdk && \
      rm -rf /var/lib/apt/lists/*

   # Установить пакет build-essential, включающий такие инструменты, как 'make', необходимые для сборки нативных модулей
   RUN apt-get update && \
      apt-get install -y build-essential && \
      rm -rf /var/lib/apt/lists/*

   # Установить node-gyp глобально, инструмент для компиляции нативных аддонов для Node.js
   RUN npm install -g node-gyp

   # Задать рабочий каталог внутри контейнера как /app
   WORKDIR /app

   # Создать файл package.json с необходимыми данными и зависимостями
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

   # Создать файл index.js с примером кода для создания презентации с помощью Aspose.Slides
   RUN echo 'const slides = require("aspose.slides.via.java");\n\
   var presentation = new slides.Presentation();\n\
   var slide = presentation.getSlides().get_Item(0);\n\
   slide.getShapes().addAutoShape(slides.ShapeType.Line, 50, 150, 300, 0);\n\
   presentation.save("./NewPresentation.pptx", slides.SaveFormat.Pptx);\n\
   console.log("Script completed, please check file /app/NewPresentation.pptx!");' > index.js

   # Установить пакет Aspose.Slides via Java, указанный в package.json
   RUN npm install aspose.slides.via.java

   # Установить команду по умолчанию для запуска приложения при старте контейнера
   CMD ["node", "index.js"]
   ```


### 2. **Собрать Docker‑образ**
   Выполните следующую команду в каталоге, где находится ваш Dockerfile, чтобы собрать Docker‑образ:
```bash
docker build -t aspose-slides-nodejs .
```


### 3. **Запустить Docker‑контейнер**
   Запустите контейнер и сохраните его ID:
   ```bash
   CONTAINER_ID=$(docker create aspose-slides-nodejs)
   docker start -a $CONTAINER_ID
   ```


### 4. **Доступ к Aspose.Slides в Docker** 
   После запуска контейнера скрипт сгенерирует файл PPTX. Вы можете найти сгенерированный файл `NewPresentation.pptx` в папке `/app` внутри контейнера:
   ```bash
   docker cp $CONTAINER_ID:/app/NewPresentation.pptx ./NewPresentation.pptx
   ```

   Удалите временный контейнер:
```bash
docker rm $CONTAINER_ID
```
