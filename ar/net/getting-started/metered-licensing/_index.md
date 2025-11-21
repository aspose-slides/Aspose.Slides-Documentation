---
title: الترخيص القائم على العدّ
type: docs
weight: 90
url: /ar/net/metered-licensing/
keywords:
- ترخيص
- ترخيص عددي
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية تمكين الترخيص القائم على العدّ في Aspose.Slides for .NET من معالجة ملفات PowerPoint وOpenDocument بمرونة، مع دفع فقط مقابل ما تستخدمه."
---

## **تطبيق مفاتيح العدّ**

{{% alert color="primary" %}} 
ترخيص العدّ هو آلية ترخيص جديدة يمكن استخدامها إلى جانب أساليب الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فإنك تختار ترخيص العدّ.

عند شراء ترخيص عدّ، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق مفتاح العدّ هذا باستخدام الفئة [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) التي توفرها Aspose لعمليات العدّ. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}} 

1. إنشاء مثال من الفئة [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. تمرير المفاتيح العامة والخاصة إلى طريقة [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. تنفيذ بعض المعالجة (أداء المهام).
1. استدعاء طريقة [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) من فئة `Metered`.

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

يظهر هذا المثال البرمجي كيفية استخدام ترخيص العدّ:

```cs
// إنشاء مثال من فئة Metered
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// تمرير المفاتيح العامة والخاصة إلى كائن Metered
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// الحصول على كمية البيانات المعدودة قبل استدعاء API
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// تنفيذ بعض العمليات باستخدام Aspose.Slides API هنا
// ...

// الحصول على كمية البيانات المعدودة بعد استدعاء API
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="ملاحظة" %}} 
لاستخدام ترخيص العدّ، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.
{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص عدّ مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. عدّ هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [أساليب الترخيص](/slides/ar/net/licensing/). يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما الذي يُحتسب كاستهلاك في ترخيص العدّ: العمليات أم الملفات؟**

يُحتسب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**هل ترخيص العدّ مناسب لبيئات الميكروسيرفيسس والخدمات غير المُستضافة حيث تُعاد تشغيل المثيلات بشكل متكرر؟**

نعم. نظرًا لأن الحساب يتم على مستوى استدعاءات API، فإن السيناريوهات التي تشهد عمليات بدء باردة متكررة متوافقة، بشرط وجود وصول شبكة ثابتة لحسابات العدّ.

**هل تختلف وظائف المكتبة عند استخدام ترخيص عدّ مقارنةً بترخيص دائم؟**

لا. هذا يتعلق فقط بآلية الترخيص والفوترة؛ قدرات المنتج تبقى نفسها.

**كيف يرتبط ترخيص العدّ بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، بينما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يوماً، وتُزيل العدّ القيود وتفرض رسومًا بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عبر رد الفعل تلقائيًا عند تجاوز عتبة الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي دوريًا عبر [طرق التتبع](https://reference.aspose.com/slides/net/aspose.slides/metered/) وتنفيذ حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.