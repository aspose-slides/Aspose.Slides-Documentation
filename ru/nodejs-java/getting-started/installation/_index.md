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
description: "Узнайте, как быстро установить Aspose.Slides. Пошаговое руководство, системные требования и примеры кода — начните работать с презентациями PowerPoint уже сегодня!"
---

Aspose.Slides for Node.js via Java — это независимый от платформы API, который можно использовать на любой платформе (Windows, Linux и MacOS), где установлены `Node.js` и мост [`java`](https://www.npmjs.com/package/java).

## **Установка из NPM**

Вы можете легко установить Aspose.Slides for Node.js via Java из [NPM](https://www.npmjs.com/).

1. Create a new folder and initiate a new project using the following command:
	```
	$ npm init
	```

	
2. Fill in the title and version fields (leave the remaining fields with their default values).

3. Install Aspose.Slides for Node.js via Java using the following command:
```
$ npm install aspose.slides.via.java
```


Если вы столкнётесь с любой проблемой во время процесса установки, пожалуйста, обратитесь к этой [статье](/slides/ru/nodejs-java/troubleshooting-installation/).

**Пример использования**:

Create a file named `hello.js` in your project folder and add the following sample code:
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

To install and use Aspose.Slides for Node.js via Java from a ZIP archive, follow these instructions instead:

### **Windows**

1. Install JDK8 and configure `JAVA_HOME` environment variable.
1. Install Node.js (https://nodejs.org/en/download/) and add node.exe to `PATH`.
1. Install node-gyp.
1. Install Windows Build Tools.
1. Install [`java`](https://www.npmjs.com/package/java) bridge and run these commands in Command Prompt as an administrator:
```bash
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```

6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) and extract it to `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Create a file named `hello.js` in `aspose.slides.nodejs` folder using the following sample code:
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

1. Install Node.js (https://nodejs.org/en/download/).
1. Install JDK8 for Linux and configure `JAVA_HOME` environment variable.
1. Install python 2.x
1. Install [`java`](https://www.npmjs.com/package/java) bridge. You can run these commands in terminal:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```

5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) and extract it to `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Create a test file named `hello.js` using this sample code in `aspose.slides.nodejs` folder:
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

1. Install Node.js (https://nodejs.org/en/download/).
1. Install JDK8 for Mac and configure `JAVA_HOME` environment variable.
1. Modify JVMCapabilities section in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` with root privilege. `jdk1.8.x_xxx.jdk` depends on your jdk version. Make it look like this:
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

4. Install python 2.x (if it is not installed).
5. Install Xcode Command Line Tools.
6. Install [`java`](https://www.npmjs.com/package/java) bridge. You can run below commands in terminal:
```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
```

7. Download Aspose.Slides for Node.js via Java and extract it into `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Create a test file named `hello.js` using this sample code in `aspose.slides.nodejs` folder:
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
Пожалуйста, используйте следующую [статью](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/), если вы столкнётесь с ошибками компиляции во время установки Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **FAQ**

**Есть ли бесплатная версия или ограничения пробного периода?**

Да, по умолчанию Aspose.Slides работает в режиме оценки, который добавляет водяные знаки и может иметь другие ограничения. Чтобы снять ограничения, вам необходимо применить действующую [лицензию](/slides/ru/nodejs-java/licensing/).