---
title: عرض محمي بكلمة مرور
type: docs
weight: 20
url: /ar/net/password-protected-presentation/
keywords: "قفل PowerPoint، فتح PowerPoint، حماية PowerPoint، تعيين كلمة مرور، إضافة كلمة مرور، تشفير PowerPoint، فك تشفير PowerPoint، حماية الكتابة، أمان PowerPoint، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "حماية كلمة مرور PowerPoint، التشفير، والأمان في C# أو .NET"

---

## **حول حماية كلمة المرور**
### **كيف تعمل حماية كلمة المرور للعرض؟**
عند حماية عرض بكلمة مرور، فهذا يعني أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض. لإزالة القيود، يجب إدخال كلمة المرور. يُعتبر العرض المحمي بكلمة مرور عرضًا مقفلاً.

عادةً ما يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض:

- **التعديل**

  إذا كنت تريد من بعض المستخدمين فقط تعديل عرضك، يمكنك تعيين قيود تعديل. تمنع هذه القيود الأشخاص من تعديل أو تغيير أو نسخ العناصر في عرضك (ما لم يوفروا كلمة المرور).

  ومع ذلك، في هذه الحالة، حتى بدون كلمة المرور، سيكون المستخدم قادرًا على الوصول إلى مستندك وفتحه. في هذا الوضع للقراءة فقط، يمكن للمستخدم عرض المحتويات أو العناصر—الروابط، الرسوم المتحركة، التأثيرات، وغيرها—داخل عرضك، لكن لا يمكنهم نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد من بعض المستخدمين فقط فتح عرضك، يمكنك تعيين قيود فتح. تمنع هذه القيود الأشخاص من حتى عرض محتويات عرضك (ما لم يوفروا كلمة المرور).

  تقنيًا، تمنع قيود الفتح أيضًا المستخدمين من تعديل عروضك: عندما لا يستطيع الأشخاص فتح عرض، لا يمكنهم تعديل أو إجراء تغييرات عليه.

  **ملاحظة** أنه عند حماية عرض بكلمة مرور لمنع الفتح، يصبح ملف العرض مُشفرًا.

## كيفية حماية عرض بكلمة مرور عبر الإنترنت

1. انتقل إلى صفحتنا [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. انقر على **إسقاط أو تحميل ملفاتك**.

3. حدد الملف الذي تريد حماية بكلمة مرور على جهاز الكمبيوتر الخاص بك.

4. أدخل كلمة المرور المفضلة لديك لحماية التحرير؛ أدخل كلمة المرور المفضلة لديك لحماية العرض.

5. إذا كنت تريد أن يرى المستخدمون عرضك كنسخة نهائية، حدد خانة **وسم على أنها نهائية**.

6. انقر على **احم الآن.**

7. انقر على **قم بالتنزيل الآن.**

### **حماية كلمة المرور للعروض في Aspose.Slides**
**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، والعمليات المماثلة للعروض في هذه الصيغ:

- PPTX و PPT - عرض Microsoft PowerPoint
- ODP - عرض OpenDocument
- OTP - قالب عرض OpenDocument

**العمليات المدعومة**

يتيح Aspose.Slides لك استخدام حماية كلمة المرور على العروض لمنع التعديلات بهذه الطرق:

- تشفير عرض
- تعيين حماية الكتابة لعرض

**عمليات أخرى**

يتيح Aspose.Slides لك إجراء مهام أخرى تتعلق بحماية كلمة المرور والتشفير بهذه الطرق:

- فك تشفير عرض؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض
- الحصول على خصائص عرض مشفر
- التحقق مما إذا كان عرضًا محميًا بكلمة مرور قبل تحميله
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور.

## تشفير عرض

يمكنك تشفير عرض عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير أو حماية عرض بكلمة مرور، يجب عليك استخدام طريقة التشفير (من [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager)) لتعيين كلمة مرور للعرض. تمرر كلمة المرور إلى طريقة التشفير وتستخدم طريقة الحفظ لحفظ العرض المُشفر الآن.

هذا الرمز المثال يوضح لك كيفية تشفير عرض:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## تعيين حماية الكتابة لعرض

 يمكنك إضافة علامة تفيد "لا تعدّل" إلى عرض. بهذه الطريقة، يمكنك إخبار المستخدمين بأنك لا تريد منهم إجراء تغييرات على العرض.

**ملاحظة** أن عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين - إذا كانوا يريدون ذلك - تعديل العرض، لكن لحفظ التغييرات، سيتعين عليهم إنشاء عرض باسم مختلف.

لتعيين حماية الكتابة، يجب عليك استخدام طريقة setWriteProtection. هذا الرمز المثال يوضح لك كيفية تعيين حماية الكتابة لعرض:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## فك تشفير عرض؛ فتح عرض مشفر

يتيح Aspose.Slides لك تحميل ملف مشفر عن طريق تمرير كلمة المرور الخاصة به. لفك تشفير عرض، يجب عليك استدعاء طريقة [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) بدون أي معاملات. ثم سيتعين عليك إدخال كلمة المرور الصحيحة لتحميل العرض.

هذا الرمز المثال يوضح لك كيفية فك تشفير عرض:

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
  // العمل مع العرض المفكوك
}
```

## إزالة التشفير؛ تعطيل حماية كلمة المرور

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض. بهذه الطريقة، يتمكن المستخدمون من الوصول أو تعديل العرض دون قيود.

لإزالة التشفير أو حماية كلمة المرور، يجب عليك استدعاء طريقة [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption). هذا الرمز المثال يوضح لك كيفية إزالة التشفير من عرض:

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## إزالة حماية الكتابة من عرض

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة المستخدمة على ملف عرض. بهذه الطريقة، يمكن للمستخدمين التعديل كما يرغبون - ولن يحصلوا على تحذيرات عندما يقومون بمثل هذه المهام.

يمكنك إزالة حماية الكتابة من عرض باستخدام طريقة [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection). هذا الرمز المثال يوضح لك كيفية إزالة حماية الكتابة من عرض:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## الحصول على خصائص عرض مشفر

عادةً ما يكافح المستخدمون للحصول على خصائص المستند لعرض مشفر أو محمي بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تتيح لك حماية كلمة مرور عرض مع الاحتفاظ بالوسائل التي تسمح للمستخدمين بالوصول إلى خصائص هذا العرض.

**ملاحظة** أنه عند تشفير Aspose.Slides عرضًا، يتم حماية خصائص مستند العرض بكلمة مرور أيضًا بشكل افتراضي. لكن إذا كنت بحاجة إلى جعل خصائص العرض متاحة (حتى بعد أن يتم تشفير العرض)، يتيح لك Aspose.Slides القيام بذلك بالضبط.

إذا كنت تريد أن يحتفظ المستخدمون بالقدرة على الوصول إلى خصائص العرض الذي قمت بتشفيره، يمكنك تعيين خاصية [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) إلى `true`. هذا الرمز المثال يوضح لك كيفية تشفير عرض أثناء توفير الوسائل للمستخدمين للوصول إلى خصائص المستند:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **التحقق مما إذا كان عرض محمي بكلمة مرور قبل تحميله**

قبل تحميل عرض، قد ترغب في التحقق من التأكد من أن العرض لم يتم حمايته بكلمة مرور. بهذه الطريقة، يمكنك تجنب الأخطاء والمشاكل المماثلة، التي تظهر عند تحميل عرض محمي بكلمة مرور بدون كلمة مروره.

يوضح هذا الرمز C# لك كيفية فحص عرض لمعرفة ما إذا كان محميًا بكلمة مرور (بدون تحميل العرض نفسه):

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("العرض محمي بكلمة مرور: " + presentationInfo.IsPasswordProtected);
```

## التحقق مما إذا كان عرض مشفرًا

يتيح لك Aspose.Slides التحقق مما إذا كان عرض مشفرًا. لأداء هذه المهمة، يمكنك استخدام خاصية [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) التي تعود `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن العرض مشفرًا.

هذا الرمز المثال يوضح لك كيفية التحقق مما إذا كان عرض مشفرًا:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## التحقق مما إذا كان عرض محميًا بحماية الكتابة

يتيح لك Aspose.Slides التحقق مما إذا كان عرض محميًا بحماية الكتابة. لأداء هذه المهمة، يمكنك استخدام خاصية [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) التي تعود `true` إذا كان العرض محميًا بحماية الكتابة أو `false` إذا لم يكن العرض مشفرًا.

هذا الرمز المثال يوضح لك كيفية التحقق مما إذا كان عرض محميًا بحماية الكتابة:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **التحقق أو التأكد من أن كلمة مرور معينة قد تم استخدامها لحماية عرض**

قد ترغب في التحقق والتأكد من أن كلمة مرور معينة قد تم استخدامها لحماية مستند عرض. يوفر Aspose.Slides الوسائل لك للتحقق من كلمة مرور.

هذا الرمز المثال يوضح لك كيفية التحقق من كلمة مرور:

```c#
using (IPresentation pres = new Presentation("pres.pptx"))
{
    // تحقق مما إذا كانت "pass" مطابقة بـ
    bool isWriteProtected = pres.ProtectionManager.CheckWriteProtection("my_password");
}
```

ترجع `true` إذا كان العرض مشفرًا باستخدام كلمة المرور المحددة. بخلاف ذلك، ترجع `false`.

{{% alert color="primary" title="انظر أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}