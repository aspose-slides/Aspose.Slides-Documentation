---
title: "تأمين العروض التقديمية بكلمات مرور في .NET"
linktitle: "حماية كلمة المرور"
type: docs
weight: 20
url: /ar/net/password-protected-presentation/
keywords:
- "قفل PowerPoint"
- "قفل العرض التقديمي"
- "فتح قفل PowerPoint"
- "إلغاء قفل العرض التقديمي"
- "حماية PowerPoint"
- "حماية العرض التقديمي"
- "تعيين كلمة مرور"
- "إضافة كلمة مرور"
- "تشفير PowerPoint"
- "تشفير العرض التقديمي"
- "فك تشفير PowerPoint"
- "فك تشفير العرض التقديمي"
- "حماية الكتابة"
- "أمان PowerPoint"
- "أمان العرض التقديمي"
- "إزالة كلمة المرور"
- "إزالة الحماية"
- "إزالة التشفير"
- "تعطيل كلمة المرور"
- "تعطيل الحماية"
- "إزالة حماية الكتابة"
- "PowerPoint"
- "OpenDocument"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تعلم كيفية قفل وفك قفل عروض PowerPoint وOpenDocument المحمية بكلمات مرور بسهولة باستخدام Aspose.Slides لـ .NET. أمن عروضك التقديمية."
---
## **المقدمة**

عندما تقوم بحماية عرض تقديمي بكلمة مرور، فهذا يعني أنك تحدد كلمة مرور تفرض قيودًا معينة على العرض التقديمي. لإزالة هذه القيود، يجب إدخال كلمة المرور. يُعتبر العرض التقديمي المحمي بكلمة مرور عرضًا مقفلًا.

عادةً، يمكنك تحديد كلمة مرور لفرض هذه القيود على العرض التقديمي:

- **تعديل**

إذا كنت تريد أن يتمكن بعض المستخدمين فقط من تعديل عرضك التقديمي، يمكنك تعيين قيد تعديل. يمنع هذا القيد الأشخاص من تعديل أو تغيير أو نسخ العناصر في عرضك التقديمي ما لم يقدموا كلمة المرور. ومع ذلك، حتى بدون كلمة المرور، سيظل بإمكان المستخدم الوصول إلى مستندك وفتحه. في وضع القراءة فقط، يمكن للمستخدم مشاهدة المحتوى—بما في ذلك الروابط التشعبية والرسوم المتحركة والتأثيرات والعناصر الأخرى—داخل عرضك التقديمي، لكنه لا يستطيع نسخ العناصر أو حفظ العرض التقديمي.

- **فتح**

إذا رغبت في أن يتمكن بعض المستخدمين فقط من فتح عرضك التقديمي، يمكنك تعيين قيد فتح. يمنع هذا القيد الأشخاص من حتى مشاهدة محتوى عرضك التقديمي ما لم يقدموا كلمة المرور. تقنيًا، يمنع قيد الفتح أيضًا المستخدمين من تعديل عروضك التقديمية—إذا لم يتمكن الأشخاص من فتح العرض، فلا يمكنهم تعديله أو إجراء تغييرات عليه.

**ملاحظة:** عندما تحمي عرضًا تقديميًا بكلمة مرور لمنع الفتح، يصبح ملف العرض مشفرًا.

## **حماية كلمة المرور في Aspose.Slides**

**الصيغ المدعومة**

يدعم Aspose.Slides حماية كلمة المرور، التشفير، والعمليات المشابهة للعروض التقديمية بهذه الصيغ:

- PPTX و PPT – عروض مايكروسوفت باوربوينت
- ODP – عروض OpenDocument
- OTP – قوالب عروض OpenDocument

**العمليات المدعومة**

يتيح لك Aspose.Slides استخدام حماية كلمة المرور على العروض التقديمية لمنع التعديلات بالطرق التالية:

- تشفير عرض تقديمي
- تعيين حماية كتابة على عرض تقديمي

**عمليات أخرى**

يتيح لك Aspose.Slides تنفيذ مهام إضافية تتعلق بحماية كلمة المرور والتشفير بالطرق التالية:

- فك تشفير عرض تقديمي؛ فتح عرض مشفر
- إزالة التشفير؛ تعطيل حماية كلمة المرور
- إزالة حماية الكتابة من عرض تقديمي
- استرجاع خصائص عرض مشفر
- التحقق مما إذا كان العرض محميًا بكلمة مرور قبل تحميله
- التحقق مما إذا كان العرض مشفرًا
- التحقق مما إذا كان العرض محميًا بكلمة مرور

## **حماية عرض تقديمي بكلمة مرور**

يمكنك تشفير عرض تقديمي عن طريق تعيين كلمة مرور. ثم، لتعديل العرض المقفل، يجب على المستخدم تقديم كلمة المرور.

لتشفير (أو حماية كلمة مرور) عرض تقديمي، استخدم الطريقة `Encrypt` من [ProtectionManager](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager) لتعيين كلمة مرور. مرّر كلمة المرور إلى الطريقة `Encrypt`، ثم استخدم الطريقة `Save` لحفظ العرض المشفر الآن.

يعرض لك هذا المثال البرمجي كيفية تشفير عرض تقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **تعيين حماية كتابة على عرض تقديمي** 

يمكنك إضافة علامة تقول "لا تعدل" إلى عرض تقديمي. هذا يُعلم المستخدمين بأنك لا تريدهم تعديل العرض.

**ملاحظة:** عملية حماية الكتابة لا تشفر العرض التقديمي. لذلك، يمكن للمستخدمين—إذا اختاروا—تعديل العرض، لكن لحفظ التغييرات، سيتعين عليهم حفظه تحت اسم مختلف.

لتعيين حماية الكتابة، استخدم الطريقة `SetWriteProtection`. يعرض لك هذا المثال البرمجي كيفية تعيين حماية الكتابة على عرض تقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **تحميل عرض مشفر**

يتيح لك Aspose.Slides تحميل عرض مشفر عن طريق تمرير كلمة المرور الصحيحة. يعرض لك هذا المثال البرمجي كيفية تحميل عرض مشفر:

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // العمل مع العرض التقديمي المفكوك.
}
```

## **إزالة التشفير من عرض تقديمي**

يمكنك إزالة التشفير أو حماية كلمة المرور من عرض تقديمي، مما يسمح للمستخدمين بالوصول إليه أو تعديله دون قيود.

لإزالة التشفير أو حماية كلمة المرور، استدعِ الطريقة [RemoveEncryption](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/methods/removeencryption). يعرض لك هذا المثال البرمجي كيفية إزالة التشفير من عرض تقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **إزالة حماية الكتابة من عرض تقديمي**

يمكنك استخدام Aspose.Slides لإزالة حماية الكتابة من ملف عرض تقديمي. بهذه الطريقة، يمكن للمستخدمين تعديله كما يشاءون—ولن يتلقوا أي تحذيرات عند تنفيذ هذه المهام.

يمكنك إزالة حماية الكتابة باستخدام الطريقة [RemoveWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/methods/removewriteprotection). يعرض لك هذا المثال البرمجي كيفية إزالة حماية الكتابة من عرض تقديمي:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **الحصول على خصائص عرض مشفر**

عادةً، يواجه المستخدمون صعوبة في استرجاع خصائص المستند لعرض مشفر أو محمي بكلمة مرور. ومع ذلك، يوفر Aspose.Slides آلية تتيح لك حماية عرض تقديمي بكلمة مرور مع الاحتفاظ بإمكانية وصول المستخدمين إلى خصائصه.

**ملاحظة:** بشكل افتراضي، عندما يقوم Aspose.Slides بتشفير عرض تقديمي، تكون خصائص مستند العرض محمية أيضًا بكلمة مرور. إذا كنت بحاجة إلى جعل خصائص المستند قابلة للوصول حتى بعد التشفير، يتيح لك Aspose.Slides القيام بذلك بدقة.

إذا أردت أن يحتفظ المستخدمون بإمكانية الوصول إلى خصائص عرض مشفر، عيّن خاصية `EncryptDocumentProperties` في [IProtectionManager](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/) إلى `false`. يعرض لك هذا المثال البرمجي كيفية تشفير عرض تقديمي مع الاستمرار في تمكين وصول المستخدمين إلى خصائص المستند الخاصة به:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **تحميل خصائص المستند فقط من عرض مشفر**

للتفحص بيانات التعريف لعرض مشفر دون تحميل شرائحه أو محتواه الآخر، أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/) واضبط [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) على `true`. في هذا الوضع، يتجاهل Aspose.Slides كلمة المرور ويحمل فقط خصائص المستند التي يمكن الوصول إليها علنًا.

يعرض المثال البرمجي التالي كيفية قراءة خصائص المستند المدمجة والمخصصة عبر [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/documentproperties/):

```c#
using Aspose.Slides;

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

يعمل هذا التدفق فقط عندما تُترك خصائص المستند غير مشفرة (عامة) عند تشفير العرض. إذا كانت خصائص المستند مشفرة، فإن ضبط `OnlyLoadDocumentProperties` على `true` يسبب استثناءً لأن كلمة المرور تُتجاهل في هذا الوضع. للوصول إلى خصائص المستند المشفرة أو تحميل العرض الكامل، بما في ذلك شرائحه ومحتوياته الأخرى، قدّم القيمة الصحيحة لـ `Password` في [LoadOptions](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/).

## **التحقق مما إذا كان العرض محميًا بكلمة مرور**

قبل تحميل عرض تقديمي، قد ترغب في التحقق من أنه لم يُحمَ بحماية كلمة مرور. يساعدك ذلك على تجنب الأخطاء والمشكلات المماثلة التي تحدث عند تحميل عرض محمي بكلمة مرور دون كلمة المرور الصحيحة.

يعرض لك هذا الكود C# كيفية فحص عرض تقديمي لمعرفة ما إذا كان محميًا بكلمة مرور دون تحميله فعليًا:

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **التحقق مما إذا كان العرض مشفرًا**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض مشفرًا. لتنفيذ هذه المهمة، يمكنك استخدام الخاصية [IsEncrypted](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/properties/isencrypted) التي تُعيد `true` إذا كان العرض مشفرًا أو `false` إذا لم يكن كذلك.

يعرض لك هذا المثال البرمجي كيفية التحقق مما إذا كان العرض مشفرًا:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

يتيح لك Aspose.Slides التحقق مما إذا كان العرض محميًا من الكتابة. لتنفيذ هذه المهمة، يمكنك استخدام الخاصية [IsWriteProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/protectionmanager/properties/iswriteprotected) التي تُعيد `true` إذا كان العرض محميًا من الكتابة أو `false` إذا لم يكن كذلك.

يعرض لك هذا المثال البرمجي كيفية التحقق مما إذا كان العرض محميًا من الكتابة:

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **التحقق من استخدام كلمة مرور العرض**

قد ترغب في التحقق والتأكد من أنه تم استخدام كلمة مرور معينة لحماية مستند العرض التقديمي. يوفر لك Aspose.Slides الوسيلة للتحقق من صحة كلمة المرور.

يعرض لك هذا المثال البرمجي كيفية التحقق من صحة كلمة مرور:

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // تحقق مما إذا كانت كلمة المرور مطابقة.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

يعيد `true` إذا تم تشفير العرض باستخدام كلمة المرور المحددة؛ وإلا يعيد `false`.

{{% alert color="info" title="انظر أيضًا" %}} 
- [التوقيع الرقمي في PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. انتقل إلى صفحة [**Aspose.Slides Lock**](https://products.aspose.app/slides/ar/lock) الخاصة بنا. 
2. انقر على **Drop or upload your files**.
3. اختر الملف الذي تريد حمايته بكلمة مرور على جهاز الكمبيوتر الخاص بك. 
4. أدخل كلمة المرور المفضلة لديك لحماية التحرير وكلمة المرور المفضلة لحماية العرض.
5. إذا أردت أن يرى المستخدمون عرضك التقديمي كنسخة نهائية، ضع علامة على خانة **Mark as final**.
6. انقر على **PROTECT NOW.** 
7. انقر على **DOWNLOAD NOW.**

![حماية عروض PowerPoint بكلمة مرور](slides-lock.png)

## **الأسئلة الشائعة**

**ما هي طرق التشفير التي يدعمها Aspose.Slides؟**

يدعم Aspose.Slides أساليب تشفير حديثة، بما في ذلك الخوارزميات القائمة على AES، ما يضمن مستوى عالٍ من أمان البيانات لعروضك التقديمية.

**ماذا يحدث إذا تم إدخال كلمة مرور غير صحيحة عند محاولة فتح عرض تقديمي؟**

يتم إلقاء استثناء إذا تم استخدام كلمة مرور غير صحيحة، مما يُنبهك بأن الوصول إلى العرض مرفوض. يساعد ذلك في منع الوصول غير المصرح به ويحمي محتوى العرض.

**هل هناك أي تأثيرات على الأداء عند العمل مع عروض محمية بكلمة مرور؟**

قد يضيف عملية التشفير وفك التشفير عبئًا بسيطًا أثناء عمليات الفتح والحفظ. في معظم الحالات، يكون هذا التأثير على الأداء ضئيلًا ولا يؤثر بشكل كبير على الوقت الكلي لمعالجة مهام العرض التقديمي.