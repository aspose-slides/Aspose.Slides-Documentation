---
title: Limitazioni e differenze API
type: docs
weight: 100
url: /it/nodejs-java/limitations-and-api-differences/
keywords:
- limitazione
- differenze API
- importazione della libreria
- confronto dei pacchetti
- streaming di file
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Confronta le limitazioni e le differenze API tra Aspose.Slides per Node.js tramite Java e Aspose.Slides per Java."
---
## **Differenze API Pubbliche**
L'elenco seguente (con segmenti di codice di esempio) mostra alcune differenze tra Aspose.Slides per Java e Aspose.Slides per Node.js tramite le API Java.

### **Importazione della libreria (Confronti dei pacchetti)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides per Node.js tramite Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Istanziare una nuova Presentazione**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides per Node.js tramite Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Streaming di file e costanti**

**Aspose.Slides for Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides per Node.js tramite Java**

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

### **Altre limitazioni di Aspose.Slides per Node.js tramite l'API Java rispetto all'API Aspose.Slides per Java**
1. L'importazione/esportazione di dati da un Array, ArrayList, ResultSet ecc. non è supportata.
2. La stampa non è supportata.