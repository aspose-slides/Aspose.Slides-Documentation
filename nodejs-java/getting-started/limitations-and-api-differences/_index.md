---
title: Limitations and API Differences
type: docs
weight: 100
url: /nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, differences"
description: "Aspose.Slides for Node.js via Java limitations and api differences."
---

## **Public API Differences**
The following list (with sample code segments) shows some differences between Aspose.Slides for Java and Aspose.Slides for Node.js via Java APIs.
https://github.com/joeferner/node-java?tab=readme-ov-file#quick-examples
### **Importing library (Package Comparisons)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('saved to file');
});
```

## **Troubleshooting the Usage of Aspose.Slides for Node.js via Java**
Aspose.Slides for Node.js via Java works with Java through the node-java library, so please refer to its documentation for assistance.
https://github.com/joeferner/node-java
### **Solutions to some common issues**
**.forEach usage**
Example of an code snippet:
```javascript
presentation.getCommentAuthors().forEach(function(commentAuthor) {
```
Example of an exception thrown:
Error: Error running instance method
java.lang.NullPointerException
Solution: add .toArray() before .forEach

Example of an exception thrown:
SyntaxError: missing ) after argument list
Solution: Check the correctness of the closing parentheses for the .forEach block.

**java type casting**
Example of an code snippet:
```javascript
java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.76, 0.59);
```
Example of an exception thrown:
Error: Could not find method "com.aspose.slides.Point2DFloat(java.lang.Double, java.lang.Double)" on class "class com.as
pose.slides.Point2DFloat". Possible matches:
  public com.aspose.slides.Point2DFloat()
  public com.aspose.slides.Point2DFloat(float,float)
Solution: Cast the argument values to the float type
```javascript
java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(0.76), java.newFloat(0.59));
```
### **Other Limitations of Aspose.Slides for Node.js via Java API compared to Aspose.Slides for Java API**
1. Importing/exporting data from an Array, ArrayList, ResultSet etc. is not supported.
1. Printing is not supported.

