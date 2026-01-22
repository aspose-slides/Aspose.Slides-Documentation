---
title: Instalación
type: docs
weight: 70
url: /es/nodejs-java/installation/
keywords:
- instalar Aspose.Slides
- descargar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a instalar rápidamente Aspose.Slides. Guía paso a paso, requisitos del sistema y ejemplos de código — ¡comience a trabajar con presentaciones de PowerPoint hoy!"
---

Aspose.Slides for Node.js via Java es una API independiente de la plataforma y puede usarse en cualquier sistema (Windows, Linux y macOS) donde estén instalados `Node.js` y el puente [`java`](https://www.npmjs.com/package/java).

## **Instalar desde NPM**

Puede instalar fácilmente Aspose.Slides for Node.js via Java desde [NPM](https://www.npmjs.com/).

1. Cree una nueva carpeta e inicie un nuevo proyecto usando el siguiente comando:
```
	$ npm init
```


2. Complete los campos de título y versión (deje los demás campos con sus valores predeterminados).

3. Instale Aspose.Slides for Node.js via Java usando el siguiente comando:
```
	$ npm install aspose.slides.via.java
```


Si encuentra algún problema durante el proceso de instalación, consulte este [artículo](/slides/es/nodejs-java/troubleshooting-installation/).

**Ejemplo de uso**:

Cree un archivo llamado `hello.js` en la carpeta de su proyecto y añada el siguiente código de ejemplo:
```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```


## **Instalar desde archivo ZIP**

Para instalar y usar Aspose.Slides for Node.js via Java a partir de un archivo ZIP, siga estas instrucciones:

### **Windows**

1. Instale JDK8 y configure la variable de entorno `JAVA_HOME`.
1. Instale Node.js (https://nodejs.org/en/download/) y añada node.exe a `PATH`.
1. Instale node-gyp.
1. Instale Windows Build Tools.
1. Instale el puente [`java`](https://www.npmjs.com/package/java) y ejecute estos comandos en el Símbolo del sistema como administrador:
```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```

6. [Descargue Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) y extráigalo en `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Cree un archivo llamado `hello.js` en la carpeta `aspose.slides.nodejs` usando el siguiente código de ejemplo:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

8. Ahora ejecute `node hello.js` en el símbolo del sistema para ejecutarlo.

### **Linux**

1. Instale Node.js (https://nodejs.org/en/download/).
1. Instale JDK8 para Linux y configure la variable de entorno `JAVA_HOME`.
1. Instale python 2.x
1. Instale el puente [`java`](https://www.npmjs.com/package/java). Puede ejecutar estos comandos en la terminal:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
	```

5. [Descargue Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) y extráigalo en `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Cree un archivo de prueba llamado `hello.js` usando este código de ejemplo en la carpeta `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

7. Ahora ejecute `node hello.js` en el símbolo del sistema para ejecutarlo.

### **Mac**

1. Instale Node.js (https://nodejs.org/en/download/).
1. Instale JDK8 para Mac y configure la variable de entorno `JAVA_HOME`.
1. Modifique la sección JVMCapabilities en `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` con privilegios de root. `jdk1.8.x_xxx.jdk` depende de su versión de jdk. Hágalo quedar así:
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

4. Instale python 2.x (si no está instalado).
5. Instale Xcode Command Line Tools.
6. Instale el puente [`java`](https://www.npmjs.com/package/java). Puede ejecutar los siguientes comandos en la terminal:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
	```

7. Descargue Aspose.Slides for Node.js via Java y extráigalo en `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Cree un archivo de prueba llamado `hello.js` usando este código de ejemplo en la carpeta `aspose.slides.nodejs`:
	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```

9. Ahora ejecute `node hello.js` en el símbolo del sistema para ejecutarlo.

{{% alert color="primary" %}}
Utilice el siguiente [artículo](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) si encuentra errores de compilación durante la instalación de Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Existe una versión gratuita o limitaciones de prueba?**

Sí, por defecto, Aspose.Slides se ejecuta en modo de evaluación, lo que inserta marcas de agua y puede tener otras limitaciones. Para eliminar las restricciones, debe aplicar una [licencia](/slides/es/nodejs-java/licensing/) válida.