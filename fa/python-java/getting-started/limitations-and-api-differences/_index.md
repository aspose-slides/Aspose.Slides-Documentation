---
title: محدودیت‌ها و تفاوت‌های API
type: docs
weight: 100
url: /fa/python-java/limitations-and-api-differences/
keywords: "node, powerpoint, محدودیت, api, تفاوت‌ها"
description: "محدودیت‌ها و تفاوت‌های api در Aspose.Slides برای Python از طریق Java."
---
## **بگ‌ها/محدودیت‌های شناخته‌شده**
کلاس‌های جاوا که خارج از یک بسته (در `default`) هستند نمی‌توانند import شوند.
به دلیل عدم پشتیبانی JVM، نمی‌توانید JVM را خاموش کنید و سپس دوباره راه‌اندازی کنید. همچنین نمی‌توانید بیش از یک نسخه از JVM را اجرا کنید.
ترکیب Python 64 بیتی با Java 32 بیتی و برعکس هنگام import ماژول jpype منجر به کرش می‌شود.

## **تفاوت‌های API عمومی**
فهرست زیر (با قطعات کد نمونه) برخی تفاوت‌ها بین Aspose.Slides برای جاوا و Aspose.Slides برای Python از طریق APIهای جاوا را نشان می‌دهد.

### **وارد کردن کتابخانه (مقایسه بسته‌ها)**

**Aspose.Slides برای جاوا**

```java
import com.aspose.slides.*;
```

**Aspose.Slides برای Python از طریق جاوا**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()
```

### **ایجاد نمونه جدید Presentation**

**Aspose.Slides برای جاوا**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides برای Python از طریق جاوا**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **پخش فایل‌ها و ثابت‌ها**

**Aspose.Slides برای جاوا**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides برای Python از طریق جاوا**

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

### **سایر محدودیت‌های Aspose.Slides برای Python از طریق API Java نسبت به Aspose.Slides برای Java API**

برای اطلاعات بیشتر درباره سایر محدودیت‌ها، لطفاً به مستندات jpype مراجعه کنید:
- https://jpype.readthedocs.io/en/latest/