---
title: Batasan dan Perbedaan API
type: docs
weight: 100
url: /id/nodejs-java/limitations-and-api-differences/
keywords:
- batasan
- perbedaan API
- mengimpor pustaka
- perbandingan paket
- streaming file
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Bandingkan batasan dan perbedaan API antara Aspose.Slides untuk Node.js via Java dan Aspose.Slides untuk Java."
---
## **Perbedaan API Publik**
Daftar berikut (dengan segmen kode contoh) menunjukkan beberapa perbedaan antara Aspose.Slides untuk Java dan Aspose.Slides untuk Node.js melalui API Java.

### **Mengimpor pustaka (Perbandingan Paket)**

**Aspose.Slides untuk Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides untuk Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Membuat Presentation baru**

**Aspose.Slides untuk Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides untuk Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Streaming File dan Konstanta**

**Aspose.Slides untuk Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides untuk Node.js via Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("open Presentation error");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
   console.log('saved to file');
});
```

### **Batasan Lain dari Aspose.Slides untuk Node.js melalui API Java dibandingkan dengan Aspose.Slides untuk Java API**
1. Mengimpor/mengekspor data dari Array, ArrayList, ResultSet, dll. tidak didukung.
1. Pencetakan tidak didukung.