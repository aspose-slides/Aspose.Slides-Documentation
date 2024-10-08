---
title: الترخيص
description: "يوفر Aspose.Slides لـ Python عبر Java خططًا مختلفة للشراء أو يقدم تجربة مجانية ورخصة مؤقتة لمدة 30 يومًا للتقييم باستخدام سياسات الترخيص والاشتراك."
type: docs
weight: 80
url: /ar/python-java/licensing/
---

في بعض الأحيان، من أجل تحقيق أفضل نتائج التقييم، قد تكون الحاجة إلى نهج عملي. لهذا السبب، يوفر Aspose.Slides خطط شراء مختلفة ويقدم أيضًا تجربة مجانية ورخصة مؤقتة لمدة 30 يومًا للتقييم.

{{% alert color="primary" %}}

يرجى ملاحظة أن هناك مجموعة من السياسات والممارسات العامة التي توجهك حول كيفية تقييم وترخيص وشراء منتجاتنا. يمكنك العثور عليها في قسم ["سياسات الشراء والأسئلة الشائعة"](https://purchase.aspose.com/policies).

{{% /alert %}}

## **تقييم Aspose.Slides**
يمكنك تنزيل Aspose.Slides للتقييم بسهولة. حزمة التقييم هي نفس حزمة الشراء. الإصدار التجريبي يصبح مرخصًا ببساطة بعد إضافة بعض سطور الشيفرة لتطبيق الترخيص.

## **قيود الإصدار التجريبي**
يوفر الإصدار التجريبي من Aspose.Slides (دون ترخيص محدد) كامل وظائف المنتج، ولكنه يضيف علامة مائية للتقييم في أعلى المستند عند الفتح والحفظ. كما أنك محدود بصفحة واحدة عند استخراج النصوص من شرائح العرض التقديمي.

{{% alert color="primary" %}} 

إذا كنت ترغب في اختبار Aspose.Slides دون قيود الإصدار التجريبي، يمكنك طلب **رخصة مؤقتة مدتها 30 يومًا**. يرجى الرجوع إلى [كيفية الحصول على رخصة مؤقتة؟](https://purchase.aspose.com/temporary-license) لمزيد من المعلومات.

{{% /alert %}} 

## **حول الترخيص**
يمكنك تنزيل إصدار تجريبي من Aspose.Slides لـ Python عبر Java من صفحته [صفحة التنزيل](https://releases.aspose.com/slides/python-java/). يوفر الإصدار التجريبي نفس **القدرات تمامًا** كالإصدار المرخص من Aspose.Slides. علاوة على ذلك، يصبح الإصدار التجريبي مرخصًا ببساطة بعد شراء ترخيص وإضافة بضعة سطور من الشيفرة لتطبيق الترخيص.

الترخيص هو ملف XML نصي يحتوي على تفاصيل مثل اسم المنتج، وعدد المطورين المرخص لهم، وتاريخ انتهاء الاشتراك، وما إلى ذلك. الملف موقع رقميًا، لذا يجب ألا تقوم بتعديل الملف. حتى إضافة غير مقصودة لفراغ إضافي إلى محتويات الملف ستجعله غير صالح.

لتجنب القيود المرتبطة بالإصدار التجريبي، تحتاج إلى تعيين ترخيص قبل استخدام **Aspose.Slides**. تحتاج فقط إلى تعيين ترخيص مرة واحدة لكل تطبيق أو عملية.

## الترخيص المشتراة

بعد الشراء، تحتاج إلى تطبيق ملف الترخيص أو الدفق. 

{{% alert color="primary" %}}

تحتاج إلى تعيين الترخيص:
* مرة واحدة فقط لكل مجال تطبيق
* قبل استخدام أي من فئات Aspose.Slides الأخرى

{{% /alert %}}

{{% alert color="primary" %}}

يمكنك العثور على معلومات التسعير على صفحة [“معلومات التسعير”](https://purchase.aspose.com/pricing/slides/family).

{{% /alert %}}

### **تعيين ترخيص في Aspose.Slides لـ Python عبر Java**

يمكن تطبيق التراخيص من هذه المواقع:

* مسار صريح
* دفق
* كترخيص مدفوع – آلية ترخيص جديدة

{{% alert color="primary" %}}

استخدم طريقة **setLicense** لترخيص مكون.

بينما تعدد الاتصالات إلى **setLicense** ليست ضارة، إلا أنها تعتبر إهدارًا للموارد (المعالج).

{{% /alert %}}

#### **تطبيق ترخيص باستخدام ملف**

هذا المقتطف البرمجي يُستخدم لتعيين ملف الترخيص:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

عند استدعاء طريقة setLicense، يجب أن يكون اسم الترخيص مطابقًا لاسم ملف الترخيص الخاص بك. على سبيل المثال، يمكنك تغيير اسم ملف الترخيص إلى "Aspose.Slides.lic.xml". ثم، في الشيفرة الخاصة بك، يجب عليك تمرير اسم الترخيص الجديد (Aspose.Slides.lic.xml) إلى طريقة setLicense.

#### **تطبيق ترخيص من بايتس**

هذا المقتطف البرمجي يُستخدم لتطبيق ترخيص من بايتس:

**Python**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### تطبيق ترخيص مدفوع

يسمح Aspose.Slides للمطورين بتطبيق مفتاح مدفوع. هذه آلية ترخيص جديدة.

سيتم استخدام آلية الترخيص الجديدة مع طريقة الترخيص الحالية. يمكن للعملاء الذين يرغبون في دفع رسوم بناءً على استخدام ميزات واجهة برمجة التطبيقات استخدام الترخيص المدفوع.

بعد إكمال جميع الخطوات اللازمة للحصول على هذا النوع من الترخيص، ستتلقى المفاتيح، وليس ملف الترخيص. يمكن تطبيق هذا المفتاح المدفوع باستخدام فئة **Metered** التي تم تقديمها خصيصًا لهذا الغرض.

يوضح المثال البرمجي التالي كيفية تعيين المفاتيح العامة والخاصة المدفوعة:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# إنشاء مثيل من فئة Metered
metered = Metered();

# الوصول إلى خاصية set_metered_key وتمرير المفاتيح العامة والخاصة كمعلمات
metered.setMeteredKey("*****", "*****");

# الحصول على كمية البيانات المدفوعة قبل استدعاء واجهة برمجة التطبيقات
amountbefore = Metered.getConsumptionQuantity()

# عرض المعلومات
print("الكمية المستهلكة قبل: \" + amountbefore + \"" )

# تحميل المستند من القرص.
pres = Presentation();

# الحصول على عدد الصفحات في المستند
print("الكمية المستهلكة بعد: \" +  pres.getSlides().size()) + \"" )

# حفظ كملف PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# الحصول على كمية البيانات المدفوعة بعد استدعاء واجهة برمجة التطبيقات
amountafter = Metered.getConsumptionQuantity()

# عرض المعلومات
print("الكمية المستهلكة بعد: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}

يرجى ملاحظة أنه يجب أن تكون لديك اتصال إنترنت مستقر للاستخدام الصحيح لترخيص المدفوع، حيث تتطلب آلية المدفوع التفاعل المستمر مع خدماتنا لتسجیل الحسابات بشكل صحيح. لمزيد من التفاصيل، يرجى الرجوع إلى قسم [“الأسئلة الشائعة حول الترخيص المدفوع”](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}