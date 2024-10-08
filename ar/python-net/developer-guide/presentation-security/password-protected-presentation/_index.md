---
title: عرض محمي بكلمة مرور
type: docs
weight: 20
url: /ar/python-net/password-protected-presentation/
keywords: "قفل PowerPoint، فتح PowerPoint، حماية PowerPoint، تعيين كلمة المرور، إضافة كلمة المرور، تشفير PowerPoint، فك تشفير PowerPoint، حماية الكتابة، أمان PowerPoint، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "حماية كلمة مرور PowerPoint، التشفير، والأمان في بايثون"

---

## **حول حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للعرض؟**
عند حماية عرض بكلمة مرور، فهذا يعني أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض. لإزالة القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمي بكلمة مرور عرضًا مقفلاً.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد من مستخدمين معينين فقط تعديل عرضك، يمكنك تعيين قيود على التعديل. تمنع هذه القيود الأشخاص من تعديل أو تغيير أو نسخ الأشياء في عرضك (ما لم يتوفر لديهم كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيكون بمقدور المستخدم الوصول إلى مستندك وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتويات أو الأشياء - الروابط التشعبية، الرسوم المتحركة، التأثيرات، وغيرها - داخل عرضك، ولكنه لا يمكنه نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد من مستخدمين معينين فقط فتح عرضك، يمكنك تعيين قيود على الفتح. تمنع هذه القيود الأشخاص حتى من عرض محتويات عرضك (ما لم يقدموا كلمة المرور).

  تقنيًا، تمنع قيود الفتح أيضًا المستخدمين من تعديل عروضك: عندما لا يمكن للأشخاص فتح عرض، فلا يمكنهم تعديل أو إجراء تغييرات عليه.

  **ملاحظة** أنه عند حماية عرض بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## كيفية حماية عرض بكلمة مرور عبر الإنترنت

1. انتقل إلى صفحتنا [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **إسقاط أو رفع ملفاتك**.

3. حدد الملف الذي تريد حمايته بكلمة مرور على جهاز الكمبيوتر الخاص بك.

4. أدخل كلمة المرور المفضلة لديك لحماية التعديل؛ أدخل كلمة المرور المفضلة لديك لحماية العرض.

5. إذا كنت تريد من المستخدمين رؤية عرضك كنسخة نهائية، قم بتحديد خانة **تحديد كنهائي**.

6. انقر على **حمايه الآن.**

7. انقر على **تنزيل الآن.**

## **حماية كلمة المرور للعروض في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، والتشفير، والعمليات المماثلة للعروض في هذه الصيغ:

- PPTX و PPT - عرض Microsoft PowerPoint
- ODP - عرض OpenDocument
- OTP - قالب عرض OpenDocument

**العمليات المدعومة**

يسمح Aspose.Slides لك باستخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض
- تعيين حماية الكتابة لعرض

**عمليات أخرى**

يسمح Aspose.Slides لك بإجراء مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## **تشفير عرض**

يمكنك تشفير عرض عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض بكلمة مرور، يجب عليك استخدام طريقة التشفير (من [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) لتعيين كلمة مرور للعرض. تمرر كلمة المرور إلى طريقة التشفير وتستخدم طريقة الحفظ لحفظ العرض المشفر الآن.

تظهر لك هذه الشفرة المصدرية كيفية تشفير عرض:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين حماية الكتابة لعرض**

يمكنك إضافة علامة تفيد "لا تعدل" إلى عرض. بهذه الطريقة، تخبر المستخدمين أنك لا تريد منهم إجراء تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين - إذا أرادوا حقًا - تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف.

لتعيين حماية الكتابة، يجب عليك استخدام طريقة setWriteProtection. تظهر لك هذه الشفرة المصدرية كيفية تعيين حماية الكتابة لعرض:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **فك تشفير عرض؛ فتح عرض مشفر**

يسمح Aspose.Slides لك بتحميل ملف مشفر عن طريق تمرير كلمة مروره. لفك تشفير عرض، يجب عليك استدعاء طريقة [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) بدون معلمات. ثم سيتعين عليك إدخال كلمة المرور الصحيحة لتحميل العرض.

تظهر لك هذه الشفرة المصدرية كيفية فك تشفير عرض:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور على عرض. بهذه الطريقة، يصبح بإمكان المستخدمين الوصول إلى العرض أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، يجب عليك استدعاء طريقة [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). تظهر لك هذه الشفرة المصدرية كيفية إزالة التشفير من عرض:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **إزالة حماية الكتابة من عرض**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض. بهذه الطريقة، يحصل المستخدمون على تعديل كما يشاءون - ولا يحصلون على تحذيرات عند تنفيذ مثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض باستخدام طريقة [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). تظهر لك هذه الشفرة المصدرية كيفية إزالة حماية الكتابة من عرض:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **الحصول على خصائص عرض مشفر**

عادةً ما يعاني المستخدمون من صعوبة في الحصول على خصائص المستند لعرض مشفر أو محمي بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تسمح لك بحماية كلمة مرور عرض مع الاحتفاظ بالوسائل للمستخدمين للوصول إلى خصائص ذلك العرض.

**ملاحظة** أنه عند تشفير Aspose.Slides عرضًا، يتم أيضًا حماية خصائص مستند العرض بكلمة مرور بشكل افتراضي. ولكن إذا كنت بحاجة إلى جعل خصائص العرض قابلة للوصول (حتى بعد أن يتم تشفير العرض)، يسمح لك Aspose.Slides بالقيام بذلك بالضبط.

إذا كنت ترغب في أن يحتفظ المستخدمون بالقدرة على الوصول إلى خصائص عرض قمت بتشفيره، يمكنك تعيين خاصية [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) إلى `True`. تظهر لك هذه الشفرة المصدرية كيفية تشفير عرض مع توفير الوسائل للمستخدمين للوصول إلى خصائص مستنداته:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله**

قبل تحميل عرض، قد ترغب في التحقق والتأكيد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، يمكنك تجنب الأخطاء والقضايا المماثلة، التي تظهر عند تحميل عرض محمي بكلمة مرور بدون كلمة المرور الخاصة به.

تظهر لك هذه الشفرة المصدرية كيفية فحص عرض لمعرفة ما إذا كان محميًا بكلمة مرور (بدون تحميل العرض نفسه):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("العرض محمي بكلمة مرور: " + str(presentationInfo.is_password_protected))
```

## **التحقق مما إذا كان العرض مشفرًا**

يسمح لك Aspose.Slides بالتحقق مما إذا كان العرض مشفرًا. لأداء هذه المهمة، يمكنك استخدام خاصية [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) التي تُعيد `True` إذا كان العرض مشفرًا أو `False` إذا لم يكن العرض مشفرًا.

تظهر لك هذه الشفرة المصدرية كيفية التحقق مما إذا كان العرض مشفرًا:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **التحقق مما إذا كان العرض محميًا ضد الكتابة**

يسمح لك Aspose.Slides بالتحقق مما إذا كان العرض محميًا ضد الكتابة. لأداء هذه المهمة، يمكنك استخدام خاصية [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) التي تُعيد `True` إذا كان العرض مشفرًا أو `False` إذا لم يكن العرض مشفرًا.

تظهر لك هذه الشفرة المصدرية كيفية التحقق مما إذا كان العرض محميًا ضد الكتابة:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **التحقق أو التأكيد من أن كلمة مرور معينة قد تم استخدامها لحماية عرض**

قد ترغب في التحقق والتأكيد من أن كلمة مرور معينة قد تم استخدامها لحماية مستند العرض. يوفر لك Aspose.Slides الوسائل للتحقق من كلمة المرور.

تظهر لك هذه الشفرة المصدرية كيفية التحقق من كلمة المرور:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # تحقق مما إذا كانت "كلمة المرور" متطابقة مع
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

يُعيد `True` إذا كان العرض قد تم تشفيره بكلمة المرور المحددة. خلاف ذلك، يُعيد `False`.

{{% alert color="primary" title="انظر أيضاً" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}