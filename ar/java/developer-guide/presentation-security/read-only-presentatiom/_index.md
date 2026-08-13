---
title: حفظ عروض تقديمية في وضع القراءة‑فقط باستخدام Java
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/java/read-only-presentation/
keywords:
- قراءة فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT، PPTX) في وضع القراءة‑فقط باستخدام Aspose.Slides for Java، مع توفير معاينات شرائح دقيقة دون تعديل عروضك التقديمية."
---
## **المقدمة**

في PowerPoint 2019، قدمت مايكروسوفت إعداد **Always Open Read-Only** كواحد من الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات العارضة والحفاظ على محتوى عرضك التقديمي بأمان.
- تريد تنبيه الأشخاص إلى أن العرض التقديمي الذي قدمته هو النسخة النهائية.

بعد اختيارك لخيار **Always Open Read-Only** لعرض تقديمي، عند فتح المستخدمين للعرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات العارضة، قام المؤلف بتعيين هذا الملف ليفتح كقراءة فقط.*

توصية **Read-Only** هي رادع بسيط لكنه فعال يُثني عن التحرير لأن المستخدمين يجب أن ينفذوا مهمة لإزالتها قبل أن يُسمح لهم بتعديل العرض التقديمي. إذا كنت لا تريد أن يجرى المستخدمون تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فإن توصية **Read-Only** قد تكون خيارًا جيدًا لك.

> إذا تم فتح عرض تقديمي محمي بـ **Read-Only** في نسخة أقدم من Microsoft PowerPoint — التي لا تدعم الدالة التي تم تقديمها مؤخرًا — سيتم تجاهل توصية **Read-Only** (يفتح العرض التقديمي كالمعتاد).

## **تطبيق وضع القراءة‑فقط**

يسمح Aspose.Slides for Java لك بتعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يُظهر لك هذا المثال كيفية تعيين عرض تقديمي إلى **Read-Only** في Java باستخدام Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات عارضة على عرض PowerPoint. إذا قرر شخص مُتحمس — يعرف ما يفعله — تعديل عرضك، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة ماسة لمنع التعديل غير المصرح به، فمن الأفضل استخدام [حمايات أكثر صرامة تتضمن التشفير وكلمات المرور](https://docs.aspose.com/slides/ar/java/password-protected-presentation/). 
{{% /alert %}} 

## **الأسئلة الشائعة**

### كيف يختلف 'Read-Only recommended' عن الحماية الكاملة بكلمة المرور؟

يُظهر 'Read-Only recommended' مجرد اقتراح لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [Password protection](/slides/ar/java/password-protected-presentation/) في الواقع يقيّد الفتح أو التحرير ويُناسب عندما تحتاج إلى ضوابط أمان حقيقية.

### هل يمكن دمج 'Read-Only recommended' مع العلامات المائية لتثبيط التعديلات أكثر؟

نعم. يمكن ربط التوصية مع [watermarks](/slides/ar/java/watermark/) كردع بصري؛ فهما آليتان منفصلتان وتعملان معًا بشكل جيد.

### هل يمكن لماكرو أو أداة خارجية تعديل الملف عندما تكون التوصية مفعلة؟

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [passwords and encryption](/slides/ar/java/password-protected-presentation/).

### كيف يرتبط 'Read-Only recommended' بالطرق 'isEncrypted' و 'isWriteProtected'؟

إنها إشارات مختلفة. 'Read-Only recommended' هي مطالبة ناعمة واختيارية؛ [isWriteProtected](https://reference.aspose.com/slides/ar/java/com.aspose.slides/protectionmanager/#isWriteProtected--) و [isEncrypted](https://reference.aspose.com/slides/ar/java/com.aspose.slides/protectionmanager/#isEncrypted--) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات المرور أو التشفير.