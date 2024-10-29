---
title: تصدير إلى XAML
type: docs
weight: 30
url: /ar/net/export-to-xaml/
keywords: "تصدير عرض PowerPoint، تحويل PowerPoint، XAML، PowerPoint إلى XAML، PPT إلى XAML، PPTX إلى XAML، C#، Csharp، .NET"
description: "تصدير أو تحويل عرض PowerPoint إلى XAML"
---

# تصدير العروض إلى XAML

{{% alert title="معلومات" color="info" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك إلى XAML. 

{{% /alert %}} 

# عن XAML

XAML هو لغة برمجة وصفية تسمح لك بإنشاء أو كتابة واجهات المستخدم للتطبيقات، وخاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وأشكال Xamarin.  

XAML، التي هي لغة قائمة على XML، هي النسخة الخاصة بـ Microsoft لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML في معظم الأوقات، لكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الخاصة بك. 

## تصدير العروض إلى XAML مع الخيارات الافتراضية

هذا الكود C# يوضح لك كيفية تصدير عرض إلى XAML مع الإعدادات الافتراضية:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## تصدير العروض إلى XAML مع خيارات مخصصة

يمكنك اختيار خيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعروضك إلى XAML. 

على سبيل المثال، إذا كنت تريد من Aspose.Slides إضافة الشرائح المخفية من عرضك عند تصديرها إلى XAML، يمكنك تعيين خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) على true. راجع هذا الكود C# كمثال:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```