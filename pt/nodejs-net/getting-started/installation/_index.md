---
title: Instalação
type: docs
weight: 70
url: /pt/nodejs-net/installation/
keywords:
- baixar Aspose.Slides
- instalar Aspose.Slides
- Instalação do Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Instale Aspose.Slides for Node.js via .NET no Windows, Linux ou macOS"
---
Aspose.Slides for Node.js via .NET é uma API independente de plataforma e pode ser usada em qualquer plataforma (Windows, Linux e MacOS) onde `Node.js` e `edge-js` estão instalados.

## **Instalar via NPM**

Você pode instalar facilmente Aspose.Slides for Node.js via .NET a partir do [NPM](https://www.npmjs.com/) usando este comando:
```
$ npm install aspose.slides.via.net
```
Se você encontrar algum problema durante o processo de instalação, consulte https://www.npmjs.com/package/edge-js.

## **Instalar a partir de arquivo ZIP**

Para instalar e usar Aspose.Slides for Node.js via .NET a partir de um arquivo ZIP, siga estas instruções:

### **Windows**

1. Instale o .NET6 ou superior.
1. Instale o Node.js (https://nodejs.org/en/download/) e adicione node.exe ao `PATH`.
1. Instale o edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Baixe Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/pt/nodejs-net/) e extraia para `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Crie um arquivo chamado `hello.js` na pasta `aspose.slides.nodejs.net` usando o código de exemplo a seguir:

```javascript
// Importa o módulo Aspose.Slides para manipulação de arquivos PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Adiciona as classes necessárias do asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Cria e salva uma apresentação vazia para demonstrar a funcionalidade básica
function createEmptyPresentation() {
	
    // Inicializa uma nova apresentação vazia
    var emptyPresentation = new Presentation();
    
    // Salva a apresentação vazia no formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Libera os recursos associados à apresentação
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Executa a função para criar uma apresentação vazia
```

8. Agora execute `node hello.js` no prompt de comando para rodá‑lo.

### **Linux**

1. Instale o .NET6 ou superior.
1. Instale o Node.js (https://nodejs.org/en/download/) e adicione node.exe ao `PATH`.
1. Instale o edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Baixe Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pt/nodejs-net/) e extraia para `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Crie um arquivo de teste chamado `hello.js` usando este código de exemplo na pasta `aspose.slides.nodejs.net`:

```javascript
// Importa o módulo Aspose.Slides para manipulação de arquivos PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Adiciona as classes necessárias do asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Cria e salva uma apresentação vazia para demonstrar a funcionalidade básica
function createEmptyPresentation() {
	
    // Inicializa uma nova apresentação vazia
    var emptyPresentation = new Presentation();
    
    // Salva a apresentação vazia no formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Libera os recursos associados à apresentação
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Executa a função para criar uma apresentação vazia
```
7. Agora execute `node hello.js` no prompt de comando para rodá‑lo.

### **Mac**

1. Instale o .NET6 ou superior.
1. Instale o Node.js (https://nodejs.org/en/download/) e adicione node.exe ao `PATH`.
1. Instale o edge-js.

$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```

```javascript
// Importa o módulo Aspose.Slides para manipulação de arquivos PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Adiciona as classes necessárias de asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Cria e salva uma apresentação vazia para demonstrar funcionalidade básica
function createEmptyPresentation() {
	
    // Inicializa uma nova apresentação vazia
    var emptyPresentation = new Presentation();
    
    // Salva a apresentação vazia no formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Libera recursos associados à apresentação
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Executa a função para criar uma apresentação vazia
```
9. Agora execute `node hello.js` no prompt de comando para rodá‑lo.