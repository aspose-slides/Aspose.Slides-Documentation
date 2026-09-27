---
title: Установка
type: docs
weight: 70
url: /ru/nodejs-java/installation/
keywords:
- установить Aspose.Slides
- загрузить Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Установите Aspose.Slides для Node.js via Java из npm на Windows, Linux и macOS: требуемые JDK, Python и инструменты сборки C++, команда npm и первый скрипт для проверки установки."
---
## **Обзор**

В этой статье объясняется, как установить Aspose.Slides for Node.js via Java в Windows, Linux и macOS, а также как проверить работоспособность установки.

Aspose.Slides for Node.js via Java распространяется как пакет `aspose.slides.via.java` в npm. Он запускает Aspose.Slides в виртуальной машине Java через пакет [`java`](https://github.com/joeferner/node-java), нативное дополнение Node.js, которое npm компилирует на вашем компьютере во время установки. Поэтому помимо Node.js требуется следующее:

- **Набор разработки Java (JDK) 8 или новее.** Одного лишь Java‑runtime недостаточно: сборке нужны заголовочные файлы JDK.
- **Python 3**, используемый инструментом сборки [node-gyp](https://github.com/nodejs/node-gyp).
- **C++‑toolchain** для вашей операционной системы.

## **Установка предварительных требований**

### **Windows**

1. Установите [Node.js](https://nodejs.org/en/download) 20 или новее.  
1. Установите JDK, например [Eclipse Temurin](https://adoptium.net/), и задайте переменную среды `JAVA_HOME`, указывающую на папку установки. Сборка использует JDK, на который указывает `JAVA_HOME`.  
1. Установите [Python 3](https://www.python.org/downloads/).  
1. Установите [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) с набором **Desktop development with C++**. Оставьте компоненты по умолчанию, включая **MSVC v143 – VS 2022 C++ x64/x86 build tools** и **Windows 11 SDK**. Visual Studio 2026 не работает: версия node-gyp, с которой компилируется пакет `java`, её не распознаёт.

### **Linux**

Установите Node.js 20 или новее из [nodejs.org](https://nodejs.org/en/download) или из репозитория вашей дистрибуции. Затем установите JDK, Python 3 и C++‑инструменты сборки. В Debian и Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

В Linux сборка автоматически обнаруживает установленный JDK без дополнительной настройки. Если установлено несколько JDK, задайте `JAVA_HOME` указывая нужный.

### **macOS**

Установите Node.js 20 или новее, JDK и инструменты командной строки Xcode, включающие Python 3 и компилятор C++. См. [Troubleshooting Installation](/slides/ru/nodejs-java/troubleshooting-installation/) для специфических замечаний по macOS.

## **Установка из npm**

Создайте папку проекта и установите пакет:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm скачивает Aspose.Slides и компилирует мост `java`, что может занять несколько минут. Если компиляция завершилась неудачно, см. [Troubleshooting Installation](/slides/ru/nodejs-java/troubleshooting-installation/).

## **Проверка установки**

Создайте в папке проекта файл *hello.js* со следующим кодом. Он создаёт презентацию, добавляет текстовое поле на первый слайд и сохраняет результат как *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides работает в виртуальной машине Java, которая удерживает Node.js запущенным, поэтому завершите процесс явно.
process.exit(0);
```

Запустите скрипт:

```bash
node hello.js
```

Если файл *hello.pptx* появился в папке проекта, установка выполнена успешно. Виртуальная машина Java, запущенная Aspose.Slides, не даёт Node.js завершиться автоматически, поэтому скрипт заканчивается вызовом `process.exit(0)`. Подробнее о коде см. в разделе [Create Presentations](/slides/ru/nodejs-java/create-presentation/).

## **Установка из ZIP‑архива**

Пакет также доступен в виде ZIP‑архива, содержащего те же файлы, что и npm‑пакет. Чтобы установить его из архива:

1. Установите предварительные требования для вашей ОС, как описано выше.  
1. Скачайте архив со [страницы загрузки Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/ru/nodejs-java/).  
1. Создайте папку проекта:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

1. Распакуйте архив в подпапку *aspose.slides.via.java* внутри папки проекта, чтобы файл *package.json* архива оказался по пути *hello-slides/aspose.slides.via.java/package.json*.  
1. Установите пакет из этой папки:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm установит мост `java`, от которого зависит пакет, и скомпилирует его, как это происходит при установке из npm.

1. Проверьте установку, как описано в разделе [Check the Installation](#check-the-installation).

## **FAQ**

**Существует ли бесплатная версия или ограничения пробного периода?**

Да. Без лицензии Aspose.Slides работает в режиме оценки: на каждый сохранённый слайд добавляется водяной знак «evaluation», а текст из презентаций обрезается. Чтобы снять эти ограничения, примените действующую [лицензию](/slides/ru/nodejs-java/licensing/).

**Почему скрипт не завершается после окончания выполнения?**

Пакет `java` запускает виртуальную машину Java внутри процесса Node.js, и эта машина удерживает процесс в работе. Вызовите `process.exit`, когда скрипт завершит свою работу.