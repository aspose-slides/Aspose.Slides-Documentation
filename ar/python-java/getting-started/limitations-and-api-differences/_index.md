---
title: القيود واختلافات واجهة برمجة التطبيقات
type: docs
weight: 100
url: /python-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, differences"
description: "قيود واختلافات واجهة برمجة التطبيقات لـ Aspose.Slides لـ Python عبر Java."
---
## **الأخطاء المعروفة / القيود**
لا يمكن استيراد فئات Java خارج حزمة (في `default`).
بسبب نقص دعم JVM، لا يمكنك إيقاف JVM ثم إعادة تشغيله، ولا يمكنك تشغيل أكثر من نسخة واحدة من JVM.
خلط Python بواجهة 64 بت مع Java بواجهة 32 بت والعكس يتسبب في عطل عند استيراد وحدة jpype.

## **اختلافات واجهة برمجة التطبيقات العامة**
تظهر القائمة التالية (مع مقاطع كود نموذجية) بعض الاختلافات بين Aspose.Slides لـ Java وAspose.Slides لـ Python عبر واجهات برمجة تطبيقات Java.

### **استيراد المكتبة (مقارنات الحزمة)**

**Aspose.Slides لـ Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides لـ Python عبر Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **إنشاء عرض تقديمي جديد**

**Aspose.Slides لـ Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides لـ Python عبر Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **تدفق الملفات والثوابت**

**Aspose.Slides لـ Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides لـ Python عبر Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **قيود أخرى لـ Aspose.Slides لـ Python عبر واجهة برمجة التطبيقات Java مقارنة بـ Aspose.Slides لـ Java API**

لمزيد من المعلومات حول القيود الأخرى، يرجى الرجوع إلى وثائق jpype: 
- https://jpype.readthedocs.io/en/latest/

