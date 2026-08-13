---
title: ترخيص الاستهلاك
type: docs
weight: 100
url: /ar/java/metered-licensing/
keywords:
- رخصة
- رخصة استهلاك
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية تمكين ترخيص الاستهلاك في Aspose.Slides for Java من معالجة ملفات PowerPoint وOpenDocument بمرونة، مع الدفع فقط مقابل ما تستخدمه."
---
## **المقدمة**

ترخيص الاستهلاك هو آلية ترخيص يمكن استخدامها إلى جانب طرق الترخيص الموجودة. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فإنك تختار ترخيص الاستهلاك.

## **تطبيق مفاتيح الاستهلاك**

{{% alert color="info" %}} 
ترخيص الاستهلاك هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الموجودة. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فإنك تختار ترخيص الاستهلاك.

عند شرائك ترخيصًا مستهلكًا، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق مفتاح الاستهلاك هذا باستخدام فئة [Metered](https://reference.aspose.com/slides/ar/java/com.aspose.slides/metered/) التي وفرتها Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}} 

1. أنشئ كائنًا من فئة [Metered](https://reference.aspose.com/slides/ar/java/com.aspose.slides/metered/).  

2. مرّر المفتاحين العام والخاص إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/ar/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).  

3. قم ببعض المعالجة (أداء المهام).  

4. استدعِ طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/ar/java/com.aspose.slides/metered/#getConsumptionQuantity--) من فئة `Metered`.

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

يعرض هذا المثال البرمجي كيفية استخدام ترخيص الاستهلاك:

```java
// ينشئ كائنًا من فئة Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // يمرّر المفتاحين العام والخاص إلى كائن Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // يحصل على قيمة الكمية المستهلكة قبل مكالمات API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // قم بعمل شيء باستخدام Aspose.Slides API هنا
    // ...

    // يحصل على قيمة الكمية المستهلكة بعد مكالمات API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="ملاحظة"  %}} 
لاستخدام ترخيص الاستهلاك، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.
{{% /alert %}} 

## **الأسئلة المتداولة**

### هل يمكنني استخدام ترخيص استهلاك مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟

نعم. الاستهلاك هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/java/licensing/). يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

### ما الذي يُحتسب كاستهلاك في ترخيص الاستهلاك: عمليات أم ملفات؟

يتم احتساب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/ar/java/com.aspose.slides/metered/).

### هل الاستهلاك مناسب للميكروسيرفيسز والبيئات الخالية من الخوادم حيث يتم إعادة تشغيل المثيلات بشكل متكرر؟

نعم. نظرًا لأن الحساب يتم على مستوى طلبات API، فإن السيناريوهات ذات البدء البارد المتكرر متوافقة، شريطة وجود وصول شبكة ثابت لحسابات الاستهلاك.

### هل تختلف وظائف المكتبة عند استخدام ترخيص استهلاك مقارنةً بترخيص دائم؟

لا. الأمر يتعلق فقط بآلية الترخيص والفوترة؛ فإن قدرات المنتج تبقى هي نفسها.

### كيف يرتبط الاستهلاك بالإصدار التجريبي والترخيص المؤقت؟

الإصدار التجريبي يحتوي على قيود وعلامات مائية، بينما يزيل [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) القيود لمدة 30 يومًا، ويزيل الاستهلاك القيود ويُحاسب بناءً على الاستخدام الفعلي.

### هل يمكنني التحكم في الميزانية عن طريق رد الفعل تلقائيًا عند تجاوز عتبة الاستهلاك؟

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي دوريًا عبر [طرق التتبع](https://reference.aspose.com/slides/ar/java/com.aspose.slides/metered/) وتطبيق حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.