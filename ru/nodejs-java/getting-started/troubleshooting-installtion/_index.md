---
title: Устранение неполадок при установке Aspose.Slides для Node.js через Java
linktitle: Устранение неполадок при установке
type: docs
weight: 75
url: /ru/nodejs-java/troubleshooting-installation/
keywords:
- загрузка Aspose.Slides
- установка Aspose.Slides
- устранение неполадок установки
- требования к версиям
- Windows
- macOS
- Linux
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Устранение проблем при установке Aspose.Slides для Node.js через Java, исправление распространённых ошибок и зависимостей, обеспечение бесперебойной работы с PPT, PPTX и ODP."
---

При [установке](/slides/ru/nodejs-java/installation/) `aspose.slides.via.java` с помощью `npm` иногда возникают ошибки при компиляции модулей `java` и `node-gyp`. Мы более подробно изучили эти ошибки и определили конкретные требования к версиям установленных программ и пакетов. 

## **Требования к версиям**

1. Для Node.js 12 и ниже:
   - Python версии не выше 3.10.
   - Для Windows рекомендуется установить Visual Studio Build Tools не новее 2017 года.
   - Версия npm‑пакета java: 0.12.1.

2. Для Node.js 13:
   - Те же требования, что и для Node.js 12.

3. Для Node.js 14:
   - Python 3.10.
   - Версия npm‑пакета java: 0.14.0.

4. Для Node.js 15:
   - Python 3.12.
   - Версия npm‑пакета java: 0.14.0.

5. Для Node.js 16 и новее:
   - Python 3.12.
   - Версия npm‑пакета java: 0.14.0.

**Следуйте инструкциям ниже, чтобы установить необходимые программы.**

### **Установка в Unix**

- Установите [Node.js](https://nodejs.org/en/download).
- Установите [Python](https://devguide.python.org/versions/).
- Установите Java (JDK 1.8).
- Установите подходящий набор компиляторов C/C++, например [GCC](https://gcc.gnu.org).

### **Установка в macOS**

- Установите [Node.js](https://nodejs.org/en/download).
- Установите [Python](https://devguide.python.org/versions/).
- Установите Java (JDK 1.8) и измените раздел JVMCapabilities в файле /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist с правами суперпользователя. jdk1.8.x_xxx.jdk зависит от вашей версии JDK. Сделайте это так: 
```
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```

- Установите автономный пакет `Xcode Command Line Tools`, выполнив `xcode-select --install`. -- OR -- При желании, если у вас уже установлен [полный Xcode](https://developer.apple.com/xcode/download/), вы можете установить инструменты командной строки через меню `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Установка в Windows**

- Установите [Node.js](https://nodejs.org/en/download).
- Установите [Python](https://devguide.python.org/versions/) из [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Установите Java (JDK 1.8).
- Установите [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (используйте "Visual C++ build tools", если используете версию старше VS2019, иначе выберите рабочую нагрузку "Desktop development with C++" или [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community) с рабочей нагрузкой "Desktop development with C++").

Убедитесь, что Node.js, Python и Java добавлены в переменную PATH.

## **Установка Aspose.Slides for Node.js via Java на Node.js версии 14 и новее**

Просто выполните команду:
```
npm i aspose.slides.via.java
```


## **Установка Aspose.Slides for Node.js via Java на Node.js версии 12 или 13**

Aspose.Slides for Node.js via Java необходимо установить вручную. Используйте следующую команду:

- Для Node.js 12:
```
npm i java@0.12.1
```

- Для Node.js 13: 
```
npm i java@0.13.0
```


После этого загрузите [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) и распакуйте его в папку `node_modules/aspose.slides.via.java`.

## **Проверка установки**

Для проверки установки создайте файл `index.js` в корне вашего проекта со следующим содержимым:
```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```


Запустите этот файл командой `node index.js`.

## **Дополнительная информация**

В рамках этой статьи невозможно охватить все возможные проблемы. Поскольку проблемы возникают из‑за компиляции модулей `java` и `node-gyp`, ниже приведённые ссылки также будут полезны:
- [установка java](https://www.npmjs.com/package/java#installation) 
- [установка node-gyp](https://www.npmjs.com/package/node-gyp#installation)