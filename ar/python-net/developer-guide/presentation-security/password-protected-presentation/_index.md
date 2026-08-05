---
title: تأمين العروض التقديمية بكلمات مرور باستخدام بايثون
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/python-net/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل العرض التقديمي
- فتح قفل PowerPoint
- فتح قفل العرض التقديمي
- حماية PowerPoint
- حماية العرض التقديمي
- تعيين كلمة مرور
- إضافة كلمة مرور
- تشفير PowerPoint
- تشفير العرض التقديمي
- فك تشفير PowerPoint
- فك تشفير العرض التقديمي
- حماية كتابة
- أمان PowerPoint
- أمان العرض التقديمي
- إزالة كلمة المرور
- إزالة الحماية
- إزالة التشفير
- تعطيل كلمة المرور
- تعطيل الحماية
- إزالة حماية الكتابة
- عرض PowerPoint
- Python
- Aspose.Slides
description: "تعلم كيفية قفل وفتح العروض التقديمية المحمية بكلمة مرور من PowerPoint وOpenDocument بسهولة باستخدام Aspose.Slides لبايثون عبر .NET. عزّز إنتاجيتك وأمّن عروضك التقديمية من خلال دليلنا خطوة بخطوة."
---
## **المقدمة**

عند حماية عرض تقديمي بكلمة مرور، فإنك تحدد كلمة مرور تفرض قيودًا معينة على العرض. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمي بكلمة مرور عرضًا مقفلًا.

عادةً ما يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من تعديل العرض، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ محتويات العرض (إلا إذا قدموا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيستطيع المستخدم الوصول إلى المستند وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتويات أو العناصر—كالروابط التشعبية والرسوم المتحركة والتأثيرات وغيرها—داخل العرض، لكنه لا يمكنه نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من فتح العرض، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى عرض محتويات العرض (إلا إذا قدموا كلمة المرور).

  تقنيًا، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضهم: عندما لا يستطيع الأشخاص فتح العرض، لا يمكنهم تعديل أو إجراء تغييرات فيه.  

  **ملاحظة** أنه عندما تحمي عرضًا تقديميًا بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## كيفية حماية عرض تقديمي بكلمة مرور عبر الإنترنت

1. انتقل إلى صفحة [**قفل Aspose.Slides**](https://products.aspose.app/slides/ar/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **إسقاط أو تحميل ملفاتك**.

3. اختر الملف الذي تريد حمايته بكلمة مرور على جهازك.

4. أدخل كلمة المرور المفضلة للحماية من التعديل؛ أدخل كلمة المرور المفضلة للحماية من العرض.

5. إذا أردت أن يرى المستخدمون عرضك كنسخة نهائية، ضع علامة على خانة **وضع علامة نهائي**.

6. انقر على **حماية الآن**.

7. انقر على **تحميل الآن**.

## **حماية كلمة المرور للعروض التقديمية في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض في هذه الصيغ:

- PPTX و PPT - عرض PowerPoint من Microsoft
- ODP - عرض OpenDocument
- OTP - قالب عرض OpenDocument

**العمليات المدعومة**

يسمح لك Aspose.Slides باستخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير العرض
- تعيين حماية كتابة للعرض

**عمليات أخرى**

يسمح لك Aspose.Slides بأداء مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من العرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض تقديمي**

يمكنك تشفير عرض تقديمي بتعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض تقديمي بكلمة مرور، عليك استخدام طريقة encrypt (من [ProtectionManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/)) لتعيين كلمة مرور للعرض. تمرر كلمة المرور إلى طريقة encrypt وتستخدم طريقة save لحفظ العرض المشفر الآن.

يعرض هذا المثال البرمجي كيفية تشفير عرض تقديمي:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حماية كتابة للعرض** 

يمكنك إضافة علامة “عدم التعديل” إلى العرض. بهذه الطريقة، تخبر المستخدمين أنك لا تريدهم أن يُجريوا تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين—إذا أرادوا—تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف.

لتعيين حماية كتابة، عليك استخدام طريقة setWriteProtection. يعرض هذا المثال البرمجي كيفية تعيين حماية كتابة للعرض:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **فك تشفير عرض تقديمي؛ فتح عرض مشفر**

يسمح لك Aspose.Slides بتحميل ملف مشفر بتمرير كلمة المرور الخاصة به. لفك تشفير عرض تقديمي، عليك استدعاء طريقة [remove_encryption](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/) دون معلمات. سيتعين عليك ثم إدخال كلمة المرور الصحيحة لتحميل العرض.

يعرض هذا المثال البرمجي كيفية فك تشفير عرض تقديمي:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور على عرض تقديمي. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، عليك استدعاء طريقة [remove_encryption](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/). يوضح هذا المثال البرمجي كيفية إزالة التشفير من عرض:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة حماية الكتابة من العرض**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض تقديمي. بهذه الطريقة، يتمكن المستخدمون من تعديل العرض كما يريدون—ولا يحصلون على أي تحذيرات عند إجراء مثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض باستخدام طريقة [remove_write_protection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/). يوضح هذا المثال البرمجي كيفية إزالة حماية الكتابة من عرض:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على خصائص عرض مشفر**

عادةً ما يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعروض مشفرة أو محمية بكلمة مرور. ومع ذلك، يقدم Aspose.Slides آلية تسمح لك بحماية عرض بكلمة مرور مع الحفاظ على قدرة المستخدمين على الوصول إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يقوم Aspose.Slides بتشفير عرض، تُحمي خصائص مستند العرض أيضًا بكلمة مرور. إذا كنت بحاجة إلى جعل خصائص المستند متاحة حتى بعد التشفير، يتيح لك Aspose.Slides فعل ذلك بالضبط.

إذا أردت أن يتمكن المستخدمون من الوصول إلى خصائص عرض مشفر، عيّن خاصية `encrypt_document_properties` في [ProtectionManager](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/) إلى `False`. يوضح هذا المثال البرمجي كيفية تشفير عرض مع إبقاء خصائص المستند متاحة للمستخدمين:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **تحميل خصائص المستند فقط من عرض مشفر**

للتفحص الوصفي لعرض مشفر دون تحميل شرائحه أو محتوياته الأخرى، أنشئ كائنًا من نوع [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/) وعين [only_load_document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/only_load_document_properties/) إلى `True`. في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمل فقط خصائص المستند المتاحة للعموم.

تقرأ مثال الشيفرة التالية خصائص المستند المدمجة وتدرج خصائص المستند المخصصة عبر [Presentation.document_properties](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # قراءة خصائص المستند المدمجة.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # سرد خصائص المستند المخصصة.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

يعمل هذا التدفق فقط عندما تُترك خصائص المستند غير مشفرة (عامة) عند تشفير العرض. إذا كانت خصائص المستند مشفرة، فإن تعيين `only_load_document_properties` إلى `True` يتسبب في استثناء لأن كلمة المرور تُهمل في هذا الوضع. للوصول إلى خصائص المستند المشفرة أو تحميل العرض بالكامل بما في ذلك شرائحه ومحتوياته الأخرى، قدم القيمة الصحيحة لـ `password` في [LoadOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides/loadoptions/).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله**

قبل تحميل عرض، قد ترغب في التحقق والتأكد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، تتجنب الأخطاء والمشكلات المماثلة التي تحدث عندما يتم تحميل عرض محمي بكلمة مرور دون كلمة المرور.

يعرض هذا الكود بلغة Python كيفية فحص عرض لمعرفة ما إذا كان محميًا بكلمة مرور (دون تحميل العرض نفسه):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **التحقق مما إذا كان العرض مشفرًا**

يسمح لك Aspose.Slides بالتحقق مما إذا كان العرض مشفرًا. للقيام بذلك، يمكنك استخدام خاصية [is_encrypted](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/) التي تُعيد `True` إذا كان العرض مشفرًا أو `False` إذا لم يكن مشفرًا.

يعرض هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفرًا:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

يسمح لك Aspose.Slides بالتحقق مما إذا كان العرض محميًا من الكتابة. للقيام بذلك، يمكنك استخدام خاصية [is_write_protected](https://reference.aspose.com/slides/ar/python-net/aspose.slides/protectionmanager/) التي تُعيد `True` إذا كان العرض مشفرًا أو `False` إذا لم يكن مشفرًا.

يعرض هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **التحقق من صحة أو تأكيد استخدام كلمة مرور معينة لحماية عرض تقديمي**

قد ترغب في التحقق وتأكيد أن كلمة مرور معينة قد استُخدمت لحماية مستند العرض. يوفر لك Aspose.Slides الوسائل للتحقق من صحة كلمة المرور.

يعرض هذا المثال البرمجي كيفية التحقق من كلمة مرور:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # تحقق مما إذا كان "pass" متطابقًا مع
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

يعيد `True` إذا تم تشفير العرض بالكلمة المحددة. وإلا، يعيد `False`.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هي طرق التشفير التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides طرق تشفير حديثة، بما في ذلك الخوارزميات القائمة على AES، مما يضمن مستوى عاليًا من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إطلاق استثناء إذا استُخدمت كلمة مرور غير صحيحة، مما يُنبهك إلى أن الوصول إلى العرض مُرفوض. يساعد ذلك في منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تبعات على الأداء عند العمل مع عروض محمية بكلمة مرور؟**

قد يضيف عملية التشفير وفك التشفير بعض الحمل الإضافي الطفيف أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون تأثير الأداء ضئيلًا ولا يؤثر بشكل كبير على الوقت الإجمالي لمعالجة مهام العرض.