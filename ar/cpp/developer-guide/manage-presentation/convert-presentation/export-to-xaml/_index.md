---
title: تصدير إلى XAML
type: docs
weight: 30
url: /cpp/export-to-xaml/

---

# تصدير العروض التقديمية إلى XAML

{{% alert color="primary" %}} 

في [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/)، قمنا بتنفيذ دعم لتصدير XAML. يمكنك الآن تصدير عروضك التقديمية إلى XAML. 

{{% /alert %}} 

# حول XAML

XAML هو لغة برمجة وصفية تتيح لك بناء أو كتابة واجهات المستخدم للتطبيقات، خاصة تلك التي تستخدم WPF (Windows Presentation Foundation) وUWP (Universal Windows Platform) وXamarin forms.  

XAML، وهي لغة قائمة على XML، هي نسخة مايكروسوفت لوصف واجهة المستخدم الرسومية. من المحتمل أن تستخدم مصممًا للعمل على ملفات XAML معظم الوقت، لكن يمكنك أيضًا كتابة وتحرير واجهة المستخدم الخاصة بك. 

## تصدير العروض التقديمية إلى XAML مع الخيارات الافتراضية

يوضح هذا الكود C++ كيفية تصدير عرض تقديمي إلى XAML مع الإعدادات الافتراضية:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## تصدير العروض التقديمية إلى XAML مع خيارات مخصصة

يمكنك اختيار خيارات من واجهة [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) التي تتحكم في عملية التصدير وتحدد كيفية تصدير Aspose.Slides لعرضك التقديمي إلى XAML. 

على سبيل المثال، إذا كنت ترغب في أن تقوم Aspose.Slides بإضافة الشرائح المخفية من عرضك التقديمي عند تصديرها إلى XAML، يمكنك تمرير true إلى دالة [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). انظر هذا المثال من كود C++: 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```