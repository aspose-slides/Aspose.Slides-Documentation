---
title: Limitações e Diferenças de API
type: docs
weight: 100
url: /pt/nodejs-java/limitations-and-api-differences/
keywords:
- limitação
- diferenças de API
- importação de biblioteca
- comparação de pacotes
- transmissão de arquivos
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Compare as limitações e diferenças de API entre Aspose.Slides para Node.js via Java e Aspose.Slides para Java."
---
## **Diferenças da API Pública**
A lista a seguir (com trechos de código de exemplo) mostra algumas diferenças entre Aspose.Slides para Java e Aspose.Slides para Node.js via APIs Java.

### **Importando biblioteca (Comparação de Pacotes)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Instanciando uma nova Apresentação**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Transmitindo arquivos e constantes**

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

### **Outras limitações do Aspose.Slides para Node.js via API Java em comparação com a API Aspose.Slides para Java**
1. Importar/exportar dados de um Array, ArrayList, ResultSet etc. não é suportado.
1. Impressão não é suportada.