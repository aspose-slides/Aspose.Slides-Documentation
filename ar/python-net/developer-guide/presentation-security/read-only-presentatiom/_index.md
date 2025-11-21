---
title: حفظ العروض التقديمية في وضع القراءة فقط باستخدام Python
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/python-net/read-only-presentation/
keywords:
- قراءة فقط
- حماية العرض التقديمي
- منع التحرير
- PowerPoint
- العرض التقديمي
- Python
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة فقط باستخدام Aspose.Slides للـ Python عبر .NET، مما يوفر معاينات شرائح دقيقة دون تعديل عروضك التقديمية."
---

## **تطبيق وضع القراءة فقط**

في PowerPoint 2019، أضافت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد لحماية عرض تقديمي عندما

- تريد منع التعديلات غير المقصودة والحفاظ على محتوى العرض التقديمي آمنًا.  
- تريد إبلاغ الأشخاص أن العرض التقديمي الذي قدمته هو النسخة النهائية.  

بعد اختيارك لخيار **Always Open Read-Only** للعرض التقديمي، عندما يفتح المستخدمون العرض التقديمي، يرون توصية **Read-Only** وقد يرون رسالة بهذه الصيغة: *لمنع التغييرات غير المقصودة، قام المؤلف بتعيين هذا الملف ليُفتح كقراءة فقط.*

تُعد توصية القراءة فقط رادعًا بسيطًا لكنه فعال يثني عن التحرير لأن المستخدمين يتعين عليهم تنفيذ مهمة لإزالتها قبل أن يُسمح لهم بتحرير العرض التقديمي. إذا كنت لا تريد للمستخدمين إجراء تغييرات على العرض التقديمي وتريد إبلاغهم بذلك بطريقة لطيفة، فقد تكون توصية القراءة فقط خيارًا جيدًا لك.

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة أقدم من Microsoft PowerPoint — والتي لا تدعم الدالة التي تم تقديمها مؤخرًا — يتم تجاهل توصية **Read-Only** (يُفتح العرض التقديمي كالمعتاد).

Aspose.Slides for Python via .NET يتيح لك ضبط عرض تقديمي ليكون **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض التقديمي) يرون توصية **Read-Only**. يُظهر لك مثال الشيفرة التالي كيفية ضبط عرض تقديمي ليكون **Read-Only** في Python باستخدام Aspose.Slides:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات غير مقصودة على عرض PowerPoint. إذا قرر شخص متحمس — يعرف ما يفعله — تعديل عرضك التقديمي، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة فعلاً لمنع التحرير غير المصرح به، فإن استخدامك لـ [حمايات أكثر صرامة تتضمن التشفير وكلمات المرور](https://docs.aspose.com/slides/python-net/password-protected-presentation/) سيكون أفضل. 

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف “Read-Only recommended” عن الحماية بكلمة مرور الكاملة؟**

“Read-Only recommended” يعرض مجرد اقتراح لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [حماية بكلمة مرور](/slides/ar/python-net/password-protected-presentation/) تقيد فعليًا الفتح أو التحرير وتناسب عندما تحتاج إلى سيطرة أمان حقيقية.

**هل يمكن دمج “Read-Only recommended” مع العلامات المائية لزيادة تثبيط التحرير؟**

نعم. يمكن ربط التوصية بـ [العلامات المائية](/slides/ar/python-net/watermark/) كوسيلة ردع بصرية؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل يمكن لماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟**

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/python-net/password-protected-presentation/).

**كيف يرتبط “Read-Only recommended” بالإشارات “is_encrypted” و “is_write_protected”؟**

هما إشارات مختلفة. “Read-Only recommended” هو تنبيه ناعم اختياري؛ [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) و [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) يشيران إلى قيود كتابة أو قراءة فعلية تعتمد على كلمات مرور أو تشفير.