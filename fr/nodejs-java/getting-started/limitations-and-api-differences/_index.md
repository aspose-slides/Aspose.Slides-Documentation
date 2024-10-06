---
title: Limitations et Différences d'API
type: docs
weight: 100
url: /nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, différences"
description: "Limitations et différences d'API d'Aspose.Slides pour Node.js via Java."
---

## **Différences de l'API Publique**
La liste suivante (avec des segments de code d'exemple) montre certaines différences entre Aspose.Slides pour Java et Aspose.Slides pour Node.js via les API Java.

### **Importation de la bibliothèque (Comparaisons de paquets)**

**Aspose.Slides pour Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides pour Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Instanciation d'une nouvelle Présentation**

**Aspose.Slides pour Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides pour Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Fichiers et Constantes de Streaming**

**Aspose.Slides pour Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides pour Node.js via Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("erreur d'ouverture de la présentation");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('enregistré dans le fichier');
});
```

### **Autres Limitations d'Aspose.Slides pour Node.js via l'API Java par rapport à l'API Java d'Aspose.Slides**
1. L'importation/exportation de données depuis un Array, ArrayList, ResultSet etc. n'est pas supportée.
1. L'impression n'est pas supportée.