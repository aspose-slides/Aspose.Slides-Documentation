---
title: Установка
type: docs
weight: 70
url: /ru/nodejs-java/installation/
keywords:
- скачать Aspose.Slides
- установить Aspose.Slides
- установка Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Установите Aspose.Slides для Node.js через Java в Windows, Linux или macOS"
---

Aspose.Slides для Node.js через Java — это независимый от платформы API, который можно использовать на любой платформе (Windows, Linux и macOS), где установлены `Node.js` и мост [`java`](https://www.npmjs.com/package/java).

## **Установка из NPM**

Вы можете легко установить Aspose.Slides для Node.js через Java из [NPM](https://www.npmjs.com/).

1. Создайте новую папку и инициализируйте новый проект, используя следующую команду:
	```
	$ npm init
	```
	
2. Заполните поля title и version (оставьте остальные поля со значениями по умолчанию).

3. Установите Aspose.Slides для Node.js через Java, используя следующую команду:
	```
	$ npm install aspose.slides.via.java
	```

Если вы столкнётесь с любой проблемой во время установки, пожалуйста, обратитесь к этой [статье](/nodejs-java/troubleshooting-installation/).

**Пример использования**:

Создайте файл с именем `hello.js` в папке вашего проекта и добавьте следующий пример кода:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Установка из ZIP-архива**

Чтобы установить и использовать Aspose.Slides для Node.js через Java из ZIP‑архива, следуйте этим инструкциям:

### **Windows**

1. Установите JDK8 и настройте переменную окружения `JAVA_HOME`.
1. Установите Node.js (https://nodejs.org/en/download/) и добавьте node.exe в `PATH`.
1. Установите node-gyp.
1. Установите Windows Build Tools.
1. Установите мост [`java`](https://www.npmjs.com/package/java) и выполните эти команды в Command Prompt от имени администратора:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Скачайте Aspose.Slides for Node.js через Java](https://releases.aspose.com/slides/nodejs-java/) и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Создайте файл с именем `hello.js` в папке `aspose.slides.nodejs`, используя следующий пример кода:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
8. Теперь запустите `node hello.js` в командной строке, чтобы выполнить его.

### **Linux**

1. Установите Node.js (https://nodejs.org/en/download/).
1. Установите JDK8 для Linux и настройте переменную окружения `JAVA_HOME`.
1. Установите Python 2.x
1. Установите мост [`java`](https://www.npmjs.com/package/java). Вы можете выполнить эти команды в терминале:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Скачайте Aspose.Slides for Node.js через Java](https://releases.aspose.com/slides/nodejs-java/) и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Создайте тестовый файл с именем `hello.js`, используя этот пример кода в папке `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Теперь запустите `node hello.js` в командной строке, чтобы выполнить его.

### **Mac**

1. Установите Node.js (https://nodejs.org/en/download/).
1. Установите JDK8 для Mac и настройте переменную окружения `JAVA_HOME`.
1. Измените секцию JVMCapabilities в `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` с правами root. `jdk1.8.x_xxx.jdk` зависит от вашей версии jdk. Сделайте её выглядящей так:
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
4. Установите Python 2.x (если он не установлен).
5. Установите Xcode Command Line Tools.
6. Установите мост [`java`](https://www.npmjs.com/package/java). Вы можете выполнить ниже команды в терминале:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Скачайте Aspose.Slides for Node.js через Java и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Создайте тестовый файл с именем `hello.js`, используя этот пример кода в папке `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Теперь запустите `node hello.js` в командной строке, чтобы выполнить его.

{{% alert color="primary" %}}
Пожалуйста, используйте следующую [статью](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/), если вы столкнетесь с ошибками компиляции при установке Aspose.Slides для Node.js через Java.
{{% /alert %}}

## **FAQ**

**Есть ли бесплатная версия или ограничения пробной версии?**

Да, по умолчанию Aspose.Slides работает в режиме оценки, который накладывает водяные знаки и может иметь другие ограничения. Чтобы снять ограничения, необходимо применить действующую [лицензию](/slides/ru/nodejs-java/licensing/).