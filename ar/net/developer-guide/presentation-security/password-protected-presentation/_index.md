---
title: تأمين عروض PowerPoint بكلمات مرور باستخدام C#
linktitle: العرض المحمي بكلمة مرور
type: docs
weight: 20
url: /ar/net/password-protected-presentation/
keywords:
- قفل PowerPoint
- قفل العرض التقديمي
- إلغاء قفل PowerPoint
- إلغاء قفل العرض التقديمي
- حماية PowerPoint
- حماية العرض التقديمي
- تعيين كلمة مرور
- إضافة كلمة مرور
- تشفير PowerPoint
- تشفير العرض التقديمي
- فك تشفير PowerPoint
- فك تشفير العرض التقديمي
- حماية الكتابة
- أمان PowerPoint
- أمان العرض التقديمي
- إزالة كلمة المرور
- إزالة الحماية
- إزالة التشفير
- تعطيل كلمة المرور
- تعطيل الحماية
- إزالة حماية الكتابة
- عرض PowerPoint
- C#
- Aspose.Slides
description: "تعرّف على كيفية قفل وإلغاء قفل عروض PowerPoint وOpenDocument المحمية بكلمة مرور بسهولة باستخدام Aspose.Slides لـ .NET. زد من إنتاجيتك وآمن عروضك التقديمية من خلال دليلنا خطوة بخطوة."
---

## **نظرة عامة**

عند حماية عرض تقديمي بكلمة مرور، فإن ذلك يعني أنك تقوم بتعيين كلمة مرور تفرض قيودًا معينة على العرض التقديمي. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض التقديمي المحمي بكلمة مرور عرضًا مؤمنًا.

عادةً يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض التقديمي:

- **التعديل**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من تعديل العرض التقديمي، يمكنك تعيين قيد تعديل. هذا القيد يمنع الأشخاص من تعديل أو تغيير أو نسخ عناصر العرض التقديمي ما لم يقدموا كلمة المرور.

  ومع ذلك، حتى بدون كلمة المرور، سيظل بإمكان المستخدم الوصول إلى المستند وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتوى—بما في ذلك الروابط التشعبية، والرسوم المتحركة، والمؤثرات، والعناصر الأخرى—داخل العرض التقديمي، لكنه لا يستطيع نسخ العناصر أو حفظ العرض التقديمي.

- **الفتح**

  إذا كنت تريد أن يتمكن بعض المستخدمين فقط من فتح العرض التقديمي، يمكنك تعيين قيد فتح. هذا القيد يمنع الأشخاص من حتى مشاهدة محتوى العرض التقديمي ما لم يقدموا كلمة المرور.

  تقنيًا، يمنع قيد الفتح المستخدمين أيضًا من تعديل عروضك التقديمية—إذا لم يتمكن الأشخاص من فتح العرض، فلن يتمكنوا من تعديل أو إجراء تغييرات عليه.

**ملاحظة:** عندما تحمي العرض التقديمي كلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **حماية كلمة المرور في Aspose.Slides**

**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، والتشفير، والعمليات المشابهة للعروض التقديمية بالصيغ التالية:

- PPTX و PPT – عروض Microsoft PowerPoint
- ODP – عروض OpenDocument
- OTP – قوالب عروض OpenDocument

**العمليات المدعومة**

يسمح Aspose.Slides باستخدام حماية كلمة المرور على العروض التقديمية لمنع التعديلات بالطرق التالية:

- تشفير عرض تقديمي
- تعيين حماية كتابة على عرض تقديمي

**عمليات أخرى**

يسمح Aspose.Slides بأداء مهام إضافية تتعلق بحماية كلمة المرور والتشفير بالطرق التالية:

- فك تشفير عرض تقديمي؛ فتح عرض تقديمي مشفر
- إزالة التشفير؛ إلغاء حماية كلمة المرور
- إزالة حماية الكتابة من عرض تقديمي
- استرجاع خصائص عرض تقديمي مشفر
- التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور

## **حماية عرض تقديمي بكلمة مرور**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المؤمن، يجب على المستخدم توفير كلمة المرور.

لتشفير (أو حماية كلمة مرور) عرض تقديمي، استخدم طريقة `Encrypt` من [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) لتعيين كلمة مرور. مرّر كلمة المرور إلى طريقة `Encrypt`، ثم استخدم طريقة `Save` لحفظ العرض المشفر الآن.

يعرض هذا المثال البرمجي كيفية تشفير عرض تقديمي:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **تعيين حماية كتابة على عرض تقديمي** 

يمكنك إضافة علامة تقول "لا تقم بالتعديل" إلى عرض تقديمي. هذا يُعلم المستخدمين بأنك لا تريدهم إجراء تغييرات على العرض.

**ملاحظة:** عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين—إذا اختاروا ذلك—تعديل العرض، ولكن لحفظ التغييرات، سيتعين عليهم حفظه باسم مختلف.

لتعيين حماية كتابة، استخدم طريقة `SetWriteProtection`. يوضح هذا المثال البرمجي كيفية تعيين حماية كتابة على عرض تقديمي:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **تحميل عرض تقديمي مشفر**

يسمح Aspose.Slides بتحميل عرض تقديمي مشفر عن طريق تمرير كلمة المرور الصحيحة. يوضح هذا المثال البرمجي كيفية تحميل عرض تقديمي مشفر:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // العمل مع العرض التقديمي المفكوك.
}
```


## **إزالة التشفير من عرض تقديمي**

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض تقديمي، مما يسمح للمستخدمين بالوصول إليه أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، استدعِ طريقة [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption). يوضح هذا المثال البرمجي كيفية إزالة التشفير من عرض تقديمي:
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **إزالة حماية الكتابة من عرض تقديمي**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة من ملف عرض تقديمي. بهذه الطريقة، يمكن للمستخدمين تعديل العرض كما يشاؤون—ولا يتلقون أي تحذيرات عند تنفيذ هذه المهام.

يمكنك إزالة حماية الكتابة باستخدام طريقة [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection). يوضح هذا المثال البرمجي كيفية إزالة حماية الكتابة من عرض تقديمي:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **استرجاع خصائص عرض تقديمي مشفر**

عادةً ما يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعرض تقديمي مشفر أو محمي بكلمة مرور. ومع ذلك، يقدم Aspose.Slides آلية تسمح لك بحماية عرض تقديمي بكلمة مرور مع الإبقاء على إمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يشفر Aspose.Slides عرضًا تقديميًا، تكون خصائص مستند العرض محمية أيضًا بكلمة مرور. إذا كنت بحاجة لجعل خصائص المستند قابلة للوصول حتى بعد التشفير، يتيح لك Aspose.Slides فعل ذلك بدقة.

إذا كنت تريد أن يتمكن المستخدمون من الوصول إلى خصائص عرض تقديمي مشفر، يمكنك تعيين خاصية [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) إلى `true`. يوضح هذا المثال البرمجي كيفية تشفير عرض تقديمي مع الحفاظ على إمكانية وصول المستخدمين إلى خصائص المستند:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق من أنه لم يُحَمَّ بكلمة مرور. يساعدك ذلك على تجنّب الأخطاء والمشكلات المماثلة التي تحدث عند تحميل عرض محمي بكلمة مرور دون كلمة المرور الصحيحة.

يظهر هذا الكود C# كيفية فحص عرض تقديمي لمعرفة ما إذا كان محميًا بكلمة مرور دون تحميله فعليًا:
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **التحقق مما إذا كان العرض مشفرًا**

يسمح Aspose.Slides بالتحقق مما إذا كان العرض مشفرًا. للقيام بذلك، يمكنك استخدام خاصية [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) التي تُعيد `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن كذلك.

يظهر هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفرًا:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **التحقق مما إذا كان العرض محميًا من الكتابة**

يسمح Aspose.Slides بالتحقق مما إذا كان العرض محميًا من الكتابة. للقيام بذلك، يمكنك استخدام خاصية [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) التي تُعيد `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

يظهر هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **التحقق من استخدام كلمة مرور للعرض**

قد تريد التحقق والتأكيد من أن كلمة مرور معينة تم استخدامها لحماية مستند العرض. يوفر Aspose.Slides وسيلة للتحقق من صحة كلمة المرور.

يظهر هذا المثال البرمجي كيفية التحقق من كلمة مرور:
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // تحقق مما إذا كانت كلمة المرور مطابقة.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


يعيد `true` إذا كان العرض قد تم تشفيره باستخدام كلمة المرور المحددة؛ وإلا فإنه يعيد `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **حماية عرض تقديمي عبر الإنترنت بكلمة مرور**

1. انتقل إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) الخاصة بنا. 
1. انقر على **Drop or upload your files**. 
1. اختر الملف الذي تريد حمايته بكلمة مرور على جهازك. 
1. أدخل كلمة المرور المفضلة لديك لحماية التعديل وكلمة المرور المفضلة لحماية العرض. 
1. إذا كنت تريد أن يرى المستخدمون عرضك كنسخة نهائية، ضع علامة على خانة **Mark as final**. 
1. انقر على **PROTECT NOW.** 
1. انقر على **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **الأسئلة الشائعة**

**ما هي طرق التشفير التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides طرق تشفير حديثة، بما في ذلك الخوارزميات القائمة على AES، مما يضمن مستوى عالٍ من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إلقاء استثناء إذا تم استخدام كلمة مرور غير صحيحة، مما يُنبهك إلى أن الوصول إلى العرض مرفوض. يساعد ذلك في منع الوصول غير المصرح به وحماية محتوى العرض.

**هل هناك أي تأثيرات على الأداء عند العمل مع عروض تقديمية محمية بكلمة مرور؟**

قد يُدخل عملية التشفير وفك التشفير بعض الحمل الإضافي البسيط أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون هذا التأثير على الأداء ضئيلًا ولا يؤثر بشكل كبير على الوقت الإجمالي لمعالجة مهام العرض الخاصة بك.