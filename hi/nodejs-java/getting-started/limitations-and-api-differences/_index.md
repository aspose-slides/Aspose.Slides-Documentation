---
title: सीमाएँ और API अंतर
type: docs
weight: 100
url: /hi/nodejs-java/limitations-and-api-differences/
keywords:
- सीमा
- API अंतर
- लाइब्रेरी आयात करना
- पैकेज तुलना
- फ़ाइलों का स्ट्रीमिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java और Aspose.Slides for Java के बीच सीमाएँ और API अंतर की तुलना करें।"
---
## **सार्वजनिक API अंतर**
निम्नलिखित सूची (नमूना कोड खंडों सहित) Aspose.Slides for Java और Aspose.Slides for Node.js via Java APIs के बीच कुछ अंतर दिखाती है।

### **लाइब्रेरी आयात करना (पैकेज तुलना)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **नई प्रस्तुति बनाना**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **फ़ाइलों और स्थिरांक का स्ट्रीमिंग**

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

### **Aspose.Slides for Node.js via Java API की अन्य सीमाएँ, Aspose.Slides for Java API की तुलना में**
1. Array, ArrayList, ResultSet आदि से डेटा आयात/निर्यात का समर्थन नहीं है।
1. प्रिंटिंग का समर्थन नहीं है।