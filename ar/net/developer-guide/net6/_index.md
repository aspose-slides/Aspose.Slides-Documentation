---
title: الدعم لـ .NET 6
type: docs
weight: 235
url: /ar/net/net6/
keywords:
- الدعم لـ .NET 6
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
description: "قم بتكوين Aspose.Slides لـ .NET 6 لإنشاء وتحرير وتحويل عروض PowerPoint بصيغة PPT و PPTX و ODP في تطبيقات C# الحديثة متعددة المنصات."
---

## مقدمة

بدءًا من [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)، تم تنفيذ الدعم لـ .NET6. خصوصية هذا الدعم هي أن .NET6 لم يعد يدعم System.Drawing.Common لنظام Linux ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) و Slides ينفذ هذا النظام الفرعي الرسومي بنفسه كمكوّن C++.

Aspose.Slides لـ .NET الآن يعمل بدون الاعتماد على GDI/libgdiplus على:
* Windows
* Linux

_دعم MacOS قيد التنفيذ._

## استخدام Slides لـ .NET6 على AWS و Azure

.NET6 هو الإصدار المفضّل لـ Aspose.Slides المستخدم في السحابة (AWS، Azure، أو حلول سحابية أخرى).

سابقًا، عندما كان يتم استخدام Aspose.Slides على مضيف Linux، كان يجب تثبيت تبعيات إضافية (libgdiplus) وكان ذلك غالبًا غير مريح أو غير عملي (مثلاً، عند استخدام [AWS Lambda](https://aws.amazon.com/lambda)). مع Slides لـ .NET6، لم تعد هذه التبعيات مطلوبة، لذا يصبح النشر أسهل بكثير.

اعتبار آخر هو المشكلات التي حدثت عندما كان يتم استخدام Aspose.Slides على حل سحابي بمضيف Windows. على سبيل المثال، [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) لديها قيود على العملية وتؤدي إلى مشاكل أثناء عملية تصدير PDF (انظر [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). استخدام Aspose.Slides لـ .NET6 يحل هذه المشكلة.

## استخدام حزمة System.Drawing.Common وفئات Slides لـ .NET6 (خطأ CS0433: النوع موجود في كل من Slides و System.Drawing.Common)

أحيانًا، يجب استخدام كل من System.Drawing وتبعيات Slides لـ .NET6 في مشروع (مثلاً، عندما يعتمد مشروع .NET6 على حزم أخرى، والتي بدورها تعتمد على System.Drawing). قد يتسبب ذلك في أخطاء تعقيد مثل هذه:

* CS0433: النوع 'Image' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0'
* CS0433: النوع 'Graphics' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0'

في هذه الحالة، يمكنك استخدام [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) لـ Aspose.Slides (الإصدار الأقل من 24.8):
1) اختر تجميع Aspose.Slides من تبعيات المشروع ثم انقر على **Properties**.
  ![خصائص حزمة Aspose Slides](package_properties.png)
2) عيّن لقبًا (مثلاً، "Slides").
  ![لقب Aspose Slides](set_alias.png)

الآن، سيتم استخدام الأنواع من System.Drawing.Common افتراضيًا. يجب تحديد لقب التجميع الخارجي حيثما تحتاج إلى أنواع Aspose.Slides.
```c#
extern alias Slides;
using Slides::Aspose.Slides;
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


بدءًا من الإصدار 24.8، تم إزالة واجهة برمجة التطبيقات العامة المتقادمة التي تعتمد على System.Drawing. بخصوص مثال الشيفرة أعلاه، يمكنك الحصول على صورة الشريحة كما يلي.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

الواجهة الجديدة موصوفة بمزيد من التفصيل في [Modern API](/net/modern-api/).