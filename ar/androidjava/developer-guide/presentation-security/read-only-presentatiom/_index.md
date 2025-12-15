---
title: حفظ العروض التقديمية في وضع القراءة-فقط على Android
linktitle: عرض تقديمي للقراءة-فقط
type: docs
weight: 30
url: /ar/androidjava/read-only-presentation/
keywords:
- قراءة فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "احفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة-فقط باستخدام Aspose.Slides for Android عبر Java، مع توفير معاينات شرائح دقيقة دون تعديل عروضك التقديمية."
---

## **تطبيق وضع القراءة‑فقط**

في PowerPoint 2019، قدَّمت Microsoft إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد لحماية العرض التقديمي عندما

- تريد منع التعديلات غير المقصودة والحفاظ على محتوى عرضك التقديمي آمنًا. 
- تريد إبلاغ الأشخاص بأن العرض التقديمي الذي قدمته هو النسخة النهائية. 

بعد اختيارك خيار **Always Open Read-Only** للعرض التقديمي، عندما يفتح المستخدمون العرض يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *To prevent accidental changes, the author has set this file to open as read-only.*

تُعد توصية القراءة‑فقط وسيلة بسيطة لكنها فعّالة لردع التعديل لأن المستخدمين يجب أن يقوموا بعمل لإزالتها قبل أن يُسمح لهم بتحرير العرض. إذا كنت لا تريد أن يُجري المستخدمون تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فقد تكون توصية القراءة‑فقط خيارًا جيدًا لك. 

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة أقدم من Microsoft PowerPoint—والتي لا تدعم الوظيفة التي تم تقديمها مؤخرًا—فإن توصية **Read-Only** يتم تجاهلها (يُفتح العرض بشكل طبيعي).

Aspose.Slides for Android via Java يتيح لك تعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يوضح لك هذا الكود المثال كيفية تعيين عرض تقديمي إلى **Read-Only** في Java باستخدام Aspose.Slides:
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

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى ردع التحرير أو منع المستخدمين من إجراء تغييرات غير مقصودة على عرض PowerPoint. إذا قرر شخصٌ مُدَرّك—يعرف ما يفعله—تعديل عرضك التقديمي، فستتمكن بسهولة من إزالة إعداد القراءة‑فقط. إذا كنت بحاجة ماسة لمنع التعديل غير المصرح به، فستكون الحمايات [أكثر صرامة تتضمن التشفير وكلمات المرور](https://docs.aspose.com/slides/androidjava/password-protected-presentation/) هي الأنسب. 

{{% /alert %}} 

## **الأسئلة المتكررة**

**كيف يختلف «Read-Only recommended» عن الحماية بكلمة مرور كاملة؟**

«Read-Only recommended» يعرض مجرد اقتراح لفتح الملف في وضع القراءة‑فقط ويسهل التجاوز عنه. [حماية بكلمة مرور](/slides/ar/androidjava/password-protected-presentation/) تقيد فعليًا الفتح أو التحرير وتناسب الحالات التي تحتاج فيها إلى ضوابط أمان حقيقية.

**هل يمكن الجمع بين «Read-Only recommended» والعلامات المائية لزيادة ردع التعديلات؟**

نعم. يمكن دمج التوصية مع [العلامات المائية](/slides/ar/androidjava/watermark/) كوسيلة مرئية للردع؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

**هل يمكن لأداة ماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعّلة؟**

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/androidjava/password-protected-presentation/).

**كيف يرتبط «Read-Only recommended» بالطرق «isEncrypted» و«isWriteProtected»؟**

هما إشارة مختلفة. «Read-Only recommended» هو تنبيه ناعم واختياري؛ [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) و[isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) يشيران إلى قيود كتابة أو قراءة فعلية تعتمد على كلمات مرور أو تشفير.