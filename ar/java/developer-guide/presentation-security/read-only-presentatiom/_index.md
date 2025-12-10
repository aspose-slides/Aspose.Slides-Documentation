---
title: حفظ العروض التقديمية في وضع القراءة فقط باستخدام Java
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/java/read-only-presentation/
keywords:
- القراءة فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT، PPTX) في وضع القراءة فقط باستخدام Aspose.Slides for Java، مع توفير معاينات دقيقة للشرائح دون تعديل عروضك التقديمية."
---

## **تطبيق وضع القراءة فقط**

في PowerPoint 2019، قدمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد لحماية عرض تقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى العرض آمنًا. 
- تريد تنبيه الأشخاص أن النسخة التي قدمتها هي النسخة النهائية. 

بعد اختيارك لخيار **Always Open Read-Only** لعروض تقديمية، عندما يفتح المستخدمون العرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *للوقاية من التغييرات غير المقصودة، قام المؤلف بتعيين هذا الملف للفتح كقراءة فقط.*

تعتبر توصية **Read-Only** رادعًا بسيطًا لكنه فعال يثني عن التحرير لأن المستخدمين يجب أن يقوموا بإجراء لإزالتها قبل السماح لهم بتحرير العرض. إذا كنت لا تريد أن يجري المستخدمون تغييرات على العرض وتريد إبلاغهم بذلك بطريقة لبقة، فقد تكون توصية **Read-Only** خيارًا جيدًا لك. 

> إذا تم فتح عرض يقدم به حماية **Read-Only** في نسخة أقدم من Microsoft PowerPoint—والتي لا تدعم الوظيفة التي تم تقديمها مؤخرًا—فإن توصية **Read-Only** تُهمل (يُفتح العرض بصورة عادية).

يسمح Aspose.Slides for Java لك بتعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتح العرض) يرون توصية **Read-Only**. يوضح لك هذا المثال البرمجي كيفية تعيين عرض تقديمي إلى **Read-Only** في Java باستخدام Aspose.Slides:
```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات عرضية على عرض PowerPoint. إذا قام شخص مطلع—يعرف ما يفعله—بتعديل العرض، يمكنه بسهولة إزالة إعداد **Read-Only**. إذا كنت بحاجة ماسة لمنع التحرير غير المصرح به، فمن الأفضل استخدام [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/java/password-protected-presentation/). 

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف “Read-Only recommended” عن الحماية الكاملة بكلمة مرور؟**

“Read-Only recommended” يعرض مجرد اقتراح لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [Password protection](/slides/ar/java/password-protected-presentation/) تقيد الفتح أو التحرير فعليًا وتناسب الحالات التي تحتاج فيها إلى ضوابط أمان حقيقية.

**هل يمكن دمج “Read-Only recommended” مع العلامات المائية لتثبيط التعديلات أكثر؟**

نعم. يمكن إقران التوصية مع [watermarks](/slides/ar/java/watermark/) كمانع بصري؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل لا يزال بمقدور ماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟**

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [passwords and encryption](/slides/ar/java/password-protected-presentation/).

**كيف يرتبط “Read-Only recommended” بالطرق “isEncrypted” و “isWriteProtected”؟**

هما إشارة مختلفة. “Read-Only recommended” هي مطالبة ناعمة واختيارية؛ [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isWriteProtected--) و[isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isEncrypted--) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات مرور أو تشفير.