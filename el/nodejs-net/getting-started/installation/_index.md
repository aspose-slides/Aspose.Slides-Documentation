---
title: Εγκατάσταση
type: docs
weight: 70
url: /el/nodejs-net/installation/
keywords:
- λήψη Aspose.Slides
- εγκατάσταση Aspose.Slides
- Εγκατάσταση Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Εγκατάσταση Aspose.Slides για Node.js μέσω .NET σε Windows, Linux ή macOS"
---
Το Aspose.Slides for Node.js via .NET είναι ένα ανεξάρτητο από την πλατφόρμα API και μπορεί να χρησιμοποιηθεί σε οποιαδήποτε πλατφόρμα (Windows, Linux και MacOS) όπου είναι εγκατεστημένα το `Node.js` και η γέφυρα `edge-js`.

## **Εγκατάσταση από NPM**

Μπορείτε εύκολα να εγκαταστήσετε το Aspose.Slides for Node.js via .NET από το [NPM](https://www.npmjs.com/) με αυτήν την εντολή:
```
$ npm install aspose.slides.via.net
```
Εάν αντιμετωπίσετε κάποιο πρόβλημα κατά τη διαδικασία εγκατάστασης, παρακαλούμε ανατρέξτε στη διεύθυνση https://www.npmjs.com/package/edge-js.

## **Εγκατάσταση από αρχείο ZIP**

Για να εγκαταστήσετε και να χρησιμοποιήσετε το Aspose.Slides for Node.js via .NET από αρχείο ZIP, ακολουθήστε αυτές τις οδηγίες:

### **Windows**

1. Εγκαταστήστε το .NET6 ή νεότερη έκδοση.
1. Εγκαταστήστε το Node.js (https://nodejs.org/en/download/) και προσθέστε το node.exe στο `PATH`.
1. Εγκαταστήστε το edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Κατεβάστε το Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/el/nodejs-net/) και εξάγετε το στο `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Δημιουργήστε ένα αρχείο με όνομα `hello.js` στον φάκελο `aspose.slides.nodejs.net` χρησιμοποιώντας τον παρακάτω κωδικό παραδείγματος:
```javascript
// Εισαγωγή του module Aspose.Slides για χειρισμό αρχείων PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Προσθήκη των απαραίτητων κλάσεων από το asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Αρχικοποίηση μιας νέας κενής παρουσίασης
    var emptyPresentation = new Presentation();
    
    // Αποθήκευση της κενής παρουσίασης σε μορφή PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Απελευθέρωση πόρων που σχετίζονται με την παρουσίαση
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Εκτέλεση της συνάρτησης για δημιουργία κενής παρουσίασης
```
8. Τώρα εκτελέστε `node hello.js` στο command prompt για να το τρέξετε.

### **Linux**

1. Εγκαταστήστε το .NET6 ή νεότερη έκδοση.
1. Εγκαταστήστε το Node.js (https://nodejs.org/en/download/) και προσθέστε το node.exe στο `PATH`.
1. Εγκαταστήστε το edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Κατεβάστε το Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/el/nodejs-net/) και εξάγετε το στο `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Δημιουργήστε ένα αρχείο δοκιμής με όνομα `hello.js` χρησιμοποιώντας αυτόν τον κώδικα παραδείγματος στον φάκελο `aspose.slides.nodejs.net`:
```javascript
// Εισαγωγή του module Aspose.Slides για τη διαχείριση αρχείων PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Προσθήκη των απαραίτητων κλάσεων από το asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Create and save an empty presentation to demonstrate basic functionality
function createEmptyPresentation() {
	
    // Αρχικοποίηση μιας νέας κενής παρουσίασης
    var emptyPresentation = new Presentation();
    
    // Αποθήκευση της κενής παρουσίασης σε μορφή PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Απελευθέρωση των πόρων που σχετίζονται με την παρουσίαση
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Εκτέλεση της συνάρτησης για τη δημιουργία κενής παρουσίασης
```
7. Τώρα εκτελέστε `node hello.js` στο command prompt για να το τρέξετε.

### **Mac**

1. Εγκαταστήστε το .NET6 ή νεότερη έκδοση.
1. Εγκαταστήστε το Node.js (https://nodejs.org/en/download/) και προσθέστε το node.exe στο `PATH`.
1. Εγκαταστήστε το edge-js.

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
9. Τώρα εκτελέστε `node hello.js` στο command prompt για να το τρέξετε.