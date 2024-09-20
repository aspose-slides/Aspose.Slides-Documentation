---
title: Устранение неисправностей при установке Aspose.Slides для Node.js через Java
type: docs
weight: 75
url: /nodejs-java/troubleshooting-installation/
keySlides: "Скачивание Aspose.Slides, Установка Aspose.Slides, Устранение неисправностей в Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Устранение неисправностей при установке Aspose.Slides для Node.js через Java в Windows, Linux или macOS"
---

При [установке](/nodejs-java/installation/) `aspose.slides.via.java` с помощью `npm` возникают случаи, когда во время компиляции модулей `java` и `node-gyp` происходят ошибки. Мы более детально исследовали эти ошибки и определили конкретные требования к версиям установленных программ и пакетов.

## **Требования к версиям**

1. Для Node.js 12 и более ранних версий:
   - Python не выше 3.10.
   - Для Windows рекомендуется установить Visual Studio Build Tools не новее 2017 года.
   - Версия npm пакета java: 0.12.1.

2. Для Node.js 13:
   - Те же требования, что и для Node.js 12.

3. Для Node.js 14:
   - Python 3.10.
   - Версия npm пакета java: 0.14.0.

4. Для Node.js 15:
   - Python 3.12.
   - Версия npm пакета java: 0.14.0.

5. Для Node.js 16 и новее:
   - Python 3.12.
   - Версия npm пакета java: 0.14.0.

**Следуйте инструкциям ниже, чтобы установить необходимые программы.**

### **Установка на Unix**

- Установите [Node.js](https://nodejs.org/en/download).
- Установите [Python](https://devguide.python.org/versions/).
- Установите Java (JDK 1.8).
- Установите подходящую цепочку инструментов компилятора C/C++, такую как [GCC](https://gcc.gnu.org).

### **Установка на macOS**

- Установите [Node.js](https://nodejs.org/en/download).
- Установите [Python](https://devguide.python.org/versions/).
- Установите Java (JDK 1.8) и измените раздел JVMCapabilities в /Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist с правами администратора. jdk1.8.x_xxx.jdk зависит от вашей версии jdk. Сделайте это выглядеть так: 
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
- Установите `Xcode Command Line Tools` отдельно, запустив `xcode-select --install`. -- ИЛИ -- Альтернативно, если у вас уже установлена [полная версия Xcode](https://developer.apple.com/xcode/download/), вы можете установить инструменты командной строки в меню `Xcode -> Open Developer Tool -> More Developer Tools...`.

### **Установка на Windows**

- Установите [Node.js](https://nodejs.org/en/download).
- Установите [Python](https://devguide.python.org/versions/) из [Microsoft Store](https://apps.microsoft.com/store/search?publisher=Python+Software+Foundation).
- Установите Java (JDK 1.8).
- Установите [Visual C++ Build Environment](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools) (используя "Visual C++ build tools", если версия старше VS2019, в противном случае используйте рабочую нагрузку "Desktop development with C++" или [Visual Studio Community](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community), используя рабочую нагрузку "Desktop development with C++").

Убедитесь, что Node.js, Python и Java добавлены в переменную PATH.

## **Установка Aspose.Slides для Node.js через Java на версии Node.js 14 и новее**

Просто используйте команду:
```
npm i aspose.slides.via.java
```

## **Установка Aspose.Slides для Node.js через Java на версии Node.js 12 или 13**

Aspose.Slides для Node.js через Java необходимо установить вручную. Используйте следующую команду:

- Для Node.js 12:
```
npm i java@0.12.1
```
- Для Node.js 13: 
```
npm i java@0.13.0
```

После этого скачайте [aspose.slides.via.java](https://releases.aspose.com/slides/nodejs-java/) и извлеките его в папку `node_modules/aspose.slides.via.java`.

## **Проверка установки**

Чтобы проверить установку, создайте файл `index.js` в корне вашего проекта со следующим содержимым:

```javascript
var aspose = aspose || {};
var java = require('java');
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);
slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
presentation.save("lineShape.pptx", aspose.slides.SaveFormat.Pptx);
```

Выполните этот файл с помощью команды `node index.js`.

## **Дополнительная информация**

В рамках этой статьи невозможно охватить все возможные проблемы. Поскольку проблемы возникают из-за компиляции модулей `java` и `node-gyp`, следующие ссылки также будут полезны:
- [установка java](https://www.npmjs.com/package/java#installation) 
- [установка node-gyp](https://www.npmjs.com/package/node-gyp#installation)