---
title: ترخيص القياس
type: docs
weight: 90
url: /ar/python-net/metered-licensing/
keywords:
- ترخيص
- ترخيص القياس
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- Python
- Aspose.Slides
description: "تعرف على كيفية تمكين Aspose.Slides for Python عبر .NET من الترخيص القائم على الاستهلاك لمعالجة ملفات PowerPoint وOpenDocument بمرونة، ودفع فقط مقابل ما تستخدمه."
---

## **تطبيق مفاتيح القياس**

{{% alert color="primary" %}} 

ترخيص القياس هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الموجودة. إذا كنت تريد أن تُفوتر بناءً على استخدامك لميزات Aspose.Slides API، فستختار ترخيص القياس.

عند شرائك لترخيص قياس، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح المقِّـيس باستخدام الفئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) التي وفرتها Aspose لعمليات القياس. للمزيد من التفاصيل، راجع [الأسئلة المتكررة لترخيص القياس](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. إنشاء مثيل للفئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. تمرير المفاتيح العامة والخاصة إلى الطريقة [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. إجراء بعض المعالجة (أداء المهام).
1. استدعاء طريقة [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) للفئة `Metered`.

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

يُظهر لك هذا المثال البرمجي كيفية استخدام ترخيص القياس:
```python
import aspose.slides as slides

# إنشاء مثيل لفئة Metered
metered = slides.Metered()

# تمرير المفاتيح العامة والخاصة إلى كائن Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# الحصول على قيمة الكمية المستهلكة قبل استدعاءات API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# تنفيذ شيء باستخدام Aspose.Slides API هنا
# ...

# الحصول على قيمة الكمية المستهلكة بعد استدعاءات API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```


{{% alert color="warning" title="NOTE"  %}} 

لاستخدام ترخيص القياس، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص قياس مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. الترخيص المقِّـيس هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/python-net/licensing/) الموجودة. يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما الذي يُحتسب كاستهلاك تحت ترخيص القياس: عمليات أم ملفات؟**

يُحتسب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**هل الترخيص المقِّـيس مناسب لبيئات الخدمات المصغرة والخوادم غير التقليدية حيث يتم إعادة تشغيل المثيلات بشكل متكرر؟**

نعم. نظرًا لأن المحاسبة تتم على مستوى استدعاء API، فإن السيناريوهات التي تتضمن عمليات بدء باردة متكررة متوافقة، بشرط توفر وصول شبكة ثابت لحسابات الترخيص المقِّـيس.

**هل تختلف وظائف المكتبة عند استخدام ترخيص قياس مقارنةً بترخيص دائم؟**

لا. الأمر يتعلق فقط بآلية الترخيص والفوترة؛ وظائف المنتج تبقى كما هي.

**كيف يرتبط الترخيص المقِّـيس بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، الـ[ترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يومًا، والقياس يزيل القيود ويتقاضى رسومًا بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عن طريق رد فعل تلقائي عند تجاوز عتبة الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي بشكل دوري عبر [طرق التتبع](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) وتطبيق حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.