---
title: 限制和 API 差异
type: docs
weight: 100
url: /zh/nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, 限制, api, 差异"
description: "通过 Java 的 Aspose.Slides for Node.js 的限制和 api 差异。"
---

## **公共 API 差异**
以下列表（带有示例代码段）显示了 Aspose.Slides for Java 和通过 Java 的 Aspose.Slides for Node.js APIs 之间的一些差异。

### **导入库（软件包比较）**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **实例化新的演示文稿**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **流文件和常量**

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
      console.log("打开演示文稿错误");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('已保存到文件');
});
```

### **与 Aspose.Slides for Java API 相比，通过 Java API 的 Aspose.Slides for Node.js 的其他限制**
1. 不支持从 Array、ArrayList、ResultSet 等导入/导出数据。
1. 不支持打印。