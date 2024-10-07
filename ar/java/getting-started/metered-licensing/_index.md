---
title: الترخيص المدفوع
type: docs
weight: 100
url: /java/metered-licensing/
---

{{% alert color="primary" %}} 

الترخيص المدفوع هو آلية ترخيص جديدة يمكن استخدامها جنبًا إلى جنب مع أساليب الترخيص الحالية. إذا كنت ترغب في أن يتم فاتورتك بناءً على استخدامك لميزات واجهة برمجة تطبيقات Aspose.Slides، يجب عليك اختيار الترخيص المدفوع.

عند شراء ترخيص مدفوع، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذه المفتاح المدفوع باستخدام الصنف [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) الذي قدمته Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [أسئلة شائعة حول الترخيص المدفوع](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 
1. قم بإنشاء مثيل من صنف [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) .

1. مرر مفاتيحك العامة والخاصة إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. قم ببعض المعالجة (نفذ المهام) .

1. استدعِ طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) من صنف Metered .

   يجب أن ترى كمية/عدد طلبات واجهة برمجة التطبيقات التي استهلكتها حتى الآن.

هذا الكود Java يوضح لك كيفية تعيين المفاتيح العامة والخاصة المدفوعة:

```java
com.aspose.slides.Metered metered=new com.aspose.slides.Metered();
try {
    // Accesses the setMeteredKey property and pass public and private keys as parameters
    metered.setMeteredKey("<valid pablic key>", "<valid private key>");

    // Gets the consumed qantity value before accessing API
    double quantityOld = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Consumption quantity" + quantityOld);


    // Gets the consumed qantity value after accessing API
    double quantity = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Consumption quantity" + quantity);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="ملاحظة"  %}} 

لاستخدام الترخيص المدفوع، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وأداء الحسابات.

{{% /alert %}} 