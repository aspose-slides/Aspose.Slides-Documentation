---
title: تصدير العروض التقديمية إلى XAML باستخدام بايثون
linktitle: تصدير إلى XAML
type: docs
weight: 30
url: /ar/python-net/export-to-xaml/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل عرض تقديمي
- PowerPoint إلى XAML
- OpenDocument إلى XAML
- عرض تقديمي إلى XAML
- PPT إلى XAML
- PPTX إلى XAML
- ODP إلى XAML
- Python
- Aspose.Slides
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML في بايثون باستخدام Aspose.Slides—حل سريع وخالٍ من Office يحافظ على تخطيطك دون تغيير."
---

## **نظرة عامة**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة تعتمد على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم المصمم للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتعديل واجهتك الرسومية. 

## **تصدير العروض التقديمية إلى XAML مع الخيارات الافتراضية**

هذا الكود Python يوضح لك كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **تصدير العروض التقديمية إلى XAML مع خيارات مخصصة**

يمكنك اختيار الخيارات من فئة [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) التي تتحكم في عملية التصدير وتحدد كيف تقوم Aspose.Slides بتصدير العرض التقديمي إلى XAML. 

على سبيل المثال، إذا أردت أن تقوم Aspose.Slides بإضافة الشرائح المخفية من العرض التقديمي عند تصديره إلى XAML، يمكنك تعيين الخاصية [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) إلى `True`. راجع هذا مثال كود Python:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط متوقعة إذا كان الخط الأصلي غير متاح على الجهاز؟**

قم بتعيين [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) في [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي غير متوفر. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل XAML المصدّر مخصص فقط لـ WPF، أم يمكن استخدامه في أكوام XAML أخرى أيضاً؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يستهدف التصدير التوافق مع مجموعات XAML من مايكروسوفت؛ السلوك الدقيق ودعم البُنى المحددة يعتمد على المنصة المستهدفة. اختبر العلامات في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُدرج الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) في [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — احتفظ به معطلاً إذا لم تحتاج إلى تصديرها.