---
title: دعم .NET6
type: docs
weight: 235
url: /ar/net/net6/
keywords: 
- .NET 6
- السحابة
- AWS
- Azure
description: "دعم .NET6"
---

## مقدمة

ابتداءً من [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)، تم تطبيق دعم .NET6. والخصوصية في هذا الدعم هي أن .NET6 لم تعد تدعم System.Drawing.Common لـ Linux ([تغيير كبير](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) وSlides تنفذ هذا النظام الرسومي بنفسها كجزء من C++.

يعمل Aspose.Slides لـ .NET الآن بدون اعتمادات على GDI/libgdiplus على:
* ويندوز
* لينوكس

دعم _ماك أو إس_ جارٍ.

## استخدام Slides لـ .NET6 على AWS وAzure

تُعتبر .NET6 الإصدار المفضل لـ Aspose.Slides المستخدمة على السحابة (AWS، Azure، أو حلول سحابية أخرى).

في السابق، عند استخدام Aspose.Slides على مضيف لينوكس، كان يجب تثبيت اعتمادات إضافية (libgdiplus) وكثيرًا ما كان ذلك غير مناسب أو عملي (على سبيل المثال، عند استخدام [AWS Lambda](https://aws.amazon.com/lambda)). مع Slides لـ .NET6، لم تعد تلك الاعتمادات مطلوبة، لذا فإن النشر أسهل بكثير.

اعتبار آخر هو المشاكل التي حدثت عند استخدام Aspose.Slides على حل سحابي مع مضيف ويندوز. على سبيل المثال، [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) لديها قيود على العملية مما يؤدي إلى مشاكل أثناء عملية تصدير PDF (راجع [هذا](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). استخدام Aspose.Slides لـ .NET6 يحل هذه المشكلة.

## استخدام حزمة System.Drawing.Common وفصول Slides لـ .NET6 (CS0433: النوع موجود في كل من Slides وSystem.Drawing.Common)

في بعض الأحيان، يجب استخدام كل من System.Drawing وSlides لـ .NET6 كاعتمادات في مشروع (على سبيل المثال، عندما يعتمد مشروع .NET6 على حزم أخرى، والتي بدورها تعتمد على System.Drawing). قد يؤدي ذلك إلى حدوث أخطاء تعقيد مثل هذه:

* CS0433: النوع 'Image' موجود في كل من 'Aspose.Slides، Version=23.2.0.0، Culture=neutral، PublicKeyToken=716fcc553a201e56' و'System.Drawing.Common، Version=6.0.0.0
* CS0433: النوع 'Graphics' موجود في كل من 'Aspose.Slides، Version=23.2.0.0، Culture=neutral، PublicKeyToken=716fcc553a201e56' و'System.Drawing.Common، Version=6.0.0.0

في هذه الحالة، يمكنك استخدام [external alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) لـ Aspose.Slides (الإصدار أقل من 24.8):
1) حدد تجميع Aspose.Slides من اعتمادات المشروع ثم انقر فوق **الخصائص**.
  ![خصائص حزمة Aspose Slides](package_properties.png)
2) قم بتعيين اسم مستعار (على سبيل المثال، "Slides").
  ![اسم مستعار لـ Aspose Slides](set_alias.png)

الآن، سيتم استخدام الأنواع من System.Drawing.Common افتراضيًا. يجب تحديد اسم مستعار للتجميع الخارجي حيثما احتجت إلى أنماط Aspose.Slides.

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

ابتداءً من الإصدار 24.8، تمت إزالة واجهة برمجة التطبيقات العامة التي تم إهمالها والتي تحتوي على اعتمادات على System.Drawing. بالنسبة لمثال الشيفرة أعلاه، يمكنك الحصول على صورة الشريحة كما يلي.

```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```
موضحة بمزيد من التفصيل في [واجهة برمجة التطبيقات الحديثة](/net/modern-api/).