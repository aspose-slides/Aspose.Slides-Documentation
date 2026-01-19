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
description: "قم بتكوين Aspose.Slides لـ .NET 6 لإنشاء وتعديل وتحويل عروض PowerPoint بصيغة PPT و PPTX و ODP في تطبيقات C# الحديثة متعددة المنصات."
---

## **المقدمة**

بدءًا من [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)، تم تنفيذ الدعم لـ .NET6. خصوصية هذا الدعم هي أن .NET6 لم يعد يدعم System.Drawing.Common على Linux ([تغيير كاسر](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) وتقوم Slides بتنفيذ هذا النظام الفرعي الرسومي نفسها كمكوّن C++.

Aspose.Slides لـ .NET يعمل الآن دون الاعتماد على GDI/libgdiplus على:
* Windows
* Linux

_دعم MacOS_ جارٍ.

## **استخدام Slides لـ .NET 6 على AWS و Azure**

.NET6 هو الإصدار المفضَّل لـ Aspose.Slides المستخدم في السحابة (AWS أو Azure أو أي حلول سحابية أخرى).

في السابق، عند استخدام Aspose.Slides على مضيف Linux، كان يتعين تثبيت تبعيات إضافية (libgdiplus) وكان ذلك غالبًا غير مريح أو غير عملي (على سبيل المثال عند استخدام [AWS Lambda](https://aws.amazon.com/lambda)). مع Slides لـ .NET6، لم تعد هذه التبعيات مطلوبة، لذا يصبح النشر أسهل كثيرًا.

اعتبار آخر هو المشكلات التي حدثت عندما تم استخدام Aspose.Slides على حل سحابي بمضيف Windows. على سبيل المثال، [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) لديها قيود على العملية وتؤدي إلى مشكلات أثناء عملية تصدير PDF (انظر [this](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). استخدام Aspose.Slides لـ .NET6 يحل هذه المشكلة.

## **استخدام حزمة System.Drawing.Common وفئات Slides لـ .NET 6 (CS0433: الخطأ "النوع موجود في كل من Slides و System.Drawing.Common")**

أحيانًا يتعين استخدام كل من تبعيات System.Drawing و Slides لـ .NET6 في مشروع (على سبيل المثال عندما يعتمد مشروع .NET6 على حزم أخرى، والتي بدورها تعتمد على System.Drawing). قد يتسبب ذلك في أخطاء تعقيد مثل هذه:

* CS0433: النوع 'Image' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0
* CS0433: النوع 'Graphics' موجود في كل من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0

في هذه الحالة، يمكنك استخدام [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) لـ Aspose.Slides (الإصدار أقل من 24.8):
1) حدد تجميع Aspose.Slides من تبعيات المشروع ثم انقر **Properties**.  
   ![خصائص حزمة Aspose Slides](package_properties.png)
2) عيّن اسمًا مستعارًا (على سبيل المثال، "Slides").  
   ![الاسم المستعار لـ Aspose Slides](set_alias.png)

الآن، سيتم استخدام الأنواع من System.Drawing.Common بشكل افتراضي. يجب تحديد الاسم المستعار للتجميع الخارجي حيثما تحتاج إلى أنواع Aspose.Slides.
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


بدءًا من الإصدار 24.8، تمت إزالة واجهة برمجة التطبيقات العامة المتقادمة التي تعتمد على System.Drawing. بالنسبة لمثال الشيفرة أعلاه، يمكنك الحصول على صورة الشريحة كما هو موضح أدناه.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

الواجهة البرمجية الجديدة موصوفة بمزيد من التفصيل في [Modern API](/slides/ar/net/modern-api/).