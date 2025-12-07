---
title: تصدير العروض التقديمية إلى XAML بـ C++
linktitle: العرض التقديمي إلى XAML
type: docs
weight: 30
url: /ar/cpp/export-to-xaml/
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
- حفظ PPT كـ XAML
- حفظ PPTX كـ XAML
- حفظ ODP كـ XAML
- تصدير PPT إلى XAML
- تصدير PPTX إلى XAML
- تصدير ODP إلى XAML
- C++
- Aspose.Slides
description: "تحويل شرائح PowerPoint و OpenDocument إلى XAML في C++ باستخدام Aspose.Slides—حل سريع بدون Office يحافظ على تخطيطك دون تعديل."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/)، تم تنفيذ دعم تصدير XAML. يمكنك الآن تصدير العروض التقديمية الخاصة بك إلى XAML. 

{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي هي لغة تستند إلى XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، ولكن لا يزال بإمكانك كتابة وتحرير واجهة المستخدم الرسومية الخاصة بك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

يعرض لك هذا الكود C++ كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار خيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي الخاص بك إلى XAML. 

على سبيل المثال، إذا أردت أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تمرير true إلى طريقة [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). راجع هذا المثال من الكود C++: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **الأسئلة المتكررة**

**كيف يمكنني ضمان خطوط متوقعة إذا لم يتوفر الخط الأصلي على الجهاز؟**

استخدم [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — يتم استخدامه كخط احتياطي عندما يكون الخط الأصلي غير موجود. يساعد ذلك في تجنب الاستبدالات غير المتوقعة.

**هل XAML المُصدَّر مخصص فقط لـ WPF، أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف واجهة مستخدم عامة تُستخدم في WPF وUWP وXamarin.Forms. يهدف التصدير إلى التوافق مع أطر XAML من مايكروسوفت؛ السلوك الدقيق ودعم التركيبات المحددة يعتمد على المنصة المستهدفة. اختبر التعليمات البرمجية في بيئتك.

**هل يتم دعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بشكل افتراضي، لا يتم تضمين الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — أبقِه معطلًا إذا لم تحتاج لتصديرها.