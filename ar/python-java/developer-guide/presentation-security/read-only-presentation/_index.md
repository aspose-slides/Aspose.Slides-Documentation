---
title: حفظ العروض التقديمية في وضع القراءة‑فقط باستخدام بايثون
linktitle: عرض قراءة‑فقط
type: docs
weight: 30
url: /ar/python-java/read-only-presentation/
keywords:
- قراءة فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- OpenDocument
- عرض
- Python
- Aspose.Slides
description: "قم بتحميل وحفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة‑فقط باستخدام Aspose.Slides للبايثون عبر جافا، مما يوفر معاينات شرائح دقيقة دون تعديل عروضك التقديمية."
---
## **مقدمة**

في PowerPoint 2019، قدمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد لحماية العرض عندما:

- تريد منع التعديلات غير المقصودة والحفاظ على محتوى العرض آمنًا.  
- تريد إبلاغ الأشخاص بأن العرض الذي قدمته هو النسخة النهائية.  

بعد اختيارك لخيار **Always Open Read-Only** للعرض، عندما يفتح المستخدمون العرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *To prevent accidental changes, the author has set this file to open as read-only.*

تعد توصية **Read-Only** وسيلة بسيطة لكنها فعّالة لمنع التعديل لأنها تتطلب من المستخدمين تنفيذ مهمة لإزالتها قبل السماح لهم بتحرير العرض. إذا كنت لا تريد أن يجري المستخدمون تغييرات على العرض وتريد إبلاغهم بذلك بطريقة لطيفة، فقد تكون توصية **Read-Only** خيارًا جيدًا لك.

> إذا تم فتح عرض محمي بتوصية **Read-Only** في تطبيق Microsoft PowerPoint أقدم—والذي لا يدعم الوظيفة التي تم تقديمها مؤخرًا—فإن توصية **Read-Only** يتم تجاهلها (يُفتح العرض كالمعتاد).

## **تطبيق وضع القراءة‑فقط**

Aspose.Slides for Python via Java يتيح لك ضبط العرض على **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا المثال كيفية ضبط العرض على **Read-Only** في Python باستخدام Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ملاحظة" %}} 

تُقصد توصية **Read-Only** ببساطة تثبيط التحرير أو منع المستخدمين من إجراء تغييرات غير مقصودة على عرض PowerPoint. إذا قرر شخصّ متحمّس—يعرف ما يفعله—تحرير عرضك، يمكنه بسهولة إزالة إعداد القراءة‑فقط. إذا كنت بحاجة ماسة لمنع التحرير غير المصرح به، فستكون الحمايات [مزيد من الحمايات الصارمة التي تتضمن التشفير وكلمات المرور](/slides/ar/python-java/password-protected-presentation/) هي الخيار الأنسب. 

{{% /alert %}} 

## **التعليمات المتكررة**

**كيف يختلف "Read-Only recommended" عن الحماية الكاملة بكلمة المرور؟**  
"Read-Only recommended" تُظهر مجرد اقتراح لفتح الملف في وضع القراءة‑فقط ويمكن تجاوزها بسهولة. [الحماية بكلمة المرور](/slides/ar/python-java/password-protected-presentation/) تحدّ فعليًا من الفتح أو التحرير وتناسب الحالات التي تحتاج فيها إلى ضوابط أمان حقيقية.

**هل يمكن دمج "Read-Only recommended" مع [العلامات المائية](/slides/ar/python-java/watermark/) لتثبيط التعديلات بصورة أكبر؟**  
نعم. يمكن إقران التوصية بـ [العلامات المائية](/slides/ar/python-java/watermark/) كوسيلة مرئية للردع؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل لا يزال بإمكان ماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟**  
نعم. التوصية لا تعيق التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/python-java/password-protected-presentation/).

**كيف يرتبط "Read-Only recommended" بالطرق [isEncrypted](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isEncrypted) و [isWriteProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isWriteProtected)؟**  
إنهما إشارات مختلفة. "Read-Only recommended" هي تنبيه ناعم اختياري؛ بينما [isWriteProtected](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isWriteProtected) و [isEncrypted](https://reference.aspose.com/slides/ar/python-java/aspose.slides/protectionmanager/#isEncrypted) تشير إلى قيود كتابة أو قراءة فعلية تعتمد على كلمات مرور أو تشفير.