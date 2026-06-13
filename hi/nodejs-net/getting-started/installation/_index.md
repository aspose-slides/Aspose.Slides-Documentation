---
title: स्थापना
type: docs
weight: 70
url: /hi/nodejs-net/installation/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides स्थापित करें
- Aspose.Slides स्थापना
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Windows, Linux या macOS में .NET के माध्यम से Node.js के लिए Aspose.Slides स्थापित करें"
---
Aspose.Slides for Node.js via .NET एक प्लेटफ़ॉर्म‑स्वतंत्र API है और इसे किसी भी प्लेटफ़ॉर्म (Windows, Linux और MacOS) पर उपयोग किया जा सकता है जहाँ `Node.js` और `edge-js` पुल स्थापित हैं।

## **NPM से इंस्टॉल करें**

आप आसानी से Aspose.Slides for Node.js via .NET को [NPM](https://www.npmjs.com/) से इस कमांड के माध्यम से इंस्टॉल कर सकते हैं:
```
$ npm install aspose.slides.via.net
```
यदि इंस्टॉलेशन प्रक्रिया के दौरान आपको कोई समस्या आती है, तो कृपया https://www.npmjs.com/package/edge-js देखें।

## **ZIP संग्रह से इंस्टॉल करें**

ZIP संग्रह से Aspose.Slides for Node.js via .NET को इंस्टॉल और उपयोग करने के लिए, कृपया इसके बजाय नीचे दिए गए निर्देशों का पालन करें:

### **Windows**

1. .NET6 या उससे ऊपर इंस्टॉल करें।
1. Node.js (https://nodejs.org/en/download/) इंस्टॉल करें और node.exe को `PATH` में जोड़ें।
1. edge-js इंस्टॉल करें।
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Aspose.Slides for Node.js via .NET डाउनलोड करें](https://releases.aspose.com/slides/hi/nodejs-net/) और इसे `aspose.slides.nodejs/node_modules/aspose.slides.via.net` में एक्सट्रैक्ट करें।
7. `aspose.slides.nodejs.net` फ़ोल्डर में `hello.js` नाम की फ़ाइल बनाएँ, निम्नलिखित नमूना कोड का उपयोग करके:

```javascript
// PowerPoint फ़ाइल हेरफ़ेर के लिए Aspose.Slides मॉड्यूल को इम्पोर्ट करें
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides से आवश्यक क्लासेज़ जोड़ें
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// मूलभूत कार्यक्षमता दिखाने के लिए एक खाली प्रस्तुति बनाएँ और सहेजें
function createEmptyPresentation() {
	
    // एक नई खाली प्रस्तुति को आरंभ करें
    var emptyPresentation = new Presentation();
    
    // खाली प्रस्तुति को PPTX प्रारूप में सहेजें
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // प्रस्तुति से जुड़े संसाधनों को रिलीज़ करें
    emptyPresentation.dispose();
}

createEmptyPresentation(); // एक खाली प्रस्तुति बनाने के लिये फ़ंक्शन को निष्पादित करें
```

8. अब इसे चलाने के लिए कमांड प्रॉम्प्ट में `node hello.js` चलाएँ।

### **Linux**

1. .NET6 या उससे ऊपर इंस्टॉल करें।
1. Node.js (https://nodejs.org/en/download/) इंस्टॉल करें और node.exe को `PATH` में जोड़ें।
1. edge-js इंस्टॉल करें।
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Aspose.Slides for Node.js via Java डाउनलोड करें](https://releases.aspose.com/slides/hi/nodejs-net/) और इसे `aspose.slides.nodejs/node_modules/aspose.slides.via.net` में एक्सट्रैक्ट करें।
6. `aspose.slides.nodejs.net` फ़ोल्डर में इस नमूना कोड का उपयोग करके `hello.js` नाम की टेस्ट फ़ाइल बनाएँ:

```javascript
// PowerPoint फ़ाइल हेरफ़ेर के लिए Aspose.Slides मॉड्यूल को इम्पोर्ट करें
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides से आवश्यक क्लासेस जोड़ें
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// मूलभूत कार्यक्षमता दिखाने के लिए एक खाली प्रस्तुति बनाएं और सहेजें
function createEmptyPresentation() {
	
    // एक नई खाली प्रस्तुति को प्रारम्भ करें
    var emptyPresentation = new Presentation();
    
    // खाली प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // प्रस्तुति से जुड़े संसाधनों को रिलीज़ करें
    emptyPresentation.dispose();
}

createEmptyPresentation(); // एक खाली प्रस्तुति बनाने के लिए फ़ंक्शन को निष्पादित करें
```
7. अब इसे चलाने के लिए कमांड प्रॉम्प्ट में `node hello.js` चलाएँ।

### **Mac**

1. .NET6 या उससे ऊपर इंस्टॉल करें।
1. Node.js (https://nodejs.org/en/download/) इंस्टॉल करें और node.exe को `PATH` में जोड़ें।
1. edge-js इंस्टॉल करें।

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
9. अब इसे चलाने के लिए कमांड प्रॉम्प्ट में `node hello.js` चलाएँ।