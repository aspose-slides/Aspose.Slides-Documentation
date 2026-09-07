---
title: تحويل عروض OpenDocument في Python
linktitle: تحويل OpenDocument
type: docs
weight: 10
url: /ar/python-java/convert-openoffice-odp/
keywords:
- تحويل ODP
- ODP إلى PDF
- ODP إلى HTML
- ODP إلى TIFF
- ODP إلى PPT
- ODP إلى PPTX
- ODP إلى XPS
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحويل عروض OpenDocument (ODP) إلى PDF وHTML وتنسيقات أخرى باستخدام Aspose.Slides for Python عبر Java، دون الحاجة إلى تثبيت OpenOffice أو LibreOffice."
---
## **المقدمة**

Aspose.Slides for Python via Java يسمح لك بتحويل عروض OpenDocument (ODP) إلى صيغ مثل PDF وHTML وTIFF وXPS وPPT وPPTX. يستخدم تحويل ODP نفس API تحويل PowerPoint: حمّل ملف المصدر باستخدام [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) وحدد صيغة الإخراج باستخدام [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/).

## **تحويل ODP إلى PDF**

اتبع [installation instructions](/slides/ar/python-java/installation/) قبل تشغيل المثال. ضع عرض ODP اسمه `pres.odp` في دليل العمل. الشيفرة التالية تبدأ JVM إذا لزم الأمر، تحمل العرض، وتحفظه كـ `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **عرض OpenDocument في تطبيقات مختلفة**

قد يظهر عرض ODP بشكل مختلف في PowerPoint وLibreOffice/OpenOffice Impress لأن هذه التطبيقات تدعم ميزات عرض مختلفة وسلوكيات تصيير مختلفة. راجع العروض المحولة عندما تعتمد تخطيطاتها على تنسيق معقد.

يمكن أن تؤثر اختلافات التوافق على:

- الجداول، بما في ذلك ترتيب تكدسها بالنسبة للأشكال الأخرى ودعم تعبئة الصور.
- دوران النص ومحاذاته.
- تعبئات الصورة والتدرج والنمط المطبقة على النص.
- القوائم المرقّمة والمرقّمة النقطية.

الصورة أدناه تُظهر قائمة تم إنشاؤها في LibreOffice Impress:

![مثال قائمة ODP في LibreOffice Impress](odp-list-example.png)

يحفظ Aspose.Slides قوائم ODP لتوافقها مع LibreOffice/OpenOffice Impress.

للتفاصيل حول توافق الميزات، راجع [Microsoft's guide to the OpenDocument Presentation format](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **التعليمات المتكررة**

**ماذا لو تغير تنسيق ملف ODP بعد التحويل؟**

تستخدم ODP وPowerPoint نماذج عرض مختلفة. قد تُظهر الجداول والخطوط وأنماط التعبئة بشكل مختلف. تحقق من توفر الخطوط المطلوبة، راجع الناتج، وضبط التخطيط أو التنسيق إذا لزم الأمر.

**هل أحتاج إلى تثبيت OpenOffice أو LibreOffice لتحويل ملفات ODP؟**

لا. Aspose.Slides for Python via Java يعالج العروض دون أي من هذين التطبيقين. يتطلب تشغيل Java متوافق وحزمة Python.

**هل يمكنني تخصيص إخراج PDF عند تحويل عرض ODP؟**

نعم. استخدم [PdfOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pdfoptions/) لتكوين إعدادات تصدير PDF، مثل جودة الصورة والضغط.

**هل يمكنني تحويل عروض ODP على خادم أو داخل حاوية؟**

نعم. ثبّت حزمة Python، وبيئة Java متوافقة، والخطوط المطلوبة لعروضك في البيئة المستهدفة. لا يلزم أي تطبيق مكتبي.