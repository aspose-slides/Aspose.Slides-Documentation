---
title: القيود والفروقات في واجهة برمجة التطبيقات
type: docs
weight: 100
url: /nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, differences"
description: "قيود وفروقات واجهة برمجة التطبيقات لـ Aspose.Slides لـ Node.js عبر Java."
---

## **فروقات واجهة البرمجة العامة**
تُظهر القائمة التالية (مع مقاطع كود عينة) بعض الفروقات بين Aspose.Slides لـ Java و Aspose.Slides لـ Node.js عبر واجهات برمجة التطبيقات Java.

### **استيراد المكتبة (مقارنات الحزمة)**

**Aspose.Slides لـ Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides لـ Node.js عبر Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **إنشاء عرض تقديمي جديد**

**Aspose.Slides لـ Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides لـ Node.js عبر Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **تدفق الملفات والثوابت**

**Aspose.Slides لـ Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides لـ Node.js عبر Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("فتح العرض التقديمي خطأ");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('تم الحفظ في الملف');
});
```

### **قيود أخرى لـ Aspose.Slides لـ Node.js عبر واجهة برمجة التطبيقات Java مقارنةً بـ Aspose.Slides لـ Java**
1. استيراد/تصدير البيانات من Array و ArrayList و ResultSet وغيرها غير مدعوم.
2. الطباعة غير مدعومة.