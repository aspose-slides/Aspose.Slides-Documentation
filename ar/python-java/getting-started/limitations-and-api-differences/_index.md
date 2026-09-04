---
title: القيود واختلافات API
type: docs
weight: 100
url: /ar/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides for Python via Java
- اختلافات API
- Python
- Java
- JPype
- قيود JVM
- PowerPoint
description: "تعرف على قيود JVM واختلافات API بين Aspose.Slides for Java وPython عبر Java، بما في ذلك الاستيراد، تنظيف الموارد، ومعالجة الملفات."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يستخدم JPype للوصول إلى مكتبة Java من Python. توضح الأمثلة أدناه مقارنة استيراد الحزم، وإنشاء العروض التقديمية، ومعالجة الملفات في واجهتي البرمجة.

## **القيود المعروفة**

- **دورة حياة JVM:** يدعم JPype JVM واحد لكل عملية Python. بعد إغلاقه، لا يمكنك إعادة تشغيله في نفس العملية. ابدأه مرة واحدة وأعد استخدامه للعمليات اللاحقة على العروض التقديمية.
- **توافق البنية:** يجب أن تكون بنية Python و Java متطابقة. راجع [متطلبات النظام](/slides/ar/python-java/system-requirements/#python-java-and-jpype-requirements) للمزيد من التفاصيل.

انظر إلى [دليل مستخدم JPype](https://jpype.readthedocs.io/en/latest/userguide.html) للحصول على تفاصيل حول هذه القيود وتكامل Java.

## **اختلافات API العامة**

قارن بين أمثلة Java و Python أدناه. للحصول على تفاصيل الأعضاء في Python عبر Java، راجع [مرجع API](/slides/ar/python-java/api-reference/).

### **استيراد المكتبة**

Java يستورد الفئات من `com.aspose.slides`. في Python، استورد `asposeslides` قبل بدء JVM، ثم استورد الفئات من `asposeslides.api` بعد تشغيل JVM. استخدم [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) لتجنب بدء JVM قيد التشغيل بالفعل.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
تترك أمثلة Python JVM قيد التشغيل حتى ينتهي عملية Python. في دفتر ملاحظات، أعد استخدام JVM النشط عبر الخلايا. إذا تم إغلاقه بالفعل، أعد تشغيل نواة دفتر الملاحظات قبل استخدام كائنات Java مرة أخرى.
{{% /alert %}}

### **إنشاء عرض تقديمي**

Java يستخدم الكلمة المفتاحية `new`; Python يستدعي فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) مباشرة. حرر موارد العرض باستخدام [Presentation.dispose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#dispose) داخل كتلة `finally`.

كلا المثالين يحفظان عرضًا تقديميًا فارغًا باستخدام [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) و [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **قراءة الملفات واستخدام ثوابت التنسيق**

يمكن لـ Java تحميل عرض تقديمي من تدفق إدخال Java. في Python، اقرأ الملف كبيانات ثنائية ومرر البايتات الناتجة إلى [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#createpresentationfrombytes). كائن ملف Python ليس تدفق إدخال Java.

تتطلب الأمثلة أدناه وجود ملف `presentation.pptx` موجود في دليل العمل وتُحفظ نسخة كـ `result.pptx`. كلاهما يغلق ملف الإدخال ويحرر موارد العرض. مثال Python يقرأ كامل ملف الإدخال إلى الذاكرة.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل أحتاج إلى إعادة تشغيل JVM لكل عرض تقديمي؟**

لا. حافظ على تشغيل JVM وأنشئ وحرّر كائنات العرض حسب الحاجة. إيقاف تشغيل JVM يمنع عمليات Java المستقبلية في نفس عملية Python.

**هل يمكنني فتح عرض تقديمي مباشرة من مسار ملف؟**

نعم. مُنشئ [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) يقبل مسار ملف. استخدم المساعد القائم على البايتات عندما تكون بيانات العرض متاحة بالفعل كـ بايتات Python.

**هل يجب علي تغيير أسماء ثوابت التنسيق عند تحويل أمثلة Java إلى Python؟**

لا. على سبيل المثال، [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#pptx) يستخدم نفس التهجئة والتنسيق في كلا الواجهتين.