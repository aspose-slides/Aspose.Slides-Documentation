---
title: تصدير العروض التقديمية إلى XAML باستخدام Python عبر Java
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/python-java/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- بايثون
- جافا
- Aspose.Slides
description: "تصدير عروض PowerPoint و OpenDocument إلى XAML باستخدام Aspose.Slides للغة Python عبر Java. استخدم الخيارات الافتراضية أو قم بتضمين الشرائح المخفية."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تصدير عروض PowerPoint وعروض OpenDocument إلى XAML باستخدام Aspose.Slides للغة Python عبر Java. تُعرّف XAML، وتظهر كيفية التصدير بالإعدادات الافتراضية، وتوضح كيفية تضمين الشرائح المخفية باستخدام [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/).

تتطلب الأمثلة Aspose.Slides للغة Python عبر Java وبيئة تشغيل Java متوافقة. ضع `pres.pptx` في دليل العمل الحالي. كل مثال يبدأ الـ JVM فقط إذا لم يكن قيد التشغيل بالفعل.

## **حول XAML**

XAML (Extensible Application Markup Language) هي لغة مبنية على XML لوصف واجهات المستخدم. تُستخدم من قبل إطارات عمل مثل Windows Presentation Foundation (WPF). يمكنك إنشاء وتحرير XAML باستخدام مصمم بصري أو محرر نصوص.

## **تصدير العروض إلى XAML باستخدام الخيارات الافتراضية**

أنشئ كائن [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) من ملف الإدخال، ثم مرّر كائن [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/) إلى [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لتصدير باستخدام الإعدادات الافتراضية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **تصدير العروض إلى XAML باستخدام خيارات مخصصة**

استخدم [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/) لتكوين عملية التصدير. لتضمين الشرائح المخفية، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) مع القيمة `True` قبل الحفظ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**كيف يمكنني اختيار خط احتياطي عندما يكون الخط الأصلي غير متوفر؟**

استخدم [setDefaultRegularFont](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) على كائن [XamlOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/) الخاص بك لتحديد خط احتياطي. تأكد من أن الخط المحدد متوفر في بيئة التصدير.

**هل يمكنني استخدام العلامات المصدرة في أي إطار عمل XAML؟**

تختلف إطارات عمل XAML في العناصر والميزات التي تدعمها. اختبر العلامات المصدرة في إطار العمل المستهدف قبل دمجها في تطبيق.

**هل يتم تصدير الشرائح المخفية افتراضيًا؟**

لا. لتضمينها، استدعِ [setExportHiddenSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) مع القيمة `True`. احتفظ به مضبوطًا على `False` لاستبعادها.