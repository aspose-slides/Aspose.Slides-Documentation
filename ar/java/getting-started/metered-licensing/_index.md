---
title: الترخيص القائم على القياس
type: docs
weight: 100
url: /ar/java/metered-licensing/
keywords:
- ترخيص
- ترخيص قائم على القياس
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية تمكين الترخيص القائم على القياس في Aspose.Slides for Java من معالجة ملفات PowerPoint وOpenDocument بمرونة، مع الدفع فقط مقابل ما تستخدمه."
---

## **تطبيق المفاتيح القابلة للقياس**

{{% alert color="primary" %}} 

الترخيص القائم على القياس هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الحالية. إذا كنت تريد الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فستختار الترخيص القائم على القياس.

عند شراء ترخيص قائم على القياس، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح القابل للقياس باستخدام الفئة [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) التي وفرتها Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. إنشاء مثال من الفئة [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. تمرير المفاتيح العامة والخاصة إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. إجراء بعض المعالجة (تنفيذ المهام).

1. استدعاء طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) من الفئة `Metered`.

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

يعرض هذا المثال البرمجي كيفية استخدام الترخيص القائم على القياس:

```java
// Creates an instance of the Metered class
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Passes the public and private keys to the Metered object
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Gets the consumed quantity value before API calls
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Do something with Aspose.Slides API here
    // ...

    // Gets the consumed quantity value after API calls
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

لاستخدام الترخيص القائم على القياس، تحتاج إلى اتصال إنترنت مستقر لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة المتكررة**

**هل يمكنني استخدام ترخيص قائم على القياس مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. الترخيص القائم على القياس هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/java/licensing/) الحالية. يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما الذي يُحتسب كاستهلاك تحت ترخيص قائم على القياس: عمليات أم ملفات؟**

يُحسب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

**هل الترخيص القائم على القياس مناسب لبيئات الميكرو خدمات والخدمات غير الخادمة حيث يتم إعادة تشغيل المثيلات بشكل متكرر؟**

نعم. نظرًا لأن المحاسبة تُجرى على مستوى نداءات API، فإن السيناريوهات التي تتضمن عمليات بدء باردة متكررة متوافقة، بشرط توفر اتصال شبكة مستقر لحسابات الترخيص القائم على القياس.

**هل تختلف وظيفة المكتبة عند استخدام ترخيص قائم على القياس مقارنةً بالترخيص الدائم؟**

لا. الأمر يتعلق فقط بآلية الترخيص والفوترة؛ فإن إمكانيات المنتج تبقى نفسها.

**كيف يرتبط الترخيص القائم على القياس بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، أما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) فيزيل القيود لمدة 30 يومًا، والترخيص القائم على القياس يزيل القيود ويُحاسب بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية من خلال رد فعل تلقائي عند تجاوز عتبة الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي بشكل دوري عبر [طرق التتبع](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) وتطبيق حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.