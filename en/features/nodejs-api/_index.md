---
title: Use Slides from Node.js
description: Process presentations in Node.js using a local runtime-backed binding.
type: docs
url: /features/nodejs-api/
weight: 380
feature_id: nodejs-api
feature_group: languages
translationKey: slides-feature-nodejs-api
feature_catalogue_version: 3
feature_guides:
- /slides/nodejs-java/installation/
- /slides/nodejs-net/installation/
---

## **Overview**

Use a Slides Node.js binding for presentation creation, editing and conversion in a server-side JavaScript application. The bindings use Java or .NET alongside Node.js, so package the required runtime with the application and follow that binding's setup instructions.

## **Usage example**

This example uses the local **Node.js via Java** binding, `aspose.slides.via.java`. Install that package and its required Java environment using the [installation guide](/slides/nodejs-java/installation/). Save the script as *create-presentation.js* and run it with Node.js. It creates a slide with a text box and saves *hello.pptx* in the working directory. No input file is needed.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const title = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 50, 50, 400, 100);
    title.getTextFrame().setText("Hello from Node.js");
    presentation.save("hello.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
process.exit(0);
```

The coordinates and dimensions are in points. The format argument selects PPTX explicitly. This standalone command exits after saving and releasing the presentation so the embedded JVM does not keep it running. Evaluation output carries a watermark; this script runs on Node.js with Java, not in a browser.

## **FAQ**

### **Is this a browser-only JavaScript library?**

No. These are Node.js bindings backed by a local runtime. Use their installation guides for the required environment.

### **Which local Node.js binding does this example use?**

It uses aspose.slides.via.java, backed by a local Java runtime. Use the [Node.js via Java guide](/slides/nodejs-java/installation/) for this example; the [Node.js via .NET binding](/slides/nodejs-net/installation/) has a separate setup and API surface.

### **How do I provide a filename and output format when saving from Node.js?**

Pass the destination path as the first argument and the explicit format as the second. The example writes a relative filename to the working directory and selects PPTX; choose a writable destination and the matching format for other outputs.

## **Guides**

- [Installation (Node.js via Java)](/slides/nodejs-java/installation/)
- [Installation (Node.js via .NET)](/slides/nodejs-net/installation/)
