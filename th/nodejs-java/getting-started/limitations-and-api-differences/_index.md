---
title: ข้อจำกัดและความแตกต่างของ API
type: docs
weight: 100
url: /th/nodejs-java/limitations-and-api-differences/
keywords:
  - ข้อจำกัด
  - ความแตกต่างของ API
  - การนำเข้าไลบรารี
  - การเปรียบเทียบแพ็กเกจ
  - การสตรีมไฟล์
  - PowerPoint
  - OpenDocument
  - การนำเสนอ
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "เปรียบเทียบข้อจำกัดและความแตกต่างของ API ระหว่าง Aspose.Slides for Node.js via Java กับ Aspose.Slides for Java."
---
## **ความแตกต่างของ API สาธารณะ**
รายการต่อไปนี้ (พร้อมตัวอย่างโค้ด) แสดงความแตกต่างบางอย่างระหว่าง Aspose.Slides for Java และ Aspose.Slides for Node.js ผ่าน Java API

### **การนำเข้าไลบรารี (เปรียบเทียบแพ็กเกจ)**
**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **การสร้าง Presentation ใหม่**
**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **การสตรีมไฟล์และคอนสแตนท์**
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

### **ข้อจำกัดอื่น ๆ ของ Aspose.Slides for Node.js ผ่าน Java API เมื่อเทียบกับ Aspose.Slides for Java API**
1. การนำเข้า/ส่งออกข้อมูลจาก Array, ArrayList, ResultSet เป็นต้น ไม่ได้รับการสนับสนุน
2. การพิมพ์ไม่ได้รับการสนับสนุน