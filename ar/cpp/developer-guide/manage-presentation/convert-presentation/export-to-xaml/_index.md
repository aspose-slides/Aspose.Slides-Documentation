---
title: تصدير العروض التقديمية إلى XAML في C++
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
description: "تحويل شرائح PowerPoint وOpenDocument إلى XAML باستخدام C++ وAspose.Slides—حل سريع لا يحتاج إلى Office ويحافظ على تنسيق التصميم."
---

## **تصدير العروض التقديمية إلى XAML**

{{% alert color="primary" %}} 

في Aspose.Slides 21.6، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

## **حول XAML**

XAML هي لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصةً تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin Forms.  

XAML، التي تعتمد على XML، هي النسخة الخاصة بمايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم أداة التصميم للعمل على ملفات XAML معظم الوقت، لكن يمكنك أيضًا كتابة وتعديل واجهة المستخدم بنفسك. 

## **تصدير العروض التقديمية إلى XAML باستخدام الخيارات الافتراضية**

هذا الكود بلغة C++ يوضح لك كيفية تصدير عرض تقديمي إلى XAML باستخدام الإعدادات الافتراضية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **تصدير العروض التقديمية إلى XAML باستخدام خيارات مخصصة**

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides للعرض التقديمي الخاص بك إلى XAML. 

على سبيل المثال، إذا كنت تريد أن يضيف Aspose.Slides الشرائح المخفية من عرضك التقديمي عند تصديره إلى XAML، يمكنك تمرير القيمة true إلى طريقة [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). راجع هذا المثال بلغة C++: 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **الأسئلة الشائعة**

**كيف يمكنني ضمان خطوط predictable إذا كانت الخطوط الأصلية غير متوفرة على الجهاز؟**

استخدم [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) في [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — يتم استخدامها كخط احتياطي عندما يكون الخط الأصلي مفقودًا. يساعد ذلك على تجنب استبدالات غير متوقعة.

**هل XAML المُصدّر مخصص فقط لـ WPF أم يمكن استخدامه في أطر XAML أخرى أيضًا؟**

XAML هي لغة توصيف عامة لواجهة المستخدم تُستخدم في WPF وUWP وXamarin.Forms. يستهدف التصدير التوافق مع أطر Microsoft XAML؛ والسلوك الدقيق والدعم للبُنى المحددة يعتمد على النظام المستهدف. اختبر العلامات في بيئتك.

**هل تدعم الشرائح المخفية، وكيف يمكنني منع تصديرها بشكل افتراضي؟**

بح默认، لا يتم تضمين الشرائح المخفية. يمكنك التحكم في هذا السلوك عبر [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) في [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — احتفظ به معطلاً إذا لم تكن بحاجة لتصديرها.