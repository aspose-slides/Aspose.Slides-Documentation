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
description: "تكوين Aspose.Slides لـ .NET 6 لإنشاء وتحرير وتحويل عروض PowerPoint PPT و PPTX و ODP في تطبيقات C# عصرية متعددة المنصات."
---

## مقدمة

بدءًا من [Aspose.Slides 23.2](https://www.nuget.org/packages/Aspose.Slides.NET/23.2.0)، تم تنفيذ الدعم لـ .NET6. خاصية هذا الدعم هي أن .NET6 لم يعد يدعم System.Drawing.Common لنظام Linux ([تغيير كسرية](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)) وتقوم Slides بتنفيذ هذا النظام الفرعي الرسومي بنفسها كمكوّن C++.

أصبح Aspose.Slides for .NET يعمل الآن بدون الاعتماد على GDI/libgdiplus على:
* Windows
* Linux

الدعم لـ _MacOS_ قيد التقدم.

## استخدام Slides لـ .NET6 على AWS و Azure

الإصدار المفضَّل لـ Aspose.Slides المستخدم على السحابة هو .NET6 (AWS، Azure، أو حلول سحابية أخرى).

سابقًا، عندما تم استخدام Aspose.Slides على مضيف Linux، كان من الضروري تثبيت تبعيات إضافية (libgdiplus) وكان ذلك غالبًا غير مريح أو غير عملي (على سبيل المثال، عند استخدام [AWS Lambda](https://aws.amazon.com/lambda)). مع Slides لـ .NET6، لم تعد تلك التبعيات مطلوبة، وبالتالي يصبح النشر أسهل كثيرًا.

اعتبار آخر هو المشكلات التي تحدث عندما يُستخدم Aspose.Slides على حل سحابي مع مضيف Windows. على سبيل المثال، لدى [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) قيود على العملية وتؤدي إلى مشاكل أثناء عملية تصدير PDF (انظر [هذا](https://github.com/projectkudu/kudu/wiki/Azure-Web-App-sandbox#unsupported-frameworks)). استخدام Aspose.Slides لـ .NET6 يحل هذه المشكلة.

## استخدام حزمة System.Drawing.Common وفئات Slides لـ .NET6 (خطأ CS0433: النوع موجود في كلٍ من Slides و System.Drawing.Common)

أحيانًا، يجب استخدام كل من تبعيات System.Drawing و Slides لـ .NET6 في مشروع (على سبيل المثال، عندما يعتمد مشروع .NET6 على حزم أخرى، والتي بدورها تعتمد على System.Drawing). قد يؤدي ذلك إلى أخطاء تعقيد مثل هذه:

* CS0433: النوع 'Image' موجود في كلٍ من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0
* CS0433: النوع 'Graphics' موجود في كلٍ من 'Aspose.Slides, Version=23.2.0.0, Culture=neutral, PublicKeyToken=716fcc553a201e56' و 'System.Drawing.Common, Version=6.0.0.0

في هذه الحالة، يمكنك استخدام [extern alias](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/extern-alias) لـ Aspose.Slides (الإصدار أقل من 24.8):
1) اختر مجموعة Aspose.Slides من تبعيات المشروع ثم انقر على **Properties**.
  ![خصائص حزمة Aspose Slides](package_properties.png)
2) حدد اسمًا مستعارًا (على سبيل المثال، \"Slides\").
  ![اسم مستعار لـ Aspose Slides](set_alias.png)

الآن، سيتم استخدام الأنواع من System.Drawing.Common بشكل افتراضي. يجب تحديد اسم المستعار للمجمع الخارجي حيثما تحتاج إلى أنواع Aspose.Slides.
```c#
extern alias Slides;
using Slides::Aspume.Slides;
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


بدءًا من الإصدار 24.8، تم إزالة واجهة برمجة التطبيقات العامة المتقادمة التي تعتمد على System.Drawing. فيما يتعلق بمثال الكود أعلاه، يمكنك الحصول على صورة الشريحة كما هو موضح أدناه.
```cs
static Aspose.Slides.IImage GetThumbnail(Presentation presentation)
{
    return presentation.Slides[0].GetImage();
}
```

يتم وصف واجهة برمجة التطبيقات الجديدة بمزيد من التفصيل في [Modern API](/net/modern-api/).