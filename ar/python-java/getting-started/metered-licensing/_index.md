---
title: الترخيص القائم على الاستهلاك
type: docs
weight: 100
url: /ar/python-java/metered-licensing/
keywords:
- ترخيص
- ترخيص استهلاكي
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعرف على كيفية استخدام الترخيص القائم على الاستهلاك في Aspose.Slides للغة Python عبر Java لمعالجة ملفات PowerPoint وOpenDocument بمرونة، مع الدفع فقط مقابل ما تستخدمه."
---
## **المقدمة**

ترخيص Metered هو آلية ترخيص يمكن استخدامها إلى جانب طرق الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فاختر ترخيص Metered.

## **تطبيق مفاتيح Metered**

{{% alert color="info" title="Note" %}}
ترخيص Metered هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فاختر ترخيص Metered.

عند شراء ترخيص Metered، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق مفتاح Metered هذا باستخدام الفئة [Metered](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/) التي تقدمها Aspose لعمليات القياس. لمزيد من التفاصيل، راجع [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}}

1. إنشاء مثال من الفئة [Metered](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/).

2. تمرير المفاتيح العامة والخاصة الخاصة بك إلى طريقة [setMeteredKey](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/#setMeteredKey).

3. إجراء بعض المعالجة (تنفيذ المهام).

4. استدعاء طريقة [getConsumptionQuantity](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/#getConsumptionQuantity) من الفئة [Metered](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/).

يجب أن ترى عدد/كمية طلبات API التي استهلكتها حتى الآن.

يعرض لك هذا الكود المثال كيفية استخدام ترخيص Metered:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# إنشاء مثال من الفئة Metered.
metered = Metered()

try:
    # تمرير المفتاحين العام والخاص إلى كائن Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # الحصول على كمية الاستهلاك قبل طلبات API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # القيام بشيء ما باستخدام Aspose.Slides API هنا.
    # ...

    # الحصول على كمية الاستهلاك بعد طلبات API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warning"  %}}
لاستخدام ترخيص Metered، تحتاج إلى اتصال إنترنت مستقر لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص Metered مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. Metered هو آلية ترخيص إضافية يمكن استخدامها جنبًا إلى جنب مع [طرق الترخيص](/slides/ar/python-java/licensing/) الحالية. تختار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما الذي يُحتسب كاستهلاك تحت ترخيص Metered: العمليات أم الملفات؟**

يُحتسب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/).

**هل يناسب ترخيص Metered بيئات الخدمات المصغرة والخوادم بدون خوادم حيث يتم إعادة تشغيل المثيلات بشكل متكرر؟**

نعم. بما أن الحساب يتم على مستوى نداء API، فإن السيناريوهات التي تشهد عمليات بدء بارد متكررة متوافقة، بشرط توفر اتصال شبكة ثابت لحسابات Metered.

**هل تختلف وظيفة المكتبة عند استخدام ترخيص Metered مقارنةً بترخيص دائم؟**

لا. هذا يتعلق فقط بآلية الترخيص والفوترة؛ قدرات المنتج تبقى نفسها.

**كيف يرتبط ترخيص Metered بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، أما [الترخيص المؤقت](https://purchase.aspose.com/temporary-license/) فيزيل القيود لمدة 30 يومًا، وترخيص Metered يزيل القيود ويتقاضى رسومًا بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عن طريق الاستجابة تلقائيًا عندما يتم تجاوز عتبة الاستهلاك؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي بشكل دوري عبر [طرق التتبع](https://reference.aspose.com/slides/ar/python-java/aspose.slides/metered/) وتنفيذ حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.