---
title: محدودیت‌ها و تفاوت‌های API
type: docs
weight: 100
url: /fa/nodejs-java/limitations-and-api-differences/
keywords:
- محدودیت
- تفاوت‌های API
- وارد کردن کتابخانه
- مقایسه بسته‌ها
- جریان‌سازی فایل‌ها
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "محدودیت‌ها و تفاوت‌های API بین Aspose.Slides برای Node.js از طریق Java و Aspose.Slides برای Java را مقایسه کنید."
---
## **تفاوت‌های API عمومی**
فهرست زیر (با نمونه‌های کد) برخی تفاوت‌های بین Aspose.Slides برای Java و Aspose.Slides برای Node.js از طریق API‌های Java را نشان می‌دهد.

### **وارد کردن کتابخانه (مقایسه بسته‌ها)**

**Aspose.Slides for Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides for Node.js via Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **ایجاد یک ارائه جدید**

**Aspose.Slides for Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides for Node.js via Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **جریان‌سازی فایل‌ها و ثابت‌ها**

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

### **محدودیت‌های دیگر Aspose.Slides برای Node.js از طریق API جاوا نسبت به Aspose.Slides برای جاوا**
1. وارد کردن/صادر کردن داده‌ها از Array، ArrayList، ResultSet و غیره پشتیبانی نمی‌شود.  
1. چاپ پشتیبانی نمی‌شود.