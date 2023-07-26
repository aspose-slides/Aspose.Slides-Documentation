---
title: Limitations and API Differences
type: docs
weight: 10
url: /nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, differences"
description: "Aspose.Slides for Node.js via Java limitations and api differences."
---

## **Public API Differences**
The following list (with sample code segments) shows some differences between Aspose.Slides for Java and Aspose.Slides for Node.js via Java APIs.
### **Importing library (Package Comparisons)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides");

```
### **Instantiating a new Presentation**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```
### **Streaming Files and Constants**

**Aspose.Slides for Java**

```javascript
InputStream inputstream = new FileInputStream(“Pres1.pptx”);
Presentation pres = new Presentation(inputstream);
pres.save(“result.pptx”, SaveFormat.Pptx);
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides");
var fs = require("fs");
var readStream = fs.createReadStream("Pres1.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(pres, err) {
   if (err) {
      console.log("open Presentation error");
      return;
   }
   Presentation.save('result.pptx', SaveFormat.Pptx));
   console.log('saved to file');
});

```
## **Other Limitations of Aspose.Slides for Node.js via Java API compared to Aspose.Slides for Java API**
1. Importing/exporting data from an Array, ArrayList, ResultSet etc. is not supported.
1. Printing is not supported.

