---
title: ترخيص متري
type: docs
weight: 100
url: /ar/androidjava/metered-licensing/
---

{{% alert color="primary" %}} 

تتيح Aspose.Slides للمطورين تطبيق مفتاح متري. إنها آلية ترخيص جديدة. سيتم استخدام آلية الترخيص الجديدة جنبًا إلى جنب مع أساليب الترخيص الموجودة. يمكن للعملاء الذين يفضلون أن يتم تحصيل رسومهم بناءً على استخدامهم لميزات واجهة برمجة التطبيقات استخدام الترخيص المتري. للحصول على مزيد من التفاصيل، يرجى الرجوع إلى قسم [أسئلة شائعة حول الترخيص المتري](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
## **ترخيص متري**
اتبع هذه الخطوات البسيطة لاستخدام فئة Metered:

1. أنشئ مثيلًا من فئة Metered.

1. مرر المفاتيح العامة والخاصة إلى طريقة setMeteredKey.

1. قم بالمعالجة (قم بأداء المهمة).

1. استدعِ طريقة getConsumptionQuantity من فئة Metered.

   ستعيد مقدار / كمية طلبات واجهة برمجة التطبيقات التي استخدمتها حتى الآن.

يوضح هذا الكود العينة كيفية إعداد المفاتيح العامة والخاصة المتري:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // الوصول إلى خاصية setMeteredKey وتمرير المفاتيح العامة والخاصة كمعلمات
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // الحصول على قيمة كمية الاستهلاك قبل الوصول إلى واجهة برمجة التطبيقات
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("كمية الاستهلاك" + quantityOld);


    // الحصول على قيمة كمية الاستهلاك بعد الوصول إلى واجهة برمجة التطبيقات
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("كمية الاستهلاك" + quantity);


} catch (Exception ex) {
    ex.printStackTrace();
}
```