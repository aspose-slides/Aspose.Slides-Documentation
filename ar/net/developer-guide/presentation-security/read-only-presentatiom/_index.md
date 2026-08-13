---
title: حفظ العروض التقديمية في وضع القراءة فقط في .NET
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/net/read-only-presentation/
keywords:
- القراءة فقط
- حماية العرض التقديمي
- منع التحرير
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بتحميل وحفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة فقط باستخدام Aspose.Slides for .NET، مع توفير معاينات دقيقة للشرائح دون تغيير عروضك التقديمية."
---
## **المقدمة**

في PowerPoint 2019، قدمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- ترغب في منع التعديلات غير المقصودة والحفاظ على محتوى عرضك التقديمي آمناً. 
- تريد تنبيه الأشخاص إلى أن العرض التقديمي الذي قدمته هو النسخة النهائية. 

بعد اختيارك الخيار **Always Open Read-Only** لعرض تقديمي، عندما يفتح المستخدمون العرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات غير المقصودة، قام المؤلف بضبط هذا الملف للفتح كقراءة فقط.*

توصية Read-Only هي رادع بسيط ولكنه فعال يثبط التحرير لأن على المستخدمين تنفيذ مهمة لإزالتها قبل أن يُسمح لهم بتحرير العرض التقديمي. إذا كنت لا تريد أن يقوم المستخدمون بإجراء تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فقد تكون توصية Read-Only خيارًا جيدًا لك. 

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة قديمة من Microsoft PowerPoint — التي لا تدعم الوظيفة التي تم تقديمها مؤخرًا — يتم تجاهل توصية **Read-Only** (يُفتح العرض بشكل عادي).

## **تطبيق وضع القراءة فقط**

يتيح لك Aspose.Slides for .NET تعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا الكود النموذجي كيفية تعيين عرض تقديمي إلى **Read-Only** بلغة C# باستخدام Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**ملاحظة**: توصية **Read-Only** تُقصد ببساطة تثبيط التحرير أو منع المستخدمين من إجراء تغييرات غير مقصودة على عرض PowerPoint. إذا قرر شخص ذا نية جيدة — يعرف ما يفعله — تعديل عرضك التقديمي، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة جادة لمنع التحرير غير المصرح به، فمن الأفضل لك استخدام [حمايات أكثر صرامة تشمل التشفير وكلمات المرور](https://docs.aspose.com/slides/ar/net/password-protected-presentation/). 

{{% /alert %}} 

## **الأسئلة الشائعة**

### ما الفرق بين 'Read-Only recommended' والحماية بكلمة مرور كاملة؟

'Read-Only recommended' يعرض فقط اقتراحًا لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [حماية بكلمة مرور](/slides/ar/net/password-protected-presentation/) تُقيد فعليًا الفتح أو التحرير وتكون مناسبة عندما تحتاج إلى ضوابط أمان حقيقية.

### هل يمكن دمج 'Read-Only recommended' مع العلامات المائية لتثبيط التعديلات أكثر؟

نعم. يمكن إقران التوصية بـ [العلامات المائية](/slides/ar/net/watermark/) كوسيلة بصرية رادعة؛ هما آليتان منفصلتان وتعملان بشكل جيد معًا.

### هل لا يزال الماكرو أو أداة خارجية يمكنها تعديل الملف عندما تكون التوصية مفعلة؟

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/net/password-protected-presentation/).

### كيف يرتبط 'Read-Only recommended' بالعلامات 'IsEncrypted' و 'IsWriteProtected'؟

إنها إشارات مختلفة. 'Read-Only recommended' هي مطالبة ناعمة واختيارية؛ [IsWriteProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/iswriteprotected/) و[IsEncrypted](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/isencrypted/) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات المرور أو التشفير.