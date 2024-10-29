---
title: Limitaciones y Diferencias de la API
type: docs
weight: 100
url: /es/nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitación, api, diferencias"
description: "Limitaciones y diferencias de la API de Aspose.Slides para Node.js a través de Java."
---

## **Diferencias en la API Pública**
La siguiente lista (con segmentos de código de ejemplo) muestra algunas diferencias entre Aspose.Slides para Java y Aspose.Slides para Node.js a través de las APIs de Java.

### **Importación de biblioteca (Comparaciones de Paquetes)**

**Aspose.Slides para Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides para Node.js a través de Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
```

### **Instanciando una nueva Presentación**

**Aspose.Slides para Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides para Node.js a través de Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Archivos de Transmisión y Constantes**

**Aspose.Slides para Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides para Node.js a través de Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("error al abrir la presentación");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('guardado en archivo');
});
```

### **Otras Limitaciones de Aspose.Slides para Node.js a través de la API de Java en comparación con la API de Aspose.Slides para Java**
1. La importación/exportación de datos desde un Array, ArrayList, ResultSet etc. no es compatible.
1. La impresión no es compatible.