---
title: تحويل عروض PowerPoint إلى XML في Python عبر Java
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/python-java/convert-powerpoint-to-xml/
keywords:
- تحويل PowerPoint إلى XML
- تحويل العرض التقديمي إلى XML
- PPT إلى XML
- PPTX إلى XML
- ODP إلى XML
- عرض PowerPoint XML
- SaveFormat.Xml
- حفظ العرض التقديمي كملف XML
- تصدير العرض التقديمي إلى XML
- تدفق XML
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint ومستندات OpenDocument إلى ملفات أو تدفقات PowerPoint XML في Python عبر Java باستخدام Aspose.Slides for Python via Java."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يمكنه تحويل عروض PowerPoint إلى تنسيق PowerPoint XML Presentation. يكون الناتج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص بنية العرض، أو استكشاف المستندات التي تم إنشاؤها، أو مقارنة النتيجة في اختبارات آلية، أو دمجه مع سير عمل يستهلك XML بدلاً من حزمة عرض تقديمي.

استخدم طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع القيمة [Xml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Xml) من الفئة [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/) . يمكنك كتابة النتيجة مباشرةً إلى ملف أو إلى تدفق.

{{% alert color="info" title="ملاحظة" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Xml) ينشئ PowerPoint XML Presentation. لا يستخرج الأجزاء الفردية من Office Open XML المخزنة داخل حزمة PPTX. إذا كنت بحاجة إلى الأجزاء الدقيقة لحزمة PPTX، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.

{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمّل عرضًا تقديميًا أصلاً باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) ، ثم مرّر مسار الإخراج و[SaveFormat.Xml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Xml) إلى [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض PPTX إلى ملف XML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **كتابة ناتج XML إلى تدفق**

استخدم نسخة الدالة التي تقبل تدفقًا من [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) عندما يجب أن يبقى XML في الذاكرة أو يُمرّر إلى مكوّن آخر، مثل خدمة ويب أو موفر تخزين أو خط أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) ويحصل على XML الناتج ككائن bytes في بايثون:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # مرّر xml_data إلى المكوّن التالي في سير العمل.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **مقارنة XML مع صيغ العرض والتصدير**

اختر صيغة الإخراج وفقًا لكيفية استخدام النتيجة:

| الصيغة | الإخراج | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | فحص البنية، استكشاف الأخطاء، مقارنة الناتج المُنشأ، وتكامل يعتمد على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint القديم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint عادي وتبادل العروض |
| PDF أو TIFF | صفحات ثابتة أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG أو JPEG أو SVG | تمثيل مصور لشريحة واحدة | الصور المصغرة، المعاينات، وملفات الصور |
| HTML أو HTML5 | ناتج عرض موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT و PPTX، يُقصد من ناتج XML أساسًا للفحص وسير العمل القائم على البيانات. وعلى عكس PDF و TIFF و HTML وصيغ صور الشرائح، فهو يمثل بيانات العرض بدلاً من تصيير الشرائح كصفحات أو أصول مرئية. جدول [الصيغ المدعومة](/slides/ar/python-java/supported-file-formats/) يدرج PowerPoint XML Presentation كصيغة حفظ فقط، لذا لا تستخدمه عندما يتطلب سير العمل تحميل الملف المصدر مرة أخرى إلى Aspose.Slides لمزيد من التحرير.

## **الأسئلة المتكررة**

**هل تصدير XML هو نفسه حفظ ملف PPTX؟**

لا. PPTX هي حزمة تحتوي على عدة أجزاء من Office Open XML، بينما [SaveFormat.Xml](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Xml) ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ ناتج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفق إخراج Java قابل للكتابة إلى [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save). على سبيل المثال، استخدم [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المصدر مرة أخرى؟**

لا. PowerPoint XML Presentation يُدعم حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو صيغة عرض مدعومة أخرى عندما تكون الحاجة إلى تحرير ذهابًا وإيابًا.

**هل تقوم تحويلات XML بتصيير كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرضٍ مُنظمة. استخدم PDF أو TIFF للحصول على مخرج موجه للصفحات، أو PNG أو JPEG أو SVG للحصول على صور شرائح فردية.