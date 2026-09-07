---
title: تحويل ODP إلى PPTX في بايثون
linktitle: ODP إلى PPTX
type: docs
weight: 10
url: /ar/python-java/convert-odp-to-pptx/
keywords:
- تحويل OpenDocument
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل ODP
- OpenDocument إلى PPTX
- ODP إلى PPTX
- حفظ ODP كـ PPTX
- تصدير ODP إلى PPTX
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحويل عروض ODP إلى PPTX باستخدام Aspose.Slides للغة بايثون عبر Java. استخدم مثال بايثون كامل دون الحاجة لتثبيت PowerPoint أو LibreOffice."
---
## **نظرة عامة**

يشرح هذا المقال كيفية تحويل عرض تقديمي بصيغة OpenDocument (ODP) إلى تنسيق PowerPoint (PPTX) باستخدام Aspose.Slides للغة Python عبر Java.

## **تحويل ODP إلى PPTX**

يمكن لفئة [العرض التقديمي](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) تحميل ملف ODP مباشرة. احفظ العرض التقديمي الذي تم تحميله بتنسيق PPTX باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/).

اتبع [تعليمات التثبيت](/slides/ar/python-java/installation/) قبل تشغيل المثال. ضع عرض ODP اسمه `AccessOpenDoc.odp` في الدليل العامل. يبدأ الشيفرة التالية JVM إذا لزم الأمر، يفتح ملف ODP، ويحفظه باسم `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # احفظ عرض ODP بصيغة PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **مثال حي**

جرّب تطبيق الويب [تحويل Aspose.Slides](https://products.aspose.app/slides/ar/conversion/) لرؤية تحويل ODP إلى PPTX مدعومًا من Aspose.Slides.

## **FAQ**

**هل أحتاج إلى تثبيت Microsoft PowerPoint أو LibreOffice لتحويل ODP إلى PPTX؟**

لا. Aspose.Slides للغة Python عبر Java يقرأ ويكتب ملفات العروض التقديمية دون الحاجة إلى أي من التطبيقين. تحتاج إلى حزمة Python وبيئة تشغيل Java متوافقة.

**هل يتم الحفاظ على الشرائح الرئيسية والتخطيطات والسمات أثناء التحويل؟**

يقوم Aspose.Slides بربط هيكل العرض التقديمي الأصلي وتنسيقه مع PPTX. ومع ذلك، تدعم صيغ ODP و PPTX ميزات مختلفة، لذا قد تبدو بعض العناصر مختلفة بعد التحويل. تأكد من توفير الخطوط المطلوبة ومراجعة العروض التي تحتوي على تنسيقات معقدة. راجع [تحويل OpenDocument](/slides/ar/python-java/convert-openoffice-odp/) للاطلاع على اعتبارات التوافق.

**هل يمكنني تحويل ملفات ODP المحمية بكلمة مرور؟**

نعم، عندما تزود كلمة المرور المطلوبة لفتح الملف. راجع [العروض التقديمية المحمية بكلمة مرور](/slides/ar/python-java/password-protected-presentation/) للحصول على تفاصيل حول تحميل الملفات المحمية قبل حفظها بصيغة أخرى.

**هل Aspose.Slides مناسب لخدمات التحويل السحابية أو المعتمدة على REST؟**

نعم. يمكنك استخدام Aspose.Slides للغة Python عبر Java في الخلفية مع بيئة تشغيل Java المطلوبة. للحصول على واجهة REST API، راجع [Aspose.Slides Cloud](https://products.aspose.cloud/slides/ar/family/).