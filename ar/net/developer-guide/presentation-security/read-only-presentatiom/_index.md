---
title: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/net/read-only-presentation/
keywords: "إعداد للقراءة فقط, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "عرض تقديمي PowerPoint للقراءة فقط في C# أو .NET"
---

## **تطبيق وضع القراءة فقط**

في PowerPoint 2019، قدمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى عرضك التقديمي آمنًا.
- تريد تنبيه الأشخاص إلى أن العرض التقديمي الذي قدمته هو النسخة النهائية.

بعد اختيارك لخيار **Always Open Read-Only** لعرض تقديمي، عند فتح المستخدمين للعرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات العرضية، قام المؤلف بتعيين هذا الملف للفتح كقراءة فقط.*

توصية القراءة فقط هي رادع بسيط ولكنه فعال يمنع التحرير لأن المستخدمين يجب أن يقوموا بإجراء لإزالتها قبل أن يُسمح لهم بتحرير العرض التقديمي. إذا كنت لا تريد أن يقوم المستخدمون بإجراء تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فقد تكون توصية القراءة فقط خيارًا جيدًا لك.

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في تطبيق Microsoft PowerPoint أقدم—الذي لا يدعم الوظيفة التي تم تقديمها مؤخرًا—فإن توصية **Read-Only** يتم تجاهلها (يُفتح العرض بشكل طبيعي).

تتيح لك Aspose.Slides for .NET تعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا الشيفرة العينية كيفية تعيين عرض تقديمي إلى **Read-Only** في C# باستخدام Aspose.Slides:
```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات عرضية على عرض PowerPoint. إذا قرر شخص متحمس—يعرف ما يفعله—تحرير عرضك، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة ماسة لمنع التحرير غير المصرح به، فمن الأفضل استخدام [حمايات أكثر صرامة تتضمن التشفير وكلمات المرور](https://docs.aspose.com/slides/net/password-protected-presentation/). 

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف "Read-Only recommended" عن الحماية بكلمة مرور كاملة؟**

"Read-Only recommended" يعرض فقط اقتراحًا لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [Password protection](/slides/ar/net/password-protected-presentation/) تقيد فعليًا الفتح أو التحرير وتكون مناسبة عندما تحتاج إلى ضوابط أمان حقيقية.

**هل يمكن الجمع بين "Read-Only recommended" وعلامات مائية لتثبيط التعديلات بشكل أكبر؟**

نعم. يمكن ربط التوصية بـ [watermarks](/slides/ar/net/watermark/) كوسيلة بصرية لتثبيط التعديلات؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل لا يزال الماكرو أو أداة خارجية قادرة على تعديل الملف عندما تكون التوصية مفعلة؟**

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [passwords and encryption](/slides/ar/net/password-protected-presentation/).

**كيف يرتبط "Read-Only recommended" بالعلامات "IsEncrypted" و"IsWriteProtected"؟**

إنها إشارات مختلفة. "Read-Only recommended" هي موجه ناعم اختياري؛ [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/iswriteprotected/) و[IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/isencrypted/) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات المرور أو التشفير.