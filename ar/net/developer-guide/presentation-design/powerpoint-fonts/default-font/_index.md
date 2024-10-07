---
title: الخط الافتراضي - واجهة برمجة تطبيقات PowerPoint C#
linktitle: الخط الافتراضي
type: docs
weight: 30
url: /net/default-font/
keywords: 
- خط
- خط افتراضي
- تقديم العرض
- PowerPoint
- عرض
- C#
- Csharp
- Aspose.Slides for .NET
description: تتيح لك واجهة برمجة تطبيقات PowerPoint C# تعيين الخط الافتراضي لعرض العروض التقديمية إلى PDF أو XPS أو الصور المصغرة
---

## **استخدام الخطوط الافتراضية لتقديم العرض**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لتقديم العرض إلى PDF أو XPS أو الصور المصغرة. توضح هذه المقالة كيفية تعريف DefaultRegular Font و DefaultAsian Font للاستخدام كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من الأدلة الخارجية باستخدام واجهة برمجة تطبيقات Aspose.Slides for .NET:

1. أنشئ مثيلًا من LoadOptions.
1. قم بتعيين DefaultRegularFont إلى الخط المرغوب فيه. في المثال التالي، استخدمت Wingdings.
1. قم بتعيين DefaultAsianFont إلى الخط المرغوب فيه. لقد استخدمت Wingdings في المثال التالي.
1. قم بتحميل العرض التقديمي باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بإنشاء الصورة المصغرة للشرائح، PDF و XPS للتحقق من النتائج.

تتمثل تنفيذ ما سبق أدناه.

```c#
// استخدم خيارات التحميل لتحديد الخطوط الافتراضية العادية والآسيوية
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```