---
title: تصدير إلى XAML
type: docs
weight: 30
url: /ar/net/export-to-xaml/
keywords: "تصدير عرض PowerPoint, تحويل PowerPoint, XAML, PowerPoint إلى XAML, PPT إلى XAML, PPTX إلى XAML, C#, Csharp, .NET"
description: "تصدير أو تحويل عرض PowerPoint إلى XAML"
---

# **تصدير العروض التقديمية إلى XAML**

{{% alert title="Info" color="info" %}} 
في [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 
{{% /alert %}} 

# **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات مستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة قائمة على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المرجح أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتحرير واجهتك الرسومية. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يعرض لك هذا الكود المكتوب بـ C# كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات المخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي إلى XAML. 

على سبيل المثال، إذا كنت ترغب في أن تقوم Aspose.Slides بإضافة الشرائح المخفية من العرض التقديمي عند تصديره إلى XAML، يمكنك تعيين الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) إلى true. راقب هذا المثال المكتوب بـ C#:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يتوفر الخط الأصلي على الجهاز؟**  
قم بتعيين [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك في تجنب الاستبدالات غير المتوقعة.  

**هل يُقصد بـ XAML المُصدّر فقط لـ WPF، أم يمكن استخدامها في مجموعات XAML أخرى أيضًا؟**  
XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يهدف التصدير إلى التوافق مع مجموعات XAML الخاصة بمايكروسوفت؛ السلوك الدقيق ودعم البُنى المحددة يعتمد على المنصة المستهدفة. اختبر العلامات في بيئتك.  

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**  
بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — احفظه معطلاً إذا لم تكن بحاجة إلى تصديرها.