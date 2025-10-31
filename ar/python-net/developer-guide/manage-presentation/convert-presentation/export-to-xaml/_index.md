---
title: تصدير العروض التقديمية إلى XAML باستخدام Python
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
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML في Python باستخدام Aspose.Slides—حل سريع وخالٍ من Office يافظ على تخطيطك كما هو."
---

## **نظرة عامة**

{{% alert title="معلومات" color="info" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/)، قمنا بتنفيذ دعم تصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة تعتمد على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم. من المحتمل أن تستخدم أداة التصميم للعمل على ملفات XAML معظم الوقت، ولكن يمكنك أيضاً كتابة وتحرير واجهتك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

هذا الكود Python يوضح لك كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions] التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك إلى XAML. 

على سبيل المثال، إذا كنت ترغب في أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك عند تصديره إلى XAML، يمكنك ضبط خاصية [ExportHiddenSlides] على true. انظر هذا المثال من كود Python: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يكن الخط الأصلي متاحًا على الجهاز؟**

قم بتعيين [default_regular_font] في [XamlOptions] — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي غير موجود. هذا يساعد على تجنب الاستبدالات غير المتوقعة.

**هل XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في تقنيات XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يستهدف التصدير التوافق مع مجموعات XAML التابعة لمايكروسوفت؛ السلوك الدقيق ودعم البُنى المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها افتراضيًا؟**

افتراضيًا، لا تُضمّن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [export_hidden_slides] في [XamlOptions] — أبقِها مُعطّلة إذا لم تكن بحاجة لتصديرها.