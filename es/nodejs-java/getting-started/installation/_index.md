---
title: Instalación
type: docs
weight: 70
url: /nodejs-java/installation/
keySlides: "Descargar Aspose.Slides, Instalar Aspose.Slides, Instalación de Aspose.Slides, Windows, macOS, Linux, Javascript, Node.js"
description: "Instalar Aspose.Slides para Node.js a través de Java en Windows, Linux o macOS"
---

Aspose.Slides para Node.js a través de Java es una API independiente de la plataforma y se puede utilizar en cualquier plataforma (Windows, Linux y MacOS) donde estén instalados `Node.js` y el puente [`java`](https://www.npmjs.com/package/java).

## **Instalar desde NPM**

Puedes instalar fácilmente Aspose.Slides para Node.js a través de Java desde [NPM](https://www.npmjs.com/).

Crea una nueva carpeta e inicia un nuevo proyecto usando el siguiente comando:
```
$ npm init
```
Completa los campos de título y versión (deja los campos restantes con valores predeterminados)

Instala Aspose.Slides para Node.js a través de Java usando el siguiente comando:
```
$ npm install aspose.slides.via.java
```

Si encuentras algún problema durante el proceso de instalación, por favor consulta este [artículo](/nodejs-java/troubleshooting-installation/).

## **Instalar desde archivo ZIP**

Para instalar y usar Aspose.Slides para Node.js a través de Java desde un archivo ZIP, sigue estas instrucciones en su lugar:

### **Windows**

1. Instala JDK8 y configura la variable de entorno `JAVA_HOME`.
1. Instala Node.js (https://nodejs.org/en/download/) y añade node.exe a `PATH`.
1. Instala node-gyp.
1. Instala Windows Build Tools.
1. Instala el puente [`java`](https://www.npmjs.com/package/java) y ejecuta estos comandos en el símbolo del sistema como administrador:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [Descarga Aspose.Slides para Node.js a través de Java](https://releases.aspose.com/slides/nodejs-java/) y extráelo a `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Crea un archivo llamado `hello.js` en la carpeta `aspose.slides.nodejs` usando el siguiente código de ejemplo:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Título de la diapositiva");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Hecho");
```

8. Ahora ejecuta `node hello.js` en el símbolo del sistema para ejecutarlo.

### **Linux**

1. Instala Node.js (https://nodejs.org/en/download/).
1. Instala JDK8 para Linux y configura la variable de entorno `JAVA_HOME`.
1. Instala python 2.x
1. Instala el puente [`java`](https://www.npmjs.com/package/java). Puedes ejecutar estos comandos en la terminal:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [Descarga Aspose.Slides para Node.js a través de Java](https://releases.aspose.com/slides/nodejs-java/) y extráelo a `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Crea un archivo de prueba llamado `hello.js` usando este código de ejemplo en la carpeta `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Título de la diapositiva");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Hecho");
```
7. Ahora ejecuta `node hello.js` en el símbolo del sistema para ejecutarlo.

### **Mac**

1. Instala Node.js (https://nodejs.org/en/download/).
1. Instala JDK8 para Mac y configura la variable de entorno `JAVA_HOME`.
1. Modifica la sección JVMCapabilities en `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` con privilegios de root. `jdk1.8.x_xxx.jdk` depende de tu versión de jdk. Haz que se vea así:
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
4. Instala python 2.x (si no está instalado).
5. Instala las herramientas de línea de comandos de Xcode.
6. Instala el puente [`java`](https://www.npmjs.com/package/java). Puedes ejecutar los siguientes comandos en la terminal:
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. Descarga Aspose.Slides para Node.js a través de Java y extráelo en `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Crea un archivo de prueba llamado `hello.js` usando este código de ejemplo en la carpeta `aspose.slides.nodejs`:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Título de la diapositiva");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Hecho");
```
9. Ahora ejecuta `node hello.js` en el símbolo del sistema para ejecutarlo.


{{% alert color="primary" %}}

Por favor, utiliza el siguiente [artículo](https://docs.aspose.com/slides/nodejs-java/troubleshooting-installation/) si encuentras errores de compilación durante la instalación de Aspose.Slides para Node.js a través de Java.

{{% /alert %}}