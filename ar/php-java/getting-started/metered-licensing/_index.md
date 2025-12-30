---
title: الترخيص المتقاس
type: docs
weight: 100
url: /ar/php-java/metered-licensing/
keywords:
- ترخيص
- ترخيص متقاس
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيف يتيح لك Aspose.Slides لـ PHP عبر Java الترخيص المتقاس معالجة ملفات PowerPoint وOpenDocument بمرونة، مع الدفع فقط مقابل ما تستخدمه."
---

## **تطبيق المفاتيح المتقاسة**

{{% alert color="primary" %}} 

تُعد ترخيصات الفوترة المتقاسة آلية ترخيص جديدة يمكن استخدامها جنبًا إلى جنب مع طرق الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فإنك تختار الترخيص المتقاس.

عند شراء ترخيص متقاس، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذه المفاتيح المتقاسة باستخدام الفئة [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) التي تقدمها Aspose لعمليات الفوترة. للمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. إنشاء مثيل من الفئة [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. تمرير المفاتيح العامة والخاصة إلى الطريقة [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. تنفيذ بعض المعالجة (أداء المهام).

1. استدعاء الطريقة [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) من الفئة `Metered` .

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

هذا النموذج البرمجي يوضح كيفية استخدام الترخيص المتقاس:
```php
// إنشاء كائن من فئة Metered
$metered = new Metered();

try {
    // تمرير المفاتيح العامة والخاصة إلى كائن Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // الحصول على قيمة كمية الاستهلاك قبل استدعاءات API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // القيام بشيء باستخدام Aspose.Slides API هنا
    // ...

    // الحصول على قيمة كمية الاستهلاك بعد استدعاءات API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```


{{% alert color="warning" title="NOTE"  %}} 

لاستخدام الترخيص المتقاس، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تعتمد على الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص متقاس مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. الترخيص المتقاس هو آلية ترخيص إضافية يمكن استخدامها جنبًا إلى جنب مع [طرق الترخيص](/slides/ar/php-java/licensing/). يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما الذي يُحسب كاستهلاك ضمن ترخيص متقاس: العمليات أم الملفات؟**

يُحتسب استهلاك API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تعقب الاستهلاك](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

**هل الترخيص المتقاس مناسب للميكروسيرفيسز والبيئات الخالية من الخوادم حيث يتم إعادة تشغيل المثيلات بشكل متكرر؟**

نعم. بما أن المحاسبة تُجرى على مستوى كل طلب API، فإن السيناريوهات التي تتضمن عمليات بدء باردة متكررة متوافقة، بشرط توفر اتصال شبكة ثابت لإجراء حسابات الترخيص المتقاس.

**هل تختلف وظائف المكتبة عند استخدام ترخيص متقاس مقارنةً بترخيص دائم؟**

لا. الأمر يقتصر على آلية الترخيص والفوترة؛ قدرات المنتج تظل نفسها.

**كيف يرتبط الترخيص المتقاس بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، بينما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يومًا، ويزيل الترخيص المتقاس القيود ويحصّك بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عبر رد فعل آلي عند تجاوز حد الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي بشكل دوري عبر [طرق التعقب](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) وتطبيق حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.