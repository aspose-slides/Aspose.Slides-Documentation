---
title: الترخيص المدفوع بالاستعمال
type: docs
weight: 100
url: /ar/php-java/metered-licensing/
---

{{% alert color="primary" %}} 

الترخيص المدفوع بالاستعمال هو آلية ترخيص جديدة يمكن استخدامها جنبًا إلى جنب مع طرق الترخيص الحالية. إذا كنت ترغب في دفع رسوم بناءً على استخدامك لميزات واجهة برمجة تطبيقات Aspose.Slides، فيمكنك اختيار الترخيص المدفوع بالاستعمال.

عند شراء ترخيص مدفوع بالاستعمال، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق مفتاح الاستعمال المدفوع باستخدام فئة [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) التي قدمتها Aspose للعمليات المتعلقة بالاستعمال. لمزيد من التفاصيل، راجع [أسئلة مكررة حول الترخيص المدفوع بالاستعمال](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. أنشئ مثيلاً لفئة [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. قم بتمرير مفاتيحك العامة والخاصة إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-).

1. قم بإجراء بعض المعالجة (قم بأداء المهام).

1. استدعِ طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) لفئة Metered.

   يجب أن ترى كمية الطلبات التي استهلكتها من واجهة برمجة التطبيقات حتى الآن.

هذا الرمز PHP يوضح لك كيفية تعيين المفاتيح العامة والخاصة المدفوعة بالاستعمال:

```php
  $metered = new Metered();
  try {
    // الوصول إلى خاصية setMeteredKey وتمرير المفاتيح العامة والخاصة كوسائط
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");
    // الحصول على قيمة كمية الاستهلاك قبل الوصول إلى واجهة برمجة التطبيقات
    $quantityOld = Metered->getConsumptionQuantity();
    echo("كمية الاستهلاك" . $quantityOld);
    // الحصول على قيمة كمية الاستهلاك بعد الوصول إلى واجهة برمجة التطبيقات
    $quantity = Metered->getConsumptionQuantity();
    echo("كمية الاستهلاك" . $quantity);
  } catch (JavaException $ex) {
    $ex->printStackTrace();
  }
```

{{% alert color="warning" title="ملاحظة"  %}} 

لاستخدام الترخيص المدفوع بالاستعمال، تحتاج إلى اتصال إنترنت مستقر لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 
