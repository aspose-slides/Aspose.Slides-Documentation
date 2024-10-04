---
title: Instalación
type: docs
weight: 70
url: /nodejs-net/installation/
keySlides: "Descargar Aspose.Slides, Instalar Aspose.Slides, Instalación de Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Instala Aspose.Slides para Node.js a través de .NET en Windows, Linux o macOS"
---

Aspose.Slides para Node.js a través de .NET es una API independiente de la plataforma y se puede usar en cualquier plataforma (Windows, Linux y MacOS) donde estén instalados `Node.js` y el puente `edge-js`.

## **Instalar desde NPM**

Puedes instalar fácilmente Aspose.Slides para Node.js a través de .NET desde [NPM](https://www.npmjs.com/) con este comando:
```
$ npm install aspose.slides.via.net
```
Si encuentras algún problema durante el proceso de instalación, consulta https://www.npmjs.com/package/edge-js.

## **Instalar desde archivo ZIP**

Para instalar y usar Aspose.Slides para Node.js a través de .NET desde un archivo ZIP, sigue estas instrucciones en su lugar:

### **Windows**

1. Instala .NET6 o superior.
1. Instala Node.js (https://nodejs.org/en/download/) y añade node.exe a `PATH`.
1. Instala edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Descargar Aspose.Slides para Node.js a través de .NET](https://releases.aspose.com/slides/nodejs-net/) y extrae el contenido en `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Crea un archivo llamado `hello.js` en la carpeta `aspose.slides.nodejs.net` usando el siguiente código de muestra:

```javascript
// Importar el módulo Aspose.Slides para la manipulación de archivos de PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Añadir las clases necesarias del asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Crear y guardar una presentación vacía para demostrar la funcionalidad básica
function createEmptyPresentation() {
	
    // Inicializar una nueva presentación vacía
    var emptyPresentation = new Presentation();
    
    // Guardar la presentación vacía en formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Liberar recursos asociados con la presentación
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Ejecutar la función para crear una presentación vacía
```

8. Ahora ejecuta `node hello.js` en el símbolo del sistema para correrlo.

### **Linux**

1. Instala .NET6 o superior.
1. Instala Node.js (https://nodejs.org/en/download/) y añade node.exe a `PATH`.
1. Instala edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Descargar Aspose.Slides para Node.js a través de .NET](https://releases.aspose.com/slides/nodejs-net/) y extrae el contenido en `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Crea un archivo de prueba llamado `hello.js` utilizando este código de muestra en la carpeta `aspose.slides.nodejs.net`:

```javascript
// Importar el módulo Aspose.Slides para la manipulación de archivos de PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Añadir las clases necesarias del asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Crear y guardar una presentación vacía para demostrar la funcionalidad básica
function createEmptyPresentation() {
	
    // Inicializar una nueva presentación vacía
    var emptyPresentation = new Presentation();
    
    // Guardar la presentación vacía en formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Liberar recursos asociados con la presentación
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Ejecutar la función para crear una presentación vacía
```
7. Ahora ejecuta `node hello.js` en el símbolo del sistema para correrlo.

### **Mac**

1. Instala .NET6 o superior.
1. Instala Node.js (https://nodejs.org/en/download/) y añade node.exe a `PATH`.
1. Instala edge-js.

```
$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Importar el módulo Aspose.Slides para la manipulación de archivos de PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Añadir las clases necesarias del asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Crear y guardar una presentación vacía para demostrar la funcionalidad básica
function createEmptyPresentation() {
	
    // Inicializar una nueva presentación vacía
    var emptyPresentation = new Presentation();
    
    // Guardar la presentación vacía en formato PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Liberar recursos asociados con la presentación
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Ejecutar la función para crear una presentación vacía
```
9. Ahora ejecuta `node hello.js` en el símbolo del sistema para correrlo.