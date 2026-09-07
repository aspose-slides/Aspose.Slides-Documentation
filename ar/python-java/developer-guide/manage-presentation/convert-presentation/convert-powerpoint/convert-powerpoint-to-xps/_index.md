---
title: تحويل عروض PowerPoint إلى XPS في Python
linktitle: PowerPoint إلى XPS
type: docs
weight: 70
url: /ar/python-java/convert-powerpoint-to-xps/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى XPS
- العرض إلى XPS
- PPT إلى XPS
- PPTX إلى XPS
- حفظ PPT كـ XPS
- حفظ PPTX كـ XPS
- تصدير PPT إلى XPS
- تصدير PPTX إلى XPS
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint بصيغة PPT و PPTX إلى XPS في Python باستخدام Aspose.Slides for Python عبر Java، باستخدام إعدادات تصدير افتراضية أو مخصصة."
---
## **نظرة عامة**

Aspose.Slides for Python via Java يتيح لك تحويل عروض PowerPoint إلى XPS عن طريق حفظ ملف PPT أو PPTX بصيغة XPS. يوضح هذا المقال متى قد يكون XPS مفيدًا ويظهر كيفية تصدير عرض باستخدام الإعدادات الافتراضية أو إعدادات [XpsOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xpsoptions/) المخصصة.

## **حول XPS**

XPS (XML Paper Specification) هو تنسيق مستند قائم على XML تم تطويره من قبل Microsoft. يصف صفحات ثابتة، preserving the layout of text and graphics for viewing and printing with compatible software.

## **متى تستخدم تنسيق XPS من Microsoft**

استخدم XPS عندما يتطلب سير عمل المستند ملفات بتخطيط ثابت للمشاركة أو الطباعة عبر أدوات متوافقة مع XPS. يحتاج المستلم إلى برنامج يدعم XPS. إذا كان سير عملك يتطلب PDF بدلاً من ذلك، راجع [Convert PowerPoint to PDF](/slides/ar/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
لتجربة تحويل عرض PPT أو PPTX إلى XPS، استخدم [free online converter](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}}

| عرض PowerPoint الإدخالي | مستند XPS الناتج |
| --- | --- |
| ![العرض الأصلي لــPowerPoint](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![العرض المحول إلى XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **تحويل XPS باستخدام Aspose.Slides**

استخدم طريقة [save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) من فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) مع [SaveFormat.Xps](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Xps) لتصدير عرض. يمكنك استخدام إعدادات التصدير الافتراضية أو توفير [XpsOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xpsoptions/) لتخصيص النتيجة.

كل مثال أدناه يبدأ الجهاز الافتراضي Java إذا لزم الأمر ويطلق سراح العرض بعد الاستخدام. استبدل اسم ملف الإدخال بالمسار إلى ملف PPT أو PPTX الخاص بك.

### **تحويل العروض إلى XPS باستخدام الإعدادات الافتراضية**

الشيفرة التالية بلغة Python تحول عرضًا إلى XPS باستخدام الإعدادات الافتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # حفظ العرض كوثيقة XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **تحويل العروض إلى XPS باستخدام إعدادات مخصصة**

المثال التالي يستخدم [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) لحفظ ملفات الميتافايل كصور PNG في مستند XPS الناتج:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # حفظ العرض باستخدام إعدادات XPS المخصصة.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **أسئلة شائعة**

**هل يمكنني حفظ XPS إلى تدفق بدلاً من ملف؟**

نعم. طريقة [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لديها إصدارات فرعية تقبل تدفق إخراج Java. باستخدام Python عبر Java، استخدم تدفق Java متوافق عبر JPype، مثل Java ByteArrayOutputStream، للحفاظ على البيانات المصدرة في الذاكرة.

**هل يتم تضمين الشرائح المخفية في ناتج XPS؟**

الشرائح المخفية مستثناة افتراضيًا. لتضمينها، اضبط [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) إلى `True` قبل الحفظ.

**هل يتم الحفاظ على الرسوم المتحركة وانتقالات الشرائح في XPS؟**

لا. XPS يحتوي على صفحات ثابتة، لذلك لا تُعرض الشرائح المصدرة الرسوم المتحركة أو تأثيرات الانتقال.