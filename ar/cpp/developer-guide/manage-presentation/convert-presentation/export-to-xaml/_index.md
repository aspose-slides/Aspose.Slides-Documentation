---
title: تصدير العروض التقديمية إلى XAML في C++
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML في C++ باستخدام Aspose.Slides—حل سريع وخالٍ من Office يحافظ على تخطيطك دون تغيير."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

## **حول XAML**

XAML هو لغة برمجة وصفية تسمح لك بإنشاء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة مبنية على XML، هي نسخة مايكروسوفت لتوصيف واجهة المستخدم الرسومية. من المرجح أنك تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، لكن لا يزال بإمكانك كتابة وتحرير واجهتك الرسومية. 

## **تصدير العروض التقديمية إلى XAML باستخدام الإعدادات الافتراضية**

هذا الكود C++ يوضح لك كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك التقديمي إلى XAML. 

على سبيل المثال، إذا كنت تريد أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تمرير true إلى طريقة [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). راجع هذا المثال من كود C++: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط قابلة للتنبؤ إذا لم يكن الخط الأصلي متوفرًا على الجهاز؟**

استخدم [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك على تجنب الاستبدالات غير المتوقعة.

**هل XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هو لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. تستهدف عملية التصدير التوافق مع أطر XAML من مايكروسوفت؛ السلوك الدقيق ودعم البُنى المحددة يعتمد على منصة الهدف. اختبر العلامات في بيئتك.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا تُضمن الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — احتفظ به معطَّلًا إذا لم تكن بحاجة لتصديرها.