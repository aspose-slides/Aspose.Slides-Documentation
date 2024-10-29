---
title: الترخيص المقنن
type: docs
weight: 90
url: /ar/python-net/metered-licensing/
---

{{% alert color="primary" %}} 

الترخيص المقنن هو آلية ترخيص جديدة يمكن استخدامها جنبًا إلى جنب مع أساليب الترخيص الحالية. إذا كنت ترغب في أن يتم فاتورتك بناءً على استخدامك لميزات واجهة برمجة التطبيقات Aspose.Slides، يمكنك اختيار الترخيص المقنن.

عند شراء ترخيص مقنن، ستحصل على مفاتيح (وليس ملف ترخيص). يمكن تطبيق هذا المفتاح المقنن باستخدام فئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) التي وفرتها Aspose لعمليات القياس. لمزيد من التفاصيل، انظر [أسئلة شائعة حول الترخيص المقنن](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. قم بإنشاء مثيل من فئة [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. مرر مفاتيحك العامة والخاصة إلى طريقة `set_metered_key`.
1. قم ببعض المعالجة (قم بأداء المهام).
1. استدعاء طريقة `get_consumption_quantity()` من فئة Metered.

   ينبغي أن ترى كمية/عدد طلبات API التي استهلكتها حتى الآن.

هذا الكود بلغة بايثون يوضح لك كيفية تعيين المفاتيح العامة والخاصة المقننة:

```python
import aspose.slides as slides

# ينشئ مثيل من فئة CAD Metered
metered = slides.Metered()

# الوصول إلى خاصية set_metered_key وتمرير المفاتيح العامة والخاصة كمعلمات
metered.set_metered_key("*****", "*****")

# الحصول على كمية البيانات المقننة قبل استدعاء واجهة برمجة التطبيقات
amountbefore = slides.metered.get_consumption_quantity()
# عرض المعلومات
print("المبلغ المستهلك قبل: " + str(amountbefore))

# تحميل المستند من القرص.
with slides.Presentation("Presentation.pptx") as pres:
   # يحصل على عدد صفحات المستند
   print(len(pres.slides))
   # حفظ كملف PDF
   pres.save("out_pdf.pdf", slides.export.SaveFormat.PDF)

# يحصل على كمية البيانات المقننة بعد استدعاء واجهة برمجة التطبيقات
amountafter = slides.metered.get_consumption_quantity()
# عرض المعلومات
print("المبلغ المستهلك بعد: " + str(amountafter))
```

{{% alert color="warning" title="ملحوظة"  %}} 

للاستخدام الترخيص المقنن، تحتاج إلى اتصال إنترنت مستقر لأن آلية الترخيص تستخدم الإنترنت للتفاعل المستمر مع خدماتنا وإجراء الحسابات.

{{% /alert %}} 