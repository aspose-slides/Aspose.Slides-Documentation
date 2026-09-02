---
title: حماية الكتابة للعروض التقديمية في .NET
linktitle: حماية الكتابة
type: docs
weight: 25
url: /ar/net/write-protected-presentation/
keywords:
- حماية الكتابة
- حماية الكتابة لبرنامج PowerPoint
- كلمة مرور للتعديل
- تقييد تعديل العرض التقديمي
- إزالة حماية الكتابة
- التحقق من كلمة مرور التعديل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعيين، اكتشاف، التحقق من صحة وإزالة كلمات مرور حماية الكتابة في عروض PowerPoint PPT و PPTX باستخدام Aspose.Slides لـ .NET."
---
## **المقدمة**

كلمة مرور الحماية من الكتابة تقيد تعديل العرض التقديمي لكنها لا تشفر محتواه. يمكن للمستخدمين تحميل وعرض عرض تقديمي محمي من الكتابة دون كلمة المرور. اعتمادًا على التطبيق، قد يتمكنون أيضًا من تعديل المحتوى وحفظه باسم مختلف، لذا لا ينبغي اعتبار الحماية من الكتابة آلية سرية.

كلمة مرور الفتح لها هدف مختلف: فهي تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. لتشفير عرض تقديمي أو للتحقق من كلمة مرور الفتح، راجع [Password-Protect Presentations](/slides/ar/net/password-protected-presentation/).

تنطبق سير العمل في هذه المقالة على عروض PPT و PPTX. تستخدم الأمثلة ملفات PPTX؛ عند الحفظ كـ PPT، استخدم الامتداد `.ppt` وتنسيق الحفظ المناسب لـ PPT.

## **تعيين حماية كتابة على عرض تقديمي**

استخدم [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/setwriteprotection/) لتعيين كلمة مرور لتعديل العرض التقديمي. سيحفظ حفظ العرض التقديمي إعداد الحماية.

المثال التالي يضبط حماية كتابة على عرض تقديمي PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **تحميل عرض تقديمي محمي من الكتابة**

نظرًا لأن الحماية من الكتابة لا تشفر محتوى العرض التقديمي، لا توجد كلمة مرور مطلوبة لتحميل العرض. تكون كلمة المرور ذات صلة فقط عند التحقق من التفويض لتعديل العرض المحمي.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

لا تقم بتمرير كلمة مرور الحماية من الكتابة إلى [LoadOptions.Password](https://reference.aspose.com/slides/ar/net/aspose.slides/loadoptions/password/). تلك الخاصية تقبل كلمة مرور الفتح للمحتوى المشفر. إذا كان للعرض التقديمي نوعا حماية كلاهما، زوّد كلمة مرور الفتح للتحميل وتعامل مع كلمة مرور الحماية من الكتابة بصورة منفصلة.

## **إزالة حماية الكتابة من عرض تقديمي**

استخدم [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/removewriteprotection/) لإزالة قيود التعديل، ثم احفظ العرض التقديمي.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **التحقق مما إذا كان العرض محميًا من الكتابة**

لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) كامل، استدعِ [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationfactory/getpresentationinfo/) وتفقد [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/iswriteprotected/). الخاصية تستخدم [NullableBool](https://reference.aspose.com/slides/ar/net/aspose.slides/nullablebool/) وتعيد `NullableBool.True` عندما تُكتشف حماية كتابة.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

الإصدار المتعلق بالتدفق من [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationfactory/getpresentationinfo/) يقدم نفس المعلومات لعرض تقديمي يُزوّد كتيار.

## **التحقق من كلمة مرور الحماية من الكتابة**

استخدم [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkwriteprotection/) للتحقق من كلمة مرور التعديل دون تحميل العرض الكامل. افحص [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/iswriteprotected/) أولاً حتى يطلب التطبيق أو يتحقق من كلمة المرور فقط عندما تكون الحماية من الكتابة موجودة.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkwriteprotection/) يتحقق فقط من كلمة مرور الحماية من الكتابة. لا يتحقق من كلمة مرور الفتح أو يحدد ما إذا كان يمكن تحميل محتوى مشفر. بالمقابل، [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationinfo/checkpassword/) يتحقق فقط من كلمة مرور الفتح. إذا كان عرض تقديمي كامل قد تم تحميله بالفعل، يوفر [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/ar/net/aspose.slides/iprotectionmanager/checkwriteprotection/) فحص الحماية من الكتابة المكافئ عبر مدير الحماية.

في التطبيقات الإنتاجية، لا تقم بتسجيل كلمات المرور أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط للمدة المطلوبة.

{{% alert color="info" title="انظر أيضًا" %}}
- [Password-Protect Presentations](/slides/ar/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/ar/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **التعليمات المتكررة**

**هل تشفر الحماية من الكتابة عرضًا تقديميًا؟**

لا. إنها تقيد التعديل ولكن تترك محتوى العرض متاحًا للتحميل والعرض.

**هل كلمة مرور الحماية من الكتابة مطلوبة لفتح عرض تقديمي؟**

لا. كلمة مرور الفتح فقط مطلوبة لتحميل محتوى عرض مشفر.

**هل يمكن أن يحتوي عرض تقديمي على كل من كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

نعم. زوّد كلمة مرور الفتح عبر خيارات التحميل لفتح العرض المشفر، وتحقق من كلمة مرور الحماية من الكتابة بشكل منفصل عند الحاجة إلى تفويض تعديل.