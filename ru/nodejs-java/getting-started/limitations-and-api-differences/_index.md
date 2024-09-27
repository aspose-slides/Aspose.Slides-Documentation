---
title: Ограничения и различия API
type: docs
weight: 100
url: /ru/nodejs-java/limitations-and-api-differences/
keywords: "node, powerpoint, ограничение, api, различия"
description: "Ограничения и различия API Aspose.Slides для Node.js через Java."
---

## **Различия в публичном API**
Следующий список (с образцами кода) показывает некоторые различия между Aspose.Slides для Java и Aspose.Slides для Node.js через API Java.

### **Импорт библиотеки (Сравнение пакетов)**

**Aspose.Slides для Java**

```javascript
import com.aspose.slides.*;
```

**Aspose.Slides для Node.js через Java**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

```

### **Создание новой презентации**

**Aspose.Slides для Java**

```javascript
Presentation pres = new Presentation();
```

**Aspose.Slides для Node.js через Java**

```javascript
var pres = new aspose.slides.Presentation();
```

### **Потоковые файлы и константы**

**Aspose.Slides для Java**

```javascript
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides для Node.js через Java**

```javascript
var aspose = aspose || {};

aspose.slides = require("aspose.slides.via.java");

var fs = require("fs");
var readStream = fs.createReadStream("presentation.pptx");
aspose.slides.Presentation.createPresentationFromStream(readStream, function(err, pres) {
   if (err) {
      console.log("ошибка открытия презентации");
      return;
   }
   pres.save("result.pptx", aspose.slides.SaveFormat.Pptx));
   console.log('сохранено в файл');
});
```

### **Другие ограничения Aspose.Slides для Node.js через Java API по сравнению с Aspose.Slides для Java API**
1. Импорт/экспорт данных из Array, ArrayList, ResultSet и т.д. не поддерживается.
2. Печать не поддерживается.