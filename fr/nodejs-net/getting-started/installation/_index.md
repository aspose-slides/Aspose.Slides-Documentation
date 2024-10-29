---
title: Installation
type: docs
weight: 70
url: /fr/nodejs-net/installation/
keySlides: "Téléchargez Aspose.Slides, Installez Aspose.Slides, Installation d'Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Installez Aspose.Slides pour Node.js via .NET sur Windows, Linux ou macOS"
---

Aspose.Slides pour Node.js via .NET est une API indépendante de la plate-forme et peut être utilisée sur n'importe quelle plate-forme (Windows, Linux et MacOS) où `Node.js` et `edge-js` sont installés.

## **Installer depuis NPM**

Vous pouvez facilement installer Aspose.Slides pour Node.js via .NET depuis [NPM](https://www.npmjs.com/) via cette commande :
```
$ npm install aspose.slides.via.net
```
Si vous rencontrez un problème durant le processus d'installation, veuillez vous référer à https://www.npmjs.com/package/edge-js.

## **Installer depuis une archive ZIP**

Pour installer et utiliser Aspose.Slides pour Node.js via .NET à partir d'une archive ZIP, suivez plutôt ces instructions :

### **Windows**

1. Installez .NET6 ou supérieur.
1. Installez Node.js (https://nodejs.org/en/download/) et ajoutez node.exe à `PATH`.
1. Installez edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Téléchargez Aspose.Slides pour Node.js via .NET](https://releases.aspose.com/slides/nodejs-net/) et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
7. Créez un fichier nommé `hello.js` dans le dossier `aspose.slides.nodejs.net` en utilisant le code d'exemple suivant :

```javascript
// Importez le module Aspose.Slides pour la manipulation de fichiers PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Ajoutez les classes nécessaires de asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Créez et enregistrez une présentation vide pour démontrer les fonctionnalités de base
function createEmptyPresentation() {
	
    // Initialisez une nouvelle présentation vide
    var emptyPresentation = new Presentation();
    
    // Enregistrez la présentation vide au format PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Libérez les ressources associées à la présentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Exécutez la fonction pour créer une présentation vide
```

8. Maintenant, exécutez `node hello.js` à l'invite de commande pour l'exécuter.

### **Linux**

1. Installez .NET6 ou supérieur.
1. Installez Node.js (https://nodejs.org/en/download/) et ajoutez node.exe à `PATH`.
1. Installez edge-js.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Téléchargez Aspose.Slides pour Node.js via Java](https://releases.aspose.com/slides/nodejs-net/) et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.
6. Créez un fichier de test nommé `hello.js` en utilisant ce code d'exemple dans le dossier `aspose.slides.nodejs.net` :

```javascript
// Importez le module Aspose.Slides pour la manipulation de fichiers PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Ajoutez les classes nécessaires de asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Créez et enregistrez une présentation vide pour démontrer les fonctionnalités de base
function createEmptyPresentation() {
	
    // Initialisez une nouvelle présentation vide
    var emptyPresentation = new Presentation();
    
    // Enregistrez la présentation vide au format PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Libérez les ressources associées à la présentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Exécutez la fonction pour créer une présentation vide
```
7. Maintenant, exécutez `node hello.js` à l'invite de commande pour l'exécuter.

### **Mac**

1. Installez .NET6 ou supérieur.
1. Installez Node.js (https://nodejs.org/en/download/) et ajoutez node.exe à `PATH`.
1. Installez edge-js.

$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Importez le module Aspose.Slides pour la manipulation de fichiers PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Ajoutez les classes nécessaires de asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Créez et enregistrez une présentation vide pour démontrer les fonctionnalités de base
function createEmptyPresentation() {
	
    // Initialisez une nouvelle présentation vide
    var emptyPresentation = new Presentation();
    
    // Enregistrez la présentation vide au format PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Libérez les ressources associées à la présentation
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Exécutez la fonction pour créer une présentation vide
```
9. Maintenant, exécutez `node hello.js` à l'invite de commande pour l'exécuter.