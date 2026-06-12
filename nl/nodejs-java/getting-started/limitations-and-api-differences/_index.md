---
title: Beperkingen en API-verschillen
type: docs
weight: 100
url: /nl/nodejs-java/limitations-and-api-differences/
keywords:
- beperking
- API-verschillen
- bibliotheek importeren
- pakketvergelijking
- bestanden streamen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Vergelijk de beperkingen en API-verschillen tussen Aspose.Slides for Node.js via Java en Aspose.Slides for Java."
---
## **Openbare API‑verschillen**
De onderstaande lijst (met voorbeeldcodefragmenten) toont enkele verschillen tussen Aspose.Slides for Java en Aspose.Slides for Node.js via Java‑API's.

### **Importeren van bibliotheek (pakketvergelijkingen)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Een nieuwe presentatie instantieren**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Bestanden en constanten streamen**

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

### **Andere beperkingen van Aspose.Slides for Node.js via Java API ten opzichte van Aspose.Slides for Java API**
1. Het importeren/exporteren van gegevens vanuit een Array, ArrayList, ResultSet enz. wordt niet ondersteund.
1. Afdrukken wordt niet ondersteund.