---
title: Installation
type: docs
weight: 70
url: /fr/nodejs-java/installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- installation Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Installez Aspose.Slides pour Node.js via Java sous Windows, Linux ou macOS"
---

Aspose.Slides pour Node.js via Java est une API indépendante de la plateforme et peut être utilisée sur n'importe quel système (Windows, Linux et macOS) où `Node.js` et le pont [`java`](https://www.npmjs.com/package/java) sont installés.

## **Installer depuis NPM**

Vous pouvez facilement installer Aspose.Slides pour Node.js via Java depuis [NPM](https://www.npmjs.com/).

1. Créez un nouveau dossier et initiez un nouveau projet avec la commande suivante :
	```
	$ npm init
	```
	
2. Remplissez les champs titre et version (laissez les autres champs avec leurs valeurs par défaut).

3. Installez Aspose.Slides pour Node.js via Java avec la commande suivante :
	```
	$ npm install aspose.slides.via.java
	```

Si vous rencontrez un problème pendant le processus d'installation, veuillez consulter cet [article](/nodejs-java/troubleshooting-installation/).

**Exemple d'utilisation** :

Créez un fichier nommé `hello.js` dans le dossier de votre projet et ajoutez le code d'exemple suivant :

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Installer depuis une archive ZIP**

Pour installer et utiliser Aspose.Slides pour Node.js via Java à partir d'une archive ZIP, suivez ces instructions à la place :

### **Windows**

1. Installez JDK 8 et configurez la variable d'environnement `JAVA_HOME`.
1. Installez Node.js (https://nodejs.org/en/download/) et ajoutez `node.exe` au `PATH`.
1. Installez node-gyp.
1. Installez Windows Build Tools.
1. Installez le pont [`java`](https://www.npmjs.com/package/java) et exécutez ces commandes dans l'invite de commandes en tant qu'administrateur :
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
	```
6. [Téléchargez Aspose.Slides pour Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Créez un fichier nommé `hello.js` dans le dossier `aspose.slides.nodejs` avec le code d'exemple suivant :

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Exécutez maintenant `node hello.js` @command prompt pour le lancer.

### **Linux**

1. Installez Node.js (https://nodejs.org/en/download/).
1. Installez JDK 8 pour Linux et configurez la variable d'environnement `JAVA_HOME`.
1. Installez python 2.x
1. Installez le pont [`java`](https://www.npmjs.com/package/java). Vous pouvez exécuter ces commandes dans le terminal :
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```
5. [Téléchargez Aspose.Slides pour Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Créez un fichier de test nommé `hello.js` en utilisant ce code d'exemple dans le dossier `aspose.slides.nodejs` :

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
7. Exécutez maintenant `node hello.js` @command prompt pour le lancer.

### **Mac**

1. Installez Node.js (https://nodejs.org/en/download/).
1. Installez JDK 8 pour Mac et configurez la variable d'environnement `JAVA_HOME`.
1. Modifiez la section JVMCapabilities dans `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` avec privilèges root. `jdk1.8.x_xxx.jdk` dépend de votre version du JDK. Faites-le ressembler à ceci :
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
4. Installez python 2.x (si ce n'est pas déjà fait).
5. Installez Xcode Command Line Tools.
6. Installez le pont [`java`](https://www.npmjs.com/package/java). Vous pouvez exécuter les commandes ci‑dessous dans le terminal :
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```
7. Téléchargez Aspose.Slides pour Node.js via Java et extrayez-le dans `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Créez un fichier de test nommé `hello.js` en utilisant ce code d'exemple dans le dossier `aspose.slides.nodejs` :

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Exécutez maintenant `node hello.js` @command prompt pour le lancer.


{{% alert color="primary" %}}
Veuillez consulter l'[article](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) si vous rencontrez des erreurs de compilation pendant l'installation d'Aspose.Slides pour Node.js via Java.
{{% /alert %}}

## **FAQ**

**Existe‑t‑il une version gratuite ou une limitation d'essai ?**

Oui, par défaut, Aspose.Slides s'exécute en mode d'évaluation, ce qui ajoute des filigranes et peut comporter d'autres limitations. Pour supprimer ces restrictions, vous devez appliquer une [licence](/slides/fr/nodejs-java/licensing/) valide.