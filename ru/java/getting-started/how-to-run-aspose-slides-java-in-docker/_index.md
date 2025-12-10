---
title: Как запустить Aspose.Slides для Java в Docker
type: docs
weight: 75
url: /ru/java/how-to-run-aspose-slides-in-docker/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Docker
- Windows
- macOS
- Linux
- кроссплатформенная совместимость
- изоляция зависимостей
- упрощённое развертывание
- настройка проекта
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Запуск Aspose.Slides в контейнерах Docker: настройка образов, зависимостей, шрифтов и лицензий для создания масштабируемых сервисов, обрабатывающих PowerPoint и OpenDocument."
---

## **Введение**

Это руководство объясняет, как контейнеризировать Java‑приложение с использованием Aspose Slides и Docker. Ключевые преимущества включают:

- **Кроссплатформенная совместимость** — работает на Windows, macOS и Linux
- **Изоляция зависимостей** — не требуется установка в системе
- **Упрощённое развертывание** — простое распространение и запуск

## **1. Установка Docker**

### **Windows**

**Требования:**

- Windows 10/11 Pro/Enterprise/Education (64‑разряд) с включённым WSL 2
- Для версии Home: требуется ручная установка WSL 2

**Шаги:**

1. Скачайте [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop/)
2. Запустите установщик и следуйте мастеру настройки
3. Перезагрузите компьютер, когда будет предложено
4. Проверьте установку:
   ```powershell
   docker --version
   ```


### **macOS**

**Требования:**

- macOS 10.15 (Catalina) или новее
- Процессор Apple Silicon или Intel

**Шаги:**

1. Скачайте [Docker Desktop for Mac](https://www.docker.com/products/docker-desktop/)
2. Перетащите приложение в папку `Applications`
3. Запустите Docker и дождитесь инициализации
4. Проверьте установку:
   ```bash
   docker --version
   ```


### **Linux (Ubuntu/Debian)**

**Установка:**
```bash
# Обновить списки пакетов
sudo apt update && sudo apt upgrade -y

# Установить предварительные требования
sudo apt install -y \
    apt-transport-https \
    ca-certificates \
    curl \
    software-properties-common

# Добавить официальный GPG‑ключ Docker
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg

# Добавить стабильный репозиторий
echo "deb [arch=amd64 signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

# Установить Docker Engine
sudo apt update
sudo apt install -y docker-ce docker-ce-cli containerd.io

# Разрешить текущему пользователю выполнять команды Docker
sudo usermod -aG docker $USER
newgrp docker

# Проверить установку
docker --version
```


## **2. Конфигурация Dockerfile**

### **Base Image**
```dockerfile
FROM ubuntu:24.04
```

> **Примечание**: Используется [официальный образ Ubuntu](https://hub.docker.com/_/ubuntu) из Docker Hub.

### **Dependencies**
```dockerfile
RUN apt-get install -y openjdk-11-jdk wget fontconfig ttf-mscorefonts-installer
```

- **OpenJDK 11**: среда выполнения Java
- **Пакеты шрифтов**: включают Microsoft Core Fonts

### **Настройка Aspose.Slides**
```dockerfile
ENV ASPOSE_VERSION=25.3

ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}
```

- Загрузка библиотеки Aspose Slides с фиксированной версией

## **3. Настройка проекта**

### **Структура файлов**
```
aspose-docker/
├── Dockerfile          # Конфигурация контейнера
├── TestAspose.java     # Код приложения
└── output/             # Папка с сгенерированными PDF (создана автоматически)
```


### **Dockerfile**

Создайте файл с именем `Dockerfile` со следующим содержимым:
```dockerfile
FROM ubuntu:24.04

# Установить переменные окружения
ENV JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64
ENV PATH=$JAVA_HOME/bin:$PATH
ENV APP_DIR=/tmp
ENV ASPOSE_VERSION=25.3
ENV ASPOSE_JAR=aspose-slides-${ASPOSE_VERSION}-jdk16.jar
ENV ASPOSE_URL=https://releases.aspose.com/java/repo/com/aspose/aspose-slides/${ASPOSE_VERSION}/${ASPOSE_JAR}

# Создать рабочий каталог
RUN mkdir -p ${APP_DIR}
WORKDIR ${APP_DIR}

# Установить зависимости
RUN apt-get update && \
    apt-get install -y --no-install-recommends \
    openjdk-11-jdk \
    wget \
    fontconfig \
    ttf-mscorefonts-installer && \
    rm -rf /var/lib/apt/lists/*

# Настроить шрифты
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections && \
    apt-get update && \
    apt-get install -y --no-install-recommends ttf-mscorefonts-installer && \
    fc-cache -f -v

# Скачать Aspose.Slides в /tmp
RUN wget ${ASPOSE_URL} -O ${APP_DIR}/${ASPOSE_JAR}

# Скопировать исходный код
COPY TestAspose.java ${APP_DIR}/

# Создать скрипт запуска
RUN echo '#!/bin/bash' > ${APP_DIR}/run.sh && \
    echo 'java --add-opens=java.desktop/sun.java2d=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.awt.image=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     --add-opens=java.desktop/sun.font=ALL-UNNAMED \' >> ${APP_DIR}/run.sh && \
    echo '     -cp ".:'"${ASPOSE_JAR}"'" TestAspose' >> ${APP_DIR}/run.sh && \
    chmod +x ${APP_DIR}/run.sh

# Явно предоставить права на выполнение скрипту
RUN chmod 755 ${APP_DIR}/run.sh

# Скомпилировать Java‑код
RUN javac -cp "${APP_DIR}/${ASPOSE_JAR}" ${APP_DIR}/TestAspose.java

# Установить рабочий каталог
WORKDIR /tmp

CMD ["sh", "-c", "/tmp/run.sh && cp /tmp/output/output.pdf /output"]
```


### **Java‑приложение**

Создайте `TestAspose.java` со следующим содержимым:
```java
import com.aspose.slides.*;

public class TestAspose {
    public static void main(String[] args) throws Exception {
        System.out.println("Creating presentation...");
        
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 190, 300, 25);
            autoShape.getTextFrame().setText("Greetings from Docker!");
            
            presentation.save("/tmp/output/output.pdf", SaveFormat.Pdf);
        } finally {
            if (presentation != null) presentation.dispose();
        }
        System.out.println("Presentation saved as output.pdf");
    }
}
```


## **4. Сборка и запуск**

### **Сборка образа**

Выполните следующую команду в каталоге, где находится ваш Dockerfile, чтобы собрать Docker‑образ:
   ```powershell
   docker build -t aspose-test .
   ```

   
- `-t` задаёт имя образа "aspose-test"
- `.` указывает использовать Dockerfile из текущего каталога

### **Запуск контейнера**

Выполните следующую команду в каталоге, где находится ваш Dockerfile, чтобы запустить Docker‑контейнер:
   ```powershell
   docker run -v "$(pwd)/output:/output" aspose-test
   ```

   
- `-v` монтирует каталог вывода
- Создаёт `output.pdf` в локальном каталоге `output`