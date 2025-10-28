---
title: ترخيص بالعداد
type: docs
weight: 90
url: /ar/python-net/metered-licensing/
keywords:
- ترخيص
- ترخيص بالعداد
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- Python
- Aspose.Slides
description: "تعرف على كيفية تمكين ترخيص بالعداد لـ Aspose.Slides للـ Python عبر .NET من معالجة ملفات PowerPoint و OpenDocument بمرونة، مع الدفع فقط مقابل ما تستخدمه."
---

## **تطبيق المفاتيح بالعداد**

{{% alert color="primary" %}} 

ترخيص بالعداد هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فإنك تختار ترخيص بالعداد.

عند شراء ترخيص بالعداد، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق مفتاح العدّ باستخدام الفئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) التي وفرتها Aspose لعمليات العدّ. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. أنشئ مثالًا من الفئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
2. مرّر المفاتيح العامة والخاصة إلى طريقة [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
3. قم ببعض المعالجة (نفّذ المهام).
4. استدعِ طريقة [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) من فئة `Metered`.

يجب أن ترى مقدار/كمية طلبات API التي استهلكتها حتى الآن.

هذا المثال يوضح كيفية استخدام ترخيص بالعداد:

```python
import aspose.slides as slides

# إنشاء مثال من فئة Metered
metered = slides.Metered()

# تمرير المفتاحين العام والخاص إلى كائن Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# الحصول على قيمة الكمية المستهلكة قبل استدعاءات API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# تنفيذ بعض العمليات باستخدام Aspose.Slides API هنا
# ...

# الحصول على قيمة الكمية المستهلكة بعد استدعاءات API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="ملاحظة" %}} 

لاستخدام ترخيص بالعداد، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة المتكررة**

**هل يمكنني استخدام ترخيص بالعداد مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. يعتبر ترخيص بالعداد آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/python-net/licensing/) الحالية. تختار أي آلية تطبق عند بدء تشغيل التطبيق.

**ما الذي يُحتسب بالضبط كاستهلاك تحت ترخيص بالعداد: عمليات أم ملفات؟**

يُحتسب استهلاك API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**هل ترخيص بالعداد مناسب للمايكرو سيرفيسز والبيئات الخالية من الخوادم حيث يتم إعادة تشغيل الحالات بشكل متكرر؟**

نعم. بما أن المحاسبة تُجرى على مستوى طلبات API، فإن السيناريوهات التي تشهد عمليات بدء باردة متكررة متوافقة، بشرط وجود اتصال شبكة ثابت لحسابات الترخيص بالعداد.

**هل تختلف وظائف المكتبة عند استخدام ترخيص بالعداد مقارنةً بترخيص دائم؟**

لا. الأمر يتعلق فقط بآلية الترخيص والفوترة؛ قدرات المنتج تظل نفسها.

**كيف يرتبط ترخيص بالعداد بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، بينما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يومًا، وترخيص بالعداد يزيل القيود ويتقاضى رسومًا بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عبر رد فعل تلقائي عندما يتجاوز استهلاك العتبة المحددة؟**

نعم. ممارسة شائعة هي قراءة الاستهلاك الحالي دوريًا عبر [طرق التتبع](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) وتنفيذ حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.