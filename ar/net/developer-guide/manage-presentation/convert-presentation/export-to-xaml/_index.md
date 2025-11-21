---
title: تصدير العروض التقديمية إلى XAML في .NET
linktitle: العرض إلى XAML
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
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في .NET باستخدام Aspose.Slides—حل سريع لا يتطلب Office ويحافظ على تنسيقك الأصلي."
---

# **تصدير العروض التقديمية إلى XAML**

{{% alert title="Info" color="info" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/)، نفّذنا دعم تصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

# **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي تعتمد على XML، هي نسخة مايكروسوفت لتوصيف واجهة المستخدم الرسومية. من المحتمل أن تستخدم أداة التصميم للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتعديل واجهة المستخدم بنفسك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الإعدادات الافتراضية**

هذا الكود C# يوضح لك كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) التي تتحكم في عملية التصدير وتحدد كيف يقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML. 

على سبيل المثال، إذا رغبت في أن يضيف Aspose.Slides الشرائح المخفية من عرضك عند تصديره إلى XAML، يمكنك ضبط الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) على true. راجع مثال الكود C# التالي: 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يتوفر الخط الأصلي على الجهاز؟**

قم بتعيين [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — يستخدم كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد هذا على تجنب الاستبدالات غير المتوقعة.

**هل XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في أنظمة XAML أخرى كذلك؟**

XAML هي لغة توصيف واجهات عامة تُستخدم في WPF وUWP وXamarin.Forms. هدف التصدير هو التوافق مع أنظمة مايكروسوفت XAML؛ السلوك والدعم للتراكيب المحددة يعتمد على المنصة المستهدفة. اختبر التعليمات البرمجية في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — أبقه معطَّلًا إذا لم تكن بحاجة إلى تصديرها.