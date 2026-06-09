---
title: Περιορισμοί και Διαφορές API
type: docs
weight: 100
url: /el/nodejs-java/limitations-and-api-differences/
keywords:
- περιορισμός
- διαφορές API
- εισαγωγή βιβλιοθήκης
- σύγκριση πακέτων
- ροή αρχείων
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Συγκρίνετε τους περιορισμούς και τις διαφορές API μεταξύ Aspose.Slides for Node.js μέσω Java και Aspose.Slides for Java."
---
## **Διαφορές Δημόσιου API**
Η παρακάτω λίστα (με δείγματα κώδικα) δείχνει ορισμένες διαφορές μεταξύ του Aspose.Slides for Java και του Aspose.Slides for Node.js μέσω Java API.

### **Εισαγωγή βιβλιοθήκης (Συγκρίσεις Πακέτων)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Δημιουργία νέας Παρουσίασης**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Ροή Αρχείων και Σταθερών**

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

### **Άλλοι περιορισμοί του Aspose.Slides for Node.js μέσω Java API σε σύγκριση με το Aspose.Slides for Java API**
1. Η εισαγωγή/εξαγωγή δεδομένων από Array, ArrayList, ResultSet κ.λπ. δεν υποστηρίζεται.
1. Η εκτύπωση δεν υποστηρίζεται.