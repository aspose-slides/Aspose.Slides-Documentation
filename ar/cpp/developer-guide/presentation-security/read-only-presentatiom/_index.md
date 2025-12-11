---
title: حفظ العروض التقديمية في وضع القراءة فقط باستخدام C++
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/cpp/read-only-presentation/
keywords:
- القراءة فقط
- حماية العرض التقديمي
- منع التحرير
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة فقط باستخدام Aspose.Slides لـ C++، مع توفير معاينات دقيقة للشرائح دون تعديل عروضك التقديمية."
---

## **تطبيق وضع القراءة فقط**

في PowerPoint 2019، قامت Microsoft بإضافة إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى عرضك التقديمي آمنًا. 
- تريد إبلاغ الأشخاص بأن العرض التقديمي الذي قدمته هو النسخة النهائية. 

بعد اختيارك لخيار **Always Open Read-Only** لعرض تقديمي، عندما يفتح المستخدمون العرض، يرون توصية **Read-Only** وقد يظهر لهم رسالة بهذا الشكل: *لمنع التغييرات العرضية، قام المؤلف بتعيين هذا الملف للفتح كقراءة فقط.*

توصية **Read-Only** هي رادع بسيط لكنه فعال يثني عن التحرير لأن المستخدمين يجب أن يقوموا بعملية لإزالتها قبل أن يُسمح لهم بتعديل العرض التقديمي. إذا كنت لا تريد للمستخدمين إجراء تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فقد تكون توصية **Read-Only** خيارًا جيدًا لك. 

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة قديمة من Microsoft PowerPoint — التي لا تدعم الوظيفة التي تم تقديمها مؤخرًا — يتم تجاهل توصية **Read-Only** (يفتح العرض بشكل طبيعي).

Aspose.Slides for C++ تتيح لك تعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا الكود المثال كيفية تعيين عرض تقديمي إلى **Read-Only** في C++ باستخدام Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات عرضية على عرض PowerPoint. إذا قام شخص مُتحفّز — يعرف ما يفعله — بتحرير عرضك، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة فعلية لمنع التحرير غير المصرّح به، فمن الأفضل استخدام [حمايات أكثر صرامة تشمل التشفير وكلمات المرور](https://docs.aspose.com/slides/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف 'Read-Only recommended' عن الحماية الكاملة بكلمة مرور؟**

'Read-Only recommended' يعرض فقط اقتراحًا لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [حماية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/) في الواقع يقيّد الفتح أو التحرير وهو مناسب عندما تحتاج إلى ضوابط أمان حقيقية.

**هل يمكن دمج 'Read-Only recommended' مع العلامات المائية لتثبيط التعديلات أكثر؟**

نعم. يمكن إقران التوصية مع [العلامات المائية](/slides/ar/cpp/watermark/) كوسيلة ردع بصرية؛ فهي آليات منفصلة وتعمل جيدًا معًا.

**هل لا يزال بإمكان ماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟**

نعم. لا تمنع التوصية التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/cpp/password-protected-presentation/).

**كيف يرتبط 'Read-Only recommended' بالعلامات 'is encrypted' و 'is write protected'؟**

إنها إشارات مختلفة. 'Read-Only recommended' هي مطالبة ناعمة واختيارية؛ [get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) و [get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_isencrypted/) يشيران إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات المرور أو التشفير.