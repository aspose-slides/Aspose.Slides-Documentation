---
title: الترخيص المستند إلى الاستخدام
type: docs
weight: 90
url: /ar/net/metered-licensing/
---

{{% alert color="primary" %}} 

الترخيص المستند إلى الاستخدام هو آلية ترخيص جديدة يمكن استخدامها بجانب طرق الترخيص الحالية. إذا كنت ترغب في أن تُحسن فاتورتك بناءً على استخدامك لميزات واجهة برمجة التطبيقات Aspose.Slides، يمكنك اختيار الترخيص المستند إلى الاستخدام.

عند شراء ترخيص مستند إلى الاستخدام، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق مفتاح الاستخدام باستخدام فئة [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) التي وفرتها Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [الأسئلة الشائعة حول الترخيص المستند إلى الاستخدام](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. قم بإنشاء مثيل من فئة [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. مرر المفاتيح العامة والخاصة إلى طريقة [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. قم بتنفيذ بعض المعالجات (أداء المهام).
1. استدعِ طريقة [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) من فئة Metered.

   يجب أن ترى كمية/عدد طلبات واجهة برمجة التطبيقات التي استخدمتها حتى الآن.

يوضح لك هذا الكود C# كيفية تعيين المفاتيح العامة والخاصة المستندة إلى الاستخدام:

```c#
//  ينشئ مثيل لفئة Metered
	Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

//  يصل إلى خاصية SetMeteredKey ويمرر المفاتيح العامة والخاصة كمعلمات
	metered.SetMeteredKey("*****", "*****");

//  يحصل على كمية البيانات المستندة إلى الاستخدام قبل استدعاء واجهة برمجة التطبيقات
	decimal amountbefore = Aspose.Slides.Metered.GetConsumptionQuantity();

//  يعرض المعلومات
	Console.WriteLine("الكمية المستهلكة قبل: " + amountbefore.ToString());

//  يحصل على كمية البيانات المستندة إلى الاستخدام بعد استدعاء واجهة برمجة التطبيقات
	decimal amountafter = Aspose.Slides.Metered.GetConsumptionQuantity();

//  يعرض المعلومات
	Console.WriteLine("الكمية المستهلكة بعد: " + amountafter.ToString());
```

{{% alert color="warning" title="ملاحظة"  %}} 

لاستخدام الترخيص المستند إلى الاستخدام، تحتاج إلى اتصال إنترنت مستقر لأن آلية الترخيص تستخدم الإنترنت للتفاعل باستمرار مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 