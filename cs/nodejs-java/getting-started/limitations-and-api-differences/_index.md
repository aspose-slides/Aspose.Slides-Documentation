---
title: Omezení a rozdíly v API
type: docs
weight: 100
url: /cs/nodejs-java/limitations-and-api-differences/
keywords:
- omezení
- rozdíly v API
- importování knihovny
- porovnání balíčků
- streamování souborů
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Porovnejte omezení a rozdíly v API mezi Aspose.Slides pro Node.js přes Java a Aspose.Slides pro Java."
---
## **Rozdíly ve veřejném API**
Následující seznam (se vzorovými ukázkami kódu) zobrazuje některé rozdíly mezi Aspose.Slides pro Java a Aspose.Slides pro Node.js přes Java API.

### **Importování knihovny (Porovnání balíčků)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Instancování nové prezentace**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Streamování souborů a konstant**

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

### **Další omezení Aspose.Slides pro Node.js přes Java API ve srovnání s Aspose.Slides pro Java API**
1. Importování/exportování dat z Array, ArrayList, ResultSet atd. není podporováno.
1. Tisk není podporován.