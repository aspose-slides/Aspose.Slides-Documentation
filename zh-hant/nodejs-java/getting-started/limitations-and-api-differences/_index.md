---
title: 限制與 API 差異
type: docs
weight: 100
url: /zh-hant/nodejs-java/limitations-and-api-differences/
keywords:
- 限制
- API 差異
- 匯入程式庫
- 套件比較
- 串流檔案
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "比較 Aspose.Slides for Node.js via Java 與 Aspose.Slides for Java 之間的限制與 API 差異。"
---
## **公開 API 差異**
以下清單（附範例程式碼段落）顯示 Aspose.Slides for Java 與透過 Java API 的 Aspose.Slides for Node.js 之間的一些差異。

### **匯入程式庫（套件比較）**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **建立新的簡報實例**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **串流檔案與常數**

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

### **與 Aspose.Slides for Java API 相比，Aspose.Slides for Node.js via Java API 的其他限制**
1. 不支援從 Array、ArrayList、ResultSet 等匯入/匯出資料。
1. 不支援列印。