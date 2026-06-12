---
title: Instalasi
type: docs
weight: 70
url: /id/nodejs-net/installation/
keywords:
- unduh Aspose.Slides
- pasang Aspose.Slides
- instalasi Aspose.Slides
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Instal Aspose.Slides untuk Node.js via .NET di Windows, Linux, atau macOS"
---
Aspose.Slides for Node.js via .NET adalah API yang bersifat platform‑independen dan dapat digunakan pada platform apa pun (Windows, Linux, dan MacOS) di mana jembatan `Node.js` dan `edge-js` telah dipasang.

## **Instal dari NPM**

Anda dapat dengan mudah menginstal Aspose.Slides for Node.js via .NET dari [NPM](https://www.npmjs.com/) melalui perintah berikut:
```
$ npm install aspose.slides.via.net
```
Jika Anda mengalami masalah selama proses instalasi, silakan merujuk ke https://www.npmjs.com/package/edge-js.

## **Instal dari arsip ZIP**

Untuk menginstal dan menggunakan Aspose.Slides for Node.js via .NET dari arsip ZIP, ikuti instruksi berikut:

### **Windows**

1. Instal .NET6 atau yang lebih baru.  
1. Instal Node.js (https://nodejs.org/en/download/) dan tambahkan node.exe ke `PATH`.  
1. Instal edge-js.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```  
6. [Unduh Aspose.Slides for Node.js via .NET](https://releases.aspose.com/slides/id/nodejs-net/) dan ekstrak ke `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.  
7. Buat file dengan nama `hello.js` di folder `aspose.slides.nodejs.net` menggunakan contoh kode berikut:

```javascript
// Impor modul Aspose.Slides untuk manipulasi file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Tambahkan kelas yang diperlukan dari asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Buat dan simpan presentasi kosong untuk mendemonstrasikan fungsionalitas dasar
function createEmptyPresentation() {
	
    // Inisialisasi presentasi kosong baru
    var emptyPresentation = new Presentation();
    
    // Simpan presentasi kosong dalam format PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Lepaskan sumber daya yang terkait dengan presentasi
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Jalankan fungsi untuk membuat presentasi kosong
```

8. Sekarang jalankan `node hello.js` di command prompt untuk mengeksekusinya.

### **Linux**

1. Instal .NET6 atau yang lebih baru.  
1. Instal Node.js (https://nodejs.org/en/download/) dan tambahkan node.exe ke `PATH`.  
1. Instal edge-js.  
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```  
5. [Unduh Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/id/nodejs-net/) dan ekstrak ke `aspose.slides.nodejs/node_modules/aspose.slides.via.net`.  
6. Buat file tes dengan nama `hello.js` menggunakan contoh kode ini di folder `aspose.slides.nodejs.net`:

```javascript
// Impor modul Aspose.Slides untuk manipulasi file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Tambahkan kelas yang diperlukan dari asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Buat dan simpan presentasi kosong untuk mendemonstrasikan fungsionalitas dasar
function createEmptyPresentation() {
	
    // Inisialisasi presentasi kosong baru
    var emptyPresentation = new Presentation();
    
    // Simpan presentasi kosong dalam format PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Lepaskan sumber daya yang terkait dengan presentasi
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Jalankan fungsi untuk membuat presentasi kosong
```
7. Sekarang jalankan `node hello.js` di command prompt untuk mengeksekusinya.

### **Mac**

1. Instal .NET6 atau yang lebih baru.  
1. Instal Node.js (https://nodejs.org/en/download/) dan tambahkan node.exe ke `PATH`.  
1. Instal edge-js.

$ mkdir aspose.slides.nodejs.net
 
$ cd aspose.slides.nodejs.net
 
$ npm install edge-js
```

```javascript
// Impor modul Aspose.Slides untuk manipulasi file PowerPoint
const asposeSlides = require('aspose.slides.via.net');

// Tambahkan kelas yang diperlukan dari asposeSlides
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Buat dan simpan presentasi kosong untuk mendemonstrasikan fungsionalitas dasar
function createEmptyPresentation() {
	
    // Inisialisasi presentasi kosong baru
    var emptyPresentation = new Presentation();
    
    // Simpan presentasi kosong dalam format PPTX
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Lepaskan sumber daya yang terkait dengan presentasi
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Jalankan fungsi untuk membuat presentasi kosong
9. Sekarang jalankan `node hello.js` di command prompt untuk mengeksekusinya.