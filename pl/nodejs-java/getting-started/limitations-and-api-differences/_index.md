---
title: Ograniczenia i różnice w API
type: docs
weight: 100
url: /pl/nodejs-java/limitations-and-api-differences/
keywords:
- ograniczenie
- różnice w API
- importowanie biblioteki
- porównanie pakietów
- strumieniowanie plików
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Porównaj ograniczenia i różnice w API pomiędzy Aspose.Slides for Node.js via Java a Aspose.Slides for Java."
---
## **Różnice w publicznym API**
Poniższa lista (z fragmentami przykładowego kodu) pokazuje niektóre różnice między Aspose.Slides for Java a Aspose.Slides for Node.js przy użyciu interfejsów Java.

### **Importowanie biblioteki (Porównania pakietów)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Tworzenie nowej prezentacji**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Strumieniowanie plików i stałych**

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

### **Inne ograniczenia Aspose.Slides for Node.js przy użyciu interfejsu Java w porównaniu do Aspose.Slides for Java**
1. Importowanie/eksportowanie danych z Array, ArrayList, ResultSet itp. nie jest obsługiwane.
1. Drukowanie nie jest obsługiwane.