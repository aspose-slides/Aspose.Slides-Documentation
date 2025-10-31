---
title: الترخيص القائم على الاستهلاك
type: docs
weight: 90
url: /ar/python-net/metered-licensing/
keywords:
- رخصة
- رخصة مستهلكة
- مفاتيح الترخيص
- المفتاح العام
- المفتاح الخاص
- كمية الاستهلاك
- Python
- Aspose.Slides
description: "تعرّف على كيفية تمكين ترخيص Aspose.Slides للغة بايثون عبر .NET القائم على الاستهلاك من معالجة ملفات PowerPoint وOpenDocument بمرونة، مع الدفع فقط مقابل ما تستخدمه."
---

## **تطبيق المفاتيح المستهلكة**

{{% alert color="primary" %}} 
الترخيص القائم على الاستهلاك هو آلية ترخيص جديدة يمكن استخدامها إلى جانب طرق الترخيص الحالية. إذا كنت ترغب في الفوترة بناءً على استخدامك لميزات Aspose.Slides API، فإنك تختار الترخيص القائم على الاستهلاك.

عند شراء ترخيص مستهلك، تحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح المستهلك باستخدام الفئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) التي قدمتها Aspose لعمليات العداد. لمزيد من التفاصيل، راجع [الأسئلة المتكررة حول الترخيص القائم على الاستهلاك](https://purchase.aspose.com/faqs/licensing/metered).
{{% /alert %}} 

1. إنشاء مثال لفئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. تمرير مفاتيحك العامة والخاصة إلى طريقة [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. إجراء بعض المعالجة (تنفيذ المهام).
1. استدعاء طريقة [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) للفئة `Metered`.

يجب أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

يوضح لك هذا المثال البرمجي كيفية استخدام الترخيص القائم على الاستهلاك:

```python
import aspose.slides as slides

# ينشئ مثالاً للفئة Metered
metered = slides.Metered()

# يمرّر المفاتيح العامة والخاصة إلى كائن Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# يحصل على قيمة كمية الاستهلاك قبل استدعاءات API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# قم بعمل شيء باستخدام Aspose.Slides API هنا
# ...

# يحصل على قيمة كمية الاستهلاك بعد استدعاءات API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 
لاستخدام الترخيص القائم على الاستهلاك، تحتاج إلى اتصال إنترنت ثابت لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.
{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام ترخيص مستهلك مع ترخيص عادي (دائم أو مؤقت) في نفس التطبيق؟**

نعم. الترخيص القائم على الاستهلاك هو آلية ترخيص إضافية يمكن استخدامها إلى جانب [طرق الترخيص](/slides/ar/python-net/licensing/) الحالية. يمكنك اختيار الآلية التي تريد تطبيقها عند بدء تشغيل التطبيق.

**ما هو ما يُحتسب كاستهلاك في ترخيص مستهلك: العمليات أم الملفات؟**

يُحتسب استخدام API، أي عدد الطلبات أو العمليات. يمكنك الحصول على الاستهلاك الحالي عبر [طرق تتبع الاستهلاك](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**هل الترخيص القائم على الاستهلاك مناسب للميكرو سيرفيسز والبيئات الخالية من الخوادم حيث يعاد تشغيل المثيلات بشكل متكرر؟**

نعم. بما أن المحاسبة تتم على مستوى استدعاءات API، فإن السيناريوهات التي تتضمن عمليات بدء باردة متكررة متوافقة، بشرط وجود اتصال شبكة ثابت لحسابات الاستهلاك.

**هل تختلف وظائف المكتبة عند استخدام ترخيص مستهلك مقارنةً بترخيص دائم؟**

لا. الأمر يتعلق فقط بآلية الترخيص والفوترة؛ قدرات المنتج تبقى هي نفسها.

**كيف يرتبط الترخيص القائم على الاستهلاك بالإصدار التجريبي والترخيص المؤقت؟**

الإصدار التجريبي يحتوي على قيود وعلامات مائية، الـ[ترخيص المؤقت](https://purchase.aspose.com/temporary-license/) يزيل القيود لمدة 30 يوماً، والترخيص القائم على الاستهلاك يزيل القيود ويحتسب الرسوم بناءً على الاستخدام الفعلي.

**هل يمكنني التحكم في الميزانية عن طريق الرد تلقائياً عندما يتجاوز استهلاك الحد المحدد؟**

نعم. من الممارسات الشائعة قراءة الاستهلاك الحالي دوريًا عبر [طرق التتبع](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) وتنفيذ حدود أو تنبيهات خاصة بك على مستوى التطبيق أو المراقبة.