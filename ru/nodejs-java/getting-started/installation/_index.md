---
title: Установка
type: docs
weight: 70
url: /ru/nodejs-java/installation/
keySlides: "Скачать Aspose.Slides, Установить Aspose.Slides, Установка Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Установите Aspose.Slides для Node.js через Java в Windows, Linux или macOS"
---

Aspose.Slides для Node.js через Java является независимым от платформы API и может использоваться на любой платформе (Windows, Linux и MacOS), где установлены `Node.js` и мост [`java`](https://www.npmjs.com/package/java).

## **Установка из NPM**

Вы можете легко установить Aspose.Slides для Node.js через Java из [NPM](https://www.npmjs.com/).

Создайте новую папку и инициируйте новый проект, используя следующую команду:
```
$ npm init
```
Заполните поля заголовка и версии (оставьте остальные поля со значениями по умолчанию)

Установите Aspose.Slides для Node.js через Java, используя следующую команду:
```
$ npm install aspose.slides.via.java
```

Если у вас возникли проблемы во время установки, пожалуйста, обратитесь к этой [статье](/nodejs-java/troubleshooting-installation/).

## **Установка из ZIP-архива**

Чтобы установить и использовать Aspose.Slides для Node.js через Java из ZIP-архива, выполните следующие инструкции:

### **Windows**

1. Установите JDK8 и настройте переменную окружения `JAVA_HOME`.
2. Установите Node.js (https://nodejs.org/en/download/) и добавьте node.exe в `PATH`.
3. Установите node-gyp.
4. Установите инструменты сборки Windows.
5. Установите мост [`java`](https://www.npmjs.com/package/java) и выполните следующие команды в командной строке от имени администратора:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [Скачайте Aspose.Slides для Node.js через Java](https://releases.aspose.com/slides/nodejs-java/) и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Создайте файл с именем `hello.js` в папке `aspose.slides.nodejs`, используя следующий пример кода:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Заголовок слайда");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Готово");
```

8. Теперь запустите `node hello.js` в командной строке для выполнения.

### **Linux**

1. Установите Node.js (https://nodejs.org/en/download/).
2. Установите JDK8 для Linux и настройте переменную окружения `JAVA_HOME`.
3. Установите python 2.x.
4. Установите мост [`java`](https://www.npmjs.com/package/java). Вы можете выполнить следующие команды в терминале:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [Скачайте Aspose.Slides для Node.js через Java](https://releases.aspose.com/slides/nodejs-java/) и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Создайте тестовый файл с именем `hello.js`, используя этот пример кода в папке `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Заголовок слайда");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Готово");
```
7. Теперь запустите `node hello.js` в командной строке для выполнения.

### **Mac**

1. Установите Node.js (https://nodejs.org/en/download/).
2. Установите JDK8 для Mac и настройте переменную окружения `JAVA_HOME`.
3. Измените секцию JVMCapabilities в `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` с правами суперпользователя. `jdk1.8.x_xxx.jdk` зависит от вашей версии jdk. Сделайте это похожим на:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
4. Установите python 2.x (если он еще не установлен).
5. Установите инструменты командной строки Xcode.
6. Установите мост [`java`](https://www.npmjs.com/package/java). Вы можете выполнить ниже приведенные команды в терминале:
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. Скачайте Aspose.Slides для Node.js через Java и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Создайте тестовый файл с именем `hello.js`, используя этот пример кода в папке `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Заголовок слайда");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Готово");
```
9. Теперь запустите `node hello.js` в командной строке для выполнения.


{{% alert color="primary" %}}

Пожалуйста, используйте следующую [статью](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/), если вы столкнетесь с ошибками компиляции во время установки Aspose.Slides для Node.js через Java.

{{% /alert %}}