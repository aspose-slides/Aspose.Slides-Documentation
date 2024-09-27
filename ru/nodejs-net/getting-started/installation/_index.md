---
title: Установка
type: docs
weight: 70
url: /ru/nodejs-net/installation/
keySlides: "Скачайте Aspose.Slides, Установите Aspose.Slides, Установка Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Установите Aspose.Slides для Node.js через .NET в Windows, Linux или macOS"
---

Aspose.Slides для Node.js через .NET является независимым от платформы API и может использоваться на любой платформе (Windows, Linux и MacOS), где установлены `Node.js` и мост `edge-js`.

## **Установка из NPM**

Вы можете легко установить Aspose.Slides для Node.js через .NET из [NPM](https://www.npmjs.com/) с помощью этой команды:
```
$ npm install aspose.slides.via.net
```
Если у вас возникли проблемы в процессе установки, пожалуйста, обратитесь к https://www.npmjs.com/package/edge-js.

## **Установка из ZIP-архива**

Для установки и использования Aspose.Slides для Node.js через .NET из ZIP-архива выполните следующие инструкции:

### **Windows**

1. Установите .NET6 или выше.
1. Установите Node.js (https://nodejs.org/en/download/) и добавьте node.exe в `PATH`.
1. Установите edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Скачайте Aspose.Slides для Node.js через .NET](https://releases.aspose.com/slides/nodejs-net/) и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Создайте файл с именем `hello.js` в папке `aspose.slides.nodejs.net`, используя следующий пример кода:

```javascript
// Импортируйте модуль Aspose.Slides для работы с файлами PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Добавьте необходимые классы из asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Создайте и сохраните пустую презентацию для демонстрации основной функциональности
function createEmptyPresentation() {
	
    // Инициализируйте новую пустую презентацию
    var emptyPresentation = new Presentation();
    
    // Сохраните пустую презентацию в формате PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Освободите ресурсы, связанные с презентацией
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Выполните функцию для создания пустой презентации
```

8. Теперь запустите `node hello.js` в командной строке.

### **Linux**

1. Установите .NET6 или выше.
1. Установите Node.js (https://nodejs.org/en/download/) и добавьте node.exe в `PATH`.
1. Установите edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Скачайте Aspose.Slides для Node.js через Java](https://releases.aspose.com/slides/nodejs-net/) и извлеките его в `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Создайте тестовый файл с именем `hello.js`, используя этот пример кода в папке `aspose.slides.nodejs.net`:

```javascript
// Импортируйте модуль Aspose.Slides для работы с файлами PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Добавьте необходимые классы из asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Создайте и сохраните пустую презентацию для демонстрации основной функциональности
function createEmptyPresentation() {
	
    // Инициализируйте новую пустую презентацию
    var emptyPresentation = new Presentation();
    
    // Сохраните пустую презентацию в формате PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Освободите ресурсы, связанные с презентацией
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Выполните функцию для создания пустой презентации
```
7. Теперь запустите `node hello.js` в командной строке.

### **Mac**

1. Установите .NET6 или выше.
1. Установите Node.js (https://nodejs.org/en/download/) и добавьте node.exe в `PATH`.
1. Установите edge-js.

```
$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Импортируйте модуль Aspose.Slides для работы с файлами PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Добавьте необходимые классы из asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Создайте и сохраните пустую презентацию для демонстрации основной функциональности
function createEmptyPresentation() {
	
    // Инициализируйте новую пустую презентацию
    var emptyPresentation = new Presentation();
    
    // Сохраните пустую презентацию в формате PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Освободите ресурсы, связанные с презентацией
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Выполните функцию для создания пустой презентации
```
9. Теперь запустите `node hello.js` в командной строке.