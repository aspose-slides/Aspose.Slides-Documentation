---
title: تحويل عروض PowerPoint التقديمية إلى GIF متحرك في C++
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/cpp/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- العرض التقديمي إلى GIF
- الشريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "يمكنك بسهولة تحويل عروض PowerPoint (PPT، PPTX) إلى GIF متحرك باستخدام Aspose.Slides للغة C++. نتائج سريعة وعالية الجودة."
---

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات الافتراضية**

يُظهر لك هذا المثال البرمجي بلغة C++ كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام الإعدادات القياسية:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```


سيتم إنشاء GIF المتحرك باستخدام المعلمات الافتراضية.

{{%  alert  title="TIP"  color="primary"  %}} 
إذا كنت تفضّل تخصيص معلمات الـ GIF، يمكنك استخدام الفئة [GifOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.gif_options). راجع مثال الشيفرة أدناه. 
{{% /alert %}} 

## **تحويل العروض التقديمية إلى GIF متحرك باستخدام الإعدادات المخصصة**

يعرض لك هذا المثال البرمجي كيفية تحويل عرض تقديمي إلى GIF متحرك باستخدام إعدادات مخصصة في C++:
``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// حجم GIF الناتج 
gifOptions->set_FrameSize(Size(960, 720));
// مدة عرض كل شريحة قبل الانتقال إلى التالية
gifOptions->set_DefaultDelay(2000);
// زيادة عدد الإطارات في الثانية لتحسين جودة انتقال الرسوم المتحركة
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```


{{% alert title="Info" color="info" %}}
قد ترغب في تجربة أداة تحويل مجانية من النص إلى GIF [Text to GIF](https://products.aspose.app/slides/text-to-gif) التي طورتها شركة Aspose. 
{{% /alert %}}

## **الأسئلة المتداولة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض التقديمي مثبتة على النظام؟**

قم بتثبيت الخطوط الناقصة أو [قم بإعداد خطوط بديلة](/slides/ar/cpp/powerpoint-fonts/). سيستبدل Aspose.Slides الخطوط، لكن قد يختلف الشكل. بالنسبة للهوية التجارية، احرص دائمًا على توفّر الخطوط المطلوبة صراحةً.

**هل يمكنني إضافة علامة مائية فوق إطارات الـ GIF؟**

نعم. [أضف كائنًا/شعارًا شبه شفاف](/slides/ar/cpp/watermark/) إلى الشريحة الأساسية أو إلى الشرائح الفردية قبل التصدير — ستظهر العلامة المائية في كل إطار.