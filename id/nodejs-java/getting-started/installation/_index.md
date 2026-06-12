---
title: Instalasi
type: docs
weight: 70
url: /id/nodejs-java/installation/
keywords:
- menginstal Aspose.Slides
- mengunduh Aspose.Slides
- menggunakan Aspose.Slides
- instalasi Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Pelajari cara menginstal Aspose.Slides dengan cepat. Panduan langkah demi langkah, persyaratan sistem, dan contoh kode — mulai bekerja dengan presentasi PowerPoint hari ini!"
---
## **Pendahuluan**

Aspose.Slides for Node.js via Java adalah API yang independen platform dan dapat digunakan pada platform apa pun (Windows, Linux, dan MacOS) di mana `Node.js` dan [`java`](https://www.npmjs.com/package/java) bridge telah terpasang.

## **Instal dari NPM**

Anda dapat dengan mudah menginstal Aspose.Slides for Node.js via Java dari [NPM](https://www.npmjs.com/).

1. Buat folder baru dan inisialisasi proyek baru menggunakan perintah berikut:
	```
	$ npm init
```
	
2. Isi bidang judul dan versi (biarkan bidang lainnya dengan nilai default).

3. Instal Aspose.Slides for Node.js via Java menggunakan perintah berikut:
	```
	$ npm install aspose.slides.via.java
```

Jika Anda mengalami masalah selama proses instalasi, silakan lihat [artikel](/slides/id/nodejs-java/troubleshooting-installation/).

**Contoh Penggunaan**:

Buat file bernama `hello.js` di folder proyek Anda dan tambahkan kode contoh berikut:

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();

var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

console.log("Done");
```

## **Instal dari arsip ZIP**

Untuk menginstal dan menggunakan Aspose.Slides for Node.js via Java dari arsip ZIP, ikuti instruksi berikut ini:

### **Windows**

1. Instal JDK8 dan konfigurasikan variabel lingkungan `JAVA_HOME`.
1. Instal Node.js (https://nodejs.org/en/download/) dan tambahkan node.exe ke `PATH`.
1. Instal node-gyp.
1. Instal Windows Build Tools.
1. Instal [`java`](https://www.npmjs.com/package/java) bridge dan jalankan perintah berikut di Command Prompt sebagai administrator:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install -g node-gyp

	$ npm install --global --production windows-build-tools

	$ npm install java
```
6. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/id/nodejs-java/) dan ekstrak ke `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
7. Buat file bernama `hello.js` di folder `aspose.slides.nodejs` menggunakan kode contoh berikut:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
```

8. Sekarang jalankan `node hello.js` di command prompt untuk mengeksekusinya.

### **Linux**

1. Instal Node.js (https://nodejs.org/en/download/).
1. Instal JDK8 untuk Linux dan konfigurasikan variabel lingkungan `JAVA_HOME`.
1. Instal python 2.x
1. Instal [`java`](https://www.npmjs.com/package/java) bridge. Anda dapat menjalankan perintah berikut di terminal:
	```bash
	$ mkdir aspose.slides.nodejs

	$ cd aspose.slides.nodejs

	$ npm install java
```
5. [Download Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/id/nodejs-java/) dan ekstrak ke `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
6. Buat file uji bernama `hello.js` menggunakan kode contoh ini di folder `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
```
7. Sekarang jalankan `node hello.js` di command prompt untuk mengeksekusinya.

### **Mac**

1. Instal Node.js (https://nodejs.org/en/download/).
1. Instal JDK8 untuk Mac dan konfigurasikan variabel lingkungan `JAVA_HOME`.
1. Modifikasi bagian JVMCapabilities di `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` dengan hak istimewa root. `jdk1.8.x_xxx.jdk` tergantung pada versi jdk Anda. Jadikan seperti ini:
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
4. Instal python 2.x (jika belum terpasang).
5. Instal Xcode Command Line Tools.
6. Instal [`java`](https://www.npmjs.com/package/java) bridge. Anda dapat menjalankan perintah berikut di terminal:
	```bash
	$ mkdir aspose.slides.nodejs
	 
	$ cd aspose.slides.nodejs
	 
	$ npm install java
```
7. Unduh Aspose.Slides for Node.js via Java dan ekstrak ke `aspose.slides.nodejs/node_modules/aspose.slides.via.java`.
8. Buat file uji bernama `hello.js` menggunakan kode contoh ini di folder `aspose.slides.nodejs`:

	```javascript
	var aspose = aspose || {};

	aspose.slides = require("aspose.slides.via.java");

	var pres = new aspose.slides.Presentation();

	var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

	slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading");

	pres.save("out.pptx", aspose.slides.SaveFormat.Pptx)

	console.log("Done");
	```
9. Sekarang jalankan `node hello.js` di command prompt untuk mengeksekusinya.


{{% alert color="primary" %}}
Silakan gunakan [artikel](https://docs.aspose.com/slides/id/nodejs-java/troubleshooting-installation/) berikut jika Anda mengalami kesalahan kompilasi selama instalasi Aspose.Slides for Node.js via Java.
{{% /alert %}}

## **FAQ**

**Apakah ada versi gratis atau batasan percobaan?**

Ya, secara default Aspose.Slides berjalan dalam mode evaluasi, yang menambahkan watermark dan mungkin memiliki batasan lain. Untuk menghapus pembatasan, Anda perlu menerapkan [lisensi](/slides/id/nodejs-java/licensing/) yang valid.