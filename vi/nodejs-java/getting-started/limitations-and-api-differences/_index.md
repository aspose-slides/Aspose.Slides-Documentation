---
title: Các hạn chế và sự khác biệt API
type: docs
weight: 100
url: /vi/nodejs-java/limitations-and-api-differences/
keywords:
- hạn chế
- sự khác biệt API
- nhập thư viện
- so sánh gói
- phát luồng tệp
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "So sánh các hạn chế và sự khác biệt API giữa Aspose.Slides cho Node.js thông qua Java và Aspose.Slides cho Java."
---
## **Khác biệt API Công cộng**
Danh sách sau (kèm các đoạn mã mẫu) cho thấy một số khác biệt giữa Aspose.Slides cho Java và Aspose.Slides cho Node.js thông qua các API Java.

### **Nhập thư viện (So sánh gói)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Tạo một bản trình bày mới**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Phát luồng tệp và hằng số**

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

### **Các hạn chế khác của Aspose.Slides cho Node.js thông qua API Java so với Aspose.Slides cho Java API**
1. Không hỗ trợ nhập/xuất dữ liệu từ Array, ArrayList, ResultSet, v.v.
1. Không hỗ trợ in.