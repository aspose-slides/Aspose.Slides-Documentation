---
title: Kurulum
type: docs
weight: 70
url: /tr/nodejs-net/installation/
keywords:
- Aspose.Slides indir
- Aspose.Slides kur
- Aspose.Slides kurulumu
- Windows
- macOS
- Linux
- JavaScript
- Node.js
description: "Aspose.Slides for Node.js via .NET'i Windows, Linux veya macOS'ta kurun"
---
Aspose.Slides for Node.js via .NET, platformdan bağımsız bir API'dir ve `Node.js` ve `edge-js` köprüsü kurulu olan herhangi bir platformda (Windows, Linux ve MacOS) kullanılabilir.

## **NPM'den Kurulum**

Bu komutla [NPM](https://www.npmjs.com/) üzerinden Aspose.Slides for Node.js via .NET'i kolayca kurabilirsiniz:
```
$ npm install aspose.slides.via.net
```
Kurulum sırasında bir sorunla karşılaşırsanız, lütfen https://www.npmjs.com/package/edge-js adresine bakınız.

## **ZIP arşivinden kurulum**

Aspose.Slides for Node.js via .NET'i bir ZIP arşivinden kurup kullanmak için, bunun yerine bu talimatları izleyin:

### **Windows**

1. .NET6 veya üzerini kurun.
1. Node.js'i (https://nodejs.org/en/download/) kurun ve node.exe'yi `PATH`'e ekleyin.
1. edge-js'i kurun.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install -g edge-js
```
6. [Aspose.Slides for Node.js via .NET'i indir](https://releases.aspose.com/slides/tr/nodejs-net/) ve `aspose.slides.nodejs/node_modules/aspose.slides.via.net` dizinine çıkarın.
7. Aşağıdaki örnek kodu kullanarak `aspose.slides.nodejs.net` klasöründe `hello.js` adlı bir dosya oluşturun:

```javascript
// PowerPoint dosya manipülasyonu için Aspose.Slides modülünü içe aktar
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides'tan gerekli sınıfları ekle
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Temel işlevselliği göstermek için boş bir sunum oluştur ve kaydet
function createEmptyPresentation() {
	
    // Yeni bir boş sunum başlat
    var emptyPresentation = new Presentation();
    
    // Boş sunumu PPTX formatında kaydet
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Sunumla ilişkili kaynakları serbest bırak
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Boş bir sunum oluşturmak için fonksiyonu çalıştır
```

8. Şimdi komut istemcisinde `node hello.js` komutunu çalıştırarak çalıştırın.

### **Linux**

1. .NET6 veya üzerini kurun.
1. Node.js'i (https://nodejs.org/en/download/) kurun ve node.exe'yi `PATH`'e ekleyin.
1. edge-js'i kurun.
```
$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```
5. [Aspose.Slides for Node.js via Java'ı indir](https://releases.aspose.com/slides/tr/nodejs-net/) ve `aspose.slides.nodejs/node_modules/aspose.slides.via.net` dizinine çıkarın.
6. `aspose.slides.nodejs.net` klasöründe bu örnek kodu kullanarak `hello.js` adlı bir test dosyası oluşturun:

```javascript
// PowerPoint dosya manipülasyonu için Aspose.Slides modülünü içe aktar
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides'tan gerekli sınıfları ekle
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Temel işlevselliği göstermek için boş bir sunum oluştur ve kaydet
function createEmptyPresentation() {
	
    // Yeni bir boş sunum başlat
    var emptyPresentation = new Presentation();
    
    // Boş sunumu PPTX formatında kaydet
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Sunumla ilişkili kaynakları serbest bırak
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Boş bir sunum oluşturmak için fonksiyonu çalıştır
```
7. Şimdi komut istemcisinde `node hello.js` komutunu çalıştırarak çalıştırın.

### **Mac**

1. .NET6 veya üzerini kurun.
1. Node.js'i (https://nodejs.org/en/download/) kurun ve node.exe'yi `PATH`'e ekleyin.
1. edge-js'i kurun.

$ mkdir aspose.slides.nodejs.net

$ cd aspose.slides.nodejs.net

$ npm install edge-js
```

```javascript
// PowerPoint dosya manipülasyonu için Aspose.Slides modülünü içe aktar
const asposeSlides = require('aspose.slides.via.net');

// asposeSlides'tan gerekli sınıfları ekle
const { Presentation, SaveFormat, PdfOptions } = asposeSlides;

const fs = require('fs');
if (!fs.existsSync("out")) fs.mkdirSync("out");

// Temel işlevselliği göstermek için boş bir sunum oluştur ve kaydet
function createEmptyPresentation() {
	
    // Yeni bir boş sunum başlat
    var emptyPresentation = new Presentation();
    
    // Boş sunumu PPTX formatında kaydet
    emptyPresentation.save("out/emptyPresentation.pptx", SaveFormat.Pptx);
    
    // Sunumla ilişkili kaynakları serbest bırak
    emptyPresentation.dispose();
}

createEmptyPresentation(); // Boş bir sunum oluşturmak için fonksiyonu çalıştır
9. Şimdi komut istemcisinde `node hello.js` komutunu çalıştırarak çalıştırın.