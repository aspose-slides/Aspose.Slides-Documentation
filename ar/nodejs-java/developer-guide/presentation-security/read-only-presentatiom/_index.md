---
title: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/nodejs-java/read-only-presentation/
---

## **تطبيق وضع القراءة فقط**

في PowerPoint 2019، قدمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى عرضك التقديمي آمنًا. 
- تريد تنبيه الأشخاص إلى أن العرض التقديمي الذي قدمته هو النسخة النهائية. 

بعد اختيارك لخيار **Always Open Read-Only** لعرض تقديمي، عندما يفتح المستخدمون العرض التقديمي، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات العرضية، قام المؤلف بتعيين هذا الملف للفتح كقراءة فقط.*

توصية **Read-Only** هي رادع بسيط ولكنه فعال يثني عن التحرير لأن المستخدمين يجب أن يؤدوا مهمة لإزالتها قبل السماح لهم بتحرير العرض التقديمي. إذا كنت لا ترغب في قيام المستخدمين بإجراء تغييرات على العرض التقديمي وتريد إخبارهم بذلك بطريقة مؤدبة، فإن توصية **Read-Only** قد تكون خيارًا جيدًا لك. 

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة قديمة من Microsoft PowerPoint—التي لا تدعم الوظيفة التي تم تقديمها مؤخرًا—تُتجاهل توصية **Read-Only** (يُفتح العرض التقديمي بصورة عادية).

Aspose.Slides for Node.js عبر Java يسمح لك بتعيين عرض تقديمي كـ **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض التقديمي) يرون توصية **Read-Only**. يُظهر لك هذا الكود العيني كيفية تعيين عرض تقديمي كـ **Read-Only** في JavaScript باستخدام Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات عرضية على عرض PowerPoint. إذا قرر شخص متحمس—يعرف ما يفعله—تحرير عرضك التقديمي، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة ماسة لمنع التعديل غير المصرح به، فمن الأفضل لك استخدام [حمايات أكثر صرامة تشمل التشفير وكلمات المرور](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **الأسئلة الشائعة**

**كيف يختلف 'Read-Only recommended' عن حماية كلمة المرور الكاملة؟**

'Read-Only recommended' يعرض فقط اقتراحًا لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [حماية كلمة المرور](/slides/ar/nodejs-java/password-protected-presentation/) تقيد فعليًا الفتح أو التحرير وتناسب عندما تحتاج إلى ضوابط أمان حقيقية.

**هل يمكن دمج 'Read-Only recommended' مع العلامات المائية لتثبيط التعديلات أكثر؟**

نعم. يمكن إقران التوصية مع [العلامات المائية](/slides/ar/nodejs-java/watermark/) كوسيلة مرئية للردع؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل لا يزال بإمكان الماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟**

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/nodejs-java/password-protected-presentation/).

**كيف يرتبط 'Read-Only recommended' بالعلامات 'IsEncrypted' و 'IsWriteProtected'؟**

إنها إشارات مختلفة. 'Read-Only recommended' هي مطالبة ناعمة واختيارية؛ [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) و [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/isencrypted/) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات المرور أو التشفير.