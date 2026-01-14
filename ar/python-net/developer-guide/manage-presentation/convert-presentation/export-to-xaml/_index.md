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
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في Python باستخدام Aspose.Slides — حل سريع وخالي من Office يحافظ على تخطيطك دون تغيير."
---

## **نظرة عامة**

{{% alert title="Info" color="info" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), تمكنا من إضافة دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خصوصًا تلك التي تستخدم WPF (Windows Presentation Foundation) أو UWP (Universal Windows Platform) أو Xamarin Forms.  

XAML، وهي لغة تعتمد على XML، هي النسخة الخاصة بمايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم المصمم للعمل على ملفات XAML في معظم الأوقات، لكن لا يزال بإمكانك كتابة وتحرير واجهتك الرسومية. 

## **تصدير العروض التقديمية إلى XAML باستخدام الإعدادات الافتراضية**

يعرض لك هذا الشيفرة بلغة Python كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات المخصصة**

يمكنك اختيار الخيارات من الفئة [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) التي تتحكم في عملية التصدير وتحدد كيف تقوم Aspose.Slides بتصدير عرضك التقديمي إلى XAML. 

على سبيل المثال، إذا كنت ترغب في أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك عند تصديره إلى XAML، يمكنك تعيين الخاصية [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) إلى `True`. راجع مثال الشيفرة التالي بلغة Python: 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

قم بتعيين الخاصية [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) في الفئة [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — تُستخدم كخط احتياطي عندما يكون الخط الأصلي غير موجود. هذا يساعد على تجنب الاستبدالات غير المتوقعة.

**هل يُقصد بالـ XAML المُصدَّر أن يُستخدم فقط في WPF، أم يمكن استعماله في أنماط XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يستهدف التصدير التوافق مع أنماط XAML التي تقدمها مايكروسوفت؛ السلوك الدقيق والدعم للبُنى المحددة يعتمد على منصة الهدف. اختبر الشيفرة في بيئتك.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر الخاصية [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) في الفئة [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — أبقها معطلة إذا لم تكن بحاجة لتصديرها.