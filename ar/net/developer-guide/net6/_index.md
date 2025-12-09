---
title: دعم .NET 6
type: docs
weight: 235
url: /ar/net/net6/
keywords:
- دعم .NET 6
- حل سحابي
- AWS Lambda
- Azure Functions
- System.Drawing.Common
- GDI
- libgdiplus
- CS0433
- .NET
- C#
- Aspose.Slides
description: "تكوين Aspose.Slides لـ .NET 6 لإنشاء وتحرير وتحويل عروض PowerPoint PPT و PPTX و ODP في تطبيقات C# عصرية وعبر المنصات."
---

## المقدمة

بدءًا من [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)، تم تنفيذ الدعم لـ .NET6. خصوصية هذا الدعم هي أن .NET6 لم يعد يدعم System.Drawing.Common على Linux ([تغيير ملحوظ](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) وتقوم Slides بتنفيذ هذا النظام الفرعي الرسومي نفسها كمكوّن C++.

Aspose.Slides لـ .NET الآن يعمل دون الاعتماد على GDI/libgdiplus على:
* Windows
* Linux

_MacOS_ الدعم قيد التقدم.

## استخدام Slides لـ .NET6 على AWS و Azure

.NET6 هو الإصدار المفضّل لـ Aspose.Slides عند الاستخدام في السحابة (AWS أو Azure أو حلول سحابية أخرى).

في السابق، عندما كان يتم استخدام Aspose.Slides على مضيف Linux، كان يلزم تثبيت تبعيات إضافية (libgdiplus) وكان ذلك غالبًا غير ملائم أو غير عملي (مثلاً عند استخدام [AWS Lambda](https://aws.amazon.com/lambda)). مع Slides لـ .NET6، لم تعد هذه التبعيات ضرورية، وبالتالي يصبح النشر أسهل بكثير.

اعتبار آخر هو المشكلات التي تحدث عندما يُستخدم Aspose.Slides على حل سحابي مع مضيف Windows. على سبيل المثال، لدى [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) قيود على العملية وتؤدي إلى مشكلات أثناء عملية تصدير PDF (انظر [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). استخدام Aspose.Slides لـ .NET6 يحل هذه المشكلة.

## استخدام حزمة System.Drawing.Common وفئات Slides لـ .NET6 (خطأ CS0433: النوع موجود في كل من Slides و System.Drawing.Common)

أحيانًا يحتاج المشروع إلى استخدام كل من تبعيات System.Drawing و Slides لـ .NET6 معًا (مثلاً عندما يعتمد مشروع .NET6 على حزم أخرى تعتمد بدورها على System.Drawing). قد يؤدي ذلك إلى أخطاء تعقيد مثل ما يلي:

* CS0433: النوع 'Image' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: النوع 'Graphics' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0'

في هذه الحالة، يمكنك استخدام [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) لـ Aspose.Slides (إصدار أقل من 24.8):
1) حدد تجميع Aspose.Slides من تبعيات المشروع ثم اضغط **Properties**.  
  ![Aspose Slides package properties](package_properties.png)
2) عيّن اسمًا مستعارًا (على سبيل المثال، "Slides").  
  ![Aspose Slides alias](set_alias.png)

الآن، سيتم استخدام الأنواع من System.Drawing.Common بشكل افتراضي. يجب تحديد اسم التجميع الخارجي حيثما يلزم استخدام أنواع Aspose.Slides.
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


بدءًا من الإصدار 24.8، تم إزالة API العام المهمل الذي يعتمد على System.Drawing. بخصوص مثال الشيفرة أعلاه، يمكنك الحصول على صورة الشريحة كما هو موضح أدناه.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

تم توضيح الـ API الجديد بمزيد من التفصيل في [Modern API](/net/modern-api/).