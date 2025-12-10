---
title: "دعم .NET 6"
type: docs
weight: 235
url: /ar/net/net6/
keywords:
- "دعم .NET 6"
- "حل سحابي"
- "AWS Lambda"
- "Azure Functions"
- "System.Drawing.Common"
- "GDI"
- "libgdiplus"
- "CS0433"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تكوين Aspose.Slides لـ .NET 6 لإنشاء وتحرير وتحويل عروض PowerPoint PPT و PPTX و ODP في تطبيقات C# الحديثة متعددة المنصات."
---

## **المقدمة**

بدءًا من [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)، تم تنفيذ الدعم لـ .NET6. ما يميز هذا الدعم هو أن .NET6 لم يعد يدعم System.Drawing.Common على Linux ([تغيير كاسح](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) وتقوم Slides بتنفيذ هذا النظام الرسومي بنفسها كمكون C++.

تعمل Aspose.Slides لـ .NET الآن بدون الاعتماد على GDI/libgdiplus على:
* Windows
* Linux

_دعم MacOS_ قيد التطوير.

## **استخدام Slides for .NET 6 على AWS و Azure**

يُعد .NET6 الإصدار المفضل لـ Aspose.Slides المستخدم على السحابة (AWS أو Azure أو حلول سحابية أخرى).

سابقًا، عندما تُستخدم Aspose.Slides على نظام تشغيل Linux، كان يلزم تثبيت تبعيات إضافية (libgdiplus) وكان ذلك غالبًا غير ملائم أو غير عملي (على سبيل المثال عند استخدام [AWS Lambda](https://aws.amazon.com/lambda)). مع Slides لـ .NET6، لم تعد هذه التبعيات مطلوبة، مما يجعل النشر أسهل كثيرًا.

اعتبار آخر هو المشكلات التي كانت تحدث عندما تُستخدم Aspose.Slides على حل سحابي يعمل بنظام Windows. على سبيل المثال، تمتلك [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) قيودًا على العملية وتؤدي إلى مشكلات أثناء عملية تصدير PDF (انظر [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). حل استخدام Aspose.Slides لـ .NET6 هذه المشكلة.

## **استخدام حزمة System.Drawing.Common وفئات Slides for .NET 6 (CS0433: الخطأ الذي يفيد بأن النوع موجود في كل من Slides و System.Drawing.Common)**

في بعض الأحيان، يجب استخدام كل من System.Drawing و Slides for .NET6 في مشروع (على سبيل المثال عندما يعتمد مشروع .NET6 على حزم أخرى تعتمد بدورها على System.Drawing). قد يتسبب ذلك في أخطاء تعقيد مثل:

* CS0433: النوع 'Image' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: النوع 'Graphics' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0'

في هذه الحالة، يمكنك استخدام [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) لـ Aspose.Slides (الإصدار الأقل من 24.8):
1) حدد تجميع Aspose.Slides من تبعيات المشروع ثم انقر على **Properties**.  
   ![خصائص حزمة Aspose Slides](package_properties.png)
2) قم بتعيين اسم مستعار (مثلاً، "Slides").  
   ![الاسم المستعار لـ Aspose Slides](set_alias.png)

الآن، سيتم استخدام الأنواع من System.Drawing.Common بشكل افتراضي. يجب تحديد الاسم المستعار للتجميع الخارجي حيثما تُحتاج أنواع Aspose.Slides.  
```c#
extern alias Slides;
using Slides::Asppe.Slides;
```


مثال كامل:  
```c#
extern alias Slides;
using Slides::Aspose.Slides;

static Slides::System.Drawing.Image GetThumbnail(Presentation pres)
{
    return pres.Slides[0].GetThumbnail();
}
```


بدءًا من الإصدار 24.8، تم إزالة واجهة برمجة التطبيقات العامة القديمة التي تعتمد على System.Drawing. فيما يتعلق بمثال الشيفرة أعلاه، يمكنك الحصول على صورة الشريحة كما يلي.  
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

يتم شرح الواجهة البرمجية الجديدة بمزيد من التفصيل في [Modern API](/net/modern-api/).