---
title: تقديم محمي بكلمة مرور
type: docs
weight: 20
url: /cpp/password-protected-presentation/
keywords: "قفل عرض PowerPoint"
description: "قفل عرض PowerPoint. عرض PowerPoint محمي بكلمة مرور مع Aspose.Slides."
---


## **نبذة عن حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للعروض التقديمية؟**
عندما تحمي عرضًا تقديميًا بكلمة مرور، فهذا يعني أنك تضع كلمة مرور تفرض قيودًا معينة على العرض التقديمي. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض التقديمي المحمي بكلمة مرور عرضًا مقفلاً.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض التقديمي:

- **التعديل**

  إذا كنت ترغب في أن يتمكن بعض المستخدمين فقط من تعديل العرض التقديمي الخاص بك، يمكنك تعيين قيد تعديل. تمنع هذه القيود الأشخاص من تعديل أو تغيير أو نسخ الأشياء في عرضك التقديمي (ما لم يقدموا كلمة المرور). 

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيكون المستخدم قادرًا على الوصول إلى المستند الخاص بك وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتويات أو الأشياء—الروابط التشعبية، الرسوم المتحركة، التأثيرات، وغيرها—داخل عرضك التقديمي، لكن لا يمكنهم نسخ العناصر أو حفظ العرض التقديمي. 

- **الافتتاح**

  إذا كنت ترغب في أن يتمكن بعض المستخدمين فقط من فتح عرضك التقديمي، يمكنك تعيين قيد افتتاح. تمنع هذه القيود الأشخاص حتى من مشاهدة محتويات عرضك التقديمي (ما لم يقدموا كلمة المرور).

  من الناحية الفنية، يمنع قيد الافتتاح أيضًا المستخدمين من تعديل عروضهم التقديمية: عندما لا يمكن للناس فتح عرض تقديمي، لا يمكنهم تعديل أو إجراء تغييرات عليه. 

  **ملاحظة** أن عند حماية عرض تقديمي بكلمة مرور لمنع الافتتاح، يصبح ملف العرض التقديمي مشفرًا.

## **كيفية حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. اذهب إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **إسقاط أو تحميل ملفاتك**.

3. حدد الملف الذي ترغب في حمايته بكلمة مرور على جهاز الكمبيوتر الخاص بك. 

4. أدخل كلمة المرور المفضلة لديك لحماية التعديل؛ أدخل كلمة المرور المفضلة لديك لحماية العرض. 

5. إذا كنت ترغب في أن يرى المستخدمون عرضك التقديمي كنسخة نهائية، ضع علامة في مربع **تعيين كنهائي**.

6. انقر على **احم الآن.** 

7. انقر على **تنزيل الآن.**

## **حماية كلمة المرور للعروض التقديمية في Aspose.Slides**
**أنواع الملفات المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، وعمليات مماثلة للعروض التقديمية في هذه الأنواع:

- PPTX و PPT - عرض PowerPoint 
- ODP - عرض OpenDocument 
- OTP - نموذج عرض OpenDocument 

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور على العروض التقديمية لمنع التعديلات بهذه الطرق:

- تشفير عرض تقديمي
- تعيين حماية كتابة لعرض تقديمي

**عمليات أخرى**

يسمح لك Aspose.Slides بأداء مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض تقديمي؛ فتح عرض تقديمي مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض تقديمي
- الحصول على خصائص عرض تقديمي مشفر
- التحقق مما إذا كان عرض تقديمي مشفرًا
- التحقق مما إذا كان عرض تقديمي محميًا بكلمة مرور.

## **تشفير عرض تقديمي**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض التقديمي المقفل، يجب على المستخدم تقديم كلمة المرور. 

لتشفير أو حماية عرض تقديمي بكلمة مرور، يجب عليك استخدام طريقة التشفير (من [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) لتعيين كلمة مرور للعرض التقديمي. تقوم بتمرير كلمة المرور إلى طريقة التشفير وتستخدم طريقة الحفظ لحفظ العرض التقديمي المشفر الآن. 

يعرض لك هذا الكود النموذجي كيفية تشفير عرض تقديمي:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **تعيين حماية الكتابة لعرض تقديمي** 

يمكنك إضافة علامة تنص على "عدم التعديل" إلى عرض تقديمي. بهذه الطريقة، يمكنك إخبار المستخدمين أنك لا تريد منهم إجراء تغييرات على العرض التقديمي.  

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض التقديمي. لذلك، يمكن للمستخدمين—إذا أرادوا فعلًا—تعديل العرض التقديمي، لكن لحفظ التغييرات، سيتوجب عليهم إنشاء عرض تقديمي باسم مختلف. 

لتعيين حماية الكتابة، يجب عليك استخدام طريقة setWriteProtection. يعرض لك هذا الكود النموذجي كيفية تعيين حماية الكتابة لعرض تقديمي:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **فك تشفير عرض تقديمي؛ فتح عرض تقديمي مشفر**

يسمح لك Aspose.Slides بتحميل ملف مشفر عن طريق تمرير كلمة مروره. لفك تشفير عرض تقديمي، يجب عليك استدعاء [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) بدون معلمات. ثم يجب عليك إدخال كلمة المرور الصحيحة لتحميل العرض التقديمي. 

يعرض لك هذا الكود النموذجي كيفية فك تشفير عرض تقديمي: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// العمل مع العرض التقديمي المفكوك تشفيره
```

## **إزالة التشفير؛ تعطيل حماية كلمة المرور**

يمكنك إزالة التشفير أو حماية كلمة المرور عن عرض تقديمي. بهذه الطريقة، يصبح المستخدمون قادرين على الوصول أو تعديل العرض التقديمي بدون قيود. 

لإزالة التشفير أو حماية كلمة المرور، يجب عليك استدعاء [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). يعرض لك هذا الكود النموذجي كيفية إزالة التشفير من عرض تقديمي:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **إزالة حماية الكتابة من عرض تقديمي**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض تقديمي. بهذه الطريقة، يمكن للمستخدمين التعديل كما يحلو لهم—ولا يحصلون على تحذيرات عند تنفيذ مثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض تقديمي باستخدام [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). يعرض لك هذا الكود النموذجي كيفية إزالة حماية الكتابة من عرض تقديمي:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **الحصول على خصائص عرض تقديمي مشفر**

عادةً، يكافح المستخدمون للحصول على خصائص الوثيقة لعروض تقديمية مشفرة أو محمية بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تسمح لك بحماية عرض تقديمي بكلمة مرور مع الاحتفاظ بوسائل وصول المستخدمين إلى خصائص ذلك العرض التقديمي.

**ملاحظة** أنه عند تشفير Aspose.Slides عرضًا تقديميًا، يتم أيضًا حماية خصائص وثيقة العرض التقديمي بكلمة مرور افتراضيًا. ولكن إذا كنت بحاجة إلى جعل خصائص العرض التقديمي قابلة للوصول (حتى بعد تشفير العرض التقديمي)، يسمح لك Aspose.Slides بفعل ذلك تمامًا. 

إذا كنت ترغب في أن يحتفظ المستخدمون بقدرتهم على الوصول إلى خصائص عرض تقديمي قمت بتشفيره، يمكنك تمرير `true` إلى [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). يعرض لك هذا الكود النموذجي كيفية تشفير عرض تقديمي مع توفير الوسائل للمستخدمين للوصول إلى خصائص وثيقته:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **التحقق مما إذا كان عرض تقديمي محميًا بكلمة مرور قبل تحميله**

قبل تحميل عرض تقديمي، قد ترغب في التحقق والتأكد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، يمكنك تجنب الأخطاء وغيرها من المشاكل، التي تظهر عند تحميل عرض تقديمي محمي بكلمة مرور بدون كلمته.

يوضح لك هذا الكود في C++ كيفية فحص عرض تقديمي للتحقق مما إذا كان محميًا بكلمة مرور (دون تحميل العرض التقديمي نفسه):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"العرض التقديمي محمي بكلمة مرور: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **التحقق مما إذا كان عرض تقديمي مشفرًا**

يسمح لك Aspose.Slides بالتحقق مما إذا كان عرض تقديمي مشفرًا. لأداء هذه المهمة، يمكنك استخدام [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) التي ترجع `true` إذا كان العرض التقديمي مشفرًا أو `false` إذا لم يكن العرض مشفرًا. 

يعرض لك هذا الكود النموذجي كيفية التحقق مما إذا كان عرض تقديمي مشفرًا:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **التحقق مما إذا كان عرض تقديمي محميًا بالكتابة**

يسمح لك Aspose.Slides بالتحقق مما إذا كان عرض تقديمي محميًا بالكتابة. لأداء هذه المهمة، يمكنك استخدام [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) التي ترجع `true` إذا كان العرض التقديمي محميًا بالكتابة أو `false` إذا لم يكن العرض محميًا بالكتابة. 

يعرض لك هذا الكود النموذجي كيفية التحقق مما إذا كان عرض تقديمي محميًا بالكتابة:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **التحقق أو التأكيد من أنه تم استخدام كلمة مرور معينة لحماية عرض تقديمي**

قد ترغب في التحقق والتأكيد من أنه تم استخدام كلمة مرور معينة لحماية وثيقة عرض تقديمي. يوفر Aspose.Slides الوسائل التي تتيح لك التحقق من كلمة مرور. 

يعرض لك هذا الكود النموذجي كيفية التحقق من كلمة المرور:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// تحقق مما إذا كانت "pass" مطابقة
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

ترجع `true` إذا تم تشفير العرض التقديمي بكلمة المرور المحددة. خلاف ذلك، ترجع `false`. 

{{% alert color="primary" title="راجع أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}