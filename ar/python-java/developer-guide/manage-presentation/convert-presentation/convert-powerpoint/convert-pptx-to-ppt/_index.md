---
title: تحويل PPTX إلى PPT في Python
linktitle: PPTX إلى PPT
type: docs
weight: 21
url: /ar/python-java/convert-pptx-to-ppt/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPTX
- PPTX إلى PPT
- حفظ PPTX كـ PPT
- تصدير PPTX إلى PPT
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تحويل PPTX إلى صيغة PPT القديمة في Python باستخدام Aspose.Slides for Python عبر Java. يتضمن مثالًا على الشيفرة وملاحظات حول التوافق والملفات المحمية."
---
## **نظرة عامة**

يتيح لك Aspose.Slides for Python عبر Java تحويل عرض تقديمي بصيغة PPTX إلى صيغة PPT القديمة المستخدمة في PowerPoint 97–2003 دون الحاجة إلى تثبيت Microsoft PowerPoint. قم بتحميل ملف PPTX واحفظه بصيغة PPT كما هو موضح أدناه.

## **تحويل PPTX إلى PPT**

حمّل الملف المصدر باستخدام فئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/)، ثم استدعِ [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) مع مسار الإخراج و[SaveFormat.Ppt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Ppt).

المثال التالي يبدأ آلة Java الافتراضية إذا لزم الأمر ويحول `template.pptx` إلى `output.ppt` باستخدام الخيارات الافتراضية. استبدل المسارات بأسماء ملفاتك الخاصة. يحرّر كتلة `finally` موارد العرض حتى إذا فشل الحفظ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# تحميل عرض PPTX.
presentation = Presentation("template.pptx")
try:
    # حفظ العرض التقديمي بصيغة PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

المعطى [SaveFormat.Ppt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/#Ppt) يحدد صيغة الإخراج؛ تغيير امتداد الملف وحده لا يحوّل العرض التقديمي. احفظ ملف PPTX الأصلي حتى تتمكن من العودة إليه إذا لم يكن لميزة أحدث مكافئ في PPT.

## **تحويل PPTX إلى صيغ أخرى**

يدعم Aspose.Slides أيضًا صيغ إخراج أخرى. راجع المقالات المقابلة للحصول على خيارات وصيغ مخصصة لكل تنسيق وأمثلة:

- [تحويل PowerPoint إلى PDF في Python](/slides/ar/python-java/convert-powerpoint-to-pdf/)
- [تحويل PowerPoint إلى XPS في Python](/slides/ar/python-java/convert-powerpoint-to-xps/)
- [تحويل PowerPoint إلى HTML في Python](/slides/ar/python-java/convert-powerpoint-to-html/)
- [حفظ العروض التقديمية بصيغة ODP في Python](/slides/ar/python-java/save-presentation/)
- [تحويل PowerPoint إلى PNG في Python](/slides/ar/python-java/convert-powerpoint-to-png/)

## **الأسئلة المتكررة**

**هل جميع تأثيرات وميزات PPTX تبقى بعد التحويل إلى PPT؟**

ليس دائمًا. صيغة PPT القديمة لا تدعم كل الميزات المتاحة في PPTX. قد تُبسط بعض التأثيرات أو الكائنات أو السلوكيات أو تُعرض بشكل مختلف. راجع العرض التقديمي المحوَّل في المشاهد المستهدف، خاصةً عندما يحتوي على ميزات PowerPoint الأحدث.

**هل يمكنني تحويل الشرائح المحددة فقط إلى PPT؟**

الحفظ بصيغة PPT يكتب العرض التقديمي بالكامل. لتحويل شرائح محددة، أنشئ عرضًا تقديميًا جديدًا، احذف شريحةه الفارغة الأولية، استنسخ الشرائح المطلوبة إليه، واحفظه كـ PPT. راجع [استنساخ الشرائح في Python](/slides/ar/python-java/clone-slides/).

**هل يمكنني تحويل ملف PPTX محمي بكلمة مرور؟**

نعم، إذا قدمت كلمة المرور الصحيحة عند تحميل العرض التقديمي المصدر. يمكنك أيضًا تكوين الحماية لملف الإخراج. راجع [العروض التقديمية محمية بكلمة مرور](/slides/ar/python-java/password-protected-presentation/).