---
title: Installation
type: docs
weight: 70
url: /nodejs-java/installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, Javascript, Node.js"
description: "Install Aspose.Slides for Node.js via Java in Windows, Linux or macOS"
---

Aspose.Slides for Node.js via Java is platform-independent API and can be used on any platform (Windows, Linux and MacOS) where `Node.js` and `node-java` bridge are installed.

## Install from NPM

You can easily use Aspose.Slides for Node.js via Java from [NPM](https://www.npmjs.com/) with the following command.
```
$ npm install aspose.slides.via.java
```
If you encounter any problems during the installation process, please refer to https://www.npmjs.com/package/java.

Install from ZIP archive.
To install and use Aspose.Slides for Node.js via Java from a ZIP archive, follow the following instructions:

## Windows

1. Install JDK8 and configure `JAVA_HOME` environment variable.
1. Install Node.js (https://nodejs.org/en/download/) and add node.exe to `PATH`.
1. Install node-gyp.
1. Install Windows Build Tools.
1. Install [`node-java`](https://www.npmjs.com/package/java) bridge and run below commands @ command prompt as an administrator:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install -g node-gyp

$ npm install --global --production windows-build-tools

$ npm install java
```
6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) and extract it into `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Create a file named `hello.js` in `aspose.slides.nodejs` folder using the following sample code:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

8. Now run `node hello.js` @command prompt to run it.

## Linux

1. Install Node.js (https://nodejs.org/en/download/).
1. Install JDK8 for Linux and configure `JAVA_HOME` environment variable.
1. Install python 2.x
1. Install [`node-java`](https://www.npmjs.com/package/java) bridge. You may run below commands @ terminal:
```
$ mkdir aspose.slides.nodejs

$ cd aspose.slides.nodejs

$ npm install java
```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/nodejs-java/) and extract it into `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Create a test file named `hello.js` using the following sample code in `aspose.slides.nodejs` folder:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```
7. Now run `node hello.js` @command prompt to run it.

## Mac

1. Install Node.js (https://nodejs.org/en/download/).
1. Install JDK8 for Mac and configure `JAVA_HOME` environment variable.
1. Modify JVMCapabilities section in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` with root privilege. (`jdk1.8.x_xxx.jdk` depends on your jdk version), make it looks like following:
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
4. Install python 2.x (if it is not installed).
5. Install Xcode Command Line Tools.
6. Install [`node-java`](https://www.npmjs.com/package/java) bridge. You may run below commands @ terminal:
```
$ mkdir aspose.slides.nodejs
 
$ cd aspose.slides.nodejs
 
$ npm install java
```
7. Download Aspose.Slides for Node.js via Java and extract it into `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Create a test file named `hello.js` using the following sample code in `aspose.slides.nodejs` folder:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```
9. Now run `node hello.js` @command prompt to run it.