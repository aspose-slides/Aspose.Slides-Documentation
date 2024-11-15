---
title: Installation
type: docs
weight: 70
url: /nodejs-net/installation/
keywords:
- download Aspose.Slides
- install Aspose.Slides
- Aspose.Slides installation
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Install Aspose.Slides for Node.js via .NET in Windows, Linux or macOS"
---

Aspose.Slides for Node.js via .NET is platform-independent API and can be used on any platform (Windows, Linux and MacOS) where `Node.js` and `edge-js` bridge are installed.

## **Install from NPM**

You can easily install Aspose.Slides for Node.js via .NET from [NPM](https://www.npmjs.com/) through this command:
```
$ npm install aspose.slides.via.net
```
If you encounter any problem during the installation process, please refer to https://www.npmjs.com/package/edge-js.

## **Install from ZIP archive**

To install and use Aspose.Slides for Node.js via .NET from a ZIP archive, follow these instructions instead:

### **Windows**

1. Install .NET6 or above.
1. Install Node.js (https://nodejs.org/en/download/) and add node.exe to `PATH`.
1. Install edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Download Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/nodejs-net/) and extract it to `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Create a file named `hello.js` in `aspose.slides.nodejs.net` folder using the following sample code:

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
```

8. Now run `node hello.js` @command prompt to run it.

### **Linux**

1. Install .NET6 or above.
1. Install Node.js (https://nodejs.org/en/download/) and add node.exe to `PATH`.
1. Install edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-net/) and extract it to `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Create a test file named `hello.js` using this sample code in `aspose.slides.nodejs.net` folder:

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
```
7. Now run `node hello.js` @command prompt to run it.

### **Mac**

1. Install .NET6 or above.
1. Install Node.js (https://nodejs.org/en/download/) and add node.exe to `PATH`.
1. Install edge-js.

$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Import the Aspose.Slides module for PowerPoint file manipulation
const asposeSlides = require('aspose.slides.via.net');

// Add necessary classes from the asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Initialize a new empty presentation
    var emptyPresentation = new Presentation();
    
    // Save the empty presentation in PPTX format
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Release resources associated with the presentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Execute the function to create an empty presentation
```
9. Now run `node hello.js` @command prompt to run it.