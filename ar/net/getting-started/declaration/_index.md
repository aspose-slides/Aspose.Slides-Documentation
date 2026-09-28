---
title: متطلبات مستوى الثقة
type: docs
weight: 190
url: /ar/net/declaration/
keywords:
- مستوى الثقة
- إذن الثقة الكاملة
- الثقة الجزئية
- الثقة المتوسطة
- أمان الوصول إلى الشفرة
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "مستوى الثقة المطلوب لأمان الوصول إلى الشفرة الذي يحتاجه Aspose.Slides for .NET: ثقة كاملة على .NET Framework، ولا إعداد ثقة على .NET 6 وما بعده."
---
## **نظرة عامة**

مستويات الثقة في أمان الوصول إلى الشفرة (CAS) موجودة فقط في إطار .NET. توضح هذه المقالة ما تعنيه بالنسبة إلى Aspose.Slides for .NET: المكتبة تحتاج إلى ثقة كاملة على .NET Framework، وعلى .NET 6 وما بعده لا توجد مستوى ثقة لتكوينه.

## **إطار .NET**

يتطلب Aspose.Slides ثقة كاملة على .NET Framework. لا يعمل تحت الثقة الجزئية، مثل تطبيق ASP.NET المُكوَّن للثقة المتوسطة (`<trust level="Medium" />`): فشل إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) مع استثناء `SecurityException`.

لم تعد مايكروسوفت تعتبر الثقة الجزئية في ASP.NET كطريقة لعزل التطبيقات عن بعضها، وتوصي بتشغيل التطبيقات في مجموعات تطبيقات منفصلة بدلاً من ذلك. راجع [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation).

## **.NET 6 وما بعده**

أمان الوصول إلى الشفرة غير متوفر على .NET 6 وما بعده، لذا لا توجد مستوى ثقة لمنحه. يعمل Aspose.Slides بأذونات الحساب الذي يشغّل تطبيقك. لتقييد ما يمكن للتطبيق الوصول إليه، توصي مايكروسوفت بحدود نظام التشغيل، مثل حسابات المستخدمين أو الحاويات أو الأجهزة الافتراضية. راجع [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas).

## **الأسئلة الشائعة**

**هل يمكنني استخدام Aspose.Slides مع مزود استضافة يشغّل تطبيقات ASP.NET في الثقة المتوسطة؟**

ليس في الثقة المتوسطة. على .NET Framework، يجب أن يعمل التطبيق الذي يستخدم Aspose.Slides بثقة كاملة.