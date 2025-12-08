---
title: تصدير العروض التقديمية إلى XAML باستخدام Python
linktitle: تصدير إلى XAML
type: docs
weight: 30
url: /ar/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في Python باستخدام Aspose.Slides—حل سريع خالٍ من Office يحافظ على تخطيطك دون تغيير."
---

## **نظرة عامة**

{{% alert title="معلومات" color="info" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/)، قمنا بإضافة دعم تصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي تعتمد على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم المصمم للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتحرير واجهتك الرسومية يدوياً. 

## **تصدير العروض التقديمية إلى XAML باستخدام الإعدادات الافتراضية**

يوضح لك هذا الكود بلغة Python كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من الواجهة [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) التي تتحكم في عملية التصدير وتحدد كيف تقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML. 

على سبيل المثال، إذا كنت تريد أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تعيين الخاصية [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) إلى true. راجع مثال الكود التالي بلغة Python: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان استقرار الخطوط إذا لم يكن الخط الأصلي متاحاً على الجهاز؟**

قم بتعيين [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) في [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — يُستخدم كخط احتياطي عندما يكون الخط الأصلي غير موجود. يساعد ذلك في تجنب الاستبدالات غير المتوقعة.

**هل يُقصد من XAML المصدَّر أنه مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF، UWP، وXamarin.Forms. يستهدف التصدير التوافق مع أطر Microsoft XAML؛ السلوك الدقيق والدعم للبنى المحددة يعتمد على منصة الهدف. اختبر التعليمات البرمجية في بيئتك.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) في [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — أبقِها معطَّلة إذا لم تكن بحاجة لتصديرها.