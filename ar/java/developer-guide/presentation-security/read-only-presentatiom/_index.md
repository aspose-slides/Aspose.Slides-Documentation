---
title: تقديم للقراءة فقط
type: docs
weight: 30
url: /ar/java/read-only-presentation/

---

في PowerPoint 2019، قدمت Microsoft إعداد **فتح دائم للقراءة فقط** كواحد من الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام إعداد القراءة فقط لحماية العرض التقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى عرضك التقديمي آمناً.
- تريد تنبيه الناس أن العرض التقديمي الذي قدمته هو النسخة النهائية.

بعد اختيار خيار **فتح دائم للقراءة فقط** لعرض تقديمي، عندما يفتح المستخدمون العرض التقديمي، يرون توصية **القراءة فقط** وقد يرون رسالة بهذه الصيغة: *لمنع التغييرات العرضية، قام المؤلف بتعيين هذا الملف ليفتح كقراءة فقط.*

توصية القراءة فقط هي رادع بسيط ولكنه فعال يثني عن التحرير لأن المستخدمين يجب أن يقوموا بأداء مهمة لإزالتها قبل أن يُسمح لهم بتحرير العرض التقديمي. إذا كنت لا تريد من المستخدمين إجراء تغييرات على العرض التقديمي وترغب في إخبارهم عن ذلك بطريقة مهذبة، فإن توصية القراءة فقط قد تكون خياراً جيداً لك.

> إذا تم فتح عرض تقديمي مع حماية **القراءة فقط** في تطبيق Microsoft PowerPoint أقدم—والذي لا يدعم الوظيفة التي تم تقديمها مؤخراً—فإن توصية **القراءة فقط** تُهمل (يتم فتح العرض التقديمي بشكل طبيعي).

تتيح لك Aspose.Slides لـ Java تعيين عرض تقديمي إلى **القراءة فقط**، مما يعني أن المستخدمين (بعد فتح العرض التقديمي) يرون توصية **القراءة فقط**. يوضح لك هذا الكود النموذجي كيفية تعيين عرض تقديمي إلى **القراءة فقط** في Java باستخدام Aspose.Slides:

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

**ملاحظة**: توصية **القراءة فقط** تهدف ببساطة إلى تثبيط التحرير أو منع المستخدمين من إجراء تغييرات عرضية على عرض PowerPoint. إذا قرر شخص مدفوع—يعرف ما يفعله—تحرير عرضك التقديمي، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة فعلية لمنع التحرير غير المصرح به، فمن الأفضل استخدام [حمايات أكثر صرامة تتضمن التشفير وكلمات المرور](https://docs.aspose.com/slides/java/password-protected-presentation/).

{{% /alert %}}