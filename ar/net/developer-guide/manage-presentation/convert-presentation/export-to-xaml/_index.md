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
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML في .NET باستخدام Aspose.Slides—حل سريع خالٍ من Office يحافظ على تخطيطك دون تغيير."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert title="Info" color="info" %}} 
في [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/)، أضفنا دعمًا لتصدير XAML. يمكنك الآن تصدير العروض التقديمية إلى XAML. 
{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تسمح لك بإنشاء أو كتابة واجهات المستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة مبنية على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المرجح أن تستخدم مصممًا للعمل على ملفات XAML في معظم الأوقات، لكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الخاصة بك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يُظهر لك هذا الكود C# كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي إلى XAML. 

على سبيل المثال، إذا كنت تريد أن تضيف Aspose.Slides الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تعيين خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) إلى true. راجع هذا مثال الكود C#:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يتوفر الخط الأصلي على الجهاز؟**

قم بتعيين [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي غير موجود. يساعد ذلك في تجنب الاستبدالات غير المتوقعة.

**هل XAML المصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في مجموعات XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يهدف التصدير إلى التوافق مع مجموعات XAML من مايكروسوفت؛ السلوك الدقيق ودعم العناصر المحددة يعتمد على المنصة المستهدفة. اختبر العلامات في بيئتك.

**هل تُدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

بشكل افتراضي، لا تُضمن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — احتفظ به معطلًا إذا لم تكن بحاجة إلى تصديرها.