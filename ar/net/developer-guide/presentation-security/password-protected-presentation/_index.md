---
title: حماية العروض التقديمية بكلمة مرور في .NET
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/net/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق من صحة، فتح، وفك تشفير العروض التقديمية المحمية بكلمة مرور PowerPoint بصيغ PPT و PPTX في C# باستخدام Aspose.Slides للـ .NET."
---
## **نظرة عامة**

كلمة مرور الفتح تقوم بتشفير العرض التقديمي. يلزم إدخال كلمة المرور الصحيحة لتحميل محتوى العرض وعرضه، لذا يوفر هذا الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض. لإدارة كلمات المرور لتعديل العروض، انظر [Write-Protect Presentations](/slides/ar/net/write-protected-presentation/).

تطبق التدفقات الوظيفية أدناه على كلٍ من العروض PPT و PPTX. تستخدم الأمثلة كلا الصيغتين حيث يكون سلوك الملف أو التيار مهمًا.

## **تشفير عرض تقديمي بكلمة مرور فتح**

استخدم [IProtectionManager.Encrypt](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/encrypt/) لتعيين كلمة مرور الفتح. ثم استخدم [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) لحفظ العرض المشفر.

المثال التالي يشفر عرضًا تقديميًا من النوع PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **ترك خصائص المستند عامة**

بشكل افتراضي، يضيف Aspose.Slides خصائص المستند إلى تشفير العرض. يتحكم الخاصية [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) في هذا السلوك بشكل مستقل عن تشفير محتوى الشرائح. اضبطها إلى `false` قبل استدعاء [IProtectionManager.Encrypt](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/encrypt/) عندما تحتاج أن تقرأ نظام الفهرسة أو التصنيف أو البحث أو إدارة المستندات البيانات الوصفية دون كلمة مرور الفتح.

المثال التالي ينشئ عرضًا تقديميًا PPTX مشفرًا مع ترك خصائص المستند المدمجة عامة:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

ضبط `EncryptDocumentProperties` إلى `false` لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر من العرض عام. يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، انظر [Manage Presentation Properties](/slides/ar/net/presentation-properties/).

## **تحميل عرض تقديمي مشفر**

اضبط [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة ولكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// العمل مع العرض المفكوك.
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مرور الفتح، استدعِ [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/removeencryption/)، ثم احفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **التحقق من صحة كلمة مرور الفتح قبل التحميل**

استخدم [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationfactory/getpresentationinfo/) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/ispasswordprotected/) قبل طلب أو التحقق من كلمة المرور. عند وجود حماية، تحقق من القيمة المقدمة باستخدام [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkpassword/).

### **تدفق مسار الملف**

المثال التالي يتحقق من كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/)، ثم يحمل العرض الكامل:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **تدفق التيار**

الإصدار المتعلق بالتيار من [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationfactory/getpresentationinfo/) يوفر نفس سير العمل. أعد تعيين موضع التيار القابل للبحث قبل تحميل العرض الكامل من ذلك التيار.

المثال التالي يستخدم ملف PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **قيم إرجاع CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkpassword/) تُعيد `true` فقط عندما يكون للعرض كلمة مرور فتح وكلمة المرور المقدمة صحيحة. تُعيد `false` في كل الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمّل مشفرًا**

بعد تحميل عرض بكلمة مرور صحيحة، افحص [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/isencrypted/) لتأكيد أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `IPresentationInfo.IsPasswordProtected` كما هو موضح أعلاه.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **توصيات أمنية**

{{% alert color="warning" title="الأمان" %}}
لا تُسجل كلمات مرور الفتح ولا تُدرجها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط طالما احتجت إليها، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض فورًا.

قد تُظهر خصائص المستند العامة أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة رغم أن محتوى العرض مشفر. شفر البيانات الوصفية الحساسة مع العرض. يجب أن تكون ترك الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما يتوجب على الأنظمة فهرسة أو تصنيف أو البحث أو إدارة الملف دون كلمة مرور فتح.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض.
1. أدخل كلمة مرور لحماية العرض أثناء العرض.
1. اختياريًا أدخل كلمة مرور منفصلة لحماية التحرير.
1. طبّق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [Write-Protect Presentations](/slides/ar/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض التقديمي وتُطلب لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، تحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وتحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل يمكن للتطبيق قراءة البيانات الوصفية دون كلمة مرور الفتح؟**

نعم، ولكن فقط عندما يكون العرض مشفرًا مع ضبط `EncryptDocumentProperties` على `false`. يجب على التطبيق حينها استخدام وضع تحميل الخصائص فقط الموضح في [Manage Presentation Properties](/slides/ar/net/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كلًا من PPT و PPTX؟**

نعم. سلوك الكشف عن كلمة مرور الفتح والتحقق منها على أساس مسار الملف أو التيار هو نفسه للعرضين PPT و PPTX.