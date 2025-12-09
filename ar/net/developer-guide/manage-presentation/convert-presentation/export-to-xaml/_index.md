---
title: تصدير العروض التقديمية إلى XAML في .NET
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/net/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- العرض التقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- .NET
- C#
- Aspose.Slides
description: تحويل شرائح PowerPoint و OpenDocument إلى XAML في .NET باستخدام Aspose.Slides—حل سريع بدون Office يحافظ على تنسيقك.
---

# **تصدير العروض التقديمية إلى XAML**

{{% alert title="Info" color="info" %}} 

في Aspose.Slides 21.6، قمنا بتنفيذ دعم تصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

# **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة مبنية على XML، هي النسخة الخاصة بمايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، لكن يمكنك أيضًا كتابة وتحرير واجهتك الرسومية يدويًا. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يعرض لك هذا الكود C# كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار خيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي إلى XAML. 

على سبيل المثال، إذا كنت تريد أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تعيين الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) إلى true. انظر هذا المثال من كود C#:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **الأسئلة المتداولة**

**كيف يمكنني ضمان خطوط ثابتة إذا كان الخط الأصلي غير متوفر على الجهاز؟**

قم بتعيين [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل XAML المصدر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف عامة لواجهة المستخدم تُستخدم في WPF وUWP وXamarin.Forms. هدف التصدير هو التوافق مع أطر Microsoft XAML؛ السلوك الدقيق والدعم للتركيبات المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — أبقِها غير مفعلة إذا لم تحتاج إلى تصديرها.