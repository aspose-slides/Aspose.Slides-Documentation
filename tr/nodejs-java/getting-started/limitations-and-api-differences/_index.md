---
title: Sınırlamalar ve API Farklılıkları
type: docs
weight: 100
url: /tr/nodejs-java/limitations-and-api-differences/
keywords:
- sınırlama
- API farklılıkları
- kütüphane içe aktarma
- paket karşılaştırması
- dosya akışı
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile Aspose.Slides for Java arasındaki sınırlamaları ve API farklılıklarını karşılaştırın."
---
## **Genel API Farklılıkları**
Aşağıdaki liste (örnek kod bölümleriyle) Aspose.Slides for Java ile Aspose.Slides for Node.js via Java API'leri arasındaki bazı farkları gösterir.

### **Kütüphane İçe Aktarma (Paket Karşılaştırmaları)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Yeni Bir Sunum Oluşturma**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Dosyaları Akışa Aktarma ve Sabitler**

**Aspose.Slides for Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Node.js via Java**

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

### **Aspose.Slides for Node.js via Java API'nin Aspose.Slides for Java API'ye kıyasla Diğer Sınırlamaları**
1. Bir Array, ArrayList, ResultSet vb. veri içe/dışa aktarımı desteklenmez.
1. Yazdırma desteklenmez.