---
title: Installation
type: docs
weight: 70
url: /nodejs-java/installation/
keySlides: "Télécharger Aspose.Slides, Installer Aspose.Slides, Installation d'Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Installer Aspose.Slides pour Node.js via Java sur Windows, Linux ou macOS"
---

Aspose.Slides pour Node.js via Java est une API indépendante de la plateforme et peut être utilisée sur n'importe quelle plateforme (Windows, Linux et MacOS) où `Node.js` et le pont [`java`](https://www.npmjs.com/package/java) sont installés.

## **Installer depuis NPM**

Vous pouvez facilement installer Aspose.Slides pour Node.js via Java depuis [NPM](https://www.npmjs.com/).

Créez un nouveau dossier et initialisez un nouveau projet en utilisant la commande suivante :
```
$ npm init
```
Remplissez les champs titre et version (laissez les autres champs avec les valeurs par défaut).

Installez Aspose.Slides pour Node.js via Java en utilisant la commande suivante :
```
$ npm install aspose.slides.via.java
```

Si vous rencontrez un problème durant le processus d'installation, veuillez vous référer à cet [article](/nodejs-java/troubleshooting-installation/).

## **Installer depuis une archive ZIP**

Pour installer et utiliser Aspose.Slides pour Node.js via Java à partir d'une archive ZIP, suivez ces instructions à la place :

### **Windows**

1. Installez JDK8 et configurez la variable d'environnement `JAVA_HOME`.
1. Installez Node.js (https://nodejs.org/en/download/) et ajoutez node.exe à `PATH`.
1. Installez node-gyp.
1. Installez les outils de construction Windows.
1. Installez le pont [`java`](https://www.npmjs.com/package/java) et exécutez ces commandes dans l'invite de commandes en tant qu'administrateur :
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [Téléchargez Aspose.Slides pour Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Créez un fichier nommé `hello.js` dans le dossier `aspose.slides.nodejs` en utilisant le code exemple suivant :

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Titre de la diapositive");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Fait");
```

8. Maintenant, exécutez `node hello.js` dans l'invite de commandes pour l'exécuter.

### **Linux**

1. Installez Node.js (https://nodejs.org/en/download/).
1. Installez JDK8 pour Linux et configurez la variable d'environnement `JAVA_HOME`.
1. Installez python 2.x.
1. Installez le pont [`java`](https://www.npmjs.com/package/java). Vous pouvez exécuter ces commandes dans le terminal :
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [Téléchargez Aspose.Slides pour Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Créez un fichier de test nommé `hello.js` en utilisant ce code exemple dans le dossier `aspose.slides.nodejs` :

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Titre de la diapositive");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Fait");
```
7. Maintenant, exécutez `node hello.js` dans l'invite de commandes pour l'exécuter.

### **Mac**

1. Installez Node.js (https://nodejs.org/en/download/).
1. Installez JDK8 pour Mac et configurez la variable d'environnement `JAVA_HOME`.
1. Modifiez la section JVMCapabilities dans `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` avec des privilèges de superutilisateur. `jdk1.8.x_xxx.jdk` dépend de votre version de jdk. Faites-le ressembler à ceci :
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
4. Installez python 2.x (s'il n'est pas déjà installé).
5. Installez les outils de ligne de commande Xcode.
6. Installez le pont [`java`](https://www.npmjs.com/package/java). Vous pouvez exécuter les commandes suivantes dans le terminal :
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. Téléchargez Aspose.Slides pour Node.js via Java et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Créez un fichier de test nommé `hello.js` en utilisant ce code exemple dans le dossier `aspose.slides.nodejs` :

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Titre de la diapositive");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Fait");
```
9. Maintenant, exécutez `node hello.js` dans l'invite de commandes pour l'exécuter.


{{% alert color="primary" %}}

Veuillez utiliser l'[article](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) suivant si vous rencontrez des erreurs de compilation lors de l'installation d'Aspose.Slides pour Node.js via Java.

{{% /alert %}}