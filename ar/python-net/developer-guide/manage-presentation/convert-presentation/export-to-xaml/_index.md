---
title: تصدير إلى XAML
type: docs
weight: 30
url: /ar/python-net/export-to-xaml/
keywords: "تصدير عرض PowerPoint، تحويل PowerPoint، XAML، PowerPoint إلى XAML، PPT إلى XAML، PPTX إلى XAML، بايثون"
description: "تصدير أو تحويل عرض PowerPoint إلى XAML"
---

# تصدير العروض إلى XAML

{{% alert title="معلومات" color="info" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك إلى XAML. 

{{% /alert %}} 

# حول XAML

XAML هي لغة برمجة وصفية تسمح لك بإنشاء أو كتابة واجهات مستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin forms.  

XAML، التي هي لغة قائمة على XML، هي النسخة الخاصة بشركة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، ولكن يمكنك أيضًا كتابة وتحرير واجهة المستخدم الخاصة بك. 

## تصدير العروض إلى XAML باستخدام الخيارات الافتراضية

هذا الرمز بلغة بايثون يوضح لك كيفية تصدير عرض إلى XAML باستخدام الإعدادات الافتراضية:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## تصدير العروض إلى XAML باستخدام خيارات مخصصة

يمكنك اختيار الخيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعروضك إلى XAML. 

على سبيل المثال، إذا كنت تريد من Aspose.Slides إضافة الشرائح المخفية من عرضك عند تصديره إلى XAML، يمكنك تعيين خاصية [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) إلى true. انظر هذا الرمز كمثال بلغة بايثون: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```