---
title: Installation
type: docs
weight: 70
url: /nodejs-net/installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, Javascript, Node.js"
description: "Install Aspose.Slides for Node.js via .NET in Windows, Linux or macOS"
---

Aspose.Slides for Node.js via .NET is platform-independent API and can be used on any platform (Windows, Linux and MacOS) where `Node.js` and [`edge-js`](https://www.npmjs.com/package/edge-js) are installed.

## **Install from NPM**

You can easily install Aspose.Slides for Node.js via .NET from [NPM](https://www.npmjs.com/).

Create a new folder and initiate a new project using the following command:
```
$ npm init
```
Fill in the title and version fields (leave the remaining fields with default values)

Install Aspose.Slides for Node.js via .NET using the following command:
```
$ npm install aspose.slides.via.net
```

If you encounter any problem during the installation process, please refer to this [article](/nodejs-net/troubleshooting-installation/).

Create New PowerPoint Presentation using Node.js:
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

{{% alert color="primary" %}}

Please use the following [article](https://docs.aspose.com/slides/nodejs-net/troubleshooting-installation/) if you encounter compilation errors during installation of Aspose.Slides for Node.js via .NET.

{{% /alert %}}