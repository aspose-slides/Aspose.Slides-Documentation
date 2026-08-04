---
title: تأمين العروض التقديمية بكلمات مرور في .NET
linktitle: حماية كلمة المرور
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
- حماية كتابة
- أمان PowerPoint
- أمان العرض التقديمي
- إزالة كلمة المرور
- إزالة الحماية
- إزالة التشفير
- تعطيل كلمة المرور
- تعطيل الحماية
- إزالة حماية الكتابة
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية قفل وإلغاء قفل العروض التقديمية المحمية بكلمة مرور في PowerPoint وOpenDocument بسهولة باستخدام Aspose.Slides لـ .NET. أَمّن عروضك التقديمية."
---
## **المقدمة**

عند حماية عرض تقديمي بكلمة مرور، يعني ذلك أنك تقوم بتعيين كلمة مرور تُطبق قيودًا معينة على العرض التقديمي. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض التقديمي المحمي بكلمة مرور عرضًا مؤمنًا.

عادةً، يمكنك تعيين كلمة مرور لفرض هذه القيود على العرض التقديمي:

- **التعديل**

  إذا كنت تريد أن يقوم مستخدمون معينون فقط بتعديل عرضك التقديمي، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ العناصر في عرضك التقديمي ما لم يقدموا كلمة المرور.

  ومع ذلك، حتى بدون كلمة المرور، سيظل المستخدم قادرًا على الوصول إلى مستندك وفتحه. في وضع القراءة فقط، يمكن للمستخدم عرض المحتوى—بما في ذلك الروابط التشعبية، والرسوم المتحركة، والمؤثرات، والعناصر الأخرى—داخل عرضك التقديمي، لكنه لا يستطيع نسخ العناصر أو حفظ العرض.

- **الفتح**

  إذا كنت تريد أن يفتح عرضك التقديمي مستخدمون معينون فقط، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتويات عرضك التقديمي ما لم يقدموا كلمة المرور.

  من الناحية التقنية، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك التقديمية—إذا لم يتمكن الأشخاص من فتح عرض تقديمي، فلا يمكنهم تعديله أو إجراء تغييرات عليه.

**ملاحظة:** عندما تحمي عرض تقديمي بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **حماية كلمة المرور في Aspose.Slides**

**الصيغ المدعومة**

Aspose.Slides يدعم حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض التقديمية بهذه الصيغ:

- PPTX و PPT – عروض Microsoft PowerPoint
- ODP – عروض OpenDocument
- OTP – قوالب عروض OpenDocument

**العمليات المدعومة**

Aspose.Slides يتيح لك استخدام حماية كلمة المرور على العروض لمنع التعديلات بالطرق التالية:

- تشفير عرض تقديمي
- تعيين حماية كتابة على عرض تقديمي

**عمليات أخرى**

Aspose.Slides يتيح لك تنفيذ مهام إضافية تتعلق بحماية كلمة المرور والتشفير بالطرق التالية:

- فك تشفير عرض تقديمي؛ فتح عرض تقديمي مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض تقديمي
- استرجاع خصائص عرض تقديمي مشفر
- التحقق ما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله
- التحقق ما إذا كان العرض التقديمي مُشفّر
- التحقق ما إذا كان العرض التقديمي محميًا بكلمة مرور

## **حماية عرض تقديمي بكلمة مرور**

يمكنك تشفير عرض تقديمي بتعيين كلمة مرور. ثم، لتعديل العرض المؤمن، يجب على المستخدم تقديم كلمة المرور.

لتشفير (أو حماية كلمة مرور) عرض تقديمي، استخدم طريقة `Encrypt` من [ProtectionManager](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager) لتعيين كلمة مرور. مرّر كلمة المرور إلى طريقة `Encrypt`، ثم استخدم طريقة `Save` لحفظ العرض الآن المشفر.

هذا المثال البرمجي يوضح لك كيفية تشفير عرض تقديمي:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **تعيين حماية كتابة على عرض تقديمي** 

يمكنك إضافة علامة تقول "Do not modify" إلى عرض تقديمي. هذه العلامة تُبلغ المستخدمين بأنك لا تريدهم تعديل العرض.

**ملاحظة:** عملية حماية الكتابة لا تشفر العرض. لذلك، يمكن للمستخدمين—إذا اختاروا ذلك—تعديل العرض، ولكن لحفظ التغييرات سيحتاجون إلى حفظه باسم مختلف.

لتعيين حماية كتابة، استخدم طريقة `SetWriteProtection`. هذا المثال البرمجي يوضح لك كيفية تعيين حماية كتابة على عرض تقديمي:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **تحميل عرض تقديمي مشفر**

Aspose.Slides يتيح لك تحميل عرض تقديمي مشفر بتمرير كلمة المرور الصحيحة. هذا المثال البرمجي يوضح لك كيفية تحميل عرض تقديمي مشفر:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // العمل مع العرض التقديمي المفك تشفيره.
}
```

## **إزالة التشفير من عرض تقديمي**

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض تقديمي، مما يسمح للمستخدمين بالوصول إليه أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، استدعِ طريقة [RemoveEncryption](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/methods/removeencryption). هذا المثال البرمجي يوضح لك كيفية إزالة التشفير من عرض تقديمي:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **إزالة حماية الكتابة من عرض تقديمي**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة من ملف عرض تقديمي. بهذه الطريقة، يمكن للمستخدمين تعديل العرض كما يشاؤون—ولن يتلقوا أي تحذيرات عند أداء هذه المهام.

يمكنك إزالة حماية الكتابة باستخدام طريقة [RemoveWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/methods/removewriteprotection). هذا المثال البرمجي يوضح لك كيفية إزالة حماية الكتابة من عرض تقديمي:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **حصول على خصائص عرض تقديمي مشفر**

عادةً، يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعرض تقديمي مشفر أو محمي بكلمة مرور. ومع ذلك، توفر Aspose.Slides آلية تتيح لك حماية عرض تقديمي بكلمة مرور مع إبقاء إمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما تقوم Aspose.Slides بتشفير عرض تقديمي، تكون خصائص المستند للعرض أيضًا محمية بكلمة مرور. إذا احتجت إلى جعل خصائص المستند قابلة للوصول حتى بعد التشفير، فإن Aspose.Slides تسمح لك بذلك.

إذا أردت أن يحتفظ المستخدمون بإمكانية الوصول إلى خصائص عرض تقديمي مشفر، عيّن الخاصية `EncryptDocumentProperties` لكائن [IProtectionManager](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/) إلى `false`. هذا المثال البرمجي يوضح لك كيفية تشفير عرض تقديمي مع استمرار إتاحة وصول المستخدمين إلى خصائص مستنده:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **تحميل خصائص المستند فقط من عرض تقديمي مشفر**

لفحص البيانات الوصفية لعرض تقديمي مشفر دون تحميل شرائحه أو محتوياته الأخرى، أنشئ كائنًا من نوع [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/) واضبط [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) على `true`. في هذا الوضع، تتجاهل Aspose.Slides كلمة المرور وتحمّل فقط خصائص المستند المتاحة للجمهور.

المثال البرمجي التالي يقرأ خصائص المستند المدمجة والمخصصة عبر [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

يعمل هذا التدفق فقط عندما تُترك خصائص المستند غير مشفرة (عامة) عند تشفير العرض. إذا كانت خصائص المستند مشفرة، فإن ضبط `OnlyLoadDocumentProperties` على `true` يتسبب في استثناء لأن كلمة المرور تُهمل في هذا الوضع. للوصول إلى خصائص المستند المشفرة أو تحميل العرض الكامل بما في ذلك الشرائح والمحتويات الأخرى، قدّم القيمة الصحيحة لـ `Password` في [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/).

## **التحقق ما إذا كان العرض التقديمي محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق من أنه لم يُحمَ بكلمة مرور. يساعدك ذلك على تجنّب الأخطاء والمشكلات المشابهة التي تحدث عند تحميل عرض محمي بكلمة مرور دون كلمة المرور الصحيحة.

هذا الكود C# يوضح لك كيفية فحص عرض تقديمي لمعرفة ما إذا كان محميًا بكلمة مرور دون تحميله فعليًا:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **التحقق ما إذا كان العرض التقديمي مُشفّر**

Aspose.Slides يتيح لك التحقق مما إذا كان العرض التقديمي مشفرًا. للقيام بذلك، يمكنك استخدام الخاصية [IsEncrypted](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/properties/isencrypted)، التي تُعيد `true` إذا كان العرض مشفّرًا أو `false` إذا لم يكن كذلك.

هذا المثال البرمجي يوضح لك كيفية التحقق مما إذا كان العرض مشفرًا:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **التحقق ما إذا كان العرض التقديمي محميًا من الكتابة**

Aspose.Slides يتيح لك التحقق مما إذا كان العرض التقديمي محميًا من الكتابة. للقيام بذلك، يمكنك استخدام الخاصية [IsWriteProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/properties/iswriteprotected)، التي تُعيد `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

هذا المثال البرمجي يوضح لك كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **التحقق من استخدام كلمة مرور للعرض التقديمي**

قد ترغب في التحقق وتأكيد أن كلمة مرور معينة قد استُخدمت لحماية مستند عرض تقديمي. Aspose.Slides توفر لك الوسيلة للتحقق من كلمة المرور.

هذا المثال البرمجي يوضح لك كيفية التحقق من كلمة مرور:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // تحقق مما إذا كانت كلمة المرور مطابقة.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

إنه يُعيد `true` إذا كان العرض قد تم تشفيره باستخدام كلمة المرور المحددة؛ وإلا يُعيد `false`.

{{% alert color="primary" title="See also" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. انتقل إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/ar/lock) الخاصة بنا. 
1. انقر على **إسقاط أو تحميل ملفاتك**. 
1. اختر الملف الذي تريد حمايته بكلمة مرور على جهاز الكمبيوتر الخاص بك. 
1. أدخل كلمة المرور المفضلة لديك لحماية التحرير وكلمة المرور المفضلة لحماية العرض. 
1. إذا كنت تريد للمستخدمين رؤية عرضك كنسخة نهائية، علِّم خانة **Mark as final**. 
1. انقر على **PROTECT NOW.** 
1. انقر على **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **الأسئلة المتكررة**

**ما هي طرق التشفير التي يدعمها Aspose.Slides؟**

Aspose.Slides يدعم طرق تشفير حديثة، بما في ذلك الخوارزميات المستندة إلى AES، مما يضمن مستوى عالٍ من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح العرض التقديمي؟**

يتم إلقاء استثناء إذا استُخدمت كلمة مرور غير صحيحة، مما يُنبهك إلى أن الوصول إلى العرض مرفوض. يساعد ذلك في منع الوصول غير المصرح به ويحمي محتوى العرض.

**هل هناك أي تبعات على الأداء عند العمل مع عروض تقديمية محمية بكلمة مرور؟**

قد يضيف عملية التشفير وفك التشفير عبئًا طفيفًا أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون هذا التأثير على الأداء ضئيلًا ولا يؤثر بشكل كبير على الوقت الكلي لمعالجة مهام العرض التقديمي.