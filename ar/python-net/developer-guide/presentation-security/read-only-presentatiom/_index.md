---
title: حفظ العروض التقديمية في وضع القراءة فقط باستخدام بايثون
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/python-net/read-only-presentation/
keywords:
- قراءة فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT، PPTX) في وضع القراءة فقط باستخدام Aspose.Slides للبايثون عبر .NET، مما يوفر معاينات دقيقة للشرائح دون تعديل عروضك التقديمية."
---

## **تطبيق وضع القراءة فقط**

في PowerPoint 2019، قدمت مايكروسوفت إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى عرضك التقديمي آمنًا. 
- تريد إبلاغ الأشخاص أن العرض التقديمي الذي قدمته هو النسخة النهائية. 

بعد أن تختار خيار **Always Open Read-Only** لعرض تقديمي، عندما يفتح المستخدمون العرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات العرضية، قام المؤلف بضبط هذا الملف ليُفتح بوضع القراءة فقط.*

توصية القراءة فقط هي وسيلة بسيطة لكنها فعّالة لردع التعديل لأن المستخدمين يجب أن يقوموا بإجراء لإزالتها قبل أن يُسمح لهم بتعديل العرض التقديمي. إذا لم ترغب في أن يقوم المستخدمون بإجراء تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فإن توصية القراءة فقط قد تكون خيارًا جيدًا لك. 

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة أقدم من Microsoft PowerPoint—والتي لا تدعم الوظيفة التي تم تقديمها مؤخرًا—فإن توصية **Read-Only** تُتجاهل (يُفتح العرض بصورة طبيعية).

Aspose.Slides للبايثون عبر .NET يتيح لك ضبط عرض تقديمي على وضع **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا المثال البرمجي كيفية ضبط عرض تقديمي على وضع **Read-Only** باستخدام بايثون وAspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى ردع التعديل أو إيقاف المستخدمين عن إجراء تغييرات عرضية على عرض PowerPoint. إذا قرر شخص مُتحمس—يعرف ما يفعله—تعديل عرضك، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة فعلاً لمنع التعديل غير المصرّح به، فمن الأفضل استخدام [حمايات أكثر صرامة تتضمن تشفيرًا وكلمات مرور](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف 'Read-Only recommended' عن الحماية الكاملة بكلمة مرور؟**

'Read-Only recommended' يعرض فقط اقتراحًا لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [حماية كلمة المرور](/slides/ar/python-net/password-protected-presentation/) تقيد فعليًا الفتح أو التعديل وتكون مناسبة عندما تحتاج إلى ضوابط أمان حقيقية.

**هل يمكن دمج 'Read-Only recommended' مع العلامات المائية لزيادة ردع التعديلات؟**

نعم. يمكن الجمع بين التوصية و[العلامات المائية](/slides/ar/python-net/watermark/) كوسيلة بصرية للردع؛ فهما آليتان منفصلتان وتعملان بشكل جيد معًا.

**هل يمكن لماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟**

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/python-net/password-protected-presentation/).

**كيف ترتبط 'Read-Only recommended' بالعلامات 'is_encrypted' و'is_write_protected'؟**

إنها إشارات مختلفة. 'Read-Only recommended' هي مطالبة ناعمة واختيارية؛ [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) و[is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات مرور أو تشفير.