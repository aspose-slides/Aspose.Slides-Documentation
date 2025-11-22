---
title: الترخيص المتعقب
type: docs
weight: 90
url: /ar/net/metered-licensing/
keywords:
- رخصة
- ترخيص متعقب
- C#
- Aspose.Slides لـ .NET
---

## **تطبيق المفاتيح المتعقبة**

{{% alert color="primary" %}} 

إن ترخيص المتعقب هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الموجودة. إذا كنت تريد الفوترة بناءً على استخدامك لميزات واجهة برمجة تطبيقات Aspose.Slides، فأنت تختار الترخيص المتعقب.

عند شراء ترخيص متعقب، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح المتعقب باستخدام فئة [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) التي قدمتها Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. أنشئ نسخة من فئة [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. مرّر المفاتيح العامة والخاصة إلى طريقة [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. قم ببعض المعالجة (أداء مهام).
1. استدعِ طريقة [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) من فئة `Metered`.

يجب أن تشاهد كمية/عدد طلبات API التي استهلكتها حتى الآن.

يعرض لك هذا الكود كيفية استخدام الترخيص المتعقب:

```cs
// ينشئ نسخة من فئة Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// يمرّر المفاتيح العامة والخاصة إلى كائن Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// يحصل على كمية البيانات المتعقبة قبل مكالمة API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// قم بعمل ما باستخدام واجهة Aspose.Slides API هنا
// ...

// يحصل على كمية البيانات المتعقبة بعد مكالمة API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="ملاحظة" %}} 

لاستخدام الترخيص المتعقب، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص متعقب مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. المتعقب هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/net/licensing/) الموجودة. يمكنك اختيار الآلية التي ستطبقها عند بدء تشغيل التطبيق.

**ما الذي يُحتسب كاستهلاك في الترخيص المتعقب: عمليات أم ملفات؟**

يُحتسب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**هل المتعقب مناسب لبيئات الميكرو سيرفيس والسيرفرلس حيث يتم إعادة تشغيل المثيلات بشكل متكرر؟**

نعم. بما أن الحساب يتم على مستوى استدعاءات API، فإن السيناريوهات التي تتطلب عمليات بدء باردة متكررة متوافقة، بشرط وجود اتصال شبكة ثابت لحسابات المتعقب.

**هل تختلف وظائف المكتبة عند استخدام ترخيص متعقب مقارنةً بترخيص دائم؟**

لا. الأمر يتعلق فقط بآلية الترخيص والفوترة؛ قدرات المنتج تظل هي نفسها.

**كيف يرتبط المتعقب بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، و[الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يوماً، والمتعقب يزيل القيود ويُحسب بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عن طريق رد الفعل تلقائياً عند تجاوز حد الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي بشكل دوري عبر [طرق التتبع](https://reference.aspose.com/slides/net/aspose.slides/metered/) وتطبيق حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.