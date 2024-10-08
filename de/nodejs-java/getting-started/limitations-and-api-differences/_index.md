---
title: Einschränkungen und API-Unterschiede
type: docs
weight: 100
url: /de/nodejs-java/einschraenkungen-und-api-unterschiede/
keywords: "node, powerpoint, einschränkung, api, unterschiede"
description: "Einschränkungen und API-Unterschiede von Aspose.Slides für Node.js über Java."
---

## **Öffentliche API-Unterschiede**
Die folgende Liste (mit Beispielcode-Segmenten) zeigt einige Unterschiede zwischen Aspose.Slides für Java und Aspose.Slides für Node.js über Java APIs.

### **Bibliothek importieren (Paketvergleiche)**

**Aspose.Slides für Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides für Node.js über Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Instanziierung einer neuen Präsentation**

**Aspose.Slides für Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides für Node.js über Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Streaming-Dateien und Konstanten**

**Aspose.Slides für Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides für Node.js über Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("Fehler beim Öffnen der Präsentation");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('in Datei gespeichert');
});
```

### **Andere Einschränkungen von Aspose.Slides für Node.js über Java API im Vergleich zur Aspose.Slides für Java API**
1. Importieren/Exportieren von Daten aus einem Array, ArrayList, ResultSet usw. wird nicht unterstützt.
1. Drucken wird nicht unterstützt.