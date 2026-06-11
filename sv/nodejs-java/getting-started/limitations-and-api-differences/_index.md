---
title: Begränsningar och API-skillnader
type: docs
weight: 100
url: /sv/nodejs-java/limitations-and-api-differences/
keywords:
- begränsning
- API-skillnader
- import av bibliotek
- paketjämförelse
- strömning av filer
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Jämför begränsningarna och API-skillnaderna mellan Aspose.Slides för Node.js via Java och Aspose.Slides för Java."
---
## **Skillnader i offentligt API**
The following list (with sample code segments) shows some differences between Aspose.Slides for Java and Aspose.Slides for Node.js via Java APIs.

### **Import av bibliotek (paketjämförelser)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Instansiering av en ny Presentation**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Strömning av filer och konstanter**

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

### **Andra begränsningar för Aspose.Slides för Node.js via Java API jämfört med Aspose.Slides för Java API**
1. Import/export av data från en Array, ArrayList, ResultSet osv. stöds inte.
1. Utskrift stöds inte.