---
title: Korlátozások és API különbségek
type: docs
weight: 100
url: /hu/nodejs-java/limitations-and-api-differences/
keywords:
- korlátozás
- API különbségek
- könyvtár importálása
- csomag összehasonlítás
- fájlok streamelése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Hasonlítsa össze az Aspose.Slides for Node.js via Java és az Aspose.Slides for Java közötti korlátozásokat és API különbségeket."
---
## **Nyilvános API különbségek**
A következő lista (példakódrészletekkel) néhány eltérést mutat az Aspose.Slides for Java és az Aspose.Slides for Node.js via Java API között.

### **Könyvtár importálása (csomag összehasonlítások)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Új Presentation példányosítása**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Fájlok és állandók streamelése**

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

### **Az Aspose.Slides for Node.js via Java API egyéb korlátai az Aspose.Slides for Java API-hoz képest**
1. Az adat importálása/exportálása Array, ArrayList, ResultSet stb. esetén nem támogatott.
1. A nyomtatás nem támogatott.