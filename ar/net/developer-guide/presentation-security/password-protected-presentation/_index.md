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
- التحقق من كلمة مرور العرض التقديمي
- فحص كلمة مرور العرض التقديمي
- فتح عرض تقديمي مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير العروض التقديمية المحمية بكلمة مرور لملفات PowerPoint PPT و PPTX باستخدام C# مع Aspose.Slides لـ .NET."
---
## **نظرة عامة**

كلمة مرور الفتح تقوم بتشفير العرض التقديمي. يلزم تقديم كلمة المرور الصحيحة لتحميل وعرض محتوى العرض التقديمي، وبالتالي توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تشفر المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/net/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا التنسيقين حيث يكون سلوكهما القائم على الملفات أو التيار مهمًا.

## **تشفير عرض تقديمي باستخدام كلمة مرور الفتح**

استخدم [IProtectionManager.Encrypt](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/encrypt/) لتعيين كلمة مرور الفتح. ثم استخدم [IPresentation.Save](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/save/) لحفظ العرض المشفر.

المثال التالي يشفر عرض PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **تحميل عرض تقديمي مشفر**

قم بتعيين [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة لكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// العمل مع العرض التقديمي المفكك التشفير.
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض التقديمي باستخدام كلمة مرور الفتح، استدعِ [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/removeencryption/)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **التحقق من كلمة مرور الفتح قبل التحميل**

استخدم [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationfactory/getpresentationinfo/) للحصول على [IPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/) دون إنشاء نسخة كاملة من العرض التقديمي. تحقق من [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/ispasswordprotected/) قبل طلب أو التحقق من كلمة المرور. عندما تكون الحماية موجودة، تحقق من القيمة التي تم التحقق منها باستخدام [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkpassword/).

### **سير عمل عبر مسار الملف**

المثال التالي يتحقق من كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/)، ثم يحمل العرض التقديمي بالكامل:

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

### **سير عمل عبر التيار**

الإصدار المتعدد للتيار من [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationfactory/getpresentationinfo/) يوفر نفس سير العمل. أعد ضبط موضع التيار القابل للبحث قبل تحميل العرض التقديمي الكامل من ذلك التيار.

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

### **قيم الإرجاع لـ CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkpassword/) يرجع `true` فقط عندما يحتوي العرض التقديمي على كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. يرجع `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض التقديمي لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمل مشفرًا**

بعد تحميل عرض تقديمي باستخدام كلمة المرور الصحيحة، افحص [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/isencrypted/) للتحقق من أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم `IPresentationInfo.IsPasswordProtected` كما هو موضح أعلاه.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **توصيات الأمان**

{{% alert color="warning" title="Security" %}}
لا تقم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط طالما كان ذلك ضروريًا، وأعد استخدام نتيجة التحقق الناجحة عند تحميل العرض التقديمي مباشرة.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو حمّل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض.
1. اختياريًا أدخل كلمة مرور منفصلة لحماية التعديل.
1. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ar/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة المتكررة**

**ما هو الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تقوم بتشفير العرض التقديمي وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض التقديمي، وتحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وقم بالتحقق من كلمة المرور قبل إنشاء نسخة كاملة من العرض التقديمي.

**هل تدعم سير عمل التحقق من كلمة المرور كل من PPT و PPTX؟**

نعم. اكتشاف كلمة مرور الفتح والتحقق منها عبر مسار الملف أو التيار يعملان بنفس الطريقة لكل من عروض PPT و PPTX.