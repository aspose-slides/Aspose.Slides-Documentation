---
title: الخط الافتراضي
type: docs
weight: 30
url: /ar/cpp/default-font/
keywords: 
- خط
- خط افتراضي
- تقديم العرض
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides لـ C++
description: يتيح لك واجهة برمجة التطبيقات PowerPoint C++ تعيين الخط الافتراضي لتقديم العروض إلى PDF و XPS أو الصور المصغرة
---

## **تعيين الخط الافتراضي**
باستخدام Aspose.Slides لـ C++ يمكنك تعيين الخط الافتراضي في عروض PowerPoint التقديمية. تم إضافة طريقة جديدة [set_DefaultRegularFont()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_save_options/#a9df129ea6e65c8196e08173799a10492) إلى [**SaveOptions**](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.save_options/) class. يمكّنك ذلك من تعيين الخط الافتراضي المستخدم بدلاً من جميع الخطوط المفقودة أثناء حفظ العروض التقديمية إلى تنسيقات مختلفة دون إعادة تحميل العروض.

توضح مقطع الكود أدناه عملية حفظ العرض إلى [HTML](https://docs.fileformat.com/web/html/) و[PDF](https://docs.fileformat.com/pdf/) بخط افتراضي عادي مختلف.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SetDefaultFont-SetDefaultFont.cpp" >}}


## **استخدام الخطوط الافتراضية لتقديم العرض**
تتيح لك Aspose.Slides تعيين الخط الافتراضي لتقديم العرض إلى PDF و XPS أو الصور المصغرة. توضح هذه المقالة كيفية تعريف DefaultRegular
Font و DefaultAsian Font لاستخدامهما كخطوط افتراضية. يرجى اتباع الخطوات أدناه لتحميل الخطوط من الدلائل الخارجية باستخدام واجهة برمجة التطبيقات Aspose.Slides لـ C++:

1. إنشاء مثيل من LoadOptions.
1. تعيين DefaultRegularFont إلى الخط المطلوب. في المثال التالي، استخدمت Wingdings.
1. تعيين DefaultAsianFont إلى الخط المطلوب. لقد استخدمت Wingdings في المثال التالي.
1. تحميل العرض باستخدام Presentation وتعيين خيارات التحميل.
1. الآن، قم بإنشاء صورة مصغرة للشريحة، وPDF وXPS للتحقق من النتائج.

تم تنفيذ ما سبق على النحو التالي.

```cpp
// استخدم خيارات التحميل لتحديد الخطوط العادية والآسيوية الافتراضية
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```